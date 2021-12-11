Imports System.Drawing
Imports System.Windows.Forms
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_NewFtpWebSettings))
        Me.password_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.password = New System.Windows.Forms.TextBox()
        Me.username_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.username = New System.Windows.Forms.TextBox()
        Me.connectionType_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.connectionType = New System.Windows.Forms.ComboBox()
        Me.server_ftp_port_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_ftp_port = New System.Windows.Forms.TextBox()
        Me.domain_ftp_ex = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_ftp_addr_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_ftp_addr = New System.Windows.Forms.TextBox()
        Me.domain_web_ex = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_web_addr_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_web_addr = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'password_lbl
        '
        Me.password_lbl.AutoSize = True
        Me.password_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password_lbl.ForeColor = System.Drawing.Color.Black
        Me.password_lbl.Location = New System.Drawing.Point(712, 508)
        Me.password_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.password_lbl.Name = "password_lbl"
        Me.password_lbl.Size = New System.Drawing.Size(108, 23)
        Me.password_lbl.TabIndex = 33
        Me.password_lbl.Text = "password"
        '
        'password
        '
        Me.password.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(715, 532)
        Me.password.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(210, 28)
        Me.password.TabIndex = 32
        '
        'username_lbl
        '
        Me.username_lbl.AutoSize = True
        Me.username_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username_lbl.ForeColor = System.Drawing.Color.Black
        Me.username_lbl.Location = New System.Drawing.Point(710, 444)
        Me.username_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.username_lbl.Name = "username_lbl"
        Me.username_lbl.Size = New System.Drawing.Size(107, 23)
        Me.username_lbl.TabIndex = 31
        Me.username_lbl.Text = "username"
        '
        'username
        '
        Me.username.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.Location = New System.Drawing.Point(713, 470)
        Me.username.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(432, 28)
        Me.username.TabIndex = 30
        '
        'connectionType_lbl
        '
        Me.connectionType_lbl.AutoSize = True
        Me.connectionType_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connectionType_lbl.ForeColor = System.Drawing.Color.Black
        Me.connectionType_lbl.Location = New System.Drawing.Point(712, 372)
        Me.connectionType_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.connectionType_lbl.Name = "connectionType_lbl"
        Me.connectionType_lbl.Size = New System.Drawing.Size(187, 23)
        Me.connectionType_lbl.TabIndex = 29
        Me.connectionType_lbl.Text = "connection type"
        '
        'connectionType
        '
        Me.connectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.connectionType.ForeColor = System.Drawing.Color.Gray
        Me.connectionType.FormattingEnabled = True
        Me.connectionType.Location = New System.Drawing.Point(715, 398)
        Me.connectionType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.connectionType.Name = "connectionType"
        Me.connectionType.Size = New System.Drawing.Size(430, 28)
        Me.connectionType.TabIndex = 28
        '
        'server_ftp_port_lbl
        '
        Me.server_ftp_port_lbl.AutoSize = True
        Me.server_ftp_port_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_port_lbl.ForeColor = System.Drawing.Color.Black
        Me.server_ftp_port_lbl.Location = New System.Drawing.Point(1173, 254)
        Me.server_ftp_port_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_ftp_port_lbl.Name = "server_ftp_port_lbl"
        Me.server_ftp_port_lbl.Size = New System.Drawing.Size(59, 23)
        Me.server_ftp_port_lbl.TabIndex = 27
        Me.server_ftp_port_lbl.Text = "Port"
        '
        'server_ftp_port
        '
        Me.server_ftp_port.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_port.Location = New System.Drawing.Point(1176, 280)
        Me.server_ftp_port.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.server_ftp_port.Name = "server_ftp_port"
        Me.server_ftp_port.Size = New System.Drawing.Size(77, 28)
        Me.server_ftp_port.TabIndex = 26
        '
        'domain_ftp_ex
        '
        Me.domain_ftp_ex.AutoSize = True
        Me.domain_ftp_ex.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_ftp_ex.ForeColor = System.Drawing.Color.Black
        Me.domain_ftp_ex.Location = New System.Drawing.Point(710, 317)
        Me.domain_ftp_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_ftp_ex.Name = "domain_ftp_ex"
        Me.domain_ftp_ex.Size = New System.Drawing.Size(319, 23)
        Me.domain_ftp_ex.TabIndex = 25
        Me.domain_ftp_ex.Text = "ex.: ftp://ftp.yourdomain.com"
        '
        'server_ftp_addr_lbl
        '
        Me.server_ftp_addr_lbl.AutoSize = True
        Me.server_ftp_addr_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_addr_lbl.ForeColor = System.Drawing.Color.Black
        Me.server_ftp_addr_lbl.Location = New System.Drawing.Point(710, 254)
        Me.server_ftp_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_ftp_addr_lbl.Name = "server_ftp_addr_lbl"
        Me.server_ftp_addr_lbl.Size = New System.Drawing.Size(201, 23)
        Me.server_ftp_addr_lbl.TabIndex = 24
        Me.server_ftp_addr_lbl.Text = "Server ftp address"
        '
        'server_ftp_addr
        '
        Me.server_ftp_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_ftp_addr.Location = New System.Drawing.Point(713, 280)
        Me.server_ftp_addr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.server_ftp_addr.Name = "server_ftp_addr"
        Me.server_ftp_addr.Size = New System.Drawing.Size(432, 28)
        Me.server_ftp_addr.TabIndex = 23
        '
        'domain_web_ex
        '
        Me.domain_web_ex.AutoSize = True
        Me.domain_web_ex.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_web_ex.ForeColor = System.Drawing.Color.Black
        Me.domain_web_ex.Location = New System.Drawing.Point(712, 189)
        Me.domain_web_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_web_ex.Name = "domain_web_ex"
        Me.domain_web_ex.Size = New System.Drawing.Size(355, 23)
        Me.domain_web_ex.TabIndex = 22
        Me.domain_web_ex.Text = "ex.: http://www.yourdomain.com"
        '
        'server_web_addr_lbl
        '
        Me.server_web_addr_lbl.AutoSize = True
        Me.server_web_addr_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr_lbl.ForeColor = System.Drawing.Color.Black
        Me.server_web_addr_lbl.Location = New System.Drawing.Point(712, 128)
        Me.server_web_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_web_addr_lbl.Name = "server_web_addr_lbl"
        Me.server_web_addr_lbl.Size = New System.Drawing.Size(207, 23)
        Me.server_web_addr_lbl.TabIndex = 21
        Me.server_web_addr_lbl.Text = "Server web address"
        '
        'server_web_addr
        '
        Me.server_web_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr.Location = New System.Drawing.Point(715, 152)
        Me.server_web_addr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.server_web_addr.Name = "server_web_addr"
        Me.server_web_addr.Size = New System.Drawing.Size(432, 28)
        Me.server_web_addr.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(231, 128)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(447, 301)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'setupWizard_NewFtpWebSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.password_lbl)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.username_lbl)
        Me.Controls.Add(Me.server_ftp_addr)
        Me.Controls.Add(Me.domain_web_ex)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.server_ftp_addr_lbl)
        Me.Controls.Add(Me.connectionType_lbl)
        Me.Controls.Add(Me.server_web_addr_lbl)
        Me.Controls.Add(Me.connectionType)
        Me.Controls.Add(Me.domain_ftp_ex)
        Me.Controls.Add(Me.server_ftp_port_lbl)
        Me.Controls.Add(Me.server_web_addr)
        Me.Controls.Add(Me.server_ftp_port)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_NewFtpWebSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents server_web_addr_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_web_addr As TextBox
    Friend WithEvents domain_web_ex As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_ftp_port_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_ftp_port As TextBox
    Friend WithEvents domain_ftp_ex As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_ftp_addr_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_ftp_addr As TextBox
    Friend WithEvents password_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents username_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents username As TextBox
    Friend WithEvents connectionType_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents connectionType As ComboBox
    Friend WithEvents password As TextBox
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
