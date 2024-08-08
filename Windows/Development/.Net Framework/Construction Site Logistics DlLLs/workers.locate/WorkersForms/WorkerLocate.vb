﻿Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class workerLocateForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Public works_worker As Dictionary(Of String, List(Of String))

    Private response, response2 As String
    Private mask As PictureBox = Nothing
    Private WithEvents DataRequests As IDataWorkersLocateRequests
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    private mainForm As MainMdiForm

    Public Sub New(_mainMdiForm As MainMdiForm)
        mainForm = _mainMdiForm
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()

    End Sub


    Private Sub frm_locate_worker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        Me.SuspendLayout()

        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        workerGroupBox.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = stateCore.dividerColor
        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        seeInfo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        seeInfo.Text = translations.getText("viewInfoLink")
        translations.load("workers")
        workerGroupBox.Text = translations.getText("workerInfo")
        title.Text = translations.getText("locateWorkerTitle")

        photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
        photobox.SizeMode = PictureBoxSizeMode.StretchImage

        contents.Text = ""
        Me.ResumeLayout()
    End Sub

    Private Sub frm_locate_worker_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "workers.locate.dll", "workersLocateDataRequests"), IDataWorkersLocateRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        load_list()
    End Sub

    Sub load_list()
        mainForm.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "workers")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadWorkersLocateInitialData()
    End Sub

    Private Sub DataRequests_getResponseWorkersLocateInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseWorkersLocateInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", stateCore.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
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
        If errorFlag Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        listview_works.Items.Clear()
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            listview_works.Items.Add(works_worker.Item("name")(i))
        Next i

        mainForm.busy.Close(True)
        removeMask()
    End Sub


    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub removeMask()
        If loaded Then
            Exit Sub
        End If
        loaded = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        doSearchWorkers(0, True, False, works_worker, listview_works, searchbox.Text.ToString)
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles seeInfo.LinkClicked
        If listview_works.SelectedIndex > -1 Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("cod", works_worker.Item("cod_worker")(listview_works.SelectedIndex))
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.loadWorkersLocateData()
        End If
    End Sub

    Private Sub DataRequests_getResponseWorkersLocateData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseWorkersLocateData
        Dim response As String = args.responseData

        translations.load("workers")
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)
            contents.Text = jsonarray(0).Item("name").ToString & Environment.NewLine & Environment.NewLine _
                & translations.getText("contact") & ": " & jsonarray(0).Item("contacto").ToString & Environment.NewLine _
                & translations.getText("emergencyContact") & ": " & jsonarray(0).Item("emergencia").ToString & Environment.NewLine _
                & translations.getText("email") & ": " & jsonarray(0).Item("email").ToString & Environment.NewLine _
                & translations.getText("companyIdCard") & ": " & AddSpaces(jsonarray(0).Item("cartao").ToString, 3) & Environment.NewLine & Environment.NewLine _
                & translations.getText("todaySite") & ": " & Environment.NewLine & jsonarray(0).Item("site").ToString.Replace("[newline]", Environment.NewLine) & Environment.NewLine _
                & jsonarray(0).Item("address").ToString.Replace("[newline]", Environment.NewLine)

            If jsonarray(0).Item("photo").ToString.Equals("") Then
                photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
            Else
                photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
                photobox.SizeMode = PictureBoxSizeMode.StretchImage
                Dim tClient As WebClient = New WebClient
                Try
                    Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & jsonarray(0).Item("photo").ToString)))
                    photobox.Image = tImage
                Catch ex As Exception
                    photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
                    translations.load("errorMessages")
                    mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                photobox.SizeMode = PictureBoxSizeMode.StretchImage
            End If
            translations.load("workers")

            contents.Text = contents.Text & Environment.NewLine & Environment.NewLine & translations.getText("thisMonthAlreadyWorked") & ":" & Environment.NewLine
            If jsonarray(0).Item("sites") IsNot Nothing Then
                For Each sites In jsonarray(0).Item("sites")
                    contents.Text = contents.Text & sites.Item("name").ToString & Environment.NewLine
                Next sites
            Else
                contents.Text = contents.Text & translations.getText("noRecordOtherSites")
            End If
        Catch ex As Exception
            mainForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        mainForm.busy.Close(True)
    End Sub

    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listview_works.DrawItem
        e.DrawBackground()
        Dim selected As Boolean = False
        If e.Index > 0 Then
            If String.Compare(listview_works.Items(e.Index).ToString.Substring(0, 1).ToLower, listview_works.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            Else
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            selected = True
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        Dim ForeColor As Color = Color.Black
        If selected Then
            ForeColor = Color.DarkGreen
        End If
        Using b As New SolidBrush(ForeColor)
            If Not IsNothing(listview_works) Then
                If listview_works.Items.Count > 0 Then
                    e.Graphics.DrawString(listview_works.GetItemText(listview_works.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub
End Class