Partial Public Class TransparentRichTextBox
    Inherits Windows.Forms.RichTextBox
    Public Sub New()
        Me.DoubleBuffered = True
        ''this set forecolor to transparent not sure why
        ''SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        ''BackColor = Color.Transparent
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As Windows.Forms.CreateParams
        Get
            Dim CP As Windows.Forms.CreateParams = MyBase.CreateParams
            CP.ExStyle = CP.ExStyle Or &H20
            Return CP
        End Get
    End Property


End Class
