Imports System.Security.AccessControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizardMainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizardMainForm))
        Me.FadeInTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AlphaGradientPanel1 = New ConstructionSiteLogistics.Libraries.Core.CustomPanels.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New ConstructionSiteLogistics.Libraries.Core.CustomPanels.ColorWithAlpha()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.backPanelBtn = New ConstructionSiteLogistics.Libraries.Core.CustomPanels.AlphaGradientPanel()
        Me.ColorWithAlpha2 = New ConstructionSiteLogistics.Libraries.Core.CustomPanels.ColorWithAlpha()
        Me.forwardPanelBtn = New ConstructionSiteLogistics.Libraries.Core.CustomPanels.AlphaGradientPanel()
        Me.forwardPicBtn = New System.Windows.Forms.PictureBox()
        Me.backPicBtn = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.title = New System.Windows.Forms.Label()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.AlphaGradientPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.backPanelBtn.SuspendLayout()
        Me.forwardPanelBtn.SuspendLayout()
        CType(Me.forwardPicBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backPicBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'FadeInTimer
        '
        Me.FadeInTimer.Interval = 50
        '
        'AlphaGradientPanel1
        '
        Me.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.AlphaGradientPanel1.Border = True
        Me.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel1.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel1.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel1.Controls.Add(Me.Panel2)
        Me.AlphaGradientPanel1.Controls.Add(Me.Panel1)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelMain)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelBottom)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelTop)
        Me.AlphaGradientPanel1.CornerRadius = 50
        Me.AlphaGradientPanel1.Corners = CType((((ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.TopLeft Or ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.TopRight) _
            Or ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.BottomLeft) _
            Or ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.BottomRight), ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner)
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
        Me.AlphaGradientPanel1.ImagePosition = ConstructionSiteLogistics.Libraries.Core.CustomPanels.ImagePosition.BottomRight
        Me.AlphaGradientPanel1.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.AlphaGradientPanel1.Name = "AlphaGradientPanel1"
        Me.AlphaGradientPanel1.Rounded = True
        Me.AlphaGradientPanel1.Size = New System.Drawing.Size(1600, 900)
        Me.AlphaGradientPanel1.TabIndex = 3
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.backPanelBtn)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 742)
        Me.Panel2.TabIndex = 13
        '
        'backPanelBtn
        '
        Me.backPanelBtn.BackColor = System.Drawing.Color.Transparent
        Me.backPanelBtn.Border = False
        Me.backPanelBtn.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.backPanelBtn.Colors.Add(Me.ColorWithAlpha2)
        Me.backPanelBtn.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.backPanelBtn.Controls.Add(Me.backPicBtn)
        Me.backPanelBtn.CornerRadius = 40
        Me.backPanelBtn.Corners = CType((ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.TopRight Or ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.BottomRight), ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner)
        Me.backPanelBtn.Gradient = False
        Me.backPanelBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.backPanelBtn.GradientOffset = 1.0!
        Me.backPanelBtn.GradientSize = New System.Drawing.Size(0, 0)
        Me.backPanelBtn.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.backPanelBtn.Grayscale = False
        Me.backPanelBtn.Image = Nothing
        Me.backPanelBtn.ImageAlpha = 75
        Me.backPanelBtn.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.backPanelBtn.ImagePosition = ConstructionSiteLogistics.Libraries.Core.CustomPanels.ImagePosition.BottomRight
        Me.backPanelBtn.ImageSize = New System.Drawing.Size(48, 48)
        Me.backPanelBtn.Location = New System.Drawing.Point(-27, 268)
        Me.backPanelBtn.Name = "backPanelBtn"
        Me.backPanelBtn.Rounded = True
        Me.backPanelBtn.Size = New System.Drawing.Size(80, 80)
        Me.backPanelBtn.TabIndex = 1
        '
        'ColorWithAlpha2
        '
        Me.ColorWithAlpha2.Alpha = 255
        Me.ColorWithAlpha2.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha2.Parent = Me.backPanelBtn
        '
        'forwardPanelBtn
        '
        Me.forwardPanelBtn.BackColor = System.Drawing.Color.Transparent
        Me.forwardPanelBtn.Border = False
        Me.forwardPanelBtn.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.forwardPanelBtn.Colors.Add(Me.ColorWithAlpha2)
        Me.forwardPanelBtn.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.forwardPanelBtn.Controls.Add(Me.forwardPicBtn)
        Me.forwardPanelBtn.CornerRadius = 40
        Me.forwardPanelBtn.Corners = CType((ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.TopLeft Or ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner.BottomLeft), ConstructionSiteLogistics.Libraries.Core.CustomPanels.Corner)
        Me.forwardPanelBtn.Gradient = False
        Me.forwardPanelBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.forwardPanelBtn.GradientOffset = 1.0!
        Me.forwardPanelBtn.GradientSize = New System.Drawing.Size(0, 0)
        Me.forwardPanelBtn.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.forwardPanelBtn.Grayscale = False
        Me.forwardPanelBtn.Image = Nothing
        Me.forwardPanelBtn.ImageAlpha = 75
        Me.forwardPanelBtn.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.forwardPanelBtn.ImagePosition = ConstructionSiteLogistics.Libraries.Core.CustomPanels.ImagePosition.BottomRight
        Me.forwardPanelBtn.ImageSize = New System.Drawing.Size(48, 48)
        Me.forwardPanelBtn.Location = New System.Drawing.Point(9, 268)
        Me.forwardPanelBtn.Name = "forwardPanelBtn"
        Me.forwardPanelBtn.Rounded = True
        Me.forwardPanelBtn.Size = New System.Drawing.Size(80, 80)
        Me.forwardPanelBtn.TabIndex = 0
        '
        'forwardPicBtn
        '
        Me.forwardPicBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.forwardPicBtn.Image = CType(resources.GetObject("forwardPicBtn.Image"), System.Drawing.Image)
        Me.forwardPicBtn.Location = New System.Drawing.Point(22, 18)
        Me.forwardPicBtn.Name = "forwardPicBtn"
        Me.forwardPicBtn.Size = New System.Drawing.Size(21, 44)
        Me.forwardPicBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.forwardPicBtn.TabIndex = 1
        Me.forwardPicBtn.TabStop = False
        '
        'backPicBtn
        '
        Me.backPicBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.backPicBtn.Image = CType(resources.GetObject("backPicBtn.Image"), System.Drawing.Image)
        Me.backPicBtn.Location = New System.Drawing.Point(38, 18)
        Me.backPicBtn.Name = "backPicBtn"
        Me.backPicBtn.Size = New System.Drawing.Size(21, 44)
        Me.backPicBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.backPicBtn.TabIndex = 0
        Me.backPicBtn.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.forwardPanelBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1541, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(59, 742)
        Me.Panel1.TabIndex = 12
        '
        'PanelMain
        '
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(0, 109)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(1600, 742)
        Me.PanelMain.TabIndex = 11
        '
        'PanelBottom
        '
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 851)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1600, 49)
        Me.PanelBottom.TabIndex = 10
        '
        'PanelTop
        '
        Me.PanelTop.Controls.Add(Me.title)
        Me.PanelTop.Controls.Add(Me.subtitle)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1600, 109)
        Me.PanelTop.TabIndex = 9
        '
        'title
        '
        Me.title.Dock = System.Windows.Forms.DockStyle.Top
        Me.title.Font = New System.Drawing.Font("Trajan Pro", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.White
        Me.title.Location = New System.Drawing.Point(0, 0)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(1600, 73)
        Me.title.TabIndex = 0
        Me.title.Text = "Setup is Complete"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'subtitle
        '
        Me.subtitle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.subtitle.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.ForeColor = System.Drawing.Color.White
        Me.subtitle.Location = New System.Drawing.Point(0, 57)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1600, 52)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "To start the Desktop app click the button bellow"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizardMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1600, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.AlphaGradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "setupWizardMainForm"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.AlphaGradientPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.backPanelBtn.ResumeLayout(False)
        Me.forwardPanelBtn.ResumeLayout(False)
        CType(Me.forwardPicBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backPicBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AlphaGradientPanel1 As CustomPanels.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As CustomPanels.ColorWithAlpha
    Friend WithEvents PanelMain As Windows.Forms.Panel
    Friend WithEvents PanelBottom As Windows.Forms.Panel
    Friend WithEvents PanelTop As Windows.Forms.Panel
    Public WithEvents title As Windows.Forms.Label
    Public WithEvents subtitle As Windows.Forms.Label
    Friend WithEvents FadeInTimer As Windows.Forms.Timer
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents backPanelBtn As CustomPanels.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha2 As CustomPanels.ColorWithAlpha
    Friend WithEvents backPicBtn As Windows.Forms.PictureBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents forwardPanelBtn As CustomPanels.AlphaGradientPanel
    Friend WithEvents forwardPicBtn As Windows.Forms.PictureBox
End Class
