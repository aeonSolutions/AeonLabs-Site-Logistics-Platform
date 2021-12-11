<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class auth_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(auth_frm))
        Me.access_code = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.codetxt = New System.Windows.Forms.MaskedTextBox()
        Me.doAuth = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.cardId = New System.Windows.Forms.TextBox()
        Me.cardId_lbl = New System.Windows.Forms.Label()
        Me.cancelCard_lbl = New System.Windows.Forms.LinkLabel()
        Me.server_msg = New System.Windows.Forms.Label()
        Me.loginIcon = New System.Windows.Forms.PictureBox()
        Me.show_password = New System.Windows.Forms.PictureBox()
        Me.Panel.SuspendLayout()
        CType(Me.loginIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'access_code
        '
        Me.access_code.AutoSize = True
        Me.access_code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.access_code.Location = New System.Drawing.Point(154, 76)
        Me.access_code.Name = "access_code"
        Me.access_code.Size = New System.Drawing.Size(108, 13)
        Me.access_code.TabIndex = 1
        Me.access_code.Text = "Código de acesso"
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 3)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(384, 29)
        Me.title.TabIndex = 3
        Me.title.Text = "Bem vindo à plataforma de gestão de obras"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'codetxt
        '
        Me.codetxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.codetxt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codetxt.Location = New System.Drawing.Point(157, 92)
        Me.codetxt.Name = "codetxt"
        Me.codetxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.codetxt.Size = New System.Drawing.Size(69, 21)
        Me.codetxt.TabIndex = 2
        Me.codetxt.ValidatingType = GetType(Date)
        '
        'doAuth
        '
        Me.doAuth.BackColor = System.Drawing.Color.Tan
        Me.doAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.doAuth.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doAuth.ForeColor = System.Drawing.Color.White
        Me.doAuth.Location = New System.Drawing.Point(287, 125)
        Me.doAuth.Name = "doAuth"
        Me.doAuth.Size = New System.Drawing.Size(100, 26)
        Me.doAuth.TabIndex = 338
        Me.doAuth.Text = "Autenticar"
        Me.doAuth.UseVisualStyleBackColor = False
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.White
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel.Controls.Add(Me.cardId)
        Me.Panel.Controls.Add(Me.cardId_lbl)
        Me.Panel.Controls.Add(Me.cancelCard_lbl)
        Me.Panel.Controls.Add(Me.server_msg)
        Me.Panel.Controls.Add(Me.loginIcon)
        Me.Panel.Controls.Add(Me.show_password)
        Me.Panel.Controls.Add(Me.doAuth)
        Me.Panel.Controls.Add(Me.title)
        Me.Panel.Controls.Add(Me.codetxt)
        Me.Panel.Controls.Add(Me.access_code)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(392, 156)
        Me.Panel.TabIndex = 339
        Me.Panel.Visible = False
        '
        'cardId
        '
        Me.cardId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardId.Location = New System.Drawing.Point(157, 52)
        Me.cardId.Name = "cardId"
        Me.cardId.Size = New System.Drawing.Size(133, 21)
        Me.cardId.TabIndex = 1
        '
        'cardId_lbl
        '
        Me.cardId_lbl.AutoSize = True
        Me.cardId_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cardId_lbl.Location = New System.Drawing.Point(154, 36)
        Me.cardId_lbl.Name = "cardId_lbl"
        Me.cardId_lbl.Size = New System.Drawing.Size(82, 13)
        Me.cardId_lbl.TabIndex = 344
        Me.cardId_lbl.Text = "ID de acesso"
        '
        'cancelCard_lbl
        '
        Me.cancelCard_lbl.AutoSize = True
        Me.cancelCard_lbl.Location = New System.Drawing.Point(341, 109)
        Me.cancelCard_lbl.Name = "cancelCard_lbl"
        Me.cancelCard_lbl.Size = New System.Drawing.Size(46, 13)
        Me.cancelCard_lbl.TabIndex = 342
        Me.cancelCard_lbl.TabStop = True
        Me.cancelCard_lbl.Text = "Cancel"
        Me.cancelCard_lbl.Visible = False
        '
        'server_msg
        '
        Me.server_msg.AutoSize = True
        Me.server_msg.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_msg.Location = New System.Drawing.Point(3, 139)
        Me.server_msg.Name = "server_msg"
        Me.server_msg.Size = New System.Drawing.Size(103, 12)
        Me.server_msg.TabIndex = 341
        Me.server_msg.Text = "Contacting server..."
        Me.server_msg.Visible = False
        '
        'loginIcon
        '
        Me.loginIcon.Image = CType(resources.GetObject("loginIcon.Image"), System.Drawing.Image)
        Me.loginIcon.Location = New System.Drawing.Point(36, 35)
        Me.loginIcon.Name = "loginIcon"
        Me.loginIcon.Size = New System.Drawing.Size(78, 78)
        Me.loginIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loginIcon.TabIndex = 340
        Me.loginIcon.TabStop = False
        '
        'show_password
        '
        Me.show_password.Image = CType(resources.GetObject("show_password.Image"), System.Drawing.Image)
        Me.show_password.Location = New System.Drawing.Point(240, 92)
        Me.show_password.Name = "show_password"
        Me.show_password.Size = New System.Drawing.Size(22, 21)
        Me.show_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.show_password.TabIndex = 339
        Me.show_password.TabStop = False
        '
        'auth_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 156)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "auth_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Autenticar"
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.loginIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.show_password, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents access_code As Label
    Friend WithEvents title As Label
    Friend WithEvents codetxt As MaskedTextBox
    Friend WithEvents doAuth As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents show_password As PictureBox
    Friend WithEvents loginIcon As PictureBox
    Friend WithEvents server_msg As Label
    Friend WithEvents cancelCard_lbl As LinkLabel
    Friend WithEvents cardId As TextBox
    Friend WithEvents cardId_lbl As Label
End Class
