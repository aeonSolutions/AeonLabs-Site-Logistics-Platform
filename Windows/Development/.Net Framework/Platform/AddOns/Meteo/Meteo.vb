Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Gui.Forms.Core
Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json

Public Class meteo_frm
    Private msgbox As messageBoxForm
    Private stateCore As environmentVars
    Private translations As languageTranslations
    public property mainForm as MainMdiForm

    Private WithEvents HttpDataRequestOpenWeather As HttpDataGetData
    Private WithEvents HttpDataRequest As HttpDataPostData

    Private works_site As Dictionary(Of String, List(Of String))
    Dim loaded As Boolean = False

    'TODO split into a abstract class for reuse outside this FORM - see translation class

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New(stateIni As environmentVars, _mainmdiform As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        stateCore = stateIni
        mainForm = _mainmdiform

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        If Not stateCore.addonsLoaded OrElse Not stateCore.addons.ContainsKey("weather") Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorWeatherAddonNotFound") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mainForm.busy.Close(True)
            Exit Sub
        End If
    End Sub

    Private Sub meteo_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)
        Me.SuspendLayout()

        select_location_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        city_txt.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        meteo_txt.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        descricao_txt.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_combo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        translations.load("busyMessages")
        meteo_txt.Text = translations.getText("commServer")
        translations.load("meteorology")
        select_location_lbl.Text = translations.getText("location")
        city_txt.Text = ""
        descricao_txt.Text = ""

    End Sub

    Private Sub meteo_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
    End Sub

    Sub load_list()
        Dim vars As New Dictionary(Of String, String)

        vars.Add("task", stateCore.taskId("queries"))
        vars.Add("request", "sites")

        HttpDataRequest = New HttpDataPostData()
        HttpDataRequest.initialize()
        HttpDataRequest.loadQueue(vars, Nothing, Nothing)
        HttpDataRequest.startRequest()
    End Sub

    Private Sub HttpDataRequest_dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String)) Handles HttpDataRequest.dataArrived
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        If Not IsResponseOk(requestData) Then
            errorMsg = GetMessage(requestData)
            errorFlag = True
            GoTo lastLine
        End If
        works_site = HttpDataRequest.ConvertDataToArray("sites", stateCore.querySiteFields, requestData)
        If IsNothing(works_site) Then
            errorMsg = HttpDataRequest.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If errorMsg Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("commonForm")
        site_combo.Items.Clear()
        site_combo.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_site.Item("name").Count - 1
            site_combo.Items.Add(works_site.Item("name")(i))
        Next
        site_combo.SelectedIndex = 0

        mainForm.busy.Close(True)
    End Sub


    Private Sub site_combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles site_combo.SelectedIndexChanged
        If stateCore.addons("translation")("name").Equals("openWeather") Then
            loadOpenWeather()
        End If
    End Sub

    Sub loadOpenWeather()
        'http://api.openweathermap.org/data/2.5/weather?appid=7c18fcf0c019a0859fc974d45f6f9d29&units=metric&lang={lang}&lat={latitude}&lon={longitude}
        'MISSING
        'metrics
        'API KEY

        mainForm.busy.Show()

        Dim latitude As String = ""
        Dim longitude As String = ""

        If (site_combo.SelectedIndex > 0) Then
            latitude = works_site.Item("gps_lat")(site_combo.SelectedIndex - 1)
            longitude = works_site.Item("gps_lon")(site_combo.SelectedIndex - 1)
        Else
            latitude = stateCore.locationData.latitude
            longitude = stateCore.locationData.longitude
        End If

        Dim url As String = stateCore.addons.Item("weather")("url").Replace("{lang}", stateCore.currentLang).Replace("{latitude}", latitude).Replace("{longitude}", longitude).Replace("{key}", stateCore.addons("weather")("key"))


        HttpDataRequestOpenWeather = New HttpDataGetData(stateCore, url)
        HttpDataRequestOpenWeather.initialize()
        HttpDataRequestOpenWeather.loadQueue(Nothing, Nothing, Nothing)
        HttpDataRequestOpenWeather.startRequest()
    End Sub

    Private Sub httpDataRequestOpenWeather_dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String)) Handles HttpDataRequestOpenWeather.dataArrived
        Dim jsonResult As Dictionary(Of String, Object)

        Try
            jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(requestData)
        Catch ex As Exception
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(requestData), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            mainForm.busy.Close(True)
            Exit Sub
        End Try

        Dim icon As String = ""
        Try
            Dim subResponse As String = jsonResult.Item("weather").ToString.Replace("[", "").Replace("]", "")
            Dim jsonSubResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(subResponse)
            Dim id As String = jsonSubResult.Item("id")
            Dim main As String = jsonSubResult.Item("main")
            Dim description As String = jsonSubResult.Item("description")
            Dim TargetEncoding As Encoding = Encoding.GetEncoding("ISO-8859-1")
            Dim SourceEncoding As Encoding = Encoding.UTF8
            description = SourceEncoding.GetString(TargetEncoding.GetBytes(description))

            icon = jsonSubResult.Item("icon")

            subResponse = jsonResult.Item("main").ToString.Replace("[", "").Replace("]", "")
            jsonSubResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(subResponse)
            Dim temp As String = jsonSubResult.Item("temp")
            Dim pressure As String = jsonSubResult.Item("pressure")
            Dim humidity As String = jsonSubResult.Item("humidity")
            Dim tempMin As String = jsonSubResult.Item("temp_min")
            Dim tempMax As String = jsonSubResult.Item("temp_max")

            Dim vis As Long = Convert.ToUInt64(jsonResult.Item("visibility")) / 1000
            Dim visibility As String = vis.ToString
            Dim Cityname As String = jsonResult.Item("name")

            subResponse = jsonResult.Item("wind").ToString.Replace("[", "").Replace("]", "")
            jsonSubResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(subResponse)
            Dim windSpeed As String = jsonSubResult.Item("speed")
            Dim windDirection As String = jsonSubResult.Item("deg")

            subResponse = jsonResult.Item("sys").ToString.Replace("[", "").Replace("]", "")
            jsonSubResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(subResponse)

            Dim tz As TimeSpan = TimeSpan.FromSeconds(Convert.ToUInt64(jsonResult.Item("timezone")))
            Dim ts As TimeSpan = TimeSpan.FromSeconds(Convert.ToUInt64(jsonSubResult.Item("sunrise")))
            ts = ts + tz
            Dim sunrise As String = String.Format("{0:00}:{1:00}", Math.Floor(ts.Hours), ts.Minutes)
            ts = TimeSpan.FromSeconds(Convert.ToUInt64(jsonSubResult.Item("sunset")))
            ts = ts + tz
            Dim sunset As String = String.Format("{0:00}:{1:00}", Math.Floor(ts.Hours), ts.Minutes)


            city_txt.Text = Cityname
            descricao_txt.Text = description
            translations.load("meteorology")

            meteo_txt.Text = translations.getText("temperature") & ": " & temp & "°C  max: " & tempMax & "°C  min: " & tempMin & "°C" & Environment.NewLine _
                & translations.getText("humidity") & ": " & humidity & "%" & Environment.NewLine _
                & translations.getText("pressure") & ": " & pressure & " mb" & Environment.NewLine & Environment.NewLine _
                & translations.getText("visibility") & ": " & visibility & " km" & Environment.NewLine & Environment.NewLine _
                & translations.getText("wind") & ": " & windSpeed & " km/h" & Environment.NewLine _
                & translations.getText("windDirection") & ": " & windDirection & "°" & Environment.NewLine & Environment.NewLine _
                & translations.getText("sunrise") & ": " & sunrise & Environment.NewLine _
                & translations.getText("sunset") & ": " & sunset & Environment.NewLine

        Catch ex As Exception
            mainForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try

        Dim tClient As WebClient = New WebClient
        Try
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData("http://openweathermap.org/img/w/" & icon & ".png")))
            weather_pic.Image = tImage
        Catch ex As Exception
            translations.load("errorMessages")
            weather_pic.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("noweather.png"))
            mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
        End Try
        weather_pic.SizeMode = PictureBoxSizeMode.StretchImage

        mainForm.busy.Close(True)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class