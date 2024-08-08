Public Interface IDataSiteManagementRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSectionsInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseManagersInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseCompaniesInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseActivitiesInitialData(sender As Object, args As DataRequestsDataResult)

    Event getResponseSaveSiteData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveSectionData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveManagerData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveCompanyData(sender As Object, args As DataRequestsDataResult)

    Function loadSiteInitialData() As Boolean
    Function loadSiteSectionInitialData() As Boolean
    Function loadSiteManagerInitialData() As Boolean
    Function loadSiteCompanyInitialData() As Boolean

    Function saveSiteData() As Boolean
    Function saveSectionData() As Boolean
    Function saveManagerData() As Boolean
    Function saveCompanyData() As Boolean

End Interface


