Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class auth_frm
    Private showPass As Boolean
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
    Private WithEvents bwLogin As New BackgroundWorker
    Private WithEvents bwRegie As BackgroundWorker

    Private nfCard As NFCard
    Private authByCard As Boolean = False
    Private loginSuccess As Boolean = False

    Private Sub auth_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = New State("all")
        translations = New languageTranslations(state)
        Me.SuspendLayout()

        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        access_code.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        codetxt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        doAuth.Font = New Font(state.fontText.Families(0), state.buttonFontSize, FontStyle.Regular)
        cancelCard_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        cardId_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        cardId.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        translations.load("commonForm")
        cancelCard_lbl.Text = translations.getText("cancelBtn")
        cancelCard_lbl.Location = New Point(Me.Width - 5 - cancelCard_lbl.Width, Me.Height - 5 - cancelCard_lbl.Height)
        translations.load("loginDialog")
        title.Text = translations.getText("title")
        access_code.Text = translations.getText("accessCode")
        doAuth.Text = translations.getText("authButton")
        cardId_lbl.Text = translations.getText("cardId")

        cardId.Text = ""
        codetxt.Text = ""
        doAuth.BackColor = state.buttonColor
        codetxt.Focus()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Location = New Point(MainMdiForm.Width / 2 - Me.Width / 2, MainMdiForm.Height / 2 - Me.Height / 2)
        loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("login_icon.png"))
        Me.ResumeLayout()


    End Sub
    Private Sub auth_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Application.DoEvents()
        showPass = True
        authByCard = False

        nfCard = New NFCard
        If nfCard.SelectDevice() Then
            Dim smartCardReaders As New List(Of String)
            Dim errMsg As String = ""
            If nfCard.GetAvailableReaders(smartCardReaders, errMsg) Then
                authByCard = True
                bwLogin = New BackgroundWorker()
                doCardAuth()
            End If
        End If
        Panel.Visible = True
    End Sub

    Private Sub doCardAuth()
        cancelCard_lbl.Visible = True
        translations.load("loginDialog")
        server_msg.Text = translations.getText("passCardOnReader")
        show_password.Visible = False
        doAuth.Visible = False
        codetxt.Enabled = False
        cardId.Enabled = False
        loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("login_icon_card.png"))
        loginIcon.SizeMode = PictureBoxSizeMode.StretchImage
        bwRegie = New BackgroundWorker()
        bwRegie.WorkerSupportsCancellation = True
        bwRegie.RunWorkerAsync()
    End Sub

    Private Sub bwRegie_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwRegie.DoWork
        Dim cardData(1) As String
        loginSuccess = False
        nfCard = New NFCard

        If nfCard.SelectDevice() Then
            nfCard.establishContext()
            While loginSuccess.Equals(False)
                If Not IsNothing(bwLogin) Then
                    If Not bwLogin.IsBusy And nfCard.connectCard() Then
                        If nfCard.readCardUID() AndAlso Not nfCard.getCardUIDString().Equals("") Then
                            cardData(0) = Convert.ToInt64(nfCard.getCardUIDString(), 16).ToString()
                            cardData(1) = If(Not nfCard.readStringOnCard(12, 5), "", nfCard.getReadedString())
                            e.Result = cardData
                            nfCard.Close()
                            Exit Sub
                        End If
                    End If
                End If
            End While
        End If
    End Sub

    Private Sub bwRegie_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwRegie.RunWorkerCompleted
        translations.load("busyMessages")
        server_msg.Text = translations.getText("commServer")
        codetxt.Text = e.Result(1)
        cardId.Text = e.Result(0)
        loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("connecting.gif"))
        loginIcon.SizeMode = PictureBoxSizeMode.StretchImage
        If authByCard Then
            cancelCard_lbl.Visible = False
        Else
            doAuth.Visible = False
        End If
        bwLogin = New BackgroundWorker()
        bwLogin.WorkerSupportsCancellation = True
        bwLogin.RunWorkerAsync(e.Result)

    End Sub

    Private Sub codetxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codetxt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            validateCode()
        End If
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles doAuth.Click
        loginIcon.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("connecting.gif"))
        loginIcon.SizeMode = PictureBoxSizeMode.StretchImage
        loginIcon.Refresh()
        validateCode()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles show_password.Click
        If showPass Then
            show_password.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("show_password.png"))
            codetxt.PasswordChar = ""
            showPass = False
        Else
            show_password.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("hide_password.png"))
            codetxt.PasswordChar = "•"
            showPass = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel.Paint

    End Sub

    Private Sub validateCode()
        loginSuccess = False
        doAuth.Enabled = False
        codetxt.Enabled = False
        cardId.Enabled = False
        translations.load("busyMessages")
        server_msg.Text = translations.getText("commServer")
        server_msg.Visible = True
        translations.load("loginDialog")
        If codetxt.Text.Equals("") Or Not IsNumeric(codetxt.Text) Or cardId.Text.Equals("") Or Not IsNumeric(cardId.Text) Then
            Dim message As String = translations.getText("loginFailed")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". " & translations.getText("tryAgain") & " ?", translations.getText("question"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            Me.Hide()
            Application.DoEvents()
            If (msgbox.ShowDialog = DialogResult.Cancel) Then
                System.Windows.Forms.Application.Exit()
                Exit Sub
            End If
            translations.load("loginDialog")
            access_code.Text = translations.getText("accessCode")
            codetxt.Enabled = True
            doAuth.Enabled = True
            cardId.Enabled = True
            server_msg.Visible = codetxt.Text = ""
            cardId.Text = ""
            loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("login_icon.png"))
            loginIcon.Refresh()

            Me.Show()
            Exit Sub
        End If

        If Not IsNothing(bwLogin) Then
            If bwLogin.IsBusy Then
                bwLogin.CancelAsync()
            End If
        End If
        Dim cardData(1) As String
        cardData(1) = codetxt.Text.ToString
        cardData(0) = cardId.Text.ToString
        server_msg.Visible = False
        loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("connecting.gif"))
        loginIcon.SizeMode = PictureBoxSizeMode.StretchImage
        If authByCard Then
            cancelCard_lbl.Visible = False
        Else
            doAuth.Visible = False
        End If
        bwLogin = New BackgroundWorker()
        bwLogin.WorkerSupportsCancellation = True
        bwLogin.RunWorkerAsync(cardData)
    End Sub

    Private Sub bwLogin_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLogin.DoWork
        Dim appId As New Security.FingerPrint
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "1")
        vars.Add("id", e.Argument(0))
        vars.Add("idkey", e.Argument(1))
        vars.Add("type", "unknown")
        vars.Add("pid", appId.Value)

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)

        If Not IsResponseOk(response) Then
            errorFlag = True
        End If

        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = response
            e.Result = s
        Else
            s(0) = False
            s(1) = response
            e.Result = s
        End If
    End Sub

    Private Sub bwLogin_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLogin.RunWorkerCompleted
        If e.Result(0).Equals("true") Then
            Dim message As String = GetMessage(e.Result(1))
            translations.load("messagebox")
            msgbox = New message_box_frm(message & " " & translations.getText("tryAgain") & " ?", translations.getText("question"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)

            Me.Hide()
            If (msgbox.ShowDialog = DialogResult.Cancel) Then
                System.Windows.Forms.Application.Exit()
                Exit Sub
            End If
            codetxt.Enabled = True
            doAuth.Enabled = True
            server_msg.Visible = False
            cardId.Enabled = True

            codetxt.Text = ""
            cardId.Text = ""
            loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("login_icon.png"))
            loginIcon.Refresh()
            If authByCard Then
                cancelCard_lbl.Visible = True
            Else
                doAuth.Visible = True
            End If

            Me.Show()
            Me.Refresh()
            If authByCard Then
                doCardAuth()
            End If
            Exit Sub
        End If

        MainMdiForm.state.userId = cardId.Text
        MainMdiForm.state.authOk = True

        loginIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("login_icon_pass.png"))
        Threading.Thread.Sleep(1000)
        Dim photoFile As String = ""
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(e.Result(1))
            If jsonLatResult.ContainsKey("photo") Then
                photoFile = jsonLatResult.Item("photo")
            End If
        Catch ex As Exception

        End Try
        If (photoFile.Equals("")) Then
            MainMdiForm.menu_profile_icon_title.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
        Else
            MainMdiForm.menu_profile_icon_title.Image = Image.FromFile(state.imagesPath & Convert.ToString("loading.png"))
            MainMdiForm.menu_profile_icon_title.SizeMode = PictureBoxSizeMode.StretchImage

            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/csaml/photos/" & photoFile)))
                MainMdiForm.menu_profile_icon_title.Image = tImage
            Catch ex As Exception
                translations.load("errorMessages")
                MainMdiForm.menu_profile_icon_title.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
                MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            MainMdiForm.menu_profile_icon_title.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        codetxt.Enabled = True
        server_msg.Visible = False
        loginSuccess = True
        cardId.Enabled = True
        If authByCard Then
            cancelCard_lbl.Visible = True
        Else
            doAuth.Visible = True
        End If
        Me.Close()
    End Sub

    Private Sub cancelCard_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cancelCard_lbl.LinkClicked
        If Not IsNothing(bwLogin) Then
            If bwLogin.IsBusy Then
                bwLogin.CancelAsync()
            End If
        End If
        System.Windows.Forms.Application.Exit()

    End Sub
End Class