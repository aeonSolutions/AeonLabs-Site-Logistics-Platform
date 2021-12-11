Imports System.Drawing
Imports System.Windows.Forms
Imports AeonLabs.Layouts
Imports BlueActivity.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LayoutStartUpForm
    Inherits FormCustomized


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LayoutStartUpForm))
        Me.VersionLabel = New LabelDoubleBuffer()
        Me.cancelCard_lbl = New System.Windows.Forms.LinkLabel()
        Me.statusMessage = New LabelDoubleBuffer()
        Me.titleLabel = New LabelDoubleBuffer()
        Me.locationLabel = New LabelDoubleBuffer()
        Me.quoteOfTheDaySentenceLabel = New LabelDoubleBuffer()
        Me.versionTitleLabel = New LabelDoubleBuffer()
        Me.TitleFlavourLabel = New LabelDoubleBuffer()
        Me.websiteLink = New System.Windows.Forms.LinkLabel()
        Me.progressbar = New CircularProgressBar.CircularProgress.CircularProgressBar()
        Me.panelLogin = New BlueActivity.Controls.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New BlueActivity.Controls.ColorWithAlpha()
        Me.loginBtn = New System.Windows.Forms.PictureBox()
        Me.cardId_lbl = New LabelDoubleBuffer()
        Me.cardId = New System.Windows.Forms.TextBox()
        Me.access_code = New LabelDoubleBuffer()
        Me.codetxt = New System.Windows.Forms.MaskedTextBox()
        Me.show_password = New System.Windows.Forms.PictureBox()
        Me.PanelLocationText = New System.Windows.Forms.Panel()
        Me.locationTextTimer = New System.Windows.Forms.Timer(Me.components)
        Me.animatedBackGround = New PictureBoxDoubleBuffer()
        Me.panelLogin.SuspendLayout()
        CType(Me.loginBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLocationText.SuspendLayout()
        CType(Me.animatedBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        Me.VersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VersionLabel.BackColor = System.Drawing.Color.Maroon
        Me.VersionLabel.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.ForeColor = System.Drawing.Color.White
        Me.VersionLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.VersionLabel.Location = New System.Drawing.Point(1076, 31)
        Me.VersionLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(153, 21)
        Me.VersionLabel.TabIndex = 1
        Me.VersionLabel.Text = "1.0.0"
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cancelCard_lbl
        '
        Me.cancelCard_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelCard_lbl.AutoSize = True
        Me.cancelCard_lbl.BackColor = System.Drawing.Color.Maroon
        Me.cancelCard_lbl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelCard_lbl.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelCard_lbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.cancelCard_lbl.LinkColor = System.Drawing.Color.White
        Me.cancelCard_lbl.Location = New System.Drawing.Point(1263, 658)
        Me.cancelCard_lbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cancelCard_lbl.Name = "cancelCard_lbl"
        Me.cancelCard_lbl.Size = New System.Drawing.Size(43, 18)
        Me.cancelCard_lbl.TabIndex = 342
        Me.cancelCard_lbl.TabStop = True
        Me.cancelCard_lbl.Text = "EXIT"
        '
        'statusMessage
        '
        Me.statusMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.statusMessage.BackColor = System.Drawing.Color.Maroon
        Me.statusMessage.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusMessage.ForeColor = System.Drawing.Color.White
        Me.statusMessage.Location = New System.Drawing.Point(944, 248)
        Me.statusMessage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.statusMessage.Name = "statusMessage"
        Me.statusMessage.Size = New System.Drawing.Size(288, 44)
        Me.statusMessage.TabIndex = 3
        Me.statusMessage.Text = "Loading files..."
        Me.statusMessage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'titleLabel
        '
        Me.titleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleLabel.BackColor = System.Drawing.Color.Maroon
        Me.titleLabel.Font = New System.Drawing.Font("Trajan Pro", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.ForeColor = System.Drawing.Color.White
        Me.titleLabel.Location = New System.Drawing.Point(938, 369)
        Me.titleLabel.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(296, 83)
        Me.titleLabel.TabIndex = 341
        Me.titleLabel.Text = "Construction Site Logistics"
        Me.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'locationLabel
        '
        Me.locationLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.locationLabel.AutoSize = True
        Me.locationLabel.BackColor = System.Drawing.Color.Maroon
        Me.locationLabel.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationLabel.ForeColor = System.Drawing.Color.White
        Me.locationLabel.Location = New System.Drawing.Point(207, 0)
        Me.locationLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.locationLabel.Name = "locationLabel"
        Me.locationLabel.Size = New System.Drawing.Size(154, 18)
        Me.locationLabel.TabIndex = 342
        Me.locationLabel.Text = "Brussels, Belgium"
        Me.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'quoteOfTheDaySentenceLabel
        '
        Me.quoteOfTheDaySentenceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quoteOfTheDaySentenceLabel.BackColor = System.Drawing.Color.Maroon
        Me.quoteOfTheDaySentenceLabel.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quoteOfTheDaySentenceLabel.ForeColor = System.Drawing.Color.White
        Me.quoteOfTheDaySentenceLabel.Location = New System.Drawing.Point(889, 522)
        Me.quoteOfTheDaySentenceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.quoteOfTheDaySentenceLabel.Name = "quoteOfTheDaySentenceLabel"
        Me.quoteOfTheDaySentenceLabel.Size = New System.Drawing.Size(343, 81)
        Me.quoteOfTheDaySentenceLabel.TabIndex = 344
        Me.quoteOfTheDaySentenceLabel.Text = "To be successful you've got to be willing to fail."
        Me.quoteOfTheDaySentenceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'versionTitleLabel
        '
        Me.versionTitleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.versionTitleLabel.BackColor = System.Drawing.Color.Maroon
        Me.versionTitleLabel.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versionTitleLabel.ForeColor = System.Drawing.Color.White
        Me.versionTitleLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.versionTitleLabel.Location = New System.Drawing.Point(1076, 9)
        Me.versionTitleLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.versionTitleLabel.Name = "versionTitleLabel"
        Me.versionTitleLabel.Size = New System.Drawing.Size(153, 22)
        Me.versionTitleLabel.TabIndex = 345
        Me.versionTitleLabel.Text = "VERSION"
        Me.versionTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TitleFlavourLabel
        '
        Me.TitleFlavourLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleFlavourLabel.BackColor = System.Drawing.Color.Maroon
        Me.TitleFlavourLabel.Font = New System.Drawing.Font("Trajan Pro", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleFlavourLabel.ForeColor = System.Drawing.Color.White
        Me.TitleFlavourLabel.Location = New System.Drawing.Point(978, 454)
        Me.TitleFlavourLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TitleFlavourLabel.Name = "TitleFlavourLabel"
        Me.TitleFlavourLabel.Size = New System.Drawing.Size(256, 23)
        Me.TitleFlavourLabel.TabIndex = 346
        Me.TitleFlavourLabel.Text = "OFFICE"
        Me.TitleFlavourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'websiteLink
        '
        Me.websiteLink.AutoSize = True
        Me.websiteLink.BackColor = System.Drawing.Color.Maroon
        Me.websiteLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.websiteLink.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.websiteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.websiteLink.LinkColor = System.Drawing.Color.White
        Me.websiteLink.Location = New System.Drawing.Point(1015, 477)
        Me.websiteLink.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.websiteLink.Name = "websiteLink"
        Me.websiteLink.Size = New System.Drawing.Size(219, 14)
        Me.websiteLink.TabIndex = 350
        Me.websiteLink.TabStop = True
        Me.websiteLink.Text = "www.SiteLogistics.Construction"
        '
        'progressbar
        '
        Me.progressbar.BackColor = System.Drawing.Color.Black
        Me.progressbar.Bar1.ActiveColor = System.Drawing.Color.White
        Me.progressbar.Bar1.BorderColor = System.Drawing.Color.DarkRed
        Me.progressbar.Bar1.Enabled = True
        Me.progressbar.Bar1.FinishColor = System.Drawing.Color.Honeydew
        Me.progressbar.Bar1.InactiveColor = System.Drawing.Color.DarkGray
        Me.progressbar.Bar2.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar2.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar2.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar2.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar3.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar3.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar3.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar3.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar4.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar4.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar4.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar4.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar5.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar5.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar5.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar5.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Font = New System.Drawing.Font("Trajan Pro", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressbar.ForeColor = System.Drawing.Color.White
        Me.progressbar.Image = Nothing
        Me.progressbar.Location = New System.Drawing.Point(1123, 144)
        Me.progressbar.MinimumSize = New System.Drawing.Size(20, 20)
        Me.progressbar.Name = "progressbar"
        Me.progressbar.Size = New System.Drawing.Size(100, 100)
        Me.progressbar.TabIndex = 351
        Me.progressbar.TextShadowColor = System.Drawing.Color.White
        '
        'panelLogin
        '
        Me.panelLogin.BackColor = System.Drawing.Color.Transparent
        Me.panelLogin.Border = True
        Me.panelLogin.BorderColor = System.Drawing.Color.White
        Me.panelLogin.Colors.Add(Me.ColorWithAlpha1)
        Me.panelLogin.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.panelLogin.Controls.Add(Me.loginBtn)
        Me.panelLogin.Controls.Add(Me.cardId_lbl)
        Me.panelLogin.Controls.Add(Me.cardId)
        Me.panelLogin.Controls.Add(Me.access_code)
        Me.panelLogin.Controls.Add(Me.codetxt)
        Me.panelLogin.Controls.Add(Me.show_password)
        Me.panelLogin.CornerRadius = 45
        Me.panelLogin.Corners = CType((BlueActivity.Controls.Corner.TopLeft Or BlueActivity.Controls.Corner.BottomRight), BlueActivity.Controls.Corner)
        Me.panelLogin.Gradient = False
        Me.panelLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.panelLogin.GradientOffset = 1.0!
        Me.panelLogin.GradientSize = New System.Drawing.Size(0, 0)
        Me.panelLogin.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.panelLogin.Grayscale = False
        Me.panelLogin.Image = Nothing
        Me.panelLogin.ImageAlpha = 100
        Me.panelLogin.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.panelLogin.ImagePosition = BlueActivity.Controls.ImagePosition.Center
        Me.panelLogin.ImageSize = New System.Drawing.Size(128, 128)
        Me.panelLogin.Location = New System.Drawing.Point(485, 292)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelLogin.Rounded = True
        Me.panelLogin.Size = New System.Drawing.Size(231, 133)
        Me.panelLogin.TabIndex = 348
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Me.panelLogin
        '
        'loginBtn
        '
        Me.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.loginBtn.Image = CType(resources.GetObject("loginBtn.Image"), System.Drawing.Image)
        Me.loginBtn.Location = New System.Drawing.Point(191, 58)
        Me.loginBtn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.loginBtn.Name = "loginBtn"
        Me.loginBtn.Size = New System.Drawing.Size(27, 26)
        Me.loginBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loginBtn.TabIndex = 346
        Me.loginBtn.TabStop = False
        '
        'cardId_lbl
        '
        Me.cardId_lbl.AutoSize = True
        Me.cardId_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cardId_lbl.ForeColor = System.Drawing.Color.White
        Me.cardId_lbl.Location = New System.Drawing.Point(37, 19)
        Me.cardId_lbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cardId_lbl.Name = "cardId_lbl"
        Me.cardId_lbl.Size = New System.Drawing.Size(23, 15)
        Me.cardId_lbl.TabIndex = 344
        Me.cardId_lbl.Text = "ID"
        '
        'cardId
        '
        Me.cardId.BackColor = System.Drawing.Color.Maroon
        Me.cardId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardId.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cardId.Location = New System.Drawing.Point(39, 37)
        Me.cardId.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cardId.Name = "cardId"
        Me.cardId.Size = New System.Drawing.Size(122, 27)
        Me.cardId.TabIndex = 1
        '
        'access_code
        '
        Me.access_code.AutoSize = True
        Me.access_code.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.access_code.ForeColor = System.Drawing.Color.White
        Me.access_code.Location = New System.Drawing.Point(37, 67)
        Me.access_code.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.access_code.Name = "access_code"
        Me.access_code.Size = New System.Drawing.Size(44, 15)
        Me.access_code.TabIndex = 1
        Me.access_code.Text = "Code"
        '
        'codetxt
        '
        Me.codetxt.BackColor = System.Drawing.Color.Maroon
        Me.codetxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.codetxt.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codetxt.Location = New System.Drawing.Point(37, 85)
        Me.codetxt.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.codetxt.Name = "codetxt"
        Me.codetxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.codetxt.Size = New System.Drawing.Size(94, 27)
        Me.codetxt.TabIndex = 2
        Me.codetxt.ValidatingType = GetType(Date)
        '
        'show_password
        '
        Me.show_password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.show_password.Image = CType(resources.GetObject("show_password.Image"), System.Drawing.Image)
        Me.show_password.Location = New System.Drawing.Point(135, 89)
        Me.show_password.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.show_password.Name = "show_password"
        Me.show_password.Size = New System.Drawing.Size(23, 16)
        Me.show_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.show_password.TabIndex = 339
        Me.show_password.TabStop = False
        '
        'PanelLocationText
        '
        Me.PanelLocationText.BackColor = System.Drawing.Color.Maroon
        Me.PanelLocationText.Controls.Add(Me.locationLabel)
        Me.PanelLocationText.Location = New System.Drawing.Point(871, 344)
        Me.PanelLocationText.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PanelLocationText.Name = "PanelLocationText"
        Me.PanelLocationText.Size = New System.Drawing.Size(363, 25)
        Me.PanelLocationText.TabIndex = 352
        '
        'locationTextTimer
        '
        Me.locationTextTimer.Interval = 50
        '
        'animatedBackGround
        '
        Me.animatedBackGround.Image = CType(resources.GetObject("animatedBackGround.Image"), System.Drawing.Image)
        Me.animatedBackGround.Location = New System.Drawing.Point(0, 0)
        Me.animatedBackGround.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.animatedBackGround.Name = "animatedBackGround"
        Me.animatedBackGround.Size = New System.Drawing.Size(1234, 701)
        Me.animatedBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.animatedBackGround.TabIndex = 4
        Me.animatedBackGround.TabStop = False
        '
        'LayoutStartUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1238, 701)
        Me.ControlBox = False
        Me.Controls.Add(Me.statusMessage)
        Me.Controls.Add(Me.PanelLocationText)
        Me.Controls.Add(Me.progressbar)
        Me.Controls.Add(Me.websiteLink)
        Me.Controls.Add(Me.panelLogin)
        Me.Controls.Add(Me.cancelCard_lbl)
        Me.Controls.Add(Me.TitleFlavourLabel)
        Me.Controls.Add(Me.versionTitleLabel)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.quoteOfTheDaySentenceLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.animatedBackGround)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LayoutStartUpForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.WhiteSmoke
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.loginBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLocationText.ResumeLayout(False)
        Me.PanelLocationText.PerformLayout()
        CType(Me.animatedBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VersionLabel As LabelDoubleBuffer
    Friend WithEvents cardId As TextBox
    Friend WithEvents cardId_lbl As LabelDoubleBuffer
    Friend WithEvents cancelCard_lbl As LinkLabel
    Friend WithEvents show_password As PictureBox
    Friend WithEvents codetxt As MaskedTextBox
    Friend WithEvents access_code As LabelDoubleBuffer
    Friend WithEvents statusMessage As LabelDoubleBuffer
    Friend WithEvents titleLabel As LabelDoubleBuffer
    Friend WithEvents locationLabel As LabelDoubleBuffer
    Friend WithEvents quoteOfTheDaySentenceLabel As LabelDoubleBuffer
    Friend WithEvents versionTitleLabel As LabelDoubleBuffer
    Friend WithEvents TitleFlavourLabel As LabelDoubleBuffer
    Friend WithEvents loginBtn As PictureBox
    Friend WithEvents panelLogin As AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As ColorWithAlpha
    Friend WithEvents websiteLink As LinkLabel
    Friend WithEvents progressbar As CircularProgressBar.CircularProgress.CircularProgressBar
    Friend WithEvents PanelLocationText As Panel
    Friend WithEvents locationTextTimer As Timer
    Friend WithEvents animatedBackGround As PictureBoxDoubleBuffer
End Class
