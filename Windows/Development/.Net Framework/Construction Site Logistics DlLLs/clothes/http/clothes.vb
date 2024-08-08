Imports ConstructionSiteLogistics.Libraries.Core

Public Class clothesDataRequests
    Implements IDataClothesRequests

    Public Const key As String = "XPuhFervQPJdDeIufzyQNDs9WvuwVL9n"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseClothesInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataClothesRequests.getResponseClothesInitialData
    Public Event getResponseClothesReportData(sender As Object, args As DataRequestsDataResult) Implements IDataClothesRequests.getResponseClothesReportData
    Public Event getResponseClothesData(sender As Object, args As DataRequestsDataResult) Implements IDataClothesRequests.getResponseClothesData
    Public Event getResponseWorkersOnSiteData(sender As Object, args As DataRequestsDataResult) Implements IDataClothesRequests.getResponseWorkersOnSiteData

    Private stateCore As New environmentVarsCore
    Private WithEvents loadClothesInitialDataHttp As HttpDataPostData
    Private WithEvents loadClothesReportDataHttp As HttpDataPostData
    Private WithEvents loadClothesDataHttp As HttpDataPostData
    Private WithEvents loadWorkersOnSiteDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataClothesRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataClothesRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadClothesInitialData() As Boolean Implements IDataClothesRequests.loadClothesInitialData
        loadClothesInitialDataHttp = New HttpDataPostData(stateCore)
        loadClothesInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadClothesInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadClothesInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadClothesInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadClothesInitialDataHttp.dataArrived
        RaiseEvent getResponseClothesInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadClothesInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadClothesInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadClothesReportData() As Boolean Implements IDataClothesRequests.loadClothesReportData
        loadClothesReportDataHttp = New HttpDataPostData(stateCore)
        loadClothesReportDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerClothes"))
            loadClothesReportDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadClothesReportDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadClothesReportDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadClothesReportDataHttp.dataArrived
        RaiseEvent getResponseClothesReportData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadClothesReportDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadClothesReportDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadClothesData() As Boolean Implements IDataClothesRequests.loadClothesData
        loadClothesDataHttp = New HttpDataPostData(stateCore)
        loadClothesDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadClothesDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadClothesDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadClothesDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadClothesDataHttp.dataArrived
        RaiseEvent getResponseClothesData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadClothesDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadClothesDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadWorkersOnSiteData() As Boolean Implements IDataClothesRequests.loadWorkersOnSiteData
        loadWorkersOnSiteDataHttp = New HttpDataPostData(stateCore)
        loadWorkersOnSiteDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadWorkersOnSiteDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadWorkersOnSiteDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadWorkersOnSiteDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadWorkersOnSiteDataHttp.dataArrived
        RaiseEvent getResponseWorkersOnSiteData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadWorkersOnSiteDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadWorkersOnSiteDataHttp.requestCompleted

    End Sub
End Class
