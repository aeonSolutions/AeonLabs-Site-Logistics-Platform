Imports System.ComponentModel

Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Windows.Forms

Public Class HttpDataPostData
    Inherits HttpDataCore

    Public Event updateProgress(sender As Object, misc As Dictionary(Of String, String))
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

        For shtIndex = 0 To threadCount
            bwDataRequest(shtIndex) = New System.ComponentModel.BackgroundWorker
            bwDataRequest(shtIndex).WorkerReportsProgress = True
            bwDataRequest(shtIndex).WorkerSupportsCancellation = False

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
        Dim translations2 = New languageTranslations(state)
        translations2.load("errorMessages")

        Dim BWQueue As _queue_data_struct
        BWQueue = e.Argument

        Dim vars As New Dictionary(Of String, String)
        vars = BWQueue.vars

        BWQueue.BwFinished = True
        Dim arg As New List(Of Object)

        BWQueue.status = -1 ' completed 

        'TODO translation need to be local
        translations.load("errorMessages")
        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Or vars Is Nothing Then
            arg.Add(BWQueue)
            If vars Is Nothing Then
                arg.Add("{'error':true,'message':'missconfiguration vars'}")
            End If

            If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Or vars Is Nothing Then
                arg.Add("{'error':true,'message':'" & translations.getText("errorNoNetwork") & "'}")
            End If


            SyncLock bwDataRequest(BWQueue.BwPos)
                CoreQueue(BWQueue.queuePos) = BWQueue
            End SyncLock

            e.Result = arg
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
            vars.Add("origin", state.softwareAccessMode)
        End If

        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encryption As New AesCipher(state)
        Dim encrypted As String = HttpUtility.UrlEncode(encryption.encrypt(json))
        Dim PostData = "origin=" & state.softwareAccessMode & "&data=" & encrypted
        Dim request As WebRequest = WebRequest.Create(url)
        Dim responseFromServer As String = ""
        Dim decrypted As String = ""

        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add("Authorization", state.ApiHttpHeaderToken & "-" & state.softwareAccessMode)
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
                    decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " |" & responseFromServer & "|'}"
                End If
            Else
                decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & response.StatusCode & ")'}"
            End If
            arg.Add(BWQueue)
            arg.Add(decrypted.Replace("\'", "'"))
        Catch ex As Exception
            decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & ex.Message.ToString.Replace("'", "\'") & ")'}"
            arg.Add(BWQueue)
            arg.Add(decrypted.Replace("\'", "'"))
        End Try

        SyncLock bwDataRequest(BWQueue.BwPos)
            CoreQueue(BWQueue.queuePos) = BWQueue
        End SyncLock

        e.Result = arg

        'ToDo
        'Workcompleted(sender, e.Result.ToString, queue)
    End Sub

    Private Sub bwDataRequest_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Workcompleted(sender, e)
    End Sub


    Private Sub Workcompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

        Dim arg As List(Of Object) = TryCast(e.Result, List(Of Object))
        Dim data As _queue_data_struct = CType(arg(0), _queue_data_struct)
        Dim result As String = CStr(arg(1))

        data.BwFinished = True

        If Not IsResponseOk(result) Then
            data.status = 0 're queue the file

            Dim errorMsg As String = GetMessage(result)

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

        loadingCounter += 1
        CompletionPercentage = (loadingCounter / CoreQueue.Count) * 100
        statusMessage = "Loading data from the cloud ..."

        RaiseEvent updateProgress(Me, data.misc)
        RaiseEvent dataArrived(Me, result, data.misc)

        data.status = -1 're queue the file

        SyncLock bwDataRequest(data.BwPos)
            CoreQueue(data.queuePos) = data
        End SyncLock

    End Sub
End Class

