Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports AeonLabs.Environment

Public Class HttpDataGetData
    Inherits HttpDataCore

    Public Event updateProgress(sender As Object, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "")
        MyBase.New(_state, _url)
    End Sub
    Public Sub initialize(ByVal Optional _threadCount As Integer = 0)
        If Not _threadCount.Equals(0) Then
            threadCount = _threadCount
        End If

        If Not url.Equals(state.ServerBaseAddr & state.ApiServerAddrPath) Then
            Dim queueItem As New _queue_data_struct
            queueItem.vars = New Dictionary(Of String, String)
            queueItem.misc = Nothing

            queueItem.vars.Add("url", url)
            queueItem.status = 0
            queueItem.filenameOrSavePath = ""
            queue.Add(queueItem)
        Else

        End If

        ReDim bwDataRequest(threadCount)
        ReDim queueBWorker(threadCount)

        For shtIndex = 0 To threadCount
            dataStatistics.Add(New _data_statistics)

            bwDataRequest(shtIndex) = New System.ComponentModel.BackgroundWorker
            bwDataRequest(shtIndex).WorkerReportsProgress = True
            bwDataRequest(shtIndex).WorkerSupportsCancellation = True

            AddHandler bwDataRequest(shtIndex).DoWork, AddressOf bwDataRequest_DoWork
            AddHandler bwDataRequest(shtIndex).RunWorkerCompleted, AddressOf bwDataRequest_RunWorkerCompleted
        Next shtIndex
        Dim retry As _retry_attempts
        With retry
            .counter = 0
            .previousPattern = -1
            .pattern = 0
            .errorMessage = ""
        End With
        retryAttempts = retry
    End Sub

    Private Sub bwDataRequest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

        ' Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
        Dim Y As Integer
        Dim Index As Integer = Nothing
        For Y = 0 To UBound(bwDataRequest)
            If sender.Equals(bwDataRequest(Y)) Then
                Index = Y
                Exit For
            End If
        Next Y

        Dim queue As _queue_data_struct
        queue = e.Argument

        Dim vars As New Dictionary(Of String, String)
        vars = queue.vars

        'TODO translation need to be local
        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)

            e.Result = "{'error':true,'message':'" & My.Resources.strings.errorNoNetwork & "'}"
            Exit Sub
        End If
        If vars IsNot Nothing Then
            If vars.Count > 0 Then
                For i = 0 To vars.Count - 1
                    If vars.ElementAt(i).Key.Equals("url") Then
                        Continue For
                    End If
                    If url.IndexOf("?") Then
                        url &= "&" & vars.ElementAt(i).Key & "=" & vars.ElementAt(i).Value
                    Else
                        url &= "?" & vars.ElementAt(i).Key & "=" & vars.ElementAt(i).Value
                    End If
                Next i
            End If
        End If
        Dim webClient As New System.Net.WebClient

        '' webClient.Headers.Add("Connection", "Keep-Alive")
        ''webClient.Headers.Add("Keep-Alive", "timeout=20")
        ''webClient.Headers.Add("ENCTYPE", "multipart/form-data")
        webClient.Headers.Add("User-Agent", "Aeon Labs")

        Dim result As Byte()
        Try

            result = webClient.DownloadData((url))
        Catch ex As Exception
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            e.Result = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " (" & ex.Message.ToString & System.Environment.NewLine & url & ")'}"
            Exit Sub
        End Try
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        e.Result = utf8Encoding.GetString(result)
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
        Dim Y As Integer
        Dim Index As Integer = Nothing
        Dim data As New _queue_data_struct

        For Y = 0 To UBound(bwDataRequest)
            If sender.Equals(bwDataRequest(Y)) Then
                Index = Y
                Exit For
            End If
        Next Y

        data = New _queue_data_struct
        data = queue(queueBWorker(Index))
        data.status = -1 'completed sucessfully status
        SyncLock queueLock
            queue(queueBWorker(Index)) = data
        End SyncLock

        loadingCounter += 1
        CompletionPercentage = (loadingCounter / queue.Count) * 100
        statusMessage = "Loading data from the cloud ..."
        RaiseEvent updateProgress(Me, queue(queueBWorker(Index)).misc)
        RaiseEvent dataArrived(Me, e.Result, queue(queueBWorker(Index)).misc)
    End Sub
End Class


