Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class team_frm

    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations

    Public works_worker, works_team, works_sections, query_bordereau As Dictionary(Of String, List(Of String))

    Private sectionsIndex As Integer()
    Private isLoading As Boolean = False
    Private response As String = ""
    Dim mask As PictureBox
    Private WithEvents bwSites As BackgroundWorker
    Dim loaded As Boolean = False

    Public idxTableWorkerPos As Integer()


    Dim holidays As DateTime() = Nothing
    Dim absense As Integer(,) = Nothing
    Dim record As Integer(,) = Nothing



    Public Shared serverData As workersJson(,)
    Public Shared AttendanceTable As String(,)

    Public Shared cellX As Integer = -1
    Public Shared CellY As Integer = -1
    Public Shared calendar As MonthCalendar
    Public Shared activeTable As String = ""
    Public Shared works_site, works_cat, transportsDB As Dictionary(Of String, List(Of String))
    Private siteSelection As Integer(,)

    Private WithEvents bwTables As BackgroundWorker

    Private cell_size As Integer
    Private num_days As Integer
    Private rowpos As Integer
    Private numRows As Integer

    Public Structure workersJson
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
        Public assignments As String
        Public foreman As Boolean
        Public duplicateRecords As String

    End Structure

    Dim Listview_teams As ListBox

    Private Sub CloseMe()
        Me.Close()
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
        Me.WindowState = FormWindowState.Maximized
        SetDoubleBuffered(teams_datatable)

        Me.Refresh()

    End Sub

    Private Sub team_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
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

        Me.SuspendLayout()

        teams_title_text.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)

        divider.BackColor = state.dividerColor

        GroupBoxSiteSelection.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        workers_group.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxWorkerAssignments.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        workersListBox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        searchTitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar_log.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        teams_datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        teams_datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)


        translations.load("commonForm")
        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(workersUpdateBtn, translations.getText("updateLink"))
        GroupBoxSiteSelection.Text = translations.getText("groupBoxSite")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        Dim removeWorkerToolTip As New ToolTip()
        removeWorkerToolTip.SetToolTip(removeWorkerBtn, translations.getText("removeLink"))
        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(tableSettingsBtn, translations.getText("settingsLink"))
        Dim SearchToolTip As New ToolTip()
        SearchToolTip.SetToolTip(loadTableDataBtn, translations.getText("searchParametersLink"))

        translations.load("teamsPlanning")
        workers_group.Text = translations.getText("workers")
        teams_title_text.Text = translations.getText("teamsTitle")
        groupBoxWorkerAssignments.Text = translations.getText("selectedWorkerResponsabilitiesAssigned")
        workerSelectionTasks.Text = translations.getText("selectWorker")

        Dim addWorkerToolTip As New ToolTip()
        addWorkerToolTip.SetToolTip(addWorkerBtn, translations.getText("add"))
        Dim copyToolTip As New ToolTip()
        copyToolTip.SetToolTip(copyTeamsBtn, translations.getText("copy"))

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        Dim width = Me.Width - 20
        Dim height = Me.Height - 20

        loaded = False

        teams_datatable.Width = width - teams_datatable.Location.X
        teams_datatable.Height = height - teams_datatable.Location.Y
        divider.Width = teams_datatable.Width

        workers_group.Height = height - workers_group.Location.Y - 20
        workersListBox.Height = workers_group.Height - workersListBox.Location.Y

        Me.ResumeLayout()
    End Sub

    Private Sub team_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
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
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sites,sections,workers,categories,transportvehicle")
        vars.Add("type", "active")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
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
            GoTo lastLine
        End If
        works_cat = request.ConvertDataToArray("categories", state.queryWorkerCategoryFields, response)
        If IsNothing(works_cat) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        transportsDB = request.ConvertDataToArray("transportvehicle", state.queryTransportsFields, response)
        If IsNothing(transportsDB) Then
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
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        ReDim sectionsIndex(works_sections.Item("cod_section").Count)

        translations.load("commonForm")

        teams_plan_frm.combo_cat.Items.Clear()
        teams_plan_frm.combo_cat.Items.Add(translations.getText("dropdownSelectCategories"))
        For i = 0 To works_cat.Item("designation").Count - 1
            teams_plan_frm.combo_cat.Items.Add(works_cat.Item("designation")(i))
        Next
        teams_plan_frm.combo_cat.SelectedIndex = 0

        teams_plan_frm.combo_driver_car.Items.Clear()
        teams_plan_frm.combo_maintenance_car.Items.Clear()
        teams_plan_frm.combo_driver_car.Items.Add(translations.getText("dropdownSelectTransport"))
        teams_plan_frm.combo_maintenance_car.Items.Add(translations.getText("dropdownSelectTransport"))
        For i = 0 To transportsDB.Item("designation").Count - 1
            teams_plan_frm.combo_driver_car.Items.Add(transportsDB.Item("designation")(i))
            teams_plan_frm.combo_maintenance_car.Items.Add(transportsDB.Item("designation")(i))
        Next
        teams_plan_frm.combo_driver_car.SelectedIndex = 0
        teams_plan_frm.combo_maintenance_car.SelectedIndex = 0

        workersListBox.Items.Clear()
        For i = 0 To works_worker.Item("name").Count - 1
            workersListBox.Items.Add(works_worker.Item("name")(i))
        Next
        workersListBox.SelectedIndex = 0

        siteSelection = loadSitesWithSections(combo_site, works_site, works_sections, False)
        combo_site.SelectedIndex = 0

        Listview_teams = New ListBox
        Listview_teams.Items.Clear()

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub





    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles workersListBox.DrawItem
        e.DrawBackground()
        Dim selected As Boolean = False

        If e.Index > 0 Then
            If String.Compare(workersListBox.Items(e.Index).ToString.Substring(0, 1).ToLower, workersListBox.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            Else
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            selected = True
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        Dim ForeColor As Color = Color.Black
        If selected Then
            ForeColor = Color.DarkGreen
        End If
        Using b As New SolidBrush(ForeColor)
            If Not IsNothing(workersListBox) Then
                If workersListBox.Items.Count > 0 Then
                    e.Graphics.DrawString(workersListBox.GetItemText(workersListBox.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub ListView_works_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles workersListBox.SelectedIndexChanged

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DropClickSearchBox(PictureBox1)
        doSearchWorkers(0, True, False, works_worker, workersListBox, searchbox.Text.ToString)
    End Sub


    Private Sub teams_datatable_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles teams_datatable.CellFormatting
        Dim grvScreenLocation As Drawing.Point = teams_datatable.PointToScreen(teams_datatable.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + teams_datatable.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + teams_datatable.Top
        Dim hit As DataGridView.HitTestInfo = teams_datatable.HitTest(tempX, tempY)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(AttendanceTable) Then
            If UBound(AttendanceTable, 1) < hit.RowIndex Or UBound(AttendanceTable, 2) < hit.ColumnIndex Then
                Exit Sub
            End If
            teams_datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = AttendanceTable(hit.RowIndex, 0)
        End If
    End Sub

    Private Sub teams_datatable_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles teams_datatable.MouseHover
        Dim grvScreenLocation As Drawing.Point = teams_datatable.PointToScreen(teams_datatable.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - grvScreenLocation.X + teams_datatable.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - grvScreenLocation.Y + teams_datatable.Top
        Dim hit As DataGridView.HitTestInfo = teams_datatable.HitTest(tempX, tempY)

        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 And Not IsNothing(AttendanceTable) Then
            If UBound(AttendanceTable, 1) < hit.RowIndex Or UBound(AttendanceTable, 2) < hit.ColumnIndex Then
                Exit Sub
            End If
            teams_datatable.Item(hit.ColumnIndex, hit.RowIndex).ToolTipText = AttendanceTable(hit.RowIndex, 0)
        End If
    End Sub
    Private Sub teams_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Private Sub teams_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles teams_datatable.CellMouseClick
        cellX = e.ColumnIndex
        CellY = e.RowIndex
        If cellX = -1 Or CellY = -1 Then
            Exit Sub
        End If
        If InArrayInt(idxTableWorkerPos, e.RowIndex) <> -1 Then
            removeWorkerBtn.Enabled = True
        Else
            removeWorkerBtn.Enabled = False
        End If

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        If InArrayInt(idxTableWorkerPos, CellY) <> -1 AndAlso cellX > 0 AndAlso cellX <= num_days Then
            workerSelectionTasks.Text = ""
            translations.load("teamsPlanning")
            workerSelectionTasks.Text += Environment.NewLine & "• " & works_cat.Item("designation")(InQueryDictionary(works_cat, serverData(CellY, cellX).category, "cod_category")) & Environment.NewLine
            If serverData(CellY, cellX).duplicateRecords.Equals("") Then
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("duplicateRecordsNone") & Environment.NewLine
            Else
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("duplicateRecords") & ": " & Environment.NewLine & serverData(CellY, cellX).duplicateRecords.Replace(Chr(13), Environment.NewLine) & Environment.NewLine
            End If

            If serverData(CellY, cellX).assignments.IndexOf("T") > -1 Then ' access to tablet on site
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("accessTablet") & Environment.NewLine
            End If
            If serverData(CellY, cellX).assignments.IndexOf("P") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("checkPlanning") & Environment.NewLine
            End If
            If serverData(CellY, cellX).assignments.IndexOf("D") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("logLivraison") & Environment.NewLine
            End If
            If serverData(CellY, cellX).assignments.IndexOf("S") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("storeMaterials") & Environment.NewLine
            End If
            If serverData(CellY, cellX).assignments.IndexOf("MT") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("storeTools") & Environment.NewLine
            End If
            If serverData(CellY, cellX).assignments.IndexOf("DRV-") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("driver")
                Dim array As String() = serverData(CellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                For Each s As String In array
                    If s.IndexOf("DRV-") > -1 Then

                        Dim code = s.Substring(s.IndexOf("DRV-") + 4)
                        workerSelectionTasks.Text += " : " & transportsDB.Item("designation")(InQueryDictionary(transportsDB, code, "cod_vehicle")) & Environment.NewLine
                        Exit For
                    End If
                Next
            End If
            If serverData(CellY, cellX).assignments.IndexOf("WCM-") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("cleaningMaintenanceCar")
                Dim array2 As String() = serverData(CellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                For Each s As String In array2
                    If s.IndexOf("WCM-") > -1 Then
                        Dim code2 = s.Substring(s.IndexOf("WCM-") + 4)
                        workerSelectionTasks.Text += Environment.NewLine & transportsDB.Item("designation")(InQueryDictionary(transportsDB, code2, "cod_vehicle"))
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub
    Private Sub teams_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles teams_datatable.CellMouseDoubleClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        If InArrayInt(idxTableWorkerPos, e.RowIndex) <> -1 AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days Then
            cellX = e.ColumnIndex
            CellY = e.RowIndex

            If teams_plan_frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                load_teams()
            End If
        End If
    End Sub

    Private errLoading As String = ""

    Private Sub tableSettingsBtn_Click(sender As Object, e As EventArgs) Handles tableSettingsBtn.Click
        tableSearchOptions_frm.from = "teams"
        tableSearchOptions_frm.ShowDialog()
        state = MainMdiForm.state
    End Sub

    Private Sub addWorkerBtn_Click(sender As Object, e As EventArgs) Handles addWorkerBtn.Click
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message5 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not (workersListBox.SelectedItems.Count > 0) Then
            translations.load("errorMessages")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        enableButtonsAndLinks(Me, False)

        'update DB
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "18") 'team
        vars.Add("type", "add")
        vars.Add("worker", works_worker.Item("cod_worker")(workersListBox.SelectedIndices(0)))
        vars.Add("codcat", works_worker.Item("cod_category")(workersListBox.SelectedIndices(0)))
        vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
        vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            Dim message5 As String = translations.getText("resultSuccessAddRecord")
            msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        enableButtonsAndLinks(Me, True)
        load_teams()

    End Sub

    Private Sub removeWorkerBtn_Click(sender As Object, e As EventArgs) Handles removeWorkerBtn.Click
        Dim cod_worker As String = ""
        If teams_datatable.CurrentRow.Index < 0 Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If InArrayInt(idxTableWorkerPos, teams_datatable.CurrentRow.Index) < 0 Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("teamsPlanning")
        Dim message3 As String = translations.getText("questionRemoveWorker") & Environment.NewLine & serverData(teams_datatable.CurrentRow.Index, 0).name & " ?"
        translations.load("messagebox")
        msgbox = New message_box_frm(message3, translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.OK) Then
            enableButtonsAndLinks(Me, False)

            cod_worker = serverData(teams_datatable.CurrentRow.Index, 0).code
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "6")
            vars.Add("request", "record")
            vars.Add("worker", cod_worker)
            vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
            vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "/" & System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM")))
            vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
            vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
            Dim request As New HttpData(state)
            response = request.RequestData(vars)
            Dim record As Dictionary(Of String, List(Of String)) = request.ConvertDataToArray("record", state.querySiteFields, response)
            If IsNothing(record) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", "18")
                vars.Add("type", "del")
                vars.Add("worker", cod_worker)
                vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
                vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
                vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
                request = New HttpData(state)
                response = request.RequestData(vars)

                If Not IsResponseOk(response) Then
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    translations.load("messagebox")
                    msgbox = New message_box_frm(GetMessage(response) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    enableButtonsAndLinks(Me, True)
                Else
                    enableButtonsAndLinks(Me, True)
                    load_teams()
                End If
            Else
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                translations.load("teamsPlanning")
                Dim message5 As String = translations.getText("errorRemoveWorker")
                translations.load("messagebox")
                msgbox = New message_box_frm(message5 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                enableButtonsAndLinks(Me, True)
            End If
        End If
    End Sub

    Private Sub copyTeamsBtn_Click(sender As Object, e As EventArgs) Handles copyTeamsBtn.Click
        If combo_site.SelectedIndex = 0 Then
            translations.load("errorMessages")
            Dim message7 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message7 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            translations.load("teamsPlanning")
            Dim message7 As String = translations.getText("questionCopyTeam") & " " & calendar_log.Value.Date.ToString("yyyy-MM")
            translations.load("messagebox")
            msgbox = New message_box_frm(message7 & ". ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If (msgbox.ShowDialog = DialogResult.Yes) Then
                enableButtonsAndLinks(Me, False)
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(False) Then
                        MainMdiForm.busy = New BusyThread
                        MainMdiForm.busy.Show()
                    End If
                End If
                Dim vars As New Dictionary(Of String, String)
                vars.Add("task", "18")
                vars.Add("type", "copy")
                vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
                vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
                vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
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
                    enableButtonsAndLinks(Me, True)

                Else
                    If Not IsNothing(MainMdiForm.busy) Then
                        If MainMdiForm.busy.isActive().Equals(True) Then
                            MainMdiForm.busy.Close(True)
                        End If
                    End If
                    translations.load("teamsPlanning")
                    MainMdiForm.statusMessage = translations.getText("resultCopySuccess")
                    enableButtonsAndLinks(Me, True)
                    load_teams()
                End If
            End If
        End If
    End Sub

    Private Sub workersUpdateBtn_Click(sender As Object, e As EventArgs) Handles workersUpdateBtn.Click
        enableButtonsAndLinks(Me, False)

        load_list()
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub teams_datatable_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles teams_datatable.CellContentClick

    End Sub

    Private Sub teams_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles teams_datatable.CellValueNeeded
        Dim serverDataTemp As workersJson(,)
        Dim AttendanceTableTemp As String(,)
        Dim absenseTemp As Integer(,) = Nothing
        Dim idxTableWorkerPosTemp As Integer()
        Dim holidaysTemp As DateTime() = Nothing

        If IsNothing(AttendanceTable) Or IsNothing(serverData) Then
            Exit Sub
        End If

        AttendanceTableTemp = AttendanceTable
        serverDataTemp = serverData
        idxTableWorkerPosTemp = idxTableWorkerPos
        absenseTemp = absense
        holidaysTemp = holidays


        With teams_datatable

            If UBound(AttendanceTableTemp, 1) < e.RowIndex Or UBound(AttendanceTableTemp, 2) < e.ColumnIndex Then
                Exit Sub
            End If
            If e.ColumnIndex.Equals(0) Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.Alignment = DataGridViewContentAlignment.BottomLeft

                If InQueryDictionary(works_site, AttendanceTableTemp(e.RowIndex, 0), "name") > -1 Then ' obra
                    .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                    .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorSite
                End If

                If InQueryDictionary(works_sections, serverDataTemp(e.RowIndex, 0).section, "cod_section") > -1 Then
                    If AttendanceTableTemp(e.RowIndex, 0).Equals(" " & works_sections.Item("description")(InQueryDictionary(works_sections, serverDataTemp(e.RowIndex, 0).section, "cod_section"))) Then ' section
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorSection
                    End If
                End If
                If InQueryDictionary(works_cat, serverDataTemp(e.RowIndex, 0).category, "cod_category") > -1 Then
                    If AttendanceTableTemp(e.RowIndex, 0).Equals("   " & works_cat.Item("designation")(InQueryDictionary(works_cat, serverDataTemp(e.RowIndex, 0).category, "cod_category"))) Then ' category
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = state.colorWorkCategories
                    End If
                End If
            End If

            Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
            If e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(idxTableWorkerPosTemp, e.RowIndex) > -1 Then
                    If AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("EP") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedTeam) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorPlannedTeam
                    ElseIf AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("MO") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorPlannedChangeOfSite) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorPlannedChangeOfSite
                    ElseIf AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("FA") And Not .Columns(e.ColumnIndex).DefaultCellStyle.ForeColor.Equals(state.colorFermetureAnnual) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorFermetureAnnual
                    ElseIf state.tableSearchOptions.viewThisConstructionSiteAttendance And AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("P") And Not .Rows(e.RowIndex).DefaultCellStyle.BackColor.Equals(state.colorFullDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(state.colorFullDayValidated, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorLightGray
                    ElseIf state.tableSearchOptions.viewThisConstructionSiteAttendance And serverDataTemp(e.RowIndex, e.ColumnIndex).status.Equals("PI") And Not .Rows(e.RowIndex).DefaultCellStyle.BackColor.Equals(state.colorPartialDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(state.colorPartialDayValidated, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = state.colorLightGray
                    End If
                    If Not serverDataTemp(e.RowIndex, e.ColumnIndex).duplicateRecords.Equals("") And AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("EP") Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
                    End If
                    'absences 
                    If Not IsNothing(absenseTemp) Then
                        If (absenseTemp(InArrayInt(idxTableWorkerPosTemp, e.RowIndex), e.ColumnIndex).Equals(1) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorAbsense)) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorAbsense
                        End If
                    End If
                End If
            End If

            If Not IsNothing(holidaysTemp) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorHolidays) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If holidaysTemp.Contains(Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & If(e.ColumnIndex < 10, "0" & e.ColumnIndex, e.ColumnIndex))) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = state.colorHolidays
                End If
            End If

            'weekends
            If e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If Not IsWeekday(calendar_log.Value.Date.ToString("yyyy-MM") & "-" & e.ColumnIndex.ToString()) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(state.colorWeekends) Then
                    .Columns(e.ColumnIndex).DefaultCellStyle.BackColor = state.colorWeekends
                End If
            End If
            'foreman
            If serverDataTemp(e.RowIndex, e.ColumnIndex).foreman Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = state.colorWithRecord
            End If
            'users without record
            If e.ColumnIndex = 0 And serverDataTemp(e.RowIndex, 0).notes <> "1" And InArrayInt(idxTableWorkerPosTemp, e.RowIndex) > -1 Then
                .Rows(e.RowIndex).Cells(0).Style.ForeColor = state.colorWithoutRecord
            End If

            If Not state.tableSearchOptions.viewThisConstructionSiteAttendance And (AttendanceTableTemp(e.RowIndex, e.ColumnIndex).Equals("P") Or serverDataTemp(e.RowIndex, e.ColumnIndex).status.Equals("PI")) Then
                e.Value = ""
            Else
                e.Value = AttendanceTableTemp(e.RowIndex, e.ColumnIndex)
            End If

        End With
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles loadTableDataBtn.Click
        DropClickSearchBox(loadTableDataBtn)
        load_teams()
    End Sub
    Sub load_teams()
        Dim qsite, qsection As String

        If (combo_site.SelectedIndex < 1) Then
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

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If
        If Not IsNothing(bwTables) Then
            If bwTables.IsBusy Then
                bwTables.CancelAsync()
            End If
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

        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = teams_datatable.Width
        mask.Height = teams_datatable.Height
        mask.Location = New Drawing.Point(teams_datatable.Location.X, teams_datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        translations.load("teamsPlanning")
        workerSelectionTasks.Text = translations.getText("selectWorker")

        enableButtonsAndLinks(Me, False)
        Refresh()

        teams_datatable.Rows.Clear()
        bwTables = New BackgroundWorker()
        bwTables.WorkerSupportsCancellation = True
        Dim vars As New Dictionary(Of String, String)
        vars.Add("site", qsite)
        vars.Add("section", qsection)
        bwTables.RunWorkerAsync(vars)
    End Sub

    Private Sub bwTables_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwTables.DoWork
        num_days = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        Dim BoldRow As New DataGridViewCellStyle With {.Font = New System.Drawing.Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)}
        Dim day As Integer = 0

        Dim stateLine As Boolean = False

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)
        cell_size = (teams_datatable.Width - 400) / num_days
        cell_size = If(cell_size < sizeOfString.Width, sizeOfString.Width, cell_size)
        rowpos = 0
        numRows = 0
        Dim holidaysJson As JArray = Nothing
        Dim closuresJson As JArray = Nothing

        idxTableWorkerPos = Nothing

        serverData = Nothing
        AttendanceTable = Nothing
        absense = Nothing
        record = Nothing

        errLoading = ""

        Dim vars As New Dictionary(Of String, String)
        vars = e.Argument
        vars.Add("task", "7")
        vars.Add("company", "all")
        vars.Add("dupes", "true")
        vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
        vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & num_days.ToString())
        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errLoading = response
            Exit Sub
        End If

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If Not data.ContainsKey("workers") Then
                errLoading = "no workers"
                Exit Sub
            Else

                If data.ContainsKey("holidays") Then
                    holidaysJson = JArray.Parse(data.Item("holidays").ToString)
                    ReDim holidays(holidaysJson.Count - 1)
                    For i = 0 To holidaysJson.Count - 1
                        holidays(i) = Convert.ToDateTime(holidaysJson(i).Item("date").ToString)
                    Next i
                End If

                Dim workers As JArray = JArray.Parse(data.Item("workers").ToString)
                rowpos = 4 'for titles and subtitles
                For i = 0 To workers.Count - 1
                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or stateLine Then ' category
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                    End If
                    stateLine = False
                    rowpos = rowpos + 1
                Next i

                ReDim idxTableWorkerPos(workers.Count - 1)
                ReDim serverData(rowpos, 32)
                ReDim AttendanceTable(rowpos + 1, 32)
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
                        serverData(i, j).photo = ""
                        serverData(i, j).checkout = ""
                        serverData(i, j).status = ""
                        serverData(i, j).absense = ""
                        serverData(i, j).notes = ""
                        serverData(i, j).data = Convert.ToDateTime("1970-01-01")
                        serverData(i, j).assignments = ""
                        serverData(i, j).foreman = False
                        serverData(i, j).duplicateRecords = ""
                        AttendanceTable(i, j) = ""
                    Next j
                Next i

                ReDim absense(workers.Count - 1, 32)
                For i = 0 To workers.Count - 1
                    For j = 0 To 31
                        absense(i, j) = 0
                    Next j
                Next i

                rowpos = 0
                serverData(rowpos, 0).site = workers(0).Item("site").ToString
                AttendanceTable(rowpos, 0) = works_site.Item("name")(InQueryDictionary(works_site, workers(0).Item("site").ToString, "cod_site"))
                rowpos = rowpos + 1
                serverData(rowpos, 0).section = workers(0).Item("section").ToString
                AttendanceTable(rowpos, 0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(0).Item("section").ToString, "cod_section"))
                rowpos = rowpos + 1
                serverData(rowpos, 0).category = workers(0).Item("cat").ToString
                AttendanceTable(rowpos, 0) = "   " & works_cat.Item("designation")(InQueryDictionary(works_cat, workers(0).Item("cat").ToString, "cod_category"))
                rowpos = rowpos + 1


                For i = 0 To workers.Count - 1
                    If i > 0 Then
                        If Not workers(i).Item("site").ToString.Equals(workers(i - 1).Item("site").ToString) Then ' obra
                            serverData(rowpos, 0).site = workers(i).Item("site").ToString
                            AttendanceTable(rowpos, 0) = works_site.Item("name")(InQueryDictionary(works_site, workers(i).Item("site").ToString, "cod_site"))
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                        If Not workers(i).Item("section").ToString.Equals(workers(i - 1).Item("section").ToString) Then ' section
                            serverData(rowpos, 0).section = workers(i).Item("section").ToString
                            AttendanceTable(rowpos, 0) = " " & works_sections.Item("description")(InQueryDictionary(works_sections, workers(i).Item("section").ToString, "cod_section"))
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                        If Not workers(i).Item("cat").ToString.Equals(workers(i - 1).Item("cat").ToString) Or stateLine Then ' category
                            serverData(rowpos, 0).category = workers(i).Item("cat").ToString
                            AttendanceTable(rowpos, 0) = "   " & works_cat.Item("designation")(InQueryDictionary(works_cat, workers(i).Item("cat").ToString, "cod_category"))
                            rowpos = rowpos + 1
                            stateLine = True
                        End If
                    End If

                    stateLine = False
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
                        serverData(rowpos, j).checkin = ""
                        serverData(rowpos, j).photo = workers(i).Item("photo").ToString
                        serverData(rowpos, j).checkout = ""
                        serverData(rowpos, j).status = ""
                        serverData(rowpos, j).absense = ""
                        serverData(rowpos, j).notes = ""
                        serverData(rowpos, j).foreman = False
                        serverData(rowpos, j).data = Convert.ToDateTime("1970-01-01")
                    Next j

                    If data.ContainsKey("closure") Then
                        closuresJson = JArray.Parse(data.Item("closure").ToString)
                        For Each closureJson In closuresJson

                            Dim startP As DateTime = Convert.ToDateTime(closureJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(closureJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & num_days) Then
                                    AttendanceTable(rowpos, CurrD.Day) = "FA"
                                End If
                                CurrD = CurrD.AddDays(1)
                            End While
                        Next closureJson
                    End If

                    Dim workerData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(workers(i).ToString)

                    If workerData.ContainsKey("record") Then
                        Dim records As JArray = JArray.Parse(workers(i).Item("record").ToString)
                        For Each recordJson In records
                            day = Convert.ToDateTime(recordJson.Item("date").ToString).Day
                            serverData(rowpos, 0).notes = "1"
                            If recordJson.Item("status").ToString.Equals("EP") Or recordJson.Item("status").ToString.Equals("MO") Or recordJson.Item("status").ToString.Equals("P") Or recordJson.Item("status").ToString.Equals("PI") Then
                                serverData(rowpos, day).checkin = recordJson.Item("checkin").ToString
                                serverData(rowpos, day).checkout = recordJson.Item("checkout").ToString
                                serverData(rowpos, day).status = recordJson.Item("status").ToString
                                serverData(rowpos, day).absense = recordJson.Item("absense").ToString
                                serverData(rowpos, day).data = Convert.ToDateTime(recordJson.Item("date").ToString)
                                serverData(rowpos, day).assignments = recordJson.Item("assignments").ToString
                                serverData(rowpos, day).category = recordJson.Item("category").ToString

                                AttendanceTable(rowpos, day) = If(recordJson.Item("status").ToString.Equals("PI"), recordJson.Item("absense").ToString.Substring(0, 5), recordJson.Item("status").ToString)
                            End If
                        Next recordJson
                    End If

                    If workerData.ContainsKey("duplicates") Then
                        Dim duplicates As JArray = JArray.Parse(workers(i).Item("duplicates").ToString)
                        For Each recordJson In duplicates
                            day = Convert.ToDateTime(recordJson.Item("date").ToString).Day
                            serverData(rowpos, day).duplicateRecords = recordJson.Item("sites").ToString
                        Next recordJson
                    End If

                    If workerData.ContainsKey("foreman") Then
                        Dim foremans As JArray = JArray.Parse(workers(i).Item("foreman").ToString)
                        For Each foremanJson In foremans
                            day = Convert.ToDateTime(foremanJson.Item("date").ToString).Day
                            serverData(rowpos, day).foreman = True
                        Next foremanJson
                    End If

                    If workerData.ContainsKey("absense") Then
                        Dim absensesJson As JArray = JArray.Parse(workers(i).Item("absense").ToString)
                        For Each absenseJson In absensesJson
                            Dim startP As DateTime = Convert.ToDateTime(absenseJson.Item("start").ToString)
                            Dim endP As DateTime = Convert.ToDateTime(absenseJson.Item("end").ToString)
                            Dim CurrD As DateTime = startP
                            While (CurrD <= endP)
                                If CurrD >= Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & "01") And CurrD <= Convert.ToDateTime(calendar_log.Value.Date.ToString("yyyy-MM-") & num_days) Then
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
            End If
        Catch ex As Exception
            ' If the Then array keys In your PHP array are Not consecutive numbers, json_encode() must make the other construct an Object since JavaScript arrays are always consecutively numerically indexed.
            ' https://stackoverflow.com/questions/11722059/php-array-to-json-array-using-json-encode
            saveCrash(ex)
            errLoading = ex.Message.ToString
        End Try
        e.Result = errLoading
    End Sub

    Private Sub bwTables_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwTables.RunWorkerCompleted
        Dim isJson As Boolean
        Try
            isJson = Not JToken.Parse(errLoading).Type.Equals(JTokenType.Null)
        Catch ex As Exception
            isJson = False
        End Try
        If errLoading.Equals("no workers") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            ReDim idxTableWorkerPos(1)
            idxTableWorkerPos(1) = -1

            translations.load("errorMessages")
            Dim message = translations.getText("errorNoRecordsFound")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)

            msgbox.ShowDialog()
            mask.Dispose()

            enableButtonsAndLinks(Me, True)
            Exit Sub
        ElseIf isJson Then
            If Not IsResponseOk(errLoading) Then
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                ReDim idxTableWorkerPos(1)
                idxTableWorkerPos(1) = -1
                msgbox = New message_box_frm(GetMessage(errLoading), "exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                mask.Dispose()
                enableButtonsAndLinks(Me, True)
            End If

        ElseIf Not errLoading.Equals("") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            mask.Dispose()
            enableButtonsAndLinks(Me, True)
            MainMdiForm.statusMessage = errLoading
            Exit Sub
        End If
        translations.load("commonForm")
        MainMdiForm.statusMessage = translations.getText("addDataToTable")
        Dim dt As Date = Now
        Dim today As Integer = dt.ToString("dd")

        SuspendLayout()
        teams_datatable.Visible = False

        teams_datatable.VirtualMode = True
        teams_datatable.RowHeadersVisible = False
        teams_datatable.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        teams_datatable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

        teams_datatable.Rows.Clear()
        teams_datatable.RowCount = rowpos
        teams_datatable.ColumnCount = num_days + 1
        teams_datatable.BackgroundColor = Color.White
        translations.load("teamsPlanning")
        teams_datatable.Columns(0).HeaderCell.Value = translations.getText("name")
        teams_datatable.Columns(0).Width = 400


        For i = 1 To num_days
            teams_datatable.Columns(i).HeaderCell.Value = i.ToString()
            teams_datatable.Columns(i).Width = cell_size
            teams_datatable.Columns(i).DefaultCellStyle.BackColor = Color.White

            If i <= today Then
                teams_datatable.Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
            End If
        Next i

        teams_datatable.Visible = True
        ResumeLayout()
        mask.Dispose()
        enableButtonsAndLinks(Me, True)


        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")

        EnforceAuthorities()
    End Sub


    Sub EnforceAuthorities()

    End Sub
End Class