<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class site_mng_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(site_mng_frm))
        Me.loading_status_company = New System.Windows.Forms.Label()
        Me.loading_status_manager = New System.Windows.Forms.Label()
        Me.loading_status = New System.Windows.Forms.Label()
        Me.downloadCompanyLogo = New System.Windows.Forms.LinkLabel()
        Me.CompanyLogo = New System.Windows.Forms.PictureBox()
        Me.downloadPhotoManager = New System.Windows.Forms.LinkLabel()
        Me.managerPhotobox = New System.Windows.Forms.PictureBox()
        Me.atribuirSection = New System.Windows.Forms.LinkLabel()
        Me.resetSectionResponsavel = New System.Windows.Forms.LinkLabel()
        Me.sectionResponsavel = New System.Windows.Forms.TextBox()
        Me.managerSectionAssigned_lbl = New System.Windows.Forms.Label()
        Me.atribuirEmpresa = New System.Windows.Forms.LinkLabel()
        Me.Panel_geral = New System.Windows.Forms.Panel()
        Me.sitesListSelection = New System.Windows.Forms.ComboBox()
        Me.GroupBoxHourly = New System.Windows.Forms.GroupBox()
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
        Me.delObra = New System.Windows.Forms.LinkLabel()
        Me.saveObra = New System.Windows.Forms.LinkLabel()
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
        Me.authRange = New System.Windows.Forms.TextBox()
        Me.moradaObra = New System.Windows.Forms.TextBox()
        Me.siteAuthRadius_lbl = New System.Windows.Forms.Label()
        Me.siteInitials_lbl = New System.Windows.Forms.Label()
        Me.siglaObra = New System.Windows.Forms.TextBox()
        Me.siteGpsCoordinates_lbl = New System.Windows.Forms.Label()
        Me.siteLatitude_lbl = New System.Windows.Forms.Label()
        Me.siteLongitude_lbl = New System.Windows.Forms.Label()
        Me.latitudeObra = New System.Windows.Forms.TextBox()
        Me.LongitudeObra = New System.Windows.Forms.TextBox()
        Me.resetEmpresa = New System.Windows.Forms.LinkLabel()
        Me.siteDuration_lbl = New System.Windows.Forms.Label()
        Me.siteStart_lbl = New System.Windows.Forms.Label()
        Me.siteEnd_lbl = New System.Windows.Forms.Label()
        Me.siteDistance_lbl = New System.Windows.Forms.Label()
        Me.distanciaObra = New System.Windows.Forms.TextBox()
        Me.EmpresaAtribuida = New System.Windows.Forms.TextBox()
        Me.siteRefContract_lbl = New System.Windows.Forms.Label()
        Me.siteCompanyAssigned_lbl = New System.Windows.Forms.Label()
        Me.refcontrato = New System.Windows.Forms.TextBox()
        Me.duracaoFim = New System.Windows.Forms.DateTimePicker()
        Me.duracaoInicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxCompany = New System.Windows.Forms.GroupBox()
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
        Me.saveEmpresa = New System.Windows.Forms.LinkLabel()
        Me.delEmpresa = New System.Windows.Forms.LinkLabel()
        Me.GroupBoxSections = New System.Windows.Forms.GroupBox()
        Me.sectionDescription_lbl = New System.Windows.Forms.Label()
        Me.descriptionSection = New System.Windows.Forms.TextBox()
        Me.saveSection = New System.Windows.Forms.LinkLabel()
        Me.delSection = New System.Windows.Forms.LinkLabel()
        Me.GroupBoxManagers = New System.Windows.Forms.GroupBox()
        Me.saveNewCard = New System.Windows.Forms.LinkLabel()
        Me.managerName_lbl = New System.Windows.Forms.Label()
        Me.nfcCardCode = New System.Windows.Forms.TextBox()
        Me.nomeResponsavel = New System.Windows.Forms.TextBox()
        Me.nfcCardCode_lbl = New System.Windows.Forms.Label()
        Me.managerCode_lbl = New System.Windows.Forms.Label()
        Me.nfcResponsavel = New System.Windows.Forms.TextBox()
        Me.managerEmail_lbl = New System.Windows.Forms.Label()
        Me.emailResponsavel = New System.Windows.Forms.TextBox()
        Me.managerPhone_lbl = New System.Windows.Forms.Label()
        Me.telefoneResponsavel = New System.Windows.Forms.TextBox()
        Me.saveResponsavel = New System.Windows.Forms.LinkLabel()
        Me.delResponsavel = New System.Windows.Forms.LinkLabel()
        Me.funcaoResponsavel = New System.Windows.Forms.ComboBox()
        Me.managerJob_lbl = New System.Windows.Forms.Label()
        Me.loading_status_sections = New System.Windows.Forms.Label()
        Me.sectionTitle = New System.Windows.Forms.Label()
        Me.sectionsList = New System.Windows.Forms.ListBox()
        Me.divider2 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.divider3 = New System.Windows.Forms.Label()
        Me.divider4 = New System.Windows.Forms.Label()
        Me.managersTitle = New System.Windows.Forms.Label()
        Me.companyTitle = New System.Windows.Forms.Label()
        Me.EmpresaList = New System.Windows.Forms.ListBox()
        Me.sectionsFileTitle = New System.Windows.Forms.Label()
        Me.ManagerList = New System.Windows.Forms.ListBox()
        Me.managersFileTitle = New System.Windows.Forms.Label()
        Me.companyFileTitle = New System.Windows.Forms.Label()
        Me.mandatoryFields = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.siteFileTitle = New System.Windows.Forms.Label()
        Me.siteTitle = New System.Windows.Forms.Label()
        Me.ObrasList = New System.Windows.Forms.ListBox()
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        CType(Me.CompanyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.managerPhotobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_geral.SuspendLayout()
        Me.GroupBoxHourly.SuspendLayout()
        Me.GroupBoxSite.SuspendLayout()
        Me.GroupBoxCompany.SuspendLayout()
        Me.GroupBoxSections.SuspendLayout()
        Me.GroupBoxManagers.SuspendLayout()
        Me.SuspendLayout()
        '
        'loading_status_company
        '
        Me.loading_status_company.AutoSize = True
        Me.loading_status_company.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_company.ForeColor = System.Drawing.Color.Red
        Me.loading_status_company.Location = New System.Drawing.Point(128, 1292)
        Me.loading_status_company.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_company.Name = "loading_status_company"
        Me.loading_status_company.Size = New System.Drawing.Size(80, 17)
        Me.loading_status_company.TabIndex = 280
        Me.loading_status_company.Text = "aguarde..."
        '
        'loading_status_manager
        '
        Me.loading_status_manager.AutoSize = True
        Me.loading_status_manager.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_manager.ForeColor = System.Drawing.Color.Red
        Me.loading_status_manager.Location = New System.Drawing.Point(167, 948)
        Me.loading_status_manager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_manager.Name = "loading_status_manager"
        Me.loading_status_manager.Size = New System.Drawing.Size(80, 17)
        Me.loading_status_manager.TabIndex = 279
        Me.loading_status_manager.Text = "aguarde..."
        '
        'loading_status
        '
        Me.loading_status.AutoSize = True
        Me.loading_status.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status.ForeColor = System.Drawing.Color.Red
        Me.loading_status.Location = New System.Drawing.Point(89, 7)
        Me.loading_status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status.Name = "loading_status"
        Me.loading_status.Size = New System.Drawing.Size(80, 17)
        Me.loading_status.TabIndex = 277
        Me.loading_status.Text = "aguarde..."
        '
        'downloadCompanyLogo
        '
        Me.downloadCompanyLogo.AutoSize = True
        Me.downloadCompanyLogo.Enabled = False
        Me.downloadCompanyLogo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downloadCompanyLogo.Location = New System.Drawing.Point(15, 193)
        Me.downloadCompanyLogo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.downloadCompanyLogo.Name = "downloadCompanyLogo"
        Me.downloadCompanyLogo.Size = New System.Drawing.Size(77, 17)
        Me.downloadCompanyLogo.TabIndex = 276
        Me.downloadCompanyLogo.TabStop = True
        Me.downloadCompanyLogo.Text = "Download"
        '
        'CompanyLogo
        '
        Me.CompanyLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CompanyLogo.Image = CType(resources.GetObject("CompanyLogo.Image"), System.Drawing.Image)
        Me.CompanyLogo.Location = New System.Drawing.Point(19, 39)
        Me.CompanyLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CompanyLogo.Name = "CompanyLogo"
        Me.CompanyLogo.Size = New System.Drawing.Size(159, 150)
        Me.CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CompanyLogo.TabIndex = 275
        Me.CompanyLogo.TabStop = False
        '
        'downloadPhotoManager
        '
        Me.downloadPhotoManager.AutoSize = True
        Me.downloadPhotoManager.Enabled = False
        Me.downloadPhotoManager.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downloadPhotoManager.Location = New System.Drawing.Point(19, 192)
        Me.downloadPhotoManager.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.downloadPhotoManager.Name = "downloadPhotoManager"
        Me.downloadPhotoManager.Size = New System.Drawing.Size(77, 17)
        Me.downloadPhotoManager.TabIndex = 274
        Me.downloadPhotoManager.TabStop = True
        Me.downloadPhotoManager.Text = "Download"
        '
        'managerPhotobox
        '
        Me.managerPhotobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.managerPhotobox.Image = CType(resources.GetObject("managerPhotobox.Image"), System.Drawing.Image)
        Me.managerPhotobox.Location = New System.Drawing.Point(19, 38)
        Me.managerPhotobox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.managerPhotobox.Name = "managerPhotobox"
        Me.managerPhotobox.Size = New System.Drawing.Size(159, 150)
        Me.managerPhotobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.managerPhotobox.TabIndex = 273
        Me.managerPhotobox.TabStop = False
        '
        'atribuirSection
        '
        Me.atribuirSection.AutoSize = True
        Me.atribuirSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atribuirSection.Location = New System.Drawing.Point(199, 86)
        Me.atribuirSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.atribuirSection.Name = "atribuirSection"
        Me.atribuirSection.Size = New System.Drawing.Size(114, 17)
        Me.atribuirSection.TabIndex = 272
        Me.atribuirSection.TabStop = True
        Me.atribuirSection.Text = "Atribuir Secção"
        '
        'resetSectionResponsavel
        '
        Me.resetSectionResponsavel.AutoSize = True
        Me.resetSectionResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetSectionResponsavel.Location = New System.Drawing.Point(200, 240)
        Me.resetSectionResponsavel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.resetSectionResponsavel.Name = "resetSectionResponsavel"
        Me.resetSectionResponsavel.Size = New System.Drawing.Size(48, 17)
        Me.resetSectionResponsavel.TabIndex = 271
        Me.resetSectionResponsavel.TabStop = True
        Me.resetSectionResponsavel.Text = "Reset"
        '
        'sectionResponsavel
        '
        Me.sectionResponsavel.Enabled = False
        Me.sectionResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionResponsavel.Location = New System.Drawing.Point(204, 212)
        Me.sectionResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sectionResponsavel.Name = "sectionResponsavel"
        Me.sectionResponsavel.Size = New System.Drawing.Size(567, 24)
        Me.sectionResponsavel.TabIndex = 269
        '
        'managerSectionAssigned_lbl
        '
        Me.managerSectionAssigned_lbl.AutoSize = True
        Me.managerSectionAssigned_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerSectionAssigned_lbl.Location = New System.Drawing.Point(200, 191)
        Me.managerSectionAssigned_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerSectionAssigned_lbl.Name = "managerSectionAssigned_lbl"
        Me.managerSectionAssigned_lbl.Size = New System.Drawing.Size(123, 17)
        Me.managerSectionAssigned_lbl.TabIndex = 270
        Me.managerSectionAssigned_lbl.Text = "Secção atribuida"
        '
        'atribuirEmpresa
        '
        Me.atribuirEmpresa.AutoSize = True
        Me.atribuirEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atribuirEmpresa.Location = New System.Drawing.Point(196, 193)
        Me.atribuirEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.atribuirEmpresa.Name = "atribuirEmpresa"
        Me.atribuirEmpresa.Size = New System.Drawing.Size(126, 17)
        Me.atribuirEmpresa.TabIndex = 265
        Me.atribuirEmpresa.TabStop = True
        Me.atribuirEmpresa.Text = "Atribuir Empresa"
        '
        'Panel_geral
        '
        Me.Panel_geral.AutoScroll = True
        Me.Panel_geral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel_geral.BackColor = System.Drawing.Color.White
        Me.Panel_geral.Controls.Add(Me.sitesListSelection)
        Me.Panel_geral.Controls.Add(Me.GroupBoxHourly)
        Me.Panel_geral.Controls.Add(Me.GroupBoxSite)
        Me.Panel_geral.Controls.Add(Me.GroupBoxCompany)
        Me.Panel_geral.Controls.Add(Me.GroupBoxSections)
        Me.Panel_geral.Controls.Add(Me.GroupBoxManagers)
        Me.Panel_geral.Controls.Add(Me.loading_status_company)
        Me.Panel_geral.Controls.Add(Me.loading_status_manager)
        Me.Panel_geral.Controls.Add(Me.loading_status_sections)
        Me.Panel_geral.Controls.Add(Me.loading_status)
        Me.Panel_geral.Controls.Add(Me.sectionTitle)
        Me.Panel_geral.Controls.Add(Me.sectionsList)
        Me.Panel_geral.Controls.Add(Me.divider2)
        Me.Panel_geral.Controls.Add(Me.Label30)
        Me.Panel_geral.Controls.Add(Me.divider3)
        Me.Panel_geral.Controls.Add(Me.divider4)
        Me.Panel_geral.Controls.Add(Me.managersTitle)
        Me.Panel_geral.Controls.Add(Me.companyTitle)
        Me.Panel_geral.Controls.Add(Me.EmpresaList)
        Me.Panel_geral.Controls.Add(Me.sectionsFileTitle)
        Me.Panel_geral.Controls.Add(Me.ManagerList)
        Me.Panel_geral.Controls.Add(Me.managersFileTitle)
        Me.Panel_geral.Controls.Add(Me.companyFileTitle)
        Me.Panel_geral.Controls.Add(Me.mandatoryFields)
        Me.Panel_geral.Controls.Add(Me.divider)
        Me.Panel_geral.Controls.Add(Me.siteFileTitle)
        Me.Panel_geral.Controls.Add(Me.siteTitle)
        Me.Panel_geral.Controls.Add(Me.ObrasList)
        Me.Panel_geral.Controls.Add(Me.updateLink)
        Me.Panel_geral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_geral.Location = New System.Drawing.Point(3, 2)
        Me.Panel_geral.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel_geral.Name = "Panel_geral"
        Me.Panel_geral.Size = New System.Drawing.Size(1971, 1095)
        Me.Panel_geral.TabIndex = 1
        '
        'sitesListSelection
        '
        Me.sitesListSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sitesListSelection.FormattingEnabled = True
        Me.sitesListSelection.Location = New System.Drawing.Point(13, 30)
        Me.sitesListSelection.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sitesListSelection.Name = "sitesListSelection"
        Me.sitesListSelection.Size = New System.Drawing.Size(465, 25)
        Me.sitesListSelection.TabIndex = 292
        '
        'GroupBoxHourly
        '
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
        Me.GroupBoxHourly.Controls.Add(Me.delObra)
        Me.GroupBoxHourly.Controls.Add(Me.saveObra)
        Me.GroupBoxHourly.Location = New System.Drawing.Point(521, 505)
        Me.GroupBoxHourly.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxHourly.Name = "GroupBoxHourly"
        Me.GroupBoxHourly.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxHourly.Size = New System.Drawing.Size(1195, 228)
        Me.GroupBoxHourly.TabIndex = 291
        Me.GroupBoxHourly.TabStop = False
        Me.GroupBoxHourly.Text = "Preço de prestações com taxa horaria"
        '
        'after_hours_time_lbl
        '
        Me.after_hours_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.after_hours_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.after_hours_time_lbl.Location = New System.Drawing.Point(19, 137)
        Me.after_hours_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.after_hours_time_lbl.Name = "after_hours_time_lbl"
        Me.after_hours_time_lbl.Size = New System.Drawing.Size(228, 21)
        Me.after_hours_time_lbl.TabIndex = 232
        Me.after_hours_time_lbl.Text = "horario extra*"
        Me.after_hours_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly9
        '
        Me.unitshourly9.AutoSize = True
        Me.unitshourly9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly9.Location = New System.Drawing.Point(1053, 135)
        Me.unitshourly9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly9.Name = "unitshourly9"
        Me.unitshourly9.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly9.TabIndex = 231
        Me.unitshourly9.Text = "€/h"
        '
        'unitshourly8
        '
        Me.unitshourly8.AutoSize = True
        Me.unitshourly8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly8.Location = New System.Drawing.Point(760, 135)
        Me.unitshourly8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly8.Name = "unitshourly8"
        Me.unitshourly8.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly8.TabIndex = 230
        Me.unitshourly8.Text = "€/h"
        '
        'unitshourly7
        '
        Me.unitshourly7.AutoSize = True
        Me.unitshourly7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly7.Location = New System.Drawing.Point(424, 135)
        Me.unitshourly7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly7.Name = "unitshourly7"
        Me.unitshourly7.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly7.TabIndex = 229
        Me.unitshourly7.Text = "€/h"
        '
        'craneman_after_hours
        '
        Me.craneman_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.craneman_after_hours.Location = New System.Drawing.Point(880, 132)
        Me.craneman_after_hours.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.craneman_after_hours.Name = "craneman_after_hours"
        Me.craneman_after_hours.Size = New System.Drawing.Size(167, 24)
        Me.craneman_after_hours.TabIndex = 228
        '
        'machinist_after_hours
        '
        Me.machinist_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinist_after_hours.Location = New System.Drawing.Point(584, 132)
        Me.machinist_after_hours.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.machinist_after_hours.Name = "machinist_after_hours"
        Me.machinist_after_hours.Size = New System.Drawing.Size(167, 24)
        Me.machinist_after_hours.TabIndex = 227
        '
        'regie_after_hours
        '
        Me.regie_after_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_after_hours.Location = New System.Drawing.Point(255, 132)
        Me.regie_after_hours.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.regie_after_hours.Name = "regie_after_hours"
        Me.regie_after_hours.Size = New System.Drawing.Size(167, 24)
        Me.regie_after_hours.TabIndex = 226
        '
        'weekends_time_lbl
        '
        Me.weekends_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.weekends_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weekends_time_lbl.Location = New System.Drawing.Point(15, 103)
        Me.weekends_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weekends_time_lbl.Name = "weekends_time_lbl"
        Me.weekends_time_lbl.Size = New System.Drawing.Size(232, 21)
        Me.weekends_time_lbl.TabIndex = 225
        Me.weekends_time_lbl.Text = "fim de semana*"
        Me.weekends_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly6
        '
        Me.unitshourly6.AutoSize = True
        Me.unitshourly6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly6.Location = New System.Drawing.Point(1053, 102)
        Me.unitshourly6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly6.Name = "unitshourly6"
        Me.unitshourly6.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly6.TabIndex = 224
        Me.unitshourly6.Text = "€/h"
        '
        'unitshourly5
        '
        Me.unitshourly5.AutoSize = True
        Me.unitshourly5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly5.Location = New System.Drawing.Point(760, 102)
        Me.unitshourly5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly5.Name = "unitshourly5"
        Me.unitshourly5.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly5.TabIndex = 223
        Me.unitshourly5.Text = "€/h"
        '
        'unitshourly4
        '
        Me.unitshourly4.AutoSize = True
        Me.unitshourly4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly4.Location = New System.Drawing.Point(424, 102)
        Me.unitshourly4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly4.Name = "unitshourly4"
        Me.unitshourly4.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly4.TabIndex = 222
        Me.unitshourly4.Text = "€/h"
        '
        'craneman_weekends
        '
        Me.craneman_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.craneman_weekends.Location = New System.Drawing.Point(880, 98)
        Me.craneman_weekends.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.craneman_weekends.Name = "craneman_weekends"
        Me.craneman_weekends.Size = New System.Drawing.Size(167, 24)
        Me.craneman_weekends.TabIndex = 221
        '
        'machinist_weekends
        '
        Me.machinist_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinist_weekends.Location = New System.Drawing.Point(584, 98)
        Me.machinist_weekends.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.machinist_weekends.Name = "machinist_weekends"
        Me.machinist_weekends.Size = New System.Drawing.Size(167, 24)
        Me.machinist_weekends.TabIndex = 220
        '
        'regie_weekends
        '
        Me.regie_weekends.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regie_weekends.Location = New System.Drawing.Point(255, 98)
        Me.regie_weekends.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.regie_weekends.Name = "regie_weekends"
        Me.regie_weekends.Size = New System.Drawing.Size(167, 24)
        Me.regie_weekends.TabIndex = 219
        '
        'normal_time_lbl
        '
        Me.normal_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.normal_time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.normal_time_lbl.Location = New System.Drawing.Point(11, 70)
        Me.normal_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.normal_time_lbl.Name = "normal_time_lbl"
        Me.normal_time_lbl.Size = New System.Drawing.Size(236, 21)
        Me.normal_time_lbl.TabIndex = 218
        Me.normal_time_lbl.Text = "horario normal*"
        Me.normal_time_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'unitshourly3
        '
        Me.unitshourly3.AutoSize = True
        Me.unitshourly3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly3.Location = New System.Drawing.Point(1053, 69)
        Me.unitshourly3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly3.Name = "unitshourly3"
        Me.unitshourly3.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly3.TabIndex = 217
        Me.unitshourly3.Text = "€/h"
        '
        'unitshourly2
        '
        Me.unitshourly2.AutoSize = True
        Me.unitshourly2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly2.Location = New System.Drawing.Point(760, 69)
        Me.unitshourly2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly2.Name = "unitshourly2"
        Me.unitshourly2.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly2.TabIndex = 216
        Me.unitshourly2.Text = "€/h"
        '
        'unitshourly1
        '
        Me.unitshourly1.AutoSize = True
        Me.unitshourly1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitshourly1.Location = New System.Drawing.Point(424, 69)
        Me.unitshourly1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.unitshourly1.Name = "unitshourly1"
        Me.unitshourly1.Size = New System.Drawing.Size(32, 17)
        Me.unitshourly1.TabIndex = 215
        Me.unitshourly1.Text = "€/h"
        '
        'cranemanHourly_lbl
        '
        Me.cranemanHourly_lbl.AutoSize = True
        Me.cranemanHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cranemanHourly_lbl.Location = New System.Drawing.Point(876, 46)
        Me.cranemanHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.cranemanHourly_lbl.Name = "cranemanHourly_lbl"
        Me.cranemanHourly_lbl.Size = New System.Drawing.Size(68, 17)
        Me.cranemanHourly_lbl.TabIndex = 214
        Me.cranemanHourly_lbl.Text = "Gruista*"
        '
        'machinistHourly_lbl
        '
        Me.machinistHourly_lbl.AutoSize = True
        Me.machinistHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinistHourly_lbl.Location = New System.Drawing.Point(581, 46)
        Me.machinistHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.machinistHourly_lbl.Name = "machinistHourly_lbl"
        Me.machinistHourly_lbl.Size = New System.Drawing.Size(101, 17)
        Me.machinistHourly_lbl.TabIndex = 213
        Me.machinistHourly_lbl.Text = "Manobrador*"
        '
        'regieHourly_lbl
        '
        Me.regieHourly_lbl.AutoSize = True
        Me.regieHourly_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieHourly_lbl.Location = New System.Drawing.Point(251, 46)
        Me.regieHourly_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.regieHourly_lbl.Name = "regieHourly_lbl"
        Me.regieHourly_lbl.Size = New System.Drawing.Size(186, 17)
        Me.regieHourly_lbl.TabIndex = 212
        Me.regieHourly_lbl.Text = "Trabalhos nao previstos*"
        '
        'cranemanHourly
        '
        Me.cranemanHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cranemanHourly.Location = New System.Drawing.Point(880, 65)
        Me.cranemanHourly.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cranemanHourly.Name = "cranemanHourly"
        Me.cranemanHourly.Size = New System.Drawing.Size(167, 24)
        Me.cranemanHourly.TabIndex = 211
        '
        'machinistHourly
        '
        Me.machinistHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.machinistHourly.Location = New System.Drawing.Point(584, 65)
        Me.machinistHourly.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.machinistHourly.Name = "machinistHourly"
        Me.machinistHourly.Size = New System.Drawing.Size(167, 24)
        Me.machinistHourly.TabIndex = 209
        '
        'regieHourly
        '
        Me.regieHourly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regieHourly.Location = New System.Drawing.Point(255, 65)
        Me.regieHourly.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.regieHourly.Name = "regieHourly"
        Me.regieHourly.Size = New System.Drawing.Size(167, 24)
        Me.regieHourly.TabIndex = 207
        '
        'delObra
        '
        Me.delObra.AutoSize = True
        Me.delObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delObra.Location = New System.Drawing.Point(996, 199)
        Me.delObra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.delObra.Name = "delObra"
        Me.delObra.Size = New System.Drawing.Size(58, 17)
        Me.delObra.TabIndex = 13
        Me.delObra.TabStop = True
        Me.delObra.Text = "Apagar"
        '
        'saveObra
        '
        Me.saveObra.AutoSize = True
        Me.saveObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveObra.Location = New System.Drawing.Point(1093, 199)
        Me.saveObra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveObra.Name = "saveObra"
        Me.saveObra.Size = New System.Drawing.Size(55, 17)
        Me.saveObra.TabIndex = 14
        Me.saveObra.TabStop = True
        Me.saveObra.Text = "Gravar"
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
        Me.GroupBoxSite.Controls.Add(Me.authRange)
        Me.GroupBoxSite.Controls.Add(Me.moradaObra)
        Me.GroupBoxSite.Controls.Add(Me.siteAuthRadius_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteInitials_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siglaObra)
        Me.GroupBoxSite.Controls.Add(Me.siteGpsCoordinates_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteLatitude_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteLongitude_lbl)
        Me.GroupBoxSite.Controls.Add(Me.latitudeObra)
        Me.GroupBoxSite.Controls.Add(Me.LongitudeObra)
        Me.GroupBoxSite.Controls.Add(Me.resetEmpresa)
        Me.GroupBoxSite.Controls.Add(Me.siteDuration_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteStart_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteEnd_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteDistance_lbl)
        Me.GroupBoxSite.Controls.Add(Me.distanciaObra)
        Me.GroupBoxSite.Controls.Add(Me.EmpresaAtribuida)
        Me.GroupBoxSite.Controls.Add(Me.siteRefContract_lbl)
        Me.GroupBoxSite.Controls.Add(Me.siteCompanyAssigned_lbl)
        Me.GroupBoxSite.Controls.Add(Me.refcontrato)
        Me.GroupBoxSite.Controls.Add(Me.duracaoFim)
        Me.GroupBoxSite.Controls.Add(Me.duracaoInicio)
        Me.GroupBoxSite.Location = New System.Drawing.Point(521, 68)
        Me.GroupBoxSite.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSite.Name = "GroupBoxSite"
        Me.GroupBoxSite.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSite.Size = New System.Drawing.Size(1195, 430)
        Me.GroupBoxSite.TabIndex = 290
        Me.GroupBoxSite.TabStop = False
        '
        'primaryLanguage
        '
        Me.primaryLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.primaryLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.primaryLanguage.Location = New System.Drawing.Point(855, 220)
        Me.primaryLanguage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.primaryLanguage.Name = "primaryLanguage"
        Me.primaryLanguage.Size = New System.Drawing.Size(307, 17)
        Me.primaryLanguage.TabIndex = 352
        Me.primaryLanguage.Text = "primary language: English"
        Me.primaryLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'setPrimaryLang
        '
        Me.setPrimaryLang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.setPrimaryLang.AutoSize = True
        Me.setPrimaryLang.Enabled = False
        Me.setPrimaryLang.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setPrimaryLang.Location = New System.Drawing.Point(1051, 366)
        Me.setPrimaryLang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.setPrimaryLang.Name = "setPrimaryLang"
        Me.setPrimaryLang.Size = New System.Drawing.Size(111, 17)
        Me.setPrimaryLang.TabIndex = 351
        Me.setPrimaryLang.TabStop = True
        Me.setPrimaryLang.Text = "Set as primary"
        Me.setPrimaryLang.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'show_default_lang
        '
        Me.show_default_lang.AutoSize = True
        Me.show_default_lang.Location = New System.Drawing.Point(781, 366)
        Me.show_default_lang.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.show_default_lang.Name = "show_default_lang"
        Me.show_default_lang.Size = New System.Drawing.Size(122, 21)
        Me.show_default_lang.TabIndex = 350
        Me.show_default_lang.Text = "Show default"
        Me.show_default_lang.UseVisualStyleBackColor = True
        '
        'languagesProject_lbl
        '
        Me.languagesProject_lbl.AutoSize = True
        Me.languagesProject_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.languagesProject_lbl.Location = New System.Drawing.Point(627, 218)
        Me.languagesProject_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.languagesProject_lbl.Name = "languagesProject_lbl"
        Me.languagesProject_lbl.Size = New System.Drawing.Size(166, 17)
        Me.languagesProject_lbl.TabIndex = 349
        Me.languagesProject_lbl.Text = "Languages of the project"
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(631, 366)
        Me.show_all_lang.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(88, 21)
        Me.show_all_lang.TabIndex = 348
        Me.show_all_lang.Text = "Show all"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'languagesList
        '
        Me.languagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.languagesList.FormattingEnabled = True
        Me.languagesList.ItemHeight = 17
        Me.languagesList.Location = New System.Drawing.Point(631, 241)
        Me.languagesList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.languagesList.Name = "languagesList"
        Me.languagesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.languagesList.Size = New System.Drawing.Size(530, 104)
        Me.languagesList.TabIndex = 347
        '
        'siteName_lbl
        '
        Me.siteName_lbl.AutoSize = True
        Me.siteName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteName_lbl.Location = New System.Drawing.Point(19, 25)
        Me.siteName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteName_lbl.Name = "siteName_lbl"
        Me.siteName_lbl.Size = New System.Drawing.Size(116, 17)
        Me.siteName_lbl.TabIndex = 38
        Me.siteName_lbl.Text = "Nome da obra*"
        '
        'nomeObra
        '
        Me.nomeObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeObra.Location = New System.Drawing.Point(23, 46)
        Me.nomeObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nomeObra.Name = "nomeObra"
        Me.nomeObra.Size = New System.Drawing.Size(569, 24)
        Me.nomeObra.TabIndex = 4
        '
        'site_ended
        '
        Me.site_ended.AutoSize = True
        Me.site_ended.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_ended.Location = New System.Drawing.Point(24, 389)
        Me.site_ended.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.site_ended.Name = "site_ended"
        Me.site_ended.Size = New System.Drawing.Size(101, 21)
        Me.site_ended.TabIndex = 283
        Me.site_ended.Text = "Terminada"
        Me.site_ended.UseVisualStyleBackColor = True
        '
        'siteAddress_lbl
        '
        Me.siteAddress_lbl.AutoSize = True
        Me.siteAddress_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteAddress_lbl.Location = New System.Drawing.Point(19, 74)
        Me.siteAddress_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteAddress_lbl.Name = "siteAddress_lbl"
        Me.siteAddress_lbl.Size = New System.Drawing.Size(68, 17)
        Me.siteAddress_lbl.TabIndex = 43
        Me.siteAddress_lbl.Text = "Morada*"
        '
        'authRange
        '
        Me.authRange.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.authRange.Location = New System.Drawing.Point(512, 241)
        Me.authRange.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.authRange.Name = "authRange"
        Me.authRange.Size = New System.Drawing.Size(80, 24)
        Me.authRange.TabIndex = 281
        Me.authRange.Text = "5"
        '
        'moradaObra
        '
        Me.moradaObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.moradaObra.Location = New System.Drawing.Point(23, 95)
        Me.moradaObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.moradaObra.Multiline = True
        Me.moradaObra.Name = "moradaObra"
        Me.moradaObra.Size = New System.Drawing.Size(569, 90)
        Me.moradaObra.TabIndex = 7
        '
        'siteAuthRadius_lbl
        '
        Me.siteAuthRadius_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteAuthRadius_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteAuthRadius_lbl.Location = New System.Drawing.Point(0, 245)
        Me.siteAuthRadius_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteAuthRadius_lbl.Name = "siteAuthRadius_lbl"
        Me.siteAuthRadius_lbl.Size = New System.Drawing.Size(203, 16)
        Me.siteAuthRadius_lbl.TabIndex = 282
        Me.siteAuthRadius_lbl.Text = "Raio de autorização* (m)"
        Me.siteAuthRadius_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteInitials_lbl
        '
        Me.siteInitials_lbl.AutoSize = True
        Me.siteInitials_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteInitials_lbl.Location = New System.Drawing.Point(624, 25)
        Me.siteInitials_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteInitials_lbl.Name = "siteInitials_lbl"
        Me.siteInitials_lbl.Size = New System.Drawing.Size(111, 17)
        Me.siteInitials_lbl.TabIndex = 45
        Me.siteInitials_lbl.Text = "Sigla da Obra*"
        '
        'siglaObra
        '
        Me.siglaObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siglaObra.Location = New System.Drawing.Point(628, 46)
        Me.siglaObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.siglaObra.Name = "siglaObra"
        Me.siglaObra.Size = New System.Drawing.Size(95, 24)
        Me.siglaObra.TabIndex = 5
        '
        'siteGpsCoordinates_lbl
        '
        Me.siteGpsCoordinates_lbl.AutoSize = True
        Me.siteGpsCoordinates_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteGpsCoordinates_lbl.Location = New System.Drawing.Point(19, 190)
        Me.siteGpsCoordinates_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteGpsCoordinates_lbl.Name = "siteGpsCoordinates_lbl"
        Me.siteGpsCoordinates_lbl.Size = New System.Drawing.Size(144, 17)
        Me.siteGpsCoordinates_lbl.TabIndex = 205
        Me.siteGpsCoordinates_lbl.Text = "Coordenadas GPS*"
        '
        'siteLatitude_lbl
        '
        Me.siteLatitude_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteLatitude_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteLatitude_lbl.Location = New System.Drawing.Point(-292, 210)
        Me.siteLatitude_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteLatitude_lbl.Name = "siteLatitude_lbl"
        Me.siteLatitude_lbl.Size = New System.Drawing.Size(108, 22)
        Me.siteLatitude_lbl.TabIndex = 206
        Me.siteLatitude_lbl.Text = "Latitude"
        Me.siteLatitude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteLongitude_lbl
        '
        Me.siteLongitude_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteLongitude_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteLongitude_lbl.Location = New System.Drawing.Point(-288, 245)
        Me.siteLongitude_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteLongitude_lbl.Name = "siteLongitude_lbl"
        Me.siteLongitude_lbl.Size = New System.Drawing.Size(104, 16)
        Me.siteLongitude_lbl.TabIndex = 207
        Me.siteLongitude_lbl.Text = "Longitude"
        Me.siteLongitude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'latitudeObra
        '
        Me.latitudeObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latitudeObra.Location = New System.Drawing.Point(123, 209)
        Me.latitudeObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.latitudeObra.Name = "latitudeObra"
        Me.latitudeObra.Size = New System.Drawing.Size(167, 24)
        Me.latitudeObra.TabIndex = 10
        '
        'LongitudeObra
        '
        Me.LongitudeObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LongitudeObra.Location = New System.Drawing.Point(123, 241)
        Me.LongitudeObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LongitudeObra.Name = "LongitudeObra"
        Me.LongitudeObra.Size = New System.Drawing.Size(167, 24)
        Me.LongitudeObra.TabIndex = 11
        '
        'resetEmpresa
        '
        Me.resetEmpresa.AutoSize = True
        Me.resetEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetEmpresa.Location = New System.Drawing.Point(19, 347)
        Me.resetEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.resetEmpresa.Name = "resetEmpresa"
        Me.resetEmpresa.Size = New System.Drawing.Size(48, 17)
        Me.resetEmpresa.TabIndex = 266
        Me.resetEmpresa.TabStop = True
        Me.resetEmpresa.Text = "Reset"
        '
        'siteDuration_lbl
        '
        Me.siteDuration_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteDuration_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteDuration_lbl.Location = New System.Drawing.Point(337, 95)
        Me.siteDuration_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteDuration_lbl.Name = "siteDuration_lbl"
        Me.siteDuration_lbl.Size = New System.Drawing.Size(197, 17)
        Me.siteDuration_lbl.TabIndex = 210
        Me.siteDuration_lbl.Text = "Duração prevista*"
        Me.siteDuration_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteStart_lbl
        '
        Me.siteStart_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteStart_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteStart_lbl.Location = New System.Drawing.Point(323, 119)
        Me.siteStart_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteStart_lbl.Name = "siteStart_lbl"
        Me.siteStart_lbl.Size = New System.Drawing.Size(125, 22)
        Me.siteStart_lbl.TabIndex = 211
        Me.siteStart_lbl.Text = "Inicio"
        Me.siteStart_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteEnd_lbl
        '
        Me.siteEnd_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteEnd_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteEnd_lbl.Location = New System.Drawing.Point(328, 151)
        Me.siteEnd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteEnd_lbl.Name = "siteEnd_lbl"
        Me.siteEnd_lbl.Size = New System.Drawing.Size(119, 22)
        Me.siteEnd_lbl.TabIndex = 212
        Me.siteEnd_lbl.Text = "Fim"
        Me.siteEnd_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteDistance_lbl
        '
        Me.siteDistance_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.siteDistance_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteDistance_lbl.Location = New System.Drawing.Point(7, 214)
        Me.siteDistance_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteDistance_lbl.Name = "siteDistance_lbl"
        Me.siteDistance_lbl.Size = New System.Drawing.Size(199, 16)
        Me.siteDistance_lbl.TabIndex = 215
        Me.siteDistance_lbl.Text = "Distância* (Km)"
        Me.siteDistance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'distanciaObra
        '
        Me.distanciaObra.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.distanciaObra.Location = New System.Drawing.Point(512, 209)
        Me.distanciaObra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.distanciaObra.Name = "distanciaObra"
        Me.distanciaObra.Size = New System.Drawing.Size(80, 24)
        Me.distanciaObra.TabIndex = 12
        '
        'EmpresaAtribuida
        '
        Me.EmpresaAtribuida.Enabled = False
        Me.EmpresaAtribuida.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpresaAtribuida.Location = New System.Drawing.Point(23, 319)
        Me.EmpresaAtribuida.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpresaAtribuida.Name = "EmpresaAtribuida"
        Me.EmpresaAtribuida.Size = New System.Drawing.Size(492, 24)
        Me.EmpresaAtribuida.TabIndex = 259
        '
        'siteRefContract_lbl
        '
        Me.siteRefContract_lbl.AutoSize = True
        Me.siteRefContract_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteRefContract_lbl.Location = New System.Drawing.Point(748, 25)
        Me.siteRefContract_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteRefContract_lbl.Name = "siteRefContract_lbl"
        Me.siteRefContract_lbl.Size = New System.Drawing.Size(103, 17)
        Me.siteRefContract_lbl.TabIndex = 217
        Me.siteRefContract_lbl.Text = "Ref. Contrato"
        '
        'siteCompanyAssigned_lbl
        '
        Me.siteCompanyAssigned_lbl.AutoSize = True
        Me.siteCompanyAssigned_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteCompanyAssigned_lbl.Location = New System.Drawing.Point(19, 298)
        Me.siteCompanyAssigned_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteCompanyAssigned_lbl.Name = "siteCompanyAssigned_lbl"
        Me.siteCompanyAssigned_lbl.Size = New System.Drawing.Size(135, 17)
        Me.siteCompanyAssigned_lbl.TabIndex = 260
        Me.siteCompanyAssigned_lbl.Text = "Empresa atribuida"
        '
        'refcontrato
        '
        Me.refcontrato.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refcontrato.Location = New System.Drawing.Point(752, 46)
        Me.refcontrato.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.refcontrato.Name = "refcontrato"
        Me.refcontrato.Size = New System.Drawing.Size(368, 24)
        Me.refcontrato.TabIndex = 6
        '
        'duracaoFim
        '
        Me.duracaoFim.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoFim.Location = New System.Drawing.Point(756, 148)
        Me.duracaoFim.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.duracaoFim.Name = "duracaoFim"
        Me.duracaoFim.Size = New System.Drawing.Size(268, 24)
        Me.duracaoFim.TabIndex = 9
        '
        'duracaoInicio
        '
        Me.duracaoInicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicio.Location = New System.Drawing.Point(756, 116)
        Me.duracaoInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.duracaoInicio.Name = "duracaoInicio"
        Me.duracaoInicio.Size = New System.Drawing.Size(268, 24)
        Me.duracaoInicio.TabIndex = 8
        '
        'GroupBoxCompany
        '
        Me.GroupBoxCompany.Controls.Add(Me.CompanyLogo)
        Me.GroupBoxCompany.Controls.Add(Me.companyName_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.nomeEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyAddress_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.moradaEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyTva_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.tvaEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.companyEmail_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.emailEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.downloadCompanyLogo)
        Me.GroupBoxCompany.Controls.Add(Me.companyPhone_lbl)
        Me.GroupBoxCompany.Controls.Add(Me.telefoneEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.saveEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.delEmpresa)
        Me.GroupBoxCompany.Controls.Add(Me.atribuirEmpresa)
        Me.GroupBoxCompany.Location = New System.Drawing.Point(533, 1289)
        Me.GroupBoxCompany.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxCompany.Name = "GroupBoxCompany"
        Me.GroupBoxCompany.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxCompany.Size = New System.Drawing.Size(1192, 263)
        Me.GroupBoxCompany.TabIndex = 289
        Me.GroupBoxCompany.TabStop = False
        '
        'companyName_lbl
        '
        Me.companyName_lbl.AutoSize = True
        Me.companyName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyName_lbl.Location = New System.Drawing.Point(196, 18)
        Me.companyName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyName_lbl.Name = "companyName_lbl"
        Me.companyName_lbl.Size = New System.Drawing.Size(144, 17)
        Me.companyName_lbl.TabIndex = 219
        Me.companyName_lbl.Text = "Nome da empresa*"
        '
        'nomeEmpresa
        '
        Me.nomeEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeEmpresa.Location = New System.Drawing.Point(200, 39)
        Me.nomeEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nomeEmpresa.Name = "nomeEmpresa"
        Me.nomeEmpresa.Size = New System.Drawing.Size(569, 24)
        Me.nomeEmpresa.TabIndex = 15
        '
        'companyAddress_lbl
        '
        Me.companyAddress_lbl.AutoSize = True
        Me.companyAddress_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyAddress_lbl.Location = New System.Drawing.Point(196, 70)
        Me.companyAddress_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyAddress_lbl.Name = "companyAddress_lbl"
        Me.companyAddress_lbl.Size = New System.Drawing.Size(68, 17)
        Me.companyAddress_lbl.TabIndex = 221
        Me.companyAddress_lbl.Text = "Morada*"
        '
        'moradaEmpresa
        '
        Me.moradaEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.moradaEmpresa.Location = New System.Drawing.Point(200, 91)
        Me.moradaEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.moradaEmpresa.Multiline = True
        Me.moradaEmpresa.Name = "moradaEmpresa"
        Me.moradaEmpresa.Size = New System.Drawing.Size(569, 98)
        Me.moradaEmpresa.TabIndex = 16
        '
        'companyTva_lbl
        '
        Me.companyTva_lbl.AutoSize = True
        Me.companyTva_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyTva_lbl.Location = New System.Drawing.Point(801, 18)
        Me.companyTva_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyTva_lbl.Name = "companyTva_lbl"
        Me.companyTva_lbl.Size = New System.Drawing.Size(57, 17)
        Me.companyTva_lbl.TabIndex = 223
        Me.companyTva_lbl.Text = "T.V.A.*"
        '
        'tvaEmpresa
        '
        Me.tvaEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvaEmpresa.Location = New System.Drawing.Point(805, 39)
        Me.tvaEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tvaEmpresa.Name = "tvaEmpresa"
        Me.tvaEmpresa.Size = New System.Drawing.Size(167, 24)
        Me.tvaEmpresa.TabIndex = 17
        '
        'companyEmail_lbl
        '
        Me.companyEmail_lbl.AutoSize = True
        Me.companyEmail_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyEmail_lbl.Location = New System.Drawing.Point(803, 70)
        Me.companyEmail_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyEmail_lbl.Name = "companyEmail_lbl"
        Me.companyEmail_lbl.Size = New System.Drawing.Size(53, 17)
        Me.companyEmail_lbl.TabIndex = 225
        Me.companyEmail_lbl.Text = "Email*"
        '
        'emailEmpresa
        '
        Me.emailEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailEmpresa.Location = New System.Drawing.Point(807, 91)
        Me.emailEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.emailEmpresa.Name = "emailEmpresa"
        Me.emailEmpresa.Size = New System.Drawing.Size(373, 24)
        Me.emailEmpresa.TabIndex = 19
        '
        'companyPhone_lbl
        '
        Me.companyPhone_lbl.AutoSize = True
        Me.companyPhone_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyPhone_lbl.Location = New System.Drawing.Point(1009, 18)
        Me.companyPhone_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyPhone_lbl.Name = "companyPhone_lbl"
        Me.companyPhone_lbl.Size = New System.Drawing.Size(74, 17)
        Me.companyPhone_lbl.TabIndex = 227
        Me.companyPhone_lbl.Text = "Telefone*"
        '
        'telefoneEmpresa
        '
        Me.telefoneEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefoneEmpresa.Location = New System.Drawing.Point(1013, 39)
        Me.telefoneEmpresa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.telefoneEmpresa.Name = "telefoneEmpresa"
        Me.telefoneEmpresa.Size = New System.Drawing.Size(167, 24)
        Me.telefoneEmpresa.TabIndex = 18
        '
        'saveEmpresa
        '
        Me.saveEmpresa.AutoSize = True
        Me.saveEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveEmpresa.Location = New System.Drawing.Point(1081, 219)
        Me.saveEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveEmpresa.Name = "saveEmpresa"
        Me.saveEmpresa.Size = New System.Drawing.Size(55, 17)
        Me.saveEmpresa.TabIndex = 21
        Me.saveEmpresa.TabStop = True
        Me.saveEmpresa.Text = "Gravar"
        '
        'delEmpresa
        '
        Me.delEmpresa.AutoSize = True
        Me.delEmpresa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delEmpresa.Location = New System.Drawing.Point(984, 219)
        Me.delEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.delEmpresa.Name = "delEmpresa"
        Me.delEmpresa.Size = New System.Drawing.Size(58, 17)
        Me.delEmpresa.TabIndex = 20
        Me.delEmpresa.TabStop = True
        Me.delEmpresa.Text = "Apagar"
        '
        'GroupBoxSections
        '
        Me.GroupBoxSections.Controls.Add(Me.sectionDescription_lbl)
        Me.GroupBoxSections.Controls.Add(Me.descriptionSection)
        Me.GroupBoxSections.Controls.Add(Me.saveSection)
        Me.GroupBoxSections.Controls.Add(Me.delSection)
        Me.GroupBoxSections.Controls.Add(Me.atribuirSection)
        Me.GroupBoxSections.Location = New System.Drawing.Point(529, 770)
        Me.GroupBoxSections.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSections.Name = "GroupBoxSections"
        Me.GroupBoxSections.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSections.Size = New System.Drawing.Size(1185, 137)
        Me.GroupBoxSections.TabIndex = 288
        Me.GroupBoxSections.TabStop = False
        '
        'sectionDescription_lbl
        '
        Me.sectionDescription_lbl.AutoSize = True
        Me.sectionDescription_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionDescription_lbl.Location = New System.Drawing.Point(199, 37)
        Me.sectionDescription_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionDescription_lbl.Name = "sectionDescription_lbl"
        Me.sectionDescription_lbl.Size = New System.Drawing.Size(84, 17)
        Me.sectionDescription_lbl.TabIndex = 254
        Me.sectionDescription_lbl.Text = "Descrição*"
        '
        'descriptionSection
        '
        Me.descriptionSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descriptionSection.Location = New System.Drawing.Point(203, 58)
        Me.descriptionSection.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.descriptionSection.Name = "descriptionSection"
        Me.descriptionSection.Size = New System.Drawing.Size(569, 24)
        Me.descriptionSection.TabIndex = 248
        '
        'saveSection
        '
        Me.saveSection.AutoSize = True
        Me.saveSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveSection.Location = New System.Drawing.Point(1083, 96)
        Me.saveSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveSection.Name = "saveSection"
        Me.saveSection.Size = New System.Drawing.Size(55, 17)
        Me.saveSection.TabIndex = 251
        Me.saveSection.TabStop = True
        Me.saveSection.Text = "Gravar"
        '
        'delSection
        '
        Me.delSection.AutoSize = True
        Me.delSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delSection.Location = New System.Drawing.Point(985, 96)
        Me.delSection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.delSection.Name = "delSection"
        Me.delSection.Size = New System.Drawing.Size(58, 17)
        Me.delSection.TabIndex = 250
        Me.delSection.TabStop = True
        Me.delSection.Text = "Apagar"
        '
        'GroupBoxManagers
        '
        Me.GroupBoxManagers.Controls.Add(Me.managerPhotobox)
        Me.GroupBoxManagers.Controls.Add(Me.saveNewCard)
        Me.GroupBoxManagers.Controls.Add(Me.managerName_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.nfcCardCode)
        Me.GroupBoxManagers.Controls.Add(Me.nomeResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.nfcCardCode_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.managerCode_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.nfcResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.managerEmail_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.emailResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.managerPhone_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.telefoneResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.saveResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.delResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.funcaoResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.managerJob_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.downloadPhotoManager)
        Me.GroupBoxManagers.Controls.Add(Me.managerSectionAssigned_lbl)
        Me.GroupBoxManagers.Controls.Add(Me.sectionResponsavel)
        Me.GroupBoxManagers.Controls.Add(Me.resetSectionResponsavel)
        Me.GroupBoxManagers.Location = New System.Drawing.Point(531, 950)
        Me.GroupBoxManagers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxManagers.Name = "GroupBoxManagers"
        Me.GroupBoxManagers.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxManagers.Size = New System.Drawing.Size(1196, 302)
        Me.GroupBoxManagers.TabIndex = 287
        Me.GroupBoxManagers.TabStop = False
        '
        'saveNewCard
        '
        Me.saveNewCard.AutoSize = True
        Me.saveNewCard.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveNewCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.saveNewCard.Location = New System.Drawing.Point(820, 191)
        Me.saveNewCard.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveNewCard.Name = "saveNewCard"
        Me.saveNewCard.Size = New System.Drawing.Size(108, 17)
        Me.saveNewCard.TabIndex = 286
        Me.saveNewCard.TabStop = True
        Me.saveNewCard.Text = "save new card"
        '
        'managerName_lbl
        '
        Me.managerName_lbl.AutoSize = True
        Me.managerName_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerName_lbl.Location = New System.Drawing.Point(197, 30)
        Me.managerName_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerName_lbl.Name = "managerName_lbl"
        Me.managerName_lbl.Size = New System.Drawing.Size(57, 17)
        Me.managerName_lbl.TabIndex = 233
        Me.managerName_lbl.Text = "Nome*"
        '
        'nfcCardCode
        '
        Me.nfcCardCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nfcCardCode.Location = New System.Drawing.Point(824, 162)
        Me.nfcCardCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nfcCardCode.Name = "nfcCardCode"
        Me.nfcCardCode.Size = New System.Drawing.Size(327, 24)
        Me.nfcCardCode.TabIndex = 284
        '
        'nomeResponsavel
        '
        Me.nomeResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomeResponsavel.Location = New System.Drawing.Point(201, 50)
        Me.nomeResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nomeResponsavel.Name = "nomeResponsavel"
        Me.nomeResponsavel.Size = New System.Drawing.Size(949, 24)
        Me.nomeResponsavel.TabIndex = 23
        '
        'nfcCardCode_lbl
        '
        Me.nfcCardCode_lbl.AutoSize = True
        Me.nfcCardCode_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nfcCardCode_lbl.Location = New System.Drawing.Point(820, 142)
        Me.nfcCardCode_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.nfcCardCode_lbl.Name = "nfcCardCode_lbl"
        Me.nfcCardCode_lbl.Size = New System.Drawing.Size(115, 17)
        Me.nfcCardCode_lbl.TabIndex = 285
        Me.nfcCardCode_lbl.Text = "Código cartão*"
        '
        'managerCode_lbl
        '
        Me.managerCode_lbl.AutoSize = True
        Me.managerCode_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerCode_lbl.Location = New System.Drawing.Point(452, 142)
        Me.managerCode_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerCode_lbl.Name = "managerCode_lbl"
        Me.managerCode_lbl.Size = New System.Drawing.Size(82, 17)
        Me.managerCode_lbl.TabIndex = 235
        Me.managerCode_lbl.Text = "ID cartão*"
        '
        'nfcResponsavel
        '
        Me.nfcResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nfcResponsavel.Location = New System.Drawing.Point(456, 162)
        Me.nfcResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nfcResponsavel.Name = "nfcResponsavel"
        Me.nfcResponsavel.Size = New System.Drawing.Size(315, 24)
        Me.nfcResponsavel.TabIndex = 26
        '
        'managerEmail_lbl
        '
        Me.managerEmail_lbl.AutoSize = True
        Me.managerEmail_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerEmail_lbl.Location = New System.Drawing.Point(200, 80)
        Me.managerEmail_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerEmail_lbl.Name = "managerEmail_lbl"
        Me.managerEmail_lbl.Size = New System.Drawing.Size(53, 17)
        Me.managerEmail_lbl.TabIndex = 237
        Me.managerEmail_lbl.Text = "Email*"
        '
        'emailResponsavel
        '
        Me.emailResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailResponsavel.Location = New System.Drawing.Point(204, 101)
        Me.emailResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.emailResponsavel.Name = "emailResponsavel"
        Me.emailResponsavel.Size = New System.Drawing.Size(567, 24)
        Me.emailResponsavel.TabIndex = 24
        '
        'managerPhone_lbl
        '
        Me.managerPhone_lbl.AutoSize = True
        Me.managerPhone_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerPhone_lbl.Location = New System.Drawing.Point(820, 80)
        Me.managerPhone_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerPhone_lbl.Name = "managerPhone_lbl"
        Me.managerPhone_lbl.Size = New System.Drawing.Size(74, 17)
        Me.managerPhone_lbl.TabIndex = 239
        Me.managerPhone_lbl.Text = "Telefone*"
        '
        'telefoneResponsavel
        '
        Me.telefoneResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.telefoneResponsavel.Location = New System.Drawing.Point(824, 100)
        Me.telefoneResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.telefoneResponsavel.Name = "telefoneResponsavel"
        Me.telefoneResponsavel.Size = New System.Drawing.Size(327, 24)
        Me.telefoneResponsavel.TabIndex = 27
        '
        'saveResponsavel
        '
        Me.saveResponsavel.AutoSize = True
        Me.saveResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveResponsavel.Location = New System.Drawing.Point(1084, 260)
        Me.saveResponsavel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.saveResponsavel.Name = "saveResponsavel"
        Me.saveResponsavel.Size = New System.Drawing.Size(55, 17)
        Me.saveResponsavel.TabIndex = 29
        Me.saveResponsavel.TabStop = True
        Me.saveResponsavel.Text = "Gravar"
        '
        'delResponsavel
        '
        Me.delResponsavel.AutoSize = True
        Me.delResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delResponsavel.Location = New System.Drawing.Point(987, 260)
        Me.delResponsavel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.delResponsavel.Name = "delResponsavel"
        Me.delResponsavel.Size = New System.Drawing.Size(58, 17)
        Me.delResponsavel.TabIndex = 28
        Me.delResponsavel.TabStop = True
        Me.delResponsavel.Text = "Apagar"
        '
        'funcaoResponsavel
        '
        Me.funcaoResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.funcaoResponsavel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.funcaoResponsavel.FormattingEnabled = True
        Me.funcaoResponsavel.Items.AddRange(New Object() {"Escolha uma", "Conducteur", "Gestionnaire"})
        Me.funcaoResponsavel.Location = New System.Drawing.Point(204, 161)
        Me.funcaoResponsavel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.funcaoResponsavel.Name = "funcaoResponsavel"
        Me.funcaoResponsavel.Size = New System.Drawing.Size(227, 25)
        Me.funcaoResponsavel.TabIndex = 25
        '
        'managerJob_lbl
        '
        Me.managerJob_lbl.AutoSize = True
        Me.managerJob_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managerJob_lbl.Location = New System.Drawing.Point(200, 142)
        Me.managerJob_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managerJob_lbl.Name = "managerJob_lbl"
        Me.managerJob_lbl.Size = New System.Drawing.Size(67, 17)
        Me.managerJob_lbl.TabIndex = 247
        Me.managerJob_lbl.Text = "Função*"
        '
        'loading_status_sections
        '
        Me.loading_status_sections.AutoSize = True
        Me.loading_status_sections.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loading_status_sections.ForeColor = System.Drawing.Color.Red
        Me.loading_status_sections.Location = New System.Drawing.Point(189, 748)
        Me.loading_status_sections.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.loading_status_sections.Name = "loading_status_sections"
        Me.loading_status_sections.Size = New System.Drawing.Size(80, 17)
        Me.loading_status_sections.TabIndex = 278
        Me.loading_status_sections.Text = "aguarde..."
        '
        'sectionTitle
        '
        Me.sectionTitle.AutoSize = True
        Me.sectionTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionTitle.Location = New System.Drawing.Point(13, 746)
        Me.sectionTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionTitle.Name = "sectionTitle"
        Me.sectionTitle.Size = New System.Drawing.Size(165, 20)
        Me.sectionTitle.TabIndex = 268
        Me.sectionTitle.Text = "Secções de Obra"
        '
        'sectionsList
        '
        Me.sectionsList.BackColor = System.Drawing.Color.Honeydew
        Me.sectionsList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionsList.FormattingEnabled = True
        Me.sectionsList.HorizontalScrollbar = True
        Me.sectionsList.ItemHeight = 17
        Me.sectionsList.Location = New System.Drawing.Point(13, 769)
        Me.sectionsList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sectionsList.Name = "sectionsList"
        Me.sectionsList.Size = New System.Drawing.Size(469, 106)
        Me.sectionsList.TabIndex = 267
        '
        'divider2
        '
        Me.divider2.BackColor = System.Drawing.Color.LimeGreen
        Me.divider2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider2.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider2.Location = New System.Drawing.Point(523, 761)
        Me.divider2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider2.Name = "divider2"
        Me.divider2.Size = New System.Drawing.Size(1191, 4)
        Me.divider2.TabIndex = 264
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.LimeGreen
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label30.Location = New System.Drawing.Point(537, 1604)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(1191, 4)
        Me.Label30.TabIndex = 263
        Me.Label30.Visible = False
        '
        'divider3
        '
        Me.divider3.BackColor = System.Drawing.Color.LimeGreen
        Me.divider3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider3.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider3.Location = New System.Drawing.Point(531, 942)
        Me.divider3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider3.Name = "divider3"
        Me.divider3.Size = New System.Drawing.Size(1191, 4)
        Me.divider3.TabIndex = 262
        '
        'divider4
        '
        Me.divider4.BackColor = System.Drawing.Color.LimeGreen
        Me.divider4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider4.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider4.Location = New System.Drawing.Point(531, 1280)
        Me.divider4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider4.Name = "divider4"
        Me.divider4.Size = New System.Drawing.Size(1191, 4)
        Me.divider4.TabIndex = 261
        '
        'managersTitle
        '
        Me.managersTitle.AutoSize = True
        Me.managersTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managersTitle.Location = New System.Drawing.Point(13, 945)
        Me.managersTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managersTitle.Name = "managersTitle"
        Me.managersTitle.Size = New System.Drawing.Size(138, 20)
        Me.managersTitle.TabIndex = 258
        Me.managersTitle.Text = "Responsáveis"
        '
        'companyTitle
        '
        Me.companyTitle.AutoSize = True
        Me.companyTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyTitle.Location = New System.Drawing.Point(13, 1289)
        Me.companyTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyTitle.Name = "companyTitle"
        Me.companyTitle.Size = New System.Drawing.Size(101, 20)
        Me.companyTitle.TabIndex = 257
        Me.companyTitle.Text = "Empresas"
        '
        'EmpresaList
        '
        Me.EmpresaList.BackColor = System.Drawing.Color.Honeydew
        Me.EmpresaList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpresaList.FormattingEnabled = True
        Me.EmpresaList.HorizontalScrollbar = True
        Me.EmpresaList.ItemHeight = 17
        Me.EmpresaList.Location = New System.Drawing.Point(17, 1312)
        Me.EmpresaList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmpresaList.Name = "EmpresaList"
        Me.EmpresaList.Size = New System.Drawing.Size(469, 191)
        Me.EmpresaList.TabIndex = 256
        '
        'sectionsFileTitle
        '
        Me.sectionsFileTitle.AutoSize = True
        Me.sectionsFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sectionsFileTitle.Location = New System.Drawing.Point(517, 736)
        Me.sectionsFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.sectionsFileTitle.Name = "sectionsFileTitle"
        Me.sectionsFileTitle.Size = New System.Drawing.Size(102, 25)
        Me.sectionsFileTitle.TabIndex = 252
        Me.sectionsFileTitle.Text = "Secções"
        '
        'ManagerList
        '
        Me.ManagerList.BackColor = System.Drawing.Color.Honeydew
        Me.ManagerList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManagerList.FormattingEnabled = True
        Me.ManagerList.HorizontalScrollbar = True
        Me.ManagerList.ItemHeight = 17
        Me.ManagerList.Location = New System.Drawing.Point(13, 969)
        Me.ManagerList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ManagerList.Name = "ManagerList"
        Me.ManagerList.Size = New System.Drawing.Size(469, 208)
        Me.ManagerList.TabIndex = 22
        '
        'managersFileTitle
        '
        Me.managersFileTitle.AutoSize = True
        Me.managersFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.managersFileTitle.Location = New System.Drawing.Point(525, 917)
        Me.managersFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.managersFileTitle.Name = "managersFileTitle"
        Me.managersFileTitle.Size = New System.Drawing.Size(165, 25)
        Me.managersFileTitle.TabIndex = 203
        Me.managersFileTitle.Text = "Responsáveis"
        '
        'companyFileTitle
        '
        Me.companyFileTitle.AutoSize = True
        Me.companyFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyFileTitle.Location = New System.Drawing.Point(528, 1255)
        Me.companyFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.companyFileTitle.Name = "companyFileTitle"
        Me.companyFileTitle.Size = New System.Drawing.Size(246, 25)
        Me.companyFileTitle.TabIndex = 201
        Me.companyFileTitle.Text = "Empresa contratante"
        '
        'mandatoryFields
        '
        Me.mandatoryFields.AutoSize = True
        Me.mandatoryFields.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatoryFields.Location = New System.Drawing.Point(1384, 48)
        Me.mandatoryFields.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.mandatoryFields.Name = "mandatoryFields"
        Me.mandatoryFields.Size = New System.Drawing.Size(306, 17)
        Me.mandatoryFields.TabIndex = 200
        Me.mandatoryFields.Text = "Campos marcados com * são obrigatórios"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(524, 33)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1191, 4)
        Me.divider.TabIndex = 199
        '
        'siteFileTitle
        '
        Me.siteFileTitle.AutoSize = True
        Me.siteFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteFileTitle.Location = New System.Drawing.Point(521, 9)
        Me.siteFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteFileTitle.Name = "siteFileTitle"
        Me.siteFileTitle.Size = New System.Drawing.Size(166, 25)
        Me.siteFileTitle.TabIndex = 198
        Me.siteFileTitle.Text = "Ficha de Obra"
        '
        'siteTitle
        '
        Me.siteTitle.AutoSize = True
        Me.siteTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteTitle.Location = New System.Drawing.Point(13, 5)
        Me.siteTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteTitle.Name = "siteTitle"
        Me.siteTitle.Size = New System.Drawing.Size(64, 20)
        Me.siteTitle.TabIndex = 194
        Me.siteTitle.Text = "Obras"
        '
        'ObrasList
        '
        Me.ObrasList.BackColor = System.Drawing.Color.Honeydew
        Me.ObrasList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObrasList.FormattingEnabled = True
        Me.ObrasList.HorizontalScrollbar = True
        Me.ObrasList.ItemHeight = 17
        Me.ObrasList.Location = New System.Drawing.Point(13, 62)
        Me.ObrasList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ObrasList.Name = "ObrasList"
        Me.ObrasList.Size = New System.Drawing.Size(469, 633)
        Me.ObrasList.TabIndex = 3
        '
        'updateLink
        '
        Me.updateLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.updateLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateLink.Location = New System.Drawing.Point(-81, 1)
        Me.updateLink.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(156, 23)
        Me.updateLink.TabIndex = 2
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Actualizar"
        Me.updateLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'site_mng_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1940, 1009)
        Me.Controls.Add(Me.Panel_geral)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "site_mng_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestão de Obras"
        CType(Me.CompanyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.managerPhotobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_geral.ResumeLayout(False)
        Me.Panel_geral.PerformLayout()
        Me.GroupBoxHourly.ResumeLayout(False)
        Me.GroupBoxHourly.PerformLayout()
        Me.GroupBoxSite.ResumeLayout(False)
        Me.GroupBoxSite.PerformLayout()
        Me.GroupBoxCompany.ResumeLayout(False)
        Me.GroupBoxCompany.PerformLayout()
        Me.GroupBoxSections.ResumeLayout(False)
        Me.GroupBoxSections.PerformLayout()
        Me.GroupBoxManagers.ResumeLayout(False)
        Me.GroupBoxManagers.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents loading_status_company As Label
    Friend WithEvents loading_status_manager As Label
    Friend WithEvents loading_status As Label
    Friend WithEvents downloadCompanyLogo As LinkLabel
    Friend WithEvents CompanyLogo As PictureBox
    Friend WithEvents downloadPhotoManager As LinkLabel
    Friend WithEvents managerPhotobox As PictureBox
    Friend WithEvents atribuirSection As LinkLabel
    Friend WithEvents resetSectionResponsavel As LinkLabel
    Friend WithEvents sectionResponsavel As TextBox
    Friend WithEvents managerSectionAssigned_lbl As Label
    Friend WithEvents atribuirEmpresa As LinkLabel
    Friend WithEvents Panel_geral As Panel
    Friend WithEvents loading_status_sections As Label
    Friend WithEvents sectionTitle As Label
    Friend WithEvents sectionsList As ListBox
    Friend WithEvents resetEmpresa As LinkLabel
    Friend WithEvents divider2 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents divider3 As Label
    Friend WithEvents divider4 As Label
    Friend WithEvents EmpresaAtribuida As TextBox
    Friend WithEvents siteCompanyAssigned_lbl As Label
    Friend WithEvents managersTitle As Label
    Friend WithEvents companyTitle As Label
    Friend WithEvents EmpresaList As ListBox
    Friend WithEvents delSection As LinkLabel
    Friend WithEvents saveSection As LinkLabel
    Friend WithEvents descriptionSection As TextBox
    Friend WithEvents sectionDescription_lbl As Label
    Friend WithEvents sectionsFileTitle As Label
    Friend WithEvents managerJob_lbl As Label
    Friend WithEvents funcaoResponsavel As ComboBox
    Friend WithEvents duracaoInicio As DateTimePicker
    Friend WithEvents duracaoFim As DateTimePicker
    Friend WithEvents delResponsavel As LinkLabel
    Friend WithEvents saveResponsavel As LinkLabel
    Friend WithEvents telefoneResponsavel As TextBox
    Friend WithEvents managerPhone_lbl As Label
    Friend WithEvents emailResponsavel As TextBox
    Friend WithEvents managerEmail_lbl As Label
    Friend WithEvents nfcResponsavel As TextBox
    Friend WithEvents managerCode_lbl As Label
    Friend WithEvents nomeResponsavel As TextBox
    Friend WithEvents managerName_lbl As Label
    Friend WithEvents delEmpresa As LinkLabel
    Friend WithEvents saveEmpresa As LinkLabel
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
    Friend WithEvents distanciaObra As TextBox
    Friend WithEvents siteDistance_lbl As Label
    Friend WithEvents siteEnd_lbl As Label
    Friend WithEvents siteStart_lbl As Label
    Friend WithEvents siteDuration_lbl As Label
    Friend WithEvents LongitudeObra As TextBox
    Friend WithEvents latitudeObra As TextBox
    Friend WithEvents siteLongitude_lbl As Label
    Friend WithEvents siteLatitude_lbl As Label
    Friend WithEvents siteGpsCoordinates_lbl As Label
    Friend WithEvents managersFileTitle As Label
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
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents delObra As LinkLabel
    Friend WithEvents saveObra As LinkLabel
    Friend WithEvents nomeObra As TextBox
    Friend WithEvents siteName_lbl As Label
    Friend WithEvents authRange As TextBox
    Friend WithEvents siteAuthRadius_lbl As Label
    Friend WithEvents site_ended As CheckBox
    Friend WithEvents saveNewCard As LinkLabel
    Friend WithEvents nfcCardCode As TextBox
    Friend WithEvents nfcCardCode_lbl As Label
    Public WithEvents ManagerList As ListBox
    Friend WithEvents GroupBoxSite As GroupBox
    Friend WithEvents GroupBoxCompany As GroupBox
    Friend WithEvents GroupBoxSections As GroupBox
    Friend WithEvents GroupBoxManagers As GroupBox
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
End Class
