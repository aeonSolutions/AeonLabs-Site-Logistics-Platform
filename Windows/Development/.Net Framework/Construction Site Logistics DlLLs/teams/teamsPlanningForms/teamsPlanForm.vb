Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Public Class teamsPlanForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Private cellX, cellY As Integer
    Private query_bordereau As String(,)
    Private TaskSelection As New List(Of Integer)
    Private loading As Boolean = False
    Private taskRequest As String = ""
    Private WithEvents DataRequests As IDataTeamsRequests
    Private changes, started As Boolean
    Private mainForm As MainMdiForm
    Private team_frm As teamsForm
    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New(_mainForm As MainMdiForm, _teamForm As teamsForm)
        team_frm = _teamForm
        mainForm = _mainForm
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        SetDoubleBuffered(calendarPlan)
        Me.Refresh()
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub teams_plan_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)

        loading = True
        cellX = team_frm.cellX
        cellY = team_frm.CellY
        Me.SuspendLayout()
        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        groupboxPlanning.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxBossType.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxResponsabilities.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxTransports.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        CheckBox_ep.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_mo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_del.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        combo_cat.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        accessTabletChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkPlanningChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        logLivraisonsChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        storeMaterialsChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        storeToolsChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        driverChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        maintenanceCarChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_driver_car.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_maintenance_car.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        worker_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        site_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        CloseBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        divider.BackColor = stateCore.dividerColor
        CloseBtn.BackColor = stateCore.buttonColor
        saveBtn.BackColor = stateCore.buttonColor

        StatusUpdate.Text = ""
        translations.load("commonForm")
        CloseBtn.Text = translations.getText("closeBtn")
        saveBtn.Text = translations.getText("saveBtn")

        translations.load("teamsPlanning")
        title.Text = translations.getText("teamPlanning")

        groupboxPlanning.Text = translations.getText("planning")
        groupBoxBossType.Text = translations.getText("workJobDescriprtion")
        groupBoxResponsabilities.Text = translations.getText("workResponsabilities")
        groupBoxTransports.Text = translations.getText("transports")

        CheckBox_ep.Text = translations.getText("assignTeam")
        checkbox_mo.Text = translations.getText("changeSite")
        checkbox_del.Text = translations.getText("removeFromSite")

        accessTabletChk.Text = translations.getText("accessTablet")
        checkPlanningChk.Text = translations.getText("checkPlanning")
        logLivraisonsChk.Text = translations.getText("logLivraison")
        storeMaterialsChk.Text = translations.getText("storeMaterials")
        storeToolsChk.Text = translations.getText("storeTools")

        driverChk.Text = translations.getText("driver")
        maintenanceCarChk.Text = translations.getText("cleaningMaintenanceCar")

        CheckBox_ep.Checked = True
        checkbox_mo.Checked = False
        checkbox_del.Checked = False

        If (team_frm.attendanceTableBuilder.serverData(cellY, cellX).photo.Equals("")) Then
            worker_photo.Image = System.Drawing.Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
        Else
            worker_photo.Image = System.Drawing.Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & team_frm.attendanceTableBuilder.serverData(cellY, cellX).photo)))
                worker_photo.Image = tImage

            Catch ex As Exception
                translations.load("errorMessages")
                worker_photo.Image = System.Drawing.Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
                mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("EP") Then
            CheckBox_ep.Checked = True
            checkbox_mo.Checked = False
            checkbox_del.Checked = False
        ElseIf team_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("MO") Then
            checkbox_mo.Checked = True
            CheckBox_ep.Checked = False
            checkbox_del.Checked = False
        End If
        translations.load("teamsPlanning")
        worker_lbl.Text = team_frm.attendanceTableBuilder.serverData(cellY, cellX).name & Environment.NewLine & team_frm.attendanceTableBuilder.serverData(cellY, cellX).contact
        site_lbl.Text = team_frm.works_site.Item("name")(InQueryDictionary(team_frm.works_site, team_frm.attendanceTableBuilder.serverData(cellY, cellX).site, "cod_site"))

        Dim oDate As DateTime = Convert.ToDateTime(team_frm.calendar.Value.Date.ToString("yyyy-MM-") & If(cellX < 10, "0" & cellX, cellX))
        calendarPlan.SetDate(oDate)

        ResumeLayout()
        calendarPlan.Visible = True
        calendarPlan.Refresh()
    End Sub

    Private Sub teams_plan_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "teams.dll", "teamsDataRequests"), IDataTeamsRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("EP") Then
            CheckBox_ep.Checked = True
        ElseIf team_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("MO") Then
            checkbox_mo.Checked = True
        End If

        Dim pos As Integer = InQueryDictionary(team_frm.works_cat, team_frm.attendanceTableBuilder.serverData(cellY, cellX).category, "cod_category")
        combo_cat.SelectedIndex = If(pos > -1, pos + 1, -1)

        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("T") > -1 Then ' access to tablet on site
            accessTabletChk.Checked = True
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("P") > -1 Then ' 
            checkPlanningChk.Checked = True
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("D") > -1 Then ' 
            logLivraisonsChk.Checked = True
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("S") > -1 Then ' 
            storeMaterialsChk.Checked = True
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("MT") > -1 Then ' 
            storeToolsChk.Checked = True
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("DRV-") > -1 Then ' 
            driverChk.Checked = True
            Dim array As String() = team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            For Each s As String In array
                If s.IndexOf("DRV-") > -1 Then
                    Dim code = s.Substring(s.IndexOf("DRV-") + 4)
                    For i = 0 To combo_driver_car.Items.Count - 1
                        If team_frm.transportsDB.Item("designation")(InQueryDictionary(team_frm.transportsDB, code, "cod_vehicle")).ToString.Equals(combo_driver_car.Items.Item(i).ToString) Then
                            combo_driver_car.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                    Exit For
                End If
            Next
        End If
        If team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.IndexOf("WCM-") > -1 Then ' 
            maintenanceCarChk.Checked = True
            Dim array2 As String() = team_frm.attendanceTableBuilder.serverData(cellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            For Each s As String In array2
                If s.IndexOf("WCM-") > -1 Then
                    Dim code2 = s.Substring(s.IndexOf("WCM-") + 4)
                    For i = 0 To combo_maintenance_car.Items.Count - 1
                        If team_frm.transportsDB.Item("designation")(InQueryDictionary(team_frm.transportsDB, code2, "cod_vehicle")).ToString.Equals(combo_maintenance_car.Items.Item(i).ToString) Then
                            combo_maintenance_car.SelectedIndex = i
                            Exit For
                        End If
                    Next i
                    Exit For
                End If
            Next
        End If
        loading = False
    End Sub

    Private Sub CheckBox_ep_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ep.CheckedChanged
        If loading Then
            Exit Sub
        End If

        If CheckBox_ep.Checked Then
            checkbox_mo.Checked = False
            checkbox_del.Checked = False
            groupBoxBossType.Enabled = True
            groupBoxResponsabilities.Enabled = True
            groupBoxTransports.Enabled = True
        End If
    End Sub

    Private Sub checkbox_mo_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_mo.CheckedChanged
        If loading Then
            Exit Sub
        End If
        If checkbox_mo.Checked Then
            CheckBox_ep.Checked = False
            checkbox_del.Checked = False

            groupBoxBossType.Enabled = False
            groupBoxResponsabilities.Enabled = False
            groupBoxTransports.Enabled = False

            accessTabletChk.Checked = False
            checkPlanningChk.Checked = False
            logLivraisonsChk.Checked = False
            storeMaterialsChk.Checked = False
            storeToolsChk.Checked = False
            driverChk.Checked = False
            maintenanceCarChk.Checked = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        enableButtonsAndLinks(Me, False)

        If calendarPlan.SelectionStart.ToString("yyyy-MM-dd").Equals(calendarPlan.SelectionEnd.ToString("yyyy-MM-dd")) Then 'one day selection
            If Not checkFields() Then
                enableButtonsAndLinks(Me, True)
                Exit Sub
            End If
            saveOneDay()
        ElseIf CheckBox_ep.Checked = False And checkbox_mo.Checked = False Then
            If Not checkFields() Then
                enableButtonsAndLinks(Me, True)
                Exit Sub
            End If
            saveMultiDay()
        Else
            If Not checkFields() Then
                enableButtonsAndLinks(Me, True)
                Exit Sub
            End If
            saveMultiDay()
        End If
        enableButtonsAndLinks(Me, True)

    End Sub

    Private Function checkFields()
        If CheckBox_ep.Checked Then
            If combo_cat.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message5 As String = translations.getText("errorSelectCategory")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Return False
            End If
            If driverChk.Checked And combo_driver_car.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message5 As String = translations.getText("errorSelectTransport")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Return False
            End If
            If maintenanceCarChk.Checked And combo_maintenance_car.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message5 As String = translations.getText("errorSelectTransport")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub saveMultiDay()
        Dim i As Integer
        Dim status As String = ""
        Dim response As String = ""
        Dim temp As String = ""
        Dim temp2 As String = ""

        translations.load("teamsPlanning")
        Dim message4 As String = translations.getText("questionPlanningMultiday") & calendarPlan.SelectionStart.ToString("yyyy/MM/dd") & " " & translations.getText("to") & " " & calendarPlan.SelectionEnd.ToString("yyyy/MM/dd") & " ?"
        translations.load("messagebox")
        msgbox = New messageBoxForm(message4, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgbox.ShowDialog <> DialogResult.Yes Then
            Exit Sub
        End If

        If checkbox_del.Checked Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("teamsClean")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message5 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog = DialogResult.Yes Then
                status = "clean"
            Else
                Exit Sub
            End If
        End If
        If checkbox_mo.Checked Then
            status = "MO"
        ElseIf CheckBox_ep.Checked Then
            status = "EP"
        End If

        Dim workerTasks As String = ""
        If accessTabletChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "T"
        End If
        If checkPlanningChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "P"
        End If
        If logLivraisonsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "D"
        End If
        If storeMaterialsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "S"
        End If
        If storeToolsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "MT"
        End If
        If driverChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "DRV-" & team_frm.transportsDB.Item("cod_vehicle")(combo_driver_car.SelectedIndex - 1)
        End If
        If maintenanceCarChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "WCM-" & team_frm.transportsDB.Item("cod_vehicle")(combo_maintenance_car.SelectedIndex - 1)
        End If

        Dim absense As String = "null"
        Dim today As Date = Date.ParseExact(calendarPlan.TodayDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim selectedDate As Date = calendarPlan.SelectionStart.ToString("yyyy-MM-dd")
        Dim selectedDateEnd As Date = calendarPlan.SelectionEnd.ToString("yyyy-MM-dd")

        Dim start_date As Integer = calendarPlan.SelectionStart.ToString("dd")
        Dim end_date As Integer = calendarPlan.SelectionEnd.ToString("dd")
        changes = False
        started = True
        taskRequest = "multi"

        DataRequests.Initialise(stateCore)
        For i = start_date To end_date
            translations.load("teamsPlanning")
            StatusUpdate.Text = translations.getText("updatingDay") & " " & calendarPlan.SelectionStart.ToString("yyyy-MM") & "-" & If(i < 10, "0" & i.ToString(), i.ToString)
            StatusUpdate.Refresh()

            If IsWeekday(calendarPlan.SelectionStart.ToString("yyyy/MM") & "/" & i.ToString()) Then
                Dim vars As New Dictionary(Of String, String)
                If status.Equals("clean") Then
                    vars.Add("type", "del")
                Else
                    vars.Add("type", "add")
                End If
                vars.Add("tasks", workerTasks)
                vars.Add("category", team_frm.works_cat.Item("cod_category")(combo_cat.SelectedIndex - 1))
                vars.Add("worker", team_frm.attendanceTableBuilder.serverData(cellY, cellX).code)
                vars.Add("site", team_frm.attendanceTableBuilder.serverData(cellY, cellX).site)
                vars.Add("section", team_frm.attendanceTableBuilder.serverData(cellY, cellX).section)
                vars.Add("date", calendarPlan.SelectionStart.ToString("yyyy-MM") & "-" & If(i < 10, "0" & i, i))
                vars.Add("status", status)
                vars.Add("absense", absense)
                vars.Add("teams", "true")

                DataRequests.loadQueue(vars, Nothing, Nothing)
            End If
        Next i
        response = DataRequests.saveTeamsWorkerRecordData()
    End Sub

    Private Sub saveTeamsWorkerRecordData_getResponseSaveTeamsWorkerRecordData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveTeamsWorkerRecordData

        If Not IsResponseOk(args.responseData) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(args.responseData), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            changes = False
        Else
            changes = True
        End If
    End Sub
    Private Sub saveTeamsWorkerRecordData_getResponseSaveTeamsWorkerRecordDataCompleted(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveTeamsWorkerRecordDataCompleted
        mainForm.busy.Close(True)
        If changes Then
            translations.load("attendance")
            mainForm.statusMessage = translations.getText("validationSuccess")
        Else
            translations.load("attendance")
            Dim message3 As String = translations.getText("noChanges")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
        taskRequest = ""
    End Sub

    Private Sub saveOneDay()
        Dim status As String = ""
        Dim query As String = ""
        Dim temp As String = ""

        If checkbox_del.Checked Then
            translations.load("teamsPlanning")
            Dim message4 As String = translations.getText("teamsClean")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message4 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog = DialogResult.Yes Then
                status = ""
            Else
                Exit Sub
            End If
        Else
            If CheckBox_ep.Checked Then
                status = "EP"
            ElseIf checkbox_mo.Checked Then
                status = "MO"
            End If
        End If
        Dim workerTasks As String = ""
        If accessTabletChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "T"
        End If
        If checkPlanningChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "P"
        End If
        If logLivraisonsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "D"
        End If
        If storeMaterialsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "S"
        End If
        If storeToolsChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "MT"
        End If
        If driverChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "DRV-" & team_frm.transportsDB.Item("cod_vehicle")(combo_driver_car.SelectedIndex - 1)
        End If
        If maintenanceCarChk.Checked Then
            workerTasks = If(workerTasks.Equals(""), "", workerTasks & ",")
            workerTasks += "WCM-" & team_frm.transportsDB.Item("cod_vehicle")(combo_maintenance_car.SelectedIndex - 1)
        End If

        Dim absense As String = "null"
        Dim vars As New Dictionary(Of String, String)
        If status <> "" Then ' add or edit 
            taskRequest = "edit"
            vars.Add("type", "add")
            vars.Add("plan", "true")
            vars.Add("worker", team_frm.attendanceTableBuilder.serverData(cellY, cellX).code)
            vars.Add("tasks", workerTasks)
            vars.Add("category", team_frm.works_cat.Item("cod_category")(combo_cat.SelectedIndex - 1))
            vars.Add("site", team_frm.attendanceTableBuilder.serverData(cellY, cellX).site)
            vars.Add("section", team_frm.attendanceTableBuilder.serverData(cellY, cellX).section)
            vars.Add("date", calendarPlan.SelectionStart.ToString("yyyy-MM") & "-" & If(cellX < 10, "0" & cellX, cellX))
            vars.Add("status", status)
            vars.Add("absense", absense)
            vars.Add("teams", "true")
        Else
            taskRequest = "del"
            vars.Add("type", "del")
            vars.Add("worker", team_frm.attendanceTableBuilder.serverData(cellY, cellX).code)
            vars.Add("site", team_frm.attendanceTableBuilder.serverData(cellY, cellX).site)
            vars.Add("section", team_frm.attendanceTableBuilder.serverData(cellY, cellX).section)
            vars.Add("date", calendarPlan.SelectionStart.ToString("yyyy-MM") & "-" & If(cellX < 10, "0" & cellX, cellX))
            vars.Add("status", "null")
            vars.Add("absense", "null")
            vars.Add("teams", "true")
        End If
        changes = False
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveTeamsWorkerRecordData()
    End Sub

    Private Sub driverChk_CheckedChanged(sender As Object, e As EventArgs) Handles driverChk.CheckedChanged
        If loading Then
            Exit Sub
        End If
        If driverChk.Checked Then
            maintenanceCarChk.Checked = True
            combo_driver_car.Enabled = True
            combo_driver_car.SelectedIndex = 0
        Else
            combo_driver_car.Enabled = False
            combo_driver_car.SelectedIndex = 0
        End If
    End Sub

    Private Sub combo_cat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_cat.SelectedIndexChanged
        If loading Then
            Exit Sub
        End If
        If combo_cat.SelectedIndex > 0 Then
            If team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).IndexOf("frm") > -1 Then 'foreman and general foreman
                accessTabletChk.Checked = True
                checkPlanningChk.Checked = True
                logLivraisonsChk.Checked = True
                storeToolsChk.Checked = True
                storeMaterialsChk.Checked = False
            ElseIf team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).Equals("srv") Then 'servente
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = False
                logLivraisonsChk.Checked = True
                storeToolsChk.Checked = False
                storeMaterialsChk.Checked = False
            ElseIf team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).Equals("crn") Then 'craneman
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = False
                logLivraisonsChk.Checked = False
                storeToolsChk.Checked = True
                storeMaterialsChk.Checked = True
            ElseIf team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).Equals("msnc") Then 'chef maçon
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = True
                logLivraisonsChk.Checked = False
                storeToolsChk.Checked = True
                storeMaterialsChk.Checked = True
            ElseIf team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).Equals("cptc") Then ' chef carpenter
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = True
                logLivraisonsChk.Checked = False
                storeToolsChk.Checked = True
                storeMaterialsChk.Checked = True
            ElseIf team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).Equals("stlc") Then 'chef steel works
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = True
                logLivraisonsChk.Checked = False
                storeToolsChk.Checked = True
                storeMaterialsChk.Checked = True
            Else
                accessTabletChk.Checked = False
                checkPlanningChk.Checked = False
                logLivraisonsChk.Checked = False
                storeToolsChk.Checked = False
                storeMaterialsChk.Checked = False
            End If

        End If
    End Sub

    Private Sub maintenanceCarChk_CheckedChanged(sender As Object, e As EventArgs) Handles maintenanceCarChk.CheckedChanged
        If loading Then
            Exit Sub
        End If
        If maintenanceCarChk.Checked Then
            combo_maintenance_car.Enabled = True
            combo_maintenance_car.SelectedIndex = 0
        Else
            combo_maintenance_car.Enabled = False
            combo_maintenance_car.SelectedIndex = 0
        End If
    End Sub

    Private Sub calendarPlan_DateChanged(sender As Object, e As DateRangeEventArgs)

    End Sub

    Private Sub StatusUpdate_Click(sender As Object, e As EventArgs) Handles StatusUpdate.Click

    End Sub

    Private Sub checkbox_del_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_del.CheckedChanged
        If loading Then
            Exit Sub
        End If
        If checkbox_del.Checked Then
            CheckBox_ep.Checked = False
            checkbox_mo.Checked = False

            groupBoxBossType.Enabled = False
            groupBoxResponsabilities.Enabled = False
            groupBoxTransports.Enabled = False

            accessTabletChk.Checked = False
            checkPlanningChk.Checked = False
            logLivraisonsChk.Checked = False
            storeMaterialsChk.Checked = False
            storeToolsChk.Checked = False
            driverChk.Checked = False
            maintenanceCarChk.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class