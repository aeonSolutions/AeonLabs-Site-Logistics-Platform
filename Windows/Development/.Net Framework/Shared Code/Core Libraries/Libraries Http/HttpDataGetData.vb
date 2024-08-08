Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms

Public Class HttpDataGetData
    Inherits HttpDataCore

    Public Event updateProgress(sender As Object, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "", Optional connTyp As String = "")
        MyBase.New(_state, _url)
        connType = connTyp
    End Sub

    Private connType As String 'external, internal/none
    Public Sub initialize(ByVal Optional _threadCount As Integer = Nothing)
        If Not IsNothing(_threadCount) Then
            If (_threadCount > 0) Then
                threadCount = _threadCount
            End If
        End If

        ReDim bwDataRequest(threadCount)

        For shtIndex = 0 To threadCount
            bwDataRequest(shtIndex) = New System.ComponentModel.BackgroundWorker
            bwDataRequest(shtIndex).WorkerReportsProgress = True
            bwDataRequest(shtIndex).WorkerSupportsCancellation = True

            AddHandler bwDataRequest(shtIndex).DoWork, AddressOf bwDataRequest_DoWork
            AddHandler bwDataRequest(shtIndex).RunWorkerCompleted, AddressOf bwDataRequest_RunWorkerCompleted

        Next shtIndex
        Dim retry As _retry_attempts
        With retry
            .counter = 0
            .errorMessage = ""
        End With
        retryAttempts = retry

        Dim vars = New Dictionary(Of String, String)
        vars.Add("", "")
        loadQueue(vars, Nothing, Nothing)
    End Sub

    Private Sub bwDataRequest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim translations2 = New languageTranslations(state)
        translations2.load("errorMessages")

        Dim BwQueue As _queue_data_struct
        BwQueue = e.Argument

        Dim arg As New List(Of Object)
        arg.Add(BwQueue)

        Dim vars As New Dictionary(Of String, String)
        vars = BwQueue.vars

        'TODO translation need to be local
        translations.load("errorMessages")
        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            arg.Add("{'error':true,'message':'" & translations.getText("errorNoNetwork") & "'}")
            e.Result = arg
            Exit Sub
        End If
        If vars IsNot Nothing Then
            If vars.Count > 0 Then
                For i = 0 To vars.Count - 1
                    If vars.ElementAt(i).Key.Equals("") Then
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
        webClient.Headers.Add("Accept", "Text/ html, Application / xhtml + Xml, Application / Xml;q=0.9,*/*;q=0.8")
        webClient.Headers.Add("Cache-Control", "max-age = 0")
        webClient.Headers.Add("User-Agent", "Mozilla/ 5.0(Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, Like Gecko) Chrome/27.0.1453.94 Safari/537.36")
        webClient.Headers.Add("Accept-Encoding", "gzip, deflate, sdch")
        webClient.Headers.Add("Accept-Language", "en-US, en;q=0.8, nl;q=0.6")

        Dim result As Byte()
        Try
            result = webClient.DownloadData((url))
        Catch ex As Exception
            translations.load("errorMessages")
            arg.Add("{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & ex.Message.ToString & Environment.NewLine & url & ")'}")
            e.Result = arg
            Exit Sub
        End Try
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)
        arg.Add(utf8Encoding.GetString(result))
        e.Result = arg
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim arg As List(Of Object) = TryCast(e.Result, List(Of Object))
        Dim data As _queue_data_struct = CType(arg(0), _queue_data_struct)
        Dim result As String = CStr(arg(1))

        data.BwFinished = True

        If Not IsResponseOk(result) And Not connType.Equals("external") Then
            data.status = 0 're queue the file

            Dim errorMsg As String = GetMessage(e.Result)
            Dim retry As _retry_attempts
            With retry
                .counter = retryAttempts.counter + 1
                .errorMessage = retryAttempts.errorMessage
            End With
            retry.errorMessage = If(retryAttempts.errorMessage.IndexOf(errorMsg) > -1, retryAttempts.errorMessage, retryAttempts.errorMessage & Environment.NewLine & errorMsg)

            retryAttempts = retry

            SyncLock bwDataRequest(data.BwPos)
                CoreQueue(data.queuePos) = data
            End SyncLock

            ErrorFound()
            Exit Sub
        End If

        data.status = -1 'completed sucessfully status

        loadingCounter += 1
        CompletionPercentage = (loadingCounter / CoreQueue.Count) * 100
        statusMessage = "Loading data from the cloud ..."
        RaiseEvent updateProgress(Me, data.misc)
        RaiseEvent dataArrived(Me, result, data.misc)

        SyncLock bwDataRequest(data.BwPos)
            CoreQueue(data.queuePos) = data
        End SyncLock
    End Sub
End Class


