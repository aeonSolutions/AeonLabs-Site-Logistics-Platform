﻿Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class site_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(site_frm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.journal_tab = New System.Windows.Forms.TabPage()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
        Me.update_loggerBtn = New System.Windows.Forms.PictureBox()
        Me.update_journalBtn = New System.Windows.Forms.PictureBox()
        Me.logger_label = New System.Windows.Forms.Label()
        Me.journal_num_workers = New System.Windows.Forms.Label()
        Me.JournalGroupBoxSelection = New System.Windows.Forms.GroupBox()
        Me.journalLoadButton = New System.Windows.Forms.PictureBox()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.journalSection_lbl = New System.Windows.Forms.Label()
        Me.calendar = New System.Windows.Forms.DateTimePicker()
        Me.combo_section = New System.Windows.Forms.ComboBox()
        Me.journalData_lbl = New System.Windows.Forms.Label()
        Me.meteo_chk = New System.Windows.Forms.CheckBox()
        Me.journal_chk = New System.Windows.Forms.CheckBox()
        Me.qtds_chk = New System.Windows.Forms.CheckBox()
        Me.livraison_chk = New System.Windows.Forms.CheckBox()
        Me.regie_chk = New System.Windows.Forms.CheckBox()
        Me.journal_label = New System.Windows.Forms.Label()
        Me.categories_box = New System.Windows.Forms.CheckBox()
        Me.ocurrences_label = New System.Windows.Forms.Label()
        Me.view_doc = New System.Windows.Forms.LinkLabel()
        Me.activities_label = New System.Windows.Forms.Label()
        Me.ocurrences = New System.Windows.Forms.TextBox()
        Me.activities = New System.Windows.Forms.TextBox()
        Me.panel_journal = New System.Windows.Forms.Panel()
        Me.Panel_logger = New System.Windows.Forms.Panel()
        Me.bordereau_tab = New System.Windows.Forms.TabPage()
        Me.qtd_panel = New System.Windows.Forms.Panel()
        Me.bordereuGroupBoxSelection = New System.Windows.Forms.GroupBox()
        Me.qtd_acumulatedResultsChk = New System.Windows.Forms.CheckBox()
        Me.qtd_data_lbl = New System.Windows.Forms.Label()
        Me.qtd_setCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.qtd_data_fim = New System.Windows.Forms.DateTimePicker()
        Me.qtd_data_to = New System.Windows.Forms.Label()
        Me.qtd_data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.qtd_amountsChk = New System.Windows.Forms.CheckBox()
        Me.qtd_qtdChk = New System.Windows.Forms.CheckBox()
        Me.qtd_site = New System.Windows.Forms.ComboBox()
        Me.qtd_section = New System.Windows.Forms.ComboBox()
        Me.bordereau_sectionSelection_lbl = New System.Windows.Forms.Label()
        Me.LoadBordereau = New System.Windows.Forms.PictureBox()
        Me.qtd_datatable = New System.Windows.Forms.DataGridView()
        Me.qtd_tab = New System.Windows.Forms.TabPage()
        Me.auto_medicao_panel = New System.Windows.Forms.Panel()
        Me.auto_medicao_delBtn = New System.Windows.Forms.PictureBox()
        Me.auto_medicao_savebtn = New System.Windows.Forms.PictureBox()
        Me.auto_medicao_tasks_group = New System.Windows.Forms.GroupBox()
        Me.auto_medicao_update_tasks = New System.Windows.Forms.LinkLabel()
        Me.auto_medicao_tasks_list = New System.Windows.Forms.ListBox()
        Me.auto_medicao_workers_group = New System.Windows.Forms.GroupBox()
        Me.auto_medicao_workers_selected = New System.Windows.Forms.ListBox()
        Me.auto_medicao_update_workers = New System.Windows.Forms.LinkLabel()
        Me.auto_medicao_afetacao = New System.Windows.Forms.Label()
        Me.autoMedicaoWorkersOnSite_lbl = New System.Windows.Forms.Label()
        Me.auto_medicao_workers = New System.Windows.Forms.ListBox()
        Me.auto_medicao_qtd_group = New System.Windows.Forms.GroupBox()
        Me.auto_medicao_translate = New System.Windows.Forms.LinkLabel()
        Me.auto_medicao_units = New System.Windows.Forms.Label()
        Me.auto_medicao_reset = New System.Windows.Forms.LinkLabel()
        Me.auto_medicao_notas = New System.Windows.Forms.TextBox()
        Me.autoMedicaoRecordAnnotations_lbl = New System.Windows.Forms.Label()
        Me.autoMedicaoRecordDate_lbl = New System.Windows.Forms.Label()
        Me.auto_medicao_date = New System.Windows.Forms.DateTimePicker()
        Me.autoMedicaoRecordQtd_lbl = New System.Windows.Forms.Label()
        Me.auto_medicao_qtd = New System.Windows.Forms.TextBox()
        Me.auto_medicao_bar = New System.Windows.Forms.Label()
        Me.auto_medicao_title = New System.Windows.Forms.Label()
        Me.autoMedicaoGroupBoxSelection = New System.Windows.Forms.GroupBox()
        Me.autoMedicaoDate_lbl = New System.Windows.Forms.Label()
        Me.autoMedicaoSetCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.auto_medicao_site = New System.Windows.Forms.ComboBox()
        Me.auto_medicao_data_fim = New System.Windows.Forms.DateTimePicker()
        Me.auto_medicao_section = New System.Windows.Forms.ComboBox()
        Me.autoMedicaoDateTo_lbl = New System.Windows.Forms.Label()
        Me.autoMedicaoSection_lbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.auto_medicao_data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.auto_medicao_datatable = New System.Windows.Forms.DataGridView()
        Me.livraison_tab = New System.Windows.Forms.TabPage()
        Me.livraison_panel = New System.Windows.Forms.Panel()
        Me.livraison_GroupBox_siteSelection = New System.Windows.Forms.GroupBox()
        Me.statsLinkLivraison = New System.Windows.Forms.LinkLabel()
        Me.livraisonDate_lbl = New System.Windows.Forms.Label()
        Me.livraisonCurrentMonthSelection_lbl = New System.Windows.Forms.LinkLabel()
        Me.livraison_site = New System.Windows.Forms.ComboBox()
        Me.livraison_data_fim = New System.Windows.Forms.DateTimePicker()
        Me.livraison_section = New System.Windows.Forms.ComboBox()
        Me.livraisonDateTo_lbl = New System.Windows.Forms.Label()
        Me.livraisonSection_lbl = New System.Windows.Forms.Label()
        Me.select_site = New System.Windows.Forms.PictureBox()
        Me.livraison_data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.livraison_datatable = New System.Windows.Forms.DataGridView()
        Me.del_photo = New System.Windows.Forms.LinkLabel()
        Me.add_photo = New System.Windows.Forms.LinkLabel()
        Me.view_photo = New System.Windows.Forms.LinkLabel()
        Me.LivraisonPhotoSelection = New System.Windows.Forms.ComboBox()
        Me.download_photo = New System.Windows.Forms.LinkLabel()
        Me.photo_separator = New System.Windows.Forms.Label()
        Me.photo_title = New System.Windows.Forms.Label()
        Me.LivraisonPhoto = New System.Windows.Forms.PictureBox()
        Me.regie_tab = New System.Windows.Forms.TabPage()
        Me.regie_panel = New System.Windows.Forms.Panel()
        Me.regieGroupBox_siteSelection = New System.Windows.Forms.GroupBox()
        Me.regie_date_lbl = New System.Windows.Forms.Label()
        Me.regieSetCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.regie_site = New System.Windows.Forms.ComboBox()
        Me.regie_data_fim = New System.Windows.Forms.DateTimePicker()
        Me.regie_section = New System.Windows.Forms.ComboBox()
        Me.regie_dateTo_lbl = New System.Windows.Forms.Label()
        Me.regie_section_lbl = New System.Windows.Forms.Label()
        Me.regie_select_site = New System.Windows.Forms.PictureBox()
        Me.regie_data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox_legenda = New System.Windows.Forms.GroupBox()
        Me.regieLegendOngoing = New System.Windows.Forms.Label()
        Me.ongoingBox = New System.Windows.Forms.Label()
        Me.regieLegendAutoEod = New System.Windows.Forms.Label()
        Me.autoEodBox = New System.Windows.Forms.Label()
        Me.regieLegendEod = New System.Windows.Forms.Label()
        Me.eodBox = New System.Windows.Forms.Label()
        Me.regieLegendClosed = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.regie_datatable = New System.Windows.Forms.DataGridView()
        Me.regie_del_photo = New System.Windows.Forms.LinkLabel()
        Me.regie_add_photo = New System.Windows.Forms.LinkLabel()
        Me.regie_view_photo = New System.Windows.Forms.LinkLabel()
        Me.regiePhotoSelection = New System.Windows.Forms.ComboBox()
        Me.regie_download_photo = New System.Windows.Forms.LinkLabel()
        Me.regie_photo_separator = New System.Windows.Forms.Label()
        Me.regie_photo_title = New System.Windows.Forms.Label()
        Me.regiePhoto = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl.SuspendLayout()
        Me.journal_tab.SuspendLayout()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.update_loggerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.update_journalBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.JournalGroupBoxSelection.SuspendLayout()
        CType(Me.journalLoadButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bordereau_tab.SuspendLayout()
        Me.qtd_panel.SuspendLayout()
        Me.bordereuGroupBoxSelection.SuspendLayout()
        CType(Me.LoadBordereau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qtd_datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.qtd_tab.SuspendLayout()
        Me.auto_medicao_panel.SuspendLayout()
        CType(Me.auto_medicao_delBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.auto_medicao_savebtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.auto_medicao_tasks_group.SuspendLayout()
        Me.auto_medicao_workers_group.SuspendLayout()
        Me.auto_medicao_qtd_group.SuspendLayout()
        Me.autoMedicaoGroupBoxSelection.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.auto_medicao_datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.livraison_tab.SuspendLayout()
        Me.livraison_panel.SuspendLayout()
        Me.livraison_GroupBox_siteSelection.SuspendLayout()
        CType(Me.select_site, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.livraison_datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LivraisonPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.regie_tab.SuspendLayout()
        Me.regie_panel.SuspendLayout()
        Me.regieGroupBox_siteSelection.SuspendLayout()
        CType(Me.regie_select_site, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_legenda.SuspendLayout()
        CType(Me.regie_datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.regiePhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.journal_tab)
        Me.TabControl.Controls.Add(Me.bordereau_tab)
        Me.TabControl.Controls.Add(Me.qtd_tab)
        Me.TabControl.Controls.Add(Me.livraison_tab)
        Me.TabControl.Controls.Add(Me.regie_tab)
        Me.TabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl.HotTrack = True
        Me.TabControl.Location = New System.Drawing.Point(18, 18)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(2253, 1291)
        Me.TabControl.TabIndex = 38
        '
        'journal_tab
        '
        Me.journal_tab.Controls.Add(Me.saveBtn)
        Me.journal_tab.Controls.Add(Me.update_loggerBtn)
        Me.journal_tab.Controls.Add(Me.update_journalBtn)
        Me.journal_tab.Controls.Add(Me.logger_label)
        Me.journal_tab.Controls.Add(Me.journal_num_workers)
        Me.journal_tab.Controls.Add(Me.JournalGroupBoxSelection)
        Me.journal_tab.Controls.Add(Me.journal_label)
        Me.journal_tab.Controls.Add(Me.categories_box)
        Me.journal_tab.Controls.Add(Me.ocurrences_label)
        Me.journal_tab.Controls.Add(Me.view_doc)
        Me.journal_tab.Controls.Add(Me.activities_label)
        Me.journal_tab.Controls.Add(Me.ocurrences)
        Me.journal_tab.Controls.Add(Me.activities)
        Me.journal_tab.Controls.Add(Me.panel_journal)
        Me.journal_tab.Controls.Add(Me.Panel_logger)
        Me.journal_tab.Location = New System.Drawing.Point(4, 34)
        Me.journal_tab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.journal_tab.Name = "journal_tab"
        Me.journal_tab.Size = New System.Drawing.Size(2245, 1253)
        Me.journal_tab.TabIndex = 6
        Me.journal_tab.Text = "Jornal de Trabalho"
        Me.journal_tab.UseVisualStyleBackColor = True
        '
        'saveBtn
        '
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(2165, 1201)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 375
        Me.saveBtn.TabStop = False
        '
        'update_loggerBtn
        '
        Me.update_loggerBtn.Image = CType(resources.GetObject("update_loggerBtn.Image"), System.Drawing.Image)
        Me.update_loggerBtn.Location = New System.Drawing.Point(429, 1203)
        Me.update_loggerBtn.Name = "update_loggerBtn"
        Me.update_loggerBtn.Size = New System.Drawing.Size(50, 50)
        Me.update_loggerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.update_loggerBtn.TabIndex = 374
        Me.update_loggerBtn.TabStop = False
        '
        'update_journalBtn
        '
        Me.update_journalBtn.Image = CType(resources.GetObject("update_journalBtn.Image"), System.Drawing.Image)
        Me.update_journalBtn.Location = New System.Drawing.Point(1043, 1203)
        Me.update_journalBtn.Name = "update_journalBtn"
        Me.update_journalBtn.Size = New System.Drawing.Size(50, 50)
        Me.update_journalBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.update_journalBtn.TabIndex = 373
        Me.update_journalBtn.TabStop = False
        '
        'logger_label
        '
        Me.logger_label.AutoSize = True
        Me.logger_label.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logger_label.Location = New System.Drawing.Point(4, 128)
        Me.logger_label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.logger_label.Name = "logger_label"
        Me.logger_label.Size = New System.Drawing.Size(299, 29)
        Me.logger_label.TabIndex = 46
        Me.logger_label.Text = "Registo de presenças"
        '
        'journal_num_workers
        '
        Me.journal_num_workers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.journal_num_workers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.journal_num_workers.Location = New System.Drawing.Point(20, 152)
        Me.journal_num_workers.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.journal_num_workers.Name = "journal_num_workers"
        Me.journal_num_workers.Size = New System.Drawing.Size(459, 23)
        Me.journal_num_workers.TabIndex = 51
        Me.journal_num_workers.Text = "- -"
        Me.journal_num_workers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'JournalGroupBoxSelection
        '
        Me.JournalGroupBoxSelection.Controls.Add(Me.journalLoadButton)
        Me.JournalGroupBoxSelection.Controls.Add(Me.combo_site)
        Me.JournalGroupBoxSelection.Controls.Add(Me.journalSection_lbl)
        Me.JournalGroupBoxSelection.Controls.Add(Me.calendar)
        Me.JournalGroupBoxSelection.Controls.Add(Me.combo_section)
        Me.JournalGroupBoxSelection.Controls.Add(Me.journalData_lbl)
        Me.JournalGroupBoxSelection.Controls.Add(Me.meteo_chk)
        Me.JournalGroupBoxSelection.Controls.Add(Me.journal_chk)
        Me.JournalGroupBoxSelection.Controls.Add(Me.qtds_chk)
        Me.JournalGroupBoxSelection.Controls.Add(Me.livraison_chk)
        Me.JournalGroupBoxSelection.Controls.Add(Me.regie_chk)
        Me.JournalGroupBoxSelection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JournalGroupBoxSelection.Location = New System.Drawing.Point(10, 5)
        Me.JournalGroupBoxSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.JournalGroupBoxSelection.Name = "JournalGroupBoxSelection"
        Me.JournalGroupBoxSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.JournalGroupBoxSelection.Size = New System.Drawing.Size(1845, 105)
        Me.JournalGroupBoxSelection.TabIndex = 50
        Me.JournalGroupBoxSelection.TabStop = False
        Me.JournalGroupBoxSelection.Text = "Obra"
        '
        'journalLoadButton
        '
        Me.journalLoadButton.Image = CType(resources.GetObject("journalLoadButton.Image"), System.Drawing.Image)
        Me.journalLoadButton.InitialImage = Nothing
        Me.journalLoadButton.Location = New System.Drawing.Point(1782, 29)
        Me.journalLoadButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.journalLoadButton.Name = "journalLoadButton"
        Me.journalLoadButton.Size = New System.Drawing.Size(45, 46)
        Me.journalLoadButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.journalLoadButton.TabIndex = 322
        Me.journalLoadButton.TabStop = False
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(9, 52)
        Me.combo_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(362, 28)
        Me.combo_site.TabIndex = 35
        '
        'journalSection_lbl
        '
        Me.journalSection_lbl.AutoSize = True
        Me.journalSection_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.journalSection_lbl.Location = New System.Drawing.Point(378, 26)
        Me.journalSection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.journalSection_lbl.Name = "journalSection_lbl"
        Me.journalSection_lbl.Size = New System.Drawing.Size(69, 20)
        Me.journalSection_lbl.TabIndex = 49
        Me.journalSection_lbl.Text = "Secção"
        '
        'calendar
        '
        Me.calendar.CustomFormat = ""
        Me.calendar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calendar.Location = New System.Drawing.Point(756, 52)
        Me.calendar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.calendar.Name = "calendar"
        Me.calendar.Size = New System.Drawing.Size(326, 28)
        Me.calendar.TabIndex = 34
        '
        'combo_section
        '
        Me.combo_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_section.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_section.FormattingEnabled = True
        Me.combo_section.Location = New System.Drawing.Point(382, 52)
        Me.combo_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_section.Name = "combo_section"
        Me.combo_section.Size = New System.Drawing.Size(362, 28)
        Me.combo_section.TabIndex = 48
        '
        'journalData_lbl
        '
        Me.journalData_lbl.AutoSize = True
        Me.journalData_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.journalData_lbl.Location = New System.Drawing.Point(752, 26)
        Me.journalData_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.journalData_lbl.Name = "journalData_lbl"
        Me.journalData_lbl.Size = New System.Drawing.Size(49, 20)
        Me.journalData_lbl.TabIndex = 37
        Me.journalData_lbl.Text = "Data"
        '
        'meteo_chk
        '
        Me.meteo_chk.AutoSize = True
        Me.meteo_chk.Checked = True
        Me.meteo_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.meteo_chk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meteo_chk.Location = New System.Drawing.Point(1119, 29)
        Me.meteo_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.meteo_chk.Name = "meteo_chk"
        Me.meteo_chk.Size = New System.Drawing.Size(120, 24)
        Me.meteo_chk.TabIndex = 38
        Me.meteo_chk.Text = "Ver Meteo"
        Me.meteo_chk.UseVisualStyleBackColor = True
        '
        'journal_chk
        '
        Me.journal_chk.AutoSize = True
        Me.journal_chk.Checked = True
        Me.journal_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.journal_chk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.journal_chk.Location = New System.Drawing.Point(1119, 57)
        Me.journal_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.journal_chk.Name = "journal_chk"
        Me.journal_chk.Size = New System.Drawing.Size(191, 24)
        Me.journal_chk.TabIndex = 39
        Me.journal_chk.Text = "Ver Jornal de obra"
        Me.journal_chk.UseVisualStyleBackColor = True
        '
        'qtds_chk
        '
        Me.qtds_chk.AutoSize = True
        Me.qtds_chk.Checked = True
        Me.qtds_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.qtds_chk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtds_chk.Location = New System.Drawing.Point(1324, 29)
        Me.qtds_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtds_chk.Name = "qtds_chk"
        Me.qtds_chk.Size = New System.Drawing.Size(177, 24)
        Me.qtds_chk.TabIndex = 40
        Me.qtds_chk.Text = "Ver Quantidades"
        Me.qtds_chk.UseVisualStyleBackColor = True
        '
        'livraison_chk
        '
        Me.livraison_chk.AutoSize = True
        Me.livraison_chk.Checked = True
        Me.livraison_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.livraison_chk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_chk.Location = New System.Drawing.Point(1324, 57)
        Me.livraison_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_chk.Name = "livraison_chk"
        Me.livraison_chk.Size = New System.Drawing.Size(215, 24)
        Me.livraison_chk.TabIndex = 41
        Me.livraison_chk.Text = "Ver notas de entrega"
        Me.livraison_chk.UseVisualStyleBackColor = True
        '
        'regie_chk
        '
        Me.regie_chk.AutoSize = True
        Me.regie_chk.Checked = True
        Me.regie_chk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.regie_chk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_chk.Location = New System.Drawing.Point(1552, 58)
        Me.regie_chk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_chk.Name = "regie_chk"
        Me.regie_chk.Size = New System.Drawing.Size(214, 24)
        Me.regie_chk.TabIndex = 42
        Me.regie_chk.Text = "Ver marcações Régie"
        Me.regie_chk.UseVisualStyleBackColor = True
        '
        'journal_label
        '
        Me.journal_label.AutoSize = True
        Me.journal_label.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.journal_label.Location = New System.Drawing.Point(507, 128)
        Me.journal_label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.journal_label.Name = "journal_label"
        Me.journal_label.Size = New System.Drawing.Size(228, 29)
        Me.journal_label.TabIndex = 45
        Me.journal_label.Text = "Registo de Obra"
        '
        'categories_box
        '
        Me.categories_box.AutoSize = True
        Me.categories_box.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categories_box.Location = New System.Drawing.Point(4, 1212)
        Me.categories_box.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.categories_box.Name = "categories_box"
        Me.categories_box.Size = New System.Drawing.Size(192, 26)
        Me.categories_box.TabIndex = 33
        Me.categories_box.Text = "Ver por categoria"
        Me.categories_box.UseVisualStyleBackColor = True
        '
        'ocurrences_label
        '
        Me.ocurrences_label.AutoSize = True
        Me.ocurrences_label.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ocurrences_label.Location = New System.Drawing.Point(1126, 714)
        Me.ocurrences_label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ocurrences_label.Name = "ocurrences_label"
        Me.ocurrences_label.Size = New System.Drawing.Size(172, 29)
        Me.ocurrences_label.TabIndex = 32
        Me.ocurrences_label.Text = "Ocorrencias"
        '
        'view_doc
        '
        Me.view_doc.AutoSize = True
        Me.view_doc.Enabled = False
        Me.view_doc.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.view_doc.Location = New System.Drawing.Point(1127, 1207)
        Me.view_doc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.view_doc.Name = "view_doc"
        Me.view_doc.Size = New System.Drawing.Size(146, 22)
        Me.view_doc.TabIndex = 31
        Me.view_doc.TabStop = True
        Me.view_doc.Text = "Ver documento"
        '
        'activities_label
        '
        Me.activities_label.AutoSize = True
        Me.activities_label.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.activities_label.Location = New System.Drawing.Point(1125, 128)
        Me.activities_label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.activities_label.Name = "activities_label"
        Me.activities_label.Size = New System.Drawing.Size(314, 29)
        Me.activities_label.TabIndex = 29
        Me.activities_label.Text = "Actividades realizadas"
        '
        'ocurrences
        '
        Me.ocurrences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ocurrences.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ocurrences.Location = New System.Drawing.Point(1131, 762)
        Me.ocurrences.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ocurrences.Multiline = True
        Me.ocurrences.Name = "ocurrences"
        Me.ocurrences.Size = New System.Drawing.Size(1084, 440)
        Me.ocurrences.TabIndex = 28
        '
        'activities
        '
        Me.activities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.activities.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.activities.Location = New System.Drawing.Point(1131, 180)
        Me.activities.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.activities.Multiline = True
        Me.activities.Name = "activities"
        Me.activities.Size = New System.Drawing.Size(1084, 453)
        Me.activities.TabIndex = 27
        '
        'panel_journal
        '
        Me.panel_journal.AutoScroll = True
        Me.panel_journal.BackColor = System.Drawing.Color.White
        Me.panel_journal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_journal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_journal.Location = New System.Drawing.Point(510, 180)
        Me.panel_journal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.panel_journal.Name = "panel_journal"
        Me.panel_journal.Size = New System.Drawing.Size(584, 1022)
        Me.panel_journal.TabIndex = 26
        '
        'Panel_logger
        '
        Me.Panel_logger.AutoScroll = True
        Me.Panel_logger.BackColor = System.Drawing.Color.White
        Me.Panel_logger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_logger.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_logger.Location = New System.Drawing.Point(4, 180)
        Me.Panel_logger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel_logger.Name = "Panel_logger"
        Me.Panel_logger.Size = New System.Drawing.Size(473, 1022)
        Me.Panel_logger.TabIndex = 25
        '
        'bordereau_tab
        '
        Me.bordereau_tab.Controls.Add(Me.qtd_panel)
        Me.bordereau_tab.Location = New System.Drawing.Point(4, 34)
        Me.bordereau_tab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bordereau_tab.Name = "bordereau_tab"
        Me.bordereau_tab.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bordereau_tab.Size = New System.Drawing.Size(2245, 1253)
        Me.bordereau_tab.TabIndex = 1
        Me.bordereau_tab.Text = "Mapa de Tarefas"
        Me.bordereau_tab.UseVisualStyleBackColor = True
        '
        'qtd_panel
        '
        Me.qtd_panel.Controls.Add(Me.bordereuGroupBoxSelection)
        Me.qtd_panel.Controls.Add(Me.qtd_datatable)
        Me.qtd_panel.Location = New System.Drawing.Point(0, 0)
        Me.qtd_panel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_panel.Name = "qtd_panel"
        Me.qtd_panel.Size = New System.Drawing.Size(2236, 1231)
        Me.qtd_panel.TabIndex = 0
        '
        'bordereuGroupBoxSelection
        '
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_acumulatedResultsChk)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_data_lbl)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_setCurrentMonth)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_data_fim)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_data_to)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_data_inicio)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_amountsChk)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_qtdChk)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_site)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.qtd_section)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.bordereau_sectionSelection_lbl)
        Me.bordereuGroupBoxSelection.Controls.Add(Me.LoadBordereau)
        Me.bordereuGroupBoxSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bordereuGroupBoxSelection.Location = New System.Drawing.Point(12, 9)
        Me.bordereuGroupBoxSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bordereuGroupBoxSelection.Name = "bordereuGroupBoxSelection"
        Me.bordereuGroupBoxSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bordereuGroupBoxSelection.Size = New System.Drawing.Size(1720, 117)
        Me.bordereuGroupBoxSelection.TabIndex = 330
        Me.bordereuGroupBoxSelection.TabStop = False
        Me.bordereuGroupBoxSelection.Text = "Obra"
        '
        'qtd_acumulatedResultsChk
        '
        Me.qtd_acumulatedResultsChk.AutoSize = True
        Me.qtd_acumulatedResultsChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_acumulatedResultsChk.Location = New System.Drawing.Point(1460, 80)
        Me.qtd_acumulatedResultsChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_acumulatedResultsChk.Name = "qtd_acumulatedResultsChk"
        Me.qtd_acumulatedResultsChk.Size = New System.Drawing.Size(184, 24)
        Me.qtd_acumulatedResultsChk.TabIndex = 329
        Me.qtd_acumulatedResultsChk.Text = "valores acumulados"
        Me.qtd_acumulatedResultsChk.UseVisualStyleBackColor = True
        '
        'qtd_data_lbl
        '
        Me.qtd_data_lbl.AutoSize = True
        Me.qtd_data_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_data_lbl.Location = New System.Drawing.Point(756, 14)
        Me.qtd_data_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.qtd_data_lbl.Name = "qtd_data_lbl"
        Me.qtd_data_lbl.Size = New System.Drawing.Size(53, 25)
        Me.qtd_data_lbl.TabIndex = 328
        Me.qtd_data_lbl.Text = "Data"
        '
        'qtd_setCurrentMonth
        '
        Me.qtd_setCurrentMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.qtd_setCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_setCurrentMonth.Location = New System.Drawing.Point(1126, 80)
        Me.qtd_setCurrentMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.qtd_setCurrentMonth.Name = "qtd_setCurrentMonth"
        Me.qtd_setCurrentMonth.Size = New System.Drawing.Size(303, 25)
        Me.qtd_setCurrentMonth.TabIndex = 327
        Me.qtd_setCurrentMonth.TabStop = True
        Me.qtd_setCurrentMonth.Text = "mês corrente"
        Me.qtd_setCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'qtd_data_fim
        '
        Me.qtd_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_data_fim.Location = New System.Drawing.Point(1126, 42)
        Me.qtd_data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_data_fim.Name = "qtd_data_fim"
        Me.qtd_data_fim.Size = New System.Drawing.Size(301, 30)
        Me.qtd_data_fim.TabIndex = 325
        '
        'qtd_data_to
        '
        Me.qtd_data_to.AutoSize = True
        Me.qtd_data_to.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_data_to.Location = New System.Drawing.Point(1083, 46)
        Me.qtd_data_to.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.qtd_data_to.Name = "qtd_data_to"
        Me.qtd_data_to.Size = New System.Drawing.Size(24, 25)
        Me.qtd_data_to.TabIndex = 326
        Me.qtd_data_to.Text = "a"
        '
        'qtd_data_inicio
        '
        Me.qtd_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_data_inicio.Location = New System.Drawing.Point(760, 42)
        Me.qtd_data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_data_inicio.Name = "qtd_data_inicio"
        Me.qtd_data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.qtd_data_inicio.TabIndex = 324
        '
        'qtd_amountsChk
        '
        Me.qtd_amountsChk.AutoSize = True
        Me.qtd_amountsChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_amountsChk.Location = New System.Drawing.Point(1460, 54)
        Me.qtd_amountsChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_amountsChk.Name = "qtd_amountsChk"
        Me.qtd_amountsChk.Size = New System.Drawing.Size(113, 24)
        Me.qtd_amountsChk.TabIndex = 323
        Me.qtd_amountsChk.Text = "Montantes"
        Me.qtd_amountsChk.UseVisualStyleBackColor = True
        '
        'qtd_qtdChk
        '
        Me.qtd_qtdChk.AutoSize = True
        Me.qtd_qtdChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_qtdChk.Location = New System.Drawing.Point(1460, 29)
        Me.qtd_qtdChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_qtdChk.Name = "qtd_qtdChk"
        Me.qtd_qtdChk.Size = New System.Drawing.Size(129, 24)
        Me.qtd_qtdChk.TabIndex = 322
        Me.qtd_qtdChk.Text = "Quantidades"
        Me.qtd_qtdChk.UseVisualStyleBackColor = True
        '
        'qtd_site
        '
        Me.qtd_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.qtd_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_site.FormattingEnabled = True
        Me.qtd_site.Location = New System.Drawing.Point(9, 43)
        Me.qtd_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_site.Name = "qtd_site"
        Me.qtd_site.Size = New System.Drawing.Size(448, 28)
        Me.qtd_site.TabIndex = 309
        '
        'qtd_section
        '
        Me.qtd_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.qtd_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_section.FormattingEnabled = True
        Me.qtd_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.qtd_section.Location = New System.Drawing.Point(468, 43)
        Me.qtd_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_section.Name = "qtd_section"
        Me.qtd_section.Size = New System.Drawing.Size(282, 28)
        Me.qtd_section.TabIndex = 319
        '
        'bordereau_sectionSelection_lbl
        '
        Me.bordereau_sectionSelection_lbl.AutoSize = True
        Me.bordereau_sectionSelection_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bordereau_sectionSelection_lbl.Location = New System.Drawing.Point(464, 14)
        Me.bordereau_sectionSelection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.bordereau_sectionSelection_lbl.Name = "bordereau_sectionSelection_lbl"
        Me.bordereau_sectionSelection_lbl.Size = New System.Drawing.Size(79, 25)
        Me.bordereau_sectionSelection_lbl.TabIndex = 320
        Me.bordereau_sectionSelection_lbl.Text = "Secção"
        '
        'LoadBordereau
        '
        Me.LoadBordereau.Image = CType(resources.GetObject("LoadBordereau.Image"), System.Drawing.Image)
        Me.LoadBordereau.InitialImage = Nothing
        Me.LoadBordereau.Location = New System.Drawing.Point(1646, 40)
        Me.LoadBordereau.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoadBordereau.Name = "LoadBordereau"
        Me.LoadBordereau.Size = New System.Drawing.Size(30, 31)
        Me.LoadBordereau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LoadBordereau.TabIndex = 321
        Me.LoadBordereau.TabStop = False
        '
        'qtd_datatable
        '
        Me.qtd_datatable.AllowUserToAddRows = False
        Me.qtd_datatable.AllowUserToDeleteRows = False
        Me.qtd_datatable.BackgroundColor = System.Drawing.Color.White
        Me.qtd_datatable.CausesValidation = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.qtd_datatable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.qtd_datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.qtd_datatable.DefaultCellStyle = DataGridViewCellStyle2
        Me.qtd_datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.qtd_datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.qtd_datatable.Location = New System.Drawing.Point(12, 135)
        Me.qtd_datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_datatable.MultiSelect = False
        Me.qtd_datatable.Name = "qtd_datatable"
        Me.qtd_datatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.qtd_datatable.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.qtd_datatable.RowHeadersWidth = 62
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.qtd_datatable.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.qtd_datatable.Size = New System.Drawing.Size(2212, 1043)
        Me.qtd_datatable.TabIndex = 275
        '
        'qtd_tab
        '
        Me.qtd_tab.Controls.Add(Me.auto_medicao_panel)
        Me.qtd_tab.Location = New System.Drawing.Point(4, 34)
        Me.qtd_tab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd_tab.Name = "qtd_tab"
        Me.qtd_tab.Size = New System.Drawing.Size(2245, 1253)
        Me.qtd_tab.TabIndex = 4
        Me.qtd_tab.Text = "Autos de Medição"
        Me.qtd_tab.UseVisualStyleBackColor = True
        '
        'auto_medicao_panel
        '
        Me.auto_medicao_panel.AutoScroll = True
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_delBtn)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_savebtn)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_tasks_group)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_workers_group)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_qtd_group)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_bar)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_title)
        Me.auto_medicao_panel.Controls.Add(Me.autoMedicaoGroupBoxSelection)
        Me.auto_medicao_panel.Controls.Add(Me.auto_medicao_datatable)
        Me.auto_medicao_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.auto_medicao_panel.Location = New System.Drawing.Point(0, 0)
        Me.auto_medicao_panel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_panel.Name = "auto_medicao_panel"
        Me.auto_medicao_panel.Size = New System.Drawing.Size(2245, 1253)
        Me.auto_medicao_panel.TabIndex = 1
        '
        'auto_medicao_delBtn
        '
        Me.auto_medicao_delBtn.Image = CType(resources.GetObject("auto_medicao_delBtn.Image"), System.Drawing.Image)
        Me.auto_medicao_delBtn.Location = New System.Drawing.Point(2106, 1181)
        Me.auto_medicao_delBtn.Name = "auto_medicao_delBtn"
        Me.auto_medicao_delBtn.Size = New System.Drawing.Size(50, 50)
        Me.auto_medicao_delBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.auto_medicao_delBtn.TabIndex = 373
        Me.auto_medicao_delBtn.TabStop = False
        '
        'auto_medicao_savebtn
        '
        Me.auto_medicao_savebtn.Image = CType(resources.GetObject("auto_medicao_savebtn.Image"), System.Drawing.Image)
        Me.auto_medicao_savebtn.Location = New System.Drawing.Point(2178, 1181)
        Me.auto_medicao_savebtn.Name = "auto_medicao_savebtn"
        Me.auto_medicao_savebtn.Size = New System.Drawing.Size(50, 50)
        Me.auto_medicao_savebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.auto_medicao_savebtn.TabIndex = 372
        Me.auto_medicao_savebtn.TabStop = False
        '
        'auto_medicao_tasks_group
        '
        Me.auto_medicao_tasks_group.Controls.Add(Me.auto_medicao_update_tasks)
        Me.auto_medicao_tasks_group.Controls.Add(Me.auto_medicao_tasks_list)
        Me.auto_medicao_tasks_group.Location = New System.Drawing.Point(1334, 875)
        Me.auto_medicao_tasks_group.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_tasks_group.Name = "auto_medicao_tasks_group"
        Me.auto_medicao_tasks_group.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_tasks_group.Size = New System.Drawing.Size(894, 298)
        Me.auto_medicao_tasks_group.TabIndex = 354
        Me.auto_medicao_tasks_group.TabStop = False
        Me.auto_medicao_tasks_group.Text = "Mapa de tarefas"
        '
        'auto_medicao_update_tasks
        '
        Me.auto_medicao_update_tasks.AutoSize = True
        Me.auto_medicao_update_tasks.Enabled = False
        Me.auto_medicao_update_tasks.Location = New System.Drawing.Point(14, 260)
        Me.auto_medicao_update_tasks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_update_tasks.Name = "auto_medicao_update_tasks"
        Me.auto_medicao_update_tasks.Size = New System.Drawing.Size(98, 25)
        Me.auto_medicao_update_tasks.TabIndex = 351
        Me.auto_medicao_update_tasks.TabStop = True
        Me.auto_medicao_update_tasks.Text = "Actualizar"
        '
        'auto_medicao_tasks_list
        '
        Me.auto_medicao_tasks_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.auto_medicao_tasks_list.FormattingEnabled = True
        Me.auto_medicao_tasks_list.HorizontalScrollbar = True
        Me.auto_medicao_tasks_list.Location = New System.Drawing.Point(9, 29)
        Me.auto_medicao_tasks_list.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_tasks_list.Name = "auto_medicao_tasks_list"
        Me.auto_medicao_tasks_list.Size = New System.Drawing.Size(876, 212)
        Me.auto_medicao_tasks_list.TabIndex = 350
        '
        'auto_medicao_workers_group
        '
        Me.auto_medicao_workers_group.Controls.Add(Me.auto_medicao_workers_selected)
        Me.auto_medicao_workers_group.Controls.Add(Me.auto_medicao_update_workers)
        Me.auto_medicao_workers_group.Controls.Add(Me.auto_medicao_afetacao)
        Me.auto_medicao_workers_group.Controls.Add(Me.autoMedicaoWorkersOnSite_lbl)
        Me.auto_medicao_workers_group.Controls.Add(Me.auto_medicao_workers)
        Me.auto_medicao_workers_group.Location = New System.Drawing.Point(1334, 555)
        Me.auto_medicao_workers_group.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_workers_group.Name = "auto_medicao_workers_group"
        Me.auto_medicao_workers_group.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_workers_group.Size = New System.Drawing.Size(897, 311)
        Me.auto_medicao_workers_group.TabIndex = 353
        Me.auto_medicao_workers_group.TabStop = False
        Me.auto_medicao_workers_group.Text = "Trabalhadores"
        '
        'auto_medicao_workers_selected
        '
        Me.auto_medicao_workers_selected.BackColor = System.Drawing.Color.Cornsilk
        Me.auto_medicao_workers_selected.Enabled = False
        Me.auto_medicao_workers_selected.FormattingEnabled = True
        Me.auto_medicao_workers_selected.HorizontalScrollbar = True
        Me.auto_medicao_workers_selected.ItemHeight = 25
        Me.auto_medicao_workers_selected.Location = New System.Drawing.Point(495, 55)
        Me.auto_medicao_workers_selected.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_workers_selected.Name = "auto_medicao_workers_selected"
        Me.auto_medicao_workers_selected.Size = New System.Drawing.Size(391, 179)
        Me.auto_medicao_workers_selected.TabIndex = 358
        '
        'auto_medicao_update_workers
        '
        Me.auto_medicao_update_workers.AutoSize = True
        Me.auto_medicao_update_workers.Enabled = False
        Me.auto_medicao_update_workers.Location = New System.Drawing.Point(15, 269)
        Me.auto_medicao_update_workers.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_update_workers.Name = "auto_medicao_update_workers"
        Me.auto_medicao_update_workers.Size = New System.Drawing.Size(98, 25)
        Me.auto_medicao_update_workers.TabIndex = 357
        Me.auto_medicao_update_workers.TabStop = True
        Me.auto_medicao_update_workers.Text = "Actualizar"
        '
        'auto_medicao_afetacao
        '
        Me.auto_medicao_afetacao.AutoSize = True
        Me.auto_medicao_afetacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_afetacao.Location = New System.Drawing.Point(490, 28)
        Me.auto_medicao_afetacao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_afetacao.Name = "auto_medicao_afetacao"
        Me.auto_medicao_afetacao.Size = New System.Drawing.Size(81, 22)
        Me.auto_medicao_afetacao.TabIndex = 356
        Me.auto_medicao_afetacao.Text = "Afetação"
        '
        'autoMedicaoWorkersOnSite_lbl
        '
        Me.autoMedicaoWorkersOnSite_lbl.AutoSize = True
        Me.autoMedicaoWorkersOnSite_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoWorkersOnSite_lbl.Location = New System.Drawing.Point(9, 29)
        Me.autoMedicaoWorkersOnSite_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoWorkersOnSite_lbl.Name = "autoMedicaoWorkersOnSite_lbl"
        Me.autoMedicaoWorkersOnSite_lbl.Size = New System.Drawing.Size(129, 22)
        Me.autoMedicaoWorkersOnSite_lbl.TabIndex = 355
        Me.autoMedicaoWorkersOnSite_lbl.Text = "em obra no dia"
        '
        'auto_medicao_workers
        '
        Me.auto_medicao_workers.FormattingEnabled = True
        Me.auto_medicao_workers.HorizontalScrollbar = True
        Me.auto_medicao_workers.ItemHeight = 25
        Me.auto_medicao_workers.Location = New System.Drawing.Point(9, 58)
        Me.auto_medicao_workers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_workers.Name = "auto_medicao_workers"
        Me.auto_medicao_workers.Size = New System.Drawing.Size(475, 179)
        Me.auto_medicao_workers.TabIndex = 354
        '
        'auto_medicao_qtd_group
        '
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_translate)
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_units)
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_reset)
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_notas)
        Me.auto_medicao_qtd_group.Controls.Add(Me.autoMedicaoRecordAnnotations_lbl)
        Me.auto_medicao_qtd_group.Controls.Add(Me.autoMedicaoRecordDate_lbl)
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_date)
        Me.auto_medicao_qtd_group.Controls.Add(Me.autoMedicaoRecordQtd_lbl)
        Me.auto_medicao_qtd_group.Controls.Add(Me.auto_medicao_qtd)
        Me.auto_medicao_qtd_group.Location = New System.Drawing.Point(1328, 174)
        Me.auto_medicao_qtd_group.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_qtd_group.Name = "auto_medicao_qtd_group"
        Me.auto_medicao_qtd_group.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_qtd_group.Size = New System.Drawing.Size(897, 318)
        Me.auto_medicao_qtd_group.TabIndex = 351
        Me.auto_medicao_qtd_group.TabStop = False
        Me.auto_medicao_qtd_group.Text = "Quantidade executada"
        '
        'auto_medicao_translate
        '
        Me.auto_medicao_translate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.auto_medicao_translate.Enabled = False
        Me.auto_medicao_translate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_translate.Location = New System.Drawing.Point(718, 294)
        Me.auto_medicao_translate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_translate.Name = "auto_medicao_translate"
        Me.auto_medicao_translate.Size = New System.Drawing.Size(165, 20)
        Me.auto_medicao_translate.TabIndex = 320
        Me.auto_medicao_translate.TabStop = True
        Me.auto_medicao_translate.Text = "traduzir"
        Me.auto_medicao_translate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'auto_medicao_units
        '
        Me.auto_medicao_units.AutoSize = True
        Me.auto_medicao_units.Location = New System.Drawing.Point(584, 52)
        Me.auto_medicao_units.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_units.Name = "auto_medicao_units"
        Me.auto_medicao_units.Size = New System.Drawing.Size(41, 25)
        Me.auto_medicao_units.TabIndex = 360
        Me.auto_medicao_units.Text = " - - "
        '
        'auto_medicao_reset
        '
        Me.auto_medicao_reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.auto_medicao_reset.Enabled = False
        Me.auto_medicao_reset.Location = New System.Drawing.Point(712, 52)
        Me.auto_medicao_reset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_reset.Name = "auto_medicao_reset"
        Me.auto_medicao_reset.Size = New System.Drawing.Size(171, 25)
        Me.auto_medicao_reset.TabIndex = 359
        Me.auto_medicao_reset.TabStop = True
        Me.auto_medicao_reset.Text = "Reset"
        Me.auto_medicao_reset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'auto_medicao_notas
        '
        Me.auto_medicao_notas.Enabled = False
        Me.auto_medicao_notas.Location = New System.Drawing.Point(15, 132)
        Me.auto_medicao_notas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_notas.Multiline = True
        Me.auto_medicao_notas.Name = "auto_medicao_notas"
        Me.auto_medicao_notas.Size = New System.Drawing.Size(871, 155)
        Me.auto_medicao_notas.TabIndex = 352
        '
        'autoMedicaoRecordAnnotations_lbl
        '
        Me.autoMedicaoRecordAnnotations_lbl.AutoSize = True
        Me.autoMedicaoRecordAnnotations_lbl.Location = New System.Drawing.Point(9, 103)
        Me.autoMedicaoRecordAnnotations_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoRecordAnnotations_lbl.Name = "autoMedicaoRecordAnnotations_lbl"
        Me.autoMedicaoRecordAnnotations_lbl.Size = New System.Drawing.Size(106, 25)
        Me.autoMedicaoRecordAnnotations_lbl.TabIndex = 351
        Me.autoMedicaoRecordAnnotations_lbl.Text = "Anotações"
        '
        'autoMedicaoRecordDate_lbl
        '
        Me.autoMedicaoRecordDate_lbl.AutoSize = True
        Me.autoMedicaoRecordDate_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoRecordDate_lbl.Location = New System.Drawing.Point(9, 28)
        Me.autoMedicaoRecordDate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoRecordDate_lbl.Name = "autoMedicaoRecordDate_lbl"
        Me.autoMedicaoRecordDate_lbl.Size = New System.Drawing.Size(45, 20)
        Me.autoMedicaoRecordDate_lbl.TabIndex = 344
        Me.autoMedicaoRecordDate_lbl.Text = "Data"
        '
        'auto_medicao_date
        '
        Me.auto_medicao_date.Enabled = False
        Me.auto_medicao_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_date.Location = New System.Drawing.Point(14, 52)
        Me.auto_medicao_date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_date.Name = "auto_medicao_date"
        Me.auto_medicao_date.Size = New System.Drawing.Size(301, 26)
        Me.auto_medicao_date.TabIndex = 343
        '
        'autoMedicaoRecordQtd_lbl
        '
        Me.autoMedicaoRecordQtd_lbl.AutoSize = True
        Me.autoMedicaoRecordQtd_lbl.Location = New System.Drawing.Point(326, 52)
        Me.autoMedicaoRecordQtd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoRecordQtd_lbl.Name = "autoMedicaoRecordQtd_lbl"
        Me.autoMedicaoRecordQtd_lbl.Size = New System.Drawing.Size(114, 25)
        Me.autoMedicaoRecordQtd_lbl.TabIndex = 339
        Me.autoMedicaoRecordQtd_lbl.Text = "Quantidade"
        '
        'auto_medicao_qtd
        '
        Me.auto_medicao_qtd.Enabled = False
        Me.auto_medicao_qtd.Location = New System.Drawing.Point(452, 48)
        Me.auto_medicao_qtd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_qtd.Name = "auto_medicao_qtd"
        Me.auto_medicao_qtd.Size = New System.Drawing.Size(121, 30)
        Me.auto_medicao_qtd.TabIndex = 345
        '
        'auto_medicao_bar
        '
        Me.auto_medicao_bar.BackColor = System.Drawing.Color.LimeGreen
        Me.auto_medicao_bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.auto_medicao_bar.ForeColor = System.Drawing.Color.GreenYellow
        Me.auto_medicao_bar.Location = New System.Drawing.Point(1328, 163)
        Me.auto_medicao_bar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_bar.Name = "auto_medicao_bar"
        Me.auto_medicao_bar.Size = New System.Drawing.Size(894, 5)
        Me.auto_medicao_bar.TabIndex = 340
        '
        'auto_medicao_title
        '
        Me.auto_medicao_title.AutoSize = True
        Me.auto_medicao_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_title.Location = New System.Drawing.Point(1322, 132)
        Me.auto_medicao_title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.auto_medicao_title.Name = "auto_medicao_title"
        Me.auto_medicao_title.Size = New System.Drawing.Size(327, 29)
        Me.auto_medicao_title.TabIndex = 337
        Me.auto_medicao_title.Text = "Detalhes do auto de medição"
        '
        'autoMedicaoGroupBoxSelection
        '
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.autoMedicaoDate_lbl)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.autoMedicaoSetCurrentMonth)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.auto_medicao_site)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.auto_medicao_data_fim)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.auto_medicao_section)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.autoMedicaoDateTo_lbl)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.autoMedicaoSection_lbl)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.PictureBox1)
        Me.autoMedicaoGroupBoxSelection.Controls.Add(Me.auto_medicao_data_inicio)
        Me.autoMedicaoGroupBoxSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoGroupBoxSelection.Location = New System.Drawing.Point(10, 12)
        Me.autoMedicaoGroupBoxSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.autoMedicaoGroupBoxSelection.Name = "autoMedicaoGroupBoxSelection"
        Me.autoMedicaoGroupBoxSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.autoMedicaoGroupBoxSelection.Size = New System.Drawing.Size(1540, 115)
        Me.autoMedicaoGroupBoxSelection.TabIndex = 334
        Me.autoMedicaoGroupBoxSelection.TabStop = False
        Me.autoMedicaoGroupBoxSelection.Text = "Obra"
        '
        'autoMedicaoDate_lbl
        '
        Me.autoMedicaoDate_lbl.AutoSize = True
        Me.autoMedicaoDate_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoDate_lbl.Location = New System.Drawing.Point(813, 12)
        Me.autoMedicaoDate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoDate_lbl.Name = "autoMedicaoDate_lbl"
        Me.autoMedicaoDate_lbl.Size = New System.Drawing.Size(53, 25)
        Me.autoMedicaoDate_lbl.TabIndex = 322
        Me.autoMedicaoDate_lbl.Text = "Data"
        '
        'autoMedicaoSetCurrentMonth
        '
        Me.autoMedicaoSetCurrentMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autoMedicaoSetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoSetCurrentMonth.Location = New System.Drawing.Point(1184, 78)
        Me.autoMedicaoSetCurrentMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoSetCurrentMonth.Name = "autoMedicaoSetCurrentMonth"
        Me.autoMedicaoSetCurrentMonth.Size = New System.Drawing.Size(303, 25)
        Me.autoMedicaoSetCurrentMonth.TabIndex = 319
        Me.autoMedicaoSetCurrentMonth.TabStop = True
        Me.autoMedicaoSetCurrentMonth.Text = "mês corrente"
        Me.autoMedicaoSetCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'auto_medicao_site
        '
        Me.auto_medicao_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.auto_medicao_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_site.FormattingEnabled = True
        Me.auto_medicao_site.Location = New System.Drawing.Point(9, 42)
        Me.auto_medicao_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_site.Name = "auto_medicao_site"
        Me.auto_medicao_site.Size = New System.Drawing.Size(448, 28)
        Me.auto_medicao_site.TabIndex = 309
        '
        'auto_medicao_data_fim
        '
        Me.auto_medicao_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_data_fim.Location = New System.Drawing.Point(1184, 40)
        Me.auto_medicao_data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_data_fim.Name = "auto_medicao_data_fim"
        Me.auto_medicao_data_fim.Size = New System.Drawing.Size(301, 30)
        Me.auto_medicao_data_fim.TabIndex = 284
        '
        'auto_medicao_section
        '
        Me.auto_medicao_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.auto_medicao_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_section.FormattingEnabled = True
        Me.auto_medicao_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.auto_medicao_section.Location = New System.Drawing.Point(468, 42)
        Me.auto_medicao_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_section.Name = "auto_medicao_section"
        Me.auto_medicao_section.Size = New System.Drawing.Size(338, 28)
        Me.auto_medicao_section.TabIndex = 319
        '
        'autoMedicaoDateTo_lbl
        '
        Me.autoMedicaoDateTo_lbl.AutoSize = True
        Me.autoMedicaoDateTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoDateTo_lbl.Location = New System.Drawing.Point(1140, 45)
        Me.autoMedicaoDateTo_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoDateTo_lbl.Name = "autoMedicaoDateTo_lbl"
        Me.autoMedicaoDateTo_lbl.Size = New System.Drawing.Size(24, 25)
        Me.autoMedicaoDateTo_lbl.TabIndex = 285
        Me.autoMedicaoDateTo_lbl.Text = "a"
        '
        'autoMedicaoSection_lbl
        '
        Me.autoMedicaoSection_lbl.AutoSize = True
        Me.autoMedicaoSection_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoSection_lbl.Location = New System.Drawing.Point(464, 14)
        Me.autoMedicaoSection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoMedicaoSection_lbl.Name = "autoMedicaoSection_lbl"
        Me.autoMedicaoSection_lbl.Size = New System.Drawing.Size(79, 25)
        Me.autoMedicaoSection_lbl.TabIndex = 320
        Me.autoMedicaoSection_lbl.Text = "Secção"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(1494, 42)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 321
        Me.PictureBox1.TabStop = False
        '
        'auto_medicao_data_inicio
        '
        Me.auto_medicao_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_data_inicio.Location = New System.Drawing.Point(818, 40)
        Me.auto_medicao_data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_data_inicio.Name = "auto_medicao_data_inicio"
        Me.auto_medicao_data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.auto_medicao_data_inicio.TabIndex = 282
        '
        'auto_medicao_datatable
        '
        Me.auto_medicao_datatable.AllowUserToAddRows = False
        Me.auto_medicao_datatable.AllowUserToDeleteRows = False
        Me.auto_medicao_datatable.BackgroundColor = System.Drawing.Color.White
        Me.auto_medicao_datatable.CausesValidation = False
        Me.auto_medicao_datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.auto_medicao_datatable.DefaultCellStyle = DataGridViewCellStyle5
        Me.auto_medicao_datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.auto_medicao_datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.auto_medicao_datatable.Location = New System.Drawing.Point(10, 137)
        Me.auto_medicao_datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.auto_medicao_datatable.MultiSelect = False
        Me.auto_medicao_datatable.Name = "auto_medicao_datatable"
        Me.auto_medicao_datatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.auto_medicao_datatable.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.auto_medicao_datatable.RowHeadersWidth = 62
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.auto_medicao_datatable.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.auto_medicao_datatable.Size = New System.Drawing.Size(1310, 1063)
        Me.auto_medicao_datatable.TabIndex = 332
        '
        'livraison_tab
        '
        Me.livraison_tab.Controls.Add(Me.livraison_panel)
        Me.livraison_tab.Location = New System.Drawing.Point(4, 34)
        Me.livraison_tab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_tab.Name = "livraison_tab"
        Me.livraison_tab.Size = New System.Drawing.Size(2245, 1253)
        Me.livraison_tab.TabIndex = 3
        Me.livraison_tab.Text = "Guias de Remessa"
        Me.livraison_tab.UseVisualStyleBackColor = True
        '
        'livraison_panel
        '
        Me.livraison_panel.AutoScroll = True
        Me.livraison_panel.Controls.Add(Me.livraison_GroupBox_siteSelection)
        Me.livraison_panel.Controls.Add(Me.livraison_datatable)
        Me.livraison_panel.Controls.Add(Me.del_photo)
        Me.livraison_panel.Controls.Add(Me.add_photo)
        Me.livraison_panel.Controls.Add(Me.view_photo)
        Me.livraison_panel.Controls.Add(Me.LivraisonPhotoSelection)
        Me.livraison_panel.Controls.Add(Me.download_photo)
        Me.livraison_panel.Controls.Add(Me.photo_separator)
        Me.livraison_panel.Controls.Add(Me.photo_title)
        Me.livraison_panel.Controls.Add(Me.LivraisonPhoto)
        Me.livraison_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.livraison_panel.Location = New System.Drawing.Point(0, 0)
        Me.livraison_panel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_panel.Name = "livraison_panel"
        Me.livraison_panel.Size = New System.Drawing.Size(2245, 1253)
        Me.livraison_panel.TabIndex = 0
        '
        'livraison_GroupBox_siteSelection
        '
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.statsLinkLivraison)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraisonDate_lbl)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraisonCurrentMonthSelection_lbl)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraison_site)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraison_data_fim)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraison_section)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraisonDateTo_lbl)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraisonSection_lbl)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.select_site)
        Me.livraison_GroupBox_siteSelection.Controls.Add(Me.livraison_data_inicio)
        Me.livraison_GroupBox_siteSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_GroupBox_siteSelection.Location = New System.Drawing.Point(10, 5)
        Me.livraison_GroupBox_siteSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_GroupBox_siteSelection.Name = "livraison_GroupBox_siteSelection"
        Me.livraison_GroupBox_siteSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_GroupBox_siteSelection.Size = New System.Drawing.Size(1455, 117)
        Me.livraison_GroupBox_siteSelection.TabIndex = 328
        Me.livraison_GroupBox_siteSelection.TabStop = False
        Me.livraison_GroupBox_siteSelection.Text = "Obra"
        '
        'statsLinkLivraison
        '
        Me.statsLinkLivraison.AutoSize = True
        Me.statsLinkLivraison.Enabled = False
        Me.statsLinkLivraison.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statsLinkLivraison.Location = New System.Drawing.Point(9, 86)
        Me.statsLinkLivraison.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.statsLinkLivraison.Name = "statsLinkLivraison"
        Me.statsLinkLivraison.Size = New System.Drawing.Size(97, 20)
        Me.statsLinkLivraison.TabIndex = 329
        Me.statsLinkLivraison.TabStop = True
        Me.statsLinkLivraison.Text = "Estatisticas"
        Me.statsLinkLivraison.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'livraisonDate_lbl
        '
        Me.livraisonDate_lbl.AutoSize = True
        Me.livraisonDate_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraisonDate_lbl.Location = New System.Drawing.Point(756, 18)
        Me.livraisonDate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.livraisonDate_lbl.Name = "livraisonDate_lbl"
        Me.livraisonDate_lbl.Size = New System.Drawing.Size(53, 25)
        Me.livraisonDate_lbl.TabIndex = 322
        Me.livraisonDate_lbl.Text = "Data"
        '
        'livraisonCurrentMonthSelection_lbl
        '
        Me.livraisonCurrentMonthSelection_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.livraisonCurrentMonthSelection_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraisonCurrentMonthSelection_lbl.Location = New System.Drawing.Point(1107, 82)
        Me.livraisonCurrentMonthSelection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.livraisonCurrentMonthSelection_lbl.Name = "livraisonCurrentMonthSelection_lbl"
        Me.livraisonCurrentMonthSelection_lbl.Size = New System.Drawing.Size(303, 25)
        Me.livraisonCurrentMonthSelection_lbl.TabIndex = 319
        Me.livraisonCurrentMonthSelection_lbl.TabStop = True
        Me.livraisonCurrentMonthSelection_lbl.Text = "mês corrente"
        Me.livraisonCurrentMonthSelection_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'livraison_site
        '
        Me.livraison_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.livraison_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_site.FormattingEnabled = True
        Me.livraison_site.Location = New System.Drawing.Point(9, 45)
        Me.livraison_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_site.Name = "livraison_site"
        Me.livraison_site.Size = New System.Drawing.Size(448, 28)
        Me.livraison_site.TabIndex = 309
        '
        'livraison_data_fim
        '
        Me.livraison_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_data_fim.Location = New System.Drawing.Point(1107, 43)
        Me.livraison_data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_data_fim.Name = "livraison_data_fim"
        Me.livraison_data_fim.Size = New System.Drawing.Size(301, 30)
        Me.livraison_data_fim.TabIndex = 284
        '
        'livraison_section
        '
        Me.livraison_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.livraison_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_section.FormattingEnabled = True
        Me.livraison_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.livraison_section.Location = New System.Drawing.Point(468, 46)
        Me.livraison_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_section.Name = "livraison_section"
        Me.livraison_section.Size = New System.Drawing.Size(282, 28)
        Me.livraison_section.TabIndex = 319
        '
        'livraisonDateTo_lbl
        '
        Me.livraisonDateTo_lbl.AutoSize = True
        Me.livraisonDateTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraisonDateTo_lbl.Location = New System.Drawing.Point(1072, 46)
        Me.livraisonDateTo_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.livraisonDateTo_lbl.Name = "livraisonDateTo_lbl"
        Me.livraisonDateTo_lbl.Size = New System.Drawing.Size(24, 25)
        Me.livraisonDateTo_lbl.TabIndex = 285
        Me.livraisonDateTo_lbl.Text = "a"
        '
        'livraisonSection_lbl
        '
        Me.livraisonSection_lbl.AutoSize = True
        Me.livraisonSection_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraisonSection_lbl.Location = New System.Drawing.Point(464, 17)
        Me.livraisonSection_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.livraisonSection_lbl.Name = "livraisonSection_lbl"
        Me.livraisonSection_lbl.Size = New System.Drawing.Size(79, 25)
        Me.livraisonSection_lbl.TabIndex = 320
        Me.livraisonSection_lbl.Text = "Secção"
        '
        'select_site
        '
        Me.select_site.Image = CType(resources.GetObject("select_site.Image"), System.Drawing.Image)
        Me.select_site.InitialImage = Nothing
        Me.select_site.Location = New System.Drawing.Point(1419, 45)
        Me.select_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.select_site.Name = "select_site"
        Me.select_site.Size = New System.Drawing.Size(30, 31)
        Me.select_site.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.select_site.TabIndex = 321
        Me.select_site.TabStop = False
        '
        'livraison_data_inicio
        '
        Me.livraison_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.livraison_data_inicio.Location = New System.Drawing.Point(760, 45)
        Me.livraison_data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_data_inicio.Name = "livraison_data_inicio"
        Me.livraison_data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.livraison_data_inicio.TabIndex = 282
        '
        'livraison_datatable
        '
        Me.livraison_datatable.AllowUserToAddRows = False
        Me.livraison_datatable.AllowUserToDeleteRows = False
        Me.livraison_datatable.BackgroundColor = System.Drawing.Color.White
        Me.livraison_datatable.CausesValidation = False
        Me.livraison_datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.livraison_datatable.DefaultCellStyle = DataGridViewCellStyle8
        Me.livraison_datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.livraison_datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.livraison_datatable.Location = New System.Drawing.Point(10, 154)
        Me.livraison_datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.livraison_datatable.MultiSelect = False
        Me.livraison_datatable.Name = "livraison_datatable"
        Me.livraison_datatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.livraison_datatable.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.livraison_datatable.RowHeadersWidth = 62
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.livraison_datatable.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.livraison_datatable.Size = New System.Drawing.Size(1408, 866)
        Me.livraison_datatable.TabIndex = 305
        '
        'del_photo
        '
        Me.del_photo.AutoSize = True
        Me.del_photo.Enabled = False
        Me.del_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del_photo.Location = New System.Drawing.Point(1868, 117)
        Me.del_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.del_photo.Name = "del_photo"
        Me.del_photo.Size = New System.Drawing.Size(62, 20)
        Me.del_photo.TabIndex = 301
        Me.del_photo.TabStop = True
        Me.del_photo.Text = "Apagar"
        '
        'add_photo
        '
        Me.add_photo.AutoSize = True
        Me.add_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_photo.Location = New System.Drawing.Point(1782, 117)
        Me.add_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.add_photo.Name = "add_photo"
        Me.add_photo.Size = New System.Drawing.Size(79, 20)
        Me.add_photo.TabIndex = 300
        Me.add_photo.TabStop = True
        Me.add_photo.Text = "Adicionar"
        '
        'view_photo
        '
        Me.view_photo.AutoSize = True
        Me.view_photo.Enabled = False
        Me.view_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.view_photo.Location = New System.Drawing.Point(1740, 117)
        Me.view_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.view_photo.Name = "view_photo"
        Me.view_photo.Size = New System.Drawing.Size(35, 20)
        Me.view_photo.TabIndex = 299
        Me.view_photo.TabStop = True
        Me.view_photo.Text = "Ver"
        '
        'LivraisonPhotoSelection
        '
        Me.LivraisonPhotoSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LivraisonPhotoSelection.Enabled = False
        Me.LivraisonPhotoSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LivraisonPhotoSelection.FormattingEnabled = True
        Me.LivraisonPhotoSelection.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.LivraisonPhotoSelection.Location = New System.Drawing.Point(1474, 112)
        Me.LivraisonPhotoSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LivraisonPhotoSelection.Name = "LivraisonPhotoSelection"
        Me.LivraisonPhotoSelection.Size = New System.Drawing.Size(254, 28)
        Me.LivraisonPhotoSelection.TabIndex = 298
        '
        'download_photo
        '
        Me.download_photo.AutoSize = True
        Me.download_photo.Enabled = False
        Me.download_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.download_photo.Location = New System.Drawing.Point(1938, 117)
        Me.download_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.download_photo.Name = "download_photo"
        Me.download_photo.Size = New System.Drawing.Size(83, 20)
        Me.download_photo.TabIndex = 297
        Me.download_photo.TabStop = True
        Me.download_photo.Text = "Download"
        '
        'photo_separator
        '
        Me.photo_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photo_separator.Location = New System.Drawing.Point(1472, 105)
        Me.photo_separator.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.photo_separator.Name = "photo_separator"
        Me.photo_separator.Size = New System.Drawing.Size(743, 5)
        Me.photo_separator.TabIndex = 296
        '
        'photo_title
        '
        Me.photo_title.AutoSize = True
        Me.photo_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.photo_title.Location = New System.Drawing.Point(1468, 74)
        Me.photo_title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.photo_title.Name = "photo_title"
        Me.photo_title.Size = New System.Drawing.Size(188, 29)
        Me.photo_title.TabIndex = 295
        Me.photo_title.Text = "Foto documento"
        '
        'LivraisonPhoto
        '
        Me.LivraisonPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LivraisonPhoto.Location = New System.Drawing.Point(1474, 154)
        Me.LivraisonPhoto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LivraisonPhoto.Name = "LivraisonPhoto"
        Me.LivraisonPhoto.Size = New System.Drawing.Size(728, 865)
        Me.LivraisonPhoto.TabIndex = 284
        Me.LivraisonPhoto.TabStop = False
        '
        'regie_tab
        '
        Me.regie_tab.Controls.Add(Me.regie_panel)
        Me.regie_tab.Location = New System.Drawing.Point(4, 34)
        Me.regie_tab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_tab.Name = "regie_tab"
        Me.regie_tab.Size = New System.Drawing.Size(2245, 1253)
        Me.regie_tab.TabIndex = 5
        Me.regie_tab.Text = "Tarefas não Planeadas"
        Me.regie_tab.UseVisualStyleBackColor = True
        '
        'regie_panel
        '
        Me.regie_panel.AutoScroll = True
        Me.regie_panel.Controls.Add(Me.regieGroupBox_siteSelection)
        Me.regie_panel.Controls.Add(Me.GroupBox_legenda)
        Me.regie_panel.Controls.Add(Me.regie_datatable)
        Me.regie_panel.Controls.Add(Me.regie_del_photo)
        Me.regie_panel.Controls.Add(Me.regie_add_photo)
        Me.regie_panel.Controls.Add(Me.regie_view_photo)
        Me.regie_panel.Controls.Add(Me.regiePhotoSelection)
        Me.regie_panel.Controls.Add(Me.regie_download_photo)
        Me.regie_panel.Controls.Add(Me.regie_photo_separator)
        Me.regie_panel.Controls.Add(Me.regie_photo_title)
        Me.regie_panel.Controls.Add(Me.regiePhoto)
        Me.regie_panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.regie_panel.Location = New System.Drawing.Point(0, 0)
        Me.regie_panel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_panel.Name = "regie_panel"
        Me.regie_panel.Size = New System.Drawing.Size(2245, 1253)
        Me.regie_panel.TabIndex = 1
        '
        'regieGroupBox_siteSelection
        '
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_date_lbl)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regieSetCurrentMonth)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_site)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_data_fim)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_section)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_dateTo_lbl)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_section_lbl)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_select_site)
        Me.regieGroupBox_siteSelection.Controls.Add(Me.regie_data_inicio)
        Me.regieGroupBox_siteSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieGroupBox_siteSelection.Location = New System.Drawing.Point(14, 5)
        Me.regieGroupBox_siteSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regieGroupBox_siteSelection.Name = "regieGroupBox_siteSelection"
        Me.regieGroupBox_siteSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regieGroupBox_siteSelection.Size = New System.Drawing.Size(1473, 103)
        Me.regieGroupBox_siteSelection.TabIndex = 326
        Me.regieGroupBox_siteSelection.TabStop = False
        Me.regieGroupBox_siteSelection.Text = "Obra"
        '
        'regie_date_lbl
        '
        Me.regie_date_lbl.AutoSize = True
        Me.regie_date_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_date_lbl.Location = New System.Drawing.Point(764, 9)
        Me.regie_date_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_date_lbl.Name = "regie_date_lbl"
        Me.regie_date_lbl.Size = New System.Drawing.Size(53, 25)
        Me.regie_date_lbl.TabIndex = 322
        Me.regie_date_lbl.Text = "Data"
        '
        'regieSetCurrentMonth
        '
        Me.regieSetCurrentMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.regieSetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieSetCurrentMonth.Location = New System.Drawing.Point(1114, 71)
        Me.regieSetCurrentMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieSetCurrentMonth.Name = "regieSetCurrentMonth"
        Me.regieSetCurrentMonth.Size = New System.Drawing.Size(302, 25)
        Me.regieSetCurrentMonth.TabIndex = 319
        Me.regieSetCurrentMonth.TabStop = True
        Me.regieSetCurrentMonth.Text = "mês corrente"
        Me.regieSetCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'regie_site
        '
        Me.regie_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.regie_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_site.FormattingEnabled = True
        Me.regie_site.Location = New System.Drawing.Point(16, 35)
        Me.regie_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_site.Name = "regie_site"
        Me.regie_site.Size = New System.Drawing.Size(448, 28)
        Me.regie_site.TabIndex = 309
        '
        'regie_data_fim
        '
        Me.regie_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_data_fim.Location = New System.Drawing.Point(1114, 32)
        Me.regie_data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_data_fim.Name = "regie_data_fim"
        Me.regie_data_fim.Size = New System.Drawing.Size(301, 30)
        Me.regie_data_fim.TabIndex = 284
        '
        'regie_section
        '
        Me.regie_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.regie_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_section.FormattingEnabled = True
        Me.regie_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.regie_section.Location = New System.Drawing.Point(476, 35)
        Me.regie_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_section.Name = "regie_section"
        Me.regie_section.Size = New System.Drawing.Size(282, 28)
        Me.regie_section.TabIndex = 319
        '
        'regie_dateTo_lbl
        '
        Me.regie_dateTo_lbl.AutoSize = True
        Me.regie_dateTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_dateTo_lbl.Location = New System.Drawing.Point(1080, 35)
        Me.regie_dateTo_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_dateTo_lbl.Name = "regie_dateTo_lbl"
        Me.regie_dateTo_lbl.Size = New System.Drawing.Size(24, 25)
        Me.regie_dateTo_lbl.TabIndex = 285
        Me.regie_dateTo_lbl.Text = "a"
        '
        'regie_section_lbl
        '
        Me.regie_section_lbl.AutoSize = True
        Me.regie_section_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_section_lbl.Location = New System.Drawing.Point(471, 9)
        Me.regie_section_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_section_lbl.Name = "regie_section_lbl"
        Me.regie_section_lbl.Size = New System.Drawing.Size(79, 25)
        Me.regie_section_lbl.TabIndex = 320
        Me.regie_section_lbl.Text = "Secção"
        '
        'regie_select_site
        '
        Me.regie_select_site.Image = CType(resources.GetObject("regie_select_site.Image"), System.Drawing.Image)
        Me.regie_select_site.InitialImage = Nothing
        Me.regie_select_site.Location = New System.Drawing.Point(1426, 32)
        Me.regie_select_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_select_site.Name = "regie_select_site"
        Me.regie_select_site.Size = New System.Drawing.Size(30, 31)
        Me.regie_select_site.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.regie_select_site.TabIndex = 321
        Me.regie_select_site.TabStop = False
        '
        'regie_data_inicio
        '
        Me.regie_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_data_inicio.Location = New System.Drawing.Point(768, 34)
        Me.regie_data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_data_inicio.Name = "regie_data_inicio"
        Me.regie_data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.regie_data_inicio.TabIndex = 282
        '
        'GroupBox_legenda
        '
        Me.GroupBox_legenda.Controls.Add(Me.regieLegendOngoing)
        Me.GroupBox_legenda.Controls.Add(Me.ongoingBox)
        Me.GroupBox_legenda.Controls.Add(Me.regieLegendAutoEod)
        Me.GroupBox_legenda.Controls.Add(Me.autoEodBox)
        Me.GroupBox_legenda.Controls.Add(Me.regieLegendEod)
        Me.GroupBox_legenda.Controls.Add(Me.eodBox)
        Me.GroupBox_legenda.Controls.Add(Me.regieLegendClosed)
        Me.GroupBox_legenda.Controls.Add(Me.Label53)
        Me.GroupBox_legenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_legenda.Location = New System.Drawing.Point(14, 117)
        Me.GroupBox_legenda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_legenda.Name = "GroupBox_legenda"
        Me.GroupBox_legenda.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_legenda.Size = New System.Drawing.Size(1408, 72)
        Me.GroupBox_legenda.TabIndex = 325
        Me.GroupBox_legenda.TabStop = False
        Me.GroupBox_legenda.Text = "Legenda"
        '
        'regieLegendOngoing
        '
        Me.regieLegendOngoing.AutoSize = True
        Me.regieLegendOngoing.CausesValidation = False
        Me.regieLegendOngoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieLegendOngoing.Location = New System.Drawing.Point(687, 35)
        Me.regieLegendOngoing.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieLegendOngoing.Name = "regieLegendOngoing"
        Me.regieLegendOngoing.Size = New System.Drawing.Size(88, 20)
        Me.regieLegendOngoing.TabIndex = 77
        Me.regieLegendOngoing.Text = "A decorrer"
        '
        'ongoingBox
        '
        Me.ongoingBox.AutoSize = True
        Me.ongoingBox.BackColor = System.Drawing.Color.DarkOrange
        Me.ongoingBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ongoingBox.CausesValidation = False
        Me.ongoingBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ongoingBox.Location = New System.Drawing.Point(656, 35)
        Me.ongoingBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ongoingBox.Name = "ongoingBox"
        Me.ongoingBox.Size = New System.Drawing.Size(21, 22)
        Me.ongoingBox.TabIndex = 76
        Me.ongoingBox.Text = "  "
        '
        'regieLegendAutoEod
        '
        Me.regieLegendAutoEod.AutoSize = True
        Me.regieLegendAutoEod.CausesValidation = False
        Me.regieLegendAutoEod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieLegendAutoEod.Location = New System.Drawing.Point(424, 34)
        Me.regieLegendAutoEod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieLegendAutoEod.Name = "regieLegendAutoEod"
        Me.regieLegendAutoEod.Size = New System.Drawing.Size(161, 20)
        Me.regieLegendAutoEod.TabIndex = 75
        Me.regieLegendAutoEod.Text = "Fim autom. às 17:30"
        '
        'autoEodBox
        '
        Me.autoEodBox.AutoSize = True
        Me.autoEodBox.BackColor = System.Drawing.Color.OrangeRed
        Me.autoEodBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.autoEodBox.CausesValidation = False
        Me.autoEodBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoEodBox.Location = New System.Drawing.Point(393, 34)
        Me.autoEodBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.autoEodBox.Name = "autoEodBox"
        Me.autoEodBox.Size = New System.Drawing.Size(21, 22)
        Me.autoEodBox.TabIndex = 74
        Me.autoEodBox.Text = "  "
        '
        'regieLegendEod
        '
        Me.regieLegendEod.AutoSize = True
        Me.regieLegendEod.CausesValidation = False
        Me.regieLegendEod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieLegendEod.Location = New System.Drawing.Point(242, 34)
        Me.regieLegendEod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieLegendEod.Name = "regieLegendEod"
        Me.regieLegendEod.Size = New System.Drawing.Size(87, 20)
        Me.regieLegendEod.TabIndex = 73
        Me.regieLegendEod.Text = "Fim do dia"
        '
        'eodBox
        '
        Me.eodBox.AutoSize = True
        Me.eodBox.BackColor = System.Drawing.Color.IndianRed
        Me.eodBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.eodBox.CausesValidation = False
        Me.eodBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eodBox.Location = New System.Drawing.Point(210, 32)
        Me.eodBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.eodBox.Name = "eodBox"
        Me.eodBox.Size = New System.Drawing.Size(21, 22)
        Me.eodBox.TabIndex = 72
        Me.eodBox.Text = "  "
        '
        'regieLegendClosed
        '
        Me.regieLegendClosed.AutoSize = True
        Me.regieLegendClosed.CausesValidation = False
        Me.regieLegendClosed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieLegendClosed.Location = New System.Drawing.Point(70, 32)
        Me.regieLegendClosed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieLegendClosed.Name = "regieLegendClosed"
        Me.regieLegendClosed.Size = New System.Drawing.Size(86, 20)
        Me.regieLegendClosed.TabIndex = 71
        Me.regieLegendClosed.Text = "Encerrada"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.YellowGreen
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.CausesValidation = False
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(46, 31)
        Me.Label53.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(21, 22)
        Me.Label53.TabIndex = 70
        Me.Label53.Text = "  "
        '
        'regie_datatable
        '
        Me.regie_datatable.AllowUserToAddRows = False
        Me.regie_datatable.AllowUserToDeleteRows = False
        Me.regie_datatable.BackgroundColor = System.Drawing.Color.White
        Me.regie_datatable.CausesValidation = False
        Me.regie_datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regie_datatable.DefaultCellStyle = DataGridViewCellStyle11
        Me.regie_datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.regie_datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.regie_datatable.Location = New System.Drawing.Point(14, 198)
        Me.regie_datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_datatable.MultiSelect = False
        Me.regie_datatable.Name = "regie_datatable"
        Me.regie_datatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.regie_datatable.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.regie_datatable.RowHeadersWidth = 62
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.regie_datatable.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.regie_datatable.Size = New System.Drawing.Size(1408, 806)
        Me.regie_datatable.TabIndex = 322
        '
        'regie_del_photo
        '
        Me.regie_del_photo.AutoSize = True
        Me.regie_del_photo.Enabled = False
        Me.regie_del_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_del_photo.Location = New System.Drawing.Point(1870, 155)
        Me.regie_del_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_del_photo.Name = "regie_del_photo"
        Me.regie_del_photo.Size = New System.Drawing.Size(62, 20)
        Me.regie_del_photo.TabIndex = 318
        Me.regie_del_photo.TabStop = True
        Me.regie_del_photo.Text = "Apagar"
        '
        'regie_add_photo
        '
        Me.regie_add_photo.AutoSize = True
        Me.regie_add_photo.Enabled = False
        Me.regie_add_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_add_photo.Location = New System.Drawing.Point(1785, 155)
        Me.regie_add_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_add_photo.Name = "regie_add_photo"
        Me.regie_add_photo.Size = New System.Drawing.Size(79, 20)
        Me.regie_add_photo.TabIndex = 317
        Me.regie_add_photo.TabStop = True
        Me.regie_add_photo.Text = "Adicionar"
        '
        'regie_view_photo
        '
        Me.regie_view_photo.AutoSize = True
        Me.regie_view_photo.Enabled = False
        Me.regie_view_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_view_photo.Location = New System.Drawing.Point(1743, 155)
        Me.regie_view_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_view_photo.Name = "regie_view_photo"
        Me.regie_view_photo.Size = New System.Drawing.Size(35, 20)
        Me.regie_view_photo.TabIndex = 316
        Me.regie_view_photo.TabStop = True
        Me.regie_view_photo.Text = "Ver"
        '
        'regiePhotoSelection
        '
        Me.regiePhotoSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.regiePhotoSelection.Enabled = False
        Me.regiePhotoSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regiePhotoSelection.FormattingEnabled = True
        Me.regiePhotoSelection.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.regiePhotoSelection.Location = New System.Drawing.Point(1478, 151)
        Me.regiePhotoSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regiePhotoSelection.Name = "regiePhotoSelection"
        Me.regiePhotoSelection.Size = New System.Drawing.Size(254, 28)
        Me.regiePhotoSelection.TabIndex = 315
        '
        'regie_download_photo
        '
        Me.regie_download_photo.AutoSize = True
        Me.regie_download_photo.Enabled = False
        Me.regie_download_photo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_download_photo.Location = New System.Drawing.Point(1941, 155)
        Me.regie_download_photo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_download_photo.Name = "regie_download_photo"
        Me.regie_download_photo.Size = New System.Drawing.Size(83, 20)
        Me.regie_download_photo.TabIndex = 314
        Me.regie_download_photo.TabStop = True
        Me.regie_download_photo.Text = "Download"
        '
        'regie_photo_separator
        '
        Me.regie_photo_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.regie_photo_separator.Location = New System.Drawing.Point(1474, 143)
        Me.regie_photo_separator.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_photo_separator.Name = "regie_photo_separator"
        Me.regie_photo_separator.Size = New System.Drawing.Size(743, 5)
        Me.regie_photo_separator.TabIndex = 313
        '
        'regie_photo_title
        '
        Me.regie_photo_title.AutoSize = True
        Me.regie_photo_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_photo_title.Location = New System.Drawing.Point(1472, 112)
        Me.regie_photo_title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regie_photo_title.Name = "regie_photo_title"
        Me.regie_photo_title.Size = New System.Drawing.Size(188, 29)
        Me.regie_photo_title.TabIndex = 312
        Me.regie_photo_title.Text = "Foto documento"
        '
        'regiePhoto
        '
        Me.regiePhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.regiePhoto.Location = New System.Drawing.Point(1478, 198)
        Me.regiePhoto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regiePhoto.Name = "regiePhoto"
        Me.regiePhoto.Size = New System.Drawing.Size(728, 805)
        Me.regiePhoto.TabIndex = 311
        Me.regiePhoto.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'site_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(2271, 1423)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "site_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Obras"
        Me.TabControl.ResumeLayout(False)
        Me.journal_tab.ResumeLayout(False)
        Me.journal_tab.PerformLayout()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.update_loggerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.update_journalBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.JournalGroupBoxSelection.ResumeLayout(False)
        Me.JournalGroupBoxSelection.PerformLayout()
        CType(Me.journalLoadButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bordereau_tab.ResumeLayout(False)
        Me.qtd_panel.ResumeLayout(False)
        Me.bordereuGroupBoxSelection.ResumeLayout(False)
        Me.bordereuGroupBoxSelection.PerformLayout()
        CType(Me.LoadBordereau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qtd_datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.qtd_tab.ResumeLayout(False)
        Me.auto_medicao_panel.ResumeLayout(False)
        Me.auto_medicao_panel.PerformLayout()
        CType(Me.auto_medicao_delBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.auto_medicao_savebtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.auto_medicao_tasks_group.ResumeLayout(False)
        Me.auto_medicao_tasks_group.PerformLayout()
        Me.auto_medicao_workers_group.ResumeLayout(False)
        Me.auto_medicao_workers_group.PerformLayout()
        Me.auto_medicao_qtd_group.ResumeLayout(False)
        Me.auto_medicao_qtd_group.PerformLayout()
        Me.autoMedicaoGroupBoxSelection.ResumeLayout(False)
        Me.autoMedicaoGroupBoxSelection.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.auto_medicao_datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.livraison_tab.ResumeLayout(False)
        Me.livraison_panel.ResumeLayout(False)
        Me.livraison_panel.PerformLayout()
        Me.livraison_GroupBox_siteSelection.ResumeLayout(False)
        Me.livraison_GroupBox_siteSelection.PerformLayout()
        CType(Me.select_site, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.livraison_datatable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LivraisonPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.regie_tab.ResumeLayout(False)
        Me.regie_panel.ResumeLayout(False)
        Me.regie_panel.PerformLayout()
        Me.regieGroupBox_siteSelection.ResumeLayout(False)
        Me.regieGroupBox_siteSelection.PerformLayout()
        CType(Me.regie_select_site, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_legenda.ResumeLayout(False)
        Me.GroupBox_legenda.PerformLayout()
        CType(Me.regie_datatable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.regiePhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl As TabControl
    Friend WithEvents bordereau_tab As TabPage
    Friend WithEvents qtd_panel As Panel
    Friend WithEvents livraison_tab As TabPage
    Friend WithEvents livraison_panel As Panel
    Friend WithEvents qtd_tab As TabPage
    Friend WithEvents auto_medicao_panel As Panel
    Friend WithEvents regie_tab As TabPage
    Friend WithEvents regie_panel As Panel
    Friend WithEvents download_photo As LinkLabel
    Friend WithEvents photo_separator As Label
    Friend WithEvents photo_title As Label
    Friend WithEvents LivraisonPhoto As PictureBox
    Friend WithEvents view_photo As LinkLabel
    Friend WithEvents LivraisonPhotoSelection As ComboBox
    Friend WithEvents qtd_datatable As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents del_photo As LinkLabel
    Friend WithEvents add_photo As LinkLabel
    Friend WithEvents livraison_datatable As DataGridView
    Friend WithEvents regieSetCurrentMonth As LinkLabel
    Friend WithEvents regie_data_fim As DateTimePicker
    Friend WithEvents regie_dateTo_lbl As Label
    Friend WithEvents regie_data_inicio As DateTimePicker
    Friend WithEvents regie_datatable As DataGridView
    Friend WithEvents regie_select_site As PictureBox
    Friend WithEvents regie_section_lbl As Label
    Friend WithEvents regie_section As ComboBox
    Friend WithEvents regie_del_photo As LinkLabel
    Friend WithEvents regie_add_photo As LinkLabel
    Friend WithEvents regie_view_photo As LinkLabel
    Friend WithEvents regiePhotoSelection As ComboBox
    Friend WithEvents regie_download_photo As LinkLabel
    Friend WithEvents regie_photo_separator As Label
    Friend WithEvents regie_photo_title As Label
    Friend WithEvents regiePhoto As PictureBox
    Friend WithEvents regie_site As ComboBox
    Friend WithEvents regieGroupBox_siteSelection As GroupBox
    Friend WithEvents GroupBox_legenda As GroupBox
    Friend WithEvents regieLegendOngoing As Label
    Friend WithEvents ongoingBox As Label
    Friend WithEvents regieLegendAutoEod As Label
    Friend WithEvents autoEodBox As Label
    Friend WithEvents regieLegendEod As Label
    Friend WithEvents eodBox As Label
    Friend WithEvents regieLegendClosed As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents livraison_GroupBox_siteSelection As GroupBox
    Friend WithEvents livraison_site As ComboBox
    Friend WithEvents livraison_section As ComboBox
    Friend WithEvents livraisonSection_lbl As Label
    Friend WithEvents select_site As PictureBox
    Friend WithEvents bordereuGroupBoxSelection As GroupBox
    Friend WithEvents qtd_section As ComboBox
    Friend WithEvents bordereau_sectionSelection_lbl As Label
    Friend WithEvents LoadBordereau As PictureBox
    Friend WithEvents autoMedicaoGroupBoxSelection As GroupBox
    Friend WithEvents auto_medicao_site As ComboBox
    Friend WithEvents auto_medicao_section As ComboBox
    Friend WithEvents autoMedicaoSection_lbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents auto_medicao_datatable As DataGridView
    Friend WithEvents auto_medicao_qtd_group As GroupBox
    Friend WithEvents autoMedicaoRecordDate_lbl As Label
    Friend WithEvents auto_medicao_date As DateTimePicker
    Friend WithEvents autoMedicaoRecordQtd_lbl As Label
    Friend WithEvents auto_medicao_qtd As TextBox
    Friend WithEvents auto_medicao_bar As Label
    Friend WithEvents auto_medicao_title As Label
    Friend WithEvents auto_medicao_tasks_group As GroupBox
    Friend WithEvents auto_medicao_update_tasks As LinkLabel
    Friend WithEvents auto_medicao_tasks_list As ListBox
    Friend WithEvents auto_medicao_workers_group As GroupBox
    Friend WithEvents auto_medicao_update_workers As LinkLabel
    Friend WithEvents auto_medicao_afetacao As Label
    Friend WithEvents autoMedicaoWorkersOnSite_lbl As Label
    Friend WithEvents auto_medicao_workers As ListBox
    Friend WithEvents auto_medicao_workers_selected As ListBox
    Friend WithEvents autoMedicaoSetCurrentMonth As LinkLabel
    Friend WithEvents auto_medicao_data_fim As DateTimePicker
    Friend WithEvents autoMedicaoDateTo_lbl As Label
    Friend WithEvents auto_medicao_data_inicio As DateTimePicker
    Friend WithEvents auto_medicao_notas As TextBox
    Friend WithEvents autoMedicaoRecordAnnotations_lbl As Label
    Friend WithEvents auto_medicao_reset As LinkLabel
    Friend WithEvents auto_medicao_units As Label
    Friend WithEvents auto_medicao_translate As LinkLabel
    Friend WithEvents journal_tab As TabPage
    Friend WithEvents journalSection_lbl As Label
    Friend WithEvents combo_section As ComboBox
    Friend WithEvents logger_label As Label
    Friend WithEvents journal_label As Label
    Friend WithEvents regie_chk As CheckBox
    Friend WithEvents livraison_chk As CheckBox
    Friend WithEvents qtds_chk As CheckBox
    Friend WithEvents journal_chk As CheckBox
    Friend WithEvents meteo_chk As CheckBox
    Friend WithEvents journalData_lbl As Label
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents calendar As DateTimePicker
    Friend WithEvents categories_box As CheckBox
    Friend WithEvents ocurrences_label As Label
    Friend WithEvents view_doc As LinkLabel
    Friend WithEvents activities_label As Label
    Friend WithEvents ocurrences As TextBox
    Friend WithEvents activities As TextBox
    Friend WithEvents panel_journal As Panel
    Friend WithEvents Panel_logger As Panel
    Friend WithEvents Timer2 As Timer
    Friend WithEvents JournalGroupBoxSelection As GroupBox
    Friend WithEvents journalLoadButton As PictureBox
    Friend WithEvents journal_num_workers As Label
    Friend WithEvents livraisonCurrentMonthSelection_lbl As LinkLabel
    Friend WithEvents livraison_data_fim As DateTimePicker
    Friend WithEvents livraisonDateTo_lbl As Label
    Friend WithEvents livraison_data_inicio As DateTimePicker
    Friend WithEvents autoMedicaoDate_lbl As Label
    Friend WithEvents livraisonDate_lbl As Label
    Friend WithEvents regie_date_lbl As Label
    Friend WithEvents statsLinkLivraison As LinkLabel
    Friend WithEvents qtd_amountsChk As CheckBox
    Friend WithEvents qtd_qtdChk As CheckBox
    Friend WithEvents qtd_data_lbl As Label
    Friend WithEvents qtd_setCurrentMonth As LinkLabel
    Friend WithEvents qtd_data_fim As DateTimePicker
    Friend WithEvents qtd_data_to As Label
    Friend WithEvents qtd_data_inicio As DateTimePicker
    Public WithEvents qtd_site As ComboBox
    Friend WithEvents qtd_acumulatedResultsChk As CheckBox
    Friend WithEvents update_loggerBtn As PictureBox
    Friend WithEvents update_journalBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
    Friend WithEvents auto_medicao_delBtn As PictureBox
    Friend WithEvents auto_medicao_savebtn As PictureBox
End Class
