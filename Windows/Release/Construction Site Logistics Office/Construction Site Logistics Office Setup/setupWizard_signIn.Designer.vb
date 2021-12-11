<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupWizard_signIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_signIn))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.signInCode = New System.Windows.Forms.MaskedTextBox()
        Me.signInCode_lbl = New System.Windows.Forms.Label()
        Me.send = New System.Windows.Forms.LinkLabel()
        Me.email_lbl = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.show_password = New System.Windows.Forms.PictureBox()
        Me.sign_id = New System.Windows.Forms.MaskedTextBox()
        Me.forgot_id = New System.Windows.Forms.LinkLabel()
        Me.sign_in_lbl = New System.Windows.Forms.Label()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnBackTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.server_msg = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.server_msg)
        Me.Panel1.Controls.Add(Me.signInCode)
        Me.Panel1.Controls.Add(Me.signInCode_lbl)
        Me.Panel1.Controls.Add(Me.send)
        Me.Panel1.Controls.Add(Me.email_lbl)
        Me.Panel1.Controls.Add(Me.email)
        Me.Panel1.Controls.Add(Me.show_password)
        Me.Panel1.Controls.Add(Me.sign_id)
        Me.Panel1.Controls.Add(Me.forgot_id)
        Me.Panel1.Controls.Add(Me.sign_in_lbl)
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
        'signInCode
        '
        Me.signInCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.signInCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInCode.Location = New System.Drawing.Point(432, 528)
        Me.signInCode.Margin = New System.Windows.Forms.Padding(4)
        Me.signInCode.Name = "signInCode"
        Me.signInCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.signInCode.Size = New System.Drawing.Size(314, 24)
        Me.signInCode.TabIndex = 348
        Me.signInCode.ValidatingType = GetType(Date)
        '
        'signInCode_lbl
        '
        Me.signInCode_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.signInCode_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInCode_lbl.ForeColor = System.Drawing.Color.Black
        Me.signInCode_lbl.Location = New System.Drawing.Point(15, 529)
        Me.signInCode_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.signInCode_lbl.Name = "signInCode_lbl"
        Me.signInCode_lbl.Size = New System.Drawing.Size(409, 25)
        Me.signInCode_lbl.TabIndex = 347
        Me.signInCode_lbl.Text = "Code"
        Me.signInCode_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'send
        '
        Me.send.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.send.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send.Location = New System.Drawing.Point(421, 609)
        Me.send.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.send.Name = "send"
        Me.send.Size = New System.Drawing.Size(325, 21)
        Me.send.TabIndex = 346
        Me.send.TabStop = True
        Me.send.Text = "Send"
        Me.send.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.send.Visible = False
        '
        'email_lbl
        '
        Me.email_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_lbl.ForeColor = System.Drawing.Color.Black
        Me.email_lbl.Location = New System.Drawing.Point(15, 583)
        Me.email_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.email_lbl.Name = "email_lbl"
        Me.email_lbl.Size = New System.Drawing.Size(409, 22)
        Me.email_lbl.TabIndex = 345
        Me.email_lbl.Text = "e-mail"
        Me.email_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.email_lbl.Visible = False
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(432, 581)
        Me.email.Margin = New System.Windows.Forms.Padding(4)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(313, 22)
        Me.email.TabIndex = 344
        Me.email.Visible = False
        '
        'show_password
        '
        Me.show_password.Image = CType(resources.GetObject("show_password.Image"), System.Drawing.Image)
        Me.show_password.Location = New System.Drawing.Point(755, 528)
        Me.show_password.Margin = New System.Windows.Forms.Padding(4)
        Me.show_password.Name = "show_password"
        Me.show_password.Size = New System.Drawing.Size(27, 25)
        Me.show_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.show_password.TabIndex = 343
        Me.show_password.TabStop = False
        '
        'sign_id
        '
        Me.sign_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sign_id.Culture = New System.Globalization.CultureInfo("")
        Me.sign_id.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_id.Location = New System.Drawing.Point(432, 487)
        Me.sign_id.Margin = New System.Windows.Forms.Padding(4)
        Me.sign_id.Name = "sign_id"
        Me.sign_id.Size = New System.Drawing.Size(314, 24)
        Me.sign_id.TabIndex = 342
        Me.sign_id.ValidatingType = GetType(Date)
        '
        'forgot_id
        '
        Me.forgot_id.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forgot_id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.forgot_id.Location = New System.Drawing.Point(432, 558)
        Me.forgot_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.forgot_id.Name = "forgot_id"
        Me.forgot_id.Size = New System.Drawing.Size(315, 20)
        Me.forgot_id.TabIndex = 12
        Me.forgot_id.TabStop = True
        Me.forgot_id.Text = "Forgot ID ?"
        Me.forgot_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sign_in_lbl
        '
        Me.sign_in_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sign_in_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_in_lbl.ForeColor = System.Drawing.Color.Black
        Me.sign_in_lbl.Location = New System.Drawing.Point(15, 489)
        Me.sign_in_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sign_in_lbl.Name = "sign_in_lbl"
        Me.sign_in_lbl.Size = New System.Drawing.Size(409, 25)
        Me.sign_in_lbl.TabIndex = 11
        Me.sign_in_lbl.Text = "Sign in with your ID"
        Me.sign_in_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(557, 731)
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
        Me.btnBackTxt.Location = New System.Drawing.Point(393, 731)
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
        Me.btnContinue.Location = New System.Drawing.Point(572, 684)
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
        Me.btnBack.Location = New System.Drawing.Point(393, 684)
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
        Me.PictureBox1.Location = New System.Drawing.Point(280, 121)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(467, 302)
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
        Me.subtitle.Location = New System.Drawing.Point(4, 76)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1023, 41)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "Enter your company credentials to proceed instalation"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(19, 8)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(997, 68)
        Me.title.TabIndex = 0
        Me.title.Text = "Sign in with your ID"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'server_msg
        '
        Me.server_msg.AutoSize = True
        Me.server_msg.Location = New System.Drawing.Point(435, 463)
        Me.server_msg.Name = "server_msg"
        Me.server_msg.Size = New System.Drawing.Size(136, 17)
        Me.server_msg.TabIndex = 349
        Me.server_msg.Text = "pass card on reader"
        '
        'setupWizard_signIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setupWizard_signIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents sign_in_lbl As Label
    Friend WithEvents forgot_id As LinkLabel
    Friend WithEvents show_password As PictureBox
    Friend WithEvents sign_id As MaskedTextBox
    Friend WithEvents email_lbl As Label
    Friend WithEvents email As TextBox
    Friend WithEvents send As LinkLabel
    Friend WithEvents signInCode As MaskedTextBox
    Friend WithEvents signInCode_lbl As Label
    Friend WithEvents server_msg As Label
End Class
