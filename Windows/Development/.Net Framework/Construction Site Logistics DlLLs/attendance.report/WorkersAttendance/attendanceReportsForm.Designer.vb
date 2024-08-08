Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class attendanceReportsForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(attendanceReportsForm))
        Me.combo_company = New System.Windows.Forms.ComboBox()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.listBoxSite = New System.Windows.Forms.ComboBox()
        Me.CheckBox_empresa = New System.Windows.Forms.CheckBox()
        Me.CheckBox_obra = New System.Windows.Forms.CheckBox()
        Me.GroupBox_selection = New System.Windows.Forms.GroupBox()
        Me.tableSettingsBtn = New System.Windows.Forms.PictureBox()
        Me.checkStatusBtn = New System.Windows.Forms.PictureBox()
        Me.loadSitesBtn = New System.Windows.Forms.PictureBox()
        Me.calendar_log = New System.Windows.Forms.DateTimePicker()
        Me.LoadReport = New System.Windows.Forms.PictureBox()
        Me.resume_type = New System.Windows.Forms.ComboBox()
        Me.tipo_relatorio_lbl = New System.Windows.Forms.Label()
        Me.CheckBox_cat = New System.Windows.Forms.CheckBox()
        Me.combo_cat = New System.Windows.Forms.ComboBox()
        Me.relatorio_lbl = New System.Windows.Forms.Label()
        Me.lateralPanel = New System.Windows.Forms.Panel()
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.sideToggleBtn = New System.Windows.Forms.PictureBox()
        Me.bottomPanel = New System.Windows.Forms.Panel()
        Me.datatableNotes = New System.Windows.Forms.DataGridView()
        Me.bottomSliderBand = New System.Windows.Forms.Panel()
        Me.bottomToggleBtn = New System.Windows.Forms.PictureBox()
        Me.tablePanel = New System.Windows.Forms.Panel()
        Me.metricsBtn = New System.Windows.Forms.PictureBox()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_selection.SuspendLayout()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkStatusBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadSitesBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lateralPanel.SuspendLayout()
        Me.GroupBox_legenda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomPanel.SuspendLayout()
        CType(Me.datatableNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bottomSliderBand.SuspendLayout()
        CType(Me.bottomToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tablePanel.SuspendLayout()
        CType(Me.metricsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'combo_company
        '
        Me.combo_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_company.Enabled = False
        Me.combo_company.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_company.FormattingEnabled = True
        Me.combo_company.Location = New System.Drawing.Point(8, 203)
        Me.combo_company.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_company.Name = "combo_company"
        Me.combo_company.Size = New System.Drawing.Size(320, 37)
        Me.combo_company.TabIndex = 25
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(7, 43)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        Me.datatable.Size = New System.Drawing.Size(2169, 1050)
        Me.datatable.TabIndex = 23
        '
        'listBoxSite
        '
        Me.listBoxSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listBoxSite.Enabled = False
        Me.listBoxSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listBoxSite.FormattingEnabled = True
        Me.listBoxSite.Location = New System.Drawing.Point(9, 122)
        Me.listBoxSite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listBoxSite.Name = "listBoxSite"
        Me.listBoxSite.Size = New System.Drawing.Size(320, 37)
        Me.listBoxSite.TabIndex = 22
        '
        'CheckBox_empresa
        '
        Me.CheckBox_empresa.AutoSize = True
        Me.CheckBox_empresa.Enabled = False
        Me.CheckBox_empresa.Location = New System.Drawing.Point(9, 171)
        Me.CheckBox_empresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox_empresa.Name = "CheckBox_empresa"
        Me.CheckBox_empresa.Size = New System.Drawing.Size(197, 24)
        Me.CheckBox_empresa.TabIndex = 29
        Me.CheckBox_empresa.Text = "Organizar por empresa"
        Me.CheckBox_empresa.UseVisualStyleBackColor = True
        '
        'CheckBox_obra
        '
        Me.CheckBox_obra.AutoSize = True
        Me.CheckBox_obra.Enabled = False
        Me.CheckBox_obra.Location = New System.Drawing.Point(9, 95)
        Me.CheckBox_obra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox_obra.Name = "CheckBox_obra"
        Me.CheckBox_obra.Size = New System.Drawing.Size(170, 24)
        Me.CheckBox_obra.TabIndex = 30
        Me.CheckBox_obra.Text = "Organizar por Obra"
        Me.CheckBox_obra.UseVisualStyleBackColor = True
        '
        'GroupBox_selection
        '
        Me.GroupBox_selection.Controls.Add(Me.metricsBtn)
        Me.GroupBox_selection.Controls.Add(Me.tableSettingsBtn)
        Me.GroupBox_selection.Controls.Add(Me.checkStatusBtn)
        Me.GroupBox_selection.Controls.Add(Me.loadSitesBtn)
        Me.GroupBox_selection.Controls.Add(Me.calendar_log)
        Me.GroupBox_selection.Controls.Add(Me.LoadReport)
        Me.GroupBox_selection.Controls.Add(Me.resume_type)
        Me.GroupBox_selection.Controls.Add(Me.tipo_relatorio_lbl)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_cat)
        Me.GroupBox_selection.Controls.Add(Me.combo_cat)
        Me.GroupBox_selection.Controls.Add(Me.listBoxSite)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_empresa)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_obra)
        Me.GroupBox_selection.Controls.Add(Me.combo_company)
        Me.GroupBox_selection.Location = New System.Drawing.Point(33, 5)
        Me.GroupBox_selection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_selection.Name = "GroupBox_selection"
        Me.GroupBox_selection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_selection.Size = New System.Drawing.Size(340, 414)
        Me.GroupBox_selection.TabIndex = 31
        Me.GroupBox_selection.TabStop = False
        Me.GroupBox_selection.Text = "Procurar"
        '
        'tableSettingsBtn
        '
        Me.tableSettingsBtn.Image = CType(resources.GetObject("tableSettingsBtn.Image"), System.Drawing.Image)
        Me.tableSettingsBtn.InitialImage = Nothing
        Me.tableSettingsBtn.Location = New System.Drawing.Point(247, 370)
        Me.tableSettingsBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tableSettingsBtn.Name = "tableSettingsBtn"
        Me.tableSettingsBtn.Size = New System.Drawing.Size(30, 30)
        Me.tableSettingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tableSettingsBtn.TabIndex = 363
        Me.tableSettingsBtn.TabStop = False
        '
        'checkStatusBtn
        '
        Me.checkStatusBtn.Image = CType(resources.GetObject("checkStatusBtn.Image"), System.Drawing.Image)
        Me.checkStatusBtn.InitialImage = Nothing
        Me.checkStatusBtn.Location = New System.Drawing.Point(149, 370)
        Me.checkStatusBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.checkStatusBtn.Name = "checkStatusBtn"
        Me.checkStatusBtn.Size = New System.Drawing.Size(30, 30)
        Me.checkStatusBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.checkStatusBtn.TabIndex = 362
        Me.checkStatusBtn.TabStop = False
        '
        'loadSitesBtn
        '
        Me.loadSitesBtn.Image = CType(resources.GetObject("loadSitesBtn.Image"), System.Drawing.Image)
        Me.loadSitesBtn.InitialImage = Nothing
        Me.loadSitesBtn.Location = New System.Drawing.Point(197, 370)
        Me.loadSitesBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.loadSitesBtn.Name = "loadSitesBtn"
        Me.loadSitesBtn.Size = New System.Drawing.Size(30, 30)
        Me.loadSitesBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadSitesBtn.TabIndex = 361
        Me.loadSitesBtn.TabStop = False
        '
        'calendar_log
        '
        Me.calendar_log.CustomFormat = "MMMM - yyyy"
        Me.calendar_log.Enabled = False
        Me.calendar_log.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.calendar_log.Location = New System.Drawing.Point(8, 334)
        Me.calendar_log.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.Size = New System.Drawing.Size(318, 26)
        Me.calendar_log.TabIndex = 360
        Me.calendar_log.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'LoadReport
        '
        Me.LoadReport.Image = CType(resources.GetObject("LoadReport.Image"), System.Drawing.Image)
        Me.LoadReport.InitialImage = Nothing
        Me.LoadReport.Location = New System.Drawing.Point(296, 370)
        Me.LoadReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoadReport.Name = "LoadReport"
        Me.LoadReport.Size = New System.Drawing.Size(30, 30)
        Me.LoadReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LoadReport.TabIndex = 204
        Me.LoadReport.TabStop = False
        '
        'resume_type
        '
        Me.resume_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.resume_type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resume_type.FormattingEnabled = True
        Me.resume_type.Items.AddRange(New Object() {"Seleccione o tipo de resumo", "Resumo mensal de presenças", "Relatório mensal de presenças detalhado", "Relatório mensal de presenças detalhado por obra"})
        Me.resume_type.Location = New System.Drawing.Point(9, 49)
        Me.resume_type.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.resume_type.Name = "resume_type"
        Me.resume_type.Size = New System.Drawing.Size(320, 28)
        Me.resume_type.TabIndex = 203
        '
        'tipo_relatorio_lbl
        '
        Me.tipo_relatorio_lbl.AutoSize = True
        Me.tipo_relatorio_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_relatorio_lbl.Location = New System.Drawing.Point(9, 25)
        Me.tipo_relatorio_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tipo_relatorio_lbl.Name = "tipo_relatorio_lbl"
        Me.tipo_relatorio_lbl.Size = New System.Drawing.Size(149, 20)
        Me.tipo_relatorio_lbl.TabIndex = 202
        Me.tipo_relatorio_lbl.Text = "Tipo de relatório"
        '
        'CheckBox_cat
        '
        Me.CheckBox_cat.AutoSize = True
        Me.CheckBox_cat.Enabled = False
        Me.CheckBox_cat.Location = New System.Drawing.Point(8, 246)
        Me.CheckBox_cat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox_cat.Name = "CheckBox_cat"
        Me.CheckBox_cat.Size = New System.Drawing.Size(201, 24)
        Me.CheckBox_cat.TabIndex = 32
        Me.CheckBox_cat.Text = "Organizar por categoria"
        Me.CheckBox_cat.UseVisualStyleBackColor = True
        '
        'combo_cat
        '
        Me.combo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_cat.Enabled = False
        Me.combo_cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_cat.FormattingEnabled = True
        Me.combo_cat.Location = New System.Drawing.Point(6, 278)
        Me.combo_cat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_cat.Name = "combo_cat"
        Me.combo_cat.Size = New System.Drawing.Size(320, 37)
        Me.combo_cat.TabIndex = 31
        '
        'relatorio_lbl
        '
        Me.relatorio_lbl.AutoSize = True
        Me.relatorio_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.relatorio_lbl.Location = New System.Drawing.Point(7, 8)
        Me.relatorio_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.relatorio_lbl.Name = "relatorio_lbl"
        Me.relatorio_lbl.Size = New System.Drawing.Size(192, 29)
        Me.relatorio_lbl.TabIndex = 32
        Me.relatorio_lbl.Text = "Tipo de relatório"
        '
        'lateralPanel
        '
        Me.lateralPanel.Controls.Add(Me.GroupBox_legenda)
        Me.lateralPanel.Controls.Add(Me.Panel3)
        Me.lateralPanel.Controls.Add(Me.GroupBox_selection)
        Me.lateralPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.lateralPanel.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanel.Name = "lateralPanel"
        Me.lateralPanel.Size = New System.Drawing.Size(397, 1277)
        Me.lateralPanel.TabIndex = 330
        Me.lateralPanel.Visible = False
        '
        'GroupBox_legenda
        '
        Me.GroupBox_legenda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_legenda.CausesValidation = False
        Me.GroupBox_legenda.Controls.Add(Me.Panel2)
        Me.GroupBox_legenda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_legenda.Location = New System.Drawing.Point(33, 428)
        Me.GroupBox_legenda.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Name = "GroupBox_legenda"
        Me.GroupBox_legenda.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Size = New System.Drawing.Size(340, 845)
        Me.GroupBox_legenda.TabIndex = 365
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
        Me.Panel2.Size = New System.Drawing.Size(332, 816)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Ivory
        Me.Panel3.Controls.Add(Me.sideToggleBtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(21, 1277)
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
        'bottomPanel
        '
        Me.bottomPanel.Controls.Add(Me.datatableNotes)
        Me.bottomPanel.Controls.Add(Me.bottomSliderBand)
        Me.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomPanel.Location = New System.Drawing.Point(397, 1107)
        Me.bottomPanel.Name = "bottomPanel"
        Me.bottomPanel.Size = New System.Drawing.Size(2189, 170)
        Me.bottomPanel.TabIndex = 331
        Me.bottomPanel.Visible = False
        '
        'datatableNotes
        '
        Me.datatableNotes.AllowUserToAddRows = False
        Me.datatableNotes.AllowUserToDeleteRows = False
        Me.datatableNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datatableNotes.BackgroundColor = System.Drawing.Color.White
        Me.datatableNotes.CausesValidation = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatableNotes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.datatableNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatableNotes.DefaultCellStyle = DataGridViewCellStyle4
        Me.datatableNotes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatableNotes.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatableNotes.Location = New System.Drawing.Point(7, 31)
        Me.datatableNotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.datatableNotes.MultiSelect = False
        Me.datatableNotes.Name = "datatableNotes"
        Me.datatableNotes.ReadOnly = True
        Me.datatableNotes.RowHeadersWidth = 62
        Me.datatableNotes.Size = New System.Drawing.Size(2169, 125)
        Me.datatableNotes.TabIndex = 366
        '
        'bottomSliderBand
        '
        Me.bottomSliderBand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bottomSliderBand.BackColor = System.Drawing.Color.Ivory
        Me.bottomSliderBand.Controls.Add(Me.bottomToggleBtn)
        Me.bottomSliderBand.Location = New System.Drawing.Point(0, 0)
        Me.bottomSliderBand.Name = "bottomSliderBand"
        Me.bottomSliderBand.Size = New System.Drawing.Size(2189, 28)
        Me.bottomSliderBand.TabIndex = 365
        '
        'bottomToggleBtn
        '
        Me.bottomToggleBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bottomToggleBtn.Image = CType(resources.GetObject("bottomToggleBtn.Image"), System.Drawing.Image)
        Me.bottomToggleBtn.InitialImage = Nothing
        Me.bottomToggleBtn.Location = New System.Drawing.Point(2153, 1)
        Me.bottomToggleBtn.Margin = New System.Windows.Forms.Padding(3, 3, 5, 3)
        Me.bottomToggleBtn.Name = "bottomToggleBtn"
        Me.bottomToggleBtn.Size = New System.Drawing.Size(24, 26)
        Me.bottomToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.bottomToggleBtn.TabIndex = 364
        Me.bottomToggleBtn.TabStop = False
        '
        'tablePanel
        '
        Me.tablePanel.Controls.Add(Me.datatable)
        Me.tablePanel.Controls.Add(Me.relatorio_lbl)
        Me.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablePanel.Location = New System.Drawing.Point(397, 0)
        Me.tablePanel.Name = "tablePanel"
        Me.tablePanel.Size = New System.Drawing.Size(2189, 1107)
        Me.tablePanel.TabIndex = 332
        '
        'metricsBtn
        '
        Me.metricsBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.metricsBtn.Enabled = False
        Me.metricsBtn.Image = CType(resources.GetObject("metricsBtn.Image"), System.Drawing.Image)
        Me.metricsBtn.InitialImage = Nothing
        Me.metricsBtn.Location = New System.Drawing.Point(98, 370)
        Me.metricsBtn.Name = "metricsBtn"
        Me.metricsBtn.Size = New System.Drawing.Size(30, 30)
        Me.metricsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.metricsBtn.TabIndex = 366
        Me.metricsBtn.TabStop = False
        '
        'attendanceReportsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(2586, 1277)
        Me.Controls.Add(Me.tablePanel)
        Me.Controls.Add(Me.bottomPanel)
        Me.Controls.Add(Me.lateralPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "attendanceReportsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relatório"
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_selection.ResumeLayout(False)
        Me.GroupBox_selection.PerformLayout()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkStatusBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadSitesBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lateralPanel.ResumeLayout(False)
        Me.GroupBox_legenda.ResumeLayout(False)
        Me.GroupBox_legenda.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomPanel.ResumeLayout(False)
        CType(Me.datatableNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bottomSliderBand.ResumeLayout(False)
        CType(Me.bottomToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tablePanel.ResumeLayout(False)
        Me.tablePanel.PerformLayout()
        CType(Me.metricsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents combo_company As ComboBox
    Friend WithEvents datatable As DataGridView
    Friend WithEvents listBoxSite As ComboBox
    Friend WithEvents CheckBox_empresa As CheckBox
    Friend WithEvents CheckBox_obra As CheckBox
    Friend WithEvents GroupBox_selection As GroupBox
    Friend WithEvents CheckBox_cat As CheckBox
    Friend WithEvents combo_cat As ComboBox
    Friend WithEvents relatorio_lbl As Label
    Friend WithEvents resume_type As ComboBox
    Friend WithEvents tipo_relatorio_lbl As Label
    Friend WithEvents LoadReport As PictureBox
    Friend WithEvents calendar_log As DateTimePicker
    Friend WithEvents lateralPanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents sideToggleBtn As PictureBox
    Friend WithEvents bottomPanel As Panel
    Friend WithEvents datatableNotes As DataGridView
    Friend WithEvents bottomSliderBand As Panel
    Friend WithEvents bottomToggleBtn As PictureBox
    Friend WithEvents tablePanel As Panel
    Friend WithEvents checkStatusBtn As PictureBox
    Friend WithEvents loadSitesBtn As PictureBox
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
    Friend WithEvents tableSettingsBtn As PictureBox
    Friend WithEvents metricsBtn As PictureBox
End Class
