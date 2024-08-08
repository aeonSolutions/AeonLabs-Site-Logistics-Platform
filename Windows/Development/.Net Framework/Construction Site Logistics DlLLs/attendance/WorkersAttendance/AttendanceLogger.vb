Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports ConstructionSiteLogistics.Gui.Forms.Shared

Public Class attendanceLoggerForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm

    Private works_worker, works_entreprise, works_category, works_register, works_ausencias, works_sections As Dictionary(Of String, List(Of String))

    Private sectionsIndex As Integer()
    Private DBrecord As String(,,,)

    Private siteSelection As Integer(,)

    Private ToggleSidePanelToolTip As New ToolTip()
    Private ToggleBottomPanelToolTip As New ToolTip()
    Private ToggleDuplicatesToolTip As New ToolTip()
    Private SitesListSelection As New List(Of Integer)
    Private WithEvents attendance As Object

    Public Property works_site As Dictionary(Of String, List(Of String))
    Public Property cellX As Integer = 0
    Public Property cellY As Integer = 0
    Public Property calendar As DateTimePicker

    Private t As System.Threading.Thread = Nothing
    Private loaded As Boolean = False
    Private currentSiteName As String

    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwLoadData As BackgroundWorker

    Private WithEvents attendanceDataRequests As IDataAttendanceRequests
    Private mask As PictureBox = Nothing
    Private mainForm As MainMdiForm

    Public Property attendanceTableBuilder As attendanceTableBuilderClass

    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub
    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
    Public Sub New(_mainMdiForm As MainMdiForm)
        mainForm = _mainMdiForm

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        GetType(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, Panel1, New Object() {True})
        SetDoubleBuffered(datatable)
        Me.Refresh()
    End Sub
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property
    Private Sub TablePanel_Paint(sender As Object, e As PaintEventArgs) Handles TablePanel.Paint

    End Sub

    Private Sub logger_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        loadForm.Enabled = True
    End Sub

    Private Sub form_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Me.SuspendLayout()
        site_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        date_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        company_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        ListBoxSite.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_company.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        txt_nota.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        gravarnota_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        GroupBoxNotes.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        GroupBox_detalhes.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        GroupBox_legenda.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar_log.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        fullday_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        partialAbsense_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        badWeather_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        fullDayAbsent_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        holidays_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        playDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        malady_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteAnnual_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteBadWeather_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        teamAssign_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        changeSite_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        colorNoRecord_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        colorAbsentDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_fullDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_partialDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_doubleRecord_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_checkinOut_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_weekend_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_holidays_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_plannedAbsense_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_assignedTeam_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        color_changeSite_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        initials_fullDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_partialAbsense_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_badWeather_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_fullDayAbsent_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_holidays_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_playDay_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_malady_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_siteAnnual_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_siteBadWeather_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_teamAssign_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        initials_changeSite_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        site_lbl.Text = translations.getText("dropdownSiteTitle")
        company_lbl.Text = translations.getText("dropdownCompanyTitle")

        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(tableSettingsBtn, translations.getText("settingsLink"))
        Dim SearchToolTip As New ToolTip()
        SearchToolTip.SetToolTip(loadTableBtn, translations.getText("searchParametersLink"))
        ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))
        ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("hidePanel"))
        Dim lockSiteToolTip As New ToolTip()
        lockSiteToolTip.SetToolTip(closeMonthAttendanceBtn, translations.getText("lockSiteLink"))
        Dim LoadSiteToolTip As New ToolTip()
        LoadSiteToolTip.SetToolTip(loadSitesBtn, translations.getText("reloadSitesLink"))

        gravarnota_lbl.Text = translations.getText("saveLink")
        GroupBoxNotes.Text = translations.getText("AnnotationTitle")
        GroupBox_legenda.Text = translations.getText("legend")
        date_lbl.Text = translations.getText("dateTitle")

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
        Dim MetricsToolTip As New ToolTip()
        MetricsToolTip.SetToolTip(metricsBtn, translations.getText("statistics"))

        txt_nota.Width = GroupBoxNotes.Width - 5 - txt_nota.Location.X
        txt_nota.Height = GroupBoxNotes.Height - txt_nota.Location.Y - 10 - gravarnota_lbl.Height - 3
        gravarnota_lbl.Location = New Drawing.Point(txt_nota.Location.X, txt_nota.Location.Y + txt_nota.Height + 3)

        GroupBoxNotes.Width = bottomPanel.Width * 0.45
        GroupBox_detalhes.Width = bottomPanel.Width * 0.52
        GroupBox_detalhes.Location = New Drawing.Point(bottomPanel.Width - GroupBox_detalhes.Width - 10, GroupBox_detalhes.Location.Y)
        reasonLateValidation.Width = GroupBox_detalhes.Width - reasonLateValidation.Location.X - 30
        calendar_log.Value = DateTime.Now

        boxDayIncomplete.BackColor = stateCore.colorPartialDayValidated
        boxDayValidated.BackColor = stateCore.colorFullDayValidated
        boxAbsentDay.BackColor = stateCore.colorAbsentDay
        boxChangeSite.BackColor = stateCore.colorPlannedChangeOfSite
        boxDuplicate.BackColor = stateCore.colorDuplicate
        boxNoRecord.BackColor = stateCore.colorWithoutRecord
        boxPlannedAbsence.BackColor = stateCore.colorAbsense
        boxPlannedTeam.BackColor = stateCore.colorPlannedTeam
        boxPlayday.BackColor = stateCore.colorHolidays
        boxWeekend.BackColor = stateCore.colorWeekends

        Me.ResumeLayout()
    End Sub

    Private Sub loadForm_Tick(sender As Object, e As EventArgs) Handles loadForm.Tick
        loadForm.Enabled = False
    End Sub
    Private Sub panel1_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles Panel1.Scroll
        Panel1.Refresh()
    End Sub
    Private Sub logger_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        mainForm.childForm = "logger"
        Try
            attendanceDataRequests = DirectCast(loadDllObject(stateCore, "attendance.dll", "attendanceDataRequests"), IDataAttendanceRequests)
        Catch ex As Exception
            attendanceDataRequests = Nothing
        End Try

        If attendanceDataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

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
        category_today.Text = ""
        reasonLateValidation.Text = ""
        duplicateRecords.Text = ""
        worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
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
        mask = Nothing
    End Sub

    Private Sub load_data()
        mainForm.busy.Show()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "categories,entreprises,sites,sections")
        vars.Add("override", "true")
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

        attendanceDataRequests.Initialise(stateCore)
        attendanceDataRequests.loadQueue(vars, Nothing, Nothing)

        attendanceDataRequests.loadLoggerInitialData()
    End Sub

    Private Sub attendanceDataRequests_getResponseLoggerInitialData(sender As Object, args As DataRequestsDataResult) Handles attendanceDataRequests.getResponseLoggerInitialData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim response As String = args.responseData

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        works_category = request.ConvertDataToArray("categories", stateCore.queryWorkerCategoryFields, response)
        If IsNothing(works_category) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_entreprise = request.ConvertDataToArray("entreprises", stateCore.queryEntreprisePartnersFields, response)
        If IsNothing(works_entreprise) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

        works_site = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_sections = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(works_sections) Then
            errorMsg = request.errorMessage
            errorFlag = True
        End If
        ReDim sectionsIndex(works_sections.Count - 1)
lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If

        siteSelection = loadSitesWithSectionsChecked(ListBoxSite, works_site, works_sections)

        translations.load("commonForm")
        combo_company.Items.Clear()
        combo_company.Items.Add(translations.getText("dropdownSelectCompany"))
        For i = 0 To works_entreprise.Item("name").Count - 1
            combo_company.Items.Add(works_entreprise.Item("name")(i))
        Next
        combo_company.Items.Add(translations.getText("dropdownSelectAll"))
        combo_company.SelectedIndex = combo_company.Items.Count - 1

        clearWorkerDetails()
        removeMask()
        If mask IsNot Nothing Then
            mask.Dispose()
            mask = Nothing
        End If
        mainForm.busy.Close(True)

        enableButtonsAndLinks(Me, True)
        closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
        closeMonthAttendanceBtn.Enabled = False
    End Sub
    Private Sub ListBoxSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxSite.SelectedIndexChanged
        ' TrackSelectionChange(ListBoxSite)
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBoxSite.MouseClick
        Dim idx As Integer = ListBoxSite.IndexFromPoint(e.Location)

        If Not IsNothing(siteSelection) And loaded Then
            If siteSelection(idx, 1).Equals(-1) Then ' all sections
                Dim pos As Integer = idx + 1
                While ListBoxSite.Items.Item(pos).ToString.IndexOf("______").Equals(-1)
                    ListBoxSite.SetSelected(pos, False)
                    pos += 1
                End While
            ElseIf siteSelection(idx, 1).Equals(-2) Then
                ListBoxSite.SetSelected(idx, False)
            Else
                Dim pos As Integer = idx - 1
                While siteSelection(idx, 1).Equals(-1) And pos >= 0
                    pos -= 1
                End While
                pos = If(pos < 0, 0, pos)
                ListBoxSite.SetSelected(pos, False)

            End If
        End If
    End Sub


    Private Sub TrackSelectionChange(ByVal lb As ListBox)
        Dim sic As CheckedListBox.SelectedIndexCollection = lb.SelectedIndices

        For Each index As Integer In sic
            If Not SitesListSelection.Contains(index) Then SitesListSelection.Add(index)
        Next

        For Each index As Integer In New List(Of Integer)(SitesListSelection)
            If Not sic.Contains(index) Then SitesListSelection.Remove(index)
        Next
    End Sub
    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded
        If Not loaded Then
            Exit Sub
        End If
        If IsNothing(attendanceTableBuilder.tableData) Then
            Exit Sub
        End If
        If attendanceTableBuilder.tableData.Rows.Count - 1 < e.RowIndex Or attendanceTableBuilder.tableData.Columns.Count - 1 < e.ColumnIndex Then
            Exit Sub
        End If
        With datatable
            If e.ColumnIndex.Equals(0) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.Alignment = DataGridViewContentAlignment.BottomLeft

                If InQueryDictionary(works_site, attendanceTableBuilder.tableData.Rows(e.RowIndex)(0), "name") > -1 Then ' obra
                    .Rows(e.RowIndex).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
                    .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorSite
                End If

                If InQueryDictionary(works_sections, attendanceTableBuilder.serverData(e.RowIndex, 0).section, "cod_section") > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(0).Equals(" " & works_sections.Item("description")(InQueryDictionary(works_sections, attendanceTableBuilder.serverData(e.RowIndex, 0).section, "cod_section"))) Then ' section
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorSection
                    End If
                End If
                If InQueryDictionary(works_sections, attendanceTableBuilder.serverData(e.RowIndex, 0).company, "cod_section") > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(0).Equals("  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, attendanceTableBuilder.serverData(e.RowIndex, 0).company, "cod_entreprise"))) Then ' company
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorCompany
                    End If
                End If
                If InQueryDictionary(works_category, attendanceTableBuilder.serverData(e.RowIndex, 0).category, "cod_category") > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(0).Equals("   " & works_category.Item("designation")(InQueryDictionary(works_category, attendanceTableBuilder.serverData(e.RowIndex, 0).category, "cod_category"))) Then ' category
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorWorkCategories
                    End If
                End If
            End If
            Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

            'absenses
            If Not IsNothing(attendanceTableBuilder.absense) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) > -1 Then
                    If (attendanceTableBuilder.absense(InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex), e.ColumnIndex).Equals(1)) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorAbsense
                    End If
                End If
            End If

            If Not IsNothing(attendanceTableBuilder.record) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("P") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("P*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorFullDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorFullDayValidated
                    ElseIf stateCore.tableSearchOptions.viewPlanningAssignmentWorkers And (attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedTeam) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(stateCore.colorPlannedTeam, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorLightGray
                    ElseIf stateCore.tableSearchOptions.viewPlanningAssignmentWorkers And (attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("MO") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("MO*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedChangeOfSite) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(stateCore.colorPlannedChangeOfSite, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorLightGray
                    ElseIf attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).IndexOf("H") > 0 And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPartialDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorPartialDayValidated
                    ElseIf attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("FA") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("FA*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorFermetureAnnual) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorFermetureAnnual
                    ElseIf attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("S") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("S*") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorRecordDeleted) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorRecordDeleted
                    ElseIf Not attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorAbsentDay) Then
                        If Not stateCore.tableSearchOptions.viewPlanningAssignmentWorkers And (attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedTeam) Then
                            '
                        ElseIf Not stateCore.tableSearchOptions.viewPlanningAssignmentWorkers And (attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("MO") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("MO*")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedChangeOfSite) Then
                            '
                        Else
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorAbsentDay
                        End If
                    End If

                    'only site records
                    If ((Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("null") And Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("00:00:00") And Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkin.Equals("")) Or (Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkout.Equals("null") And Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkout.Equals("00:00:00") And Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).checkout.Equals(""))) And (attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).status.Equals("") Or attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).status.Equals("EP") Or attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).status.Equals("MO")) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorWithRecord) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorWithRecord
                    End If
                End If
            End If

            'holidays
            If Not IsNothing(attendanceTableBuilder.holidays) AndAlso Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorHolidays) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If attendanceTableBuilder.holidays.Contains(Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & If(e.ColumnIndex < 10, "0" & e.ColumnIndex, e.ColumnIndex))) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = stateCore.colorHolidays
                End If
            End If

            'weekends
            If e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If Not IsWeekday(calendar_log.Value.Date.ToString("yyyy-MM") & "-" & e.ColumnIndex.ToString()) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorWeekends) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = stateCore.colorWeekends
                End If
            End If

            'users without record
            If e.ColumnIndex = 0 And attendanceTableBuilder.serverData(e.RowIndex, 0).data.ToString("yyyy-MM-dd").Equals("1970-01-01") And InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) > -1 Then
                .Rows(e.RowIndex).Cells(0).Style.ForeColor = stateCore.colorWithoutRecord
            End If

            If e.RowIndex.Equals(datatable.Rows.Count - 2) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorLightGray
            End If
            If e.RowIndex.Equals(datatable.Rows.Count - 1) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorDarkGray
            End If
            If e.RowIndex.Equals(datatable.Rows.Count - 3) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorDarkGray
            End If

            If Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).otherSites.Equals("") And stateCore.tableSearchOptions.viewOtherConstructionSitesAttendance And (attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("") Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).IndexOf("EP") > -1 Or attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).IndexOf("MO") > -1) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorAbsentDay
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Black

            End If

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
        If (combo_company.SelectedIndex < 1 Or ListBoxSite.SelectedItems.Count < 1) Then
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
            metricsBtn.Enabled = False
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        ElseIf siteSelection(ListBoxSite.SelectedIndex, 0).Equals(-2) Then
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            metricsBtn.Enabled = False
            Exit Sub
        End If

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TablePanel.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        duplicatesBtn.Image = Nothing

        mainForm.busy.Show()


        translations.load("attendance")

        mainForm.busy.Show()
        Dim qempresa As String
        Dim sites As String = ""
        Dim tmp As String = ""
        currentSiteName = ""
        Dim moreThanOneSite As Boolean = False
        For Each Index In ListBoxSite.SelectedIndices
            If siteSelection(Index, 0).Equals(-1) And siteSelection(Index, 1).Equals(-1) Then 'ALL sites all sections
                For i = 0 To ListBoxSite.Items.Count - 1
                    If tmp.IndexOf(siteSelection(i, 0)).Equals(-1) And siteSelection(i, 0) <> -2 And siteSelection(i, 1) <> -1 Then
                        sites = If(sites.Equals(""), siteSelection(i, 0) & "-" & siteSelection(i, 1), sites & "," & siteSelection(i, 0) & "-" & siteSelection(i, 1))
                        tmp = tmp & "," & siteSelection(Index, 0)
                    End If
                Next i
                Exit For
            ElseIf siteSelection(Index, 1).Equals(-1) Then 'all sections of the site
                currentSiteName = works_site.Item("name")(InQueryDictionary(works_site, siteSelection(Index, 0), "cod_site"))
                sites = If(sites.Equals(""), siteSelection(Index, 0) & "-all", sites & "," & siteSelection(Index, 0) & "-all")
                tmp = tmp & "," & siteSelection(Index, 0)
            ElseIf tmp.IndexOf(siteSelection(Index, 0)).Equals(-1) And siteSelection(Index, 0) <> -2 Then
                sites = If(sites.Equals(""), siteSelection(Index, 0) & "-" & siteSelection(Index, 1), sites & "," & siteSelection(Index, 0) & "-" & siteSelection(Index, 1))
                tmp = tmp & "," & siteSelection(Index, 0)
                currentSiteName = works_site.Item("name")(InQueryDictionary(works_site, siteSelection(Index, 0), "cod_site"))
                If moreThanOneSite Then
                    currentSiteName = ""
                End If
                moreThanOneSite = True
            End If
        Next


        If combo_company.SelectedIndex.Equals(works_entreprise.Item("cod_entreprise").Count + 1) Then ' ALL
            qempresa = "all"
        Else
            qempresa = works_entreprise.Item("cod_entreprise")(combo_company.SelectedIndex - 1)
        End If

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        Dim vars As New Dictionary(Of String, String)
        vars.Add("company", qempresa)
        vars.Add("site", sites)
        vars.Add("section", "custom")
        vars.Add("dupes", "true")
        vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
        vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & num_days.ToString())

        attendanceDataRequests.Initialise(stateCore)
        attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
        attendanceDataRequests.loadLoggerData()
    End Sub
    Private Sub attendanceDataRequests_getResponseLoggerData(sender As Object, args As DataRequestsDataResult) Handles attendanceDataRequests.getResponseLoggerData
        bwLoadData = New BackgroundWorker()
        bwLoadData.WorkerSupportsCancellation = True
        Dim s(1) As String
        s(0) = args.responseData
        s(1) = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        bwLoadData.RunWorkerAsync(s)
    End Sub

    Private Sub bwLoadData_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwLoadData.DoWork
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim response As String = e.Argument(0)

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        translations.load("busyMessages")
        mainForm.statusMessage = translations.getText("loadingTable")

        attendanceTableBuilder = New attendanceTableBuilderClass(stateCore, response, calendar_log.Value.Date, works_entreprise, works_category, works_sections, works_site)
        stateCore.datatableContents = attendanceTableBuilder.buildDataTable()

        Dim statsI As New attendanceTableBuilderClass.statsJson
        statsI = attendanceTableBuilder.stats
        statsI.site = If(currentSiteName.Equals(""), translations.getText("global"), currentSiteName)
        statsI.data = calendar_log.Value.Date.ToString("MMMM, yyyy")
        attendanceTableBuilder.stats = statsI
lastLine:
        Dim s(2) As String
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

    Private Sub bwLoadData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwLoadData.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()

        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            mainForm.busy.Close(True)
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If

        If e.Result(1).Equals("no workers") Then
            mainForm.busy.Close(True)

            datatable.Rows.Clear()
            translations.load("attendance")
            Dim message3 As String = translations.getText("workersNotFound")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()

            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
            metricsBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("metricsShadowedIcon.png"))
            metricsBtn.Enabled = False

            Exit Sub
        End If
        If e.Result(1).Equals("loading data") Then
            mainForm.busy.Close(True)

            mask.Dispose()
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
            metricsBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("metricsShadowedIcon.png"))
            metricsBtn.Enabled = False
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            mainForm.busy.Close(True)
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New messageBoxForm(e.Result(1), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
            metricsBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("metricsShadowedIcon.png"))
            metricsBtn.Enabled = False
            Exit Sub
        End If

        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0

        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        Dim cell_size As Integer = (datatable.Width - 400) / num_days
        cell_size = If(cell_size < sizeOfString.Width, sizeOfString.Width, cell_size)

        SuspendLayout()
        loaded = False
        translations.load("commonForm")
        With datatable
            .Visible = False
            .VirtualMode = True
            .DataSource = stateCore.datatableContents

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

            Dim today As Integer = DateTime.Now.Day

            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
            .Columns(0).Width = 300
            For i = 1 To num_days
                .Columns(i).HeaderCell.Value = i.ToString()
                .Columns(i).Width = cell_size
                If i.Equals(today) And DateTime.Now.Month.Equals(CInt(calendar_log.Value.Date.ToString("MM"))) Then
                    .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                Else
                    .Columns(i).DefaultCellStyle.BackColor = Color.White
                End If
                If i > today And DateTime.Now.Month.Equals(CInt(calendar_log.Value.Date.ToString("MM"))) Then
                    .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
            Next i
            .Columns(num_days + 1).HeaderCell.Value = translations.getText("tableRowTotal")

            .Rows(.Rows.Count - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 2).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 3).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
            .Rows(.Rows.Count - 2).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
            .Rows(.Rows.Count - 3).Cells(0).Style.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)

            .Visible = True
        End With
        ResumeLayout()

        Dim allSites As Boolean = False
        Dim moreThanOneSite As Boolean = False
        Dim qsite As String = ""
        Dim qsection As String = ""

        For Each Index In ListBoxSite.SelectedIndices
            If siteSelection(Index, 0).Equals(-1) And siteSelection(Index, 1).Equals(-1) Then 'ALL sites all sections
                allSites = True
                Exit For
            ElseIf siteSelection(Index, 1).Equals(-1) Then 'all sections of the site
                allSites = True
            Else
                If moreThanOneSite Then
                    allSites = True
                    Exit For
                End If
                moreThanOneSite = True
                qsite = siteSelection(Index, 0)
                qsection = siteSelection(Index, 1)
            End If
        Next

        If Not allSites Then 'ALL
            Dim checkDate As Date
            Dim formats As String() = New String() {"dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd"}
            If DateTime.TryParseExact(works_sections.Item("attendances_last_close")(InQueryDictionary(works_sections, qsection, "cod_section")), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, checkDate) Then
                checkDate = Convert.ToDateTime(works_sections.Item("attendances_last_close")(InQueryDictionary(works_sections, qsection, "cod_section")))
                If (checkDate.Year = DateTime.Now.Year And checkDate.Month = DateTime.Now.Month) Then 'already closed
                    'good date and  closed
                    closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogClosed.png"))
                    closeMonthAttendanceBtn.Enabled = False
                Else
                    'good date not closed
                    closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpen.png"))
                    closeMonthAttendanceBtn.Enabled = True
                End If
            Else
                'bad date
                closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpen.png"))
                closeMonthAttendanceBtn.Enabled = True
            End If
        Else
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogOpenShadowed.png"))
            closeMonthAttendanceBtn.Enabled = False
        End If
        translations.load("attendance")

        If attendanceTableBuilder.duplicateWorkerRecords(0).IsEmpty Then
            duplicatesBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("dupesChecked.png"))
            duplicatesBtn.Enabled = True
            ToggleDuplicatesToolTip.SetToolTip(duplicatesBtn, translations.getText("noDuplicates"))
        Else
            duplicatesBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("error.png"))
            duplicatesBtn.Enabled = True
            ToggleDuplicatesToolTip.SetToolTip(duplicatesBtn, attendanceTableBuilder.duplicateWorkerRecords.Count & " " & translations.getText("duplicatesFound"))
        End If
        duplicatesBtn.Refresh()
        mainForm.busy.Close(True)

        translations.load("successMessages")
        metricsBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("metricsIcon.png"))
        metricsBtn.Enabled = True

        loaded = True
        mask.Dispose()
        datatable.Refresh()
        mainForm.statusMessage = translations.getText("tableLoaded") & "."

    End Sub


    Private Sub gravarnota_lbl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles gravarnota_lbl.LinkClicked
        If txt_nota.Equals("") Then
            Exit Sub
        End If

        cellY = datatable.CurrentCell.RowIndex
        cellX = datatable.CurrentCell.ColumnIndex
        enableButtonsAndLinks(Me, False)

        Dim vars As New Dictionary(Of String, String)
        vars.Add("worker", attendanceTableBuilder.serverData(cellY, cellX).code)
        vars.Add("site", attendanceTableBuilder.serverData(cellY, cellX).site)
        vars.Add("section", attendanceTableBuilder.serverData(cellY, cellX).section)
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & cellX)
        vars.Add("note", txt_nota.Text)
        attendanceDataRequests.Initialise(stateCore)
        attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
        attendanceDataRequests.SaveLoggerAnnotationData()
    End Sub

    Private Sub attendanceDataRequests_getResponsebwFormLoggerSaveAnnotation(sender As Object, args As DataRequestsDataResult) Handles attendanceDataRequests.getResponsebwFormLoggerSaveAnnotation
        Dim response As String = args.responseData

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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
            attendanceTableBuilder.serverData(cellY, cellX).notes = txt_nota.Text

            translations.load("attendance")
            Dim message3 As String = translations.getText("successSaveNote")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            If datatable.Rows(cellY).Cells(cellX).Value IsNot Nothing Then
                Dim str As String = datatable.Rows(cellY).Cells(cellX).Value
                datatable.Rows(cellY).Cells(cellX).Value = Mid(str, 1, str.Length - 1)

                translations.load("attendance")
                Dim message3 As String = translations.getText("successDelNote")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        If Not InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex).Equals(-1) AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days Then
            cellX = e.ColumnIndex
            cellY = e.RowIndex
            If cellX = -1 Or cellY = -1 Then
                Exit Sub
            End If
            txt_nota.Enabled = True
            gravarnota_lbl.Enabled = True
            txt_nota.Text = attendanceTableBuilder.serverData(cellY, cellX).notes
            translations.load("attendance")

            GroupBox_detalhes.Text = translations.getText("details") & " " & calendar_log.Value.Date.ToString("yyyy-MM") & "-" & cellX
            detalhes_nome.Text = attendanceTableBuilder.serverData(cellY, cellX).name
            detalhes_nfc.Text = translations.getText("workerCompanyCardCode") & ": " & AddSpaces(attendanceTableBuilder.serverData(cellY, cellX).nfc, 3)
            detalhes_contacto.Text = translations.getText("contact") & ": " & attendanceTableBuilder.serverData(cellY, cellX).contact
            detalhes_emergencia.Text = translations.getText("contactEmergency") & ": " & attendanceTableBuilder.serverData(cellY, cellX).eContact
            detalhes_obra.Text = translations.getText("constructionSite") & ": " & works_site.Item("name")(InQueryDictionary(works_site, attendanceTableBuilder.serverData(cellY, cellX).site, "cod_site"))
            detalhes_empresa.Text = translations.getText("partnerCompany") & ": " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, attendanceTableBuilder.serverData(cellY, cellX).company, "cod_entreprise"))
            detalhes_cat.Text = translations.getText("professinalCategory") & ": " & works_category.Item("designation")(InQueryDictionary(works_category, attendanceTableBuilder.serverData(cellY, cellX).category, "cod_category"))
            duplicateRecords.Text = translations.getText("duplicateRecordsOnSites") & ": " & If(attendanceTableBuilder.serverData(cellY, cellX).duplicates.Equals(""), "- - ", attendanceTableBuilder.serverData(cellY, cellX).duplicates)
            If attendanceTableBuilder.serverData(cellY, cellX).categoryToday.Equals(0) Then
                category_today.Text = translations.getText("categoryToday") & ": - - "
            Else
                category_today.Text = translations.getText("categoryToday") & ": " & works_category.Item("designation")(InQueryDictionary(works_category, attendanceTableBuilder.serverData(cellY, cellX).categoryToday, "cod_category"))
            End If
            reasonLateValidation.Text = attendanceTableBuilder.serverData(cellY, cellX).validationReason
            detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("notValidated")
            detalhes_checkout.Text = translations.getText("checkout") & ": - -"
            detalhes_checkin.Text = translations.getText("checkin") & ": - -"

            If attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Or attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("") Or attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("null") Then
                detalhes_checkin.Text = translations.getText("checkin") & ": - -"
            Else
                detalhes_checkin.Text = translations.getText("checkin") & ": " & If(attendanceTableBuilder.serverData(cellY, cellX).checkin.Length < 5, attendanceTableBuilder.serverData(cellY, cellX).checkin, attendanceTableBuilder.serverData(cellY, cellX).checkin.Substring(0, 5).Replace(":", "H"))
            End If

            If attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Or attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("") Or attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("null") Then
                detalhes_checkout.Text = translations.getText("checkout") & ": - -"
            Else
                detalhes_checkout.Text = translations.getText("checkout") & ": " & If(attendanceTableBuilder.serverData(cellY, cellX).checkout.Length < 5, attendanceTableBuilder.serverData(cellY, cellX).checkout, attendanceTableBuilder.serverData(cellY, cellX).checkout.Substring(0, 5).Replace(":", "H"))
            End If

            If attendanceTableBuilder.serverData(cellY, cellX).status.Equals("P") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("fullDay")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("PI") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("partialDay") & " " & If(attendanceTableBuilder.serverData(cellY, cellX).absense.Length < 5, attendanceTableBuilder.serverData(cellY, cellX).absense, attendanceTableBuilder.serverData(cellY, cellX).absense.Substring(0, 5).Replace(":", "H"))
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("I") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("badWeather")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("A") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("fullDayAbsent")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("V") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("holidays")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("C") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("playday")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("M") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("malady")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("FA") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("siteAnnual")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("FI") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("siteWeather")
            ElseIf attendanceTableBuilder.serverData(cellY, cellX).status.Equals("") Or attendanceTableBuilder.serverData(cellY, cellX).status.Equals("EP") Or attendanceTableBuilder.serverData(cellY, cellX).status.Equals("MO") Then
                detalhes_validacao.Text = translations.getText("validation") & ": " & translations.getText("notValidated")
            End If

            If (attendanceTableBuilder.serverData(cellY, cellX).photo.Equals("")) Then
                worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
            Else
                worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
                worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
                Dim tClient As WebClient = New WebClient
                Try
                    Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & attendanceTableBuilder.serverData(cellY, cellX).photo)))
                    worker_photo.Image = tImage
                Catch ex As Exception
                    worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
                    translations.load("attendance")
                    mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                End Try
                worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
            End If
            worker_photo.Visible = True
            Panel1.Refresh()
            GroupBoxNotes.Refresh()

        Else
            clearWorkerDetails()
            txt_nota.Enabled = False
            gravarnota_lbl.Enabled = False

        End If
        EnforceAuthorities()
    End Sub
    Private Sub GroupBox_legenda_Enter(sender As Object, e As EventArgs) Handles GroupBox_legenda.Enter
    End Sub

    Private Sub datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick

    End Sub

    Private Sub tableSettingsBtn_Click(sender As Object, e As EventArgs) Handles tableSettingsBtn.Click
        Dim tableSearchOptions_frm As New tableSearchOptionsForm(mainForm, stateCore)
        tableSearchOptions_frm.from = "logger"
        enableButtonsAndLinks(Me, False)
        tableSearchOptions_frm.ShowDialog()
        enableButtonsAndLinks(Me, True)
        stateCore = mainForm.state
    End Sub

    Private Sub closeMonthAttendanceBtn_Click(sender As Object, e As EventArgs) Handles closeMonthAttendanceBtn.Click
        If Not attendanceTableBuilder.duplicateWorkerRecords(0).IsEmpty Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorDuplicatesFound")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim allSites As Boolean = False
        Dim moreThanOneSite As Boolean = False
        Dim qsite As String = ""
        Dim qsection As String = ""
        For Each Index In ListBoxSite.SelectedIndices
            If siteSelection(Index, 0).Equals(-1) And siteSelection(Index, 1).Equals(-1) Then 'ALL sites all sections
                allSites = True
                Exit For
            ElseIf siteSelection(Index, 1).Equals(-1) Then 'all sections of the site
                allSites = True
            Else
                If moreThanOneSite Then
                    allSites = True
                    Exit For
                End If
                moreThanOneSite = True
                qsite = siteSelection(Index, 0)
                qsection = siteSelection(Index, 1)
            End If
        Next

        If calendar_log.Value.Date.Year = DateTime.Now.Year And calendar_log.Value.Date.Month = DateTime.Now.Month And combo_company.SelectedIndex > 0 And ListBoxSite.SelectedItems.Count.Equals(1) And Not allSites Then
            Dim checkDate As Date
            Dim formats As String() = New String() {"dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd"}
            If DateTime.TryParseExact(works_sections.Item("attendances_last_close")(InQueryDictionary(works_sections, qsection, "cod_section")), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, checkDate) Then
                checkDate = Convert.ToDateTime(works_sections.Item("attendances_last_close")(InQueryDictionary(works_sections, qsection, "cod_section")))
                If (checkDate.Year = DateTime.Now.Year And checkDate.Month = DateTime.Now.Month) Then
                    translations.load("attendance")
                    Dim message4 As String = translations.getText("errorAttendanceAlreadyClosed")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message4, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    Exit Sub
                End If
            End If

            translations.load("attendance")
            Dim message3 As String = translations.getText("questionCloseMonthAttendance")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & "? ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If msgbox.ShowDialog = DialogResult.Yes Then
                Dim vars As New Dictionary(Of String, String)
                vars.Add("type", "lock")
                vars.Add("site", qsite)
                vars.Add("section", qsection)
                vars.Add("date", DateTime.Now.Date.ToString("yyyy-MM-dd"))

                attendanceDataRequests.Initialise(stateCore)
                attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
                attendanceDataRequests.SaveLoggerAnnotationData()
            End If
        Else
            If (calendar_log.Value.Date.Year = DateTime.Now.Year And calendar_log.Value.Date.Month <> DateTime.Now.Month) Or calendar_log.Value.Date.Year <> DateTime.Now.Year Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectCurrentMonth")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf combo_company.SelectedIndex = 0 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectEntreprise")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf ListBoxSite.SelectedIndex = 0 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            Else
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectOneSiteOnly")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub attendanceDataRequests_getResponseSaveCloseAttendanceData(sender As Object, args As DataRequestsDataResult) Handles attendanceDataRequests.getResponseSaveCloseAttendanceData
        Dim response As String = args.responseData
        mainForm.busy.Close(True)

        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            'good date and  closed
            closeMonthAttendanceBtn.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("closeLogClosed.png"))
            closeMonthAttendanceBtn.Enabled = False

            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub sideToggleBtn_Click(sender As Object, e As EventArgs) Handles sideToggleBtn.Click
        translations.load("commonForm")
        If (lateralPanel.Width.Equals(270)) Then
            lateralPanel.Width = 28
            Refresh()
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("showPanel"))
        Else
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))
            lateralPanel.Width = 270
            Refresh()
        End If
    End Sub

    Private Sub bottomToggleBtn_Click(sender As Object, e As EventArgs) Handles bottomToggleBtn.Click
        translations.load("commonForm")
        If (bottomPanel.Height.Equals(227)) Then
            bottomPanel.Height = 28
            Refresh()
            ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("showPanel"))
        Else
            bottomPanel.Height = 227
            Refresh()
            ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("hidePanel"))
        End If
    End Sub

    Private Sub loadSitesBtn_Click(sender As Object, e As EventArgs) Handles loadSitesBtn.Click
        mainForm.busy.Show()
        enableButtonsAndLinks(Me, False)

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        TablePanel.Controls.Add(mask)
        mask.BringToFront()
        Refresh()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "categories,entreprises,sites,sections")
        vars.Add("override", "true")
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

        attendanceDataRequests.Initialise(stateCore)
        attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
        attendanceDataRequests.loadLoggerInitialData()
    End Sub

    Private Sub duplicatesBtn_Click(sender As Object, e As EventArgs) Handles duplicatesBtn.Click
        If Not attendanceTableBuilder.duplicateWorkerRecords(0).IsEmpty Then
            enableButtonsAndLinks(Me, False)
            Dim duplicateRecords As New duplicateRecordsCheck_frm(mainForm, attendanceTableBuilder)
            If duplicateRecords.ShowDialog() = DialogResult.OK Then
                load_grid()
            End If
            enableButtonsAndLinks(Me, True)
        End If
    End Sub

    Private Sub metricsBtn_Click(sender As Object, e As EventArgs) Handles metricsBtn.Click
        enableButtonsAndLinks(Me, False)
        Dim statsForm As New logger_stats_frm(mainForm, attendanceTableBuilder.stats)
        statsForm.ShowDialog()
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseDoubleClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        Dim today As Integer = DateTime.Now.Day

        If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) <> -1 AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days AndAlso e.RowIndex <= UBound(attendanceTableBuilder.serverData, 1) Then
            Dim datePos As New MonthCalendar
            datePos.SelectionStart = calendar_log.Value.Date.ToString("yyyy-MM") & "-" & If(e.ColumnIndex < 10, "0" & e.ColumnIndex.ToString, e.ColumnIndex)
            If datePos.SelectionStart <= DateTime.Now.Date Then
                cellX = e.ColumnIndex
                cellY = e.RowIndex
                calendar = calendar_log
                Dim logday As New logday_frm(mainForm, Me)
                If logday.ShowDialog() = Windows.Forms.DialogResult.OK Then
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

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(attendanceTableBuilder.tableData) Then
            If attendanceTableBuilder.tableData.Rows.Count - 1 < hit.RowIndex Or attendanceTableBuilder.tableData.Columns.Count - 1 < hit.ColumnIndex Then
                Exit Sub
            End If
            datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = attendanceTableBuilder.tableData.Rows(hit.RowIndex)(0)
        End If
    End Sub

    Private Sub datatable_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles datatable.CellFormatting
        Dim grvScreenLocation As Drawing.Point = datatable.PointToScreen(datatable.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + datatable.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + datatable.Top
        Dim hit As DataGridView.HitTestInfo = datatable.HitTest(tempX, tempY)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(attendanceTableBuilder.tableData) Then
            If attendanceTableBuilder.tableData.Rows.Count - 1 < hit.RowIndex Or attendanceTableBuilder.tableData.Columns.Count - 1 < hit.ColumnIndex Then
                Exit Sub
            End If
            datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = attendanceTableBuilder.tableData.Rows(hit.RowIndex)(0)
        End If
    End Sub

    Private Sub logger_frm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If Me.Focused = False Then
            mainForm.childForm = "logger"
        End If
    End Sub
End Class