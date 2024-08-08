Imports System.ComponentModel

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms

Public Class HttpDataFilesUpload
    Inherits HttpDataCore

    Public Event updateProgressStatistics(sender As Object, misc As Dictionary(Of String, String))
    Public Event dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String))

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "")
        MyBase.New(_state, _url)
    End Sub
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
    End Sub

    Private Sub bwDataRequest_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim translations As languageTranslations
        translations = New languageTranslations(state)
        Dim responseBytes As Byte()

        translations.load("errorMessages")

        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("errorNoNetwork") & "'}")

            Exit Sub
        End If

        Dim BwQueue As _queue_data_struct
        BwQueue = e.Argument

        Dim arg As New List(Of Object)
        arg.Add(BwQueue)

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

        Dim currentspeed As Double = -1

        translations.load("uploadFile")

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
        Dim header As String = String.Format(headerTemplate, "file", System.IO.Path.GetFileName(BwQueue.filenameOrSavePath), "application/octet-stream")
        Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        rs.Write(headerbytes, 0, headerbytes.Length)
        Dim fileStream As FileStream = New FileStream(BwQueue.filenameOrSavePath, FileMode.Open, FileAccess.Read)
        Dim buffer As Byte() = New Byte(4095) {}

        Dim bytesRead As Integer = 0
        Dim totalBytesRead As Double = 0
        Dim readings As Integer = 0
        Dim speedtimer As New Stopwatch
        Dim dataStatisticsItem As _data_statistics
        With dataStatisticsItem
            .filesize = translations.getText("size") & ": " & Math.Round(fileStream.Length / 1024, 0) & " " & translations.getText("bytes")
            .bytesSentReceived = 0
            .speed = 0
        End With
        dataStatistics(BwQueue.BwPos) = dataStatisticsItem

        bytesRead = fileStream.Read(buffer, 0, buffer.Length)
        While (bytesRead <> 0)
            rs.Write(buffer, 0, bytesRead)

            dataStatisticsItem.bytesSentReceived += bytesRead
            dataStatistics(BwQueue.BwPos) = dataStatisticsItem

            readings += 1
            If readings >= 5 Then
                dataStatisticsItem.speed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                dataStatistics(BwQueue.BwPos) = dataStatisticsItem
                speedtimer.Reset()
                readings = 0
                RaiseEvent updateProgressStatistics(Me, BwQueue.misc)
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
            translations.load("errorMessages")
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("contactingCommServer") & ":" & ex.Message & "'}")

            If wresp IsNot Nothing Then
                wresp.Close()
                wresp = Nothing
            End If
        End Try
        wr = Nothing
        arg.Add(responseBytes)
        e.Result = arg
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim arg As List(Of Object) = TryCast(e.Result, List(Of Object))
        Dim data As _queue_data_struct = CType(arg(0), _queue_data_struct)
        Dim dataBytes As Byte() = CType(arg(1), Byte())

        Dim responseFromServer As String = System.Text.Encoding.UTF8.GetString(e.Result)
        Dim decrypted As String = ""
        Dim encryption As New AesCipher(state)

        data.BwFinished = True

        Try
            If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                decrypted = encryption.decrypt((responseFromServer))
            Else
                translations.load("errorMessages")
                decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " |" & responseFromServer & "|'}"
            End If

        Catch ex As Exception
            translations.load("errorMessages")
            decrypted = "{'error':true,'message':'" & ex.Message.ToString.Replace("'", "\'") & "'}"
        End Try

        If Not IsResponseOk(decrypted) Then
            data.status = 0 're queue the file

            Dim errorMsg As String = GetMessage(decrypted)
            Dim retry As _retry_attempts
            With retry
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
        statusMessage = "Uploading data to the cloud ..."
        RaiseEvent dataArrived(Me, decrypted, data.misc)

        SyncLock bwDataRequest(data.BwPos)
            CoreQueue(data.queuePos) = data
        End SyncLock
    End Sub

End Class
