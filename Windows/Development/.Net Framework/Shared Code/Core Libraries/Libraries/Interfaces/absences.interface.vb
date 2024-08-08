Public Interface IDataAbsencesRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    Event getResponseAbsencesInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseAbsencesReportData(sender As Object, args As DataRequestsDataResult)
    Event getResponseAbsencesData(sender As Object, args As DataRequestsDataResult)
    Function loadAbsencesInitialData() As Boolean
    Function loadAbsencesReportData() As Boolean
    Function loadAbsencesData() As Boolean

End Interface
