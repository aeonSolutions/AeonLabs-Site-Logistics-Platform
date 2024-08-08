Imports ConstructionSiteLogistics.Libraries.Core

Public Class teamsDataRequests
    Implements IDataTeamsRequests

    Public Const key As String = "8cQ0c1vvb9OxLn5iNzn1xsN2hJodh4Ab"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseTeamsInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseTeamsInitialData
    Public Event getResponseSaveTeamsData(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseSaveTeamsData
    Public Event getResponseLoadRecordData(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseLoadRecordData
    Public Event getResponseLoadTeamsTableData(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseLoadTeamsTableData
    Public Event getResponseSaveTeamsWorkerRecordData(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseSaveTeamsWorkerRecordData
    Public Event getResponseSaveTeamsWorkerRecordDataCompleted(sender As Object, args As DataRequestsDataResult) Implements IDataTeamsRequests.getResponseSaveTeamsWorkerRecordDataCompleted

    Private stateCore As New environmentVarsCore

    Private WithEvents loadTeamsInitialDataHttp As HttpDataPostData
    Private WithEvents saveTeamsDataHttp As HttpDataPostData
    Private WithEvents loadRecordDataHttp As HttpDataPostData
    Private WithEvents loadTeamsTableDataHttp As HttpDataPostData
    Private WithEvents saveTeamsWorkerRecordDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataTeamsRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub
    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataTeamsRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadTeamsInitialData() As Boolean Implements IDataTeamsRequests.loadTeamsInitialData
        loadTeamsInitialDataHttp = New HttpDataPostData(stateCore)
        loadTeamsInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadTeamsInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadTeamsInitialDataHttp.startRequest()
        Return True

    End Function
    Private Sub loadTeamsInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadTeamsInitialDataHttp.dataArrived
        RaiseEvent getResponseTeamsInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadTeamsInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadTeamsInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveTeamsData() As Boolean Implements IDataTeamsRequests.saveTeamsData
        saveTeamsDataHttp = New HttpDataPostData(stateCore)
        saveTeamsDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteTeams"))
            saveTeamsDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveTeamsDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveTeamsDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveTeamsDataHttp.dataArrived
        RaiseEvent getResponseSaveTeamsData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveTeamsDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveTeamsDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadRecordData() As Boolean Implements IDataTeamsRequests.loadRecordData
        loadRecordDataHttp = New HttpDataPostData(stateCore)
        loadRecordDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadRecordDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadRecordDataHttp.startRequest()
        Return True

    End Function
    Private Sub loadRecordDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadRecordDataHttp.dataArrived
        RaiseEvent getResponseLoadRecordData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadRecordDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadRecordDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadTeamsTableData() As Boolean Implements IDataTeamsRequests.loadTeamsTableData
        loadTeamsTableDataHttp = New HttpDataPostData(stateCore)
        loadTeamsTableDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendance"))
            loadTeamsTableDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadTeamsTableDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadTeamsTableDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadTeamsTableDataHttp.dataArrived
        RaiseEvent getResponseLoadTeamsTableData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadTeamsTableDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadTeamsTableDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveTeamsWorkerRecordData() As String Implements IDataTeamsRequests.saveTeamsWorkerRecordData
        saveTeamsWorkerRecordDataHttp = New HttpDataPostData(stateCore)
        saveTeamsWorkerRecordDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("attendanceRecords"))
            saveTeamsWorkerRecordDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveTeamsWorkerRecordDataHttp.startRequest()
        Return True
    End Function

    Private Sub saveTeamsWorkerRecordDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveTeamsWorkerRecordDataHttp.dataArrived
        RaiseEvent getResponseSaveTeamsWorkerRecordData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveTeamsWorkerRecordDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveTeamsWorkerRecordDataHttp.requestCompleted
        RaiseEvent getResponseSaveTeamsWorkerRecordDataCompleted(Me, New DataRequestsDataResult(responseData, Nothing))

    End Sub
End Class


