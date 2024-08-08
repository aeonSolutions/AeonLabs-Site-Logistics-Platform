Public Class SyncWithUI
    Public Event continueInUI(sender As Object)
    Private runBol As Boolean = False
    Private runBolSet As Boolean = False
    Public Base As Object
    Private setSize As Integer
    Private tasksDone As Integer = 0
    Public Sub New(Optional sender As Object = Nothing, Optional setSiz As Integer = 1)
        Base = sender
        setSize = setSiz
        tasksDone = 0
    End Sub

    Public Property RunningSet() As Boolean
        Get
            RunningSet = runBolSet
        End Get
        Set(ByVal value As Boolean)
            tasksDone += 1
            If tasksDone >= setSize Then
                runBolSet = value
                RaiseEvent continueInUI(Base)
            End If
        End Set
    End Property

    Public Property Running() As Boolean
        Get
            Running = runBol
        End Get
        Set(ByVal value As Boolean)
            runBol = value

            RaiseEvent continueInUI(Base)
        End Set
    End Property

End Class


