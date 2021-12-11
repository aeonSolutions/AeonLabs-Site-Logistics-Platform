Public Class backgroundTasks
    Dim t As Threading.Thread = Nothing

    Public Sub New(_t As Threading.Thread)
        t = _t
        t.SetApartmentState(Threading.ApartmentState.STA)
        t.Priority = Threading.ThreadPriority.Normal
        t.IsBackground = True
    End Sub

    Public Sub Start()
        t.Start()
    End Sub
    Public Function threadName() As String
        Return t.Name
    End Function

    Public Function hasEnded() As Boolean
        Try
            Return Not (t.ThreadState = ThreadState.Initialized = True Or t.ThreadState = ThreadState.Running = True)
        Catch
            Return True
        End Try
    End Function

    Public Function State() As Boolean
        Return t.ThreadState
    End Function

    Public Sub dispose()
        t.Join()
        t = Nothing
    End Sub
End Class
