<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_user_profile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_user_profile))
        Me.downloadLink = New System.Windows.Forms.LinkLabel()
        Me.photobox = New System.Windows.Forms.PictureBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.saveLink = New System.Windows.Forms.LinkLabel()
        Me.contact = New System.Windows.Forms.TextBox()
        Me.contact_lbl = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.email_lbl = New System.Windows.Forms.Label()
        Me.nome = New System.Windows.Forms.TextBox()
        Me.name_lbl = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'downloadLink
        '
        Me.downloadLink.AutoSize = True
        Me.downloadLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downloadLink.Location = New System.Drawing.Point(12, 220)
        Me.downloadLink.Name = "downloadLink"
        Me.downloadLink.Size = New System.Drawing.Size(63, 13)
        Me.downloadLink.TabIndex = 203
        Me.downloadLink.TabStop = True
        Me.downloadLink.Text = "Download"
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(15, 45)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(172, 172)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 205
        Me.photobox.TabStop = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(545, 248)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.saveLink)
        Me.Panel2.Controls.Add(Me.contact)
        Me.Panel2.Controls.Add(Me.contact_lbl)
        Me.Panel2.Controls.Add(Me.email)
        Me.Panel2.Controls.Add(Me.email_lbl)
        Me.Panel2.Controls.Add(Me.nome)
        Me.Panel2.Controls.Add(Me.name_lbl)
        Me.Panel2.Controls.Add(Me.divider)
        Me.Panel2.Controls.Add(Me.photobox)
        Me.Panel2.Controls.Add(Me.title)
        Me.Panel2.Controls.Add(Me.closeBtn)
        Me.Panel2.Controls.Add(Me.downloadLink)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(649, 290)
        Me.Panel2.TabIndex = 338
        Me.Panel2.Visible = False
        '
        'saveLink
        '
        Me.saveLink.AutoSize = True
        Me.saveLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveLink.Location = New System.Drawing.Point(205, 204)
        Me.saveLink.Name = "saveLink"
        Me.saveLink.Size = New System.Drawing.Size(47, 13)
        Me.saveLink.TabIndex = 346
        Me.saveLink.TabStop = True
        Me.saveLink.Text = "Gravar"
        '
        'contact
        '
        Me.contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contact.Location = New System.Drawing.Point(208, 162)
        Me.contact.Name = "contact"
        Me.contact.Size = New System.Drawing.Size(177, 20)
        Me.contact.TabIndex = 345
        '
        'contact_lbl
        '
        Me.contact_lbl.AutoSize = True
        Me.contact_lbl.Location = New System.Drawing.Point(205, 146)
        Me.contact_lbl.Name = "contact_lbl"
        Me.contact_lbl.Size = New System.Drawing.Size(50, 13)
        Me.contact_lbl.TabIndex = 344
        Me.contact_lbl.Text = "Contacto"
        '
        'email
        '
        Me.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.email.Location = New System.Drawing.Point(208, 110)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(335, 20)
        Me.email.TabIndex = 343
        '
        'email_lbl
        '
        Me.email_lbl.AutoSize = True
        Me.email_lbl.Location = New System.Drawing.Point(205, 94)
        Me.email_lbl.Name = "email_lbl"
        Me.email_lbl.Size = New System.Drawing.Size(32, 13)
        Me.email_lbl.TabIndex = 342
        Me.email_lbl.Text = "Email"
        '
        'nome
        '
        Me.nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nome.Location = New System.Drawing.Point(208, 61)
        Me.nome.Name = "nome"
        Me.nome.Size = New System.Drawing.Size(423, 20)
        Me.nome.TabIndex = 341
        '
        'name_lbl
        '
        Me.name_lbl.AutoSize = True
        Me.name_lbl.Location = New System.Drawing.Point(205, 45)
        Me.name_lbl.Name = "name_lbl"
        Me.name_lbl.Size = New System.Drawing.Size(35, 13)
        Me.name_lbl.TabIndex = 340
        Me.name_lbl.Text = "Nome"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(9, 28)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(622, 4)
        Me.divider.TabIndex = 339
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(11, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(133, 20)
        Me.title.TabIndex = 338
        Me.title.Text = "Perfil de utilizador"
        '
        'frm_user_profile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 290)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_user_profile"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Localizar trabalhador"
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents downloadLink As LinkLabel
    Friend WithEvents photobox As PictureBox
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents saveLink As LinkLabel
    Friend WithEvents contact As TextBox
    Friend WithEvents contact_lbl As Label
    Friend WithEvents email As TextBox
    Friend WithEvents email_lbl As Label
    Friend WithEvents nome As TextBox
    Friend WithEvents name_lbl As Label
End Class
