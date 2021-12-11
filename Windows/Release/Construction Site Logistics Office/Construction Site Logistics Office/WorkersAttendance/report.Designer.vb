<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class report_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(report_frm))
        Me.combo_company = New System.Windows.Forms.ComboBox()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.CheckBox_empresa = New System.Windows.Forms.CheckBox()
        Me.CheckBox_obra = New System.Windows.Forms.CheckBox()
        Me.GroupBox_selection = New System.Windows.Forms.GroupBox()
        Me.calendar_log = New System.Windows.Forms.DateTimePicker()
        Me.LoadReport = New System.Windows.Forms.PictureBox()
        Me.resume_type = New System.Windows.Forms.ComboBox()
        Me.tipo_relatorio_lbl = New System.Windows.Forms.Label()
        Me.CheckBox_cat = New System.Windows.Forms.CheckBox()
        Me.combo_cat = New System.Windows.Forms.ComboBox()
        Me.relatorio_lbl = New System.Windows.Forms.Label()
        Me.GroupBox_legenda = New System.Windows.Forms.GroupBox()
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
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_selection.SuspendLayout()
        CType(Me.LoadReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_legenda.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'combo_company
        '
        Me.combo_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_company.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_company.FormattingEnabled = True
        Me.combo_company.Location = New System.Drawing.Point(5, 132)
        Me.combo_company.Name = "combo_company"
        Me.combo_company.Size = New System.Drawing.Size(215, 26)
        Me.combo_company.TabIndex = 25
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
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
        Me.datatable.Location = New System.Drawing.Point(239, 32)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.Size = New System.Drawing.Size(1527, 778)
        Me.datatable.TabIndex = 23
        Me.datatable.Visible = False
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(6, 79)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(215, 26)
        Me.combo_site.TabIndex = 22
        '
        'CheckBox_empresa
        '
        Me.CheckBox_empresa.AutoSize = True
        Me.CheckBox_empresa.Location = New System.Drawing.Point(6, 111)
        Me.CheckBox_empresa.Name = "CheckBox_empresa"
        Me.CheckBox_empresa.Size = New System.Drawing.Size(132, 17)
        Me.CheckBox_empresa.TabIndex = 29
        Me.CheckBox_empresa.Text = "Organizar por empresa"
        Me.CheckBox_empresa.UseVisualStyleBackColor = True
        '
        'CheckBox_obra
        '
        Me.CheckBox_obra.AutoSize = True
        Me.CheckBox_obra.Location = New System.Drawing.Point(6, 62)
        Me.CheckBox_obra.Name = "CheckBox_obra"
        Me.CheckBox_obra.Size = New System.Drawing.Size(115, 17)
        Me.CheckBox_obra.TabIndex = 30
        Me.CheckBox_obra.Text = "Organizar por Obra"
        Me.CheckBox_obra.UseVisualStyleBackColor = True
        '
        'GroupBox_selection
        '
        Me.GroupBox_selection.Controls.Add(Me.calendar_log)
        Me.GroupBox_selection.Controls.Add(Me.LoadReport)
        Me.GroupBox_selection.Controls.Add(Me.resume_type)
        Me.GroupBox_selection.Controls.Add(Me.tipo_relatorio_lbl)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_cat)
        Me.GroupBox_selection.Controls.Add(Me.combo_cat)
        Me.GroupBox_selection.Controls.Add(Me.combo_site)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_empresa)
        Me.GroupBox_selection.Controls.Add(Me.CheckBox_obra)
        Me.GroupBox_selection.Controls.Add(Me.combo_company)
        Me.GroupBox_selection.Location = New System.Drawing.Point(5, 30)
        Me.GroupBox_selection.Name = "GroupBox_selection"
        Me.GroupBox_selection.Size = New System.Drawing.Size(227, 253)
        Me.GroupBox_selection.TabIndex = 31
        Me.GroupBox_selection.TabStop = False
        Me.GroupBox_selection.Text = "Procurar"
        Me.GroupBox_selection.Visible = False
        '
        'calendar_log
        '
        Me.calendar_log.CustomFormat = "MMMM - yyyy"
        Me.calendar_log.Enabled = False
        Me.calendar_log.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.calendar_log.Location = New System.Drawing.Point(5, 217)
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.Size = New System.Drawing.Size(168, 20)
        Me.calendar_log.TabIndex = 360
        Me.calendar_log.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'LoadReport
        '
        Me.LoadReport.Image = CType(resources.GetObject("LoadReport.Image"), System.Drawing.Image)
        Me.LoadReport.InitialImage = Nothing
        Me.LoadReport.Location = New System.Drawing.Point(200, 217)
        Me.LoadReport.Name = "LoadReport"
        Me.LoadReport.Size = New System.Drawing.Size(20, 20)
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
        Me.resume_type.Location = New System.Drawing.Point(6, 32)
        Me.resume_type.Name = "resume_type"
        Me.resume_type.Size = New System.Drawing.Size(215, 21)
        Me.resume_type.TabIndex = 203
        '
        'tipo_relatorio_lbl
        '
        Me.tipo_relatorio_lbl.AutoSize = True
        Me.tipo_relatorio_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_relatorio_lbl.Location = New System.Drawing.Point(6, 16)
        Me.tipo_relatorio_lbl.Name = "tipo_relatorio_lbl"
        Me.tipo_relatorio_lbl.Size = New System.Drawing.Size(101, 13)
        Me.tipo_relatorio_lbl.TabIndex = 202
        Me.tipo_relatorio_lbl.Text = "Tipo de relatório"
        '
        'CheckBox_cat
        '
        Me.CheckBox_cat.AutoSize = True
        Me.CheckBox_cat.Location = New System.Drawing.Point(5, 160)
        Me.CheckBox_cat.Name = "CheckBox_cat"
        Me.CheckBox_cat.Size = New System.Drawing.Size(136, 17)
        Me.CheckBox_cat.TabIndex = 32
        Me.CheckBox_cat.Text = "Organizar por categoria"
        Me.CheckBox_cat.UseVisualStyleBackColor = True
        '
        'combo_cat
        '
        Me.combo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_cat.FormattingEnabled = True
        Me.combo_cat.Location = New System.Drawing.Point(4, 181)
        Me.combo_cat.Name = "combo_cat"
        Me.combo_cat.Size = New System.Drawing.Size(215, 26)
        Me.combo_cat.TabIndex = 31
        '
        'relatorio_lbl
        '
        Me.relatorio_lbl.AutoSize = True
        Me.relatorio_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.relatorio_lbl.Location = New System.Drawing.Point(239, 9)
        Me.relatorio_lbl.Name = "relatorio_lbl"
        Me.relatorio_lbl.Size = New System.Drawing.Size(122, 20)
        Me.relatorio_lbl.TabIndex = 32
        Me.relatorio_lbl.Text = "Tipo de relatório"
        Me.relatorio_lbl.Visible = False
        '
        'GroupBox_legenda
        '
        Me.GroupBox_legenda.CausesValidation = False
        Me.GroupBox_legenda.Controls.Add(Me.Panel2)
        Me.GroupBox_legenda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_legenda.Location = New System.Drawing.Point(5, 290)
        Me.GroupBox_legenda.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Name = "GroupBox_legenda"
        Me.GroupBox_legenda.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_legenda.Size = New System.Drawing.Size(227, 520)
        Me.GroupBox_legenda.TabIndex = 33
        Me.GroupBox_legenda.TabStop = False
        Me.GroupBox_legenda.Text = "Legenda"
        Me.GroupBox_legenda.Visible = False
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
        Me.Panel2.Location = New System.Drawing.Point(4, 18)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(219, 498)
        Me.Panel2.TabIndex = 0
        '
        'color_checkinOut_lbl
        '
        Me.color_checkinOut_lbl.AutoSize = True
        Me.color_checkinOut_lbl.CausesValidation = False
        Me.color_checkinOut_lbl.Location = New System.Drawing.Point(33, 345)
        Me.color_checkinOut_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.color_checkinOut_lbl.Name = "color_checkinOut_lbl"
        Me.color_checkinOut_lbl.Size = New System.Drawing.Size(180, 13)
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
        Me.Label47.Size = New System.Drawing.Size(17, 15)
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
        Me.color_changeSite_lbl.Size = New System.Drawing.Size(107, 13)
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
        Me.teamAssign_lbl.Size = New System.Drawing.Size(95, 13)
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
        Me.initials_teamAssign_lbl.Size = New System.Drawing.Size(21, 13)
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
        Me.Label39.Size = New System.Drawing.Size(17, 15)
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
        Me.changeSite_lbl.Size = New System.Drawing.Size(105, 13)
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
        Me.initials_changeSite_lbl.Size = New System.Drawing.Size(25, 13)
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
        Me.color_assignedTeam_lbl.Size = New System.Drawing.Size(95, 13)
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
        Me.colorAbsentDay_lbl.Size = New System.Drawing.Size(125, 13)
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
        Me.Label41.Size = New System.Drawing.Size(17, 15)
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
        Me.Label37.Size = New System.Drawing.Size(17, 15)
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
        Me.color_fullDay_lbl.Size = New System.Drawing.Size(134, 13)
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
        Me.Label32.Size = New System.Drawing.Size(17, 15)
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
        Me.color_plannedAbsense_lbl.Size = New System.Drawing.Size(114, 13)
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
        Me.colorNoRecord_lbl.Size = New System.Drawing.Size(76, 13)
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
        Me.Label30.Size = New System.Drawing.Size(17, 15)
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
        Me.Label34.Size = New System.Drawing.Size(17, 15)
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
        Me.color_partialDay_lbl.Size = New System.Drawing.Size(148, 13)
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
        Me.Label26.Size = New System.Drawing.Size(17, 15)
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
        Me.color_holidays_lbl.Size = New System.Drawing.Size(49, 13)
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
        Me.siteBadWeather_lbl.Size = New System.Drawing.Size(179, 13)
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
        Me.initials_siteBadWeather_lbl.Size = New System.Drawing.Size(18, 13)
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
        Me.Label28.Size = New System.Drawing.Size(17, 15)
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
        Me.siteAnnual_lbl.Size = New System.Drawing.Size(122, 13)
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
        Me.initials_siteAnnual_lbl.Size = New System.Drawing.Size(20, 13)
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
        Me.color_weekend_lbl.Size = New System.Drawing.Size(94, 13)
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
        Me.malady_lbl.Size = New System.Drawing.Size(50, 13)
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
        Me.Label13.Size = New System.Drawing.Size(17, 15)
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
        Me.initials_malady_lbl.Size = New System.Drawing.Size(16, 13)
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
        Me.playDay_lbl.Size = New System.Drawing.Size(49, 13)
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
        Me.initials_playDay_lbl.Size = New System.Drawing.Size(16, 13)
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
        Me.holidays_lbl.Size = New System.Drawing.Size(41, 13)
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
        Me.initials_holidays_lbl.Size = New System.Drawing.Size(15, 13)
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
        Me.fullDayAbsent_lbl.Size = New System.Drawing.Size(117, 13)
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
        Me.initials_fullDayAbsent_lbl.Size = New System.Drawing.Size(15, 13)
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
        Me.badWeather_lbl.Size = New System.Drawing.Size(70, 13)
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
        Me.initials_badWeather_lbl.Size = New System.Drawing.Size(12, 13)
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
        Me.fullday_lbl.Size = New System.Drawing.Size(82, 13)
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
        Me.initials_fullDay_lbl.Size = New System.Drawing.Size(14, 13)
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
        Me.initials_partialAbsense_lbl.Size = New System.Drawing.Size(14, 13)
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
        Me.color_doubleRecord_lbl.Size = New System.Drawing.Size(107, 13)
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
        Me.partialAbsense_lbl.Size = New System.Drawing.Size(58, 13)
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
        Me.Label11.Size = New System.Drawing.Size(17, 15)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "  "
        '
        'report_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1829, 830)
        Me.Controls.Add(Me.GroupBox_legenda)
        Me.Controls.Add(Me.relatorio_lbl)
        Me.Controls.Add(Me.GroupBox_selection)
        Me.Controls.Add(Me.datatable)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "report_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relatório"
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_selection.ResumeLayout(False)
        Me.GroupBox_selection.PerformLayout()
        CType(Me.LoadReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_legenda.ResumeLayout(False)
        Me.GroupBox_legenda.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents combo_company As ComboBox
    Friend WithEvents datatable As DataGridView
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents CheckBox_empresa As CheckBox
    Friend WithEvents CheckBox_obra As CheckBox
    Friend WithEvents GroupBox_selection As GroupBox
    Friend WithEvents CheckBox_cat As CheckBox
    Friend WithEvents combo_cat As ComboBox
    Friend WithEvents relatorio_lbl As Label
    Friend WithEvents resume_type As ComboBox
    Friend WithEvents tipo_relatorio_lbl As Label
    Friend WithEvents GroupBox_legenda As GroupBox
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
    Friend WithEvents LoadReport As PictureBox
    Friend WithEvents calendar_log As DateTimePicker
End Class
