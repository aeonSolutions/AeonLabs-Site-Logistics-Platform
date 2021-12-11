Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Controls

Public Class teams_plan_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     

    Public cellX, cellY As Integer
    Private response As String = ""
    Private serverData As team_frm.workersJson(,)
    Private query_bordereau As String(,)
    Dim TaskSelection As New List(Of Integer)
    Private loading As Boolean = False

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub teams_plan_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        serverData = team_frm.serverData
        loading = True
        cellX = team_frm.cellX
        cellY = team_frm.CellY

        Me.SuspendLayout()

        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        groupboxPlanning.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxBossType.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxResponsabilities.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        groupBoxTransports.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        CheckBox_ep.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_mo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_del.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        combo_cat.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        accessTabletChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkPlanningChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        logLivraisonsChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        storeMaterialsChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        storeToolsChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        driverChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        maintenanceCarChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_driver_car.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_maintenance_car.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        worker_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        site_lbl.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        CloseBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        divider.BackColor = state.dividerColor
        CloseBtn.BackColor = state.buttonColor
        saveBtn.BackColor = state.buttonColor

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

        If (serverData(cellY, cellX).photo.Equals("")) Then
            worker_photo.Image = System.Drawing.Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
        Else
            worker_photo.Image = System.Drawing.Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & serverData(cellY, cellX).photo)))
                worker_photo.Image = tImage

            Catch ex As Exception
                translations.load("errorMessages")
                worker_photo.Image = System.Drawing.Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
                MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
        End If


        If serverData(cellY, cellX).status.Equals("EP") Then
            CheckBox_ep.Checked = True
            checkbox_mo.Checked = False
            checkbox_del.Checked = False
        ElseIf serverData(cellY, cellX).status.Equals("MO") Then
            checkbox_mo.Checked = True
            CheckBox_ep.Checked = False
            checkbox_del.Checked = False
        End If
        translations.load("teamsPlanning")
        calendar.SetDate(team_frm.calendar_log.Value.Date.ToString("yyyy-MM-") & If(cellX < 10, "0" & cellX, cellX))
        worker_lbl.Text = serverData(cellY, cellX).name & Environment.NewLine & serverData(cellY, cellX).contact
        site_lbl.Text = team_frm.works_site.Item("name")(InQueryDictionary(team_frm.works_site, serverData(cellY, cellX).site, "cod_site"))

        ResumeLayout()
    End Sub

    Private Sub teams_plan_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        If serverData(cellY, cellX).status.Equals("EP") Then
            CheckBox_ep.Checked = True
        ElseIf serverData(cellY, cellX).status.Equals("MO") Then
            checkbox_mo.Checked = True
        End If

        Dim pos As Integer = InQueryDictionary(team_frm.works_cat, serverData(cellY, cellX).category, "cod_category")
        combo_cat.SelectedIndex = If(pos > -1, pos + 1, -1)

        If serverData(cellY, cellX).assignments.IndexOf("T") > -1 Then ' access to tablet on site
            accessTabletChk.Checked = True
        End If
        If serverData(cellY, cellX).assignments.IndexOf("P") > -1 Then ' 
            checkPlanningChk.Checked = True
        End If
        If serverData(cellY, cellX).assignments.IndexOf("D") > -1 Then ' 
            logLivraisonsChk.Checked = True
        End If
        If serverData(cellY, cellX).assignments.IndexOf("S") > -1 Then ' 
            storeMaterialsChk.Checked = True
        End If
        If serverData(cellY, cellX).assignments.IndexOf("MT") > -1 Then ' 
            storeToolsChk.Checked = True
        End If
        If serverData(cellY, cellX).assignments.IndexOf("DRV-") > -1 Then ' 
            driverChk.Checked = True
            Dim array As String() = serverData(cellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
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
        If serverData(cellY, cellX).assignments.IndexOf("WCM-") > -1 Then ' 
            maintenanceCarChk.Checked = True
            Dim array2 As String() = serverData(cellY, cellX).assignments.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
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

        If calendar.SelectionStart.ToString("yyyy-MM-dd").Equals(calendar.SelectionEnd.ToString("yyyy-MM-dd")) Then 'one day selection
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
                msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Return False
            End If
            If driverChk.Checked And combo_driver_car.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message5 As String = translations.getText("errorSelectTransport")
                translations.load("messagebox")
                msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Return False
            End If
            If maintenanceCarChk.Checked And combo_maintenance_car.SelectedIndex < 1 Then
                translations.load("errorMessages")
                Dim message5 As String = translations.getText("errorSelectTransport")
                translations.load("messagebox")
                msgbox = New message_box_frm(message5 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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
        Dim message4 As String = translations.getText("questionPlanningMultiday") & calendar.SelectionStart.ToString("yyyy/MM/dd") & " " & translations.getText("to") & " " & calendar.SelectionEnd.ToString("yyyy/MM/dd") & " ?"
        translations.load("messagebox")
        msgbox = New message_box_frm(message4, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgbox.ShowDialog <> DialogResult.Yes Then
            Exit Sub
        End If

        If checkbox_del.Checked Then
            translations.load("teamsPlanning")
            Dim message5 As String = translations.getText("teamsClean")
            translations.load("messagebox")
            msgbox = New message_box_frm(message5 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

        Dim today As Date = Date.ParseExact(calendar.TodayDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)
        Dim selectedDate As Date = calendar.SelectionStart.ToString("yyyy-MM-dd")
        Dim selectedDateEnd As Date = calendar.SelectionEnd.ToString("yyyy-MM-dd")

        Dim start_date As Integer = calendar.SelectionStart.ToString("dd")
        Dim end_date As Integer = calendar.SelectionEnd.ToString("dd")
        Dim changes As Boolean = False
        For i = start_date To end_date
            translations.load("teamsPlanning")
            StatusUpdate.Text = translations.getText("updatingDay") & " " & calendar.SelectionStart.ToString("yyyy-MM") & "-" & If(i < 10, "0" & i.ToString(), i.ToString)
            StatusUpdate.Refresh()

            If IsWeekday(calendar.SelectionStart.ToString("yyyy/MM") & "/" & i.ToString()) Then
                Dim vars As New Dictionary(Of String, String)
                vars.Add("task", "5")
                If status.Equals("clean") Then
                    vars.Add("type", "del")
                Else
                    vars.Add("type", "add")
                End If
                If team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).IndexOf("frm") > -1 Then 'foreman and general foreman
                    vars.Add("plan", "true")
                End If
                vars.Add("tasks", workerTasks)
                vars.Add("category", team_frm.works_cat.Item("cod_category")(combo_cat.SelectedIndex - 1))
                vars.Add("worker", serverData(cellY, cellX).code)
                vars.Add("site", serverData(cellY, cellX).site)
                vars.Add("section", serverData(cellY, cellX).section)
                vars.Add("date", calendar.SelectionStart.ToString("yyyy-MM") & "-" & If(i < 10, "0" & i, i))
                vars.Add("status", status)
                vars.Add("absense", absense)
                vars.Add("teams", "true")

                Dim request As New HttpData(state)
                response = request.RequestData(vars)
                If Not IsResponseOk(response) Then
                    translations.load("messagebox")
                    MainMdiForm.statusMessage = GetMessage(response)
                    changes = False
                Else
                    changes = True
                End If
            End If
        Next i
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If changes Then
            MainMdiForm.statusMessage = translations.getText("resultSuccessSaveRecord")
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultNoChangesRecord"), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub saveOneDay()
        Dim status As String = ""
        Dim query As String = ""
        Dim temp As String = ""


        If checkbox_del.Checked Then
            translations.load("teamsPlanning")
            Dim message4 As String = translations.getText("teamsClean")
            translations.load("messagebox")
            msgbox = New message_box_frm(message4 & "?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog = DialogResult.Yes Then
                status = ""
            Else
                Exit Sub
            End If
        Else
            Dim today As Date = Date.ParseExact(calendar.TodayDate.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)
            Dim selectedDate As Date = Date.ParseExact(calendar.SelectionStart.ToString("yyyy-MM-") & If(cellX < 10, "0" & cellX, cellX), "yyyy-MM-dd", CultureInfo.InvariantCulture)

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

        If status <> "" Then ' add or edit 
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "5")
            vars.Add("type", "add")
            If team_frm.works_cat.Item("reference")(combo_cat.SelectedIndex - 1).IndexOf("frm") > -1 Then 'foreman and general foreman
                vars.Add("plan", "true")
            End If
            vars.Add("worker", serverData(cellY, cellX).code)
            vars.Add("tasks", workerTasks)
            vars.Add("category", team_frm.works_cat.Item("cod_category")(combo_cat.SelectedIndex - 1))
            vars.Add("site", serverData(cellY, cellX).site)
            vars.Add("section", serverData(cellY, cellX).section)
            vars.Add("date", calendar.SelectionStart.ToString("yyyy-MM") & "-" & cellX)
            vars.Add("status", status)
            vars.Add("absense", absense)
            vars.Add("teams", "true")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                MainMdiForm.statusMessage = translations.getText("resultSuccessAddRecord")
            End If
        Else ' delete record
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "5")
            vars.Add("type", "del")
            If Not team_frm.activeTable.Equals("teams") Then
                vars.Add("plan", "true")
            End If
            vars.Add("worker", serverData(cellY, cellX).code)
            vars.Add("site", serverData(cellY, cellX).site)
            vars.Add("section", serverData(cellY, cellX).section)
            vars.Add("date", calendar.SelectionStart.ToString("yyyy-MM") & "-" & cellX)
            vars.Add("status", "null")
            vars.Add("absense", "null")
            vars.Add("teams", "true")

            Dim request As New HttpData(state)
            response = request.RequestData(vars)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                translations.load("messagebox")
                msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord"), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                msgbox.ShowDialog()
            End If
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
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