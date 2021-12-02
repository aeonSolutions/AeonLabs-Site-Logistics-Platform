Public Class tasksManagerClass
    Public Const TO_START As Integer = -1
    Public Const BUSY As Integer = 1
    Public Const FINISHED As Integer = 0

    Public Event tasksCompleted(sender As Object)

    Private tasks As Dictionary(Of String, Integer)
    Private atimer As New System.Timers.Timer
    Private taskEnded As Boolean = False
    Public Sub New()
        tasks = New Dictionary(Of String, Integer)
    End Sub

    Public Sub registerTask(name As String, status As Integer)
        tasks.Add(name, status)
    End Sub

    Public Sub startListening()
        taskEnded = False
        atimer.AutoReset = True
        atimer.Interval = 100
        AddHandler aTimer.Elapsed, AddressOf tick
        atimer.Start()

    End Sub

    Public Sub unload()
        If atimer IsNot Nothing Then
            atimer.Stop()
        End If
    End Sub
    Private Sub tick(ByVal sender As Object, ByVal e As EventArgs)
        If getTasksStatus.Equals(FINISHED) And Not taskEnded Then
            taskEnded = True
            RaiseEvent tasksCompleted(Me)
            atimer.Stop()
        End If
    End Sub

    Public Sub setStatus(name As String, status As Integer)
        tasks(name) = status
    End Sub

    Public Function getTasksStatus() As Integer
        For i = 0 To tasks.Count - 1
            If tasks.ElementAt(i).Value.Equals(TO_START) Or tasks.ElementAt(i).Value.Equals(BUSY) Then
                Return BUSY
            End If
        Next i
        Return FINISHED
    End Function
End Class
