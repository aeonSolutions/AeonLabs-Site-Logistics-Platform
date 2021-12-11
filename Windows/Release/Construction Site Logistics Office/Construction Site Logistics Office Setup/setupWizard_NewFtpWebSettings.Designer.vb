<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupWizard_NewFtpWebSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_NewFtpWebSettings))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.password_lbl = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.username_lbl = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.TextBox()
        Me.connectionType_lbl = New System.Windows.Forms.Label()
        Me.connectionType = New System.Windows.Forms.ComboBox()
        Me.server_ftp_port_lbl = New System.Windows.Forms.Label()
        Me.server_ftp_port = New System.Windows.Forms.TextBox()
        Me.domain_ftp_ex = New System.Windows.Forms.Label()
        Me.server_ftp_addr_lbl = New System.Windows.Forms.Label()
        Me.server_ftp_addr = New System.Windows.Forms.TextBox()
        Me.domain_web_ex = New System.Windows.Forms.Label()
        Me.server_web_addr_lbl = New System.Windows.Forms.Label()
        Me.server_web_addr = New System.Windows.Forms.TextBox()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnBackTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.password_lbl)
        Me.Panel1.Controls.Add(Me.password)
        Me.Panel1.Controls.Add(Me.username_lbl)
        Me.Panel1.Controls.Add(Me.username)
        Me.Panel1.Controls.Add(Me.connectionType_lbl)
        Me.Panel1.Controls.Add(Me.connectionType)
        Me.Panel1.Controls.Add(Me.server_ftp_port_lbl)
        Me.Panel1.Controls.Add(Me.server_ftp_port)
        Me.Panel1.Controls.Add(Me.domain_ftp_ex)
        Me.Panel1.Controls.Add(Me.server_ftp_addr_lbl)
        Me.Panel1.Controls.Add(Me.server_ftp_addr)
        Me.Panel1.Controls.Add(Me.domain_web_ex)
        Me.Panel1.Controls.Add(Me.server_web_addr_lbl)
        Me.Panel1.Controls.Add(Me.server_web_addr)
        Me.Panel1.Controls.Add(Me.btnContinueTxt)
        Me.Panel1.Controls.Add(Me.btnBackTxt)
        Me.Panel1.Controls.Add(Me.btnContinue)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 788)
        Me.Panel1.TabIndex = 1
        '
        'password_lbl
        '
        Me.password_lbl.AutoSize = True
        Me.password_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_lbl.ForeColor = System.Drawing.Color.Gray
        Me.password_lbl.Location = New System.Drawing.Point(460, 510)
        Me.password_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.password_lbl.Name = "password_lbl"
        Me.password_lbl.Size = New System.Drawing.Size(72, 17)
        Me.password_lbl.TabIndex = 33
        Me.password_lbl.Text = "password"
        '
        'password
        '
        Me.password.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(463, 530)
        Me.password.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(187, 25)
        Me.password.TabIndex = 32
        '
        'username_lbl
        '
        Me.username_lbl.AutoSize = True
        Me.username_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_lbl.ForeColor = System.Drawing.Color.Gray
        Me.username_lbl.Location = New System.Drawing.Point(459, 459)
        Me.username_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.username_lbl.Name = "username_lbl"
        Me.username_lbl.Size = New System.Drawing.Size(74, 17)
        Me.username_lbl.TabIndex = 31
        Me.username_lbl.Text = "username"
        '
        'username
        '
        Me.username.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.Location = New System.Drawing.Point(461, 480)
        Me.username.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(384, 25)
        Me.username.TabIndex = 30
        '
        'connectionType_lbl
        '
        Me.connectionType_lbl.AutoSize = True
        Me.connectionType_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connectionType_lbl.ForeColor = System.Drawing.Color.Gray
        Me.connectionType_lbl.Location = New System.Drawing.Point(460, 402)
        Me.connectionType_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.connectionType_lbl.Name = "connectionType_lbl"
        Me.connectionType_lbl.Size = New System.Drawing.Size(110, 17)
        Me.connectionType_lbl.TabIndex = 29
        Me.connectionType_lbl.Text = "connection type"
        '
        'connectionType
        '
        Me.connectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.connectionType.ForeColor = System.Drawing.Color.Gray
        Me.connectionType.FormattingEnabled = True
        Me.connectionType.Location = New System.Drawing.Point(463, 422)
        Me.connectionType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.connectionType.Name = "connectionType"
        Me.connectionType.Size = New System.Drawing.Size(383, 24)
        Me.connectionType.TabIndex = 28
        '
        'server_ftp_port_lbl
        '
        Me.server_ftp_port_lbl.AutoSize = True
        Me.server_ftp_port_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_port_lbl.ForeColor = System.Drawing.Color.Gray
        Me.server_ftp_port_lbl.Location = New System.Drawing.Point(872, 326)
        Me.server_ftp_port_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_ftp_port_lbl.Name = "server_ftp_port_lbl"
        Me.server_ftp_port_lbl.Size = New System.Drawing.Size(35, 17)
        Me.server_ftp_port_lbl.TabIndex = 27
        Me.server_ftp_port_lbl.Text = "Port"
        '
        'server_ftp_port
        '
        Me.server_ftp_port.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_port.Location = New System.Drawing.Point(875, 347)
        Me.server_ftp_port.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.server_ftp_port.Name = "server_ftp_port"
        Me.server_ftp_port.Size = New System.Drawing.Size(69, 25)
        Me.server_ftp_port.TabIndex = 26
        '
        'domain_ftp_ex
        '
        Me.domain_ftp_ex.AutoSize = True
        Me.domain_ftp_ex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_ftp_ex.ForeColor = System.Drawing.Color.DimGray
        Me.domain_ftp_ex.Location = New System.Drawing.Point(460, 377)
        Me.domain_ftp_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_ftp_ex.Name = "domain_ftp_ex"
        Me.domain_ftp_ex.Size = New System.Drawing.Size(186, 16)
        Me.domain_ftp_ex.TabIndex = 25
        Me.domain_ftp_ex.Text = "ex.: ftp://ftp.yourdomain.com"
        '
        'server_ftp_addr_lbl
        '
        Me.server_ftp_addr_lbl.AutoSize = True
        Me.server_ftp_addr_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_addr_lbl.ForeColor = System.Drawing.Color.Gray
        Me.server_ftp_addr_lbl.Location = New System.Drawing.Point(460, 326)
        Me.server_ftp_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_ftp_addr_lbl.Name = "server_ftp_addr_lbl"
        Me.server_ftp_addr_lbl.Size = New System.Drawing.Size(128, 17)
        Me.server_ftp_addr_lbl.TabIndex = 24
        Me.server_ftp_addr_lbl.Text = "Server ftp address"
        '
        'server_ftp_addr
        '
        Me.server_ftp_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_addr.Location = New System.Drawing.Point(463, 347)
        Me.server_ftp_addr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.server_ftp_addr.Name = "server_ftp_addr"
        Me.server_ftp_addr.Size = New System.Drawing.Size(384, 25)
        Me.server_ftp_addr.TabIndex = 23
        '
        'domain_web_ex
        '
        Me.domain_web_ex.AutoSize = True
        Me.domain_web_ex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_web_ex.ForeColor = System.Drawing.Color.DimGray
        Me.domain_web_ex.Location = New System.Drawing.Point(460, 255)
        Me.domain_web_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_web_ex.Name = "domain_web_ex"
        Me.domain_web_ex.Size = New System.Drawing.Size(204, 16)
        Me.domain_web_ex.TabIndex = 22
        Me.domain_web_ex.Text = "ex.: http://www.yourdomain.com"
        '
        'server_web_addr_lbl
        '
        Me.server_web_addr_lbl.AutoSize = True
        Me.server_web_addr_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr_lbl.ForeColor = System.Drawing.Color.Gray
        Me.server_web_addr_lbl.Location = New System.Drawing.Point(460, 206)
        Me.server_web_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_web_addr_lbl.Name = "server_web_addr_lbl"
        Me.server_web_addr_lbl.Size = New System.Drawing.Size(139, 17)
        Me.server_web_addr_lbl.TabIndex = 21
        Me.server_web_addr_lbl.Text = "Server web address"
        '
        'server_web_addr
        '
        Me.server_web_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr.Location = New System.Drawing.Point(463, 226)
        Me.server_web_addr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.server_web_addr.Name = "server_web_addr"
        Me.server_web_addr.Size = New System.Drawing.Size(384, 25)
        Me.server_web_addr.TabIndex = 3
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(527, 732)
        Me.btnContinueTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnContinueTxt.Name = "btnContinueTxt"
        Me.btnContinueTxt.Size = New System.Drawing.Size(72, 17)
        Me.btnContinueTxt.TabIndex = 8
        Me.btnContinueTxt.Text = "Continue"
        Me.btnContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBackTxt
        '
        Me.btnBackTxt.AutoSize = True
        Me.btnBackTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnBackTxt.Location = New System.Drawing.Point(365, 732)
        Me.btnBackTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBackTxt.Name = "btnBackTxt"
        Me.btnBackTxt.Size = New System.Drawing.Size(43, 17)
        Me.btnBackTxt.TabIndex = 7
        Me.btnBackTxt.Text = "Back"
        Me.btnBackTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContinue
        '
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.Location = New System.Drawing.Point(540, 686)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(47, 43)
        Me.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(365, 686)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(47, 43)
        Me.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBack.TabIndex = 5
        Me.btnBack.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(33, 206)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(397, 241)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'subtitle
        '
        Me.subtitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subtitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.ForeColor = System.Drawing.Color.Gray
        Me.subtitle.Location = New System.Drawing.Point(15, 95)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1001, 36)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "Fill out the following information to setup the server"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(8, 7)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(1019, 68)
        Me.title.TabIndex = 0
        Me.title.Text = "Server Configuration"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_NewFtpWebSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "setupWizard_NewFtpWebSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnContinueTxt As Label
    Friend WithEvents btnBackTxt As Label
    Friend WithEvents btnContinue As PictureBox
    Friend WithEvents btnBack As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents subtitle As Label
    Friend WithEvents title As Label
    Friend WithEvents server_web_addr_lbl As Label
    Friend WithEvents server_web_addr As TextBox
    Friend WithEvents domain_web_ex As Label
    Friend WithEvents server_ftp_port_lbl As Label
    Friend WithEvents server_ftp_port As TextBox
    Friend WithEvents domain_ftp_ex As Label
    Friend WithEvents server_ftp_addr_lbl As Label
    Friend WithEvents server_ftp_addr As TextBox
    Friend WithEvents password_lbl As Label
    Friend WithEvents username_lbl As Label
    Friend WithEvents username As TextBox
    Friend WithEvents connectionType_lbl As Label
    Friend WithEvents connectionType As ComboBox
    Friend WithEvents password As TextBox
End Class
