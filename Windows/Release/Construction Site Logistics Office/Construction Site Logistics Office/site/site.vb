Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading
Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class site_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations

    Private response As String = ""
    Private qtdSectionsIndex As Integer()
    Private livraisonSectionsIndex As Integer()
    Private regieSectionsIndex As Integer()
    Private AutoMedicaoSectionsIndex As Integer()
    Private mask, mask2 As PictureBox

    Private WithEvents bwRegie As BackgroundWorker
    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwLoadAM As BackgroundWorker
    Private WithEvents bwLoadWorkersOnSite As BackgroundWorker
    Private WithEvents bwLoadBordereau As BackgroundWorker
    Private WithEvents bwLoadJournal As BackgroundWorker
    Private WithEvents bwLoadAutoMedicao As BackgroundWorker
    Private WithEvents bwLoadLivraison As BackgroundWorker

    Private am_qtd As regie_json()
    Private selected_qtd_record As String()
    Private loaded As Boolean = False
    Private updated As Boolean = False
    Private loadedForm As Boolean = False
    Private qtdworks As bordereau_works_json()
    Private livraisonPhotos()() As livraison_photos

    Private regiePhotos()() As livraison_photos
    Private regieSection() As String

    Public Shared bordereauTable, bordereauTableState, livraisonTable, regieTable, AMTable As String(,)
    Public Shared query_site, query_company, query_manager, query_sections, db_sections, DbBordereau, query_bordereau, query_workers_on_site As Dictionary(Of String, List(Of String))
    Public Shared livraisonSection() As String
    Public Shared regieCodes() As String
    Public Shared livraison_datatable_cellX, livraison_datatable_cellY As Integer
    Public Shared regie_datatable_cellX, regie_datatable_cellY As Integer
    Public Shared bordereau_datatable_cellX, bordereau_datatable_cellY As Integer
    Public Shared auto_medicao_datatable_cellX, auto_medicao_datatable_cellY As Integer
    Public Shared qtd_datatable_cellX, qtd_datatable_cellY As Integer
    Public Shared livraisonCodes() As String
    Public Shared datatableChanges As Boolean = False
    Public Shared regie_selected_site As Integer
    Public Shared richtext As New RichTextBox
    Public Shared currentDatatable, currentLivraisonDatatable, currentRegieDatatable, currentProductionDatatable, currentBorderauDatatable As DataGridView
    Public Shared qtd_site_index As Integer

    Dim ArrDates As New List(Of Date)
    Private journalFile As String = ""
    Private weatherIcon As Bitmap()
    Private weatherText As String()
    Private works_sections As String(,)
    Private JournalSectionsIndex As Integer()


    'constant values for setup columns on bordereau table
    Private PREVIOUS_QUANTITIES_COL As Integer = 7
    Private TOTAL_QUANTITIES_DONE_COL As Integer = 9
    Private TOTAL_QUANTITIES_TODO_COL As Integer = 10
    Private TOTAL_AMOUNTS_DONE_COL As Integer = 9
    Private TOTAL_AMOUNTS_TODO_COL As Integer = 10
    Private SUBTOTAL_AMOUNTS_COL As Integer = TOTAL_AMOUNTS_DONE_COL - 1
    Private BORDEREAU_BASE_COLUMNS As Integer = 9

    Public Structure regie_json
        Public code As Integer
        Public data As Date
        Public stime As String
        Public etime As String
        Public section As Integer
        Public workersList As String
        Public notas As String
        Public workers As worker_json()
    End Structure

    Public Structure worker_json
        Public code As Integer
        Public name As String
        Public url As String
    End Structure
    Public Structure livraison_photos
        Public code As String
        Public file As String
    End Structure

    Public Structure bordereau_works_json
        Public data As Date
        Public qtdone As Double
        Public qtdToDo As Double
        Public mtDone As Double
        Public mtToDo As Double
        Public rup As Double
        Public hours As Double
        Public task As String
        Public previousQtd As Double
    End Structure

    Sub EnforceAuthorities()

    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub TabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl.SelectedIndexChanged
        If TabControl.SelectedTab.Name.Equals("regie_tab") Then
            currentDatatable = regie_datatable
        ElseIf TabControl.SelectedTab.Name.Equals("bordereau_tab") Then
            currentDatatable = qtd_datatable
        ElseIf TabControl.SelectedTab.Name.Equals("livraison_tab") Then
            currentDatatable = livraison_datatable
        ElseIf TabControl.SelectedTab.Name.Equals("qtd_tab") Then
            currentDatatable = auto_medicao_datatable
        End If
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub


    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.DoEvents()
        SetDoubleBuffered(qtd_datatable)
        SetDoubleBuffered(auto_medicao_datatable)
        SetDoubleBuffered(regie_datatable)
        SetDoubleBuffered(livraison_datatable)

        Me.WindowState = FormWindowState.Maximized

        Me.Refresh()
    End Sub

    Private Sub site_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        state = MainMdiForm.state
        translations = New languageTranslations(state)

        MainMdiForm.childForm = "site"

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Height = Me.Height
        mask.Width = Me.Width
        mask.BackColor = Color.White
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Application.DoEvents()
        Me.SuspendLayout()

        TabControl.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Regular)
        qtd_datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        qtd_datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraison_datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        livraison_datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        regie_datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        auto_medicao_datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        JournalGroupBoxSelection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        journalData_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        journalSection_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        meteo_chk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        journal_chk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtds_chk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraison_chk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_chk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        journal_num_workers.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        logger_label.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        journal_label.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        activities_label.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        ocurrences_label.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        activities.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ocurrences.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        categories_box.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        update_logger.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        update_journal.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        view_doc.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        bordereuGroupBoxSelection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        qtd_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_data_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_data_to.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_setCurrentMonth.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        qtd_data_inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_data_fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_qtdChk.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        qtd_amountsChk.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        qtd_acumulatedResultsChk.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        bordereau_GroupBox_search.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        bordereau_searchBox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        bordereau_sectionSelection_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        autoMedicaoGroupBoxSelection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_GroupBox_search.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_qtd_group.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_workers_group.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_tasks_group.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        auto_medicao_bar.BackColor = state.dividerColor
        auto_medicao_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_data_inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_data_fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoSection_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoDate_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoSetCurrentMonth.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoDateTo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoRecordDate_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_date.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoRecordQtd_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_qtd.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_units.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_reset.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoRecordAnnotations_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_notas.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_translate.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        autoMedicaoWorkersOnSite_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_afetacao.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_workers.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_workers_selected.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_update_workers.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_tasks_list.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_update_tasks.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_del.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        auto_medicao_save.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        livraison_GroupBox_siteSelection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        livraison_GroupBox_search.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        livraison_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraison_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraison_data_inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraison_data_fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraisonCurrentMonthSelection_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        livraisonSearchBox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        livraisonSection_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        livraisonDate_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        livraisonDateTo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        photo_title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        photo_separator.BackColor = state.dividerColor
        LivraisonPhotoSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        view_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        add_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        del_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        download_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        statsLinkLivraison.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        regieGroupBox_siteSelection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        regie_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_data_inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_data_fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_section_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_date_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regieSetCurrentMonth.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_dateTo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        GroupBox_legenda.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regieLegendClosed.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regieLegendEod.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regieLegendAutoEod.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regieLegendOngoing.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_GroupBox_search.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        regieSearchBox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_photo_title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        regie_photo_separator.BackColor = state.dividerColor
        regiePhotoSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        regie_view_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_add_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_del_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        regie_download_photo.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        JournalGroupBoxSelection.Text = translations.getText("groupBoxSite")
        journalData_lbl.Text = translations.getText("dateTitle")
        journalSection_lbl.Text = translations.getText("siteSection")
        update_logger.Text = translations.getText("updateLink")
        update_journal.Text = translations.getText("updateLink")
        save.Text = translations.getText("saveLink")
        view_doc.Text = translations.getText("viewDocumentLink")
        bordereau_sectionSelection_lbl.Text = translations.getText("siteSection")
        bordereuGroupBoxSelection.Text = translations.getText("groupBoxSite")
        bordereau_GroupBox_search.Text = translations.getText("SearchBoxTitle")
        autoMedicaoGroupBoxSelection.Text = translations.getText("groupBoxSite")
        auto_medicao_GroupBox_search.Text = translations.getText("SearchBoxTitle")
        autoMedicaoSection_lbl.Text = translations.getText("siteSection")
        autoMedicaoDate_lbl.Text = translations.getText("dateTitle")
        autoMedicaoSetCurrentMonth.Text = translations.getText("setCurrentMonthLink")
        autoMedicaoDateTo_lbl.Text = translations.getText("dateTo")
        qtd_data_lbl.Text = translations.getText("dateTitle")
        qtd_data_to.Text = translations.getText("dateTo")
        qtd_setCurrentMonth.Text = translations.getText("setCurrentMonthLink")
        autoMedicaoRecordDate_lbl.Text = translations.getText("dateTitle")
        autoMedicaoRecordAnnotations_lbl.Text = translations.getText("AnnotationTitle")
        auto_medicao_translate.Text = translations.getText("translateLink")
        auto_medicao_update_tasks.Text = translations.getText("updateLink")
        auto_medicao_del.Text = translations.getText("delLink")
        auto_medicao_save.Text = translations.getText("saveLink")
        livraison_GroupBox_siteSelection.Text = translations.getText("groupBoxSite")
        livraison_GroupBox_search.Text = translations.getText("SearchBoxTitle")
        livraisonCurrentMonthSelection_lbl.Text = translations.getText("setCurrentMonthLink")
        livraisonSection_lbl.Text = translations.getText("siteSection")
        livraisonDate_lbl.Text = translations.getText("dateTitle")
        livraisonDateTo_lbl.Text = translations.getText("dateTo")
        regieGroupBox_siteSelection.Text = translations.getText("groupBoxSite")
        regie_section_lbl.Text = translations.getText("siteSection")
        regie_date_lbl.Text = translations.getText("dateTitle")
        regieSetCurrentMonth.Text = translations.getText("setCurrentMonthLink")
        regie_dateTo_lbl.Text = translations.getText("dateTo")
        view_photo.Text = translations.getText("viewLink")
        add_photo.Text = translations.getText("addLink")
        del_photo.Text = translations.getText("delLink")
        download_photo.Text = translations.getText("downloadLink")
        regie_view_photo.Text = translations.getText("viewLink")
        regie_add_photo.Text = translations.getText("addLink")
        regie_del_photo.Text = translations.getText("delLink")
        regie_download_photo.Text = translations.getText("downloadLink")
        regie_GroupBox_search.Text = translations.getText("SearchBoxTitle")
        GroupBox_legenda.Text = translations.getText("legend")
        auto_medicao_update_workers.Text = translations.getText("updateLink")
        autoMedicaoWorkersOnSite_lbl.Text = translations.getText("workersOnSite")
        auto_medicao_reset.Text = translations.getText("resetLink")
        auto_medicao_workers_group.Text = translations.getText("workersTitle")
        categories_box.Text = translations.getText("seeByCategory")
        statsLinkLivraison.Text = translations.getText("statisticsLink")

        translations.load("siteActivity")
        meteo_chk.Text = translations.getText("journalMeteo")
        journal_chk.Text = translations.getText("journalSiteJournal")
        qtds_chk.Text = translations.getText("journalProduction")
        livraison_chk.Text = translations.getText("journalDelivery")
        regie_chk.Text = translations.getText("journalRegie")
        logger_label.Text = translations.getText("journalAttendanceRecord")
        journal_label.Text = translations.getText("journalActivityRecord")
        activities_label.Text = translations.getText("journalActivities")
        ocurrences_label.Text = translations.getText("journalOcurrences")
        auto_medicao_qtd_group.Text = translations.getText("productionRecordQuantityTitle")
        auto_medicao_tasks_group.Text = translations.getText("TasksTitle")
        auto_medicao_title.Text = translations.getText("productionRecordTitle")
        autoMedicaoRecordQtd_lbl.Text = translations.getText("productionQuantity")
        auto_medicao_units.Text = translations.getText("productionUnits")
        auto_medicao_afetacao.Text = translations.getText("productionWorkersAssigned")
        photo_title.Text = translations.getText("photoDocument")
        regie_photo_title.Text = translations.getText("photoDocument")
        regieLegendClosed.Text = translations.getText("regieLegendClosed")
        regieLegendEod.Text = translations.getText("regieLegendEod")
        regieLegendAutoEod.Text = translations.getText("regieLegendAutoEod")
        regieLegendOngoing.Text = translations.getText("regieLegendOngoing")
        TabControl.TabPages.Item(0).Text = translations.getText("journalTabTitle")
        TabControl.TabPages.Item(1).Text = translations.getText("tasksTabTitle")
        TabControl.TabPages.Item(2).Text = translations.getText("productionTabTitle")
        TabControl.TabPages.Item(3).Text = translations.getText("deliveryTabTitle")
        TabControl.TabPages.Item(4).Text = translations.getText("regieTabTitle")
        qtd_qtdChk.Text = translations.getText("tasksProduction")
        qtd_amountsChk.Text = translations.getText("tasksAmounts")
        qtd_acumulatedResultsChk.Text = translations.getText("tasksAcumulatedResults")

        Dim Width As Integer = Me.Width - 30
        Dim height As Integer = Me.Height - 30

        TabControl.Width = width
        TabControl.Height = height

        qtd_panel.Width = TabControl.Width - 25
        qtd_panel.Height = TabControl.Height - 25

        qtd_datatable.Height = qtd_panel.Height - qtd_datatable.Location.Y - 30
        qtd_datatable.Width = qtd_panel.Width - 10

        LivraisonPhoto.Height = TabControl.Height - LivraisonPhoto.Location.Y - 50
        LivraisonPhoto.Width = LivraisonPhoto.Height / 1.5
        LivraisonPhoto.Location = New Point(TabControl.Width - LivraisonPhoto.Width - 30, LivraisonPhoto.Location.Y)
        LivraisonPhotoSelection.Location = New Point(LivraisonPhoto.Location.X, LivraisonPhotoSelection.Location.Y)
        view_photo.Location = New Point(LivraisonPhotoSelection.Location.X + LivraisonPhotoSelection.Width + 10, view_photo.Location.Y)
        add_photo.Location = New Point(view_photo.Location.X + view_photo.Width + 10, view_photo.Location.Y)
        del_photo.Location = New Point(add_photo.Location.X + add_photo.Width + 10, view_photo.Location.Y)
        download_photo.Location = New Point(del_photo.Location.X + del_photo.Width + 10, view_photo.Location.Y)
        photo_separator.Location = New Point(LivraisonPhoto.Location.X, photo_separator.Location.Y)
        photo_separator.Width = LivraisonPhoto.Width
        photo_title.Location = New Point(LivraisonPhoto.Location.X, photo_title.Location.Y)
        livraison_datatable.Width = LivraisonPhoto.Location.X - livraison_datatable.Location.X - 20
        livraison_datatable.Height = LivraisonPhoto.Height
        livraison_datatable.Location = New Point(livraison_datatable.Location.X, livraison_GroupBox_siteSelection.Location.Y + livraison_GroupBox_siteSelection.Height + 5)

        regiePhoto.Height = TabControl.Height - regiePhoto.Location.Y - 50
        regiePhoto.Width = LivraisonPhoto.Height / 1.5
        regiePhoto.Location = New Point(TabControl.Width - regiePhoto.Width - 30, regie_datatable.Location.Y)
        regiePhotoSelection.Location = New Point(regiePhoto.Location.X, regiePhotoSelection.Location.Y)
        regie_view_photo.Location = New Point(regiePhotoSelection.Location.X + regiePhotoSelection.Width + 10, regie_view_photo.Location.Y)
        regie_add_photo.Location = New Point(regie_view_photo.Location.X + regie_view_photo.Width + 10, regie_view_photo.Location.Y)
        regie_del_photo.Location = New Point(regie_add_photo.Location.X + regie_add_photo.Width + 10, regie_view_photo.Location.Y)
        regie_download_photo.Location = New Point(regie_del_photo.Location.X + regie_del_photo.Width + 10, regie_view_photo.Location.Y)

        regie_photo_separator.Location = New Point(regiePhoto.Location.X, regie_photo_separator.Location.Y)
        regie_photo_separator.Width = regiePhoto.Width
        regie_photo_title.Location = New Point(regiePhoto.Location.X, regie_photo_title.Location.Y)
        regie_datatable.Width = regiePhoto.Location.X - regie_datatable.Location.X - 20
        regie_datatable.Height = regiePhoto.Height
        regie_datatable.Location = New Point(regie_datatable.Location.X, regie_datatable.Location.Y)

        eodBox.Location = New Point(regieLegendClosed.Location.X + regieLegendClosed.Width + 10, regieLegendClosed.Location.Y)
        regieLegendEod.Location = New Point(eodBox.Location.X + eodBox.Width + 4, regieLegendClosed.Location.Y)
        autoEodBox.Location = New Point(regieLegendEod.Location.X + regieLegendEod.Width + 10, regieLegendClosed.Location.Y)
        regieLegendAutoEod.Location = New Point(autoEodBox.Location.X + autoEodBox.Width + 10, regieLegendClosed.Location.Y)
        ongoingBox.Location = New Point(regieLegendAutoEod.Location.X + regieLegendAutoEod.Width + 10, regieLegendClosed.Location.Y)
        regieLegendOngoing.Location = New Point(ongoingBox.Location.X + ongoingBox.Width + 10, regieLegendClosed.Location.Y)


        auto_medicao_datatable.Width = TabControl.Width / 2
        auto_medicao_datatable.Height = TabControl.Height - 50 - auto_medicao_datatable.Location.Y

        auto_medicao_title.Location = New Point(auto_medicao_datatable.Width + auto_medicao_datatable.Location.X + 30, auto_medicao_datatable.Location.Y)

        auto_medicao_bar.Location = New Point(auto_medicao_title.Location.X, auto_medicao_title.Location.Y + auto_medicao_title.Height)
        auto_medicao_bar.Width = TabControl.Width - auto_medicao_datatable.Width - 60

        auto_medicao_qtd_group.Location = New Point(auto_medicao_title.Location.X, auto_medicao_bar.Location.Y + auto_medicao_bar.Height + 5)
        auto_medicao_qtd_group.Width = TabControl.Width - auto_medicao_datatable.Width - 60
        auto_medicao_notas.Width = auto_medicao_qtd_group.Width - 5 - auto_medicao_notas.Location.X
        auto_medicao_reset.Location = New Point(auto_medicao_qtd_group.Width - auto_medicao_reset.Width - 5, auto_medicao_reset.Location.Y)
        auto_medicao_translate.Location = New Point(auto_medicao_qtd_group.Width - auto_medicao_translate.Width - 5, auto_medicao_translate.Location.Y)

        Dim amw As Integer = (auto_medicao_datatable.Location.Y + auto_medicao_datatable.Height - (auto_medicao_qtd_group.Location.Y + auto_medicao_qtd_group.Height)) / 2 - 14

        auto_medicao_workers_group.Location = New Point(auto_medicao_title.Location.X, auto_medicao_qtd_group.Location.Y + auto_medicao_qtd_group.Height + 5)
        auto_medicao_workers_group.Width = TabControl.Width - auto_medicao_datatable.Width - 60
        auto_medicao_workers.Width = auto_medicao_workers_group.Width / 2 - 5
        auto_medicao_workers_group.Height = amw
        auto_medicao_workers.Height = auto_medicao_workers_group.Height - auto_medicao_workers.Location.Y - auto_medicao_update_workers.Height
        auto_medicao_update_workers.Location = New Point(auto_medicao_update_workers.Location.X, auto_medicao_workers_group.Height - auto_medicao_update_workers.Height - 5)
        auto_medicao_workers_selected.Location = New Point(auto_medicao_workers.Location.X + auto_medicao_workers.Width + 5, auto_medicao_workers_selected.Location.Y)
        auto_medicao_workers_selected.Width = auto_medicao_workers_group.Width / 2 - 10
        auto_medicao_workers_selected.Height = auto_medicao_workers_group.Height - auto_medicao_workers.Location.Y - auto_medicao_update_workers.Height
        auto_medicao_afetacao.Location = New Point(auto_medicao_workers_selected.Location.X, auto_medicao_afetacao.Location.Y)

        auto_medicao_tasks_group.Location = New Point(auto_medicao_title.Location.X, auto_medicao_workers_group.Location.Y + auto_medicao_workers_group.Height + 5)
        auto_medicao_tasks_group.Width = TabControl.Width - auto_medicao_datatable.Width - 60
        auto_medicao_tasks_list.Width = auto_medicao_tasks_group.Width - 5 - auto_medicao_tasks_list.Location.X
        auto_medicao_tasks_group.Height = amw
        auto_medicao_tasks_list.Height = auto_medicao_tasks_group.Height - auto_medicao_tasks_list.Location.Y - auto_medicao_update_tasks.Height - 5
        auto_medicao_update_tasks.Location = New Point(auto_medicao_update_tasks.Location.X, auto_medicao_tasks_group.Height - auto_medicao_update_tasks.Height - 5)

        auto_medicao_del.Location = New Point(auto_medicao_tasks_group.Location.X + auto_medicao_tasks_group.Width - auto_medicao_save.Width - 20 - auto_medicao_del.Width, auto_medicao_tasks_group.Location.Y + auto_medicao_tasks_group.Height)
        auto_medicao_save.Location = New Point(auto_medicao_tasks_group.Location.X + auto_medicao_tasks_group.Width - auto_medicao_save.Width, auto_medicao_tasks_group.Location.Y + auto_medicao_tasks_group.Height)

        'JOURNAL
        Panel_logger.Width = Width * 0.25
        Panel_logger.Height = height - Panel_logger.Location.Y - 60
        logger_label.Location = New Point(Panel_logger.Location.X, Panel_logger.Location.Y - 20)
        categories_box.Location = New Point(Panel_logger.Location.X, Panel_logger.Location.Y + Panel_logger.Height)
        update_logger.Location = New Point(Panel_logger.Location.X + Panel_logger.Width - update_logger.Width, categories_box.Location.Y)

        panel_journal.Location = New Point(Panel_logger.Location.X + Panel_logger.Width + 20, Panel_logger.Location.Y)
        panel_journal.Width = Panel_logger.Width
        panel_journal.Height = Panel_logger.Height
        journal_label.Location = New Point(panel_journal.Location.X, panel_journal.Location.Y - 20)
        update_journal.Location = New Point(panel_journal.Location.X + panel_journal.Width - update_journal.Width, panel_journal.Location.Y + panel_journal.Height)

        activities.Location = New Point(panel_journal.Location.X + panel_journal.Width + 20, panel_journal.Location.Y)
        activities.Width = Width * 0.5 - 80
        activities.Height = Panel_logger.Height * 0.5 - 25
        activities_label.Location = New Point(activities.Location.X, activities.Location.Y - 20)

        ocurrences.Location = New Point(activities.Location.X, activities.Location.Y + activities.Height + 50)
        ocurrences.Width = activities.Width
        ocurrences.Height = activities.Height
        ocurrences_label.Location = New Point(ocurrences.Location.X, ocurrences.Location.Y - 20)
        save.Location = New Point(ocurrences.Location.X + ocurrences.Width - save.Width, ocurrences.Location.Y + ocurrences.Height)
        view_doc.Location = New Point(save.Location.X - view_doc.Width - 5, save.Location.Y)
        journal_num_workers.Location = New Point(Panel_logger.Location.X + Panel_logger.Width - journal_num_workers.Width, journal_num_workers.Location.Y)

        bordereau_GroupBox_search.Location = New Point(TabControl.Width - bordereau_GroupBox_search.Width - 30, bordereau_GroupBox_search.Location.Y)
        auto_medicao_GroupBox_search.Location = New Point(TabControl.Width - auto_medicao_GroupBox_search.Width - 20, auto_medicao_GroupBox_search.Location.Y)
        livraison_GroupBox_search.Location = New Point(TabControl.Width - livraison_GroupBox_search.Width - 20, livraison_GroupBox_search.Location.Y)
        regie_GroupBox_search.Location = New Point(TabControl.Width - regie_GroupBox_search.Width - 20, regie_GroupBox_search.Location.Y)


        Me.ResumeLayout()
    End Sub

    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
        Try
            FileSystem.Kill(String.Format("{0}", Environment.CurrentDirectory & "\tmp\*.*"))
        Catch

        End Try
    End Sub

    Private Sub removeMask()
        If loadedForm Then
            Exit Sub
        End If

        loadedForm = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()
        EnforceAuthorities()
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

        updated = False
        livraison_site.Enabled = False
        auto_medicao_site.Enabled = False
        qtd_site.Enabled = False

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sites,sections")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(query_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        db_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(db_sections) Then
            errorMsg = request.errorMessage
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
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If


        ReDim qtdSectionsIndex(db_sections.Item("cod_section").Count)
        ReDim livraisonSectionsIndex(db_sections.Item("cod_section").Count)
        ReDim regieSectionsIndex(db_sections.Item("cod_section").Count)
        ReDim AutoMedicaoSectionsIndex(db_sections.Item("cod_section").Count)
        ReDim JournalSectionsIndex(db_sections.Item("cod_section").Count)

        While Not Me.IsHandleCreated
            System.Windows.Forms.Application.DoEvents()
        End While

        translations.load("commonForm")

        qtd_site.Items.Clear()
        qtd_site.Items.Add(translations.getText("dropdownSelectSite"))
        livraison_site.Items.Clear()
        livraison_site.Items.Add(translations.getText("dropdownSelectSite"))
        regie_site.Items.Clear()
        regie_site.Items.Add(translations.getText("dropdownSelectSite"))
        auto_medicao_site.Items.Clear()
        auto_medicao_site.Items.Add(translations.getText("dropdownSelectSite"))
        combo_site.Items.Clear()
        combo_site.Items.Add(translations.getText("dropdownSelectSite"))

        For i = 0 To query_site.Item("cod_site").Count - 1
            qtd_site.Items.Add(query_site.Item("name")(i))
            livraison_site.Items.Add(query_site.Item("name")(i))
            regie_site.Items.Add(query_site.Item("name")(i))
            auto_medicao_site.Items.Add(query_site.Item("name")(i))
            combo_site.Items.Add(query_site.Item("name")(i))
        Next i

        combo_site.SelectedIndex = 0
        qtd_site.SelectedIndex = 0
        livraison_site.SelectedIndex = 0
        auto_medicao_site.SelectedIndex = 0

        livraison_site.Enabled = True
        auto_medicao_site.Enabled = True
        qtd_site.Enabled = True
        updated = True

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub regie_do_search_Click_1(sender As Object, e As EventArgs) Handles regie_do_search.Click
        Dim msgbox As message_box_frm
        DropClickSearchBox(regie_do_search)

        If regieSearchBox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf regie_datatable.Rows.Count <= 0 Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchResultsNotFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            doSearch(If(regie_datatable_cellY < 0, 0, regie_datatable_cellY), regie_datatable, regieSearchBox.Text, {5, 6}, True)
        End If
    End Sub

    Private Sub livraison_do_search_Click(sender As Object, e As EventArgs) Handles livraison_do_search.Click
        Dim msgbox As message_box_frm
        DropClickSearchBox(livraison_do_search)
        If livraisonSearchBox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf livraison_datatable.Rows.Count <= 0 Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchResultsNotFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            doSearch(If(livraison_datatable_cellY < 0, 0, livraison_datatable_cellY), livraison_datatable, livraisonSearchBox.Text, {2, 5}, True)
        End If
    End Sub

    Private Sub bordereau_do_search_Click(sender As Object, e As EventArgs) Handles bordereau_do_search.Click
        Dim msgbox As message_box_frm
        DropClickSearchBox(bordereau_do_search)

        If bordereau_searchBox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf qtd_datatable.Rows.Count <= 0 Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchResultsNotFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            doSearch(If(bordereau_datatable_cellY < 0, 0, bordereau_datatable_cellY), qtd_datatable, bordereau_searchBox.Text, {1, 2}, True)
        End If
    End Sub

    Private Sub doSearch(start As Integer, datatable As DataGridView, searchQ As String, cols As Integer(), firstTime As Boolean)
        Dim msgbox As message_box_frm
        If datatable.Rows.Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To datatable.Rows.Count - 1
                For j = 0 To UBound(cols)
                    If Not datatable.Rows(i).Cells(cols(j)).Value.ToString.ToLower.IndexOf(searchQ.ToLower) = -1 Then
                        datatable.CurrentCell = datatable.Rows(i).Cells(cols(j))
                        found = True
                        Exit For
                    End If
                Next j
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message As String = translations.getText("searchResultsNotFound") & ". " & translations.getText("searchAgainQuestion") & " ?"
                translations.load("messagebox")
                msgbox = New message_box_frm(message & ". ", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearch(0, datatable, searchQ, cols, False)
                End If
            End If
        End If
    End Sub

    Private Sub qtd_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles qtd_site.SelectedIndexChanged
        qtd_section.Items.Clear()
        If qtd_site.SelectedIndex > 0 Then
            If Not IsNothing(db_sections) Then
                Dim idx As Integer = 1
                translations.load("commonForm")
                qtd_section.Items.Add(translations.getText("dropdownSelectAll"))
                If Not qtd_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                    For i = 0 To db_sections.Item("cod_section").Count - 1
                        If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(qtd_site.SelectedIndex - 1)) Then
                            qtd_section.Items.Add(db_sections.Item("description")(i))
                            qtdSectionsIndex(idx) = i
                            idx = idx + 1
                        End If
                    Next
                End If
            End If

            If qtd_section.Items.Count > 0 Then
                qtd_section.SelectedIndex = 0
            End If

        End If
    End Sub


    Private Sub qtd_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles qtd_datatable.CellMouseClick
        bordereau_datatable_cellY = e.RowIndex
        bordereau_datatable_cellX = e.ColumnIndex
        If e.RowIndex.Equals(-1) Or e.ColumnIndex.Equals(-1) Then
            Exit Sub
        End If
    End Sub

    Private Sub qtd_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles qtd_datatable.CellValueNeeded
        If UBound(bordereauTable, 1) < e.RowIndex Or UBound(bordereauTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If

        If qtd_qtdChk.Checked And e.ColumnIndex.Equals(TOTAL_QUANTITIES_DONE_COL) Then
            If Not bordereauTable(e.RowIndex, e.ColumnIndex).Equals("") AndAlso IsNumeric(Convert.ToDouble(bordereauTable(e.RowIndex, e.ColumnIndex), CultureInfo.InvariantCulture)) Then
                If Convert.ToDouble(bordereauTable(e.RowIndex, e.ColumnIndex), CultureInfo.InvariantCulture) < 0 Then
                    qtd_datatable.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                End If
            End If
        End If

        If qtd_amountsChk.Checked And e.ColumnIndex.Equals(TOTAL_AMOUNTS_DONE_COL) Then
            If Not bordereauTable(e.RowIndex, e.ColumnIndex).Equals("") AndAlso IsNumeric(Double.Parse(bordereauTable(e.RowIndex, e.ColumnIndex), Globalization.NumberStyles.Currency)) Then
                If Double.Parse(bordereauTable(e.RowIndex, e.ColumnIndex), Globalization.NumberStyles.Currency) < 0 Then
                    qtd_datatable.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
                End If
            End If
        End If

        e.Value = bordereauTable(e.RowIndex, e.ColumnIndex)
        currentBorderauDatatable = qtd_datatable
    End Sub

    Private Sub qtd_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles qtd_datatable.CellMouseDoubleClick
        qtd_datatable_cellY = e.RowIndex
        qtd_datatable_cellX = e.ColumnIndex
        qtd_site_index = qtd_site.SelectedIndex
        If qtd_datatable_cellY.Equals(-1) Or qtd_datatable_cellX.Equals(-1) Then
            Exit Sub
        End If
        translations.load("siteActivity")
        If Not bordereauTableState(e.RowIndex, 0).Equals(translations.getText("regieSection")) And Not bordereauTable(e.RowIndex, 0).Equals("SUBTOT") And Not bordereauTable(e.RowIndex, 0).Equals("TOT") _
            And Not bordereauTable(e.RowIndex, 0).Equals("R") And Not bordereauTable(e.RowIndex, 0).Equals("G") And Not bordereauTable(e.RowIndex, 0).Equals("M") Then
            If siteProductionEditTasks_frm.ShowDialog() = DialogResult.OK Then
                load_list_bordereau()
                If qtd_datatable.Rows.Count >= qtd_datatable_cellY Then
                    qtd_datatable.CurrentCell = qtd_datatable.Rows(qtd_datatable_cellY).Cells(0)
                End If
            End If
        End If

    End Sub
    Private Sub qtd_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles qtd_datatable.CellContentClick

    End Sub


    Private Sub LoadBordereau_Click_1(sender As Object, e As EventArgs) Handles LoadBordereau.Click
        DropClickSearchBox(LoadBordereau)
        load_list_bordereau()
    End Sub


    Sub load_list_bordereau()
        If qtd_site.SelectedIndex < 1 And qtd_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        If qtd_qtdChk.Checked.Equals(False) And qtd_amountsChk.Checked.Equals(False) Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("errorTasksSearchParameters")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

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

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = qtd_datatable.Width
        mask.Height = qtd_datatable.Height
        mask.Location = New Drawing.Point(qtd_datatable.Location.X, qtd_datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TabControl.TabPages(1).Controls.Add(mask)
        mask.BringToFront()
        enableButtonsAndLinks(Me, False)
        updated = False

        If Not IsNothing(bwLoadBordereau) Then
            If bwLoadBordereau.IsBusy Then
                bwLoadBordereau.CancelAsync()
            End If
        End If
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("commServer")

        bwLoadBordereau = New BackgroundWorker()
        bwLoadBordereau.WorkerSupportsCancellation = True
        bwLoadBordereau.RunWorkerAsync()
    End Sub

    Private Sub Bordereau_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadBordereau.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim qsection As String = ""
        Dim qSite As String = ""

        translations.load("commonForm")
        qtd_section.Invoke(Sub()
                               If qtd_section.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                                   qsection = "all"
                               Else
                                   qsection = db_sections.Item("cod_section")(qtdSectionsIndex(qtd_section.SelectedIndex))
                               End If
                           End Sub)
        qtd_site.Invoke(Sub()
                            qSite = query_site.Item("cod_site")(qtd_site.SelectedIndex - 1)

                        End Sub)

        vars.Add("task", "6")
        vars.Add("request", "bordereau")
        vars.Add("site", qSite)
        vars.Add("section", qsection)

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        DbBordereau = request.ConvertDataToArray("bordereau", state.queryBordereauFields, response)
        If IsNothing(DbBordereau) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

        vars = New Dictionary(Of String, String)

        Dim params As String = "1" ' 1 - daily 2- weekly 3-monthly

        params = If(qtd_amountsChk.Checked.Equals(True), params & ",1", params & ",0")
        params = If(qtd_amountsChk.Checked.Equals(True), params & ",1", params & ",0")
        params = If(qtd_qtdChk.Checked.Equals(True), params & ",1", params & ",0")
        params = If(qtd_qtdChk.Checked.Equals(True), params & ",1", params & ",0")
        params = params & ",0" ' hours
        params = params & ",0" ' RUP

        vars = New Dictionary(Of String, String)
        vars.Add("task", "19")
        vars.Add("request", "load")
        vars.Add("p", params)
        vars.Add("section", qsection)
        vars.Add("site", qSite)
        qtd_data_inicio.Invoke(Sub()
                                   vars.Add("sd", qtd_data_inicio.Value.ToString("yyyy-MM-dd"))
                               End Sub)
        qtd_data_fim.Invoke(Sub()
                                vars.Add("ed", qtd_data_fim.Value.ToString("yyyy-MM-dd"))
                            End Sub)


        request = New HttpData(state)
        response = request.RequestData(vars)

        If Not IsResponseOk(response) Then
            errorFlag = True
            errorMsg = GetMessage(response)
            GoTo lastLine
        End If

        PREVIOUS_QUANTITIES_COL = 7
        TOTAL_QUANTITIES_DONE_COL = 10
        TOTAL_QUANTITIES_TODO_COL = 11
        TOTAL_AMOUNTS_DONE_COL = 10
        TOTAL_AMOUNTS_TODO_COL = 11
        SUBTOTAL_AMOUNTS_COL = TOTAL_AMOUNTS_DONE_COL - 1
        BORDEREAU_BASE_COLUMNS = 9

        Dim section_counter As Integer = -1
        Dim task_counter As Integer = -1
        Dim work_counter As Integer = -1
        Dim max_num_dates As Integer = 0

        Dim TempWork As bordereau_works_json
        Dim tempCounter As Integer = 0
        Dim hasWorks As Boolean = False
        Dim rowpos As Integer = 0
        Dim numRows As Integer = 0

        Dim grutierPos As Integer = -1
        Dim regiePos As Integer = -1
        Dim machinistPos As Integer = -1
        Dim machinistPosWorks As Integer = -1
        Dim grutierPosWorks As Integer = -1
        Dim regiePosWorks As Integer = -1
        Dim previousQtd() As Double
        Dim baseCols As Integer = BORDEREAU_BASE_COLUMNS

        If qtd_qtdChk.Checked Then
            baseCols += 2
            TOTAL_AMOUNTS_DONE_COL += 2
            TOTAL_AMOUNTS_TODO_COL += 2
            SUBTOTAL_AMOUNTS_COL = TOTAL_AMOUNTS_DONE_COL - 1
        End If
        If qtd_amountsChk.Checked Then
            baseCols += 2
        End If
        If qtd_amountsChk.Checked Or qtd_amountsChk.Checked Then
            baseCols += 2 ' total number for the next column not the total number of base cols
        End If
        Dim numColsData As Integer = 0
        If qtd_qtdChk.Checked Then
            numColsData = 2
        End If
        If qtd_amountsChk.Checked And qtd_qtdChk.Checked Then
            numColsData = 4
        ElseIf qtd_amountsChk.Checked Then
            numColsData = 2
        End If

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim sections As JArray = JArray.Parse(data.Item("data").ToString)

            For Each section In sections
                rowpos = rowpos + 1
                Dim tasks As JArray = JArray.Parse(section.Item("bordereau").ToString)
                Dim prevTask As String = "n"
                For Each task In tasks
                    If Not task.Item("avenant").ToString.Equals(prevTask) Then
                        rowpos = rowpos + 2
                        prevTask = task.Item("avenant").ToString
                    End If
                    rowpos = rowpos + 1
                Next task
                If prevTask.Equals("s") Then
                    rowpos = rowpos + 1
                End If
                rowpos = rowpos + 8

                If Not IsNothing(section.Item("works")) Then
                    Dim works As JArray = JArray.Parse(section.Item("works").ToString)
                    For Each work In works
                        If Not work.Item("date").ToString.Equals("1970-01-01") Then
                            If Not ArrDates.Contains(Convert.ToDateTime(work.Item("date").ToString)) Then
                                ArrDates.Add(Convert.ToDateTime(work.Item("date").ToString))
                            End If
                        End If
                    Next work
                End If
            Next section


            ReDim bordereauTable(rowpos, baseCols + ArrDates.Count * numColsData)
            ReDim bordereauTableState(rowpos, 5)
            ReDim previousQtd(rowpos)

            For i = 0 To rowpos
                bordereauTableState(i, 0) = ""
                bordereauTableState(i, 1) = ""
                bordereauTableState(i, 2) = ""
                bordereauTableState(i, 3) = ""
                bordereauTableState(i, 4) = ""
                bordereauTableState(i, 5) = ""

                For j = 0 To baseCols + ArrDates.Count * numColsData
                    bordereauTable(i, j) = ""
                Next j
            Next i

            ReDim Preserve qtdworks(0)
            ArrDates.Clear()
            rowpos = 0
            translations.load("siteActivity")
            For Each section In sections
                bordereauTableState(rowpos, 0) = translations.getText("regieSection")

                bordereauTable(rowpos, 0) = "-"
                bordereauTable(rowpos, 1) = "-"
                bordereauTable(rowpos, 2) = section.Item("name").ToString
                bordereauTable(rowpos, 3) = "-"
                bordereauTable(rowpos, 4) = "-"
                bordereauTable(rowpos, 5) = "-"
                bordereauTable(rowpos, 6) = "-"

                rowpos = rowpos + 1
                hasWorks = False

                Dim tasks As JArray = JArray.Parse(section.Item("bordereau").ToString)
                Dim prevTask As String = "n"
                For Each task In tasks
                    If Not task.Item("avenant").ToString.Equals(prevTask) Then
                        bordereauTable(rowpos, 0) = "SUBTOT"
                        bordereauTable(rowpos, 1) = ""
                        bordereauTable(rowpos, 2) = translations.getText("tasksSubTotal")
                        bordereauTable(rowpos, 3) = ""
                        bordereauTable(rowpos, 4) = ""
                        bordereauTable(rowpos, 5) = ""
                        bordereauTable(rowpos, 6) = ""
                        bordereauTableState(rowpos, 1) = "3"
                        rowpos = rowpos + 1

                        bordereauTable(rowpos, 0) = ""
                        bordereauTable(rowpos, 1) = ""
                        bordereauTable(rowpos, 2) = translations.getText("tasksAmendments")
                        bordereauTable(rowpos, 3) = ""
                        bordereauTable(rowpos, 4) = ""
                        bordereauTable(rowpos, 5) = ""
                        bordereauTable(rowpos, 6) = ""
                        bordereauTableState(rowpos, 1) = "2"
                        rowpos = rowpos + 1
                        prevTask = "s"

                    End If

                    bordereauTable(rowpos, 0) = task.Item("task").ToString
                    bordereauTable(rowpos, 1) = task.Item("ref").ToString ' R for Regie, M for machinist, G for Grutier
                    bordereauTable(rowpos, 2) = task.Item("description").ToString
                    bordereauTable(rowpos, 3) = If(IsNumeric(task.Item("pu").ToString) AndAlso Not Convert.ToDouble(task.Item("pu").ToString, CultureInfo.InvariantCulture).Equals(0), task.Item("pu").ToString, "")
                    bordereauTable(rowpos, 4) = If(IsNumeric(task.Item("qtd").ToString) AndAlso Not Convert.ToDouble(task.Item("qtd").ToString, CultureInfo.InvariantCulture).Equals(0), task.Item("qtd").ToString, "")
                    bordereauTable(rowpos, 5) = task.Item("units").ToString
                    bordereauTable(rowpos, 6) = ""
                    bordereauTableState(rowpos, 0) = task.Item("avenant").ToString
                    bordereauTableState(rowpos, 1) = task.Item("enabled").ToString
                    bordereauTableState(rowpos, 2) = section.Item("code").ToString
                    bordereauTableState(rowpos, 3) = qSite
                    bordereauTableState(rowpos, 4) = task.Item("translations").ToString
                    bordereauTableState(rowpos, 5) = task.Item("original").ToString

                    previousQtd(rowpos) = Convert.ToDouble(task.Item("previous").ToString, CultureInfo.InvariantCulture)
                    prevTask = bordereauTableState(rowpos, 0)
                    rowpos = rowpos + 1

                Next task
                If prevTask.Equals("s") Then
                    ' sub totals avenants
                    bordereauTable(rowpos, 0) = "SUBTOT"
                    bordereauTable(rowpos, 1) = ""
                    bordereauTable(rowpos, 2) = translations.getText("tasksSubTotal")
                    bordereauTable(rowpos, 3) = ""
                    bordereauTable(rowpos, 4) = ""
                    bordereauTable(rowpos, 5) = ""
                    bordereauTable(rowpos, 6) = ""
                    bordereauTableState(rowpos, 1) = "3"
                    rowpos = rowpos + 1
                End If

                ' add works at hour: craneman, machinist regie
                bordereauTable(rowpos, 0) = ""
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksTableRowWorkByHour")
                bordereauTable(rowpos, 3) = ""
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = ""
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "0"
                rowpos = rowpos + 1
                'CRANEMAN
                bordereauTable(rowpos, 0) = "C"
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksTableRowWorkCraneman")
                qtd_site.Invoke(Sub()
                                    bordereauTable(rowpos, 3) = query_site.Item("craneman_hourly")(qtd_site.SelectedIndex - 1)
                                End Sub)
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = "h"
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "1"
                If Not IsNothing(section.Item("previousbyhour")) Then
                    Dim previousbyhourArray As JArray = JArray.Parse(section.Item("previousbyhour").ToString)
                    For Each previousbyhour In previousbyhourArray
                        If previousbyhour.Item("task").ToString.Equals("M") Then
                            previousQtd(rowpos) = Convert.ToDouble(previousbyhour.Item("qtdone").ToString, CultureInfo.InvariantCulture)
                        End If
                    Next previousbyhour
                End If
                rowpos = rowpos + 1
                'MACHINIST
                bordereauTable(rowpos, 0) = "M"
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksTableRowWorkMachinist")
                qtd_site.Invoke(Sub()
                                    bordereauTable(rowpos, 3) = query_site.Item("machinist_hourly")(qtd_site.SelectedIndex - 1)
                                End Sub)
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = "h"
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "1"
                If Not IsNothing(section.Item("previousbyhour")) Then
                    Dim previousbyhourArray As JArray = JArray.Parse(section.Item("previousbyhour").ToString)
                    For Each previousbyhour In previousbyhourArray
                        If previousbyhour.Item("task").ToString.Equals("M") Then
                            previousQtd(rowpos) = Convert.ToDouble(previousbyhour.Item("qtdone").ToString, CultureInfo.InvariantCulture)
                        End If
                    Next previousbyhour
                End If

                rowpos = rowpos + 1
                'REGIE
                bordereauTable(rowpos, 0) = "R"
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksTableRowWorkRegie")
                qtd_site.Invoke(Sub()
                                    bordereauTable(rowpos, 3) = query_site.Item("regie_hourly")(qtd_site.SelectedIndex - 1)
                                End Sub)
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = "h"
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "1"
                If Not IsNothing(section.Item("previousbyhour")) Then
                    Dim previousbyhourArray As JArray = JArray.Parse(section.Item("previousbyhour").ToString)
                    For Each previousbyhour In previousbyhourArray
                        If previousbyhour.Item("task").ToString.Equals("R") Then
                            previousQtd(rowpos) = Convert.ToDouble(previousbyhour.Item("qtdone").ToString, CultureInfo.InvariantCulture)
                        End If
                    Next previousbyhour
                End If
                rowpos = rowpos + 1

                ' sub totals works at hour
                bordereauTable(rowpos, 0) = "SUBTOT"
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksSubTotal")
                bordereauTable(rowpos, 3) = ""
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = ""
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "3"
                rowpos = rowpos + 1
                '  total global
                bordereauTable(rowpos, 0) = "TOT"
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksTotal")
                bordereauTable(rowpos, 3) = ""
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = ""
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 1) = "4"
                rowpos = rowpos + 1

                bordereauTable(rowpos, 0) = ""
                bordereauTable(rowpos, 1) = ""
                bordereauTable(rowpos, 2) = translations.getText("tasksAddTask")
                bordereauTable(rowpos, 3) = ""
                bordereauTable(rowpos, 4) = ""
                bordereauTable(rowpos, 5) = ""
                bordereauTable(rowpos, 6) = ""
                bordereauTableState(rowpos, 2) = section.Item("code").ToString
                bordereauTableState(rowpos, 3) = qSite
                rowpos = rowpos + 1

                If Not IsNothing(section.Item("works")) Then
                    Dim works As JArray = JArray.Parse(section.Item("works").ToString)
                    If (If(work_counter < 0, 0, work_counter) + works.Count) > UBound(qtdworks, 1) Then
                        ReDim Preserve qtdworks(If(work_counter < 0, 0, work_counter) + works.Count - 1)
                    End If
                    For Each work In works
                        work_counter = work_counter + 1
                        qtdworks(work_counter).qtdone = Convert.ToDouble(work.Item("qtdone").ToString, CultureInfo.InvariantCulture)
                        qtdworks(work_counter).data = Convert.ToDateTime(work.Item("date").ToString)
                        qtdworks(work_counter).task = work.Item("task").ToString
                        qtdworks(work_counter).rup = Convert.ToDouble(If(Not IsNothing(work.Item("rup")), work.Item("rup").ToString(), "0"), CultureInfo.InvariantCulture)
                        qtdworks(work_counter).hours = Convert.ToDouble(If(Not IsNothing(work.Item("hours")), work.Item("hours").ToString(), "0"), CultureInfo.InvariantCulture)

                        If Not ArrDates.Contains(qtdworks(work_counter).data) And Not work.Item("date").ToString.Equals("1970-01-01") Then '1970 for grutier and regie
                            ArrDates.Add(qtdworks(work_counter).data)
                        End If
                    Next work
                    hasWorks = True

                    tempCounter = -1
                    ArrDates.Sort()
                    For Each arr In ArrDates
                        tempCounter = tempCounter + 1
                        For i = 0 To UBound(qtdworks)
                            If arr.ToString("yyyy-MM-dd").Equals(qtdworks(i).data.ToString("yyyy-MM-dd")) Then
                                TempWork = qtdworks(i)
                                qtdworks(i) = qtdworks(tempCounter)
                                qtdworks(tempCounter) = TempWork
                            End If
                        Next i
                    Next arr
                End If

            Next section
        Catch ex As Exception
            errorFlag = True
            errorMsg = ex.Message.ToString
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            GoTo lastLine
        End Try



        If hasWorks Then

            Dim sumToDoAtDate As Double = 0.0
            Dim sumDoneAtDate As Double = 0.0
            Dim sumLineQtdDone As Double = 0.0

            Dim sumSubTotalPrevious As Double = 0.0
            Dim sumTotalPrevious As Double = 0.0

            Dim sumSubTotals() As Double
            Dim sumTotals() As Double

            ReDim sumSubTotals(ArrDates.Count * 2 + 2)
            ReDim sumTotals(ArrDates.Count * 2 + 2)
            For i = 0 To ArrDates.Count * 2 + 2
                sumSubTotals(i) = 0.0
                sumTotals(i) = 0.0
            Next i

            Dim qrPos As Integer = -1
            Dim qprPos As Integer = -1
            Dim mrPos As Integer = -1
            Dim mprPos As Integer = -1

            Dim SqrPos As Integer = -1
            Dim SqprPos As Integer = -1
            Dim SmrPos As Integer = -1
            Dim SmprPos As Integer = -1

            Dim hasValuesDone As Boolean
            Dim hasValuesToDo As Boolean
            Dim fields As String = ""

            Dim allCols As Integer = 0
            Dim temp As Double = 0.0

            If qtd_qtdChk.Checked Then
                SqrPos = 0
                SqprPos = 1
                numColsData = 2
                allCols = 2
            End If
            If qtd_amountsChk.Checked And qtd_qtdChk.Checked Then
                SmrPos = 2
                SmprPos = 3
                numColsData = 4
            ElseIf qtd_amountsChk.Checked Then
                SmrPos = 0
                SmprPos = 1
                allCols = 0
                numColsData = 2
            End If

            For k = 0 To UBound(bordereauTable)
                ' previuous dates values
                bordereauTable(k, PREVIOUS_QUANTITIES_COL) = If(IsNumeric(previousQtd(k)) AndAlso Not previousQtd(k).Equals(0), previousQtd(k), "")
                temp = If(IsNumeric(previousQtd(k)) And IsNumeric(bordereauTable(k, 3)) AndAlso Not previousQtd(k).Equals(0), previousQtd(k) * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture), 0.0)
                sumSubTotalPrevious += temp
                sumTotalPrevious += temp
                bordereauTable(k, PREVIOUS_QUANTITIES_COL + 1) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp.ToString("C"), "")

                If bordereauTableState(k, 1).Equals("1") Then
                    'ADD records of WORKS at date
                    qrPos = baseCols + SqrPos
                    mrPos = baseCols + SmrPos
                    qprPos = baseCols + SqprPos
                    mprPos = baseCols + SmprPos

                    sumLineQtdDone = 0.0
                    For l = 0 To ArrDates.Count - 1
                        sumToDoAtDate = 0.0
                        hasValuesToDo = False
                        sumDoneAtDate = 0.0
                        hasValuesDone = False

                        For m = 0 To UBound(qtdworks)
                            If qtdworks(m).task.Equals(bordereauTable(k, 0)) And DateTime.Compare(qtdworks(m).data, ArrDates(l)) = 0 Then
                                sumDoneAtDate += qtdworks(m).qtdone
                                hasValuesDone = True
                            End If
                            If qtdworks(m).task.Equals(bordereauTable(k, 0)) And DateTime.Compare(qtdworks(m).data, ArrDates(l)) <= 0 Then
                                hasValuesToDo = If(DateTime.Compare(qtdworks(m).data, ArrDates(l)) = 0, True, If(hasValuesToDo.Equals(True), True, False))
                                sumToDoAtDate += qtdworks(m).qtdone
                            End If
                        Next m



                        sumLineQtdDone += sumDoneAtDate
                        sumToDoAtDate += previousQtd(k)
                        If qtd_acumulatedResultsChk.Checked Then
                            sumDoneAtDate += previousQtd(k)
                        End If
                        If hasValuesDone Then
                            If qtd_qtdChk.Checked Then
                                bordereauTable(k, qrPos) = If(IsNumeric(sumDoneAtDate) AndAlso Not (sumDoneAtDate).Equals(0), (sumDoneAtDate).ToString("F2"), "")
                            End If
                            If qtd_amountsChk.Checked Then
                                temp = (If(IsNumeric(bordereauTable(k, 3)), Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture) * (sumDoneAtDate), 0.0))
                                bordereauTable(k, mrPos) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp.ToString("C"), "")

                                sumSubTotals(2 + l) += temp
                                sumTotals(2 + l) += temp
                            End If
                        End If

                        If hasValuesToDo And Not bordereauTable(k, 0).Equals("C") And Not bordereauTable(k, 0).Equals("G") And Not bordereauTable(k, 0).Equals("R") Then
                            If qtd_qtdChk.Checked Then
                                temp = (If(IsNumeric(bordereauTable(k, 4)), Convert.ToDouble(bordereauTable(k, 4).Replace(",", "."), CultureInfo.InvariantCulture), 0.0) - sumToDoAtDate)
                                bordereauTable(k, qprPos) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp.ToString("F2"), "")
                            End If
                            If qtd_amountsChk.Checked Then
                                temp = (If(IsNumeric(bordereauTable(k, 4)) And IsNumeric(bordereauTable(k, 3)), Convert.ToDouble(bordereauTable(k, 4).Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture) - (sumToDoAtDate) * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture), 0.0))
                                bordereauTable(k, mprPos) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp.ToString("C"), "")

                                sumSubTotals(3 + l) += temp
                                sumTotals(3 + l) += temp
                            End If
                        End If

                        qrPos += numColsData
                        mrPos += numColsData
                        qprPos += numColsData
                        mprPos += numColsData
                    Next l

                    If qtd_acumulatedResultsChk.Checked Then
                        sumLineQtdDone += previousQtd(k)
                    End If

                    If qtd_qtdChk.Checked Then  ' total qtd realizada
                        bordereauTable(k, TOTAL_QUANTITIES_DONE_COL) = If(IsNumeric(sumLineQtdDone) AndAlso Not temp.Equals(0), sumLineQtdDone.ToString("F2"), "")

                        If Not bordereauTable(k, 0).Equals("C") And Not bordereauTable(k, 0).Equals("G") And Not bordereauTable(k, 0).Equals("R") Then
                            temp = (If(IsNumeric(bordereauTable(k, 4)), Convert.ToDouble(bordereauTable(k, 4).Replace(",", "."), CultureInfo.InvariantCulture) - (sumLineQtdDone + previousQtd(k)), 0.0))
                            temp = If(temp < 0, 0, temp)
                            bordereauTable(k, TOTAL_QUANTITIES_TODO_COL) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp.ToString("F2"), "")
                        End If
                    End If

                    If qtd_amountsChk.Checked Then ' total mont. realizado
                        temp = If(IsNumeric(bordereauTable(k, 3)), sumLineQtdDone * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture), 0.0)
                        sumSubTotals(0) += temp
                        sumTotals(0) += temp
                        bordereauTable(k, TOTAL_AMOUNTS_DONE_COL) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp, "")

                        If Not bordereauTable(k, 0).Equals("C") And Not bordereauTable(k, 0).Equals("G") And Not bordereauTable(k, 0).Equals("R") Then
                            temp = If(IsNumeric(bordereauTable(k, 4)) And IsNumeric(bordereauTable(k, 3)), Convert.ToDouble(bordereauTable(k, 4).Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture) - (sumLineQtdDone + previousQtd(k)) * Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture), 0.0)
                            temp = If(temp < 0, 0, temp)
                            sumSubTotals(1) += (temp)
                            sumTotals(1) += (temp)
                            bordereauTable(k, TOTAL_AMOUNTS_TODO_COL) = If(IsNumeric(temp) AndAlso Not temp.Equals(0), temp, "")
                        End If
                    End If
                End If

                'sub totals and totals amounts
                If bordereauTable(k, 0).Equals("SUBTOT") Then
                    bordereauTable(k, PREVIOUS_QUANTITIES_COL + 1) = If(IsNumeric(sumSubTotalPrevious) AndAlso Not sumSubTotalPrevious.Equals(0), sumSubTotalPrevious.ToString("C"), (0.0).ToString("C"))
                    If qtd_amountsChk.Checked Then ' total mont. realizado
                        bordereauTable(k, TOTAL_AMOUNTS_DONE_COL) = sumSubTotals(0).ToString("C")
                        bordereauTable(k, TOTAL_AMOUNTS_TODO_COL) = sumSubTotals(1).ToString("C")
                    End If
                    'zero out subtotals vars
                    'zero out subtotals vars
                    sumSubTotalPrevious = 0.0
                    ' done total amounts
                    sumSubTotals(0) = 0.0
                    'todo total amounts
                    sumSubTotals(1) = 0.0
                    mrPos = baseCols + SmrPos
                    mprPos = baseCols + SmprPos
                    For l = 0 To ArrDates.Count - 1
                        If qtd_amountsChk.Checked Then
                            bordereauTable(k, mrPos) = sumSubTotals(2 + l).ToString("C")
                            bordereauTable(k, mprPos) = sumSubTotals(3 + l).ToString("C")
                            sumSubTotals(2 + l) = 0.0
                            sumSubTotals(3 + l) = 0.0
                        End If
                        mrPos += numColsData
                        mprPos += numColsData
                    Next l
                ElseIf bordereauTable(k, 0).Equals("TOT") Then
                    bordereauTable(k, PREVIOUS_QUANTITIES_COL + 1) = If(IsNumeric(sumTotalPrevious) AndAlso Not sumTotalPrevious.Equals(0), sumTotalPrevious.ToString("C"), (0.0).ToString("C"))
                    If qtd_amountsChk.Checked Then ' total mont. realizado
                        bordereauTable(k, TOTAL_AMOUNTS_DONE_COL) = sumTotals(0).ToString("C")
                        bordereauTable(k, TOTAL_AMOUNTS_TODO_COL) = sumTotals(1).ToString("C")
                    End If
                    'zero out totals vars
                    sumTotalPrevious = 0.0
                        ' done total amounts
                        sumTotals(0) = 0.0
                        'todo total amounts
                        sumTotals(1) = 0.0
                        mrPos = baseCols + SmrPos
                        mprPos = baseCols + SmprPos
                        For l = 0 To ArrDates.Count - 1
                            If qtd_amountsChk.Checked Then
                                bordereauTable(k, mrPos) = sumTotals(2 + l).ToString("C")
                                bordereauTable(k, mprPos) = sumTotals(3 + l).ToString("C")
                                sumTotals(2 + l) = 0.0
                                sumTotals(3 + l) = 0.0
                            End If
                            mrPos += numColsData
                            mprPos += numColsData
                        Next l
                    End If
            Next k

            'remove zeros
            For k = 0 To UBound(bordereauTable)
                If qtd_qtdChk.Checked Then
                    bordereauTable(k, TOTAL_QUANTITIES_DONE_COL) = If(IsNumeric(bordereauTable(k, TOTAL_QUANTITIES_DONE_COL)) AndAlso Not Convert.ToDouble(bordereauTable(k, TOTAL_QUANTITIES_DONE_COL), CultureInfo.InvariantCulture).Equals(0), bordereauTable(k, TOTAL_QUANTITIES_DONE_COL), "")
                    bordereauTable(k, TOTAL_QUANTITIES_TODO_COL) = If(IsNumeric(bordereauTable(k, TOTAL_QUANTITIES_TODO_COL)) AndAlso Not Convert.ToDouble(bordereauTable(k, TOTAL_QUANTITIES_TODO_COL), CultureInfo.InvariantCulture).Equals(0), bordereauTable(k, TOTAL_QUANTITIES_TODO_COL), "")
                End If
                If qtd_amountsChk.Checked Then
                    If IsNumeric(bordereauTable(k, TOTAL_AMOUNTS_TODO_COL)) AndAlso Not Double.Parse(bordereauTable(k, TOTAL_AMOUNTS_TODO_COL), Globalization.NumberStyles.Currency).Equals(0) Then
                        bordereauTable(k, TOTAL_AMOUNTS_TODO_COL) = Double.Parse(bordereauTable(k, TOTAL_AMOUNTS_TODO_COL), Globalization.NumberStyles.Currency).ToString("C")
                    ElseIf bordereauTable(k, 0).Equals("SUBTOT") Or bordereauTable(k, 0).Equals("TOT") Then
                        bordereauTable(k, TOTAL_AMOUNTS_TODO_COL) = (0.0).ToString("C")
                    End If

                    If IsNumeric(bordereauTable(k, TOTAL_AMOUNTS_DONE_COL)) AndAlso Not Double.Parse(bordereauTable(k, TOTAL_AMOUNTS_DONE_COL), Globalization.NumberStyles.Currency).Equals(0) Then
                        bordereauTable(k, TOTAL_AMOUNTS_DONE_COL) = Double.Parse(bordereauTable(k, TOTAL_AMOUNTS_DONE_COL), Globalization.NumberStyles.Currency).ToString("C")
                    ElseIf bordereauTable(k, 0).Equals("SUBTOT") Or bordereauTable(k, 0).Equals("TOT") Then
                        bordereauTable(k, TOTAL_AMOUNTS_DONE_COL) = (0.0).ToString("C")
                    End If
                End If
                bordereauTable(k, 3) = If(Not IsNumeric(bordereauTable(k, 3)), "", (Convert.ToDouble(bordereauTable(k, 3).Replace(",", "."), CultureInfo.InvariantCulture)).ToString("C"))
            Next k
        End If

lastLine:
        Dim s(3) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            s(2) = ""
            s(3) = ""
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = rowpos
            s(2) = baseCols
            s(3) = If(hasWorks, "true", "false")

            e.Result = s
        End If

    End Sub

    Private Sub Bordereau_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadBordereau.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            mask.Dispose()
            updated = True
            enableButtonsAndLinks(Me, True)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            updated = True
            enableButtonsAndLinks(Me, True)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Exit Sub
        End If
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")

        Dim rowpos As Integer = e.Result(1)
        Dim nextCol As Integer
        Dim baseCols As Integer = e.Result(2)
        Dim hasWorks As Boolean = If(e.Result(3).Equals("true"), True, False)
        Dim size As Integer = 0
        Dim prevdate As Date = If(ArrDates.Count.Equals(0), Now(), ArrDates.Item(0))
        Dim colorr As Color = Color.White
        Dim numColsData As Integer = 0
        Dim allCols As Integer = 0
        If qtd_qtdChk.Checked Then
            numColsData = 2
            allCols = 2
        End If
        If qtd_amountsChk.Checked And qtd_qtdChk.Checked Then
            numColsData = 4
        ElseIf qtd_amountsChk.Checked Then
            allCols = 0
            numColsData = 2
        End If

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)
        translations.load("siteActivity")
        SuspendLayout()
        With qtd_datatable
            .Visible = False
            .VirtualMode = True
            .Rows.Clear()
            .RowCount = rowpos

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = If(hasWorks, baseCols, baseCols - 2) + ArrDates.Count * numColsData
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

            .Columns(0).HeaderCell.Value = translations.getText("tasksTableColumnId")
            .Columns(0).Width = g.MeasureString("FFFF", fontToMeasure).Width

            .Columns(1).HeaderCell.Value = translations.getText("tasksTableColumnReference")
            .Columns(1).Width = g.MeasureString("FFFfffFFFfff", fontToMeasure).Width

            .Columns(2).HeaderCell.Value = translations.getText("tasksTableColumnActivityTask")
            .Columns(2).Width = 400
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft


            .Columns(3).HeaderCell.Value = translations.getText("tasksTableColumnUnitPrice")
            .Columns(3).Width = g.MeasureString("88.888.00€", fontToMeasure).Width
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(4).HeaderCell.Value = translations.getText("tasksTableColumnQuantity")
            .Columns(4).Width = g.MeasureString("88.888.00€", fontToMeasure).Width
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(5).HeaderCell.Value = translations.getText("tasksTableColumnUnits")
            .Columns(5).Width = g.MeasureString(translations.getText("tasksTableColumnUnits") & "....", fontToMeasure).Width
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(6).HeaderCell.Value = ""
            .Columns(6).Width = 25
            .Columns(6).DefaultCellStyle.BackColor = Color.MistyRose
            .Columns(6).Width = 30

            .Columns(7).HeaderCell.Value = translations.getText("tasksTableColumnQuantityDone") & Environment.NewLine & translations.getText("tasksTableColumnPrevious")
            .Columns(7).Width = g.MeasureString(translations.getText("tasksTableColumnPrevious") & "....", fontToMeasure).Width
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Columns(8).HeaderCell.Value = translations.getText("tasksTableColumnAmountDone") & Environment.NewLine & translations.getText("tasksTableColumnPrevious")
            .Columns(8).Width = g.MeasureString(translations.getText("tasksTableColumnPrevious") & "....", fontToMeasure).Width
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            If hasWorks Then 'add works dates
                .Columns(9).HeaderCell.Value = ""
                .Columns(9).Width = 25
                .Columns(9).DefaultCellStyle.BackColor = Color.MistyRose
                .Columns(9).Width = 30

                nextCol = 9

                If qtd_qtdChk.Checked Then
                    .Columns(nextCol + 1).HeaderCell.Value = If(qtd_acumulatedResultsChk.Checked, Convert.ToChar(&H3A3) & " ", "") & translations.getText("tasksTableColumnQuantityDone") & Environment.NewLine & translations.getText("tasksTableTotals")
                    .Columns(nextCol + 1).Width = g.MeasureString("88.888.00", fontToMeasure).Width
                    .Columns(nextCol + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                    .Columns(nextCol + 2).HeaderCell.Value = translations.getText("tasksTableColumnQuantityToDo") & Environment.NewLine & translations.getText("tasksTableTotals")
                    .Columns(nextCol + 2).Width = g.MeasureString(translations.getText("tasksTableColumnQuantityToDo") & "....", fontToMeasure).Width
                    .Columns(nextCol + 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    nextCol = nextCol + 2
                End If
                If qtd_amountsChk.Checked Then
                    .Columns(nextCol + 1).HeaderCell.Value = If(qtd_acumulatedResultsChk.Checked, Convert.ToChar(&H3A3) & " ", "") & translations.getText("tasksTableColumnAmountDone") & Environment.NewLine & translations.getText("tasksTableTotals")
                    .Columns(nextCol + 1).Width = g.MeasureString("88.888.00", fontToMeasure).Width
                    .Columns(nextCol + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                    .Columns(nextCol + 2).HeaderCell.Value = translations.getText("tasksTableColumnAmountToDo") & Environment.NewLine & translations.getText("tasksTableTotals")
                    .Columns(nextCol + 2).Width = g.MeasureString("88.888.00", fontToMeasure).Width
                    .Columns(nextCol + 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    nextCol = nextCol + 2
                End If
                If qtd_amountsChk.Checked Or qtd_amountsChk.Checked Then
                    .Columns(nextCol + 1).HeaderCell.Value = ""
                    .Columns(nextCol + 1).Width = 25
                    .Columns(nextCol + 1).DefaultCellStyle.BackColor = Color.MistyRose
                    nextCol += 1
                End If


                For j = 0 To ArrDates.Count - 1
                    If Not prevdate.Equals(ArrDates.Item(j)) Then
                        colorr = If(colorr.Equals(Color.White), Color.FloralWhite, Color.White)
                        prevdate = ArrDates.Item(j)
                    End If
                    If qtd_qtdChk.Checked Then
                        .Columns(baseCols + j * numColsData).HeaderCell.Value = If(qtd_acumulatedResultsChk.Checked, Convert.ToChar(&H3A3) & " ", "") & translations.getText("tasksTableColumnQuantityDone") & Environment.NewLine & ArrDates.Item(j).ToString("MM-dd")
                        .Columns(baseCols + j * numColsData + 1).HeaderCell.Value = translations.getText("tasksTableColumnQuantityToDo") & Environment.NewLine & ArrDates.Item(j).ToString("MM-dd")

                        With .Columns(baseCols + j * numColsData).DefaultCellStyle
                            .Alignment = DataGridViewContentAlignment.BottomRight
                            .BackColor = colorr
                        End With
                        With .Columns(baseCols + j * numColsData + 1).DefaultCellStyle
                            .Alignment = DataGridViewContentAlignment.BottomRight
                            .BackColor = colorr
                        End With

                        .Columns(baseCols + j * numColsData).Width = g.MeasureString(.Columns(baseCols + j * numColsData).HeaderCell.Value.ToString.Replace(Environment.NewLine, "") & "...", fontToMeasure).Width
                        .Columns(baseCols + j * numColsData + 1).Width = g.MeasureString(.Columns(baseCols + j * numColsData).HeaderCell.Value.ToString.Replace(Environment.NewLine, "") & "...", fontToMeasure).Width
                    End If
                    If qtd_amountsChk.Checked Then
                        .Columns(baseCols + j * numColsData + allCols).HeaderCell.Value = If(qtd_acumulatedResultsChk.Checked, Convert.ToChar(&H3A3) & " ", "") & translations.getText("tasksTableColumnAmountDone") & Environment.NewLine & ArrDates.Item(j).ToString("MM-dd")
                        .Columns(baseCols + j * numColsData + allCols + 1).HeaderCell.Value = translations.getText("tasksTableColumnAmountToDo") & Environment.NewLine & ArrDates.Item(j).ToString("MM-dd")

                        With .Columns(baseCols + j * numColsData + allCols).DefaultCellStyle
                            .Alignment = DataGridViewContentAlignment.BottomRight
                            .BackColor = colorr
                        End With
                        With .Columns(baseCols + j * numColsData + allCols + 1).DefaultCellStyle
                            .Alignment = DataGridViewContentAlignment.BottomRight
                            .BackColor = colorr
                        End With

                        .Columns(baseCols + j * numColsData + allCols).Width = g.MeasureString(.Columns(baseCols + j * numColsData).HeaderCell.Value.ToString.Replace(Environment.NewLine, "") & "...", fontToMeasure).Width
                        .Columns(baseCols + j * numColsData + allCols + 1).Width = g.MeasureString(.Columns(baseCols + j * numColsData).HeaderCell.Value.ToString.Replace(Environment.NewLine, "") & "...", fontToMeasure).Width
                    End If
                Next j
            End If
            .AutoResizeColumns()
            .Columns(2).Width = 400
            Dim colMaxHEight As Integer = 0
            Dim lines As Integer = 0
            Dim newlines As Integer = 0
            Dim BoldTotalsRow2 As New DataGridViewCellStyle
            BoldTotalsRow2.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Bold)
            BoldTotalsRow2.BackColor = Color.AntiqueWhite
            Dim BoldTotalsRow0 As New DataGridViewCellStyle
            BoldTotalsRow0.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Bold)
            BoldTotalsRow0.BackColor = Color.WhiteSmoke
            Dim BoldTotalsRow3 As New DataGridViewCellStyle
            BoldTotalsRow3.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Bold)
            BoldTotalsRow3.BackColor = Color.Lavender
            Dim BoldTotalsRow4 As New DataGridViewCellStyle
            BoldTotalsRow4.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Bold)
            BoldTotalsRow4.BackColor = Color.Thistle

            For i = 0 To rowpos - 1
                If bordereauTableState(i, 1).Equals("2") Then
                    qtd_datatable.Rows(i).DefaultCellStyle = BoldTotalsRow2
                ElseIf bordereauTableState(i, 1).Equals("0") Then
                    qtd_datatable.Rows(i).DefaultCellStyle = BoldTotalsRow0
                ElseIf bordereauTableState(i, 1).Equals("3") Then
                    qtd_datatable.Rows(i).DefaultCellStyle = BoldTotalsRow3
                ElseIf bordereauTableState(i, 1).Equals("4") Then
                    qtd_datatable.Rows(i).DefaultCellStyle = BoldTotalsRow4
                ElseIf bordereauTableState(i, 0).Equals(translations.getText("regieSection")) Then
                    qtd_datatable.Rows(i).DefaultCellStyle.BackColor = Color.LightSkyBlue
                ElseIf bordereauTable(i, 2).Equals(translations.getText("tasksAmendments")) Then
                    qtd_datatable.Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf bordereauTable(i, 2).Equals(translations.getText("tasksAddTaskEntry")) Then
                    qtd_datatable.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                End If

                colMaxHEight = 0
                newlines = 0
                For j = 0 To 5
                    sizeOfString = g.MeasureString(bordereauTable(i, j), fontToMeasure)
                    lines = Math.Truncate(sizeOfString.Width / .Columns(j).Width) + 1
                    newlines = bordereauTable(i, j).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * colMaxHEight
            Next i
            .Visible = True
        End With
        ResumeLayout()
        mask.Dispose()
        updated = True
        enableButtonsAndLinks(Me, True)
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub qtd_setCurrentMonth_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles qtd_setCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        qtd_data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        qtd_data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    ' _______________________________________________________________________________________
    ' REGIE WORKS
    ' _______________________________________________________________________________________

    Private Sub regie_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles regie_site.SelectedIndexChanged
        regie_section.Items.Clear()
        If regie_site.SelectedIndex > 0 Then
            If IsDate(query_site.Item("data_inicio")(regie_site.SelectedIndex - 1)) Then
                regie_data_inicio.Value = query_site.Item("data_inicio")(regie_site.SelectedIndex - 1)
            Else
                regie_data_inicio.Value = DateTime.Now
            End If

            If IsDate(query_site.Item("data_fim")(regie_site.SelectedIndex - 1)) Then
                regie_data_fim.Value = query_site.Item("data_fim")(regie_site.SelectedIndex - 1)
            Else
                regie_data_fim.Value = DateTime.Now
            End If

            If Not IsNothing(db_sections) Then
                Dim idx As Integer = 1
                translations.load("commonForm")
                regie_section.Items.Add(translations.getText("dropdownSelectAll"))
                If Not regie_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                    For i = 1 To db_sections.Item("cod_section").Count - 1
                        If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(regie_site.SelectedIndex - 1)) Then
                            regie_section.Items.Add(db_sections.Item("description")(i))
                            regieSectionsIndex(idx) = i
                            idx = idx + 1
                        End If
                    Next
                End If
            End If
            If regie_section.Items.Count > 0 Then
                regie_section.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub regie_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regie_datatable.CellContentClick

    End Sub

    Private Sub regie_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles regie_datatable.CellMouseDoubleClick
        regie_datatable_cellY = e.RowIndex
        regie_datatable_cellX = e.ColumnIndex
        If e.RowIndex.Equals(-1) Or e.ColumnIndex.Equals(-1) Then
            Exit Sub
        End If
        translations.load("siteActivity")
        If Not regieTable(e.RowIndex, 0).Equals(translations.getText("regieSection")) And Not regieTable(e.RowIndex, 2).Equals(translations.getText("tasksTotal")) Then
            regie_selected_site = regie_site.SelectedIndex
            If siteRegieEdit.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Refresh()
                load_regie_entries()
            End If
        End If

    End Sub

    Private Sub regie_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles regie_datatable.CellMouseClick
        regie_datatable_cellY = e.RowIndex
        regie_datatable_cellX = e.ColumnIndex
        regie_view_photo.Enabled = False
        regie_add_photo.Enabled = True
        regie_del_photo.Enabled = False
        regie_download_photo.Enabled = False
        regiePhotoSelection.Enabled = False
        translations.load("siteActivity")
        regie_photo_title.Text = translations.getText("photoDocument")
        regiePhoto.Image = Nothing
        If regie_datatable_cellY.Equals(-1) Or regie_datatable_cellX.Equals(-1) Then
            Exit Sub
        End If
        If Not regieTable(e.RowIndex, 0).Equals(translations.getText("regieSection")) And Not regieTable(e.RowIndex, 4).Equals("Adicionar marcação manual á regie") And Not regieTable(e.RowIndex, 2).Equals(translations.getText("tasksTotal")) Then
            datatableChanges = False
            If Not regiePhotos(e.RowIndex)(0).code.Equals("-1") Then
                regiePhotoSelection.Items.Clear()
                regie_photo_title.Text = (UBound(regiePhotos(e.RowIndex)) + 1) & translations.getText("photosDocument")
                For i = 0 To UBound(regiePhotos(e.RowIndex))
                    regiePhotoSelection.Items.Add(translations.getText("photo") & " " & (i + 1))
                Next i
                regiePhotoSelection.Enabled = True
            End If
        End If
    End Sub

    Private Sub regiePhotoSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles regiePhotoSelection.SelectedIndexChanged
        translations.load("siteActivity")
        If regiePhotoSelection.SelectedIndex > -1 And Not regieTable(regie_datatable_cellY, 0).Equals(translations.getText("regieSection")) And Not regieTable(regie_datatable_cellY, 3).Equals(translations.getText("regieAddRegieEntry")) Then
            If regiePhotos(regie_datatable_cellY)(regiePhotoSelection.SelectedIndex).code.Equals("-1") Then
                regiePhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                regiePhoto.SizeMode = PictureBoxSizeMode.CenterImage
            Else
                regiePhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "downloading.png")
                regiePhoto.SizeMode = PictureBoxSizeMode.CenterImage

                Dim tClient As WebClient = New WebClient
                Try
                    Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(state.ServerBaseAddr & "/works/files/regie/" & regiePhotos(regie_datatable_cellY)(regiePhotoSelection.SelectedIndex).file))
                    regiePhoto.Image = tImage
                    view_photo.Enabled = True
                    add_photo.Enabled = True
                    del_photo.Enabled = True
                    download_photo.Enabled = True
                Catch ex As Exception
                    regiePhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                    regiePhoto.SizeMode = PictureBoxSizeMode.CenterImage
                    translations.load("errorMessages")
                    MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                regiePhoto.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End If
    End Sub

    Private Sub regie_download_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles regie_download_photo.LinkClicked
        Dim saveFileDialog1 As New SaveFileDialog
        translations.load("commonForm")
        saveFileDialog1.Title = translations.getText("saveImageDialogTitle")
        saveFileDialog1.Filter = translations.getText("saveImageDialogFilter") & " jpg|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim filename = saveFileDialog1.FileName
            regiePhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub regie_view_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles regie_view_photo.LinkClicked
        Dim filename = MainMdiForm.state.basePath & "tmp\regiePhoto.jpg"
        Dim File = New FileInfo(filename)
        File.Refresh()
        If File.Exists Then
            Try
                File.Delete()
            Catch ex As Exception
                translations.load("commonForm")
                MainMdiForm.statusMessage = translations.getText("errorDeletingData")
                Exit Sub
            End Try
        End If
        LivraisonPhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        Process.Start(filename)
    End Sub

    Private Sub regie_del_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles regie_del_photo.LinkClicked
        Dim msgbox As message_box_frm

        If regiePhotoSelection.SelectedIndex > -1 And Not regiePhotos(regie_datatable_cellY)(regiePhotoSelection.SelectedIndex).code.Equals("-1") Then
            translations.load("messagebox")
            Dim message As String = translations.getText("questionDeletePhoto")
            msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If Not msgbox.ShowDialog = DialogResult.OK Then
                Exit Sub
            End If

            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "20")
            vars.Add("request", "del")
            vars.Add("cod", regiePhotos(regie_datatable_cellY)(regiePhotoSelection.SelectedIndex).code)
            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()

            Else
                translations.load("messagebox")
                Dim message2 As String = translations.getText("resultSuccessDelRecord")
                msgbox = New message_box_frm(message2 & " .", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                regiePhotos(livraison_datatable_cellY)(regiePhotoSelection.SelectedIndex).code = "-1"
                regiePhotoSelection.Items.RemoveAt(regiePhotoSelection.SelectedIndex)
                regiePhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                regiePhoto.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        Else
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectPhoto")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & " ?", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If

    End Sub

    Private Sub regie_add_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles regie_add_photo.LinkClicked
        Dim msgbox As message_box_frm
        translations.load("siteActivity")
        If Not regieTable(regie_datatable_cellY, 1).Equals(translations.getText("regieSection")) And Not regieTable(regie_datatable_cellY, 3).Equals(translations.getText("regieAddRegieEntry")) And Not regieCodes(regie_datatable_cellY).Equals("") Then
            translations.load("commonForm")
            Dim OpenFileDialog1 As New OpenFileDialog
            OpenFileDialog1.Title = translations.getText("openFileDialogTitle")
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = translations.getText("saveImageDialogFilter") & " jpg|*.jpg"
            If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                Dim filename = OpenFileDialog1.FileName
                regiePhoto.Image = Image.FromFile(filename)
                regiePhoto.SizeMode = PictureBoxSizeMode.StretchImage

                translations.load("messagebox")
                Dim message As String = translations.getText("questionAddPhoto")
                msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If (msgbox.ShowDialog = DialogResult.OK) Then

                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "20") 'photo
                    vars.Add("request", "add")
                    vars.Add("where", "regie")
                    vars.Add("cod", regieCodes(regie_datatable_cellY))
                    Dim request As New HttpData(state)
                    Dim response As String = request.SendHttpFile(vars, filename)

                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        translations.load("messagebox")
                        msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                        msgbox.ShowDialog()
                    Else
                        load_regie_entries()
                        regiePhotoSelection.Items.Clear()
                    End If
                End If
                regiePhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                regiePhoto.SizeMode = PictureBoxSizeMode.CenterImage
            Else
                translations.load("messagebox")
                Dim message As String = translations.getText("resultErrorAddPhotoSelectedItem")
                msgbox = New message_box_frm(message & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub
    Private Sub regieSetCurrentMonth_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles regieSetCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        regie_data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        regie_data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub regie_do_search_Click(sender As Object, e As EventArgs)
        Dim msgbox As message_box_frm

        If regieSearchBox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf regie_datatable.Rows.Count <= 0 Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchResultsNotFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            Dim ini As Integer = 0
            Dim results As Boolean = False
            If regie_datatable_cellY >= 0 Then
                ini = regie_datatable_cellY + 1
                If ini > regie_datatable.Rows.Count - 1 Then
                    ini = regie_datatable.Rows.Count - 1
                End If
            End If
            For i = ini To regie_datatable.Rows.Count - 1
                If Not regie_datatable.Rows(i).Cells(2).Value.ToString.ToLower.IndexOf(regieSearchBox.Text.ToLower).Equals(-1) Then
                    regie_datatable.Rows(i).Cells(2).Selected = True
                    regie_datatable_cellY = i
                    results = True
                    Exit For
                End If
                If Not regie_datatable.Rows(i).Cells(5).Value.ToString.ToLower.IndexOf(regieSearchBox.Text.ToLower).Equals(-1) Then
                    regie_datatable.Rows(i).Cells(5).Selected = True
                    regie_datatable_cellY = i
                    results = True
                    Exit For
                End If
            Next i

            If Not results Then
                translations.load("infoMessages")
                Dim message As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If

        End If
    End Sub

    Private Sub regie_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles regie_datatable.CellValueNeeded

        If UBound(regieTable, 1) < e.RowIndex Or UBound(regieTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If
        translations.load("siteActivity")
        'completed values:
        '1 - checkout EOD 
        '2 - default EOD
        '3 - ongoing
        '4 - completed
        If regieTable(e.RowIndex, 10).Equals("1") Then
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.IndianRed
        End If
        If regieTable(e.RowIndex, 10).Equals("2") Then
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.OrangeRed
        End If
        If regieTable(e.RowIndex, 10).Equals("3") Then
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkOrange
        End If
        If regieTable(e.RowIndex, 10).Equals("4") Then
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.YellowGreen
        End If
        If regieTable(e.RowIndex, 10).Equals("5") Then
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.LightGray
        End If

        If regieTable(e.RowIndex, 6).Equals(translations.getText("regieSection")) Then
            Dim BoldTitleRow As New DataGridViewCellStyle With {.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)}

            Dim fontToMeasure As New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
            Dim sizeOfString As New SizeF
            Dim g As Graphics = Me.CreateGraphics

            regie_datatable.Rows(e.RowIndex).DefaultCellStyle = BoldTitleRow
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorSection
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            regie_datatable.Rows(e.RowIndex).Height = g.MeasureString("F", fontToMeasure).Height
        End If

        If regieTable(e.RowIndex, 7).Equals(translations.getText("regieAddRegieEntry")) Then
            Dim BoldTitleRow As New DataGridViewCellStyle With {.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)}

            Dim fontToMeasure As New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
            Dim sizeOfString As New SizeF
            Dim g As Graphics = Me.CreateGraphics

            regie_datatable.Rows(e.RowIndex).DefaultCellStyle = BoldTitleRow
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            regie_datatable.Rows(e.RowIndex).Height = g.MeasureString("F", fontToMeasure).Height
        End If
        If regieTable(e.RowIndex, 4).Equals(translations.getText("regieTableTotals")) Then
            Dim BoldTotalsRow As New DataGridViewCellStyle With {.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)}
            regie_datatable.Rows(e.RowIndex).DefaultCellStyle = BoldTotalsRow
        End If

        e.Value = regieTable(e.RowIndex, e.ColumnIndex)
        currentRegieDatatable = regie_datatable
    End Sub

    Private Sub regie_select_site_Click(sender As Object, e As EventArgs) Handles regie_select_site.Click
        DropClickSearchBox(regie_select_site)
        load_regie_entries()
    End Sub

    Sub load_regie_entries()
        If regie_site.SelectedIndex < 1 And regie_section.SelectedIndex < 0 Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = regie_datatable.Width
        mask.Height = regie_datatable.Height
        mask.Location = New Drawing.Point(regie_datatable.Location.X, regie_datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TabControl.TabPages(4).Controls.Add(mask)
        mask.BringToFront()

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
                Refresh()
            End If
        End If
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
                Static start As Single
                start = Microsoft.VisualBasic.Timer()
                While bwSites.IsBusy And Microsoft.VisualBasic.Timer() < start + 10
                End While
            End If
        End If

        updated = False
        enableButtonsAndLinks(Me, False)
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("commServer")
        bwRegie = New BackgroundWorker()
        bwRegie.WorkerSupportsCancellation = True
        bwRegie.RunWorkerAsync()
    End Sub

    Private Sub bwRegie_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwRegie.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        Dim section_counter As Integer = -1
        Dim delivery_counter As Integer = -1
        Dim photo_counter As Integer = -1

        Dim rowpos As Integer = 0
        Dim numRows As Integer = 0
        Dim num_cols As Integer = 0

        Dim qsection As String = ""
        translations.load("commonForm")
        regie_section.Invoke(Sub()
                                 qsection = regie_section.Text
                             End Sub)
        If qsection.Equals(translations.getText("dropdownSelectAll")) Then
            qsection = "all"
        Else
            regie_section.Invoke(Sub()
                                     qsection = db_sections.Item("cod_section")(regieSectionsIndex(regie_section.SelectedIndex))
                                 End Sub)
        End If

        Dim startD As Date, endD As Date

        regie_data_inicio.Invoke(Sub()
                                     startD = regie_data_inicio.Value
                                 End Sub)
        regie_data_fim.Invoke(Sub()
                                  endD = regie_data_fim.Value
                              End Sub)

        If DateTime.Compare(startD, endD) > 0 And Not startD.ToString("yyyy-MM-dd").Equals(endD.ToString("yyyy-MM-dd")) Then
            errorMsg = translations.getText("errorDateInterval") & "."
            errorFlag = True
            GoTo skipLoadingJson
        End If

        vars = New Dictionary(Of String, String)
        vars.Add("task", "4")
        vars.Add("request", "load")
        vars.Add("type", "main")
        vars.Add("sdate", regie_data_inicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("edate", regie_data_fim.Value.ToString("yyyy-MM-dd"))
        vars.Add("section", qsection)
        regie_site.Invoke(Sub()
                              vars.Add("site", query_site.Item("cod_site")(regie_site.SelectedIndex - 1))
                          End Sub)

        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsResponseOk(response) Or (IsResponseOk(response) And GetMessageField(response, "empty")) Then
            errorMsg = GetMessage(response)
            If qsection.Equals("all") Then ' no records found since its all sections add manual entry is not allowed
                errorFlag = True
                GoTo skipLoadingJson
            End If

            'add new manual entry
            rowpos = 1
            num_cols = 10
            translations.load("siteActivity")
            ReDim regieTable(rowpos - 1, num_cols)
            ReDim regiePhotos(rowpos - 1)
            ReDim regieCodes(rowpos - 1)
            ReDim regieSection(rowpos - 1)
            For i = 0 To rowpos - 1
                regieCodes(i) = "-1"
                regieSection(i) = ""
                ReDim regiePhotos(i)(0)
                regiePhotos(i)(0).code = "-1"
                For j = 0 To num_cols
                    regieTable(i, j) = ""
                Next j
            Next i
            rowpos = 0
            regieSection(rowpos) = qsection
            regieTable(rowpos, 0) = "-" ' code
            regieTable(rowpos, 1) = "-" ' type of record
            regieTable(rowpos, 2) = "-"
            regieTable(rowpos, 3) = "-"
            regieTable(rowpos, 4) = "-"
            regieTable(rowpos, 5) = "-"
            regieTable(rowpos, 6) = "-"
            regieTable(rowpos, 7) = translations.getText("regieAddRegieEntry")
            regieTable(rowpos, 8) = "-"
            regieTable(rowpos, 9) = qsection
            regieTable(rowpos, 10) = "-1"
            rowpos = rowpos + 1
            GoTo skipLoadingJson
        End If
        translations.load("commonForm")
        MainMdiForm.statusMessage = translations.getText("addDataToTable")

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim sections As JArray = JArray.Parse(data.Item("data").ToString)

            For Each section In sections
                rowpos = rowpos + 2
                Dim regies As JArray = JArray.Parse(section.Item("regie").ToString)
                rowpos = rowpos + 1
                For Each regie In regies
                    rowpos = rowpos + 1
                Next regie
            Next section

            num_cols = 10

            ReDim regieTable(rowpos - 1, num_cols)
            ReDim regiePhotos(rowpos - 1)
            ReDim regieCodes(rowpos - 1)
            ReDim regieSection(rowpos - 1)

            For i = 0 To rowpos - 1
                regieCodes(i) = "-1"
                regieSection(i) = ""
                ReDim regiePhotos(i)(0)
                regiePhotos(i)(0).code = "-1"
                For j = 0 To num_cols
                    regieTable(i, j) = ""
                Next j
            Next i

            rowpos = 0
            translations.load("siteActivity")
            For Each section In sections
                regieSection(rowpos) = qsection
                regieTable(rowpos, 0) = "" ' code
                regieTable(rowpos, 1) = "" ' type of record
                regieTable(rowpos, 2) = ""
                regieTable(rowpos, 3) = ""
                regieTable(rowpos, 4) = ""
                regieTable(rowpos, 5) = ""
                regieTable(rowpos, 6) = translations.getText("regieSection")
                regieTable(rowpos, 7) = section.Item("name").ToString
                regieTable(rowpos, 8) = ""
                regieTable(rowpos, 9) = "-1"
                regieTable(rowpos, 10) = "-1" 'completed values
                regieCodes(rowpos) = "-1"

                rowpos = rowpos + 1
                Dim regies As JArray = JArray.Parse(section.Item("regie").ToString)
                Dim sectionCode As String = ""
                Dim Hours As Decimal = 0.0
                Dim totalHours As Decimal = 0.0
                For Each regie In regies
                    Dim tstart As String = regie.Item("start").ToString.Substring(0, 5) & ":00"
                    Dim tend As String = regie.Item("end").ToString.Substring(0, 5) & ":00"

                    regieCodes(rowpos) = regie.Item("code").ToString

                    regieTable(rowpos, 0) = regie.Item("code").ToString ' code

                    If regie.Item("completed").ToString.Equals("1") Then
                        regieTable(rowpos, 1) = "CEOD" ' type of record
                    ElseIf regie.Item("completed").ToString.Equals("2") Then
                        regieTable(rowpos, 1) = "AEOD" ' type of record
                    ElseIf regie.Item("completed").ToString.Equals("3") Then
                        regieTable(rowpos, 1) = "ON" ' type of record
                    ElseIf regie.Item("completed").ToString.Equals("4") Then
                        regieTable(rowpos, 1) = "CLOSED" ' type of record
                    Else
                        regieTable(rowpos, 1) = "DELETED" ' type of record
                    End If

                    regieTable(rowpos, 2) = regie.Item("date").ToString
                    regieTable(rowpos, 3) = tstart
                    regieTable(rowpos, 4) = tend
                    regieTable(rowpos, 5) = ""
                    regieTable(rowpos, 6) = "-"
                    regieTable(rowpos, 7) = regie.Item("workerlist").ToString
                    regieTable(rowpos, 8) = regie.Item("note").ToString.Replace(vbCrLf, Environment.NewLine)
                    regieTable(rowpos, 9) = regie.Item("section").ToString
                    regieTable(rowpos, 10) = regie.Item("completed").ToString 'completed values

                    'completed values:
                    '1 - checkout EOD 
                    '2 - default EOD
                    '3 - ongoing
                    '4 - completed
                    '5 - deleted

                    If Not regie.Item("completed").ToString.Equals("5") Then
                        Dim stime, etime As DateTime
                        stime = DateTime.ParseExact(If(tstart.Equals("00:00:00"), "07:30:00", tstart), "HH:mm:ss", Nothing)
                        If regie.Item("completed").ToString.Equals("3") Then
                            etime = DateTime.ParseExact(Now.ToString("HH:mm:00"), "HH:mm:ss", Nothing)
                        Else
                            etime = DateTime.ParseExact(If(tend.Equals("00:00:00"), "17:30:00", tend), "HH:mm:ss", Nothing)
                        End If
                        Hours = Hours + (etime - stime).TotalHours
                        'remove lunch time
                        Dim hourStart As Integer = tstart.Substring(0, 2)
                        Dim hourEnd As Integer = If(tend.Equals("00:00:00"), "17:30:00", tend).ToString.Substring(0, 2)
                        If (hourStart < 13 And (hourEnd > 13)) Then
                            Hours = Hours - 0.5
                            regieTable(rowpos, 5) = Math.Round((etime - stime).TotalHours - 0.5, 2)
                        Else
                            regieTable(rowpos, 5) = Math.Round((etime - stime).TotalHours, 2)
                        End If
                        totalHours = totalHours + regieTable(rowpos, 5) * (regie.Item("workerlist").ToString.Split(",").Length - 1)
                        regieTable(rowpos, 6) = regieTable(rowpos, 5) * (regie.Item("workerlist").ToString.Split(",").Length - 1)

                        regieTable(rowpos, 3) = regie.Item("start").ToString.Substring(0, 5)
                        regieTable(rowpos, 4) = regie.Item("end").ToString.Substring(0, 5)

                    End If


                    sectionCode = regie.Item("section").ToString

                    ReDim Preserve regiePhotos(rowpos)(0)
                    regiePhotos(rowpos)(0).code = "-1"
                    If Not IsNothing(regie.Item("photos")) Then
                        Dim photos As JArray = JArray.Parse(regie.Item("photos").ToString)
                        photo_counter = -1
                        ReDim Preserve regiePhotos(rowpos)(photos.Count - 1)
                        For Each photo In photos
                            photo_counter = photo_counter + 1
                            regiePhotos(rowpos)(photo_counter).code = photo.Item("code").ToString
                            regiePhotos(rowpos)(photo_counter).file = photo.Item("file").ToString
                        Next photo
                    End If
                    rowpos = rowpos + 1

                Next regie
                regieSection(rowpos) = sectionCode
                regieTable(rowpos, 0) = "" ' code
                regieTable(rowpos, 1) = "" ' type of record
                regieTable(rowpos, 2) = ""
                regieTable(rowpos, 3) = ""
                regieTable(rowpos, 4) = translations.getText("regieTableTotals")
                regieTable(rowpos, 5) = Math.Round(Hours, 2)
                regieTable(rowpos, 6) = Math.Round(totalHours, 2)
                regieTable(rowpos, 7) = translations.getText("regieTableHours")
                regieTable(rowpos, 8) = ""
                regieTable(rowpos, 9) = "-1"
                regieTable(rowpos, 10) = "-1" 'completed values
                rowpos = rowpos + 1

                regieSection(rowpos) = sectionCode
                regieTable(rowpos, 0) = "" ' code
                regieTable(rowpos, 1) = "" ' type of record
                regieTable(rowpos, 2) = ""
                regieTable(rowpos, 3) = ""
                regieTable(rowpos, 4) = ""
                regieTable(rowpos, 5) = ""
                regieTable(rowpos, 6) = ""
                regieTable(rowpos, 7) = translations.getText("regieAddRegieEntry")
                regieTable(rowpos, 8) = ""
                regieTable(rowpos, 9) = sectionCode
                regieTable(rowpos, 10) = "-1" 'completed values
                rowpos = rowpos + 1

            Next section

        Catch ex As Exception
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            errorFlag = True
            errorMsg = ex.Message.ToString
        End Try
skipLoadingJson:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = rowpos
            e.Result = s
        End If
    End Sub

    Private Sub bwRegie_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwRegie.RunWorkerCompleted
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        Dim rowpos As Integer = e.Result(1)

        sizeOfString = g.MeasureString("888", fontToMeasure)
        translations.load("siteActivity")
        SuspendLayout()
        With regie_datatable
            .Visible = False

            .VirtualMode = True
            .Rows.Clear()
            .RowCount = rowpos

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 9

            .Columns(0).HeaderCell.Value = translations.getText("regieTableColumnId")
            .Columns(0).Width = g.MeasureString("2031", fontToMeasure).Width

            .Columns(1).HeaderCell.Value = translations.getText("regieTableColumnType")
            .Columns(1).Width = g.MeasureString("CLOSED_", fontToMeasure).Width


            .Columns(2).HeaderCell.Value = translations.getText("regieTableColumnDate")
            .Columns(2).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(3).HeaderCell.Value = translations.getText("regieTableColumnStart")
            .Columns(3).Width = g.MeasureString("99:99:99", fontToMeasure).Width

            .Columns(4).HeaderCell.Value = translations.getText("regieTableColumnEnd")
            .Columns(4).Width = g.MeasureString("99:99:99", fontToMeasure).Width

            .Columns(5).HeaderCell.Value = translations.getText("regieTableColumnHoursDay")
            .Columns(5).Width = g.MeasureString("99:99:99", fontToMeasure).Width

            .Columns(6).HeaderCell.Value = translations.getText("regieTableColumnHoursTotal")
            .Columns(6).Width = g.MeasureString("99:99:99", fontToMeasure).Width

            .Columns(7).HeaderCell.Value = translations.getText("regieTableColumnWorkers")
            .Columns(7).Width = 400
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(8).HeaderCell.Value = translations.getText("regieTableColumnAnnotations")
            .Columns(8).Width = 400

            Dim colMaxHEight As Integer = 0
            Dim newlines As Integer = 0
            Dim lines As Integer = 0
            For i = 0 To rowpos - 1
                .Rows(i).Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Rows(i).Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                colMaxHEight = 0
                For j = 0 To 8
                    sizeOfString = g.MeasureString(regieTable(i, j), fontToMeasure)
                    lines = Math.Round(sizeOfString.Width / .Columns(j).Width + 0.5, 0, MidpointRounding.AwayFromZero)
                    newlines = regieTable(i, j).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * colMaxHEight
            Next i
            .Visible = True
        End With
        mask.Dispose()
        enableButtonsAndLinks(Me, True)
        ResumeLayout()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
    End Sub


    'PRODUCTION
    Private Sub auto_medicao_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles auto_medicao_site.SelectedIndexChanged
        auto_medicao_section.Items.Clear()
        If auto_medicao_site.SelectedIndex > 0 Then
            If IsDate(query_site.Item("data_inicio")(auto_medicao_site.SelectedIndex - 1)) Then
                auto_medicao_data_inicio.Value = query_site.Item("data_inicio")(auto_medicao_site.SelectedIndex - 1)
            Else
                auto_medicao_data_inicio.Value = DateTime.Now
            End If

            If IsDate(query_site.Item("data_fim")(auto_medicao_site.SelectedIndex - 1)) Then
                auto_medicao_data_fim.Value = query_site.Item("data_fim")(auto_medicao_site.SelectedIndex - 1)
            Else
                auto_medicao_data_fim.Value = DateTime.Now
            End If

            If Not IsNothing(db_sections) Then
                Dim idx As Integer = 1
                translations.load("commonForm")
                auto_medicao_section.Items.Add(translations.getText("dropdownSelectAll"))
                If Not auto_medicao_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                    For i = 0 To db_sections.Item("cod_section").Count - 1
                        If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1)) Then
                            auto_medicao_section.Items.Add(db_sections.Item("description")(i))
                            AutoMedicaoSectionsIndex(idx) = i
                            idx = idx + 1
                        End If
                    Next
                End If
            End If
            If auto_medicao_section.Items.Count > 0 Then
                auto_medicao_section.SelectedIndex = 0
            End If
        Else
            loaded = False ' disable update workers on date change

            auto_medicao_units.Text = ""
            auto_medicao_qtd.Text = ""
            auto_medicao_notas.Text = ""
            auto_medicao_date.Value = Now

            auto_medicao_date.Enabled = False
            auto_medicao_notas.Enabled = False
            auto_medicao_qtd.Enabled = False
            auto_medicao_units.Enabled = False
            auto_medicao_del.Enabled = False
            auto_medicao_save.Enabled = False
            auto_medicao_reset.Enabled = False
            auto_medicao_workers_selected.Enabled = False
            auto_medicao_workers_selected.Items.Clear()
            auto_medicao_workers.Enabled = False
            auto_medicao_workers.Items.Clear()
            auto_medicao_update_workers.Enabled = False
            loaded = True
        End If
    End Sub

    Private Sub autoMedicaoSetCurrentMonth_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles autoMedicaoSetCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        auto_medicao_data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        auto_medicao_data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DropClickSearchBox(PictureBox1)

        loaded = False

        auto_medicao_units.Text = ""
        auto_medicao_qtd.Text = ""
        auto_medicao_notas.Text = ""
        auto_medicao_date.Value = Now

        auto_medicao_workers_selected.Items.Clear()
        auto_medicao_workers.Items.Clear()

        If Not IsNothing(selected_qtd_record) Then
            For i = 0 To UBound(selected_qtd_record)
                selected_qtd_record(i) = ""
            Next i
        End If
        load_production()
    End Sub
    Private Sub load_production()

        loaded = False
        If auto_medicao_site.SelectedIndex < 1 And auto_medicao_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        Dim qsection As String = ""
        translations.load("commonForm")
        If auto_medicao_section.Text.Equals(translations.getText("dropdownSelectAll")) Then
            qsection = "all"
        Else
            qsection = db_sections.Item("cod_section")(AutoMedicaoSectionsIndex(auto_medicao_section.SelectedIndex))
        End If

        Dim startD As Date, endD As Date

        startD = auto_medicao_data_inicio.Value
        endD = auto_medicao_data_fim.Value

        If DateTime.Compare(startD, endD) > 0 And Not auto_medicao_data_inicio.Value.ToString("yyyy-MM-dd").Equals(auto_medicao_data_fim.Value.ToString("yyyy-MM-dd")) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorDateInterval")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("commServer")

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "21")
        vars.Add("request", "load")
        vars.Add("type", "main")
        vars.Add("sdate", auto_medicao_data_inicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("edate", auto_medicao_data_fim.Value.ToString("yyyy-MM-dd"))
        vars.Add("section", qsection)
        vars.Add("site", query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1))

        Dim vars2 As New Dictionary(Of String, String)
        vars2.Add("task", "6")
        vars2.Add("request", "bordereau")
        vars2.Add("section", qsection)
        vars2.Add("site", query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1))

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If


        If Not IsNothing(bwLoadAM) Then
            If bwLoadAM.IsBusy Then
                bwLoadAM.CancelAsync()
            End If
        End If

        Dim send(1) As Dictionary(Of String, String)

        send(0) = vars
        send(1) = vars2
        bwLoadAM = New BackgroundWorker()
        bwLoadAM.WorkerSupportsCancellation = True
        bwLoadAM.RunWorkerAsync(send)

        enableButtonsAndLinks(Me, False)
        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = auto_medicao_datatable.Width
        mask.Height = auto_medicao_datatable.Height
        mask.Location = New Drawing.Point(auto_medicao_datatable.Location.X, auto_medicao_datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TabControl.TabPages(2).Controls.Add(mask)
        mask.BringToFront()

        mask2 = New PictureBox
        mask2.BackColor = Color.White
        mask2.Top = TopMost
        'mask2.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        'mask2.SizeMode = PictureBoxSizeMode.CenterImage
        mask2.Width = auto_medicao_tasks_list.Width
        mask2.Height = auto_medicao_tasks_list.Height
        mask2.Location = New Drawing.Point(auto_medicao_tasks_list.Location.X, auto_medicao_tasks_list.Location.Y)
        mask2.BorderStyle = BorderStyle.FixedSingle
        auto_medicao_tasks_group.Controls.Add(mask2)
        mask2.BringToFront()
    End Sub
    Private Sub bwLoadAM_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadAM.DoWork
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim send(2) As String
        Dim s(3) As String

        Dim request As New HttpData(state)
        Dim resp As String = request.RequestData(e.Argument(1))

        Dim workers_counter As Integer = -1

        Dim rowpos As Integer = 0
        Dim numRows As Integer = 0
        Dim num_cols As Integer = 0

        send(0) = resp
        send(1) = "0"
        send(2) = False 'true continue loading even if theres an error
        e.Result = send

        If Not IsResponseOk(resp) Then
            errorMsg = GetMessage(resp)
            errorFlag = True
            GoTo lastLine
        End If
        query_bordereau = request.ConvertDataToArray("bordereau", state.queryBordereauFields, resp)
        If IsNothing(query_bordereau) Then
            errorMsg = request.errorMessage
            errorFlag = True
            s(2) = False 'true continue loading even if theres an error
            GoTo lastLine
        End If

        resp = request.RequestData(e.Argument(0))

        If Not IsResponseOk(resp) Or (IsResponseOk(resp) And GetMessageField(resp, "empty")) Then
            errorMsg = GetMessage(resp)
            errorFlag = True
            s(2) = True 'true continue loading even if theres an error
            ' add manual entry
            num_cols = 8
            rowpos = 1
            ReDim AMTable(rowpos - 1, num_cols)
            ReDim selected_qtd_record(num_cols)
            ReDim am_qtd(rowpos - 1)
            For i = 0 To rowpos - 1
                For j = 0 To num_cols
                    AMTable(i, j) = ""
                Next j
            Next i

            Dim qsection As String = ""
            auto_medicao_section.Invoke(Sub()
                                            If auto_medicao_section.Text.Equals(translations.getText("dropdownSelectAll")) Then
                                                qsection = "all"
                                            Else
                                                qsection = db_sections.Item("cod_section")(AutoMedicaoSectionsIndex(auto_medicao_section.SelectedIndex))
                                            End If
                                        End Sub)

            translations.load("siteActivity")
            rowpos = 0
            AMTable(rowpos, 0) = "-"
            AMTable(rowpos, 1) = "-"
            AMTable(rowpos, 2) = translations.getText("productionAddManualEntry")
            AMTable(rowpos, 3) = "-"
            AMTable(rowpos, 4) = "-"
            AMTable(rowpos, 5) = "-"
            AMTable(rowpos, 6) = "-"
            AMTable(rowpos, 7) = "-"
            AMTable(rowpos, 8) = qsection
            rowpos = rowpos + 1

            s(3) = rowpos
            GoTo lastLine
        End If

lastLine:
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



        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(resp)
            Dim sections As JArray = JArray.Parse(data.Item("data").ToString)

            For Each section In sections
                rowpos = rowpos + 2
                Dim regies As JArray = JArray.Parse(section.Item("production").ToString)
                rowpos = rowpos + 1
                For Each regie In regies
                    rowpos = rowpos + 1
                Next regie
            Next section

            num_cols = 8

            ReDim AMTable(rowpos - 1, num_cols)
            ReDim selected_qtd_record(num_cols)
            ReDim am_qtd(rowpos - 1)
            For i = 0 To rowpos - 1
                For j = 0 To num_cols
                    AMTable(i, j) = ""
                Next j
            Next i

            rowpos = 0
            translations.load("siteActivity")
            For Each section In sections
                AMTable(rowpos, 0) = ""
                AMTable(rowpos, 1) = translations.getText("regieSection")
                AMTable(rowpos, 2) = section.Item("name").ToString
                AMTable(rowpos, 3) = "-"
                AMTable(rowpos, 4) = "-"
                AMTable(rowpos, 5) = "-"
                AMTable(rowpos, 6) = "-"
                AMTable(rowpos, 7) = "-"
                AMTable(rowpos, 8) = "-"

                rowpos = rowpos + 1
                Dim qtd_entries As JArray = JArray.Parse(section.Item("production").ToString)
                For Each qtd_entry In qtd_entries
                    AMTable(rowpos, 0) = qtd_entry.Item("code").ToString
                    AMTable(rowpos, 1) = qtd_entry.Item("date").ToString
                    AMTable(rowpos, 2) = qtd_entry.Item("workersList").ToString
                    AMTable(rowpos, 3) = qtd_entry.Item("qtd").ToString
                    AMTable(rowpos, 4) = qtd_entry.Item("units").ToString
                    AMTable(rowpos, 5) = qtd_entry.Item("taskcode").ToString
                    AMTable(rowpos, 6) = qtd_entry.Item("task").ToString
                    AMTable(rowpos, 7) = qtd_entry.Item("note").ToString.Replace(vbCrLf, Environment.NewLine)
                    AMTable(rowpos, 8) = section.Item("code").ToString
                    am_qtd(rowpos).code = qtd_entry.Item("code").ToString

                    If Not IsNothing(qtd_entry.Item("workers")) Then
                        Dim workers As JArray = JArray.Parse(qtd_entry.Item("workers").ToString)
                        workers_counter = -1
                        ReDim Preserve am_qtd(rowpos).workers(workers.Count - 1)
                        For Each worker In workers
                            workers_counter = workers_counter + 1
                            am_qtd(rowpos).workers(workers_counter).code = worker.Item("code").ToString
                            am_qtd(rowpos).workers(workers_counter).name = worker.Item("name").ToString
                        Next worker
                    End If
                    rowpos = rowpos + 1
                Next qtd_entry

                AMTable(rowpos, 0) = "-"
                AMTable(rowpos, 1) = "-"
                AMTable(rowpos, 2) = translations.getText("productionAddManualEntry")
                AMTable(rowpos, 3) = "-"
                AMTable(rowpos, 4) = "-"
                AMTable(rowpos, 5) = "-"
                AMTable(rowpos, 6) = "-"
                AMTable(rowpos, 7) = "-"
                AMTable(rowpos, 8) = section.Item("code").ToString
                rowpos = rowpos + 1

            Next section
        Catch ex As Exception
            Dim trace = New Diagnostics.StackTrace(ex, True)
            Dim line As String = Microsoft.VisualBasic.Right(trace.ToString, 7)

            saveCrash(ex)
            translations.load("errorMessages")
            s(0) = "true"
            s(1) = translations.getText("errorInternalAtLine") & " " & line & " (" & ex.Message.ToString & ")"
            e.Result = s
            Exit Sub

        End Try

        send(0) = False
        send(1) = rowpos
        e.Result = send

    End Sub

    Private Sub bwLoadAM_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadAM.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            mask.Dispose()
            mask2.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            If e.Result(2).Equals("False") Then
                mask2.Dispose()
                mask.Dispose()
                enableButtonsAndLinks(Me, True)
                Exit Sub
            End If
            e.Result(1) = e.Result(3)
        End If

        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")

        auto_medicao_tasks_list.Items.Clear()
        For i = 0 To query_bordereau.Item("cod_task").Count - 1
            auto_medicao_tasks_list.Items.Add(query_bordereau.Item("cod_task")(i) & " - " & query_bordereau.Item("descricao")(i))
        Next
        auto_medicao_tasks_list.SelectedIndex = 0

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)

        translations.load("siteActivity")

        SuspendLayout()
        With auto_medicao_datatable
            .Visible = False
            .VirtualMode = True
            .Rows.Clear()
            .RowCount = e.Result(1)

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 8

            .Columns(0).HeaderCell.Value = translations.getText("productionTableColumnCode")
            .Columns(0).Width = g.MeasureString("99999", fontToMeasure).Width

            .Columns(1).HeaderCell.Value = translations.getText("productionTableColumnDate")
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(2).HeaderCell.Value = translations.getText("productionTableColumnWorkers")
            .Columns(2).Width = 400
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(3).HeaderCell.Value = translations.getText("productionTableColumnQuantity")
            .Columns(3).Width = g.MeasureString("999999", fontToMeasure).Width

            .Columns(4).HeaderCell.Value = translations.getText("productionTableColumnUntis")
            .Columns(4).Width = g.MeasureString("PPPP", fontToMeasure).Width

            .Columns(5).HeaderCell.Value = translations.getText("productionTableColumnCode")
            .Columns(5).Width = g.MeasureString("99999", fontToMeasure).Width

            .Columns(6).HeaderCell.Value = translations.getText("productionTableColumnTasks")
            .Columns(6).Width = 400
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(7).HeaderCell.Value = translations.getText("productionTableColumnAnnotations")
            .Columns(7).Width = 400
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            Dim colMaxHEight As Integer = 0
            Dim newlines As Integer = 0
            Dim lines As Integer = 0
            For i = 0 To .RowCount - 1
                .Rows(i).Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Rows(i).Cells(6).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Rows(i).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                colMaxHEight = 0
                For j = 0 To 6
                    sizeOfString = g.MeasureString(AMTable(i, j), fontToMeasure)
                    lines = Math.Round(sizeOfString.Width / .Columns(j).Width + 0.5, 0, MidpointRounding.AwayFromZero)
                    newlines = AMTable(i, j).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * colMaxHEight
            Next i
            .Visible = True
        End With
        ResumeLayout()
        mask.Dispose()
        mask2.Dispose()
        enableButtonsAndLinks(Me, True)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
        loaded = True
    End Sub

    Private Sub auto_medicao_tasks_list_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles auto_medicao_tasks_list.DrawItem
        e.DrawBackground()
        If IsNothing(query_bordereau) Then
            Exit Sub
        End If

        If e.Index < 0 Or query_bordereau.Item("cod_task").Count - 1 < e.Index Then
            Exit Sub
        End If

        If query_bordereau.Item("enabled")(e.Index).Equals("0") Or query_bordereau.Item("enabled")(e.Index).Equals("") Then
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Gainsboro)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.LimeGreen)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If

        Using b As New SolidBrush(e.ForeColor)
            If Not IsNothing(auto_medicao_tasks_list) Then
                If auto_medicao_tasks_list.Items.Count > 0 And e.Index > -1 Then
                    e.Graphics.DrawString(auto_medicao_tasks_list.GetItemText(auto_medicao_tasks_list.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub auto_medicao_tasks_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles auto_medicao_tasks_list.SelectedIndexChanged
        If auto_medicao_tasks_list.Items.Count > 0 Then
            If auto_medicao_tasks_list.SelectedIndex > -1 Then
                If query_bordereau.Item("enabled")(auto_medicao_tasks_list.SelectedIndex + 1).Equals("0") Or query_bordereau.Item("enabled")(auto_medicao_tasks_list.SelectedIndex + 1).Equals("") Then
                    auto_medicao_tasks_list.SetSelected(auto_medicao_tasks_list.SelectedIndex, False)
                Else
                    auto_medicao_units.Text = query_bordereau.Item("units")(auto_medicao_tasks_list.SelectedIndex + 1)
                End If
            End If
        End If
    End Sub

    Private Sub auto_medicao_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles auto_medicao_datatable.CellValueNeeded

        If UBound(AMTable, 1) < e.RowIndex Or UBound(AMTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If

        translations.load("siteActivity")
        If AMTable(e.RowIndex, 1).Equals(translations.getText("regieSection")) Then
            auto_medicao_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
        End If

        If AMTable(e.RowIndex, 2).Equals(translations.getText("productionAddManualEntry")) Then
            auto_medicao_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
        End If

        e.Value = AMTable(e.RowIndex, e.ColumnIndex)
        currentProductionDatatable = auto_medicao_datatable
    End Sub

    Private Sub auto_medicao_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles auto_medicao_datatable.CellContentClick

    End Sub
    Private Sub auto_medicao_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles auto_medicao_datatable.CellMouseDoubleClick
        auto_medicao_datatable_cellY = e.RowIndex
        auto_medicao_datatable_cellX = e.ColumnIndex
        If auto_medicao_datatable_cellY.Equals(-1) Or auto_medicao_datatable_cellX.Equals(-1) Then
            Exit Sub
        End If

        translations.load("siteActivity")
        If Not AMTable(auto_medicao_datatable_cellY, 1).Equals(translations.getText("regieSection")) And Not AMTable(auto_medicao_datatable_cellY, 2).Equals(translations.getText("productionAddManualEntry")) Then
            For i = 0 To UBound(selected_qtd_record)
                selected_qtd_record(i) = AMTable(auto_medicao_datatable_cellY, i)
            Next i
            auto_medicao_date.Value = AMTable(auto_medicao_datatable_cellY, 1)
            load_production_data()
        ElseIf AMTable(auto_medicao_datatable_cellY, 2).Equals(translations.getText("productionAddManualEntry")) Then
            For i = 0 To UBound(selected_qtd_record)
                selected_qtd_record(i) = AMTable(auto_medicao_datatable_cellY, i)
            Next i
            auto_medicao_units.Text = ""
            auto_medicao_qtd.Text = ""
            auto_medicao_notas.Text = ""
            auto_medicao_date.Value = Now

            auto_medicao_date.Enabled = True
            auto_medicao_notas.Enabled = True
            auto_medicao_qtd.Enabled = True
            auto_medicao_units.Enabled = True
            auto_medicao_del.Enabled = False
            auto_medicao_save.Enabled = True
            auto_medicao_reset.Enabled = False
            auto_medicao_workers_selected.Enabled = True
            auto_medicao_workers_selected.Items.Clear()
            auto_medicao_workers.Enabled = True
            auto_medicao_workers.Items.Clear()
            auto_medicao_update_workers.Enabled = True
            auto_medicao_update_tasks.Enabled = True
            auto_medicao_translate.Enabled = True

        End If

    End Sub

    Private Sub auto_medicao_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles auto_medicao_datatable.CellMouseClick
        loaded = False
        auto_medicao_units.Text = ""
        auto_medicao_qtd.Text = ""
        auto_medicao_notas.Text = ""
        auto_medicao_date.Value = Now

        auto_medicao_date.Enabled = False
        auto_medicao_notas.Enabled = False
        auto_medicao_qtd.Enabled = False
        auto_medicao_units.Enabled = False
        auto_medicao_del.Enabled = False
        auto_medicao_save.Enabled = False
        auto_medicao_reset.Enabled = False
        auto_medicao_workers_selected.Enabled = False
        auto_medicao_workers_selected.Items.Clear()
        auto_medicao_workers.Enabled = False
        auto_medicao_workers.Items.Clear()
        auto_medicao_update_workers.Enabled = False
        auto_medicao_update_tasks.Enabled = False
        auto_medicao_translate.Enabled = False

        For i = 0 To UBound(selected_qtd_record)
            selected_qtd_record(i) = ""
        Next i

        If auto_medicao_tasks_list.Items.Count > 0 Then
            If auto_medicao_tasks_list.SelectedIndex > -1 Then
                auto_medicao_tasks_list.SelectedIndex = -1
            End If
        End If
        loaded = True

    End Sub

    Private Sub load_production_data()
        Dim msgbox As message_box_frm

        If auto_medicao_site.SelectedIndex < 1 And auto_medicao_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        auto_medicao_units.Text = AMTable(auto_medicao_datatable_cellY, 4)
        auto_medicao_qtd.Text = AMTable(auto_medicao_datatable_cellY, 3)
        auto_medicao_notas.Text = AMTable(auto_medicao_datatable_cellY, 7)
        auto_medicao_date.Value = AMTable(auto_medicao_datatable_cellY, 1)

        auto_medicao_date.Enabled = True
        auto_medicao_notas.Enabled = True
        auto_medicao_qtd.Enabled = True
        auto_medicao_units.Enabled = True
        auto_medicao_del.Enabled = True
        auto_medicao_save.Enabled = True
        auto_medicao_reset.Enabled = True
        auto_medicao_workers_selected.Enabled = True
        auto_medicao_workers.Enabled = True
        auto_medicao_update_workers.Enabled = True
        auto_medicao_workers.Items.Clear()
        auto_medicao_update_tasks.Enabled = True
        auto_medicao_translate.Enabled = True

        auto_medicao_workers_selected.Items.Clear()
        For i = 0 To UBound(am_qtd(auto_medicao_datatable_cellY).workers)
            auto_medicao_workers_selected.Items.Add(am_qtd(auto_medicao_datatable_cellY).workers(i).name)
        Next i

        For i = 0 To query_bordereau.Item("cod_task").Count - 1
            If query_bordereau.Item("cod_task")(i).Equals(AMTable(auto_medicao_datatable_cellY, 5)) Then
                auto_medicao_tasks_list.SetSelected(i, True)
                Exit For
            End If
        Next i

        If Not IsNothing(bwLoadWorkersOnSite) Then
            If bwLoadWorkersOnSite.IsBusy Then
                bwLoadWorkersOnSite.CancelAsync()
            End If
        End If

        bwLoadWorkersOnSite = New BackgroundWorker()
        bwLoadWorkersOnSite.WorkerSupportsCancellation = True
        bwLoadWorkersOnSite.RunWorkerAsync()
    End Sub


    Private Sub bwLoadWorkersOnSite_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadWorkersOnSite.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        Dim qsection As String = ""
        translations.load("commonForm")
        auto_medicao_section.Invoke(Sub()
                                        vars.Add("site", query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1))
                                    End Sub)

        vars.Add("task", "6")
        vars.Add("request", "workersonsite")
        vars.Add("section", AMTable(auto_medicao_datatable_cellY, 8))
        vars.Add("date", auto_medicao_date.Value.ToString("yyyy-MM-dd"))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_workers_on_site = request.ConvertDataToArray("workersonsite", state.queryWorkersOnSiteFields, response)
        If IsNothing(query_workers_on_site) Then
            errorMsg = request.errorMessage
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

    Private Sub bwLoadWorkersOnSite_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadWorkersOnSite.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then

            auto_medicao_notas.Enabled = False
            auto_medicao_qtd.Enabled = False
            auto_medicao_units.Enabled = False
            auto_medicao_del.Enabled = False
            auto_medicao_save.Enabled = False
            auto_medicao_workers_selected.Enabled = False
            auto_medicao_workers.Enabled = False
            auto_medicao_update_workers.Enabled = False
            auto_medicao_workers.Items.Clear()
            auto_medicao_update_tasks.Enabled = False
            auto_medicao_translate.Enabled = False
            auto_medicao_reset.Enabled = False

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim temp = query_workers_on_site

        auto_medicao_workers.Items.Clear()
        For i = 0 To temp.Item("cod_worker").Count - 1
            auto_medicao_workers.Items.Add(temp.Item("name")(i))
        Next
        auto_medicao_workers.SelectedIndex = 0

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

    End Sub

    Private Sub auto_medicao_update_taks_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_update_tasks.LinkClicked
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwLoadBordereau) Then
            If bwLoadBordereau.IsBusy Then
                bwLoadBordereau.CancelAsync()
            End If
        End If

        bwLoadAutoMedicao = New BackgroundWorker()
        bwLoadAutoMedicao.WorkerSupportsCancellation = True
        bwLoadAutoMedicao.RunWorkerAsync()

    End Sub

    Private Sub bwLoadAutoMedicao_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadAutoMedicao.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        Dim qsection As String = ""
        translations.load("commonForm")
        If auto_medicao_section.Text.Equals(translations.getText("dropdownSelectAll")) Then
            qsection = "all"
        Else
            qsection = db_sections.Item("cod_section")(AutoMedicaoSectionsIndex(auto_medicao_section.SelectedIndex))
        End If

        vars.Add("task", "6")
        vars.Add("request", "bordereau")
        vars.Add("site", query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1))
        vars.Add("section", qsection)
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_bordereau = request.ConvertDataToArray("bordereau", state.queryBordereauFields, response)
        If IsNothing(query_bordereau) Then
            errorMsg = request.errorMessage
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

    Private Sub bwLoadAutoMedicao_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadAutoMedicao.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim temp = query_bordereau

        auto_medicao_tasks_list.Items.Clear()

        For i = 0 To query_bordereau.Item("cod_task").Count - 1
            auto_medicao_tasks_list.Items.Add(temp.Item("cod_task")(i) & " - " & temp.Item("descricao")(i))
        Next
        auto_medicao_tasks_list.SelectedIndex = 0

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

        load_production()

    End Sub
    Private Sub auto_medicao_update_workers_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_update_workers.LinkClicked
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwLoadWorkersOnSite) Then
            If bwLoadWorkersOnSite.IsBusy Then
                bwLoadWorkersOnSite.CancelAsync()
            End If
        End If

        bwLoadWorkersOnSite = New BackgroundWorker()
        bwLoadWorkersOnSite.WorkerSupportsCancellation = True
        bwLoadWorkersOnSite.RunWorkerAsync()
    End Sub

    Private Sub auto_medicao_reset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_reset.LinkClicked
        load_production_data()
    End Sub

    Private Sub auto_medicao_workers_selected_DoubleClick(sender As Object, e As EventArgs) Handles auto_medicao_workers_selected.DoubleClick
        If auto_medicao_workers_selected.SelectedIndex > -1 Then
            auto_medicao_workers_selected.Items.RemoveAt(auto_medicao_workers_selected.SelectedIndex)
        End If
    End Sub

    Private Sub auto_medicao_date_ValueChanged(sender As Object, e As EventArgs) Handles auto_medicao_date.ValueChanged
        If Not loaded Then
            Exit Sub
        End If
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwLoadWorkersOnSite) Then
            If bwLoadWorkersOnSite.IsBusy Then
                bwLoadWorkersOnSite.CancelAsync()
            End If
        End If

        bwLoadWorkersOnSite = New BackgroundWorker()
        bwLoadWorkersOnSite.WorkerSupportsCancellation = True
        bwLoadWorkersOnSite.RunWorkerAsync()
        auto_medicao_workers_selected.Items.Clear()

    End Sub



    Private Sub auto_medicao_del_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_del.LinkClicked
        Dim msgbox As message_box_frm
        If selected_qtd_record(0).Equals("") Or Not IsNumeric(selected_qtd_record(0)) Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorInvalidRecord")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "21")
        vars.Add("request", "del")
        vars.Add("cod", selected_qtd_record(0))
        Dim request As New HttpData(state)
        Dim resp As String = request.RequestData(vars)

        If Not IsResponseOk(resp) Then
            If Not IsNothing(MainMdiForm.busy) Then
                MainMdiForm.busy.Close(True)
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(resp), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            loaded = False

            auto_medicao_units.Text = ""
            auto_medicao_qtd.Text = ""
            auto_medicao_notas.Text = ""
            auto_medicao_date.Value = Now

            auto_medicao_date.Enabled = False
            auto_medicao_notas.Enabled = False
            auto_medicao_qtd.Enabled = False
            auto_medicao_units.Enabled = False
            auto_medicao_del.Enabled = False
            auto_medicao_save.Enabled = False
            auto_medicao_reset.Enabled = False
            auto_medicao_workers_selected.Enabled = False
            auto_medicao_workers_selected.Items.Clear()
            auto_medicao_workers.Enabled = False
            auto_medicao_workers.Items.Clear()
            auto_medicao_update_workers.Enabled = False
            auto_medicao_update_tasks.Enabled = False
            If Not IsNothing(selected_qtd_record) Then
                For i = 0 To UBound(selected_qtd_record)
                    selected_qtd_record(i) = ""
                Next i
            End If
            load_production()
            translations.load("messagebox")
            Dim message As String = translations.getText("resultSuccessDelRecord")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub auto_medicao_save_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_save.LinkClicked
        Dim msgbox As message_box_frm
        If auto_medicao_site.SelectedIndex < 1 And auto_medicao_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If Not selected_qtd_record(8).Equals("") And Not IsNumeric(selected_qtd_record(8)) Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("productionErrorInvalidRecord")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If auto_medicao_workers_selected.Items.Count.Equals(0) Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("productionErrorSelectWorkers")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If auto_medicao_qtd.Text.Equals("") Or Not IsNumeric(auto_medicao_qtd.Text) Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("productionErrorTypeValidQuantity")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If auto_medicao_tasks_list.SelectedIndex < 0 Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("productionErrorSelectTask")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim workers As String = ""
        For i = 0 To auto_medicao_workers_selected.Items.Count - 1
            For j = 0 To query_workers_on_site.Item("cod_worker").Count - 1
                If query_workers_on_site.Item("name")(j).Equals(auto_medicao_workers_selected.Items(i).ToString) Then
                    workers = If(workers.Equals(""), query_workers_on_site.Item("cod_worker")(j), workers & "," & query_workers_on_site.Item("cod_worker")(j))
                End If
            Next j
        Next i

        Dim vars As New Dictionary(Of String, String)

        vars.Add("task", "21")
        If IsNumeric(selected_qtd_record(0)) Then
            vars.Add("request", "edit")
            vars.Add("cod", selected_qtd_record(0))
        Else
            vars.Add("request", "add")
        End If
        vars.Add("workers", workers)
        vars.Add("section", selected_qtd_record(8))
        vars.Add("site", query_site.Item("cod_site")(auto_medicao_site.SelectedIndex - 1))
        vars.Add("qtd", auto_medicao_qtd.Text)
        vars.Add("date", auto_medicao_date.Value.ToString("yyyy-MM-dd"))
        vars.Add("notes", auto_medicao_notas.Text)
        vars.Add("bordereau", query_bordereau.Item("cod_task")(auto_medicao_tasks_list.SelectedIndex))
        Dim request As New HttpData(state)
        Dim resp As String = request.RequestData(vars)

        If Not IsResponseOk(resp) Then
            If Not IsNothing(MainMdiForm.busy) Then
                MainMdiForm.busy.Close(True)
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(resp), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            loaded = False

            auto_medicao_units.Text = ""
            auto_medicao_qtd.Text = ""
            auto_medicao_notas.Text = ""
            auto_medicao_date.Value = Now

            auto_medicao_date.Enabled = False
            auto_medicao_notas.Enabled = False
            auto_medicao_qtd.Enabled = False
            auto_medicao_units.Enabled = False
            auto_medicao_del.Enabled = False
            auto_medicao_save.Enabled = False
            auto_medicao_reset.Enabled = False
            auto_medicao_workers_selected.Enabled = False
            auto_medicao_workers_selected.Items.Clear()
            auto_medicao_workers.Enabled = False
            auto_medicao_workers.Items.Clear()
            auto_medicao_update_workers.Enabled = False
            auto_medicao_update_tasks.Enabled = False
            If Not IsNothing(selected_qtd_record) Then
                For i = 0 To UBound(selected_qtd_record)
                    selected_qtd_record(i) = ""
                Next i
            End If
            load_production()

            translations.load("messagebox")
            Dim message As String = translations.getText("resultSuccessSaveRecord")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub auto_medicao_workers_selected_SelectedIndexChanged(sender As Object, e As EventArgs) Handles auto_medicao_workers_selected.SelectedIndexChanged

    End Sub

    Private Sub auto_medicao_translate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles auto_medicao_translate.LinkClicked
        enableButtonsAndLinks(Me, False)
        auto_medicao_notas.Text = DoTranslation(auto_medicao_notas.Text, site_frm.query_site("primary_lang")(InQueryDictionary(site_frm.query_site, auto_medicao_site.SelectedIndex - 1, "cod_site")), state.currentLang)
        enableButtonsAndLinks(Me, True)

    End Sub

    Private Sub auto_medicao_searchbox_button_Click(sender As Object, e As EventArgs) Handles auto_medicao_searchbox_button.Click
        Dim msgbox As message_box_frm
        DropClickSearchBox(auto_medicao_searchbox_button)
        If auto_medicao_SearchBox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf auto_medicao_datatable.Rows.Count <= 0 Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchResultsNotFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            doSearch(If(auto_medicao_datatable_cellY < 0, 0, auto_medicao_datatable_cellY), auto_medicao_datatable, auto_medicao_SearchBox.Text, {2, 3, 5}, True)
        End If
    End Sub

    Private Sub qtd_section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles qtd_section.SelectedIndexChanged

    End Sub

    Private Sub Label51_Click(sender As Object, e As EventArgs) Handles bordereau_sectionSelection_lbl.Click

    End Sub

    Private Sub auto_medicao_workers_DoubleClick(sender As Object, e As EventArgs) Handles auto_medicao_workers.DoubleClick
        Dim msgbox As message_box_frm
        If auto_medicao_workers.SelectedIndex > -1 Then
            If auto_medicao_workers_selected.Items.Count > 0 Then
                For i = 0 To auto_medicao_workers_selected.Items.Count - 1
                    If auto_medicao_workers.SelectedItem.ToString().Equals(auto_medicao_workers_selected.Items(i).ToString) Then
                        translations.load("messagebox")
                        Dim message As String = translations.getText("fieldAlreadyAdded")
                        msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                        msgbox.ShowDialog()
                        Exit Sub
                    End If
                Next i
            End If
            auto_medicao_workers_selected.Items.Add(auto_medicao_workers.SelectedItem.ToString)
        End If
    End Sub

    'LIVRAISONS
    Private Sub livraison_site_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles livraison_site.SelectedIndexChanged
        livraison_section.Items.Clear()
        If livraison_site.SelectedIndex > 0 Then
            If IsDate(query_site.Item("data_inicio")(livraison_site.SelectedIndex - 1)) Then
                livraison_data_inicio.Value = query_site.Item("data_inicio")(livraison_site.SelectedIndex - 1)
            Else
                livraison_data_inicio.Value = DateTime.Now
            End If

            If IsDate(query_site.Item("data_fim")(livraison_site.SelectedIndex - 1)) Then
                livraison_data_fim.Value = query_site.Item("data_fim")(livraison_site.SelectedIndex - 1)
            Else
                livraison_data_fim.Value = DateTime.Now
            End If

            If Not IsNothing(db_sections) Then
                Dim idx As Integer = 1
                translations.load("commonForm")
                livraison_section.Items.Add(translations.getText("dropdownSelectAll"))
                If Not livraison_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                    For i = 0 To db_sections.Item("cod_section").Count - 1
                        If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(livraison_site.SelectedIndex - 1)) Then
                            livraison_section.Items.Add(db_sections.Item("description")(i))
                            livraisonSectionsIndex(idx) = i
                            idx = idx + 1
                        End If
                    Next
                End If
            End If
            If livraison_section.Items.Count > 0 Then
                livraison_section.SelectedIndex = 0
            End If
        Else
            livraison_data_inicio.Value = DateTime.Now
            livraison_data_fim.Value = DateTime.Now
        End If
    End Sub

    Private Sub livraison_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles livraison_datatable.CellMouseDoubleClick
        livraison_datatable_cellY = e.RowIndex
        livraison_datatable_cellX = e.ColumnIndex
        If livraison_datatable_cellY.Equals(-1) Or livraison_datatable_cellX.Equals(-1) Then
            Exit Sub
        End If
        translations.load("siteActivity")
        If Not livraisonTable(e.RowIndex, 1).Equals(translations.getText("regieSection")) Then
            datatableChanges = False
            If SiteLivraisonEdit.ShowDialog() = DialogResult.OK Then
                load_livraisons()
                If livraison_datatable.Rows.Count >= livraison_datatable_cellY Then
                    livraison_datatable.CurrentCell = livraison_datatable.Rows(livraison_datatable_cellY).Cells(0)
                End If
            End If
        End If

    End Sub
    Private Sub livraison_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles livraison_datatable.CellContentClick

    End Sub
    Private Sub livraison_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles livraison_datatable.CellMouseClick
        translations.load("siteActivity")
        livraison_datatable_cellY = e.RowIndex
        livraison_datatable_cellX = e.ColumnIndex
        view_photo.Enabled = False
        add_photo.Enabled = True
        del_photo.Enabled = False
        download_photo.Enabled = False
        LivraisonPhotoSelection.Enabled = False
        photo_title.Text = translations.getText("photoDocument")
        LivraisonPhoto.Image = Nothing
        If livraison_datatable_cellY.Equals(-1) Or livraison_datatable_cellX.Equals(-1) Then
            Exit Sub
        End If

        If Not livraisonTable(e.RowIndex, 1).Equals(translations.getText("regieSection")) And Not livraisonTable(e.RowIndex, 2).Equals(translations.getText("DeliveryAddManualEntry")) Then
            datatableChanges = False
            If Not livraisonPhotos(e.RowIndex)(0).code.Equals("-1") Then
                LivraisonPhotoSelection.Items.Clear()
                photo_title.Text = (UBound(livraisonPhotos(e.RowIndex)) + 1) & " " & translations.getText("photosDocument")
                For i = 0 To UBound(livraisonPhotos(e.RowIndex))
                    LivraisonPhotoSelection.Items.Add(translations.getText("photo") & " " & (i + 1))
                Next i
                LivraisonPhotoSelection.Enabled = True
            End If
        End If
    End Sub

    Private Sub LivraisonPhotoSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LivraisonPhotoSelection.SelectedIndexChanged
        translations.load("siteActivity")
        If LivraisonPhotoSelection.SelectedIndex > -1 And Not livraisonTable(livraison_datatable_cellY, 1).Equals(translations.getText("regieSection")) And Not livraisonTable(livraison_datatable_cellY, 2).Equals(translations.getText("DeliveryAddManualEntry")) Then
            If livraisonPhotos(livraison_datatable_cellY)(LivraisonPhotoSelection.SelectedIndex).code.Equals("-1") Then
                LivraisonPhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.CenterImage
            Else
                LivraisonPhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "downloading.png")
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.CenterImage

                Dim tClient As WebClient = New WebClient
                Try
                    Dim tImage As Bitmap = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/files/delivery/" & livraisonPhotos(livraison_datatable_cellY)(LivraisonPhotoSelection.SelectedIndex).file)))
                    LivraisonPhoto.Image = tImage
                    view_photo.Enabled = True
                    add_photo.Enabled = True
                    del_photo.Enabled = True
                    download_photo.Enabled = True
                Catch ex As Exception
                    LivraisonPhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                    LivraisonPhoto.SizeMode = PictureBoxSizeMode.CenterImage
                    translations.load("errorMessages")
                    MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End If
    End Sub

    Private Sub download_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles download_photo.LinkClicked
        translations.load("commonForm")
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Title = translations.getText("saveImageDialogTitle")
        saveFileDialog1.Filter = translations.getText("saveImageDialogFilter") & " jpg|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim filename = saveFileDialog1.FileName
            LivraisonPhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub view_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles view_photo.LinkClicked
        Dim filename = MainMdiForm.state.basePath & "tmp\deliveryPhoto.jpg"
        Dim File = New FileInfo(filename)
        File.Refresh()
        If File.Exists Then
            Try
                File.Delete()
            Catch ex As Exception
                translations.load("errorMessages")
                MainMdiForm.statusMessage = translations.getText("errorDeletingData")
                Exit Sub
            End Try
        End If
        LivraisonPhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        Process.Start(filename)
    End Sub

    Private Sub del_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles del_photo.LinkClicked
        Dim msgbox As message_box_frm

        If LivraisonPhotoSelection.SelectedIndex > -1 And Not livraisonPhotos(livraison_datatable_cellY)(LivraisonPhotoSelection.SelectedIndex).code.Equals("-1") Then
            translations.load("messagebox")
            Dim message As String = translations.getText("questionDeletePhoto")
            msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If Not msgbox.ShowDialog = DialogResult.OK Then
                Exit Sub
            End If

            Dim vars As New Dictionary(Of String, String)
            Dim errorFlag As Boolean = False
            Dim errorMsg As String = ""

            vars.Add("task", "20")
            vars.Add("request", "del")
            vars.Add("cod", livraisonPhotos(livraison_datatable_cellY)(LivraisonPhotoSelection.SelectedIndex).code)
            Dim request As New HttpData(state)
            Dim response As String = request.RequestData(vars)

            If Not IsResponseOk(response) Then
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            Else
                translations.load("messagebox")
                Dim message2 As String = translations.getText("resultSuccessDelRecord")
                msgbox = New message_box_frm(message2 & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                livraisonPhotos(livraison_datatable_cellY)(LivraisonPhotoSelection.SelectedIndex).code = "-1"
                LivraisonPhotoSelection.Items.RemoveAt(LivraisonPhotoSelection.SelectedIndex)
                LivraisonPhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        Else
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectPhoto")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If

    End Sub

    Private Sub add_photo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles add_photo.LinkClicked
        Dim msgbox As message_box_frm

        translations.load("siteActivity")
        If Not livraisonTable(livraison_datatable_cellY, 1).Equals(translations.getText("regieSection")) And Not livraisonTable(livraison_datatable_cellY, 2).Equals(translations.getText("DeliveryAddManualEntry")) And Not livraisonCodes(livraison_datatable_cellY).Equals("") Then
            translations.load("commonForm")
            Dim OpenFileDialog1 As New OpenFileDialog
            OpenFileDialog1.Title = translations.getText("openFileDialogTitle")
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = translations.getText("saveImageDialogFilter") & " jpg|*.jpg"
            If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                Dim filename = OpenFileDialog1.FileName
                LivraisonPhoto.Image = Image.FromFile(filename)
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.StretchImage

                translations.load("messagebox")
                Dim message As String = translations.getText("questionAddPhoto")
                msgbox = New message_box_frm(message & ".", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If (msgbox.ShowDialog = DialogResult.OK) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "20") 'photo
                    vars.Add("request", "add")
                    vars.Add("where", "delivery")
                    vars.Add("cod", livraisonCodes(livraison_datatable_cellY))
                    Dim request As New HttpData(state)
                    Dim response As String = request.SendHttpFile(vars, filename)

                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    If Not IsResponseOk(response) Then
                        msgbox = New message_box_frm(GetMessage(response), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        msgbox.ShowDialog()
                    Else
                        load_livraisons()
                        LivraisonPhotoSelection.Items.Clear()

                    End If
                End If
                LivraisonPhoto.Image = Image.FromFile(MainMdiForm.state.imagesPath & "camera.png")
                LivraisonPhoto.SizeMode = PictureBoxSizeMode.CenterImage
            Else
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorOperationCanceled")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub
    Private Sub livraison_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles livraison_datatable.CellValueNeeded

        If UBound(livraisonTable, 1) < e.RowIndex Or UBound(livraisonTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If

        translations.load("siteActivity")
        If livraisonTable(e.RowIndex, 1).Equals(translations.getText("regieSection")) Then
            livraison_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
        End If

        If livraisonTable(e.RowIndex, 2).Equals(translations.getText("DeliveryAddManualEntry")) Then
            livraison_datatable.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
        End If

        e.Value = livraisonTable(e.RowIndex, e.ColumnIndex)
        currentLivraisonDatatable = livraison_datatable
    End Sub

    Private Sub select_site_Click_1(sender As Object, e As EventArgs) Handles select_site.Click
        DropClickSearchBox(select_site)

        load_livraisons()
    End Sub

    Private Sub auto_medicao_workers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles auto_medicao_workers.SelectedIndexChanged

    End Sub

    Private Sub select_site_Click(sender As Object, e As EventArgs)
        load_livraisons()
    End Sub

    Sub load_livraisons()
        If livraison_site.SelectedIndex < 1 And livraison_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = livraison_datatable.Width
        mask.Height = livraison_datatable.Height
        mask.Location = New Drawing.Point(livraison_datatable.Location.X, livraison_datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TabControl.TabPages(3).Controls.Add(mask)
        mask.BringToFront()
        enableButtonsAndLinks(Me, False)

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

        updated = False
        livraison_site.Enabled = False
        auto_medicao_site.Enabled = False
        qtd_site.Enabled = False

        bwLoadLivraison = New BackgroundWorker()
        bwLoadLivraison.WorkerSupportsCancellation = True
        bwLoadLivraison.RunWorkerAsync()
    End Sub

    Private Sub bwLoadLivraison_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadLivraison.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        Dim section_counter As Integer = -1
        Dim delivery_counter As Integer = -1
        Dim photo_counter As Integer = -1

        Dim rowpos As Integer = 0
        Dim numRows As Integer = 0
        Dim num_cols As Integer = 0


        translations.load("commonForm")
        Dim qsection As String = ""
        livraison_section.Invoke(Sub()
                                     If livraison_section.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                                         qsection = "all"
                                     Else
                                         qsection = db_sections.Item("cod_section")(livraisonSectionsIndex(livraison_section.SelectedIndex))
                                     End If
                                 End Sub)

        Dim startD As Date, endD As Date
        livraison_data_inicio.Invoke(Sub()
                                         startD = livraison_data_inicio.Value
                                     End Sub)
        livraison_data_fim.Invoke(Sub()
                                      endD = livraison_data_fim.Value
                                  End Sub)

        If DateTime.Compare(startD, endD) >= 0 Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("errorMessages")
            errorMsg = translations.getText("errorDateInterval")
            errorFlag = True
            GoTo lastLine
        End If

        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("commServer")

        vars.Add("task", "22")
        vars.Add("request", "load")
        vars.Add("sdate", startD.ToString("yyyy-MM-dd"))
        vars.Add("edate", endD.ToString("yyyy-MM-dd"))
        vars.Add("section", qsection)
        livraison_site.Invoke(Sub()
                                  vars.Add("site", query_site.Item("cod_site")(livraison_site.SelectedIndex - 1))
                              End Sub)

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)

        If Not IsResponseOk(response) Or (IsResponseOk(response) And GetMessageField(response, "empty")) Then
            errorMsg = GetMessage(response)
            errorFlag = True

            If qsection.Equals("all") Then ' no records found since its all sections add manual entry is not allowed
                GoTo lastLine
            End If

            'add manual entry
            num_cols = 6
            rowpos = 1
            ReDim livraisonTable(rowpos - 1, num_cols)
            ReDim livraisonPhotos(rowpos - 1)
            ReDim livraisonCodes(rowpos - 1)
            ReDim livraisonSection(rowpos - 1)

            For i = 0 To rowpos - 1
                livraisonCodes(i) = ""
                livraisonSection(i) = ""
                For j = 0 To num_cols
                    livraisonTable(i, j) = ""
                Next j
            Next i

            translations.load("siteActivity")
            rowpos = 0

            livraisonSection(rowpos) = qsection
            livraisonTable(rowpos, 0) = "-"
            livraisonTable(rowpos, 1) = "-"
            livraisonTable(rowpos, 2) = translations.getText("DeliveryAddManualEntry")
            livraisonTable(rowpos, 3) = "-"
            livraisonTable(rowpos, 4) = "-"
            livraisonTable(rowpos, 5) = "-"
            livraisonTable(rowpos, 6) = "-"
            rowpos = 1
            GoTo lastLine
        End If

        translations.load("commonForm")
        MainMdiForm.statusMessage = translations.getText("addDataToTable")
        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim sections As JArray = JArray.Parse(data.Item("data").ToString)

            For Each section In sections
                rowpos = rowpos + 1
                Dim deliveries As JArray = JArray.Parse(section.Item("delivery").ToString)
                rowpos = rowpos + 1
                For Each delivery In deliveries
                    rowpos = rowpos + 1
                Next delivery
            Next section

            num_cols = 6

            ReDim livraisonTable(rowpos - 1, num_cols)
            ReDim livraisonPhotos(rowpos - 1)
            ReDim livraisonCodes(rowpos - 1)
            ReDim livraisonSection(rowpos - 1)

            For i = 0 To rowpos - 1
                livraisonCodes(i) = ""
                livraisonSection(i) = ""
                For j = 0 To num_cols
                    livraisonTable(i, j) = ""
                Next j
            Next i

            translations.load("siteActivity")
            rowpos = 0
            For Each section In sections
                livraisonTable(rowpos, 0) = ""
                livraisonTable(rowpos, 1) = translations.getText("regieSection")
                livraisonTable(rowpos, 2) = section.Item("name").ToString
                livraisonTable(rowpos, 3) = "-"
                livraisonTable(rowpos, 4) = "-"
                livraisonTable(rowpos, 5) = "-"
                livraisonTable(rowpos, 6) = "-"

                rowpos = rowpos + 1
                Dim deliveries As JArray = JArray.Parse(section.Item("delivery").ToString)
                Dim sectionCode As String = ""
                For Each delivery In deliveries
                    livraisonCodes(rowpos) = delivery.Item("code").ToString
                    livraisonTable(rowpos, 0) = delivery.Item("ref").ToString
                    livraisonTable(rowpos, 1) = delivery.Item("data").ToString
                    livraisonTable(rowpos, 2) = delivery.Item("material").ToString
                    livraisonTable(rowpos, 3) = delivery.Item("units").ToString
                    livraisonTable(rowpos, 4) = delivery.Item("qtd").ToString
                    livraisonTable(rowpos, 5) = delivery.Item("note").ToString.Replace(vbCrLf, Environment.NewLine)
                    sectionCode = delivery.Item("section").ToString

                    ReDim Preserve livraisonPhotos(rowpos)(0)
                    livraisonPhotos(rowpos)(0).code = "-1"
                    If Not IsNothing(delivery.Item("photos")) Then
                        Dim photos As JArray = JArray.Parse(delivery.Item("photos").ToString)
                        photo_counter = -1
                        ReDim Preserve livraisonPhotos(rowpos)(photos.Count - 1)
                        For Each photo In photos
                            photo_counter = photo_counter + 1
                            livraisonPhotos(rowpos)(photo_counter).code = photo.Item("code").ToString
                            livraisonPhotos(rowpos)(photo_counter).file = photo.Item("file").ToString
                        Next photo
                    End If
                    rowpos = rowpos + 1
                Next delivery

                livraisonSection(rowpos) = sectionCode
                livraisonTable(rowpos, 0) = "-"
                livraisonTable(rowpos, 1) = "-"
                livraisonTable(rowpos, 2) = translations.getText("DeliveryAddManualEntry")
                livraisonTable(rowpos, 3) = "-"
                livraisonTable(rowpos, 4) = "-"
                livraisonTable(rowpos, 5) = "-"
                livraisonTable(rowpos, 6) = "-"
                rowpos = rowpos + 1
            Next section
        Catch ex As Exception
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            errorMsg = ex.Message.ToString
            errorFlag = True
            GoTo lastLine
        End Try

lastLine:
        Dim s(3) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            s(2) = rowpos
            s(3) = num_cols
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            s(2) = rowpos
            s(3) = num_cols
            e.Result = s
        End If

    End Sub

    Private Sub bwLoadLivraison_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadLivraison.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            translations.load("commonForm")
            If livraison_section.Text.Equals(translations.getText("dropdownSelectAll")) Then
                mask.Dispose()
                enableButtonsAndLinks(Me, True)
                Exit Sub
            End If
        End If

        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        Dim rowpos = e.Result(2)
        Dim num_cols = e.Result(3)

        sizeOfString = g.MeasureString("888", fontToMeasure)

        SuspendLayout()
        With livraison_datatable
            .Visible = False

            .VirtualMode = True
            .Rows.Clear()
            .RowCount = rowpos

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = num_cols

            .Columns(0).HeaderCell.Value = translations.getText("deliveryTableColumnRef")
            .Columns(0).Width = g.MeasureString("1234567890", fontToMeasure).Width

            .Columns(1).HeaderCell.Value = translations.getText("deliveryTableColumnData")
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(2).HeaderCell.Value = translations.getText("deliveryTableColumnMaterial")
            .Columns(2).Width = 400

            .Columns(3).HeaderCell.Value = translations.getText("deliveryTableColumnUnits")
            .Columns(3).Width = g.MeasureString("MMM", fontToMeasure).Width
            .Columns(4).HeaderCell.Value = translations.getText("deliveryTableColumnQuantity")
            .Columns(4).Width = g.MeasureString("88.888.00", fontToMeasure).Width
            .Columns(5).HeaderCell.Value = translations.getText("deliveryTableColumnAnnotations")
            .Columns(5).Width = 400

            Dim colMaxHEight As Integer = 0
            Dim lines As Integer = 0
            Dim newlines As Integer = 0
            For i = 0 To rowpos - 1
                .Rows(i).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Rows(i).Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                colMaxHEight = 0
                newlines = 0
                For j = 0 To 5
                    sizeOfString = g.MeasureString(livraisonTable(i, j), fontToMeasure)
                    lines = Math.Round(sizeOfString.Width / .Columns(j).Width + 0.5, 0, MidpointRounding.AwayFromZero)
                    newlines = livraisonTable(i, j).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * colMaxHEight
            Next i
            .Visible = True
        End With
        ResumeLayout()
        mask.Dispose()
        enableButtonsAndLinks(Me, True)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        statsLinkLivraison.Enabled = True
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles livraisonCurrentMonthSelection_lbl.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        livraison_data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        livraison_data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub journal_tab_Click(sender As Object, e As EventArgs) Handles journal_tab.Click

    End Sub

    Private Sub statsLinkLivraison_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles statsLinkLivraison.LinkClicked
        siteLivraisonStats.ShowDialog()
    End Sub



    '===========  JOURNAL ==============================================================
    Private Sub journalLoadButton_Click(sender As Object, e As EventArgs) Handles journalLoadButton.Click
        DropClickSearchBox(journalLoadButton)

        Dim msgbox As message_box_frm
        If combo_section.SelectedIndex > -1 Then
            activities.Text = ""
            ocurrences.Text = ""
            save.Enabled = True
            view_doc.Enabled = True
            update_logger.Enabled = True
            update_journal.Enabled = True

            If Not journalFile.Equals("") Then
                Dim JFile = New FileInfo(Path.Combine(state.tmpPath, journalFile))
                JFile.Refresh()
                If Not JFile.Exists Then
                    LoadJournalTemplateFile()
                End If
            Else
                LoadJournalTemplateFile()
            End If

            If New FileInfo(journalFile).Length.Equals(0) Then
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorFileEmpty")
                translations.load("messagebox")
                msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            End If
            Application.DoEvents()
            loadDailyReport()
            Application.DoEvents()
            loadWorkers()
            Application.DoEvents()
            loadJournal()
            Application.DoEvents()
        Else
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()

        End If
    End Sub
    Private Sub LoadJournalTemplateFile()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "26")
        vars.Add("type", "journal")
        Dim request As New HttpData(state)
        journalFile = request.GetHttpFile(vars)
        If Not IsResponseOk(journalFile) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(journalFile) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        Else
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(journalFile)
            journalFile = data.Item("file")
        End If
    End Sub


    Private Sub loadJournalTemplate(file As String)
        Dim msgbox As message_box_frm
        Dim cfgFile = New FileInfo(file)
        cfgFile.Refresh()
        If Not cfgFile.Exists Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorDownloadingFile")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If combo_site.SelectedIndex < 1 Or combo_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "23")
        vars.Add("type", "journal")
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If (Not IsResponseOk(response)) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = GetMessage(response)
            Exit Sub
        End If

        richtext = New RichTextBox
        richtext.LoadFile(file, RichTextBoxStreamType.RichText)

        Dim str As String = ""
        Dim sb = New System.Text.StringBuilder()
        'sb.Append("{\rtf1\ansi")
        'sb.Append("This number is bold: \b 123\b0 ! Yes, it is...")
        'sb.Append("}")

        translations.load("siteActivity")
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)

            For Each item As JObject In jsonarray
                Dim s As Boolean = item.SelectToken("soustraitant")
                str = ""
                If (s.Equals(True)) Then
                    str = (" (" & translations.getText("journalDocumentClient") & ")")
                End If
                sb.Append(" \b " & translations.getText("journalDocumentCompanyName") & ": " & item.SelectToken("entreprise").ToString & " \b0 " & str & " \line ")

                Dim jsonarrayCat As JArray = JArray.Parse(item.SelectToken("category").ToString)
                For Each itemCat As JObject In jsonarrayCat
                    sb.Append(" \b      " & itemCat.SelectToken("name").ToString & " \b0 (" & itemCat.SelectToken("total").ToString & " " & translations.getText("journalDocumentTotal") & " ) \line ")
                    sb.Append("          " & itemCat.SelectToken("workers").ToString.Replace("[newline]", " \line           ") & " \line ")
                Next
                sb.Append(" \line ")
                sb.Append(" \b " & translations.getText("journalDocumentTotalWorkersSite") & ":  \b0 " & item.SelectToken("total").ToString)
            Next

        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        str = richtext.Rtf
        str = str.Replace("[workers_on_site]", sb.ToString)

        str = str.Replace("[date]", calendar.Value.ToString("yyyy-MM-dd"))
        str = str.Replace("[activities]", activities.Text.Replace(Environment.NewLine, " \line "))
        str = str.Replace("[ocurrences]", ocurrences.Text.Replace(Environment.NewLine, " \line "))
        str = str.Replace("[chantier]", query_site.Item("name")(combo_site.SelectedIndex - 1) & " (" & query_site.Item("address")(combo_site.SelectedIndex - 1) & ") \line " _
                                                    & translations.getText("journalDocumentAddress") & ": " & query_site.Item("gps_lon")(combo_site.SelectedIndex - 1) & " \line " _
                                                    & translations.getText("journalDocumentGpsCoordinates") & ": " & query_site.Item("initials")(combo_site.SelectedIndex - 1) & "   " & query_site.Item("gps_lat")(combo_site.SelectedIndex - 1))


        str = str.Replace("[responsable]", state.journalResponsables)

        If (Not weatherText(0).Equals("")) Then
            str = str.Replace("[matin]", "[matin] \line " & weatherText(0).Replace("[newline]", " \line "))
        End If
        If (Not weatherText(1).Equals("")) Then
            str = str.Replace("[apres_midi]", "[apres_midi] \line " & weatherText(1).Replace("[newline]", " \line "))
        End If
        If (Not weatherText(2).Equals("")) Then
            str = str.Replace("[nuit]", "[nuit] \line " & weatherText(2).Replace("[newline]", " \line "))
        End If

        richtext.Rtf = str

        If (Not weatherText(0).Equals("")) Then
            Clipboard.Clear()
            Clipboard.SetImage(weatherIcon(0))
            richtext.SelectionStart = richtext.Find("[matin]")
            richtext.SelectionLength = 7
            richtext.Paste()
        Else
            richtext.Rtf = richtext.Rtf.Replace("[matin]", "")
        End If
        If (Not weatherText(1).Equals("")) Then
            Clipboard.Clear()
            Clipboard.SetImage(weatherIcon(1))
            richtext.SelectionStart = richtext.Find("[apres_midi]")
            richtext.SelectionLength = 12
            richtext.Paste()
        Else
            richtext.Rtf = richtext.Rtf.Replace("[apres_midi]", "")
        End If
        If (Not weatherText(2).Equals("")) Then
            Clipboard.Clear()
            Clipboard.SetImage(weatherIcon(2))
            richtext.SelectionStart = richtext.Find("[nuit]")
            richtext.SelectionLength = 6
            richtext.Paste()
        Else
            richtext.Rtf = richtext.Rtf.Replace("[nuit]", "")
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            MainMdiForm.busy.Close(True)
        End If


        '        Image img = Image.FromFile(filename) 'if you want to load it from file...
        '        Clipboard.SetImage(img)
        '       richTextBox1.Paste()
        '       richTextBox1.AppendText("your text")
        '   Private Sub UpdateSmiley(Code As String, ResNumber As Integer)
        ' 
        '        Set pctSmile.Picture = LoadResPicture(ResNumber, vbResBitmap)
        '        Clipboard.Clear()
        '        Clipboard.SetData pctSmile.Picture, vbCFBitmap
        '
        '        Do Until rtbPane.Find(Code) = -1
        '        rtbPane.Locked = False
        '       rtbPane.SelStart = rtbPane.Find(Code)
        '            rtbPane.SelLength = 2 'To Set The Position for bmp placement
        '        SendMessage rtbPane.hwnd, &H302, 0, 0
        '        rtbPane.Locked = True
        '        Loop
        '
        '        Clipboard.Clear()

        '    End Sub

        '   RichTextBox1.Lines(RichTextBox1.GetLineFromCharIndex(RichTextBox1.SelectionStart))
    End Sub

    Private Sub loadDailyReport()
        Dim report As Dictionary(Of String, List(Of String))
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "dailyreport")
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        report = request.ConvertDataToArray("dailyreport", state.querySiteDailyReportFields, response)
        If Not IsNothing(report) Then
            activities.Text = report.Item("activities")(0)
            ocurrences.Text = report.Item("ocurrences")(0)
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub


    Private Sub loadJournal()

        ReDim weatherText(3)
        ReDim weatherIcon(3)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        weatherText(0) = ""
        weatherText(1) = ""
        weatherText(2) = ""

        weatherIcon(0) = Nothing
        weatherIcon(1) = Nothing
        weatherIcon(2) = Nothing

        If Me.panel_journal.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.panel_journal.Controls.Count - 1 To 0 Step -1
                ctrl = Me.panel_journal.Controls(i)
                Me.panel_journal.Controls.Remove(ctrl)
                ctrl.Dispose()
            Next
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "24")
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)

        If (Not IsResponseOk(response)) Then
            MainMdiForm.statusMessage = GetMessage(response)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Exit Sub
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)
            Dim Position As Integer = 0

            For Each item As JObject In jsonarray

                If (item.SelectToken("title").ToString.Equals("Registo de presenças") And Not meteo_chk.Checked) Then Continue For
                If (item.SelectToken("title").ToString.Equals("Marcação de trabalho à Régie") And Not regie_chk.Checked) Then Continue For
                If (item.SelectToken("title").ToString.Equals("Registo de Qtd executada") And Not qtds_chk.Checked) Then Continue For
                If (item.SelectToken("title").ToString.Equals("Entrega de material em obra") And Not livraison_chk.Checked) Then Continue For
                If (item.SelectToken("title").ToString.Equals("Entrada no Jornal") And Not journal_chk.Checked) Then Continue For
                If (item.SelectToken("title").ToString.Equals("Informação meteorologica") And Not meteo_chk.Checked) Then Continue For

                Dim Label_time As New Label() With
                            {
                            .Font = New Font("Verdana", 10, FontStyle.Bold),
                            .Text = item.SelectToken("time").ToString,
                            .Location = New Point(10, 20 + Position)
                           }
                Dim sz As Size = New Size(Label_time.Width, Int32.MaxValue)
                sz = TextRenderer.MeasureText(Label_time.Text, Label_time.Font, sz, TextFormatFlags.WordBreak)
                Label_time.Height = sz.Height
                Label_time.Width = sz.Width
                'Position += sz.Height
                panel_journal.Controls.Add(Label_time)

                Dim Label_title As New Label() With
                            {
                            .Font = New Font("Verdana", 8, FontStyle.Bold),
                            .Text = item.SelectToken("title").ToString,
                            .Location = New Point(10 + sz.Width, 23 + Position),
                            .Width = Panel_logger.Width - 120
                           }
                Position += sz.Height
                sz = New Size(Label_title.Width, Int32.MaxValue)
                sz = TextRenderer.MeasureText(Label_title.Text, Label_title.Font, sz, TextFormatFlags.WordBreak)
                Label_title.Height = sz.Height
                Label_title.Width = sz.Width
                panel_journal.Controls.Add(Label_title)

                Dim posX As Integer = 10

                If (item.SelectToken("title").ToString.Equals("Informação meteorologica")) Then

                    Dim img As New PictureBox() With
                        {
                            .Location = New Point(10, 10 + Position),
                            .Width = 50,
                            .Height = 50
                        }
                    Dim tClient As WebClient = New WebClient
                    Dim tImage As Bitmap

                    Try
                        Dim photo As String = "http://openweathermap.org/img/w/" & item.SelectToken("icon").ToString & ".png"
                        tImage = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(photo)))
                        img.Image = tImage
                    Catch ex As Exception
                        MainMdiForm.statusMessage = ex.Message.ToString
                        saveCrash(ex)
                        tImage = Image.FromFile(state.imagesPath & "noweather.png")
                        img.Image = tImage
                        translations.load("errorMessages")
                        MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    img.SizeMode = PictureBoxSizeMode.StretchImage

                    panel_journal.Controls.Add(img)
                    posX = 60
                    Dim time As String = item.SelectToken("time")
                    Dim hour As Integer = time.Substring(0, 2)
                    If hour < 12 And weatherText(0).Equals("") Then
                        weatherText(0) = item.SelectToken("text").ToString
                        weatherIcon(0) = tImage
                    End If
                    If hour > 12 And hour < 18 And weatherText(1).Equals("") Then
                        weatherText(1) = item.SelectToken("text").ToString
                        weatherIcon(1) = tImage
                    End If
                    If hour > 18 And weatherText(2).Equals("") Then
                        weatherText(2) = item.SelectToken("text").ToString
                        weatherIcon(2) = tImage
                    End If
                End If

                If (item.SelectToken("text") IsNot Nothing) Then

                    Dim Label_text As New Label() With
                            {
                            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                            .Text = item.SelectToken("text").ToString.Replace("[newline]", Environment.NewLine),
                            .Location = New Point(posX, 20 + Position),
                            .Width = Panel_logger.Width - 20 - posX
                            }
                    sz = New Size(Label_text.Width, Int32.MaxValue)
                    sz = TextRenderer.MeasureText(Label_text.Text, Label_text.Font, sz, TextFormatFlags.WordBreak)
                    Label_text.Height = sz.Height
                    Position += sz.Height
                    panel_journal.Controls.Add(Label_text)
                End If

                Position += 20
            Next

        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub loadWorkers()

        If Me.Panel_logger.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.Panel_logger.Controls.Count - 1 To 0 Step -1
                ctrl = Me.Panel_logger.Controls(i)
                Me.Panel_logger.Controls.Remove(ctrl)
                ctrl.Dispose()
            Next
        End If
        If categories_box.Checked Then
            loadWorkersCategories()
        Else
            loadWorkersSimple()
        End If

    End Sub
    Private Sub loadWorkersCategories()
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "23")
        vars.Add("type", "categories")
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)

        If (Not IsResponseOk(response)) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = GetMessage(response)
            Exit Sub
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)
            Dim Position As Integer = 0

            For Each item As JObject In jsonarray

                Dim Label As New Label() With
                        {
                        .Font = New Font("Verdana", 10, FontStyle.Bold),
                        .Text = item.SelectToken("category").ToString.Replace("[newline]", Environment.NewLine),
                        .Location = New Point(10, 20 + Position),
                        .Width = Panel_logger.Width - 120
                       }
                Dim sz As Size = New Size(Label.Width, Int32.MaxValue)
                sz = TextRenderer.MeasureText(Label.Text, Label.Font, sz, TextFormatFlags.WordBreak)
                Label.Height = sz.Height
                Position += sz.Height
                Panel_logger.Controls.Add(Label)

                Dim Label2 As New Label() With
                        {
                        .Font = New Font("Verdana", 8, FontStyle.Regular),
                        .Text = item.SelectToken("name").ToString.Replace("[newline]", Environment.NewLine),
                        .Location = New Point(10, 20 + Position),
                        .Width = Panel_logger.Width - 120
                       }
                sz = New Size(Label2.Width, Int32.MaxValue)
                sz = TextRenderer.MeasureText(Label2.Text, Label2.Font, sz, TextFormatFlags.WordBreak)
                Label2.Height = sz.Height
                Position += sz.Height
                Panel_logger.Controls.Add(Label2)
            Next

        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub
    Private Sub loadWorkersSimple()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "23")
        vars.Add("type", "workers")
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)

        If (Not IsResponseOk(response)) Then
            MainMdiForm.statusMessage = GetMessage(response)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Exit Sub
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Dim jsonarray As JArray = JArray.Parse(jsonResult.Item("data").ToString)
            Dim Position As Integer = 0

            For Each item As JObject In jsonarray

                Dim img As New PictureBox() With
                    {
                        .Location = New Point(10, 20 + 110 * Position),
                        .Width = 100,
                        .Height = 100
                    }
                Dim tClient As WebClient = New WebClient
                Try
                    Dim photo As String = item.SelectToken("imgURL").ToString
                    If photo.Equals("") Then
                        photo = "person.png"
                    End If
                    Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & photo)))
                    img.Image = tImage
                Catch ex As Exception
                    img.Image = Image.FromFile(state.imagesPath & "worker.png")

                    translations.load("errorMessages")
                    MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                img.SizeMode = PictureBoxSizeMode.StretchImage

                Panel_logger.Controls.Add(img)

                translations.load("attendance")
                Dim validacao As String = ""
                If item.SelectToken("validacao").ToString.Equals("P") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("fullDay")
                ElseIf item.SelectToken("validacao").ToString.Equals("PI") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("partialDay") & " " & item.SelectToken("faltou").ToString & " h"
                ElseIf item.SelectToken("validacao").ToString.Equals("I") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("badWeather")
                ElseIf item.SelectToken("validacao").ToString.Equals("A") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("fullDayAbsent")
                ElseIf item.SelectToken("validacao").ToString.Equals("V") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("holidays")
                ElseIf item.SelectToken("validacao").ToString.Equals("C") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("playDay")
                ElseIf item.SelectToken("validacao").ToString.Equals("M") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("malady")
                ElseIf item.SelectToken("validacao").ToString.Equals("FA") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("siteAnnual")
                ElseIf item.SelectToken("validacao").ToString.Equals("FI") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("siteWeather")
                ElseIf item.SelectToken("validacao").ToString.Equals("") Then
                    validacao = translations.getText("validation") & ": " & translations.getText("notValidated")
                End If

                Dim Label As New Label() With
                        {
                        .Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold),
                        .Text = item.SelectToken("name").ToString.Replace("[newline]", Environment.NewLine) & Environment.NewLine _
                        & translations.getText("checkin") & ": " & item.SelectToken("checkin").ToString & Environment.NewLine _
                        & translations.getText("checkout") & ": " & item.SelectToken("checkout").ToString & Environment.NewLine _
                        & validacao,
                        .Location = New Point(110, 20 + 110 * Position),
                        .Height = 100,
                        .Width = Panel_logger.Width - 120
                       }


                Panel_logger.Controls.Add(Label)
                Position += 1
            Next
            translations.load("siteActivity")
            journal_num_workers.Text = Position & " " & translations.getText("journalDocumentWorkersOnSite")
            journal_num_workers.Location = New Point(Panel_logger.Location.X + Panel_logger.Width - journal_num_workers.Width, journal_num_workers.Location.Y)


        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_site.SelectedIndexChanged
        combo_section.Items.Clear()
        If combo_site.SelectedIndex > 0 Then
            If Not IsNothing(db_sections) Then
                Dim idx As Integer = 0

                For i = 0 To db_sections.Item("cod_section").Count - 1
                    If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(combo_site.SelectedIndex - 1)) Then
                        combo_section.Items.Add(db_sections.Item("description")(i))
                        JournalSectionsIndex(idx) = i
                        idx = idx + 1
                    End If
                Next
            End If
            If combo_section.Items.Count > 0 Then
                combo_section.SelectedIndex = 0
            End If
        End If
    End Sub


    Private Sub update_logger_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles update_logger.LinkClicked
        loadWorkers()
    End Sub

    Private Sub update_journal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles update_journal.LinkClicked
        loadJournal()
    End Sub

    Private Sub save_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        Dim msgbox As message_box_frm
        If activities.Text.Equals("") Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("journalErrorActivities")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If ocurrences.Text.Equals("") Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("journalErrorOccurences")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If combo_site.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If combo_section.SelectedIndex < 0 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSection")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If
        save.Enabled = False
        loadJournalTemplate(journalFile)
        Try
            FileSystem.Kill(Environment.CurrentDirectory & "\tmp\journal.rtf")
            FileSystem.Kill(Environment.CurrentDirectory & "\tmp\journal.pdf")
        Catch

        End Try

        richtext.SaveFile(Environment.CurrentDirectory & "\tmp\journal.rtf")

        Dim p As New ProcessStartInfo
        p.FileName = Environment.CurrentDirectory & "\pdf\docto.exe"
        p.Arguments = " -f """ & Environment.CurrentDirectory & "\tmp\journal.rtf """ & " -O """ & Environment.CurrentDirectory & "\tmp\journal.pdf""" & " -T wdFormatPDF -Q"
        p.WindowStyle = ProcessWindowStyle.Hidden

        Process.Start(p)

        Dim file = New FileInfo(Environment.CurrentDirectory & "\tmp\journal.pdf")

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        Do While Microsoft.VisualBasic.Timer() < start + 10 And Not file.Exists
            System.Windows.Forms.Application.DoEvents()
            file.Refresh()
        Loop

        If Not file.Exists Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorFileConversion")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            save.Enabled = True
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "25")
        vars.Add("site", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        vars.Add("section", db_sections.Item("cod_section")(JournalSectionsIndex(combo_section.SelectedIndex)))
        vars.Add("activity", activities.Text)
        vars.Add("ocurrence", ocurrences.Text)
        vars.Add("date", calendar.Value.ToString("yyyy-MM-dd"))
        Dim request As New HttpData(state)
        Dim response As String = request.SendHttpFile(vars, state.tmpPath & "journal.pdf")

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            Dim message As String = translations.getText("resultSuccessSaveRecord")
            msgbox = New message_box_frm(message & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        save.Enabled = True
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")

        'Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", "Microsoft Print to PDF"))

        'Send to default printer using the default program that Is associated with the rtf
        'Dim p As New Process
        'With p.StartInfo
        '.FileName = fileName
        '.Verb = "print"
        '.CreateNoWindow = True

        'End With
        'p.Start()

    End Sub

    Private Sub view_doc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles view_doc.LinkClicked
        loadJournalTemplate(journalFile)
        journal_view_frm.Width = MainMdiForm.Width * 0.5
        journal_view_frm.Height = MainMdiForm.Height * 0.75
        journal_view_frm.ShowDialog()
    End Sub

    Private Sub combo_section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_section.SelectedIndexChanged

    End Sub

End Class