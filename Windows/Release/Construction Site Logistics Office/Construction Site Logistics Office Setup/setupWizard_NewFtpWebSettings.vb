Imports System.Drawing.Text
Imports ConstructionSiteLogistics

Public Class setupWizard_NewFtpWebSettings
    Private translations As languageTranslations

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("title")
            subtitle.Text = translations.getText("subtitle")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            server_web_addr_lbl.Text = translations.getText("serverWebAddr")

            server_ftp_addr_lbl.Text = translations.getText("serverFtpAddr")
            server_ftp_port_lbl.Text = translations.getText("serverFtpPort")
            connectionType_lbl.Text = translations.getText("ftpConncetionTypeTitle")
            username_lbl.Text = translations.getText("ftpUsername")
            password_lbl.Text = translations.getText("ftpPassword")

            connectionType.Items.Clear()
            connectionType.Items.Add(translations.getText("ftpConnTypeOverTls"))
            connectionType.Items.Add(translations.getText("ftpConnTypePlain"))
            connectionType.SelectedIndex = 0

            If Not IsNothing(setupWizard_country.settings.serverWebAddr) Then
                server_web_addr.Text = setupWizard_country.settings.serverWebAddr
            End If

            If Not IsNothing(setupWizard_country.settings.serverFtpAddr) Then
                server_ftp_addr.Text = setupWizard_country.settings.serverFtpAddr
            End If
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        server_web_addr.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        server_web_addr_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_addr.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_addr_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        domain_web_ex.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 8, FontStyle.Regular)
        domain_ftp_ex.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 8, FontStyle.Regular)
        title.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 12, FontStyle.Regular)
        server_ftp_port_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_port.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        connectionType_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        connectionType.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        username.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        username_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        password.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        password_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        Me.ResumeLayout()
    End Sub
    Private Sub setupWizard_1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()
        setupWizard_platformType.Show()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If IsValidUrl("http|https", server_web_addr.Text).Equals(True) And IsValidUrl("ftp", server_ftp_addr.Text).Equals(True) And Not username.Text.Equals("") And Not password.Text.Equals("") Then
            wizardGoForward()
        End If
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        If IsValidUrl("http|https", server_web_addr.Text).Equals(True) And IsValidUrl("ftp", server_ftp_addr.Text).Equals(True) And Not username.Text.Equals("") And Not password.Text.Equals("") Then
            wizardGoForward()
        End If
    End Sub

    Private Sub wizardGoForward()
        btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtn.png")
        btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
        btnContinueTxt.ForeColor = Color.Gray
        btnBack.Image = Image.FromFile(setupWizard_country.state.imagesPath & "leftArrowBtn.png")
        btnBack.SizeMode = PictureBoxSizeMode.StretchImage
        btnBackTxt.ForeColor = Color.Gray
        btnBackTxt.Enabled = False
        btnContinueTxt.Enabled = False
        btnContinue.Enabled = False
        btnBack.Enabled = False

        server_web_addr.Text = If(server_web_addr.Text(server_web_addr.Text.Length - 1).Equals("/"), server_web_addr.Text.Substring(0, server_web_addr.Text.Length - 2), server_web_addr.Text)
        server_ftp_addr.Text = If(server_ftp_addr.Text(server_ftp_addr.Text.Length - 1).Equals("/"), server_ftp_addr.Text.Substring(0, server_ftp_addr.Text.Length - 2), server_ftp_addr.Text)

        If Not IsValidUrl("http|https", server_web_addr.Text) AndAlso Not IsOnline(server_web_addr.Text) Then  ' check if is online and working
            btnBackTxt.Enabled = True
            btnContinueTxt.Enabled = True
            btnContinue.Enabled = True
            btnBack.Enabled = True
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
            btnBack.Image = Image.FromFile(setupWizard_country.state.imagesPath & "leftArrowBtnOn.png")
            btnBack.SizeMode = PictureBoxSizeMode.StretchImage
            btnBackTxt.ForeColor = Color.DimGray

            Dim msgbox As message_box_frm
            msgbox = New message_box_frm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, setupWizard_country.state)
            msgbox.ShowDialog()
            server_web_addr.Focus()
        End If
        Dim connectType As Boolean = False
        If connectionType.SelectedIndex.Equals(0) Then
            connectType = True ' with ssl
        End If
        If Not password.Text.Equals("") And Not username.Text.Equals("") And Not IsValidUrl("ftp", server_ftp_addr.Text) AndAlso Not IsFtpOnline(connectType, server_ftp_addr.Text, username.Text, password.Text) Then  ' check if is online and working
            btnBackTxt.Enabled = True
            btnContinueTxt.Enabled = True
            btnContinue.Enabled = True
            btnBack.Enabled = True
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
            btnBack.Image = Image.FromFile(setupWizard_country.state.imagesPath & "leftArrowBtnOn.png")
            btnBack.SizeMode = PictureBoxSizeMode.StretchImage
            btnBackTxt.ForeColor = Color.DimGray

            Dim msgbox As message_box_frm
            msgbox = New message_box_frm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, setupWizard_country.state)
            msgbox.ShowDialog()
            server_web_addr.Focus()
        End If

        'web server
        setupWizard_country.settings.serverWebAddr = server_web_addr.Text
        setupWizard_country.settings.ApiServerAddrPath = setupWizard_country.defaultApiServerAddrPath
        'ftp server
        setupWizard_country.settings.serverFtpAddr = server_ftp_addr.Text
        setupWizard_country.settings.serverFtpPort = server_ftp_port.Text
        setupWizard_country.settings.serverFtpPwd = password.Text
        setupWizard_country.settings.serverFtpUser = username.Text
        setupWizard_country.settings.serverFtpSsl = connectType

        Me.Hide()
        setupWizard_createDB.Show()
    End Sub

    Private Sub server_web_addr_TextChanged(sender As Object, e As EventArgs) Handles server_web_addr.TextChanged
        validateFields()
    End Sub

    Private Sub server_ftp_addr_TextChanged(sender As Object, e As EventArgs) Handles server_ftp_addr.TextChanged
        validateFields()
    End Sub
    Private Sub username_TextChanged(sender As Object, e As EventArgs) Handles username.TextChanged
        validateFields()
    End Sub
    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged
        validateFields()
    End Sub


    Private Sub validateFields()
        If server_ftp_addr.Text.ToString.IndexOf("ftp.") > -1 And server_ftp_addr.Text.ToString.IndexOf("ftp://") = -1 Then
            server_ftp_addr.Text = "ftp://" & server_ftp_addr.Text
            server_ftp_addr.SelectionStart = server_ftp_addr.Text.Length + 1
        End If
        If server_web_addr.Text.ToString.IndexOf("www.") > -1 And server_web_addr.Text.ToString.IndexOf("http://") = -1 And server_web_addr.Text.ToString.IndexOf("https://") = -1 Then
            server_web_addr.Text = "http://" & server_web_addr.Text
            server_web_addr.SelectionStart = server_web_addr.Text.Length + 1
        End If

        If IsValidUrl("http|https", server_web_addr.Text).Equals(True) And IsValidUrl("ftp", server_ftp_addr.Text).Equals(True) And Not username.Text.Equals("") And Not password.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs) Handles title.Click

    End Sub

    Private Sub subtitle_Click(sender As Object, e As EventArgs) Handles subtitle.Click

    End Sub
End Class