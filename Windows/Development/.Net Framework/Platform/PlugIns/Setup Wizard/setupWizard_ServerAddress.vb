Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_ServerAddress
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
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")

            If (IsValidUrl("http|https", mainform.settings.serverWebAddr).Equals(True)) Then
                selectionOkpic.Visible = False
            Else
                selectionOkpic.Visible = True
            End If

            server_web_addr_lbl.Text = translations.getText("serverWebAddr")
            If Not IsNothing(mainform.settings.serverWebAddr) Then
                server_web_addr.Text = mainform.settings.serverWebAddr
            End If
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        server_web_addr.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        server_web_addr_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        domain_web_ex.Font = New Font(mainform.enVars.fontTitle.Families(0), 7, FontStyle.Regular)

        Me.ResumeLayout()
    End Sub
    Private Sub setupWizard_1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub server_web_addr_TextChanged(sender As Object, e As EventArgs) Handles server_web_addr.TextChanged
        If server_web_addr.Text.ToString.IndexOf("www.") > -1 And server_web_addr.Text.ToString.IndexOf("http://") = -1 And server_web_addr.Text.ToString.IndexOf("https://") = -1 Then
            server_web_addr.Text = "http://" & server_web_addr.Text
            server_web_addr.SelectionStart = server_web_addr.Text.Length + 1
        End If

        If server_web_addr.Text.Equals("") Then
            selectionOkpic.Visible = False
            TimerCheckIsOnline.Enabled = False
            TimerCheckIsOnline.Stop()
        ElseIf (IsValidUrl("http|https", server_web_addr.Text).Equals(True)) Then
            TimerCheckIsOnline.Enabled = True
            TimerCheckIsOnline.Start()
        Else
            selectionOkpic.Visible = False
            TimerCheckIsOnline.Enabled = False
            TimerCheckIsOnline.Stop()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TimerCheckIsOnline_Tick(sender As Object, e As EventArgs) Handles TimerCheckIsOnline.Tick
        If (IsValidUrl("http|https", server_web_addr.Text).Equals(True)) Then
            If IsOnline(server_web_addr.Text) Then  ' check if is online and working
                mainform.settings.serverWebAddr = server_web_addr.Text
                mainform.settings.isNewServer = False
                mainform.settings.ApiServerAddrPath = mainform.defaultApiServerAddrPath
                selectionOkpic.Visible = True
            Else
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, -1, -1, mainform.enVars)
                msgbox.ShowDialog()
            End If
        End If
    End Sub
End Class