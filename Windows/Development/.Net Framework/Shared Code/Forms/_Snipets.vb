Imports System.ComponentModel

Public Class Class1
    Private WithEvents bwSites As BackgroundWorker

    Private Sub sample()
        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSample_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork

    End Sub

    Private Sub bwSample_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        'While Not team_frm.IsHandleCreated
        'System.Windows.Forms.Application.DoEvents()
        'End While

        'If Not IsNothing(mainForm.busy) Then
        '   mainForm.busy.Close(True)
        'End If

    End Sub

    'Module A
    Private _value As Integer
        Public Event ValueChanged()

        Public Property Value() As Integer
            Get
                Return _value
            End Get
            Set(ByVal value As Integer)
                _value = value
                RaiseEvent ValueChanged()
            End Set
        End Property
    'End Module

    'Module B
    Sub Main()
            AddHandler ValueChanged, AddressOf Method_ValueChanged
        'A.Value = 12
    End Sub

        Public Sub Method_ValueChanged()
            Console.WriteLine("Changed!")
        End Sub
    'End Module
End Class
