Imports System.Threading

Public Class BusyThread
    Private isVisible As Boolean
    Private busyForm As waiting_frm
    Private mainform As MainMdiForm

    Public Sub New(_mainform As MainMdiForm)
        isVisible = False
    End Sub

    Public Sub Show(ByVal Optional text As String = "")
        If isVisible.Equals(False) Then
            isVisible = True
            busyForm = New waiting_frm(mainform)
            busyForm.isClosed = False
            busyForm.Start(text)
            While busyForm.isCheckingConnection Or Not busyForm.IsHandleCreated

            End While
        End If
    End Sub

    Public Function isActive() As Boolean
        Return isVisible
    End Function

    Public Sub Close(ByVal Optional override As Boolean = True)
        If Not IsNothing(busyForm) Then
            If isVisible Then
                busyForm.Stop()
                While Not busyForm.isClosed

                End While
                If busyForm.isClosed Then
                    busyForm = Nothing
                    isVisible = False
                End If
            End If
        End If
    End Sub

    Public Sub setMessage(text As String)
        busyForm.setMessage(text)
    End Sub
    Public Sub setTitle(text As String)
        busyForm.setTitle(text)
    End Sub
End Class
