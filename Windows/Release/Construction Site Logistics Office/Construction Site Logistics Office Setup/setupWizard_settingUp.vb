Imports System.Drawing.Text
Imports ConstructionSiteLogistics
Imports Newtonsoft.Json

Public Class setupWizard_settingUp


    Private state As New State
    Private msgbox As message_box_frm
    Private translations As languageTranslations
    Private progressValueTop As Integer = 0


    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub

    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("title") & " ..."
            progress_status_text.Text = translations.getText("settingUp") & " ..."
            Me.ResumeLayout()
            state.currentLang = setupWizard_country.settings.lang
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        progress_status_text.Font = New Font(state.fontText.Families(0), 9, FontStyle.Bold)
        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
    End Sub

    Private Sub setupWizard_1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        translations = New languageTranslations(setupWizard_country.state)

        If setupWizard_country.settings.isSharedServer Then
            If setupWizard_country.settings.isNewServer Then 'shared new 
                SaveSettingsSharedNew()
            Else ' shared existing
                SaveSettingsSharedExisting()
            End If
        ElseIf setupWizard_country.settings.isNewServer Then 'own new 
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
        If Not getSecretKey() Then
            Exit Sub
        End If

        ProgressBar.Value = 33
        progressValueTop = 66

        'REGISTER COMPUTER programID ON DB
        If Not registerComputerPIDonDB() Then
            Exit Sub
        End If

        ProgressBar.Value = 66
        progressValueTop = 100
        'SAVE SETTINGS FILE
        state.secretKey = state.SettingsSecretKey
        setupWizard_country.settings.updateState(state)
        Application.DoEvents()
        setupWizard_country.settings.save()
        ProgressBar.Value = 100
    End Sub

    Private Function getSecretKey() As Boolean
        Dim state As New State
        Dim vars As New Dictionary(Of String, String)
        Dim request As HttpData
        Dim response As String

        vars.Add("task", "1020")
        vars.Add("id", setupWizard_country.settings.userId)
        'INSTALL DEFAULT SECRET KEY
        state.secretKey = setupWizard_country.defaultEncryptionKey
        state.currentLang = setupWizard_country.settings.lang
        request = New HttpData(state, setupWizard_country.settings.serverWebAddr & setupWizard_country.settings.ApiServerAddrPath)
        response = request.RequestData(vars, "installoffice")
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            If msgbox.ShowDialog = DialogResult.Retry Then
                SaveSettingsOwnExisting()
                Return False
            Else
                translations.load("setupWizard")
                Dim message As String = translations.getText("cannotContinue")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                Application.DoEvents()
                msgbox.ShowDialog()
                Application.Exit()
                Return False
            End If
        End If

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If data.ContainsKey("key") Then
                setupWizard_country.settings.ApiEncryptionKey = data.Item("key").ToString
            Else
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorLoadingDataFile") & ". " & translations.getText("contactEnterpriseSupport")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                Application.DoEvents()
                msgbox.ShowDialog()
                Application.Exit()
                Return False
            End If

        Catch e As Exception
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorLoadingDataFile") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            msgbox.ShowDialog()
            Application.Exit()
            Return False
        End Try
        Return True
    End Function
    Private Function registerComputerPIDonDB() As Boolean
        Dim state As New State
        Dim vars As New Dictionary(Of String, String)
        Dim request As HttpData
        Dim response As String

        vars.Add("task", "1021")
        vars.Add("id", setupWizard_country.settings.userId)
        vars.Add("pid", setupWizard_country.settings.programId)
        'INSTALL DEFAULT SECRETE KEY
        state.secretKey = setupWizard_country.settings.ApiEncryptionKey
        state.currentLang = setupWizard_country.settings.lang
        request = New HttpData(state, setupWizard_country.settings.serverWebAddr & setupWizard_country.settings.ApiServerAddrPath)
        response = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information)
            Me.BringToFront()
            Application.DoEvents()
            If msgbox.ShowDialog = DialogResult.Retry Then
                SaveSettingsOwnExisting()
                Return False
            Else
                translations.load("setupWizard")
                Dim message As String = translations.getText("cannotContinue")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BringToFront()
                msgbox.ShowDialog()
                Application.Exit()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If ProgressBar.Value < progressValueTop Then
            ProgressBar.Increment(1)
        End If
        If ProgressBar.Value = 100 Then
            Me.Hide()
            Timer.Enabled = False
            setupWizard_finnish.Show()
        End If
    End Sub
End Class