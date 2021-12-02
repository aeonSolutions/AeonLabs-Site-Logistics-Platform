Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json

Public Class setupWizard_settingUp
    Private msgbox As messageBoxForm
    Private translations As languageTranslations
    Private progressValueTop As Integer = 0
    Private mainform As setupWizardMainForm
    Private WithEvents getSecretHttp As HttpDataPostData
    Private WithEvents registerPC As HttpDataPostData
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

    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")
            progress_status_text.Text = translations.getText("settingUp") & " ..."
            Me.ResumeLayout()
            mainform.enVars.currentLang = mainform.settings.lang
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        progress_status_text.Font = New Font(mainform.enVars.fontText.Families(0), 9, FontStyle.Bold)
    End Sub

    Private Sub setupWizard_1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        translations = New languageTranslations(mainform.enVars)

        If mainform.settings.isSharedServer Then
            If mainform.settings.isNewServer Then 'shared new 
                SaveSettingsSharedNew()
            Else ' shared existing
                SaveSettingsSharedExisting()
            End If
        ElseIf mainform.settings.isNewServer Then 'own new 
            SaveSettingsOwnNew()
        Else ' own existing
            SaveSettingsOwnExisting()
        End If
    End Sub
    Private Sub SaveSettingsSharedExisting()

    End Sub

    Private Sub SaveSettingsSharedNew()

    End Sub

    Private Sub SaveSettingsOwnNew()
        'REQUEST INSTALL FILES BY FTP ON SITELOGISTICS.CONSTRUCTION

        'REQUEST INSTALL DB ON OWN SERVER (AFTER FILES INSTALATION) + CONFIGURE ADDONS + DELETE SETUP FILES

        'GET SECRET KEY

        'REGISTER PROGRAM ID ON DB

        'REGISTER ADMIN

        'ADD AUTHORIZATIONS FOR DIAGONSTICS AND CRASH DATA ON SITELOGISTICS.CONSTRUCTION

    End Sub
    Private Sub SaveSettingsOwnExisting()
        progressValueTop = 33
        'GET SECRETE KEY
        getSecretKey()
    End Sub

    Private Sub getSecretKey()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "1020")
        vars.Add("id", mainform.settings.userId)
        'INSTALL DEFAULT SECRET KEY
        mainform.enVars.secretKey = mainform.defaultEncryptionKey
        mainform.enVars.currentLang = mainform.settings.lang
        getSecretHttp = New HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr & mainform.settings.ApiServerAddrPath)
        getSecretHttp.loadQueue(vars)
        getSecretHttp.startRequest()

    End Sub
    Private Sub getSecretHttp_dataarrived(sender As Object, responseData As String, msic As Dictionary(Of String, String)) Handles getSecretHttp.dataArrived


        If Not IsResponseOk(responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            If msgbox.ShowDialog = DialogResult.Retry Then
                SaveSettingsOwnExisting()
                Exit Sub
            Else
                translations.load("setupWizard")
                Dim message As String = translations.getText("cannotContinue")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                Application.DoEvents()
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If

        End If

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If data.ContainsKey("key") Then
                mainform.settings.ApiEncryptionKey = data.Item("key").ToString
            Else
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorLoadingDataFile") & ". " & translations.getText("contactEnterpriseSupport")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                Application.DoEvents()
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If

        Catch e As Exception
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorLoadingDataFile") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End Try

        ProgressBar.Value = 33
        progressValueTop = 66

        'REGISTER COMPUTER programID ON DB
        registerComputerPIDonDB()
    End Sub
    Private Sub registerComputerPIDonDB()
        Dim vars As New Dictionary(Of String, String)

        vars.Add("task", "1021")
        vars.Add("id", mainform.settings.userId)
        vars.Add("pid", mainform.settings.programId)
        'INSTALL DEFAULT SECRETE KEY
        mainform.enVars.secretKey = mainform.settings.ApiEncryptionKey
        mainform.enVars.currentLang = mainform.settings.lang

        registerPC = New HttpDataPostData(mainform.enVars, mainform.settings.serverWebAddr & mainform.settings.ApiServerAddrPath)
        registerPC.loadQueue(vars)
        registerPC.startRequest()

    End Sub
    Private Sub registerPC_dataarrived(sender As Object, responseData As String, msic As Dictionary(Of String, String)) Handles registerPC.dataArrived

        If Not IsResponseOk(responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            If msgbox.ShowDialog = DialogResult.Retry Then
                SaveSettingsOwnExisting()
                Exit Sub
            Else
                translations.load("setupWizard")
                Dim message As String = translations.getText("cannotContinue")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If
        End If

        ProgressBar.Value = 66
        progressValueTop = 100
        'SAVE SETTINGS FILE
        mainform.enVars.secretKey = mainform.enVars.SettingsSecretKey
        mainform.settings.updateState(mainform.enVars)
        Application.DoEvents()
        mainform.settings.save()
        ProgressBar.Value = 100
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If ProgressBar.Value < progressValueTop Then
            ProgressBar.Increment(1)
        End If
        If ProgressBar.Value = 100 Then
            Me.Hide()
            Timer.Enabled = False
            mainform.updateform()
        End If
    End Sub

    Private Sub AlphaGradientPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs)

    End Sub
End Class