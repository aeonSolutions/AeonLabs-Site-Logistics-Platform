Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class userProfileForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(userProfileForm))
        Me.photobox = New System.Windows.Forms.PictureBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
        Me.downloadBtn = New System.Windows.Forms.PictureBox()
        Me.changePin = New System.Windows.Forms.LinkLabel()
        Me.pin = New System.Windows.Forms.TextBox()
        Me.pin_lbl = New System.Windows.Forms.Label()
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
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downloadBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(22, 83)
        Me.photobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(257, 264)
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
        Me.closeBtn.Location = New System.Drawing.Point(818, 382)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.saveBtn)
        Me.Panel2.Controls.Add(Me.downloadBtn)
        Me.Panel2.Controls.Add(Me.changePin)
        Me.Panel2.Controls.Add(Me.pin)
        Me.Panel2.Controls.Add(Me.pin_lbl)
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
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(974, 446)
        Me.Panel2.TabIndex = 338
        Me.Panel2.Visible = False
        '
        'saveBtn
        '
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(312, 297)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 351
        Me.saveBtn.TabStop = False
        '
        'downloadBtn
        '
        Me.downloadBtn.Image = CType(resources.GetObject("downloadBtn.Image"), System.Drawing.Image)
        Me.downloadBtn.Location = New System.Drawing.Point(22, 355)
        Me.downloadBtn.Name = "downloadBtn"
        Me.downloadBtn.Size = New System.Drawing.Size(50, 50)
        Me.downloadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.downloadBtn.TabIndex = 350
        Me.downloadBtn.TabStop = False
        '
        'changePin
        '
        Me.changePin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.changePin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changePin.Location = New System.Drawing.Point(683, 285)
        Me.changePin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.changePin.Name = "changePin"
        Me.changePin.Size = New System.Drawing.Size(266, 20)
        Me.changePin.TabIndex = 349
        Me.changePin.TabStop = True
        Me.changePin.Text = "change PIN"
        Me.changePin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pin
        '
        Me.pin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pin.Location = New System.Drawing.Point(681, 249)
        Me.pin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pin.Name = "pin"
        Me.pin.Size = New System.Drawing.Size(264, 26)
        Me.pin.TabIndex = 348
        '
        'pin_lbl
        '
        Me.pin_lbl.AutoSize = True
        Me.pin_lbl.Location = New System.Drawing.Point(676, 225)
        Me.pin_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pin_lbl.Name = "pin_lbl"
        Me.pin_lbl.Size = New System.Drawing.Size(35, 20)
        Me.pin_lbl.TabIndex = 347
        Me.pin_lbl.Text = "PIN"
        '
        'contact
        '
        Me.contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contact.Location = New System.Drawing.Point(312, 249)
        Me.contact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contact.Name = "contact"
        Me.contact.Size = New System.Drawing.Size(326, 26)
        Me.contact.TabIndex = 345
        '
        'contact_lbl
        '
        Me.contact_lbl.AutoSize = True
        Me.contact_lbl.Location = New System.Drawing.Point(308, 225)
        Me.contact_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contact_lbl.Name = "contact_lbl"
        Me.contact_lbl.Size = New System.Drawing.Size(74, 20)
        Me.contact_lbl.TabIndex = 344
        Me.contact_lbl.Text = "Contacto"
        '
        'email
        '
        Me.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.email.Location = New System.Drawing.Point(312, 169)
        Me.email.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(634, 26)
        Me.email.TabIndex = 343
        '
        'email_lbl
        '
        Me.email_lbl.AutoSize = True
        Me.email_lbl.Location = New System.Drawing.Point(308, 145)
        Me.email_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.email_lbl.Name = "email_lbl"
        Me.email_lbl.Size = New System.Drawing.Size(48, 20)
        Me.email_lbl.TabIndex = 342
        Me.email_lbl.Text = "Email"
        '
        'nome
        '
        Me.nome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nome.Location = New System.Drawing.Point(312, 94)
        Me.nome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nome.Name = "nome"
        Me.nome.Size = New System.Drawing.Size(634, 26)
        Me.nome.TabIndex = 341
        '
        'name_lbl
        '
        Me.name_lbl.AutoSize = True
        Me.name_lbl.Location = New System.Drawing.Point(308, 69)
        Me.name_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.name_lbl.Name = "name_lbl"
        Me.name_lbl.Size = New System.Drawing.Size(51, 20)
        Me.name_lbl.TabIndex = 340
        Me.name_lbl.Text = "Nome"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(14, 43)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(932, 5)
        Me.divider.TabIndex = 339
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(16, 12)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(206, 29)
        Me.title.TabIndex = 338
        Me.title.Text = "Perfil de utilizador"
        '
        'userProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "userProfileForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Localizar trabalhador"
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downloadBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents photobox As PictureBox
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents contact As TextBox
    Friend WithEvents contact_lbl As Label
    Friend WithEvents email As TextBox
    Friend WithEvents email_lbl As Label
    Friend WithEvents nome As TextBox
    Friend WithEvents name_lbl As Label
    Friend WithEvents changePin As LinkLabel
    Friend WithEvents pin As TextBox
    Friend WithEvents pin_lbl As Label
    Friend WithEvents downloadBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
End Class
