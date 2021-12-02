Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_NewFtpWebSettings
    Private translations As languageTranslations
    Private mainform As setupWizardMainForm
    Public Sub preLoadData(_mainForm As setupWizardMainForm)
        mainform = _mainForm
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)


        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.envars)
            translations.load("setupWizard")

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

            If Not IsNothing(mainform.settings.serverWebAddr) Then
                server_web_addr.Text = mainform.settings.serverWebAddr
            End If

            If Not IsNothing(mainform.settings.serverFtpAddr) Then
                server_ftp_addr.Text = mainform.settings.serverFtpAddr
            End If
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        server_web_addr.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        server_web_addr_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_addr.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_addr_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        domain_web_ex.Font = New Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular)
        domain_ftp_ex.Font = New Font(mainform.enVars.fontTitle.Families(0), 8, FontStyle.Regular)
        server_ftp_port_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        server_ftp_port.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        connectionType_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        connectionType.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        username.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        username_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        password.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        password_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        Me.ResumeLayout()
    End Sub
    Private Sub setupWizard_1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        ''TODO
        ''        setupWizard_platformType.Show()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs)
        If IsValidUrl("http|https", server_web_addr.Text).Equals(True) And IsValidUrl("ftp", server_ftp_addr.Text).Equals(True) And Not username.Text.Equals("") And Not password.Text.Equals("") Then
            wizardGoForward()
        End If
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs)
        If IsValidUrl("http|https", server_web_addr.Text).Equals(True) And IsValidUrl("ftp", server_ftp_addr.Text).Equals(True) And Not username.Text.Equals("") And Not password.Text.Equals("") Then
            wizardGoForward()
        End If
    End Sub

    Private Sub wizardGoForward()


        server_web_addr.Text = If(server_web_addr.Text(server_web_addr.Text.Length - 1).Equals("/"), server_web_addr.Text.Substring(0, server_web_addr.Text.Length - 2), server_web_addr.Text)
        server_ftp_addr.Text = If(server_ftp_addr.Text(server_ftp_addr.Text.Length - 1).Equals("/"), server_ftp_addr.Text.Substring(0, server_ftp_addr.Text.Length - 2), server_ftp_addr.Text)

        If Not IsValidUrl("http|https", server_web_addr.Text) AndAlso Not IsOnline(server_web_addr.Text) Then  ' check if is online and working


            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars)
            msgbox.ShowDialog()
            server_web_addr.Focus()
        End If
        Dim connectType As Boolean = False
        If connectionType.SelectedIndex.Equals(0) Then
            connectType = True ' with ssl
        End If
        If Not password.Text.Equals("") And Not username.Text.Equals("") And Not IsValidUrl("ftp", server_ftp_addr.Text) AndAlso Not IsFtpOnline(connectType, server_ftp_addr.Text, username.Text, password.Text) Then  ' check if is online and working


            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars)
            msgbox.ShowDialog()
            server_web_addr.Focus()
        End If

        'web server
        mainform.settings.serverWebAddr = server_web_addr.Text
        mainform.settings.ApiServerAddrPath = mainform.defaultApiServerAddrPath
        'ftp server
        mainform.settings.serverFtpAddr = server_ftp_addr.Text
        mainform.settings.serverFtpPort = server_ftp_port.Text
        mainform.settings.serverFtpPwd = password.Text
        mainform.settings.serverFtpUser = username.Text
        mainform.settings.serverFtpSsl = connectType

        ''TODO
        ''setupWizard_createDB.Show()
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
            ''TODO add chdckmark pic
        Else

        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub subtitle_Click(sender As Object, e As EventArgs)

    End Sub
End Class