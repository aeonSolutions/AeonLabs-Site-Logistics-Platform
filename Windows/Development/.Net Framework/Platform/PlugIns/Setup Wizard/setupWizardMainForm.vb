Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Gui.Forms.Core
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizardMainForm
    Inherits FormCustomized

    Public Property ExternalLoadEnVars As environmentVars = Nothing
    Public Property TypesOnAssemblies As Assembly = Nothing

    Public enVars As New environmentVars
    Public defaultEncryptionKey As String = "26kozQaMwRuNJ24t"
    Public defaultApiServerAddrPath As String = "/csaml/api/index.php"

    Public settings As New Settings
    Public Property translations As languageTranslations
    Public Property programId As New FingerPrint

    ''FORMS
    Private FadeAlpha As Integer
    Private fadeIn As Boolean

    Private wizardForms As New List(Of Form)
    Private WizardFormsLoadedIndex As Integer = 0
    Private wizardFormsTitles As New List(Of String)
    Private wizardFormsSubtitles As New List(Of String)
    Private formLoaded As Boolean = False
    Private CurrentWrapperForm As Form
    Private Sub PanelMain_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles PanelMain.Paint
    End Sub

    Private Sub loadAssembly()
        Try
            Dim assembly As Assembly = Assembly.LoadFile(enVars.libraryPath & "setup.dll")
            TypesOnAssemblies = assembly

        Catch ex As Exception
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("Setup error. You need to download and install the lastest version of the program at ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End Try
    End Sub

    Private Sub loadFormsForTesting()
        Dim setupWizardLanguageForm As New setupWizard_language
        setupWizardLanguageForm.preLoadData(Me)
        wizardForms.Add(setupWizardLanguageForm)

        Dim setupWizardCountryForm As New setupWizard_country
        setupWizardCountryForm.preLoadData(Me)
        wizardForms.Add(setupWizardCountryForm)

        Dim setupWizard_platformTypeForm As New setupWizard_platformType
        setupWizard_platformTypeForm.preLoadData(Me)
        wizardForms.Add(setupWizard_platformTypeForm)

        Dim setupWizard_ServerAddressForm As New setupWizard_ServerAddress
        setupWizard_ServerAddressForm.preLoadData(Me)
        wizardForms.Add(setupWizard_ServerAddressForm)

        Dim setupWizard_signInForm As New setupWizard_signIn
        setupWizard_signInForm.preLoadData(Me)
        wizardForms.Add(setupWizard_signInForm)

        Dim setupWizard_NewFtpWebSettingsForm As New setupWizard_NewFtpWebSettings
        setupWizard_NewFtpWebSettingsForm.preLoadData(Me)
        wizardForms.Add(setupWizard_NewFtpWebSettingsForm)

        Dim setupWizard_createDBForm As New setupWizard_createDB
        setupWizard_createDBForm.preLoadData(Me)
        wizardForms.Add(setupWizard_createDBForm)

        Dim setupWizard_addOnsForm As New setupWizard_addOns
        setupWizard_addOnsForm.preLoadData(Me)
        wizardForms.Add(setupWizard_addOnsForm)

        Dim setupWizard_createAdminAccountForm As New setupWizard_createAdminAccount
        setupWizard_createAdminAccountForm.preLoadData(Me)
        wizardForms.Add(setupWizard_createAdminAccountForm)

        Dim setupWizard_DiagnosticsCrashDataForm As New setupWizard_DiagnosticsCrashData
        setupWizard_DiagnosticsCrashDataForm.preLoadData(Me)
        wizardForms.Add(setupWizard_DiagnosticsCrashDataForm)

        Dim setupWizard_settingUpForm As New setupWizard_settingUp
        setupWizard_settingUpForm.preLoadData(Me)
        wizardForms.Add(setupWizard_settingUpForm)

        Dim setupWizard_finnishForm As New setupWizard_finnish
        setupWizard_finnishForm.preLoadData(Me)
        wizardForms.Add(setupWizard_finnishForm)
    End Sub

    Public Sub New()
        If ExternalLoadEnVars IsNot Nothing Then
            enVars = ExternalLoadEnVars
        End If

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()

        translations = New languageTranslations(enVars)

        'for testing only
        loadFormsForTesting()
        'loadAssembly()

        ''LOAD WIZARD FORMS FORMS    ==============================================
        If TypesOnAssemblies IsNot Nothing Then

            Dim setupWizardLanguageForm As setupWizard_language = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_language")), Form)
            setupWizardLanguageForm.preLoadData(Me)
            wizardForms.Add(setupWizardLanguageForm)

            Dim setupWizardCountryForm As setupWizard_country = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_country")), Form)
            setupWizardCountryForm.preLoadData(Me)
            wizardForms.Add(setupWizardCountryForm)

            Dim setupWizard_platformTypeForm As setupWizard_platformType = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_platformType")), Form)
            setupWizard_platformTypeForm.preLoadData(Me)
            wizardForms.Add(setupWizard_platformTypeForm)

            Dim setupWizard_ServerAddressForm As setupWizard_ServerAddress = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_ServerAddress")), Form)
            setupWizard_ServerAddressForm.preLoadData(Me)
            wizardForms.Add(setupWizard_ServerAddressForm)

            Dim setupWizard_signInForm As setupWizard_signIn = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_signIn")), Form)
            setupWizard_signInForm.preLoadData(Me)
            wizardForms.Add(setupWizard_signInForm)

            Dim setupWizard_NewFtpWebSettingsForm As setupWizard_NewFtpWebSettings = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_NewFtpWebSettings")), Form)
            setupWizard_NewFtpWebSettingsForm.preLoadData(Me)
            wizardForms.Add(setupWizard_NewFtpWebSettingsForm)

            Dim setupWizard_createDBForm As setupWizard_createDB = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_createDB")), Form)
            setupWizard_createDBForm.preLoadData(Me)
            wizardForms.Add(setupWizard_createDBForm)

            Dim setupWizard_addOnsForm As setupWizard_addOns = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_addOns")), Form)
            setupWizard_addOnsForm.preLoadData(Me)
            wizardForms.Add(setupWizard_addOnsForm)

            Dim setupWizard_createAdminAccountForm As setupWizard_createAdminAccount = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_createAdminAccount")), Form)
            setupWizard_createAdminAccountForm.preLoadData(Me)
            wizardForms.Add(setupWizard_createAdminAccountForm)

            Dim setupWizard_DiagnosticsCrashDataForm As setupWizard_DiagnosticsCrashData = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_DiagnosticsCrashData")), Form)
            setupWizard_DiagnosticsCrashDataForm.preLoadData(Me)
            wizardForms.Add(setupWizard_DiagnosticsCrashDataForm)

            Dim setupWizard_settingUpForm As setupWizard_settingUp = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_settingUp")), Form)
            setupWizard_settingUpForm.preLoadData(Me)
            wizardForms.Add(setupWizard_settingUpForm)

            Dim setupWizard_finnishForm As setupWizard_finnish = TryCast(Activator.CreateInstance(TypesOnAssemblies.[GetType]("ConstructionSiteLogistics.Setup.Gui.setupWizard_finnish")), Form)
            setupWizard_finnishForm.preLoadData(Me)
            wizardForms.Add(setupWizard_finnishForm)

        Else
            loadFormsForTesting()
        End If

        loadTitlesAndSubTitles()

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
        If Me.Visible And formLoaded Then

        End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Me.SuspendLayout()


        title.Font = New Font(enVars.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(enVars.fontTitle.Families(0), 12, FontStyle.Regular)

        title.Text = wizardFormsTitles(WizardFormsLoadedIndex)
        subtitle.Text = wizardFormsSubtitles(WizardFormsLoadedIndex)

        settings.programId = programId.Value()

        WizardFormsLoadedIndex = 0
        loadWizardForm()
        backPicBtn.Visible = False
        Me.ResumeLayout()
        formLoaded = True
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
            loadWizardForm()
        End If
    End Sub

    Private Sub goForward()
        If WizardFormsLoadedIndex < wizardForms.Count - 1 Then
            subUpdateIndex(1)
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
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_signIn)
                End If
            Else
                If settings.isNewServer Then
                    ''GOTO newFTP setings from
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_NewFtpWebSettings)
                Else
                    ''goto server address form
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_ServerAddress)
                End If
            End If

        ElseIf TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_signIn Then
            If idx < 0 Then
                If settings.isSharedServer Then
                    If settings.isNewServer Then
                        '' WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)
                    Else
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)
                    End If
                Else
                    If settings.isNewServer Then
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_NewFtpWebSettings)
                    Else
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_ServerAddress)
                    End If
                End If
            Else
                WizardFormsLoadedIndex = getFormPos(New setupWizard_DiagnosticsCrashData)
            End If
        ElseIf TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_NewFtpWebSettings And idx < 0 Then
            If idx < 0 Then
                If settings.isSharedServer Then
                    If settings.isNewServer Then
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)
                    Else
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)
                    End If
                Else
                    If settings.isNewServer Then
                        WizardFormsLoadedIndex = getFormPos(New setupWizard_platformType)

                    End If
                End If
            Else
                WizardFormsLoadedIndex = getFormPos(New setupWizard_DiagnosticsCrashData)
            End If
        ElseIf TypeOf wizardForms(WizardFormsLoadedIndex) Is setupWizard_DiagnosticsCrashData And idx < 0 Then
            If settings.isSharedServer Then
                If settings.isNewServer Then
                    'ToDo: setup new shared
                Else
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_signIn)
                End If
            Else
                If settings.isNewServer Then
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_createAdminAccount)
                Else
                    WizardFormsLoadedIndex = getFormPos(New setupWizard_signIn)
                End If
            End If
        Else
            WizardFormsLoadedIndex = WizardFormsLoadedIndex + idx
        End If
    End Sub

    Public Sub updateform()
        WizardFormsLoadedIndex = getFormPos(New setupWizard_finnish)
        loadWizardForm()
    End Sub

    Private Function getFormPos(formSearch As Form) As Integer
        For i = 0 To wizardForms.Count - 1
            If wizardForms(i).Name.Equals(formSearch.Name) Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Private Sub loadWizardForm()
        Me.SuspendLayout()
        title.Text = wizardFormsTitles(WizardFormsLoadedIndex)
        subtitle.Text = wizardFormsSubtitles(WizardFormsLoadedIndex)
        Me.ResumeLayout()

        FadeAlpha = 100
        fadeIn = True
        FadeInTimer.Enabled = True 'go!

    End Sub

    Private Sub FadeInTimer_Tick(sender As Object, e As EventArgs) Handles FadeInTimer.Tick
        If fadeIn Then
            FadeAlpha -= 1 'amount of opacity change for each timer tick
        Else
            FadeAlpha += 1
        End If
        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Opacity = FadeAlpha / 100
            PanelMain.Refresh()
        End If

        If FadeAlpha <= 0 Then
            FadeInTimer.Enabled = False 'finished fade-in

            If CurrentWrapperForm IsNot Nothing Then
                If Me.PanelMain.Controls.Count > 0 Then
                    Dim ctrl As Control = Nothing
                    For i As Integer = Me.PanelMain.Controls.Count - 1 To 0 Step -1
                        ctrl = Me.PanelMain.Controls(i)
                        Try
                            Me.PanelMain.Controls.Remove(ctrl)
                        Catch ex As Exception
                            Dim statusMessage = "Error unloading form"
                        End Try
                    Next
                End If
            End If
            loadNextForm()

        ElseIf FadeAlpha >= 100 Then
            FadeInTimer.Enabled = False 'finished fade-in
        End If
    End Sub

    Private Sub loadNextForm()
        Me.SuspendLayout()
        CurrentWrapperForm = wizardForms.ElementAt(WizardFormsLoadedIndex)
        CurrentWrapperForm.TopLevel = False
        CurrentWrapperForm.Parent = PanelMain
        CurrentWrapperForm.Size = PanelMain.Size
        CurrentWrapperForm.Dock = DockStyle.Fill
        CurrentWrapperForm.Opacity = 0.0
        PanelMain.Controls.Add(CurrentWrapperForm)

        CurrentWrapperForm.Show()

        If WizardFormsLoadedIndex.Equals(getFormPos(New setupWizard_settingUp)) Then
            forwardPicBtn.Visible = False
            backPicBtn.Visible = True
        ElseIf WizardFormsLoadedIndex < wizardForms.Count - 1 And WizardFormsLoadedIndex > 0 Then
            forwardPicBtn.Visible = True
            backPicBtn.Visible = True
        ElseIf WizardFormsLoadedIndex.Equals(0) Then
            backPicBtn.Visible = False
            forwardPicBtn.Visible = True
        End If

        Me.ResumeLayout()

        FadeAlpha = 0
        fadeIn = False
        FadeInTimer.Enabled = True 'go!
    End Sub


    Private Sub backPicBtn_Click_1(sender As Object, e As EventArgs) Handles backPicBtn.Click
        goBack()
    End Sub

    Private Sub forwardPicBtn_Click_1(sender As Object, e As EventArgs) Handles forwardPicBtn.Click
        goForward()
    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs) Handles title.Click

    End Sub

    Private Sub PanelBottom_Paint(sender As Object, e As PaintEventArgs) Handles PanelBottom.Paint

    End Sub

    Private Sub AlphaGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles AlphaGradientPanel1.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class