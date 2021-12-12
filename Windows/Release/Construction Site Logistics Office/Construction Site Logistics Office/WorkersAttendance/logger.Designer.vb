<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class logger_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(logger_frm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.combo_company = New System.Windows.Forms.ComboBox()
        Me.company_lbl = New System.Windows.Forms.Label()
        Me.calendar_log = New System.Windows.Forms.MonthCalendar()
        Me.GroupBox_detalhes = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.worker_photo = New System.Windows.Forms.PictureBox()
        Me.detalhes_validacao = New System.Windows.Forms.Label()
        Me.detalhes_emergencia = New System.Windows.Forms.Label()
        Me.detalhes_obra = New System.Windows.Forms.Label()
        Me.detalhes_empresa = New System.Windows.Forms.Label()
        Me.detalhes_cat = New System.Windows.Forms.Label()
        Me.detalhes_checkout = New System.Windows.Forms.Label()
        Me.detalhes_checkin = New System.Windows.Forms.Label()
        Me.detalhes_nfc = New System.Windows.Forms.Label()
        Me.detalhes_contacto = New System.Windows.Forms.Label()
        Me.detalhes_nome = New System.Windows.Forms.Label()
        Me.gravarnota_lbl = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.notes_group = New System.Windows.Forms.GroupBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.stats_lbl = New System.Windows.Forms.LinkLabel()
        Me.loadTableBtn = New System.Windows.Forms.PictureBox()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.color_checkinOut_lbl = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.color_changeSite_lbl = New System.Windows.Forms.Label()
        Me.teamAssign_lbl = New System.Windows.Forms.Label()
        Me.initials_teamAssign_lbl = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.changeSite_lbl = New System.Windows.Forms.Label()
        Me.initials_changeSite_lbl = New System.Windows.Forms.Label()
        Me.color_assignedTeam_lbl = New System.Windows.Forms.Label()
        Me.colorAbsentDay_lbl = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.color_fullDay_lbl = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.color_plannedAbsense_lbl = New System.Windows.Forms.Label()
        Me.colorNoRecord_lbl = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.color_partialDay_lbl = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.color_holidays_lbl = New System.Windows.Forms.Label()
        Me.siteBadWeather_lbl = New System.Windows.Forms.Label()
        Me.initials_siteBadWeather_lbl = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.siteAnnual_lbl = New System.Windows.Forms.Label()
        Me.initials_siteAnnual_lbl = New System.Windows.Forms.Label()
        Me.color_weekend_lbl = New System.Windows.Forms.Label()
        Me.malady_lbl = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.initials_malady_lbl = New System.Windows.Forms.Label()
        Me.playDay_lbl = New System.Windows.Forms.Label()
        Me.initials_playDay_lbl = New System.Windows.Forms.Label()
        Me.holidays_lbl = New System.Windows.Forms.Label()
        Me.initials_holidays_lbl = New System.Windows.Forms.Label()
        Me.fullDayAbsent_lbl = New System.Windows.Forms.Label()
        Me.initials_fullDayAbsent_lbl = New System.Windows.Forms.Label()
        Me.badWeather_lbl = New System.Windows.Forms.Label()
        Me.initials_badWeather_lbl = New System.Windows.Forms.Label()
        Me.fullday_lbl = New System.Windows.Forms.Label()
        Me.initials_fullDay_lbl = New System.Windows.Forms.Label()
        Me.initials_partialAbsense_lbl = New System.Windows.Forms.Label()
        Me.color_doubleRecord_lbl = New System.Windows.Forms.Label()
        Me.partialAbsense_lbl = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox_legenda = New System.Windows.Forms.GroupBox()
        Me.tableSettingsBtn = New System.Windows.Forms.PictureBox()
        Me.multipleSelectionBtn = New System.Windows.Forms.PictureBox()
        Me.duplicateRecords = New System.Windows.Forms.Label()
        Me.GroupBox_detalhes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.notes_group.SuspendLayout()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox_legenda.SuspendLayout()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.multipleSelectionBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(6, 11)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(54, 20)
        Me.site_lbl.TabIndex = 0
        Me.site_lbl.Text = "Obra"
        Me.site_lbl.Visible = False
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(68, 6)
        Me.combo_site.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(490, 32)
        Me.combo_site.TabIndex = 1
        Me.combo_site.Visible = False
        '
        'combo_company
        '
        Me.combo_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_company.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_company.FormattingEnabled = True
        Me.combo_company.Location = New System.Drawing.Point(677, 4)
        Me.combo_company.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_company.Name = "combo_company"
        Me.combo_company.Size = New System.Drawing.Size(279, 32)
        Me.combo_company.TabIndex = 6
        Me.combo_company.Visible = False
        '
        'company_lbl
        '
        Me.company_lbl.AutoSize = True
        Me.company_lbl.CausesValidation = False
        Me.company_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.company_lbl.Location = New System.Drawing.Point(578, 11)
        Me.company_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.company_lbl.Name = "company_lbl"
        Me.company_lbl.Size = New System.Drawing.Size(91, 20)
        Me.company_lbl.TabIndex = 5
        Me.company_lbl.Text = "Empresa"
        Me.company_lbl.Visible = False
        '
        'calendar_log
        '
        Me.calendar_log.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calendar_log.Location = New System.Drawing.Point(7, 46)
        Me.calendar_log.Margin = New System.Windows.Forms.Padding(13, 11, 13, 11)
        Me.calendar_log.MaxSelectionCount = 1
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.TabIndex = 20
        Me.calendar_log.Visible = False
        '
        'GroupBox_detalhes
        '
        Me.GroupBox_detalhes.CausesValidation = False
        Me.GroupBox_detalhes.Controls.Add(Me.Panel1)
        Me.GroupBox_detalhes.Location = New System.Drawing.Point(868, 588)
        Me.GroupBox_detalhes.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalhes.Name = "GroupBox_detalhes"
        Me.GroupBox_detalhes.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalhes.Size = New System.Drawing.Size(787, 181)
        Me.GroupBox_detalhes.TabIndex = 22
        Me.GroupBox_detalhes.TabStop = False
        Me.GroupBox_detalhes.Text = "Detalhes 01-01-2019"
        Me.GroupBox_detalhes.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.duplicateRecords)
        Me.Panel1.Controls.Add(Me.worker_photo)
        Me.Panel1.Controls.Add(Me.detalhes_validacao)
        Me.Panel1.Controls.Add(Me.detalhes_emergencia)
        Me.Panel1.Controls.Add(Me.detalhes_obra)
        Me.Panel1.Controls.Add(Me.detalhes_empresa)
        Me.Panel1.Controls.Add(Me.detalhes_cat)
        Me.Panel1.Controls.Add(Me.detalhes_checkout)
        Me.Panel1.Controls.Add(Me.detalhes_checkin)
        Me.Panel1.Controls.Add(Me.detalhes_nfc)
        Me.Panel1.Controls.Add(Me.detalhes_contacto)
        Me.Panel1.Controls.Add(Me.detalhes_nome)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 24)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(779, 153)
        Me.Panel1.TabIndex = 0
        '
        'worker_photo
        '
        Me.worker_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.worker_photo.Image = CType(resources.GetObject("worker_photo.Image"), System.Drawing.Image)
        Me.worker_photo.InitialImage = Nothing
        Me.worker_photo.Location = New System.Drawing.Point(15, 14)
        Me.worker_photo.Name = "worker_photo"
        Me.worker_photo.Size = New System.Drawing.Size(101, 111)
        Me.worker_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.worker_photo.TabIndex = 45
        Me.worker_photo.TabStop = False
        Me.worker_photo.Visible = False
        '
        'detalhes_validacao
        '
        Me.detalhes_validacao.AutoSize = True
        Me.detalhes_validacao.BackColor = System.Drawing.Color.White
        Me.detalhes_validacao.CausesValidation = False
        Me.detalhes_validacao.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_validacao.ForeColor = System.Drawing.Color.Black
        Me.detalhes_validacao.Location = New System.Drawing.Point(417, 144)
        Me.detalhes_validacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_validacao.Name = "detalhes_validacao"
        Me.detalhes_validacao.Size = New System.Drawing.Size(158, 17)
        Me.detalhes_validacao.TabIndex = 44
        Me.detalhes_validacao.Text = "Validação: Intempérie"
        '
        'detalhes_emergencia
        '
        Me.detalhes_emergencia.AutoSize = True
        Me.detalhes_emergencia.BackColor = System.Drawing.Color.White
        Me.detalhes_emergencia.CausesValidation = False
        Me.detalhes_emergencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_emergencia.ForeColor = System.Drawing.Color.Black
        Me.detalhes_emergencia.Location = New System.Drawing.Point(417, 100)
        Me.detalhes_emergencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_emergencia.Name = "detalhes_emergencia"
        Me.detalhes_emergencia.Size = New System.Drawing.Size(233, 17)
        Me.detalhes_emergencia.TabIndex = 43
        Me.detalhes_emergencia.Text = "Emergência: +351 933 651 316"
        '
        'detalhes_obra
        '
        Me.detalhes_obra.AutoSize = True
        Me.detalhes_obra.BackColor = System.Drawing.Color.White
        Me.detalhes_obra.CausesValidation = False
        Me.detalhes_obra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_obra.ForeColor = System.Drawing.Color.Black
        Me.detalhes_obra.Location = New System.Drawing.Point(123, 33)
        Me.detalhes_obra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_obra.Name = "detalhes_obra"
        Me.detalhes_obra.Size = New System.Drawing.Size(102, 17)
        Me.detalhes_obra.TabIndex = 42
        Me.detalhes_obra.Text = "Obra: Perwez"
        '
        'detalhes_empresa
        '
        Me.detalhes_empresa.AutoSize = True
        Me.detalhes_empresa.BackColor = System.Drawing.Color.White
        Me.detalhes_empresa.CausesValidation = False
        Me.detalhes_empresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_empresa.ForeColor = System.Drawing.Color.Black
        Me.detalhes_empresa.Location = New System.Drawing.Point(123, 78)
        Me.detalhes_empresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_empresa.Name = "detalhes_empresa"
        Me.detalhes_empresa.Size = New System.Drawing.Size(224, 17)
        Me.detalhes_empresa.TabIndex = 41
        Me.detalhes_empresa.Text = "Empresa: AeonLabs"
        '
        'detalhes_cat
        '
        Me.detalhes_cat.AutoSize = True
        Me.detalhes_cat.BackColor = System.Drawing.Color.White
        Me.detalhes_cat.CausesValidation = False
        Me.detalhes_cat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_cat.ForeColor = System.Drawing.Color.Black
        Me.detalhes_cat.Location = New System.Drawing.Point(123, 100)
        Me.detalhes_cat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_cat.Name = "detalhes_cat"
        Me.detalhes_cat.Size = New System.Drawing.Size(229, 17)
        Me.detalhes_cat.TabIndex = 40
        Me.detalhes_cat.Text = "Categoria profissional: pedreiro"
        '
        'detalhes_checkout
        '
        Me.detalhes_checkout.AutoSize = True
        Me.detalhes_checkout.BackColor = System.Drawing.Color.White
        Me.detalhes_checkout.CausesValidation = False
        Me.detalhes_checkout.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_checkout.ForeColor = System.Drawing.Color.Black
        Me.detalhes_checkout.Location = New System.Drawing.Point(577, 121)
        Me.detalhes_checkout.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_checkout.Name = "detalhes_checkout"
        Me.detalhes_checkout.Size = New System.Drawing.Size(167, 17)
        Me.detalhes_checkout.TabIndex = 39
        Me.detalhes_checkout.Text = "Checkout: s/ checkout"
        '
        'detalhes_checkin
        '
        Me.detalhes_checkin.AutoSize = True
        Me.detalhes_checkin.BackColor = System.Drawing.Color.White
        Me.detalhes_checkin.CausesValidation = False
        Me.detalhes_checkin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_checkin.ForeColor = System.Drawing.Color.Black
        Me.detalhes_checkin.Location = New System.Drawing.Point(417, 121)
        Me.detalhes_checkin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_checkin.Name = "detalhes_checkin"
        Me.detalhes_checkin.Size = New System.Drawing.Size(143, 17)
        Me.detalhes_checkin.TabIndex = 38
        Me.detalhes_checkin.Text = "Checkin: s/ checkin"
        '
        'detalhes_nfc
        '
        Me.detalhes_nfc.AutoSize = True
        Me.detalhes_nfc.BackColor = System.Drawing.Color.White
        Me.detalhes_nfc.CausesValidation = False
        Me.detalhes_nfc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_nfc.ForeColor = System.Drawing.Color.Black
        Me.detalhes_nfc.Location = New System.Drawing.Point(123, 121)
        Me.detalhes_nfc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_nfc.Name = "detalhes_nfc"
        Me.detalhes_nfc.Size = New System.Drawing.Size(198, 17)
        Me.detalhes_nfc.TabIndex = 37
        Me.detalhes_nfc.Text = "Codigo cartao: 123456789"
        '
        'detalhes_contacto
        '
        Me.detalhes_contacto.AutoSize = True
        Me.detalhes_contacto.BackColor = System.Drawing.Color.White
        Me.detalhes_contacto.CausesValidation = False
        Me.detalhes_contacto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_contacto.ForeColor = System.Drawing.Color.Black
        Me.detalhes_contacto.Location = New System.Drawing.Point(417, 78)
        Me.detalhes_contacto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_contacto.Name = "detalhes_contacto"
        Me.detalhes_contacto.Size = New System.Drawing.Size(214, 17)
        Me.detalhes_contacto.TabIndex = 36
        Me.detalhes_contacto.Text = "contacto: +351 933 651 316"
        '
        'detalhes_nome
        '
        Me.detalhes_nome.AutoSize = True
        Me.detalhes_nome.BackColor = System.Drawing.Color.White
        Me.detalhes_nome.CausesValidation = False
        Me.detalhes_nome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_nome.ForeColor = System.Drawing.Color.Black
        Me.detalhes_nome.Location = New System.Drawing.Point(123, 14)
        Me.detalhes_nome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_nome.Name = "detalhes_nome"
        Me.detalhes_nome.Size = New System.Drawing.Size(191, 17)
        Me.detalhes_nome.TabIndex = 35
        Me.detalhes_nome.Text = "Miguel Tomas Pinto e Silva"
        '
        'gravarnota_lbl
        '
        Me.gravarnota_lbl.AutoSize = True
        Me.gravarnota_lbl.Enabled = False
        Me.gravarnota_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gravarnota_lbl.Location = New System.Drawing.Point(7, 132)
        Me.gravarnota_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.gravarnota_lbl.Name = "gravarnota_lbl"
        Me.gravarnota_lbl.Size = New System.Drawing.Size(92, 17)
        Me.gravarnota_lbl.TabIndex = 24
        Me.gravarnota_lbl.TabStop = True
        Me.gravarnota_lbl.Text = "Gravar nota"
        Me.gravarnota_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'notes_group
        '
        Me.notes_group.Controls.Add(Me.gravarnota_lbl)
        Me.notes_group.Controls.Add(Me.txt_nota)
        Me.notes_group.Location = New System.Drawing.Point(290, 588)
        Me.notes_group.Name = "notes_group"
        Me.notes_group.Size = New System.Drawing.Size(567, 181)
        Me.notes_group.TabIndex = 30
        Me.notes_group.TabStop = False
        Me.notes_group.Text = "Anotações"
        Me.notes_group.Visible = False
        '
        'txt_nota
        '
        Me.txt_nota.Enabled = False
        Me.txt_nota.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota.Location = New System.Drawing.Point(7, 19)
        Me.txt_nota.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(538, 109)
        Me.txt_nota.TabIndex = 3
        '
        'stats_lbl
        '
        Me.stats_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stats_lbl.Enabled = False
        Me.stats_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stats_lbl.Location = New System.Drawing.Point(1319, 14)
        Me.stats_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.stats_lbl.Name = "stats_lbl"
        Me.stats_lbl.Size = New System.Drawing.Size(332, 28)
        Me.stats_lbl.TabIndex = 31
        Me.stats_lbl.TabStop = True
        Me.stats_lbl.Text = "Estatisticas"
        Me.stats_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.stats_lbl.Visible = False
        '
        'loadTableBtn
        '
        Me.loadTableBtn.Image = CType(resources.GetObject("loadTableBtn.Image"), System.Drawing.Image)
        Me.loadTableBtn.InitialImage = Nothing
        Me.loadTableBtn.Location = New System.Drawing.Point(242, 258)
        Me.loadTableBtn.Name = "loadTableBtn"
        Me.loadTableBtn.Size = New System.Drawing.Size(24, 26)
        Me.loadTableBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadTableBtn.TabIndex = 323
        Me.loadTableBtn.TabStop = False
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
        Me.datatable.BackgroundColor = System.Drawing.Color.White
        Me.datatable.CausesValidation = False
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle1
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(290, 46)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.Size = New System.Drawing.Size(1361, 524)
        Me.datatable.TabIndex = 324
        Me.datatable.Visible = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.CausesValidation = False
        Me.Panel2.Controls.Add(Me.color_checkinOut_lbl)
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.color_changeSite_lbl)
        Me.Panel2.Controls.Add(Me.teamAssign_lbl)
        Me.Panel2.Controls.Add(Me.initials_teamAssign_lbl)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Controls.Add(Me.changeSite_lbl)
        Me.Panel2.Controls.Add(Me.initials_changeSite_lbl)
        Me.Panel2.Controls.Add(Me.color_assignedTeam_lbl)
        Me.Panel2.Controls.Add(Me.colorAbsentDay_lbl)
        Me.Panel2.Controls.Add(Me.Label41)
        Me.Panel2.Controls.Add(Me.Label37)
        Me.Panel2.Controls.Add(Me.color_fullDay_lbl)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.color_plannedAbsense_lbl)
        Me.Panel2.Controls.Add(Me.colorNoRecord_lbl)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Controls.Add(Me.color_partialDay_lbl)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.color_holidays_lbl)
        Me.Panel2.Controls.Add(Me.siteBadWeather_lbl)
        Me.Panel2.Controls.Add(Me.initials_siteBadWeather_lbl)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.siteAnnual_lbl)
        Me.Panel2.Controls.Add(Me.initials_siteAnnual_lbl)
        Me.Panel2.Controls.Add(Me.color_weekend_lbl)
        Me.Panel2.Controls.Add(Me.malady_lbl)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.initials_malady_lbl)
        Me.Panel2.Controls.Add(Me.playDay_lbl)
        Me.Panel2.Controls.Add(Me.initials_playDay_lbl)
        Me.Panel2.Controls.Add(Me.holidays_lbl)
        Me.Panel2.Controls.Add(Me.initials_holidays_lbl)
        Me.Panel2.Controls.Add(Me.fullDayAbsent_lbl)
        Me.Panel2.Controls.Add(Me.initials_fullDayAbsent_lbl)
        Me.Panel2.Controls.Add(Me.badWeather_lbl)
        Me.Panel2.Controls.Add(Me.initials_badWeather_lbl)
        Me.Panel2.Controls.Add(Me.fullday_lbl)
        Me.Panel2.Controls.Add(Me.initials_fullDay_lbl)
        Me.Panel2.Controls.Add(Me.initials_partialAbsense_lbl)
        Me.Panel2.Controls.Add(Me.color_doubleRecord_lbl)
        Me.Panel2.Controls.Add(Me.partialAbsense_lbl)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 21)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(252, 453)
        Me.Panel2.TabIndex = 0
        '
        'color_checkinOut_lbl
        '
        Me.color_checkinOut_lbl.AutoSize = True
        Me.color_checkinOut_lbl.CausesValidation = False
        Me.color_checkinOut_lbl.Location = New System.Drawing.Point(33, 345)
        Me.color_checkinOut_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_checkinOut_lbl.Name = "color_checkinOut_lbl"
        Me.color_checkinOut_lbl.Size = New System.Drawing.Size(218, 17)
        Me.color_checkinOut_lbl.TabIndex = 85
        Me.color_checkinOut_lbl.Text = "Checkin / Checkout efectuado"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Gold
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.CausesValidation = False
        Me.Label47.Location = New System.Drawing.Point(6, 343)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(20, 19)
        Me.Label47.TabIndex = 84
        Me.Label47.Text = "  "
        '
        'color_changeSite_lbl
        '
        Me.color_changeSite_lbl.AutoSize = True
        Me.color_changeSite_lbl.CausesValidation = False
        Me.color_changeSite_lbl.Location = New System.Drawing.Point(31, 467)
        Me.color_changeSite_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_changeSite_lbl.Name = "color_changeSite_lbl"
        Me.color_changeSite_lbl.Size = New System.Drawing.Size(130, 17)
        Me.color_changeSite_lbl.TabIndex = 77
        Me.color_changeSite_lbl.Text = "Mudança de Obra"
        '
        'teamAssign_lbl
        '
        Me.teamAssign_lbl.AutoSize = True
        Me.teamAssign_lbl.CausesValidation = False
        Me.teamAssign_lbl.Location = New System.Drawing.Point(35, 176)
        Me.teamAssign_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.teamAssign_lbl.Name = "teamAssign_lbl"
        Me.teamAssign_lbl.Size = New System.Drawing.Size(116, 17)
        Me.teamAssign_lbl.TabIndex = 83
        Me.teamAssign_lbl.Text = "Equipa prevista"
        '
        'initials_teamAssign_lbl
        '
        Me.initials_teamAssign_lbl.AutoSize = True
        Me.initials_teamAssign_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_teamAssign_lbl.CausesValidation = False
        Me.initials_teamAssign_lbl.Location = New System.Drawing.Point(3, 176)
        Me.initials_teamAssign_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_teamAssign_lbl.Name = "initials_teamAssign_lbl"
        Me.initials_teamAssign_lbl.Size = New System.Drawing.Size(25, 17)
        Me.initials_teamAssign_lbl.TabIndex = 82
        Me.initials_teamAssign_lbl.Text = "EP"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.CausesValidation = False
        Me.Label39.Location = New System.Drawing.Point(8, 465)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(20, 19)
        Me.Label39.TabIndex = 76
        Me.Label39.Text = "  "
        '
        'changeSite_lbl
        '
        Me.changeSite_lbl.AutoSize = True
        Me.changeSite_lbl.CausesValidation = False
        Me.changeSite_lbl.Location = New System.Drawing.Point(35, 195)
        Me.changeSite_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.changeSite_lbl.Name = "changeSite_lbl"
        Me.changeSite_lbl.Size = New System.Drawing.Size(128, 17)
        Me.changeSite_lbl.TabIndex = 81
        Me.changeSite_lbl.Text = "Mudança de obra"
        '
        'initials_changeSite_lbl
        '
        Me.initials_changeSite_lbl.AutoSize = True
        Me.initials_changeSite_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_changeSite_lbl.CausesValidation = False
        Me.initials_changeSite_lbl.Location = New System.Drawing.Point(1, 195)
        Me.initials_changeSite_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_changeSite_lbl.Name = "initials_changeSite_lbl"
        Me.initials_changeSite_lbl.Size = New System.Drawing.Size(30, 17)
        Me.initials_changeSite_lbl.TabIndex = 80
        Me.initials_changeSite_lbl.Text = "MO"
        '
        'color_assignedTeam_lbl
        '
        Me.color_assignedTeam_lbl.AutoSize = True
        Me.color_assignedTeam_lbl.CausesValidation = False
        Me.color_assignedTeam_lbl.Location = New System.Drawing.Point(31, 443)
        Me.color_assignedTeam_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_assignedTeam_lbl.Name = "color_assignedTeam_lbl"
        Me.color_assignedTeam_lbl.Size = New System.Drawing.Size(116, 17)
        Me.color_assignedTeam_lbl.TabIndex = 75
        Me.color_assignedTeam_lbl.Text = "Equipa prevista"
        '
        'colorAbsentDay_lbl
        '
        Me.colorAbsentDay_lbl.AutoSize = True
        Me.colorAbsentDay_lbl.CausesValidation = False
        Me.colorAbsentDay_lbl.Location = New System.Drawing.Point(35, 256)
        Me.colorAbsentDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.colorAbsentDay_lbl.Name = "colorAbsentDay_lbl"
        Me.colorAbsentDay_lbl.Size = New System.Drawing.Size(152, 17)
        Me.colorAbsentDay_lbl.TabIndex = 79
        Me.colorAbsentDay_lbl.Text = "Validado dia ausente"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.MistyRose
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.CausesValidation = False
        Me.Label41.Location = New System.Drawing.Point(6, 254)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(20, 19)
        Me.Label41.TabIndex = 78
        Me.Label41.Text = "  "
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.CausesValidation = False
        Me.Label37.Location = New System.Drawing.Point(8, 443)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(20, 19)
        Me.Label37.TabIndex = 74
        Me.Label37.Text = "  "
        '
        'color_fullDay_lbl
        '
        Me.color_fullDay_lbl.AutoSize = True
        Me.color_fullDay_lbl.CausesValidation = False
        Me.color_fullDay_lbl.Location = New System.Drawing.Point(35, 277)
        Me.color_fullDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_fullDay_lbl.Name = "color_fullDay_lbl"
        Me.color_fullDay_lbl.Size = New System.Drawing.Size(161, 17)
        Me.color_fullDay_lbl.TabIndex = 71
        Me.color_fullDay_lbl.Text = "Dia completo validado"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.CausesValidation = False
        Me.Label32.Location = New System.Drawing.Point(6, 276)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(20, 19)
        Me.Label32.TabIndex = 70
        Me.Label32.Text = "  "
        '
        'color_plannedAbsense_lbl
        '
        Me.color_plannedAbsense_lbl.AutoSize = True
        Me.color_plannedAbsense_lbl.CausesValidation = False
        Me.color_plannedAbsense_lbl.Location = New System.Drawing.Point(31, 422)
        Me.color_plannedAbsense_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_plannedAbsense_lbl.Name = "color_plannedAbsense_lbl"
        Me.color_plannedAbsense_lbl.Size = New System.Drawing.Size(137, 17)
        Me.color_plannedAbsense_lbl.TabIndex = 73
        Me.color_plannedAbsense_lbl.Text = "Ausencia planeada"
        '
        'colorNoRecord_lbl
        '
        Me.colorNoRecord_lbl.AutoSize = True
        Me.colorNoRecord_lbl.CausesValidation = False
        Me.colorNoRecord_lbl.Location = New System.Drawing.Point(36, 234)
        Me.colorNoRecord_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.colorNoRecord_lbl.Name = "colorNoRecord_lbl"
        Me.colorNoRecord_lbl.Size = New System.Drawing.Size(93, 17)
        Me.colorNoRecord_lbl.TabIndex = 69
        Me.colorNoRecord_lbl.Text = "Sem registo"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.White
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.CausesValidation = False
        Me.Label30.Location = New System.Drawing.Point(6, 231)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 19)
        Me.Label30.TabIndex = 68
        Me.Label30.Text = "  "
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.CausesValidation = False
        Me.Label34.Location = New System.Drawing.Point(8, 421)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(20, 19)
        Me.Label34.TabIndex = 72
        Me.Label34.Text = "  "
        '
        'color_partialDay_lbl
        '
        Me.color_partialDay_lbl.AutoSize = True
        Me.color_partialDay_lbl.CausesValidation = False
        Me.color_partialDay_lbl.Location = New System.Drawing.Point(35, 300)
        Me.color_partialDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_partialDay_lbl.Name = "color_partialDay_lbl"
        Me.color_partialDay_lbl.Size = New System.Drawing.Size(178, 17)
        Me.color_partialDay_lbl.TabIndex = 65
        Me.color_partialDay_lbl.Text = "Dia validado incompleto "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.CausesValidation = False
        Me.Label26.Location = New System.Drawing.Point(6, 298)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(20, 19)
        Me.Label26.TabIndex = 64
        Me.Label26.Text = "  "
        '
        'color_holidays_lbl
        '
        Me.color_holidays_lbl.AutoSize = True
        Me.color_holidays_lbl.CausesValidation = False
        Me.color_holidays_lbl.Location = New System.Drawing.Point(33, 401)
        Me.color_holidays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_holidays_lbl.Name = "color_holidays_lbl"
        Me.color_holidays_lbl.Size = New System.Drawing.Size(59, 17)
        Me.color_holidays_lbl.TabIndex = 67
        Me.color_holidays_lbl.Text = "Feriado"
        '
        'siteBadWeather_lbl
        '
        Me.siteBadWeather_lbl.AutoSize = True
        Me.siteBadWeather_lbl.CausesValidation = False
        Me.siteBadWeather_lbl.Location = New System.Drawing.Point(35, 158)
        Me.siteBadWeather_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteBadWeather_lbl.Name = "siteBadWeather_lbl"
        Me.siteBadWeather_lbl.Size = New System.Drawing.Size(220, 17)
        Me.siteBadWeather_lbl.TabIndex = 63
        Me.siteBadWeather_lbl.Text = "Encerramento por mau tempo"
        '
        'initials_siteBadWeather_lbl
        '
        Me.initials_siteBadWeather_lbl.AutoSize = True
        Me.initials_siteBadWeather_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_siteBadWeather_lbl.CausesValidation = False
        Me.initials_siteBadWeather_lbl.Location = New System.Drawing.Point(4, 158)
        Me.initials_siteBadWeather_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_siteBadWeather_lbl.Name = "initials_siteBadWeather_lbl"
        Me.initials_siteBadWeather_lbl.Size = New System.Drawing.Size(21, 17)
        Me.initials_siteBadWeather_lbl.TabIndex = 62
        Me.initials_siteBadWeather_lbl.Text = "FI"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.CausesValidation = False
        Me.Label28.Location = New System.Drawing.Point(8, 400)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(20, 19)
        Me.Label28.TabIndex = 66
        Me.Label28.Text = "  "
        '
        'siteAnnual_lbl
        '
        Me.siteAnnual_lbl.AutoSize = True
        Me.siteAnnual_lbl.CausesValidation = False
        Me.siteAnnual_lbl.Location = New System.Drawing.Point(35, 139)
        Me.siteAnnual_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteAnnual_lbl.Name = "siteAnnual_lbl"
        Me.siteAnnual_lbl.Size = New System.Drawing.Size(148, 17)
        Me.siteAnnual_lbl.TabIndex = 61
        Me.siteAnnual_lbl.Text = "Encerramento anual"
        '
        'initials_siteAnnual_lbl
        '
        Me.initials_siteAnnual_lbl.AutoSize = True
        Me.initials_siteAnnual_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_siteAnnual_lbl.CausesValidation = False
        Me.initials_siteAnnual_lbl.Location = New System.Drawing.Point(4, 139)
        Me.initials_siteAnnual_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_siteAnnual_lbl.Name = "initials_siteAnnual_lbl"
        Me.initials_siteAnnual_lbl.Size = New System.Drawing.Size(25, 17)
        Me.initials_siteAnnual_lbl.TabIndex = 60
        Me.initials_siteAnnual_lbl.Text = "FA"
        '
        'color_weekend_lbl
        '
        Me.color_weekend_lbl.AutoSize = True
        Me.color_weekend_lbl.CausesValidation = False
        Me.color_weekend_lbl.Location = New System.Drawing.Point(33, 379)
        Me.color_weekend_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_weekend_lbl.Name = "color_weekend_lbl"
        Me.color_weekend_lbl.Size = New System.Drawing.Size(113, 17)
        Me.color_weekend_lbl.TabIndex = 49
        Me.color_weekend_lbl.Text = "Fim de semana"
        '
        'malady_lbl
        '
        Me.malady_lbl.AutoSize = True
        Me.malady_lbl.CausesValidation = False
        Me.malady_lbl.Location = New System.Drawing.Point(35, 119)
        Me.malady_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.malady_lbl.Name = "malady_lbl"
        Me.malady_lbl.Size = New System.Drawing.Size(60, 17)
        Me.malady_lbl.TabIndex = 59
        Me.malady_lbl.Text = "Doença"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.CausesValidation = False
        Me.Label13.Location = New System.Drawing.Point(8, 378)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 19)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "  "
        '
        'initials_malady_lbl
        '
        Me.initials_malady_lbl.AutoSize = True
        Me.initials_malady_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_malady_lbl.CausesValidation = False
        Me.initials_malady_lbl.Location = New System.Drawing.Point(4, 119)
        Me.initials_malady_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_malady_lbl.Name = "initials_malady_lbl"
        Me.initials_malady_lbl.Size = New System.Drawing.Size(19, 17)
        Me.initials_malady_lbl.TabIndex = 58
        Me.initials_malady_lbl.Text = "M"
        '
        'playDay_lbl
        '
        Me.playDay_lbl.AutoSize = True
        Me.playDay_lbl.CausesValidation = False
        Me.playDay_lbl.Location = New System.Drawing.Point(35, 100)
        Me.playDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.playDay_lbl.Name = "playDay_lbl"
        Me.playDay_lbl.Size = New System.Drawing.Size(59, 17)
        Me.playDay_lbl.TabIndex = 57
        Me.playDay_lbl.Text = "Feriado"
        '
        'initials_playDay_lbl
        '
        Me.initials_playDay_lbl.AutoSize = True
        Me.initials_playDay_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_playDay_lbl.CausesValidation = False
        Me.initials_playDay_lbl.Location = New System.Drawing.Point(4, 100)
        Me.initials_playDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_playDay_lbl.Name = "initials_playDay_lbl"
        Me.initials_playDay_lbl.Size = New System.Drawing.Size(18, 17)
        Me.initials_playDay_lbl.TabIndex = 56
        Me.initials_playDay_lbl.Text = "C"
        '
        'holidays_lbl
        '
        Me.holidays_lbl.AutoSize = True
        Me.holidays_lbl.CausesValidation = False
        Me.holidays_lbl.Location = New System.Drawing.Point(35, 80)
        Me.holidays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.holidays_lbl.Name = "holidays_lbl"
        Me.holidays_lbl.Size = New System.Drawing.Size(49, 17)
        Me.holidays_lbl.TabIndex = 55
        Me.holidays_lbl.Text = "Férias"
        '
        'initials_holidays_lbl
        '
        Me.initials_holidays_lbl.AutoSize = True
        Me.initials_holidays_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_holidays_lbl.CausesValidation = False
        Me.initials_holidays_lbl.Location = New System.Drawing.Point(4, 80)
        Me.initials_holidays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_holidays_lbl.Name = "initials_holidays_lbl"
        Me.initials_holidays_lbl.Size = New System.Drawing.Size(18, 17)
        Me.initials_holidays_lbl.TabIndex = 54
        Me.initials_holidays_lbl.Text = "V"
        '
        'fullDayAbsent_lbl
        '
        Me.fullDayAbsent_lbl.AutoSize = True
        Me.fullDayAbsent_lbl.CausesValidation = False
        Me.fullDayAbsent_lbl.Location = New System.Drawing.Point(35, 60)
        Me.fullDayAbsent_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fullDayAbsent_lbl.Name = "fullDayAbsent_lbl"
        Me.fullDayAbsent_lbl.Size = New System.Drawing.Size(144, 17)
        Me.fullDayAbsent_lbl.TabIndex = 53
        Me.fullDayAbsent_lbl.Text = "Faltou dia completo"
        '
        'initials_fullDayAbsent_lbl
        '
        Me.initials_fullDayAbsent_lbl.AutoSize = True
        Me.initials_fullDayAbsent_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_fullDayAbsent_lbl.CausesValidation = False
        Me.initials_fullDayAbsent_lbl.Location = New System.Drawing.Point(4, 60)
        Me.initials_fullDayAbsent_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_fullDayAbsent_lbl.Name = "initials_fullDayAbsent_lbl"
        Me.initials_fullDayAbsent_lbl.Size = New System.Drawing.Size(18, 17)
        Me.initials_fullDayAbsent_lbl.TabIndex = 52
        Me.initials_fullDayAbsent_lbl.Text = "A"
        '
        'badWeather_lbl
        '
        Me.badWeather_lbl.AutoSize = True
        Me.badWeather_lbl.CausesValidation = False
        Me.badWeather_lbl.Location = New System.Drawing.Point(36, 41)
        Me.badWeather_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.badWeather_lbl.Name = "badWeather_lbl"
        Me.badWeather_lbl.Size = New System.Drawing.Size(86, 17)
        Me.badWeather_lbl.TabIndex = 51
        Me.badWeather_lbl.Text = "Mau tempo"
        '
        'initials_badWeather_lbl
        '
        Me.initials_badWeather_lbl.AutoSize = True
        Me.initials_badWeather_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_badWeather_lbl.CausesValidation = False
        Me.initials_badWeather_lbl.Location = New System.Drawing.Point(6, 41)
        Me.initials_badWeather_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_badWeather_lbl.Name = "initials_badWeather_lbl"
        Me.initials_badWeather_lbl.Size = New System.Drawing.Size(13, 17)
        Me.initials_badWeather_lbl.TabIndex = 50
        Me.initials_badWeather_lbl.Text = "I"
        '
        'fullday_lbl
        '
        Me.fullday_lbl.AutoSize = True
        Me.fullday_lbl.CausesValidation = False
        Me.fullday_lbl.Location = New System.Drawing.Point(35, 0)
        Me.fullday_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fullday_lbl.Name = "fullday_lbl"
        Me.fullday_lbl.Size = New System.Drawing.Size(99, 17)
        Me.fullday_lbl.TabIndex = 43
        Me.fullday_lbl.Text = "Dia completo"
        '
        'initials_fullDay_lbl
        '
        Me.initials_fullDay_lbl.AutoSize = True
        Me.initials_fullDay_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_fullDay_lbl.CausesValidation = False
        Me.initials_fullDay_lbl.Location = New System.Drawing.Point(4, 0)
        Me.initials_fullDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_fullDay_lbl.Name = "initials_fullDay_lbl"
        Me.initials_fullDay_lbl.Size = New System.Drawing.Size(16, 17)
        Me.initials_fullDay_lbl.TabIndex = 42
        Me.initials_fullDay_lbl.Text = "P"
        '
        'initials_partialAbsense_lbl
        '
        Me.initials_partialAbsense_lbl.AutoSize = True
        Me.initials_partialAbsense_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_partialAbsense_lbl.CausesValidation = False
        Me.initials_partialAbsense_lbl.Location = New System.Drawing.Point(4, 21)
        Me.initials_partialAbsense_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_partialAbsense_lbl.Name = "initials_partialAbsense_lbl"
        Me.initials_partialAbsense_lbl.Size = New System.Drawing.Size(17, 17)
        Me.initials_partialAbsense_lbl.TabIndex = 44
        Me.initials_partialAbsense_lbl.Text = "2"
        '
        'color_doubleRecord_lbl
        '
        Me.color_doubleRecord_lbl.AutoSize = True
        Me.color_doubleRecord_lbl.CausesValidation = False
        Me.color_doubleRecord_lbl.Location = New System.Drawing.Point(33, 321)
        Me.color_doubleRecord_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_doubleRecord_lbl.Name = "color_doubleRecord_lbl"
        Me.color_doubleRecord_lbl.Size = New System.Drawing.Size(132, 17)
        Me.color_doubleRecord_lbl.TabIndex = 47
        Me.color_doubleRecord_lbl.Text = "Registo duplicado"
        '
        'partialAbsense_lbl
        '
        Me.partialAbsense_lbl.AutoSize = True
        Me.partialAbsense_lbl.CausesValidation = False
        Me.partialAbsense_lbl.Location = New System.Drawing.Point(35, 21)
        Me.partialAbsense_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.partialAbsense_lbl.Name = "partialAbsense_lbl"
        Me.partialAbsense_lbl.Size = New System.Drawing.Size(73, 17)
        Me.partialAbsense_lbl.TabIndex = 45
        Me.partialAbsense_lbl.Text = "Faltou 2h"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Red
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.CausesValidation = False
        Me.Label11.Location = New System.Drawing.Point(6, 320)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 19)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "  "
        '
        'GroupBox_legenda
        '
        Me.GroupBox_legenda.CausesValidation = False
        Me.GroupBox_legenda.Controls.Add(Me.Panel2)
        Me.GroupBox_legenda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_legenda.Location = New System.Drawing.Point(10, 291)
        Me.GroupBox_legenda.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Name = "GroupBox_legenda"
        Me.GroupBox_legenda.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Size = New System.Drawing.Size(260, 478)
        Me.GroupBox_legenda.TabIndex = 34
        Me.GroupBox_legenda.TabStop = False
        Me.GroupBox_legenda.Text = "Legenda"
        Me.GroupBox_legenda.Visible = False
        '
        'tableSettingsBtn
        '
        Me.tableSettingsBtn.Image = CType(resources.GetObject("tableSettingsBtn.Image"), System.Drawing.Image)
        Me.tableSettingsBtn.InitialImage = Nothing
        Me.tableSettingsBtn.Location = New System.Drawing.Point(186, 258)
        Me.tableSettingsBtn.Name = "tableSettingsBtn"
        Me.tableSettingsBtn.Size = New System.Drawing.Size(24, 26)
        Me.tableSettingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tableSettingsBtn.TabIndex = 325
        Me.tableSettingsBtn.TabStop = False
        '
        'multipleSelectionBtn
        '
        Me.multipleSelectionBtn.Image = CType(resources.GetObject("multipleSelectionBtn.Image"), System.Drawing.Image)
        Me.multipleSelectionBtn.InitialImage = Nothing
        Me.multipleSelectionBtn.Location = New System.Drawing.Point(12, 258)
        Me.multipleSelectionBtn.Name = "multipleSelectionBtn"
        Me.multipleSelectionBtn.Size = New System.Drawing.Size(24, 26)
        Me.multipleSelectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.multipleSelectionBtn.TabIndex = 326
        Me.multipleSelectionBtn.TabStop = False
        '
        'duplicateRecords
        '
        Me.duplicateRecords.AutoSize = True
        Me.duplicateRecords.BackColor = System.Drawing.Color.White
        Me.duplicateRecords.CausesValidation = False
        Me.duplicateRecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicateRecords.ForeColor = System.Drawing.Color.Black
        Me.duplicateRecords.Location = New System.Drawing.Point(123, 54)
        Me.duplicateRecords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.duplicateRecords.Name = "duplicateRecords"
        Me.duplicateRecords.Size = New System.Drawing.Size(218, 17)
        Me.duplicateRecords.TabIndex = 46
        Me.duplicateRecords.Text = "Registo duplicado: outra obra"
        '
        'logger_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1673, 784)
        Me.Controls.Add(Me.multipleSelectionBtn)
        Me.Controls.Add(Me.tableSettingsBtn)
        Me.Controls.Add(Me.datatable)
        Me.Controls.Add(Me.loadTableBtn)
        Me.Controls.Add(Me.GroupBox_legenda)
        Me.Controls.Add(Me.stats_lbl)
        Me.Controls.Add(Me.notes_group)
        Me.Controls.Add(Me.GroupBox_detalhes)
        Me.Controls.Add(Me.calendar_log)
        Me.Controls.Add(Me.combo_company)
        Me.Controls.Add(Me.company_lbl)
        Me.Controls.Add(Me.combo_site)
        Me.Controls.Add(Me.site_lbl)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "logger_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registo de presenças"
        Me.GroupBox_detalhes.ResumeLayout(False)
        Me.GroupBox_detalhes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.notes_group.ResumeLayout(False)
        Me.notes_group.PerformLayout()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox_legenda.ResumeLayout(False)
        Me.GroupBox_legenda.PerformLayout()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.multipleSelectionBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents site_lbl As Label
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents combo_company As ComboBox
    Friend WithEvents company_lbl As Label
    Friend WithEvents calendar_log As MonthCalendar
    Friend WithEvents GroupBox_detalhes As GroupBox
    Friend WithEvents gravarnota_lbl As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents detalhes_validacao As Label
    Friend WithEvents detalhes_emergencia As Label
    Friend WithEvents detalhes_obra As Label
    Friend WithEvents detalhes_empresa As Label
    Friend WithEvents detalhes_cat As Label
    Friend WithEvents detalhes_checkout As Label
    Friend WithEvents detalhes_checkin As Label
    Friend WithEvents detalhes_nfc As Label
    Friend WithEvents detalhes_contacto As Label
    Friend WithEvents detalhes_nome As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents notes_group As GroupBox
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents stats_lbl As LinkLabel
    Friend WithEvents loadTableBtn As PictureBox
    Friend WithEvents datatable As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents color_checkinOut_lbl As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents color_changeSite_lbl As Label
    Friend WithEvents teamAssign_lbl As Label
    Friend WithEvents initials_teamAssign_lbl As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents changeSite_lbl As Label
    Friend WithEvents initials_changeSite_lbl As Label
    Friend WithEvents color_assignedTeam_lbl As Label
    Friend WithEvents colorAbsentDay_lbl As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents color_fullDay_lbl As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents color_plannedAbsense_lbl As Label
    Friend WithEvents colorNoRecord_lbl As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents color_partialDay_lbl As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents color_holidays_lbl As Label
    Friend WithEvents siteBadWeather_lbl As Label
    Friend WithEvents initials_siteBadWeather_lbl As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents siteAnnual_lbl As Label
    Friend WithEvents initials_siteAnnual_lbl As Label
    Friend WithEvents color_weekend_lbl As Label
    Friend WithEvents malady_lbl As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents initials_malady_lbl As Label
    Friend WithEvents playDay_lbl As Label
    Friend WithEvents initials_playDay_lbl As Label
    Friend WithEvents holidays_lbl As Label
    Friend WithEvents initials_holidays_lbl As Label
    Friend WithEvents fullDayAbsent_lbl As Label
    Friend WithEvents initials_fullDayAbsent_lbl As Label
    Friend WithEvents badWeather_lbl As Label
    Friend WithEvents initials_badWeather_lbl As Label
    Friend WithEvents fullday_lbl As Label
    Friend WithEvents initials_fullDay_lbl As Label
    Friend WithEvents initials_partialAbsense_lbl As Label
    Friend WithEvents color_doubleRecord_lbl As Label
    Friend WithEvents partialAbsense_lbl As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox_legenda As GroupBox
    Friend WithEvents tableSettingsBtn As PictureBox
    Friend WithEvents multipleSelectionBtn As PictureBox
    Friend WithEvents worker_photo As PictureBox
    Friend WithEvents duplicateRecords As Label
End Class
