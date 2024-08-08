Imports System.Drawing
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core

Public NotInheritable Class setupWizardMainForm
    Public enVars As New environmentVars
    Public defaultEncryptionKey As String = "26kozQaMwRuNJ24t"
    Public defaultApiServerAddrPath As String = "/csaml/api/index.php"

    Public settings As New Settings
    Public Property translations As languageTranslations
    Public Property programId As New FingerPrint

    ''FORMS
    Private FadeAlpha As Integer
    Private wizardForms As New List(Of Form)
    Private WizardFormsLoadedIndex As Integer = 0
    Private wizardFormsTitles As New List(Of String)
    Private wizardFormsSubtitles As New List(Of String)
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub PanelMain_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles PanelMain.Paint
    End Sub
    Public Sub New(_envVars As environmentVars)
        enVars = _envVars

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()

        translations = New languageTranslations(enVars)

        ''LOAD WIZARD FORMS FORMS    ==============================================
        wizardForms.Add(New setupWizard_country(Me))
        wizardForms.Add(New setupWizard_language(Me))
        wizardForms.Add(New setupWizard_platformType(Me))
        wizardForms.Add(New setupWizard_ServerAddress(Me))
        wizardForms.Add(New setupWizard_signIn(Me))
        wizardForms.Add(New setupWizard_NewFtpWebSettings(Me))
        wizardForms.Add(New setupWizard_createDB(Me))
        wizardForms.Add(New setupWizard_addOns(Me))
        wizardForms.Add(New setupWizard_createAdminAccount(Me))
        wizardForms.Add(New setupWizard_DiagnosticsCrashData(Me))
        wizardForms.Add(New setupWizard_settingUp(Me))
        wizardForms.Add(New setupWizard_finnish(Me))

        WizardFormsLoadedIndex = 0
        loadTitlesAndSubTitles()
        ''=========================================================================
    End Sub
    Public Sub loadTitlesAndSubTitles()
        translations.load("setupWizard")
        ''TITLES
        wizardFormsTitles.Add(translations.getText("titleCountry")) ''country
        wizardFormsTitles.Add(translations.getText("titleCountry")) ''language
        wizardFormsTitles.Add(translations.getText("titlePlatformType")) ''platform type
        wizardFormsTitles.Add(translations.getText("title")) ''server addr
        wizardFormsTitles.Add(translations.getText("titleSignIn")) ''sign in
        wizardFormsTitles.Add(translations.getText("title")) ''new ftp setup
        wizardFormsTitles.Add(translations.getText("titleDb")) ''new db setup
        wizardFormsTitles.Add(translations.getText("AddonsTitle")) ''new addons setup
        wizardFormsTitles.Add(translations.getText("AdminTitle")) ''new admin account setup
        wizardFormsTitles.Add(translations.getText("titleDiagnostics")) '' diagnostics
        wizardFormsTitles.Add(translations.getText("title") & " ...") '' settings up
        wizardFormsTitles.Add(translations.getText("titleFinnish"))
        wizardFormsTitles.Add(translations.getText(""))
        wizardFormsTitles.Add(translations.getText(""))
        wizardFormsTitles.Add(translations.getText(""))
        wizardFormsTitles.Add(translations.getText(""))

        ''SUBTITLES
        wizardFormsSubtitles.Add(translations.getText("subtitleCountry")) ''country
        wizardFormsSubtitles.Add(translations.getText("subtitleCountry")) ''language
        wizardFormsSubtitles.Add(translations.getText("subtitlePlatformType")) ''platform type
        wizardFormsSubtitles.Add(translations.getText("subtitle")) ''server addr
        wizardFormsSubtitles.Add(translations.getText("subtitleSignIn")) ''sign in
        wizardFormsSubtitles.Add(translations.getText("subtitle")) ''new ftp setup
        wizardFormsSubtitles.Add(translations.getText("subtitleDb")) ''new db setup
        wizardFormsSubtitles.Add(translations.getText("AddonsSubTitle")) ''new addons setup
        wizardFormsSubtitles.Add(translations.getText("AdminSubtitle")) ''new admin acc setup
        wizardFormsSubtitles.Add(translations.getText("subtitlePlatformType")) ''diagnostics
        wizardFormsSubtitles.Add("") ''settings up
        wizardFormsSubtitles.Add(translations.getText("subtitleFinnish"))
        wizardFormsSubtitles.Add(translations.getText(""))
        wizardFormsSubtitles.Add(translations.getText(""))
        wizardFormsSubtitles.Add(translations.getText(""))
        wizardFormsSubtitles.Add(translations.getText(""))
        wizardFormsSubtitles.Add(translations.getText(""))

    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()

            title.Text = wizardFormsTitles(WizardFormsLoadedIndex)
            subtitle.Text = wizardFormsSubtitles(WizardFormsLoadedIndex)

            settings.programId = programId.Value()
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        title.Font = New Font(enVars.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(enVars.fontTitle.Families(0), 12, FontStyle.Regular)

        Me.ResumeLayout()

        ' check if setup.cfg file exists and load setup
        Dim setupCfg As New setupSettings
        If setupCfg.load() Then
            If Not setupCfg.getText("platform").Equals("error") Then
                If setupCfg.getText("platform").Equals("custom") Then
                    settings.isSharedServer = False
                End If
                If setupCfg.getText("platform").Equals("shared") Then
                    settings.isSharedServer = True
                End If
            End If
            If Not setupCfg.getText("server").Equals("error") Then
                If setupCfg.getText("server").Equals("new") Then
                    settings.isNewServer = True
                End If
                If setupCfg.getText("server").Equals("existing") Then
                    settings.isNewServer = False
                End If
            End If
            If Not setupCfg.getText("serverWebAddress").Equals("error") Then
                settings.serverWebAddr = setupCfg.getText("serverWebAddress")

                settings.serverWebAddr = If(settings.serverWebAddr(settings.serverWebAddr.Length - 1).Equals("/"), settings.serverWebAddr.Substring(0, settings.serverWebAddr.Length - 2), settings.serverWebAddr)
                If settings.serverWebAddr.IndexOf("www.") > -1 And settings.serverWebAddr.IndexOf("http://") = -1 And settings.serverWebAddr.IndexOf("https://") = -1 Then
                    settings.serverWebAddr = "http://" & settings.serverWebAddr
                End If
                If (IsValidUrl("http|https", settings.serverWebAddr).Equals(True)) Then
                    settings.serverWebAddr = setupCfg.getText("serverWebAddress")
                Else
                    settings.serverWebAddr = Nothing
                End If
            End If
            If Not setupCfg.getText("serverFtpAddress").Equals("error") Then
                settings.serverFtpAddr = setupCfg.getText("serverftpAddress")

                settings.serverFtpAddr = If(settings.serverFtpAddr(settings.serverFtpAddr.Length - 1).Equals("/"), settings.serverFtpAddr.Substring(0, settings.serverFtpAddr.Length - 2), settings.serverFtpAddr)
                If settings.serverFtpAddr.IndexOf("ftp.") > -1 And settings.serverFtpAddr.IndexOf("ftp://") = -1 Then
                    settings.serverFtpAddr = "ftp://" & settings.serverFtpAddr
                End If
                If (IsValidUrl("ftp", settings.serverFtpAddr).Equals(True)) Then
                    settings.serverFtpAddr = setupCfg.getText("serverftpAddress")
                Else
                    settings.serverFtpAddr = Nothing
                End If
            End If
            If Not setupCfg.getText("disableOptions").Equals("error") Then
                If setupCfg.getText("disableOptions").Equals("true") Then
                    settings.disableOptions = True
                ElseIf setupCfg.getText("disableOptions").Equals("false") Then
                    settings.disableOptions = False
                End If
            End If

            If Not setupCfg.getText("diagnostics").Equals("error") Then
                If setupCfg.getText("diagnostics").Equals("true") Then
                    settings.sendDiags = True
                ElseIf setupCfg.getText("diagnostics").Equals("false") Then
                    settings.sendDiags = False
                End If
            End If

            If Not setupCfg.getText("crashreports").Equals("error") Then
                If setupCfg.getText("crashreports").Equals("true") Then
                    settings.sendCrash = True
                ElseIf setupCfg.getText("crashreports").Equals("false") Then
                    settings.sendCrash = False
                End If
            End If
        End If

    End Sub

    Private Sub backPicBtn_Click(sender As Object, e As EventArgs)
        goBack()
    End Sub

    Private Sub backTxtBtn_Click(sender As Object, e As EventArgs)
        goBack()
    End Sub

    Private Sub forwardPicBtn_Click(sender As Object, e As EventArgs)
        goForward()
    End Sub

    Private Sub forwardTxtBtn_Click(sender As Object, e As EventArgs)
        goForward()
    End Sub

    Private Sub goBack()
        If WizardFormsLoadedIndex > 0 Then
            subUpdateIndex(-1)
            If WizardFormsLoadedIndex.Equals(0) Then
                backPanelBtn.Visible = False
            ElseIf backPanelBtn.Visible.Equals(False) Then
                backPanelBtn.Visible = True
            End If
            loadWizardForm()
        End If
    End Sub

    Private Sub goForward()
        If WizardFormsLoadedIndex < wizardForms.Count - 1 Then
            subUpdateIndex(1)
            If WizardFormsLoadedIndex.Equals(wizardForms.Count - 1) Then
                forwardPanelBtn.Visible = False
            ElseIf forwardPanelBtn.Visible.Equals(False) Then
                forwardPanelBtn.Visible = True
            End If
            loadWizardForm()
        End If
    End Sub

    Private Sub subUpdateIndex(idx As Integer)
        If TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_platformType And idx > 0 Then
            If settings.isSharedServer Then
                If settings.isNewServer Then
                    'ToDo: setup new shared
                Else
                    ''GOTO SIGN IN FRM

                End If
            Else
                If settings.isNewServer Then
                    ''GOTO newFTP setings from
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_NewFtpWebSettings(Me))

                Else
                    ''goto server address form
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_ServerAddress(Me))
                End If
            End If

        ElseIf TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_signIn Then
            If idx < 0 Then
                If settings.isSharedServer Then
                    If settings.isNewServer Then
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType(Me))
                    Else
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType(Me))
                    End If
                Else
                    If settings.isNewServer Then
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_NewFtpWebSettings(Me))
                    Else
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_ServerAddress(Me))
                    End If
                End If
            Else
                WizardFormsLoadedIndex = getFormPos(New setupWizard_DiagnosticsCrashData(Me))
            End If
        ElseIf TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_DiagnosticsCrashData And idx < 0 Then
            If settings.isSharedServer Then
                If settings.isNewServer Then
                    'ToDo: setup new shared
                Else
                    'ToDo: setup exisiting shared
                End If
            Else
                If settings.isNewServer Then
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_NewFtpWebSettings(Me))
                Else
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_ServerAddress(Me))
                End If
            End If
        Else
            WizardFormsLoadedIndex = WizardFormsLoadedIndex + idx
        End If

    End Sub

    Public Sub updateform()
        WizardFormsLoadedIndex = getFormPos(New setupWizard_finnish(Me))
        loadWizardForm()
    End Sub

    Private Function getFormPos(formSearch As Form) As Integer
        For i = 0 To wizardForms.Count - 1
            If CStr(wizardForms(i) Is formSearch) Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Private Sub loadWizardForm()
        PanelMain.BackColor = Color.FromArgb(0, 0, 0)
        PanelMain.Refresh()
        Me.SuspendLayout()
        title.Text = wizardFormsTitles(WizardFormsLoadedIndex)
        subtitle.Text = wizardFormsSubtitles(WizardFormsLoadedIndex)

        wizardForms.ElementAt(WizardFormsLoadedIndex).Parent = PanelMain
        wizardForms.ElementAt(WizardFormsLoadedIndex).Size = PanelMain.Size
        wizardForms.ElementAt(WizardFormsLoadedIndex).Dock = DockStyle.Fill
        wizardForms.ElementAt(WizardFormsLoadedIndex).Show()
        Me.ResumeLayout()
        FadeInTimer.Enabled = True 'go!
    End Sub

    Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs) Handles FadeInTimer.Tick
        PanelMain.BackColor = Color.FromArgb(FadeAlpha, 255, 0, 0)
        PanelMain.Refresh()
        FadeAlpha += 5 'amount of opacity change for each timer tick
        If FadeAlpha > 255 Then
            FadeInTimer.Enabled = False 'finished fade-in
        End If
    End Sub

    Private Sub forwardPicBtn_Click_1(sender As Object, e As EventArgs) Handles forwardPicBtn.Click

    End Sub
End Class