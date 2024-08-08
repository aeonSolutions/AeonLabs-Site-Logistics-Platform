Imports System.ComponentModel
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class attendanceReportsDataRequests
    Implements IDataAttendanceReportsRequests

    Public Const key As String = "Es42aOFmQN5JXp4gKgfsek795BpI8Mq0"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseAttendanceReportInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceReportsRequests.getResponseAttendanceReportInitialData
    Public Event getResponseAttendanceReportData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceReportsRequests.getResponseAttendanceReportData
    Public Event getResponseLoadAttendanceReportRecordData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceReportsRequests.getResponseLoadAttendanceReportRecordData
    Public Event getResponseLoadAttendanceReportRecordDataCompleted(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceReportsRequests.getResponseLoadAttendanceReportRecordDataCompleted
    Public Event getResponseLoggerData(sender As Object, args As DataRequestsDataResult) Implements IDataAttendanceReportsRequests.getResponseLoggerData

    Private stateCore As New environmentVarsCore
    Private nestedForm As Form

    Private WithEvents loadAttendanceReportInitialDataHttp As HttpDataPostData
    Private WithEvents loadAttendanceReportDataHttp As HttpDataPostData
    Private WithEvents loadAttendanceReportRecordDataHttp As HttpDataPostData
    Private WithEvents loadLoggerRecordDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataAttendanceReportsRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataAttendanceReportsRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadAttendanceReportInitialData() As Boolean Implements IDataAttendanceReportsRequests.loadAttendanceReportInitialData
        loadAttendanceReportInitialDataHttp = New HttpDataPostData(stateCore)
        loadAttendanceReportInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadAttendanceReportInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadAttendanceReportInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadAttendanceReportInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadAttendanceReportInitialDataHttp.dataArrived
        RaiseEvent getResponseAttendanceReportInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadAttendanceReportInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadAttendanceReportInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadAttendanceReportData() As Boolean Implements IDataAttendanceReportsRequests.loadAttendanceReportData
        loadAttendanceReportDataHttp = New HttpDataPostData(stateCore)
        loadAttendanceReportDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            _vars.ElementAt(i).Add("request", "report")
            loadAttendanceReportDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadAttendanceReportDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadAttendanceReportDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadAttendanceReportDataHttp.dataArrived
        RaiseEvent getResponseAttendanceReportData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadAttendanceReportDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadAttendanceReportDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadAttendanceReportRecordData() As Boolean Implements IDataAttendanceReportsRequests.loadAttendanceReportRecordData
        loadAttendanceReportRecordDataHttp = New HttpDataPostData(stateCore)
        loadAttendanceReportRecordDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            _vars.ElementAt(i).Add("request", "record")
            loadAttendanceReportRecordDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadAttendanceReportRecordDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadAttendanceReportRecordDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadAttendanceReportRecordDataHttp.dataArrived
        RaiseEvent getResponseLoadAttendanceReportRecordData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadAttendanceReportRecordDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadAttendanceReportRecordDataHttp.requestCompleted
        RaiseEvent getResponseLoadAttendanceReportRecordDataCompleted(Me, New DataRequestsDataResult(responseData, Nothing))

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadLoggerData() As Boolean Implements IDataAttendanceReportsRequests.loadLoggerData
        loadLoggerRecordDataHttp = New HttpDataPostData(stateCore)
        loadLoggerRecordDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendance"))
            _vars.ElementAt(i).Add("request", "record")
            loadLoggerRecordDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadLoggerRecordDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadLoggerDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadLoggerRecordDataHttp.dataArrived
        RaiseEvent getResponseLoggerData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadLoggerDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadLoggerRecordDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
End Class


