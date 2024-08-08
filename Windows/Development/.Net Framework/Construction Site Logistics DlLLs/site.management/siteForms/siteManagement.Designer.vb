Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class site_mng_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(site_mng_frm))
        Me.loading_status_company = New System.Windows.Forms.Label()
        Me.loading_status_contractor_manager = New System.Windows.Forms.Label()
        Me.loading_status = New System.Windows.Forms.Label()
        Me.CompanyLogo = New System.Windows.Forms.PictureBox()
        Me.contractorManagerPhotobox = New System.Windows.Forms.PictureBox()
        Me.atribuirSection = New System.Windows.Forms.LinkLabel()
        Me.contractorManagerResetSection = New System.Windows.Forms.LinkLabel()
        Me.contractorManagerSection = New System.Windows.Forms.TextBox()
        Me.contractorManagerSectionAssigned_lbl = New System.Windows.Forms.Label()
        Me.atribuirEmpresa = New System.Windows.Forms.LinkLabel()
        Me.Panel_geral = New System.Windows.Forms.Panel()
        Me.updateBtn = New System.Windows.Forms.PictureBox()
        Me.sitesListSelection = New System.Windows.Forms.ComboBox()
        Me.GroupBoxHourly = New System.Windows.Forms.GroupBox()
        Me.delObraBtn = New System.Windows.Forms.PictureBox()
        Me.saveObraBtn = New System.Windows.Forms.PictureBox()
        Me.after_hours_time_lbl = New System.Windows.Forms.Label()
        Me.unitshourly9 = New System.Windows.Forms.Label()
        Me.unitshourly8 = New System.Windows.Forms.Label()
        Me.unitshourly7 = New System.Windows.Forms.Label()
        Me.craneman_after_hours = New System.Windows.Forms.TextBox()
        Me.machinist_after_hours = New System.Windows.Forms.TextBox()
        Me.regie_after_hours = New System.Windows.Forms.TextBox()
        Me.weekends_time_lbl = New System.Windows.Forms.Label()
        Me.unitshourly6 = New System.Windows.Forms.Label()
        Me.unitshourly5 = New System.Windows.Forms.Label()
        Me.unitshourly4 = New System.Windows.Forms.Label()
        Me.craneman_weekends = New System.Windows.Forms.TextBox()
        Me.machinist_weekends = New System.Windows.Forms.TextBox()
        Me.regie_weekends = New System.Windows.Forms.TextBox()
        Me.normal_time_lbl = New System.Windows.Forms.Label()
        Me.unitshourly3 = New System.Windows.Forms.Label()
        Me.unitshourly2 = New System.Windows.Forms.Label()
        Me.unitshourly1 = New System.Windows.Forms.Label()
        Me.cranemanHourly_lbl = New System.Windows.Forms.Label()
        Me.machinistHourly_lbl = New System.Windows.Forms.Label()
        Me.regieHourly_lbl = New System.Windows.Forms.Label()
        Me.cranemanHourly = New System.Windows.Forms.TextBox()
        Me.machinistHourly = New System.Windows.Forms.TextBox()
        Me.regieHourly = New System.Windows.Forms.TextBox()
        Me.GroupBoxSite = New System.Windows.Forms.GroupBox()
        Me.primaryLanguage = New System.Windows.Forms.Label()
        Me.setPrimaryLang = New System.Windows.Forms.LinkLabel()
        Me.show_default_lang = New System.Windows.Forms.CheckBox()
        Me.languagesProject_lbl = New System.Windows.Forms.Label()
        Me.show_all_lang = New System.Windows.Forms.CheckBox()
        Me.languagesList = New System.Windows.Forms.ListBox()
        Me.siteName_lbl = New System.Windows.Forms.Label()
        Me.nomeObra = New System.Windows.Forms.TextBox()
        Me.site_ended = New System.Windows.Forms.CheckBox()
        Me.siteAddress_lbl = New System.Windows.Forms.Label()
        Me.moradaObra = New System.Windows.Forms.TextBox()
        Me.siteInitials_lbl = New System.Windows.Forms.Label()
        Me.siglaObra = New System.Windows.Forms.TextBox()
        Me.resetEmpresa = New System.Windows.Forms.LinkLabel()
        Me.siteDuration_lbl = New System.Windows.Forms.Label()
        Me.siteStart_lbl = New System.Windows.Forms.Label()
        Me.siteEnd_lbl = New System.Windows.Forms.Label()
        Me.EmpresaAtribuida = New System.Windows.Forms.TextBox()
        Me.siteRefContract_lbl = New System.Windows.Forms.Label()
        Me.siteCompanyAssigned_lbl = New System.Windows.Forms.Label()
        Me.refcontrato = New System.Windows.Forms.TextBox()
        Me.duracaoFim = New System.Windows.Forms.DateTimePicker()
        Me.duracaoInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxCompany = New System.Windows.Forms.GroupBox()
        Me.delEmpresaBtn = New System.Windows.Forms.PictureBox()
        Me.downloadCompanyLogo = New System.Windows.Forms.PictureBox()
        Me.companyName_lbl = New System.Windows.Forms.Label()
        Me.nomeEmpresa = New System.Windows.Forms.TextBox()
        Me.companyAddress_lbl = New System.Windows.Forms.Label()
        Me.moradaEmpresa = New System.Windows.Forms.TextBox()
        Me.companyTva_lbl = New System.Windows.Forms.Label()
        Me.tvaEmpresa = New System.Windows.Forms.TextBox()
        Me.companyEmail_lbl = New System.Windows.Forms.Label()
        Me.emailEmpresa = New System.Windows.Forms.TextBox()
        Me.companyPhone_lbl = New System.Windows.Forms.Label()
        Me.telefoneEmpresa = New System.Windows.Forms.TextBox()
        Me.GroupBoxSections = New System.Windows.Forms.GroupBox()
        Me.delSectionBtn = New System.Windows.Forms.PictureBox()
        Me.saveSectionBtn = New System.Windows.Forms.PictureBox()
        Me.sectionDescription_lbl = New System.Windows.Forms.Label()
        Me.descriptionSection = New System.Windows.Forms.TextBox()
        Me.GroupBoxContractorManagers = New System.Windows.Forms.GroupBox()
        Me.delContractorManagerBtn = New System.Windows.Forms.PictureBox()
        Me.saveContractorManagerBtn = New System.Windows.Forms.PictureBox()
        Me.downloadPhotoContractorManager = New System.Windows.Forms.PictureBox()
        Me.saveNewCard = New System.Windows.Forms.LinkLabel()
        Me.contractorManagerName_lbl = New System.Windows.Forms.Label()
        Me.contractorManagerCardCode = New System.Windows.Forms.TextBox()
        Me.contractorManagerName = New System.Windows.Forms.TextBox()
        Me.contractorManagerCardCode_lbl = New System.Windows.Forms.Label()
        Me.contractorManagerCardId_lbl = New System.Windows.Forms.Label()
        Me.contractorManagerCardId = New System.Windows.Forms.TextBox()
        Me.contractorManagerEmail_lbl = New System.Windows.Forms.Label()
        Me.conractorManagerEmail = New System.Windows.Forms.TextBox()
        Me.contractorManagerPhone_lbl = New System.Windows.Forms.Label()
        Me.contractorManagerPhone = New System.Windows.Forms.TextBox()
        Me.contractorManagerJobAuthority = New System.Windows.Forms.ComboBox()
        Me.contractorManagerJobAuthority_lbl = New System.Windows.Forms.Label()
        Me.loading_status_sections = New System.Windows.Forms.Label()
        Me.sectionTitle = New System.Windows.Forms.Label()
        Me.sectionsList = New System.Windows.Forms.ListBox()
        Me.divider2 = New System.Windows.Forms.Label()
        Me.divider3 = New System.Windows.Forms.Label()
        Me.divider4 = New System.Windows.Forms.Label()
        Me.contractorManagersTitle = New System.Windows.Forms.Label()
        Me.companyTitle = New System.Windows.Forms.Label()
        Me.EmpresaList = New System.Windows.Forms.ListBox()
        Me.sectionsFileTitle = New System.Windows.Forms.Label()
        Me.contratorManagerList = New System.Windows.Forms.ListBox()
        Me.contractorManagersFileTitle = New System.Windows.Forms.Label()
        Me.companyFileTitle = New System.Windows.Forms.Label()
        Me.mandatoryFields = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.siteFileTitle = New System.Windows.Forms.Label()
        Me.siteTitle = New System.Windows.Forms.Label()
        Me.ObrasList = New System.Windows.Forms.ListBox()
        Me.GroupBoxManagers = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.downloadPhotoManagerBtn = New System.Windows.Forms.PictureBox()
        Me.managerPhotobox = New System.Windows.Forms.PictureBox()
        Me.managerName_lbl = New System.Windows.Forms.Label()
        Me.managerName = New System.Windows.Forms.TextBox()
        Me.managerCardId_lbl = New System.Windows.Forms.Label()
        Me.managerCardId = New System.Windows.Forms.TextBox()
        Me.managerEmail_lbl = New System.Windows.Forms.Label()
        Me.managerEmail = New System.Windows.Forms.TextBox()
        Me.managerPhone_lbl = New System.Windows.Forms.Label()
        Me.managerPhone = New System.Windows.Forms.TextBox()
        Me.managerJobAuthority = New System.Windows.Forms.ComboBox()
        Me.managerJobAuthority_lbl = New System.Windows.Forms.Label()
        Me.managerAssignedSection = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.managerSectionReset = New System.Windows.Forms.LinkLabel()
        Me.loadingStatusManager = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.managerTitle = New System.Windows.Forms.Label()
        Me.managerList = New System.Windows.Forms.ListBox()
        Me.managerFileTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sectionRadius = New System.Windows.Forms.TextBox()
        Me.sectionRadius_lbl = New System.Windows.Forms.Label()
        Me.sectionGpsCoordinates_lbl = New System.Windows.Forms.Label()
        Me.sectionLatitude_lbl = New System.Windows.Forms.Label()
        Me.sectionLongitude_lbl = New System.Windows.Forms.Label()
        Me.sectionLatitude = New System.Windows.Forms.TextBox()
        Me.sectionLongitude = New System.Windows.Forms.TextBox()
        Me.sectiondistance_lbl = New System.Windows.Forms.Label()
        Me.sectionDistance = New System.Windows.Forms.TextBox()
        Me.saveEmpresaBtn = New System.Windows.Forms.PictureBox()
        CType(Me.CompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contractorManagerPhotobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_geral.SuspendLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxHourly.SuspendLayout()
        CType(Me.delObraBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveObraBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSite.SuspendLayout()
        Me.GroupBoxCompany.SuspendLayout()
        CType(Me.delEmpresaBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downloadCompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSections.SuspendLayout()
        CType(Me.delSectionBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveSectionBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxContractorManagers.SuspendLayout()
        CType(Me.delContractorManagerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveContractorManagerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downloadPhotoContractorManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxManagers.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.downloadPhotoManagerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.managerPhotobox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveEmpresaBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'loading_status_company
        '
        Me.loading_status_company.AutoSize = True
        Me.loading_status_company.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_company.ForeColor = System.Drawing.Color.Red
        Me.loading_status_company.Location = New System.Drawing.Point(139, 1971)
        Me.loading_status_company.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_company.Name = "loading_status_company"
        Me.loading_status_company.Size = New System.Drawing.Size(97, 20)
        Me.loading_status_company.TabIndex = 280
        Me.loading_status_company.Text = "aguarde..."
        '
        'loading_status_contractor_manager
        '
        Me.loading_status_contractor_manager.AutoSize = True
        Me.loading_status_contractor_manager.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_contractor_manager.ForeColor = System.Drawing.Color.Red
        Me.loading_status_contractor_manager.Location = New System.Drawing.Point(211, 1571)
        Me.loading_status_contractor_manager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_contractor_manager.Name = "loading_status_contractor_manager"
        Me.loading_status_contractor_manager.Size = New System.Drawing.Size(97, 20)
        Me.loading_status_contractor_manager.TabIndex = 279
        Me.loading_status_contractor_manager.Text = "aguarde..."
        '
        'loading_status
        '
        Me.loading_status.AutoSize = True
        Me.loading_status.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status.ForeColor = System.Drawing.Color.Red
        Me.loading_status.Location = New System.Drawing.Point(100, 9)
        Me.loading_status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status.Name = "loading_status"
        Me.loading_status.Size = New System.Drawing.Size(97, 20)
        Me.loading_status.TabIndex = 277
        Me.loading_status.Text = "aguarde..."
        '
        'CompanyLogo
        '
        Me.CompanyLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyLogo.Image = CType(resources.GetObject("CompanyLogo.Image"), System.Drawing.Image)
        Me.CompanyLogo.Location = New System.Drawing.Point(21, 49)
        Me.CompanyLogo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CompanyLogo.Name = "CompanyLogo"
        Me.CompanyLogo.Size = New System.Drawing.Size(179, 187)
        Me.CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CompanyLogo.TabIndex = 275
        Me.CompanyLogo.TabStop = False
        '
        'contractorManagerPhotobox
        '
        Me.contractorManagerPhotobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contractorManagerPhotobox.Image = CType(resources.GetObject("contractorManagerPhotobox.Image"), System.Drawing.Image)
        Me.contractorManagerPhotobox.Location = New System.Drawing.Point(21, 48)
        Me.contractorManagerPhotobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerPhotobox.Name = "contractorManagerPhotobox"
        Me.contractorManagerPhotobox.Size = New System.Drawing.Size(179, 187)
        Me.contractorManagerPhotobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.contractorManagerPhotobox.TabIndex = 273
        Me.contractorManagerPhotobox.TabStop = False
        '
        'atribuirSection
        '
        Me.atribuirSection.AutoSize = True
        Me.atribuirSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atribuirSection.Location = New System.Drawing.Point(20, 88)
        Me.atribuirSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.atribuirSection.Name = "atribuirSection"
        Me.atribuirSection.Size = New System.Drawing.Size(140, 20)
        Me.atribuirSection.TabIndex = 272
        Me.atribuirSection.TabStop = True
        Me.atribuirSection.Text = "Atribuir Secção"
        '
        'contractorManagerResetSection
        '
        Me.contractorManagerResetSection.AutoSize = True
        Me.contractorManagerResetSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerResetSection.Location = New System.Drawing.Point(225, 300)
        Me.contractorManagerResetSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerResetSection.Name = "contractorManagerResetSection"
        Me.contractorManagerResetSection.Size = New System.Drawing.Size(57, 20)
        Me.contractorManagerResetSection.TabIndex = 271
        Me.contractorManagerResetSection.TabStop = True
        Me.contractorManagerResetSection.Text = "Reset"
        '
        'contractorManagerSection
        '
        Me.contractorManagerSection.Enabled = False
        Me.contractorManagerSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerSection.Location = New System.Drawing.Point(230, 265)
        Me.contractorManagerSection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerSection.Name = "contractorManagerSection"
        Me.contractorManagerSection.Size = New System.Drawing.Size(637, 28)
        Me.contractorManagerSection.TabIndex = 269
        '
        'contractorManagerSectionAssigned_lbl
        '
        Me.contractorManagerSectionAssigned_lbl.AutoSize = True
        Me.contractorManagerSectionAssigned_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerSectionAssigned_lbl.Location = New System.Drawing.Point(225, 238)
        Me.contractorManagerSectionAssigned_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerSectionAssigned_lbl.Name = "contractorManagerSectionAssigned_lbl"
        Me.contractorManagerSectionAssigned_lbl.Size = New System.Drawing.Size(152, 20)
        Me.contractorManagerSectionAssigned_lbl.TabIndex = 270
        Me.contractorManagerSectionAssigned_lbl.Text = "Secção atribuida"
        '
        'atribuirEmpresa
        '
        Me.atribuirEmpresa.AutoSize = True
        Me.atribuirEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atribuirEmpresa.Location = New System.Drawing.Point(220, 242)
        Me.atribuirEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.atribuirEmpresa.Name = "atribuirEmpresa"
        Me.atribuirEmpresa.Size = New System.Drawing.Size(155, 20)
        Me.atribuirEmpresa.TabIndex = 265
        Me.atribuirEmpresa.TabStop = True
        Me.atribuirEmpresa.Text = "Atribuir Empresa"
        '
        'Panel_geral
        '
        Me.Panel_geral.AutoScroll = True
        Me.Panel_geral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel_geral.BackColor = System.Drawing.Color.White
        Me.Panel_geral.Controls.Add(Me.Label1)
        Me.Panel_geral.Controls.Add(Me.GroupBoxManagers)
        Me.Panel_geral.Controls.Add(Me.loadingStatusManager)
        Me.Panel_geral.Controls.Add(Me.Label10)
        Me.Panel_geral.Controls.Add(Me.managerTitle)
        Me.Panel_geral.Controls.Add(Me.managerList)
        Me.Panel_geral.Controls.Add(Me.managerFileTitle)
        Me.Panel_geral.Controls.Add(Me.updateBtn)
        Me.Panel_geral.Controls.Add(Me.sitesListSelection)
        Me.Panel_geral.Controls.Add(Me.GroupBoxHourly)
        Me.Panel_geral.Controls.Add(Me.GroupBoxSite)
        Me.Panel_geral.Controls.Add(Me.GroupBoxCompany)
        Me.Panel_geral.Controls.Add(Me.GroupBoxSections)
        Me.Panel_geral.Controls.Add(Me.GroupBoxContractorManagers)
        Me.Panel_geral.Controls.Add(Me.loading_status_company)
        Me.Panel_geral.Controls.Add(Me.loading_status_contractor_manager)
        Me.Panel_geral.Controls.Add(Me.loading_status_sections)
        Me.Panel_geral.Controls.Add(Me.loading_status)
        Me.Panel_geral.Controls.Add(Me.sectionTitle)
        Me.Panel_geral.Controls.Add(Me.sectionsList)
        Me.Panel_geral.Controls.Add(Me.divider2)
        Me.Panel_geral.Controls.Add(Me.divider3)
        Me.Panel_geral.Controls.Add(Me.divider4)
        Me.Panel_geral.Controls.Add(Me.contractorManagersTitle)
        Me.Panel_geral.Controls.Add(Me.companyTitle)
        Me.Panel_geral.Controls.Add(Me.EmpresaList)
        Me.Panel_geral.Controls.Add(Me.sectionsFileTitle)
        Me.Panel_geral.Controls.Add(Me.contratorManagerList)
        Me.Panel_geral.Controls.Add(Me.contractorManagersFileTitle)
        Me.Panel_geral.Controls.Add(Me.companyFileTitle)
        Me.Panel_geral.Controls.Add(Me.mandatoryFields)
        Me.Panel_geral.Controls.Add(Me.divider)
        Me.Panel_geral.Controls.Add(Me.siteFileTitle)
        Me.Panel_geral.Controls.Add(Me.siteTitle)
        Me.Panel_geral.Controls.Add(Me.ObrasList)
        Me.Panel_geral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_geral.Location = New System.Drawing.Point(3, 3)
        Me.Panel_geral.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel_geral.Name = "Panel_geral"
        Me.Panel_geral.Size = New System.Drawing.Size(2172, 1923)
        Me.Panel_geral.TabIndex = 1
        Me.Panel_geral.Visible = False
        '
        'updateBtn
        '
        Me.updateBtn.Image = CType(resources.GetObject("updateBtn.Image"), System.Drawing.Image)
        Me.updateBtn.Location = New System.Drawing.Point(493, 788)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(50, 50)
        Me.updateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.updateBtn.TabIndex = 352
        Me.updateBtn.TabStop = False
        '
        'sitesListSelection
        '
        Me.sitesListSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sitesListSelection.FormattingEnabled = True
        Me.sitesListSelection.Location = New System.Drawing.Point(15, 37)
        Me.sitesListSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sitesListSelection.Name = "sitesListSelection"
        Me.sitesListSelection.Size = New System.Drawing.Size(523, 28)
        Me.sitesListSelection.TabIndex = 292
        '
        'GroupBoxHourly
        '
        Me.GroupBoxHourly.Controls.Add(Me.delObraBtn)
        Me.GroupBoxHourly.Controls.Add(Me.saveObraBtn)
        Me.GroupBoxHourly.Controls.Add(Me.after_hours_time_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly9)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly8)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly7)
        Me.GroupBoxHourly.Controls.Add(Me.craneman_after_hours)
        Me.GroupBoxHourly.Controls.Add(Me.machinist_after_hours)
        Me.GroupBoxHourly.Controls.Add(Me.regie_after_hours)
        Me.GroupBoxHourly.Controls.Add(Me.weekends_time_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly6)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly5)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly4)
        Me.GroupBoxHourly.Controls.Add(Me.craneman_weekends)
        Me.GroupBoxHourly.Controls.Add(Me.machinist_weekends)
        Me.GroupBoxHourly.Controls.Add(Me.regie_weekends)
        Me.GroupBoxHourly.Controls.Add(Me.normal_time_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly3)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly2)
        Me.GroupBoxHourly.Controls.Add(Me.unitshourly1)
        Me.GroupBoxHourly.Controls.Add(Me.cranemanHourly_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.machinistHourly_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.regieHourly_lbl)
        Me.GroupBoxHourly.Controls.Add(Me.cranemanHourly)
        Me.GroupBoxHourly.Controls.Add(Me.machinistHourly)
        Me.GroupBoxHourly.Controls.Add(Me.regieHourly)
        Me.GroupBoxHourly.Location = New System.Drawing.Point(586, 570)
        Me.GroupBoxHourly.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxHourly.Name = "GroupBoxHourly"
        Me.GroupBoxHourly.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxHourly.Size = New System.Drawing.Size(1344, 268)
        Me.GroupBoxHourly.TabIndex = 291
        Me.GroupBoxHourly.TabStop = False
        Me.GroupBoxHourly.Text = "Preço de prestações com taxa horaria"
        '
        'delObraBtn
        '
        Me.delObraBtn.Image = CType(resources.GetObject("delObraBtn.Image"), System.Drawing.Image)
        Me.delObraBtn.Location = New System.Drawing.Point(1203, 192)
        Me.delObraBtn.Name = "delObraBtn"
        Me.delObraBtn.Size = New System.Drawing.Size(50, 50)
        Me.delObraBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delObraBtn.TabIndex = 354
        Me.delObraBtn.TabStop = False
        '
        'saveObraBtn
        '
        Me.saveObraBtn.Image = CType(resources.GetObject("saveObraBtn.Image"), System.Drawing.Image)
        Me.saveObraBtn.Location = New System.Drawing.Point(1270, 192)
        Me.saveObraBtn.Name = "saveObraBtn"
        Me.saveObraBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveObraBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveObraBtn.TabIndex = 352
        Me.saveObraBtn.TabStop = False
        '
        'after_hours_time_lbl
        '
        Me.after_hours_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.after_hours_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.after_hours_time_lbl.Location = New System.Drawing.Point(35, 150)
        Me.after_hours_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.after_hours_time_lbl.Name = "after_hours_time_lbl"
        Me.after_hours_time_lbl.Size = New System.Drawing.Size(256, 26)
        Me.after_hours_time_lbl.TabIndex = 232
        Me.after_hours_time_lbl.Text = "horario extra*"
        Me.after_hours_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly9
        '
        Me.unitshourly9.AutoSize = True
        Me.unitshourly9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly9.Location = New System.Drawing.Point(1199, 148)
        Me.unitshourly9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly9.Name = "unitshourly9"
        Me.unitshourly9.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly9.TabIndex = 231
        Me.unitshourly9.Text = "€/h"
        '
        'unitshourly8
        '
        Me.unitshourly8.AutoSize = True
        Me.unitshourly8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly8.Location = New System.Drawing.Point(869, 148)
        Me.unitshourly8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly8.Name = "unitshourly8"
        Me.unitshourly8.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly8.TabIndex = 230
        Me.unitshourly8.Text = "€/h"
        '
        'unitshourly7
        '
        Me.unitshourly7.AutoSize = True
        Me.unitshourly7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly7.Location = New System.Drawing.Point(491, 148)
        Me.unitshourly7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly7.Name = "unitshourly7"
        Me.unitshourly7.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly7.TabIndex = 229
        Me.unitshourly7.Text = "€/h"
        '
        'craneman_after_hours
        '
        Me.craneman_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.craneman_after_hours.Location = New System.Drawing.Point(1004, 144)
        Me.craneman_after_hours.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.craneman_after_hours.Name = "craneman_after_hours"
        Me.craneman_after_hours.Size = New System.Drawing.Size(187, 28)
        Me.craneman_after_hours.TabIndex = 228
        '
        'machinist_after_hours
        '
        Me.machinist_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinist_after_hours.Location = New System.Drawing.Point(671, 144)
        Me.machinist_after_hours.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.machinist_after_hours.Name = "machinist_after_hours"
        Me.machinist_after_hours.Size = New System.Drawing.Size(187, 28)
        Me.machinist_after_hours.TabIndex = 227
        '
        'regie_after_hours
        '
        Me.regie_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_after_hours.Location = New System.Drawing.Point(300, 144)
        Me.regie_after_hours.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_after_hours.Name = "regie_after_hours"
        Me.regie_after_hours.Size = New System.Drawing.Size(187, 28)
        Me.regie_after_hours.TabIndex = 226
        '
        'weekends_time_lbl
        '
        Me.weekends_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.weekends_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weekends_time_lbl.Location = New System.Drawing.Point(30, 108)
        Me.weekends_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weekends_time_lbl.Name = "weekends_time_lbl"
        Me.weekends_time_lbl.Size = New System.Drawing.Size(261, 26)
        Me.weekends_time_lbl.TabIndex = 225
        Me.weekends_time_lbl.Text = "fim de semana*"
        Me.weekends_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly6
        '
        Me.unitshourly6.AutoSize = True
        Me.unitshourly6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly6.Location = New System.Drawing.Point(1199, 107)
        Me.unitshourly6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly6.Name = "unitshourly6"
        Me.unitshourly6.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly6.TabIndex = 224
        Me.unitshourly6.Text = "€/h"
        '
        'unitshourly5
        '
        Me.unitshourly5.AutoSize = True
        Me.unitshourly5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly5.Location = New System.Drawing.Point(869, 107)
        Me.unitshourly5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly5.Name = "unitshourly5"
        Me.unitshourly5.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly5.TabIndex = 223
        Me.unitshourly5.Text = "€/h"
        '
        'unitshourly4
        '
        Me.unitshourly4.AutoSize = True
        Me.unitshourly4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly4.Location = New System.Drawing.Point(491, 107)
        Me.unitshourly4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly4.Name = "unitshourly4"
        Me.unitshourly4.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly4.TabIndex = 222
        Me.unitshourly4.Text = "€/h"
        '
        'craneman_weekends
        '
        Me.craneman_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.craneman_weekends.Location = New System.Drawing.Point(1004, 102)
        Me.craneman_weekends.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.craneman_weekends.Name = "craneman_weekends"
        Me.craneman_weekends.Size = New System.Drawing.Size(187, 28)
        Me.craneman_weekends.TabIndex = 221
        '
        'machinist_weekends
        '
        Me.machinist_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinist_weekends.Location = New System.Drawing.Point(671, 102)
        Me.machinist_weekends.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.machinist_weekends.Name = "machinist_weekends"
        Me.machinist_weekends.Size = New System.Drawing.Size(187, 28)
        Me.machinist_weekends.TabIndex = 220
        '
        'regie_weekends
        '
        Me.regie_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_weekends.Location = New System.Drawing.Point(300, 102)
        Me.regie_weekends.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regie_weekends.Name = "regie_weekends"
        Me.regie_weekends.Size = New System.Drawing.Size(187, 28)
        Me.regie_weekends.TabIndex = 219
        '
        'normal_time_lbl
        '
        Me.normal_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.normal_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.normal_time_lbl.Location = New System.Drawing.Point(26, 67)
        Me.normal_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.normal_time_lbl.Name = "normal_time_lbl"
        Me.normal_time_lbl.Size = New System.Drawing.Size(266, 26)
        Me.normal_time_lbl.TabIndex = 218
        Me.normal_time_lbl.Text = "horario normal*"
        Me.normal_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly3
        '
        Me.unitshourly3.AutoSize = True
        Me.unitshourly3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly3.Location = New System.Drawing.Point(1199, 65)
        Me.unitshourly3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly3.Name = "unitshourly3"
        Me.unitshourly3.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly3.TabIndex = 217
        Me.unitshourly3.Text = "€/h"
        '
        'unitshourly2
        '
        Me.unitshourly2.AutoSize = True
        Me.unitshourly2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly2.Location = New System.Drawing.Point(869, 65)
        Me.unitshourly2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly2.Name = "unitshourly2"
        Me.unitshourly2.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly2.TabIndex = 216
        Me.unitshourly2.Text = "€/h"
        '
        'unitshourly1
        '
        Me.unitshourly1.AutoSize = True
        Me.unitshourly1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly1.Location = New System.Drawing.Point(491, 65)
        Me.unitshourly1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly1.Name = "unitshourly1"
        Me.unitshourly1.Size = New System.Drawing.Size(39, 20)
        Me.unitshourly1.TabIndex = 215
        Me.unitshourly1.Text = "€/h"
        '
        'cranemanHourly_lbl
        '
        Me.cranemanHourly_lbl.AutoSize = True
        Me.cranemanHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cranemanHourly_lbl.Location = New System.Drawing.Point(1000, 36)
        Me.cranemanHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.cranemanHourly_lbl.Name = "cranemanHourly_lbl"
        Me.cranemanHourly_lbl.Size = New System.Drawing.Size(82, 20)
        Me.cranemanHourly_lbl.TabIndex = 214
        Me.cranemanHourly_lbl.Text = "Gruista*"
        '
        'machinistHourly_lbl
        '
        Me.machinistHourly_lbl.AutoSize = True
        Me.machinistHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinistHourly_lbl.Location = New System.Drawing.Point(668, 36)
        Me.machinistHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.machinistHourly_lbl.Name = "machinistHourly_lbl"
        Me.machinistHourly_lbl.Size = New System.Drawing.Size(121, 20)
        Me.machinistHourly_lbl.TabIndex = 213
        Me.machinistHourly_lbl.Text = "Manobrador*"
        '
        'regieHourly_lbl
        '
        Me.regieHourly_lbl.AutoSize = True
        Me.regieHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieHourly_lbl.Location = New System.Drawing.Point(296, 36)
        Me.regieHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieHourly_lbl.Name = "regieHourly_lbl"
        Me.regieHourly_lbl.Size = New System.Drawing.Size(222, 20)
        Me.regieHourly_lbl.TabIndex = 212
        Me.regieHourly_lbl.Text = "Trabalhos nao previstos*"
        '
        'cranemanHourly
        '
        Me.cranemanHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cranemanHourly.Location = New System.Drawing.Point(1004, 61)
        Me.cranemanHourly.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cranemanHourly.Name = "cranemanHourly"
        Me.cranemanHourly.Size = New System.Drawing.Size(187, 28)
        Me.cranemanHourly.TabIndex = 211
        '
        'machinistHourly
        '
        Me.machinistHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinistHourly.Location = New System.Drawing.Point(671, 61)
        Me.machinistHourly.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.machinistHourly.Name = "machinistHourly"
        Me.machinistHourly.Size = New System.Drawing.Size(187, 28)
        Me.machinistHourly.TabIndex = 209
        '
        'regieHourly
        '
        Me.regieHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieHourly.Location = New System.Drawing.Point(300, 61)
        Me.regieHourly.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.regieHourly.Name = "regieHourly"
        Me.regieHourly.Size = New System.Drawing.Size(187, 28)
        Me.regieHourly.TabIndex = 207
        '
        'GroupBoxSite
        '
        Me.GroupBoxSite.Controls.Add(Me.primaryLanguage)
        Me.GroupBoxSite.Controls.Add(Me.setPrimaryLang)
        Me.GroupBoxSite.Controls.Add(Me.show_default_lang)
        Me.GroupBoxSite.Controls.Add(Me.languagesProject_lbl)
        Me.GroupBoxSite.Controls.Add(Me.show_all_lang)
        Me.GroupBoxSite.Controls.Add(Me.languagesList)
        Me.GroupBoxSite.Controls.Add(Me.siteName_lbl)
        Me.GroupBoxSite.Controls.Add(Me.nomeObra)
        Me.GroupBoxSite.Controls.Add(Me.site_ended)
        Me.GroupBoxSite.Controls.Add(Me.siteAddress_lbl)
        Me.GroupBoxSite.Controls.Add(Me.moradaObra)
        Me.GroupBoxSite.Controls.Add(Me.siteInitials_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siglaObra)
        Me.GroupBoxSite.Controls.Add(Me.resetEmpresa)
        Me.GroupBoxSite.Controls.Add(Me.siteDuration_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteStart_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteEnd_lbl)
        Me.GroupBoxSite.Controls.Add(Me.EmpresaAtribuida)
        Me.GroupBoxSite.Controls.Add(Me.siteRefContract_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteCompanyAssigned_lbl)
        Me.GroupBoxSite.Controls.Add(Me.refcontrato)
        Me.GroupBoxSite.Controls.Add(Me.duracaoFim)
        Me.GroupBoxSite.Controls.Add(Me.duracaoInicio)
        Me.GroupBoxSite.Location = New System.Drawing.Point(586, 85)
        Me.GroupBoxSite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSite.Name = "GroupBoxSite"
        Me.GroupBoxSite.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSite.Size = New System.Drawing.Size(1344, 475)
        Me.GroupBoxSite.TabIndex = 290
        Me.GroupBoxSite.TabStop = False
        '
        'primaryLanguage
        '
        Me.primaryLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.primaryLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primaryLanguage.Location = New System.Drawing.Point(962, 275)
        Me.primaryLanguage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.primaryLanguage.Name = "primaryLanguage"
        Me.primaryLanguage.Size = New System.Drawing.Size(345, 22)
        Me.primaryLanguage.TabIndex = 352
        Me.primaryLanguage.Text = "primary language: English"
        Me.primaryLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'setPrimaryLang
        '
        Me.setPrimaryLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.setPrimaryLang.Enabled = False
        Me.setPrimaryLang.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setPrimaryLang.Location = New System.Drawing.Point(1090, 431)
        Me.setPrimaryLang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.setPrimaryLang.Name = "setPrimaryLang"
        Me.setPrimaryLang.Size = New System.Drawing.Size(210, 20)
        Me.setPrimaryLang.TabIndex = 351
        Me.setPrimaryLang.TabStop = True
        Me.setPrimaryLang.Text = "Set as primary"
        Me.setPrimaryLang.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'show_default_lang
        '
        Me.show_default_lang.AutoSize = True
        Me.show_default_lang.Location = New System.Drawing.Point(876, 429)
        Me.show_default_lang.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.show_default_lang.Name = "show_default_lang"
        Me.show_default_lang.Size = New System.Drawing.Size(148, 24)
        Me.show_default_lang.TabIndex = 350
        Me.show_default_lang.Text = "Show default"
        Me.show_default_lang.UseVisualStyleBackColor = True
        '
        'languagesProject_lbl
        '
        Me.languagesProject_lbl.AutoSize = True
        Me.languagesProject_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.languagesProject_lbl.Location = New System.Drawing.Point(705, 272)
        Me.languagesProject_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.languagesProject_lbl.Name = "languagesProject_lbl"
        Me.languagesProject_lbl.Size = New System.Drawing.Size(194, 20)
        Me.languagesProject_lbl.TabIndex = 349
        Me.languagesProject_lbl.Text = "Languages of the project"
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(710, 429)
        Me.show_all_lang.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(108, 24)
        Me.show_all_lang.TabIndex = 348
        Me.show_all_lang.Text = "Show all"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'languagesList
        '
        Me.languagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.languagesList.FormattingEnabled = True
        Me.languagesList.ItemHeight = 20
        Me.languagesList.Location = New System.Drawing.Point(710, 302)
        Me.languagesList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.languagesList.Name = "languagesList"
        Me.languagesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.languagesList.Size = New System.Drawing.Size(596, 122)
        Me.languagesList.TabIndex = 347
        '
        'siteName_lbl
        '
        Me.siteName_lbl.AutoSize = True
        Me.siteName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteName_lbl.Location = New System.Drawing.Point(21, 31)
        Me.siteName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteName_lbl.Name = "siteName_lbl"
        Me.siteName_lbl.Size = New System.Drawing.Size(141, 20)
        Me.siteName_lbl.TabIndex = 38
        Me.siteName_lbl.Text = "Nome da obra*"
        '
        'nomeObra
        '
        Me.nomeObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeObra.Location = New System.Drawing.Point(26, 57)
        Me.nomeObra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nomeObra.Name = "nomeObra"
        Me.nomeObra.Size = New System.Drawing.Size(640, 28)
        Me.nomeObra.TabIndex = 4
        '
        'site_ended
        '
        Me.site_ended.AutoSize = True
        Me.site_ended.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_ended.Location = New System.Drawing.Point(32, 425)
        Me.site_ended.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.site_ended.Name = "site_ended"
        Me.site_ended.Size = New System.Drawing.Size(124, 24)
        Me.site_ended.TabIndex = 283
        Me.site_ended.Text = "Terminada"
        Me.site_ended.UseVisualStyleBackColor = True
        '
        'siteAddress_lbl
        '
        Me.siteAddress_lbl.AutoSize = True
        Me.siteAddress_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteAddress_lbl.Location = New System.Drawing.Point(21, 92)
        Me.siteAddress_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteAddress_lbl.Name = "siteAddress_lbl"
        Me.siteAddress_lbl.Size = New System.Drawing.Size(82, 20)
        Me.siteAddress_lbl.TabIndex = 43
        Me.siteAddress_lbl.Text = "Morada*"
        '
        'moradaObra
        '
        Me.moradaObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.moradaObra.Location = New System.Drawing.Point(26, 116)
        Me.moradaObra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.moradaObra.Multiline = True
        Me.moradaObra.Name = "moradaObra"
        Me.moradaObra.Size = New System.Drawing.Size(640, 181)
        Me.moradaObra.TabIndex = 7
        '
        'siteInitials_lbl
        '
        Me.siteInitials_lbl.AutoSize = True
        Me.siteInitials_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteInitials_lbl.Location = New System.Drawing.Point(702, 31)
        Me.siteInitials_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteInitials_lbl.Name = "siteInitials_lbl"
        Me.siteInitials_lbl.Size = New System.Drawing.Size(137, 20)
        Me.siteInitials_lbl.TabIndex = 45
        Me.siteInitials_lbl.Text = "Sigla da Obra*"
        '
        'siglaObra
        '
        Me.siglaObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siglaObra.Location = New System.Drawing.Point(706, 57)
        Me.siglaObra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.siglaObra.Name = "siglaObra"
        Me.siglaObra.Size = New System.Drawing.Size(106, 28)
        Me.siglaObra.TabIndex = 5
        '
        'resetEmpresa
        '
        Me.resetEmpresa.AutoSize = True
        Me.resetEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetEmpresa.Location = New System.Drawing.Point(26, 373)
        Me.resetEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.resetEmpresa.Name = "resetEmpresa"
        Me.resetEmpresa.Size = New System.Drawing.Size(57, 20)
        Me.resetEmpresa.TabIndex = 266
        Me.resetEmpresa.TabStop = True
        Me.resetEmpresa.Text = "Reset"
        '
        'siteDuration_lbl
        '
        Me.siteDuration_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteDuration_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteDuration_lbl.Location = New System.Drawing.Point(755, 118)
        Me.siteDuration_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteDuration_lbl.Name = "siteDuration_lbl"
        Me.siteDuration_lbl.Size = New System.Drawing.Size(222, 22)
        Me.siteDuration_lbl.TabIndex = 210
        Me.siteDuration_lbl.Text = "Duração prevista*"
        Me.siteDuration_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteStart_lbl
        '
        Me.siteStart_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteStart_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteStart_lbl.Location = New System.Drawing.Point(698, 145)
        Me.siteStart_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteStart_lbl.Name = "siteStart_lbl"
        Me.siteStart_lbl.Size = New System.Drawing.Size(141, 28)
        Me.siteStart_lbl.TabIndex = 211
        Me.siteStart_lbl.Text = "Inicio"
        Me.siteStart_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteEnd_lbl
        '
        Me.siteEnd_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteEnd_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteEnd_lbl.Location = New System.Drawing.Point(702, 185)
        Me.siteEnd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteEnd_lbl.Name = "siteEnd_lbl"
        Me.siteEnd_lbl.Size = New System.Drawing.Size(134, 28)
        Me.siteEnd_lbl.TabIndex = 212
        Me.siteEnd_lbl.Text = "Fim"
        Me.siteEnd_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EmpresaAtribuida
        '
        Me.EmpresaAtribuida.Enabled = False
        Me.EmpresaAtribuida.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpresaAtribuida.Location = New System.Drawing.Point(31, 337)
        Me.EmpresaAtribuida.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EmpresaAtribuida.Name = "EmpresaAtribuida"
        Me.EmpresaAtribuida.Size = New System.Drawing.Size(635, 28)
        Me.EmpresaAtribuida.TabIndex = 259
        '
        'siteRefContract_lbl
        '
        Me.siteRefContract_lbl.AutoSize = True
        Me.siteRefContract_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteRefContract_lbl.Location = New System.Drawing.Point(842, 31)
        Me.siteRefContract_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteRefContract_lbl.Name = "siteRefContract_lbl"
        Me.siteRefContract_lbl.Size = New System.Drawing.Size(122, 20)
        Me.siteRefContract_lbl.TabIndex = 217
        Me.siteRefContract_lbl.Text = "Ref. Contrato"
        '
        'siteCompanyAssigned_lbl
        '
        Me.siteCompanyAssigned_lbl.AutoSize = True
        Me.siteCompanyAssigned_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteCompanyAssigned_lbl.Location = New System.Drawing.Point(26, 311)
        Me.siteCompanyAssigned_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteCompanyAssigned_lbl.Name = "siteCompanyAssigned_lbl"
        Me.siteCompanyAssigned_lbl.Size = New System.Drawing.Size(189, 20)
        Me.siteCompanyAssigned_lbl.TabIndex = 260
        Me.siteCompanyAssigned_lbl.Text = "Empresa contratante"
        '
        'refcontrato
        '
        Me.refcontrato.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refcontrato.Location = New System.Drawing.Point(846, 57)
        Me.refcontrato.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.refcontrato.Name = "refcontrato"
        Me.refcontrato.Size = New System.Drawing.Size(414, 28)
        Me.refcontrato.TabIndex = 6
        '
        'duracaoFim
        '
        Me.duracaoFim.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoFim.Location = New System.Drawing.Point(850, 185)
        Me.duracaoFim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.duracaoFim.Name = "duracaoFim"
        Me.duracaoFim.Size = New System.Drawing.Size(301, 28)
        Me.duracaoFim.TabIndex = 9
        '
        'duracaoInicio
        '
        Me.duracaoInicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicio.Location = New System.Drawing.Point(850, 145)
        Me.duracaoInicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.duracaoInicio.Name = "duracaoInicio"
        Me.duracaoInicio.Size = New System.Drawing.Size(301, 28)
        Me.duracaoInicio.TabIndex = 8
        '
        'GroupBoxCompany
        '
        Me.GroupBoxCompany.Controls.Add(Me.delEmpresaBtn)
        Me.GroupBoxCompany.Controls.Add(Me.saveEmpresaBtn)
        Me.GroupBoxCompany.Controls.Add(Me.downloadCompanyLogo)
        Me.GroupBoxCompany.Controls.Add(Me.CompanyLogo)
        Me.GroupBoxCompany.Controls.Add(Me.companyName_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.nomeEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyAddress_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.moradaEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyTva_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.tvaEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyEmail_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.emailEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyPhone_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.telefoneEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.atribuirEmpresa)
        Me.GroupBoxCompany.Location = New System.Drawing.Point(587, 1973)
        Me.GroupBoxCompany.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxCompany.Name = "GroupBoxCompany"
        Me.GroupBoxCompany.Padding = New System.Windows.Forms.Padding(4, 5, 4, 50)
        Me.GroupBoxCompany.Size = New System.Drawing.Size(1341, 307)
        Me.GroupBoxCompany.TabIndex = 289
        Me.GroupBoxCompany.TabStop = False
        '
        'delEmpresaBtn
        '
        Me.delEmpresaBtn.Image = CType(resources.GetObject("delEmpresaBtn.Image"), System.Drawing.Image)
        Me.delEmpresaBtn.Location = New System.Drawing.Point(1199, 242)
        Me.delEmpresaBtn.Name = "delEmpresaBtn"
        Me.delEmpresaBtn.Size = New System.Drawing.Size(50, 50)
        Me.delEmpresaBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delEmpresaBtn.TabIndex = 353
        Me.delEmpresaBtn.TabStop = False
        '
        'downloadCompanyLogo
        '
        Me.downloadCompanyLogo.Image = CType(resources.GetObject("downloadCompanyLogo.Image"), System.Drawing.Image)
        Me.downloadCompanyLogo.Location = New System.Drawing.Point(21, 242)
        Me.downloadCompanyLogo.Name = "downloadCompanyLogo"
        Me.downloadCompanyLogo.Size = New System.Drawing.Size(50, 50)
        Me.downloadCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.downloadCompanyLogo.TabIndex = 351
        Me.downloadCompanyLogo.TabStop = False
        '
        'companyName_lbl
        '
        Me.companyName_lbl.AutoSize = True
        Me.companyName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyName_lbl.Location = New System.Drawing.Point(220, 23)
        Me.companyName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyName_lbl.Name = "companyName_lbl"
        Me.companyName_lbl.Size = New System.Drawing.Size(177, 20)
        Me.companyName_lbl.TabIndex = 219
        Me.companyName_lbl.Text = "Nome da empresa*"
        '
        'nomeEmpresa
        '
        Me.nomeEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeEmpresa.Location = New System.Drawing.Point(225, 49)
        Me.nomeEmpresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.nomeEmpresa.Name = "nomeEmpresa"
        Me.nomeEmpresa.Size = New System.Drawing.Size(640, 28)
        Me.nomeEmpresa.TabIndex = 15
        '
        'companyAddress_lbl
        '
        Me.companyAddress_lbl.AutoSize = True
        Me.companyAddress_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyAddress_lbl.Location = New System.Drawing.Point(220, 88)
        Me.companyAddress_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyAddress_lbl.Name = "companyAddress_lbl"
        Me.companyAddress_lbl.Size = New System.Drawing.Size(82, 20)
        Me.companyAddress_lbl.TabIndex = 221
        Me.companyAddress_lbl.Text = "Morada*"
        '
        'moradaEmpresa
        '
        Me.moradaEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.moradaEmpresa.Location = New System.Drawing.Point(225, 114)
        Me.moradaEmpresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.moradaEmpresa.Multiline = True
        Me.moradaEmpresa.Name = "moradaEmpresa"
        Me.moradaEmpresa.Size = New System.Drawing.Size(640, 121)
        Me.moradaEmpresa.TabIndex = 16
        '
        'companyTva_lbl
        '
        Me.companyTva_lbl.AutoSize = True
        Me.companyTva_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyTva_lbl.Location = New System.Drawing.Point(902, 23)
        Me.companyTva_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyTva_lbl.Name = "companyTva_lbl"
        Me.companyTva_lbl.Size = New System.Drawing.Size(68, 20)
        Me.companyTva_lbl.TabIndex = 223
        Me.companyTva_lbl.Text = "T.V.A.*"
        '
        'tvaEmpresa
        '
        Me.tvaEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvaEmpresa.Location = New System.Drawing.Point(906, 49)
        Me.tvaEmpresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tvaEmpresa.Name = "tvaEmpresa"
        Me.tvaEmpresa.Size = New System.Drawing.Size(187, 28)
        Me.tvaEmpresa.TabIndex = 17
        '
        'companyEmail_lbl
        '
        Me.companyEmail_lbl.AutoSize = True
        Me.companyEmail_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyEmail_lbl.Location = New System.Drawing.Point(903, 88)
        Me.companyEmail_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyEmail_lbl.Name = "companyEmail_lbl"
        Me.companyEmail_lbl.Size = New System.Drawing.Size(68, 20)
        Me.companyEmail_lbl.TabIndex = 225
        Me.companyEmail_lbl.Text = "Email*"
        '
        'emailEmpresa
        '
        Me.emailEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailEmpresa.Location = New System.Drawing.Point(908, 114)
        Me.emailEmpresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.emailEmpresa.Name = "emailEmpresa"
        Me.emailEmpresa.Size = New System.Drawing.Size(420, 28)
        Me.emailEmpresa.TabIndex = 19
        '
        'companyPhone_lbl
        '
        Me.companyPhone_lbl.AutoSize = True
        Me.companyPhone_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyPhone_lbl.Location = New System.Drawing.Point(1136, 23)
        Me.companyPhone_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyPhone_lbl.Name = "companyPhone_lbl"
        Me.companyPhone_lbl.Size = New System.Drawing.Size(90, 20)
        Me.companyPhone_lbl.TabIndex = 227
        Me.companyPhone_lbl.Text = "Telefone*"
        '
        'telefoneEmpresa
        '
        Me.telefoneEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefoneEmpresa.Location = New System.Drawing.Point(1140, 49)
        Me.telefoneEmpresa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.telefoneEmpresa.Name = "telefoneEmpresa"
        Me.telefoneEmpresa.Size = New System.Drawing.Size(187, 28)
        Me.telefoneEmpresa.TabIndex = 18
        '
        'GroupBoxSections
        '
        Me.GroupBoxSections.Controls.Add(Me.sectionRadius)
        Me.GroupBoxSections.Controls.Add(Me.sectionRadius_lbl)
        Me.GroupBoxSections.Controls.Add(Me.sectionGpsCoordinates_lbl)
        Me.GroupBoxSections.Controls.Add(Me.sectionLatitude_lbl)
        Me.GroupBoxSections.Controls.Add(Me.sectionLongitude_lbl)
        Me.GroupBoxSections.Controls.Add(Me.sectionLatitude)
        Me.GroupBoxSections.Controls.Add(Me.sectionLongitude)
        Me.GroupBoxSections.Controls.Add(Me.sectiondistance_lbl)
        Me.GroupBoxSections.Controls.Add(Me.sectionDistance)
        Me.GroupBoxSections.Controls.Add(Me.delSectionBtn)
        Me.GroupBoxSections.Controls.Add(Me.saveSectionBtn)
        Me.GroupBoxSections.Controls.Add(Me.sectionDescription_lbl)
        Me.GroupBoxSections.Controls.Add(Me.descriptionSection)
        Me.GroupBoxSections.Controls.Add(Me.atribuirSection)
        Me.GroupBoxSections.Location = New System.Drawing.Point(587, 896)
        Me.GroupBoxSections.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSections.Name = "GroupBoxSections"
        Me.GroupBoxSections.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSections.Size = New System.Drawing.Size(1342, 171)
        Me.GroupBoxSections.TabIndex = 288
        Me.GroupBoxSections.TabStop = False
        '
        'delSectionBtn
        '
        Me.delSectionBtn.Image = CType(resources.GetObject("delSectionBtn.Image"), System.Drawing.Image)
        Me.delSectionBtn.Location = New System.Drawing.Point(1202, 104)
        Me.delSectionBtn.Name = "delSectionBtn"
        Me.delSectionBtn.Size = New System.Drawing.Size(50, 50)
        Me.delSectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delSectionBtn.TabIndex = 354
        Me.delSectionBtn.TabStop = False
        '
        'saveSectionBtn
        '
        Me.saveSectionBtn.Image = CType(resources.GetObject("saveSectionBtn.Image"), System.Drawing.Image)
        Me.saveSectionBtn.Location = New System.Drawing.Point(1269, 104)
        Me.saveSectionBtn.Name = "saveSectionBtn"
        Me.saveSectionBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveSectionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveSectionBtn.TabIndex = 352
        Me.saveSectionBtn.TabStop = False
        '
        'sectionDescription_lbl
        '
        Me.sectionDescription_lbl.AutoSize = True
        Me.sectionDescription_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionDescription_lbl.Location = New System.Drawing.Point(20, 26)
        Me.sectionDescription_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionDescription_lbl.Name = "sectionDescription_lbl"
        Me.sectionDescription_lbl.Size = New System.Drawing.Size(118, 20)
        Me.sectionDescription_lbl.TabIndex = 254
        Me.sectionDescription_lbl.Text = "Designacao*"
        '
        'descriptionSection
        '
        Me.descriptionSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionSection.Location = New System.Drawing.Point(24, 52)
        Me.descriptionSection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.descriptionSection.Name = "descriptionSection"
        Me.descriptionSection.Size = New System.Drawing.Size(448, 28)
        Me.descriptionSection.TabIndex = 248
        '
        'GroupBoxContractorManagers
        '
        Me.GroupBoxContractorManagers.Controls.Add(Me.delContractorManagerBtn)
        Me.GroupBoxContractorManagers.Controls.Add(Me.saveContractorManagerBtn)
        Me.GroupBoxContractorManagers.Controls.Add(Me.downloadPhotoContractorManager)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerPhotobox)
        Me.GroupBoxContractorManagers.Controls.Add(Me.saveNewCard)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerName_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerCardCode)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerName)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerCardCode_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerCardId_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerCardId)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerEmail_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.conractorManagerEmail)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerPhone_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerPhone)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerJobAuthority)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerJobAuthority_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerSectionAssigned_lbl)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerSection)
        Me.GroupBoxContractorManagers.Controls.Add(Me.contractorManagerResetSection)
        Me.GroupBoxContractorManagers.Location = New System.Drawing.Point(587, 1571)
        Me.GroupBoxContractorManagers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxContractorManagers.Name = "GroupBoxContractorManagers"
        Me.GroupBoxContractorManagers.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxContractorManagers.Size = New System.Drawing.Size(1341, 344)
        Me.GroupBoxContractorManagers.TabIndex = 287
        Me.GroupBoxContractorManagers.TabStop = False
        '
        'delContractorManagerBtn
        '
        Me.delContractorManagerBtn.Image = CType(resources.GetObject("delContractorManagerBtn.Image"), System.Drawing.Image)
        Me.delContractorManagerBtn.Location = New System.Drawing.Point(1202, 270)
        Me.delContractorManagerBtn.Name = "delContractorManagerBtn"
        Me.delContractorManagerBtn.Size = New System.Drawing.Size(50, 50)
        Me.delContractorManagerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delContractorManagerBtn.TabIndex = 354
        Me.delContractorManagerBtn.TabStop = False
        '
        'saveContractorManagerBtn
        '
        Me.saveContractorManagerBtn.Image = CType(resources.GetObject("saveContractorManagerBtn.Image"), System.Drawing.Image)
        Me.saveContractorManagerBtn.Location = New System.Drawing.Point(1269, 270)
        Me.saveContractorManagerBtn.Name = "saveContractorManagerBtn"
        Me.saveContractorManagerBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveContractorManagerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveContractorManagerBtn.TabIndex = 352
        Me.saveContractorManagerBtn.TabStop = False
        '
        'downloadPhotoContractorManager
        '
        Me.downloadPhotoContractorManager.Image = CType(resources.GetObject("downloadPhotoContractorManager.Image"), System.Drawing.Image)
        Me.downloadPhotoContractorManager.Location = New System.Drawing.Point(21, 238)
        Me.downloadPhotoContractorManager.Name = "downloadPhotoContractorManager"
        Me.downloadPhotoContractorManager.Size = New System.Drawing.Size(50, 50)
        Me.downloadPhotoContractorManager.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.downloadPhotoContractorManager.TabIndex = 351
        Me.downloadPhotoContractorManager.TabStop = False
        '
        'saveNewCard
        '
        Me.saveNewCard.AutoSize = True
        Me.saveNewCard.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveNewCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.saveNewCard.Location = New System.Drawing.Point(922, 238)
        Me.saveNewCard.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveNewCard.Name = "saveNewCard"
        Me.saveNewCard.Size = New System.Drawing.Size(132, 20)
        Me.saveNewCard.TabIndex = 286
        Me.saveNewCard.TabStop = True
        Me.saveNewCard.Text = "save new card"
        '
        'contractorManagerName_lbl
        '
        Me.contractorManagerName_lbl.AutoSize = True
        Me.contractorManagerName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerName_lbl.Location = New System.Drawing.Point(222, 37)
        Me.contractorManagerName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerName_lbl.Name = "contractorManagerName_lbl"
        Me.contractorManagerName_lbl.Size = New System.Drawing.Size(70, 20)
        Me.contractorManagerName_lbl.TabIndex = 233
        Me.contractorManagerName_lbl.Text = "Nome*"
        '
        'contractorManagerCardCode
        '
        Me.contractorManagerCardCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerCardCode.Location = New System.Drawing.Point(927, 203)
        Me.contractorManagerCardCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerCardCode.Name = "contractorManagerCardCode"
        Me.contractorManagerCardCode.Size = New System.Drawing.Size(367, 28)
        Me.contractorManagerCardCode.TabIndex = 284
        '
        'contractorManagerName
        '
        Me.contractorManagerName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerName.Location = New System.Drawing.Point(226, 63)
        Me.contractorManagerName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerName.Name = "contractorManagerName"
        Me.contractorManagerName.Size = New System.Drawing.Size(641, 28)
        Me.contractorManagerName.TabIndex = 23
        '
        'contractorManagerCardCode_lbl
        '
        Me.contractorManagerCardCode_lbl.AutoSize = True
        Me.contractorManagerCardCode_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerCardCode_lbl.Location = New System.Drawing.Point(922, 177)
        Me.contractorManagerCardCode_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerCardCode_lbl.Name = "contractorManagerCardCode_lbl"
        Me.contractorManagerCardCode_lbl.Size = New System.Drawing.Size(138, 20)
        Me.contractorManagerCardCode_lbl.TabIndex = 285
        Me.contractorManagerCardCode_lbl.Text = "Código cartão*"
        '
        'contractorManagerCardId_lbl
        '
        Me.contractorManagerCardId_lbl.AutoSize = True
        Me.contractorManagerCardId_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerCardId_lbl.Location = New System.Drawing.Point(923, 100)
        Me.contractorManagerCardId_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerCardId_lbl.Name = "contractorManagerCardId_lbl"
        Me.contractorManagerCardId_lbl.Size = New System.Drawing.Size(100, 20)
        Me.contractorManagerCardId_lbl.TabIndex = 235
        Me.contractorManagerCardId_lbl.Text = "ID cartão*"
        '
        'contractorManagerCardId
        '
        Me.contractorManagerCardId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerCardId.Location = New System.Drawing.Point(928, 126)
        Me.contractorManagerCardId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerCardId.Name = "contractorManagerCardId"
        Me.contractorManagerCardId.Size = New System.Drawing.Size(366, 28)
        Me.contractorManagerCardId.TabIndex = 26
        '
        'contractorManagerEmail_lbl
        '
        Me.contractorManagerEmail_lbl.AutoSize = True
        Me.contractorManagerEmail_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerEmail_lbl.Location = New System.Drawing.Point(225, 100)
        Me.contractorManagerEmail_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerEmail_lbl.Name = "contractorManagerEmail_lbl"
        Me.contractorManagerEmail_lbl.Size = New System.Drawing.Size(68, 20)
        Me.contractorManagerEmail_lbl.TabIndex = 237
        Me.contractorManagerEmail_lbl.Text = "Email*"
        '
        'conractorManagerEmail
        '
        Me.conractorManagerEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conractorManagerEmail.Location = New System.Drawing.Point(230, 126)
        Me.conractorManagerEmail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.conractorManagerEmail.Name = "conractorManagerEmail"
        Me.conractorManagerEmail.Size = New System.Drawing.Size(637, 28)
        Me.conractorManagerEmail.TabIndex = 24
        '
        'contractorManagerPhone_lbl
        '
        Me.contractorManagerPhone_lbl.AutoSize = True
        Me.contractorManagerPhone_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerPhone_lbl.Location = New System.Drawing.Point(922, 37)
        Me.contractorManagerPhone_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerPhone_lbl.Name = "contractorManagerPhone_lbl"
        Me.contractorManagerPhone_lbl.Size = New System.Drawing.Size(90, 20)
        Me.contractorManagerPhone_lbl.TabIndex = 239
        Me.contractorManagerPhone_lbl.Text = "Telefone*"
        '
        'contractorManagerPhone
        '
        Me.contractorManagerPhone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerPhone.Location = New System.Drawing.Point(927, 62)
        Me.contractorManagerPhone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerPhone.Name = "contractorManagerPhone"
        Me.contractorManagerPhone.Size = New System.Drawing.Size(367, 28)
        Me.contractorManagerPhone.TabIndex = 27
        '
        'contractorManagerJobAuthority
        '
        Me.contractorManagerJobAuthority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.contractorManagerJobAuthority.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerJobAuthority.FormattingEnabled = True
        Me.contractorManagerJobAuthority.Items.AddRange(New Object() {"Escolha uma", "Human Resources", "Engineer on site", "Safety and Training", "Project Engineer", "Materials Manager"})
        Me.contractorManagerJobAuthority.Location = New System.Drawing.Point(230, 202)
        Me.contractorManagerJobAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contractorManagerJobAuthority.Name = "contractorManagerJobAuthority"
        Me.contractorManagerJobAuthority.Size = New System.Drawing.Size(463, 28)
        Me.contractorManagerJobAuthority.TabIndex = 25
        '
        'contractorManagerJobAuthority_lbl
        '
        Me.contractorManagerJobAuthority_lbl.AutoSize = True
        Me.contractorManagerJobAuthority_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagerJobAuthority_lbl.Location = New System.Drawing.Point(225, 177)
        Me.contractorManagerJobAuthority_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagerJobAuthority_lbl.Name = "contractorManagerJobAuthority_lbl"
        Me.contractorManagerJobAuthority_lbl.Size = New System.Drawing.Size(81, 20)
        Me.contractorManagerJobAuthority_lbl.TabIndex = 247
        Me.contractorManagerJobAuthority_lbl.Text = "Função*"
        '
        'loading_status_sections
        '
        Me.loading_status_sections.AutoSize = True
        Me.loading_status_sections.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_sections.ForeColor = System.Drawing.Color.Red
        Me.loading_status_sections.Location = New System.Drawing.Point(213, 899)
        Me.loading_status_sections.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_sections.Name = "loading_status_sections"
        Me.loading_status_sections.Size = New System.Drawing.Size(97, 20)
        Me.loading_status_sections.TabIndex = 278
        Me.loading_status_sections.Text = "aguarde..."
        '
        'sectionTitle
        '
        Me.sectionTitle.AutoSize = True
        Me.sectionTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionTitle.Location = New System.Drawing.Point(15, 896)
        Me.sectionTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionTitle.Name = "sectionTitle"
        Me.sectionTitle.Size = New System.Drawing.Size(197, 25)
        Me.sectionTitle.TabIndex = 268
        Me.sectionTitle.Text = "Secções de Obra"
        '
        'sectionsList
        '
        Me.sectionsList.BackColor = System.Drawing.Color.Cornsilk
        Me.sectionsList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionsList.FormattingEnabled = True
        Me.sectionsList.HorizontalScrollbar = True
        Me.sectionsList.ItemHeight = 20
        Me.sectionsList.Location = New System.Drawing.Point(15, 926)
        Me.sectionsList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sectionsList.Name = "sectionsList"
        Me.sectionsList.Size = New System.Drawing.Size(528, 144)
        Me.sectionsList.TabIndex = 267
        '
        'divider2
        '
        Me.divider2.BackColor = System.Drawing.Color.LimeGreen
        Me.divider2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider2.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider2.Location = New System.Drawing.Point(587, 884)
        Me.divider2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider2.Name = "divider2"
        Me.divider2.Size = New System.Drawing.Size(1340, 5)
        Me.divider2.TabIndex = 264
        '
        'divider3
        '
        Me.divider3.BackColor = System.Drawing.Color.LimeGreen
        Me.divider3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider3.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider3.Location = New System.Drawing.Point(587, 1560)
        Me.divider3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider3.Name = "divider3"
        Me.divider3.Size = New System.Drawing.Size(1340, 5)
        Me.divider3.TabIndex = 262
        '
        'divider4
        '
        Me.divider4.BackColor = System.Drawing.Color.LimeGreen
        Me.divider4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider4.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider4.Location = New System.Drawing.Point(584, 1962)
        Me.divider4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider4.Name = "divider4"
        Me.divider4.Size = New System.Drawing.Size(1340, 5)
        Me.divider4.TabIndex = 261
        '
        'contractorManagersTitle
        '
        Me.contractorManagersTitle.AutoSize = True
        Me.contractorManagersTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagersTitle.Location = New System.Drawing.Point(13, 1571)
        Me.contractorManagersTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagersTitle.Name = "contractorManagersTitle"
        Me.contractorManagersTitle.Size = New System.Drawing.Size(165, 25)
        Me.contractorManagersTitle.TabIndex = 258
        Me.contractorManagersTitle.Text = "Responsáveis"
        '
        'companyTitle
        '
        Me.companyTitle.AutoSize = True
        Me.companyTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyTitle.Location = New System.Drawing.Point(10, 1967)
        Me.companyTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyTitle.Name = "companyTitle"
        Me.companyTitle.Size = New System.Drawing.Size(121, 25)
        Me.companyTitle.TabIndex = 257
        Me.companyTitle.Text = "Empresas"
        '
        'EmpresaList
        '
        Me.EmpresaList.BackColor = System.Drawing.Color.Cornsilk
        Me.EmpresaList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpresaList.FormattingEnabled = True
        Me.EmpresaList.HorizontalScrollbar = True
        Me.EmpresaList.ItemHeight = 20
        Me.EmpresaList.Location = New System.Drawing.Point(15, 1996)
        Me.EmpresaList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.EmpresaList.Name = "EmpresaList"
        Me.EmpresaList.Size = New System.Drawing.Size(528, 284)
        Me.EmpresaList.TabIndex = 256
        '
        'sectionsFileTitle
        '
        Me.sectionsFileTitle.AutoSize = True
        Me.sectionsFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionsFileTitle.Location = New System.Drawing.Point(581, 853)
        Me.sectionsFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionsFileTitle.Name = "sectionsFileTitle"
        Me.sectionsFileTitle.Size = New System.Drawing.Size(120, 29)
        Me.sectionsFileTitle.TabIndex = 252
        Me.sectionsFileTitle.Text = "Secções"
        '
        'contratorManagerList
        '
        Me.contratorManagerList.BackColor = System.Drawing.Color.Cornsilk
        Me.contratorManagerList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contratorManagerList.FormattingEnabled = True
        Me.contratorManagerList.HorizontalScrollbar = True
        Me.contratorManagerList.ItemHeight = 20
        Me.contratorManagerList.Location = New System.Drawing.Point(13, 1600)
        Me.contratorManagerList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.contratorManagerList.Name = "contratorManagerList"
        Me.contratorManagerList.Size = New System.Drawing.Size(528, 304)
        Me.contratorManagerList.TabIndex = 22
        '
        'contractorManagersFileTitle
        '
        Me.contractorManagersFileTitle.AutoSize = True
        Me.contractorManagersFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contractorManagersFileTitle.Location = New System.Drawing.Point(581, 1529)
        Me.contractorManagersFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.contractorManagersFileTitle.Name = "contractorManagersFileTitle"
        Me.contractorManagersFileTitle.Size = New System.Drawing.Size(541, 29)
        Me.contractorManagersFileTitle.TabIndex = 203
        Me.contractorManagersFileTitle.Text = "Work authorities at Contrator Company"
        '
        'companyFileTitle
        '
        Me.companyFileTitle.AutoSize = True
        Me.companyFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyFileTitle.Location = New System.Drawing.Point(581, 1931)
        Me.companyFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyFileTitle.Name = "companyFileTitle"
        Me.companyFileTitle.Size = New System.Drawing.Size(294, 29)
        Me.companyFileTitle.TabIndex = 201
        Me.companyFileTitle.Text = "Empresa contratante"
        '
        'mandatoryFields
        '
        Me.mandatoryFields.AutoSize = True
        Me.mandatoryFields.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatoryFields.Location = New System.Drawing.Point(1557, 60)
        Me.mandatoryFields.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.mandatoryFields.Name = "mandatoryFields"
        Me.mandatoryFields.Size = New System.Drawing.Size(369, 20)
        Me.mandatoryFields.TabIndex = 200
        Me.mandatoryFields.Text = "Campos marcados com * são obrigatórios"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(590, 42)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1340, 5)
        Me.divider.TabIndex = 199
        '
        'siteFileTitle
        '
        Me.siteFileTitle.AutoSize = True
        Me.siteFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteFileTitle.Location = New System.Drawing.Point(586, 11)
        Me.siteFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteFileTitle.Name = "siteFileTitle"
        Me.siteFileTitle.Size = New System.Drawing.Size(198, 29)
        Me.siteFileTitle.TabIndex = 198
        Me.siteFileTitle.Text = "Ficha de Obra"
        '
        'siteTitle
        '
        Me.siteTitle.AutoSize = True
        Me.siteTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteTitle.Location = New System.Drawing.Point(15, 6)
        Me.siteTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteTitle.Name = "siteTitle"
        Me.siteTitle.Size = New System.Drawing.Size(78, 25)
        Me.siteTitle.TabIndex = 194
        Me.siteTitle.Text = "Obras"
        '
        'ObrasList
        '
        Me.ObrasList.BackColor = System.Drawing.Color.Cornsilk
        Me.ObrasList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObrasList.FormattingEnabled = True
        Me.ObrasList.HorizontalScrollbar = True
        Me.ObrasList.ItemHeight = 20
        Me.ObrasList.Location = New System.Drawing.Point(15, 77)
        Me.ObrasList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ObrasList.Name = "ObrasList"
        Me.ObrasList.Size = New System.Drawing.Size(528, 704)
        Me.ObrasList.TabIndex = 3
        '
        'GroupBoxManagers
        '
        Me.GroupBoxManagers.Controls.Add(Me.PictureBox1)
        Me.GroupBoxManagers.Controls.Add(Me.PictureBox2)
        Me.GroupBoxManagers.Controls.Add(Me.downloadPhotoManagerBtn)
        Me.GroupBoxManagers.Controls.Add(Me.managerPhotobox)
        Me.GroupBoxManagers.Controls.Add(Me.managerName_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerName)
        Me.GroupBoxManagers.Controls.Add(Me.managerCardId_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerCardId)
        Me.GroupBoxManagers.Controls.Add(Me.managerEmail_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerEmail)
        Me.GroupBoxManagers.Controls.Add(Me.managerPhone_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerPhone)
        Me.GroupBoxManagers.Controls.Add(Me.managerJobAuthority)
        Me.GroupBoxManagers.Controls.Add(Me.managerJobAuthority_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerAssignedSection)
        Me.GroupBoxManagers.Controls.Add(Me.TextBox6)
        Me.GroupBoxManagers.Controls.Add(Me.managerSectionReset)
        Me.GroupBoxManagers.Location = New System.Drawing.Point(586, 1119)
        Me.GroupBoxManagers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxManagers.Name = "GroupBoxManagers"
        Me.GroupBoxManagers.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxManagers.Size = New System.Drawing.Size(1341, 342)
        Me.GroupBoxManagers.TabIndex = 359
        Me.GroupBoxManagers.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1203, 262)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 354
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1270, 262)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 352
        Me.PictureBox2.TabStop = False
        '
        'downloadPhotoManagerBtn
        '
        Me.downloadPhotoManagerBtn.Image = CType(resources.GetObject("downloadPhotoManagerBtn.Image"), System.Drawing.Image)
        Me.downloadPhotoManagerBtn.Location = New System.Drawing.Point(21, 238)
        Me.downloadPhotoManagerBtn.Name = "downloadPhotoManagerBtn"
        Me.downloadPhotoManagerBtn.Size = New System.Drawing.Size(50, 50)
        Me.downloadPhotoManagerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.downloadPhotoManagerBtn.TabIndex = 351
        Me.downloadPhotoManagerBtn.TabStop = False
        '
        'managerPhotobox
        '
        Me.managerPhotobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.managerPhotobox.Image = CType(resources.GetObject("managerPhotobox.Image"), System.Drawing.Image)
        Me.managerPhotobox.Location = New System.Drawing.Point(21, 48)
        Me.managerPhotobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerPhotobox.Name = "managerPhotobox"
        Me.managerPhotobox.Size = New System.Drawing.Size(179, 187)
        Me.managerPhotobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.managerPhotobox.TabIndex = 273
        Me.managerPhotobox.TabStop = False
        '
        'managerName_lbl
        '
        Me.managerName_lbl.AutoSize = True
        Me.managerName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerName_lbl.Location = New System.Drawing.Point(222, 37)
        Me.managerName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerName_lbl.Name = "managerName_lbl"
        Me.managerName_lbl.Size = New System.Drawing.Size(70, 20)
        Me.managerName_lbl.TabIndex = 233
        Me.managerName_lbl.Text = "Nome*"
        '
        'managerName
        '
        Me.managerName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerName.Location = New System.Drawing.Point(226, 63)
        Me.managerName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerName.Name = "managerName"
        Me.managerName.Size = New System.Drawing.Size(1068, 28)
        Me.managerName.TabIndex = 23
        '
        'managerCardId_lbl
        '
        Me.managerCardId_lbl.AutoSize = True
        Me.managerCardId_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerCardId_lbl.Location = New System.Drawing.Point(922, 167)
        Me.managerCardId_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerCardId_lbl.Name = "managerCardId_lbl"
        Me.managerCardId_lbl.Size = New System.Drawing.Size(100, 20)
        Me.managerCardId_lbl.TabIndex = 235
        Me.managerCardId_lbl.Text = "ID cartão*"
        '
        'managerCardId
        '
        Me.managerCardId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerCardId.Location = New System.Drawing.Point(927, 192)
        Me.managerCardId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerCardId.Name = "managerCardId"
        Me.managerCardId.Size = New System.Drawing.Size(366, 28)
        Me.managerCardId.TabIndex = 26
        '
        'managerEmail_lbl
        '
        Me.managerEmail_lbl.AutoSize = True
        Me.managerEmail_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerEmail_lbl.Location = New System.Drawing.Point(225, 100)
        Me.managerEmail_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerEmail_lbl.Name = "managerEmail_lbl"
        Me.managerEmail_lbl.Size = New System.Drawing.Size(68, 20)
        Me.managerEmail_lbl.TabIndex = 237
        Me.managerEmail_lbl.Text = "Email*"
        '
        'managerEmail
        '
        Me.managerEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerEmail.Location = New System.Drawing.Point(230, 126)
        Me.managerEmail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerEmail.Name = "managerEmail"
        Me.managerEmail.Size = New System.Drawing.Size(637, 28)
        Me.managerEmail.TabIndex = 24
        '
        'managerPhone_lbl
        '
        Me.managerPhone_lbl.AutoSize = True
        Me.managerPhone_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerPhone_lbl.Location = New System.Drawing.Point(922, 100)
        Me.managerPhone_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerPhone_lbl.Name = "managerPhone_lbl"
        Me.managerPhone_lbl.Size = New System.Drawing.Size(90, 20)
        Me.managerPhone_lbl.TabIndex = 239
        Me.managerPhone_lbl.Text = "Telefone*"
        '
        'managerPhone
        '
        Me.managerPhone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerPhone.Location = New System.Drawing.Point(927, 125)
        Me.managerPhone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerPhone.Name = "managerPhone"
        Me.managerPhone.Size = New System.Drawing.Size(367, 28)
        Me.managerPhone.TabIndex = 27
        '
        'managerJobAuthority
        '
        Me.managerJobAuthority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.managerJobAuthority.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerJobAuthority.FormattingEnabled = True
        Me.managerJobAuthority.Items.AddRange(New Object() {"Escolha uma", "Human Resources", "Engineer on site", "Safety and Training", "Project Engineer", "Materials Manager"})
        Me.managerJobAuthority.Location = New System.Drawing.Point(229, 192)
        Me.managerJobAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerJobAuthority.Name = "managerJobAuthority"
        Me.managerJobAuthority.Size = New System.Drawing.Size(456, 28)
        Me.managerJobAuthority.TabIndex = 25
        '
        'managerJobAuthority_lbl
        '
        Me.managerJobAuthority_lbl.AutoSize = True
        Me.managerJobAuthority_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerJobAuthority_lbl.Location = New System.Drawing.Point(225, 167)
        Me.managerJobAuthority_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerJobAuthority_lbl.Name = "managerJobAuthority_lbl"
        Me.managerJobAuthority_lbl.Size = New System.Drawing.Size(81, 20)
        Me.managerJobAuthority_lbl.TabIndex = 247
        Me.managerJobAuthority_lbl.Text = "Função*"
        '
        'managerAssignedSection
        '
        Me.managerAssignedSection.AutoSize = True
        Me.managerAssignedSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerAssignedSection.Location = New System.Drawing.Point(228, 234)
        Me.managerAssignedSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerAssignedSection.Name = "managerAssignedSection"
        Me.managerAssignedSection.Size = New System.Drawing.Size(152, 20)
        Me.managerAssignedSection.TabIndex = 270
        Me.managerAssignedSection.Text = "Secção atribuida"
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(229, 259)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(637, 28)
        Me.TextBox6.TabIndex = 269
        '
        'managerSectionReset
        '
        Me.managerSectionReset.AutoSize = True
        Me.managerSectionReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerSectionReset.Location = New System.Drawing.Point(229, 292)
        Me.managerSectionReset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerSectionReset.Name = "managerSectionReset"
        Me.managerSectionReset.Size = New System.Drawing.Size(57, 20)
        Me.managerSectionReset.TabIndex = 271
        Me.managerSectionReset.TabStop = True
        Me.managerSectionReset.Text = "Reset"
        '
        'loadingStatusManager
        '
        Me.loadingStatusManager.AutoSize = True
        Me.loadingStatusManager.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadingStatusManager.ForeColor = System.Drawing.Color.Red
        Me.loadingStatusManager.Location = New System.Drawing.Point(188, 1142)
        Me.loadingStatusManager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loadingStatusManager.Name = "loadingStatusManager"
        Me.loadingStatusManager.Size = New System.Drawing.Size(97, 20)
        Me.loadingStatusManager.TabIndex = 358
        Me.loadingStatusManager.Text = "aguarde..."
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LimeGreen
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label10.Location = New System.Drawing.Point(586, 1109)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1340, 5)
        Me.Label10.TabIndex = 356
        '
        'managerTitle
        '
        Me.managerTitle.AutoSize = True
        Me.managerTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerTitle.Location = New System.Drawing.Point(15, 1139)
        Me.managerTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerTitle.Name = "managerTitle"
        Me.managerTitle.Size = New System.Drawing.Size(166, 25)
        Me.managerTitle.TabIndex = 355
        Me.managerTitle.Text = "Gestionnaires"
        '
        'managerList
        '
        Me.managerList.BackColor = System.Drawing.Color.Cornsilk
        Me.managerList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerList.FormattingEnabled = True
        Me.managerList.HorizontalScrollbar = True
        Me.managerList.ItemHeight = 20
        Me.managerList.Location = New System.Drawing.Point(15, 1168)
        Me.managerList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.managerList.Name = "managerList"
        Me.managerList.Size = New System.Drawing.Size(528, 284)
        Me.managerList.TabIndex = 353
        '
        'managerFileTitle
        '
        Me.managerFileTitle.AutoSize = True
        Me.managerFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerFileTitle.Location = New System.Drawing.Point(582, 1079)
        Me.managerFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerFileTitle.Name = "managerFileTitle"
        Me.managerFileTitle.Size = New System.Drawing.Size(348, 29)
        Me.managerFileTitle.TabIndex = 354
        Me.managerFileTitle.Text = "Open authorities at work"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label1.Location = New System.Drawing.Point(10, 1488)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1916, 16)
        Me.Label1.TabIndex = 360
        '
        'sectionRadius
        '
        Me.sectionRadius.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionRadius.Location = New System.Drawing.Point(1068, 91)
        Me.sectionRadius.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sectionRadius.Name = "sectionRadius"
        Me.sectionRadius.Size = New System.Drawing.Size(90, 28)
        Me.sectionRadius.TabIndex = 362
        Me.sectionRadius.Text = "5"
        '
        'sectionRadius_lbl
        '
        Me.sectionRadius_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sectionRadius_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionRadius_lbl.Location = New System.Drawing.Point(832, 95)
        Me.sectionRadius_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionRadius_lbl.Name = "sectionRadius_lbl"
        Me.sectionRadius_lbl.Size = New System.Drawing.Size(228, 20)
        Me.sectionRadius_lbl.TabIndex = 363
        Me.sectionRadius_lbl.Text = "Raio de autorização* (m)"
        Me.sectionRadius_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sectionGpsCoordinates_lbl
        '
        Me.sectionGpsCoordinates_lbl.AutoSize = True
        Me.sectionGpsCoordinates_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionGpsCoordinates_lbl.Location = New System.Drawing.Point(513, 26)
        Me.sectionGpsCoordinates_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionGpsCoordinates_lbl.Name = "sectionGpsCoordinates_lbl"
        Me.sectionGpsCoordinates_lbl.Size = New System.Drawing.Size(172, 20)
        Me.sectionGpsCoordinates_lbl.TabIndex = 358
        Me.sectionGpsCoordinates_lbl.Text = "Coordenadas GPS*"
        '
        'sectionLatitude_lbl
        '
        Me.sectionLatitude_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sectionLatitude_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionLatitude_lbl.Location = New System.Drawing.Point(504, 53)
        Me.sectionLatitude_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionLatitude_lbl.Name = "sectionLatitude_lbl"
        Me.sectionLatitude_lbl.Size = New System.Drawing.Size(122, 28)
        Me.sectionLatitude_lbl.TabIndex = 359
        Me.sectionLatitude_lbl.Text = "Latitude"
        Me.sectionLatitude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sectionLongitude_lbl
        '
        Me.sectionLongitude_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sectionLongitude_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionLongitude_lbl.Location = New System.Drawing.Point(504, 99)
        Me.sectionLongitude_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionLongitude_lbl.Name = "sectionLongitude_lbl"
        Me.sectionLongitude_lbl.Size = New System.Drawing.Size(117, 20)
        Me.sectionLongitude_lbl.TabIndex = 360
        Me.sectionLongitude_lbl.Text = "Longitude"
        Me.sectionLongitude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sectionLatitude
        '
        Me.sectionLatitude.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionLatitude.Location = New System.Drawing.Point(630, 51)
        Me.sectionLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sectionLatitude.Name = "sectionLatitude"
        Me.sectionLatitude.Size = New System.Drawing.Size(187, 28)
        Me.sectionLatitude.TabIndex = 355
        '
        'sectionLongitude
        '
        Me.sectionLongitude.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionLongitude.Location = New System.Drawing.Point(630, 94)
        Me.sectionLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sectionLongitude.Name = "sectionLongitude"
        Me.sectionLongitude.Size = New System.Drawing.Size(187, 28)
        Me.sectionLongitude.TabIndex = 356
        '
        'sectiondistance_lbl
        '
        Me.sectiondistance_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sectiondistance_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectiondistance_lbl.Location = New System.Drawing.Point(832, 56)
        Me.sectiondistance_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectiondistance_lbl.Name = "sectiondistance_lbl"
        Me.sectiondistance_lbl.Size = New System.Drawing.Size(224, 20)
        Me.sectiondistance_lbl.TabIndex = 361
        Me.sectiondistance_lbl.Text = "Distância* (Km)"
        Me.sectiondistance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sectionDistance
        '
        Me.sectionDistance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionDistance.Location = New System.Drawing.Point(1068, 51)
        Me.sectionDistance.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sectionDistance.Name = "sectionDistance"
        Me.sectionDistance.Size = New System.Drawing.Size(90, 28)
        Me.sectionDistance.TabIndex = 357
        '
        'saveEmpresaBtn
        '
        Me.saveEmpresaBtn.Image = CType(resources.GetObject("saveEmpresaBtn.Image"), System.Drawing.Image)
        Me.saveEmpresaBtn.Location = New System.Drawing.Point(1266, 242)
        Me.saveEmpresaBtn.Name = "saveEmpresaBtn"
        Me.saveEmpresaBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveEmpresaBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveEmpresaBtn.TabIndex = 352
        Me.saveEmpresaBtn.TabStop = False
        '
        'site_mng_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(2234, 1314)
        Me.Controls.Add(Me.Panel_geral)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "site_mng_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestão de Obras"
        CType(Me.CompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contractorManagerPhotobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_geral.ResumeLayout(False)
        Me.Panel_geral.PerformLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxHourly.ResumeLayout(False)
        Me.GroupBoxHourly.PerformLayout()
        CType(Me.delObraBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveObraBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSite.ResumeLayout(False)
        Me.GroupBoxSite.PerformLayout()
        Me.GroupBoxCompany.ResumeLayout(False)
        Me.GroupBoxCompany.PerformLayout()
        CType(Me.delEmpresaBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downloadCompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSections.ResumeLayout(False)
        Me.GroupBoxSections.PerformLayout()
        CType(Me.delSectionBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveSectionBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxContractorManagers.ResumeLayout(False)
        Me.GroupBoxContractorManagers.PerformLayout()
        CType(Me.delContractorManagerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveContractorManagerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downloadPhotoContractorManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxManagers.ResumeLayout(False)
        Me.GroupBoxManagers.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.downloadPhotoManagerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.managerPhotobox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveEmpresaBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents loading_status_company As Label
    Friend WithEvents loading_status_contractor_manager As Label
    Friend WithEvents loading_status As Label
    Friend WithEvents CompanyLogo As PictureBox
    Friend WithEvents contractorManagerPhotobox As PictureBox
    Friend WithEvents atribuirSection As LinkLabel
    Friend WithEvents contractorManagerResetSection As LinkLabel
    Friend WithEvents contractorManagerSection As TextBox
    Friend WithEvents contractorManagerSectionAssigned_lbl As Label
    Friend WithEvents atribuirEmpresa As LinkLabel
    Friend WithEvents Panel_geral As Panel
    Friend WithEvents loading_status_sections As Label
    Friend WithEvents sectionTitle As Label
    Friend WithEvents sectionsList As ListBox
    Friend WithEvents resetEmpresa As LinkLabel
    Friend WithEvents divider2 As Label
    Friend WithEvents divider3 As Label
    Friend WithEvents divider4 As Label
    Friend WithEvents EmpresaAtribuida As TextBox
    Friend WithEvents siteCompanyAssigned_lbl As Label
    Friend WithEvents contractorManagersTitle As Label
    Friend WithEvents companyTitle As Label
    Friend WithEvents EmpresaList As ListBox
    Friend WithEvents descriptionSection As TextBox
    Friend WithEvents sectionDescription_lbl As Label
    Friend WithEvents sectionsFileTitle As Label
    Friend WithEvents contractorManagerJobAuthority_lbl As Label
    Friend WithEvents contractorManagerJobAuthority As ComboBox
    Friend WithEvents duracaoInicio As DateTimePicker
    Friend WithEvents duracaoFim As DateTimePicker
    Friend WithEvents contractorManagerPhone As TextBox
    Friend WithEvents contractorManagerPhone_lbl As Label
    Friend WithEvents conractorManagerEmail As TextBox
    Friend WithEvents contractorManagerEmail_lbl As Label
    Friend WithEvents contractorManagerCardId As TextBox
    Friend WithEvents contractorManagerCardId_lbl As Label
    Friend WithEvents contractorManagerName As TextBox
    Friend WithEvents contractorManagerName_lbl As Label
    Friend WithEvents telefoneEmpresa As TextBox
    Friend WithEvents companyPhone_lbl As Label
    Friend WithEvents emailEmpresa As TextBox
    Friend WithEvents companyEmail_lbl As Label
    Friend WithEvents tvaEmpresa As TextBox
    Friend WithEvents companyTva_lbl As Label
    Friend WithEvents moradaEmpresa As TextBox
    Friend WithEvents companyAddress_lbl As Label
    Friend WithEvents nomeEmpresa As TextBox
    Friend WithEvents companyName_lbl As Label
    Friend WithEvents refcontrato As TextBox
    Friend WithEvents siteRefContract_lbl As Label
    Friend WithEvents siteEnd_lbl As Label
    Friend WithEvents siteStart_lbl As Label
    Friend WithEvents siteDuration_lbl As Label
    Friend WithEvents contractorManagersFileTitle As Label
    Friend WithEvents companyFileTitle As Label
    Friend WithEvents mandatoryFields As Label
    Friend WithEvents divider As Label
    Friend WithEvents siteFileTitle As Label
    Friend WithEvents siteTitle As Label
    Friend WithEvents ObrasList As ListBox
    Friend WithEvents siglaObra As TextBox
    Friend WithEvents siteInitials_lbl As Label
    Friend WithEvents moradaObra As TextBox
    Friend WithEvents siteAddress_lbl As Label
    Friend WithEvents nomeObra As TextBox
    Friend WithEvents siteName_lbl As Label
    Friend WithEvents site_ended As CheckBox
    Friend WithEvents saveNewCard As LinkLabel
    Friend WithEvents contractorManagerCardCode As TextBox
    Friend WithEvents contractorManagerCardCode_lbl As Label
    Public WithEvents contratorManagerList As ListBox
    Friend WithEvents GroupBoxSite As GroupBox
    Friend WithEvents GroupBoxCompany As GroupBox
    Friend WithEvents GroupBoxSections As GroupBox
    Friend WithEvents GroupBoxContractorManagers As GroupBox
    Friend WithEvents GroupBoxHourly As GroupBox
    Friend WithEvents cranemanHourly_lbl As Label
    Friend WithEvents machinistHourly_lbl As Label
    Friend WithEvents regieHourly_lbl As Label
    Friend WithEvents cranemanHourly As TextBox
    Friend WithEvents machinistHourly As TextBox
    Friend WithEvents regieHourly As TextBox
    Friend WithEvents unitshourly3 As Label
    Friend WithEvents unitshourly2 As Label
    Friend WithEvents unitshourly1 As Label
    Friend WithEvents languagesProject_lbl As Label
    Friend WithEvents show_all_lang As CheckBox
    Friend WithEvents languagesList As ListBox
    Friend WithEvents normal_time_lbl As Label
    Friend WithEvents after_hours_time_lbl As Label
    Friend WithEvents unitshourly9 As Label
    Friend WithEvents unitshourly8 As Label
    Friend WithEvents unitshourly7 As Label
    Friend WithEvents craneman_after_hours As TextBox
    Friend WithEvents machinist_after_hours As TextBox
    Friend WithEvents regie_after_hours As TextBox
    Friend WithEvents weekends_time_lbl As Label
    Friend WithEvents unitshourly6 As Label
    Friend WithEvents unitshourly5 As Label
    Friend WithEvents unitshourly4 As Label
    Friend WithEvents craneman_weekends As TextBox
    Friend WithEvents machinist_weekends As TextBox
    Friend WithEvents regie_weekends As TextBox
    Friend WithEvents show_default_lang As CheckBox
    Friend WithEvents setPrimaryLang As LinkLabel
    Friend WithEvents primaryLanguage As Label
    Friend WithEvents sitesListSelection As ComboBox
    Friend WithEvents downloadCompanyLogo As PictureBox
    Friend WithEvents downloadPhotoContractorManager As PictureBox
    Friend WithEvents saveObraBtn As PictureBox
    Friend WithEvents saveSectionBtn As PictureBox
    Friend WithEvents saveContractorManagerBtn As PictureBox
    Friend WithEvents delObraBtn As PictureBox
    Friend WithEvents delEmpresaBtn As PictureBox
    Friend WithEvents delSectionBtn As PictureBox
    Friend WithEvents delContractorManagerBtn As PictureBox
    Friend WithEvents updateBtn As PictureBox
    Friend WithEvents GroupBoxManagers As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents downloadPhotoManagerBtn As PictureBox
    Friend WithEvents managerPhotobox As PictureBox
    Friend WithEvents managerName_lbl As Label
    Friend WithEvents managerName As TextBox
    Friend WithEvents managerCardId_lbl As Label
    Friend WithEvents managerCardId As TextBox
    Friend WithEvents managerEmail_lbl As Label
    Friend WithEvents managerEmail As TextBox
    Friend WithEvents managerPhone_lbl As Label
    Friend WithEvents managerPhone As TextBox
    Friend WithEvents managerJobAuthority As ComboBox
    Friend WithEvents managerJobAuthority_lbl As Label
    Friend WithEvents managerAssignedSection As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents managerSectionReset As LinkLabel
    Friend WithEvents loadingStatusManager As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents managerTitle As Label
    Public WithEvents managerList As ListBox
    Friend WithEvents managerFileTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sectionRadius As TextBox
    Friend WithEvents sectionRadius_lbl As Label
    Friend WithEvents sectionGpsCoordinates_lbl As Label
    Friend WithEvents sectionLatitude_lbl As Label
    Friend WithEvents sectionLongitude_lbl As Label
    Friend WithEvents sectionLatitude As TextBox
    Friend WithEvents sectionLongitude As TextBox
    Friend WithEvents sectiondistance_lbl As Label
    Friend WithEvents sectionDistance As TextBox
    Friend WithEvents saveEmpresaBtn As PictureBox
End Class
