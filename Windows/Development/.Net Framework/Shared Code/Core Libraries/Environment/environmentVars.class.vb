Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class environmentVars
    Inherits environmentVarsCore

    Public fontText, fontTitle As New PrivateFontCollection()
    Private WithEvents loadAddOnsData As HttpDataPostData
    Private WithEvents loadLocationData As HttpDataGetData
    Private WithEvents loadIpAddressData As HttpDataGetData
    Private WithEvents loadLocationCoordinates As HttpDataGetData

    Private dataLoadedStatusQueue As Integer = 0

    Public Event environmentVarsLoadComplete(sender As Object, errorMessage As String, Err As Boolean)

    Private WithEvents SyncUI As New SyncWithUI

    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Public Sub New(ByVal Optional settings As Integer = -100)
        'ToDo check default font files are present
        fontTitle.AddFontFile(fontsPath & fontTitleFile)
        fontText.AddFontFile(fontsPath & fontTextFile)
        Dim options As New TableSearchOptionsStructure
        options.viewPlanningAssignmentWorkers = False
        options.viewOtherConstructionSitesAttendance = False
        options.viewThisConstructionSiteAttendance = False
        tableSearchOptions = options
        dataLoaded = False
        dataLoadedStatusQueue = 0
        SyncUI = New SyncWithUI(Me, 1)
        load(settings)
    End Sub

    Public Sub load(ByVal Optional settings As Integer = -100)
        If settings.Equals(LOAD_ALL) Then
            Dim settingsFile = New FileInfo(Path.Combine(libraryPath, "ScrewDriver.eon"))
            settingsFile.Refresh()
            If settingsFile.Exists Then
                SyncUI = New SyncWithUI(Me, 3)
                loadSettings()
                loadAddons()
                loadLocation()
            Else
                SyncUI = New SyncWithUI(Me, 1)
                loadLocation()
            End If

        ElseIf settings.Equals(LOAD_SETTINGS) Then
            SyncUI = New SyncWithUI(Me, 1)
            loadSettings()
        ElseIf settings.Equals(LOAD_LOCATION) Then
            SyncUI = New SyncWithUI(Me, 1)
            loadLocation()
        ElseIf settings.Equals(LOAD_ADDONS) Then
            'REQUIRES VALID USER ID
            'TODO move to cloud settings on startup
            SyncUI = New SyncWithUI(Me, 1)
            loadAddons()
        End If
    End Sub

    Private Sub vars_continueInUI(sender As Object) Handles SyncUI.continueInUI
        RaiseEvent environmentVarsLoadComplete(Me, stateErrorMessage, stateLoaded)
    End Sub
    Public Sub loadSettings()
        Dim settings As New Settings(New environmentVarsCore)
        Dim newState As environmentVarsCore = Nothing

        newState = settings.load()
        If newState Is Nothing Then
            stateLoaded = False
            stateErrorMessage = settings.errorMessage
            SyncUI.RunningSet = False
            Exit Sub
        End If

        If newState IsNot Nothing Then
            country = newState.country
            currentLang = newState.currentLang
            ServerBaseAddr = newState.ServerBaseAddr
            ApiServerAddrPath = newState.ApiServerAddrPath
            secretKey = newState.secretKey
            SendDiagnosticData = newState.SendDiagnosticData
            SendCrashData = newState.SendCrashData
            stateLoaded = True
        End If
        Dim configFile = New FileInfo(Path.Combine(libraryPath, "ScrewDriver.cfg"))
        configFile.Refresh()
        If configFile.Exists Then
            loadConfig()
        Else
            SyncUI.RunningSet = False
        End If
    End Sub

    Public Sub loadConfig()
        Dim translations As languageTranslations
        Dim cfgstate As New environmentVarsCore
        cfgstate.secretKey = secretKey
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
                stateErrorMessage = ex.ToString
            End Try
        Else
            stateErrorMessage = translations.getText("errorDataFileNotFound")
        End If

        SyncUI.RunningSet = False
    End Sub

    Public Sub loadAddons() 'REQUIRES VALID USER ID
        If userId.Equals("") Then
            SyncUI.RunningSet = False
            Exit Sub
        End If
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", taskId("addons"))
        vars.Add("id", userId)
        changeDataLoadedState(True)

        loadAddOnsData = New HttpDataPostData(Me)
        loadAddOnsData.initialize()
        loadAddOnsData.loadQueue(vars, Nothing, Nothing)
        loadAddOnsData.startRequest()
    End Sub
    Private Sub loadAddOnsData_dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String)) Handles loadAddOnsData.dataArrived
        If Not IsResponseOk(requestData) Then
            stateErrorMessage = GetMessage(requestData)
            addonsLoaded = False
            SyncUI.RunningSet = False
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
                    addons.Add(Jaddon.Item("type"), addonItem)
                Next Jaddon
                addonsLoaded = True
            End If
        Catch ex As Exception
            stateErrorMessage = ex.ToString

        End Try
        changeDataLoadedState(False)

        SyncUI.RunningSet = False
    End Sub

    Public Sub loadLocation()
        changeDataLoadedState(True)
        loadIpAddressData = New HttpDataGetData(Me, "https://api.ipify.org", "external")
        loadIpAddressData.initialize()
        loadIpAddressData.startRequest()
    End Sub
    Private Sub loadIpAddressData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadIpAddressData.dataArrived
        Dim _ip As IPAddress = Nothing
        If IPAddress.TryParse(responseData, _ip).Equals(True) Then
            currentIpAddress = responseData

            loadLocationCoordinates = New HttpDataGetData(Me, "http://ip-api.com/json/" & responseData, "external")
            loadLocationCoordinates.initialize()
            loadLocationCoordinates.startRequest()
        Else
            SyncUI.RunningSet = False
        End If

    End Sub
    Private Sub loadLocationCoordinates_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLocationCoordinates.dataArrived
        Dim locationDataItem As locationDataStructure
        locationDataItem = locationData
        Try
            Dim jsonLatResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonLatResult.ContainsKey("lat") And jsonLatResult.ContainsKey("lon") Then
                locationDataItem.latitude = jsonLatResult.Item("lat")
                locationDataItem.longitude = jsonLatResult.Item("lon")
                locationData = locationDataItem
                'https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=-34.44076&lon=-58.70521
                loadLocationData = New HttpDataGetData(Me, "http://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=" & locationData.latitude & "&lon=" & locationData.longitude & "&zoom=18&addressdetails=1", "external")
                loadLocationData.initialize()
                loadLocationData.startRequest()
            Else
                SyncUI.RunningSet = False
            End If
        Catch ex As Exception
            stateErrorMessage = ex.ToString
            SyncUI.RunningSet = False
        End Try
    End Sub
    Private Sub loadLocationData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLocationData.dataArrived
        Dim locationDataItem As locationDataStructure
        locationDataItem = locationData
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(responseData)
            If jsonResult.ContainsKey("display_name") Then
                locationDataItem.displayName = jsonResult.Item("display_name")
            End If
            If jsonResult.ContainsKey("address") Then
                Dim jsonAddresult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonResult.Item("address").ToString)

                locationDataItem.address = jsonAddresult.Item("road")
                locationDataItem.houseNumber = jsonAddresult.Item("house_number")
                locationDataItem.road = jsonAddresult.Item("road")
                locationDataItem.town = jsonAddresult.Item("town")
                locationDataItem.municipality = jsonAddresult.Item("municipality")
                locationDataItem.state = jsonAddresult.Item("state")
                locationDataItem.postCode = jsonAddresult.Item("postcode")
                locationDataItem.country = jsonAddresult.Item("country")
                locationDataItem.countryCode = jsonAddresult.Item("country_code")

                locationData = locationDataItem
            End If
        Catch ex As Exception
            stateErrorMessage = ex.ToString
        End Try
        changeDataLoadedState(False)

        SyncUI.RunningSet = False
    End Sub

    Private Sub changeDataLoadedState(loadState As Boolean)
        If loadState.Equals(True) Then
            'add queue
            dataLoadedStatusQueue += 1
            dataLoaded = False
        ElseIf loadState.Equals(False) Then
            If dataLoadedStatusQueue.Equals(1) Then
                dataLoadedStatusQueue = 0
                dataLoaded = True
            Else
                dataLoadedStatusQueue -= 1
            End If
        End If

    End Sub

End Class
