Imports System.IO
Imports AeonLabs.Environment
Imports AeonLabs.environmentLoading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class loadingForm

    Public Property enVars As environmentVarsCore
    Private WithEvents getFiles As Network.HttpDataFilesDownload
    Private WithEvents getUpdates As Network.HttpDataPostData
    Private WithEvents taskManager As tasksManager.tasksManagerClass

    Public Sub New(_enVars As environmentVarsCore)
        enVars = _enVars

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub loadingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = My.Resources.strings.loading
        progressbar.Location = New Point(Me.Width / 2 - progressbar.Width / 2, Me.Height / 2 - progressbar.Height / 2)
        Label1.Location = New Point(Me.Width / 2 - Label1.Width / 2, progressbar.Location.Y + progressbar.Height)
        progressbar.Visible = False
        taskManager = New tasksManager.tasksManagerClass
    End Sub

    Private Sub loadingForm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim setupFile As FileInfo
        setupFile = New FileInfo(Path.Combine(enVars.libraryPath, "custom.eon"))
        setupFile.Refresh()
        'LOAD SETUP FILE
        If setupFile.Exists And enVars.customization.hasSetup Then
            'TODO
            'LOAD SETUP FILE
        End If

        If Not enVars.customization.expireDate.Equals("") Then
            Dim today As New MonthCalendar
            Dim oneYear As New MonthCalendar
            oneYear.SetDate(Date.ParseExact(enVars.customization.expireDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))
            If today.TodayDate > oneYear.SelectionStart Then 'APP EXPIRE DATE OVERDUE
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If
        End If

        ' check if local settings files exists 
        Dim settingsFile As FileInfo
        settingsFile = New FileInfo(Path.Combine(enVars.libraryPath, "settings.eon"))
        settingsFile.Refresh()

        If enVars.customization.hasLocalSettings And settingsFile.Exists Then
            ''DEFINE TASKS TO DO
            With taskManager
                .registerTask("loadLocalSettings", tasksManager.tasksManagerClass.TO_START)
                If enVars.checkForUpdatesIsEnabled And enVars.userSettings.checkForUpdatesIsEnabled Then
                    .registerTask("checkUpdates", tasksManager.tasksManagerClass.TO_START)
                End If
                .registerTask("checkPackages", tasksManager.tasksManagerClass.TO_START)
            End With
            taskManager.startListening()

            'LOAD LOCAL SETTINGS
            loadLocalSettings()

            If enVars.checkForUpdatesIsEnabled And enVars.userSettings.checkForUpdatesIsEnabled Then
                'CHECK CORE FILES UPDATES
                Dim dlVars As environmentVarsCore = enVars
                dlVars.ApiServerAddrPath = enVars.customization.updateServerAddr
                getUpdates = New Network.HttpDataPostData(dlVars)
                getUpdates.initialize()
                'add DLLS to queue 
                Dim vars = New Dictionary(Of String, String)
                vars.Add("task", "update")

                getUpdates.loadQueue(vars, Nothing, Nothing)
                taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.BUSY)
                getUpdates.startRequest()
            End If

            'ÇHECK PACKAGES
            checkPackages()

            'ÇHECK PLUGINS
            checkPlugins()
        Else
            'TODO review
            Dim temp As New environmentVarsCore
            temp.layoutDesign.loadDefaults(enVars)
            Me.Close()
        End If
    End Sub

#Region "check plugins"
    Private Sub checkPlugins()

    End Sub
#End Region

#Region "Check packages"
    Private Sub checkPackages()
        ' check if there are packages installed 
        taskManager.setStatus("checkPackages", tasksManager.tasksManagerClass.BUSY)

        Dim setupFile As FileInfo
        Dim di As DirectoryInfo = New DirectoryInfo(Path.Combine(enVars.packagesPath))
        Dim packagesToDownloadAndSetup As New Dictionary(Of String, String)
        Dim packagesToConfig As New Dictionary(Of String, String)
        Dim packagesInstalled As New Dictionary(Of String, String)
        For Each folder In di.GetDirectories
            Dim addToPackToSDownloadAndSetup As DirectoryInfo = Nothing
            Dim addToPackToConfig As DirectoryInfo = Nothing

            'check integrity of the package
            setupFile = New FileInfo(folder.FullName & "config\settings.cfg")
            setupFile.Refresh()
            If Not setupFile.Exists Then
                addToPackToSDownloadAndSetup = folder
            Else
                'load package settings (cjeck if is valid setitngs file) and check integrity of package files
                'TODO
                'çheck for updates of the package
                'TODO
                If enVars.packageUpdatesIsEnabled And enVars.userSettings.packageUpdatesIsenabled Then

                End If
                'check configuration file
                setupFile = New FileInfo(folder.FullName & "config\config.cfg")
                setupFile.Refresh()
                If Not setupFile.Exists Then
                    addToPackToConfig = folder
                Else
                    'load packages configurantion and check if is valid
                    'TODO
                End If
            End If

            If addToPackToConfig IsNot Nothing Then
                packagesToConfig.Add(addToPackToConfig.Name, addToPackToConfig.FullName)
            End If
            If addToPackToSDownloadAndSetup IsNot Nothing Then
                packagesToDownloadAndSetup.Add(addToPackToSDownloadAndSetup.Name, addToPackToSDownloadAndSetup.FullName)
            End If

            If addToPackToConfig Is Nothing And addToPackToSDownloadAndSetup Is Nothing Then
                packagesInstalled.Add(folder.Name, folder.FullName)
            End If
        Next folder

        If packagesToDownloadAndSetup.Count > 0 Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("There are corrupted packages. Do you want to reinstall again ? ", "qestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog() = DialogResult.Yes Then
                'LOAD STORE
                Try
                    Dim assembly As Reflection.Assembly = Reflection.Assembly.LoadFile(enVars.libraryPath & "store.dll")
                    Dim type As Type = assembly.[GetType]("AeonLabs.storeMainForm")
                    Dim SetupForm As Form = TryCast(Activator.CreateInstance(type), Form)

                    Dim TypesOnAssemblies As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("TypesOnAssemblies")
                    TypesOnAssemblies.SetValue(SetupForm, type)

                    Dim enVarsSetup As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("ExternalLoadEnVars")
                    enVarsSetup.SetValue(SetupForm, enVars)

                    Me.Hide()
                    SetupForm.ShowDialog()
                    taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.FINISHED)
                    If enVars.customization.hasLocalSettings Then
                        loadLocalSettings()
                    End If
                Catch ex As Exception
                    taskManager.unload()
                    msgbox = New messageBoxForm("Store error. You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Application.Exit()
                    Exit Sub
                End Try

            Else
                'TODO delete corrupted packages

            End If

        End If
        taskManager.setStatus("checkPackages", tasksManager.tasksManagerClass.FINISHED)

    End Sub
#End Region

#Region "Get updates"
    Private Sub getUpdates_requestCompleted(sender As Object, responseData As String) Handles getUpdates.requestCompleted
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonLatResult.ContainsKey("update") Then
                Dim Jupdates As JArray = JArray.Parse(jsonLatResult.Item("update").ToString)
                For Each Jupdate In Jupdates
                    Dim notif As New notificationsClass
                    With notif
                        .title = Jupdate.Item("title")
                        .message = Jupdate.Item("message")
                        .autoTaskExecute = Jupdate.Item("autotask")
                        .status = NOTIFICATIONS_UNREADED
                    End With
                    enVars.notifications.Add(notif)
                Next Jupdate
            End If
        Catch ex As Exception

        End Try

        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region


#Region "LOAD SETUP - to review"
    Private Sub loadSetupfile()
        progressbar.Bar1.Value = 0
        progressbar.Visible = True
        Dim dlVars As environmentVarsCore = enVars
        dlVars.ApiServerAddrPath = enVars.customization.updateServerAddr
        getFiles = New Network.HttpDataFilesDownload(dlVars)
        getFiles.initialize()
        'add DLLS to queue 
        Dim vars = New Dictionary(Of String, String)
        vars.Add("task", "download")
        vars.Add("file", "setup.dll")

        getFiles.loadQueue(vars, Nothing, enVars.libraryPath)
        taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.BUSY)
        getFiles.startRequest()
    End Sub

    Private Sub updateProgressStatistics(sender As Object, dataStatistics As Network.HttpDataFilesDownload._data_statistics, misc As Dictionary(Of String, String))
        If Not Me.IsHandleCreated Then
            Exit Sub
        End If

        progressbar.Invoke(Sub()
                               progressbar.Bar1.Value = dataStatistics.bytesSentReceived / dataStatistics.filesize
                           End Sub)
    End Sub

    Private Sub getfiles_requestCompleted(sender As Object, responseData As String) Handles getFiles.requestCompleted
        Try
            Dim assembly As Reflection.Assembly = Reflection.Assembly.LoadFile(enVars.libraryPath & "setup.dll")
            Dim type As Type = assembly.[GetType]("AeonLabs.setupWizardMainForm")
            Dim SetupForm As Form = TryCast(Activator.CreateInstance(type), Form)

            Dim TypesOnAssemblies As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("TypesOnAssemblies")
            TypesOnAssemblies.SetValue(SetupForm, type)

            Dim enVarsSetup As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("ExternalLoadEnVars")
            enVarsSetup.SetValue(SetupForm, enVars)

            Me.Hide()
            SetupForm.ShowDialog()
            taskManager.setStatus("downloadSetup", tasksManager.tasksManagerClass.FINISHED)
            If enVars.customization.hasLocalSettings Then
                loadLocalSettings()
            End If
        Catch ex As Exception
            taskManager.unload()
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("Setup error. You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Load Local Settings"
    Private Sub loadLocalSettings()
        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.BUSY)

        Dim loadEnv = New loadEnvironment(enVars, loadEnvironment.LOAD_SETTINGS)
        enVars = loadEnv.GetEnviroment()

        If Not enVars.stateLoaded Then
            taskManager.unload()
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("(2) You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End If
        taskManager.setStatus("loadLocalSettings", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

    Private Sub taskmanager_completed(sender As Object) Handles taskManager.tasksCompleted
        Me.Close()
    End Sub

    Private Sub exitAppLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles exitAppLink.LinkClicked
        Application.Exit()
    End Sub
End Class
