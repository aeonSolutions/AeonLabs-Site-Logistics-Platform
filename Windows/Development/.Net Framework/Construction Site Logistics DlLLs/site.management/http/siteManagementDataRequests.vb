Imports System.ComponentModel
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class siteManagementDataRequests
    Implements IDataSiteManagementRequests

    Public Const key As String = "G6mdfqhUpYpP0B2mnd8OfRymDjM7e13j"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSiteInitialData
    Public Event getResponseSectionsInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSectionsInitialData
    Public Event getResponseManagersInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseManagersInitialData
    Public Event getResponseCompaniesInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseCompaniesInitialData
    Public Event getResponseActivitiesInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseActivitiesInitialData

    Public Event getResponseSaveSiteData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSaveSiteData
    Public Event getResponseSaveSectionData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSaveSectionData
    Public Event getResponseSaveManagerData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSaveManagerData
    Public Event getResponseSaveCompanyData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteManagementRequests.getResponseSaveCompanyData

    Private stateCore As New environmentVarsCore
    Private task As String

    Private WithEvents loadSiteInitialDataHttp As HttpDataPostData
    Private WithEvents loadSiteSectionInitialDataHttp As HttpDataPostData
    Private WithEvents loadSiteCompanyInitialDataHttp As HttpDataPostData
    Private WithEvents loadSiteManagerInitialDataHttp As HttpDataPostData

    Private WithEvents saveSiteDataHttp As HttpDataPostData
    Private WithEvents saveManagerDataHttp As HttpDataPostData
    Private WithEvents saveSectionDataHttp As HttpDataPostData
    Private WithEvents saveCompanyDataHttp As HttpDataPostData


    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataSiteManagementRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataSiteManagementRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadSiteInitialData() As Boolean Implements IDataSiteManagementRequests.loadSiteInitialData
        loadSiteInitialDataHttp = New HttpDataPostData(stateCore)
        loadSiteInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadSiteInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadSiteInitialDataHttp.startRequest()
        Return True

    End Function
    Private Sub loadSiteInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadSiteInitialDataHttp.dataArrived
        If misc("task").Equals("activities") Then
            RaiseEvent getResponseActivitiesInitialData(Me, New DataRequestsDataResult(responseData, misc))
        Else
            RaiseEvent getResponseSiteInitialData(Me, New DataRequestsDataResult(responseData, misc))
        End If
    End Sub
    Private Sub loadSiteInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadSiteInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadSiteSectionInitialData() As Boolean Implements IDataSiteManagementRequests.loadSiteSectionInitialData
        loadSiteSectionInitialDataHttp = New HttpDataPostData(stateCore)
        loadSiteSectionInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadSiteSectionInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadSiteSectionInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadSiteSectionInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadSiteSectionInitialDataHttp.dataArrived
        RaiseEvent getResponseSectionsInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadSiteSectionInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadSiteSectionInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadSiteManagerInitialData() As Boolean Implements IDataSiteManagementRequests.loadSiteManagerInitialData
        loadSiteManagerInitialDataHttp = New HttpDataPostData(stateCore)
        loadSiteManagerInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadSiteManagerInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadSiteManagerInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadSiteManagerInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadSiteManagerInitialDataHttp.dataArrived
        RaiseEvent getResponseManagersInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadSiteManagerInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadSiteManagerInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadSiteCompanyInitialData() As Boolean Implements IDataSiteManagementRequests.loadSiteCompanyInitialData
        loadSiteCompanyInitialDataHttp = New HttpDataPostData(stateCore)
        loadSiteCompanyInitialDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadSiteCompanyInitialDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadSiteCompanyInitialDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadSiteCompanyInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadSiteCompanyInitialDataHttp.dataArrived
        RaiseEvent getResponseCompaniesInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadSiteCompanyInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadSiteCompanyInitialDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveSiteData() As Boolean Implements IDataSiteManagementRequests.saveSiteData
        saveSiteDataHttp = New HttpDataPostData(stateCore)
        saveSiteDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("site"))
            saveSiteDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveSiteDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveSiteDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveSiteDataHttp.dataArrived
        RaiseEvent getResponseSaveSiteData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveSiteDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveSiteDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveManagerData() As Boolean Implements IDataSiteManagementRequests.saveManagerData
        saveManagerDataHttp = New HttpDataPostData(stateCore)
        saveManagerDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteManagers"))
            saveManagerDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveManagerDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveManagerDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveManagerDataHttp.dataArrived
        RaiseEvent getResponseSaveManagerData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveManagerDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveManagerDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveSectionData() As Boolean Implements IDataSiteManagementRequests.saveSectionData
        saveSectionDataHttp = New HttpDataPostData(stateCore)
        saveSectionDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteSections"))
            saveSectionDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveSectionDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveSectionDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveSectionDataHttp.dataArrived
        RaiseEvent getResponseSaveSectionData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveSectionDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveSectionDataHttp.requestCompleted

    End Sub

    '____________________________________________________________________________________________________________________
    Public Function saveCompanyData() As Boolean Implements IDataSiteManagementRequests.saveCompanyData
        saveCompanyDataHttp = New HttpDataPostData(stateCore)
        saveCompanyDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteGeneralContractors"))
            saveCompanyDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveCompanyDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadClothesInitialDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveCompanyDataHttp.dataArrived
        RaiseEvent getResponseSaveCompanyData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadClothesInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveCompanyDataHttp.requestCompleted

    End Sub
End Class



