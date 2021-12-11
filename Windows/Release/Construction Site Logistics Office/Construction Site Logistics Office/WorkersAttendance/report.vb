Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Reflection
Imports System.Windows

Public Class report_frm
    Private state As State
    Private translations As languageTranslations
     
    Private msgbox As message_box_frm
    Private works_worker, works_entreprise, works_category, works_site, works_register, works_sections As Dictionary(Of String, List(Of String))

    Private sectionsIndex As Integer()
    Private DBrecord As String(,,,)
    Private cellX As Integer = 0
    Private cellY As Integer = 0
    Private idxTableWorkerPos As Integer()
    Private response As String = ""
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private siteSelection As Integer(,)

    Public Shared currentDatatable As DataGridView
    Public Shared relatorio_tipo As String = ""

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Private Sub datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick
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

    Private Sub report_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Refresh()

        Me.SuspendLayout()

        GroupBox_selection.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        relatorio_lbl.Font = New Font(state.fontText.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
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

        tipo_relatorio_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        resume_type.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_obra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_empresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_company.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_cat.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_cat.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        datatable.Width = Me.Width - datatable.Location.X - 10
        datatable.Height = Me.Height - datatable.Location.Y - 10
        GroupBox_legenda.Height = datatable.Location.Y + datatable.Height - GroupBox_legenda.Location.Y
        resume_type.SelectedIndex = 0

        translations.load("commonForm")
        GroupBox_legenda.Text = translations.getText("legend")
        Dim SearchToolTip As New ToolTip()
        SearchToolTip.SetToolTip(LoadReport, translations.getText("searchParametersLink"))

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
        resume_type.Items.Add(translations.getText("reportMonthltyDetailedBySite"))
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
        ResumeLayout()

        loaded = False
        MainMdiForm.childForm = "report"
    End Sub

    Private Sub report_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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

    End Sub

    Sub load_list()
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
        translations.load("commonForm")

        siteSelection = loadSitesWithSections(combo_site, works_site, works_sections)


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

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()

        CheckBox_cat.Checked = False
        CheckBox_empresa.Checked = False
        CheckBox_obra.Checked = False

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
            combo_site.SelectedIndex = 0
        End If
        If CheckBox_obra.Checked = True And combo_site.SelectedIndex = 0 Then
            CheckBox_obra.Checked = False
        End If
    End Sub

    Private Sub combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_site.SelectedIndexChanged
        If combo_site.SelectedIndex = 0 Then
            CheckBox_obra.Checked = False
        Else
            CheckBox_obra.Checked = True

        End If

    End Sub


    Private Sub resume_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles resume_type.SelectedIndexChanged
        translations.load("attendance")
        If resume_type.SelectedIndex > 0 Then
            calendar_log.Enabled = True
            CheckBox_cat.Enabled = True
            CheckBox_empresa.Enabled = True
            combo_cat.Enabled = True
            combo_company.Enabled = True

            relatorio_tipo = resume_type.SelectedItem.ToString
            If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then
                CheckBox_obra.Enabled = False
                combo_site.Enabled = False
            Else
                CheckBox_obra.Enabled = True
                combo_site.Enabled = True
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
            combo_site.Enabled = False
            relatorio_lbl.Text = translations.getText("reportTypeTitle")
        End If

    End Sub


    Private Sub LoadReport_Click(sender As Object, e As EventArgs) Handles LoadReport.Click
        DropClickSearchBox(LoadReport)
        If resume_type.SelectedIndex > 0 Then
            If Not relatorio_tipo.Equals(translations.getText("reportMonthly")) AndAlso (combo_site.SelectedIndex < 1) Then
                translations.load("errorMessages")
                Dim message = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            ElseIf Not relatorio_tipo.Equals(translations.getText("reportMonthly")) AndAlso siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-2) Then
                translations.load("errorMessages")
                Dim message = translations.getText("errorSelectSite")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            End If

            If combo_company.SelectedIndex > 0 And combo_cat.SelectedIndex > 0 Then
                load_grid()
            ElseIf combo_company.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectEntreprise")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf combo_cat.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectCategory")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        Else
            translations.load("attendance")
            Dim message3 As String = translations.getText("errorSelectReportType")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
    End Sub

    Sub load_grid()
        enableButtonsAndLinks(Me, False)

        translations.load("attendance")
        Dim infoMessage As String = translations.getText("reportReminderCheckDuplicates")
        translations.load("messagebox")
        msgbox = New message_box_frm(infoMessage, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        msgbox.ShowDialog()

        Dim str(3) As String
        Dim site, empresa, cat, qsection As String

        site = "none"
        empresa = "none"
        cat = "none"
        qsection = "all"

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If CheckBox_obra.Checked Or CheckBox_empresa.Checked Or CheckBox_cat.Checked Then
            translations.load("attendance")
            If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
                site = "none"
            ElseIf siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-1) Then 'ALL
                site = "all"
            ElseIf Not CheckBox_obra.Checked Then
                site = "none"
            Else
                site = siteSelection(combo_site.SelectedIndex - 1, 0)
            End If
            If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
                qsection = "none"
            ElseIf siteSelection(combo_site.SelectedIndex - 1, 1).Equals(-1) Then
                qsection = "all"
            ElseIf Not CheckBox_obra.Checked Then
                qsection = "none"
            Else
                qsection = siteSelection(combo_site.SelectedIndex - 1, 1)
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
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "report")
        vars.Add("empresa", empresa)
        vars.Add("site", site)
        vars.Add("cat", cat)
        vars.Add("section", qsection)
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

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
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)

            Exit Sub
        End If
        translations.load("busyMessages")
        MainMdiForm.statusMessage = translations.getText("loadingTable")
        translations.load("commonForm")

        Dim err As Boolean = False
        Dim fields As String()

        If resume_type.SelectedIndex.Equals(1) Then
            fields = state.queryReportMonthly
        Else
            fields = state.queryReportDetailed
        End If
        works_worker = request.ConvertDataToArray("report", fields, response)
        If IsNothing(works_worker) Then
            err = True
        End If

        If err Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1
            datatable.Rows.Clear()
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(request.errorMessage), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)

            Exit Sub
        End If

        If works_worker.Item("cod_worker").Count < 1 Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("errorMessages")
            Dim message = translations.getText("errorNoRecordsFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mask.Dispose()
            enableButtonsAndLinks(Me, True)

            Exit Sub
        End If

        translations.load("attendance")
        If relatorio_tipo.Equals(translations.getText("reportMonthly")) Then 'tipos de relatorio: Resumo mensal de presenças; Relatório mensal de presenças detalhado; Relatório mensal de presenças detalhado por obra
            relatorio_resumo()
        ElseIf relatorio_tipo.Equals(translations.getText("reportMonthltyDetailed")) Or relatorio_tipo.Equals(translations.getText("reportMonthltyDetailedBySite")) Then
            relatorio_detalhado()
        Else
            relatorio_resumo()
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        enableButtonsAndLinks(Me, True)

    End Sub

    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded
    End Sub

    Sub relatorio_resumo()
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim cell_size As Integer = 50 '(datatable.Width - 400) / (works_site.GetLength(0))
        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0
        Dim query As String
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        ReDim idxTableWorkerPos(works_worker.Item("cod_worker").Count)

        translations.load("commonForm")
        SuspendLayout()

        With datatable
            .Visible = False

            .RowHeadersVisible = False
            .ColumnCount = 2 * works_site.Item("cod_site").Count + 12

            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
            .Columns(0).Width = 300

            translations.load("attendance")
            .Columns(1).HeaderCell.Value = translations.getText("tableHeaderDaysTotal")
            .Columns(1).Width = cell_size + 30

            For i = 0 To works_site.Item("cod_site").Count - 1
                .Columns(i + 2).HeaderCell.Value = works_site.Item("initials")(i).ToUpper
                .Columns(i + 2).Width = cell_size
            Next i

            .Columns(works_site.Item("cod_site").Count + 2).HeaderCell.Value = ""
            .Columns(works_site.Item("cod_site").Count + 2).Width = cell_size
            .Columns(works_site.Item("cod_site").Count + 2).DefaultCellStyle.BackColor = Color.Black
            .Columns(works_site.Item("cod_site").Count + 2).Width = 30

            .Columns(works_site.Item("cod_site").Count + 3).HeaderCell.Value = translations.getText("tableHeaderHoursTotal")
            .Columns(works_site.Item("cod_site").Count + 3).Width = cell_size + 10

            For i = 0 To works_site.Item("cod_site").Count - 1
                .Columns(works_site.Item("cod_site").Count + 4 + i).HeaderCell.Value = works_site.Item("initials")(i).ToUpper
                .Columns(works_site.Item("cod_site").Count + 4 + i).Width = cell_size
            Next i

            .Columns(2 * works_site.Item("cod_site").Count + 4).HeaderCell.Value = ""
            .Columns(2 * works_site.Item("cod_site").Count + 4).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 4).DefaultCellStyle.BackColor = Color.Black
            .Columns(2 * works_site.Item("cod_site").Count + 4).Width = 30

            .Columns(2 * works_site.Item("cod_site").Count + 5).HeaderCell.Value = "A"
            .Columns(2 * works_site.Item("cod_site").Count + 5).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 6).HeaderCell.Value = "V"
            .Columns(2 * works_site.Item("cod_site").Count + 6).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 7).HeaderCell.Value = "I"
            .Columns(2 * works_site.Item("cod_site").Count + 7).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 8).HeaderCell.Value = "C"
            .Columns(2 * works_site.Item("cod_site").Count + 8).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 9).HeaderCell.Value = "M"
            .Columns(2 * works_site.Item("cod_site").Count + 9).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 10).HeaderCell.Value = "FA"
            .Columns(2 * works_site.Item("cod_site").Count + 10).Width = cell_size
            .Columns(2 * works_site.Item("cod_site").Count + 11).HeaderCell.Value = "FI"
            .Columns(2 * works_site.Item("cod_site").Count + 11).Width = cell_size

            .Rows.Clear()
            .RowCount = 500

            Dim rowpos As Integer = 0
            Dim spaces As Boolean = False

            '"cod_worker", "name", "contact", "cod_nfc", "cod_category", "cod_entreprise"
            If CheckBox_empresa.Checked Then
                .Rows(rowpos).Cells(0).Value = "" & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(0), "cod_entreprise"))
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorCompany
                rowpos = rowpos + 1
            End If

            If CheckBox_cat.Checked Then
                .Rows(rowpos).Cells(0).Value = " " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(0), "cod_category"))
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorWorkCategories
                rowpos = rowpos + 1

            End If

            For i = 0 To works_worker.Item("cod_worker").Count - 1
                If i > 0 Then
                    If CheckBox_empresa.Checked Then
                        If works_worker.Item("cod_entreprise")(i) <> works_worker.Item("cod_entreprise")(i - 1) Or spaces Then
                            translations.load("attendance")
                            .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsCompany")
                            .Rows(rowpos).DefaultCellStyle = BoldRow
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                            rowpos = rowpos + 1

                            .Rows(rowpos).Cells(0).Value = "" & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(i), "cod_entreprise"))
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorCompany
                            rowpos = rowpos + 1
                            spaces = True
                        End If
                    End If

                    If CheckBox_cat.Checked Then
                        If works_worker.Item("cod_category")(i) <> works_worker.Item("cod_category")(i - 1) Or spaces Then
                            .Rows(rowpos).Cells(0).Value = " " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(i), "cod_category"))
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorWorkCategories
                            rowpos = rowpos + 1
                            spaces = False
                        End If
                    End If

                End If
                idxTableWorkerPos(i) = rowpos
                .Rows(rowpos).Cells(0).Value = "   " & works_worker.Item("name")(i)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                rowpos = rowpos + 1
                spaces = False
            Next i
            If CheckBox_empresa.Checked Then
                translations.load("attendance")
                .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsCompany")
                .Rows(rowpos).DefaultCellStyle = BoldRow
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                rowpos = rowpos + 1
            End If

            translations.load("commonForm")
            Dim loadingTxt As String = translations.getText("loading")
            Dim ofTxt As String = translations.getText("of")
            translations.load("attendance")

            query = ""
            For i = 0 To works_worker.Item("cod_worker").Count - 1
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.setMessage(loadingTxt & " " & (i + 1) & " " & ofTxt & " " & works_worker.Item("cod_worker").Count)
                    End If
                End If

                Dim vars As New Dictionary(Of String, String)
                vars.Add("task", "6")
                vars.Add("request", "record")
                vars.Add("site", "all")
                vars.Add("section", "all")
                vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
                vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & num_days.ToString())
                vars.Add("worker", works_worker.Item("cod_worker")(i))

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
                    translations.load("messagebox")
                    msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    mask.Dispose()
                    Refresh()
                    Exit Sub
                End If

                works_register = request.ConvertDataToArray("record", state.queryAttendanceRecords, response)
                If IsNothing(works_register) Then
                    Continue For
                End If

                '"checkin", "checkout", "date", "status", "absense", "notas", "cod_site", "cod_section"
                For j = 0 To works_register.Item("checkin").Count - 1
                    If works_register.Item("status")(j).Equals("P") Then
                        .Rows(idxTableWorkerPos(i)).Cells(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2).Value += 1

                    ElseIf works_register.Item("status")(j).Equals("PI") Then
                        'adicionar mais um dia de trabalho
                        .Rows(idxTableWorkerPos(i)).Cells(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site") + 2).Value += 1

                        ' adicionar horas que faltou
                        Dim stime, etime As TimeSpan
                        Dim ftime As TimeSpan

                        If (IsNothing(.Rows(idxTableWorkerPos(i)).Cells(works_site.Item("cod_site").Count + 4 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).Value)) Then
                            .Rows(idxTableWorkerPos(i)).Cells(works_site.Item("cod_site").Count + 4 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).Value = works_register.Item("absense")(j).Substring(0, 5).Replace(":", "H")
                        Else
                            Dim sw0 As String = .Rows(idxTableWorkerPos(i)).Cells(works_site.Item("cod_site").Count + 3 + InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).Value.ToString.Replace("H", ":") & ":00"
                            Dim hours0 = sw0.Substring(0, 2)
                            Dim minutes0 = sw0.Substring(3, 2)
                            Dim totalSeconds0 = CInt(hours0) * 60 * 60 + CInt(minutes0) * 60

                            stime = TimeSpan.FromSeconds(totalSeconds0)
                            etime = TimeSpan.Parse(works_register.Item("absense")(j))
                            ftime = stime + etime
                            .Rows(idxTableWorkerPos(i)).Cells(works_site.Item("cod_site").Count + 4).Value = ftime.ToString().Substring(0, 5).Replace(":", "H")
                        End If

                    ElseIf works_register.Item("status")(j).Equals("A") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 5).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("V") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 6).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("I") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 7).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("C") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 8).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("M") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 9).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("FA") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 10).Value += 1
                    ElseIf works_register.Item("status")(j).Equals("FI") Then
                        .Rows(idxTableWorkerPos(i)).Cells(2 * works_site.Item("cod_site").Count + 11).Value += 1
                    End If

                Next j
            Next i
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            .RowCount = rowpos + 1
            translations.load("commonForm")
            Dim tableRowTotalString As String = translations.getText("tableRowTotal")
            .Rows(rowpos).Cells(0).Value = translations.getText("tableRowTotal")
            .Rows(rowpos).DefaultCellStyle = BoldRow
            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight

            Dim counter As Integer = 0
            translations.load("attendance")
            For i = 2 To 1 + works_site.Item("cod_site").Count
                counter = 0
                For j = 0 To works_worker.Item("cod_worker").Count - 1
                    If Not IsNothing(.Rows(idxTableWorkerPos(j)).Cells(i).Value) Then
                        .Rows(idxTableWorkerPos(j)).Cells(1).Value += .Rows(idxTableWorkerPos(j)).Cells(i).Value
                        counter += .Rows(idxTableWorkerPos(j)).Cells(i).Value
                    End If
                Next j
                .Rows(rowpos).Cells(i).Value = counter.ToString()
            Next i

            Dim counterCompany As Integer = 0
            counter = 0
            For i = 1 To 1 + works_site.Item("cod_site").Count
                counterCompany = 0
                counter = 0
                For j = 0 To rowpos - 1
                    If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Then
                        .Rows(j).Cells(i).Value = counterCompany
                        counterCompany = 0
                    ElseIf Not IsNothing(.Rows(j).Cells(i).Value) Then
                        counterCompany += .Rows(j).Cells(i).Value
                        counter += .Rows(j).Cells(i).Value
                    End If
                Next j
                .Rows(rowpos).Cells(i).Value = counter.ToString()
            Next i

            'totals in hours of absense in column
            Dim counterTime, counterTimeCompany, counterTimeGlobalTotals As TimeSpan
            For i = works_site.Item("cod_site").Count + 4 To 2 * works_site.Item("cod_site").Count + 3
                counterTime = TimeSpan.Parse("00:00:00")
                counterTimeCompany = TimeSpan.Parse("00:00:00")
                Dim counterTimeCompanyTotals As TimeSpan = TimeSpan.Parse("00:00:00")
                counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")

                For j = 0 To rowpos
                    If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("tableRowTotal")) Then
                        If counterTimeGlobalTotals.ToString().IndexOf(".") > -1 Then
                            Dim dc As Integer = counterTimeCompany.ToString().Substring(0, counterTimeCompany.ToString().IndexOf("."))
                            .Rows(j).Cells(i).Value = (dc * 24 + CInt(counterTimeGlobalTotals.Hours.ToString())).ToString() & "H" & If(counterTimeGlobalTotals.Minutes < 10, "0", "") & counterTimeGlobalTotals.Minutes.ToString()
                        Else
                            .Rows(j).Cells(i).Value = counterTimeGlobalTotals.ToString().Substring(0, 5).Replace(":", "H")
                        End If
                        counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")

                    ElseIf .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Then
                        Dim tmp1 As TimeSpan = TimeSpan.Parse("00:00:00")
                        Dim sw1 = If(IsNothing(.Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value), "00:00:00", .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value.ToString.Replace("H", ":"))
                        Dim hours1 = sw1.Substring(0, 2)
                        Dim minutes1 = sw1.Substring(3, 2)
                        Dim totalSeconds1 = CInt(hours1) * 60 * 60 + CInt(minutes1) * 60
                        counterTimeCompanyTotals += TimeSpan.FromSeconds(totalSeconds1)
                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = counterTimeCompanyTotals.ToString
                        counterTimeCompanyTotals = TimeSpan.Parse("00:00:00")

                        If counterTimeCompany.ToString().IndexOf(".") > -1 Then
                            Dim dc As Integer = counterTimeCompany.ToString().Substring(0, counterTimeCompany.ToString().IndexOf("."))
                            .Rows(j).Cells(i).Value = (dc * 24 + CInt(counterTimeCompany.Hours.ToString())).ToString() & "H" & If(counterTimeCompany.Minutes < 10, "0", "") & counterTimeCompany.Minutes.ToString()
                        Else
                            .Rows(j).Cells(i).Value = counterTimeCompany.ToString().Substring(0, 5).Replace(":", "H")
                        End If
                        counterTimeCompany = TimeSpan.Parse("00:00:00")
                    ElseIf Not IsNothing(.Rows(j).Cells(i).Value) AndAlso .Rows(j).Cells(i).Value.ToString().IndexOf("H") > -1 Then
                        Dim tmp3 As TimeSpan = TimeSpan.Parse("00:00:00")
                        Dim sw3 = If(IsNothing(.Rows(j).Cells(i).Value), "00:00:00", .Rows(j).Cells(i).Value.ToString.Replace("H", ":"))
                        Dim hours3 = sw3.Substring(0, 2)
                        Dim minutes3 = sw3.Substring(3, 2)
                        Dim totalSeconds3 = CInt(hours3) * 60 * 60 + CInt(minutes3) * 60
                        tmp3 = TimeSpan.FromSeconds(totalSeconds3)

                        counterTime += tmp3
                        counterTimeCompany += tmp3

                        Dim tmp2 As TimeSpan = TimeSpan.Parse("00:00:00")
                        Dim sw2 = If(IsNothing(.Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value), "00:00:00", .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value)
                        Dim hours2 = sw2.Substring(0, 2)
                        Dim minutes2 = sw2.Substring(3, 2)
                        Dim totalSeconds2 = CInt(hours2) * 60 * 60 + CInt(minutes2) * 60 + CInt(hours3) * 60 * 60 + CInt(minutes3) * 60
                        Dim TotalInLineTimeTmp As TimeSpan = TimeSpan.FromSeconds(totalSeconds2)

                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = TotalInLineTimeTmp.ToString
                    End If
                Next j
                If counterTime.ToString().IndexOf(".") > -1 Then
                    Dim d As Integer = counterTime.ToString().Substring(0, counterTime.ToString().IndexOf("."))
                    .Rows(rowpos).Cells(i).Value = (d * 24 + CInt(counterTime.Hours.ToString())).ToString() & "H" & If(counterTime.Minutes < 10, "0", "") & counterTime.Minutes.ToString()
                Else
                    .Rows(rowpos).Cells(i).Value = counterTime.ToString().Substring(0, 5).Replace(":", "H")
                End If
            Next i

            'convert to 24++ time the totals column
            counterTimeGlobalTotals = TimeSpan.Parse("00:00:00")
            For j = 0 To rowpos
                If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Or .Rows(j).Cells(0).Value.ToString.Equals(tableRowTotalString) Then
                    Dim tmp4 As TimeSpan = TimeSpan.Parse("00:00:00")
                    For i = works_site.Item("cod_site").Count + 4 To 2 * works_site.Item("cod_site").Count + 3
                        Dim sw4 = If(IsNothing(.Rows(j).Cells(i).Value), "00:00:00", .Rows(j).Cells(i).Value.ToString.Replace("H", ":"))
                        Dim hours4 = sw4.Substring(0, 2)
                        Dim minutes4 = sw4.Substring(3, 2)
                        Dim totalSeconds4 = CInt(hours4) * 60 * 60 + CInt(minutes4) * 60
                        tmp4 += TimeSpan.FromSeconds(totalSeconds4)
                    Next i
                    If tmp4.ToString().IndexOf(".") > -1 Then
                        Dim dc4 As Integer = tmp4.ToString().Substring(0, tmp4.ToString().IndexOf("."))
                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = (dc4 * 24 + CInt(tmp4.Hours.ToString())).ToString() & "H" & If(tmp4.Minutes < 10, "0", "") & tmp4.Minutes.ToString()
                    Else
                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = tmp4.ToString().Substring(0, 5).Replace(":", "H")
                    End If
                ElseIf Not IsNothing(.Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value) Then
                    Dim tmp5 As TimeSpan = TimeSpan.Parse("00:00:00")
                    Dim sw5 = If(IsNothing(.Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value), "00:00:00", .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value.ToString.Replace("H", ":"))
                    Dim hours5 = sw5.Substring(0, 2)
                    Dim minutes5 = sw5.Substring(3, 2)
                    Dim totalSeconds5 = CInt(hours5) * 60 * 60 + CInt(minutes5) * 60
                    tmp5 = TimeSpan.FromSeconds(totalSeconds5)
                    If tmp5.ToString().IndexOf(".") > -1 Then
                        Dim dc5 As Integer = tmp5.ToString().Substring(0, tmp5.ToString().IndexOf("."))
                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = (dc5 * 24 + CInt(tmp5.Hours.ToString())).ToString() & "H" & If(tmp5.Minutes < 10, "0", "") & tmp5.Minutes.ToString()
                    Else
                        .Rows(j).Cells(works_site.Item("cod_site").Count + 3).Value = tmp5.ToString().Substring(0, 5).Replace(":", "H")
                    End If
                End If
            Next j

            .Visible = True

        End With
        ResumeLayout()
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
        currentDatatable = datatable
        mask.Dispose()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Sub relatorio_detalhado()
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)
        Dim cell_size As Integer = (datatable.Width - 400) / num_days
        cell_size = If(cell_size < sizeOfString.Width, sizeOfString.Width, cell_size)

        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0
        Dim sitesPos As Integer = 0
        Dim query As String
        Dim Siteinitials, sites As String()

        ReDim Siteinitials(1)
        Dim pos As Integer = 0

        For i = 0 To works_site.Item("cod_site").Count - 1
            If (Not works_site.Item("initials")(i).Equals("")) Then
                ReDim Preserve Siteinitials(pos)
                Siteinitials(pos) = works_site.Item("initials")(i)
                pos = pos + 1
            End If
        Next i
        ReDim sites(UBound(Siteinitials))

        ReDim idxTableWorkerPos(works_worker.Item("cod_worker").Count)

        translations.load("commonForm")


        SuspendLayout()
        With datatable
            .Visible = False
            .RowHeadersVisible = False
            .ColumnCount = num_days + 2

            translations.load("commonForm")
            .Columns(0).HeaderCell.Value = translations.getText("tableHeaderName")
            .Columns(0).Width = 300
            For i = 1 To num_days
                .Columns(i).HeaderCell.Value = i.ToString()
                .Columns(i).Width = cell_size
                .Columns(i).DefaultCellStyle.BackColor = Color.White

            Next i
            translations.load("commonForm")
            .Columns(num_days + 1).HeaderCell.Value = translations.getText("tableRowTotal")
            .Rows.Clear()
            .RowCount = 500

            'weekends
            For i = 1 To num_days
                If Not IsWeekday(calendar_log.Value.Date.ToString("yyyy/MM") & "/" & i.ToString()) Then
                    .Columns(i).DefaultCellStyle.BackColor = state.colorWeekends
                End If
            Next i

            Dim rowpos As Integer = 0
            Dim enableSpaces As Boolean = False
            Dim spaces As String = ""

            If CheckBox_obra.Checked Then

                .Rows(rowpos).Cells(0).Value = works_site.Item("name")(InQueryDictionary(works_site, works_worker.Item("cod_site")(0), "cod_site"))
                sites(sitesPos) = works_site.Item("initials")(InQueryDictionary(works_site, works_worker.Item("cod_site")(0), "cod_site"))
                sitesPos = sitesPos + 1
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorSite
                rowpos = rowpos + 1
                .Rows(rowpos).Cells(0).Value = " " & works_sections.Item("description")(InQueryDictionary(works_sections, works_worker.Item("cod_section")(0), "cod_section"))
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorSection
                rowpos = rowpos + 1
            End If
            If CheckBox_empresa.Checked Then
                .Rows(rowpos).Cells(0).Value = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(0), "cod_entreprise"))
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorCompany
                rowpos = rowpos + 1
            End If

            If CheckBox_cat.Checked Then
                .Rows(rowpos).Cells(0).Value = "   " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(0), "cod_category"))
                .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                .Rows(rowpos).DefaultCellStyle.BackColor = state.colorWorkCategories
                rowpos = rowpos + 1
            End If

            Dim counter As Integer = 0
            Dim counter2 As Integer = 0
            Dim counter3 As Integer = 0
            Dim counter_t(2) As Integer
            counter_t(1) = 0
            query = ""
            Dim last As String = ""

            query = ""
            translations.load("commonForm")
            Dim loadingTxt As String = translations.getText("loading")
            Dim ofTxt As String = translations.getText("of")
            translations.load("attendance")

            'worker.cod_worker, worker.name, worker.contact, worker.cod_nfc, worker.cod_category, worker.cod_entreprise, teams.cod_site, teams.cod_section
            For i = 0 To works_worker.Item("cod_worker").Count - 1
                If i > 1 Then
                    If CheckBox_obra.Checked Then
                        If works_worker.Item("cod_site")(i) <> works_worker.Item("cod_site")(i - 1) Then
                            enableSpaces = True
                        End If
                    End If
                    If CheckBox_empresa.Checked And combo_company.SelectedIndex = works_entreprise.Item("cod_entreprise").Count Then
                        If works_worker.Item("cod_entreprise")(i) <> works_worker.Item("cod_entreprise")(i - 1) Or enableSpaces Then
                            translations.load("attendance")
                            .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsCompany")
                            .Rows(rowpos).DefaultCellStyle = BoldRow
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                            rowpos = rowpos + 1
                        End If
                    End If


                    If CheckBox_obra.Checked And siteSelection(combo_site.SelectedIndex - 1, 1).Equals(-1) Then 'all sections
                        If works_worker.Item("cod_section")(i) <> works_worker.Item("cod_section")(i - 1) Then
                            translations.load("attendance")
                            .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsSection")
                            .Rows(rowpos).DefaultCellStyle = BoldRow
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                            rowpos = rowpos + 1
                        End If
                    End If
                    If CheckBox_obra.Checked And combo_site.SelectedIndex.Equals(siteSelection.Length - 1) Then ' all sites
                        If works_worker.Item("cod_site")(i) <> works_worker.Item("cod_site")(i - 1) Then
                            translations.load("attendance")
                            .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsSite")
                            .Rows(rowpos).DefaultCellStyle = BoldRow
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                            rowpos = rowpos + 1
                        End If
                    End If

                    If CheckBox_obra.Checked Then
                        If works_worker.Item("cod_site")(i) <> works_worker.Item("cod_site")(i - 1) Then
                            .Rows(rowpos).Cells(0).Value = works_site.Item("name")(InQueryDictionary(works_site, works_worker.Item("cod_site")(i), "cod_site"))
                            sites(sitesPos) = works_site.Item("initials")(InQueryDictionary(works_site, works_worker.Item("cod_site")(i), "cod_site"))
                            sitesPos = sitesPos + 1
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorSite
                            rowpos = rowpos + 1

                            enableSpaces = True
                        End If
                        If works_worker.Item("cod_section")(i) <> works_worker.Item("cod_section")(i - 1) Or enableSpaces Then
                            .Rows(rowpos).Cells(0).Value = " " & works_sections.Item("description")(InQueryDictionary(works_sections, works_worker.Item("cod_section")(i), "cod_section"))
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorSection
                            rowpos = rowpos + 1
                            enableSpaces = True
                        End If
                    End If
                    If CheckBox_empresa.Checked Then
                        If works_worker.Item("cod_entreprise")(i) <> works_worker.Item("cod_entreprise")(i - 1) Or enableSpaces Then
                            .Rows(rowpos).Cells(0).Value = "  " & works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item("cod_entreprise")(i), "cod_entreprise"))
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorCompany
                            rowpos = rowpos + 1
                            enableSpaces = True
                        End If
                    End If

                    If CheckBox_cat.Checked Then
                        If works_worker.Item("cod_category")(i) <> works_worker.Item("cod_category")(i - 1) Or enableSpaces Then
                            .Rows(rowpos).Cells(0).Value = "   " & works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(i), "cod_category"))
                            .Rows(rowpos).Cells(0).Style.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
                            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                            .Rows(rowpos).DefaultCellStyle.BackColor = state.colorWorkCategories
                            rowpos = rowpos + 1
                        End If
                    End If
                End If
                idxTableWorkerPos(i) = rowpos
                .Rows(rowpos).Cells(0).Value = "    " & works_worker.Item("name")(i)
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                rowpos = rowpos + 1
                enableSpaces = False



                Dim vars As New Dictionary(Of String, String)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.setMessage(loadingTxt & " " & (i + 1) & " " & ofTxt & " " & works_worker.Item("cod_worker").Count)
                    End If
                End If
                vars.Add("task", "6")
                vars.Add("request", "record")

                vars.Add("site", works_worker.Item("cod_site")(i))
                vars.Add("section", works_worker.Item("cod_section")(i))
                vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
                vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & num_days.ToString())
                vars.Add("worker", works_worker.Item("cod_worker")(i))

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
                    translations.load("messagebox")
                    msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    mask.Dispose()
                    Refresh()
                    Exit Sub
                End If

                works_register = request.ConvertDataToArray("record", state.queryAttendanceRecords, response)
                If IsNothing(works_register) Then
                    Continue For
                End If

                If works_register.Item("checkin").Count < 1 Then
                    Continue For
                End If

                '"checkin", "checkout", "date", "status", "absense", "notas", "cod_site", "cod_section"
                translations.load("attendance")
                For j = 0 To works_register.Item("checkin").Count - 1
                    day = DateTime.Parse(works_register.Item("date")(j)).Day

                    If .Rows(idxTableWorkerPos(i)).Cells(day).Value <> "" Then ' duplicate found
                        .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = Color.Red
                    End If
                    If relatorio_tipo.Equals(translations.getText("reportMonthltyDetailed")) Then
                        If works_register.Item("status")(j).Equals("P") Then
                            .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorFullDayValidated
                            .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_register.Item("status")(j)
                        ElseIf Not works_register.Item("status")(j).Equals("") And Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                            .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorAbsentDay
                            If Not works_register.Item("status")(j).Equals("PI") And Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                                .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_register.Item("status")(j)
                            Else
                                .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorPartialDayValidated
                                .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_register.Item("absense")(j).Substring(0, 5).Replace(":", "H")
                            End If
                        End If

                        If ((works_register.Item("checkin")(j) <> "" And works_register.Item("checkin")(j) <> "00:00:00") Or (works_register.Item("checkout")(j) <> "" And works_register.Item("checkout")(j) <> "00:00:00")) And (works_register.Item("status")(j) = "" Or works_register.Item("status")(j) = "EP" Or works_register.Item("status")(j) = "MO") Then
                            .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorWithRecord
                            If Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                                .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_register.Item("status")(j)
                            End If
                        End If
                    Else ' Relatório mensal de presenças detalhado por obra
                        If works_register.Item("status")(j).Equals("P") Then
                            .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorFullDayValidated
                            .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_site.Item("initials")(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).ToUpper
                        ElseIf Not works_register.Item("status")(j).Equals("") And Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                            .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorAbsentDay
                            If Not works_register.Item("status")(j).Equals("PI") And Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                                .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_site.Item("initials")(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).ToUpper
                            ElseIf Not works_register.Item("status")(j).Equals("") And Not works_register.Item("status")(j).Equals("EP") And Not works_register.Item("status")(j).Equals("MO") Then
                                .Rows(idxTableWorkerPos(i)).Cells(day).Style.BackColor = state.colorPartialDayValidated
                                .Rows(idxTableWorkerPos(i)).Cells(day).Value = works_site.Item("initials")(InQueryDictionary(works_site, works_register.Item("cod_site")(j), "cod_site")).ToUpper
                            End If
                        End If
                    End If
                Next j
                ' totais do mes por homem - horizontal
                counter = 0
                If CheckBox_obra.Checked Then
                    last = works_worker.Item("cod_site")(i)
                End If

                For j = 1 To num_days
                    If Not IsNothing(.Rows(idxTableWorkerPos(i)).Cells(j).Value) Then
                        If .Rows(idxTableWorkerPos(i)).Cells(j).Value = "P" Or .Rows(idxTableWorkerPos(i)).Cells(j).Value.ToString().IndexOf("H") > 0 Or (Not .Rows(idxTableWorkerPos(i)).Cells(j).Value = "" And Array.IndexOf(Siteinitials, .Rows(idxTableWorkerPos(i)).Cells(j).Value) > -1) Then
                            If CheckBox_obra.Checked And relatorio_tipo.Equals(translations.getText("reportMonthltyDetailedBySite")) Then
                                Dim s = .Rows(idxTableWorkerPos(i)).Cells(j).Value
                                Dim ss = sites(sitesPos - 1)
                                Dim sss = sites
                                If .Rows(idxTableWorkerPos(i)).Cells(j).Value = sites(sitesPos - 1) And (.Rows(idxTableWorkerPos(i)).Cells(j).Style.BackColor.Equals(state.colorFullDayValidated) Or .Rows(idxTableWorkerPos(i)).Cells(j).Style.BackColor.Equals(state.colorPartialDayValidated)) Then
                                    counter = counter + 1
                                End If
                            Else
                                counter = counter + 1
                            End If
                        End If
                    End If
                Next j
                .Rows(idxTableWorkerPos(i)).Cells(num_days + 1).Value = counter.ToString()
                counter_t(1) = counter_t(1) + counter

            Next i



            If CheckBox_empresa.Checked And combo_company.SelectedIndex = works_entreprise.Item("cod_entreprise").Count Then
                translations.load("attendance")
                .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsCompany")
                .Rows(rowpos).DefaultCellStyle = BoldRow
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                rowpos = rowpos + 1
            End If
            If CheckBox_obra.Checked And siteSelection(combo_site.SelectedIndex - 1, 1).Equals(-1) Then 'all sections
                translations.load("attendance")
                .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsSection")
                .Rows(rowpos).DefaultCellStyle = BoldRow
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                rowpos = rowpos + 1
            End If
            If CheckBox_obra.Checked And combo_site.SelectedIndex = works_site.Item("cod_site").Count Then
                translations.load("attendance")
                .Rows(rowpos).Cells(0).Value = translations.getText("reportTotalsSite")
                .Rows(rowpos).DefaultCellStyle = BoldRow
                .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight
                rowpos = rowpos + 1
            End If

            .RowCount = rowpos + 1
            translations.load("commonForm")
            .Rows(rowpos).Cells(0).Value = translations.getText("tableRowTotal")
            .Rows(rowpos).DefaultCellStyle = BoldRow
            .Rows(rowpos).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomRight


            translations.load("attendance")
            counter_t(2) = 0
            Dim posSites As Integer = 0
            ' counting per worker at end of month na vertical
            For i = 1 To num_days
                counter = 0
                posSites = 0
                If CheckBox_obra.Checked Then
                    last = works_worker.Item("cod_site")(0)
                End If
                For j = 0 To works_worker.Item("cod_worker").Count - 1
                    If CheckBox_obra.Checked Then
                        If Not works_worker.Item("cod_site")(j).Equals(last) Then
                            posSites = posSites + 1
                            last = works_worker.Item("cod_site")(j)
                        End If
                    End If
                    If Not IsNothing(.Rows(idxTableWorkerPos(j)).Cells(i).Value) Then
                        If .Rows(idxTableWorkerPos(j)).Cells(i).Value = "P" Or .Rows(idxTableWorkerPos(j)).Cells(i).Value.ToString().IndexOf("H") > 0 Or Array.IndexOf(Siteinitials, .Rows(idxTableWorkerPos(j)).Cells(i).Value) > -1 Then
                            If CheckBox_obra.Checked And relatorio_tipo.Equals(translations.getText("reportMonthltyDetailedBySite")) Then
                                If .Rows(idxTableWorkerPos(j)).Cells(i).Value = sites(posSites) And (.Rows(idxTableWorkerPos(j)).Cells(i).Style.BackColor.Equals(state.colorFullDayValidated) Or .Rows(idxTableWorkerPos(j)).Cells(i).Style.BackColor.Equals(state.colorPartialDayValidated)) Then
                                    counter = counter + 1
                                End If
                            Else
                                counter = counter + 1
                            End If
                        End If
                    End If
                Next j
                .Rows(rowpos).Cells(i).Value = If(counter.Equals(0), "", counter.ToString())
                counter_t(2) = counter_t(2) + counter
            Next i
            .Rows(rowpos).Cells(num_days + 1).Value = counter_t(1).ToString() & "(" & counter_t(2).ToString() & ")"

            'counting all workers per day 
            If CheckBox_obra.Checked Or CheckBox_empresa.Checked Then
                translations.load("attendance")

                For i = 1 To num_days
                    counter = 0
                    posSites = 0
                    counter2 = 0
                    counter3 = 0
                    For j = 1 To rowpos - 1
                        If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsSite")) Or .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Or .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsSection")) Then
                            If .Rows(j).Cells(0).Value.ToString = "Total Obra" Then
                                .Rows(j).Cells(i).Value = If(counter.Equals(0), "", counter.ToString())
                                counter = 0
                            End If
                            If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Then
                                .Rows(j).Cells(i).Value = If(counter2.Equals(0), "", counter2.ToString())
                                counter2 = 0
                            End If
                            If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsSection")) Then
                                .Rows(j).Cells(i).Value = If(counter3.Equals(0), "", counter3.ToString())
                                counter3 = 0
                            End If
                        ElseIf Not IsNothing(.Rows(j).Cells(i).Value) AndAlso (.Rows(j).Cells(i).Value = "P" Or .Rows(j).Cells(i).Value.ToString().IndexOf("H") > 0 Or (Not .Rows(j).Cells(i).Value = "" And Array.IndexOf(Siteinitials, .Rows(j).Cells(i).Value) > -1)) Then
                            If CheckBox_obra.Checked And relatorio_tipo.Equals(translations.getText("reportMonthltyDetailedBySite")) Then
                                If .Rows(j).Cells(i).Value = sites(posSites) And (.Rows(j).Cells(i).Style.BackColor.Equals(state.colorFullDayValidated) Or .Rows(j).Cells(i).Style.BackColor.Equals(state.colorPartialDayValidated)) Then
                                    counter = counter + 1
                                    counter2 = counter2 + 1
                                    counter3 = counter3 + 1

                                End If
                            Else
                                counter = counter + 1
                                counter2 = counter2 + 1
                                counter3 = counter3 + 1
                            End If
                        End If
                        If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsSite")) Then
                            posSites = posSites + 1
                        End If
                    Next j
                Next i
                For j = 1 To rowpos - 1
                    If .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsCompany")) Or .Rows(j).Cells(0).Value.ToString.Equals(translations.getText("reportTotalsSite")) Then
                        counter = 0
                        For i = 1 To num_days
                            counter = counter + If(.Rows(j).Cells(i).Value.ToString().Equals(""), 0, .Rows(j).Cells(i).Value)
                        Next i
                        .Rows(j).Cells(num_days + 1).Value = If(counter.Equals(0), "", counter.ToString())

                    End If
                Next j
            End If
            .Visible = True

        End With
        ResumeLayout()
        mask.Dispose()
        Refresh()

        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")
        currentDatatable = datatable
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub


End Class