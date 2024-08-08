
Imports System.ComponentModel
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class siteDataRequests
    Implements IDataSiteRequests

    Public Const key As String = "WIoPiMsFF0MF0nWV6R8BhBmMpB30qlZD"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSiteInitialData
    Public Event getResponseBordereauInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseBordereauInitialData
    Public Event getResponseProductionInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseProductionInitialData
    Public Event getResponseWorkersOnSiteInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseWorkersOnSiteInitialData

    Public Event getResponseloadBordereauTableData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseloadBordereauTableData
    Public Event getResponseLoadRegieTableData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadRegieTableData
    Public Event getResponseProductionTableData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseProductionTableData
    Public Event getResponseDeliveryTableData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseDeliveryTableData

    Public Event getResponseLoadJournalData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadJournalData
    Public Event getResponseLoadMaterialsReceptionData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadMaterialsReceptionData
    Public Event getResponseLoadJournalWorkersData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadJournalWorkersData
    Public Event getResponseLoadJournalWorkersCategoriesData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadJournalWorkersCategoriesData
    Public Event getResponseloadJournalReportData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseloadJournalReportData
    Public Event getResponseloadJournalHistoryOfDayData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseloadJournalHistoryOfDayData
    Public Event getResponseLoadSiteClosedDaysData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseLoadSiteClosedDaysData

    Public Event getResponseSaveClosedDaysData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSaveClosedDaysData
    Public Event getResponseSaveProductionData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSaveProductionData
    Public Event getResponseSavePhotoData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSavePhotoData
    Public Event getResponseSaveDeliveryData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSaveDeliveryData
    Public Event getResponseSaveRegieData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSaveRegieData
    Public Event getResponseSaveMaterialsReceptionData(sender As Object, args As DataRequestsDataResult) Implements IDataSiteRequests.getResponseSaveMaterialsReceptionData


    Private stateCore As New environmentVarsCore

    Private WithEvents loadSiteInitialDataHttp As HttpDataPostData
    Private WithEvents loadBordereauTableDataHttp As HttpDataPostData
    Private WithEvents savePhotoDataHttp As HttpDataPostData
    Private WithEvents loadRegieTableDataHttp As HttpDataPostData
    Private WithEvents loadProductionTableDataHttp As HttpDataPostData
    Private WithEvents saveProductionDataHttp As HttpDataPostData
    Private WithEvents loadDeliveryTableDataHttp As HttpDataPostData
    Private WithEvents loadJournalDataHttp As HttpDataPostData
    Private WithEvents loadJournalReportDataHttp As HttpDataPostData
    Private WithEvents loadJournalHistoryOfDayDataHttp As HttpDataPostData
    Private WithEvents saveClosedDaysDataHttp As HttpDataPostData
    Private WithEvents saveDeliveryDataHttp As HttpDataPostData
    Private WithEvents saveRegieDataHttp As HttpDataPostData
    Private WithEvents saveReceptionMaterialsDataHttp As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataSiteRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataSiteRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub

    '____________________________________________________________________________________________________________________
    Public Function loadSiteInitialData() As Boolean Implements IDataSiteRequests.loadSiteInitialData
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

        If misc("task").Equals("") Then
            RaiseEvent getResponseSiteInitialData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("bordereau") Then
            RaiseEvent getResponseBordereauInitialData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("production") Then
            RaiseEvent getResponseProductionInitialData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("workersOnSite") Then
            RaiseEvent getResponseWorkersOnSiteInitialData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("materialsReception") Then
            RaiseEvent getResponseLoadMaterialsReceptionData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("siteClosedDays") Then
            RaiseEvent getResponseLoadSiteClosedDaysData(Me, New DataRequestsDataResult(responseData, misc))
        End If
    End Sub
    Private Sub loadSiteInitialDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadSiteInitialDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadBordereauTableData() As Boolean Implements IDataSiteRequests.loadBordereauTableData
        loadBordereauTableDataHttp = New HttpDataPostData(stateCore)
        loadBordereauTableDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteActivitiesMap"))
            loadBordereauTableDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadBordereauTableDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadBordereauTableDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadBordereauTableDataHttp.dataArrived
        RaiseEvent getResponseloadBordereauTableData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadBordereauTableDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadBordereauTableDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function savePhotoData() As Boolean Implements IDataSiteRequests.savePhotoData
        savePhotoDataHttp = New HttpDataPostData(stateCore)
        savePhotoDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("photos"))
            savePhotoDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        savePhotoDataHttp.startRequest()
        Return True
    End Function
    Private Sub savePhotoDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles savePhotoDataHttp.dataArrived
        RaiseEvent getResponseSavePhotoData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub savePhotoDataHttp_requestCompleted(sender As Object, responseData As String) Handles savePhotoDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadRegieTableData() As Boolean Implements IDataSiteRequests.loadRegieTableData
        loadRegieTableDataHttp = New HttpDataPostData(stateCore)
        loadRegieTableDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("unscheduledWorks"))
            loadRegieTableDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadRegieTableDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadRegieTableDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadRegieTableDataHttp.dataArrived
        RaiseEvent getResponseLoadRegieTableData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadRegieTableDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadRegieTableDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadProductionTableData() As Boolean Implements IDataSiteRequests.loadProductionTableData
        loadProductionTableDataHttp = New HttpDataPostData(stateCore)
        loadProductionTableDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadProductionTableDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadProductionTableDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadProductionTableDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadProductionTableDataHttp.dataArrived
        RaiseEvent getResponseProductionTableData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadProductionTableDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadProductionTableDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveProductionData() As Boolean Implements IDataSiteRequests.saveProductionData
        saveProductionDataHttp = New HttpDataPostData(stateCore)
        saveProductionDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteDailyProduction"))
            saveProductionDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveProductionDataHttp.startRequest()
        Return True

    End Function
    Private Sub saveProductionDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveProductionDataHttp.dataArrived
        RaiseEvent getResponseSaveProductionData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveProductionDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveProductionDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadDeliveryTableData() As Boolean Implements IDataSiteRequests.loadDeliveryTableData
        loadDeliveryTableDataHttp = New HttpDataPostData(stateCore)
        loadDeliveryTableDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteMaterialsDelivery"))
            loadDeliveryTableDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadDeliveryTableDataHttp.startRequest()
        Return True

    End Function
    Private Sub loadDeliveryTableDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadDeliveryTableDataHttp.dataArrived
        RaiseEvent getResponseDeliveryTableData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadDeliveryTableDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadDeliveryTableDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadJournalData() As Boolean Implements IDataSiteRequests.loadJournalData
        loadJournalDataHttp = New HttpDataPostData(stateCore)
        loadJournalDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("journalattendance"))
            loadJournalDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadJournalDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadJournalDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadJournalDataHttp.dataArrived
        If misc("task").Equals("journal") Then
            RaiseEvent getResponseLoadJournalData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("workers") Then
            RaiseEvent getResponseLoadJournalWorkersData(Me, New DataRequestsDataResult(responseData, misc))
        ElseIf misc("task").Equals("workerCategories") Then
            RaiseEvent getResponseLoadJournalWorkersCategoriesData(Me, New DataRequestsDataResult(responseData, misc))
        End If
    End Sub
    Private Sub loadJournalDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadJournalDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadJournalReportData() As Boolean Implements IDataSiteRequests.loadJournalReportData
        loadJournalReportDataHttp = New HttpDataPostData(stateCore)
        loadJournalReportDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            loadJournalReportDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadJournalReportDataHttp.startRequest()
        Return True

    End Function
    Private Sub loadJournalReportDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadJournalReportDataHttp.dataArrived
        RaiseEvent getResponseloadJournalReportData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadJournalReportDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadJournalReportDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadJournalHistoryOfDayData() As Boolean Implements IDataSiteRequests.loadJournalHistoryOfDayData
        loadJournalHistoryOfDayDataHttp = New HttpDataPostData(stateCore)
        loadJournalHistoryOfDayDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("journalLog"))
            loadJournalHistoryOfDayDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        loadJournalHistoryOfDayDataHttp.startRequest()
        Return True
    End Function
    Private Sub loadJournalHistoryOfDayDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles loadJournalHistoryOfDayDataHttp.dataArrived
        RaiseEvent getResponseloadJournalHistoryOfDayData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub loadJournalHistoryOfDayDataHttp_requestCompleted(sender As Object, responseData As String) Handles loadJournalHistoryOfDayDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveClosedDaysData() As Boolean Implements IDataSiteRequests.saveClosedDaysData
        saveClosedDaysDataHttp = New HttpDataPostData(stateCore)
        saveClosedDaysDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteClosedDays"))
            saveClosedDaysDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveClosedDaysDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveClosedDaysDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveClosedDaysDataHttp.dataArrived
        RaiseEvent getResponseSaveClosedDaysData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveClosedDaysDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveClosedDaysDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveDeliveryData() As Boolean Implements IDataSiteRequests.saveDeliveryData
        saveDeliveryDataHttp = New HttpDataPostData(stateCore)
        saveDeliveryDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteMaterialsDelivery"))
            saveDeliveryDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveDeliveryDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveDeliveryDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveDeliveryDataHttp.dataArrived
        RaiseEvent getResponseSaveDeliveryData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveDeliveryDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveDeliveryDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveRegieData() As Boolean Implements IDataSiteRequests.saveRegieData
        saveRegieDataHttp = New HttpDataPostData(stateCore)
        saveRegieDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("unscheduledWorks"))
            saveRegieDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveRegieDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveRegieDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveRegieDataHttp.dataArrived
        RaiseEvent getResponseSaveRegieData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveRegieDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveRegieDataHttp.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function saveReceptionMaterialsData() As Boolean Implements IDataSiteRequests.saveReceptionMaterialsData
        saveReceptionMaterialsDataHttp = New HttpDataPostData(stateCore)
        saveReceptionMaterialsDataHttp.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("siteMaterialsReception"))
            saveReceptionMaterialsDataHttp.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        saveReceptionMaterialsDataHttp.startRequest()
        Return True
    End Function
    Private Sub saveReceptionMaterialsDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles saveReceptionMaterialsDataHttp.dataArrived
        RaiseEvent getResponseSaveMaterialsReceptionData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub saveReceptionMaterialsDataHttp_requestCompleted(sender As Object, responseData As String) Handles saveReceptionMaterialsDataHttp.requestCompleted

    End Sub
End Class


