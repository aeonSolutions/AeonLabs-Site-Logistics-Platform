Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Timers
Imports System.Windows.Forms
Imports AeonLabs
Imports AeonLabs.Environment
Imports Newtonsoft.Json

Public Class HttpDataCore
    Public Property url As String
    Public Property state As New environmentVarsCore
    Public Property errorMessage As String = ""
    Public Property statusMessage As String
    Public Property threadCount As Integer = 25
    Public Property numberOfRetryAttempts = 5
    Public Property queue As List(Of _queue_data_struct)
    Public Property queueBWorker As Integer() ' has the size of threadCount
    Public Property queueLock As New Object
    Public Property retryAttempts As New _retry_attempts
    Public Property dataStatistics As List(Of _data_statistics)
    Public Property loadingCounter As Integer
    Public Property CompletionPercentage As Integer ' value range 0-100
    Public Property IsBusy As Boolean

    Public Structure _queue_data_struct
        Dim vars As Dictionary(Of String, String)
        Dim filenameOrSavePath As String                  ' full address file name or full adress folder path
        Dim misc As Dictionary(Of String, String)
        Dim status As Integer                             ' -1 - completed; 0- not sent yet; 1-already sent / processing 
    End Structure
    Public Structure _retry_attempts
        Dim counter As Integer
        Dim pattern As Integer
        Dim previousPattern As Integer
        Dim errorMessage As String
    End Structure
    Public Structure _data_statistics
        Dim filesize As Double
        Dim bytesSentReceived As Double
        Dim speed As Double
    End Structure

    Public WithEvents RestartQueueTimer As New Timers.Timer
    Public bwDataRequest() As BackgroundWorker

    Public Event requestCompleted(sender As Object, requestData As String) 'TODO add misc vars

    Private sendToQueue As Boolean
    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _overrideUrl As String = "")
        queue = New List(Of _queue_data_struct)
        dataStatistics = New List(Of _data_statistics)
        loadingCounter = 0
        sendToQueue = False
        If _state IsNot Nothing AndAlso _overrideUrl.Equals("") Then
            url = _state.ServerBaseAddr & _state.ApiServerAddrPath
        ElseIf Not _overrideUrl.Equals("") Then
            url = _overrideUrl
        Else
            Throw New System.Exception("Initialization err: state and url cannot be both null at same time")
        End If

        If _state IsNot Nothing Then
            state = _state
        End If

    End Sub
    Public Sub loadQueue(ByVal vars As Dictionary(Of String, String), ByVal Optional misc As Dictionary(Of String, String) = Nothing, ByVal Optional filenameOrSavePath As String = Nothing)
        Dim queueItem As New _queue_data_struct
        queueItem.vars = New Dictionary(Of String, String)
        queueItem.misc = New Dictionary(Of String, String)

        queueItem.vars = vars
        queueItem.status = 0
        queueItem.misc = misc
        queueItem.filenameOrSavePath = filenameOrSavePath
        queue.Add(queueItem)
    End Sub

    Public Sub clearQueue()
        loadingCounter = 0
        queue = New List(Of _queue_data_struct)
    End Sub
    Public Sub startRequest()
        If bwDataRequest(0) Is Nothing Then
            Throw New Exception("You need to call initialze first")
            Exit Sub
        End If

        'startSendQueue()
        IsBusy = True

        AddHandler RestartQueueTimer.Elapsed, New ElapsedEventHandler(AddressOf QueueTimerTick)
        With RestartQueueTimer
            .Enabled = True
            .Interval = 500
            .Start()
        End With
    End Sub

    Private Sub QueueTimerTick(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        If QueuesToComplete(queue).Equals(0) And QueuesToSend(queue).Equals(0) Then
            RestartQueueTimer.Stop()
            queue = New List(Of _queue_data_struct)
            RaiseEvent requestCompleted(Me, Nothing)
            IsBusy = False
            Exit Sub
        End If

        If retryAttempts.counter >= numberOfRetryAttempts Then 'ToDo a retry number of attempts before quits
            Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            Dim MsgBox As messageBoxForm
            MsgBox = New messageBoxForm(retryAttempts.errorMessage & ". " & My.Resources.strings.tryAgain & " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If MsgBox.ShowDialog() = DialogResult.Yes Then
                Dim retry As _retry_attempts
                With retry
                    .counter = 0
                    .previousPattern = -1
                    .pattern = 0
                    .errorMessage = ""
                End With
                retryAttempts = retry
                startSendQueue()
            Else
                RestartQueueTimer.Stop()
                queue = New List(Of _queue_data_struct)
                RaiseEvent requestCompleted(Me, Nothing)
                IsBusy = False
                Exit Sub
            End If
            Exit Sub
        ElseIf Not sendToQueue And QueuesToSend(queue) > 0 Then
            startSendQueue()
        End If
    End Sub

    Private Sub startSendQueue()
        sendToQueue = True
        While QueuesToSend(queue) > 0
            For shtIndex = 0 To threadCount
                For i = 0 To queue.Count - 1
                    If Not bwDataRequest(shtIndex).IsBusy Then
                        SyncLock queueLock
                            If queue.ElementAt(i).status.Equals(0) Then
                                Dim data As New _queue_data_struct
                                data.vars = queue.ElementAt(i).vars
                                data.status = 1
                                data.misc = queue.ElementAt(i).misc
                                data.filenameOrSavePath = queue.ElementAt(i).filenameOrSavePath
                                queue(i) = data
                                queueBWorker(shtIndex) = i
                                dataStatistics(shtIndex) = (New _data_statistics)

                                bwDataRequest(shtIndex).RunWorkerAsync(queue(i))
                                Threading.Thread.Sleep(50)
                            End If
                        End SyncLock
                    End If
                Next i
            Next shtIndex
        End While
        sendToQueue = False
    End Sub

    Public Function QueuesToSend(queue As List(Of _queue_data_struct)) As Integer
        Dim counter As Integer = 0
        For i = 0 To queue.Count - 1
            If queue(i).status.Equals(0) Then
                counter += 1
            End If
        Next i
        Return counter
    End Function
    Public Function QueuesToComplete(queue As List(Of _queue_data_struct)) As Integer
        Dim counter As Integer = 0
        For i = 0 To queue.Count - 1
            If queue(i).status.Equals(1) Then
                counter += 1
            End If
        Next i
        Return counter
    End Function
    Public Function QueuesMultiHash(queue As List(Of _queue_data_struct)) As Integer
        Dim counter As Integer = 0
        For i = 0 To queue.Count - 1
            If queue(i).status.Equals(1) Then
                counter += i
            End If
        Next i
        Return counter
    End Function

    Public Function IsBase64String(ByVal s As String) As Boolean
        s = s.Trim()
        Return (s.Length Mod 4 = 0) AndAlso Regex.IsMatch(s, "^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)
    End Function

    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Public Function ConvertDataToArray(key As String, fields As String(), response As String) As Dictionary(Of String, List(Of String))
        If GetMessage(response).Equals("1001") Then
            Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            errorMessage = "{'error':true,'message':'" & My.Resources.strings.errorNoRecordsFound & "'}"
            Return Nothing
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If jsonResult.ContainsKey(key) Then
                If Not jsonResult.Item(key).item(0).Count.Equals(fields.Length) Then
                    Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                    errorMessage = "{'error':true,'message':'" & My.Resources.strings.JsonFieldsMismatch & ". table(" & key & "'}"
                    Return Nothing
                Else
                    Dim results = New Dictionary(Of String, List(Of String))
                    For k = 0 To fields.Length - 1
                        Dim fieldValues As List(Of String) = New List(Of String)
                        For i = 0 To jsonResult.Item(key).Count - 1
                            fieldValues.Add(jsonResult.Item(key).item(i).item(k).ToString)
                        Next i
                        results.Add(fields(k), fieldValues)

                    Next k
                    Return results
                End If
            Else
                Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                errorMessage = "{'error':true,'message':'" & My.Resources.strings.JsonkeyNotFound & " (" & key & "'}"
                Return Nothing
            End If
        Catch ex As Exception
            errorMessage = "{'error':true,'message':'" & ex.ToString & "'}"
            errorMessage = ex.ToString
            Return Nothing
        End Try
    End Function
End Class
