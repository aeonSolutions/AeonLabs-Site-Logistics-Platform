Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings_frm
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
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.generalPanel = New System.Windows.Forms.Panel()
        Me.workHours = New System.Windows.Forms.DateTimePicker()
        Me.workHours_lbl = New System.Windows.Forms.Label()
        Me.attendanceText = New System.Windows.Forms.Label()
        Me.domain_web_ex = New System.Windows.Forms.Label()
        Me.server_web_addr_lbl = New System.Windows.Forms.Label()
        Me.server_web_addr = New System.Windows.Forms.TextBox()
        Me.attendanceNumDays = New System.Windows.Forms.TextBox()
        Me.attendanceNumDays_lbl = New System.Windows.Forms.Label()
        Me.translation_apikey_lbl = New System.Windows.Forms.Label()
        Me.translationApiKey = New System.Windows.Forms.TextBox()
        Me.weather_provider_lbl = New System.Windows.Forms.Label()
        Me.weatherProvider = New System.Windows.Forms.ComboBox()
        Me.translation_provider_lbl = New System.Windows.Forms.Label()
        Me.translationProvider = New System.Windows.Forms.ComboBox()
        Me.enableWeather = New System.Windows.Forms.CheckBox()
        Me.enableTranslation = New System.Windows.Forms.CheckBox()
        Me.weather_apikey_lbl = New System.Windows.Forms.Label()
        Me.weatherApiKey = New System.Windows.Forms.TextBox()
        Me.about_diagnostics = New System.Windows.Forms.LinkLabel()
        Me.share_details = New System.Windows.Forms.TextBox()
        Me.share = New System.Windows.Forms.CheckBox()
        Me.send_details = New System.Windows.Forms.TextBox()
        Me.send = New System.Windows.Forms.CheckBox()
        Me.selectRegularFile = New System.Windows.Forms.Button()
        Me.selectTitleFile = New System.Windows.Forms.Button()
        Me.fontsRegularFile = New System.Windows.Forms.TextBox()
        Me.fontsTitleFile = New System.Windows.Forms.TextBox()
        Me.fontsRegularFontName = New System.Windows.Forms.Label()
        Me.fontsTitleFontName = New System.Windows.Forms.Label()
        Me.fontsRegular_lbl = New System.Windows.Forms.Label()
        Me.fontsTitles_lbl = New System.Windows.Forms.Label()
        Me.saveLink = New System.Windows.Forms.LinkLabel()
        Me.apiServerDivider = New System.Windows.Forms.Label()
        Me.apiServerTitle = New System.Windows.Forms.Label()
        Me.diagsDivider = New System.Windows.Forms.Label()
        Me.diagsTitle = New System.Windows.Forms.Label()
        Me.fontsDivider = New System.Windows.Forms.Label()
        Me.fontsTitle = New System.Windows.Forms.Label()
        Me.attendanceDivider = New System.Windows.Forms.Label()
        Me.attendanceTitle = New System.Windows.Forms.Label()
        Me.addonsDivider = New System.Windows.Forms.Label()
        Me.addonsTitle = New System.Windows.Forms.Label()
        Me.languageDivider = New System.Windows.Forms.Label()
        Me.languageTitle = New System.Windows.Forms.Label()
        Me.show_all_lang = New System.Windows.Forms.CheckBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.fontsPanel = New System.Windows.Forms.Panel()
        Me.lateralMenu_lbl = New System.Windows.Forms.Label()
        Me.lateralMenu_color = New System.Windows.Forms.Label()
        Me.lateralMenu_box = New System.Windows.Forms.Label()
        Me.saveColorsLink = New System.Windows.Forms.LinkLabel()
        Me.sites_lbl = New System.Windows.Forms.Label()
        Me.sites_color = New System.Windows.Forms.Label()
        Me.sites_box = New System.Windows.Forms.Label()
        Me.sections_lbl = New System.Windows.Forms.Label()
        Me.sections_color = New System.Windows.Forms.Label()
        Me.sections_box = New System.Windows.Forms.Label()
        Me.companies_lbl = New System.Windows.Forms.Label()
        Me.companies_color = New System.Windows.Forms.Label()
        Me.companies_box = New System.Windows.Forms.Label()
        Me.workCategories_lbl = New System.Windows.Forms.Label()
        Me.workCategories_color = New System.Windows.Forms.Label()
        Me.workCategories_box = New System.Windows.Forms.Label()
        Me.plannedAbsense_lbl = New System.Windows.Forms.Label()
        Me.plannedAbsense_color = New System.Windows.Forms.Label()
        Me.plannedAbsense_box = New System.Windows.Forms.Label()
        Me.holidays_lbl = New System.Windows.Forms.Label()
        Me.holidays_color = New System.Windows.Forms.Label()
        Me.holidays_box = New System.Windows.Forms.Label()
        Me.record_lbl = New System.Windows.Forms.Label()
        Me.record_color = New System.Windows.Forms.Label()
        Me.record_box = New System.Windows.Forms.Label()
        Me.absentDayValidated_lbl = New System.Windows.Forms.Label()
        Me.absentDayValidated_color = New System.Windows.Forms.Label()
        Me.absentDayValidated_box = New System.Windows.Forms.Label()
        Me.annualCloseDays_lbl = New System.Windows.Forms.Label()
        Me.annualCloseDays_color = New System.Windows.Forms.Label()
        Me.annualCloseDays_box = New System.Windows.Forms.Label()
        Me.withoutRecord_lbl = New System.Windows.Forms.Label()
        Me.withoutRecord_color = New System.Windows.Forms.Label()
        Me.withoutRecord_box = New System.Windows.Forms.Label()
        Me.weekends_lbl = New System.Windows.Forms.Label()
        Me.weekends_color = New System.Windows.Forms.Label()
        Me.weekends_box = New System.Windows.Forms.Label()
        Me.partialDayValidated_lbl = New System.Windows.Forms.Label()
        Me.partialDayValidated_color = New System.Windows.Forms.Label()
        Me.partialDayValidated_box = New System.Windows.Forms.Label()
        Me.plannedSiteChange_lbl = New System.Windows.Forms.Label()
        Me.plannedSiteChange_color = New System.Windows.Forms.Label()
        Me.plannedSiteChange_box = New System.Windows.Forms.Label()
        Me.plannedTeam_lbl = New System.Windows.Forms.Label()
        Me.plannedTeam_color = New System.Windows.Forms.Label()
        Me.plannedTeam_box = New System.Windows.Forms.Label()
        Me.fullDayValidated_lbl = New System.Windows.Forms.Label()
        Me.fullDayValidated_color = New System.Windows.Forms.Label()
        Me.fullDayValidated_box = New System.Windows.Forms.Label()
        Me.dividers_lbl = New System.Windows.Forms.Label()
        Me.dividers_color = New System.Windows.Forms.Label()
        Me.dividers_box = New System.Windows.Forms.Label()
        Me.buttons_lbl = New System.Windows.Forms.Label()
        Me.buttons_color = New System.Windows.Forms.Label()
        Me.buttons_box = New System.Windows.Forms.Label()
        Me.datatableResetLink = New System.Windows.Forms.LinkLabel()
        Me.generalResetLink = New System.Windows.Forms.LinkLabel()
        Me.datatablesDivider = New System.Windows.Forms.Label()
        Me.datatablesTitle = New System.Windows.Forms.Label()
        Me.generalDivider = New System.Windows.Forms.Label()
        Me.generalTitle = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBoxCheckIn = New System.Windows.Forms.CheckBox()
        Me.validation_erase_lbl = New System.Windows.Forms.Label()
        Me.CheckBoxCheckOut = New System.Windows.Forms.CheckBox()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.generalPanel.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.fontsPanel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(639, 450)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(15, 31)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(622, 4)
        Me.divider.TabIndex = 341
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(17, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(84, 20)
        Me.title.TabIndex = 340
        Me.title.Text = "Definições"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Location = New System.Drawing.Point(15, 49)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(710, 385)
        Me.TabControl.TabIndex = 342
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.generalPanel)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(702, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Geral"
        '
        'generalPanel
        '
        Me.generalPanel.AutoScroll = True
        Me.generalPanel.Controls.Add(Me.CheckBoxCheckOut)
        Me.generalPanel.Controls.Add(Me.validation_erase_lbl)
        Me.generalPanel.Controls.Add(Me.CheckBoxCheckIn)
        Me.generalPanel.Controls.Add(Me.workHours)
        Me.generalPanel.Controls.Add(Me.workHours_lbl)
        Me.generalPanel.Controls.Add(Me.attendanceText)
        Me.generalPanel.Controls.Add(Me.domain_web_ex)
        Me.generalPanel.Controls.Add(Me.server_web_addr_lbl)
        Me.generalPanel.Controls.Add(Me.server_web_addr)
        Me.generalPanel.Controls.Add(Me.attendanceNumDays)
        Me.generalPanel.Controls.Add(Me.attendanceNumDays_lbl)
        Me.generalPanel.Controls.Add(Me.translation_apikey_lbl)
        Me.generalPanel.Controls.Add(Me.translationApiKey)
        Me.generalPanel.Controls.Add(Me.weather_provider_lbl)
        Me.generalPanel.Controls.Add(Me.weatherProvider)
        Me.generalPanel.Controls.Add(Me.translation_provider_lbl)
        Me.generalPanel.Controls.Add(Me.translationProvider)
        Me.generalPanel.Controls.Add(Me.enableWeather)
        Me.generalPanel.Controls.Add(Me.enableTranslation)
        Me.generalPanel.Controls.Add(Me.weather_apikey_lbl)
        Me.generalPanel.Controls.Add(Me.weatherApiKey)
        Me.generalPanel.Controls.Add(Me.about_diagnostics)
        Me.generalPanel.Controls.Add(Me.share_details)
        Me.generalPanel.Controls.Add(Me.share)
        Me.generalPanel.Controls.Add(Me.send_details)
        Me.generalPanel.Controls.Add(Me.send)
        Me.generalPanel.Controls.Add(Me.selectRegularFile)
        Me.generalPanel.Controls.Add(Me.selectTitleFile)
        Me.generalPanel.Controls.Add(Me.fontsRegularFile)
        Me.generalPanel.Controls.Add(Me.fontsTitleFile)
        Me.generalPanel.Controls.Add(Me.fontsRegularFontName)
        Me.generalPanel.Controls.Add(Me.fontsTitleFontName)
        Me.generalPanel.Controls.Add(Me.fontsRegular_lbl)
        Me.generalPanel.Controls.Add(Me.fontsTitles_lbl)
        Me.generalPanel.Controls.Add(Me.saveLink)
        Me.generalPanel.Controls.Add(Me.apiServerDivider)
        Me.generalPanel.Controls.Add(Me.apiServerTitle)
        Me.generalPanel.Controls.Add(Me.diagsDivider)
        Me.generalPanel.Controls.Add(Me.diagsTitle)
        Me.generalPanel.Controls.Add(Me.fontsDivider)
        Me.generalPanel.Controls.Add(Me.fontsTitle)
        Me.generalPanel.Controls.Add(Me.attendanceDivider)
        Me.generalPanel.Controls.Add(Me.attendanceTitle)
        Me.generalPanel.Controls.Add(Me.addonsDivider)
        Me.generalPanel.Controls.Add(Me.addonsTitle)
        Me.generalPanel.Controls.Add(Me.languageDivider)
        Me.generalPanel.Controls.Add(Me.languageTitle)
        Me.generalPanel.Controls.Add(Me.show_all_lang)
        Me.generalPanel.Controls.Add(Me.ListBox1)
        Me.generalPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.generalPanel.Location = New System.Drawing.Point(3, 3)
        Me.generalPanel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 20)
        Me.generalPanel.Name = "generalPanel"
        Me.generalPanel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.generalPanel.Size = New System.Drawing.Size(696, 353)
        Me.generalPanel.TabIndex = 0
        '
        'workHours
        '
        Me.workHours.CustomFormat = "HH:mm"
        Me.workHours.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.workHours.Location = New System.Drawing.Point(350, 874)
        Me.workHours.Name = "workHours"
        Me.workHours.ShowUpDown = True
        Me.workHours.Size = New System.Drawing.Size(65, 20)
        Me.workHours.TabIndex = 386
        Me.workHours.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'workHours_lbl
        '
        Me.workHours_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.workHours_lbl.Location = New System.Drawing.Point(18, 870)
        Me.workHours_lbl.Name = "workHours_lbl"
        Me.workHours_lbl.Size = New System.Drawing.Size(305, 24)
        Me.workHours_lbl.TabIndex = 384
        Me.workHours_lbl.Text = "number of work hours in one day"
        Me.workHours_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'attendanceText
        '
        Me.attendanceText.AutoSize = True
        Me.attendanceText.Location = New System.Drawing.Point(180, 812)
        Me.attendanceText.Name = "attendanceText"
        Me.attendanceText.Size = New System.Drawing.Size(316, 13)
        Me.attendanceText.TabIndex = 383
        Me.attendanceText.Text = "number of delay days allowed for validation of attendance records"
        '
        'domain_web_ex
        '
        Me.domain_web_ex.AutoSize = True
        Me.domain_web_ex.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_web_ex.Location = New System.Drawing.Point(247, 1045)
        Me.domain_web_ex.Name = "domain_web_ex"
        Me.domain_web_ex.Size = New System.Drawing.Size(140, 12)
        Me.domain_web_ex.TabIndex = 382
        Me.domain_web_ex.Text = "ex.: http://www.yourdomain.com"
        '
        'server_web_addr_lbl
        '
        Me.server_web_addr_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.server_web_addr_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr_lbl.ForeColor = System.Drawing.Color.Gray
        Me.server_web_addr_lbl.Location = New System.Drawing.Point(57, 1024)
        Me.server_web_addr_lbl.Name = "server_web_addr_lbl"
        Me.server_web_addr_lbl.Size = New System.Drawing.Size(184, 18)
        Me.server_web_addr_lbl.TabIndex = 381
        Me.server_web_addr_lbl.Text = "Server web address"
        Me.server_web_addr_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'server_web_addr
        '
        Me.server_web_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr.Location = New System.Drawing.Point(249, 1021)
        Me.server_web_addr.Name = "server_web_addr"
        Me.server_web_addr.Size = New System.Drawing.Size(289, 21)
        Me.server_web_addr.TabIndex = 380
        '
        'attendanceNumDays
        '
        Me.attendanceNumDays.Location = New System.Drawing.Point(350, 842)
        Me.attendanceNumDays.Name = "attendanceNumDays"
        Me.attendanceNumDays.Size = New System.Drawing.Size(54, 20)
        Me.attendanceNumDays.TabIndex = 379
        '
        'attendanceNumDays_lbl
        '
        Me.attendanceNumDays_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.attendanceNumDays_lbl.Location = New System.Drawing.Point(24, 842)
        Me.attendanceNumDays_lbl.Name = "attendanceNumDays_lbl"
        Me.attendanceNumDays_lbl.Size = New System.Drawing.Size(299, 24)
        Me.attendanceNumDays_lbl.TabIndex = 378
        Me.attendanceNumDays_lbl.Text = "number of delay days"
        Me.attendanceNumDays_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'translation_apikey_lbl
        '
        Me.translation_apikey_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.translation_apikey_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_apikey_lbl.ForeColor = System.Drawing.Color.Gray
        Me.translation_apikey_lbl.Location = New System.Drawing.Point(1, 635)
        Me.translation_apikey_lbl.Name = "translation_apikey_lbl"
        Me.translation_apikey_lbl.Size = New System.Drawing.Size(132, 15)
        Me.translation_apikey_lbl.TabIndex = 377
        Me.translation_apikey_lbl.Text = "API Key"
        Me.translation_apikey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'translationApiKey
        '
        Me.translationApiKey.Enabled = False
        Me.translationApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationApiKey.Location = New System.Drawing.Point(228, 629)
        Me.translationApiKey.Name = "translationApiKey"
        Me.translationApiKey.Size = New System.Drawing.Size(236, 21)
        Me.translationApiKey.TabIndex = 376
        '
        'weather_provider_lbl
        '
        Me.weather_provider_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.weather_provider_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_provider_lbl.ForeColor = System.Drawing.Color.Gray
        Me.weather_provider_lbl.Location = New System.Drawing.Point(4, 707)
        Me.weather_provider_lbl.Name = "weather_provider_lbl"
        Me.weather_provider_lbl.Size = New System.Drawing.Size(133, 19)
        Me.weather_provider_lbl.TabIndex = 375
        Me.weather_provider_lbl.Text = "Provider"
        Me.weather_provider_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'weatherProvider
        '
        Me.weatherProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.weatherProvider.Enabled = False
        Me.weatherProvider.FormattingEnabled = True
        Me.weatherProvider.Items.AddRange(New Object() {"OpenWeatherMap.org"})
        Me.weatherProvider.Location = New System.Drawing.Point(228, 705)
        Me.weatherProvider.Name = "weatherProvider"
        Me.weatherProvider.Size = New System.Drawing.Size(142, 21)
        Me.weatherProvider.TabIndex = 374
        '
        'translation_provider_lbl
        '
        Me.translation_provider_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.translation_provider_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_provider_lbl.ForeColor = System.Drawing.Color.Gray
        Me.translation_provider_lbl.Location = New System.Drawing.Point(-2, 604)
        Me.translation_provider_lbl.Name = "translation_provider_lbl"
        Me.translation_provider_lbl.Size = New System.Drawing.Size(139, 19)
        Me.translation_provider_lbl.TabIndex = 373
        Me.translation_provider_lbl.Text = "Provider"
        Me.translation_provider_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'translationProvider
        '
        Me.translationProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.translationProvider.Enabled = False
        Me.translationProvider.FormattingEnabled = True
        Me.translationProvider.Items.AddRange(New Object() {"Google"})
        Me.translationProvider.Location = New System.Drawing.Point(228, 602)
        Me.translationProvider.Name = "translationProvider"
        Me.translationProvider.Size = New System.Drawing.Size(142, 21)
        Me.translationProvider.TabIndex = 372
        '
        'enableWeather
        '
        Me.enableWeather.AutoSize = True
        Me.enableWeather.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableWeather.Location = New System.Drawing.Point(145, 680)
        Me.enableWeather.Name = "enableWeather"
        Me.enableWeather.Size = New System.Drawing.Size(259, 19)
        Me.enableWeather.TabIndex = 371
        Me.enableWeather.Text = "Enable weather reports inside the platform"
        Me.enableWeather.UseVisualStyleBackColor = True
        '
        'enableTranslation
        '
        Me.enableTranslation.AutoSize = True
        Me.enableTranslation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableTranslation.Location = New System.Drawing.Point(145, 577)
        Me.enableTranslation.Name = "enableTranslation"
        Me.enableTranslation.Size = New System.Drawing.Size(231, 19)
        Me.enableTranslation.TabIndex = 370
        Me.enableTranslation.Text = "Enable translation inside the platform"
        Me.enableTranslation.UseVisualStyleBackColor = True
        '
        'weather_apikey_lbl
        '
        Me.weather_apikey_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.weather_apikey_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_apikey_lbl.ForeColor = System.Drawing.Color.Gray
        Me.weather_apikey_lbl.Location = New System.Drawing.Point(7, 735)
        Me.weather_apikey_lbl.Name = "weather_apikey_lbl"
        Me.weather_apikey_lbl.Size = New System.Drawing.Size(126, 18)
        Me.weather_apikey_lbl.TabIndex = 369
        Me.weather_apikey_lbl.Text = "API Key"
        Me.weather_apikey_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'weatherApiKey
        '
        Me.weatherApiKey.Enabled = False
        Me.weatherApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weatherApiKey.Location = New System.Drawing.Point(228, 732)
        Me.weatherApiKey.Name = "weatherApiKey"
        Me.weatherApiKey.Size = New System.Drawing.Size(236, 21)
        Me.weatherApiKey.TabIndex = 368
        '
        'about_diagnostics
        '
        Me.about_diagnostics.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.about_diagnostics.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.about_diagnostics.Location = New System.Drawing.Point(223, 499)
        Me.about_diagnostics.Name = "about_diagnostics"
        Me.about_diagnostics.Size = New System.Drawing.Size(370, 22)
        Me.about_diagnostics.TabIndex = 367
        Me.about_diagnostics.TabStop = True
        Me.about_diagnostics.Text = "About Diagnostics and Privacy ..."
        Me.about_diagnostics.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'share_details
        '
        Me.share_details.BackColor = System.Drawing.Color.White
        Me.share_details.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.share_details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.share_details.Location = New System.Drawing.Point(162, 457)
        Me.share_details.Multiline = True
        Me.share_details.Name = "share_details"
        Me.share_details.Size = New System.Drawing.Size(344, 57)
        Me.share_details.TabIndex = 366
        Me.share_details.Text = "Help app developers improve their apps by allowing us to share crash data with th" &
    "em."
        '
        'share
        '
        Me.share.AutoSize = True
        Me.share.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.share.Location = New System.Drawing.Point(145, 434)
        Me.share.Name = "share"
        Me.share.Size = New System.Drawing.Size(233, 19)
        Me.share.TabIndex = 365
        Me.share.Text = "Share crash data with app developers"
        Me.share.UseVisualStyleBackColor = True
        '
        'send_details
        '
        Me.send_details.BackColor = System.Drawing.Color.White
        Me.send_details.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.send_details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send_details.Location = New System.Drawing.Point(162, 371)
        Me.send_details.Multiline = True
        Me.send_details.Name = "send_details"
        Me.send_details.Size = New System.Drawing.Size(344, 57)
        Me.send_details.TabIndex = 364
        Me.send_details.Text = "Help us improve the products and services by automatically sending diagnostics an" &
    "d usage data. Diagnostic my include locations."
        '
        'send
        '
        Me.send.AutoSize = True
        Me.send.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send.Location = New System.Drawing.Point(145, 348)
        Me.send.Name = "send"
        Me.send.Size = New System.Drawing.Size(198, 19)
        Me.send.TabIndex = 363
        Me.send.Text = "Send diagnostics && usage data"
        Me.send.UseVisualStyleBackColor = True
        '
        'selectRegularFile
        '
        Me.selectRegularFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.selectRegularFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selectRegularFile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectRegularFile.ForeColor = System.Drawing.Color.White
        Me.selectRegularFile.Location = New System.Drawing.Point(529, 259)
        Me.selectRegularFile.Name = "selectRegularFile"
        Me.selectRegularFile.Size = New System.Drawing.Size(86, 22)
        Me.selectRegularFile.TabIndex = 362
        Me.selectRegularFile.Text = "escolher"
        Me.selectRegularFile.UseVisualStyleBackColor = False
        '
        'selectTitleFile
        '
        Me.selectTitleFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.selectTitleFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selectTitleFile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectTitleFile.ForeColor = System.Drawing.Color.White
        Me.selectTitleFile.Location = New System.Drawing.Point(529, 226)
        Me.selectTitleFile.Name = "selectTitleFile"
        Me.selectTitleFile.Size = New System.Drawing.Size(86, 22)
        Me.selectTitleFile.TabIndex = 361
        Me.selectTitleFile.Text = "escolher"
        Me.selectTitleFile.UseVisualStyleBackColor = False
        '
        'fontsRegularFile
        '
        Me.fontsRegularFile.Location = New System.Drawing.Point(263, 260)
        Me.fontsRegularFile.Name = "fontsRegularFile"
        Me.fontsRegularFile.Size = New System.Drawing.Size(257, 20)
        Me.fontsRegularFile.TabIndex = 360
        '
        'fontsTitleFile
        '
        Me.fontsTitleFile.Location = New System.Drawing.Point(263, 228)
        Me.fontsTitleFile.Name = "fontsTitleFile"
        Me.fontsTitleFile.Size = New System.Drawing.Size(257, 20)
        Me.fontsTitleFile.TabIndex = 359
        '
        'fontsRegularFontName
        '
        Me.fontsRegularFontName.AutoSize = True
        Me.fontsRegularFontName.Location = New System.Drawing.Point(112, 263)
        Me.fontsRegularFontName.Name = "fontsRegularFontName"
        Me.fontsRegularFontName.Size = New System.Drawing.Size(27, 13)
        Me.fontsRegularFontName.TabIndex = 358
        Me.fontsRegularFontName.Text = "Arial"
        '
        'fontsTitleFontName
        '
        Me.fontsTitleFontName.AutoSize = True
        Me.fontsTitleFontName.Location = New System.Drawing.Point(112, 228)
        Me.fontsTitleFontName.Name = "fontsTitleFontName"
        Me.fontsTitleFontName.Size = New System.Drawing.Size(27, 13)
        Me.fontsTitleFontName.TabIndex = 357
        Me.fontsTitleFontName.Text = "Arial"
        '
        'fontsRegular_lbl
        '
        Me.fontsRegular_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fontsRegular_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontsRegular_lbl.Location = New System.Drawing.Point(-12, 263)
        Me.fontsRegular_lbl.Name = "fontsRegular_lbl"
        Me.fontsRegular_lbl.Size = New System.Drawing.Size(103, 13)
        Me.fontsRegular_lbl.TabIndex = 356
        Me.fontsRegular_lbl.Text = "Regular text"
        Me.fontsRegular_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fontsTitles_lbl
        '
        Me.fontsTitles_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fontsTitles_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontsTitles_lbl.Location = New System.Drawing.Point(-9, 228)
        Me.fontsTitles_lbl.Name = "fontsTitles_lbl"
        Me.fontsTitles_lbl.Size = New System.Drawing.Size(100, 13)
        Me.fontsTitles_lbl.TabIndex = 355
        Me.fontsTitles_lbl.Text = "Titles"
        Me.fontsTitles_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'saveLink
        '
        Me.saveLink.AutoSize = True
        Me.saveLink.Location = New System.Drawing.Point(607, 1087)
        Me.saveLink.Name = "saveLink"
        Me.saveLink.Size = New System.Drawing.Size(32, 13)
        Me.saveLink.TabIndex = 354
        Me.saveLink.TabStop = True
        Me.saveLink.Text = "Save"
        '
        'apiServerDivider
        '
        Me.apiServerDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.apiServerDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.apiServerDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.apiServerDivider.Location = New System.Drawing.Point(5, 981)
        Me.apiServerDivider.Name = "apiServerDivider"
        Me.apiServerDivider.Size = New System.Drawing.Size(622, 4)
        Me.apiServerDivider.TabIndex = 353
        '
        'apiServerTitle
        '
        Me.apiServerTitle.AutoSize = True
        Me.apiServerTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.apiServerTitle.Location = New System.Drawing.Point(7, 961)
        Me.apiServerTitle.Name = "apiServerTitle"
        Me.apiServerTitle.Size = New System.Drawing.Size(82, 20)
        Me.apiServerTitle.TabIndex = 352
        Me.apiServerTitle.Text = "API server"
        '
        'diagsDivider
        '
        Me.diagsDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.diagsDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.diagsDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.diagsDivider.Location = New System.Drawing.Point(11, 333)
        Me.diagsDivider.Name = "diagsDivider"
        Me.diagsDivider.Size = New System.Drawing.Size(622, 4)
        Me.diagsDivider.TabIndex = 351
        '
        'diagsTitle
        '
        Me.diagsTitle.AutoSize = True
        Me.diagsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagsTitle.Location = New System.Drawing.Point(13, 313)
        Me.diagsTitle.Name = "diagsTitle"
        Me.diagsTitle.Size = New System.Drawing.Size(189, 20)
        Me.diagsTitle.TabIndex = 350
        Me.diagsTitle.Text = "Diagnostics && Crash data"
        '
        'fontsDivider
        '
        Me.fontsDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.fontsDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fontsDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.fontsDivider.Location = New System.Drawing.Point(17, 208)
        Me.fontsDivider.Name = "fontsDivider"
        Me.fontsDivider.Size = New System.Drawing.Size(622, 4)
        Me.fontsDivider.TabIndex = 349
        '
        'fontsTitle
        '
        Me.fontsTitle.AutoSize = True
        Me.fontsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontsTitle.Location = New System.Drawing.Point(19, 188)
        Me.fontsTitle.Name = "fontsTitle"
        Me.fontsTitle.Size = New System.Drawing.Size(50, 20)
        Me.fontsTitle.TabIndex = 348
        Me.fontsTitle.Text = "Fonts"
        '
        'attendanceDivider
        '
        Me.attendanceDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.attendanceDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.attendanceDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.attendanceDivider.Location = New System.Drawing.Point(11, 794)
        Me.attendanceDivider.Name = "attendanceDivider"
        Me.attendanceDivider.Size = New System.Drawing.Size(622, 4)
        Me.attendanceDivider.TabIndex = 347
        '
        'attendanceTitle
        '
        Me.attendanceTitle.AutoSize = True
        Me.attendanceTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.attendanceTitle.Location = New System.Drawing.Point(13, 774)
        Me.attendanceTitle.Name = "attendanceTitle"
        Me.attendanceTitle.Size = New System.Drawing.Size(153, 20)
        Me.attendanceTitle.TabIndex = 346
        Me.attendanceTitle.Text = "Workers attendance"
        '
        'addonsDivider
        '
        Me.addonsDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.addonsDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.addonsDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.addonsDivider.Location = New System.Drawing.Point(11, 548)
        Me.addonsDivider.Name = "addonsDivider"
        Me.addonsDivider.Size = New System.Drawing.Size(622, 4)
        Me.addonsDivider.TabIndex = 345
        '
        'addonsTitle
        '
        Me.addonsTitle.AutoSize = True
        Me.addonsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addonsTitle.Location = New System.Drawing.Point(13, 528)
        Me.addonsTitle.Name = "addonsTitle"
        Me.addonsTitle.Size = New System.Drawing.Size(64, 20)
        Me.addonsTitle.TabIndex = 344
        Me.addonsTitle.Text = "Addons"
        '
        'languageDivider
        '
        Me.languageDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.languageDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.languageDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.languageDivider.Location = New System.Drawing.Point(23, 31)
        Me.languageDivider.Name = "languageDivider"
        Me.languageDivider.Size = New System.Drawing.Size(622, 4)
        Me.languageDivider.TabIndex = 343
        '
        'languageTitle
        '
        Me.languageTitle.AutoSize = True
        Me.languageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.languageTitle.Location = New System.Drawing.Point(25, 11)
        Me.languageTitle.Name = "languageTitle"
        Me.languageTitle.Size = New System.Drawing.Size(81, 20)
        Me.languageTitle.TabIndex = 342
        Me.languageTitle.Text = "Language"
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(209, 173)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(66, 17)
        Me.show_all_lang.TabIndex = 6
        Me.show_all_lang.Text = "Show all"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(209, 48)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(254, 119)
        Me.ListBox1.TabIndex = 5
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.fontsPanel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(702, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Fonts & Colors"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'fontsPanel
        '
        Me.fontsPanel.AutoScroll = True
        Me.fontsPanel.Controls.Add(Me.lateralMenu_lbl)
        Me.fontsPanel.Controls.Add(Me.lateralMenu_color)
        Me.fontsPanel.Controls.Add(Me.lateralMenu_box)
        Me.fontsPanel.Controls.Add(Me.saveColorsLink)
        Me.fontsPanel.Controls.Add(Me.sites_lbl)
        Me.fontsPanel.Controls.Add(Me.sites_color)
        Me.fontsPanel.Controls.Add(Me.sites_box)
        Me.fontsPanel.Controls.Add(Me.sections_lbl)
        Me.fontsPanel.Controls.Add(Me.sections_color)
        Me.fontsPanel.Controls.Add(Me.sections_box)
        Me.fontsPanel.Controls.Add(Me.companies_lbl)
        Me.fontsPanel.Controls.Add(Me.companies_color)
        Me.fontsPanel.Controls.Add(Me.companies_box)
        Me.fontsPanel.Controls.Add(Me.workCategories_lbl)
        Me.fontsPanel.Controls.Add(Me.workCategories_color)
        Me.fontsPanel.Controls.Add(Me.workCategories_box)
        Me.fontsPanel.Controls.Add(Me.plannedAbsense_lbl)
        Me.fontsPanel.Controls.Add(Me.plannedAbsense_color)
        Me.fontsPanel.Controls.Add(Me.plannedAbsense_box)
        Me.fontsPanel.Controls.Add(Me.holidays_lbl)
        Me.fontsPanel.Controls.Add(Me.holidays_color)
        Me.fontsPanel.Controls.Add(Me.holidays_box)
        Me.fontsPanel.Controls.Add(Me.record_lbl)
        Me.fontsPanel.Controls.Add(Me.record_color)
        Me.fontsPanel.Controls.Add(Me.record_box)
        Me.fontsPanel.Controls.Add(Me.absentDayValidated_lbl)
        Me.fontsPanel.Controls.Add(Me.absentDayValidated_color)
        Me.fontsPanel.Controls.Add(Me.absentDayValidated_box)
        Me.fontsPanel.Controls.Add(Me.annualCloseDays_lbl)
        Me.fontsPanel.Controls.Add(Me.annualCloseDays_color)
        Me.fontsPanel.Controls.Add(Me.annualCloseDays_box)
        Me.fontsPanel.Controls.Add(Me.withoutRecord_lbl)
        Me.fontsPanel.Controls.Add(Me.withoutRecord_color)
        Me.fontsPanel.Controls.Add(Me.withoutRecord_box)
        Me.fontsPanel.Controls.Add(Me.weekends_lbl)
        Me.fontsPanel.Controls.Add(Me.weekends_color)
        Me.fontsPanel.Controls.Add(Me.weekends_box)
        Me.fontsPanel.Controls.Add(Me.partialDayValidated_lbl)
        Me.fontsPanel.Controls.Add(Me.partialDayValidated_color)
        Me.fontsPanel.Controls.Add(Me.partialDayValidated_box)
        Me.fontsPanel.Controls.Add(Me.plannedSiteChange_lbl)
        Me.fontsPanel.Controls.Add(Me.plannedSiteChange_color)
        Me.fontsPanel.Controls.Add(Me.plannedSiteChange_box)
        Me.fontsPanel.Controls.Add(Me.plannedTeam_lbl)
        Me.fontsPanel.Controls.Add(Me.plannedTeam_color)
        Me.fontsPanel.Controls.Add(Me.plannedTeam_box)
        Me.fontsPanel.Controls.Add(Me.fullDayValidated_lbl)
        Me.fontsPanel.Controls.Add(Me.fullDayValidated_color)
        Me.fontsPanel.Controls.Add(Me.fullDayValidated_box)
        Me.fontsPanel.Controls.Add(Me.dividers_lbl)
        Me.fontsPanel.Controls.Add(Me.dividers_color)
        Me.fontsPanel.Controls.Add(Me.dividers_box)
        Me.fontsPanel.Controls.Add(Me.buttons_lbl)
        Me.fontsPanel.Controls.Add(Me.buttons_color)
        Me.fontsPanel.Controls.Add(Me.buttons_box)
        Me.fontsPanel.Controls.Add(Me.datatableResetLink)
        Me.fontsPanel.Controls.Add(Me.generalResetLink)
        Me.fontsPanel.Controls.Add(Me.datatablesDivider)
        Me.fontsPanel.Controls.Add(Me.datatablesTitle)
        Me.fontsPanel.Controls.Add(Me.generalDivider)
        Me.fontsPanel.Controls.Add(Me.generalTitle)
        Me.fontsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fontsPanel.Location = New System.Drawing.Point(3, 3)
        Me.fontsPanel.MaximumSize = New System.Drawing.Size(0, 700)
        Me.fontsPanel.Name = "fontsPanel"
        Me.fontsPanel.Size = New System.Drawing.Size(696, 353)
        Me.fontsPanel.TabIndex = 0
        '
        'lateralMenu_lbl
        '
        Me.lateralMenu_lbl.AutoSize = True
        Me.lateralMenu_lbl.CausesValidation = False
        Me.lateralMenu_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lateralMenu_lbl.Location = New System.Drawing.Point(333, 103)
        Me.lateralMenu_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lateralMenu_lbl.Name = "lateralMenu_lbl"
        Me.lateralMenu_lbl.Size = New System.Drawing.Size(112, 13)
        Me.lateralMenu_lbl.TabIndex = 439
        Me.lateralMenu_lbl.Text = "Lateral Main Menu"
        '
        'lateralMenu_color
        '
        Me.lateralMenu_color.AutoSize = True
        Me.lateralMenu_color.CausesValidation = False
        Me.lateralMenu_color.Location = New System.Drawing.Point(390, 127)
        Me.lateralMenu_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lateralMenu_color.Name = "lateralMenu_color"
        Me.lateralMenu_color.Size = New System.Drawing.Size(69, 13)
        Me.lateralMenu_color.TabIndex = 438
        Me.lateralMenu_color.Text = "Color or RGB"
        '
        'lateralMenu_box
        '
        Me.lateralMenu_box.AutoSize = True
        Me.lateralMenu_box.BackColor = System.Drawing.Color.MistyRose
        Me.lateralMenu_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lateralMenu_box.CausesValidation = False
        Me.lateralMenu_box.Location = New System.Drawing.Point(361, 125)
        Me.lateralMenu_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lateralMenu_box.Name = "lateralMenu_box"
        Me.lateralMenu_box.Size = New System.Drawing.Size(15, 15)
        Me.lateralMenu_box.TabIndex = 437
        Me.lateralMenu_box.Text = "  "
        '
        'saveColorsLink
        '
        Me.saveColorsLink.AutoSize = True
        Me.saveColorsLink.Location = New System.Drawing.Point(583, 746)
        Me.saveColorsLink.Name = "saveColorsLink"
        Me.saveColorsLink.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.saveColorsLink.Size = New System.Drawing.Size(32, 33)
        Me.saveColorsLink.TabIndex = 436
        Me.saveColorsLink.TabStop = True
        Me.saveColorsLink.Text = "Save"
        '
        'sites_lbl
        '
        Me.sites_lbl.AutoSize = True
        Me.sites_lbl.CausesValidation = False
        Me.sites_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sites_lbl.Location = New System.Drawing.Point(57, 655)
        Me.sites_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sites_lbl.Name = "sites_lbl"
        Me.sites_lbl.Size = New System.Drawing.Size(35, 13)
        Me.sites_lbl.TabIndex = 422
        Me.sites_lbl.Text = "Sites"
        '
        'sites_color
        '
        Me.sites_color.AutoSize = True
        Me.sites_color.CausesValidation = False
        Me.sites_color.Location = New System.Drawing.Point(114, 679)
        Me.sites_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sites_color.Name = "sites_color"
        Me.sites_color.Size = New System.Drawing.Size(69, 13)
        Me.sites_color.TabIndex = 421
        Me.sites_color.Text = "Color or RGB"
        '
        'sites_box
        '
        Me.sites_box.AutoSize = True
        Me.sites_box.BackColor = System.Drawing.Color.MistyRose
        Me.sites_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sites_box.CausesValidation = False
        Me.sites_box.Location = New System.Drawing.Point(85, 677)
        Me.sites_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sites_box.Name = "sites_box"
        Me.sites_box.Size = New System.Drawing.Size(15, 15)
        Me.sites_box.TabIndex = 420
        Me.sites_box.Text = "  "
        '
        'sections_lbl
        '
        Me.sections_lbl.AutoSize = True
        Me.sections_lbl.CausesValidation = False
        Me.sections_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sections_lbl.Location = New System.Drawing.Point(354, 591)
        Me.sections_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sections_lbl.Name = "sections_lbl"
        Me.sections_lbl.Size = New System.Drawing.Size(80, 13)
        Me.sections_lbl.TabIndex = 418
        Me.sections_lbl.Text = "Site sections"
        '
        'sections_color
        '
        Me.sections_color.AutoSize = True
        Me.sections_color.CausesValidation = False
        Me.sections_color.Location = New System.Drawing.Point(411, 615)
        Me.sections_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sections_color.Name = "sections_color"
        Me.sections_color.Size = New System.Drawing.Size(69, 13)
        Me.sections_color.TabIndex = 417
        Me.sections_color.Text = "Color or RGB"
        '
        'sections_box
        '
        Me.sections_box.AutoSize = True
        Me.sections_box.BackColor = System.Drawing.Color.MistyRose
        Me.sections_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sections_box.CausesValidation = False
        Me.sections_box.Location = New System.Drawing.Point(382, 613)
        Me.sections_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sections_box.Name = "sections_box"
        Me.sections_box.Size = New System.Drawing.Size(15, 15)
        Me.sections_box.TabIndex = 416
        Me.sections_box.Text = "  "
        '
        'companies_lbl
        '
        Me.companies_lbl.AutoSize = True
        Me.companies_lbl.CausesValidation = False
        Me.companies_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companies_lbl.Location = New System.Drawing.Point(57, 591)
        Me.companies_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companies_lbl.Name = "companies_lbl"
        Me.companies_lbl.Size = New System.Drawing.Size(68, 13)
        Me.companies_lbl.TabIndex = 414
        Me.companies_lbl.Text = "Companies"
        '
        'companies_color
        '
        Me.companies_color.AutoSize = True
        Me.companies_color.CausesValidation = False
        Me.companies_color.Location = New System.Drawing.Point(114, 615)
        Me.companies_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companies_color.Name = "companies_color"
        Me.companies_color.Size = New System.Drawing.Size(69, 13)
        Me.companies_color.TabIndex = 413
        Me.companies_color.Text = "Color or RGB"
        '
        'companies_box
        '
        Me.companies_box.AutoSize = True
        Me.companies_box.BackColor = System.Drawing.Color.MistyRose
        Me.companies_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.companies_box.CausesValidation = False
        Me.companies_box.Location = New System.Drawing.Point(85, 613)
        Me.companies_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companies_box.Name = "companies_box"
        Me.companies_box.Size = New System.Drawing.Size(15, 15)
        Me.companies_box.TabIndex = 412
        Me.companies_box.Text = "  "
        '
        'workCategories_lbl
        '
        Me.workCategories_lbl.AutoSize = True
        Me.workCategories_lbl.CausesValidation = False
        Me.workCategories_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workCategories_lbl.Location = New System.Drawing.Point(354, 532)
        Me.workCategories_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workCategories_lbl.Name = "workCategories_lbl"
        Me.workCategories_lbl.Size = New System.Drawing.Size(100, 13)
        Me.workCategories_lbl.TabIndex = 410
        Me.workCategories_lbl.Text = "Work categories"
        '
        'workCategories_color
        '
        Me.workCategories_color.AutoSize = True
        Me.workCategories_color.CausesValidation = False
        Me.workCategories_color.Location = New System.Drawing.Point(411, 556)
        Me.workCategories_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workCategories_color.Name = "workCategories_color"
        Me.workCategories_color.Size = New System.Drawing.Size(69, 13)
        Me.workCategories_color.TabIndex = 409
        Me.workCategories_color.Text = "Color or RGB"
        '
        'workCategories_box
        '
        Me.workCategories_box.AutoSize = True
        Me.workCategories_box.BackColor = System.Drawing.Color.MistyRose
        Me.workCategories_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.workCategories_box.CausesValidation = False
        Me.workCategories_box.Location = New System.Drawing.Point(382, 554)
        Me.workCategories_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workCategories_box.Name = "workCategories_box"
        Me.workCategories_box.Size = New System.Drawing.Size(15, 15)
        Me.workCategories_box.TabIndex = 408
        Me.workCategories_box.Text = "  "
        '
        'plannedAbsense_lbl
        '
        Me.plannedAbsense_lbl.AutoSize = True
        Me.plannedAbsense_lbl.CausesValidation = False
        Me.plannedAbsense_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plannedAbsense_lbl.Location = New System.Drawing.Point(57, 532)
        Me.plannedAbsense_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedAbsense_lbl.Name = "plannedAbsense_lbl"
        Me.plannedAbsense_lbl.Size = New System.Drawing.Size(104, 13)
        Me.plannedAbsense_lbl.TabIndex = 406
        Me.plannedAbsense_lbl.Text = "Planned absense"
        '
        'plannedAbsense_color
        '
        Me.plannedAbsense_color.AutoSize = True
        Me.plannedAbsense_color.CausesValidation = False
        Me.plannedAbsense_color.Location = New System.Drawing.Point(114, 556)
        Me.plannedAbsense_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedAbsense_color.Name = "plannedAbsense_color"
        Me.plannedAbsense_color.Size = New System.Drawing.Size(69, 13)
        Me.plannedAbsense_color.TabIndex = 405
        Me.plannedAbsense_color.Text = "Color or RGB"
        '
        'plannedAbsense_box
        '
        Me.plannedAbsense_box.AutoSize = True
        Me.plannedAbsense_box.BackColor = System.Drawing.Color.MistyRose
        Me.plannedAbsense_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plannedAbsense_box.CausesValidation = False
        Me.plannedAbsense_box.Location = New System.Drawing.Point(85, 554)
        Me.plannedAbsense_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedAbsense_box.Name = "plannedAbsense_box"
        Me.plannedAbsense_box.Size = New System.Drawing.Size(15, 15)
        Me.plannedAbsense_box.TabIndex = 404
        Me.plannedAbsense_box.Text = "  "
        '
        'holidays_lbl
        '
        Me.holidays_lbl.AutoSize = True
        Me.holidays_lbl.CausesValidation = False
        Me.holidays_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.holidays_lbl.Location = New System.Drawing.Point(354, 418)
        Me.holidays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.holidays_lbl.Name = "holidays_lbl"
        Me.holidays_lbl.Size = New System.Drawing.Size(55, 13)
        Me.holidays_lbl.TabIndex = 402
        Me.holidays_lbl.Text = "Holidays"
        '
        'holidays_color
        '
        Me.holidays_color.AutoSize = True
        Me.holidays_color.CausesValidation = False
        Me.holidays_color.Location = New System.Drawing.Point(411, 442)
        Me.holidays_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.holidays_color.Name = "holidays_color"
        Me.holidays_color.Size = New System.Drawing.Size(69, 13)
        Me.holidays_color.TabIndex = 401
        Me.holidays_color.Text = "Color or RGB"
        '
        'holidays_box
        '
        Me.holidays_box.AutoSize = True
        Me.holidays_box.BackColor = System.Drawing.Color.MistyRose
        Me.holidays_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.holidays_box.CausesValidation = False
        Me.holidays_box.Location = New System.Drawing.Point(382, 440)
        Me.holidays_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.holidays_box.Name = "holidays_box"
        Me.holidays_box.Size = New System.Drawing.Size(15, 15)
        Me.holidays_box.TabIndex = 400
        Me.holidays_box.Text = "  "
        '
        'record_lbl
        '
        Me.record_lbl.AutoSize = True
        Me.record_lbl.CausesValidation = False
        Me.record_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.record_lbl.Location = New System.Drawing.Point(57, 418)
        Me.record_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.record_lbl.Name = "record_lbl"
        Me.record_lbl.Size = New System.Drawing.Size(150, 13)
        Me.record_lbl.TabIndex = 398
        Me.record_lbl.Text = "Atendance on site record"
        '
        'record_color
        '
        Me.record_color.AutoSize = True
        Me.record_color.CausesValidation = False
        Me.record_color.Location = New System.Drawing.Point(114, 442)
        Me.record_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.record_color.Name = "record_color"
        Me.record_color.Size = New System.Drawing.Size(69, 13)
        Me.record_color.TabIndex = 397
        Me.record_color.Text = "Color or RGB"
        '
        'record_box
        '
        Me.record_box.AutoSize = True
        Me.record_box.BackColor = System.Drawing.Color.MistyRose
        Me.record_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.record_box.CausesValidation = False
        Me.record_box.Location = New System.Drawing.Point(85, 440)
        Me.record_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.record_box.Name = "record_box"
        Me.record_box.Size = New System.Drawing.Size(15, 15)
        Me.record_box.TabIndex = 396
        Me.record_box.Text = "  "
        '
        'absentDayValidated_lbl
        '
        Me.absentDayValidated_lbl.AutoSize = True
        Me.absentDayValidated_lbl.CausesValidation = False
        Me.absentDayValidated_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.absentDayValidated_lbl.Location = New System.Drawing.Point(354, 359)
        Me.absentDayValidated_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.absentDayValidated_lbl.Name = "absentDayValidated_lbl"
        Me.absentDayValidated_lbl.Size = New System.Drawing.Size(128, 13)
        Me.absentDayValidated_lbl.TabIndex = 394
        Me.absentDayValidated_lbl.Text = "Absent Day validated"
        '
        'absentDayValidated_color
        '
        Me.absentDayValidated_color.AutoSize = True
        Me.absentDayValidated_color.CausesValidation = False
        Me.absentDayValidated_color.Location = New System.Drawing.Point(411, 384)
        Me.absentDayValidated_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.absentDayValidated_color.Name = "absentDayValidated_color"
        Me.absentDayValidated_color.Size = New System.Drawing.Size(69, 13)
        Me.absentDayValidated_color.TabIndex = 393
        Me.absentDayValidated_color.Text = "Color or RGB"
        '
        'absentDayValidated_box
        '
        Me.absentDayValidated_box.AutoSize = True
        Me.absentDayValidated_box.BackColor = System.Drawing.Color.MistyRose
        Me.absentDayValidated_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.absentDayValidated_box.CausesValidation = False
        Me.absentDayValidated_box.Location = New System.Drawing.Point(382, 382)
        Me.absentDayValidated_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.absentDayValidated_box.Name = "absentDayValidated_box"
        Me.absentDayValidated_box.Size = New System.Drawing.Size(15, 15)
        Me.absentDayValidated_box.TabIndex = 392
        Me.absentDayValidated_box.Text = "  "
        '
        'annualCloseDays_lbl
        '
        Me.annualCloseDays_lbl.AutoSize = True
        Me.annualCloseDays_lbl.CausesValidation = False
        Me.annualCloseDays_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.annualCloseDays_lbl.Location = New System.Drawing.Point(57, 359)
        Me.annualCloseDays_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annualCloseDays_lbl.Name = "annualCloseDays_lbl"
        Me.annualCloseDays_lbl.Size = New System.Drawing.Size(174, 13)
        Me.annualCloseDays_lbl.TabIndex = 390
        Me.annualCloseDays_lbl.Text = "Scheduled Annual close days"
        '
        'annualCloseDays_color
        '
        Me.annualCloseDays_color.AutoSize = True
        Me.annualCloseDays_color.CausesValidation = False
        Me.annualCloseDays_color.Location = New System.Drawing.Point(114, 384)
        Me.annualCloseDays_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annualCloseDays_color.Name = "annualCloseDays_color"
        Me.annualCloseDays_color.Size = New System.Drawing.Size(69, 13)
        Me.annualCloseDays_color.TabIndex = 389
        Me.annualCloseDays_color.Text = "Color or RGB"
        '
        'annualCloseDays_box
        '
        Me.annualCloseDays_box.AutoSize = True
        Me.annualCloseDays_box.BackColor = System.Drawing.Color.MistyRose
        Me.annualCloseDays_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.annualCloseDays_box.CausesValidation = False
        Me.annualCloseDays_box.Location = New System.Drawing.Point(85, 382)
        Me.annualCloseDays_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annualCloseDays_box.Name = "annualCloseDays_box"
        Me.annualCloseDays_box.Size = New System.Drawing.Size(15, 15)
        Me.annualCloseDays_box.TabIndex = 388
        Me.annualCloseDays_box.Text = "  "
        '
        'withoutRecord_lbl
        '
        Me.withoutRecord_lbl.AutoSize = True
        Me.withoutRecord_lbl.CausesValidation = False
        Me.withoutRecord_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.withoutRecord_lbl.Location = New System.Drawing.Point(354, 474)
        Me.withoutRecord_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.withoutRecord_lbl.Name = "withoutRecord_lbl"
        Me.withoutRecord_lbl.Size = New System.Drawing.Size(139, 13)
        Me.withoutRecord_lbl.TabIndex = 386
        Me.withoutRecord_lbl.Text = "Worker without records"
        '
        'withoutRecord_color
        '
        Me.withoutRecord_color.AutoSize = True
        Me.withoutRecord_color.CausesValidation = False
        Me.withoutRecord_color.Location = New System.Drawing.Point(411, 498)
        Me.withoutRecord_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.withoutRecord_color.Name = "withoutRecord_color"
        Me.withoutRecord_color.Size = New System.Drawing.Size(69, 13)
        Me.withoutRecord_color.TabIndex = 385
        Me.withoutRecord_color.Text = "Color or RGB"
        '
        'withoutRecord_box
        '
        Me.withoutRecord_box.AutoSize = True
        Me.withoutRecord_box.BackColor = System.Drawing.Color.MistyRose
        Me.withoutRecord_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.withoutRecord_box.CausesValidation = False
        Me.withoutRecord_box.Location = New System.Drawing.Point(382, 496)
        Me.withoutRecord_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.withoutRecord_box.Name = "withoutRecord_box"
        Me.withoutRecord_box.Size = New System.Drawing.Size(15, 15)
        Me.withoutRecord_box.TabIndex = 384
        Me.withoutRecord_box.Text = "  "
        '
        'weekends_lbl
        '
        Me.weekends_lbl.AutoSize = True
        Me.weekends_lbl.CausesValidation = False
        Me.weekends_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weekends_lbl.Location = New System.Drawing.Point(57, 474)
        Me.weekends_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weekends_lbl.Name = "weekends_lbl"
        Me.weekends_lbl.Size = New System.Drawing.Size(67, 13)
        Me.weekends_lbl.TabIndex = 382
        Me.weekends_lbl.Text = "Weekends"
        '
        'weekends_color
        '
        Me.weekends_color.AutoSize = True
        Me.weekends_color.CausesValidation = False
        Me.weekends_color.Location = New System.Drawing.Point(114, 498)
        Me.weekends_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weekends_color.Name = "weekends_color"
        Me.weekends_color.Size = New System.Drawing.Size(69, 13)
        Me.weekends_color.TabIndex = 381
        Me.weekends_color.Text = "Color or RGB"
        '
        'weekends_box
        '
        Me.weekends_box.AutoSize = True
        Me.weekends_box.BackColor = System.Drawing.Color.MistyRose
        Me.weekends_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.weekends_box.CausesValidation = False
        Me.weekends_box.Location = New System.Drawing.Point(85, 496)
        Me.weekends_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weekends_box.Name = "weekends_box"
        Me.weekends_box.Size = New System.Drawing.Size(15, 15)
        Me.weekends_box.TabIndex = 380
        Me.weekends_box.Text = "  "
        '
        'partialDayValidated_lbl
        '
        Me.partialDayValidated_lbl.AutoSize = True
        Me.partialDayValidated_lbl.CausesValidation = False
        Me.partialDayValidated_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.partialDayValidated_lbl.Location = New System.Drawing.Point(354, 295)
        Me.partialDayValidated_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.partialDayValidated_lbl.Name = "partialDayValidated_lbl"
        Me.partialDayValidated_lbl.Size = New System.Drawing.Size(125, 13)
        Me.partialDayValidated_lbl.TabIndex = 378
        Me.partialDayValidated_lbl.Text = "Partial Day validated"
        '
        'partialDayValidated_color
        '
        Me.partialDayValidated_color.AutoSize = True
        Me.partialDayValidated_color.CausesValidation = False
        Me.partialDayValidated_color.Location = New System.Drawing.Point(411, 319)
        Me.partialDayValidated_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.partialDayValidated_color.Name = "partialDayValidated_color"
        Me.partialDayValidated_color.Size = New System.Drawing.Size(69, 13)
        Me.partialDayValidated_color.TabIndex = 377
        Me.partialDayValidated_color.Text = "Color or RGB"
        '
        'partialDayValidated_box
        '
        Me.partialDayValidated_box.AutoSize = True
        Me.partialDayValidated_box.BackColor = System.Drawing.Color.MistyRose
        Me.partialDayValidated_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.partialDayValidated_box.CausesValidation = False
        Me.partialDayValidated_box.Location = New System.Drawing.Point(382, 317)
        Me.partialDayValidated_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.partialDayValidated_box.Name = "partialDayValidated_box"
        Me.partialDayValidated_box.Size = New System.Drawing.Size(15, 15)
        Me.partialDayValidated_box.TabIndex = 376
        Me.partialDayValidated_box.Text = "  "
        '
        'plannedSiteChange_lbl
        '
        Me.plannedSiteChange_lbl.AutoSize = True
        Me.plannedSiteChange_lbl.CausesValidation = False
        Me.plannedSiteChange_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plannedSiteChange_lbl.Location = New System.Drawing.Point(57, 295)
        Me.plannedSiteChange_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedSiteChange_lbl.Name = "plannedSiteChange_lbl"
        Me.plannedSiteChange_lbl.Size = New System.Drawing.Size(138, 13)
        Me.plannedSiteChange_lbl.TabIndex = 374
        Me.plannedSiteChange_lbl.Text = "Planned change of site"
        '
        'plannedSiteChange_color
        '
        Me.plannedSiteChange_color.AutoSize = True
        Me.plannedSiteChange_color.CausesValidation = False
        Me.plannedSiteChange_color.Location = New System.Drawing.Point(114, 319)
        Me.plannedSiteChange_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedSiteChange_color.Name = "plannedSiteChange_color"
        Me.plannedSiteChange_color.Size = New System.Drawing.Size(69, 13)
        Me.plannedSiteChange_color.TabIndex = 373
        Me.plannedSiteChange_color.Text = "Color or RGB"
        '
        'plannedSiteChange_box
        '
        Me.plannedSiteChange_box.AutoSize = True
        Me.plannedSiteChange_box.BackColor = System.Drawing.Color.MistyRose
        Me.plannedSiteChange_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plannedSiteChange_box.CausesValidation = False
        Me.plannedSiteChange_box.Location = New System.Drawing.Point(85, 317)
        Me.plannedSiteChange_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedSiteChange_box.Name = "plannedSiteChange_box"
        Me.plannedSiteChange_box.Size = New System.Drawing.Size(15, 15)
        Me.plannedSiteChange_box.TabIndex = 372
        Me.plannedSiteChange_box.Text = "  "
        '
        'plannedTeam_lbl
        '
        Me.plannedTeam_lbl.AutoSize = True
        Me.plannedTeam_lbl.CausesValidation = False
        Me.plannedTeam_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plannedTeam_lbl.Location = New System.Drawing.Point(354, 236)
        Me.plannedTeam_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedTeam_lbl.Name = "plannedTeam_lbl"
        Me.plannedTeam_lbl.Size = New System.Drawing.Size(88, 13)
        Me.plannedTeam_lbl.TabIndex = 370
        Me.plannedTeam_lbl.Text = "Planned Team"
        '
        'plannedTeam_color
        '
        Me.plannedTeam_color.AutoSize = True
        Me.plannedTeam_color.CausesValidation = False
        Me.plannedTeam_color.Location = New System.Drawing.Point(411, 260)
        Me.plannedTeam_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedTeam_color.Name = "plannedTeam_color"
        Me.plannedTeam_color.Size = New System.Drawing.Size(69, 13)
        Me.plannedTeam_color.TabIndex = 369
        Me.plannedTeam_color.Text = "Color or RGB"
        '
        'plannedTeam_box
        '
        Me.plannedTeam_box.AutoSize = True
        Me.plannedTeam_box.BackColor = System.Drawing.Color.MistyRose
        Me.plannedTeam_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plannedTeam_box.CausesValidation = False
        Me.plannedTeam_box.Location = New System.Drawing.Point(382, 258)
        Me.plannedTeam_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.plannedTeam_box.Name = "plannedTeam_box"
        Me.plannedTeam_box.Size = New System.Drawing.Size(15, 15)
        Me.plannedTeam_box.TabIndex = 368
        Me.plannedTeam_box.Text = "  "
        '
        'fullDayValidated_lbl
        '
        Me.fullDayValidated_lbl.AutoSize = True
        Me.fullDayValidated_lbl.CausesValidation = False
        Me.fullDayValidated_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fullDayValidated_lbl.Location = New System.Drawing.Point(57, 236)
        Me.fullDayValidated_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fullDayValidated_lbl.Name = "fullDayValidated_lbl"
        Me.fullDayValidated_lbl.Size = New System.Drawing.Size(109, 13)
        Me.fullDayValidated_lbl.TabIndex = 366
        Me.fullDayValidated_lbl.Text = "Full Day validated"
        '
        'fullDayValidated_color
        '
        Me.fullDayValidated_color.AutoSize = True
        Me.fullDayValidated_color.CausesValidation = False
        Me.fullDayValidated_color.Location = New System.Drawing.Point(114, 260)
        Me.fullDayValidated_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fullDayValidated_color.Name = "fullDayValidated_color"
        Me.fullDayValidated_color.Size = New System.Drawing.Size(69, 13)
        Me.fullDayValidated_color.TabIndex = 365
        Me.fullDayValidated_color.Text = "Color or RGB"
        '
        'fullDayValidated_box
        '
        Me.fullDayValidated_box.AutoSize = True
        Me.fullDayValidated_box.BackColor = System.Drawing.Color.MistyRose
        Me.fullDayValidated_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fullDayValidated_box.CausesValidation = False
        Me.fullDayValidated_box.Location = New System.Drawing.Point(85, 258)
        Me.fullDayValidated_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.fullDayValidated_box.Name = "fullDayValidated_box"
        Me.fullDayValidated_box.Size = New System.Drawing.Size(15, 15)
        Me.fullDayValidated_box.TabIndex = 364
        Me.fullDayValidated_box.Text = "  "
        '
        'dividers_lbl
        '
        Me.dividers_lbl.AutoSize = True
        Me.dividers_lbl.CausesValidation = False
        Me.dividers_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dividers_lbl.Location = New System.Drawing.Point(333, 51)
        Me.dividers_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.dividers_lbl.Name = "dividers_lbl"
        Me.dividers_lbl.Size = New System.Drawing.Size(53, 13)
        Me.dividers_lbl.TabIndex = 362
        Me.dividers_lbl.Text = "Dividers"
        '
        'dividers_color
        '
        Me.dividers_color.AutoSize = True
        Me.dividers_color.CausesValidation = False
        Me.dividers_color.Location = New System.Drawing.Point(390, 75)
        Me.dividers_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.dividers_color.Name = "dividers_color"
        Me.dividers_color.Size = New System.Drawing.Size(69, 13)
        Me.dividers_color.TabIndex = 361
        Me.dividers_color.Text = "Color or RGB"
        '
        'dividers_box
        '
        Me.dividers_box.AutoSize = True
        Me.dividers_box.BackColor = System.Drawing.Color.MistyRose
        Me.dividers_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dividers_box.CausesValidation = False
        Me.dividers_box.Location = New System.Drawing.Point(361, 73)
        Me.dividers_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.dividers_box.Name = "dividers_box"
        Me.dividers_box.Size = New System.Drawing.Size(15, 15)
        Me.dividers_box.TabIndex = 360
        Me.dividers_box.Text = "  "
        '
        'buttons_lbl
        '
        Me.buttons_lbl.AutoSize = True
        Me.buttons_lbl.CausesValidation = False
        Me.buttons_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttons_lbl.Location = New System.Drawing.Point(36, 51)
        Me.buttons_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.buttons_lbl.Name = "buttons_lbl"
        Me.buttons_lbl.Size = New System.Drawing.Size(50, 13)
        Me.buttons_lbl.TabIndex = 358
        Me.buttons_lbl.Text = "Buttons"
        '
        'buttons_color
        '
        Me.buttons_color.AutoSize = True
        Me.buttons_color.CausesValidation = False
        Me.buttons_color.Location = New System.Drawing.Point(93, 75)
        Me.buttons_color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.buttons_color.Name = "buttons_color"
        Me.buttons_color.Size = New System.Drawing.Size(69, 13)
        Me.buttons_color.TabIndex = 357
        Me.buttons_color.Text = "Color or RGB"
        '
        'buttons_box
        '
        Me.buttons_box.AutoSize = True
        Me.buttons_box.BackColor = System.Drawing.Color.MistyRose
        Me.buttons_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.buttons_box.CausesValidation = False
        Me.buttons_box.Location = New System.Drawing.Point(64, 73)
        Me.buttons_box.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.buttons_box.Name = "buttons_box"
        Me.buttons_box.Size = New System.Drawing.Size(15, 15)
        Me.buttons_box.TabIndex = 356
        Me.buttons_box.Text = "  "
        '
        'datatableResetLink
        '
        Me.datatableResetLink.AutoSize = True
        Me.datatableResetLink.Location = New System.Drawing.Point(57, 746)
        Me.datatableResetLink.Name = "datatableResetLink"
        Me.datatableResetLink.Padding = New System.Windows.Forms.Padding(0, 0, 0, 20)
        Me.datatableResetLink.Size = New System.Drawing.Size(30, 33)
        Me.datatableResetLink.TabIndex = 355
        Me.datatableResetLink.TabStop = True
        Me.datatableResetLink.Text = "reset"
        '
        'generalResetLink
        '
        Me.generalResetLink.AutoSize = True
        Me.generalResetLink.Location = New System.Drawing.Point(36, 157)
        Me.generalResetLink.Name = "generalResetLink"
        Me.generalResetLink.Size = New System.Drawing.Size(30, 13)
        Me.generalResetLink.TabIndex = 354
        Me.generalResetLink.TabStop = True
        Me.generalResetLink.Text = "reset"
        '
        'datatablesDivider
        '
        Me.datatablesDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.datatablesDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.datatablesDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.datatablesDivider.Location = New System.Drawing.Point(18, 211)
        Me.datatablesDivider.Name = "datatablesDivider"
        Me.datatablesDivider.Size = New System.Drawing.Size(622, 4)
        Me.datatablesDivider.TabIndex = 353
        '
        'datatablesTitle
        '
        Me.datatablesTitle.AutoSize = True
        Me.datatablesTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datatablesTitle.Location = New System.Drawing.Point(20, 191)
        Me.datatablesTitle.Name = "datatablesTitle"
        Me.datatablesTitle.Size = New System.Drawing.Size(87, 20)
        Me.datatablesTitle.TabIndex = 352
        Me.datatablesTitle.Text = "Datatables"
        '
        'generalDivider
        '
        Me.generalDivider.BackColor = System.Drawing.Color.LimeGreen
        Me.generalDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.generalDivider.ForeColor = System.Drawing.Color.GreenYellow
        Me.generalDivider.Location = New System.Drawing.Point(18, 32)
        Me.generalDivider.Name = "generalDivider"
        Me.generalDivider.Size = New System.Drawing.Size(622, 4)
        Me.generalDivider.TabIndex = 351
        '
        'generalTitle
        '
        Me.generalTitle.AutoSize = True
        Me.generalTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generalTitle.Location = New System.Drawing.Point(20, 12)
        Me.generalTitle.Name = "generalTitle"
        Me.generalTitle.Size = New System.Drawing.Size(66, 20)
        Me.generalTitle.TabIndex = 350
        Me.generalTitle.Text = "General"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.FullOpen = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.title)
        Me.Panel3.Controls.Add(Me.TabControl)
        Me.Panel3.Controls.Add(Me.closeBtn)
        Me.Panel3.Controls.Add(Me.divider)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(737, 485)
        Me.Panel3.TabIndex = 343
        '
        'CheckBoxCheckIn
        '
        Me.CheckBoxCheckIn.AutoSize = True
        Me.CheckBoxCheckIn.Location = New System.Drawing.Point(350, 907)
        Me.CheckBoxCheckIn.Name = "CheckBoxCheckIn"
        Me.CheckBoxCheckIn.Size = New System.Drawing.Size(66, 17)
        Me.CheckBoxCheckIn.TabIndex = 387
        Me.CheckBoxCheckIn.Text = "CheckIn"
        Me.CheckBoxCheckIn.UseVisualStyleBackColor = True
        '
        'validation_erase_lbl
        '
        Me.validation_erase_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.validation_erase_lbl.Location = New System.Drawing.Point(18, 902)
        Me.validation_erase_lbl.Name = "validation_erase_lbl"
        Me.validation_erase_lbl.Size = New System.Drawing.Size(305, 24)
        Me.validation_erase_lbl.TabIndex = 388
        Me.validation_erase_lbl.Text = "on validation erase "
        Me.validation_erase_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBoxCheckOut
        '
        Me.CheckBoxCheckOut.AutoSize = True
        Me.CheckBoxCheckOut.Location = New System.Drawing.Point(350, 930)
        Me.CheckBoxCheckOut.Name = "CheckBoxCheckOut"
        Me.CheckBoxCheckOut.Size = New System.Drawing.Size(74, 17)
        Me.CheckBoxCheckOut.TabIndex = 389
        Me.CheckBoxCheckOut.Text = "CheckOut"
        Me.CheckBoxCheckOut.UseVisualStyleBackColor = True
        '
        'settings_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 485)
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "settings_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.generalPanel.ResumeLayout(False)
        Me.generalPanel.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.fontsPanel.ResumeLayout(False)
        Me.fontsPanel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents closeBtn As Button
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents generalPanel As Panel
    Friend WithEvents languageDivider As Label
    Friend WithEvents languageTitle As Label
    Friend WithEvents show_all_lang As CheckBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents addonsDivider As Label
    Friend WithEvents addonsTitle As Label
    Friend WithEvents attendanceDivider As Label
    Friend WithEvents attendanceTitle As Label
    Friend WithEvents fontsDivider As Label
    Friend WithEvents fontsTitle As Label
    Friend WithEvents diagsDivider As Label
    Friend WithEvents diagsTitle As Label
    Friend WithEvents saveLink As LinkLabel
    Friend WithEvents apiServerDivider As Label
    Friend WithEvents apiServerTitle As Label
    Friend WithEvents selectRegularFile As Button
    Friend WithEvents selectTitleFile As Button
    Friend WithEvents fontsRegularFile As TextBox
    Friend WithEvents fontsTitleFile As TextBox
    Friend WithEvents fontsRegularFontName As Label
    Friend WithEvents fontsTitleFontName As Label
    Friend WithEvents fontsRegular_lbl As Label
    Friend WithEvents fontsTitles_lbl As Label
    Friend WithEvents about_diagnostics As LinkLabel
    Friend WithEvents share_details As TextBox
    Friend WithEvents share As CheckBox
    Friend WithEvents send_details As TextBox
    Friend WithEvents send As CheckBox
    Friend WithEvents attendanceNumDays As TextBox
    Friend WithEvents attendanceNumDays_lbl As Label
    Friend WithEvents translation_apikey_lbl As Label
    Friend WithEvents translationApiKey As TextBox
    Friend WithEvents weather_provider_lbl As Label
    Friend WithEvents weatherProvider As ComboBox
    Friend WithEvents translation_provider_lbl As Label
    Friend WithEvents translationProvider As ComboBox
    Friend WithEvents enableWeather As CheckBox
    Friend WithEvents enableTranslation As CheckBox
    Friend WithEvents weather_apikey_lbl As Label
    Friend WithEvents weatherApiKey As TextBox
    Friend WithEvents domain_web_ex As Label
    Friend WithEvents server_web_addr_lbl As Label
    Friend WithEvents server_web_addr As TextBox
    Friend WithEvents fontsPanel As Panel
    Friend WithEvents generalDivider As Label
    Friend WithEvents generalTitle As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents datatableResetLink As LinkLabel
    Friend WithEvents generalResetLink As LinkLabel
    Friend WithEvents datatablesDivider As Label
    Friend WithEvents datatablesTitle As Label
    Friend WithEvents buttons_color As Label
    Friend WithEvents buttons_box As Label
    Friend WithEvents withoutRecord_lbl As Label
    Friend WithEvents withoutRecord_color As Label
    Friend WithEvents withoutRecord_box As Label
    Friend WithEvents weekends_lbl As Label
    Friend WithEvents weekends_color As Label
    Friend WithEvents weekends_box As Label
    Friend WithEvents partialDayValidated_lbl As Label
    Friend WithEvents partialDayValidated_color As Label
    Friend WithEvents partialDayValidated_box As Label
    Friend WithEvents plannedSiteChange_lbl As Label
    Friend WithEvents plannedSiteChange_color As Label
    Friend WithEvents plannedSiteChange_box As Label
    Friend WithEvents plannedTeam_lbl As Label
    Friend WithEvents plannedTeam_color As Label
    Friend WithEvents plannedTeam_box As Label
    Friend WithEvents fullDayValidated_lbl As Label
    Friend WithEvents fullDayValidated_color As Label
    Friend WithEvents fullDayValidated_box As Label
    Friend WithEvents dividers_lbl As Label
    Friend WithEvents dividers_color As Label
    Friend WithEvents dividers_box As Label
    Friend WithEvents buttons_lbl As Label
    Friend WithEvents saveColorsLink As LinkLabel
    Friend WithEvents sites_lbl As Label
    Friend WithEvents sites_color As Label
    Friend WithEvents sites_box As Label
    Friend WithEvents sections_lbl As Label
    Friend WithEvents sections_color As Label
    Friend WithEvents sections_box As Label
    Friend WithEvents companies_lbl As Label
    Friend WithEvents companies_color As Label
    Friend WithEvents companies_box As Label
    Friend WithEvents workCategories_lbl As Label
    Friend WithEvents workCategories_color As Label
    Friend WithEvents workCategories_box As Label
    Friend WithEvents plannedAbsense_lbl As Label
    Friend WithEvents plannedAbsense_color As Label
    Friend WithEvents plannedAbsense_box As Label
    Friend WithEvents holidays_lbl As Label
    Friend WithEvents holidays_color As Label
    Friend WithEvents holidays_box As Label
    Friend WithEvents record_lbl As Label
    Friend WithEvents record_color As Label
    Friend WithEvents record_box As Label
    Friend WithEvents absentDayValidated_lbl As Label
    Friend WithEvents absentDayValidated_color As Label
    Friend WithEvents absentDayValidated_box As Label
    Friend WithEvents annualCloseDays_lbl As Label
    Friend WithEvents annualCloseDays_color As Label
    Friend WithEvents annualCloseDays_box As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents attendanceText As Label
    Friend WithEvents lateralMenu_lbl As Label
    Friend WithEvents lateralMenu_color As Label
    Friend WithEvents lateralMenu_box As Label
    Friend WithEvents workHours_lbl As Label
    Friend WithEvents workHours As DateTimePicker
    Friend WithEvents CheckBoxCheckOut As CheckBox
    Friend WithEvents validation_erase_lbl As Label
    Friend WithEvents CheckBoxCheckIn As CheckBox
End Class
