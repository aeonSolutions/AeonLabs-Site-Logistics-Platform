Imports ConstructionSiteLogistics.Libraries.Core

Public Class workersTemplatesRequests
    Implements IDataWorkersTemplatesRequests

    Public Const key As String = "jkVhlny1Kmf6ZlKI0LkhpOvV3fEUkapa"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseWorkersTemplatesInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersTemplatesRequests.getResponseWorkersTemplatesInitialData
    Public Event getResponseWorkersTemplatesData(sender As Object, args As DataRequestsDataResult) Implements IDataWorkersTemplatesRequests.getResponseWorkersTemplatesData

    Private stateCore As New environmentVarsCore
    Private WithEvents loadWorkersTemplatesInitialDataHttp As HttpDataPostData
    Private WithEvents loadWorkersTemplatesDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataWorkersTemplatesRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataWorkersTemplatesRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadWorkersTemplatesInitialData() As Boolean Implements IDataWorkersTemplatesRequests.loadWorkersTemplatesInitialData
        loadWorkersTemplatesInitialDataHttp = New HttpDataPostData(stateCore)
        loadWorkersTemplatesInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersTemplatesInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersTemplatesInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersLocateInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersTemplatesInitialDataHttp.dataArrived
        RaiseEvent getResponseWorkersTemplatesInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadWorkersLocateInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersTemplatesInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadWorkersTemplatesData() As Boolean Implements IDataWorkersTemplatesRequests.loadWorkersTemplatesData
        loadWorkersTemplatesDataHttp = New HttpDataPostData(stateCore)
        loadWorkersTemplatesDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersTemplatesDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i
        loadWorkersTemplatesDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersTemplatesDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersTemplatesDataHttp.dataArrived
        RaiseEvent getResponseWorkersTemplatesData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadWorkersTemplatesDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersTemplatesDataHttp.requestCompleted

    End Sub

End Class


