
Imports System.Drawing

Public Class environmentVarsCore
    Public Property bundleSpecificVars As New bundleSpecificVarsClass

    Public Property imagesPath As String = String.Format("{0}\images\", Environment.CurrentDirectory)
    Public Property basePath As String = String.Format("{0}\", Environment.CurrentDirectory)
    Public Property tmpPath As String = String.Format("{0}\tmp\", Environment.CurrentDirectory)
    Public Property fontsPath As String = String.Format("{0}\fonts\", Environment.CurrentDirectory)
    Public Property libraryPath As String = String.Format("{0}\library\", Environment.CurrentDirectory)
    Public Property templatesPath As String = String.Format("{0}\templates\", Environment.CurrentDirectory)

    Public Property WebsiteBaseAddr As String = "http://aeonlabs.science" ' base path without final slash, ex: www.qualityconstruction.be

    Public Property ServerBaseAddr As String = "http://aeonlabs.atwebpages.com" ' base path without final slash, ex: www.qualityconstruction.be
    Public Property ApiServerAddrPath As String = "/csaml/api/index.php"
    Public Property ApiHttpHeaderToken As String = randomString(32)
    Public Property updateServerAddr As String = "http://aeonlabs.atwebpages.com/csaml/update/update.php?task=office"
    Public Property crashReportServerAddr As String = "http://aeonlabs.atwebpages.com/csaml/crash/api.php"
    Public Property dataLoaded As Boolean = False

    Public Property softwareAccessMode As String = "" 'possible values: office, site, contractor
    Public Property taskId As New Dictionary(Of String, String)

    Public Property authorizedDLLs As New Dictionary(Of String, String)
    Public Property authorizedFileTemplates As New Dictionary(Of String, String)

    Public Property SettingsSecretKey = "29kdzQaFwSuNJ85t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 
    Public Property secretKey = "26kozQaKwRuNJ24t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 

    Public Property AppId As String = ""
    Public Property currentIpAddress As String = ""

    Public Property SendDiagnosticData As Boolean = False
    Public Property SendCrashData As Boolean = False

    Public Property authOk As Boolean = False
    Public Property userId As String = ""
    Public Property username As String = ""
    Public Property userConnType As String = ""
    Public Property userType As String = ""
    Public Property userPhoto As String = ""

    Public Property stateLoaded As Boolean = False
    Public Property stateErrorMessage As String = ""

    Public Property businessName As String = "Construction Site Logistics"
    Public Property journalResponsables As String = "Miguel Silva"

    'runtime user selections and settings
    Public Property tableSearchOptions As New TableSearchOptionsStructure
    Public Property datatableContents As New DataTable
    Public Property locationData As New locationDataStructure

    'INTO SETTINGS: 
    'LANGUAGE
    Public Property currentLang As String = ""
    Public Property country As String = ""
    Public Property defaultTranslatedLang = "fr"

    'ToDo: settings to add on DB settings table
    Public Property delayDaysValidationAttendance As Integer = 1
    Public Property AutomaticLogoutTime As New TimeSpan(0, 15, 0) '15 min timeout - integer (Hours, Minutes, Seconds) 
    Public Property maxMinutesForClearCheckout As Integer = 300
    Public Property isWorkingHoursIncompleteWorkDayHoursLogged As Boolean = False
    Public Property maxWorkHoursDay As TimeSpan = TimeSpan.Parse("10:00:00")

    'VISUAL STYLES
    'fonts
    Public Property fontTitleFile As String = "Roboto-Medium.ttf"
    Public Property fontTextFile As String = "Roboto-Medium.ttf"

    'font text size
    Public Property menuTitleFontSize As Integer = 10
    Public Property subMenuTitleFontSize As Integer = 8
    Public Property buttonFontSize As Integer = 9
    Public Property SmallTextFontSize As Integer = 7
    Public Property RegularTextFontSize As Integer = 8
    Public Property DialogTitleFontSize As Integer = 10
    Public Property groupBoxTitleFontSize As Integer = 8
    'main color schemes
    Public Property buttonColor As Color = Color.DarkOrange
    Public Property dividerColor As Color = Color.FromArgb(253, 186, 49)
    Public Property colorMainMenu As Color = Color.FromArgb(35, 40, 45)
    Public Property colorMainPageHeader As Color = Color.FromArgb(253, 186, 49)

    'datatable color schemes
    Public Property colorFullDayValidated As Color = Color.FromArgb(192, 255, 192)
    Public Property colorPlannedTeam As Color = Color.FromArgb(204, 255, 117)
    Public Property colorPlannedChangeOfSite As Color = Color.LightSkyBlue
    Public Property colorPartialDayValidated As Color = Color.FromArgb(255, 218, 117)
    Public Property colorFermetureAnnual As Color = Color.LightGray
    Public Property colorRecordDeleted As Color = Color.LightGray

    Public Property colorAbsentDay As Color = Color.MistyRose
    Public Property colorWithRecord As Color = Color.Gold
    Public Property colorHolidays As Color = Color.FromArgb(204, 236, 255)
    Public Property colorWeekends As Color = Color.Tan
    Public Property colorWithoutRecord As Color = Color.IndianRed
    Public Property colorDarkGray As Color = Color.Gainsboro
    Public Property colorLightGray As Color = Color.LightGray
    Public Property colorAbsense As Color = Color.PaleGoldenrod
    Public Property colorWorkCategories As Color = Color.Beige
    Public Property colorCompany As Color = Color.Linen
    Public Property colorSection As Color = Color.Bisque
    Public Property colorSite As Color = Color.Bisque
    Public Property colorDuplicate As Color = Color.Red

    'ADDONS
    Public Property addonsLoaded As Boolean = False
    Public Property addons As New Dictionary(Of String, Dictionary(Of String, String))

    'QUERY FIELDS
    Public Property querySettingsFields As String() = {"disable_checkin", "disable_checkout", "max_days_delay_validation", "work_hours", "company_name"}
    Public Property querySiteFields As String() = {"cod_site", "name", "address", "initials", "gps_lat", "gps_lon", "ref_contrato", "cod_company", "data_inicio", "data_fim", "distancia", "authentication_radius", "active", "regie_hourly", "craneman_hourly", "machinist_hourly", "regie_weekends", "machinist_weekends", "craneman_weekends", "regie_after_hours", "machinist_after_hours", "craneman_after_hours", "project_languages", "primary_lang"}
    Public Property queryEntreprisePartnersFields As String() = {"cod_entreprise", "name", "contact"}
    Public Property querySiteSectionFields As String() = {"cod_section", "cod_site", "description", "attendances_last_close"}
    Public Property queryWorkerCategoryFields As String() = {"cod_category", "designation", "reference"}
    Public Property queryHolidaysFields As String() = {"date"}
    Public Property queryAbsenseFields As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public Property queryWorkersFields As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "contact112", "photo", "data_nascimento", "idade", "estado_civil", "nacionalidade",
        "cc", "cc_validade", "nif", "niss", "filhos", "filhos_encargo", "email", "data_inicio_trabalho", "morada", "prob_saude", "nib", "peso", "altura", "calcas", "pe", "casaco", "contrato_inicio",
        "contrato_fim", "contrato_file", "destacamento_inicio", "destacamento_fim", "destacamento_file", "act_inicio", "act_fim", "act_file", "a1_inicio", "a1_fim", "a1_file", "mutuelle_inicio", "mutuelle_file",
        "medico_inicio", "medico_file", "gruista_file", "refeicao", "ajudascusto", "salario", "classificacao", "localizacao", "naturalidade", "concelho", "cc_file", "csaude_file", "activo", "activo_date",
        "csaude_validade", "cod_meal_place", "cod_lodging", "notes", "room", "card_auth_key"}
    Public Property queryNonValidatedEntriesFields As String() = {"cod_site", "name", "date", "cod_worker"}
    Public Property queryDuplicatesFields As String() = {"cod_site", "name", "description"}
    Public Property querySiteClosureFields As String() = {"cod_closure", "cod_site", "start", "end", "motivo"}
    Public Property querySiteClothesFields As String() = {"cod_clothes", "cod_worker", "data", "clothes", "note", "request_date", "delivered"}
    Public Property querySiteMaterialsReceptionFields As String() = {"cod_materials_reception", "cod_site", "cod_section", "data", "start", "end", "qtd", "units", "material", "notas"}
    Public Property queryMobileDevicesFields As String() = {"cod_tablet", "worker.name", "pin", "tablet_id", "puk", "mobile", "name", "sw_version", "serial", "site.name", "site_section.description", "active", "date", "email"}
    Public Property querySiteContractorFields As String() = {"cod_company", "nome", "phone", "tva", "address", "email", "logo"}
    Public Property querySiteManagerFields As String() = {"cod_manager", "telef", "email", "name", "cod_site", "job", "cod_nfc", "cod_section", "photo", "auth_string"}
    Public Property queryTeamFields As String() = {"cod_worker", "cod_category"}
    Public Property queryBordereauFields As String() = {"cod_task", "descricao", "enabled", "units", "previous_task", "translations", "contractor_ref", "pu", "qtd"}
    Public Property queryWorkersOnSiteFields As String() = {"cod_worker", "name", "photo"}
    Public Property querySiteDailyReportFields As String() = {"activities", "ocurrences"}
    Public Property queryWorkerAbsensesFields As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public Property queryWorkersMealsPlace As String() = {"cod_meal_place", "name"}
    Public Property queryWorkersLodgingPlace As String() = {"cod_lodging", "name"}
    Public Property queryReportMonthly As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise"}
    Public Property queryReportDetailed As String() = {"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise", "cod_site", "cod_section"}
    Public Property queryAttendanceRecords As String() = {"checkin", "checkout", "date", "status", "absense", "notas", "cod_site", "cod_section", "validation_reason"}
    Public Property queryLimosaRecords As String() = {"cod_limosa", "inicio", "fim", "file", "name", "qrcode"}
    Public Property queryAusenciasRecords As String() = {"cod_ausencia", "cod_worker", "inicio", "fim", "tipo", "viagem", "motivo"}
    Public Property queryProfileFields As String() = {"name", "email", "photo", "contact", "cod_user", "pin"}
    Public Property queryTransportsFields As String() = {"cod_vehicle", "designation", "initials", "active", "rental"}

    ' options on queries
    Public Property queryWorkerOptionsClothes As String() = {"pe", "calcas", "casaco", "peso", "altura"}
    Public Structure TableSearchOptionsStructure
        Public viewPlanningAssignmentWorkers As Boolean
        Public viewOtherConstructionSitesAttendance As Boolean
        Public viewThisConstructionSiteAttendance As Boolean
    End Structure

    Public Structure locationDataStructure
        Public displayName As String
        Public address As String
        Public houseNumber As String
        Public road As String
        Public town As String
        Public municipality As String
        Public state As String
        Public postCode As String
        Public country As String
        Public countryCode As String
        Public latitude As String
        Public longitude As String

    End Structure
End Class
