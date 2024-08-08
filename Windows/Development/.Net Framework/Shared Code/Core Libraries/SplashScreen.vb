Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports AutoUpdaterDotNET
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public NotInheritable Class SplashScreen
    Public WithEvents state As New environmentVars
    Public DBsettings As Dictionary(Of String, List(Of String))

    Private translations As languageTranslations
    Private showPass As Boolean
    Private msgbox As messageBoxForm

    Private WithEvents loadLoginData As HttpDataPostData
    Private WithEvents loadCloudSettingsData As HttpDataPostData
    Private WithEvents sendCrashData As HttpDataPostData
    Private WithEvents get_DLL_Files As HttpDataFilesDownload

    Private WithEvents bwDoCardAuth As BackgroundWorker

    Private bwDownloadFile() As BackgroundWorker
    Private fileExtension() As String
    Private threadCount As Integer = 25

    Private queue As List(Of _queue_data_struct)
    Private queueBWorker() As Integer
    Private queueLock As New Object
    Private WithEvents RestartQueueTimer As New Windows.Forms.Timer
    Public Event getResponseFromQueueData(sender As Object, args As Dictionary(Of String, String))

    Structure _queue_data_struct
        Dim vars As Dictionary(Of String, String)
        Dim misc As Dictionary(Of String, String)
        Dim status As Integer ' -1 - completed; 0- not sent yet; 1-already sent / processing 
    End Structure

    Structure _retry_attempts
        Dim counter As Integer
        Dim pattern As Integer
        Dim previousPattern As Integer
        Dim errorMessage As String
    End Structure
    Private retryAttempts As New _retry_attempts
    Private Const numberOfRetryAttempts = 5

    Private WithEvents smartcard As IsmartCard

    Private authByCard As Boolean = False
    Private loginSuccess As Boolean = False
    Private OnGoingLogin As Boolean = False
    Private LoadingCounter As Integer
    Private LoadingCounterTotalTasks As Integer = 4
    Private programUpdateStatus As Dictionary(Of String, String)
    Private dllsToLoad As New List(Of String)
    Private dllsLoaded() As Boolean
    Private DllFilesList As Dictionary(Of String, String)

    Private loading As Boolean = False
    Private WithEvents SyncUI_Auth As New SyncWithUI
    Private WithEvents SyncUI_Dll As New SyncWithUI
    Private WithEvents SyncUI_serverSettings As New SyncWithUI
    Private WithEvents SyncUI_CrashReports As New SyncWithUI
    Private AuthSarted As Boolean = False

    Private errorMsgAlreadyOccurredDLLs As Boolean
    Private errorMsgAlreadyOccurredSettings As Boolean
    Private oldState As environmentVarsCore

    Private MessageInfoFree As Boolean = True
    Private MessageInfoFree_timer As Timer
    Private logs As String()

#Region "Misc"
    Private Sub reLoadAgain()
        translations.load("messagebox")
        msgbox = New messageBoxForm(GetMessage(get_DLL_Files.errorMessage) & ". Try again ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)

        If msgbox.ShowDialog() = DialogResult.Yes Then
            loadServerSettings()
        Else
            If (Application.MessageLoop) Then
                Application.Exit()
            Else
                Environment.Exit(1)
            End If
        End If
    End Sub

    Private Sub MessageInfoFree_timer_Timer_Sub(sender As Object, e As EventArgs)
        MessageInfoFree = True
    End Sub

    Private Sub TerminateApp()
        If (Application.MessageLoop) Then
            Application.Exit()
        Else
            Environment.Exit(1)
        End If
    End Sub
    Private Sub reloadBaseEnvironmentVars()
        If IsNothing(oldState) Then
            Exit Sub
        End If

        state.bundleSpecificVars = oldState.bundleSpecificVars
        state.authorizedDLLs = oldState.authorizedDLLs
        state.softwareAccessMode = oldState.softwareAccessMode
        state.taskId = oldState.taskId
        'ToDo: HACK to srewdriver.eon delete
        Dim tmp As New environmentVars
        state.ServerBaseAddr = tmp.ServerBaseAddr
    End Sub
    Private Sub checkLoadingTasks()
        If Not (SyncUI_Auth.Running And SyncUI_Dll.Running And SyncUI_serverSettings.Running And SyncUI_CrashReports.Running) Then
            'Load main App
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Loading complete"
                                     statusMessage.Refresh()
                                 End Sub)

        End If
    End Sub

    Private Sub monitorBackgrundWorkStatus()
        If Not SyncUI_Auth.Running And Not SyncUI_CrashReports.Running And Not SyncUI_Dll.Running And Not SyncUI_serverSettings.Running And AuthSarted Then
            Dim MainForm As New MainMdiForm(state)
            Me.Hide()
            MainForm.Show()
        End If
    End Sub

    Private Sub handleControls()

        codetxt.Invoke(Sub()
                           codetxt.Enabled = True
                           codetxt.Text = ""
                       End Sub)

        cardId.Invoke(Sub()
                          cardId.Text = ""
                          cardId.Enabled = True
                      End Sub)

        cancelCard_lbl.Invoke(Sub()
                                  If authByCard Then
                                      cancelCard_lbl.Visible = True
                                  Else
                                      cardId.Visible = True
                                      Me.Refresh()
                                      Me.Show()

                                  End If
                              End Sub)

    End Sub
#End Region

#Region "Login"
    Private Sub codetxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codetxt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            validateCode()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles show_password.Click
        If showPass Then
            show_password.Image = Image.FromFile(state.imagesPath & Convert.ToString("show_password.png"))
            codetxt.PasswordChar = ""
            showPass = False
        Else
            show_password.Image = Image.FromFile(state.imagesPath & Convert.ToString("hide_password.png"))
            codetxt.PasswordChar = "•"
            showPass = True
        End If
    End Sub

    Private Sub validateCode()
        loginSuccess = False
        cardId.Enabled = False
        codetxt.Enabled = False
        cardId.Enabled = False
        translations.load("busyMessages")
        statusMessage.Text = translations.getText("commServer")
        statusMessage.Visible = True
        translations.load("loginDialog")
        If codetxt.Text.Equals("") Or Not IsNumeric(codetxt.Text) Or cardId.Text.Equals("") Or Not IsNumeric(cardId.Text) Then
            Dim message As String = translations.getText("loginFailed")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & ". " & translations.getText("tryAgain") & " ?", translations.getText("question"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If (msgbox.ShowDialog = DialogResult.Cancel) Then
                OnGoingLogin = False
                TerminateApp()
                Exit Sub
            End If
            translations.load("loginDialog")
            access_code.Text = translations.getText("accessCode")
            panelLogin.Visible = True
            codetxt.Enabled = True
            cardId.Enabled = True
            cardId.Enabled = True
            statusMessage.Visible = True
            codetxt.Text = ""
            cardId.Text = ""
            statusMessage.Text = "You need to Login"
            OnGoingLogin = False
            Exit Sub
        End If


        If authByCard Then
            cancelCard_lbl.Visible = False
        Else
            cardId.Visible = False
        End If

        panelLogin.Invoke(Sub()
                              panelLogin.Visible = False
                              panelLogin.Refresh()
                          End Sub)

        OnGoingLogin = True
        state = New environmentVars(LOAD_ALL)

    End Sub

    Private Sub status_environmentVarsLoadComplete(sender As Object, errorMessage As String, Err As Boolean) Handles state.environmentVarsLoadComplete
        If state.stateLoaded.Equals(False) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorLoadingSettings") & Environment.NewLine & state.stateErrorMessage
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & ". Try again ?", translations.getText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If msgbox.ShowDialog() = DialogResult.Yes Then
                loadSessionFiles()
                Exit Sub
            End If
        End If

        reloadBaseEnvironmentVars()

        If OnGoingLogin.Equals(False) Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("login"))
        vars.Add("id", cardId.Text.ToString)
        vars.Add("idkey", codetxt.Text.ToString)
        vars.Add("type", "unknown")

        loadLoginData = New HttpDataPostData(state)
        loadLoginData.initialize()
        loadLoginData.loadQueue(vars, Nothing, Nothing)
        loadLoginData.numberOfRetryAttempts = -1
        loadLoginData.startRequest()
        SyncUI_Auth.Running = True
        AuthSarted = True
        panelLogin.Invoke(Sub()
                              panelLogin.Visible = False
                          End Sub)
    End Sub

    Private Sub PrivateloadLoginData_dataCompleted(sender As Object, err As Boolean) Handles loadLoginData.requestCompleted

    End Sub
    Private Sub loadLoginData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLoginData.dataArrived
        If Not IsResponseOk(responseData) Then
            errorAuth(GetMessage(responseData))
            Exit Sub
        End If

        'UPDATE ENV VARS
        programUpdateStatus = New Dictionary(Of String, String)
        dllsToLoad = New List(Of String)

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)

            state.userType = data.Item("type").ToString
            state.userConnType = data.Item("conntype").ToString
            state.username = data.Item("username").ToString
            'ToDo: Add user photo to state
            If (responseData.IndexOf("status") > -1) Then
                Dim jsonPuStatus = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(data.Item("status").ToString)
                programUpdateStatus.Add("version", jsonPuStatus.Item("version").ToString)
                programUpdateStatus.Add("url", jsonPuStatus.Item("url").ToString)
                programUpdateStatus.Add("changelog", jsonPuStatus.Item("changelog").ToString)
                programUpdateStatus.Add("checksum", jsonPuStatus.Item("checksum").ToString)
                programUpdateStatus.Add("mandatory", jsonPuStatus.Item("mandatory").ToString)
            End If

            Dim DllsJson = JArray.Parse(data.Item("dlls").ToString)
            For i = 0 To DllsJson.Count - 1
                dllsToLoad.Add(DllsJson.Item(i).ToString)
            Next i
        Catch ex As Exception
            errorAuth("Error loading data")
            Exit Sub
        Finally
            state.userId = cardId.Text
            state.authOk = True
        End Try

        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonLatResult.ContainsKey("photo") Then
                state.userPhoto = jsonLatResult.Item("photo")
            End If
            If jsonLatResult.ContainsKey("username") Then
                state.username = jsonLatResult.Item("username")
            End If
        Catch ex As Exception
            errorAuth(ex.Message.ToString)
            Exit Sub
        End Try

        SyncUI_Auth.Running = False
    End Sub

    Private Sub SyncAuthWithUIThread(sender As Object) Handles SyncUI_Auth.continueInUI
        If SyncUI_Auth.Running Then
            Exit Sub
        End If
        panelLogin.Invoke(Sub()
                              panelLogin.Visible = False
                              panelLogin.Refresh()
                          End Sub)
        Me.Invoke(Sub()
                      handleControls()
                      loadSessionFiles()
                  End Sub)

    End Sub
    Private Sub errorAuth(message As String)
        statusMessage.Text = "You need to Login"
        translations.load("messagebox")
        msgbox = New messageBoxForm(message & " " & translations.getText("tryAgain") & " ?", translations.getText("question"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)

        If (msgbox.ShowDialog = DialogResult.Cancel) Then
            System.Windows.Forms.Application.Exit()
            Exit Sub
        End If

        handleControls()
        doCardAuth()
    End Sub

#End Region

#Region "Initialize Form and Load"
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Public Sub New(_envVars As environmentVars)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        state = _envVars
        oldState = _envVars

    End Sub
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        translations = New languageTranslations(state)
        Me.SuspendLayout()

        translations.load("commonForm")
        cancelCard_lbl.Text = translations.getText("cancelBtn")
        cancelCard_lbl.Location = New Point(Me.Width - 5 - cancelCard_lbl.Width, Me.Height - 5 - cancelCard_lbl.Height)
        translations.load("loginDialog")
        access_code.Text = translations.getText("accessCode")
        cardId_lbl.Text = translations.getText("cardId")

        cardId.Text = ""
        codetxt.Text = ""
        loginBtn.Enabled = True

        codetxt.Focus()
        Me.StartPosition = FormStartPosition.CenterScreen

        PanelLogin.Location = New Point(Me.Width / 2 - (PanelLogin.Width) / 2, PanelLogin.Location.Y)

        'Copyright info
        translations.load("SplashScreen")
        VersionLabel.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        versionTitleLabel.Text = translations.getText("Version")

        Dim padding As Integer = 50

        SuspendLayout()
        versionTitleLabel.Location = animatedBackGround.PointToClient(Me.PointToScreen(versionTitleLabel.Location))
        versionTitleLabel.Parent = animatedBackGround
        versionTitleLabel.BackColor = Color.Transparent

        VersionLabel.Location = animatedBackGround.PointToClient(Me.PointToScreen(VersionLabel.Location))
        VersionLabel.Parent = animatedBackGround
        VersionLabel.BackColor = Color.Transparent

        ProgressBar.Location = animatedBackGround.PointToClient(Me.PointToScreen(ProgressBar.Location))
        ProgressBar.Parent = animatedBackGround
        ProgressBar.BackColor = Color.Transparent
        ProgressBar.Location = New Point(Me.Width - ProgressBar.Width - padding, ProgressBar.Location.Y)
        ProgressBar.Visible = False

        statusMessage.Location = animatedBackGround.PointToClient(Me.PointToScreen(statusMessage.Location))
        statusMessage.Parent = animatedBackGround
        statusMessage.BackColor = Color.Transparent
        statusMessage.Location = New Point(Me.Width - statusMessage.Width - padding, statusMessage.Location.Y)

        locationLabel.Location = animatedBackGround.PointToClient(Me.PointToScreen(locationLabel.Location))
        locationLabel.Parent = animatedBackGround
        locationLabel.BackColor = Color.Transparent
        locationLabel.Location = New Point(Me.Width - locationLabel.Width - padding, locationLabel.Location.Y)

        titleLabel.Location = animatedBackGround.PointToClient(Me.PointToScreen(titleLabel.Location))
        titleLabel.Parent = animatedBackGround
        titleLabel.BackColor = Color.Transparent
        titleLabel.Location = New Point(Me.Width - titleLabel.Width - padding, titleLabel.Location.Y)

        TitleFlavourLabel.Location = animatedBackGround.PointToClient(Me.PointToScreen(TitleFlavourLabel.Location))
        TitleFlavourLabel.Parent = animatedBackGround
        TitleFlavourLabel.BackColor = Color.Transparent
        TitleFlavourLabel.Location = New Point(Me.Width - TitleFlavourLabel.Width - padding, TitleFlavourLabel.Location.Y)

        cancelCard_lbl.Location = animatedBackGround.PointToClient(Me.PointToScreen(cancelCard_lbl.Location))
        cancelCard_lbl.Parent = animatedBackGround
        cancelCard_lbl.BackColor = Color.Transparent
        cancelCard_lbl.Location = New Point(Me.Width - cancelCard_lbl.Width - padding, cancelCard_lbl.Location.Y)

        websiteLink.Parent = animatedBackGround
        websiteLink.BackColor = Color.Transparent
        websiteLink.Location = New Point(Me.Width - websiteLink.Width - padding, websiteLink.Location.Y)

        ''quoteLabel.Location = backGroundImage.PointToClient(Me.PointToScreen(quoteLabel.Location))
        quoteOfTheDaySentenceLabel.Parent = animatedBackGround
        quoteOfTheDaySentenceLabel.BackColor = Color.Transparent
        quoteOfTheDaySentenceLabel.Location = New Point(Me.Width - quoteOfTheDaySentenceLabel.Width - padding, quoteOfTheDaySentenceLabel.Location.Y)

        weatherPic.Parent = animatedBackGround
        weatherPic.BackColor = Color.Transparent
        weatherPic.Location = New Point(Me.Width - weatherPic.Width - padding, weatherPic.Location.Y)

        weatherText.Parent = animatedBackGround
        weatherText.BackColor = Color.Transparent
        weatherText.Location = New Point(Me.Width - weatherText.Width - padding, weatherText.Location.Y)

        PanelLogin.Location = animatedBackGround.PointToClient(Me.PointToScreen(PanelLogin.Location))
        PanelLogin.Parent = animatedBackGround

        cardId_lbl.Location = animatedBackGround.PointToClient(Me.PointToScreen(cardId_lbl.Location))
        cardId_lbl.Parent = panelLogin

        cardId.Location = animatedBackGround.PointToClient(Me.PointToScreen(cardId.Location))
        cardId.Parent = panelLogin
        cardId.BackColor = Color.White

        access_code.Location = animatedBackGround.PointToClient(Me.PointToScreen(access_code.Location))
        access_code.Parent = panelLogin

        codetxt.Location = animatedBackGround.PointToClient(Me.PointToScreen(codetxt.Location))
        codetxt.Parent = panelLogin
        codetxt.BackColor = Color.White

        show_password.Location = animatedBackGround.PointToClient(Me.PointToScreen(show_password.Location))
        show_password.Parent = panelLogin

        loginBtn.Location = animatedBackGround.PointToClient(Me.PointToScreen(loginBtn.Location))
        loginBtn.Parent = panelLogin
        websiteLink.Text = state.WebsiteBaseAddr

        ResumeLayout()
        Refresh()
        SyncUI_Auth.Base = Me
        SyncUI_Dll.Base = Me
        SyncUI_serverSettings.Base = Me
        SyncUI_CrashReports.Base = Me

        MessageInfoFree_timer = New Timer()
        MessageInfoFree_timer.Interval = 500 'Timer will trigger one second after start
        AddHandler MessageInfoFree_timer.Tick, AddressOf MessageInfoFree_timer_Timer_Sub 'Timer will call this sub when done
        MessageInfoFree = True
    End Sub


    Private Sub SplashScreen_visibility(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible And Not loading Then
            loading = True
            loginSuccess = False
            ProgressBar.Value = 0
            ProgressBar.Visible = False
            ProgressBar.ResetText()
            statusMessage.Visible = True
            cardId.Text = ""
            codetxt.Text = ""
            weatherPic.Visible = False
            weatherText.Visible = False
            panelLogin.Visible = False

            SuspendLayout()
            translations.load("busyMessages")
            statusMessage.Text = "You need to Login"
            'LOAD COOL SENTENCE
            quoteOfTheDaySentenceLabel.Text = loadSentenceQuoteOfTheDay()

            ResumeLayout()

            state.loadLocation()
            'TODO get location city and country to lqabel.text
            doCardAuth()

            loading = False
        End If

        WaitForDataLoadingTimer.Enabled = True
        'ToDo: load weather info 

    End Sub

    Private Sub SplashScreen1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub
#End Region

#Region "Weather"
    Private Sub WaitForDataLoadingTimer_Tick(sender As Object, e As EventArgs) Handles WaitForDataLoadingTimer.Tick
        If state.dataLoaded Then
            If state.addonsLoaded Then
                If state.addons.ContainsKey("weather") Then
                    weatherPic.Visible = True
                    weatherText.Visible = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "SmartCard"
    Private Sub doCardAuth()
        showPass = True
        authByCard = False
        Try
            smartcard = DirectCast(loadDllObject(state, "smartcard.dll", "smartCard"), IsmartCard)
        Catch ex As Exception
            smartcard = Nothing
        End Try
        If smartcard IsNot Nothing Then
            If smartcard.SelectDevice() Then
                Dim smartCardReaders As New List(Of String)
                Dim errMsg As String = ""
                If smartcard.GetAvailableReaders(smartCardReaders, errMsg) Then
                    authByCard = True

                    cancelCard_lbl.Visible = True
                    translations.load("loginDialog")
                    statusMessage.Text = translations.getText("passCardOnReader")
                    show_password.Visible = False
                    cardId.Visible = False
                    codetxt.Enabled = False
                    cardId.Enabled = False
                    bwDoCardAuth = New BackgroundWorker()
                    bwDoCardAuth.WorkerSupportsCancellation = True
                    bwDoCardAuth.RunWorkerAsync()
                End If
            End If
        ElseIf state.userId.Equals("") Then
            panelLogin.Visible = True
        End If
    End Sub

    Private Sub bwDoCardAuth_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwDoCardAuth.DoWork
        Dim cardData(1) As String
        loginSuccess = False

        If smartcard.SelectDevice() Then
            smartcard.establishContext()
            While loginSuccess.Equals(False)
                If Not IsNothing(loadLoginData) Then
                    If Not loadLoginData.isQueueRunning And smartcard.connectCard() Then
                        If smartcard.readCardUID() AndAlso Not smartcard.getCardUIDString().Equals("") Then
                            cardData(0) = Convert.ToInt64(smartcard.getCardUIDString(), 16).ToString()
                            cardData(1) = If(Not smartcard.readStringOnCard(12, 5), "", smartcard.getReadedString())
                            e.Result = cardData
                            smartcard.Close()
                            Exit Sub
                        End If
                    End If
                End If
            End While
        End If
    End Sub

    Private Sub bwDoCardAuth_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwDoCardAuth.RunWorkerCompleted
        translations.load("busyMessages")
        statusMessage.Text = translations.getText("commServer")
        codetxt.Text = e.Result(1)
        cardId.Text = e.Result(0)
        If authByCard Then
            cancelCard_lbl.Visible = False
        Else
            cardId.Visible = False
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("login"))
        vars.Add("id", cardId.Text.ToString)
        vars.Add("type", "unknown")

        loadLoginData = New HttpDataPostData(state)
        loadLoginData.initialize()
        loadLoginData.numberOfRetryAttempts = -1
        loadLoginData.loadQueue(vars, Nothing, Nothing)
        loadLoginData.startRequest()
        SyncUI_Auth.Running = True
        AuthSarted = True
        panelLogin.Visible = False

    End Sub


#End Region

#Region "Load Session"
    Private Sub loadSessionFiles()
        SuspendLayout()
        ProgressBar.Invoke(Sub()
                               ProgressBar.Visible = True
                               Me.Refresh()
                           End Sub)

        ResumeLayout()

        AutoUpdater.ReportErrors = False
        AutoUpdater.Mandatory = True
        AddHandler AutoUpdater.ParseUpdateInfoEvent, AddressOf AutoUpdaterOnParseUpdateInfoEvent
        AutoUpdater.Start(state.updateServerAddr)


        ProgressBar.Invoke(Sub()
                               ProgressBar.Value = 0
                           End Sub)

        statusMessage.Invoke(Sub()
                                 statusMessage.Text = "Loading cloud settings..."
                                 statusMessage.Refresh()
                             End Sub)

        loadServerSettings()

        loadDllFiles()

        uploadCrashreports()
    End Sub

    '===========================================================================================================
    Private Sub AutoUpdaterOnParseUpdateInfoEvent(ByVal args As ParseUpdateInfoEventArgs)
        Dim json = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(args.RemoteData)

        args.UpdateInfo = New UpdateInfoEventArgs With {
        .CurrentVersion = New Version(json.Item("version")).ToString,
        .ChangelogURL = json.Item("changelog"),
        .DownloadURL = json.Item("url")
    }
    End Sub
#End Region

#Region "Crash Reports"
    Private Sub uploadCrashreports()
        Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
        crashFile.Refresh()
        If crashFile.Exists And state.SendDiagnosticData Then
            LoadingCounterTotalTasks = dllsToLoad.Count + state.authorizedFileTemplates.Count + 3
        Else
            LoadingCounterTotalTasks = dllsToLoad.Count + state.authorizedFileTemplates.Count + 2
        End If

        'TODO: send encryped and auth crach reports plus add latency time on more
        If crashFile.Exists And state.SendDiagnosticData Then
            translations.load("crashReport")
            statusMessage.Text = "sending crash report data..."

            Dim report As String = My.Computer.FileSystem.ReadAllText(Path.Combine(state.basePath, "crash.log"), System.Text.Encoding.UTF8)
            logs = Split(report, "-------------end report---------------")

            sendCrashData = New HttpDataPostData(state, state.crashReportServerAddr)
            sendCrashData.initialize()

            For i = 0 To logs.Length - 1
                If logs(i).Replace(" ", "").Replace(Environment.NewLine, "").Equals("") Then
                    Continue For
                End If

                Dim vars = New Dictionary(Of String, String)
                vars.Add("report", System.Uri.EscapeDataString(logs(i)))
                Dim misc = New Dictionary(Of String, String)
                misc.Add("report", i & " Crash Data Report(s) sent")

                sendCrashData.loadQueue(vars, misc, Nothing)
            Next i
            sendCrashData.InfoMessageWhileHtttpRequest = "Sending Crash Data"
            sendCrashData.TaskIDstring = "Crash Data"

            'sendCrashData.startRequest()
            SyncUI_CrashReports.Running = True
        Else
            SyncUI_CrashReports.Running = False

            ProgressBar.Invoke(Sub()
                                   ProgressBar.Value += 34
                               End Sub)
        End If
    End Sub

    Private Sub sendCrashData_requestSent(sender As Object, message As String, err As Boolean) Handles sendCrashData.requestSent
        If logs.Length < 100 Then
            Exit Sub
        End If
        If MessageInfoFree Then
            MessageInfoFree = False
        End If
        statusMessage.Invoke(Sub()
                                 statusMessage.Text = message
                                 statusMessage.Refresh()
                             End Sub)
    End Sub

    Private Sub sendCrashData_updateProgress(sender As Object, misc As Dictionary(Of String, String)) Handles sendCrashData.updateProgress
        If MessageInfoFree Then
            MessageInfoFree = False
        End If
    End Sub

    Private Sub sendCrashData_requestCompleted(sender As Object, err As Boolean) Handles sendCrashData.requestCompleted
        Try
            Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
            crashFile.Refresh()
            crashFile.Delete()
        Catch ex As Exception
            translations.load("readyMessages")
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = translations.getText("errorDeletingData")
                                 End Sub)
        Finally
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Crash Data successfully sent"
                                 End Sub)
        End Try

        SyncUI_CrashReports.Running = False

        ProgressBar.Invoke(Sub()
                               ProgressBar.Value += 34
                           End Sub)
    End Sub

    Private Sub SyncCrashReportsWithUIThread(sender As Object) Handles SyncUI_CrashReports.continueInUI
        If SyncUI_CrashReports.Running Then
            Exit Sub
        End If

        ' verify is all is loaded and ready
        checkLoadingTasks()
    End Sub

#End Region

#Region "Load Server Settings"
    Sub loadServerSettings()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("queries"))
        vars.Add("id", state.userId)
        vars.Add("request", "settings")

        errorMsgAlreadyOccurredSettings = False
        loadCloudSettingsData = New HttpDataPostData(state)
        loadCloudSettingsData.initialize()
        loadCloudSettingsData.loadQueue(vars, Nothing, Nothing)
        loadCloudSettingsData.TaskIDstring = "Settings"
        loadCloudSettingsData.startRequest()
        SyncUI_serverSettings.Running = True

        translations.load("busyMessages")
        statusMessage.Invoke(Sub()
                                 statusMessage.Text = "Loading Server Settings"
                             End Sub)
    End Sub
    Private Sub loadCloudSettingsData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadCloudSettingsData.dataArrived
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        If Not IsResponseOk(responseData) Then
            errorMsg = GetMessage(responseData)
            errorFlag = True
            GoTo Lastline
        End If

        DBsettings = loadCloudSettingsData.ConvertDataToArray("settings", state.querySettingsFields, responseData)
        If IsNothing(DBsettings) Then
            errorMsg = loadCloudSettingsData.errorMessage
            errorFlag = True
            GoTo Lastline
        End If
        state.maxWorkHoursDay = TimeSpan.Parse(DBsettings("work_hours")(0))
        state.delayDaysValidationAttendance = DBsettings("max_days_delay_validation")(0)
        state.businessName = DBsettings("company_name")(0)

Lastline:
        If errorFlag Then
            errorMsgAlreadyOccurredSettings = True
            reLoadAgain()
            Exit Sub
        End If
        LoadingCounter += 1
        SyncUI_serverSettings.Running = False
    End Sub
    Private Sub loadCloudSettingsData_requestCompleted(sender As Object, err As Boolean) Handles loadCloudSettingsData.requestCompleted
        If err Then
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Error Loading cloud settings"
                                     statusMessage.Refresh()
                                 End Sub)

            errorMsgAlreadyOccurredDLLs = True
            reLoadAgain()
            Exit Sub
        Else
            SyncUI_Dll.Running = False
            SyncUI_Dll.Running = False
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Cloud Senttings Loaded"
                                     statusMessage.Refresh()
                                 End Sub)
            ProgressBar.Invoke(Sub()
                                   ProgressBar.Value += 33
                               End Sub)
        End If

    End Sub

    Private Sub SyncServerSettingsWithUIThread(sender As Object) Handles SyncUI_serverSettings.continueInUI
        If SyncUI_serverSettings.Running Then
            Exit Sub
        End If


        statusMessage.Invoke(Sub()
                                 statusMessage.Text = "Cloud Settings done"
                                 statusMessage.Refresh()
                             End Sub)

        ' verify is all is loaded and ready
        checkLoadingTasks()

    End Sub

#End Region

#Region "Load DLL Files"
    Private Sub loadDllFiles()
        translations.load("busyMessages")
        statusMessage.Invoke(Sub()
                                 statusMessage.Text = "Loading Dynamic Libraries"
                             End Sub)
        ' dll files for the usertype
        DllFilesList = state.authorizedDLLs
        If Not DllFilesList.Count.Equals(dllsToLoad.Count) Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("(3) You need to download and install the lastest version of the program at " & state.ServerBaseAddr, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
            msgbox.ShowDialog()
            TerminateApp()
            Exit Sub
        End If

        Dim found As Boolean = False
        For i = 0 To DllFilesList.Count - 1
            found = False
            For j = 0 To dllsToLoad.Count - 1
                If dllsToLoad.ElementAt(j).Equals(DllFilesList.ElementAt(i).Key) Then
                    found = True
                    Exit For
                End If
            Next j
            If Not found Then
                Exit For
            End If
        Next i
        If Not found Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("Incorrect Dll files. You need to download and install the lastest version of the program at " & state.ServerBaseAddr, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
            msgbox.ShowDialog()
            TerminateApp()
            Exit Sub
        End If

        If Not System.IO.Directory.Exists(state.tmpPath) Then
            System.IO.Directory.CreateDirectory(state.tmpPath)
        End If

        Dim myDir As DirectoryInfo = New DirectoryInfo(state.tmpPath)
        If (myDir.EnumerateFiles().Any()) Then
            Try
                FileSystem.Kill(String.Format("{0}", state.tmpPath & "*.*"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete temporary files. Clear tmp folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
                msgbox.ShowDialog()
                TerminateApp()
                Exit Sub
            End Try
        End If

        If Not System.IO.Directory.Exists(state.templatesPath) Then
            System.IO.Directory.CreateDirectory(state.templatesPath)
        End If

        myDir = New DirectoryInfo(state.templatesPath)
        If (myDir.EnumerateFiles().Any()) Then
            Try
                FileSystem.Kill(String.Format("{0}", state.templatesPath & "*.*"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete templates files. Clear templates folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
                msgbox.ShowDialog()
                TerminateApp()
                Exit Sub
            End Try
        End If

        If Directory.EnumerateFiles(state.libraryPath, "*.dll").Count > 0 Then
            Try
                FileSystem.Kill(String.Format("{0}", state.libraryPath & "*.dll"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete dll files. Clear dll files in library folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2, state)
                msgbox.ShowDialog()
                TerminateApp()
                Exit Sub
            End Try
        End If

        get_DLL_Files = New HttpDataFilesDownload(state)
        get_DLL_Files.initialize()
        ReDim dllsLoaded(dllsToLoad.Count - 1)
        'add DLLS to queue 
        For j = 0 To dllsToLoad.Count - 1
            dllsLoaded(j) = False
            Dim vars = New Dictionary(Of String, String)
            vars.Add("task", "1100")
            vars.Add("file", dllsToLoad.ElementAt(j))

            get_DLL_Files.loadQueue(vars, Nothing, state.libraryPath)
        Next j

        'add templates to queue
        If state.authorizedFileTemplates IsNot Nothing Then
            Dim templates As Dictionary(Of String, String) = state.authorizedFileTemplates
            For j = 0 To templates.Count - 1
                Dim vars = New Dictionary(Of String, String)
                vars.Add("task", "1050")
                vars.Add("file", templates.ElementAt(j).Key)

                get_DLL_Files.loadQueue(vars, Nothing, state.templatesPath)
            Next j
        End If

        errorMsgAlreadyOccurredDLLs = False
        get_DLL_Files.TerminatedOnError = True
        get_DLL_Files.TaskIDstring = "DLLs"
        get_DLL_Files.startRequest()
        SyncUI_Dll.Running = True
    End Sub

    Private Sub getDLL_Files_requestSent(sender As Object, message As String, err As Boolean) Handles get_DLL_Files.requestSent
        If MessageInfoFree Then
            MessageInfoFree = False
        End If
        statusMessage.Invoke(Sub()
                                 statusMessage.Text = message
                                 statusMessage.Refresh()
                             End Sub)
    End Sub

    Private Sub getDLL_Files_dataArrived(sender As Object, filename As String, misc As Dictionary(Of String, String)) Handles get_DLL_Files.dataArrived
        For j = 0 To dllsToLoad.Count - 1
            If dllsToLoad.ElementAt(j).Equals(filename) Then
                dllsLoaded(j) = True
                Exit For
            End If
        Next j
    End Sub

    Private Sub getDLLfiles_requestCompleted(sender As Object, err As Boolean) Handles get_DLL_Files.requestCompleted
        If err Then
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Error Loading Dynamic Libraries"
                                     statusMessage.Refresh()
                                 End Sub)

            errorMsgAlreadyOccurredDLLs = True
            reLoadAgain()
            Exit Sub
        Else
            SyncUI_Dll.Running = False
            SyncUI_Dll.Running = False
            statusMessage.Invoke(Sub()
                                     statusMessage.Text = "Dynamic Libraries Completed"
                                     statusMessage.Refresh()
                                 End Sub)
            ProgressBar.Invoke(Sub()
                                   ProgressBar.Value += 33
                               End Sub)
        End If

    End Sub

    Private Sub SyncServerDLLsUIThread(sender As Object) Handles SyncUI_Dll.continueInUI
        If SyncUI_Dll.Running Then
            Exit Sub
        End If
        ' verify is all is loaded and ready
        CheckLoadingTasks()

    End Sub
#End Region

#Region "Form Controls & Events"
    Private Sub cancelCard_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles cancelCard_lbl.LinkClicked
        TerminateApp()
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        validateCode()
    End Sub

    Private Sub websiteLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles websiteLink.LinkClicked
        System.Diagnostics.Process.Start("http://www.sitelogistics.construction")

    End Sub

    Private Sub cardId_lbl_Click(sender As Object, e As EventArgs) Handles cardId_lbl.Click

    End Sub
#End Region

End Class
