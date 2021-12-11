Imports System.ComponentModel

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms
Imports AeonLabs.Environment
Imports AeonLabs.Security

Public Class HttpDataFilesDownload
    Inherits HttpDataCore

    Private fileExtension() As String

    Public Event dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String))
    Public Event updateProgressStatistics(sender As Object, dataStatistics As _data_statistics, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "")
        MyBase.New(_state, _url)
    End Sub
    Public Sub initialize(ByVal Optional _threadCount As Integer = 0)
        If Not _threadCount.Equals(0) Then
            threadCount = _threadCount
        End If

        ReDim bwDataRequest(threadCount)
        ReDim fileExtension(threadCount)
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

        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            e.Result = False
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            fileExtension(queueBWorker(Index)) = "{'error':true,'message':'" & My.Resources.strings.errorNoNetwork & "'}"
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

        Dim Data2Send As String = ""
        For i = 0 To PostData.Count - 1
            Data2Send += HttpUtility.UrlEncode(PostData.Keys(i)) + "=" + HttpUtility.UrlEncode(PostData.Item(PostData.Keys(i))) + "&"
        Next

        Dim request As HttpWebRequest = HttpWebRequest.Create(url)
        request.Method = "POST"
        Dim data() As Byte = Encoding.UTF8.GetBytes(Data2Send)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = data.Length

        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(data, 0, data.Length)
        requestStream.Close()

        Dim readings As Integer = 0
        Dim speedtimer As New Stopwatch
        Dim dataStatisticsItem As _data_statistics

        Try
            Using response As HttpWebResponse = request.GetResponse()
                Using stream = response.GetResponseStream()
                    Using bytes = New MemoryStream()
                        Dim Buffer(256) As Byte
                        With dataStatisticsItem
                            .filesize = Math.Round(bytes.Length / 1024, 0)
                            .bytesSentReceived = 0
                            .speed = 0
                        End With
                        dataStatistics(queueBWorker(Index)) = dataStatisticsItem

                        While (bytes.Length < response.ContentLength)
                            Dim read = stream.Read(Buffer, 0, Buffer.Length)
                            If (read > 0) Then
                                bytes.Write(Buffer, 0, read)
                            Else
                                Exit While
                            End If

                            readings += 1
                            If readings >= 5 Then
                                dataStatisticsItem.speed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                                dataStatistics(queueBWorker(Index)) = dataStatisticsItem
                                speedtimer.Reset()
                                readings = 0
                                RaiseEvent updateProgressStatistics(Me, dataStatisticsItem, queue.misc)
                            End If
                        End While

                        Dim utf8Encoding As New System.Text.UTF8Encoding(True)

                        If response.StatusCode = HttpStatusCode.Accepted Or response.StatusCode = 200 Then
                            Dim responseFromServer = utf8Encoding.GetString(bytes.ToArray())
                            Dim decrypted As String = ""
                            If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                                decrypted = encryption.decrypt((responseFromServer)).Replace("\'", "'")
                                fileExtension(queueBWorker(Index)) = decrypted
                                e.Result = False
                            ElseIf response.GetResponseHeader("Content-Disposition") IsNot Nothing AndAlso Not response.GetResponseHeader("Content-Disposition").Equals("") Then
                                fileExtension(queueBWorker(Index)) = response.GetResponseHeader("Content-Disposition").Substring(response.GetResponseHeader("Content-Disposition").IndexOf("filename=") + 9)
                                e.Result = bytes.ToArray()
                            Else
                                Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                                fileExtension(queueBWorker(Index)) = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " (" & response.StatusCode & ")'}"
                                e.Result = False
                            End If
                        Else
                            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                            fileExtension(queueBWorker(Index)) = "{'error':true,'message':'" & My.Resources.strings.contactingCommServer & " (" & response.StatusCode & ")', 'statuscode':'" & response.StatusCode & "'}"
                            e.Result = False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            e.Result = False
            fileExtension(queueBWorker(Index)) = "{'error':true,'message':'" & ex.Message & "'}"
        End Try
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
        Dim data As New _queue_data_struct

        If IsResponseOk(fileExtension(queueBWorker(Index)), "statuscode") Then
            data = queue(queueBWorker(Index))
            data.status = 0 're queue the file
            SyncLock queueLock
                queue(queueBWorker(Index)) = data
            End SyncLock
            Dim errorMsg As String = ""
            Dim retry As _retry_attempts
            With retry
                .counter = retryAttempts.counter
                .previousPattern = retryAttempts.previousPattern
                .pattern = retryAttempts.pattern
                .errorMessage = retryAttempts.errorMessage
            End With

            errorMsg = GetMessage(fileExtension(Index))
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
        ElseIf IsResponseOk(fileExtension(Index)) Then
            errorMessage = GetMessage(fileExtension(Index))
        End If

        If Not e.Result.Equals(False) Then
            Try
                fileExtension(queueBWorker(Index)) = queue(queueBWorker(Index)).filenameOrSavePath & fileExtension(queueBWorker(Index))
                System.IO.File.WriteAllBytes(fileExtension(queueBWorker(Index)), e.Result)
            Catch ex As Exception
                Dim retry As _retry_attempts
                With retry
                    .counter = retryAttempts.counter
                    .previousPattern = retryAttempts.previousPattern
                    .pattern = retryAttempts.pattern
                    .errorMessage = retryAttempts.errorMessage
                End With

                retry.counter = 100
                retry.previousPattern = retry.pattern
                retry.errorMessage = "error saving file"

                retryAttempts = retry
            Finally

            End Try
        End If

        data = New _queue_data_struct
        data = queue(queueBWorker(Index))
        data.status = -1 'completed sucessfully status
        SyncLock queueLock
            queue(queueBWorker(Index)) = data
        End SyncLock

        loadingCounter += 1
        CompletionPercentage = (loadingCounter / queue.Count) * 100
        statusMessage = "Loading cloud files..."
        RaiseEvent dataArrived(Me, fileExtension(queueBWorker(Index)), queue(queueBWorker(Index)).misc)
    End Sub

End Class
