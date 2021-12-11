Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Threading
Imports System.Windows
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class logger_frm
    Private state As State
    Private translations As languageTranslations

    Private msgbox As message_box_frm
    Private works_worker, works_entreprise, works_category, works_register, works_ausencias, works_sections As Dictionary(Of String, List(Of String))


    Private sectionsIndex As Integer()
    Private DBrecord As String(,,,)


    Private siteSelection As Integer(,)
    Private response As String = ""

    Private holidays As DateTime() = Nothing
    Private closures As DateTime() = Nothing
    Private absense As Integer(,) = Nothing
    Private record As Integer(,) = Nothing

    Public Shared serverData As workersJson(,)
    Public Shared stats As _stats
    Public Shared cellX As Integer = 0
    Public Shared cellY As Integer = 0
    Public Shared works_site As Dictionary(Of String, List(Of String))
    Public Shared idxTableWorkerPos As Integer()
    Public Shared AttendanceTable As String(,)
    Public Shared calendar As MonthCalendar
    Public Shared currentDatatable As DataGridView

    Structure workersJson
        Public section As Integer
        Public site As Integer

        Public code As Integer
        Public name As String
        Public contact As String
        Public nfc As String
        Public category As Integer
        Public company As Integer
        Public eContact As String
        Public photo As String
        Public checkin As String
        Public checkout As String
        Public data As Date
        Public status As String
        Public absense As String
        Public notes As String
        Public validationReason As String
        Public reference As String
        Public duplicates As String
    End Structure

    Structure _stats
        Public site As String
        Public data As String
        Public maxWorkers As Integer
        Public minWorkers As Integer
        Public absenseHours As TimeSpan
        Public totalDaysWorked As Integer
        Public totalWorkDays As Integer
        Public totalDaysInMonth As Integer
    End Structure

    Private t As System.Threading.Thread = Nothing
    Private loaded As Boolean = False
    Private WithEvents bwSites As BackgroundWorker

    Private mask As PictureBox = Nothing

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()
    End Sub

    Private Sub logger_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        SetDoubleBuffered(datatable)

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.SuspendLayout()

        combo_site.Location = New Drawing.Point(site_lbl.Location.X + site_lbl.Width + 5, combo_site.Location.Y)
        company_lbl.Location = New Drawing.Point(combo_site.Location.X + combo_site.Width + 5, company_lbl.Location.Y)
        combo_company.Location = New Drawing.Point(company_lbl.Location.X + company_lbl.Width + 5, combo_company.Location.Y)

        datatable.Width = Me.Width - datatable.Location.X - 5
        datatable.Height = Me.Height - datatable.Location.Y - notes_group.Height - 10
        calendar_log.Location = New Drawing.Point((datatable.Location.X - 10) / 2 - calendar_log.Width / 2, calendar_log.Location.Y)

        notes_group.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y + datatable.Height + 5)
        notes_group.Width = datatable.Width * 0.45
        txt_nota.Width = notes_group.Width - 5 - txt_nota.Location.X
        txt_nota.Height = notes_group.Height - txt_nota.Location.Y - 10 - gravarnota_lbl.Height - 3
        gravarnota_lbl.Location = New Drawing.Point(txt_nota.Location.X, txt_nota.Location.Y + txt_nota.Height + 3)

        GroupBox_detalhes.Width = datatable.Width * 0.54
        GroupBox_detalhes.Location = New Drawing.Point(datatable.Location.X + datatable.Width - GroupBox_detalhes.Width, notes_group.Location.Y)
        GroupBox_detalhes.Height = notes_group.Location.Y + notes_group.Height - notes_group.Location.Y

        GroupBox_legenda.Height = notes_group.Height + notes_group.Location.Y - GroupBox_legenda.Location.Y
        stats_lbl.Location = New Drawing.Point(datatable.Location.X + datatable.Width - stats_lbl.Width, stats_lbl.Location.Y)

        site_lbl.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        company_lbl.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_company.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        stats_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        txt_nota.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        gravarnota_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        notes_group.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar_log.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        GroupBox_legenda.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        fullday_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        partialAbsense_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        badWeather_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        fullDayAbsent_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        holidays_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        playDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        malady_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteAnnual_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteBadWeather_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        teamAssign_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        changeSite_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        colorNoRecord_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        colorAbsentDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_fullDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_partialDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_doubleRecord_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_checkinOut_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_weekend_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_holidays_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_plannedAbsense_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_assignedTeam_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_changeSite_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        initials_fullDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_partialAbsense_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_badWeather_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_fullDayAbsent_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_holidays_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_playDay_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_malady_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_siteAnnual_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_siteBadWeather_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_teamAssign_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_changeSite_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        site_lbl.Text = translations.getText("dropdownSiteTitle")
        company_lbl.Text = translations.getText("dropdownCompanyTitle")
        Dim multipleSelectionToolTip As New ToolTip()
        multipleSelectionToolTip.SetToolTip(multipleSelectionBtn, translations.getText("multipleValidationLink"))
        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(tableSettingsBtn, translations.getText("settingsLink"))
        Dim SearchToolTip As New ToolTip()
        SearchToolTip.SetToolTip(loadTableBtn, translations.getText("searchParametersLink"))
        gravarnota_lbl.Text = translations.getText("saveLink")
        notes_group.Text = translations.getText("AnnotationTitle")
        GroupBox_legenda.Text = translations.getText("legend")

        translations.load("attendance")
        fullday_lbl.Text = translations.getText("fullDay")
        partialAbsense_lbl.Text = translations.getText("partialDay") & " 2h"
        badWeather_lbl.Text = translations.getText("badWeather")
        fullDayAbsent_lbl.Text = translations.getText("fullDayAbsent")
        holidays_lbl.Text = translations.getText("holidays")
        playDay_lbl.Text = translations.getText("playDay")
        malady_lbl.Text = translations.getText("malady")
        siteAnnual_lbl.Text = translations.getText("siteAnnual")
        siteBadWeather_lbl.Text = translations.getText("siteWeather")
        teamAssign_lbl.Text = translations.getText("teamAssign")
        changeSite_lbl.Text = translations.getText("changeSite")
        colorNoRecord_lbl.Text = translations.getText("noRecord")
        colorAbsentDay_lbl.Text = translations.getText("fullDayAbsent")
        color_fullDay_lbl.Text = translations.getText("fullDay")
        color_partialDay_lbl.Text = translations.getText("incompleteDay")
        color_doubleRecord_lbl.Text = translations.getText("doubleRecord")
        color_checkinOut_lbl.Text = translations.getText("checkinOutRecord")
        color_weekend_lbl.Text = translations.getText("weekend")
        color_holidays_lbl.Text = translations.getText("holidays")
        color_plannedAbsense_lbl.Text = translations.getText("plannedAbsense")
        color_assignedTeam_lbl.Text = translations.getText("teamAssign")
        color_changeSite_lbl.Text = translations.getText("changeSite")
        stats_lbl.Text = translations.getText("statistics")

        combo_site.Location = New Drawing.Point(site_lbl.Location.X + site_lbl.Width + 5, combo_site.Location.Y)
        company_lbl.Location = New Drawing.Point(combo_site.Location.X + combo_site.Width + 5, company_lbl.Location.Y)
        combo_company.Location = New Drawing.Point(company_lbl.Location.X + company_lbl.Width + 5, combo_company.Location.Y)
        Me.ResumeLayout()
    End Sub


    Private Sub logger_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        MainMdiForm.childForm = "logger"

        load_data()
        loaded = False
    End Sub
    Sub clearWorkerDetails()
        translations.load("attendance")
        GroupBox_detalhes.Text = translations.getText("details")
        detalhes_cat.Text = ""
        detalhes_checkin.Text = ""
        detalhes_checkout.Text = ""
        detalhes_contacto.Text = ""
        detalhes_empresa.Text = ""
        detalhes_nfc.Text = ""
        detalhes_nome.Text = translations.getText("selectDayDetails")
        detalhes_obra.Text = ""
        detalhes_emergencia.Text = ""
        detalhes_validacao.Text = ""
        txt_nota.Text = ""
        duplicateRecords.Text = ""
        worker_photo.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
        worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
        worker_photo.Visible = False
    End Sub
    Sub EnforceAuthorities()

    End Sub

    Private Sub CloseMe()
        Me.Close()
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

    Sub load_data()
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Forms.Application.DoEvents()
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
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim appId As New Security.FingerPrint
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "categories,entreprises,sites,sections")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_category = request.ConvertDataToArray("categories", state.queryWorkerCategoryFields, response)
        If IsNothing(works_category) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_entreprise = request.ConvertDataToArray("entreprises", state.queryEntreprisePartnersFields, response)
        If IsNothing(works_entreprise) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

        works_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(works_sections) Then
            errorMsg = request.errorMessage
            errorFlag = True
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
        ReDim sectionsIndex(works_sections.Count - 1)

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

        siteSelection = loadSitesWithSections(combo_site, works_site, works_sections)
        translations.load("commonForm")
        combo_company.Items.Clear()
        combo_company.Items.Add(translations.getText("dropdownSelectCompany"))
        For i = 0 To works_entreprise.Item("name").Count - 1
            combo_company.Items.Add(works_entreprise.Item("name")(i))
        Next
        combo_company.Items.Add(translations.getText("dropdownSelectAll"))
        combo_company.SelectedIndex = combo_company.Items.Count - 1

        clearWorkerDetails()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded
        If Not loaded Then
            Exit Sub
        End If
        If IsNothing(AttendanceTable) Then
            Exit Sub
        End If
        If UBound(AttendanceTable, 1) < e.RowIndex Or UBound(AttendanceTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If
        With datatable
            If e.ColumnIndex.Equals(0) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.Alignment = DataGridViewContentAlignment.BottomLeft

                If InQueryDictionary(works_site, AttendanceTable(e.RowIndex, 0), "name") > -1 Then ' obra
                    .Rows(e.RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                    .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorSite
                End If

                If InQueryDictionary(works_sections, serverData(e.RowIndex, 0).section, "cod_section") > -1 Then
                    If AttendanceTable(e.RowIndex, 0).Equals(" " & works_sections.Item("description")(InQueryDictionary(works_sections, serverData(e.RowIndex, 0).section, "cod_section"))) Then ' section
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorSection
                    End If
                End If
                If InQueryDictionary(works_sections, serverData(e.RowIndex, 0).company, "cod_section") > -1 Then
                    If AttendanceTable(e.RowIndex, 0).Equals("  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, serverData(e.RowIndex, 0).company, "cod_entreprise"))) Then ' company
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorCompany
                    End If
                End If
                If InQueryDictionary(works_category, serverData(e.RowIndex, 0).category, "cod_category") > -1 Then
                    If AttendanceTable(e.RowIndex, 0).Equals("   " & works_category.Item("designation")(InQueryDictionary(works_category, serverData(e.RowIndex, 0).category, "cod_category"))) Then ' category
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorWorkCategories
                    End If
                End If
            End If
            Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.SelectionStart.ToString("yyyy"), calendar_log.SelectionStart.ToString("MM"))

            'absenses
            If Not IsNothing(absense) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(idxTableWorkerPos, e.RowIndex) > -1 Then
                    If (absense(InArrayInt(idxTableWorkerPos, e.RowIndex), e.ColumnIndex).Equals(1)) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorAbsense
                    End If
                End If
            End If


            If Not IsNothing(record) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(idxTableWorkerPos, e.RowIndex) > -1 Then
                    If AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("P") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("P*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorFullDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorFullDayValidated
                    ElseIf state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedTeam) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(state.colorPlannedTeam, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorLightGray
                    ElseIf state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedChangeOfSite) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(state.colorPlannedChangeOfSite, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorLightGray
                    ElseIf AttendanceTable(e.RowIndex, e.ColumnIndex).IndexOf("H") > 0 And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPartialDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorPartialDayValidated
                    ElseIf AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("FA") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("FA*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorFermetureAnnual) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorFermetureAnnual
                    ElseIf AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("S") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("S*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorRecordDeleted) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorRecordDeleted
                    ElseIf Not AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorAbsentDay) Then
                        If Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedTeam) Then
                            '
                        ElseIf Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedChangeOfSite) Then
                            '
                        Else
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorAbsentDay
                        End If
                    End If

                    'only site records
                    If ((Not serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("null") And Not serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("00:00:00") And Not serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("")) Or (Not serverData(e.RowIndex, e.ColumnIndex).checkout.Equals("null") And Not serverData(e.RowIndex, e.ColumnIndex).checkout.Equals("00:00:00") And Not serverData(e.RowIndex, e.ColumnIndex).checkout.Equals(""))) And (serverData(e.RowIndex, e.ColumnIndex).status.Equals("") Or serverData(e.RowIndex, e.ColumnIndex).status.Equals("EP") Or serverData(e.RowIndex, e.ColumnIndex).status.Equals("MO")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorWithRecord) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorWithRecord
                    End If
                End If
            End If

            'holidays
            If Not IsNothing(holidays) AndAlso Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorHolidays) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If holidays.Contains(Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & If(e.ColumnIndex < 10, "0" & e.ColumnIndex, e.ColumnIndex))) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = state.colorHolidays
                End If
            End If

            'weekends
            If e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If Not IsWeekday(calendar_log.SelectionStart.ToString("yyyy-MM") & "-" & e.ColumnIndex.ToString()) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorWeekends) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = state.colorWeekends
                End If
            End If

            'users without record
            If e.ColumnIndex = 0 And serverData(e.RowIndex, 0).data.ToString("yyyy-MM-dd").Equals("1970-01-01") And InArrayInt(idxTableWorkerPos, e.RowIndex) > -1 Then
                .Rows(e.RowIndex).Cells(0).Style.ForeColor = state.colorWithoutRecord
            End If

            If e.RowIndex.Equals(datatable.Rows.Count - 2) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorLightGray
            End If
            If e.RowIndex.Equals(datatable.Rows.Count - 1) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorDarkGray
            End If
            If e.RowIndex.Equals(datatable.Rows.Count - 3) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorDarkGray
            End If

            If Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("EP*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedTeam) Then
                e.Value = ""
            ElseIf Not state.tableSearchOptions.viewPlanningAssignmentWorkers And (AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO") Or AttendanceTable(e.RowIndex, e.ColumnIndex).Equals("MO*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedChangeOfSite) Then
                e.Value = ""
            Else
                e.Value = AttendanceTable(e.RowIndex, e.ColumnIndex)
            End If
            currentDatatable = datatable
        End With
    End Sub



    Private Sub datatable_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles datatable.CellPainting
        'Draw custom cell borders.
        'If current column is DisplayName...
        If e.RowIndex.Equals(datatable.Rows.Count - 3) Then
            Dim Brush As New SolidBrush(datatable.ColumnHeadersDefaultCellStyle.BackColor)
            e.Graphics.FillRectangle(Brush, e.CellBounds)
            Brush.Dispose()
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentBackground)
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, datatable.GridColor, 1, ButtonBorderStyle.Solid, datatable.GridColor, 1, ButtonBorderStyle.Solid, datatable.GridColor, 1, ButtonBorderStyle.Solid, datatable.GridColor, 1, ButtonBorderStyle.Solid)
            e.Handled = True
        End If
    End Sub

    Private Sub journalLoadButton_Click(sender As Object, e As EventArgs) Handles loadTableBtn.Click
        DropClickSearchBox(loadTableBtn)
        clearWorkerDetails()
        enableButtonsAndLinks(Me, False)
        load_grid()
        enableButtonsAndLinks(Me, True)
        Refresh()
        calendar_log.Refresh()
    End Sub

    Sub load_grid()
        If (combo_company.SelectedIndex < 1 Or combo_site.SelectedIndex < 1) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        ElseIf siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-2) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.SelectionStart.ToString("yyyy"), calendar_log.SelectionStart.ToString("MM"))
        Dim qempresa, qsite, qsection As String
        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)
        Dim cell_size As Integer = (datatable.Width - 400) / num_days
        cell_size = If(cell_size < sizeOfString.Width, sizeOfString.Width, cell_size)
        Dim rowpos As Integer = 4
        Dim numRows As Integer = 0
        Dim num_workers As Integer = 0
        Dim holidaysJson As JArray = Nothing
        Dim ClosuresJson As JArray = Nothing
        Dim loadingState As Boolean = False

        idxTableWorkerPos = Nothing
        serverData = Nothing
        AttendanceTable = Nothing
        absense = Nothing
        record = Nothing

        translations.load("attendance")
        stats.site = If(combo_site.SelectedIndex > works_site.Item("cod_site").Count, translations.getText("global"), works_site.Item("name")(combo_site.SelectedIndex - 1))
        stats.data = calendar_log.SelectionStart.ToString("MMMM, yyyy")

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If combo_company.SelectedIndex.Equals(works_entreprise.Item("cod_entreprise").Count + 1) Then ' ALL
            qempresa = "all"
        Else
            qempresa = works_entreprise.Item("cod_entreprise")(combo_company.SelectedIndex - 1)
        End If
        If siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-1) Then 'ALL
            qsite = "all"
        Else
            qsite = siteSelection(combo_site.SelectedIndex - 1, 0)
        End If
        If siteSelection(combo_site.SelectedIndex - 1, 1).Equals(-1) Then
            qsection = "all"
        Else
            qsection = siteSelection(combo_site.SelectedIndex - 1, 1)
        End If


        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "7")
        vars.Add("company", qempresa)
        vars.Add("site", qsite)
        vars.Add("section", qsection)
        vars.Add("dupes", "true")
        vars.Add("startdate", calendar_log.SelectionStart.ToString("yyyy-MM") & "-01")
        vars.Add("enddate", calendar_log.SelectionStart.ToString("yyyy-MM") & "-" & num_days.ToString())
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1
            datatable.Rows.Clear()
            multipleSelectionBtn.Enabled = False
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            Exit Sub
        End If
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")
        translations.load("commonForm")
        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If Not data.ContainsKey("workers") Then
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If

                ReDim idxTableWorkerPos(1)
                idxTableWorkerPos(1) = -1
                datatable.Rows.Clear()
                multipleSelectionBtn.Enabled = False
                translations.load("attendance")
                Dim message3 As String = translations.getText("workersNotFound")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                mask.Dispose()
                Exit Sub
            Else
                Dim workers As JArray = JArray.Parse(data.Item("workers").ToString)
                For i = 0 To workers.Count - 1
                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("company").ToString.Equals(workers(i - 1).Item("company").ToString) Or loadingState Then ' company
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or loadingState Then ' category
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                    End If
                    loadingState = False
                    rowpos = rowpos + 1
                Next i
                rowpos += 2 ' totals lines

                ReDim idxTableWorkerPos(workers.Count - 1)
                ReDim serverData(rowpos, 32)
                ReDim AttendanceTable(rowpos, 32)
                stats.absenseHours = New TimeSpan(0, 0, 0)
                For i = 0 To rowpos
                    For j = 0 To 32
                        serverData(i, j).site = 0
                        serverData(i, j).section = 0
                        serverData(i, j).company = 0
                        serverData(i, j).category = 0
                        serverData(i, j).code = 0
                        serverData(i, j).name = ""
                        serverData(i, j).contact = ""
                        serverData(i, j).nfc = ""
                        serverData(i, j).eContact = ""
                        serverData(i, j).checkin = ""
                        serverData(i, j).checkout = ""
                        serverData(i, j).status = ""
                        serverData(i, j).absense = ""
                        serverData(i, j).notes = ""
                        serverData(i, j).photo = ""
                        serverData(i, j).reference = ""
                        serverData(i, j).validationReason = ""
                        serverData(i, j).duplicates = ""

                        serverData(i, j).data = Convert.ToDateTime("1970-01-01")

                        AttendanceTable(i, j) = ""
                    Next j
                Next i
                ReDim absense(workers.Count - 1, 32)
                ReDim record(workers.Count - 1, 32)
                For i = 0 To workers.Count - 1
                    For j = 0 To 31
                        absense(i, j) = 0
                        record(i, j) = 0
                    Next j
                Next i

                If data.ContainsKey("holidays") Then
                    holidaysJson = JArray.Parse(data.Item("holidays").ToString)
                    ReDim holidays(holidaysJson.Count - 1)
                    For i = 0 To holidaysJson.Count - 1
                        holidays(i) = Convert.ToDateTime(holidaysJson(i).Item("date").ToString)
                    Next i
                End If

                rowpos = 0
                serverData(rowpos, 0).site = workers(0).Item("site").ToString
                AttendanceTable(rowpos, 0) = works_site.Item("name")(InQueryDictionary(works_site, workers(0).Item("site").ToString, "cod_site"))
                rowpos = rowpos + 1
                serverData(rowpos, 0).section = workers(0).Item("section").ToString
                AttendanceTable(rowpos, 0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(0).Item("section").ToString, "cod_section"))
                rowpos = rowpos + 1
                serverData(rowpos, 0).company = workers(0).Item("company").ToString
                AttendanceTable(rowpos, 0) = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, workers(0).Item("company").ToString, "cod_entreprise"))
                rowpos = rowpos + 1
                serverData(rowpos, 0).category = workers(0).Item("cat").ToString
                AttendanceTable(rowpos, 0) = "   " & works_category.Item("designation")(InQueryDictionary(works_category, workers(0).Item("cat").ToString, "cod_category"))
                rowpos = rowpos + 1

                For i = 0 To workers.Count - 1
                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            serverData(rowpos, 0).site = workers(i).Item("site").ToString
                            AttendanceTable(rowpos, 0) = works_site.Item("name")(InQueryDictionary(works_site, workers(i).Item("site").ToString, "cod_site"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            serverData(rowpos, 0).section = workers(i).Item("section").ToString
                            AttendanceTable(rowpos, 0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(i).Item("section").ToString, "cod_section"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("company").ToString.Equals(workers(i - 1).Item("company").ToString) Or loadingState Then ' company
                            serverData(rowpos, 0).company = workers(i).Item("company").ToString
                            AttendanceTable(rowpos, 0) = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, workers(i).Item("company").ToString, "cod_entreprise"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or loadingState Then ' category
                            serverData(rowpos, 0).category = workers(i).Item("cat").ToString
                            AttendanceTable(rowpos, 0) = "   " & works_category.Item("designation")(InQueryDictionary(works_category, workers(i).Item("cat").ToString, "cod_category"))
                            rowpos = rowpos + 1
                            loadingState = True
                        End If
                    End If
                    loadingState = False
                    For j = 0 To num_days
                        serverData(rowpos, j).site = workers(i).Item("site").ToString
                        serverData(rowpos, j).section = workers(i).Item("section").ToString
                        serverData(rowpos, j).company = workers(i).Item("company").ToString
                        serverData(rowpos, j).category = workers(i).Item("cat").ToString
                        serverData(rowpos, j).code = workers(i).Item("code").ToString
                        serverData(rowpos, j).name = workers(i).Item("name").ToString
                        serverData(rowpos, j).contact = workers(i).Item("contact").ToString
                        serverData(rowpos, j).nfc = workers(i).Item("nfc").ToString
                        serverData(rowpos, j).eContact = workers(i).Item("112").ToString
                        serverData(rowpos, j).photo = workers(i).Item("photo").ToString
                        serverData(rowpos, j).reference = workers(i).Item("ref").ToString

                        serverData(rowpos, j).checkin = ""
                        serverData(rowpos, j).checkout = ""
                        serverData(rowpos, j).status = ""
                        serverData(rowpos, j).absense = ""
                        serverData(rowpos, j).notes = ""
                        serverData(rowpos, j).validationReason = ""
                        serverData(rowpos, j).data = Convert.ToDateTime("1970-01-01")

                    Next j

                    If data.ContainsKey("closure") Then
                        ClosuresJson = JArray.Parse(data.Item("closure").ToString)

                        For Each closureJson In ClosuresJson

                            Dim startP As DateTime = Convert.ToDateTime(closureJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(closureJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & num_days) Then
                                    AttendanceTable(rowpos, CurrD.Day) = "FA"
                                End If
                                CurrD = CurrD.AddDays(1)
                            End While
                        Next closureJson
                    End If

                    Dim workerData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(workers(i).ToString)

                    If workerData.ContainsKey("record") Then
                        Dim records As JArray = JArray.Parse(workers(i).Item("record").ToString)
                        serverData(rowpos, 0).data = Convert.ToDateTime("1970-01-02")
                        For Each recordJson In records
                            day = Convert.ToDateTime(recordJson.Item("date").ToString).Day

                            serverData(rowpos, day).checkin = recordJson.Item("checkin").ToString
                            serverData(rowpos, day).checkout = recordJson.Item("checkout").ToString
                            serverData(rowpos, day).status = recordJson.Item("status").ToString
                            serverData(rowpos, day).absense = recordJson.Item("absense").ToString
                            serverData(rowpos, day).notes = recordJson.Item("notas").ToString
                            serverData(rowpos, day).data = Convert.ToDateTime(recordJson.Item("date").ToString)
                            serverData(rowpos, day).validationReason = recordJson.Item("reason").ToString

                            If TimeSpan.TryParse(recordJson.Item("absense").ToString, New TimeSpan()) Then
                                stats.absenseHours += TimeSpan.Parse(recordJson.Item("absense").ToString)
                            End If
                            If (serverData(rowpos, day).status.Equals("EP") Or serverData(rowpos, day).status.Equals("MO")) And (Not serverData(rowpos, day).checkin.Equals("") And Not serverData(rowpos, day).checkin.Equals("00:00:00") Or Not serverData(rowpos, day).checkout.Equals("") And Not serverData(rowpos, day).checkout.Equals("00:00:00")) Then
                                AttendanceTable(rowpos, day) = ""
                            Else
                                AttendanceTable(rowpos, day) = If(recordJson.Item("status").ToString.Equals("PI"), If(recordJson.Item("absense").ToString.Length < 5, recordJson.Item("absense").ToString, recordJson.Item("absense").ToString.Substring(0, 5).Replace(":", "H")), recordJson.Item("status").ToString)
                            End If
                            If Not recordJson.Item("notas").ToString().Equals("") Then
                                AttendanceTable(rowpos, day) = AttendanceTable(rowpos, day) & "*"
                            End If
                        Next recordJson
                    End If

                    If workerData.ContainsKey("duplicates") Then
                        Dim duplicates As JArray = JArray.Parse(workers(i).Item("duplicates").ToString)
                        For Each recordJson In duplicates
                            day = Convert.ToDateTime(recordJson.Item("date").ToString).Day
                            serverData(rowpos, day).duplicates = recordJson.Item("sites").ToString
                        Next recordJson
                    End If

                    If workerData.ContainsKey("absense") Then
                        Dim absensesJson As JArray = JArray.Parse(workers(i).Item("absense").ToString)
                        For Each absenseJson In absensesJson

                            Dim startP As DateTime = Convert.ToDateTime(absenseJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(absenseJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & num_days) Then
                                    absense(i, CurrD.Day) = 1
                                End If
                                CurrD = CurrD.AddDays(1)
                            End While

                        Next absenseJson
                    End If

                    idxTableWorkerPos(i) = rowpos
                    AttendanceTable(rowpos, 0) = workers(i).Item("name").ToString
                    rowpos = rowpos + 1
                Next i
                translations.load("attendance")
                AttendanceTable(rowpos, 0) = translations.getText("tableRowTotalValidated")
                rowpos = rowpos + 1
                AttendanceTable(rowpos, 0) = translations.getText("tableRowTotalNonValidated")
                rowpos = rowpos + 1
                translations.load("commonForm")
                AttendanceTable(rowpos, 0) = translations.getText("tableRowTotal")
            End If

        Catch ex As Exception
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            mask.Dispose()
            Exit Sub
        End Try

        SuspendLayout()
        loaded = False
        With datatable
            .Visible = False

            Dim ts = serverData
            .VirtualMode = True

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

            .Rows.Clear()
            .RowCount = rowpos + 1

            Dim counter As Integer = 0
            Dim counter_t(2) As Integer

            counter_t(1) = 0
            stats.totalDaysWorked = 0

            For i = 0 To UBound(AttendanceTable, 1)
                counter = 0
                For j = 1 To num_days

                    If AttendanceTable(i, j).Equals("P") Or AttendanceTable(i, j).Equals("P*") Or AttendanceTable(i, j).IndexOf("H") > 0 Then
                        counter = counter + 1
                    End If

                    If ((AttendanceTable(i, j).Equals("EP") Or AttendanceTable(i, j).Equals("EP*") Or AttendanceTable(i, j).Equals("") Or AttendanceTable(i, j).Equals("P") Or AttendanceTable(i, j).Equals("P*")) _
                        And Not serverData(i, j).checkin.Equals("00:00:00") And Not serverData(i, j).checkin.Equals("")) _
                        And j.Equals(Convert.ToInt32(DateTime.Today.ToString("dd"))) And Not serverData(i, j).checkin.Equals("null") And Not serverData(i, j).checkout.Equals("null") Then
                        num_workers = num_workers + 1 ' num registered workers today
                    End If

                Next j
                stats.totalDaysWorked = Math.Max(stats.totalDaysWorked, counter)
                AttendanceTable(i, num_days + 1) = If(counter.Equals(0), "", counter.ToString())
                counter_t(1) = counter_t(1) + counter
            Next i

            counter_t(2) = 0
            Dim counterNonValidated As Integer = 0
            Dim counterNonValidatedTotals As Integer = 0

            For i = 1 To num_days
                counter = 0
                counterNonValidated = 0
                For j = 0 To UBound(AttendanceTable, 1)
                    If AttendanceTable(j, i).Equals("P") Or AttendanceTable(j, i).Equals("P*") Or AttendanceTable(j, i).IndexOf("H") > 0 Then
                        counter = counter + 1
                    End If
                    If (AttendanceTable(j, i).Equals("EP") Or AttendanceTable(j, i).Equals("EP*") Or AttendanceTable(j, i).Equals("")) And Not serverData(j, i).checkin.Equals("00:00:00") And Not serverData(j, i).checkin.Equals("") And Not serverData(j, i).checkin.Equals("null") Then
                        counterNonValidated = counterNonValidated + 1 ' num registered workers not validated
                    End If
                Next j
                'rows count-1 = totals
                'rows count-2 = totals non validated
                'rows count-3 = totals validated
                counterNonValidatedTotals += counterNonValidated
                AttendanceTable(.Rows.Count - 3, i) = If(counter.Equals(0), "", counter.ToString())
                AttendanceTable(.Rows.Count - 2, i) = If(counterNonValidated.Equals(0), "", counterNonValidated.ToString())
                AttendanceTable(.Rows.Count - 1, i) = If((counter + counterNonValidated).Equals(0), "", (counter + counterNonValidated).ToString())
                counter_t(2) = counter_t(2) + counter
            Next i
            AttendanceTable(.Rows.Count - 3, num_days + 1) = counter_t(1).ToString() & "(" & counter_t(2).ToString() & ")"
            AttendanceTable(.Rows.Count - 2, num_days + 1) = counterNonValidatedTotals.ToString()
            AttendanceTable(.Rows.Count - 1, num_days + 1) = (counterNonValidatedTotals + counter_t(1)).ToString()
            stats.totalDaysInMonth = counter_t(1)

            stats.maxWorkers = 0
            stats.minWorkers = 1000
            stats.totalWorkDays = 0
            For i = 1 To num_days
                stats.maxWorkers = Math.Max(stats.maxWorkers, If(AttendanceTable(UBound(AttendanceTable, 1), i).Equals(""), 0, Convert.ToInt32(AttendanceTable(UBound(AttendanceTable, 1), i))))
                If Not AttendanceTable(.Rows.Count - 3, i).Equals("0") And Not AttendanceTable(.Rows.Count - 3, i).Equals("") Then
                    stats.minWorkers = Math.Min(stats.minWorkers, Convert.ToInt32(AttendanceTable(.Rows.Count - 3, i)))
                End If
                If IsWeekday(calendar_log.SelectionStart.ToString("yyyy-MM") & "-" & i) Then
                    If Not IsNothing(holidays) Then
                        If Not holidays.Contains(Convert.ToDateTime(calendar_log.SelectionStart.ToString("yyyy-MM-") & If(i < 10, "0" & i, i))) Then
                            stats.totalWorkDays += 1
                        End If
                    Else
                        stats.totalWorkDays += 1
                    End If
                End If
            Next i
            stats.minWorkers = If(stats.minWorkers.Equals(1000), 0, stats.minWorkers)

            Dim today As Integer = calendar_log.TodayDate.ToString("dd")

            .ColumnCount = num_days + 2
            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
            .Columns(0).Width = 300
            For i = 1 To num_days
                .Columns(i).HeaderCell.Value = i.ToString()
                .Columns(i).Width = cell_size
                If i.Equals(today) And calendar_log.TodayDate.ToString("MM").Equals(calendar_log.SelectionStart.ToString("MM")) Then
                    .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                Else
                    .Columns(i).DefaultCellStyle.BackColor = Color.White
                End If
                If i > today And calendar_log.TodayDate.ToString("MM").Equals(calendar_log.SelectionStart.ToString("MM")) Then
                    .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
            Next i
            .Columns(num_days + 1).HeaderCell.Value = translations.getText("tableRowTotal")

            .Rows(.Rows.Count - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 2).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 3).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
            .Rows(.Rows.Count - 2).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
            .Rows(.Rows.Count - 3).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)

            .Visible = True
        End With
        ResumeLayout()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

        translations.load("successMessages")
        'Close form and terminate busy thread
        MainMdiForm.statusMessage = translations.getText("tableLoaded") & "."
        multipleSelectionBtn.Enabled = False
        stats_lbl.Enabled = True
        loaded = True
        mask.Dispose()
        EnforceAuthorities()

    End Sub




    Private Sub gravarnota_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles gravarnota_lbl.LinkClicked

        Dim type As String = ""

        cellY = datatable.CurrentCell.RowIndex
        cellX = datatable.CurrentCell.ColumnIndex
        enableButtonsAndLinks(Me, False)

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "8")
        vars.Add("worker", serverData(cellY, cellX).code)
        vars.Add("site", serverData(cellY, cellX).site)
        vars.Add("section", serverData(cellY, cellX).section)
        vars.Add("date", calendar_log.SelectionStart.ToString("yyyy-MM") & "-" & cellX)
        vars.Add("note", txt_nota.Text)
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        If txt_nota.Text <> "" Then
            If datatable.Rows(cellY).Cells(cellX).Value IsNot Nothing Then
                If datatable.Rows(cellY).Cells(cellX).Value.IndexOf("*") = -1 Then
                    datatable.Rows(cellY).Cells(cellX).Value = datatable.Rows(cellY).Cells(cellX).Value & "*"
                End If
            Else
                datatable.Rows(cellY).Cells(cellX).Value = "*"

            End If
            serverData(cellY, cellX).notes = txt_nota.Text

            translations.load("attendance")
            Dim message3 As String = translations.getText("successSaveNote")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            If datatable.Rows(cellY).Cells(cellX).Value IsNot Nothing Then
                Dim str As String = datatable.Rows(cellY).Cells(cellX).Value
                datatable.Rows(cellY).Cells(cellX).Value = Mid(str, 1, str.Length - 1)

                translations.load("attendance")
                Dim message3 As String = translations.getText("successDelNote")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
        enableButtonsAndLinks(Me, True)

    End Sub

    Private Sub datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.SelectionStart.ToString("yyyy"), calendar_log.SelectionStart.ToString("MM"))

        If Not InArrayInt(idxTableWorkerPos, e.RowIndex).Equals(-1) AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days Then
            cellX = e.ColumnIndex
            cellY = e.RowIndex
            If cellX = -1 Or cellY = -1 Then
                Exit Sub
            End If
            txt_nota.Enabled = True
            gravarnota_lbl.Enabled = True
            txt_nota.Text = serverData(cellY, cellX).notes
            translations.load("attendance")

            GroupBox_detalhes.Text = translations.getText("details") & " " & calendar_log.SelectionStart.ToString("yyyy/MM") & "-" & cellX
            detalhes_nome.Text = serverData(cellY, cellX).name
            detalhes_nfc.Text = translations.getText("workerCompanyCardCode") & ": " & AddSpaces(serverData(cellY, cellX).nfc, 3)
            detalhes_contacto.Text = translations.getText("contact") & ": " & serverData(cellY, cellX).contact
            detalhes_emergencia.Text = translations.getText("contactEmergency") & ": " & serverData(cellY, cellX).eContact
            detalhes_obra.Text = translations.getText("constructionSite") & ": " & works_site.Item("name")(InQueryDictionary(works_site, serverData(cellY, cellX).site, "cod_site"))
            detalhes_empresa.Text = translations.getText("partnerCompany") & ": " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, serverData(cellY, cellX).company, "cod_entreprise"))
            detalhes_cat.Text = translations.getText("professinalCategory") & ": " & works_category.Item("designation")(InQueryDictionary(works_category, serverData(cellY, cellX).category, "cod_category"))
            duplicateRecords.Text = translations.getText("duplicateRecordsOnSites") & ": " & If(serverData(cellY, cellX).duplicates.Equals(""), "- - ", serverData(cellY, cellX).duplicates)
            detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("notValidated")
            detalhes_checkout.Text = translations.getText("checkout") & ": - -"
            detalhes_checkin.Text = translations.getText("checkin") & ": - -"
            detalhes_emergencia.Text = translations.getText("contactEmergency") & ": - -"

            If serverData(cellY, cellX).checkin.Equals("00:00:00") Or serverData(cellY, cellX).checkin.Equals("") Or serverData(cellY, cellX).checkin.Equals("null") Then
                detalhes_checkin.Text = translations.getText("checkin") & ": - -"
            Else
                detalhes_checkin.Text = translations.getText("checkin") & ": " & If(serverData(cellY, cellX).checkin.Length < 5, serverData(cellY, cellX).checkin, serverData(cellY, cellX).checkin.Substring(0, 5).Replace(":", "H"))
            End If

            If serverData(cellY, cellX).checkout.Equals("00:00:00") Or serverData(cellY, cellX).checkout.Equals("") Or serverData(cellY, cellX).checkout.Equals("null") Then
                detalhes_checkout.Text = translations.getText("checkout") & ": - -"
            Else
                detalhes_checkout.Text = translations.getText("checkout") & ": " & If(serverData(cellY, cellX).checkout.Length < 5, serverData(cellY, cellX).checkout, serverData(cellY, cellX).checkout.Substring(0, 5).Replace(":", "H"))
            End If

            If serverData(cellY, cellX).status.Equals("P") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("fullDay")
            ElseIf serverData(cellY, cellX).status.Equals("PI") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("partialDay") & " " & If(serverData(cellY, cellX).absense.Length < 5, serverData(cellY, cellX).absense, serverData(cellY, cellX).absense.Substring(0, 5).Replace(":", "H"))
            ElseIf serverData(cellY, cellX).status.Equals("I") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("badWeather")
            ElseIf serverData(cellY, cellX).status.Equals("A") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("fullDayAbsent")
            ElseIf serverData(cellY, cellX).status.Equals("V") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("holidays")
            ElseIf serverData(cellY, cellX).status.Equals("C") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("playday")
            ElseIf serverData(cellY, cellX).status.Equals("M") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("malady")
            ElseIf serverData(cellY, cellX).status.Equals("FA") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("siteAnnual")
            ElseIf serverData(cellY, cellX).status.Equals("FI") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("siteWeather")
            ElseIf serverData(cellY, cellX).status.Equals("") Or serverData(cellY, cellX).status.Equals("EP") Or serverData(cellY, cellX).status.Equals("MO") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("notValidated")
            End If

            If (logger_frm.serverData(cellY, cellX).photo.Equals("")) Then
                worker_photo.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
            Else
                worker_photo.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
                worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
                Dim tClient As WebClient = New WebClient
                Try
                    Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & logger_frm.serverData(cellY, cellX).photo)))
                    worker_photo.Image = tImage
                Catch ex As Exception
                    worker_photo.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
                    translations.load("attendance")
                    MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
            End If
            worker_photo.Visible = True
            Panel1.Refresh()
            notes_group.Refresh()

        Else
            clearWorkerDetails()
            txt_nota.Enabled = False
            gravarnota_lbl.Enabled = False

        End If
        EnforceAuthorities()
    End Sub
    Private Sub MonthCalendar1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles calendar_log.MouseDown
        If calendar_log.HitTest(e.X, e.Y).HitArea.Equals(MonthCalendar.HitArea.NextMonthButton) Or calendar_log.HitTest(e.X, e.Y).HitArea.Equals(MonthCalendar.HitArea.PrevMonthButton) Then
            datatable.Rows.Clear()
            multipleSelectionBtn.Enabled = False
            stats_lbl.Enabled = False
        End If
    End Sub

    Private Sub GroupBox_legenda_Enter(sender As Object, e As EventArgs) Handles GroupBox_legenda.Enter
    End Sub

    Private Sub datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick

    End Sub

    Private Sub multipleSelectionBtn_Click(sender As Object, e As EventArgs) Handles multipleSelectionBtn.Click

        If combo_company.SelectedIndex > 0 And combo_site.SelectedIndex > 0 And combo_site.Items.Count - 1 > combo_site.SelectedIndex And calendar_log.SelectionStart.Date <= calendar_log.TodayDate.Date Then
            calendar = calendar_log
            currentDatatable = datatable
            If multiday_frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                load_grid()
            End If
        Else
            If calendar_log.SelectionStart.Date > calendar_log.TodayDate.Date Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectDayTomorrow")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf combo_company.SelectedIndex = 0 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectEntreprise")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf combo_site.SelectedIndex = 0 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            Else
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectOneSiteOnly")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub tableSettingsBtn_Click(sender As Object, e As EventArgs) Handles tableSettingsBtn.Click
        tableSearchOptions_frm.from = "logger"
        tableSearchOptions_frm.ShowDialog()
        state = MainMdiForm.state
    End Sub

    Private Sub combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_site.SelectedIndexChanged

    End Sub

    Private Sub detalhes_contacto_Click(sender As Object, e As EventArgs) Handles detalhes_contacto.Click

    End Sub

    Private Sub detalhes_cat_Click(sender As Object, e As EventArgs) Handles detalhes_cat.Click

    End Sub

    Private Sub company_lbl_Click(sender As Object, e As EventArgs) Handles company_lbl.Click

    End Sub

    Private Sub calendar_log_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendar_log.DateChanged

    End Sub

    Private Sub detalhes_empresa_Click(sender As Object, e As EventArgs) Handles detalhes_empresa.Click

    End Sub

    Private Sub detalhes_nfc_Click(sender As Object, e As EventArgs) Handles detalhes_nfc.Click

    End Sub

    Private Sub detalhes_emergencia_Click(sender As Object, e As EventArgs) Handles detalhes_emergencia.Click

    End Sub

    Private Sub stats_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles stats_lbl.LinkClicked
        logger_stats_frm.ShowDialog()
    End Sub



    Private Sub datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseDoubleClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.SelectionStart.ToString("yyyy"), calendar_log.SelectionStart.ToString("MM"))
        Dim today As Integer = calendar_log.TodayDate.ToString("dd")

        If InArrayInt(idxTableWorkerPos, e.RowIndex) <> -1 AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days Then
            Dim datePos As New MonthCalendar
            datePos.SelectionStart = calendar_log.SelectionStart.ToString("yyyy-MM") & "-" & If(e.ColumnIndex < 10, "0" & e.ColumnIndex.ToString, e.ColumnIndex)
            If datePos.SelectionStart <= calendar_log.TodayDate Then
                cellX = e.ColumnIndex
                cellY = e.RowIndex
                calendar = calendar_log
                If logday_frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    load_grid()
                End If
            End If
        End If
    End Sub


    Private Sub datatable_MouseHover(ByVal sender As System.Object, ByVal e As EventArgs) Handles datatable.MouseHover

        Dim grvScreenLocation As Drawing.Point = datatable.PointToScreen(datatable.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + datatable.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + datatable.Top
        Dim hit As DataGridView.HitTestInfo = datatable.HitTest(tempX, tempY)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(AttendanceTable) Then
            If UBound(AttendanceTable, 1) < hit.RowIndex Or UBound(AttendanceTable, 2) < hit.ColumnIndex Then
                Exit Sub
            End If
            datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = AttendanceTable(hit.RowIndex, 0)
        End If
    End Sub

    Private Sub datatable_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles datatable.CellFormatting
        Dim grvScreenLocation As Drawing.Point = datatable.PointToScreen(datatable.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + datatable.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + datatable.Top
        Dim hit As DataGridView.HitTestInfo = datatable.HitTest(tempX, tempY)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(AttendanceTable) Then
            If UBound(AttendanceTable, 1) < hit.RowIndex Or UBound(AttendanceTable, 2) < hit.ColumnIndex Then
                Exit Sub
            End If
            datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = AttendanceTable(hit.RowIndex, 0)
        End If
    End Sub

    Private Sub logger_frm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Me.Focused = False Then
            MainMdiForm.childForm = "logger"
        End If
    End Sub
End Class