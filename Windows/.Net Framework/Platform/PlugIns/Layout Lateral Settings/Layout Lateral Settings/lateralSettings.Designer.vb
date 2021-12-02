

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lateralSettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ColorPickerDialog = New System.Windows.Forms.ColorDialog()
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.selectBackGroundImage = New FontAwesome.Sharp.IconPictureBox()
        Me.selectPanelBackColor = New FontAwesome.Sharp.IconPictureBox()
        Me.MacTrackBar1 = New XComponent.SliderBar.MACTrackBar()
        Me.panelForm = New PanelDoubleBuffer()
        CType(Me.selectBackGroundImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'selectBackGroundImage
        '
        Me.selectBackGroundImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.selectBackGroundImage.BackColor = System.Drawing.Color.Transparent
        Me.selectBackGroundImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selectBackGroundImage.IconChar = FontAwesome.Sharp.IconChar.Image
        Me.selectBackGroundImage.IconColor = System.Drawing.Color.White
        Me.selectBackGroundImage.IconSize = 20
        Me.selectBackGroundImage.Location = New System.Drawing.Point(40, 44)
        Me.selectBackGroundImage.Name = "selectBackGroundImage"
        Me.selectBackGroundImage.Size = New System.Drawing.Size(20, 20)
        Me.selectBackGroundImage.TabIndex = 3
        Me.selectBackGroundImage.TabStop = False
        '
        'selectPanelBackColor
        '
        Me.selectPanelBackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.selectPanelBackColor.BackColor = System.Drawing.Color.Transparent
        Me.selectPanelBackColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selectPanelBackColor.IconChar = FontAwesome.Sharp.IconChar.Palette
        Me.selectPanelBackColor.IconColor = System.Drawing.Color.White
        Me.selectPanelBackColor.IconSize = 20
        Me.selectPanelBackColor.Location = New System.Drawing.Point(3, 44)
        Me.selectPanelBackColor.Name = "selectPanelBackColor"
        Me.selectPanelBackColor.Size = New System.Drawing.Size(20, 20)
        Me.selectPanelBackColor.TabIndex = 2
        Me.selectPanelBackColor.TabStop = False
        '
        'MacTrackBar1
        '
        Me.MacTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.BorderColor = System.Drawing.Color.Transparent
        Me.MacTrackBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MacTrackBar1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MacTrackBar1.ForeColor = System.Drawing.Color.White
        Me.MacTrackBar1.IndentHeight = 6
        Me.MacTrackBar1.LargeChange = 10
        Me.MacTrackBar1.Location = New System.Drawing.Point(0, 0)
        Me.MacTrackBar1.Maximum = 100
        Me.MacTrackBar1.Minimum = 0
        Me.MacTrackBar1.Name = "MacTrackBar1"
        Me.MacTrackBar1.Size = New System.Drawing.Size(400, 38)
        Me.MacTrackBar1.TabIndex = 1
        Me.MacTrackBar1.TextTickStyle = System.Windows.Forms.TickStyle.None
        Me.MacTrackBar1.TickColor = System.Drawing.Color.White
        Me.MacTrackBar1.TickFrequency = 10
        Me.MacTrackBar1.TickHeight = 4
        Me.MacTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.MacTrackBar1.TrackerColor = System.Drawing.Color.White
        Me.MacTrackBar1.TrackerSize = New System.Drawing.Size(16, 16)
        Me.MacTrackBar1.TrackLineColor = System.Drawing.Color.White
        Me.MacTrackBar1.TrackLineHeight = 3
        Me.MacTrackBar1.Value = 0
        '
        'panelForm
        '
        Me.panelForm.Controls.Add(Me.MacTrackBar1)
        Me.panelForm.Controls.Add(Me.selectBackGroundImage)
        Me.panelForm.Controls.Add(Me.selectPanelBackColor)
        Me.panelForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelForm.Location = New System.Drawing.Point(0, 0)
        Me.panelForm.Name = "panelForm"
        Me.panelForm.PANEL_CLOSED_STATE_DIM = 40
        Me.panelForm.PANEL_OPEN_STATE_DIM = 400
        Me.panelForm.Size = New System.Drawing.Size(400, 113)
        Me.panelForm.TabIndex = 356
        '
        'lateralSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(400, 113)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelForm)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "lateralSettingsForm"
        Me.Opacity = 0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Silver
        CType(Me.selectBackGroundImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.selectPanelBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelForm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents MacTrackBar1 As XComponent.SliderBar.MACTrackBar
    Friend WithEvents selectPanelBackColor As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ColorPickerDialog As ColorDialog
    Friend WithEvents selectBackGroundImage As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents ToolTips As ToolTip
    Friend WithEvents panelForm As PanelDoubleBuffer
End Class
