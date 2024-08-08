Imports System.ComponentModel
Imports ConstructionSiteLogistics.Libraries.Core

Public Class workersDataRequests
    Implements IDataWorkersRequests

    Public Const key As String = "DvqsDWYajUskhBN9LXRdx2mQJwojHnQP"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseWorkersInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseWorkersInitialData
    Public Event getResponseSaveWorkersData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseSaveWorkersData
    Public Event getResponseSaveWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseSaveWorkersLimosasData
    Public Event getResponseDelWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseDelWorkersLimosasData
    Public Event getResponseWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseWorkersLimosasData
    Public Event getResponseDelWorkersFileData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersRequests.getResponseDelWorkersFileData

    Private stateCore As New environmentVarsCore
    Private WithEvents loadWorkersInitialDataHttp As HttpDataPostData
    Private WithEvents saveWorkersDataHttp As HttpDataPostData
    Private WithEvents saveWorkersLimosasDataHttp As HttpDataFilesUpload
    Private WithEvents delWorkersLimosasDataHttp As HttpDataPostData
    Private WithEvents loadWorkersLimosasDataHttp As HttpDataPostData
    Private WithEvents delWorkersFileDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataWorkersRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataWorkersRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadWorkersInitialData() As Boolean Implements IDataWorkersRequests.loadWorkersInitialData
        loadWorkersInitialDataHttp = New HttpDataPostData(stateCore)
        loadWorkersInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersInitialDataHttp.dataArrived
        RaiseEvent getResponseWorkersInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadWorkersInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveWorkersData() As Boolean Implements IDataWorkersRequests.saveWorkersData
        saveWorkersDataHttp = New HttpDataPostData(stateCore)
        saveWorkersDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerDossier"))
            saveWorkersDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        saveWorkersDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveWorkersDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveWorkersDataHttp.dataArrived
        RaiseEvent getResponseSaveWorkersData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveWorkersDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveWorkersDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveWorkersLimosasData(vars As Dictionary(Of String, String), filename As String) As Boolean Implements IDataWorkersRequests.saveWorkersLimosasData
        saveWorkersLimosasDataHttp = New HttpDataFilesUpload(stateCore)
        saveWorkersLimosasDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerLimosas"))
            saveWorkersLimosasDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        saveWorkersLimosasDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveWorkersLimosasDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveWorkersLimosasDataHttp.dataArrived
        RaiseEvent getResponseSaveWorkersLimosasData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveWorkersLimosasDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveWorkersLimosasDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function delWorkersLimosasData() As Boolean Implements IDataWorkersRequests.delWorkersLimosasData
        delWorkersLimosasDataHttp = New HttpDataPostData(stateCore)
        delWorkersLimosasDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerLimosas"))
            delWorkersLimosasDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        delWorkersLimosasDataHttp.startRequest()
        Return True
    End Function
    Private Sub delWorkersLimosasDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles delWorkersLimosasDataHttp.dataArrived
        RaiseEvent getResponseDelWorkersLimosasData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub delWorkersLimosasDataHttp_requestCompleted(sender As Object, responseData As String) Handles delWorkersLimosasDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadWorkersLimosasData() As Boolean Implements IDataWorkersRequests.loadWorkersLimosasData
        loadWorkersLimosasDataHttp = New HttpDataPostData(stateCore)
        loadWorkersLimosasDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersLimosasDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersLimosasDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersLimosasDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersLimosasDataHttp.dataArrived
        RaiseEvent getResponseWorkersLimosasData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadWorkersLimosasDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersLimosasDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function delWorkersFileData() As Boolean Implements IDataWorkersRequests.delWorkersFileData
        delWorkersFileDataHttp = New HttpDataPostData(stateCore)
        delWorkersFileDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("templateFiles"))
            delWorkersFileDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        delWorkersFileDataHttp.startRequest()
        Return True
    End Function
    Private Sub delWorkersFileDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles delWorkersFileDataHttp.dataArrived
        RaiseEvent getResponseDelWorkersFileData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub delWorkersFileDataHttp_requestCompleted(sender As Object, responseData As String) Handles delWorkersFileDataHttp.requestCompleted

    End Sub
End Class

