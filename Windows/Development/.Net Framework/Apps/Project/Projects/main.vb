

Imports ConstructionSiteLogistics.Libraries.Core

Module main
    Public bundleSpecificVars As New bundleSpecificVarsClass
    Public envVars As environmentVars

    Public Sub main()
        envVars = New environmentVars(LOAD_SETTINGS)
        load_tasks_IDs()
        load_Athorized_DLLs()
        loadAuthorizedFileTemplates()
        Load_menu()
        envVars.softwareAccessMode = "office"  'possible values: office, site, contractor

        Application.Run(New SplashScreen(envVars))
    End Sub

    Public Sub loadAuthorizedFileTemplates()
        Dim office As New Dictionary(Of String, String)
        Dim site As New Dictionary(Of String, String)
        Dim contractor As New Dictionary(Of String, String)

        office.Add("contract", "contrato.rtf")
        office.Add("destacamento", "destacamento.rtf")
        office.Add("act", "act.rtf")
        office.Add("ficha", "ficha.rtf")

        site.Add("journal", "journal.rtf")

        envVars.authorizedFileTemplates = office
    End Sub
    Private Sub load_Athorized_DLLs()
        Dim office As New Dictionary(Of String, String)
        Dim site As New Dictionary(Of String, String)
        Dim contractor As New Dictionary(Of String, String)
        Dim officeAdm As New Dictionary(Of String, String)

        officeAdm.Add("attendance.dll", "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29")
        officeAdm.Add("attendance.report.dll", "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0")
        officeAdm.Add("absences.dll", "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9")
        officeAdm.Add("clothes.dll", "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n")
        officeAdm.Add("workers.dll", "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP")
        officeAdm.Add("workers.locate.dll", "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB")
        officeAdm.Add("workers.templates.dll", "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa")
        officeAdm.Add("site.management.dll", "G6mdfqhUpYpP0B2mnd8OfRymDjM7e13j")
        officeAdm.Add("site.dll", "WIoPiMsFF0MF0nWV6R8BhBmMpB30qlZD")
        officeAdm.Add("teams.dll", "8cQ0c1vvb9OxLn5iNzn1xsN2hJodh4Ab")

        office.Add("attendance.dll", "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29")
        office.Add("attendance.report.dll", "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0")
        office.Add("absences.dll", "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9")
        office.Add("clothes.dll", "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n")
        office.Add("workers.dll", "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP")
        office.Add("workers.locate.dll", "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB")
        office.Add("workers.templates.dll", "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa")
        office.Add("site.management.dll", "G6mdfqhUpYpP0B2mnd8OfRymDjM7e13j")

        site.Add("absences.dll", "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9")
        site.Add("attendance.dll", "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29")
        site.Add("attendance.report.dll", "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0")
        site.Add("clothes.dll", "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n")
        site.Add("site.dll", "WIoPiMsFF0MF0nWV6R8BhBmMpB30qlZD")
        site.Add("teams.dll", "8cQ0c1vvb9OxLn5iNzn1xsN2hJodh4Ab")

        contractor.Add("attendance.dll", "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29")
        contractor.Add("clothes.dll", "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n")
        contractor.Add("site.dll", "WIoPiMsFF0MF0nWV6R8BhBmMpB30qlZD")
        contractor.Add("site.management.dll", "G6mdfqhUpYpP0B2mnd8OfRymDjM7e13j") '?
        contractor.Add("teams.dll", "8cQ0c1vvb9OxLn5iNzn1xsN2hJodh4Ab")

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
        With bundleSpecificVars
            .addMenuItem("username", Nothing, Nothing, False, 0) ' menu header
            .addMenuItem("myProfile", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("settings", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("logout", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("exit", Nothing, Nothing, True, 0) ' menu item
            .addMenu("profile")

            .addMenuItem("data", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("export", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("activityHistory", Nothing, Nothing, False, 0) ' menu item
            .addMenu("data")

            .addMenuItem("workers", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("dossier", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("locate", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("documents", Nothing, Nothing, False, 0) ' menu item
            .addMenu("workers")

            .addMenuItem("site", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("attendance", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("absences", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("closedDays", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("clothes", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("teams", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("materialsReception", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("activity", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("weather", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("mobileDevices", Nothing, Nothing, False, 0) ' menu item
            .addMenu("site")

            .addMenuItem("clients", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("dossier", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("bordereau", Nothing, Nothing, False, 0) ' menu item
            .addMenu("clientes")

            .addMenuItem("reports", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("workers", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("attendance", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("absences", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("clothes", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("closedDays", Nothing, Nothing, False, 0) ' menu item
            .addMenuItem("materialsReception", Nothing, Nothing, False, 0) ' menu item
            .addMenu("reports")

            .addMenuItem("help", Nothing, Nothing, True, 0) ' menu item
            .addMenuItem("about", Nothing, Nothing, False, 0) ' menu item
            .addMenu("help")
        End With
    End Sub
End Module
