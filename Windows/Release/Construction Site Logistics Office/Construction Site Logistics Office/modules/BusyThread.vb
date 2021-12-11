Imports System.Threading

Public Class BusyThread
    Private isClosed As Boolean
    Private busyForm As New waiting_frm
    Public Sub New()
        isClosed = True
    End Sub

    Public Sub Show(ByVal Optional text As String = "")
        If isClosed Then
            isClosed = False
            busyForm.Start(text)
        End If
    End Sub

    Public Function isActive() As Boolean
        Return Not isClosed
    End Function

    Public Sub Close(ByVal Optional override As Boolean = True)
        busyForm.Stop()
        If busyForm.isClosed Then
            isClosed = True
        End If
    End Sub

    Public Sub setMessage(text As String)
        busyForm.setMessage(text)
    End Sub
    Public Sub setTitle(text As String)
        busyForm.setTitle(text)
    End Sub
End Class
