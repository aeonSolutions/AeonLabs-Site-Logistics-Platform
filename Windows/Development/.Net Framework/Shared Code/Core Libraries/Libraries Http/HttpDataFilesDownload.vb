Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.UI

Public Class HttpDataFilesDownload
    Inherits HttpDataCore

    Private fileExtension() As String

    Public Event updateProgressStatistics(sender As Object, dataStatistics As _data_statistics, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, requestData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVars = Nothing, ByVal Optional _url As String = "")
        MyBase.New(_state, _url)
    End Sub
    Public Sub initialize(ByVal Optional _threadCount As Integer = Nothing)
        If Not IsNothing(_threadCount) Then
            If (_threadCount > 0) Then
                threadCount = _threadCount
            End If
        End If

        ReDim bwDataRequest(threadCount)
        ReDim fileExtension(threadCount)
        ReDim dataStatistics(threadCount)

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
    End Sub

    Private Sub bwDataRequest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Me.TaskIDstring = Me.TaskIDstring

        Dim EmptyBuffer As Byte() = New Byte() {}

        Dim translations2 = New languageTranslations(state)
        translations2.load("errorMessages")

        Dim BwQueue As _queue_data_struct
        BwQueue = e.Argument

        Dim arg As New List(Of Object)
        arg.Add(BwQueue)

        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            fileExtension(BwQueue.BwPos) = "{'error':true,'message':'" & translations2.getText("errorNoNetwork") & "'}"
            arg.Add(EmptyBuffer)
            arg.Add(False)
            e.Result = arg
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)

        vars = BwQueue.vars
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
        PostData.Add("origin", state.softwareAccessMode)
        PostData.Add("data", encrypted)

        Dim Data2Send As String = ""
        translations2.load("uploadFile")
        For i = 0 To PostData.Count - 1
            Data2Send += HttpUtility.UrlEncode(PostData.Keys(i)) + "=" + HttpUtility.UrlEncode(PostData.Item(PostData.Keys(i))) + "&"
        Next

        Dim request As HttpWebRequest = HttpWebRequest.Create(state.ServerBaseAddr & state.ApiServerAddrPath)
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
                        dataStatistics(BwQueue.BwPos) = dataStatisticsItem

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
                                dataStatistics(BwQueue.BwPos) = dataStatisticsItem
                                speedtimer.Reset()
                                readings = 0
                                RaiseEvent updateProgressStatistics(Me, dataStatisticsItem, BwQueue.misc)
                            End If
                        End While

                        Dim utf8Encoding As New System.Text.UTF8Encoding(True)

                        Dim responseFromServer = utf8Encoding.GetString(bytes.ToArray())
                        Dim decrypted As String = ""
                        If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                            decrypted = encryption.decrypt((responseFromServer)).Replace("\'", "'")
                            fileExtension(BwQueue.BwPos) = decrypted
                            arg.Add(EmptyBuffer)
                            arg.Add(False)
                        Else
                            fileExtension(BwQueue.BwPos) = response.GetResponseHeader("Content-Disposition").Substring(response.GetResponseHeader("Content-Disposition").IndexOf("filename=") + 9)
                            arg.Add(bytes.ToArray())
                            arg.Add(True)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            arg.Add(EmptyBuffer)
            arg.Add(False)
            fileExtension(BwQueue.BwPos) = "{'error':true,'message':'" & ex.Message & "'}"
        End Try

        e.Result = arg
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Me.TaskIDstring = Me.TaskIDstring

        Dim arg As List(Of Object) = TryCast(e.Result, List(Of Object))
        Dim data As _queue_data_struct = CType(arg(0), _queue_data_struct)
        Dim dataBytes As Byte() = CType(arg(1), Byte())
        Dim resultState As Boolean = CBool(arg(2))

        data.BwFinished = True

        If resultState.Equals(False) Or fileExtension(data.BwPos).Equals("") Then
            data.status = 0 're queue the file

            Dim errorMsg As String = ""

            Dim retry As _retry_attempts
            With retry
                .errorMessage = retryAttempts.errorMessage
            End With

            If fileExtension(data.BwPos).Equals("") Then
                errorMsg = retryAttempts.errorMessage
                retry.errorMessage = If(retryAttempts.errorMessage.IndexOf(errorMsg) > -1, retryAttempts.errorMessage, retryAttempts.errorMessage & Environment.NewLine & errorMsg)
            ElseIf Not IsResponseOk(fileExtension(data.BwPos)) Then
                errorMsg = GetMessage(fileExtension(data.BwPos)) & "(" & CoreQueue(data.BwPos).vars("file") & ")"
                retry.errorMessage = If(retryAttempts.errorMessage.IndexOf(errorMsg) > -1, retryAttempts.errorMessage, retryAttempts.errorMessage & Environment.NewLine & errorMsg)
            Else
                errorMsg = fileExtension(data.BwPos)
                retry.errorMessage = If(retryAttempts.errorMessage.IndexOf(errorMsg) > -1, retryAttempts.errorMessage, retryAttempts.errorMessage & Environment.NewLine & errorMsg)
            End If
            retryAttempts = retry

            SyncLock bwDataRequest(data.BwPos)
                CoreQueue(data.queuePos) = data
            End SyncLock

            ErrorFound()
            Exit Sub
        End If

        fileExtension(data.BwPos) = data.filenameOrSavePath & fileExtension(data.BwPos)
        Try
            System.IO.File.WriteAllBytes(state.libraryPath & fileExtension(data.BwPos), dataBytes)
        Catch ex As Exception
            data.status = 0 're queue the file

            Dim retry As _retry_attempts
            With retry
                .counter = retryAttempts.counter
                .errorMessage = retryAttempts.errorMessage
            End With

            retry.errorMessage = "error saving file"
            retryAttempts = retry

            SyncLock bwDataRequest(data.BwPos)
                CoreQueue(data.queuePos) = data
            End SyncLock

            ErrorFound()
            Exit Sub
        End Try

        data.status = -1 'completed sucessfully status

        loadingCounter += 1
        CompletionPercentage = (loadingCounter / CoreQueue.Count) * 100
        statusMessage = "Loading cloud files..."
        RaiseEvent updateProgressStatistics(Me, dataStatistics(data.BwPos), data.misc)
        RaiseEvent dataArrived(Me, fileExtension(data.BwPos), data.misc)

        SyncLock bwDataRequest(data.BwPos)
            CoreQueue(data.queuePos) = data
        End SyncLock
    End Sub
End Class
