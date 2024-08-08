Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Timers
Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class HttpDataCore
    Public Property translations As languageTranslations
    Public Property url As String
    Public Property state As New environmentVars
    'Public Property form As Form

    Public Property errorMessage As String = ""
    Public Property statusMessage As String
    Public Property threadCount As Integer = 10
    Public Property numberOfRetryAttempts = 5

    Public Property CoreQueue As List(Of _queue_data_struct)
    Public Property retryAttempts As New _retry_attempts
    Public dataStatistics() As _data_statistics

    Public Property loadingCounter As Integer
    Public Property CompletionPercentage As Integer ' value range 0-100
    Public Property TerminatedOnError As Boolean = Nothing
    Private errorMsgAlreadyOccurred As Boolean = False

    Public Property TaskIDstring = "none"

    Public Structure _queue_data_struct
        Dim vars As Dictionary(Of String, String)
        Dim filenameOrSavePath As String                  ' full address file name or full adress folder path
        Dim misc As Dictionary(Of String, String)
        Dim status As Integer                             ' -1 - completed; 0- not sent yet; 1-already sent / processing 
        Dim BwPos As Integer '(thread array position )
        Dim BwFinished As Boolean
        Dim queuePos As Integer
    End Structure
    Public Structure _retry_attempts
        Dim counter As Integer
        Dim errorMessage As String
    End Structure
    Public Structure _data_statistics
        Dim filesize As Double
        Dim bytesSentReceived As Double
        Dim speed As Double
    End Structure

    Public bwDataRequest() As BackgroundWorker
    Public BwStartSendQueue As BackgroundWorker
    Public TaskRequestCompleted As BackgroundWorker

    Public isQueueRunning As Boolean = False
    Private stopQueueRunning As Boolean = False

    Public InfoMessageWhileHtttpRequest As String = "Data"

    Public Event requestCompleted(sender As Object, Err As Boolean)
    Public Event requestSent(sender As Object, requestData As String, Err As Boolean)

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing, ByVal Optional _url As String = "")
        If _state IsNot Nothing AndAlso _url.Equals("") Then
            url = _state.ServerBaseAddr & _state.ApiServerAddrPath
        ElseIf Not _url.Equals("") Then
            url = _url
        Else
            Throw New System.Exception("Initialization err: state and url cannot be both null at same time")
        End If

        If _state IsNot Nothing Then
            state = _state
        End If

        CoreQueue = New List(Of _queue_data_struct)
        loadingCounter = 0
        translations = New languageTranslations(state)
        translations.load("errorMessages")

        TaskRequestCompleted = New System.ComponentModel.BackgroundWorker
        AddHandler TaskRequestCompleted.DoWork, AddressOf TaskRequestCompletedMonitor

        BwStartSendQueue = New System.ComponentModel.BackgroundWorker
        AddHandler BwStartSendQueue.DoWork, AddressOf startSendQueue
    End Sub
    Public Sub loadQueue(ByVal vars As Dictionary(Of String, String), ByVal Optional misc As Dictionary(Of String, String) = Nothing, ByVal Optional filenameOrSavePath As String = Nothing)
        Dim queueItem As New _queue_data_struct
        queueItem.vars = New Dictionary(Of String, String)
        queueItem.misc = New Dictionary(Of String, String)

        queueItem.vars = vars
        queueItem.status = 0
        queueItem.BwFinished = True
        queueItem.BwPos = -1
        queueItem.queuePos = -1
        queueItem.misc = misc
        queueItem.filenameOrSavePath = filenameOrSavePath
        CoreQueue.Add(queueItem)
    End Sub

    Public Sub clearQueue()
        loadingCounter = 0
        stopQueueRunning = True
        CoreQueue = New List(Of _queue_data_struct)

    End Sub
    Public Sub startRequest()
        Me.TaskIDstring = Me.TaskIDstring
        If bwDataRequest Is Nothing Then
            Throw New Exception("You need to call initialze first")
            Exit Sub
        End If

        isQueueRunning = False
        stopQueueRunning = False
        errorMsgAlreadyOccurred = False
        TerminatedOnError = False

        Dim retry As _retry_attempts
        With retry
            .counter = 0
            .errorMessage = ""
        End With
        retryAttempts = retry

        If BwStartSendQueue.IsBusy.Equals(False) Then
            BwStartSendQueue.RunWorkerAsync()
        End If

        If TaskRequestCompleted.IsBusy.Equals(False) Then
            TaskRequestCompleted.RunWorkerAsync()
        End If
    End Sub

    Private Sub TaskRequestCompletedMonitor(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Me.TaskIDstring = Me.TaskIDstring

        While QueuesToComplete(CoreQueue) > 0 And BwBusy() > 0
            Threading.Thread.Sleep(100)
        End While
        RaiseEvent requestCompleted(Me, TerminatedOnError)
    End Sub
    Private Function BwBusy() As Integer
        Dim i As Integer
        Dim counter As Integer = 0
        For i = 0 To bwDataRequest.Count - 1
            counter += 1
        Next i
        Return counter
    End Function
    Private Sub startSendQueue(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Me.TaskIDstring = Me.TaskIDstring

        If Me.TaskIDstring.Equals("DLLs") Then
            Me.TaskIDstring = Me.TaskIDstring
        End If

        Dim QueueSent As Boolean
        Dim count As Integer = 0

        If TerminatedOnError Or isQueueRunning Then
            Exit Sub
        End If
        isQueueRunning = True
        Dim tmp = QueuesToSend(CoreQueue)
        While QueuesToSend(CoreQueue) > 0
            For shtIndex = 0 To threadCount
                If stopQueueRunning Or TerminatedOnError Then
                    isQueueRunning = False
                    Exit Sub
                End If
                If bwDataRequest(shtIndex).IsBusy Then
                    Continue For
                End If

                For i = 0 To CoreQueue.Count - 1
                    If stopQueueRunning Or TerminatedOnError Then
                        isQueueRunning = False
                        Exit Sub
                    End If

                    If (CoreQueue.ElementAt(i).status.Equals(0)) And bwDataRequest(shtIndex).IsBusy.Equals(False) And CoreQueue.ElementAt(i).BwFinished.Equals(True) Then
                        count += 1

                        Dim data As New _queue_data_struct
                        data.vars = CoreQueue.ElementAt(i).vars
                        data.status = 1 'sent
                        data.misc = CoreQueue.ElementAt(i).misc
                        data.BwPos = shtIndex
                        data.BwFinished = False
                        data.queuePos = i

                        SyncLock bwDataRequest(shtIndex)
                            CoreQueue(i) = data
                            bwDataRequest(shtIndex).RunWorkerAsync(CoreQueue(i))
                        End SyncLock

                        Dim tmp2 = QueueCount()

                        RaiseEvent requestSent(Me, InfoMessageWhileHtttpRequest & " (" & QueueCount() & "/" & CoreQueue.Count & ") sent", False)
                        QueueSent = True
                        Exit For
                    End If
                Next i
                If QueueSent Then
                    QueueSent = False
                    Exit For
                End If
            Next shtIndex ' next Bw
        End While

        Dim retry As _retry_attempts
        With retry
            .counter = retryAttempts.counter + 1
            .errorMessage = ""
        End With
        retryAttempts = retry

        isQueueRunning = False
    End Sub

    Public Sub ErrorFound()
        TerminatedOnError = True
        errorMessage = retryAttempts.errorMessage
    End Sub


    '========================= QUEUE MNGT =================================================
    Private Function QueueCount() As Integer
        Dim i, count As Integer
        count = 0
        For i = 0 To CoreQueue.Count - 1
            If (CoreQueue(i).status.Equals(-1)) Then
                count += 1
            End If
        Next i
        Return count
    End Function

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
            If Not queue(i).status.Equals(-1) Then
                counter += 1
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
            translations.load("errorMessages")
            errorMessage = "{'error':true,'message':'" & translations.getText("errorNoRecordsFound") & "'}"
            Return Nothing
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If jsonResult.ContainsKey(key) Then
                If Not jsonResult.Item(key).item(0).Count.Equals(fields.Length) Then
                    translations.load("system")
                    errorMessage = "{'error':true,'message':'" & translations.getText("JsonFieldsMismatch") & ". table(" & key & ")'}"
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
                translations.load("system")
                errorMessage = "{'error':true,'message':'" & translations.getText("JsonkeyNotFound") & " (" & key & ")'}"
                Return Nothing
            End If
        Catch ex As Exception
            errorMessage = "{'error':true,'message':'" & ex.ToString & "'}"
            errorMessage = ex.ToString
            Return Nothing
        End Try
    End Function
End Class
