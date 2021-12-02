Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Partial Public Class PanelTransparentTextBox
    Inherits Panel
    Public Sub New()
        SuspendLayout()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        '' SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.UpdateStyles()

        BackColor = Color.Transparent
        Dim line As New LabelDoubleBuffer With {
            .BackColor = Color.White,
            .Size = New Size(Me.Width, 2),
            .Location = New Point(0, Me.Height),
            .Dock = DockStyle.Bottom,
            .AutoSize = False
        }
        Me.Controls.Add(line)
        ResumeLayout()
    End Sub


End Class
