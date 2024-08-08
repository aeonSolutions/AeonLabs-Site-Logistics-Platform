Imports System.ComponentModel
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports ConstructionSiteLogistics.Gui.Forms.Shared

Public Class attendanceReportsForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm
    Private works_worker, works_entreprise, works_category, works_register As Dictionary(Of String, List(Of String))

    Private sectionsIndex As Integer()
    Private DBrecord As String(,,,)
    Private cellX As Integer = 0
    Private cellY As Integer = 0
    Private idxTableWorkerPos As Integer()
    Private response As String = ""
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwLoadData As BackgroundWorker

    Private loaded As Boolean = False
    Private siteSelection As Integer(,)
    Private ToggleSidePanelToolTip As New ToolTip()
    Private ToggleBottomPanelToolTip As New ToolTip()
    Private WithEvents DataRequests As IDataAttendanceReportsRequests
    Private currentSiteName As String
    Private tableData As DataTable
    Private syncLockObj As New Object

    Public Shared attendanceTableBuilder As attendanceTableBuilderClass

    Private notasPos As Integer = 0
    Private mainForm As MainMdiForm
    Public Property relatorio_tipo As String = ""
    Public Property works_site As Dictionary(Of String, List(Of String))
    Public Property works_sections As Dictionary(Of String, List(Of String))
    Private Sub CloseMe()
        Me.Close()
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs)
        mainForm.doMenuAnimmation("form")
    End Sub
    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Private Sub datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        SetDoubleBuffered(datatable)
        SetDoubleBuffered(datatableNotes)
        Me.Refresh()
    End Sub
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub report_frm_Load(sender As Object, e As EventArgs) Handles Me.Load

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
        mask.Refresh()
        bottomPanel.Height = 28
        bottomPanel.Refresh()
        Me.SuspendLayout()

        GroupBox_selection.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        relatorio_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        datatableNotes.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatableNotes.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar_log.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        GroupBox_legenda.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
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

        tipo_relatorio_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        resume_type.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_obra.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        listBoxSite.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_empresa.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_company.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_cat.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_cat.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        GroupBox_legenda.Height = datatable.Location.Y + datatable.Height - GroupBox_legenda.Location.Y
        resume_type.SelectedIndex = 0

        translations.load("commonForm")
        GroupBox_legenda.Text = translations.getText("legend")
        Dim SearchToolTip As New ToolTip()
        SearchToolTip.SetToolTip(LoadReport, translations.getText("searchParametersLink"))
        Dim lockSiteToolTip As New ToolTip()
        lockSiteToolTip.SetToolTip(checkStatusBtn, translations.getText("lockSiteLink"))
        ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))
        ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("hidePanel"))
        Dim LoadSiteToolTip As New ToolTip()
        LoadSiteToolTip.SetToolTip(loadSitesBtn, translations.getText("reloadSitesLink"))
        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(tableSettingsBtn, translations.getText("settingsLink"))

        translations.load("attendance")
        tipo_relatorio_lbl.Text = translations.getText("chooseReportType")
        relatorio_lbl.Text = translations.getText("reportTypeTitle")
        CheckBox_obra.Text = translations.getText("categorizeBySite")
        CheckBox_empresa.Text = translations.getText("categorizeByCompany")
        CheckBox_cat.Text = translations.getText("categorizeByCategory")
        resume_type.Items.Clear()
        resume_type.Items.Add(translations.getText("selectReportType"))
        resume_type.Items.Add(translations.getText("reportMonthly"))
        resume_type.Items.Add(translations.getText("reportMonthltyDetailed"))
        resume_type.SelectedIndex = 0
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

        calendar_log.Value = Now()

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

        ResumeLayout()

        loaded = False
        mainForm.childForm = "report"
    End Sub

    Private Sub report_frm_show(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "attendance.report.dll", "attendanceReportsDataRequests"), IDataAttendanceReportsRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try

        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        load_list()
        removeMask()
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

    Sub load_list()
        loaded = False
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "categories,entreprises,sites,sections")
        vars.Add("override", "true")
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadAttendanceReportInitialData()
    End Sub

    Private Sub DataRequests_getResponseAttendanceReportInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseAttendanceReportInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastline
        End If
        works_category = request.ConvertDataToArray("categories", stateCore.queryWorkerCategoryFields, response)
        If IsNothing(works_category) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastline
        End If
        works_entreprise = request.ConvertDataToArray("entreprises", stateCore.queryEntreprisePartnersFields, response)
        If IsNothing(works_entreprise) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastline
        End If

        works_site = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastline
        End If
        works_sections = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(works_sections) Then
            errorMsg = request.errorMessage
            errorFlag = True
        End If
        ReDim sectionsIndex(works_sections.Count - 1)
lastline:
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
            msgbox = New messageBoxForm(GetMessage(response) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        translations.load("commonForm")
        siteSelection = loadSitesWithSections(listBoxSite, works_site, works_sections, True, True)

        combo_company.Items.Clear()
        combo_company.Items.Add(translations.getText("dropdownSelectCompany"))
        For i = 0 To works_entreprise.Item("name").Count - 1
            combo_company.Items.Add(works_entreprise.Item("name")(i))
        Next
        combo_company.Items.Add(translations.getText("dropdownSelectAll"))
        combo_company.SelectedIndex = combo_company.Items.Count - 1

        combo_cat.Items.Clear()
        combo_cat.Items.Add(translations.getText("dropdownSelectCategories"))
        For i = 0 To works_category.Item("designation").Count - 1
            combo_cat.Items.Add(works_category.Item("designation")(i))
        Next
        combo_cat.Items.Add(translations.getText("dropdownSelectAll"))
        combo_cat.SelectedIndex = 0

        mainForm.busy.Close(True)
        removeMask()
        If mask IsNot Nothing Then
            mask.Dispose()
            mask = Nothing
        End If
        enableButtonsAndLinks(Me, True)
        CheckBox_cat.Checked = False
        CheckBox_empresa.Checked = False
        CheckBox_obra.Checked = False
        combo_cat.Enabled = False
        combo_company.Enabled = False
        listBoxSite.Enabled = False
        resume_type.SelectedIndex = 0
        loaded = True
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
        tablePanel.Controls.Add(mask)
        mask.BringToFront()
        Refresh()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "categories,entreprises,sites,sections")
        vars.Add("override", "true")
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadAttendanceReportInitialData()
    End Sub

    Private Sub combo_cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_cat.SelectedIndexChanged
        If combo_cat.SelectedIndex = 0 Then
            CheckBox_cat.Checked = False
        Else
            CheckBox_cat.Checked = True
        End If
    End Sub

    Private Sub combo_empresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_company.SelectedIndexChanged
        If combo_company.SelectedIndex = 0 Then
            CheckBox_empresa.Checked = False
        Else
            CheckBox_empresa.Checked = True
        End If
    End Sub

    Private Sub CheckBox_cat_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_cat.CheckedChanged
        If CheckBox_cat.Checked = False Then
            combo_cat.SelectedIndex = 0
        End If
        If CheckBox_cat.Checked = True And combo_cat.SelectedIndex = 0 Then
            CheckBox_cat.Checked = False
        End If
    End Sub

    Private Sub CheckBox_empresa_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_empresa.CheckedChanged
        If CheckBox_empresa.Checked = False Then
            combo_company.SelectedIndex = 0
        End If
        If CheckBox_empresa.Checked = True And combo_company.SelectedIndex = 0 Then
            CheckBox_empresa.Checked = False
        End If
    End Sub

    Private Sub CheckBox_obra_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_obra.CheckedChanged
        If CheckBox_obra.Checked = False Then
            listBoxSite.SelectedIndex = 0
        End If
        If CheckBox_obra.Checked = True And listBoxSite.SelectedIndex = 0 Then
            CheckBox_obra.Checked = False
        End If
    End Sub

    Private Sub combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBoxSite.SelectedIndexChanged
        If listBoxSite.SelectedIndex = 0 Then
            CheckBox_obra.Checked = False
        Else
            CheckBox_obra.Checked = True
        End If
    End Sub

    Private Sub resume_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles resume_type.SelectedIndexChanged
        translations.load("attendance")
        If resume_type.SelectedIndex > 0 And loaded Then
            calendar_log.Enabled = True
            CheckBox_cat.Enabled = True
            CheckBox_empresa.Enabled = True
            combo_cat.Enabled = True
            combo_company.Enabled = True

            relatorio_tipo = resume_type.SelectedItem.ToString
            If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then
                CheckBox_obra.Enabled = False
                listBoxSite.Enabled = False
            Else
                CheckBox_obra.Enabled = True
                listBoxSite.Enabled = True
            End If
            relatorio_lbl.Text = relatorio_tipo
            calendar_log.Enabled = True
        Else
            calendar_log.Enabled = False
            CheckBox_cat.Enabled = False
            CheckBox_empresa.Enabled = False
            combo_cat.Enabled = False
            combo_company.Enabled = False
            CheckBox_obra.Enabled = False
            listBoxSite.Enabled = False
            relatorio_lbl.Text = translations.getText("reportTypeTitle")
        End If
    End Sub

    Private Sub LoadReport_Click(sender As Object, e As EventArgs) Handles LoadReport.Click
        DropClickSearchBox(LoadReport)
        translations.load("attendance")
        If resume_type.SelectedIndex > 0 Then
            If Not relatorio_tipo.Equals(translations.getText("reportMonthly")) AndAlso (listBoxSite.SelectedIndex < 1) Then
                translations.load("errorMessages")
                Dim message = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            ElseIf Not relatorio_tipo.Equals(translations.getText("reportMonthly")) AndAlso siteSelection(listBoxSite.SelectedIndex - 1, 0).Equals(-2) Then
                translations.load("errorMessages")
                Dim message = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            End If

            If combo_company.SelectedIndex > 0 And combo_cat.SelectedIndex > 0 Then
                load_grid()
            ElseIf combo_company.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectEntreprise")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf combo_cat.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectCategory")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        Else
            translations.load("attendance")
            Dim message3 As String = translations.getText("errorSelectReportType")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub checkStatusBtn_Click(sender As Object, e As EventArgs) Handles checkStatusBtn.Click
        Dim attendanceCloseStatus As New frm_attendances_close_status(mainForm, Me)
        attendanceCloseStatus.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles tablePanel.Paint

    End Sub

    Private Sub sideToggleBtn_Click(sender As Object, e As EventArgs) Handles sideToggleBtn.Click
        translations.load("commonForm")
        If (lateralPanel.Width.Equals(397)) Then
            lateralPanel.Width = 28
            Refresh()
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("showPanel"))
        Else
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))
            lateralPanel.Width = 397
            Refresh()
        End If
    End Sub

    Private Sub bottomToggleBtn_Click(sender As Object, e As EventArgs) Handles bottomToggleBtn.Click
        translations.load("commonForm")
        If (Not bottomPanel.Height.Equals(28)) Then
            bottomPanel.Height = 28
            Refresh()
            ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("showPanel"))
            stateCore.datatableContents = datatable.DataSource
        Else
            bottomPanel.Height = Me.Height - 28
            Refresh()
            ToggleBottomPanelToolTip.SetToolTip(bottomToggleBtn, translations.getText("hidePanel"))
            stateCore.datatableContents = datatableNotes.DataSource
        End If
    End Sub
    Private Sub metricsBtn_Click(sender As Object, e As EventArgs) Handles metricsBtn.Click
        enableButtonsAndLinks(Me, False)
        Dim statsForm As New logger_stats_frm(mainForm, attendanceTableBuilder.stats)
        statsForm.ShowDialog()
        enableButtonsAndLinks(Me, True)
    End Sub

    Sub load_grid()
        enableButtonsAndLinks(Me, False)

        translations.load("attendance")
        Dim infoMessage As String = translations.getText("reportReminderCheckDuplicates")
        translations.load("messagebox")
        msgbox = New messageBoxForm(infoMessage, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        msgbox.ShowDialog()

        Dim str(3) As String
        Dim site, empresa, cat, qsection As String

        site = "none"
        empresa = "none"
        cat = "none"
        qsection = "all"

        mainForm.busy.Show()
        translations.load("attendance")
        If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
            If CheckBox_obra.Checked Or CheckBox_empresa.Checked Or CheckBox_cat.Checked Then
                translations.load("attendance")
                If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
                    site = "none"
                ElseIf siteSelection(listBoxSite.SelectedIndex - 1, 0).Equals(-1) Then 'ALL
                    site = "all"
                ElseIf Not CheckBox_obra.Checked Then
                    site = "none"
                Else
                    site = siteSelection(listBoxSite.SelectedIndex - 1, 0)
                End If
                If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
                    qsection = "none"
                ElseIf siteSelection(listBoxSite.SelectedIndex - 1, 1).Equals(-1) Then
                    qsection = "all"
                ElseIf Not CheckBox_obra.Checked Then
                    qsection = "none"
                Else
                    qsection = siteSelection(listBoxSite.SelectedIndex - 1, 1)
                End If
                translations.load("commonForm")

                If combo_company.Text.Equals(translations.getText("dropdownSelectAll")) Then
                    empresa = "all"
                ElseIf combo_company.SelectedIndex <> 0 Then
                    empresa = works_entreprise.Item("cod_entreprise")(combo_company.SelectedIndex - 1)
                ElseIf Not CheckBox_empresa.Checked Then
                    empresa = "none"
                Else
                    empresa = "all"
                End If

                If combo_cat.Text.Equals(translations.getText("dropdownSelectAll")) Then
                    cat = "all"
                ElseIf combo_cat.SelectedIndex <> 0 Then
                    cat = works_category.Item("cod_category")(combo_cat.SelectedIndex - 1)
                ElseIf Not CheckBox_cat.Checked Then
                    cat = "none"
                Else
                    cat = "all"
                End If
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
            tablePanel.Controls.Add(mask)
            mask.BringToFront()
            Refresh()

            Dim vars As New Dictionary(Of String, String)
            vars.Add("empresa", empresa)
            vars.Add("site", site)
            vars.Add("cat", cat)
            vars.Add("section", qsection)
            vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.loadAttendanceReportData()

        ElseIf relatorio_tipo.Equals(translations.getText("reportMonthltyDetailed")) Or relatorio_tipo.Equals(translations.getText("reportMonthltyDetailedBySite")) Then
            relatorio_detalhado()
        End If
    End Sub

    Private Sub DataRequests_getResponseAttendanceReportData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseAttendanceReportData
        Dim response As String = args.responseData
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            mainForm.busy.Close(True)
            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        translations.load("busyMessages")
        mainForm.statusMessage = translations.getText("loadingTable")
        translations.load("commonForm")

        Dim err As Boolean = False
        Dim fields As String()

        If resume_type.SelectedIndex.Equals(1) Then
            fields = stateCore.queryReportMonthly
        Else
            fields = stateCore.queryReportDetailed
        End If
        works_worker = request.ConvertDataToArray("report", fields, response)
        If IsNothing(works_worker) Then
            err = True
        End If

        If err Then
            mainForm.busy.Close(True)
            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(request.errorMessage), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If

        If works_worker.Item("cod_worker").Count < 1 Then
            mainForm.busy.Close(True)
            translations.load("errorMessages")
            Dim message = translations.getText("errorNoRecordsFound")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If

        relatorio_resumo()

        mainForm.busy.Close(True)
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub tableSettingsBtn_Click(sender As Object, e As EventArgs) Handles tableSettingsBtn.Click
        Dim tableSearchOptions_frm As New tableSearchOptionsForm(mainForm, stateCore)
        tableSearchOptions_frm.from = "logger"
        enableButtonsAndLinks(Me, False)
        tableSearchOptions_frm.ShowDialog()
        enableButtonsAndLinks(Me, True)
        stateCore = mainForm.state
    End Sub

    Sub relatorio_resumo()
        mainForm.busy.Show()

        ReDim idxTableWorkerPos(works_worker.Item("cod_worker").Count)

        translations.load("commonForm")
        SuspendLayout()
        With datatableNotes
            .Visible = False
            .Rows.Clear()
            .RowHeadersVisible = False
            .ColumnCount = 6
            .RowCount = 1

            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
            .Columns(0).Width = 300

            .Columns(1).HeaderCell.Value = translations.getText("dateTitle")
            .Columns(1).Width = 70

            .Columns(2).HeaderCell.Value = translations.getText("dropdownSiteTitle")
            .Columns(2).Width = 200

            .Columns(3).HeaderCell.Value = translations.getText("siteSection")
            .Columns(3).Width = 100

            translations.load("EditRegieDialog")
            .Columns(4).HeaderCell.Value = translations.getText("reason")
            .Columns(4).Width = 300

            translations.load("siteActivity")
            .Columns(5).HeaderCell.Value = translations.getText("productionTableColumnAnnotations")
            .Columns(5).Width = 300
        End With
        Dim request As New HttpDataCore
        tableData = New DataTable

        translations.load("commonForm")
        tableData.Columns.Add(translations.getText("tableHeaderName"), GetType(String))
        translations.load("attendance")
        tableData.Columns.Add(translations.getText("tableHeaderDaysTotal"), GetType(String))
        For i = 0 To works_site.Item("cod_site").Count - 1
            tableData.Columns.Add(translations.getText("initials"), GetType(String))
        Next i

        tableData.Columns.Add("", GetType(String))
        tableData.Columns.Add(translations.getText("tableHeaderHoursTotal"), GetType(String))
        For i = 0 To works_site.Item("cod_site").Count - 1
            tableData.Columns.Add(works_site.Item("initials")(i).ToUpper, GetType(String))
        Next i

        tableData.Columns.Add("", GetType(String))

        tableData.Columns.Add("A", GetType(String))
        tableData.Columns.Add("V", GetType(String))
        tableData.Columns.Add("I", GetType(String))
        tableData.Columns.Add("C", GetType(String))
        tableData.Columns.Add("M", GetType(String))
        tableData.Columns.Add("FA", GetType(String))
        tableData.Columns.Add("FI", GetType(String))

        Dim dr() As Object
        ReDim dr(tableData.Columns.Count - 1)

        Dim rowpos As Integer = 0
        Dim spaces As Boolean = False

        If CheckBox_empresa.Checked Then
            Array.Clear(dr, 0, dr.Length)
            dr(0) = "" & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(0), "cod_entreprise"))
            tableData.Rows.Add(dr)
        End If

        If CheckBox_cat.Checked Then
            Array.Clear(dr, 0, dr.Length)
            dr(0) = " " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(0), "cod_category"))
            tableData.Rows.Add(dr)
        End If

        For i = 0 To works_worker.Item("cod_worker").Count - 1
                If i > 0 Then
                    If CheckBox_empresa.Checked Then
                        If works_worker.Item("cod_entreprise")(i) <> works_worker.Item("cod_entreprise")(i - 1) Or spaces Then
                        translations.load("attendance")
                        Array.Clear(dr, 0, dr.Length)
                        dr(0) = translations.getText("reportTotalsCompany")
                        tableData.Rows.Add(dr)
                        rowpos += 1
                        Array.Clear(dr, 0, dr.Length)
                        dr(0) = "" & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(i), "cod_entreprise"))
                        tableData.Rows.Add(dr)
                        rowpos += 1
                        spaces = True
                    End If
                    End If

                    If CheckBox_cat.Checked Then
                    If works_worker.Item("cod_category")(i) <> works_worker.Item("cod_category")(i - 1) Or spaces Then
                        Array.Clear(dr, 0, dr.Length)
                        dr(0) = " " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(i), "cod_category"))
                        tableData.Rows.Add(dr)
                        rowpos += 1
                        spaces = False
                    End If
                End If

                End If
            idxTableWorkerPos(i) = rowpos
            Array.Clear(dr, 0, dr.Length)
            dr(0) = "   " & works_worker.Item("name")(i)
            tableData.Rows.Add(dr)
            rowpos += 1
            spaces = False
        Next i
        If CheckBox_empresa.Checked Then
            translations.load("attendance")
            Array.Clear(dr, 0, dr.Length)
            dr(0) = translations.getText("reportTotalsCompany")
            tableData.Rows.Add(dr)
            rowpos += 1
        End If

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        DataRequests.Initialise(stateCore)
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            Dim vars As New Dictionary(Of String, String)
            vars.Add("site", "all")
            vars.Add("section", "all")
            vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
            vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & num_days.ToString())
            vars.Add("worker", works_worker.Item("cod_worker")(i))

            Dim misc As New Dictionary(Of String, String)
            misc.Add("pos", i)
            misc.Add("rowpos", rowpos)

            DataRequests.loadQueue(vars, misc, Nothing)
        Next i
        response = DataRequests.loadAttendanceReportRecordData()
    End Sub
    Private Sub dataRequests_getResponseLoadAttendanceReportRecordData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadAttendanceReportRecordData
        If Not IsResponseOk(args.responseData) Then
            mainForm.busy.Close(True)

            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(args.responseData), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            Refresh()
            Exit Sub
        End If
        Dim i As Integer = args.misc("pos")
        Dim request As New HttpDataCore
        Dim notasPos As Integer = 0
        works_register = request.ConvertDataToArray("record", stateCore.queryAttendanceRecords, args.responseData)
        If IsNothing(works_register) Then
            Exit Sub
        End If

        For j = 0 To works_register.Item("checkin").Count - 1
            If Not works_register.Item("notas")(j).Equals("") Then
                datatableNotes.Rows(notasPos).Cells(5).Value = works_register.Item("notas")(j)
                datatableNotes.Rows(notasPos).Cells(1).Value = works_register.Item("date")(j)
                datatableNotes.Rows(notasPos).Cells(0).Value = works_worker.Item("name")(i)
                datatableNotes.Rows(notasPos).Cells(2).Value = works_site("name")(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site"))
                datatableNotes.Rows(notasPos).Cells(3).Value = works_sections("description")(InQueryDictionary(works_sections, works_register.Item("cod_section")(j), "cod_section"))
                notasPos += 1
                datatableNotes.Rows.Add()
            End If
            If Not works_register.Item("validation_reason")(j).Equals("") Then
                datatableNotes.Rows(notasPos).Cells(4).Value = works_register.Item("validation_reason")(j)
                datatableNotes.Rows(notasPos).Cells(1).Value = works_register.Item("date")(j)
                datatableNotes.Rows(notasPos).Cells(0).Value = works_worker.Item("name")(i)
                datatableNotes.Rows(notasPos).Cells(2).Value = works_site("name")(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site"))
                datatableNotes.Rows(notasPos).Cells(3).Value = works_sections("description")(InQueryDictionary(works_sections, works_register.Item("cod_section")(j), "cod_section"))
                notasPos += 1
                datatableNotes.Rows.Add()
            End If

            Dim dr() As Object
            ReDim dr(tableData.Columns.Count - 1)
            Dim row, col As Integer

            If works_register.Item("status")(j).Equals("P") Then
                Array.Clear(dr, 0, dr.Length)
                dr(0) = translations.getText("reportTotalsCompany")
                SyncLock syncLockObj
                    row = idxTableWorkerPos(i)
                    col = InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2
                    tableData.Rows(row)(col) = If(IsDBNull(tableData.Rows(row)(col)), "0", (CInt(tableData.Rows(row)(col)) + 1).ToString)
                End SyncLock
            ElseIf works_register.Item("status")(j).Equals("PI") Then
                'adicionar mais um dia de trabalho
                Array.Clear(dr, 0, dr.Length)
                dr(0) = translations.getText("reportTotalsCompany")
                SyncLock syncLockObj
                    row = idxTableWorkerPos(i)
                    col = InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2
                    tableData.Rows(row)(col) = If(IsDBNull(tableData.Rows(row)(col)), "0", (CInt(tableData.Rows(row)(col)) + 1).ToString)
                End SyncLock

                ' adicionar horas que faltou
                Dim stime, etime As TimeSpan
                Dim ftime As TimeSpan

                row = idxTableWorkerPos(i)
                col = works_site.Item("cod_site").Count + 4 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")
                If IsDBNull(tableData.Rows(row)(col)) Then
                    Array.Clear(dr, 0, dr.Length)
                    dr(0) = translations.getText("reportTotalsCompany")
                    SyncLock syncLockObj
                        row = idxTableWorkerPos(i)
                        col = InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2
                        tableData.Rows(row)(col) = works_register.Item("absense")(j).Substring(0, 5).Replace(":", "H")
                    End SyncLock
                End If

                row = idxTableWorkerPos(i)
                col = works_site.Item("cod_site").Count + 4 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")
                If Not IsDBNull(tableData.Rows(row)(col)) Then
                    Array.Clear(dr, 0, dr.Length)
                    dr(0) = translations.getText("reportTotalsCompany")
                    SyncLock syncLockObj
                        row = idxTableWorkerPos(i)
                        col = InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2
                        tableData.Rows(row)(col) = If(IsDBNull(tableData.Rows(row)(col)), "0", (CInt(tableData.Rows(row)(col)) + 1).ToString)
                    End SyncLock

                Else
                    Dim sw0 As String = tableData.Rows(idxTableWorkerPos(i))(works_site.Item("cod_site").Count + 3 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).Value.ToString.Replace("H", ":") & ":00"
                    Dim hours0 = sw0.Substring(0, 2)
                    Dim minutes0 = sw0.Substring(3, 2)
                    Dim totalSeconds0 = CInt(hours0) * 60 * 60 + CInt(minutes0) * 60

                    stime = TimeSpan.FromSeconds(totalSeconds0)
                    etime = TimeSpan.Parse(works_register.Item("absense")(j))
                    ftime = stime + etime
                    tableData.Rows(idxTableWorkerPos(i))(works_site.Item("cod_site").Count + 4) = ftime.ToString().Substring(0, 5).Replace(":", "H")
                End If

            ElseIf works_register.Item("status")(j).Equals("A") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 5) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 5)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 5)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("V") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 6) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 6)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 6)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("I") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 7) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 7)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 7)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("C") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 8) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 8)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 8)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("M") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 9) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 9)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 9)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("FA") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 10) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 10)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 10)) + 1).ToString)
            ElseIf works_register.Item("status")(j).Equals("FI") Then
                tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 11) = If(IsDBNull(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 11)), "0", (CInt(tableData(idxTableWorkerPos(i))(2 * works_site.Item("cod_site").Count + 11)) + 1).ToString)
            End If
        Next j
    End Sub


    Private Sub dataRequests_getResponseLoadAttendanceReportRecordDataCompleted(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadAttendanceReportRecordDataCompleted
        Dim dr() As Object
        ReDim dr(tableData.Columns.Count - 1)

        Array.Clear(dr, 0, dr.Length)
        translations.load("commonForm")
        Dim tableRowTotalString As String = translations.getText("tableRowTotal")
        Dim textTrans As String = translations.getText("tableRowTotal")

        dr(0) = translations.getText("tableRowTotal")
        tableData.Rows.Add(dr)

        Dim counter As Integer = 0
        translations.load("attendance")
        For i = 2 To 1 + works_site.Item("cod_site").Count
            counter = 0
            For j = 0 To works_worker.Item("cod_worker").Count - 1
                If Not IsDBNull(tableData.Rows(idxTableWorkerPos(j))(i)) Then
                    tableData.Rows(idxTableWorkerPos(j))(1) = tableData.Rows(idxTableWorkerPos(j))(i)
                    counter += CInt(tableData.Rows(idxTableWorkerPos(j))(i))
                End If
            Next j
            tableData.Rows(tableData.Rows.Count - 1)(i) = counter.ToString
        Next i

        Dim counterCompany As Integer = 0
        counter = 0
        For i = 1 To 1 + works_site.Item("cod_site").Count
            counterCompany = 0
            counter = 0
            For j = 0 To tableData.Rows.Count - 1
                If tableData.Rows(j)(0).ToString.Equals(translations.getText("reportTotalsCompany")) Then
                    tableData.Rows(j)(i) = counterCompany
                    counterCompany = 0
                ElseIf Not IsDBNull(tableData.Rows(j)(i)) Then
                    counterCompany += CInt(tableData.Rows(j)(i))
                    counter += CInt(tableData.Rows(j)(i))
                End If
            Next j
            tableData.Rows(tableData.Rows.Count - 1)(i) = counter.ToString()
        Next i

        'totals in hours of absense in column
        Dim counterTime, counterTimeCompany, counterTimeGlobalTotals As TimeSpan
        translations.load("attendance")
        For i = works_site.Item("cod_site").Count + 4 To 2 * works_site.Item("cod_site").Count + 3
            counterTime = TimeSpan.Parse("00:00:00")
            counterTimeCompany = TimeSpan.Parse("00:00:00")
            Dim counterTimeCompanyTotals As TimeSpan = TimeSpan.Parse("00:00:00")
            counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")

            For j = 0 To tableData.Rows.Count - 1
                If tableData.Rows(j)(0).ToString.Equals(textTrans) Then
                    If counterTimeGlobalTotals.ToString().IndexOf(".") > -1 Then
                        Dim dc As Integer = counterTimeCompany.ToString().Substring(0, counterTimeCompany.ToString().IndexOf("."))
                        tableData.Rows(j)(i) = (dc * 24 + CInt(counterTimeGlobalTotals.Hours.ToString())).ToString() & "H" & If(counterTimeGlobalTotals.Minutes < 10, "0", "") & counterTimeGlobalTotals.Minutes.ToString()
                    Else
                        tableData.Rows(j)(i).Value = counterTimeGlobalTotals.ToString().Substring(0, 5).Replace(":", "H")
                    End If
                    counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")

                ElseIf tableData.Rows(j)(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Then
                    Dim tmp1 As TimeSpan = TimeSpan.Parse("00:00:00")
                    Dim sw1 = If(IsNothing(tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value), "00:00:00", tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value.ToString.Replace("H", ":"))
                    Dim hours1 = sw1.Substring(0, 2)
                    Dim minutes1 = sw1.Substring(3, 2)
                    Dim totalSeconds1 = CInt(hours1) * 60 * 60 + CInt(minutes1) * 60
                    counterTimeCompanyTotals += TimeSpan.FromSeconds(totalSeconds1)
                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = counterTimeCompanyTotals.ToString
                    counterTimeCompanyTotals = TimeSpan.Parse("00:00:00")

                    If counterTimeCompany.ToString().IndexOf(".") > -1 Then
                        Dim dc As Integer = counterTimeCompany.ToString().Substring(0, counterTimeCompany.ToString().IndexOf("."))
                        tableData.Rows(j)(i).Value = (dc * 24 + CInt(counterTimeCompany.Hours.ToString())).ToString() & "H" & If(counterTimeCompany.Minutes < 10, "0", "") & counterTimeCompany.Minutes.ToString()
                    Else
                        tableData.Rows(j)(i).Value = counterTimeCompany.ToString().Substring(0, 5).Replace(":", "H")
                    End If
                    counterTimeCompany = TimeSpan.Parse("00:00:00")
                ElseIf Not IsNothing(tableData.Rows(j)(i).Value) AndAlso tableData.Rows(j)(i).Value.ToString().IndexOf("H") > -1 Then
                    Dim tmp3 As TimeSpan = TimeSpan.Parse("00:00:00")
                    Dim sw3 = If(IsNothing(tableData.Rows(j)(i).Value), "00:00:00", tableData.Rows(j)(i).Value.ToString.Replace("H", ":"))
                    Dim hours3 = sw3.Substring(0, 2)
                    Dim minutes3 = sw3.Substring(3, 2)
                    Dim totalSeconds3 = CInt(hours3) * 60 * 60 + CInt(minutes3) * 60
                    tmp3 = TimeSpan.FromSeconds(totalSeconds3)

                    counterTime += tmp3
                    counterTimeCompany += tmp3

                    Dim tmp2 As TimeSpan = TimeSpan.Parse("00:00:00")
                    Dim sw2 = If(IsNothing(tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value), "00:00:00", tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value)
                    Dim hours2 = sw2.Substring(0, 2)
                    Dim minutes2 = sw2.Substring(3, 2)
                    Dim totalSeconds2 = CInt(hours2) * 60 * 60 + CInt(minutes2) * 60 + CInt(hours3) * 60 * 60 + CInt(minutes3) * 60
                    Dim TotalInLineTimeTmp As TimeSpan = TimeSpan.FromSeconds(totalSeconds2)

                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = TotalInLineTimeTmp.ToString
                End If
            Next j
            If counterTime.ToString().IndexOf(".") > -1 Then
                Dim d As Integer = counterTime.ToString().Substring(0, counterTime.ToString().IndexOf("."))
                tableData.Rows(tableData.Rows.Count - 1)(i).Value = (d * 24 + CInt(counterTime.Hours.ToString())).ToString() & "H" & If(counterTime.Minutes < 10, "0", "") & counterTime.Minutes.ToString()
            Else
                tableData.Rows(tableData.Rows.Count - 1)(i).Value = counterTime.ToString().Substring(0, 5).Replace(":", "H")
            End If
        Next i

        'convert to 24++ time the totals column
        counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")
        For j = 0 To tableData.Rows.Count - 1
            If tableData.Rows(j)(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Or tableData.Rows(j)(0).Value.ToString.Equals(tableRowTotalString) Then
                Dim tmp4 As TimeSpan = TimeSpan.Parse("00:00:00")
                For i = works_site.Item("cod_site").Count + 4 To 2 * works_site.Item("cod_site").Count + 3
                    Dim sw4 = If(IsNothing(tableData.Rows(j)(i)), "00:00:00", tableData.Rows(j)(i).Value.ToString.Replace("H", ":"))
                    Dim hours4 = sw4.Substring(0, 2)
                    Dim minutes4 = sw4.Substring(3, 2)
                    Dim totalSeconds4 = CInt(hours4) * 60 * 60 + CInt(minutes4) * 60
                    tmp4 += TimeSpan.FromSeconds(totalSeconds4)
                Next i
                If tmp4.ToString().IndexOf(".") > -1 Then
                    Dim dc4 As Integer = tmp4.ToString().Substring(0, tmp4.ToString().IndexOf("."))
                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = (dc4 * 24 + CInt(tmp4.Hours.ToString())).ToString() & "H" & If(tmp4.Minutes < 10, "0", "") & tmp4.Minutes.ToString()
                Else
                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = tmp4.ToString().Substring(0, 5).Replace(":", "H")
                End If
            ElseIf Not IsDBNull(tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value) Then
                Dim tmp5 As TimeSpan = TimeSpan.Parse("00:00:00")
                Dim sw5 = If(IsDBNull(tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value), "00:00:00", tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value.ToString.Replace("H", ":"))
                Dim hours5 = sw5.Substring(0, 2)
                Dim minutes5 = sw5.Substring(3, 2)
                Dim totalSeconds5 = CInt(hours5) * 60 * 60 + CInt(minutes5) * 60
                tmp5 = TimeSpan.FromSeconds(totalSeconds5)
                If tmp5.ToString().IndexOf(".") > -1 Then
                    Dim dc5 As Integer = tmp5.ToString().Substring(0, tmp5.ToString().IndexOf("."))
                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = (dc5 * 24 + CInt(tmp5.Hours.ToString())).ToString() & "H" & If(tmp5.Minutes < 10, "0", "") & tmp5.Minutes.ToString()
                Else
                    tableData.Rows(j)(works_site.Item("cod_site").Count + 3).Value = tmp5.ToString().Substring(0, 5).Replace(":", "H")
                End If
            End If
        Next j

        Dim cell_size As Integer = 50 '(datatable.Width - 400) / (works_site.GetLength(0))
        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        With datatable
            .Visible = False
            .DataSource = tableData
            .Columns(0).Width = 300
            .Columns(1).Width = cell_size + 30
            For i = 0 To works_site.Item("cod_site").Count - 1
                .Columns(i + 2).Width = cell_size
            Next i
            .Columns(works_site.Item("cod_site").Count + 2).Width = 30
            .Columns(works_site.Item("cod_site").Count + 2).DefaultCellStyle.BackColor = Color.Black
            .Columns(works_site.Item("cod_site").Count + 3).Width = cell_size + 10

            For i = 0 To works_site.Item("cod_site").Count - 1
                .Columns(works_site.Item("cod_site").Count + 4 + i).Width = cell_size
            Next i
            .Columns(2 * works_site.Item("cod_site").Count + 4).DefaultCellStyle.BackColor = Color.Black
            .Columns(2 * works_site.Item("cod_site").Count + 4).Width = 30

            .Columns(2 * works_site.Item("cod_site").Count + 5).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 6).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 7).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 8).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 9).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 10).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 11).Width = cell_size

            .Visible = True
        End With

        datatableNotes.Visible = True
        stateCore.datatableContents = tableData

        ResumeLayout()
        translations.load("readyMessages")
        mainForm.statusMessage = translations.getText("ready")
        mask.Dispose()

        mainForm.busy.Close(True)
    End Sub

    Sub relatorio_detalhado()
        mainForm.busy.Show()
        translations.load("attendance")
        mainForm.busy.Show()
        Dim qempresa As String
        Dim sites As String = ""
        Dim index As Integer = listBoxSite.SelectedIndex
        sites = If(sites.Equals(""), siteSelection(Index, 0) & "-" & siteSelection(Index, 1), sites & "," & siteSelection(Index, 0) & "-" & siteSelection(Index, 1))

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

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadLoggerData()
    End Sub

    Private Sub attendanceDataRequests_getResponseLoggerData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoggerData
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

            Exit Sub
        End If
        If e.Result(1).Equals("loading data") Then
            mainForm.busy.Close(True)

            mask.Dispose()
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            mainForm.busy.Close(True)
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New messageBoxForm(e.Result(1), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
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

        loadDatatableNotes()

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

        loaded = True
        mask.Dispose()
        datatable.Refresh()
        mainForm.statusMessage = translations.getText("tableLoaded") & "."
    End Sub

    Private Sub loadDatatableNotes()
        Dim tableDataNotes As DataTable = attendanceTableBuilder.BuildNotesTableData()
        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)

        With datatableNotes
            .Visible = False
            .VirtualMode = True
            .DataSource = tableDataNotes

            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
                .Columns(0).Width = 300

                .Columns(1).HeaderCell.Value = translations.getText("dateTitle")
                .Columns(1).Width = 70

                .Columns(2).HeaderCell.Value = translations.getText("dropdownSiteTitle")
                .Columns(2).Width = 200

                .Columns(3).HeaderCell.Value = translations.getText("siteSection")
                .Columns(3).Width = 100

                translations.load("EditRegieDialog")
                .Columns(4).HeaderCell.Value = translations.getText("reason")
                .Columns(4).Width = 300

                translations.load("siteActivity")
                .Columns(5).HeaderCell.Value = translations.getText("productionTableColumnAnnotations")
            .Columns(5).Width = 300

            Dim colMaxHEight As Integer = 0
            Dim lines As Integer = 0
            Dim newlines As Integer = 0
            For i = 0 To tableDataNotes.Rows.Count - 1
                colMaxHEight = 0
                newlines = 0
                For j = 0 To datatable.Columns.Count - 1
                    If j > 0 Then
                        .Rows(i).Cells(j).ReadOnly = False
                    End If
                    sizeOfString = g.MeasureString(If(IsDBNull(tableDataNotes.Rows(i)(j)), " ", tableDataNotes.Rows(i)(j)), fontToMeasure)
                    lines = Math.Truncate(sizeOfString.Width / .Columns(j).Width) + 1
                    newlines = If(IsDBNull(tableDataNotes.Rows(i)(j)), " ", tableDataNotes.Rows(i)(j)).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * 1.15 * colMaxHEight
            Next i
        End With
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
End Class