<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupWizard_ServerAddress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_ServerAddress))
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 788)
        Me.Panel1.TabIndex = 1
        '
        'domain_web_ex
        '
        Me.domain_web_ex.AutoSize = True
        Me.domain_web_ex.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_web_ex.Location = New System.Drawing.Point(388, 570)
        Me.domain_web_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_web_ex.Name = "domain_web_ex"
        Me.domain_web_ex.Size = New System.Drawing.Size(178, 15)
        Me.domain_web_ex.TabIndex = 22
        Me.domain_web_ex.Text = "ex.: http://www.yourdomain.com"
        '
        'server_web_addr_lbl
        '
        Me.server_web_addr_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.server_web_addr_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr_lbl.ForeColor = System.Drawing.Color.Gray
        Me.server_web_addr_lbl.Location = New System.Drawing.Point(4, 543)
        Me.server_web_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_web_addr_lbl.Name = "server_web_addr_lbl"
        Me.server_web_addr_lbl.Size = New System.Drawing.Size(385, 22)
        Me.server_web_addr_lbl.TabIndex = 21
        Me.server_web_addr_lbl.Text = "Server web address"
        Me.server_web_addr_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'server_web_addr
        '
        Me.server_web_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr.Location = New System.Drawing.Point(391, 540)
        Me.server_web_addr.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4)
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
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(47, 43)
        Me.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBack.TabIndex = 5
        Me.btnBack.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(212, 121)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(564, 302)
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
        Me.subtitle.Location = New System.Drawing.Point(8, 76)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1024, 41)
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
        Me.title.Location = New System.Drawing.Point(15, 21)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(1001, 55)
        Me.title.TabIndex = 0
        Me.title.Text = "Server Configuration"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_ServerAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setupWizard_ServerAddress"
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
End Class
