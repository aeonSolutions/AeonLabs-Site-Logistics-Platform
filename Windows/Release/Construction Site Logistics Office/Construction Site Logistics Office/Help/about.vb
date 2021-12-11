Public Class about_frm
    Private Sub about_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelVersion.Text = " " & Me.GetType.Assembly.GetName.Version.ToString

    End Sub



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:mtpsilva@icloud.com")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class