Imports System.ComponentModel

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports AeonLabs.Environment
Imports AeonLabs.Security

Public Class HttpDataFilesUpload
    Inherits HttpDataCore

    Public Event updateProgressStatistics(sender As Object, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "")
        MyBase.New(_state, _url)
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
        Dim responseBytes As Byte()

        ' Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
        Dim Y As Integer
        Dim Index As Integer = Nothing
        For Y = 0 To UBound(bwDataRequest)
            If sender.Equals(bwDataRequest(Y)) Then
                Index = Y
                Exit For
            End If
        Next Y

        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)

            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & My.Resources.strings.errorNoNetwork & "'}")

            Exit Sub
        End If

        Dim queue As _queue_data_struct
        queue = e.Argument

        Dim vars As New Dictionary(Of String, String)

        vars = queue.vars
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


        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encryption As New AesCipher(state)
        Dim encrypted As String = HttpUtility.UrlEncode(encryption.encrypt(json))
        Dim PostData As New Dictionary(Of String, String)
        PostData.Add("origin", state.customization.softwareAccessMode)
        PostData.Add("data", encrypted)

        Dim currentspeed As Double = -1

        Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & vbCrLf)
        Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        wr.ContentType = "multipart/form-data; boundary=" & boundary
        wr.Method = "POST"
        wr.KeepAlive = True
        wr.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim rs As Stream = wr.GetRequestStream()
        Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" & vbCrLf & vbCrLf & "{1}"

        For i = 0 To PostData.Count - 1
            rs.Write(boundarybytes, 0, boundarybytes.Length)
            Dim formitem As String = String.Format(formdataTemplate, PostData.Keys(i), PostData.Item(PostData.Keys(i)))
            Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
            rs.Write(formitembytes, 0, formitembytes.Length)
        Next

        rs.Write(boundarybytes, 0, boundarybytes.Length)
        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCrLf & "Content-Type: {2}" & vbCrLf & vbCrLf
        Dim header As String = String.Format(headerTemplate, "file", System.IO.Path.GetFileName(queue.filenameOrSavePath), "application/octet-stream")
        Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        rs.Write(headerbytes, 0, headerbytes.Length)
        Dim fileStream As FileStream = New FileStream(queue.filenameOrSavePath, FileMode.Open, FileAccess.Read)
        Dim buffer As Byte() = New Byte(4095) {}

        Dim bytesRead As Integer = 0
        Dim totalBytesRead As Double = 0
        Dim readings As Integer = 0
        Dim speedtimer As New Stopwatch
        Dim dataStatisticsItem As _data_statistics
        Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
        With dataStatisticsItem

            .filesize = My.Resources.strings.size & ": " & Math.Round(fileStream.Length / 1024, 0) & " " & My.Resources.strings.bytes
            .bytesSentReceived = 0
            .speed = 0
        End With
        dataStatistics(queueBWorker(Index)) = dataStatisticsItem

        bytesRead = fileStream.Read(buffer, 0, buffer.Length)
        While (bytesRead <> 0)
            rs.Write(buffer, 0, bytesRead)

            dataStatisticsItem.bytesSentReceived += bytesRead
            dataStatistics(queueBWorker(Index)) = dataStatisticsItem

            readings += 1
            If readings >= 5 Then
                dataStatisticsItem.speed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                dataStatistics(queueBWorker(Index)) = dataStatisticsItem
                speedtimer.Reset()
                readings = 0
                RaiseEvent updateProgressStatistics(Me, queue.misc)
            End If
            bytesRead = fileStream.Read(buffer, 0, buffer.Length)
        End While

        fileStream.Close()
        Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & "--" & vbCrLf)
        rs.Write(trailer, 0, trailer.Length)
        rs.Close()
        Dim wresp As WebResponse = Nothing

        Try
            wresp = wr.GetResponse()
            Dim stream2 As Stream = wresp.GetResponseStream()
            Dim reader2 As StreamReader = New StreamReader(stream2)

            responseBytes = System.Text.Encoding.UTF8.GetBytes(reader2.ReadToEnd())
        Catch ex As Exception
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & My.Resources.strings.contactingCommServer & ":" & ex.Message & "'}")

            If wresp IsNot Nothing Then
                wresp.Close()
                wresp = Nothing
            End If
        End Try
        wr = Nothing
        e.Result = responseBytes
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        ' Find out the Index of the bWorker that called this DoWork (could be cleaner, I know)
        Dim Y As Integer
        Dim Index As Integer = Nothing
        For Y = 0 To UBound(bwDataRequest)
            If sender.Equals(bwDataRequest(Y)) Then
                Index = Y
                Exit For
            End If
        Next Y

        Dim responseFromServer As String = System.Text.Encoding.UTF8.GetString(e.Result)
        Dim decrypted As String = ""
        Dim encryption As New AesCipher(state)
        Dim data As _queue_data_struct
        Try
            If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                decrypted = encryption.decrypt((responseFromServer))
            Else
                Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                decrypted = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " |" & responseFromServer & "|'}"
            End If

        Catch ex As Exception
            decrypted = "{'error':true,'message':'" & ex.Message.ToString.Replace("'", "\'") & "'}"
        End Try

        If Not IsResponseOk(decrypted) Then
            data = New _queue_data_struct
            data = queue(queueBWorker(Index))
            data.status = 0 're queue the file
            SyncLock queueLock
                queue(queueBWorker(Index)) = data
            End SyncLock
            Dim errorMsg As String = GetMessage(decrypted)
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
        statusMessage = "Uploading data to the cloud ..."
        RaiseEvent dataArrived(Me, decrypted, queue(queueBWorker(Index)).misc)
    End Sub

End Class
