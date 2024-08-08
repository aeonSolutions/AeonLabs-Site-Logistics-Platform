Public Interface IDataAttendanceReportsRequests
    Sub Initialise(stateIni As environmentVarsCore)
    Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String)

    ' LOGGER ________________________________________________________________________________________________
    Event getResponseAttendanceReportInitialData(sender As Object, args As DataRequestsDataResult)
    Event getResponseAttendanceReportData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadAttendanceReportRecordData(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoadAttendanceReportRecordDataCompleted(sender As Object, args As DataRequestsDataResult)
    Event getResponseLoggerData(sender As Object, args As DataRequestsDataResult)

    Function loadAttendanceReportInitialData() As Boolean
    Function loadAttendanceReportData() As Boolean
    Function loadAttendanceReportRecordData() As Boolean
    Function loadLoggerData() As Boolean

    ' LOGGER REPORTS ________________________________________________________________________________________________
End Interface



