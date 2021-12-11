Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class State
    Public CHECKING_CONNECTION As Integer = 1000
    Public NOT_CHECKING_CONNECTION As Integer = 1001

    Public imagesPath As String = String.Format("{0}\images\", Environment.CurrentDirectory)
    Public basePath As String = String.Format("{0}\", Environment.CurrentDirectory)
    Public tmpPath As String = String.Format("{0}\tmp\", Environment.CurrentDirectory)
    Public fontsPath As String = String.Format("{0}\fonts\", Environment.CurrentDirectory)
    Public libraryPath As String = String.Format("{0}\library\", Environment.CurrentDirectory)

    Public ServerBaseAddr As String = "" ' base path without final slash, ex: www.qualityconstruction.be
    Public ApiServerAddrPath As String = "/sitelogistics.construction/shared/csaml/api/index.php"
    Public ApiHttpHeaderToken = "dfhdfghfghfgjhdfgjfdj"
    Public updateServerAddr As String = "http://www.sitelogistics.construction/shared/update/update.php?task=office"
    Public crashReportServerAddr As String = "http://www.sitelogistics.construction/shared/crash/api.php?task=crash&uuid={origin}&report={report}"

    Public SettingsSecretKey = "29kdzQaFwSuNJ85t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 
    Public secretKey = "26kozQaKwRuNJ24t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 
    Public AppId As String = ""
    Public latitude As String = ""
    Public longitude As String = ""
    Public currentIpAddress As String = ""

    Public SendDiagnosticData As Boolean = False
    Public SendCrashData As Boolean = False

    Public authOk As Boolean = False
    Public userId As String = ""

    Public stateLoaded As Boolean = False
    Public stateErrorMessage As String = ""

    Public businessName As String = "Construction Site Logistics"
    Public journalResponsables As String = "José Azevedo, Miguel Silva"


    'runtime user selections and settings
    Public tableSearchOptions As New TableSearchOptionsStructure

    'INTO SETTINGS: 
    'LANGUAGE
    Public currentLang As String = ""
    Public country As String = ""
    Public defaultTranslatedLang = "fr"

    'ToDo: settings to add on DB settings table
    Public delayDaysValidationAttendance As Integer = 1
    Public AutomaticLogoutTime As New TimeSpan(0, 15, 0) '15 min timeout - integer (Hours, Minutes, Seconds) 
    Public maxMinutesForClearCheckout As Integer = 300
    Public isWorkingHoursIncompleteWorkDayHoursLogged As Boolean = False
    Public maxWorkHoursDay As TimeSpan = TimeSpan.Parse("10:00:00")

    'VISUAL STYLES
    'fonts
    Public fontTitleFile As String = "Roboto-Bold.ttf"
    Public fontTextFile As String = "Roboto-Regular.ttf"
    Public fontText, fontTitle As New PrivateFontCollection()

    'font text size
    Public buttonFontSize As Integer = 9
    Public SmallTextFontSize As Integer = 8
    Public RegularTextFontSize As Integer = 9
    Public DialogTitleFontSize As Integer = 12
    Public groupBoxTitleFontSize As Integer = 10
    'main color schemes
    Public buttonColor As Color = Color.FromArgb(131, 193, 79)
    Public dividerColor As Color = Color.FromArgb(131, 193, 79)
    Public colorMainMenu As Color = Color.FromArgb(134, 202, 102)
    Public colorMainPageHeader As Color = Color.FromArgb(92, 174, 208)

    'datatable color schemes
    Public colorFullDayValidated As Color = Color.FromArgb(192, 255, 192)
    Public colorPlannedTeam As Color = Color.FromArgb(204, 255, 117)
    Public colorPlannedChangeOfSite As Color = Color.LightSkyBlue
    Public colorPartialDayValidated As Color = Color.FromArgb(255, 218, 117)
    Public colorFermetureAnnual As Color = Color.LightGray
    Public colorRecordDeleted As Color = Color.LightGray

    Public colorAbsentDay As Color = Color.MistyRose
    Public colorWithRecord As Color = Color.Gold
    Public colorHolidays As Color = Color.FromArgb(204, 236, 255)
    Public colorWeekends As Color = Color.AliceBlue
    Public colorWithoutRecord As Color = Color.IndianRed
    Public colorDarkGray As Color = Color.Gainsboro
    Public colorLightGray As Color = Color.LightGray
    Public colorAbsense As Color = Color.PaleGoldenrod
    Public colorWorkCategories As Color = Color.Beige
    Public colorCompany As Color = Color.Linen
    Public colorSection As Color = Color.Bisque
    Public colorSite As Color = Color.Bisque

    'ADDONS
    Public addonsLoaded As Boolean = False
    Public addons As New Dictionary(Of String, String) 'addon name , url

    'QUERY FIELDS
    Public querySiteFields As String() = {"cod_site", "name", "address", "initials", "gps_lat", "gps_lon", "ref_contrato", "cod_company", "data_inicio", "data_fim", "distancia", "authentication_radius", "active", "regie_hourly", "craneman_hourly", "machinist_hourly", "regie_weekends", "machinist_weekends", "craneman_weekends", "regie_after_hours", "machinist_after_hours", "craneman_after_hours", "project_languages", "primary_lang"}
    Public queryEntreprisePartnersFields As String() = {"cod_entreprise", "name", "contact"}
    Public querySiteSectionFields As String() = {"cod_section", "cod_site", "description"}
    Public queryWorkerCategoryFields As String() = {"cod_category", "designation", "reference"}
    Public queryHolidaysFields As String() = {"date"}
    Public queryAbsenseFields As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public queryWorkersFields As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "contact112", "photo", "data_nascimento", "idade", "estado_civil", "nacionalidade",
        "cc", "cc_validade", "nif", "niss", "filhos", "filhos_encargo", "email", "data_inicio_trabalho", "morada", "prob_saude", "nib", "peso", "altura", "calcas", "pe", "casaco", "contrato_inicio",
        "contrato_fim", "contrato_file", "destacamento_inicio", "destacamento_fim", "destacamento_file", "act_inicio", "act_fim", "act_file", "a1_inicio", "a1_fim", "a1_file", "mutuelle_inicio", "mutuelle_file",
        "medico_inicio", "medico_file", "gruista_file", "refeicao", "ajudascusto", "salario", "classificacao", "localizacao", "naturalidade", "concelho", "cc_file", "csaude_file", "activo", "activo_date",
        "csaude_validade", "cod_meal_place", "cod_lodging", "notes", "room", "card_auth_key"}
    Public queryNonValidatedEntriesFields As String() = {"cod_site", "name", "date", "cod_worker"}
    Public queryDuplicatesFields As String() = {"cod_site", "name", "description"}
    Public querySiteClosureFields As String() = {"cod_closure", "cod_site", "start", "end", "motivo"}
    Public querySiteClothesFields As String() = {"cod_clothes", "cod_worker", "data", "clothes", "note", "request_date", "delivered"}
    Public querySiteMaterialsReceptionFields As String() = {"cod_materials_reception", "cod_site", "cod_section", "data", "start", "end", "qtd", "units", "material", "notas"}
    Public queryMobileDevicesFields As String() = {"cod_tablet", "worker.name", "pin", "tablet_id", "puk", "mobile", "name", "sw_version", "serial", "site.name", "site_section.description", "active", "date", "email"}
    Public querySiteContractorFields As String() = {"cod_company", "nome", "phone", "tva", "address", "email", "logo"}
    Public querySiteManagerFields As String() = {"cod_manager", "telef", "email", "name", "cod_site", "job", "cod_nfc", "cod_section", "photo", "auth_string"}
    Public queryTeamFields As String() = {"cod_worker", "cod_category"}
    Public queryBordereauFields As String() = {"cod_task", "descricao", "enabled", "units", "previous_task", "translations"}
    Public queryWorkersOnSiteFields As String() = {"cod_worker", "name", "photo"}
    Public querySiteDailyReportFields As String() = {"activities", "ocurrences"}
    Public queryWorkerAbsensesFields As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public queryWorkersMealsPlace As String() = {"cod_meal_place", "name"}
    Public queryWorkersLodgingPlace As String() = {"cod_lodging", "name"}
    Public queryReportMonthly As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise"}
    Public queryReportDetailed As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "cod_site", "cod_section"}
    Public queryAttendanceRecords As String() = {"checkin", "checkout", "date", "status", "absense", "notas", "cod_site", "cod_section"}
    Public queryLimosaRecords As String() = {"cod_limosa", "inicio", "fim", "file", "name", "qrcode"}
    Public queryAusenciasRecords As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public queryProfileFields As String() = {"name", "email", "photo", "contact", "cod_user"}
    Public queryTransportsFields As String() = {"cod_vehicle", "designation", "initials", "active", "rental"}

    ' options on queries
    Public queryWorkerOptionsClothes As String() = {"pe", "calcas", "casaco", "peso", "altura"}
    Public Structure TableSearchOptionsStructure
        Public viewPlanningAssignmentWorkers As Boolean
        Public viewOtherConstructionSitesAttendance As Boolean
        Public viewThisConstructionSiteAttendance As Boolean
    End Structure


    '___________________________________________________________________________________________________________________________
    'METHODS
    Public Sub New(ByVal Optional settings As String = "")
        'ToDo check default font files are present
        fontTitle.AddFontFile(fontsPath & fontTitleFile)
        fontText.AddFontFile(fontsPath & fontTextFile)
        tableSearchOptions.viewPlanningAssignmentWorkers = False
        tableSearchOptions.viewOtherConstructionSitesAttendance = False
        tableSearchOptions.viewThisConstructionSiteAttendance = False
        loadAll(settings)
    End Sub

    Public Sub loadAll(ByVal Optional settings As String = "")
        If settings.Equals("all") Then
            Dim settingsFile = New FileInfo(Path.Combine(libraryPath, "ScrewDriver.eon"))
            settingsFile.Refresh()
            If settingsFile.Exists Then
                loadSettings()
                loadAddons()
            End If
            loadLocation()
        ElseIf settings.Equals("loadSettingsOnly") Then
            loadSettings()
        ElseIf settings.Equals("loadLocationOnly") Then
            loadLocation()
        ElseIf settings.Equals("loadAddonsOnly") Then
            loadAddons()
        End If
    End Sub
    Public Sub loadSettings()
        Dim settings As New Settings(New State)
        Dim newState As State = Nothing

        newState = settings.load()
        If IsNothing(newState) Then
            stateLoaded = False
            stateErrorMessage = settings.errorMessage
            Exit Sub
        End If

        If Not IsNothing(newState) Then
            stateLoaded = True
            country = newState.country
            currentLang = newState.currentLang
            ServerBaseAddr = newState.ServerBaseAddr
            ApiServerAddrPath = newState.ApiServerAddrPath
            secretKey = newState.secretKey
            SendDiagnosticData = newState.SendDiagnosticData
            SendCrashData = newState.SendCrashData
            'MISSING
            'entreprise name
        End If
        Dim configFile = New FileInfo(Path.Combine(libraryPath, "ScrewDriver.cfg"))
        configFile.Refresh()
        If configFile.Exists Then
            loadConfig()
        End If
    End Sub

    Public Sub loadConfig()
        Dim translations As languageTranslations
        Dim cfgState As New State
        cfgState.secretKey = secretKey
        Dim encryption As New AesCipher(cfgState)
        translations = New languageTranslations(cfgState)

        Dim settingsFile = New FileInfo(Path.Combine(cfgState.libraryPath, "ScrewDriver.cfg"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                Dim bytes = File.ReadAllBytes(Path.Combine(cfgState.libraryPath, "ScrewDriver.cfg"))

                Dim encrypted As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Dim decrypted As String = encryption.decrypt(encrypted)

                Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(decrypted)

                'datatable color schemes
                buttonColor = Color.FromArgb(CInt(data.Item("buttonColor").ToString))
                dividerColor = Color.FromArgb(CInt(data.Item("dividerColor").ToString))
                colorSite = Color.FromArgb(CInt(data.Item("colorSite").ToString))
                colorSection = Color.FromArgb(CInt(data.Item("colorSection").ToString))
                colorCompany = Color.FromArgb(CInt(data.Item("colorCompany").ToString))
                colorWorkCategories = Color.FromArgb(CInt(data.Item("colorWorkCategories").ToString))
                colorAbsense = Color.FromArgb(CInt(data.Item("colorAbsense").ToString))
                colorWithoutRecord = Color.FromArgb(CInt(data.Item("colorWithoutRecord").ToString))
                colorWeekends = Color.FromArgb(CInt(data.Item("colorWeekends").ToString))
                colorHolidays = Color.FromArgb(CInt(data.Item("colorHolidays").ToString))
                colorWithRecord = Color.FromArgb(CInt(data.Item("colorWithRecord").ToString))
                colorAbsentDay = Color.FromArgb(CInt(data.Item("colorAbsentDay").ToString))
                colorFermetureAnnual = Color.FromArgb(CInt(data.Item("colorFermetureAnnual").ToString))
                colorPartialDayValidated = Color.FromArgb(CInt(data.Item("colorPartialDayValidated").ToString))
                colorPlannedChangeOfSite = Color.FromArgb(CInt(data.Item("colorPlannedChangeOfSite").ToString))
                colorPlannedTeam = Color.FromArgb(CInt(data.Item("colorPlannedTeam").ToString))
                colorFullDayValidated = Color.FromArgb(CInt(data.Item("colorFullDayValidated").ToString))
                colorMainMenu = Color.FromArgb(CInt(data.Item("colorMainMenu").ToString))
                'font files
                fontTitleFile = data.Item("fontTitleFile").ToString
                fontTextFile = data.Item("fontTextFile").ToString
                'delay Days Validation Attendance
                delayDaysValidationAttendance = data.Item("delayDaysValidationAttendance").ToString
                fontTitle.AddFontFile(fontsPath & fontTitleFile)
                fontText.AddFontFile(fontsPath & fontTextFile)
            Catch ex As Exception
                Throw New ArgumentNullException(ex.ToString)
            End Try
        Else
            Throw New ArgumentNullException(translations.getText("errorDataFileNotFound"))
        End If

    End Sub


    Public Sub loadAddons() 'REQUIRES VALID USER ID
        If userId.Equals("") Then
            Exit Sub
        End If
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "2")
        vars.Add("id", userId)

        System.Threading.Tasks.Task.Run(Sub()
                                            Dim request As New HttpData(Nothing, ServerBaseAddr & ApiServerAddrPath)
                                            Dim response As String = request.RequestData(vars)
                                            If Not IsResponseOk(response) Then
                                                addonsLoaded = False
                                                Exit Sub
                                            End If

                                            Try
                                                Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
                                                If jsonLatResult.ContainsKey("addons") Then
                                                    Dim Jaddons As JArray = JArray.Parse(jsonLatResult.Item("addons").ToString)
                                                    For Each Jaddon In Jaddons
                                                        addons.Add(Jaddon.Item("type"), Jaddon.Item("url"))
                                                    Next Jaddon
                                                    addonsLoaded = True
                                                End If
                                            Catch ex As Exception
                                                stateErrorMessage = ex.ToString
                                            End Try

                                        End Sub)
    End Sub

    Public Sub loadLocation()


        Dim response As String = ""
        Dim data As New HttpData
        Dim _ip As IPAddress = Nothing

        response = data.RequestExternalData("https://api.ipify.org")
        If IPAddress.TryParse(response, _ip).Equals(True) Then
            currentIpAddress = response
            System.Threading.Tasks.Task.Run(Sub()
                                                response = data.RequestExternalData("http://ip-api.com/json/" & response)
                                                Try
                                                    Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
                                                    If jsonLatResult.ContainsKey("lat") And jsonLatResult.ContainsKey("lon") Then
                                                        latitude = jsonLatResult.Item("lat")
                                                        longitude = jsonLatResult.Item("lon")
                                                    End If
                                                Catch ex As Exception

                                                End Try
                                            End Sub)
        End If
    End Sub
End Class
