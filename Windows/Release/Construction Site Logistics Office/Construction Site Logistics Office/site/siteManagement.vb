Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net

Public Class site_mng_frm
    Private msgbox As message_box_frm
    Private state As State
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
    Private nfc_card As New NFCard
    Private posToLoad As Integer = -1
    Private inactiveWorkerPosZero As Integer = 0

    Dim WithEvents bwManagers As BackgroundWorker
    Dim WithEvents bwSections As BackgroundWorker
    Dim WithEvents bwCompany As BackgroundWorker
    Dim WithEvents bwSites As BackgroundWorker

    Private Sub Panel_geral_Paint(sender As Object, e As PaintEventArgs) Handles Panel_geral.Paint

    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.DoEvents()
        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()
    End Sub

    Private Sub site_mng_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        saveNewCard.Enabled = False
        MainMdiForm.childForm = "site"
        state = MainMdiForm.state
        translations = New languageTranslations(state)

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        Me.SuspendLayout()
        loading_status.Text = ""
        loading_status_company.Text = ""
        loading_status_manager.Text = ""
        loading_status_sections.Text = ""

        siteFileTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        sectionsFileTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        managersFileTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        companyFileTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = state.dividerColor
        divider2.BackColor = state.dividerColor
        divider3.BackColor = state.dividerColor
        divider4.BackColor = state.dividerColor

        siteTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        sectionTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        managersTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        companyTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        loading_status.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_company.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_manager.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        loading_status_sections.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ObrasList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ManagerList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionsList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        EmpresaList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        updateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        resetEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        delObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        atribuirSection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        delSection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveSection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadPhotoManager.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        resetSectionResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        delResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadCompanyLogo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        atribuirEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        delEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nomeEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        emailEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        tvaEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        telefoneEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        moradaEmpresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nfcResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        emailResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nomeResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        telefoneResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        funcaoResponsavel.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        descriptionSection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nomeObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siglaObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        moradaObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        latitudeObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        LongitudeObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        distanciaObra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        authRange.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_ended.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        EmpresaAtribuida.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        refcontrato.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mandatoryFields.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteAddress_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteAuthRadius_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteCompanyAssigned_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteDuration_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteEnd_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteGpsCoordinates_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteLatitude_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteLongitude_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteName_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteRefContract_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteStart_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteDistance_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteInitials_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        sectionDescription_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerCode_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerEmail_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerJob_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerPhone_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerName_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerJob_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyAddress_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyEmail_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyTva_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyName_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        companyPhone_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        managerSectionAssigned_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveNewCard.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nfcCardCode_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nfcCardCode.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cranemanHourly.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinistHourly.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regieHourly.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        craneman_weekends.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinist_weekends.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_weekends.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        craneman_after_hours.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinist_after_hours.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_after_hours.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        GroupBoxHourly.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Bold)
        unitshourly1.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly2.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly3.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly4.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly5.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly6.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly7.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly8.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitshourly9.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regieHourly_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        machinistHourly_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cranemanHourly_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        normal_time_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        weekends_time_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        after_hours_time_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_all_lang.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_default_lang.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        primaryLanguage.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        setPrimaryLang.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        languagesProject_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        sitesListSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        mandatoryFields.Text = translations.getText("mandatoryFields")
        delEmpresa.Text = translations.getText("delLink")
        saveEmpresa.Text = translations.getText("saveLink")
        delObra.Text = translations.getText("delLink")
        saveObra.Text = translations.getText("saveLink")
        delSection.Text = translations.getText("delLink")
        saveSection.Text = translations.getText("saveLink")
        delResponsavel.Text = translations.getText("delLink")
        saveResponsavel.Text = translations.getText("saveLink")
        resetEmpresa.Text = translations.getText("resetLink")
        resetSectionResponsavel.Text = translations.getText("resetLink")
        downloadCompanyLogo.Text = translations.getText("downloadLink")
        downloadPhotoManager.Text = translations.getText("downloadLink")
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
        siteAuthRadius_lbl.Text = translations.getText("siteAuthRadius") & "* (m)"
        siteCompanyAssigned_lbl.Text = translations.getText("siteCompanyAssigned") & "*"
        siteDuration_lbl.Text = translations.getText("siteDuration") & "*"
        siteEnd_lbl.Text = translations.getText("siteDateEnd")
        siteGpsCoordinates_lbl.Text = translations.getText("siteGpsCoordinates") & "*"
        siteLatitude_lbl.Text = translations.getText("siteLatitude")
        siteLongitude_lbl.Text = translations.getText("siteLongitude")
        siteName_lbl.Text = translations.getText("siteName") & "*"
        siteRefContract_lbl.Text = translations.getText("siteContractRef")
        siteStart_lbl.Text = translations.getText("siteDateStart")
        siteDistance_lbl.Text = translations.getText("siteDistance") & "* (Km)"
        siteInitials_lbl.Text = translations.getText("siteInitials") & "*"
        sectionDescription_lbl.Text = translations.getText("siteSectionName") & "*"
        managerCode_lbl.Text = translations.getText("SiteManagerId") & "*"
        managerEmail_lbl.Text = translations.getText("siteManagerEmail") & "*"
        managerJob_lbl.Text = translations.getText("SiteManagerJob") & "*"
        managerPhone_lbl.Text = translations.getText("SiteManagerPhone") & "*"
        managerName_lbl.Text = translations.getText("siteManagerName") & "*"
        managerJob_lbl.Text = translations.getText("SiteManagerJob") & "*"
        managerSectionAssigned_lbl.Text = translations.getText("siteSectionAssigned") & "*"
        companyAddress_lbl.Text = translations.getText("siteCompanyAddress") & "*"
        companyEmail_lbl.Text = translations.getText("siteManagerEmail") & "*"
        companyTva_lbl.Text = translations.getText("siteCompanyVat") & "*"
        companyName_lbl.Text = translations.getText("siteCompanyName") & "*"
        companyPhone_lbl.Text = translations.getText("SiteManagerPhone") & "*"
        siteFileTitle.Text = translations.getText("SiteFileTitle")
        sectionsFileTitle.Text = translations.getText("SiteSectionsFileTitle")
        managersFileTitle.Text = translations.getText("SiteManagerFileTitle")
        companyFileTitle.Text = translations.getText("SiteCompanyFileTitle")
        siteTitle.Text = translations.getText("SiteListTitle")
        sectionTitle.Text = translations.getText("SiteSectionListTitle")
        managersTitle.Text = translations.getText("SiteManagerListTitle")
        companyTitle.Text = translations.getText("SiteCompanyListTitle")
        site_ended.Text = translations.getText("SiteWorksEnded")
        regieHourly_lbl.Text = translations.getText("regieHourly") & "*"
        machinistHourly_lbl.Text = translations.getText("machinistHourly") & "*"
        cranemanHourly_lbl.Text = translations.getText("cranemanHourly") & "*"
        normal_time_lbl.Text = translations.getText("normalTime")
        weekends_time_lbl.Text = translations.getText("weekendsTime")
        after_hours_time_lbl.Text = translations.getText("afterHoursTime")
        languagesProject_lbl.Text = translations.getText("languagesProject")

        funcaoResponsavel.Items.Clear()
        funcaoResponsavel.Items.Add(translations.getText("siteManagerSelectOne"))
        funcaoResponsavel.Items.Add(translations.getText("siteManagerConducteur"))
        funcaoResponsavel.Items.Add(translations.getText("siteManagerGestionnaire"))


        translations.load("workers")
        nfcCardCode_lbl.Text = translations.getText("cardAuthCode") & "*"

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

        updateLink.Location = New Point(ObrasList.Location.X + ObrasList.Width - updateLink.Width, updateLink.Location.Y)
        loading_status_sections.Location = New Point(sectionTitle.Location.X + 5 + sectionTitle.Width, loading_status_sections.Location.Y)
        loading_status_manager.Location = New Point(managersTitle.Location.X + 5 + managersTitle.Width, loading_status_manager.Location.Y)
        loading_status_company.Location = New Point(companyTitle.Location.X + 5 + companyTitle.Width, loading_status_company.Location.Y)
        mandatoryFields.Location = New Point(divider.Location.X + divider.Width - mandatoryFields.Width, mandatoryFields.Location.Y)

        siteStart_lbl.Location = New Point(duracaoInicio.Location.X - siteStart_lbl.Width, siteStart_lbl.Location.Y)
        siteEnd_lbl.Location = New Point(duracaoFim.Location.X - siteEnd_lbl.Width, siteEnd_lbl.Location.Y)
        siteLatitude_lbl.Location = New Point(latitudeObra.Location.X - siteLatitude_lbl.Width, siteLatitude_lbl.Location.Y)
        siteLongitude_lbl.Location = New Point(LongitudeObra.Location.X - siteLongitude_lbl.Width, siteLongitude_lbl.Location.Y)
        siteDistance_lbl.Location = New Point(distanciaObra.Location.X - siteDistance_lbl.Width, siteDistance_lbl.Location.Y)
        siteAuthRadius_lbl.Location = New Point(authRange.Location.X - siteAuthRadius_lbl.Width, siteAuthRadius_lbl.Location.Y)

        siteDuration_lbl.Location = New Point(duracaoInicio.Location.X + siteDuration_lbl.Width / 3 - siteDuration_lbl.Width, siteDuration_lbl.Location.Y)
        siteGpsCoordinates_lbl.Location = New Point(latitudeObra.Location.X + siteGpsCoordinates_lbl.Width / 3 - siteGpsCoordinates_lbl.Width, siteGpsCoordinates_lbl.Location.Y)

        duracaoInicio.CustomFormat = "yyyy-MM-dd"
        duracaoFim.CustomFormat = "yyyy-MM-dd"
        GroupBoxCompany.Enabled = False
        GroupBoxManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = False
        Me.ResumeLayout()
    End Sub

    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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

        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
            End If
        End If

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
        enableButtonsAndLinks(Me, False)
        GroupBoxCompany.Enabled = False
        GroupBoxManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = False

    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sites,sections")
        vars.Add("override", "true")

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(query_site) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translations.getText("SiteListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If
        db_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(db_sections) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translations.getText("SiteSectionListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        sectionsList.Items.Clear()
        sectionsList.Items.Add(translations.getText("siteSectionSelectAdd"))
        translations.load("siteManagement")
        ObrasList.Items.Clear()
        ObrasList.Items.Add(translations.getText("siteSelectAdd"))
        updated = True
        loading_status.Text = ""
        ObrasList.SelectedIndex = 0
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            setPrimaryLang.Enabled = False

            removeMask()
            GroupBoxSite.Enabled = False
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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
        GroupBoxManagers.Enabled = False
        GroupBoxSections.Enabled = False
        GroupBoxSite.Enabled = True
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
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
                End If
            End If
        Next ci
    End Sub

    Sub LoadListCompany()
        translations.load("commonForm")
        loading_status_company.Text = translations.getText("wait") & "..."

        If Not IsNothing(bwCompany) Then
            If bwCompany.IsBusy Then
                bwCompany.CancelAsync()
            End If
        End If

        bwCompany = New BackgroundWorker()
        bwCompany.WorkerSupportsCancellation = True
        bwCompany.RunWorkerAsync()
        enableButtonsAndLinks(Me, False)
        GroupBoxCompany.Enabled = False

    End Sub

    Private Sub bwCompany_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCompany.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "company")

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_company = request.ConvertDataToArray("company", state.querySiteContractorFields, response)
        If IsNothing(query_company) Then
            errorMsg = GetMessage(request.errorMessage) & "(" & translations.getText("SiteCompanyListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwCompany_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwCompany.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        translations.load("siteManagement")
        EmpresaList.Items.Clear()
        EmpresaList.Items.Add(translations.getText("siteCompanySelectAdd"))
        loading_status_company.Text = ""
        EmpresaList.SelectedIndex = 0
        EmpresaList.Enabled = True
        ManagerList.Items.Clear()
        ManagerList.Items.Add(translations.getText("siteManagerSelectAdd"))
        funcaoResponsavel.SelectedIndex = 0
        updated = True
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxCompany.Enabled = True
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxCompany.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_company.Item("nome").Count - 1
            EmpresaList.Items.Add(query_company.Item("nome")(i))
        Next

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        enableButtonsAndLinks(Me, True)
        GroupBoxCompany.Enabled = True

    End Sub

    Sub LoadListManager()
        translations.load("commonForm")
        loading_status_manager.Text = translations.getText("wait") & "..."
        ManagerList.Enabled = False
        If Not IsNothing(bwManagers) Then
            If bwManagers.IsBusy Then
                bwManagers.CancelAsync()
            End If
        End If

        bwManagers = New BackgroundWorker()
        bwManagers.WorkerSupportsCancellation = True
        bwManagers.RunWorkerAsync()
        enableButtonsAndLinks(Me, False)
        GroupBoxManagers.Enabled = False

    End Sub

    Private Sub bwManagers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwManagers.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "manager")
        vars.Add("site", query_site.Item("cod_site")(posToLoad))

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_manager = request.ConvertDataToArray("manager", state.querySiteManagerFields, response)
        If IsNothing(query_manager) Then
            translations.load("siteManagement")
            errorMsg = GetMessage(request.errorMessage) & "(" & translations.getText("SiteManagerListTitle") & ")"
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwManagers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwManagers.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        translations.load("siteManagement")
        ManagerList.Items.Clear()
        ManagerList.Items.Add(translations.getText("siteManagerSelectAdd"))
        loading_status_manager.Text = ""
        ManagerList.SelectedIndex = 0
        ManagerList.Enabled = True
        updated = True
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxManagers.Enabled = True
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxManagers.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_manager.Item("name").Count - 1
            ManagerList.Items.Add(query_manager.Item("name")(i))
        Next

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        enableButtonsAndLinks(Me, True)
        GroupBoxManagers.Enabled = True

    End Sub

    Sub LoadListSections()
        translations.load("commonForm")
        loading_status_sections.Text = translations.getText("wait") & "..."
        sectionsList.Enabled = False
        If Not IsNothing(bwSections) Then
            If bwSections.IsBusy Then
                bwSections.CancelAsync()
            End If
        End If
        enableButtonsAndLinks(Me, False)
        bwSections = New BackgroundWorker()
        bwSections.WorkerSupportsCancellation = True
        bwSections.RunWorkerAsync()
        GroupBoxSections.Enabled = False

    End Sub

    Private Sub bwSections_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSections.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sections")
        vars.Add("site", query_site.Item("cod_site")(posToLoad))

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(query_sections) Then
            errorMsg = GetMessage(request.errorMessage)
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If
    End Sub

    Private Sub bwSections_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSections.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        loading_status_sections.Text = ""
        translations.load("siteManagement")
        sectionsList.Items.Clear()
        sectionsList.Items.Add(translations.getText("siteSectionSelectAdd"))
        sectionsList.SelectedIndex = 0
        sectionsList.Enabled = True
        updated = True
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            GroupBoxSections.Enabled = True
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            GroupBoxSections.Enabled = True
            Exit Sub
        End If

        For i = 0 To query_sections.Item("description").Count - 1
            sectionsList.Items.Add(query_sections.Item("description")(i))
        Next
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        enableButtonsAndLinks(Me, True)
        GroupBoxSections.Enabled = True

    End Sub

    Sub clearFields()
        delObra.Enabled = False
        resetEmpresa.Enabled = False
        resetSectionResponsavel.Enabled = False
        atribuirEmpresa.Enabled = False
        atribuirSection.Enabled = False

        show_all_lang.Checked = False
        show_default_lang.Checked = False
        moradaObra.Text = ""
        siglaObra.Text = ""
        distanciaObra.Text = ""
        latitudeObra.Text = ""
        LongitudeObra.Text = ""
        nomeObra.Text = ""
        refcontrato.Text = ""
        EmpresaAtribuida.Text = ""
        authRange.Text = ""
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
        ManagerList.Items.Clear()
        ManagerList.Items.Add(translations.getText("siteManagerSelectAdd"))
        clearFieldsManager()
        clearFieldsEmpresas()
        clearFieldsSections()
    End Sub

    Sub clearFieldsManager()
        nomeResponsavel.Text = ""
        emailResponsavel.Text = ""
        nfcResponsavel.Text = ""
        nfcCardCode.Text = ""
        telefoneResponsavel.Text = ""
        sectionResponsavel.Text = ""
        funcaoResponsavel.SelectedIndex = 0
        delResponsavel.Enabled = False
        resetSectionResponsavel.Enabled = False
        downloadPhotoManager.Enabled = False
        managerPhotobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "engineer.png")

    End Sub
    Sub DisableFieldsManager(b As Boolean)
        nomeResponsavel.Enabled = b
        emailResponsavel.Enabled = b
        nfcResponsavel.Enabled = b
        telefoneResponsavel.Enabled = b
        funcaoResponsavel.Enabled = b
        saveResponsavel.Enabled = b
        ManagerList.Enabled = b
        downloadPhotoManager.Enabled = b

    End Sub

    Sub clearFieldsEmpresas()
        nomeEmpresa.Text = ""
        tvaEmpresa.Text = ""
        emailEmpresa.Text = ""
        telefoneEmpresa.Text = ""
        moradaEmpresa.Text = ""
        delEmpresa.Enabled = False
        atribuirEmpresa.Enabled = False
        CompanyLogo.Image = Image.FromFile(MainMdiForm.state.imagesPath & "companyLogo.png")
        downloadCompanyLogo.Enabled = False

    End Sub

    Sub DisableFieldsSections(b As Boolean)
        sectionsList.Enabled = b
        descriptionSection.Enabled = b
        saveSection.Enabled = b
        delSection.Enabled = b
    End Sub

    Sub clearFieldsSections()
        descriptionSection.Text = ""
        delSection.Enabled = False
        atribuirSection.Enabled = False
    End Sub

    Private Sub saveObra_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveObra.LinkClicked
        Dim msgbox As message_box_frm

        Dim response As String
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
        If Not IsNumeric(latitudeObra.Text) Then
            latitudeObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteLatitude")
        End If
        If Not IsNumeric(LongitudeObra.Text) Then
            LongitudeObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteLongitude")
        End If
        If Not IsNumeric(distanciaObra.Text) Then
            distanciaObra.Focus()
            ValidationRequired = True
            err = translations.getText("siteDistance")
        End If
        If Not IsNumeric(authRange.Text) Then
            authRange.Focus()
            ValidationRequired = True
            err = translations.getText("siteAuthRadius")
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
            translations.load("siteManagement")
            err = translations.getText("primaryLanguage")
        End If
        translations.load("siteManagement")
        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If EmpresaAtribuida.Text.Equals("") Then
            Dim message3 As String = translations.getText("errorSelectCompany")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If languagesList.SelectedItems.Count < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectOneLanguage")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        vars.Add("task", "14")
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
        vars.Add("lat", latitudeObra.Text)
        vars.Add("lon", LongitudeObra.Text)
        vars.Add("dist", distanciaObra.Text)
        vars.Add("range", authRange.Text)
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
        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("siteManagement")
            Dim message3 As String = translations.getText("siteSuccess")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            load_list()
            clearFields()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub saveResponsavel_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveResponsavel.LinkClicked
        Dim response As String
        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        translations.load("siteManagement")
        If nomeResponsavel.Text.Equals("") Then
            nomeResponsavel.Focus()
            ValidationRequired = True
            err = translations.getText("siteManagerName")
        End If
        If Not IsValidEmailFormat(emailResponsavel.Text) Or emailResponsavel.Text.Equals("") Then
            emailResponsavel.Focus()
            ValidationRequired = True
            err = translations.getText("siteManagerEmail")
        End If
        If funcaoResponsavel.SelectedIndex = 0 Then
            ValidationRequired = True
            err = translations.getText("SiteManagerJob")
        End If

        If nfcResponsavel.Text.Equals("") Or Not IsNumeric(nfcResponsavel.Text.ToString.Replace(" ", "")) Then
            nfcResponsavel.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerId")
        End If
        If nfcCardCode.Text.Equals("") Then
            nfcCardCode.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerId")
        End If

        If telefoneResponsavel.Text.Equals("") Then
            telefoneResponsavel.Focus()
            ValidationRequired = True
            err = translations.getText("SiteManagerPhone")
        End If
        If sectionResponsavel.Text.Equals("") Then
            sectionResponsavel.Focus()
            ValidationRequired = True
            err = translations.getText("SiteSection")
        End If

        If (ValidationRequired) Then
            Dim message3 As String = translations.getText("field") & ", " & err & ", " & translations.getText("cannotBeEmpty")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (ObrasList.SelectedItems.Count > 0) Then
            If ObrasList.SelectedIndices(0) = 0 Then
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Exit Sub
            End If
        Else
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "15")
        If (ManagerList.SelectedItems.Count > 0) Then
            If ManagerList.SelectedIndices(0) = 0 Then
                vars.Add("request", "add")
            Else
                vars.Add("request", "edit")
                vars.Add("cod", query_manager.Item("cod_manager")(ManagerList.SelectedIndices(0) - 1))
            End If
        Else
            vars.Add("request", "add")
        End If
        If ManagerList.SelectedIndices(0) > 0 Then
            vars.Add("section", query_manager.Item("cod_section")(ManagerList.SelectedIndices(0) - 1))
        Else
            vars.Add("section", query_sections.Item("cod_section")(sectionIndex))
        End If
        vars.Add("nome", nomeResponsavel.Text)
        vars.Add("email", emailResponsavel.Text)
        'TODO: funcao is not lang independent
        vars.Add("funcao", funcaoResponsavel.SelectedIndex)
        vars.Add("nfc", nfcResponsavel.Text.ToString.Replace(" ", ""))
        vars.Add("idkey", nfcCardCode.Text.ToString.Replace(" - ", ""))
        vars.Add("contact", telefoneResponsavel.Text)
        vars.Add("site", query_site.Item("cod_site")(posToLoad))

        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            Dim message3 As String = translations.getText("siteSuccessManager")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            clearFieldsManager()
            LoadListManager()
        End If
        enableButtonsAndLinks(Me, False)
    End Sub

    Private Sub saveEmpresa_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveEmpresa.LinkClicked
        Dim response As String
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
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "16")
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

        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            Dim message3 As String = translations.getText("siteSuccessCompany")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()

            If (ObrasList.SelectedItems.Count > 0 And EmpresaList.SelectedItems.Count > 0) Then
                If ObrasList.SelectedIndices(0) > 0 And EmpresaList.SelectedIndices(0) > 0 Then
                    If query_site.Item("cod_company")(ObrasList.SelectedIndex - 1).Equals(query_company.Item("cod_company")(EmpresaList.SelectedIndices(0) - 1)) Then
                        EmpresaAtribuida.Text = nomeEmpresa.Text
                    End If
                End If
            End If
            clearFieldsEmpresas()
            LoadListCompany()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub atribuirEmpresa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles atribuirEmpresa.LinkClicked
        If (EmpresaList.SelectedItems.Count > 0) Then
            If EmpresaList.SelectedIndices(0) = 0 Then
                EmpresaAtribuida.Text = ""
                empresaIndex = 0
            Else
                EmpresaAtribuida.Text = query_company.Item("nome")(EmpresaList.SelectedIndices(0) - 1)
                empresaIndex = EmpresaList.SelectedIndices(0)
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

    Private Sub delObra_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles delObra.LinkClicked
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveAllSiteData")
        translations.load("messagebox")
        msgbox = New message_box_frm(message3 & "?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.OK) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (ObrasList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "14")
            vars.Add("del", query_site.Item("cod_site")(posToLoad))
            vars.Add("request", "del")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                Dim message4 As String = translations.getText("siteRemoved") & "(" & query_site.Item("name")(posToLoad) & ")"
                translations.load("messagebox")
                msgbox = New message_box_frm(message4, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
                load_list()
                clearFields()
            End If
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub delEmpresa_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles delEmpresa.LinkClicked
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveCompany")
        translations.load("messagebox")
        msgbox = New message_box_frm(message3 & "?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.OK) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (EmpresaList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "16")
            vars.Add("del", query_company.Item("cod_company")(EmpresaList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                Dim message4 As String = translations.getText("siteCompanyRemoved") & "(" & query_company.Item("name")(EmpresaList.SelectedIndices(0) - 1) & ")"
                translations.load("messagebox")
                msgbox = New message_box_frm(message4, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
                load_list()
                clearFields()
            End If
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub delResponsavel_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles delResponsavel.LinkClicked
        translations.load("siteManagement")
        Dim message3 As String = translations.getText("siteRemoveManager")
        translations.load("messagebox")
        msgbox = New message_box_frm(message3 & "?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.OK) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        If (ManagerList.SelectedItems.Count > 0) Then

            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "15")
            vars.Add("del", query_manager.Item("cod_manager")(ManagerList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                Dim message4 As String = translations.getText("siteManagerRemoved") & "(" & query_manager.Item("name")(EmpresaList.SelectedIndices(0) - 1) & ")"
                translations.load("messagebox")
                msgbox = New message_box_frm(message4, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
                LoadListManager()
                clearFieldsManager()
            End If
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub delSection_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles delSection.LinkClicked
        translations.load("siteManagement")
        If sectionsList.Items.Count < 3 Then
            Dim message3 As String = translations.getText("errorCantDeleteSection")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim message4 As String = translations.getText("siteRemoveSection")
        translations.load("messagebox")
        msgbox = New message_box_frm(message4, translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If (msgbox.ShowDialog <> DialogResult.OK) Then
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        translations.load("siteManagement")
        If (sectionsList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "17")
            vars.Add("del", query_sections.Item("cod_section")(sectionsList.SelectedIndices(0) - 1))
            vars.Add("request", "del")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                Dim message5 As String = translations.getText("siteSectionRemoved") & "(" & query_sections.Item("description")(sectionsList.SelectedIndices(0) - 1) & ")"
                translations.load("messagebox")
                msgbox = New message_box_frm(message5, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
                LoadListSections()
                clearFieldsSections()
            End If
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub saveSection_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveSection.LinkClicked
        translations.load("siteManagement")
        Dim response As String
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
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (ObrasList.SelectedItems.Count > 0) Then
            If ObrasList.SelectedIndices(0) = 0 Then
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                Exit Sub
            End If
        Else
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "17")
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
        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            Dim message3 As String = translations.getText("siteSectionAdd")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            clearFieldsSections()
            LoadListSections()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles updateLink.LinkClicked
        clearFields()
        load_list()
    End Sub

    Private Sub atribuirSection_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles atribuirSection.LinkClicked
        If (sectionsList.SelectedItems.Count > 0) Then
            If sectionsList.SelectedIndices(0) = 0 Then
                sectionResponsavel.Text = ""
                sectionIndex = 0
            Else
                sectionResponsavel.Text = query_sections.Item("description")(sectionsList.SelectedIndices(0) - 1)
                sectionIndex = sectionsList.SelectedIndices(0) - 1
            End If
        End If
    End Sub

    Private Sub resetSectionResponsavel_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles resetSectionResponsavel.LinkClicked
        If ManagerList.SelectedIndex < 1 Then
            Exit Sub
        End If

        sectionIndex = 0

        Dim i As Integer = InQueryDictionary(query_sections, query_manager.Item("cod_section")(ManagerList.SelectedIndex - 1), "cod_section")
        If i = -1 Then
            sectionResponsavel.Text = ""
        Else
            sectionResponsavel.Text = query_sections.Item("description")(i)
        End If
    End Sub

    Private Sub managerPhotobox_Click(sender As Object, e As EventArgs) Handles managerPhotobox.Click
        translations.load("siteManagement")
        If (ManagerList.SelectedItems.Count > 0) Then
            If ManagerList.SelectedIndex > 0 Then
                Dim idx = ManagerList.SelectedIndex
                Dim OpenFileDialog1 As New OpenFileDialog
                OpenFileDialog1.Title = "Abrir ficheiro..."
                OpenFileDialog1.Multiselect = False
                OpenFileDialog1.Filter = "Imagem jpg|*.jpg"
                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                    Dim filename = OpenFileDialog1.FileName
                    managerPhotobox.Image = Image.FromFile(filename)
                    managerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage

                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("siteAddPhoto")
                    translations.load("messagebox")
                    msgbox = New message_box_frm(message3 & "?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
                    If (msgbox.ShowDialog = DialogResult.OK) Then
                        enableButtonsAndLinks(Me, False)
                        Dim request As New HttpData(state)
                        Dim vars As New Dictionary(Of String, String)
                        vars.Add("task", "15")
                        vars.Add("request", "file")
                        vars.Add("cod", query_manager.Item("cod_manager")(ManagerList.SelectedIndex - 1))
                        Dim response As String = request.SendHttpFile(vars, filename)
                        If Not IsNothing(MainMdiForm.busy) Then
                            If MainMdiForm.busy.isActive().Equals(True) Then
                                MainMdiForm.busy.Close(True)
                            End If
                        End If
                        If Not IsResponseOk(response) Then
                            translations.load("messagebox")
                            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            msgbox.ShowDialog()
                        Else
                            clearFieldsManager()
                            LoadListManager()
                        End If
                        enableButtonsAndLinks(Me, True)
                    End If
                End If
            Else
                translations.load("siteManagement")
                Dim message3 As String = translations.getText("errorSelectManager")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub downloadPhotoManager_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles downloadPhotoManager.LinkClicked
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
                    msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            managerPhotobox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub downloadCompanyLogo_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles downloadCompanyLogo.LinkClicked
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
                    msgbox = New message_box_frm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            CompanyLogo.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
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
                    msgbox = New message_box_frm(message3 & "?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question)
                    If (msgbox.ShowDialog = DialogResult.OK) Then
                        enableButtonsAndLinks(Me, False)
                        Dim request As New HttpData(state)
                        Dim vars As New Dictionary(Of String, String)
                        vars.Add("task", "16")
                        vars.Add("request", "file")
                        vars.Add("cod", query_company.Item("cod_entreprise")(EmpresaList.SelectedIndex - 1))
                        Dim response As String = request.SendHttpFile(vars, filename)
                        If Not IsNothing(MainMdiForm.busy) Then
                            If MainMdiForm.busy.isActive().Equals(True) Then
                                MainMdiForm.busy.Close(True)
                            End If
                        End If
                        If Not IsResponseOk(response) Then
                            CompanyLogo.Image = Image.FromFile(MainMdiForm.state.imagesPath & "companyLogo.png")
                            translations.load("messagebox")
                            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            msgbox.ShowDialog()
                        Else
                            clearFieldsEmpresas()
                            LoadListCompany()
                        End If
                        enableButtonsAndLinks(Me, True)
                    End If
                End If
            Else
                translations.load("siteManagement")
                Dim message3 As String = translations.getText("errorSelectCompany")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles siteDistance_lbl.Click
    End Sub

    Private Sub saveNewCard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveNewCard.LinkClicked
        initializeSmartCard.siteForm = New site_mng_frm
        initializeSmartCard.workersForm = Nothing

        initializeSmartCard.ShowDialog()

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
                    msgbox = New message_box_frm(message3, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                End If
            Else
                delSection.Enabled = True
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

    Private Sub GroupBoxSite_Enter(sender As Object, e As EventArgs) Handles GroupBoxSite.Enter

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
                GroupBoxManagers.Enabled = False
                GroupBoxSections.Enabled = False
            Else
                delObra.Enabled = True
                resetEmpresa.Enabled = True

                DisableFieldsManager(True)
                DisableFieldsSections(True)

                GroupBoxSite.Enabled = True
                GroupBoxCompany.Enabled = True
                GroupBoxManagers.Enabled = True
                GroupBoxSections.Enabled = True

                downloadPhotoManager.Enabled = False

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
                latitudeObra.Text = query_site.Item("gps_lat")(posToLoad)
                LongitudeObra.Text = query_site.Item("gps_lon")(posToLoad)
                distanciaObra.Text = query_site.Item("distancia")(posToLoad)
                authRange.Text = query_site.Item("authentication_radius")(posToLoad)
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

    End Sub



    Private Sub ManagerList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ManagerList.SelectedIndexChanged
        If (ManagerList.SelectedItems.Count > 0) Then
            nomeResponsavel.Text = ManagerList.SelectedItems(0).ToString
            If ManagerList.SelectedIndices(0) = 0 Then
                clearFieldsManager()
                saveNewCard.Enabled = False
                managerListPos = -1
                If ObrasList.SelectedItems.Count = 0 Then
                    translations.load("siteManagement")
                    Dim message3 As String = translations.getText("errorSelectSite")
                    translations.load("messagebox")
                    msgbox = New message_box_frm(message3, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                End If
            Else
                managerListPos = ManagerList.SelectedIndices(0) - 1

                If nfc_card.SelectDevice() Then
                    Dim smartCardReaders As New List(Of String)
                    Dim errMsg As String = ""
                    If nfc_card.GetAvailableReaders(smartCardReaders, errMsg) Then
                        saveNewCard.Enabled = True
                    End If
                End If

                delResponsavel.Enabled = True
                resetSectionResponsavel.Enabled = True
                nomeResponsavel.Text = query_manager.Item("name")(ManagerList.SelectedIndices(0) - 1)
                emailResponsavel.Text = query_manager.Item("email")(ManagerList.SelectedIndices(0) - 1)
                telefoneResponsavel.Text = query_manager.Item("telef")(ManagerList.SelectedIndices(0) - 1)

                nfcResponsavel.Text = AddSpaces(query_manager.Item("cod_nfc")(ManagerList.SelectedIndices(0) - 1), 3)
                If query_manager.Item("auth_string")(ManagerList.SelectedIndices(0) - 1).ToString.Length.Equals(12) Then
                    nfcCardCode.Text = query_manager.Item("auth_string")(ManagerList.SelectedIndices(0) - 1).Substring(0, 4) & " - " & query_manager.Item("auth_string")(ManagerList.SelectedIndices(0) - 1).Substring(4, 3) & " - " & query_manager.Item("auth_string")(ManagerList.SelectedIndices(0) - 1).Substring(7, 5)
                Else
                    nfcCardCode.Text = query_manager.Item("auth_string")(ManagerList.SelectedIndices(0) - 1)
                End If

                Dim i As Integer = InQueryDictionary(query_sections, query_manager.Item("cod_section")(ManagerList.SelectedIndices(0) - 1), "cod_section")
                If i = -1 Then
                    sectionResponsavel.Text = ""
                Else
                    sectionResponsavel.Text = query_sections.Item("description")(i)
                End If

                ' 0 - select 
                ' 1 - conducteur
                ' 2 - gestionnaire

                If IsNumeric(query_manager.Item("job")(ManagerList.SelectedIndices(0) - 1)) Then
                    funcaoResponsavel.SelectedIndex = query_manager.Item("job")(ManagerList.SelectedIndices(0) - 1)
                    funcaoResponsavel.SelectedIndex = 0
                End If

                If (query_manager.Item("photo")(ManagerList.SelectedIndices(0) - 1).Equals("")) Then
                    managerPhotobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "engineer.png")
                Else
                    managerPhotobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
                    managerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & query_manager.Item("photo")(ManagerList.SelectedIndices(0) - 1))))
                        managerPhotobox.Image = tImage
                        downloadPhotoManager.Enabled = True
                    Catch ex As Exception
                        translations.load("siteManagement")
                        managerPhotobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "engineer.png")
                        MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    managerPhotobox.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End If
        End If
    End Sub

    Private Sub EmpresaList_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles EmpresaList.SelectedIndexChanged
        If (EmpresaList.SelectedItems.Count > 0) Then
            nomeEmpresa.Text = EmpresaList.SelectedItems(0).ToString
            If EmpresaList.SelectedIndices(0) = 0 Then
                clearFieldsEmpresas()
            Else
                delEmpresa.Enabled = True
                atribuirEmpresa.Enabled = True
                tvaEmpresa.Text = query_company.Item("tva")(EmpresaList.SelectedIndices(0) - 1)
                telefoneEmpresa.Text = query_company.Item("phone")(EmpresaList.SelectedIndices(0) - 1)
                emailEmpresa.Text = query_company.Item("email")(EmpresaList.SelectedIndices(0) - 1)
                moradaEmpresa.Text = query_company.Item("address")(EmpresaList.SelectedIndices(0) - 1)

                If (query_company.Item("logo")(EmpresaList.SelectedIndices(0) - 1).Equals("")) Then
                    CompanyLogo.Image = Image.FromFile(MainMdiForm.state.imagesPath & "companyLogo.png")
                Else
                    CompanyLogo.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
                    CompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & query_company.Item("logo")(EmpresaList.SelectedIndices(0) - 1))))
                        CompanyLogo.Image = tImage
                        downloadCompanyLogo.Enabled = True
                    Catch ex As Exception
                        translations.load("siteManagement")
                        CompanyLogo.Image = Image.FromFile(MainMdiForm.state.imagesPath & "companyLogo.png")
                        MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    CompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End If
        End If
    End Sub
End Class