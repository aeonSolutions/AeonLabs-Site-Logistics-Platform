Imports System.Drawing
Imports System.Windows.Forms



<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.animatedBackGround = New System.Windows.Forms.PictureBox()
        Me.cancelCard_lbl = New System.Windows.Forms.LinkLabel()
        Me.statusMessage = New System.Windows.Forms.Label()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.locationLabel = New System.Windows.Forms.Label()
        Me.ProgressBar = New CircularProgressBar.CircularProgressBar()
        Me.quoteOfTheDaySentenceLabel = New System.Windows.Forms.Label()
        Me.versionTitleLabel = New System.Windows.Forms.Label()
        Me.TitleFlavourLabel = New System.Windows.Forms.Label()
        Me.weatherPic = New System.Windows.Forms.PictureBox()
        Me.panelLogin = New CustomPanels.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New CustomPanels.ColorWithAlpha()
        Me.loginBtn = New System.Windows.Forms.PictureBox()
        Me.cardId_lbl = New System.Windows.Forms.Label()
        Me.cardId = New System.Windows.Forms.TextBox()
        Me.access_code = New System.Windows.Forms.Label()
        Me.codetxt = New System.Windows.Forms.MaskedTextBox()
        Me.show_password = New System.Windows.Forms.PictureBox()
        Me.weatherText = New System.Windows.Forms.Label()
        Me.WaitForDataLoadingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.websiteLink = New System.Windows.Forms.LinkLabel()
        CType(Me.animatedBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.weatherPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLogin.SuspendLayout()
        CType(Me.loginBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        Me.VersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VersionLabel.BackColor = System.Drawing.Color.Maroon
        Me.VersionLabel.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.ForeColor = System.Drawing.Color.White
        Me.VersionLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.VersionLabel.Location = New System.Drawing.Point(1605, 51)
        Me.VersionLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(230, 32)
        Me.VersionLabel.TabIndex = 1
        Me.VersionLabel.Text = "1.0.0"
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'animatedBackGround
        '
        Me.animatedBackGround.BackColor = System.Drawing.Color.Transparent
        Me.animatedBackGround.Dock = System.Windows.Forms.DockStyle.Fill
        Me.animatedBackGround.Image = CType(resources.GetObject("animatedBackGround.Image"), System.Drawing.Image)
        Me.animatedBackGround.Location = New System.Drawing.Point(0, 0)
        Me.animatedBackGround.Name = "animatedBackGround"
        Me.animatedBackGround.Size = New System.Drawing.Size(1918, 1078)
        Me.animatedBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.animatedBackGround.TabIndex = 4
        Me.animatedBackGround.TabStop = False
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
        Me.cancelCard_lbl.Location = New System.Drawing.Point(1764, 1013)
        Me.cancelCard_lbl.Name = "cancelCard_lbl"
        Me.cancelCard_lbl.Size = New System.Drawing.Size(62, 25)
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
        Me.statusMessage.Location = New System.Drawing.Point(1339, 416)
        Me.statusMessage.Name = "statusMessage"
        Me.statusMessage.Size = New System.Drawing.Size(492, 56)
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
        Me.titleLabel.Location = New System.Drawing.Point(1276, 568)
        Me.titleLabel.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(559, 127)
        Me.titleLabel.TabIndex = 341
        Me.titleLabel.Text = "Construction Site Logistics"
        Me.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'locationLabel
        '
        Me.locationLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.locationLabel.BackColor = System.Drawing.Color.Maroon
        Me.locationLabel.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationLabel.ForeColor = System.Drawing.Color.White
        Me.locationLabel.Location = New System.Drawing.Point(1336, 520)
        Me.locationLabel.Name = "locationLabel"
        Me.locationLabel.Size = New System.Drawing.Size(498, 36)
        Me.locationLabel.TabIndex = 342
        Me.locationLabel.Text = "Brussels, Belgium"
        Me.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.ProgressBar.AnimationSpeed = 500
        Me.ProgressBar.BackColor = System.Drawing.Color.Transparent
        Me.ProgressBar.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBar.ForeColor = System.Drawing.Color.White
        Me.ProgressBar.InnerColor = System.Drawing.Color.Transparent
        Me.ProgressBar.InnerMargin = 0
        Me.ProgressBar.InnerWidth = 0
        Me.ProgressBar.Location = New System.Drawing.Point(1704, 266)
        Me.ProgressBar.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar.MarqueeAnimationSpeed = 2000
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.OuterColor = System.Drawing.Color.White
        Me.ProgressBar.OuterMargin = -5
        Me.ProgressBar.OuterWidth = 5
        Me.ProgressBar.ProgressColor = System.Drawing.Color.DarkGray
        Me.ProgressBar.ProgressWidth = 5
        Me.ProgressBar.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgressBar.Size = New System.Drawing.Size(130, 130)
        Me.ProgressBar.StartAngle = 270
        Me.ProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.ProgressBar.SubscriptMargin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar.SubscriptText = "   "
        Me.ProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.ProgressBar.SuperscriptMargin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar.SuperscriptText = "     "
        Me.ProgressBar.TabIndex = 343
        Me.ProgressBar.Text = "10 / 13"
        Me.ProgressBar.TextMargin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ProgressBar.Value = 68
        '
        'quoteOfTheDaySentenceLabel
        '
        Me.quoteOfTheDaySentenceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.quoteOfTheDaySentenceLabel.BackColor = System.Drawing.Color.Maroon
        Me.quoteOfTheDaySentenceLabel.Font = New System.Drawing.Font("Trajan Pro", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quoteOfTheDaySentenceLabel.ForeColor = System.Drawing.Color.White
        Me.quoteOfTheDaySentenceLabel.Location = New System.Drawing.Point(1203, 803)
        Me.quoteOfTheDaySentenceLabel.Name = "quoteOfTheDaySentenceLabel"
        Me.quoteOfTheDaySentenceLabel.Size = New System.Drawing.Size(628, 124)
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
        Me.versionTitleLabel.Location = New System.Drawing.Point(1605, 17)
        Me.versionTitleLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.versionTitleLabel.Name = "versionTitleLabel"
        Me.versionTitleLabel.Size = New System.Drawing.Size(230, 34)
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
        Me.TitleFlavourLabel.Location = New System.Drawing.Point(1337, 698)
        Me.TitleFlavourLabel.Name = "TitleFlavourLabel"
        Me.TitleFlavourLabel.Size = New System.Drawing.Size(498, 36)
        Me.TitleFlavourLabel.TabIndex = 346
        Me.TitleFlavourLabel.Text = "OFFICE"
        Me.TitleFlavourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'weatherPic
        '
        Me.weatherPic.BackColor = System.Drawing.Color.Maroon
        Me.weatherPic.Image = CType(resources.GetObject("weatherPic.Image"), System.Drawing.Image)
        Me.weatherPic.Location = New System.Drawing.Point(29, 982)
        Me.weatherPic.Name = "weatherPic"
        Me.weatherPic.Size = New System.Drawing.Size(70, 70)
        Me.weatherPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.weatherPic.TabIndex = 347
        Me.weatherPic.TabStop = False
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
        Me.panelLogin.CornerRadius = 25
        Me.panelLogin.Corners = CType((CustomPanels.Corner.TopLeft Or CustomPanels.Corner.BottomRight), CustomPanels.Corner)
        Me.panelLogin.Gradient = False
        Me.panelLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.panelLogin.GradientOffset = 1.0!
        Me.panelLogin.GradientSize = New System.Drawing.Size(0, 0)
        Me.panelLogin.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.panelLogin.Grayscale = False
        Me.panelLogin.Image = Nothing
        Me.panelLogin.ImageAlpha = 100
        Me.panelLogin.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.panelLogin.ImagePosition = CustomPanels.ImagePosition.Center
        Me.panelLogin.ImageSize = New System.Drawing.Size(128, 128)
        Me.panelLogin.Location = New System.Drawing.Point(727, 449)
        Me.panelLogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.panelLogin.Name = "panelLogin"
        Me.panelLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.panelLogin.Rounded = True
        Me.panelLogin.Size = New System.Drawing.Size(346, 204)
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
        Me.loginBtn.Location = New System.Drawing.Point(275, 84)
        Me.loginBtn.Name = "loginBtn"
        Me.loginBtn.Size = New System.Drawing.Size(40, 40)
        Me.loginBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loginBtn.TabIndex = 346
        Me.loginBtn.TabStop = False
        '
        'cardId_lbl
        '
        Me.cardId_lbl.AutoSize = True
        Me.cardId_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cardId_lbl.ForeColor = System.Drawing.Color.White
        Me.cardId_lbl.Location = New System.Drawing.Point(44, 28)
        Me.cardId_lbl.Name = "cardId_lbl"
        Me.cardId_lbl.Size = New System.Drawing.Size(35, 23)
        Me.cardId_lbl.TabIndex = 344
        Me.cardId_lbl.Text = "ID"
        '
        'cardId
        '
        Me.cardId.BackColor = System.Drawing.Color.Maroon
        Me.cardId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardId.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cardId.Location = New System.Drawing.Point(44, 56)
        Me.cardId.Name = "cardId"
        Me.cardId.Size = New System.Drawing.Size(182, 37)
        Me.cardId.TabIndex = 1
        '
        'access_code
        '
        Me.access_code.AutoSize = True
        Me.access_code.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.access_code.ForeColor = System.Drawing.Color.White
        Me.access_code.Location = New System.Drawing.Point(44, 117)
        Me.access_code.Name = "access_code"
        Me.access_code.Size = New System.Drawing.Size(63, 23)
        Me.access_code.TabIndex = 1
        Me.access_code.Text = "Code"
        '
        'codetxt
        '
        Me.codetxt.BackColor = System.Drawing.Color.Maroon
        Me.codetxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.codetxt.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codetxt.Location = New System.Drawing.Point(44, 145)
        Me.codetxt.Name = "codetxt"
        Me.codetxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.codetxt.Size = New System.Drawing.Size(140, 37)
        Me.codetxt.TabIndex = 2
        Me.codetxt.ValidatingType = GetType(Date)
        '
        'show_password
        '
        Me.show_password.Cursor = System.Windows.Forms.Cursors.Hand
        Me.show_password.Image = CType(resources.GetObject("show_password.Image"), System.Drawing.Image)
        Me.show_password.Location = New System.Drawing.Point(190, 151)
        Me.show_password.Name = "show_password"
        Me.show_password.Size = New System.Drawing.Size(35, 25)
        Me.show_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.show_password.TabIndex = 339
        Me.show_password.TabStop = False
        '
        'weatherText
        '
        Me.weatherText.AutoSize = True
        Me.weatherText.BackColor = System.Drawing.Color.Maroon
        Me.weatherText.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weatherText.ForeColor = System.Drawing.Color.White
        Me.weatherText.Location = New System.Drawing.Point(111, 991)
        Me.weatherText.Name = "weatherText"
        Me.weatherText.Size = New System.Drawing.Size(85, 52)
        Me.weatherText.TabIndex = 349
        Me.weatherText.Text = "24˚"
        Me.weatherText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WaitForDataLoadingTimer
        '
        '
        'websiteLink
        '
        Me.websiteLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.websiteLink.BackColor = System.Drawing.Color.Maroon
        Me.websiteLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.websiteLink.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.websiteLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.websiteLink.LinkColor = System.Drawing.Color.White
        Me.websiteLink.Location = New System.Drawing.Point(1341, 736)
        Me.websiteLink.Name = "websiteLink"
        Me.websiteLink.Size = New System.Drawing.Size(494, 30)
        Me.websiteLink.TabIndex = 350
        Me.websiteLink.TabStop = True
        Me.websiteLink.Text = "www.SiteLogistics.Construction"
        Me.websiteLink.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1918, 1078)
        Me.Controls.Add(Me.websiteLink)
        Me.Controls.Add(Me.weatherText)
        Me.Controls.Add(Me.panelLogin)
        Me.Controls.Add(Me.weatherPic)
        Me.Controls.Add(Me.cancelCard_lbl)
        Me.Controls.Add(Me.TitleFlavourLabel)
        Me.Controls.Add(Me.versionTitleLabel)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.statusMessage)
        Me.Controls.Add(Me.quoteOfTheDaySentenceLabel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.locationLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.animatedBackGround)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "SplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.Color.WhiteSmoke
        CType(Me.animatedBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.weatherPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLogin.ResumeLayout(False)
        Me.panelLogin.PerformLayout()
        CType(Me.loginBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VersionLabel As Label
    Friend WithEvents animatedBackGround As PictureBox
    Friend WithEvents cardId As TextBox
    Friend WithEvents cardId_lbl As Label
    Friend WithEvents cancelCard_lbl As LinkLabel
    Friend WithEvents show_password As PictureBox
    Friend WithEvents codetxt As MaskedTextBox
    Friend WithEvents access_code As Label
    Friend WithEvents statusMessage As Label
    Friend WithEvents titleLabel As Label
    Friend WithEvents locationLabel As Label
    Friend WithEvents ProgressBar As CircularProgressBar.CircularProgressBar
    Friend WithEvents quoteOfTheDaySentenceLabel As Label
    Friend WithEvents versionTitleLabel As Label
    Friend WithEvents TitleFlavourLabel As Label
    Friend WithEvents loginBtn As PictureBox
    Friend WithEvents weatherPic As PictureBox
    Friend WithEvents panelLogin As CustomPanels.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As CustomPanels.ColorWithAlpha
    Friend WithEvents weatherText As Label
    Friend WithEvents WaitForDataLoadingTimer As Timer
    Friend WithEvents websiteLink As LinkLabel
End Class
