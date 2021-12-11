Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frm_user_profile
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private profileDB As Dictionary(Of String, List(Of String))

    Private response, response2 As String
    Private mask As PictureBox = Nothing

    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()

    End Sub


    Private Sub frm_locate_worker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.SuspendLayout()

         
         
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        downloadLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        name_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nome.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)


        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        downloadLink.Text = translations.getText("downloadLink")
        saveLink.Text = translations.getText("saveLink")
        translations.load("profile")
        title.Text = translations.getText("profileTitle")
        name_lbl.Text = translations.getText("name")
        email_lbl.Text = translations.getText("email")
        contact_lbl.Text = translations.getText("contact")

        photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
        photobox.SizeMode = PictureBoxSizeMode.StretchImage

        Me.ResumeLayout()
    End Sub

    Private Sub frm_locate_worker_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
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
        vars.Add("request", "profile")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        profileDB = request.ConvertDataToArray("profile", state.queryProfileFields, response)
        If IsNothing(profileDB) Then
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
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        SuspendLayout()
        nome.Text = profileDB.Item("name")(0)
        email.Text = profileDB.Item("email")(0)
        contact.Text = profileDB.Item("contact")(0)
        If profileDB.Item("photo")(0).Equals("") Then
            photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
            downloadLink.Enabled = False
        Else
            photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/csaml/photos/" & profileDB.Item("photo")(0))))
                photobox.Image = tImage
                MainMdiForm.menu_profile_icon_title.Image = tImage
                downloadLink.Enabled = True
            Catch ex As Exception
                photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
                translations.load("errorMessages")
                MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                downloadLink.Enabled = False
            End Try
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        ResumeLayout()
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
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

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub saveLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveLink.LinkClicked
        If nome.Text.Equals("") Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("name") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (Not email.Text.Equals("") And Not IsValidEmailFormat(email.Text)) Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("email") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If contact.Text.Equals("") Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("contact") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        downloadLink.Enabled = False
        closeBtn.Enabled = False
        saveLink.Enabled = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "31")
        vars.Add("cod", profileDB("cod_user")(0))
        vars.Add("request", "edit")
        vars.Add("name", nome.Text)
        vars.Add("email", email.Text)
        vars.Add("contact", contact.Text)
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultSuccessSaveRecord"), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        End If
        downloadLink.Enabled = True
        closeBtn.Enabled = True
        saveLink.Enabled = True
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub downloadLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles downloadLink.LinkClicked
        translations.load("commonForm")
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Title = translations.getText("saveImageDialogTitle") & "..."
        saveFileDialog1.Filter = translations.getText("filesImage") & "|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim cfgFile = New FileInfo(saveFileDialog1.FileName)
            cfgFile.Refresh()
            If cfgFile.Exists Then
                Try
                    FileSystem.Kill(saveFileDialog1.FileName)
                Catch
                    translations.load("errorMessages")
                    Dim message3 As String = translations.getText("errorFileWriteProtected")
                    translations.load("messagebox")
                    msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            photobox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub photobox_Click(sender As Object, e As EventArgs) Handles photobox.Click

        translations.load("commonForm")
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = translations.getText("openImageDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesImage") & "|*.jpg"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim filename = OpenFileDialog1.FileName
            photobox.Image = Image.FromFile(filename)
            photobox.SizeMode = PictureBoxSizeMode.StretchImage

            translations.load("messagebox")
            Dim message3 As String = translations.getText("questionAddPhoto")
            msgbox = New message_box_frm(message3 & " ?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
            If (msgbox.ShowDialog = DialogResult.OK) Then
                downloadLink.Enabled = False
                closeBtn.Enabled = False
                saveLink.Enabled = False

                Dim request As New HttpData(state)
                Dim vars As New Dictionary(Of String, String)
                vars.Add("task", "31")
                vars.Add("request", "file")
                vars.Add("cod", profileDB("cod_user")(0))
                Dim response As String = request.SendHttpFile(vars, filename)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                If Not IsResponseOk(response) Then
                    photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
                    translations.load("messagebox")
                    msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                Else
                    load_list()
                End If
                downloadLink.Enabled = True
                closeBtn.Enabled = True
                saveLink.Enabled = True
            End If
        End If
    End Sub
End Class