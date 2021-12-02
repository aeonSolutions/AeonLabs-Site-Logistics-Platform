Imports System.IO
Imports AeonLabs.Environment
Imports AeonLabs.environmentLoading
Imports AeonLabs.Network
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class startupBackgroundTasksClass
    Public state As environmentVarsCore
    Public WithEvents enVarsLoading As loadEnvironment

    Public Event updatePrgressBar(sender As Object, value As Integer)
    Public Event updateStatusMessage(sender As Object, message As String)
    Public Event loginError(sender As Object, message As String)
    Public Event startUpTasksCompleted(sender As Object, enVarsResult As environmentVarsCore)

    Private WithEvents loadLoginData As HttpDataPostData
    Private WithEvents loadCloudSettingsData As HttpDataPostData
    Private WithEvents sendCrashData As HttpDataGetData
    Private WithEvents loadUpdateStatusData As HttpDataGetData
    Private WithEvents getFiles As HttpDataFilesDownload
    Private WithEvents getUpdateFile As HttpDataFilesDownload

    Private WithEvents taskManager As tasksManager.tasksManagerClass

    Private dynamicAssembliesToLoad As New List(Of String)
    Private dynamicAssembliesToLoadIndex As New List(Of Integer)

    Private cardId As String

    Private LoadingCounter As Integer
    Private LoadingCounterTotalTasks As Integer = 4

    Private programUpdateStatus As Dictionary(Of String, String)

    Public Sub New(_enVars As environmentVarsCore)
        state = _enVars
    End Sub

#Region "request cloud access (login)"
    Public Sub doLogin(_cardId As String, codeTxt As String)
        cardId = _cardId

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("login"))
        vars.Add("id", cardId)
        vars.Add("idkey", codeTxt)
        vars.Add("type", "unknown")

        loadLoginData = New HttpDataPostData(state)
        loadLoginData.initialize()
        loadLoginData.loadQueue(vars, Nothing, Nothing)
        loadLoginData.startRequest()
    End Sub
    Private Sub loadLoginData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLoginData.dataArrived

        If Not IsResponseOk(responseData) Then
            RaiseEvent loginError(Me, GetMessage(responseData))
            Exit Sub
        End If

        dynamicAssembliesToLoad = New List(Of String)

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)

            'USER CREDENTIALS
            state.userType = data.Item("type").ToString
            state.userConnType = data.Item("conntype").ToString
            state.username = data.Item("username").ToString

            'USER PROFILE PHOTO
            If data.ContainsKey("photo") Then
                state.userPhoto = data.Item("photo")
            End If

            'PROGRAM UPDATE STAUTS
            If data.ContainsKey("status") Then
                Dim jsonPuStatus = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(data.Item("status").ToString)
                programUpdateStatus.Add("version", jsonPuStatus.Item("version").ToString)
                programUpdateStatus.Add("url", jsonPuStatus.Item("url").ToString)
                programUpdateStatus.Add("changelog", jsonPuStatus.Item("changelog").ToString)
                programUpdateStatus.Add("checksum", jsonPuStatus.Item("checksum").ToString)
                programUpdateStatus.Add("mandatory", jsonPuStatus.Item("mandatory").ToString)
            End If

            'LOAD DYNAMIC ASSEMBLIES
            If data.ContainsKey("dlls") And state.customization.hasDynamicAssemblies Then
                Dim DllsJson = JArray.Parse(data.Item("dlls").ToString)
                For i = 0 To DllsJson.Count - 1
                    dynamicAssembliesToLoad.Add(DllsJson.Item(i).ToString)
                Next i
            End If

        Catch ex As Exception
            state.successLogin = False
            state.userId = ""
            ''TODO message error
            RaiseEvent loginError(Me, "")
            Exit Sub
        Finally
            state.userId = cardId

            'TODO
            'add raise event here to load TOTP dialog for code verification
            'in case of needed to download dynamic assemblies outside the assemblies defined as static
            If state.customization.hasDynamicAssemblies Then

            Else
                'only static assemblies
                state.successLogin = True
            End If
        End Try

        'ÇONTINUE LOADING =========================================
        ''DEFINE TASKS TO DO
        With taskManager
            .registerTask("loadEnvironmentVarsFromCloud", tasksManager.tasksManagerClass.TO_START)
            .registerTask("loadServerSettings", tasksManager.tasksManagerClass.TO_START)
            .registerTask("sendCrashReports", tasksManager.tasksManagerClass.TO_START)
            .registerTask("loadCloudFiles", tasksManager.tasksManagerClass.TO_START)
            .registerTask("checkUpdates", tasksManager.tasksManagerClass.TO_START)
        End With
        taskManager.startListening()

        RaiseEvent updatePrgressBar(Me, 0)

        'Calculating number of tasks to do
        LoadingCounter = 0
        Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
        crashFile.Refresh()
        If crashFile.Exists And state.SendDiagnosticData Then
            LoadingCounterTotalTasks = dynamicAssembliesToLoad.Count + state.authorizedFileTemplates.Count + 3
        Else
            LoadingCounterTotalTasks = dynamicAssembliesToLoad.Count + state.authorizedFileTemplates.Count + 2
        End If

        '' in between load settings from cloud
        loadEnvironmentVarsFromCloud()
        loadServerSettings()
        sendCrashReports()
        loadCloudFiles()

        If Not My.Application.Info.Version.ToString.Equals(programUpdateStatus("version")) And programUpdateStatus("mandatory").Equals("true") Then
            RaiseEvent updateStatusMessage(Me, "checking for updates ...")

            getUpdateFile = New HttpDataFilesDownload(state, state.customization.updateServerAddr)
            getUpdateFile.initialize()
            Dim vars = New Dictionary(Of String, String)
            vars.Add("key", programUpdateStatus("checksum"))
            getUpdateFile.loadQueue(vars, Nothing, state.templatesPath)
            getUpdateFile.startRequest()
            taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.BUSY)
        End If
    End Sub
#End Region

#Region "updateApp"
    Private Sub getUpdateFile_updateProgressStatistics(sender As Object, dataStatistics As HttpDataFilesDownload._data_statistics, misc As Dictionary(Of String, String)) Handles getUpdateFile.updateProgressStatistics
        RaiseEvent updatePrgressBar(Me, CInt(dataStatistics.bytesSentReceived / dataStatistics.filesize * 100))
    End Sub
    Private Sub getUpdateFile_dataArrived(sender As Object, filenamePAth As String, misc As Dictionary(Of String, String)) Handles getUpdateFile.dataArrived
        Try
            Dim setupFile = New FileInfo(filenamePAth)
            setupFile.Refresh()
            If setupFile.Exists Then
                Process.Start(filenamePAth)
                Application.Exit()
            End If
        Catch ex As Exception
            RaiseEvent updateStatusMessage(Me, "Error downloading update")
        End Try
        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

#Region "sendCrashData"
    Private Sub sendCrashReports()
        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.BUSY)

        'TODO: send encryped and auth crach reports plus add latency time on more
        Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
        crashFile.Refresh()
        If crashFile.Exists And state.SendDiagnosticData AndAlso BasicLibraries.FileInUse(Path.Combine(state.basePath, "crash.log")) Then
            RaiseEvent updateStatusMessage(Me, "sending crash report data...")

            Dim report As String = My.Computer.FileSystem.ReadAllText(Path.Combine(state.basePath, "crash.log"), System.Text.Encoding.UTF8)
            Dim logs As String() = Split(report, "-------------end report---------------")

            sendCrashData = New HttpDataGetData(state, state.customization.crashReportServerAddr)
            sendCrashData.initialize()

            For i = 0 To logs.Length - 1
                If logs(i).Replace(" ", "").Replace(System.Environment.NewLine, "").Equals("") Then
                    Continue For
                End If

                Dim vars = New Dictionary(Of String, String)
                vars.Add("uuid", state.userId)
                vars.Add("report", System.Uri.EscapeDataString(logs(i)))

                sendCrashData.loadQueue(vars, Nothing, state.libraryPath)
            Next i
            sendCrashData.startRequest()
        Else
            taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
        End If
    End Sub

    Private Sub sendCrashData_requestCompleted(sender As Object, responseData As String) Handles sendCrashData.requestCompleted
        Try
            Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
            crashFile.Refresh()
            crashFile.Delete()
        Catch ex As Exception
            RaiseEvent updateStatusMessage(Me, My.Resources.strings.errorDeletingData)
        Finally
            RaiseEvent updateStatusMessage(Me, My.Resources.strings.crashDataSent)
        End Try

        LoadingCounter += 1
        RaiseEvent updatePrgressBar(Me, CInt((LoadingCounter / LoadingCounterTotalTasks) * 100))

        taskManager.setStatus("checkUpdates", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

#Region "loadCloudFiles"
    Private Sub loadCloudFiles()
        taskManager.setStatus("loadCloudFiles", tasksManager.tasksManagerClass.BUSY)

        LoadingCounter += 1
        RaiseEvent updatePrgressBar(Me, CInt((LoadingCounter / LoadingCounterTotalTasks) * 100))
        RaiseEvent updateStatusMessage(Me, "Loading cloud settings...")

        'TODO review
        dynamicAssembliesToLoadIndex = New List(Of Integer)
        Dim found As Boolean = False
        For i = 0 To state.assemblies.Count - 1
            found = False
            For j = 0 To dynamicAssembliesToLoad.Count - 1
                If dynamicAssembliesToLoad.ElementAt(j).Equals(state.assemblies.ElementAt(i).Key) Then
                    dynamicAssembliesToLoadIndex.Add(i)
                    found = True
                    Exit For
                End If
            Next j
            If Not found Then
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Incorrect Dll files. You need to download and install the lastest version of the program at " & state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                taskManager.unload()
                Application.Exit()
                Exit Sub
            End If
        Next i

        If Not Directory.Exists(state.tmpPath) Or Not Directory.Exists(state.libraryPath) Or Not Directory.Exists(state.templatesPath) Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("Folders not found. You need to download and install the lastest version of the program at " & state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End If

        Dim myDir As DirectoryInfo = New DirectoryInfo(state.tmpPath)
        If (myDir.EnumerateFiles().Any()) Then
            Try
                FileSystem.Kill(String.Format("{0}", state.tmpPath & "*.*"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete temporary files. Clear tmp folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End Try
        End If

        myDir = New DirectoryInfo(state.templatesPath)
        If (myDir.EnumerateFiles().Any()) Then
            Try
                FileSystem.Kill(String.Format("{0}", state.templatesPath & "*.*"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete templates files. Clear templates folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End Try
        End If

        If Directory.EnumerateFiles(state.libraryPath, "*.dll").Count > 0 Then
            Try
                FileSystem.Kill(String.Format("{0}", state.libraryPath & "*.dll"))
            Catch ex As Exception
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Unable do delete dll files. Clear dll files in library folder and start the App again.", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                taskManager.unload()
                Application.Exit()
                Exit Sub
            End Try
        End If

        getFiles = New HttpDataFilesDownload(state)
        getFiles.initialize()
        'add DLLS to queue 
        For j = 0 To dynamicAssembliesToLoad.Count - 1
            Dim vars = New Dictionary(Of String, String)
            vars.Add("task", "1100")
            vars.Add("file", dynamicAssembliesToLoad.ElementAt(j))

            getFiles.loadQueue(vars, Nothing, state.libraryPath)
        Next j

        'add templates to queue
        If state.authorizedFileTemplates IsNot Nothing Then
            Dim templates As Dictionary(Of String, String) = state.authorizedFileTemplates
            For j = 0 To templates.Count - 1
                Dim vars = New Dictionary(Of String, String)
                vars.Add("task", "1050")
                vars.Add("file", templates.ElementAt(j).Key)

                getFiles.loadQueue(vars, Nothing, state.templatesPath)
            Next j
        End If

        getFiles.startRequest()

    End Sub

    Private Sub getFiles_dataArrived(sender As Object, filenamePAth As String, misc As Dictionary(Of String, String)) Handles getFiles.dataArrived
        RaiseEvent updatePrgressBar(Me, getFiles.CompletionPercentage)
        RaiseEvent updateStatusMessage(Me, getFiles.statusMessage)
    End Sub

    Private Sub getfiles_requestCompleted(sender As Object, responseData As String) Handles getFiles.requestCompleted
        Try
            'TODO review
            For i = 0 To state.assemblies.Count - 1
                Dim assembly As Reflection.Assembly = Reflection.Assembly.LoadFile(state.libraryPath & state.assemblies.ElementAt(i).Key)
                state.assemblies(i).Values.ElementAt(0).AssemblyObject = assembly.[GetType](state.assemblies(i).Values.ElementAt(0).spaceName)
            Next


        Catch ex As Exception
            'TODO save crash report
            taskManager.unload()
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("Error Loading libraries. You need to download and install the lastest version of the program at " & state.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End Try

        taskManager.setStatus("loadCloudFiles", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

#Region "load envirnment from cloud"
    Private Sub loadEnvironmentVarsFromCloud()
        taskManager.setStatus("loadEnvironmentVarsFromCloud", tasksManager.tasksManagerClass.BUSY)
        enVarsLoading = New environmentLoading.loadEnvironment(state)
        enVarsLoading.loadAddons()
        ''see result above
    End Sub
#End Region

#Region "load cloud settings"
    Private Sub loadServerSettings()
        taskManager.setStatus("loadServerSettings", tasksManager.tasksManagerClass.BUSY)

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", state.taskId("queries"))
        vars.Add("request", "settings")

        loadCloudSettingsData = New HttpDataPostData(state)
        loadCloudSettingsData.initialize()
        loadCloudSettingsData.loadQueue(vars, Nothing, Nothing)
        loadCloudSettingsData.startRequest()
    End Sub
    Private Sub loadCloudSettingsData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadCloudSettingsData.dataArrived
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        If Not IsResponseOk(responseData) Then
            errorMsg = GetMessage(responseData)
            errorFlag = True
            GoTo Lastline
        End If

        Dim DBsettings As Dictionary(Of String, List(Of String))
        DBsettings = loadCloudSettingsData.ConvertDataToArray("settings", state.querySettingsFields, responseData)
        If IsNothing(DBsettings) Then
            errorMsg = loadCloudSettingsData.errorMessage
            errorFlag = True
            GoTo Lastline
        End If
        state.maxWorkHoursDay = TimeSpan.Parse(DBsettings("work_hours")(0))
        state.delayDaysValidationAttendance = DBsettings("max_days_delay_validation")(0)
        state.customization.businessname = DBsettings("company_name")(0)

Lastline:
        If errorFlag Then
            Dim MsgBox As messageBoxForm = New messageBoxForm(errorMsg & ". " & My.Resources.strings.tryAgain & " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If MsgBox.ShowDialog() = DialogResult.Yes Then
                loadServerSettings()
            Else
                RaiseEvent loginError(Me, errorMsg)
            End If
            Exit Sub
        End If
        LoadingCounter += 1
        RaiseEvent updatePrgressBar(Me, CInt((LoadingCounter / LoadingCounterTotalTasks) * 100))
        RaiseEvent updateStatusMessage(Me, "Loading cloud settings...done")

        taskManager.setStatus("loadServerSettings", tasksManager.tasksManagerClass.FINISHED)
    End Sub
#End Region

    Private Sub enVarsLoading_environmentDataLoadedCompleted(task As Integer) Handles enVarsLoading.environmentDataLoadedCompleted
        If task.Equals(loadEnvironment.LOAD_ADDONS) Then
            taskManager.setStatus("loadEnvironmentVarsFromCloud", tasksManager.tasksManagerClass.FINISHED)
        End If
    End Sub

    Private Sub taskmanager_completed(sender As Object) Handles taskManager.tasksCompleted
        RaiseEvent startUpTasksCompleted(Me, state)
    End Sub
End Class
