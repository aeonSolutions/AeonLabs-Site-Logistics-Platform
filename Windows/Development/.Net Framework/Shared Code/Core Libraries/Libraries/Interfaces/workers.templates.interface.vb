Public Interface IDataWorkersTemplatesRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseWorkersTemplatesInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseWorkersTemplatesData(sender As Object, args As DataRequestsDataResult)
    Function loadWorkersTemplatesInitialData() As Boolean
    Function loadWorkersTemplatesData() As Boolean

End Interface


