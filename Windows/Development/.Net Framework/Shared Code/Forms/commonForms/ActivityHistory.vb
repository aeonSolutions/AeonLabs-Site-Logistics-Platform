Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class activity_frm
    Private state As New environmentVars
    private mainForm As MainMdiForm

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars)
        mainForm = _mainMdiForm
        state = _state
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()

    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub
    Private Sub activity_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tablePanel_Paint(sender As Object, e As PaintEventArgs) Handles tablePanel.Paint

    End Sub
End Class