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
        While Not team_frm.IsHandleCreated
            System.Windows.Forms.Application.DoEvents()
        End While



        If Not IsNothing(MainMdiForm.busy) Then
            MainMdiForm.busy.Close(True)
        End If

    End Sub

End Class
