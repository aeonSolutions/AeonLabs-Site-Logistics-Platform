Public Interface IDataWorkersRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseWorkersInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveWorkersData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveWorkersLimosasData(sender As Object, args As DataRequestsDataResult)
    Event getResponseDelWorkersLimosasData(sender As Object, args As DataRequestsDataResult)
    Event getResponseWorkersLimosasData(sender As Object, args As DataRequestsDataResult)
    Event getResponseDelWorkersFileData(sender As Object, args As DataRequestsDataResult)
    Function loadWorkersInitialData() As Boolean
    Function saveWorkersData() As Boolean
    Function saveWorkersLimosasData(vars As Dictionary(Of String, String), filename As String) As Boolean
    Function delWorkersLimosasData() As Boolean
    Function loadWorkersLimosasData() As Boolean
    Function delWorkersFileData() As Boolean

End Interface

