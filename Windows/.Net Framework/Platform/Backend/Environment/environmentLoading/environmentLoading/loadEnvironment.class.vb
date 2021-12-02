Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports AeonLabs.Environment
Imports AeonLabs.Network
Imports AeonLabs.Security
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class loadEnvironment

    Private dataLoaded As Boolean = False

    ''SETTINGS 
    Public Const LOAD_ALL As Integer = 1
    Public Const LOAD_SETTINGS As Integer = 2
    Public Const LOAD_LOCATION As Integer = 3
    Public Const LOAD_ADDONS As Integer = 4
    Public Const LOAD_ASSEMBLIES As Integer = 5
    Public Const LOAD_CONFIG As Integer = 6

    Public Event environmentDataLoadedCompleted(task As Integer)

    Private WithEvents loadAddOnsData As HttpDataPostData
    Private WithEvents loadLocationData As HttpDataGetData
    Private WithEvents loadIpAddressData As HttpDataGetData
    Private WithEvents loadLocationCoordinates As HttpDataGetData

    Private dataLoadedStatusQueue As Integer = 0
    Private enVars As environmentVarsCore

#Region "get enVars"
    Public Function GetEnviroment()
        Return enVars
    End Function
#End Region

#Region "Copy Fields from core"
    Public Sub CopyFieldsFromCore(enVarsCore As environmentVarsCore)
        Dim bindingFlagsSelection = BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.[Public]
        Dim fieldValues = enVarsCore.[GetType]().GetFields(bindingFlagsSelection)
        For Each field In fieldValues
            Dim info As MemberInfo() = Me.[GetType]().GetMember(field.Name)
            Dim meField As FieldInfo = TryCast(info(0), FieldInfo)
            meField.SetValue(Me, field.GetValue(enVarsCore))
        Next field
    End Sub
#End Region

#Region "contructors"
    Public Sub New(_enVars As environmentVarsCore, ByVal Optional settings As Integer = -100)
        enVars = _enVars

        enVars.loadEnvironmentcoreDefaults()
        dataLoaded = False
        dataLoadedStatusQueue = 0
        load(settings)
    End Sub
#End Region

#Region "Load data"
    Public Sub load(ByVal Optional settings As Integer = -100)
        If settings.Equals(LOAD_ALL) Then
            Dim settingsFile = New FileInfo(Path.Combine(enVars.libraryPath, "ScrewDriver.eon"))
            settingsFile.Refresh()
            If settingsFile.Exists Then
                loadSettings()
                loadAddons()
            End If
            loadLocation()
        ElseIf settings.Equals(LOAD_SETTINGS) Then
            loadSettings()
        ElseIf settings.Equals(LOAD_LOCATION) Then
            loadLocation()
        ElseIf settings.Equals(LOAD_ADDONS) Then
            'REQUIRES VALID USER ID
            'TODO move to cloud settings on startup
            loadAddons()
        End If

    End Sub
#End Region

#Region "load local settings"
    Public Sub loadSettings()
        changeDataLoadedState(True)

        Dim settings As New AeonLabs.Settings.Settings(enVars)
        enVars = settings.load()

        If settings.hasError Then
            enVars.settingsLoaded = False
            enVars.stateErrorMessage = settings.errorMessage
            Exit Sub
        End If

        Dim configFile = New FileInfo(Path.Combine(enVars.libraryPath, "ScrewDriver.cfg"))
        configFile.Refresh()
        If configFile.Exists Then
            loadConfig()
        End If

        changeDataLoadedState(False, LOAD_SETTINGS)
    End Sub
#End Region

#Region "load local config"
    Public Sub loadConfig()
        changeDataLoadedState(True)

        Dim cfgstate As New environmentVarsCore
        cfgstate.secretKey = enVars.secretKey
        Dim encryption As New AesCipher(cfgstate)

        Dim settingsFile = New FileInfo(Path.Combine(cfgstate.libraryPath, "ScrewDriver.cfg"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            With enVars
                Try
                    Dim bytes = File.ReadAllBytes(Path.Combine(cfgstate.libraryPath, "ScrewDriver.cfg"))
                    Dim encrypted As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                    Dim decrypted As String = encryption.decrypt(encrypted)

                    Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(decrypted)

                    'datatable color schemes
                    .layoutDesign.buttonColor = Color.FromArgb(CInt(data.Item("buttonColor").ToString))
                    .layoutDesign.dividerColor = Color.FromArgb(CInt(data.Item("dividerColor").ToString))
                    .colorSite = Color.FromArgb(CInt(data.Item("colorSite").ToString))
                    .colorSection = Color.FromArgb(CInt(data.Item("colorSection").ToString))
                    .colorCompany = Color.FromArgb(CInt(data.Item("colorCompany").ToString))
                    .colorWorkCategories = Color.FromArgb(CInt(data.Item("colorWorkCategories").ToString))
                    .colorAbsense = Color.FromArgb(CInt(data.Item("colorAbsense").ToString))
                    .colorWithoutRecord = Color.FromArgb(CInt(data.Item("colorWithoutRecord").ToString))
                    .colorWeekends = Color.FromArgb(CInt(data.Item("colorWeekends").ToString))
                    .colorHolidays = Color.FromArgb(CInt(data.Item("colorHolidays").ToString))
                    .colorWithRecord = Color.FromArgb(CInt(data.Item("colorWithRecord").ToString))
                    .colorAbsentDay = Color.FromArgb(CInt(data.Item("colorAbsentDay").ToString))
                    .colorFermetureAnnual = Color.FromArgb(CInt(data.Item("colorFermetureAnnual").ToString))
                    .colorPartialDayValidated = Color.FromArgb(CInt(data.Item("colorPartialDayValidated").ToString))
                    .colorPlannedChangeOfSite = Color.FromArgb(CInt(data.Item("colorPlannedChangeOfSite").ToString))
                    .colorPlannedTeam = Color.FromArgb(CInt(data.Item("colorPlannedTeam").ToString))
                    .colorFullDayValidated = Color.FromArgb(CInt(data.Item("colorFullDayValidated").ToString))
                    .layoutDesign.colorMainMenu = Color.FromArgb(CInt(data.Item("colorMainMenu").ToString))
                    'font files
                    .layoutDesign.fontTitleFile = data.Item("fontTitleFile").ToString
                    .layoutDesign.fontTextFile = data.Item("fontTextFile").ToString
                    'delay Days Validation Attendance
                    .delayDaysValidationAttendance = data.Item("delayDaysValidationAttendance").ToString
                    .layoutDesign.fontTitle.AddFontFile(.fontsPath & .layoutDesign.fontTitleFile)
                    .layoutDesign.fontText.AddFontFile(.fontsPath & .layoutDesign.fontTextFile)
                Catch ex As Exception
                    .stateErrorMessage = ex.ToString
                End Try
            End With
        Else
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)
            enVars.stateErrorMessage = My.Resources.strings.errorDataFileNotFound
        End If
        changeDataLoadedState(False, LOAD_CONFIG)
    End Sub
#End Region

#Region "load AddOns"
    Public Sub loadAddons() 'REQUIRES VALID USER ID
        changeDataLoadedState(True)
        If enVars.userId.Equals("") Then
            changeDataLoadedState(False)
            enVars.addonsLoaded = False
            Exit Sub
        End If
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", enVars.taskId("addons"))
        vars.Add("id", enVars.userId)

        loadAddOnsData = New HttpDataPostData(enVars)
        loadAddOnsData.initialize()
        loadAddOnsData.loadQueue(vars, Nothing, Nothing)
        loadAddOnsData.startRequest()
    End Sub
    Private Sub loadAddOnsData_dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String)) Handles loadAddOnsData.dataArrived
        If Not IsResponseOk(requestData) Then
            changeDataLoadedState(False, LOAD_ADDONS)

            enVars.stateErrorMessage = GetMessage(requestData)
            enVars.addonsLoaded = False
            Exit Sub
        End If
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(requestData)
            If jsonLatResult.ContainsKey("addons") Then
                Dim Jaddons As JArray = JArray.Parse(jsonLatResult.Item("addons").ToString)
                For Each Jaddon In Jaddons
                    Dim addonItem As New Dictionary(Of String, String)
                    addonItem.Add("url", Jaddon.Item("url"))
                    addonItem.Add("name", Jaddon.Item("name"))
                    enVars.addons.Add(Jaddon.Item("type"), addonItem)
                Next Jaddon
                enVars.addonsLoaded = True
            End If
        Catch ex As Exception
            enVars.addonsLoaded = False
            enVars.stateErrorMessage = ex.ToString
        End Try
        changeDataLoadedState(False, LOAD_ADDONS)
    End Sub
#End Region

#Region "load Location"
    Public Sub loadLocation()
        changeDataLoadedState(True)
        loadIpAddressData = New HttpDataGetData(enVars, "https://api.ipify.org")
        loadIpAddressData.initialize()
        loadIpAddressData.startRequest()
    End Sub
    Private Sub loadIpAddressData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadIpAddressData.dataArrived
        Dim _ip As IPAddress = Nothing
        If IPAddress.TryParse(responseData, _ip).Equals(True) Then
            enVars.currentIpAddress = responseData

            loadLocationCoordinates = New HttpDataGetData(enVars, "http://ip-api.com/json/" & responseData)
            loadLocationCoordinates.initialize()
            loadLocationCoordinates.startRequest()
        End If
    End Sub
    Private Sub loadLocationCoordinates_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLocationCoordinates.dataArrived
        Dim locationDataItem As environmentVarsCore.locationDataStructure
        locationDataItem = enVars.locationData
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonLatResult.ContainsKey("lat") And jsonLatResult.ContainsKey("lon") Then
                locationDataItem.latitude = jsonLatResult.Item("lat").ToString.Replace(",", ".")
                locationDataItem.longitude = jsonLatResult.Item("lon").ToString.Replace(",", ".")
                enVars.locationData = locationDataItem
                loadLocationData = New HttpDataGetData(enVars, "http://nominatim.openstreetmap.org/reverse?format=json&lat=" & enVars.locationData.latitude & "&lon=" & enVars.locationData.longitude & "&zoom=18&addressdetails=1")
                loadLocationData.initialize()
                loadLocationData.startRequest()
            End If
        Catch ex As Exception
            changeDataLoadedState(False, LOAD_LOCATION)

            enVars.stateErrorMessage = ex.ToString
        End Try
    End Sub
    Private Sub loadLocationData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLocationData.dataArrived
        Dim locationDataItem As environmentVarsCore.locationDataStructure
        locationDataItem = enVars.locationData

        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonResult.ContainsKey("display_name") Then
                locationDataItem.displayName = jsonResult.Item("display_name")
            End If
            If jsonResult.ContainsKey("address") Then
                Dim jsonAddresult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonResult.Item("address").ToString)

                locationDataItem.road = jsonAddresult.Item("road")
                locationDataItem.hamlet = jsonAddresult.Item("hamlet")
                locationDataItem.state = jsonAddresult.Item("state")
                locationDataItem.postCode = jsonAddresult.Item("postcode")
                locationDataItem.country = jsonAddresult.Item("country")
                locationDataItem.countryCode = jsonAddresult.Item("country_code")

                enVars.locationData = locationDataItem
            End If
        Catch ex As Exception
            enVars.stateErrorMessage = ex.ToString
        End Try
        changeDataLoadedState(False, LOAD_LOCATION)

    End Sub
#End Region

#Region "data loading state monitoring"
    Private Sub changeDataLoadedState(loadState As Boolean, Optional task As Integer = Nothing)
        If loadState.Equals(True) Then
            'add queue
            dataLoadedStatusQueue += 1
            dataLoaded = False
        ElseIf loadState.Equals(False) Then
            If dataLoadedStatusQueue.Equals(1) Then
                dataLoadedStatusQueue = 0
                dataLoaded = True
                RaiseEvent environmentDataLoadedCompleted(task)
            Else
                dataLoadedStatusQueue -= 1
            End If
        End If
    End Sub
#End Region

#Region "load assemblies"
    Public Sub LoadAssemblies()
        changeDataLoadedState(True)
        'TODO ? is needed ?
        changeDataLoadedState(False, LOAD_ASSEMBLIES)
    End Sub
#End Region

End Class
