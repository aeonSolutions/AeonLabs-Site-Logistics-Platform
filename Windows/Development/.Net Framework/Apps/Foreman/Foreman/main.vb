Imports System.IO
Imports System.Windows.Forms.AxHost
Imports ConstructionSiteLogistics.Libraries.Core

Module main
    Public envVars As environmentVars

    Public Sub main()
        envVars = New environmentVars(LOAD_SETTINGS)
        load_tasks_IDs()
        load_Athorized_DLLs()
        loadAuthorizedFileTemplates()
        Load_menu()
        envVars.softwareAccessMode = "office"  'possible values: office, site, contractor


        Dim settingsFile As FileInfo
        settingsFile = New FileInfo(Path.Combine(envVars.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()

        If settingsFile.Exists = False Then
            Dim setupFile As FileInfo
            setupFile = New FileInfo(Path.Combine(envVars.libraryPath, "setup.dll"))
            setupFile.Refresh()
            If settingsFile.Exists = False Then
                envVars.softwareAccessMode = "installOffice"
                Application.Run(New setupWizardMainForm(envVars))
            Else
                Dim msgbox As messageBoxForm
                msgbox = New messageBoxForm("Setup DLL not found. You need to download and install the lastest version of the program at http://www.sitelogistics.construction ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0, envVars)
                msgbox.ShowDialog()
                Application.Exit()
                Exit Sub
            End If
        End If

        Dim today As New MonthCalendar
        Dim oneYear As New MonthCalendar
        oneYear.SetDate(Date.ParseExact("26/02/2025", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo))

        If Not settingsFile.Exists Or today.TodayDate > oneYear.SelectionStart Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("You need to download and install the lastest version of the program at http://www.sitelogistics.construction ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0, envVars)
            msgbox.ShowDialog()
            Application.Exit()
        End If

        Dim settings As New Settings(New environmentVarsCore)
        Dim newState As environmentVarsCore = Nothing

        newState = settings.load()
        If IsNothing(newState) Then
            Dim msgbox As messageBoxForm
            msgbox = New messageBoxForm("(2) You need to download and install the lastest version of the program at http://www.sitelogistics.construction ", "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0, envVars)
            msgbox.ShowDialog()
            Application.Exit()
            Exit Sub
        End If

        Application.Run(New SplashScreen(envVars))
    End Sub

    Public Sub loadAuthorizedFileTemplates()
        Dim office As New Dictionary(Of String, String)

        office.Add("contract", "contrato.rtf")
        office.Add("destacamento", "destacamento.rtf")
        office.Add("act", "act.rtf")
        office.Add("ficha", "ficha.rtf")

        envVars.authorizedFileTemplates = office
    End Sub
    Private Sub load_Athorized_DLLs()
        Dim office As New Dictionary(Of String, String)

        office.Add("attendance.dll", "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29")
        office.Add("attendance.report.dll", "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0")
        office.Add("absences.dll", "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9")
        office.Add("clothes.dll", "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n")
        office.Add("workers.dll", "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP")
        office.Add("workers.locate.dll", "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB")
        office.Add("workers.templates.dll", "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa")
        office.Add("site.management.dll", "G6mdfqhUpYpP0B2mnd8OfRymDjM7e13j")

        envVars.authorizedDLLs = office
    End Sub
    Private Sub load_tasks_IDs()
        With envVars
            .taskId.Add("login", "1")
            .taskId.Add("addons", "2")
            .taskId.Add("siteClosedDays", "3")
            .taskId.Add("unscheduledWorks", "4")
            .taskId.Add("attendanceRecords", "5")
            .taskId.Add("queries", "6")
            .taskId.Add("attendance", "7")
            .taskId.Add("attendanceAnnotations", "8")
            .taskId.Add("holidays", "9")
            .taskId.Add("workerAbsenses", "10")
            .taskId.Add("workerClothes", "11")
            .taskId.Add("siteMaterialsReception", "12")
            .taskId.Add("mobileDevices", "13")
            .taskId.Add("site", "14")
            .taskId.Add("siteManagers", "15")
            .taskId.Add("siteGeneralContractors", "16")
            .taskId.Add("siteSections", "17")
            .taskId.Add("siteTeams", "18")
            .taskId.Add("siteActivitiesMap", "19")
            .taskId.Add("photos", "20")
            .taskId.Add("siteDailyProduction", "21")
            .taskId.Add("siteMaterialsDelivery", "22")
            .taskId.Add("journalattendance", "23")
            .taskId.Add("journalLog", "24")
            .taskId.Add("journal", "25")
            .taskId.Add("templateFiles", "1050")
            .taskId.Add("workerLocate", "27")
            .taskId.Add("workerDossier", "28")
            .taskId.Add("workerLimosas", "29")
            .taskId.Add("userProfile", "31")
            .taskId.Add("siteActivitiesMapEdit", "32")
        End With
    End Sub
    Private Sub Load_menu()

        With envVars.bundleSpecificVars
            .addMenuItem("username", Nothing, False, "worker.icon.png", False, 0) ' menu header
            .addMenuItem("menuItemMyProfile", Nothing, True, "", True, 0) ' menu item
            .addMenuItem("menuItemSettings", Nothing, True, "", True, 0) ' menu item
            .addMenuItem("menuItemLogout", Nothing, False, "", True, 0) ' menu item
            .addMenuItem("menuExitTitle", Nothing, False, "", True, 0) ' menu item
            .addMenu("profile")

            .addMenuItem("menuDataTitle", Nothing, False, "printer.icon.png", True, 0) ' menu item
            .addMenuItem("menuItemExport", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemActivityHistory", Nothing, False, "", False, 0) ' menu item
            .addMenu("data")

            .addMenuItem("menuWorkersTitle", Nothing, False, "worker.icon.png", True, 0) ' menu item
            .addMenuItem("menuItemWorkerFile", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemLocateWorker", "workerLocateForm", True, "", False, 0) ' menu item
            .addMenuItem("menuItemWorkerDocs", Nothing, False, "", False, 0) ' menu item
            .addMenu("workers")

            .addMenuItem("menuSiteTitle", Nothing, False, "project.png", True, 0) ' menu item
            .addMenuItem("menuIytemDailyAttendance", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemAbsences", Nothing, True, "", False, 0) ' menu item
            .addMenuItem("menuItemFermetures", Nothing, True, "", False, 0) ' menu item
            .addMenuItem("menuItemClothes", "workersClothesForm", True, "", False, 0) ' menu item
            .addMenuItem("menuItemTeams", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemMaterialDelivery", Nothing, True, "", False, 0) ' menu item
            .addMenuItem("menuItemSiteActivity", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemMeteo", Nothing, True, "", False, 0) ' menu item
            .addMenuItem("menuItemSiteDevices", Nothing, True, "", False, 0) ' menu item
            .addMenu("site")

            .addMenuItem("menuClientsTitle", Nothing, False, "contracts.icon.png", True, 0) ' menu item
            .addMenuItem("menuItemSiteFile", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemSiteActivities", Nothing, False, "", False, 0) ' menu item
            .addMenu("clientes")

            .addMenuItem("menuReportsTitle", Nothing, False, "reports.icon.png", True, 0) ' menu item
            .addMenuItem("menuItemReportWorkers", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemReportAttendance", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemReportAbsences", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemReportClothes", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemReportSiteClosures", Nothing, False, "", False, 0) ' menu item
            .addMenuItem("menuItemReportMaterialsDelivery", Nothing, False, "", False, 0) ' menu item
            .addMenu("reports")

            .addMenuItem("menuHelpTitle", Nothing, False, "help.icon.png", True, 0) ' menu item
            .addMenuItem("about", Nothing, True, "", False, 0) ' menu item
            .addMenu("help")
        End With
    End Sub
End Module
