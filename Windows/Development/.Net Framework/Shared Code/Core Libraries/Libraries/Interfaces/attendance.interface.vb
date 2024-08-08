Public Interface IDataAttendanceRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    ' LOGGER ________________________________________________________________________________________________
    Event getResponseLoggerInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoggerData(sender As Object, args As DataRequestsDataResult)
    Event getResponsebwFormLoggerSaveAnnotation(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveLoggerValidationData(sender As Object, args As DataRequestsDataResult)
    Event getResponseSaveCloseAttendanceData(sender As Object, args As DataRequestsDataResult)

    Function loadLoggerInitialData() As Boolean
    Function loadLoggerData() As Boolean
    Function SaveLoggerValidationData() As String
    Function SaveLoggerAnnotationData() As Boolean
    Function saveCloseAttendancenData() As Boolean

    ' LOGGER REPORTS ________________________________________________________________________________________________
End Interface


