Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mobileDevicesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mobileDevicesForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.updateBtn = New System.Windows.Forms.PictureBox()
        Me.delBtn = New System.Windows.Forms.PictureBox()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
        Me.tablets_list = New System.Windows.Forms.ListBox()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.mandatoryFields_lbl = New System.Windows.Forms.Label()
        Me.device_details = New System.Windows.Forms.GroupBox()
        Me.nome = New System.Windows.Forms.TextBox()
        Me.device_name_lbl = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.device_email_lbl = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.TextBox()
        Me.device_id_lbl = New System.Windows.Forms.Label()
        Me.mobile = New System.Windows.Forms.TextBox()
        Me.device_gsm_lbl = New System.Windows.Forms.Label()
        Me.active = New System.Windows.Forms.CheckBox()
        Me.pin = New System.Windows.Forms.TextBox()
        Me.device_pin_lbl = New System.Windows.Forms.Label()
        Me.puk = New System.Windows.Forms.TextBox()
        Me.device_puk_lbl = New System.Windows.Forms.Label()
        Me.serial = New System.Windows.Forms.TextBox()
        Me.device_serial_lbl = New System.Windows.Forms.Label()
        Me.device_lastUsage = New System.Windows.Forms.GroupBox()
        Me.section_logged = New System.Windows.Forms.TextBox()
        Me.site_logged = New System.Windows.Forms.TextBox()
        Me.last_login_date = New System.Windows.Forms.TextBox()
        Me.last_login_lbl = New System.Windows.Forms.Label()
        Me.version = New System.Windows.Forms.TextBox()
        Me.version_app_lbl = New System.Windows.Forms.Label()
        Me.section_lbl = New System.Windows.Forms.Label()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.worker = New System.Windows.Forms.TextBox()
        Me.worker_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.devicesList_lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.device_details.SuspendLayout()
        Me.device_lastUsage.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.updateBtn)
        Me.Panel1.Controls.Add(Me.delBtn)
        Me.Panel1.Controls.Add(Me.saveBtn)
        Me.Panel1.Controls.Add(Me.tablets_list)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.mandatoryFields_lbl)
        Me.Panel1.Controls.Add(Me.device_details)
        Me.Panel1.Controls.Add(Me.device_lastUsage)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.devicesList_lbl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1216, 832)
        Me.Panel1.TabIndex = 0
        '
        'updateBtn
        '
        Me.updateBtn.Image = CType(resources.GetObject("updateBtn.Image"), System.Drawing.Image)
        Me.updateBtn.Location = New System.Drawing.Point(27, 762)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(50, 50)
        Me.updateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.updateBtn.TabIndex = 372
        Me.updateBtn.TabStop = False
        '
        'delBtn
        '
        Me.delBtn.Image = CType(resources.GetObject("delBtn.Image"), System.Drawing.Image)
        Me.delBtn.Location = New System.Drawing.Point(596, 762)
        Me.delBtn.Name = "delBtn"
        Me.delBtn.Size = New System.Drawing.Size(50, 50)
        Me.delBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delBtn.TabIndex = 371
        Me.delBtn.TabStop = False
        '
        'saveBtn
        '
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(681, 762)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 370
        Me.saveBtn.TabStop = False
        '
        'tablets_list
        '
        Me.tablets_list.FormattingEnabled = True
        Me.tablets_list.HorizontalScrollbar = True
        Me.tablets_list.ItemHeight = 20
        Me.tablets_list.Location = New System.Drawing.Point(27, 132)
        Me.tablets_list.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tablets_list.Name = "tablets_list"
        Me.tablets_list.Size = New System.Drawing.Size(558, 624)
        Me.tablets_list.TabIndex = 368
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(22, 45)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1170, 5)
        Me.divider.TabIndex = 365
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(16, 14)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(248, 29)
        Me.title.TabIndex = 364
        Me.title.Text = "Equipamentos Mobile"
        '
        'mandatoryFields_lbl
        '
        Me.mandatoryFields_lbl.AutoSize = True
        Me.mandatoryFields_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatoryFields_lbl.Location = New System.Drawing.Point(969, 51)
        Me.mandatoryFields_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.mandatoryFields_lbl.Name = "mandatoryFields_lbl"
        Me.mandatoryFields_lbl.Size = New System.Drawing.Size(241, 20)
        Me.mandatoryFields_lbl.TabIndex = 363
        Me.mandatoryFields_lbl.Text = "campos com * são obrigatórios"
        Me.mandatoryFields_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'device_details
        '
        Me.device_details.Controls.Add(Me.nome)
        Me.device_details.Controls.Add(Me.device_name_lbl)
        Me.device_details.Controls.Add(Me.email)
        Me.device_details.Controls.Add(Me.device_email_lbl)
        Me.device_details.Controls.Add(Me.id)
        Me.device_details.Controls.Add(Me.device_id_lbl)
        Me.device_details.Controls.Add(Me.mobile)
        Me.device_details.Controls.Add(Me.device_gsm_lbl)
        Me.device_details.Controls.Add(Me.active)
        Me.device_details.Controls.Add(Me.pin)
        Me.device_details.Controls.Add(Me.device_pin_lbl)
        Me.device_details.Controls.Add(Me.puk)
        Me.device_details.Controls.Add(Me.device_puk_lbl)
        Me.device_details.Controls.Add(Me.serial)
        Me.device_details.Controls.Add(Me.device_serial_lbl)
        Me.device_details.Location = New System.Drawing.Point(596, 108)
        Me.device_details.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.device_details.Name = "device_details"
        Me.device_details.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.device_details.Size = New System.Drawing.Size(597, 332)
        Me.device_details.TabIndex = 362
        Me.device_details.TabStop = False
        Me.device_details.Text = "Caracteristicas do Equipamento"
        '
        'nome
        '
        Me.nome.Location = New System.Drawing.Point(14, 49)
        Me.nome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nome.Name = "nome"
        Me.nome.Size = New System.Drawing.Size(390, 26)
        Me.nome.TabIndex = 364
        '
        'device_name_lbl
        '
        Me.device_name_lbl.AutoSize = True
        Me.device_name_lbl.Location = New System.Drawing.Point(9, 25)
        Me.device_name_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_name_lbl.Name = "device_name_lbl"
        Me.device_name_lbl.Size = New System.Drawing.Size(170, 20)
        Me.device_name_lbl.TabIndex = 363
        Me.device_name_lbl.Text = "Nome do equipamento"
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(14, 285)
        Me.email.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(403, 26)
        Me.email.TabIndex = 362
        Me.email.Text = "@qualityconstruction.be"
        '
        'device_email_lbl
        '
        Me.device_email_lbl.AutoSize = True
        Me.device_email_lbl.Location = New System.Drawing.Point(9, 260)
        Me.device_email_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_email_lbl.Name = "device_email_lbl"
        Me.device_email_lbl.Size = New System.Drawing.Size(51, 20)
        Me.device_email_lbl.TabIndex = 361
        Me.device_email_lbl.Text = "e-mail"
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(14, 165)
        Me.id.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(390, 26)
        Me.id.TabIndex = 360
        '
        'device_id_lbl
        '
        Me.device_id_lbl.AutoSize = True
        Me.device_id_lbl.Location = New System.Drawing.Point(9, 140)
        Me.device_id_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_id_lbl.Name = "device_id_lbl"
        Me.device_id_lbl.Size = New System.Drawing.Size(153, 20)
        Me.device_id_lbl.TabIndex = 359
        Me.device_id_lbl.Text = "ID do Equipamento*"
        '
        'mobile
        '
        Me.mobile.Location = New System.Drawing.Point(14, 225)
        Me.mobile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.mobile.Name = "mobile"
        Me.mobile.Size = New System.Drawing.Size(226, 26)
        Me.mobile.TabIndex = 358
        '
        'device_gsm_lbl
        '
        Me.device_gsm_lbl.AutoSize = True
        Me.device_gsm_lbl.Location = New System.Drawing.Point(9, 200)
        Me.device_gsm_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_gsm_lbl.Name = "device_gsm_lbl"
        Me.device_gsm_lbl.Size = New System.Drawing.Size(108, 20)
        Me.device_gsm_lbl.TabIndex = 357
        Me.device_gsm_lbl.Text = "Número Telef."
        '
        'active
        '
        Me.active.AutoSize = True
        Me.active.Location = New System.Drawing.Point(414, 169)
        Me.active.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.active.Name = "active"
        Me.active.Size = New System.Drawing.Size(76, 24)
        Me.active.TabIndex = 356
        Me.active.Text = "Ativo*"
        Me.active.UseVisualStyleBackColor = True
        '
        'pin
        '
        Me.pin.Location = New System.Drawing.Point(428, 225)
        Me.pin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pin.Name = "pin"
        Me.pin.Size = New System.Drawing.Size(133, 26)
        Me.pin.TabIndex = 355
        '
        'device_pin_lbl
        '
        Me.device_pin_lbl.AutoSize = True
        Me.device_pin_lbl.Location = New System.Drawing.Point(423, 200)
        Me.device_pin_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_pin_lbl.Name = "device_pin_lbl"
        Me.device_pin_lbl.Size = New System.Drawing.Size(35, 20)
        Me.device_pin_lbl.TabIndex = 354
        Me.device_pin_lbl.Text = "PIN"
        '
        'puk
        '
        Me.puk.Location = New System.Drawing.Point(250, 225)
        Me.puk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.puk.Name = "puk"
        Me.puk.Size = New System.Drawing.Size(166, 26)
        Me.puk.TabIndex = 353
        '
        'device_puk_lbl
        '
        Me.device_puk_lbl.AutoSize = True
        Me.device_puk_lbl.Location = New System.Drawing.Point(246, 200)
        Me.device_puk_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_puk_lbl.Name = "device_puk_lbl"
        Me.device_puk_lbl.Size = New System.Drawing.Size(41, 20)
        Me.device_puk_lbl.TabIndex = 352
        Me.device_puk_lbl.Text = "PUK"
        '
        'serial
        '
        Me.serial.Location = New System.Drawing.Point(14, 105)
        Me.serial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.serial.Name = "serial"
        Me.serial.Size = New System.Drawing.Size(390, 26)
        Me.serial.TabIndex = 351
        '
        'device_serial_lbl
        '
        Me.device_serial_lbl.AutoSize = True
        Me.device_serial_lbl.Location = New System.Drawing.Point(9, 80)
        Me.device_serial_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.device_serial_lbl.Name = "device_serial_lbl"
        Me.device_serial_lbl.Size = New System.Drawing.Size(128, 20)
        Me.device_serial_lbl.TabIndex = 350
        Me.device_serial_lbl.Text = "Número de Série"
        '
        'device_lastUsage
        '
        Me.device_lastUsage.Controls.Add(Me.section_logged)
        Me.device_lastUsage.Controls.Add(Me.site_logged)
        Me.device_lastUsage.Controls.Add(Me.last_login_date)
        Me.device_lastUsage.Controls.Add(Me.last_login_lbl)
        Me.device_lastUsage.Controls.Add(Me.version)
        Me.device_lastUsage.Controls.Add(Me.version_app_lbl)
        Me.device_lastUsage.Controls.Add(Me.section_lbl)
        Me.device_lastUsage.Controls.Add(Me.site_lbl)
        Me.device_lastUsage.Controls.Add(Me.worker)
        Me.device_lastUsage.Controls.Add(Me.worker_lbl)
        Me.device_lastUsage.Location = New System.Drawing.Point(596, 449)
        Me.device_lastUsage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.device_lastUsage.Name = "device_lastUsage"
        Me.device_lastUsage.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.device_lastUsage.Size = New System.Drawing.Size(597, 305)
        Me.device_lastUsage.TabIndex = 361
        Me.device_lastUsage.TabStop = False
        Me.device_lastUsage.Text = "Última utilização do Equipamento"
        '
        'section_logged
        '
        Me.section_logged.Location = New System.Drawing.Point(22, 192)
        Me.section_logged.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.section_logged.Name = "section_logged"
        Me.section_logged.Size = New System.Drawing.Size(547, 26)
        Me.section_logged.TabIndex = 356
        '
        'site_logged
        '
        Me.site_logged.Location = New System.Drawing.Point(22, 131)
        Me.site_logged.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.site_logged.Name = "site_logged"
        Me.site_logged.Size = New System.Drawing.Size(547, 26)
        Me.site_logged.TabIndex = 355
        '
        'last_login_date
        '
        Me.last_login_date.Location = New System.Drawing.Point(220, 254)
        Me.last_login_date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.last_login_date.Name = "last_login_date"
        Me.last_login_date.Size = New System.Drawing.Size(186, 26)
        Me.last_login_date.TabIndex = 354
        '
        'last_login_lbl
        '
        Me.last_login_lbl.AutoSize = True
        Me.last_login_lbl.Location = New System.Drawing.Point(216, 229)
        Me.last_login_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.last_login_lbl.Name = "last_login_lbl"
        Me.last_login_lbl.Size = New System.Drawing.Size(97, 20)
        Me.last_login_lbl.TabIndex = 353
        Me.last_login_lbl.Text = "Último Login"
        '
        'version
        '
        Me.version.Location = New System.Drawing.Point(24, 254)
        Me.version.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.version.Name = "version"
        Me.version.Size = New System.Drawing.Size(166, 26)
        Me.version.TabIndex = 352
        '
        'version_app_lbl
        '
        Me.version_app_lbl.AutoSize = True
        Me.version_app_lbl.Location = New System.Drawing.Point(20, 229)
        Me.version_app_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.version_app_lbl.Name = "version_app_lbl"
        Me.version_app_lbl.Size = New System.Drawing.Size(115, 20)
        Me.version_app_lbl.TabIndex = 351
        Me.version_app_lbl.Text = "Versão da App"
        '
        'section_lbl
        '
        Me.section_lbl.AutoSize = True
        Me.section_lbl.Location = New System.Drawing.Point(18, 168)
        Me.section_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.section_lbl.Name = "section_lbl"
        Me.section_lbl.Size = New System.Drawing.Size(63, 20)
        Me.section_lbl.TabIndex = 350
        Me.section_lbl.Text = "Secção"
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.Location = New System.Drawing.Point(18, 106)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(44, 20)
        Me.site_lbl.TabIndex = 348
        Me.site_lbl.Text = "Obra"
        '
        'worker
        '
        Me.worker.Location = New System.Drawing.Point(22, 66)
        Me.worker.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.worker.Name = "worker"
        Me.worker.Size = New System.Drawing.Size(547, 26)
        Me.worker.TabIndex = 346
        '
        'worker_lbl
        '
        Me.worker_lbl.AutoSize = True
        Me.worker_lbl.Location = New System.Drawing.Point(18, 42)
        Me.worker_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.worker_lbl.Name = "worker_lbl"
        Me.worker_lbl.Size = New System.Drawing.Size(85, 20)
        Me.worker_lbl.TabIndex = 345
        Me.worker_lbl.Text = "Atribuido a"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1064, 772)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 360
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'devicesList_lbl
        '
        Me.devicesList_lbl.AutoSize = True
        Me.devicesList_lbl.Location = New System.Drawing.Point(22, 108)
        Me.devicesList_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.devicesList_lbl.Name = "devicesList_lbl"
        Me.devicesList_lbl.Size = New System.Drawing.Size(197, 20)
        Me.devicesList_lbl.TabIndex = 359
        Me.devicesList_lbl.Text = "Equipamentos Registados"
        '
        'mobileDevicesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 832)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mobileDevicesForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Equipamentos Mobile"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.device_details.ResumeLayout(False)
        Me.device_details.PerformLayout()
        Me.device_lastUsage.ResumeLayout(False)
        Me.device_lastUsage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tablets_list As ListBox
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents mandatoryFields_lbl As Label
    Friend WithEvents device_details As GroupBox
    Friend WithEvents email As TextBox
    Friend WithEvents device_email_lbl As Label
    Friend WithEvents id As TextBox
    Friend WithEvents device_id_lbl As Label
    Friend WithEvents mobile As TextBox
    Friend WithEvents device_gsm_lbl As Label
    Friend WithEvents active As CheckBox
    Friend WithEvents pin As TextBox
    Friend WithEvents device_pin_lbl As Label
    Friend WithEvents puk As TextBox
    Friend WithEvents device_puk_lbl As Label
    Friend WithEvents serial As TextBox
    Friend WithEvents device_serial_lbl As Label
    Friend WithEvents device_lastUsage As GroupBox
    Friend WithEvents section_logged As TextBox
    Friend WithEvents site_logged As TextBox
    Friend WithEvents last_login_date As TextBox
    Friend WithEvents last_login_lbl As Label
    Friend WithEvents version As TextBox
    Friend WithEvents version_app_lbl As Label
    Friend WithEvents section_lbl As Label
    Friend WithEvents site_lbl As Label
    Friend WithEvents worker As TextBox
    Friend WithEvents worker_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents devicesList_lbl As Label
    Friend WithEvents nome As TextBox
    Friend WithEvents device_name_lbl As Label
    Friend WithEvents delBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
    Friend WithEvents updateBtn As PictureBox
End Class
