Imports System.Windows.Forms

Public Class DoubleBufferPanel

    Inherits Panel
    Public Sub New()
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        Me.UpdateStyles()
    End Sub
End Class
