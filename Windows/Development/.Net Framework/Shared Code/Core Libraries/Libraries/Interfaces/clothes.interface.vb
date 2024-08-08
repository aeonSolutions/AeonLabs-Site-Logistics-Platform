Public Interface IDataClothesRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseClothesInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseClothesReportData(sender As Object, args As DataRequestsDataResult)
    Event getResponseClothesData(sender As Object, args As DataRequestsDataResult)
    Event getResponseWorkersOnSiteData(sender As Object, args As DataRequestsDataResult)
    Function loadClothesInitialData() As Boolean
    Function loadClothesReportData() As Boolean
    Function loadClothesData() As Boolean
    Function loadWorkersOnSiteData() As Boolean

End Interface
