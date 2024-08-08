Imports System.ComponentModel
Imports ConstructionSiteLogistics.Libraries.Core

Public Class workersLocateDataRequests
    Implements IDataWorkersLocateRequests

    Public Const key As String = "fSORC6dnPZNawPh5YMdTcqBRRVKBI6jB"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseWorkersLocateInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersLocateRequests.getResponseWorkersLocateInitialData
    Public Event getResponseWorkersLocateData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersLocateRequests.getResponseWorkersLocateData

    Private stateCore As New environmentVarsCore
    Private WithEvents loadWorkersLocateInitialDataHttp As HttpDataPostData
    Private WithEvents loadWorkersLocateDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataWorkersLocateRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataWorkersLocateRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadWorkersLocateInitialData() As Boolean Implements IDataWorkersLocateRequests.loadWorkersLocateInitialData
        loadWorkersLocateInitialDataHttp = New HttpDataPostData(stateCore)
        loadWorkersLocateInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersLocateInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersLocateInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersLocateInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersLocateInitialDataHttp.dataArrived
        RaiseEvent getResponseWorkersLocateInitialData(Me, New DataRequestsDataResult(responseData, Nothing))
    End Sub
    Private Sub loadWorkersLocateInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersLocateInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadWorkersLocateData() As Boolean Implements IDataWorkersLocateRequests.loadWorkersLocateData
        loadWorkersLocateDataHttp = New HttpDataPostData(stateCore)
        loadWorkersLocateDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerLocate"))
            loadWorkersLocateDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersLocateDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersLocateDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersLocateDataHttp.dataArrived
        RaiseEvent getResponseWorkersLocateData(Me, New DataRequestsDataResult(responseData, Nothing))
    End Sub
    Private Sub loadWorkersLocateDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersLocateDataHttp.requestCompleted

    End Sub
End Class

