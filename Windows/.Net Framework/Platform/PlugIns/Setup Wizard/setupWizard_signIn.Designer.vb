Imports System.Drawing
Imports System.Windows.Forms
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_signIn))
        Me.server_msg = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.signInCode = New System.Windows.Forms.MaskedTextBox()
        Me.signInCode_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.send = New System.Windows.Forms.LinkLabel()
        Me.email_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.email = New System.Windows.Forms.TextBox()
        Me.show_password = New System.Windows.Forms.PictureBox()
        Me.sign_id = New System.Windows.Forms.MaskedTextBox()
        Me.forgot_id = New System.Windows.Forms.LinkLabel()
        Me.sign_in_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'server_msg
        '
        Me.server_msg.AutoSize = True
        Me.server_msg.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_msg.ForeColor = System.Drawing.Color.Black
        Me.server_msg.Location = New System.Drawing.Point(722, 456)
        Me.server_msg.Name = "server_msg"
        Me.server_msg.Size = New System.Drawing.Size(192, 20)
        Me.server_msg.TabIndex = 349
        Me.server_msg.Text = "pass card on reader"
        '
        'signInCode
        '
        Me.signInCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.signInCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInCode.Location = New System.Drawing.Point(719, 537)
        Me.signInCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.signInCode.Name = "signInCode"
        Me.signInCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.signInCode.Size = New System.Drawing.Size(353, 28)
        Me.signInCode.TabIndex = 348
        Me.signInCode.ValidatingType = GetType(Date)
        '
        'signInCode_lbl
        '
        Me.signInCode_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.signInCode_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInCode_lbl.ForeColor = System.Drawing.Color.Black
        Me.signInCode_lbl.Location = New System.Drawing.Point(250, 538)
        Me.signInCode_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.signInCode_lbl.Name = "signInCode_lbl"
        Me.signInCode_lbl.Size = New System.Drawing.Size(460, 31)
        Me.signInCode_lbl.TabIndex = 347
        Me.signInCode_lbl.Text = "Code"
        Me.signInCode_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'send
        '
        Me.send.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.send.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send.Location = New System.Drawing.Point(707, 638)
        Me.send.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.send.Name = "send"
        Me.send.Size = New System.Drawing.Size(366, 26)
        Me.send.TabIndex = 346
        Me.send.TabStop = True
        Me.send.Text = "Send"
        Me.send.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.send.Visible = False
        '
        'email_lbl
        '
        Me.email_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.email_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email_lbl.ForeColor = System.Drawing.Color.Black
        Me.email_lbl.Location = New System.Drawing.Point(250, 606)
        Me.email_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.email_lbl.Name = "email_lbl"
        Me.email_lbl.Size = New System.Drawing.Size(460, 28)
        Me.email_lbl.TabIndex = 345
        Me.email_lbl.Text = "e-mail"
        Me.email_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.email_lbl.Visible = False
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(719, 603)
        Me.email.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(352, 26)
        Me.email.TabIndex = 344
        Me.email.Visible = False
        '
        'show_password
        '
        Me.show_password.Image = CType(resources.GetObject("show_password.Image"), System.Drawing.Image)
        Me.show_password.Location = New System.Drawing.Point(1082, 537)
        Me.show_password.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.show_password.Name = "show_password"
        Me.show_password.Size = New System.Drawing.Size(30, 31)
        Me.show_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.show_password.TabIndex = 343
        Me.show_password.TabStop = False
        '
        'sign_id
        '
        Me.sign_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sign_id.Culture = New System.Globalization.CultureInfo("")
        Me.sign_id.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_id.Location = New System.Drawing.Point(719, 486)
        Me.sign_id.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sign_id.Name = "sign_id"
        Me.sign_id.Size = New System.Drawing.Size(353, 28)
        Me.sign_id.TabIndex = 342
        Me.sign_id.ValidatingType = GetType(Date)
        '
        'forgot_id
        '
        Me.forgot_id.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.forgot_id.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.forgot_id.Location = New System.Drawing.Point(719, 575)
        Me.forgot_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.forgot_id.Name = "forgot_id"
        Me.forgot_id.Size = New System.Drawing.Size(354, 25)
        Me.forgot_id.TabIndex = 12
        Me.forgot_id.TabStop = True
        Me.forgot_id.Text = "Forgot ID ?"
        Me.forgot_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sign_in_lbl
        '
        Me.sign_in_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sign_in_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sign_in_lbl.ForeColor = System.Drawing.Color.Black
        Me.sign_in_lbl.Location = New System.Drawing.Point(250, 488)
        Me.sign_in_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sign_in_lbl.Name = "sign_in_lbl"
        Me.sign_in_lbl.Size = New System.Drawing.Size(460, 31)
        Me.sign_in_lbl.TabIndex = 11
        Me.sign_in_lbl.Text = "Sign in with your ID"
        Me.sign_in_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(548, 28)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(525, 378)
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
        'setupWizard_signIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.server_msg)
        Me.Controls.Add(Me.signInCode)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.signInCode_lbl)
        Me.Controls.Add(Me.forgot_id)
        Me.Controls.Add(Me.sign_in_lbl)
        Me.Controls.Add(Me.send)
        Me.Controls.Add(Me.sign_id)
        Me.Controls.Add(Me.email_lbl)
        Me.Controls.Add(Me.show_password)
        Me.Controls.Add(Me.email)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_signIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents sign_in_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents forgot_id As LinkLabel
    Friend WithEvents show_password As PictureBox
    Friend WithEvents sign_id As MaskedTextBox
    Friend WithEvents email_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents email As TextBox
    Friend WithEvents send As LinkLabel
    Friend WithEvents signInCode As MaskedTextBox
    Friend WithEvents signInCode_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_msg As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
