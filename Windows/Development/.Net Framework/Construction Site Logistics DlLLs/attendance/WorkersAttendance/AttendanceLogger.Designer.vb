Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class attendanceLoggerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(attendanceLoggerForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.combo_company = New System.Windows.Forms.ComboBox()
        Me.company_lbl = New System.Windows.Forms.Label()
        Me.GroupBox_detalhes = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.category_today = New System.Windows.Forms.Label()
        Me.reasonLateValidation_lbl = New System.Windows.Forms.Label()
        Me.reasonLateValidation = New System.Windows.Forms.TextBox()
        Me.duplicateRecords = New System.Windows.Forms.Label()
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
        Me.GroupBoxNotes = New System.Windows.Forms.GroupBox()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.bottomPanel = New System.Windows.Forms.Panel()
        Me.bottomSliderBand = New System.Windows.Forms.Panel()
        Me.bottomToggleBtn = New System.Windows.Forms.PictureBox()
        Me.TablePanel = New System.Windows.Forms.Panel()
        Me.metricsBtn = New System.Windows.Forms.PictureBox()
        Me.tableSettingsBtn = New System.Windows.Forms.PictureBox()
        Me.loadTableBtn = New System.Windows.Forms.PictureBox()
        Me.closeMonthAttendanceBtn = New System.Windows.Forms.PictureBox()
        Me.GroupBox_legenda = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.color_checkinOut_lbl = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.color_changeSite_lbl = New System.Windows.Forms.Label()
        Me.teamAssign_lbl = New System.Windows.Forms.Label()
        Me.initials_teamAssign_lbl = New System.Windows.Forms.Label()
        Me.boxChangeSite = New System.Windows.Forms.Label()
        Me.changeSite_lbl = New System.Windows.Forms.Label()
        Me.initials_changeSite_lbl = New System.Windows.Forms.Label()
        Me.color_assignedTeam_lbl = New System.Windows.Forms.Label()
        Me.colorAbsentDay_lbl = New System.Windows.Forms.Label()
        Me.boxAbsentDay = New System.Windows.Forms.Label()
        Me.boxPlannedTeam = New System.Windows.Forms.Label()
        Me.color_fullDay_lbl = New System.Windows.Forms.Label()
        Me.boxDayValidated = New System.Windows.Forms.Label()
        Me.color_plannedAbsense_lbl = New System.Windows.Forms.Label()
        Me.colorNoRecord_lbl = New System.Windows.Forms.Label()
        Me.boxNoRecord = New System.Windows.Forms.Label()
        Me.boxPlannedAbsence = New System.Windows.Forms.Label()
        Me.color_partialDay_lbl = New System.Windows.Forms.Label()
        Me.boxDayIncomplete = New System.Windows.Forms.Label()
        Me.color_holidays_lbl = New System.Windows.Forms.Label()
        Me.siteBadWeather_lbl = New System.Windows.Forms.Label()
        Me.initials_siteBadWeather_lbl = New System.Windows.Forms.Label()
        Me.boxPlayday = New System.Windows.Forms.Label()
        Me.siteAnnual_lbl = New System.Windows.Forms.Label()
        Me.initials_siteAnnual_lbl = New System.Windows.Forms.Label()
        Me.color_weekend_lbl = New System.Windows.Forms.Label()
        Me.malady_lbl = New System.Windows.Forms.Label()
        Me.boxWeekend = New System.Windows.Forms.Label()
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
        Me.boxDuplicate = New System.Windows.Forms.Label()
        Me.lateralPanel = New System.Windows.Forms.Panel()
        Me.ListBoxSite = New System.Windows.Forms.ListBox()
        Me.duplicatesBtn = New System.Windows.Forms.PictureBox()
        Me.loadSitesBtn = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.sideToggleBtn = New System.Windows.Forms.PictureBox()
        Me.date_lbl = New System.Windows.Forms.Label()
        Me.calendar_log = New System.Windows.Forms.DateTimePicker()
        Me.loadForm = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_detalhes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxNotes.SuspendLayout()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomPanel.SuspendLayout()
        Me.bottomSliderBand.SuspendLayout()
        CType(Me.bottomToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TablePanel.SuspendLayout()
        CType(Me.metricsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.closeMonthAttendanceBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_legenda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.lateralPanel.SuspendLayout()
        CType(Me.duplicatesBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadSitesBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(32, 9)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(66, 25)
        Me.site_lbl.TabIndex = 0
        Me.site_lbl.Text = "Obra"
        '
        'combo_company
        '
        Me.combo_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_company.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_company.FormattingEnabled = True
        Me.combo_company.Location = New System.Drawing.Point(31, 293)
        Me.combo_company.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_company.Name = "combo_company"
        Me.combo_company.Size = New System.Drawing.Size(227, 37)
        Me.combo_company.TabIndex = 6
        '
        'company_lbl
        '
        Me.company_lbl.AutoSize = True
        Me.company_lbl.CausesValidation = False
        Me.company_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.company_lbl.Location = New System.Drawing.Point(28, 273)
        Me.company_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.company_lbl.Name = "company_lbl"
        Me.company_lbl.Size = New System.Drawing.Size(109, 25)
        Me.company_lbl.TabIndex = 5
        Me.company_lbl.Text = "Empresa"
        '
        'GroupBox_detalhes
        '
        Me.GroupBox_detalhes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_detalhes.CausesValidation = False
        Me.GroupBox_detalhes.Controls.Add(Me.Panel1)
        Me.GroupBox_detalhes.Location = New System.Drawing.Point(620, 37)
        Me.GroupBox_detalhes.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalhes.Name = "GroupBox_detalhes"
        Me.GroupBox_detalhes.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_detalhes.Size = New System.Drawing.Size(771, 181)
        Me.GroupBox_detalhes.TabIndex = 22
        Me.GroupBox_detalhes.TabStop = False
        Me.GroupBox_detalhes.Text = "Detalhes 01-01-2019"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.category_today)
        Me.Panel1.Controls.Add(Me.reasonLateValidation_lbl)
        Me.Panel1.Controls.Add(Me.reasonLateValidation)
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
        Me.Panel1.Location = New System.Drawing.Point(4, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(763, 149)
        Me.Panel1.TabIndex = 0
        '
        'category_today
        '
        Me.category_today.AutoSize = True
        Me.category_today.BackColor = System.Drawing.Color.White
        Me.category_today.CausesValidation = False
        Me.category_today.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.category_today.ForeColor = System.Drawing.Color.Black
        Me.category_today.Location = New System.Drawing.Point(119, 144)
        Me.category_today.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.category_today.Name = "category_today"
        Me.category_today.Size = New System.Drawing.Size(193, 20)
        Me.category_today.TabIndex = 64
        Me.category_today.Text = "em funcoes: pedreiro"
        '
        'reasonLateValidation_lbl
        '
        Me.reasonLateValidation_lbl.AutoSize = True
        Me.reasonLateValidation_lbl.BackColor = System.Drawing.Color.White
        Me.reasonLateValidation_lbl.CausesValidation = False
        Me.reasonLateValidation_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reasonLateValidation_lbl.ForeColor = System.Drawing.Color.Black
        Me.reasonLateValidation_lbl.Location = New System.Drawing.Point(7, 224)
        Me.reasonLateValidation_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.reasonLateValidation_lbl.Name = "reasonLateValidation_lbl"
        Me.reasonLateValidation_lbl.Size = New System.Drawing.Size(221, 20)
        Me.reasonLateValidation_lbl.TabIndex = 63
        Me.reasonLateValidation_lbl.Text = "Justificacao da validacao"
        '
        'reasonLateValidation
        '
        Me.reasonLateValidation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reasonLateValidation.Location = New System.Drawing.Point(11, 248)
        Me.reasonLateValidation.Margin = New System.Windows.Forms.Padding(4)
        Me.reasonLateValidation.Multiline = True
        Me.reasonLateValidation.Name = "reasonLateValidation"
        Me.reasonLateValidation.ReadOnly = True
        Me.reasonLateValidation.Size = New System.Drawing.Size(611, 97)
        Me.reasonLateValidation.TabIndex = 62
        '
        'duplicateRecords
        '
        Me.duplicateRecords.AutoSize = True
        Me.duplicateRecords.BackColor = System.Drawing.Color.White
        Me.duplicateRecords.CausesValidation = False
        Me.duplicateRecords.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicateRecords.ForeColor = System.Drawing.Color.Black
        Me.duplicateRecords.Location = New System.Drawing.Point(119, 53)
        Me.duplicateRecords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.duplicateRecords.Name = "duplicateRecords"
        Me.duplicateRecords.Size = New System.Drawing.Size(265, 20)
        Me.duplicateRecords.TabIndex = 61
        Me.duplicateRecords.Text = "Registo duplicado: outra obra"
        '
        'worker_photo
        '
        Me.worker_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.worker_photo.Image = CType(resources.GetObject("worker_photo.Image"), System.Drawing.Image)
        Me.worker_photo.InitialImage = Nothing
        Me.worker_photo.Location = New System.Drawing.Point(11, 13)
        Me.worker_photo.Name = "worker_photo"
        Me.worker_photo.Size = New System.Drawing.Size(101, 111)
        Me.worker_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.worker_photo.TabIndex = 60
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
        Me.detalhes_validacao.Location = New System.Drawing.Point(490, 186)
        Me.detalhes_validacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_validacao.Name = "detalhes_validacao"
        Me.detalhes_validacao.Size = New System.Drawing.Size(200, 20)
        Me.detalhes_validacao.TabIndex = 59
        Me.detalhes_validacao.Text = "Validação: Intempérie"
        '
        'detalhes_emergencia
        '
        Me.detalhes_emergencia.AutoSize = True
        Me.detalhes_emergencia.BackColor = System.Drawing.Color.White
        Me.detalhes_emergencia.CausesValidation = False
        Me.detalhes_emergencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_emergencia.ForeColor = System.Drawing.Color.Black
        Me.detalhes_emergencia.Location = New System.Drawing.Point(7, 164)
        Me.detalhes_emergencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_emergencia.Name = "detalhes_emergencia"
        Me.detalhes_emergencia.Size = New System.Drawing.Size(288, 20)
        Me.detalhes_emergencia.TabIndex = 58
        Me.detalhes_emergencia.Text = "Emergência: +351 933 651 316"
        '
        'detalhes_obra
        '
        Me.detalhes_obra.AutoSize = True
        Me.detalhes_obra.BackColor = System.Drawing.Color.White
        Me.detalhes_obra.CausesValidation = False
        Me.detalhes_obra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_obra.ForeColor = System.Drawing.Color.Black
        Me.detalhes_obra.Location = New System.Drawing.Point(119, 32)
        Me.detalhes_obra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_obra.Name = "detalhes_obra"
        Me.detalhes_obra.Size = New System.Drawing.Size(124, 20)
        Me.detalhes_obra.TabIndex = 57
        Me.detalhes_obra.Text = "Obra: Perwez"
        '
        'detalhes_empresa
        '
        Me.detalhes_empresa.AutoSize = True
        Me.detalhes_empresa.BackColor = System.Drawing.Color.White
        Me.detalhes_empresa.CausesValidation = False
        Me.detalhes_empresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_empresa.ForeColor = System.Drawing.Color.Black
        Me.detalhes_empresa.Location = New System.Drawing.Point(119, 99)
        Me.detalhes_empresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_empresa.Name = "detalhes_empresa"
        Me.detalhes_empresa.Size = New System.Drawing.Size(274, 20)
        Me.detalhes_empresa.TabIndex = 56
        Me.detalhes_empresa.Text = "Empresa: Quality Construction"
        '
        'detalhes_cat
        '
        Me.detalhes_cat.AutoSize = True
        Me.detalhes_cat.BackColor = System.Drawing.Color.White
        Me.detalhes_cat.CausesValidation = False
        Me.detalhes_cat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_cat.ForeColor = System.Drawing.Color.Black
        Me.detalhes_cat.Location = New System.Drawing.Point(119, 120)
        Me.detalhes_cat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_cat.Name = "detalhes_cat"
        Me.detalhes_cat.Size = New System.Drawing.Size(280, 20)
        Me.detalhes_cat.TabIndex = 55
        Me.detalhes_cat.Text = "Categoria profissional: pedreiro"
        '
        'detalhes_checkout
        '
        Me.detalhes_checkout.AutoSize = True
        Me.detalhes_checkout.BackColor = System.Drawing.Color.White
        Me.detalhes_checkout.CausesValidation = False
        Me.detalhes_checkout.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_checkout.ForeColor = System.Drawing.Color.Black
        Me.detalhes_checkout.Location = New System.Drawing.Point(487, 144)
        Me.detalhes_checkout.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_checkout.Name = "detalhes_checkout"
        Me.detalhes_checkout.Size = New System.Drawing.Size(203, 20)
        Me.detalhes_checkout.TabIndex = 54
        Me.detalhes_checkout.Text = "Checkout: s/ checkout"
        '
        'detalhes_checkin
        '
        Me.detalhes_checkin.AutoSize = True
        Me.detalhes_checkin.BackColor = System.Drawing.Color.White
        Me.detalhes_checkin.CausesValidation = False
        Me.detalhes_checkin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_checkin.ForeColor = System.Drawing.Color.Black
        Me.detalhes_checkin.Location = New System.Drawing.Point(487, 166)
        Me.detalhes_checkin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_checkin.Name = "detalhes_checkin"
        Me.detalhes_checkin.Size = New System.Drawing.Size(179, 20)
        Me.detalhes_checkin.TabIndex = 53
        Me.detalhes_checkin.Text = "Checkin: s/ checkin"
        '
        'detalhes_nfc
        '
        Me.detalhes_nfc.AutoSize = True
        Me.detalhes_nfc.BackColor = System.Drawing.Color.White
        Me.detalhes_nfc.CausesValidation = False
        Me.detalhes_nfc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_nfc.ForeColor = System.Drawing.Color.Black
        Me.detalhes_nfc.Location = New System.Drawing.Point(487, 120)
        Me.detalhes_nfc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_nfc.Name = "detalhes_nfc"
        Me.detalhes_nfc.Size = New System.Drawing.Size(240, 20)
        Me.detalhes_nfc.TabIndex = 52
        Me.detalhes_nfc.Text = "Codigo cartao: 123456789"
        '
        'detalhes_contacto
        '
        Me.detalhes_contacto.AutoSize = True
        Me.detalhes_contacto.BackColor = System.Drawing.Color.White
        Me.detalhes_contacto.CausesValidation = False
        Me.detalhes_contacto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_contacto.ForeColor = System.Drawing.Color.Black
        Me.detalhes_contacto.Location = New System.Drawing.Point(7, 186)
        Me.detalhes_contacto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_contacto.Name = "detalhes_contacto"
        Me.detalhes_contacto.Size = New System.Drawing.Size(260, 20)
        Me.detalhes_contacto.TabIndex = 51
        Me.detalhes_contacto.Text = "contacto: +351 933 651 316"
        '
        'detalhes_nome
        '
        Me.detalhes_nome.AutoSize = True
        Me.detalhes_nome.BackColor = System.Drawing.Color.White
        Me.detalhes_nome.CausesValidation = False
        Me.detalhes_nome.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detalhes_nome.ForeColor = System.Drawing.Color.Black
        Me.detalhes_nome.Location = New System.Drawing.Point(119, 13)
        Me.detalhes_nome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.detalhes_nome.Name = "detalhes_nome"
        Me.detalhes_nome.Size = New System.Drawing.Size(238, 20)
        Me.detalhes_nome.TabIndex = 50
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
        Me.gravarnota_lbl.Size = New System.Drawing.Size(110, 20)
        Me.gravarnota_lbl.TabIndex = 24
        Me.gravarnota_lbl.TabStop = True
        Me.gravarnota_lbl.Text = "Gravar nota"
        Me.gravarnota_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'GroupBoxNotes
        '
        Me.GroupBoxNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxNotes.Controls.Add(Me.gravarnota_lbl)
        Me.GroupBoxNotes.Controls.Add(Me.txt_nota)
        Me.GroupBoxNotes.Location = New System.Drawing.Point(6, 37)
        Me.GroupBoxNotes.Name = "GroupBoxNotes"
        Me.GroupBoxNotes.Size = New System.Drawing.Size(606, 181)
        Me.GroupBoxNotes.TabIndex = 30
        Me.GroupBoxNotes.TabStop = False
        Me.GroupBoxNotes.Text = "Anotações"
        '
        'txt_nota
        '
        Me.txt_nota.Enabled = False
        Me.txt_nota.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nota.Location = New System.Drawing.Point(7, 31)
        Me.txt_nota.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(538, 97)
        Me.txt_nota.TabIndex = 3
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
        Me.datatable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.datatable.Location = New System.Drawing.Point(7, 28)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.Size = New System.Drawing.Size(1383, 526)
        Me.datatable.TabIndex = 324
        '
        'bottomPanel
        '
        Me.bottomPanel.Controls.Add(Me.GroupBoxNotes)
        Me.bottomPanel.Controls.Add(Me.GroupBox_detalhes)
        Me.bottomPanel.Controls.Add(Me.bottomSliderBand)
        Me.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomPanel.Location = New System.Drawing.Point(270, 567)
        Me.bottomPanel.Name = "bottomPanel"
        Me.bottomPanel.Size = New System.Drawing.Size(1403, 227)
        Me.bottomPanel.TabIndex = 330
        Me.bottomPanel.Visible = False
        '
        'bottomSliderBand
        '
        Me.bottomSliderBand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bottomSliderBand.BackColor = System.Drawing.Color.Ivory
        Me.bottomSliderBand.Controls.Add(Me.bottomToggleBtn)
        Me.bottomSliderBand.Location = New System.Drawing.Point(0, 0)
        Me.bottomSliderBand.Name = "bottomSliderBand"
        Me.bottomSliderBand.Size = New System.Drawing.Size(1403, 28)
        Me.bottomSliderBand.TabIndex = 365
        '
        'bottomToggleBtn
        '
        Me.bottomToggleBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bottomToggleBtn.Image = CType(resources.GetObject("bottomToggleBtn.Image"), System.Drawing.Image)
        Me.bottomToggleBtn.InitialImage = Nothing
        Me.bottomToggleBtn.Location = New System.Drawing.Point(1367, 1)
        Me.bottomToggleBtn.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.bottomToggleBtn.Name = "bottomToggleBtn"
        Me.bottomToggleBtn.Size = New System.Drawing.Size(24, 26)
        Me.bottomToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.bottomToggleBtn.TabIndex = 364
        Me.bottomToggleBtn.TabStop = False
        '
        'TablePanel
        '
        Me.TablePanel.Controls.Add(Me.datatable)
        Me.TablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TablePanel.Location = New System.Drawing.Point(270, 0)
        Me.TablePanel.Name = "TablePanel"
        Me.TablePanel.Size = New System.Drawing.Size(1403, 567)
        Me.TablePanel.TabIndex = 331
        Me.TablePanel.Visible = False
        '
        'metricsBtn
        '
        Me.metricsBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metricsBtn.Enabled = False
        Me.metricsBtn.Image = CType(resources.GetObject("metricsBtn.Image"), System.Drawing.Image)
        Me.metricsBtn.InitialImage = Nothing
        Me.metricsBtn.Location = New System.Drawing.Point(33, 371)
        Me.metricsBtn.Name = "metricsBtn"
        Me.metricsBtn.Size = New System.Drawing.Size(24, 26)
        Me.metricsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.metricsBtn.TabIndex = 365
        Me.metricsBtn.TabStop = False
        '
        'tableSettingsBtn
        '
        Me.tableSettingsBtn.Image = CType(resources.GetObject("tableSettingsBtn.Image"), System.Drawing.Image)
        Me.tableSettingsBtn.InitialImage = Nothing
        Me.tableSettingsBtn.Location = New System.Drawing.Point(174, 371)
        Me.tableSettingsBtn.Name = "tableSettingsBtn"
        Me.tableSettingsBtn.Size = New System.Drawing.Size(24, 26)
        Me.tableSettingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tableSettingsBtn.TabIndex = 325
        Me.tableSettingsBtn.TabStop = False
        '
        'loadTableBtn
        '
        Me.loadTableBtn.Image = CType(resources.GetObject("loadTableBtn.Image"), System.Drawing.Image)
        Me.loadTableBtn.InitialImage = Nothing
        Me.loadTableBtn.Location = New System.Drawing.Point(234, 371)
        Me.loadTableBtn.Name = "loadTableBtn"
        Me.loadTableBtn.Size = New System.Drawing.Size(24, 26)
        Me.loadTableBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadTableBtn.TabIndex = 323
        Me.loadTableBtn.TabStop = False
        '
        'closeMonthAttendanceBtn
        '
        Me.closeMonthAttendanceBtn.Image = CType(resources.GetObject("closeMonthAttendanceBtn.Image"), System.Drawing.Image)
        Me.closeMonthAttendanceBtn.InitialImage = Nothing
        Me.closeMonthAttendanceBtn.Location = New System.Drawing.Point(101, 371)
        Me.closeMonthAttendanceBtn.Name = "closeMonthAttendanceBtn"
        Me.closeMonthAttendanceBtn.Size = New System.Drawing.Size(24, 26)
        Me.closeMonthAttendanceBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.closeMonthAttendanceBtn.TabIndex = 327
        Me.closeMonthAttendanceBtn.TabStop = False
        '
        'GroupBox_legenda
        '
        Me.GroupBox_legenda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_legenda.CausesValidation = False
        Me.GroupBox_legenda.Controls.Add(Me.Panel2)
        Me.GroupBox_legenda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_legenda.Location = New System.Drawing.Point(31, 404)
        Me.GroupBox_legenda.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Name = "GroupBox_legenda"
        Me.GroupBox_legenda.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Size = New System.Drawing.Size(227, 380)
        Me.GroupBox_legenda.TabIndex = 34
        Me.GroupBox_legenda.TabStop = False
        Me.GroupBox_legenda.Text = "Legenda"
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
        Me.Panel2.Controls.Add(Me.boxChangeSite)
        Me.Panel2.Controls.Add(Me.changeSite_lbl)
        Me.Panel2.Controls.Add(Me.initials_changeSite_lbl)
        Me.Panel2.Controls.Add(Me.color_assignedTeam_lbl)
        Me.Panel2.Controls.Add(Me.colorAbsentDay_lbl)
        Me.Panel2.Controls.Add(Me.boxAbsentDay)
        Me.Panel2.Controls.Add(Me.boxPlannedTeam)
        Me.Panel2.Controls.Add(Me.color_fullDay_lbl)
        Me.Panel2.Controls.Add(Me.boxDayValidated)
        Me.Panel2.Controls.Add(Me.color_plannedAbsense_lbl)
        Me.Panel2.Controls.Add(Me.colorNoRecord_lbl)
        Me.Panel2.Controls.Add(Me.boxNoRecord)
        Me.Panel2.Controls.Add(Me.boxPlannedAbsence)
        Me.Panel2.Controls.Add(Me.color_partialDay_lbl)
        Me.Panel2.Controls.Add(Me.boxDayIncomplete)
        Me.Panel2.Controls.Add(Me.color_holidays_lbl)
        Me.Panel2.Controls.Add(Me.siteBadWeather_lbl)
        Me.Panel2.Controls.Add(Me.initials_siteBadWeather_lbl)
        Me.Panel2.Controls.Add(Me.boxPlayday)
        Me.Panel2.Controls.Add(Me.siteAnnual_lbl)
        Me.Panel2.Controls.Add(Me.initials_siteAnnual_lbl)
        Me.Panel2.Controls.Add(Me.color_weekend_lbl)
        Me.Panel2.Controls.Add(Me.malady_lbl)
        Me.Panel2.Controls.Add(Me.boxWeekend)
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
        Me.Panel2.Controls.Add(Me.boxDuplicate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 25)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(219, 351)
        Me.Panel2.TabIndex = 0
        '
        'color_checkinOut_lbl
        '
        Me.color_checkinOut_lbl.AutoSize = True
        Me.color_checkinOut_lbl.CausesValidation = False
        Me.color_checkinOut_lbl.Location = New System.Drawing.Point(33, 345)
        Me.color_checkinOut_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_checkinOut_lbl.Name = "color_checkinOut_lbl"
        Me.color_checkinOut_lbl.Size = New System.Drawing.Size(267, 20)
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
        Me.Label47.Size = New System.Drawing.Size(23, 22)
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
        Me.color_changeSite_lbl.Size = New System.Drawing.Size(159, 20)
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
        Me.teamAssign_lbl.Size = New System.Drawing.Size(143, 20)
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
        Me.initials_teamAssign_lbl.Size = New System.Drawing.Size(30, 20)
        Me.initials_teamAssign_lbl.TabIndex = 82
        Me.initials_teamAssign_lbl.Text = "EP"
        '
        'boxChangeSite
        '
        Me.boxChangeSite.AutoSize = True
        Me.boxChangeSite.BackColor = System.Drawing.Color.LightSkyBlue
        Me.boxChangeSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxChangeSite.CausesValidation = False
        Me.boxChangeSite.Location = New System.Drawing.Point(8, 465)
        Me.boxChangeSite.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxChangeSite.Name = "boxChangeSite"
        Me.boxChangeSite.Size = New System.Drawing.Size(23, 22)
        Me.boxChangeSite.TabIndex = 76
        Me.boxChangeSite.Text = "  "
        '
        'changeSite_lbl
        '
        Me.changeSite_lbl.AutoSize = True
        Me.changeSite_lbl.CausesValidation = False
        Me.changeSite_lbl.Location = New System.Drawing.Point(35, 195)
        Me.changeSite_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.changeSite_lbl.Name = "changeSite_lbl"
        Me.changeSite_lbl.Size = New System.Drawing.Size(156, 20)
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
        Me.initials_changeSite_lbl.Size = New System.Drawing.Size(36, 20)
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
        Me.color_assignedTeam_lbl.Size = New System.Drawing.Size(143, 20)
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
        Me.colorAbsentDay_lbl.Size = New System.Drawing.Size(188, 20)
        Me.colorAbsentDay_lbl.TabIndex = 79
        Me.colorAbsentDay_lbl.Text = "Validado dia ausente"
        '
        'boxAbsentDay
        '
        Me.boxAbsentDay.AutoSize = True
        Me.boxAbsentDay.BackColor = System.Drawing.Color.MistyRose
        Me.boxAbsentDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxAbsentDay.CausesValidation = False
        Me.boxAbsentDay.Location = New System.Drawing.Point(6, 254)
        Me.boxAbsentDay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxAbsentDay.Name = "boxAbsentDay"
        Me.boxAbsentDay.Size = New System.Drawing.Size(23, 22)
        Me.boxAbsentDay.TabIndex = 78
        Me.boxAbsentDay.Text = "  "
        '
        'boxPlannedTeam
        '
        Me.boxPlannedTeam.AutoSize = True
        Me.boxPlannedTeam.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.boxPlannedTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxPlannedTeam.CausesValidation = False
        Me.boxPlannedTeam.Location = New System.Drawing.Point(8, 443)
        Me.boxPlannedTeam.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxPlannedTeam.Name = "boxPlannedTeam"
        Me.boxPlannedTeam.Size = New System.Drawing.Size(23, 22)
        Me.boxPlannedTeam.TabIndex = 74
        Me.boxPlannedTeam.Text = "  "
        '
        'color_fullDay_lbl
        '
        Me.color_fullDay_lbl.AutoSize = True
        Me.color_fullDay_lbl.CausesValidation = False
        Me.color_fullDay_lbl.Location = New System.Drawing.Point(35, 277)
        Me.color_fullDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_fullDay_lbl.Name = "color_fullDay_lbl"
        Me.color_fullDay_lbl.Size = New System.Drawing.Size(200, 20)
        Me.color_fullDay_lbl.TabIndex = 71
        Me.color_fullDay_lbl.Text = "Dia completo validado"
        '
        'boxDayValidated
        '
        Me.boxDayValidated.AutoSize = True
        Me.boxDayValidated.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.boxDayValidated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxDayValidated.CausesValidation = False
        Me.boxDayValidated.Location = New System.Drawing.Point(6, 276)
        Me.boxDayValidated.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxDayValidated.Name = "boxDayValidated"
        Me.boxDayValidated.Size = New System.Drawing.Size(23, 22)
        Me.boxDayValidated.TabIndex = 70
        Me.boxDayValidated.Text = "  "
        '
        'color_plannedAbsense_lbl
        '
        Me.color_plannedAbsense_lbl.AutoSize = True
        Me.color_plannedAbsense_lbl.CausesValidation = False
        Me.color_plannedAbsense_lbl.Location = New System.Drawing.Point(31, 422)
        Me.color_plannedAbsense_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_plannedAbsense_lbl.Name = "color_plannedAbsense_lbl"
        Me.color_plannedAbsense_lbl.Size = New System.Drawing.Size(170, 20)
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
        Me.colorNoRecord_lbl.Size = New System.Drawing.Size(113, 20)
        Me.colorNoRecord_lbl.TabIndex = 69
        Me.colorNoRecord_lbl.Text = "Sem registo"
        '
        'boxNoRecord
        '
        Me.boxNoRecord.AutoSize = True
        Me.boxNoRecord.BackColor = System.Drawing.Color.White
        Me.boxNoRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxNoRecord.CausesValidation = False
        Me.boxNoRecord.Location = New System.Drawing.Point(6, 231)
        Me.boxNoRecord.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxNoRecord.Name = "boxNoRecord"
        Me.boxNoRecord.Size = New System.Drawing.Size(23, 22)
        Me.boxNoRecord.TabIndex = 68
        Me.boxNoRecord.Text = "  "
        '
        'boxPlannedAbsence
        '
        Me.boxPlannedAbsence.AutoSize = True
        Me.boxPlannedAbsence.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.boxPlannedAbsence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxPlannedAbsence.CausesValidation = False
        Me.boxPlannedAbsence.Location = New System.Drawing.Point(8, 421)
        Me.boxPlannedAbsence.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxPlannedAbsence.Name = "boxPlannedAbsence"
        Me.boxPlannedAbsence.Size = New System.Drawing.Size(23, 22)
        Me.boxPlannedAbsence.TabIndex = 72
        Me.boxPlannedAbsence.Text = "  "
        '
        'color_partialDay_lbl
        '
        Me.color_partialDay_lbl.AutoSize = True
        Me.color_partialDay_lbl.CausesValidation = False
        Me.color_partialDay_lbl.Location = New System.Drawing.Point(35, 300)
        Me.color_partialDay_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_partialDay_lbl.Name = "color_partialDay_lbl"
        Me.color_partialDay_lbl.Size = New System.Drawing.Size(222, 20)
        Me.color_partialDay_lbl.TabIndex = 65
        Me.color_partialDay_lbl.Text = "Dia validado incompleto "
        '
        'boxDayIncomplete
        '
        Me.boxDayIncomplete.AutoSize = True
        Me.boxDayIncomplete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.boxDayIncomplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxDayIncomplete.CausesValidation = False
        Me.boxDayIncomplete.Location = New System.Drawing.Point(6, 298)
        Me.boxDayIncomplete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxDayIncomplete.Name = "boxDayIncomplete"
        Me.boxDayIncomplete.Size = New System.Drawing.Size(23, 22)
        Me.boxDayIncomplete.TabIndex = 64
        Me.boxDayIncomplete.Text = "  "
        '
        'color_holidays_lbl
        '
        Me.color_holidays_lbl.AutoSize = True
        Me.color_holidays_lbl.CausesValidation = False
        Me.color_holidays_lbl.Location = New System.Drawing.Point(33, 401)
        Me.color_holidays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_holidays_lbl.Name = "color_holidays_lbl"
        Me.color_holidays_lbl.Size = New System.Drawing.Size(72, 20)
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
        Me.siteBadWeather_lbl.Size = New System.Drawing.Size(268, 20)
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
        Me.initials_siteBadWeather_lbl.Size = New System.Drawing.Size(27, 20)
        Me.initials_siteBadWeather_lbl.TabIndex = 62
        Me.initials_siteBadWeather_lbl.Text = "FI"
        '
        'boxPlayday
        '
        Me.boxPlayday.AutoSize = True
        Me.boxPlayday.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.boxPlayday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxPlayday.CausesValidation = False
        Me.boxPlayday.Location = New System.Drawing.Point(8, 400)
        Me.boxPlayday.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxPlayday.Name = "boxPlayday"
        Me.boxPlayday.Size = New System.Drawing.Size(23, 22)
        Me.boxPlayday.TabIndex = 66
        Me.boxPlayday.Text = "  "
        '
        'siteAnnual_lbl
        '
        Me.siteAnnual_lbl.AutoSize = True
        Me.siteAnnual_lbl.CausesValidation = False
        Me.siteAnnual_lbl.Location = New System.Drawing.Point(35, 139)
        Me.siteAnnual_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteAnnual_lbl.Name = "siteAnnual_lbl"
        Me.siteAnnual_lbl.Size = New System.Drawing.Size(182, 20)
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
        Me.initials_siteAnnual_lbl.Size = New System.Drawing.Size(30, 20)
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
        Me.color_weekend_lbl.Size = New System.Drawing.Size(141, 20)
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
        Me.malady_lbl.Size = New System.Drawing.Size(72, 20)
        Me.malady_lbl.TabIndex = 59
        Me.malady_lbl.Text = "Doença"
        '
        'boxWeekend
        '
        Me.boxWeekend.AutoSize = True
        Me.boxWeekend.BackColor = System.Drawing.Color.Gainsboro
        Me.boxWeekend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxWeekend.CausesValidation = False
        Me.boxWeekend.Location = New System.Drawing.Point(8, 378)
        Me.boxWeekend.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxWeekend.Name = "boxWeekend"
        Me.boxWeekend.Size = New System.Drawing.Size(23, 22)
        Me.boxWeekend.TabIndex = 48
        Me.boxWeekend.Text = "  "
        '
        'initials_malady_lbl
        '
        Me.initials_malady_lbl.AutoSize = True
        Me.initials_malady_lbl.BackColor = System.Drawing.Color.Transparent
        Me.initials_malady_lbl.CausesValidation = False
        Me.initials_malady_lbl.Location = New System.Drawing.Point(4, 119)
        Me.initials_malady_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.initials_malady_lbl.Name = "initials_malady_lbl"
        Me.initials_malady_lbl.Size = New System.Drawing.Size(23, 20)
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
        Me.playDay_lbl.Size = New System.Drawing.Size(72, 20)
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
        Me.initials_playDay_lbl.Size = New System.Drawing.Size(21, 20)
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
        Me.holidays_lbl.Size = New System.Drawing.Size(60, 20)
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
        Me.initials_holidays_lbl.Size = New System.Drawing.Size(21, 20)
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
        Me.fullDayAbsent_lbl.Size = New System.Drawing.Size(178, 20)
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
        Me.initials_fullDayAbsent_lbl.Size = New System.Drawing.Size(21, 20)
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
        Me.badWeather_lbl.Size = New System.Drawing.Size(105, 20)
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
        Me.initials_badWeather_lbl.Size = New System.Drawing.Size(17, 20)
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
        Me.fullday_lbl.Size = New System.Drawing.Size(122, 20)
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
        Me.initials_fullDay_lbl.Size = New System.Drawing.Size(19, 20)
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
        Me.initials_partialAbsense_lbl.Size = New System.Drawing.Size(20, 20)
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
        Me.color_doubleRecord_lbl.Size = New System.Drawing.Size(162, 20)
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
        Me.partialAbsense_lbl.Size = New System.Drawing.Size(89, 20)
        Me.partialAbsense_lbl.TabIndex = 45
        Me.partialAbsense_lbl.Text = "Faltou 2h"
        '
        'boxDuplicate
        '
        Me.boxDuplicate.AutoSize = True
        Me.boxDuplicate.BackColor = System.Drawing.Color.Red
        Me.boxDuplicate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxDuplicate.CausesValidation = False
        Me.boxDuplicate.Location = New System.Drawing.Point(6, 320)
        Me.boxDuplicate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.boxDuplicate.Name = "boxDuplicate"
        Me.boxDuplicate.Size = New System.Drawing.Size(23, 22)
        Me.boxDuplicate.TabIndex = 46
        Me.boxDuplicate.Text = "  "
        '
        'lateralPanel
        '
        Me.lateralPanel.Controls.Add(Me.ListBoxSite)
        Me.lateralPanel.Controls.Add(Me.duplicatesBtn)
        Me.lateralPanel.Controls.Add(Me.loadSitesBtn)
        Me.lateralPanel.Controls.Add(Me.metricsBtn)
        Me.lateralPanel.Controls.Add(Me.GroupBox_legenda)
        Me.lateralPanel.Controls.Add(Me.Panel3)
        Me.lateralPanel.Controls.Add(Me.date_lbl)
        Me.lateralPanel.Controls.Add(Me.calendar_log)
        Me.lateralPanel.Controls.Add(Me.combo_company)
        Me.lateralPanel.Controls.Add(Me.site_lbl)
        Me.lateralPanel.Controls.Add(Me.company_lbl)
        Me.lateralPanel.Controls.Add(Me.closeMonthAttendanceBtn)
        Me.lateralPanel.Controls.Add(Me.loadTableBtn)
        Me.lateralPanel.Controls.Add(Me.tableSettingsBtn)
        Me.lateralPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.lateralPanel.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanel.Name = "lateralPanel"
        Me.lateralPanel.Size = New System.Drawing.Size(270, 794)
        Me.lateralPanel.TabIndex = 329
        Me.lateralPanel.Visible = False
        '
        'ListBoxSite
        '
        Me.ListBoxSite.FormattingEnabled = True
        Me.ListBoxSite.ItemHeight = 25
        Me.ListBoxSite.Location = New System.Drawing.Point(39, 37)
        Me.ListBoxSite.Name = "ListBoxSite"
        Me.ListBoxSite.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxSite.Size = New System.Drawing.Size(219, 229)
        Me.ListBoxSite.TabIndex = 368
        '
        'duplicatesBtn
        '
        Me.duplicatesBtn.InitialImage = Nothing
        Me.duplicatesBtn.Location = New System.Drawing.Point(69, 371)
        Me.duplicatesBtn.Name = "duplicatesBtn"
        Me.duplicatesBtn.Size = New System.Drawing.Size(26, 26)
        Me.duplicatesBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.duplicatesBtn.TabIndex = 367
        Me.duplicatesBtn.TabStop = False
        '
        'loadSitesBtn
        '
        Me.loadSitesBtn.Image = CType(resources.GetObject("loadSitesBtn.Image"), System.Drawing.Image)
        Me.loadSitesBtn.InitialImage = Nothing
        Me.loadSitesBtn.Location = New System.Drawing.Point(204, 371)
        Me.loadSitesBtn.Name = "loadSitesBtn"
        Me.loadSitesBtn.Size = New System.Drawing.Size(24, 26)
        Me.loadSitesBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadSitesBtn.TabIndex = 366
        Me.loadSitesBtn.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Ivory
        Me.Panel3.Controls.Add(Me.sideToggleBtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(28, 794)
        Me.Panel3.TabIndex = 364
        '
        'sideToggleBtn
        '
        Me.sideToggleBtn.Image = CType(resources.GetObject("sideToggleBtn.Image"), System.Drawing.Image)
        Me.sideToggleBtn.InitialImage = Nothing
        Me.sideToggleBtn.Location = New System.Drawing.Point(2, 2)
        Me.sideToggleBtn.Name = "sideToggleBtn"
        Me.sideToggleBtn.Size = New System.Drawing.Size(24, 26)
        Me.sideToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sideToggleBtn.TabIndex = 363
        Me.sideToggleBtn.TabStop = False
        '
        'date_lbl
        '
        Me.date_lbl.AutoSize = True
        Me.date_lbl.CausesValidation = False
        Me.date_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lbl.Location = New System.Drawing.Point(28, 323)
        Me.date_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.date_lbl.Name = "date_lbl"
        Me.date_lbl.Size = New System.Drawing.Size(64, 25)
        Me.date_lbl.TabIndex = 362
        Me.date_lbl.Text = "Data"
        '
        'calendar_log
        '
        Me.calendar_log.CustomFormat = "MMMM - yyyy"
        Me.calendar_log.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.calendar_log.Location = New System.Drawing.Point(31, 342)
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.Size = New System.Drawing.Size(227, 31)
        Me.calendar_log.TabIndex = 361
        Me.calendar_log.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'loadForm
        '
        '
        'attendanceLoggerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1673, 794)
        Me.Controls.Add(Me.TablePanel)
        Me.Controls.Add(Me.bottomPanel)
        Me.Controls.Add(Me.lateralPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "attendanceLoggerForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registo de presenças"
        Me.GroupBox_detalhes.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxNotes.ResumeLayout(False)
        Me.GroupBoxNotes.PerformLayout()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomPanel.ResumeLayout(False)
        Me.bottomSliderBand.ResumeLayout(False)
        CType(Me.bottomToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TablePanel.ResumeLayout(False)
        CType(Me.metricsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.closeMonthAttendanceBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_legenda.ResumeLayout(False)
        Me.GroupBox_legenda.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.lateralPanel.ResumeLayout(False)
        Me.lateralPanel.PerformLayout()
        CType(Me.duplicatesBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadSitesBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents site_lbl As Label
    Friend WithEvents combo_company As ComboBox
    Friend WithEvents company_lbl As Label
    Friend WithEvents GroupBox_detalhes As GroupBox
    Friend WithEvents gravarnota_lbl As LinkLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBoxNotes As GroupBox
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents datatable As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents category_today As Label
    Friend WithEvents reasonLateValidation_lbl As Label
    Friend WithEvents reasonLateValidation As TextBox
    Friend WithEvents duplicateRecords As Label
    Friend WithEvents worker_photo As PictureBox
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
    Friend WithEvents bottomPanel As Panel
    Friend WithEvents TablePanel As Panel
    Friend WithEvents tableSettingsBtn As PictureBox
    Friend WithEvents loadTableBtn As PictureBox
    Friend WithEvents closeMonthAttendanceBtn As PictureBox
    Friend WithEvents GroupBox_legenda As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents color_checkinOut_lbl As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents color_changeSite_lbl As Label
    Friend WithEvents teamAssign_lbl As Label
    Friend WithEvents initials_teamAssign_lbl As Label
    Friend WithEvents boxChangeSite As Label
    Friend WithEvents changeSite_lbl As Label
    Friend WithEvents initials_changeSite_lbl As Label
    Friend WithEvents color_assignedTeam_lbl As Label
    Friend WithEvents colorAbsentDay_lbl As Label
    Friend WithEvents boxAbsentDay As Label
    Friend WithEvents boxPlannedTeam As Label
    Friend WithEvents color_fullDay_lbl As Label
    Friend WithEvents boxDayValidated As Label
    Friend WithEvents color_plannedAbsense_lbl As Label
    Friend WithEvents colorNoRecord_lbl As Label
    Friend WithEvents boxNoRecord As Label
    Friend WithEvents boxPlannedAbsence As Label
    Friend WithEvents color_partialDay_lbl As Label
    Friend WithEvents boxDayIncomplete As Label
    Friend WithEvents color_holidays_lbl As Label
    Friend WithEvents siteBadWeather_lbl As Label
    Friend WithEvents initials_siteBadWeather_lbl As Label
    Friend WithEvents boxPlayday As Label
    Friend WithEvents siteAnnual_lbl As Label
    Friend WithEvents initials_siteAnnual_lbl As Label
    Friend WithEvents color_weekend_lbl As Label
    Friend WithEvents malady_lbl As Label
    Friend WithEvents boxWeekend As Label
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
    Friend WithEvents boxDuplicate As Label
    Friend WithEvents lateralPanel As Panel
    Friend WithEvents calendar_log As DateTimePicker
    Friend WithEvents date_lbl As Label
    Friend WithEvents bottomToggleBtn As PictureBox
    Friend WithEvents sideToggleBtn As PictureBox
    Friend WithEvents bottomSliderBand As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents metricsBtn As PictureBox
    Friend WithEvents loadSitesBtn As PictureBox
    Friend WithEvents duplicatesBtn As PictureBox
    Friend WithEvents loadForm As Timer
    Friend WithEvents ListBoxSite As ListBox
End Class
