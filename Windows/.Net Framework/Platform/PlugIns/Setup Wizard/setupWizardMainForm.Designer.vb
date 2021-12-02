

Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Gui.Forms.Core

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizardMainForm
    Inherits FormCustomized


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizardMainForm))
        Me.AlphaGradientPanel1 = New BlueActivity.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.forwardPicBtn = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.backPicBtn = New System.Windows.Forms.PictureBox()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.title = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.subtitle = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.ColorWithAlpha2 = New BlueActivity.ColorWithAlpha()
        Me.FadeInTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AlphaGradientPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.forwardPicBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.backPicBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'AlphaGradientPanel1
        '
        Me.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.AlphaGradientPanel1.Border = True
        Me.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel1.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel1.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel1.Controls.Add(Me.Panel1)
        Me.AlphaGradientPanel1.Controls.Add(Me.Panel2)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelMain)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelBottom)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelTop)
        Me.AlphaGradientPanel1.CornerRadius = 25
        Me.AlphaGradientPanel1.Corners = CType((((BlueActivity.Corner.TopLeft Or BlueActivity.Corner.TopRight) _
            Or BlueActivity.Corner.BottomLeft) _
            Or BlueActivity.Corner.BottomRight), BlueActivity.Corner)
        Me.AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AlphaGradientPanel1.Gradient = False
        Me.AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.AlphaGradientPanel1.GradientOffset = 1.0!
        Me.AlphaGradientPanel1.GradientSize = New System.Drawing.Size(0, 0)
        Me.AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.AlphaGradientPanel1.Grayscale = False
        Me.AlphaGradientPanel1.Image = Nothing
        Me.AlphaGradientPanel1.ImageAlpha = 75
        Me.AlphaGradientPanel1.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight
        Me.AlphaGradientPanel1.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel1.Location = New System.Drawing.Point(5, 5)
        Me.AlphaGradientPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.AlphaGradientPanel1.Name = "AlphaGradientPanel1"
        Me.AlphaGradientPanel1.Rounded = True
        Me.AlphaGradientPanel1.Size = New System.Drawing.Size(935, 500)
        Me.AlphaGradientPanel1.TabIndex = 3
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 255
        Me.ColorWithAlpha1.Color = System.Drawing.Color.WhiteSmoke
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.forwardPicBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(891, 71)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(44, 408)
        Me.Panel1.TabIndex = 12
        '
        'forwardPicBtn
        '
        Me.forwardPicBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.forwardPicBtn.Image = CType(resources.GetObject("forwardPicBtn.Image"), System.Drawing.Image)
        Me.forwardPicBtn.Location = New System.Drawing.Point(17, 210)
        Me.forwardPicBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.forwardPicBtn.Name = "forwardPicBtn"
        Me.forwardPicBtn.Size = New System.Drawing.Size(14, 29)
        Me.forwardPicBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.forwardPicBtn.TabIndex = 1
        Me.forwardPicBtn.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.backPicBtn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 71)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(39, 408)
        Me.Panel2.TabIndex = 13
        '
        'backPicBtn
        '
        Me.backPicBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.backPicBtn.Image = CType(resources.GetObject("backPicBtn.Image"), System.Drawing.Image)
        Me.backPicBtn.Location = New System.Drawing.Point(8, 210)
        Me.backPicBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.backPicBtn.Name = "backPicBtn"
        Me.backPicBtn.Size = New System.Drawing.Size(14, 29)
        Me.backPicBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.backPicBtn.TabIndex = 0
        Me.backPicBtn.TabStop = False
        '
        'PanelMain
        '
        Me.PanelMain.Location = New System.Drawing.Point(341, 165)
        Me.PanelMain.Margin = New System.Windows.Forms.Padding(1)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(200, 155)
        Me.PanelMain.TabIndex = 11
        '
        'PanelBottom
        '
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 479)
        Me.PanelBottom.Margin = New System.Windows.Forms.Padding(1)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(935, 21)
        Me.PanelBottom.TabIndex = 10
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.title)
        Me.PanelTop.Controls.Add(Me.subtitle)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(935, 71)
        Me.PanelTop.TabIndex = 9
        '
        'title
        '
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Dock = System.Windows.Forms.DockStyle.Top
        Me.title.Font = New System.Drawing.Font("Trajan Pro", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Black
        Me.title.Location = New System.Drawing.Point(0, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(935, 47)
        Me.title.TabIndex = 0
        Me.title.Text = "Setup is Complete"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'subtitle
        '
        Me.subtitle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.subtitle.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.ForeColor = System.Drawing.Color.Black
        Me.subtitle.Location = New System.Drawing.Point(0, 37)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(935, 34)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "To start the Desktop app click the button bellow"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ColorWithAlpha2
        '
        Me.ColorWithAlpha2.Alpha = 255
        Me.ColorWithAlpha2.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha2.Parent = Nothing
        '
        'FadeInTimer
        '
        Me.FadeInTimer.Interval = 50
        '
        'setupWizardMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(978, 544)
        Me.Controls.Add(Me.AlphaGradientPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "setupWizardMainForm"
        Me.Opacity = 0.999R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TargetOpacity = 1.0R
        Me.TransparencyKey = System.Drawing.Color.Maroon
        Me.AlphaGradientPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.forwardPicBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.backPicBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AlphaGradientPanel1 As BlueActivity.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents PanelBottom As Windows.Forms.Panel
    Friend WithEvents PanelTop As Windows.Forms.Panel
    Public WithEvents title As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Public WithEvents subtitle As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents FadeInTimer As Windows.Forms.Timer
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents ColorWithAlpha2 As BlueActivity.ColorWithAlpha
    Friend WithEvents backPicBtn As Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents forwardPicBtn As Windows.Forms.PictureBox
    Friend WithEvents PanelMain As Panel
End Class
