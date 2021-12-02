Imports System.ComponentModel

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports AeonLabs.Environment
Imports AeonLabs.Security

Public Class HttpDataPostData
    Inherits HttpDataCore

    Public Event updateProgress(sender As Object, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _overrideUrl As String = "")
        MyBase.New(_state, _overrideUrl)
    End Sub
    Public Sub initialize(ByVal Optional _threadCount As Integer = 0)
        If Not _threadCount.Equals(0) Then
            threadCount = _threadCount
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
        If vars Is Nothing Then
            e.Result = "{'error':true,'message':'missconfiguration vars'}"
            Exit Sub
        End If

        If Not vars.ContainsKey("id") Then
            vars.Add("id", state.userId)
        End If
        If Not vars.ContainsKey("pid") Then
            Dim appId As New FingerPrint
            vars.Add("pid", appId.Value)
        End If
        If Not vars.ContainsKey("language") Then
            vars.Add("language", state.currentLang)
        End If
        If Not vars.ContainsKey("origin") Then
            vars.Add("origin", state.customization.softwareAccessMode)
        End If

        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encryption As New AesCipher(state)
        Dim encrypted As String = HttpUtility.UrlEncode(encryption.encrypt(json))
        Dim PostData = "origin=" & state.customization.softwareAccessMode & "&data=" & encrypted
        Dim request As WebRequest = WebRequest.Create(url)
        Dim responseFromServer As String = ""
        Dim decrypted As String = ""

        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add("Authorization", state.ApiHttpHeaderToken & "-" & state.customization.softwareAccessMode)
        request.ContentLength = byteArray.Length
        Try
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            responseFromServer = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()

            If response.StatusCode = HttpStatusCode.Accepted Or response.StatusCode = 200 Then
                If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                    decrypted = encryption.decrypt((responseFromServer)).Replace("\'", "'")
                Else
                    Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                    decrypted = "{'error':true,'encrypted':false,'message':'" & My.Resources.strings.contactingCommServer & " |" & responseFromServer & "|'}"
                End If
            Else
                Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                decrypted = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " (" & response.StatusCode & ")', 'statuscode':'" & response.StatusCode & "'}"
            End If
        Catch ex As Exception
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            decrypted = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " (" & ex.Message.ToString.Replace("'", "\'") & ")'}"
        End Try

        e.Result = decrypted.Replace("\'", "'")
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

        If IsResponseOk(e.Result, "statuscode") Then
            data = New _queue_data_struct
            data = queue(queueBWorker(Index))
            data.status = 0 're queue the file
            SyncLock queueLock
                queue(queueBWorker(Index)) = data
            End SyncLock
            Dim errorMsg As String = GetMessage(e.Result)
            Dim retry As _retry_attempts
            With retry
                .counter = retryAttempts.counter
                .previousPattern = retryAttempts.previousPattern
                .pattern = retryAttempts.pattern
                .errorMessage = retryAttempts.errorMessage
            End With
            retry.errorMessage = If(retryAttempts.errorMessage.IndexOf(errorMsg) > -1, retryAttempts.errorMessage, retryAttempts.errorMessage & System.Environment.NewLine & errorMsg)

            retry.pattern = QueuesMultiHash(queue)
            If retry.previousPattern.Equals(retry.pattern) Then
                retry.counter += 1
            Else
                retry.counter = 1
                retry.previousPattern = retryAttempts.pattern
            End If

            retryAttempts = retry
            Exit Sub
        End If

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

