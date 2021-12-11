Public Class msgCenter_frm
    Private Sub msgCenter_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Dim width As Integer = Me.Width
        Dim height As Integer = Me.Height

    End Sub
    Private Sub CloseMe()
        Me.Close()
    End Sub


    Private Sub msgCenter_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown




    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class