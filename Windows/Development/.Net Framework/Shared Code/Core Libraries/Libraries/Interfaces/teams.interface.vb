Public Interface IDataTeamsRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseTeamsInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveTeamsData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadRecordData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadTeamsTableData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveTeamsWorkerRecordData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveTeamsWorkerRecordDataCompleted(sender As Object, args As DataRequestsDataResult)

    Function loadTeamsInitialData() As Boolean
    Function saveTeamsData() As Boolean
    Function loadRecordData() As Boolean
    Function loadTeamsTableData() As Boolean
    Function saveTeamsWorkerRecordData() As String

End Interface


