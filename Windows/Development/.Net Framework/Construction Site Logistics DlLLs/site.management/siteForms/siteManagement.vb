Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.SmartCards.GUI
Imports ConstructionSiteLogistics.Gui.Libraries

Public Class site_mng_frm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private countryList, countryListings As New Dictionary(Of String, String)
    Private languageListSelection As New List(Of Integer)

    Private query_site, query_company, query_sections, db_sections As Dictionary(Of String, List(Of String))

    Public Shared query_manager As Dictionary(Of String, List(Of String))
    Public Shared managerListPos As Integer = -1
    Private mask As PictureBox = Nothing
    Private loaded As Boolean = False
    Private updated As Boolean = False

    Dim t As Threading.Thread = Nothing
    Private response As String = ""
    Private empresaIndex As Integer = 0
    Private sectionIndex As Integer = 0

    Private WithEvents initializeSmartCardForm As initializeSmartCard
    Private WithEvents nfc_card As IsmartCard

    Private posToLoad As Integer = -1
    Private inactiveWorkerPosZero As Integer = 0
    Private WithEvents DataRequests As IDataSiteManagementRequests
    Private taskRequest As String = ""
    Private mainForm As MainMdiForm

    Private WithEvents sendPhotoCompanyHttp As HttpDataFilesUpload
    Private WithEvents sendPhotoManagerHttp As HttpDataFilesUpload

    Private Sub Panel_geral_Paint(sender As Object, e As PaintEventArgs) Handles Panel_geral.Paint

    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New(_mainForm As MainMdiForm)
        mainForm = _mainForm
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Application.DoEvents()
        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()
    End Sub
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub site_mng_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        saveNewCard.Enabled = False
        mainForm.childForm = "site"
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        Me.SuspendLayout()
        loading_status.Text = ""
        loading_status_company.Text = ""
        loading_status_contractor_manager.Text = ""
        loading_status_sections.Text = ""

        siteFileTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        sectionsFileTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        contractorManagersFileTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        companyFileTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = stateCore.dividerColor
        divider2.BackColor = stateCore.dividerColor
        divider3.BackColor = stateCore.dividerColor
        divider4.BackColor = stateCore.dividerColor

        siteTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        sectionTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        contractorManagersTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        companyTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        loading_status.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_company.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_contractor_manager.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_sections.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        ObrasList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contratorManagerList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionsList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        EmpresaList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        resetEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        atribuirSection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadPhotoContractorManager.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerResetSection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadCompanyLogo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        atribuirEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        nomeEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        emailEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        tvaEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        telefoneEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        moradaEmpresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerCardId.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        conractorManagerEmail.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerName.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerPhone.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerSection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerJobAuthority.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        descriptionSection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        nomeObra.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siglaObra.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        moradaObra.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionLatitude.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionLongitude.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionDistance.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionRadius.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_ended.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        EmpresaAtribuida.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFim.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        refcontrato.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        mandatoryFields.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteAddress_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionRadius_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteCompanyAssigned_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteDuration_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteEnd_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionGpsCoordinates_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionLatitude_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionLongitude_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteName_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteRefContract_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteStart_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectiondistance_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteInitials_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionDescription_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerCardId_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerEmail_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerJobAuthority_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerPhone_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerName_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerJobAuthority_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyAddress_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyEmail_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyTva_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyName_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyPhone_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerSectionAssigned_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveNewCard.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerCardCode_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractorManagerCardCode.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        cranemanHourly.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinistHourly.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        regieHourly.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        craneman_weekends.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinist_weekends.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_weekends.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        craneman_after_hours.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinist_after_hours.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_after_hours.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        GroupBoxHourly.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Bold)
        unitshourly1.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly2.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly3.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly4.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly5.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly6.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly7.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly8.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly9.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        regieHourly_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinistHourly_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        cranemanHourly_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        normal_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        weekends_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        after_hours_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_all_lang.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_default_lang.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        primaryLanguage.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        setPrimaryLang.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        languagesProject_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        sitesListSelection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(updateBtn, translations.getText("updateLink"))

        Dim SaveEmpresaToolTip As New ToolTip()
        SaveEmpresaToolTip.SetToolTip(saveEmpresaBtn, translations.getText("saveLink"))

        Dim saveObraToolTip As New ToolTip()
        saveObraToolTip.SetToolTip(saveObraBtn, translations.getText("saveLink"))

        Dim saveSectionToolTip As New ToolTip()
        saveSectionToolTip.SetToolTip(saveSectionBtn, translations.getText("saveLink"))

        Dim saveResponsavelToolTip As New ToolTip()
        saveResponsavelToolTip.SetToolTip(saveContractorManagerBtn, translations.getText("saveLink"))

        Dim delEmpresaToolTip As New ToolTip()
        delEmpresaToolTip.SetToolTip(delEmpresaBtn, translations.getText("delLink"))

        Dim delObraToolTip As New ToolTip()
        delObraToolTip.SetToolTip(delObraBtn, translations.getText("delLink"))

        Dim delSectionToolTip As New ToolTip()
        delSectionToolTip.SetToolTip(delSectionBtn, translations.getText("delLink"))

        Dim delResponsavelToolTip As New ToolTip()
        delResponsavelToolTip.SetToolTip(delContractorManagerBtn, translations.getText("delLink"))

        mandatoryFields.Text = translations.getText("mandatoryFields")
        resetEmpresa.Text = translations.getText("resetLink")
        contractorManagerResetSection.Text = translations.getText("resetLink")
        downloadCompanyLogo.Text = translations.getText("downloadLink")
        downloadPhotoContractorManager.Text = translations.getText("downloadLink")
        saveNewCard.Text = translations.getText("saveLink")
        show_all_lang.Text = translations.getText("showAllLink")
        show_default_lang.Text = translations.getText("showDefaultLink")
        setPrimaryLang.Text = translations.getText("setPrimaryLink")
        primaryLanguage.Text = translations.getText("primaryLanguage") & ": - -"

        translations.load("workers")
        sitesListSelection.Items.Add(translations.getText("workerActive"))
        sitesListSelection.Items.Add(translations.getText("workerInactive"))
        sitesListSelection.Items.Add(translations.getText("workerAll"))
        sitesListSelection.SelectedIndex = 0

        translations.load("siteManagement")
        atribuirEmpresa.Text = translations.getText("siteAssignCompany")
        atribuirSection.Text = translations.getText("siteAssignSection")
        siteAddress_lbl.Text = translations.getText("siteAddress") & "*"
        sectionRadius_lbl.Text = translations.getText("siteAuthRadius") & "* (m)"
        siteCompanyAssigned_lbl.Text = translations.getText("siteCompanyAssigned") & "*"
        siteDuration_lbl.Text = translations.getText("siteDuration") & "*"
        siteEnd_lbl.Text = translations.getText("siteDateEnd")
        sectionGpsCoordinates_lbl.Text = translations.getText("siteGpsCoordinates") & "*"
        sectionLatitude_lbl.Text = translations.getText("siteLatitude")
        sectionLongitude_lbl.Text = translations.getText("siteLongitude")
        siteName_lbl.Text = translations.getText("siteName") & "*"
        siteRefContract_lbl.Text = translations.getText("siteContractRef")
        siteStart_lbl.Text = translations.getText("siteDateStart")
        sectiondistance_lbl.Text = translations.getText("siteDistance") & "* (Km)"
        siteInitials_lbl.Text = translations.getText("siteInitials") & "*"
        sectionDescription_lbl.Text = translations.getText("siteSectionName") & "*"
        contractorManagerCardId_lbl.Text = translations.getText("SiteManagerId") & "*"
        contractorManagerEmail_lbl.Text = translations.getText("siteManagerEmail") & "*"
        contractorManagerJobAuthority_lbl.Text = translations.getText("SiteManagerJob") & "*"
        contractorManagerPhone_lbl.Text = translations.getText("SiteManagerPhone") & "*"
        contractorManagerName_lbl.Text = translations.getText("siteManagerName") & "*"
        contractorManagerJobAuthority_lbl.Text = translations.getText("SiteManagerJob") & "*"
        contractorManagerSectionAssigned_lbl.Text = translations.getText("siteSectionAssigned") & "*"
        companyAddress_lbl.Text = translations.getText("siteCompanyAddress") & "*"
        companyEmail_lbl.Text = translations.getText("siteManagerEmail") & "*"
        companyTva_lbl.Text = translations.getText("siteCompanyVat") & "*"
        companyName_lbl.Text = translations.getText("siteCompanyName") & "*"
        companyPhone_lbl.Text = translations.getText("SiteManagerPhone") & "*"
        siteFileTitle.Text = translations.getText("SiteFileTitle")
        sectionsFileTitle.Text = translations.getText("SiteSectionsFileTitle")
        contractorManagersFileTitle.Text = translations.getText("SiteManagerFileTitle")
        companyFileTitle.Text = translations.getText("SiteCompanyFileTitle")
        siteTitle.Text = translations.getText("SiteListTitle")
        sectionTitle.Text = translations.getText("SiteSectionListTitle")
        contractorManagersTitle.Text = translations.getText("SiteManagerListTitle")
        companyTitle.Text = translations.getText("SiteCompanyListTitle")
        site_ended.Text = translations.getText("SiteWorksEnded")
        regieHourly_lbl.Text = translations.getText("regieHourly") & "*"
        machinistHourly_lbl.Text = translations.getText("machinistHourly") & "*"
        cranemanHourly_lbl.Text = translations.getText("cranemanHourly") & "*"
        normal_time_lbl.Text = translations.getText("normalTime")
        weekends_time_lbl.Text = translations.getText("weekendsTime")
        after_hours_time_lbl.Text = translations.getText("afterHoursTime")
        languagesProject_lbl.Text = translations.getText("languagesProject")

        contractorManagerJobAuthority.Items.Clear()
        contractorManagerJobAuthority.Items.Add(translations.getText("siteManagerSelectOne"))
        contractorManagerJobAuthority.Items.Add(translations.getText("siteManagerConducteur"))
        contractorManagerJobAuthority.Items.Add(translations.getText("siteManagerGestionnaire"))

        translations.load("workers")
        contractorManagerCardCode_lbl.Text = translations.getText("cardAuthCode") & "*"

        translations.load("siteActivity")
        GroupBoxHourly.Text = translations.getText("tasksTableRowWorkByHour")

        unitshourly1.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly2.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly3.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly4.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly5.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly6.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly7.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly8.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"
        unitshourly9.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol & "/h"

        Dim width As Integer = Me.Width
        Dim height As Integer = Me.Height

        Panel_geral.Width = width - 20
        Panel_geral.Height = height - 20

        loading_status_sections.Location = New Point(sectionTitle.Location.X + 5 + sectionTitle.Width, loading_status_sections.Location.Y)
        loading_status_contractor_manager.Location = New Point(contractorManagersTitle.Location.X + 5 + contractorManagersTitle.Width, loading_status_contractor_manager.Location.Y)
        loading_status_company.Location = New Point(companyTitle.Location.X + 5 + companyTitle.Width, loading_status_company.Location.Y)
        mandatoryFields.Location = New Point(divider.Location.X + divider.Width - mandatoryFields.Width, mandatoryFields.Location.Y)

        siteStart_lbl.Location = New Point(duracaoInicio.Location.X - siteStart_lbl.Width, siteStart_lbl.Location.Y)
        siteEnd_lbl.Location = New Point(duracaoFim.Location.X - siteEnd_lbl.Width, siteEnd_lbl.Location.Y)
        'siteLatitude_lbl.Location = New Point(latitudeObra.Location.X - siteLatitude_lbl.Width, siteLatitude_lbl.Location.Y)
        'siteLongitude_lbl.Location = New Point(LongitudeObra.Location.X - siteLongitude_lbl.Width, siteLongitude_lbl.Location.Y)
        'siteDistance_lbl.Location = New Point(distanciaObra.Location.X - siteDistance_lbl.Width, siteDistance_lbl.Location.Y)
        'siteAuthRadius_lbl.Location = New Point(authRange.Location.X - siteAuthRadius_lbl.Width, siteAuthRadius_lbl.Location.Y)

        siteDuration_lbl.Location = New Point(duracaoInicio.Location.X + siteDuration_lbl.Width / 3 - siteDuration_lbl.Width, siteDuration_lbl.Location.Y)
        'siteGpsCoordinates_lbl.Location = New Point(latitudeObra.Location.X + siteGpsCoordinates_lbl.Width / 3 - siteGpsCoordinates_lbl.Width, siteGpsCoordinates_lbl.Location.Y)

        duracaoInicio.CustomFormat = "yyyy-MM-dd"
        duracaoFim.CustomFormat = "yyyy-MM-dd"
        GroupBoxCompany.Enabled = False
        GroupBoxContractorManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = False
        Me.ResumeLayout()
    End Sub

    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "site.management.dll", "siteManagementDataRequests"), IDataSiteManagementRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        loaded = False
        countryList.Clear()

        Dim ci As CultureInfo
        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            If Not countryListings.ContainsKey(ci.DisplayName) Then
                countryListings.Add(newKeyValuePair.Key, newKeyValuePair.Value)
            End If
        Next ci

        clearFields()
        load_list()
        LoadListCompany()
    End Sub

    Private Sub removeMask()
        If loaded Then
            Exit Sub
        End If

        loaded = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()
    End Sub

    Sub load_list()
        mainForm.busy.Show()

        enableButtonsAndLinks(Me, False)
        GroupBoxCompany.Enabled = False
        GroupBoxContractorManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = False

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites,sections")
        vars.Add("override", "true")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadSiteInitialData()

    End Sub
    Private Sub DataRequests_getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSiteInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim translationsSite As languageTranslations
        translationsSite = New languageTranslations(stateCore)
        translationsSite.load("siteManagement")

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_site = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(query_site) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translationsSite.getText("SiteListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If
        db_sections = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(db_sections) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translationsSite.getText("SiteSectionListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        sectionsList.Items.Clear()
        sectionsList.Items.Add(translationsSite.getText("siteSectionSelectAdd"))

        ObrasList.Items.Clear()
        ObrasList.Items.Add(translationsSite.getText("siteSelectAdd"))
        updated = True
        loading_status.Text = ""
        ObrasList.SelectedIndex = 0
        If Not Me.IsHandleCreated Then
            translationsSite.load("system")
            mainForm.statusMessage = translationsSite.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            setPrimaryLang.Enabled = False

            removeMask()
            GroupBoxSite.Enabled = False
            Exit Sub
        End If
        If errorFlag Then
            translationsSite.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translationsSite.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()

            enableButtonsAndLinks(Me, True)
            GroupBoxSite.Enabled = False
            setPrimaryLang.Enabled = False

            removeMask()
            Exit Sub
        End If

        For i = 0 To query_site.Item("cod_site").Count - 1
            If sitesListSelection.SelectedIndex.Equals(0) And query_site.Item("active")(i).Equals("1") Then
                ObrasList.Items.Add(query_site.Item("name")(i))
            ElseIf sitesListSelection.SelectedIndex.Equals(1) And query_site.Item("active")(i).Equals("0") Then
                If inactiveWorkerPosZero.Equals(0) Then
                    inactiveWorkerPosZero = i
                End If
                ObrasList.Items.Add(query_site.Item("name")(i))
            ElseIf sitesListSelection.SelectedIndex.Equals(2) Then
                ObrasList.Items.Add(query_site.Item("name")(i))
            End If
        Next i


        GetAllCountryLanguages()

        enableButtonsAndLinks(Me, True)
        DisableFieldsManager(False)
        DisableFieldsSections(False)
        GroupBoxCompany.Enabled = False
        GroupBoxContractorManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = True
        mainForm.busy.Close(True)
        removeMask()
        setPrimaryLang.Enabled = False
    End Sub



    Public Sub GetAllCountryLanguages(Optional SiteListIndex As Integer = -1)
        ' Iterate the Framework Cultures...
        Dim shortcountryList As New List(Of String)
        If SiteListIndex.Equals(-1) Then
            shortcountryList.Add("nl")
            shortcountryList.Add("en")
            shortcountryList.Add("fr")
            shortcountryList.Add("pt")

        ElseIf Not IsNothing(query_site) Then
            Dim numLangs = query_site.Item("project_languages")(SiteListIndex).ToString.Split(",")

            For i = 0 To numLangs.Length - 1
                shortcountryList.Add(numLangs(i))
            Next i
            If shortcountryList.Count = 0 Then
                SiteListIndex = -2
                shortcountryList.Add("nl")
                shortcountryList.Add("en")
                shortcountryList.Add("fr")
                shortcountryList.Add("pt")
            End If
        End If
        languagesList.Items.Clear()
        countryList.Clear()

        Dim ci As CultureInfo
        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            If show_all_lang.Checked Then
                If Not countryList.ContainsKey(ci.DisplayName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    languagesList.Items.Add(ci.DisplayName)
                End If
            ElseIf SiteListIndex.Equals(-1) Then
                If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    languagesList.Items.Add(ci.DisplayName)
                End If
            ElseIf SiteListIndex.Equals(-2) Then
                If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    languagesList.Items.Add(ci.DisplayName)
                End If
            Else
                If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    languagesList.Items.Add(ci.DisplayName)
                    languagesList.SetSelected(languagesList.Items.Count - 1, True)
                End If
            End If
        Next ci
    End Sub

    Sub LoadListCompany()
        translations.load("commonForm")
        loading_status_company.Text = translations.getText("wait") & "..."

        enableButtonsAndLinks(Me, False)
        GroupBoxCompany.Enabled = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "company")
        Dim misc As New Dictionary(Of String, String)
        misc.Add("task", "companies")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, misc, Nothing)
        DataRequests.loadSiteCompanyInitialData()

    End Sub
    Private Sub DataRequests_getResponseCompaniesInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseCompaniesInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        Dim translationsSite As languageTranslations
        translationsSite = New languageTranslations(stateCore)
        translationsSite.load("siteManagement")

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_company = request.ConvertDataToArray("company", stateCore.querySiteContractorFields, response)
        If IsNothing(query_company) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translationsSite.getText("SiteCompanyListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        translationsSite.load("siteManagement")
        EmpresaList.Items.Clear()
        EmpresaList.Items.Add(translationsSite.getText("siteCompanySelectAdd"))
        loading_status_company.Text = ""
        EmpresaList.SelectedIndex = 0
        EmpresaList.Enabled = True
        contratorManagerList.Items.Clear()
        contratorManagerList.Items.Add(translationsSite.getText("siteManagerSelectAdd"))
        contractorManagerJobAuthority.SelectedIndex = 0
        updated = True
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translationsSite.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxCompany.Enabled = True
            Exit Sub
        End If
        If errorFlag Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translationsSite.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxCompany.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_company.Item("nome").Count - 1
            EmpresaList.Items.Add(query_company.Item("nome")(i))
        Next

        mainForm.busy.Close(True)
        enableButtonsAndLinks(Me, True)
        GroupBoxCompany.Enabled = True
    End Sub


    Sub LoadListManager()
        translations.load("commonForm")
        loading_status_contractor_manager.Text = translations.getText("wait") & "..."
        contratorManagerList.Enabled = False
        enableButtonsAndLinks(Me, False)
        GroupBoxContractorManagers.Enabled = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "manager")
        vars.Add("site", query_site.Item("cod_site")(posToLoad))
        Dim misc As New Dictionary(Of String, String)
        misc.Add("task", "companies")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, misc, Nothing)
        DataRequests.loadSiteManagerInitialData()
    End Sub
    Private Sub DataRequests_getResponseManagersInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseManagersInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim translationsSite As languageTranslations
        translationsSite = New languageTranslations(stateCore)
        translationsSite.load("siteManagement")

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_manager = request.ConvertDataToArray("manager", stateCore.querySiteManagerFields, response)
        If IsNothing(query_manager) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translationsSite.getText("SiteManagerListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        contratorManagerList.Items.Clear()
        contratorManagerList.Items.Add(translationsSite.getText("siteManagerSelectAdd"))
        loading_status_contractor_manager.Text = ""
        contratorManagerList.SelectedIndex = 0
        contratorManagerList.Enabled = True
        updated = True
        If Not Me.IsHandleCreated Then
            translationsSite.load("system")
            mainForm.statusMessage = translationsSite.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxContractorManagers.Enabled = True
            Exit Sub
        End If
        If errorFlag Then
            translationsSite.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translationsSite.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxContractorManagers.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_manager.Item("name").Count - 1
            contratorManagerList.Items.Add(query_manager.Item("name")(i))
        Next

        mainForm.busy.Close(True)
        enableButtonsAndLinks(Me, True)
        GroupBoxContractorManagers.Enabled = True
    End Sub


    Sub LoadListSections()
        translations.load("commonForm")
        loading_status_sections.Text = translations.getText("wait") & "..."
        sectionsList.Enabled = False
        enableButtonsAndLinks(Me, False)
        GroupBoxSections.Enabled = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sections")
        vars.Add("site", query_site.Item("cod_site")(posToLoad))
        Dim misc As New Dictionary(Of String, String)
        misc.Add("task", "companies")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, misc, Nothing)
        DataRequests.loadSiteSectionInitialData()
    End Sub
    Private Sub DataRequests_getResponseSectionsInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSectionsInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim translationsSite As languageTranslations
        translationsSite = New languageTranslations(stateCore)
        translationsSite.load("siteManagement")

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_sections = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(query_sections) Then
            errorMsg = GetMessage(request.errorMessage)
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        loading_status_sections.Text = ""
        sectionsList.Items.Clear()
        sectionsList.Items.Add(translationsSite.getText("siteSectionSelectAdd"))
        sectionsList.SelectedIndex = 0
        sectionsList.Enabled = True
        updated = True
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translationsSite.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxSections.Enabled = True
            Exit Sub
        End If
        If errorFlag Then
            translationsSite.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translationsSite.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxSections.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_sections.Item("description").Count - 1
            sectionsList.Items.Add(query_sections.Item("description")(i))
        Next
        mainForm.busy.Close(True)
        enableButtonsAndLinks(Me, True)
        GroupBoxSections.Enabled = True
    End Sub

    Sub clearFields()
        delObraBtn.Enabled = False
        resetEmpresa.Enabled = False
        contractorManagerResetSection.Enabled = False
        atribuirEmpresa.Enabled = False
        atribuirSection.Enabled = False

        show_all_lang.Checked = False
        show_default_lang.Checked = False
        moradaObra.Text = ""
        siglaObra.Text = ""
        sectionDistance.Text = ""
        sectionLatitude.Text = ""
        sectionLongitude.Text = ""
        nomeObra.Text = ""
        refcontrato.Text = ""
        EmpresaAtribuida.Text = ""
        sectionRadius.Text = ""
        regieHourly.Text = ""
        cranemanHourly.Text = ""
        machinistHourly.Text = ""
        regie_weekends.Text = ""
        craneman_weekends.Text = ""
        machinist_weekends.Text = ""
        regie_after_hours.Text = ""
        craneman_after_hours.Text = ""
        machinist_after_hours.Text = ""
        translations.load("commonForm")
        primaryLanguage.Text = translations.getText("primaryLanguage") & ": - -"

        GetAllCountryLanguages()
        duracaoInicio.Value = DateTime.Now
        duracaoFim.Value = DateTime.Now
        translations.load("siteManagement")
        contratorManagerList.Items.Clear()
        contratorManagerList.Items.Add(translations.getText("siteManagerSelectAdd"))
        clearFieldsManager()
        clearFieldsEmpresas()
        clearFieldsSections()
    End Sub

    Sub clearFieldsManager()
        contractorManagerName.Text = ""
        conractorManagerEmail.Text = ""
        contractorManagerCardId.Text = ""
        contractorManagerCardCode.Text = ""
        contractorManagerPhone.Text = ""
        contractorManagerSection.Text = ""
        contractorManagerJobAuthority.SelectedIndex = 0
        delContractorManagerBtn.Enabled = False
        contractorManagerResetSection.Enabled = False
        downloadPhotoContractorManager.Enabled = False
        contractorManagerPhotobox.Image = Image.FromFile(mainForm.state.imagesPath & "engineer.png")

    End Sub
    Sub DisableFieldsManager(b As Boolean)
        contractorManagerName.Enabled = b
        conractorManagerEmail.Enabled = b
        contractorManagerCardId.Enabled = b
        contractorManagerPhone.Enabled = b
        contractorManagerJobAuthority.Enabled = b
        saveContractorManagerBtn.Enabled = b
        contratorManagerList.Enabled = b
        downloadPhotoContractorManager.Enabled = b

    End Sub

    Sub clearFieldsEmpresas()
        nomeEmpresa.Text = ""
        tvaEmpresa.Text = ""
        emailEmpresa.Text = ""
        telefoneEmpresa.Text = ""
        moradaEmpresa.Text = ""
        delEmpresaBtn.Enabled = False
        atribuirEmpresa.Enabled = False
        CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & "companyLogo.png")
        downloadCompanyLogo.Enabled = False

    End Sub

    Sub DisableFieldsSections(b As Boolean)
        sectionsList.Enabled = b
        descriptionSection.Enabled = b
        saveSectionBtn.Enabled = b
        delSectionBtn.Enabled = b
    End Sub

    Sub clearFieldsSections()
        descriptionSection.Text = ""
        delSectionBtn.Enabled = False
        atribuirSection.Enabled = False
    End Sub

    Private Sub saveObraBtn_Click(sender As Object, e As EventArgs) Handles saveObraBtn.Click
        Dim msgbox As messageBoxForm

        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        translations.load("siteManagement")

        If nomeObra.Text.Equals("") Then
            nomeObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteName")
        End If
        If siglaObra.Text.Equals("") Or Not siglaObra.Text.Length.Equals(3) Then
            siglaObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteInitials")
        End If
        If refcontrato.Text.Equals("") Then
            refcontrato.Focus()
            ValidationRequired = True
            err = translations.getText("siteContractRef")
        End If
        If moradaObra.Text.Equals("") Then
            moradaObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteAddress")
        End If

        If Not IsNumeric(regieHourly.Text) Then
            regieHourly.Focus()
            ValidationRequired = True
            err = translations.getText("regieHourly")
        End If
        If Not IsNumeric(machinistHourly.Text) Then
            machinistHourly.Focus()
            ValidationRequired = True
            err = translations.getText("machinistHourly")
        End If
        If Not IsNumeric(cranemanHourly.Text) Then
            cranemanHourly.Focus()
            ValidationRequired = True
            err = translations.getText("cranemanHourly")
        End If
        If Not IsNumeric(regie_after_hours.Text) Then
            regie_after_hours.Focus()
            ValidationRequired = True
            err = translations.getText("regieHourly")
        End If
        If Not IsNumeric(machinist_after_hours.Text) Then
            machinist_after_hours.Focus()
            ValidationRequired = True
            err = translations.getText("machinistHourly")
        End If
        If Not IsNumeric(craneman_after_hours.Text) Then
            craneman_after_hours.Focus()
            ValidationRequired = True
            err = translations.getText("cranemanHourly")
        End If
        If Not IsNumeric(regie_weekends.Text) Then
            regie_weekends.Focus()
            ValidationRequired = True
            err = translations.getText("regieHourly")
        End If
        If Not IsNumeric(machinist_weekends.Text) Then
            machinist_weekends.Focus()
            ValidationRequired = True
            err = translations.getText("machinistHourly")
        End If
        If Not IsNumeric(craneman_weekends.Text) Then
            craneman_weekends.Focus()
            ValidationRequired = True
            err = translations.getText("cranemanHourly")
        End If
        translations.load("commonForm")
        If primaryLanguage.Text.Equals(translations.getText("primaryLanguage") & ": - -") Then
            craneman_weekends.Focus()
            ValidationRequired = True
            translations.load("commonForm")
            err = translations.getText("primaryLanguage")
        End If
        translations.load("siteManagement")
        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If EmpresaAtribuida.Text.Equals("") Then
            Dim message3 As String = translations.getText("errorSelectCompany")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If languagesList.SelectedItems.Count < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectOneLanguage")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)

        Dim languages As String = ""
        For Each Index In languagesList.SelectedIndices
            If languages.IndexOf(countryList.ElementAt(Index).Value) = -1 Then
                languages = If(languages.Equals(""), countryList.ElementAt(Index).Value, languages & "," & countryList.ElementAt(Index).Value)
            End If
        Next

        translations.load("commonForm")
        Dim primaryLang As String = primaryLanguage.Text.Replace(translations.getText("primaryLanguage") & ": ", "")
        primaryLang = countryListings(primaryLang)

        Dim vars As New Dictionary(Of String, String)

        If (ObrasList.SelectedItems.Count > 0) Then
            If ObrasList.SelectedIndices(0) = 0 Then
                vars.Add("request", "add")
            Else
                vars.Add("request", "edit")
                vars.Add("cod", query_site.Item("cod_site")(posToLoad))
            End If
        Else
            vars.Add("request", "add")
        End If
        If site_ended.Checked Then
            vars.Add("active", "0")
        Else
            vars.Add("active", "1")
        End If
        If empresaIndex.Equals(0) Then
            vars.Add("company", query_site.Item("cod_company")(posToLoad))
        Else
            vars.Add("company", query_company.Item("cod_company")(empresaIndex))
        End If

        vars.Add("dinicio", duracaoInicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("dfim", duracaoFim.Value.ToString("yyyy-MM-dd"))
        vars.Add("nome", nomeObra.Text)
        vars.Add("ref", refcontrato.Text)
        vars.Add("sig", siglaObra.Text)
        vars.Add("address", moradaObra.Text)
        vars.Add("regie", regieHourly.Text)
        vars.Add("craneman", cranemanHourly.Text)
        vars.Add("machinist", machinistHourly.Text)
        vars.Add("regie_extra", regie_after_hours.Text)
        vars.Add("craneman_extra", craneman_after_hours.Text)
        vars.Add("machinist_extra", machinist_after_hours.Text)
        vars.Add("regie_weekends", regie_weekends.Text)
        vars.Add("craneman_weekends", craneman_weekends.Text)
        vars.Add("machinist_weekends", machinist_weekends.Text)
        vars.Add("project_lang", languages)
        vars.Add("primary_lang", primaryLang)
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveSiteData()

    End Sub
    Private Sub DataRequests_getResponseSaveSiteData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveSiteData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("siteManagement")
            If taskRequest.Equals("edit") Then
                mainForm.statusMessage = translations.getText("siteSuccess") & "(" & query_site.Item("name")(posToLoad) & ")"
            Else
                mainForm.statusMessage = translations.getText("siteRemoved")
            End If

            load_list()
            clearFields()
        End If
        enableButtonsAndLinks(Me, True)
        taskRequest = ""
    End Sub

    Private Sub saveResponsavelBtn_Click(sender As Object, e As EventArgs) Handles saveContractorManagerBtn.Click
        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        translations.load("siteManagement")
        If contractorManagerName.Text.Equals("") Then
            contractorManagerName.Focus()
            ValidationRequired = True
            err = translations.getText("siteManagerName")
        End If
        If Not IsValidEmailFormat(conractorManagerEmail.Text) Or conractorManagerEmail.Text.Equals("") Then
            conractorManagerEmail.Focus()
            ValidationRequired = True
            err = translations.getText("siteManagerEmail")
        End If
        If contractorManagerJobAuthority.SelectedIndex = 0 Then
            ValidationRequired = True
            err = translations.getText("SiteManagerJob")
        End If

        If contractorManagerCardId.Text.Equals("") Or Not IsNumeric(contractorManagerCardId.Text.ToString.Replace(" ", "")) Then
            contractorManagerCardId.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerId")
        End If
        If contractorManagerCardCode.Text.Equals("") Then
            contractorManagerCardCode.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerId")
        End If

        If contractorManagerPhone.Text.Equals("") Then
            contractorManagerPhone.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerPhone")
        End If
        If contractorManagerSection.Text.Equals("") Then
            contractorManagerSection.Focus()
            ValidationRequired = True
            err = translations.getText("SiteSection")
        End If

        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (ObrasList.SelectedItems.Count > 0) Then
            If ObrasList.SelectedIndices(0) = 0 Then
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Exit Sub
            End If
        Else
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        If (contratorManagerList.SelectedItems.Count > 0) Then
            If contratorManagerList.SelectedIndices(0) = 0 Then
                vars.Add("request", "add")
            Else
                vars.Add("request", "edit")
                vars.Add("cod", query_manager.Item("cod_manager")(contratorManagerList.SelectedIndices(0) - 1))
            End If
        Else
            vars.Add("request", "add")
        End If
        If contratorManagerList.SelectedIndices(0) > 0 Then
            vars.Add("section", query_manager.Item("cod_section")(contratorManagerList.SelectedIndices(0) - 1))
        Else
            vars.Add("section", query_sections.Item("cod_section")(sectionIndex))
        End If
        vars.Add("nome", contractorManagerName.Text)
        vars.Add("email", conractorManagerEmail.Text)
        'TODO: funcao is not lang independent
        vars.Add("funcao", contractorManagerJobAuthority.SelectedIndex)
        vars.Add("nfc", contractorManagerCardId.Text.ToString.Replace(" ", ""))
        vars.Add("idkey", contractorManagerCardCode.Text.ToString.Replace(" - ", ""))
        vars.Add("contact", contractorManagerPhone.Text)
        vars.Add("site", query_site.Item("cod_site")(posToLoad))
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveManagerData()

    End Sub
    Private Sub DataRequests_getResponseSaveManagerData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveManagerData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("siteManagement")
            If taskRequest.Equals("edit") Then
                mainForm.statusMessage = translations.getText("siteSuccessManager")
                clearFieldsManager()
                LoadListManager()
            Else
                mainForm.statusMessage = translations.getText("siteManagerRemoved")
                LoadListManager()
                clearFieldsManager()
            End If
        End If
        enableButtonsAndLinks(Me, False)
        taskRequest = ""
    End Sub

    Private Sub saveEmpresaBtn_Click(sender As Object, e As EventArgs) Handles saveEmpresaBtn.Click
        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        translations.load("siteManagement")

        If nomeEmpresa.Text.Equals("") Then
            nomeEmpresa.Focus()
            ValidationRequired = True
            err = translations.getText("siteCompanyName")
        End If
        If tvaEmpresa.Text.Equals("") Then
            tvaEmpresa.Focus()
            ValidationRequired = True
            err = translations.getText("siteCompanyVat")
        End If
        If telefoneEmpresa.Text.Equals("") Then
            telefoneEmpresa.Focus()
            ValidationRequired = True
            err = translations.getText("siteCompanyPhone")
        End If
        If moradaEmpresa.Text.Equals("") Then
            moradaEmpresa.Focus()
            ValidationRequired = True
            err = translations.getText("siteCompanyAddress")
        End If

        If Not IsValidEmailFormat(emailEmpresa.Text) Or emailEmpresa.Text.Equals("") Then
            emailEmpresa.Focus()
            ValidationRequired = True
            err = translations.getText("siteCompanyEmail")
        End If
        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)

        If (EmpresaList.SelectedItems.Count > 0) Then
            If EmpresaList.SelectedIndices(0) = 0 Then
                vars.Add("request", "add")
            Else
                vars.Add("request", "edit")
                vars.Add("cod", query_company.Item("cod_company")(EmpresaList.SelectedIndices(0) - 1))
            End If
        Else
            vars.Add("request", "add")
        End If
        vars.Add("nome", nomeEmpresa.Text)
        vars.Add("email", emailEmpresa.Text)
        vars.Add("address", moradaEmpresa.Text)
        vars.Add("tva", tvaEmpresa.Text)
        vars.Add("contact", telefoneEmpresa.Text)
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveCompanyData()

    End Sub
    Private Sub DataRequests_getResponseSaveCompanyData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveCompanyData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("siteManagement")
            If taskRequest.Equals("edit") Then
                mainForm.statusMessage = translations.getText("siteSuccessCompany")

                If (ObrasList.SelectedItems.Count > 0 And EmpresaList.SelectedItems.Count > 0) Then
                    If ObrasList.SelectedIndices(0) > 0 And EmpresaList.SelectedIndices(0) > 0 Then
                        If query_site.Item("cod_company")(ObrasList.SelectedIndex - 1).Equals(query_company.Item("cod_company")(EmpresaList.SelectedIndices(0) - 1)) Then
                            EmpresaAtribuida.Text = nomeEmpresa.Text
                        End If
                    End If
                End If
                clearFieldsEmpresas()
                LoadListCompany()
            Else
                mainForm.statusMessage = translations.getText("siteCompanyRemoved")
                load_list()
                clearFields()
            End If
        End If

        taskRequest = ""
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub saveSectionBtn_Click(sender As Object, e As EventArgs) Handles saveSectionBtn.Click
        translations.load("siteManagement")

        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        If descriptionSection.Text.Equals("") Then
            descriptionSection.Focus()
            ValidationRequired = True
            err = translations.getText("description")
        End If

        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (ObrasList.SelectedItems.Count > 0) Then
            If ObrasList.SelectedIndices(0) = 0 Then
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Exit Sub
            End If
        Else
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If Not IsNumeric(sectionLatitude.Text) Then
            sectionLatitude.Focus()
            ValidationRequired = True
            err = translations.getText("siteLatitude")
        End If
        If Not IsNumeric(sectionLongitude.Text) Then
            sectionLongitude.Focus()
            ValidationRequired = True
            err = translations.getText("siteLongitude")
        End If
        If Not IsNumeric(sectionDistance.Text) Then
            sectionDistance.Focus()
            ValidationRequired = True
            err = translations.getText("siteDistance")
        End If
        If Not IsNumeric(sectionRadius.Text) Then
            sectionRadius.Focus()
            ValidationRequired = True
            err = translations.getText("siteAuthRadius")
        End If
        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        If (sectionsList.SelectedItems.Count > 0) Then
            If sectionsList.SelectedIndices(0) = 0 Then
                vars.Add("request", "add")
            Else
                vars.Add("request", "edit")
                vars.Add("cod", query_sections.Item("cod_section")(sectionsList.SelectedIndices(0) - 1))
            End If
        Else
            vars.Add("request", "add")
        End If
        vars.Add("desc", descriptionSection.Text)
        vars.Add("site", query_site.Item("cod_site")(posToLoad))
        vars.Add("lat", sectionLatitude.Text)
        vars.Add("lon", sectionLongitude.Text)
        vars.Add("dist", sectionDistance.Text)
        vars.Add("range", sectionRadius.Text)
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveSectionData()

    End Sub
    Private Sub DataRequests_getResponseSaveSectionData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveSectionData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            If taskRequest.Equals("edit") Then
                mainForm.statusMessage = translations.getText("siteSectionAdd")
                clearFieldsSections()
                LoadListSections()
            Else
                mainForm.statusMessage = translations.getText("siteSectionRemoved") & "(" & query_sections.Item("description")(sectionsList.SelectedIndices(0) - 1) & ")"
                LoadListSections()
                clearFieldsSections()
            End If
        End If
        enableButtonsAndLinks(Me, True)
        taskRequest = ""
    End Sub

    Private Sub atribuirEmpresa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles atribuirEmpresa.LinkClicked
        If (EmpresaList.SelectedItems.Count > 0) Then
            If EmpresaList.SelectedIndices(0) = 0 Then
                EmpresaAtribuida.Text = ""
                empresaIndex = 0
            Else
                EmpresaAtribuida.Text = query_company.Item("nome")(EmpresaList.SelectedIndices(0) - 1)
                empresaIndex = EmpresaList.SelectedIndices(0) - 1
            End If
        End If
    End Sub

    Private Sub resetEmpresa_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles resetEmpresa.LinkClicked
        empresaIndex = 0
        Dim i As Integer = InQueryDictionary(query_company, query_site.Item("cod_company")(ObrasList.SelectedIndex - 1), "cod_company")
        If i = -1 Then
            EmpresaAtribuida.Text = ""
        Else
            EmpresaAtribuida.Text = query_company.Item("nome")(i)
        End If
    End Sub

    Private Sub delObraBtn_Click(sender As Object, e As EventArgs) Handles delObraBtn.Click
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveAllSiteData")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message3 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.Yes) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (ObrasList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("del", query_site.Item("cod_site")(posToLoad))
            vars.Add("request", "del")
            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveSiteData()
        End If
    End Sub

    Private Sub delEmpresaBtn_Click(sender As Object, e As EventArgs) Handles delEmpresaBtn.Click
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveCompany")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message3 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.Yes) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (EmpresaList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("del", query_company.Item("cod_company")(EmpresaList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveCompanyData()
        End If
    End Sub

    Private Sub delResponsavelBtn_Click(sender As Object, e As EventArgs) Handles delContractorManagerBtn.Click
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveManager")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message3 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.Yes) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (contratorManagerList.SelectedItems.Count > 0) Then

            Dim vars As New Dictionary(Of String, String)
            vars.Add("del", query_manager.Item("cod_manager")(contratorManagerList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveManagerData()
        End If
    End Sub

    Private Sub delSectionBtn_Click(sender As Object, e As EventArgs) Handles delSectionBtn.Click
        translations.load("siteManagement")
        If sectionsList.Items.Count < 3 Then
            Dim message3 As String = translations.getText("errorCantDeleteSection")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim message4 As String = translations.getText("siteRemoveSection")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message4, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.Yes) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        translations.load("siteManagement")
        If (sectionsList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("del", query_sections.Item("cod_section")(sectionsList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveSectionData()
        End If
    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        clearFields()
        load_list()
    End Sub

    Private Sub atribuirSection_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles atribuirSection.LinkClicked
        If (sectionsList.SelectedItems.Count > 0) Then
            If sectionsList.SelectedIndices(0) = 0 Then
                contractorManagerSection.Text = ""
                sectionIndex = 0
            Else
                contractorManagerSection.Text = query_sections.Item("description")(sectionsList.SelectedIndices(0) - 1)
                sectionIndex = sectionsList.SelectedIndices(0) - 1
            End If
        End If
    End Sub

    Private Sub resetSectionResponsavel_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles contractorManagerResetSection.LinkClicked
        If contratorManagerList.SelectedIndex < 1 Then
            Exit Sub
        End If

        sectionIndex = 0

        Dim i As Integer = InQueryDictionary(query_sections, query_manager.Item("cod_section")(contratorManagerList.SelectedIndex - 1), "cod_section")
        If i = -1 Then
            contractorManagerSection.Text = ""
        Else
            contractorManagerSection.Text = query_sections.Item("description")(i)
        End If
    End Sub

    Private Sub managerPhotobox_Click(sender As Object, e As EventArgs) Handles contractorManagerPhotobox.Click
        translations.load("siteManagement")
        If (contratorManagerList.SelectedItems.Count > 0) Then
            If contratorManagerList.SelectedIndex > 0 Then
                Dim idx = contratorManagerList.SelectedIndex
                Dim OpenFileDialog1 As New OpenFileDialog
                OpenFileDialog1.Title = "Abrir ficheiro..."
                OpenFileDialog1.Multiselect = False
                OpenFileDialog1.Filter = "Imagem jpg|*.jpg"
                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                    Dim filename = OpenFileDialog1.FileName
                    contractorManagerPhotobox.Image = Image.FromFile(filename)
                    contractorManagerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage

                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("siteAddPhoto")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & "?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
                    If (msgbox.ShowDialog = DialogResult.OK) Then
                        enableButtonsAndLinks(Me, False)
                        Dim request As New HttpDataCore
                        Dim vars As New Dictionary(Of String, String)
                        vars.Add("task", stateCore.taskId("siteManagers"))
                        vars.Add("request", "file")
                        vars.Add("cod", query_manager.Item("cod_manager")(contratorManagerList.SelectedIndex - 1))

                        sendPhotoManagerHttp = New HttpDataFilesUpload(stateCore)
                        sendPhotoManagerHttp.loadQueue(vars, Nothing, filename)
                        sendPhotoManagerHttp.startRequest()
                    End If
                End If
            Else
                translations.load("siteManagement")
                Dim message3 As String = translations.getText("errorSelectManager")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub sendPhotoManagerHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles sendPhotoManagerHttp.dataArrived
        mainForm.busy.Close(True)

        If Not IsResponseOk(responseData) Then
            CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & "companyLogo.png")
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            clearFieldsManager()
            LoadListManager()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub


    Private Sub CompanyLogo_Click(sender As Object, e As EventArgs) Handles CompanyLogo.Click

        translations.load("siteManagement")
        If (EmpresaList.SelectedItems.Count > 0) Then
            If EmpresaList.SelectedIndex > 0 Then
                Dim idx = EmpresaList.SelectedIndex
                Dim OpenFileDialog1 As New OpenFileDialog
                OpenFileDialog1.Title = "Abrir ficheiro..."
                OpenFileDialog1.Multiselect = False
                OpenFileDialog1.Filter = "Imagem jpg|*.jpg"
                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
                    Dim filename = OpenFileDialog1.FileName
                    CompanyLogo.Image = Image.FromFile(filename)
                    CompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage

                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("siteAddPhoto")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & "?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
                    If (msgbox.ShowDialog = DialogResult.OK) Then
                        enableButtonsAndLinks(Me, False)
                        Dim request As New HttpDataCore
                        Dim vars As New Dictionary(Of String, String)
                        vars.Add("task", stateCore.taskId("siteGeneralContractors"))
                        vars.Add("request", "file")
                        vars.Add("cod", query_company.Item("cod_entreprise")(EmpresaList.SelectedIndex - 1))

                        sendPhotoCompanyHttp = New HttpDataFilesUpload(stateCore)
                        sendPhotoCompanyHttp.loadQueue(vars, Nothing, filename)
                        sendPhotoCompanyHttp.startRequest()

                    End If
                End If
            Else
                translations.load("siteManagement")
                Dim message3 As String = translations.getText("errorSelectCompany")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        End If
    End Sub
    Private Sub sendPhotoCompanyHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles sendPhotoCompanyHttp.dataArrived
        mainForm.busy.Close(True)

        If Not IsResponseOk(responseData) Then
            CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & "companyLogo.png")
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            clearFieldsEmpresas()
            LoadListCompany()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub saveNewCard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveNewCard.LinkClicked
        Dim currentFormData As New Dictionary(Of String, String)
        If (contratorManagerList.SelectedItems.Count > 0) Then
            If contratorManagerList.SelectedIndices(0) > 0 Then 'edit worker
                currentFormData.Add("userCode", query_manager.Item("cod_manager")(contratorManagerList.SelectedIndex - 1))
                currentFormData.Add("cardId", contractorManagerCardId.Text)
                currentFormData.Add("authString", contractorManagerCardCode.Text)
            End If
        End If

        initializeSmartCardForm = New initializeSmartCard(Me.mainForm, stateCore, currentFormData)
        initializeSmartCardForm.ShowDialog()
    End Sub
    Private Sub initializeSmartCardForm_getSmartCardDetails(sender As Object, args As Dictionary(Of String, String)) Handles initializeSmartCardForm.getSmartCardDetails
        contractorManagerCardId.Text = args("cardId")
        contractorManagerCardCode.Text = args("authstring")
    End Sub
    Private Sub sectionsList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles sectionsList.SelectedIndexChanged
        If (sectionsList.SelectedItems.Count > 0) Then
            descriptionSection.Text = sectionsList.SelectedItems(0).ToString

            If sectionsList.SelectedIndices(0) = 0 Then
                clearFieldsSections()
                If ObrasList.SelectedItems.Count = 0 Then
                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("errorSelectSite")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                End If
            Else
                delSectionBtn.Enabled = True
                atribuirSection.Enabled = True
            End If
        End If
    End Sub

    Private Sub GroupBoxHourly_Enter(sender As Object, e As EventArgs) Handles GroupBoxHourly.Enter

    End Sub

    Private Sub show_default_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_default_lang.CheckedChanged
        If show_default_lang.Checked Then
            show_all_lang.Checked = False
            GetAllCountryLanguages()
        ElseIf show_all_lang.Checked = False And ObrasList.SelectedIndex > 0 Then
            GetAllCountryLanguages(ObrasList.SelectedIndex - 1)
        ElseIf show_all_lang.Checked = False Then
            GetAllCountryLanguages()
        End If
    End Sub
    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            show_default_lang.Checked = False
            GetAllCountryLanguages()
        ElseIf show_default_lang.Checked = False And ObrasList.SelectedIndex > 0 Then
            GetAllCountryLanguages(ObrasList.SelectedIndex - 1)
        ElseIf show_default_lang.Checked = False Then
            GetAllCountryLanguages()
        End If
    End Sub

    Private Sub setPrimaryLang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles setPrimaryLang.LinkClicked

        translations.load("commonForm")
        If countryListings.ContainsKey(languagesList.Items.Item(languageListSelection(languageListSelection.Count - 1)).ToString) Then

            primaryLanguage.Text = translations.getText("primaryLanguage") & ": " & languagesList.Items.Item(languageListSelection(languageListSelection.Count - 1)).ToString
        Else
            primaryLanguage.Text = translations.getText("primaryLanguage") & ": - -"
        End If
    End Sub


    Private listBox1_selection As List(Of Integer) = New List(Of Integer)()



    Private Sub languagesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles languagesList.SelectedIndexChanged
        TrackSelectionChange(languagesList)
        If languagesList.SelectedIndex < 0 Then
            setPrimaryLang.Enabled = False
        Else
            setPrimaryLang.Enabled = True
        End If
    End Sub
    Private Sub TrackSelectionChange(ByVal lb As ListBox)
        Dim sic As ListBox.SelectedIndexCollection = lb.SelectedIndices

        For Each index As Integer In sic
            If Not languageListSelection.Contains(index) Then languageListSelection.Add(index)
        Next

        For Each index As Integer In New List(Of Integer)(languageListSelection)
            If Not sic.Contains(index) Then languageListSelection.Remove(index)
        Next
    End Sub

    Private Sub workersListSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sitesListSelection.SelectedIndexChanged
        If sitesListSelection.SelectedIndex > -1 And loaded Then
            load_list()
        End If
    End Sub

    Private Sub downloadPhotoManager_Click(sender As Object, e As EventArgs) Handles downloadPhotoContractorManager.Click
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Title = "guardar imagem..."
        saveFileDialog1.Filter = "Imagem jpg|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim cfgFile = New FileInfo(saveFileDialog1.FileName)
            cfgFile.Refresh()
            If cfgFile.Exists Then
                Try
                    FileSystem.Kill(saveFileDialog1.FileName)
                Catch
                    translations.load("errorMessages")
                    Dim message3 As String = translations.getText("errorFileWriteProtected")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try
            End If
            Dim filename = saveFileDialog1.FileName
            contractorManagerPhotobox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles managerCardId.TextChanged

    End Sub

    Private Sub GroupBoxManagers_Enter(sender As Object, e As EventArgs) Handles GroupBoxContractorManagers.Enter

    End Sub

    Private Sub divider3_Click(sender As Object, e As EventArgs) Handles divider3.Click

    End Sub

    Private Sub GroupBoxSections_Enter(sender As Object, e As EventArgs) Handles GroupBoxSections.Enter

    End Sub

    Private Sub managerList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles managerList.SelectedIndexChanged

    End Sub

    Private Sub downloadCompanyLogo_Click(sender As Object, e As EventArgs) Handles downloadCompanyLogo.Click
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Title = "guardar imagem..."
        saveFileDialog1.Filter = "Imagem jpg|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim cfgFile = New FileInfo(saveFileDialog1.FileName)
            cfgFile.Refresh()
            If cfgFile.Exists Then
                Try
                    FileSystem.Kill(saveFileDialog1.FileName)
                Catch
                    translations.load("errorMessages")
                    Dim message3 As String = translations.getText("errorFileWriteProtected")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            CompanyLogo.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub


    Private Sub ObrasList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ObrasList.SelectedIndexChanged

        If (ObrasList.SelectedItems.Count > 0) Then
            clearFields()
            nomeObra.Text = ObrasList.SelectedItems(0).ToString
            If ObrasList.SelectedIndices(0) = 0 Then
                DisableFieldsManager(False)
                DisableFieldsSections(False)

                GroupBoxSite.Enabled = True
                GroupBoxCompany.Enabled = True
                GroupBoxContractorManagers.Enabled = False
                GroupBoxSections.Enabled = False
            Else
                delObraBtn.Enabled = True
                resetEmpresa.Enabled = True

                DisableFieldsManager(True)
                DisableFieldsSections(True)

                GroupBoxSite.Enabled = True
                GroupBoxCompany.Enabled = True
                GroupBoxContractorManagers.Enabled = True
                GroupBoxSections.Enabled = True

                downloadPhotoContractorManager.Enabled = False

                If sitesListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = ObrasList.SelectedIndices(0) - 1
                ElseIf sitesListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = ObrasList.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = ObrasList.SelectedIndices(0) - 1
                End If

                moradaObra.Text = query_site.Item("address")(posToLoad)
                siglaObra.Text = query_site.Item("initials")(posToLoad)
                refcontrato.Text = query_site.Item("ref_contrato")(posToLoad)
                sectionLatitude.Text = query_site.Item("gps_lat")(posToLoad)
                sectionLongitude.Text = query_site.Item("gps_lon")(posToLoad)
                sectionDistance.Text = query_site.Item("distancia")(posToLoad)
                sectionRadius.Text = query_site.Item("authentication_radius")(posToLoad)
                regieHourly.Text = query_site.Item("regie_hourly")(posToLoad)
                cranemanHourly.Text = query_site.Item("craneman_hourly")(posToLoad)
                machinistHourly.Text = query_site.Item("machinist_hourly")(posToLoad)
                regie_weekends.Text = query_site.Item("regie_weekends")(posToLoad)
                craneman_weekends.Text = query_site.Item("craneman_weekends")(posToLoad)
                machinist_weekends.Text = query_site.Item("machinist_weekends")(posToLoad)
                regie_after_hours.Text = query_site.Item("regie_after_hours")(posToLoad)
                craneman_after_hours.Text = query_site.Item("craneman_after_hours")(posToLoad)
                machinist_after_hours.Text = query_site.Item("machinist_after_hours")(posToLoad)
                translations.load("commonForm")
                If countryListings.ContainsValue(query_site.Item("primary_lang")(posToLoad)) Then
                    Dim pair As KeyValuePair(Of String, String)
                    For Each pair In countryListings
                        If pair.Value.Equals(query_site.Item("primary_lang")(posToLoad)) Then
                            primaryLanguage.Text = translations.getText("primaryLanguage") & ": " & pair.Key
                            Exit For
                        End If
                    Next
                Else
                    primaryLanguage.Text = translations.getText("primaryLanguage") & ": - -"
                End If

                If query_site.Item("active")(posToLoad).Equals("1") Then
                    site_ended.Checked = False
                Else
                    site_ended.Checked = True
                End If
                If (IsDate(query_site.Item("data_inicio")(posToLoad))) Then
                    duracaoInicio.Value = Date.ParseExact(query_site.Item("data_inicio")(posToLoad), "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End If
                If (IsDate(query_site.Item("data_fim")(posToLoad))) Then
                    duracaoFim.Value = Date.ParseExact(query_site.Item("data_fim")(posToLoad), "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End If
                empresaIndex = 0
                Dim i As Integer = InQueryDictionary(query_company, query_site.Item("cod_company")(posToLoad), "cod_company")
                If i.Equals(-1) Then
                    EmpresaAtribuida.Text = ""
                Else
                    EmpresaAtribuida.Text = query_company.Item("nome")(i)
                End If

                GetAllCountryLanguages(posToLoad)
                LoadListManager()
                LoadListSections()
            End If
        End If
        setPrimaryLang.Enabled = False
        saveNewCard.Enabled = False
    End Sub



    Private Sub ManagerList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles contratorManagerList.SelectedIndexChanged
        If (contratorManagerList.SelectedItems.Count > 0) Then
            contractorManagerName.Text = contratorManagerList.SelectedItems(0).ToString
            If contratorManagerList.SelectedIndices(0) = 0 Then
                clearFieldsManager()
                saveNewCard.Enabled = False
                managerListPos = -1
                If ObrasList.SelectedItems.Count = 0 Then
                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("errorSelectSite")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                End If
            Else
                managerListPos = contratorManagerList.SelectedIndices(0) - 1

                If nfc_card.SelectDevice() Then
                    Dim smartCardReaders As New List(Of String)
                    Dim errMsg As String = ""
                    If nfc_card.GetAvailableReaders(smartCardReaders, errMsg) Then
                        saveNewCard.Enabled = True
                    End If
                End If

                delContractorManagerBtn.Enabled = True
                contractorManagerResetSection.Enabled = True
                contractorManagerName.Text = query_manager.Item("name")(contratorManagerList.SelectedIndices(0) - 1)
                conractorManagerEmail.Text = query_manager.Item("email")(contratorManagerList.SelectedIndices(0) - 1)
                contractorManagerPhone.Text = query_manager.Item("telef")(contratorManagerList.SelectedIndices(0) - 1)

                contractorManagerCardId.Text = AddSpaces(query_manager.Item("cod_nfc")(contratorManagerList.SelectedIndices(0) - 1), 3)
                If query_manager.Item("auth_string")(contratorManagerList.SelectedIndices(0) - 1).ToString.Length.Equals(12) Then
                    contractorManagerCardCode.Text = query_manager.Item("auth_string")(contratorManagerList.SelectedIndices(0) - 1).Substring(0, 4) & " - " & query_manager.Item("auth_string")(contratorManagerList.SelectedIndices(0) - 1).Substring(4, 3) & " - " & query_manager.Item("auth_string")(contratorManagerList.SelectedIndices(0) - 1).Substring(7, 5)
                Else
                    contractorManagerCardCode.Text = query_manager.Item("auth_string")(contratorManagerList.SelectedIndices(0) - 1)
                End If

                Dim i As Integer = InQueryDictionary(query_sections, query_manager.Item("cod_section")(contratorManagerList.SelectedIndices(0) - 1), "cod_section")
                If i = -1 Then
                    contractorManagerSection.Text = ""
                Else
                    contractorManagerSection.Text = query_sections.Item("description")(i)
                End If

                ' 0 - select 
                ' 1 - conducteur
                ' 2 - gestionnaire

                If IsNumeric(query_manager.Item("job")(contratorManagerList.SelectedIndices(0) - 1)) Then
                    contractorManagerJobAuthority.SelectedIndex = query_manager.Item("job")(contratorManagerList.SelectedIndices(0) - 1)
                    contractorManagerJobAuthority.SelectedIndex = 0
                End If

                If (query_manager.Item("photo")(contratorManagerList.SelectedIndices(0) - 1).Equals("")) Then
                    contractorManagerPhotobox.Image = Image.FromFile(mainForm.state.imagesPath & "engineer.png")
                Else
                    contractorManagerPhotobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
                    contractorManagerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & query_manager.Item("photo")(contratorManagerList.SelectedIndices(0) - 1))))
                        contractorManagerPhotobox.Image = tImage
                        downloadPhotoContractorManager.Enabled = True
                    Catch ex As Exception
                        translations.load("siteManagement")
                        contractorManagerPhotobox.Image = Image.FromFile(mainForm.state.imagesPath & "engineer.png")
                        mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    contractorManagerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End If
        Else
            clearFieldsManager()
            saveNewCard.Enabled = False
        End If
    End Sub

    Private Sub EmpresaList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles EmpresaList.SelectedIndexChanged
        If (EmpresaList.SelectedItems.Count > 0) Then
            nomeEmpresa.Text = EmpresaList.SelectedItems(0).ToString
            If EmpresaList.SelectedIndices(0) = 0 Then
                clearFieldsEmpresas()
            Else
                delEmpresaBtn.Enabled = True
                atribuirEmpresa.Enabled = True
                tvaEmpresa.Text = query_company.Item("tva")(EmpresaList.SelectedIndices(0) - 1)
                telefoneEmpresa.Text = query_company.Item("phone")(EmpresaList.SelectedIndices(0) - 1)
                emailEmpresa.Text = query_company.Item("email")(EmpresaList.SelectedIndices(0) - 1)
                moradaEmpresa.Text = query_company.Item("address")(EmpresaList.SelectedIndices(0) - 1)

                If (query_company.Item("logo")(EmpresaList.SelectedIndices(0) - 1).Equals("")) Then
                    CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & "companyLogo.png")
                Else
                    CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
                    CompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & query_company.Item("logo")(EmpresaList.SelectedIndices(0) - 1))))
                        CompanyLogo.Image = tImage
                        downloadCompanyLogo.Enabled = True
                    Catch ex As Exception
                        translations.load("siteManagement")
                        CompanyLogo.Image = Image.FromFile(mainForm.state.imagesPath & "companyLogo.png")
                        mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    CompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End If
        End If
    End Sub
End Class