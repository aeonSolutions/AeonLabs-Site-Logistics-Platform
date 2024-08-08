Imports System.Drawing
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core



Public Class journal_view_frm
    Private mainForm As MainMdiForm

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles richTextView.TextChanged

    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        Me.Refresh()
    End Sub

    Private Sub journal_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = mainForm.Width * 0.5
        Me.Height = mainForm.Height * 0.75
        richTextView.Width = Me.Width - 30
        richTextView.Height = Me.Height - 100

        Button3.Location = New Point(Me.Width - Button3.Width - 10, Me.Height - Button3.Height - 10)

        richTextView.Rtf = site_frm.richtext.Rtf

        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class