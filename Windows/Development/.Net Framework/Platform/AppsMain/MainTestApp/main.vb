
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Runtime.Remoting
Imports AeonLabs
Imports AeonLabs.Environment
Imports AeonLabs.environmentLoading
Imports AeonLabs.Network
Imports AeonLabs.tasksManager
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module main
#Region "variables, fields, ..."
    Public enVars As New environmentVarsCore
    Public updateMainApp As environmentVarsCore.updateMainLayoutDelegate

    Private WithEvents getUpdates As Network.HttpDataPostData

    Private waitForTasksToComplete As Boolean = True
    Private tasksCompletedSuccessfully As Boolean = False
    Private updateEnv As New updateEnvironmentClass
#End Region


#Region "sub main"
    Public Sub main()
        Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(False)

        'Instantiating the delegate for update data from child forms
        updateMainApp = AddressOf updateMain

        'set customization option
        enVars.customization.hasCodedCustomizationSettings = True

        'check for customization file
        If Not LoadCustomizationFile() Then
            Exit Sub
        End If

        ' check if local settings files exists 
        Dim settingsFile As FileInfo
        settingsFile = New FileInfo(Path.Combine(enVars.libraryPath, "settings.eon"))
        settingsFile.Refresh()

        If enVars.customization.hasLocalSettings And settingsFile.Exists Then
            'LOAD LOCAL SETTING
            loadLocalSettings()
        End If

        'LOAD CONFIG MENU TREE
        Dim loadMenu As menuOptions = New menuOptions
        enVars = loadMenu.Load(enVars)

        'TODO: LOAD USER DEFINED MENU TREE

        'Load assemblies across multiple locations
        Dim loadAssemblies As New assembliesToLoadClass
        enVars = loadAssemblies.Load(enVars)
        'TODO: LOAD USER BOUGHT ASSEMBLIES (PACKAGES, WIDGETS, LAYOUTS)
        'loadUserAssemblies()

        'TODO REVIEW
        'LOAD CONFIG API CALL IDS
        loadAPItasksIDs()

        'LOAD CONFIG STATIC TEMPLATE FILES AUTHORIZED
        loadAuthorizedFileTemplates()

        'TODO: CHECK CORE FILES UPDATES
        ' check if there are any downloaded core files to be updated

        'LOAD STARTUP FORM
        loadStartupForm()

        'LOAD MAIN LAYOUT ASSEMBLY
        'TODO LOAD custom layut in alternative to default layout // if previous got error dont load cusom, load default
        ' check if local settings files exists 
        Dim mainForm As FormCustomized

        mainForm = loadLayout(enVars.customization.designLayoutCustomAssemblyFileName, enVars.customization.designLayoutCustomAssemblyNameSpace)
        If mainForm Is Nothing Then
            mainForm = loadLayout(enVars.customization.designLayoutAssemblyFileName, enVars.customization.designLayoutAssemblyNameSpace)
            If mainForm Is Nothing Then
                MsgBox("Error initializing main layout file:" + enVars.customization.designLayoutAssemblyFileName + ". Name spaxe:" + enVars.customization.designLayoutAssemblyNameSpace)
                Application.Exit()
                Exit Sub
            End If
        End If

        'start the main layout
        Application.Run(mainForm)
    End Sub
#End Region

#Region "Load Layout"
    Private Function loadLayout(layout As String, layoutNameSpace As String) As FormCustomized
        Dim mainForm As FormCustomized = Nothing
        Dim typeMainLayout As Type = Nothing

        Dim layoutFile As FileInfo
        layoutFile = New FileInfo(enVars.basePath & enVars.customization.designLayoutAssemblyFileName)
        layoutFile.Refresh()
        If Not layoutFile.Exists Then
            Return Nothing
            Microsoft.VisualBasic.MsgBox("Layout file not found. You need to reinstall the program")

        End If
        Dim assembly As Reflection.Assembly = Nothing
        Try
            assembly = Reflection.Assembly.LoadFile(layout)
            Dim typeMainLayoutIni = assembly.[GetType](layoutNameSpace & ".initializeLayoutClass")
            Dim iniClass = Activator.CreateInstance(typeMainLayoutIni, True)
            Dim methodInfo = typeMainLayoutIni.GetMethod("AssembliesToLoadAtStart")
            enVars.assemblies = methodInfo.Invoke(iniClass, Nothing)

            typeMainLayout = assembly.[GetType](layoutNameSpace & ".mainAppLayoutForm")
            mainForm = TryCast(Activator.CreateInstance(typeMainLayout, enVars), FormCustomized)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region

#Region "load startup/splash form"
    Private Sub loadStartupForm()
        'to delete
        Dim dataUpdate As New updateMainAppClass
        dataUpdate.envars = enVars
        dataUpdate.envars.successLogin = True
        dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT
        updateMainApp.Invoke(Nothing, dataUpdate)
        Exit Sub

        'LOAD STARTUP & LOGIN DLG
        Dim layoutFile As FileInfo
        layoutFile = New FileInfo(enVars.basePath & enVars.customization.designStartupLayoutAssemblyFileName)
        layoutFile.Refresh()
        If Not layoutFile.Exists Then
            Microsoft.VisualBasic.MsgBox("Startup Layout file not found. You need to reinstall the program")
            Application.Exit()
            Exit Sub
        End If
        Dim typeStartupLayout As Type = Nothing
        Dim startupLayout As FormCustomized = Nothing
        Dim assembly As Reflection.Assembly = Nothing
        Try
            assembly = Reflection.Assembly.LoadFile(enVars.basePath & enVars.customization.designStartupLayoutAssemblyFileName)
            typeStartupLayout = assembly.[GetType](enVars.customization.designLayoutAssemblyNameSpace & ".LayoutStartUpForm")
            startupLayout = TryCast(Activator.CreateInstance(typeStartupLayout, enVars, updateMainApp), FormCustomized)
        Catch ex As Exception
            MsgBox("Error loading main layout:" & ex.Message)
            Application.Exit()
            Exit Sub
        End Try

        'start the startup layout and waits for update answer from form
        Application.Run(startupLayout)
    End Sub
#End Region

#Region "update main and load main layout"
    Public Sub updateMain(sender As Object, ByRef updateContents As updateMainAppClass)
        enVars = updateContents.envars
        If Not enVars.successLogin And enVars.customization.hasLogin Then
            tasksCompletedSuccessfully = False
        Else
            tasksCompletedSuccessfully = True
        End If
        waitForTasksToComplete = False
    End Sub
#End Region

#Region "Load Authorized file templates"
    Public Sub loadAuthorizedFileTemplates()
        Dim office As New Dictionary(Of String, String)

        office.Add("contract", "contrato.rtf")
        office.Add("destacamento", "destacamento.rtf")
        office.Add("act", "act.rtf")
        office.Add("ficha", "ficha.rtf")

        enVars.authorizedFileTemplates = office
    End Sub
#End Region

#Region "load API task IDs"
    Private Sub loadAPItasksIDs()
        Dim apiTasksSet = My.Resources.apiTasks.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
        With enVars
            For Each task In apiTasksSet
                If Not task.value.Equals("") Then
                    .taskId.Add(task.value, task.key)
                End If
            Next
        End With
    End Sub
#End Region

#Region "Load Local Settings"
    Private Sub loadLocalSettings()

        Dim loadEnv = New loadEnvironment(enVars, loadEnvironment.LOAD_SETTINGS)
        enVars = loadEnv.GetEnviroment()

        If Not enVars.stateLoaded Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("(2) You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End If
    End Sub
#End Region

#Region "load customization file"
    Private Function LoadCustomizationFile() As Boolean
        Dim custom = New FileInfo(enVars.libraryPath & "custom.eon")
        custom.Refresh()
        If custom.Exists And Not enVars.customization.hasCodedCustomizationSettings Then
            enVars.customization.loadCustomizationFile(enVars)
        ElseIf enVars.customization.hasCodedCustomizationSettings Then
            'LOAD Çustomizations coded in for the App
            enVars = setupCustomizationVariables(enVars)
        End If

        'check if program has an expire date
        If Not enVars.customization.expireDate.Equals("") Then
            Dim today As New MonthCalendar
            Dim oneYear As New MonthCalendar
            oneYear.SetDate(Date.ParseExact(enVars.customization.expireDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))
            If today.TodayDate > oneYear.SelectionStart Then 'APP EXPIRE DATE OVERDUE
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("You need to download and install the lastest version of the program at " & enVars.customization.websiteToLoadProgram, "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Application.Exit()
                Return False
            End If
        End If
        Return True
    End Function
#End Region

End Module
