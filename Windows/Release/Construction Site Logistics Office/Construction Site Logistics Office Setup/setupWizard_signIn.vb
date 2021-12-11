Imports System.ComponentModel
Imports System.Drawing.Text
Imports ConstructionSiteLogistics

Public Class setupWizard_signIn
    Private state As New State("loadLocationOnly")
    Private showpass As Boolean
    Private translations As languageTranslations
    Private msgbox As message_box_frm
    Private busy As BusyThread
    Private WithEvents bwRegie As New BackgroundWorker
    Private nfCard As NFCard
    Private authByCard As Boolean = False
    Private loginSuccess As Boolean = False

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        sign_id.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        sign_in_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        forgot_id.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)

        signInCode.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        signInCode_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)

        email.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        email_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        send.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)

        server_msg.Font = New Font(state.fontTitle.Families(0), 8, FontStyle.Regular)

        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        Me.ResumeLayout()

    End Sub

    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("titleSignIn")
            subtitle.Text = translations.getText("subtitleSignIn")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            sign_in_lbl.Text = translations.getText("signIn")
            forgot_id.Text = translations.getText("forgotId") & " ?"
            email_lbl.Text = translations.getText("email")
            send.Text = translations.getText("send")
            signInCode_lbl.Text = translations.getText("code")
            Me.ResumeLayout()
            state.currentLang = setupWizard_country.settings.lang

            showpass = True
            authByCard = False
            server_msg.Visible = False

            nfCard = New NFCard
            'If nfCard.SelectDevice() Then
            'Dim smartCardReaders As New List(Of String)
            'Dim errMsg As String = ""
            'If nfCard.GetAvailableReaders(smartCardReaders, errMsg) Then
            'authByCard = True
            'server_msg.Visible = True
            'doCardAuth()

            'End If

        End If
    End Sub

    Private Sub doCardAuth()
        signInCode.Enabled = False
        translations.load("loginDialog")
        server_msg.Text = translations.getText("passCardOnReader")
        sign_id.Enabled = False
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
                If nfCard.readCardUID() AndAlso Not nfCard.getCardUIDString().Equals("") Then
                    cardData(0) = Convert.ToInt64(nfCard.getCardUIDString(), 16).ToString()
                    cardData(1) = If(Not nfCard.readStringOnCard(12, 5), "", nfCard.getReadedString())
                    e.Result = cardData
                    nfCard.Close()
                    Exit Sub
                End If
            End While
        End If
    End Sub

    Private Sub bwRegie_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwRegie.RunWorkerCompleted
        translations.load("busyMessages")
        server_msg.Text = translations.getText("commServer")
        signInCode.Text = e.Result(1)
        sign_id.Text = e.Result(0)

        wizardGoForward()
    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()

        If setupWizard_country.settings.isSharedServer Then
            If setupWizard_country.settings.isNewServer Then
                setupWizard_platformType.Show()
            Else
                setupWizard_platformType.Show()
            End If
        Else
            If setupWizard_country.settings.isNewServer Then
                setupWizard_NewFtpWebSettings.Show()
            Else
                setupWizard_ServerAddress.Show()
            End If
        End If
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        If sign_id.Text.Equals("") Or Not IsNumeric(sign_id.Text) Then
            Exit Sub
        End If

        btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
        btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
        btnContinueTxt.ForeColor = Color.Gray
        btnBack.Image = Image.FromFile(state.imagesPath & "leftArrowBtn.png")
        btnBack.SizeMode = PictureBoxSizeMode.StretchImage
        btnBackTxt.ForeColor = Color.Gray
        btnBackTxt.Enabled = False
        btnContinueTxt.Enabled = False
        btnContinue.Enabled = False
        btnBack.Enabled = False

        translations = New languageTranslations(setupWizard_country.state)
        translations.load("busyDialog")

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "101")
        vars.Add("id", sign_id.Text.ToString.Replace(" ", ""))
        vars.Add("idkey", signInCode.Text.ToString.Replace(" ", ""))
        vars.Add("type", "unknown")
        ' install default secret key
        state.secretKey = setupWizard_country.defaultEncryptionKey
        state.currentLang = setupWizard_country.settings.lang
        Dim request As New HttpData(state, setupWizard_country.settings.serverWebAddr & setupWizard_country.settings.ApiServerAddrPath)
        Dim response As String = request.RequestData(vars, "installoffice")
        btnBackTxt.Enabled = True
        btnContinueTxt.Enabled = True
        btnContinue.Enabled = True
        btnBack.Enabled = True
        btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
        btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
        btnContinueTxt.ForeColor = Color.DimGray
        btnBack.Image = Image.FromFile(state.imagesPath & "leftArrowBtnOn.png")
        btnBack.SizeMode = PictureBoxSizeMode.StretchImage
        btnBackTxt.ForeColor = Color.DimGray
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, setupWizard_country.state)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
            If authByCard Then
                doCardAuth()
            End If
            Exit Sub
        End If

        setupWizard_country.settings.userId = sign_id.Text
        Me.Hide()
        setupWizard_DiagnosticsCrashData.Show()
    End Sub

    Private Sub forgot_id_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgot_id.LinkClicked
        email.Visible = True
        email_lbl.Visible = True
        send.Visible = True
    End Sub

    Private Sub sign_id_TextChanged(sender As Object, e As EventArgs) Handles sign_id.TextChanged
        If Not sign_id.Text.Equals("") And Not signInCode.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub show_password_Click(sender As Object, e As EventArgs) Handles show_password.Click
        If showpass Then
            show_password.Image = Image.FromFile(state.imagesPath & Convert.ToString("show_password.png"))
            signInCode.PasswordChar = ""
            showpass = False
        Else
            show_password.Image = Image.FromFile(state.imagesPath & Convert.ToString("hide_password.png"))
            signInCode.PasswordChar = "•"
            showpass = True
        End If
    End Sub

    Private Sub sign_id_MaskChanged(sender As Object, e As EventArgs) Handles sign_id.MaskChanged
        If Not sign_id.Text.Equals("") And Not signInCode.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub send_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles send.LinkClicked
        If Not IsValidEmailFormat(email.Text) Then
            Exit Sub
        End If

        btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
        btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
        btnContinueTxt.ForeColor = Color.Gray
        btnBack.Image = Image.FromFile(state.imagesPath & "leftArrowBtn.png")
        btnBack.SizeMode = PictureBoxSizeMode.StretchImage
        btnBackTxt.ForeColor = Color.Gray
        btnBackTxt.Enabled = False
        btnContinueTxt.Enabled = False
        btnContinue.Enabled = False
        btnBack.Enabled = False

        Dim busyForm As New BusyThread
        translations = New languageTranslations(setupWizard_country.state)
        translations.load("busyDialog")
        busyForm.Show(translations.getText("connectingServer"))
        Application.DoEvents()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "1011")
        vars.Add("email", email.Text)
        vars.Add("type", "unknown")
        ' install default secret key
        state.secretKey = setupWizard_country.defaultEncryptionKey
        state.currentLang = setupWizard_country.settings.lang
        Dim request As New HttpData(state, setupWizard_country.settings.serverWebAddr & setupWizard_country.settings.ApiServerAddrPath)
        Dim response As String = request.RequestData(vars, "installoffice")
        btnBackTxt.Enabled = True
        btnContinueTxt.Enabled = True
        btnContinue.Enabled = True
        btnBack.Enabled = True
        btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
        btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
        btnContinueTxt.ForeColor = Color.DimGray
        btnBack.Image = Image.FromFile(state.imagesPath & "leftArrowBtnOn.png")
        btnBack.SizeMode = PictureBoxSizeMode.StretchImage
        btnBackTxt.ForeColor = Color.DimGray
        busyForm.Close()
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, setupWizard_country.state)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, -1, -1, setupWizard_country.state)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
        End If
    End Sub

End Class