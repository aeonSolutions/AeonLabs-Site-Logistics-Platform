
Imports System.Drawing
Imports System.Windows.Forms

Public Class messageBoxForm

    Private msbox As MessageBoxChild

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Public Sub New(_message As String, _title As String, _buttons As MessageBoxButtons, _icon As MessageBoxIcon, ByVal Optional posx As Integer = -1, ByVal Optional posy As Integer = -1, ByVal Optional _state As AeonLabs.Environment.environmentVarsCore = Nothing)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        msbox = New MessageBoxChild(_message, _title, _buttons, _icon, posx, posy)
    End Sub

    Private Sub messageBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AddOwnedForm(msbox)

    End Sub
    Private Sub messageBoxForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.DialogResult = msbox.ShowDialog()
    End Sub
    Private Sub AlignForms(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged, Me.Move, Me.Layout
        If msbox Is Nothing Then
            Exit Sub
        End If
        msbox.Location = Me.PointToScreen(Point.Empty)
        msbox.Size = Me.ClientSize
        msbox.Invalidate()
    End Sub
End Class
