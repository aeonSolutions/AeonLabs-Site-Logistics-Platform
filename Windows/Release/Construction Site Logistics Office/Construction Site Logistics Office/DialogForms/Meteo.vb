Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class meteo_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private works_site As Dictionary(Of String, List(Of String))
    Dim response As String
    Dim loaded As Boolean = False
    Private WithEvents bwSites As BackgroundWorker

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub meteo_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        Me.SuspendLayout()
         
         

        select_location_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        city_txt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        meteo_txt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        descricao_txt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_combo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
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
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sites")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub site_combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles site_combo.SelectedIndexChanged
        loadMeteo()

    End Sub

    Sub loadMeteo()
        'http://api.openweathermap.org/data/2.5/weather?appid=7c18fcf0c019a0859fc974d45f6f9d29&units=metric&lang={lang}&lat={latitude}&lon={longitude}
        'MISSING
        'metrics
        'API KEY

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim latitude As String = ""
        Dim longitude As String = ""

        If (site_combo.SelectedIndex > 0) Then
            latitude = works_site.Item("gps_lat")(site_combo.SelectedIndex - 1)
            longitude = works_site.Item("gps_lon")(site_combo.SelectedIndex - 1)
        Else
            latitude = state.latitude
            longitude = state.longitude
        End If
        If Not state.addonsLoaded OrElse Not state.addons.ContainsKey("weather") Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorWeatherAddonNotFound") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Exit Sub
        End If

        Dim url As String = state.addons.Item("weather").Replace("{lang}", state.currentLang).Replace("{latitude}", latitude).Replace("{longitude}", longitude)
        Dim request As New HttpData(state)
        Dim response As String = request.RequestExternalData(url)
        Dim jsonResult As Object = Nothing
        Try
            jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
        Catch ex As Exception
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
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
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try

        Dim tClient As WebClient = New WebClient
        Try
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData("http://openweathermap.org/img/w/" & icon & ".png")))
            weather_pic.Image = tImage
        Catch ex As Exception
            translations.load("errorMessages")
            weather_pic.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("noweather.png"))
            MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
        End Try
        weather_pic.SizeMode = PictureBoxSizeMode.StretchImage

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class