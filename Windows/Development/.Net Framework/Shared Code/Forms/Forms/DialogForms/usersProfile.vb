Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.SmartCards.GUI


Public Class userProfileForm
    Private msgbox As messageBoxForm
    Private translations As languageTranslations

    Private profileDB As Dictionary(Of String, List(Of String))

    Private response, response2 As String
    Private mask As PictureBox = Nothing

    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private nfc_card As IsmartCard
    Private WithEvents httpRequest As HttpDataPostData

    Public Shared changeAuth As String = Nothing
    Public Shared userCode As String = Nothing
    Public Shared changedPin As String = Nothing
    Private state As New environmentVars
    private mainForm As MainMdiForm
    Private WithEvents initializeSmartCardForm As initializeSmartCard
    Private WithEvents HttpDataRequest As HttpDataPostData
    Private WithEvents httpSendFileRequest As HttpDataFilesUpload

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars)
        mainForm = _mainMdiForm
        state = _state

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub frm_locate_worker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        state = mainForm.state
        translations = New languageTranslations(state)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        mask.Refresh()
        Me.SuspendLayout()

        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        name_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nome.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")

        Dim DownloadToolTip As New ToolTip()
        DownloadToolTip.SetToolTip(downloadBtn, translations.getText("downloadLink"))

        Dim SaveToolTip As New ToolTip()
        SaveToolTip.SetToolTip(saveBtn, translations.getText("saveLink"))

        translations.load("profile")
        title.Text = translations.getText("profileTitle")
        name_lbl.Text = translations.getText("name")
        email_lbl.Text = translations.getText("email")
        contact_lbl.Text = translations.getText("contact")

        photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
        photobox.SizeMode = PictureBoxSizeMode.StretchImage

        changeAuth = Nothing
        pin.Enabled = False
        pin_lbl.Enabled = False
        changePin.Enabled = False


        Try
            nfc_card = DirectCast(loadDllObject(state, "contactless.smartcards.dll", "smartCard"), IsmartCard)
        Catch ex As Exception
            nfc_card = Nothing
        End Try
        If nfc_card Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            mainForm.NoNetwork()
            Me.Close()
            Exit Sub
        End If

        If nfc_card.SelectDevice() Then
            Dim smartCardReaders As New List(Of String)
            Dim errMsg As String = ""
            If nfc_card.GetAvailableReaders(smartCardReaders, errMsg) Then
                pin.Enabled = True
                pin_lbl.Enabled = True
                changePin.Enabled = True
            End If
        End If

        Me.ResumeLayout()
        Refresh()
    End Sub

    Private Sub frm_locate_worker_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
    End Sub

    Sub load_list()
        Dim vars As New Dictionary(Of String, String)
        httpRequest = New HttpDataPostData(state)
        httpRequest.initialize()

        vars.Add("task", state.taskId("queries"))
        vars.Add("request", "profile")

        httpRequest.loadQueue(vars, Nothing)
        httpRequest.startRequest()
    End Sub

    Private Sub httpRequest_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles httpRequest.dataArrived
        Dim errorMsg As String = ""
        Dim errorFlag As Boolean = False

        If Not IsResponseOk(responseData) Then
            errorMsg = GetMessage(responseData)
            errorFlag = True
            GoTo lastLine
        End If
        profileDB = httpRequest.ConvertDataToArray("profile", state.queryProfileFields, responseData)
        If IsNothing(profileDB) Then
            errorMsg = httpRequest.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            mainForm.busy.Close(True)
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        SuspendLayout()
        nome.Text = profileDB.Item("name")(0)
        email.Text = profileDB.Item("email")(0)
        contact.Text = profileDB.Item("contact")(0)
        pin.Text = profileDB.Item("pin")(0)
        userCode = profileDB.Item("cod_user")(0)

        If profileDB.Item("photo")(0).Equals("") Then
            photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
            downloadBtn.Enabled = False
        Else
            photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/csaml/photos/" & profileDB.Item("photo")(0))))
                photobox.Image = tImage
                mainForm.usernamePhoto.Image = tImage
                downloadBtn.Enabled = True
            Catch ex As Exception
                photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
                translations.load("errorMessages")
                mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                downloadBtn.Enabled = False
            End Try
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        ResumeLayout()
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

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub changePin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles changePin.LinkClicked
        If pin.Text.ToString.Length.Equals(4) And IsNumeric(pin.Text) Then
            Dim currentFormData As New Dictionary(Of String, String)
            currentFormData.Add("userCode", profileDB("cod_user")(0))
            currentFormData.Add("pin", pin.Text)
            currentFormData.Add("cardId", "")
            currentFormData.Add("authString", "")

            initializeSmartCardForm = New initializeSmartCard(mainForm, state, currentFormData)
            initializeSmartCardForm.ShowDialog()
        Else
            translations.load("errorMessages")
            Dim message3 As String = "PIN must be a 4 digit numeric number"
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub initializeSmartCardForm_getSmartCardDetails(sender As Object, args As Dictionary(Of String, String)) Handles initializeSmartCardForm.getSmartCardDetails
        pin.Text = args("pin")
    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles downloadBtn.Click
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
                    msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            photobox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If nome.Text.Equals("") Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("name") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New messageBoxForm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (Not email.Text.Equals("") And Not IsValidEmailFormat(email.Text)) Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("email") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New messageBoxForm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If contact.Text.Equals("") Then
            translations.load("profile")
            Dim msgTxt As String = translations.getText("contact") & " "
            translations.load("errorMessages")
            msgTxt += translations.getText("errorFieldGeneric")
            translations.load("messagebox")
            msgbox = New messageBoxForm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If Not pin.Text.ToString.Length.Equals(4) Or Not IsNumeric(pin.Text) Then
            translations.load("errorMessages")
            Dim message3 As String = "PIN must be a 4 digit numeric number"
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If (IsNothing(changeAuth) And Not pin.Text.ToString.Equals(profileDB.Item("pin")(0))) Then
            translations.load("errorMessages")
            Dim message3 As String = "You need to save the PIN on the NFC card writer"
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        downloadBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.Enabled = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("userProfile"))
        vars.Add("cod", profileDB("cod_user")(0))
        vars.Add("request", "edit")
        vars.Add("name", nome.Text)
        vars.Add("email", email.Text)
        vars.Add("contact", contact.Text)
        If Not pin.Text.ToString.Equals(profileDB.Item("pin")(0)) And Not IsNothing(changeAuth) Then
            vars.Add("auth", changeAuth)
        End If

        HttpDataRequest = New HttpDataPostData(state)
        HttpDataRequest.initialize()
        HttpDataRequest.loadQueue(vars, Nothing, Nothing)
        HttpDataRequest.startRequest()
    End Sub

    Private Sub HttpDataRequest_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles HttpDataRequest.dataArrived
        mainForm.busy.Close(True)

        If Not IsResponseOk(responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New messageBoxForm(translations.getText("resultSuccessSaveRecord"), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        End If
        downloadBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.Enabled = True
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
            msgbox = New messageBoxForm(message3 & " ?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
            If (msgbox.ShowDialog = DialogResult.OK) Then
                downloadBtn.Enabled = False
                closeBtn.Enabled = False
                saveBtn.Enabled = False

                Dim vars As New Dictionary(Of String, String)
                vars.Add("task", state.taskId("userProfile"))
                vars.Add("request", "file")
                vars.Add("cod", profileDB("cod_user")(0))

                httpSendFileRequest = New HttpDataFilesUpload(state, "")
                httpSendFileRequest.initialize()
                httpSendFileRequest.loadQueue(vars, Nothing, Nothing)
                httpSendFileRequest.startRequest()
            End If
        End If
    End Sub
    Private Sub httpSendFileRequest_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles httpSendFileRequest.dataArrived
        mainForm.busy.Close(True)

        If Not IsResponseOk(responseData) Then
            photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.png"))
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            load_list()
        End If
        downloadBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.Enabled = True
    End Sub
End Class