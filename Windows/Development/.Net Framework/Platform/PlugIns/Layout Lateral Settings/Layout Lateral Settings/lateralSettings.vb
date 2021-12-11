
Imports System.Drawing
Imports System.Windows.Forms
Imports AeonLabs.Environment

Public Class lateralSettingsForm

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private envars As environmentVarsCore
    Private updateMainApp As environmentVarsCore.updateMainLayoutDelegate

    Private backGroundImageToolTip As New ToolTip()
    Private colorPalleteToolTip As New ToolTip()

    Public Sub New(_envars As AeonLabs.Environment.environmentVarsCore, ByRef _updateMainApp As environmentVarsCore.updateMainLayoutDelegate)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        envars = _envars
        updateMainApp = _updateMainApp

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(envars.currentLang)

        Dim backGroundImageToolTip As New ToolTip()
        backGroundImageToolTip.SetToolTip(selectBackGroundImage, My.Resources.strings.backGroundImage)

        Dim colorPalleteToolTip As New ToolTip()
        colorPalleteToolTip.SetToolTip(selectPanelBackColor, My.Resources.strings.colorPallete)

        panelForm.BackColor = Color.FromArgb(envars.layoutDesign.PanelTransparencyIndex, envars.layoutDesign.PanelBackColor)

        Me.ResumeLayout()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        MacTrackBar1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub messageBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub messageBoxForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub selectPanelBackColor_Click(sender As Object, e As EventArgs) Handles selectPanelBackColor.Click
        If ColorPickerDialog.ShowDialog = Global.System.Windows.Forms.DialogResult.OK Then
            envars.layoutDesign.PanelBackColor = ColorPickerDialog.Color

            Dim dataUpdate As New updateMainAppClass
            dataUpdate.envars = envars
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT
            updateMainApp.Invoke(Me, dataUpdate)
        End If
    End Sub

    Private Sub MacTrackBar2_ValueChanged(sender As Object, value As Decimal) Handles MacTrackBar1.ValueChanged
        envars.layoutDesign.PanelTransparencyIndex = value

        Dim dataUpdate As New updateMainAppClass
        dataUpdate.envars = envars
        dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT
        updateMainApp.Invoke(Me, dataUpdate)
    End Sub

    Private Sub panelForm_Paint_1(sender As Object, e As PaintEventArgs) Handles panelForm.Paint

    End Sub

    Private Sub selectBackGroundImage_Click(sender As Object, e As EventArgs) Handles selectBackGroundImage.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = My.Resources.strings.openFile
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = My.Resources.strings.imageFile & " jpg|*.jpg"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim dataUpdate As New updateMainAppClass
            dataUpdate.envars = envars
            dataUpdate.backGroundFileName = OpenFileDialog1.FileName
            dataUpdate.updateTask = updateMainAppClass.UPDATE_LAYOUT_BACKGROUND
            updateMainApp.Invoke(Me, dataUpdate)
        End If
    End Sub
End Class

