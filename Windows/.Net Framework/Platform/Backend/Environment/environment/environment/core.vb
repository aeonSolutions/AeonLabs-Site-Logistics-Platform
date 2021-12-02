
Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO

Public Class environmentVarsCore
#Region "constructors"
    Public Sub New()
        layoutDesign.loadDefaults(Me)
    End Sub
#End Region

#Region "Interfaces, Events and delegates"
    Public Event dataChanged(sender As Object, envars As environmentVarsCore)
    Public Delegate Sub updateMainLayoutDelegate(sender As Object, ByRef updateContents As updateMainAppClass)

    Public Sub updateMainLayout(sender As Object, ByRef updateContents As updateMainAppClass)

    End Sub

#End Region

#Region "CUSTOMIZATION"
    Public Property customization As New customization
#End Region

#Region "ASSEMBLIES"
    Public Property assemblies As New Dictionary(Of String, environmentAssembliesClass)
    Public Property assignedAssembliesToControl As New Dictionary(Of String, List(Of EnvironmentAssignedToControlClass))
#End Region

#Region "LOCAL USER SETTINGS"
    Public Property SettingsSecretKey = "29kdzQaFwSuNJ85t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 

    'ÚSER SETTINGS
    Public Property userSettings As New userSettingsClass

    'UPDATES
    Public Property checkForUpdatesIsEnabled As Boolean = False
    Public Property packageUpdatesIsEnabled As Boolean = False
    Public Property plugInsUpdatesIsEnabled As Boolean = False
    'LANGUAGE
    Public Property currentLang As String = ""
    Public Property country As String = ""
    Public Property defaultTranslatedLang = "fr"
#End Region

#Region "NOTIFICATIONS"
    Public Property notifications As New List(Of notificationsClass)
#End Region

#Region "APP DESIGN"
    Public WithEvents layoutDesign As New environmentLayoutClass
#End Region

#Region "FOLDER PATHS"
    Public Property imagesPath As String = String.Format("{0}\images\", System.Environment.CurrentDirectory)
    Public Property basePath As String = String.Format("{0}\", System.Environment.CurrentDirectory)
    Public Property tmpPath As String = String.Format("{0}\tmp\", System.Environment.CurrentDirectory)
    Public Property fontsPath As String = String.Format("{0}\fonts\", System.Environment.CurrentDirectory)
    Public Property libraryPath As String = String.Format("{0}\library\", System.Environment.CurrentDirectory)
    Public Property templatesPath As String = String.Format("{0}\templates\", System.Environment.CurrentDirectory)
    Public Property packagesPath As String = String.Format("{0}\packages\", System.Environment.CurrentDirectory)
    Public Property plugInsPath As String = String.Format("{0}\plugins\", System.Environment.CurrentDirectory)
#End Region

#Region "DIAGONOSTICS AND CRASH DATA"
    Public Property SendDiagnosticData As Boolean = False
    Public Property SendCrashData As Boolean = False
#End Region

#Region "Env. vars states (this class)"
    Public Property stateLoaded As Boolean = False
    Public Property settingsLoaded As Boolean = False
    Public Property dataLoaded As Boolean = False
    Public Property stateErrorFound As Boolean = False
    Public Property stateErrorMessage As String = ""
#End Region
    Public Property externalFilesToLoad As New Dictionary(Of String, String) 'TODO remove entries when assembly is unloaded

    'TO BE CLASSIF. and SORTED
    Public Property ServerBaseAddr As String = "" ' base path without final slash
    Public Property ApiServerAddrPath As String = ""
    Public Property ApiHttpHeaderToken As String = "" 'GEN STRING ON LOAD

    Public Property taskId As New Dictionary(Of String, String)

    Public Property authorizedFileTemplates As Dictionary(Of String, String)

    Public Property secretKey = "26kozQaKwRuNJ24t" ' it has to be exactly 16 chars for a 128bit encryption, 32chars for 256bit 

    Public Property AppId As String = ""
    Public Property currentIpAddress As String = ""

    Public Property successLogin As Boolean = False
    Public Property userId As String = ""
    Public Property username As String = ""
    Public Property userConnType As String = ""
    Public Property userType As String = ""
    Public Property userPhoto As String = ""

    Public Property journalResponsables As String = "Miguel Silva"

    'runtime user selections and settings
    Public Property tableSearchOptions As New TableSearchOptionsStructure
    Public Property datatableContents As New Data.DataTable
    Public Property locationData As locationDataStructure

    'INTO SETTINGS: 
    'ToDo: settings to add on DB settings table
    Public Property delayDaysValidationAttendance As Integer = 1
    Public Property AutomaticLogoutTime As New TimeSpan(0, 15, 0) '15 min timeout - integer (Hours, Minutes, Seconds) 
    Public Property maxMinutesForClearCheckout As Integer = 300
    Public Property isWorkingHoursIncompleteWorkDayHoursLogged As Boolean = False
    Public Property maxWorkHoursDay As TimeSpan = TimeSpan.Parse("10:00:00")

    'VISUAL STYLES
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
        Public hamlet As String
        Public municipality As String
        Public state As String
        Public postCode As String
        Public country As String
        Public countryCode As String
        Public latitude As String
        Public longitude As String

    End Structure

    Public Sub loadEnvironmentcoreDefaults()
        layoutDesign.loadDefaults(Me)

        'TODO move tableSearchOptions to its assembly
        Dim options As New environmentVarsCore.TableSearchOptionsStructure
        options.viewPlanningAssignmentWorkers = False
        options.viewOtherConstructionSitesAttendance = False
        options.viewThisConstructionSiteAttendance = False
        tableSearchOptions = options
    End Sub
End Class
