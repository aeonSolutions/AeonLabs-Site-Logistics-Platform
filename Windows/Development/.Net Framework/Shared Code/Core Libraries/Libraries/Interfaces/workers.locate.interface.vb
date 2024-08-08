Public Interface IDataWorkersLocateRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseWorkersLocateInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseWorkersLocateData(sender As Object, args As DataRequestsDataResult)
    Function loadWorkersLocateInitialData() As Boolean
    Function loadWorkersLocateData() As Boolean

End Interface

