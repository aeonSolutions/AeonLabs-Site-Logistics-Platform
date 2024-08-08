Imports System.ComponentModel
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class absencesDataRequests
    Implements IDataAbsencesRequests

    Public Const key As String = "NPmPqPuuqlwPL6swalnnMSqKGCp6MTr9"
    Public version As Version = My.Application.Info.Version

    'the custom event use to send the name and password back to the caller form.
    'you can declare them to be whatever type of data you want. They don`t have to be strings
    Public Event getResponseAbsencesInitialData(sender As Object, args As DataRequestsDataResult) Implements IDataAbsencesRequests.getResponseAbsencesInitialData
    Public Event getResponseAbsencesReportData(sender As Object, args As DataRequestsDataResult) Implements IDataAbsencesRequests.getResponseAbsencesReportData
    Public Event getResponseAbsencesData(sender As Object, args As DataRequestsDataResult) Implements IDataAbsencesRequests.getResponseAbsencesData

    Private stateCore As New environmentVarsCore
    Private nestedForm As Form
    Private WithEvents bwLoadForm As HttpDataPostData
    Private WithEvents bwloadTableData As HttpDataPostData
    Private WithEvents bwloadClothesData As HttpDataPostData

    Private _vars As List(Of Dictionary(Of String, String))
    Private _misc As List(Of Dictionary(Of String, String))
    Private _filenamePath As List(Of String)

    'Use the constructor to pass info to this form. Use as many parameters of whatever type you need to pass to the form
    Public Sub New()
    End Sub

    Public Sub Initialise(stateIni As environmentVarsCore) Implements IDataAbsencesRequests.Initialise
        stateCore = stateIni
        _vars = New List(Of Dictionary(Of String, String))
        _misc = New List(Of Dictionary(Of String, String))
        _filenamePath = New List(Of String)
    End Sub

    Public Sub loadQueue(vars As Dictionary(Of String, String), misc As Dictionary(Of String, String), filenamePath As String) Implements IDataAbsencesRequests.loadQueue
        _vars.Add(vars)
        _misc.Add(misc)
        _filenamePath.Add(filenamePath)
    End Sub
    '==========================================================================================================================
    Public Function loadAbsencesInitialData() As Boolean Implements IDataAbsencesRequests.loadAbsencesInitialData
        bwLoadForm = New HttpDataPostData(stateCore)
        bwLoadForm.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            bwLoadForm.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        bwLoadForm.startRequest()
        Return True
    End Function

    Private Sub bwLoadForm_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles bwLoadForm.dataArrived
        RaiseEvent getResponseAbsencesInitialData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub bwLoadForm_requestCompleted(sender As Object, responseData As String) Handles bwLoadForm.requestCompleted

    End Sub
    '========================================================================================================================
    Public Function loadAbsencesReportData() As Boolean Implements IDataAbsencesRequests.loadAbsencesReportData
        bwloadTableData = New HttpDataPostData(stateCore)
        bwloadTableData.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("queries"))
            bwloadTableData.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        bwloadTableData.startRequest()
        Return True
    End Function

    Private Sub bwloadTableData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles bwloadTableData.dataArrived
        RaiseEvent getResponseAbsencesReportData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub bwloadTableData_requestCompleted(sender As Object, responseData As String) Handles bwloadTableData.requestCompleted

    End Sub
    '____________________________________________________________________________________________________________________
    Public Function loadAbsencesData() As Boolean Implements IDataAbsencesRequests.loadAbsencesData
        bwloadTableData = New HttpDataPostData(stateCore)
        bwloadTableData.initialize()

        If _vars.Count.Equals(0) Then
            Return False
        End If
        For i = 0 To _vars.Count - 1
            _vars.ElementAt(i).Add("task", stateCore.taskId("workerAbsenses"))
            bwloadClothesData.loadQueue(_vars.ElementAt(i), _misc.ElementAt(i), _filenamePath.ElementAt(i))
        Next i

        bwloadClothesData.startRequest()
        Return True
    End Function

    Private Sub bwloadClothesData_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles bwloadClothesData.dataArrived
        RaiseEvent getResponseAbsencesData(Me, New DataRequestsDataResult(responseData, misc))
    End Sub
    Private Sub bwloadClothesData_requestCompleted(sender As Object, responseData As String) Handles bwloadClothesData.requestCompleted

    End Sub
End Class
