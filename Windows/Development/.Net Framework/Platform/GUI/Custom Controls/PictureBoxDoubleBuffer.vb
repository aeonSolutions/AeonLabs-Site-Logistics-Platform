Imports System.Windows.Forms

Public Class PictureBoxDoubleBuffer
    Inherits PictureBox
    Public Sub New()
        SuspendLayout()

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        ''SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.UpdateStyles()

        ResumeLayout()
    End Sub
End Class
