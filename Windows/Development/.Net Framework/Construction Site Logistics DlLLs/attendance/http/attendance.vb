Imports ConstructionSiteLogistics.Libraries.Core

Public Class attendanceDataRequests
    Implements IDataAttendanceRequests

    Public Const key As String = "TsRL8UBkdbPGq9ncvkMGvOQMM5q3dP29"
    Public version As Version = My.Application.Info.Version

    Public Event getResponseLoggerInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceRequests.getResponseLoggerInitialData
    Public Event getResponseLoggerData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceRequests.getResponseLoggerData
    Public Event getResponsebwFormLoggerSaveAnnotation(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceRequests.getResponsebwFormLoggerSaveAnnotation
    Public Event getResponseSaveLoggerValidationData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceRequests.getResponseSaveLoggerValidationData
    Public Event getResponseSaveCloseAttendanceData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceRequests.getResponseSaveCloseAttendanceData

    Private stateCore As environmentVarsCore
    Private WithEvents loadLoggerInitialDataHttp As HttpDataPostData
    Private WithEvents loadLoggerDataHttp As HttpDataPostData
    Private WithEvents saveLoggerSaveAnnotationData As HttpDataPostData
    Private WithEvents saveValidationData As HttpDataPostData
    Private WithEvents saveCloseAttendanceDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataAttendanceRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataAttendanceRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '____________________________________________________________________________________________________________________
    Public Function SaveLoggerValidationData() As String Implements IDataAttendanceRequests.SaveLoggerValidationData
        saveValidationData = New HttpDataPostData(stateCore)
        saveValidationData.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendanceRecords"))
            saveValidationData.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveValidationData.startRequest()
        Return True
    End Function
    Private Sub saveValidationData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveValidationData.dataArrived
        RaiseEvent getResponseSaveLoggerValidationData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveValidationData_requestCompleted(sender As Object, responseData As String) Handles saveValidationData.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function SaveLoggerAnnotationData() As Boolean Implements IDataAttendanceRequests.SaveLoggerAnnotationData
        saveLoggerSaveAnnotationData = New HttpDataPostData(stateCore)
        saveLoggerSaveAnnotationData.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendanceAnnotations"))
            saveLoggerSaveAnnotationData.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveLoggerSaveAnnotationData.startRequest()
        Return True
    End Function
    Private Sub saveLoggerSaveAnnotationData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveLoggerSaveAnnotationData.dataArrived
        RaiseEvent getResponsebwFormLoggerSaveAnnotation(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveLoggerSaveAnnotationData_requestCompleted(sender As Object, responseData As String) Handles saveLoggerSaveAnnotationData.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadLoggerInitialData() As Boolean Implements IDataAttendanceRequests.loadLoggerInitialData
        loadLoggerInitialDataHttp = New HttpDataPostData(stateCore)
        loadLoggerInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadLoggerInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadLoggerInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadLoggerInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLoggerInitialDataHttp.dataArrived
        RaiseEvent getResponseLoggerInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadLoggerInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadLoggerInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadLoggerData() As Boolean Implements IDataAttendanceRequests.loadLoggerData
        loadLoggerDataHttp = New HttpDataPostData(stateCore)
        loadLoggerDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendance"))
            loadLoggerDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadLoggerDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadLoggerDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLoggerDataHttp.dataArrived
        RaiseEvent getResponseLoggerData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadLoggerDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadLoggerDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveCloseAttendancenData() As Boolean Implements IDataAttendanceRequests.saveCloseAttendancenData
        saveCloseAttendanceDataHttp = New HttpDataPostData(stateCore)
        saveCloseAttendanceDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendanceRecords"))
            saveCloseAttendanceDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        saveCloseAttendanceDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveCloseAttendanceDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveCloseAttendanceDataHttp.dataArrived
        RaiseEvent getResponseSaveCloseAttendanceData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveCloseAttendanceDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveCloseAttendanceDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________

End Class
