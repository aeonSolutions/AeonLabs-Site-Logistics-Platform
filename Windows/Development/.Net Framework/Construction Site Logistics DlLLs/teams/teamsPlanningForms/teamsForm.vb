Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core

Imports ConstructionSiteLogistics.Gui.Libraries
Imports ConstructionSiteLogistics.Gui.Forms.Shared

Public Class teamsForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private mask As PictureBox
    Private mainform As MainMdiForm
    Private teamsPlan_frm As teamsPlanForm
    Public Property works_worker As Dictionary(Of String, List(Of String))
    Public Property works_team As Dictionary(Of String, List(Of String))
    Public Property works_sections As Dictionary(Of String, List(Of String))
    Public Property query_bordereau As Dictionary(Of String, List(Of String))
    Public Property AttendanceTable As String(,)
    Public Property cellX As Integer = -1
    Public Property CellY As Integer = -1
    Public Property calendar As DateTimePicker
    Public Property activeTable As String = ""
    Public Property works_site As Dictionary(Of String, List(Of String))
    Public Property works_cat As Dictionary(Of String, List(Of String))
    Public Property works_enterprise As Dictionary(Of String, List(Of String))

    Public Property transportsDB As Dictionary(Of String, List(Of String))


    Public Property attendanceTableBuilder As attendanceTableBuilderClass
    Private WithEvents bwLoadData As BackgroundWorker
    Private WithEvents DataRequests As IDataTeamsRequests

    Private isLoading As Boolean = False
    Private loaded As Boolean = False
    Private siteSelection As Integer(,)


    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainform.doMenuAnimmation("form")
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New(_mainForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainform = _mainForm
        teamsPlan_frm = New teamsPlanForm(mainform, Me)
        Me.WindowState = FormWindowState.Maximized
        SetDoubleBuffered(datatable)
        Me.Refresh()
    End Sub

    Private Sub team_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        stateCore = mainform.state
        loadForm.Enabled = True

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub

    Private Sub loadForm_Tick(sender As Object, e As EventArgs) Handles loadForm.Tick
        loadForm.Enabled = False
        translations = New languageTranslations(stateCore)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainform.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()

        Me.SuspendLayout()

        teams_title_text.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)

        divider.BackColor = stateCore.dividerColor

        GroupBoxSiteSelection.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        workers_group.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxWorkerAssignments.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        workersListBox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        searchTitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar_log.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)


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

        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        Dim width = Me.Width - 20
        Dim height = Me.Height - 20

        loaded = False

        datatable.Width = width - datatable.Location.X
        datatable.Height = height - datatable.Location.Y
        divider.Width = datatable.Width

        workers_group.Height = height - workers_group.Location.Y - 20
        workersListBox.Height = workers_group.Height - workersListBox.Location.Y

        Me.ResumeLayout()
    End Sub

    Private Sub team_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "teams.dll", "teamsDataRequests"), IDataTeamsRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainform.statusMessage = "DLL file not found"
            mainform.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

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
        mainform.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites,sections,workers,categories,transportvehicle,entreprises")
        vars.Add("type", "active")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadTeamsInitialData()
    End Sub

    Private Sub DataRequests_getResponseTeamsInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseTeamsInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_enterprise = request.ConvertDataToArray("entreprises", stateCore.queryEntreprisePartnersFields, response)
        If IsNothing(works_site) Then
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
            GoTo lastLine
        End If
        works_cat = request.ConvertDataToArray("categories", stateCore.queryWorkerCategoryFields, response)
        If IsNothing(works_cat) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", stateCore.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        transportsDB = request.ConvertDataToArray("transportvehicle", stateCore.queryTransportsFields, response)
        If IsNothing(transportsDB) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainform.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If errorFlag Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("commonForm")

        teamsPlan_frm.combo_cat.Items.Clear()
        teamsPlan_frm.combo_cat.Items.Add(translations.getText("dropdownSelectCategories"))
        For i = 0 To works_cat.Item("designation").Count - 1
            teamsPlan_frm.combo_cat.Items.Add(works_cat.Item("designation")(i))
        Next
        teamsPlan_frm.combo_cat.SelectedIndex = 0

        teamsPlan_frm.combo_driver_car.Items.Clear()
        teamsPlan_frm.combo_maintenance_car.Items.Clear()
        teamsPlan_frm.combo_driver_car.Items.Add(translations.getText("dropdownSelectTransport"))
        teamsPlan_frm.combo_maintenance_car.Items.Add(translations.getText("dropdownSelectTransport"))
        For i = 0 To transportsDB.Item("designation").Count - 1
            teamsPlan_frm.combo_driver_car.Items.Add(transportsDB.Item("designation")(i))
            teamsPlan_frm.combo_maintenance_car.Items.Add(transportsDB.Item("designation")(i))
        Next
        teamsPlan_frm.combo_driver_car.SelectedIndex = 0
        teamsPlan_frm.combo_maintenance_car.SelectedIndex = 0

        workersListBox.Items.Clear()
        For i = 0 To works_worker.Item("name").Count - 1
            workersListBox.Items.Add(works_worker.Item("name")(i))
        Next
        workersListBox.SelectedIndex = 0

        siteSelection = loadSitesWithSections(combo_site, works_site, works_sections, False)
        combo_site.SelectedIndex = 0

        mainform.busy.Close(True)
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


    Private Sub teams_datatable_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles datatable.CellFormatting
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

    Private Sub teams_datatable_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datatable.MouseHover
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
    Private Sub teams_datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Private Sub teams_datatable_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseClick
        cellX = e.ColumnIndex
        CellY = e.RowIndex
        If cellX = -1 Or CellY = -1 Then
            Exit Sub
        End If
        If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) <> -1 Then
            removeWorkerBtn.Enabled = True
        Else
            removeWorkerBtn.Enabled = False
        End If

        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
        If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, CellY) <> -1 AndAlso cellX > 0 AndAlso cellX <= num_days Then
            workerSelectionTasks.Text = ""
            translations.load("teamsPlanning")
            workerSelectionTasks.Text += Environment.NewLine & "• " & works_cat.Item("designation")(InQueryDictionary(works_cat, attendanceTableBuilder.serverData(CellY, cellX).category, "cod_category")) & Environment.NewLine
            If attendanceTableBuilder.serverData(CellY, cellX).duplicates.Equals("") Then
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("duplicateRecordsNone") & Environment.NewLine
            Else
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("duplicateRecords") & ": " & Environment.NewLine & attendanceTableBuilder.serverData(CellY, cellX).duplicates.Replace(Chr(13), Environment.NewLine) & Environment.NewLine
            End If

            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("T") > -1 Then ' access to tablet on site
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("accessTablet") & Environment.NewLine
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("P") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("checkPlanning") & Environment.NewLine
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("D") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("logLivraison") & Environment.NewLine
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("S") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("storeMaterials") & Environment.NewLine
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("MT") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("storeTools") & Environment.NewLine
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("DRV-") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("driver")
                Dim array As String() = attendanceTableBuilder.serverData(CellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                For Each s As String In array
                    If s.IndexOf("DRV-") > -1 Then

                        Dim code = s.Substring(s.IndexOf("DRV-") + 4)
                        workerSelectionTasks.Text += " : " & transportsDB.Item("designation")(InQueryDictionary(transportsDB, code, "cod_vehicle")) & Environment.NewLine
                        Exit For
                    End If
                Next
            End If
            If attendanceTableBuilder.serverData(CellY, cellX).assignments.IndexOf("WCM-") > -1 Then ' 
                workerSelectionTasks.Text += Environment.NewLine & "• " & translations.getText("cleaningMaintenanceCar")
                Dim array2 As String() = attendanceTableBuilder.serverData(CellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
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
    Private Sub teams_datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseDoubleClick
        Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))

        If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) <> -1 AndAlso e.ColumnIndex > 0 AndAlso e.ColumnIndex <= num_days Then
            cellX = e.ColumnIndex
            CellY = e.RowIndex
            calendar = calendar_log

            If teamsPlan_frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                load_teams()
            End If
        End If
    End Sub

    Private errLoading As String = ""

    Private Sub tableSettingsBtn_Click(sender As Object, e As EventArgs) Handles tableSettingsBtn.Click
        Dim tableSearchOptions_frm As tableSearchOptionsForm = New tableSearchOptionsForm(mainform, stateCore)
        tableSearchOptions_frm.from = "teams"
        tableSearchOptions_frm.ShowDialog()
        stateCore = mainform.state
    End Sub

    Private Sub addWorkerBtn_Click(sender As Object, e As EventArgs) Handles addWorkerBtn.Click
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message5 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If Not (workersListBox.SelectedItems.Count > 0) Then
            translations.load("errorMessages")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        enableButtonsAndLinks(Me, False)

        'update DB
        Dim vars As New Dictionary(Of String, String)
        vars.Add("type", "add")
        vars.Add("worker", works_worker.Item("cod_worker")(workersListBox.SelectedIndices(0)))
        vars.Add("codcat", works_worker.Item("cod_category")(workersListBox.SelectedIndices(0)))
        vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
        vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
        vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveTeamsData()
    End Sub

    Private Sub DataRequests_getResponseSaveTeamsData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveTeamsData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainform.busy.Close(True)
        If Not IsResponseOk(response) Then
            mainform.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
        Else
            enableButtonsAndLinks(Me, True)
            load_teams()
        End If
    End Sub

    Private Sub removeWorkerBtn_Click(sender As Object, e As EventArgs) Handles removeWorkerBtn.Click
        Dim cod_worker As String = ""
        If datatable.CurrentRow.Index < 0 Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, datatable.CurrentRow.Index) < 0 Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("teamsPlanning")
        Dim message3 As String = translations.getText("questionRemoveWorker") & Environment.NewLine & attendanceTableBuilder.serverData(datatable.CurrentRow.Index, 0).name & " ?"
        translations.load("messagebox")
        msgbox = New messageBoxForm(message3, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            enableButtonsAndLinks(Me, False)

            cod_worker = attendanceTableBuilder.serverData(datatable.CurrentRow.Index, 0).code
            Dim vars As New Dictionary(Of String, String)
            vars.Add("request", "record")
            vars.Add("worker", cod_worker)
            vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
            vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "/" & System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM")))
            vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
            vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.loadRecordData()
        End If
    End Sub

    Private Sub DataRequests_getResponseLoadRecordData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadRecordData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        Dim record As Dictionary(Of String, List(Of String)) = request.ConvertDataToArray("record", stateCore.querySiteFields, response)
        If IsNothing(record) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("type", "del")
            vars.Add("worker", attendanceTableBuilder.serverData(datatable.CurrentRow.Index, 0).code)
            vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
            vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
            vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))

            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveTeamsData()
        Else
            mainform.busy.Close(True)
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("errorRemoveWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
        End If
    End Sub

    Private Sub copyTeamsBtn_Click(sender As Object, e As EventArgs) Handles copyTeamsBtn.Click
        If combo_site.SelectedIndex = 0 Then
            translations.load("errorMessages")
            Dim message7 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message7 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            translations.load("teamsPlanning")
            Dim message7 As String = translations.getText("questionCopyTeam") & " " & calendar_log.Value.Date.ToString("yyyy-MM")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message7 & ". ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If (msgbox.ShowDialog = DialogResult.Yes) Then
                enableButtonsAndLinks(Me, False)
                If Not IsNothing(mainform.busy) Then
                    If mainform.busy.isActive().Equals(False) Then

                        mainform.busy.Show()
                    End If
                End If
                Dim vars As New Dictionary(Of String, String)
                vars.Add("type", "copy")
                vars.Add("site", siteSelection(combo_site.SelectedIndex - 1, 0))
                vars.Add("section", siteSelection(combo_site.SelectedIndex - 1, 1))
                vars.Add("date", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")

                DataRequests.Initialise(stateCore)
                DataRequests.loadQueue(vars, Nothing, Nothing)
                DataRequests.saveTeamsData()
            End If
        End If
    End Sub

    Private Sub workersUpdateBtn_Click(sender As Object, e As EventArgs) Handles workersUpdateBtn.Click
        enableButtonsAndLinks(Me, False)

        load_list()
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub teams_datatable_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick

    End Sub

    Private Sub teams_datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded
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

                If InQueryDictionary(works_site, attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex), "name") > -1 Then ' obra
                    .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                    .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorSite
                End If

                If InQueryDictionary(works_sections, attendanceTableBuilder.serverData(e.RowIndex, 0).section, "cod_section") > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals(" " & works_sections.Item("description")(InQueryDictionary(works_sections, attendanceTableBuilder.serverData(e.RowIndex, 0).section, "cod_section"))) Then ' section
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorSection
                    End If
                End If
                If InQueryDictionary(works_cat, attendanceTableBuilder.serverData(e.RowIndex, 0).category, "cod_category") > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("   " & works_cat.Item("designation")(InQueryDictionary(works_cat, attendanceTableBuilder.serverData(e.RowIndex, 0).category, "cod_category"))) Then ' category
                        .Rows(e.RowIndex).Cells(0).Style.Font = New Font("Ariel", 8, Drawing.FontStyle.Bold)
                        .Rows(e.RowIndex).Cells(0).Style.Alignment = DataGridViewContentAlignment.BottomLeft
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = stateCore.colorWorkCategories
                    End If
                End If
            End If

            Dim num_days As Integer = System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM"))
            If e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
                If InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) > -1 Then
                    If attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedTeam) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorPlannedTeam
                    ElseIf attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("MO") And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPlannedChangeOfSite) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorPlannedChangeOfSite
                    ElseIf attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("FA") And Not .Columns(e.ColumnIndex).DefaultCellStyle.ForeColor.Equals(stateCore.colorFermetureAnnual) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorFermetureAnnual
                    ElseIf stateCore.tableSearchOptions.viewThisConstructionSiteAttendance And attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("P") And Not .Rows(e.RowIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorFullDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(stateCore.colorFullDayValidated, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorLightGray
                    ElseIf stateCore.tableSearchOptions.viewThisConstructionSiteAttendance And attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).status.Equals("PI") And Not .Rows(e.RowIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorPartialDayValidated) Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = ControlPaint.Light(stateCore.colorPartialDayValidated, 1.0F)
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = stateCore.colorLightGray
                    End If
                    If Not attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).duplicates.Equals("") And attendanceTableBuilder.tableData.Rows(e.RowIndex)(e.ColumnIndex).Equals("EP") Then
                        .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose
                    End If
                    'absences 
                    If Not IsNothing(attendanceTableBuilder.absense) Then
                        If (attendanceTableBuilder.absense(InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex), e.ColumnIndex).Equals(1) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorAbsense)) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorAbsense
                        End If
                    End If
                End If
            End If

            If Not IsNothing(attendanceTableBuilder.holidays) And Not .Columns(e.ColumnIndex).DefaultCellStyle.BackColor.Equals(stateCore.colorHolidays) And e.ColumnIndex > 0 And e.ColumnIndex <= num_days Then
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

            'foreman
            If attendanceTableBuilder.serverData(e.RowIndex, e.ColumnIndex).foreman And e.ColumnIndex > 0 Then
                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = stateCore.colorWithRecord

            End If

            'users without record
            If e.ColumnIndex = 0 And attendanceTableBuilder.serverData(e.RowIndex, 0).notes <> "1" And InArrayInt(attendanceTableBuilder.idxTableWorkerPos, e.RowIndex) > -1 Then
                .Rows(e.RowIndex).Cells(0).Style.ForeColor = stateCore.colorWithoutRecord
            End If

        End With
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles loadTableDataBtn.Click
        load_teams()
    End Sub
    Sub load_teams()
        Dim qsite, qsection As String

        If (combo_site.SelectedIndex < 1) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        ElseIf siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-2) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        mainform.busy.Show()

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
        mask.Image = Image.FromFile(mainform.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        translations.load("teamsPlanning")
        workerSelectionTasks.Text = translations.getText("selectWorker")
        enableButtonsAndLinks(Me, False)
        Refresh()

        datatable.Rows.Clear()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("site", qsite)
        vars.Add("section", qsection)
        vars.Add("company", "all")
        vars.Add("dupes", "true")
        vars.Add("startdate", calendar_log.Value.Date.ToString("yyyy-MM") & "-01")
        vars.Add("enddate", calendar_log.Value.Date.ToString("yyyy-MM") & "-" & System.DateTime.DaysInMonth(calendar_log.Value.Date.ToString("yyyy"), calendar_log.Value.Date.ToString("MM")).ToString())

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadTeamsTableData()
    End Sub

    Private Sub DataRequests_getResponseLoadTeamsTableData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadTeamsTableData
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
        mainform.statusMessage = translations.getText("loadingTable")

        attendanceTableBuilder = New attendanceTableBuilderClass(stateCore, response, calendar_log.Value.Date, works_enterprise, works_cat, works_sections, works_site)
        stateCore.datatableContents = attendanceTableBuilder.buildDataTable()

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
            mainform.busy.Close(True)
            translations.load("system")
            mainform.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If

        If e.Result(1).Equals("no workers") Then
            mainform.busy.Close(True)

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
            mainform.busy.Close(True)

            mask.Dispose()
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            mainform.busy.Close(True)
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
        mainform.statusMessage = translations.getText("tableLoaded") & "."
    End Sub
End Class