Imports System.Drawing.Text

Public Class multiday_frm
    Private state As State
    Private translations As languageTranslations
    Public cellX, cellY As Integer
    Private response As String = ""
    Dim time As TimeSpan
    Private msgbox As message_box_frm
    Private ts As TimeSpan
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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
        Me.Refresh()
    End Sub

    Private Sub multiday_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        cellX = logger_frm.cellX
        cellY = logger_frm.cellY
    End Sub

    Private Sub multiday_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        Me.SuspendLayout()

        title.Font = New Font(state.fontText.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        GroupBox1.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        startdate_lbl.Font = New Font(state.fontText.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Regular)
        CheckBox_p.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_ah.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_a.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_c.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_i.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_v.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        checkbox_logs_only.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        hora_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        saveBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        saveBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor

        translations.load("attendance")
        GroupBox1.Text = translations.getText("attendanceValidationTitle")
        startdate_lbl.Text = logger_frm.calendar.SelectionStart.ToString("yyyy-MM-dd")
        CheckBox_p.Text = translations.getText("fullDay")
        CheckBox_ah.Text = translations.getText("absenceTime")
        CheckBox_a.Text = translations.getText("fullDayAbsent")
        CheckBox_c.Text = translations.getText("playDay")
        checkbox_i.Text = translations.getText("badWeather")
        checkbox_v.Text = translations.getText("holidays")
        checkbox_logs_only.Text = translations.getText("validateWorkersWithRecord")
        title.Text = translations.getText("multipleValidationTitle")
        hora_lbl.Text = translations.getText("time")

        translations.load("commonForm")
        saveBtn.Text = translations.getText("saveBtn")
        closeBtn.Text = translations.getText("closeBtn")

        absense_time.CustomFormat = "HH:mm"
        absense_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        absense_time.ShowUpDown = True
        absense_time.Value = "2000-01-01 00:00"
        absense_time.Enabled = False
        hora_lbl.Enabled = False
        checkbox_i.Checked = False
        checkbox_v.Checked = False
        CheckBox_a.Checked = False
        CheckBox_c.Checked = False
        CheckBox_ah.Checked = False
        CheckBox_p.Checked = False

        Dim dateSelected As DateTime = Convert.ToDateTime(logger_frm.calendar_log.SelectionStart.ToString("yyyy-MM-dd"))
        Dim dateToday As DateTime = Convert.ToDateTime(Date.Today().ToString("yyyy-MM-dd"))
        ts = dateToday.Subtract(dateSelected)

        motif.Text = ""
        checkMotifEnabled()

        Me.ResumeLayout()
    End Sub

    Private Function checkMotifEnabled() As Boolean
        translations.load("attendance")
        If Not CheckBox_p.Checked And Not checkbox_v.Checked And Not CheckBox_a.Checked And Not CheckBox_ah.Checked Then
            motif.Enabled = True
            groupBoxMotif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= state.delayDaysValidationAttendance And ((logger_frm.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkin.Equals("")) And (logger_frm.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkout.Equals(""))) Then
            motif.Enabled = True
            groupBoxMotif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= state.delayDaysValidationAttendance And (Not (logger_frm.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkin.Equals("")) And (logger_frm.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkout.Equals(""))) Then
            groupBoxMotif.Enabled = True
            motif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= state.delayDaysValidationAttendance And (Not (logger_frm.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkin.Equals("")) And Not (logger_frm.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.serverData(cellY, cellX).checkout.Equals(""))) Then
            groupBoxMotif.Enabled = False
            motif.Enabled = False
            groupBoxMotif.Text = translations.getText("attendanceNoValidationJustification")
            Return False
        ElseIf Math.Abs(ts.Days) > state.delayDaysValidationAttendance Then
            groupBoxMotif.Enabled = True
            motif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        End If
    End Function

    Private Sub textbox_ah_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CheckBox_ah.Checked = True
        checkbox_i.Checked = False
        checkbox_v.Checked = False
        CheckBox_a.Checked = False
        CheckBox_c.Checked = False
        CheckBox_p.Checked = False

    End Sub

    Private Sub CheckBox_p_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_p.CheckedChanged
        If CheckBox_p.Checked Then
            checkbox_i.Checked = False
            checkbox_v.Checked = False
            CheckBox_a.Checked = False
            CheckBox_c.Checked = False
            CheckBox_ah.Checked = False
        End If
    End Sub

    Private Sub CheckBox_i_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_i.CheckedChanged
        If checkbox_i.Checked Then
            CheckBox_p.Checked = False
            checkbox_v.Checked = False
            CheckBox_a.Checked = False
            CheckBox_c.Checked = False
            CheckBox_ah.Checked = False
        End If
    End Sub

    Private Sub CheckBox_v_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_v.CheckedChanged
        If checkbox_v.Checked Then
            checkbox_i.Checked = False
            CheckBox_p.Checked = False
            CheckBox_a.Checked = False
            CheckBox_c.Checked = False
            CheckBox_ah.Checked = False
        End If
    End Sub

    Private Sub CheckBox_a_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_a.CheckedChanged
        If CheckBox_a.Checked Then
            checkbox_i.Checked = False
            checkbox_v.Checked = False
            CheckBox_p.Checked = False
            CheckBox_c.Checked = False
            CheckBox_ah.Checked = False
        End If
    End Sub

    Private Sub CheckBox_c_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_c.CheckedChanged
        If CheckBox_c.Checked Then
            checkbox_i.Checked = False
            checkbox_v.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
        End If
    End Sub

    Private Sub CheckBox_ah_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ah.CheckedChanged
        If CheckBox_ah.Checked Then
            checkbox_i.Checked = False
            checkbox_v.Checked = False
            CheckBox_a.Checked = False
            CheckBox_c.Checked = False
            CheckBox_p.Checked = False
            absense_time.Enabled = True
            hora_lbl.Enabled = True
        Else
            absense_time.Enabled = False
            hora_lbl.Enabled = False

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        saveBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.BackColor = Color.Silver
        closeBtn.BackColor = Color.Silver

        Dim dateSelected As DateTime = Convert.ToDateTime(logger_frm.calendar_log.SelectionStart.ToString("yyyy-MM-dd"))
        Dim dateToday As DateTime = Convert.ToDateTime(Date.Today().ToString("yyyy-MM-dd"))
        Dim ts As TimeSpan = dateToday.Subtract(dateSelected)

        If motif.Text.Equals("") And checkMotifEnabled() Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("attendanceErrorValidationJustification")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = state.buttonColor
            closeBtn.BackColor = state.buttonColor
            Exit Sub
        End If

        saveBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.BackColor = Color.Silver
        closeBtn.BackColor = Color.Silver
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If checkbox_i.Checked Or checkbox_v.Checked Or CheckBox_a.Checked Or CheckBox_c.Checked Or CheckBox_ah.Checked Or CheckBox_p.Checked Then
            Dim start_date As Integer = logger_frm.calendar.SelectionStart.ToString("dd")
            Dim end_date As Integer = logger_frm.calendar.SelectionEnd.ToString("dd")
            Dim i, j As Integer
            Dim status As String = ""
            Dim response As String = ""
            Dim temp As String = ""
            Dim temp2 As String = ""

            If checkbox_logs_only.Checked Then
                translations.load("attendance")
                temp2 = translations.getText("workersWithRecord")
            Else
                translations.load("attendance")
                temp2 = translations.getText("allWorkers")
            End If

            If checkbox_i.Checked Then
                status = "I"

            ElseIf checkbox_v.Checked Then
                status = "V"

            ElseIf CheckBox_a.Checked Then
                status = "A"

            ElseIf CheckBox_c.Checked Then
                status = "C"
            ElseIf CheckBox_ah.Checked Then
                If absense_time.Value.TimeOfDay.ToString("hh\:mm\:ss").Equals("00:00:00") Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorZeroAbsenseTime")
                    translations.load("messagebox")
                    msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = state.buttonColor
                    closeBtn.BackColor = state.buttonColor
                    Exit Sub
                End If

                If absense_time.Value.TimeOfDay > state.maxWorkHoursDay Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorMaxWorkTime")
                    translations.load("messagebox")
                    msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = state.buttonColor
                    closeBtn.BackColor = state.buttonColor
                    Exit Sub
                End If

                status = "PI"
                temp = "ah"
            ElseIf CheckBox_p.Checked Then
                status = "P"
            End If
            Dim absense As String = "null"
            If temp <> "" Then
                absense = absense_time.Value.TimeOfDay.ToString("hh\:mm\:ss")
            End If
            If status.Equals("") Then
                translations.load("attendance")
                Dim message3 As String = translations.getText("noChanges")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = state.buttonColor
                closeBtn.BackColor = state.buttonColor
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                Exit Sub
            End If

            translations.load("messagebox")
            Dim message4 As String = translations.getText("question")
            translations.load("attendance")
            msgbox = New message_box_frm(translations.getText("sureToValidate") & " " & temp2 & " " & translations.getText("sureToValidateDays") & " " & logger_frm.calendar.SelectionStart.ToString("yyyy-MM-dd") & " ?", message4, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If msgbox.ShowDialog <> DialogResult.OK Then
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = state.buttonColor
                closeBtn.BackColor = state.buttonColor
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                Exit Sub
            End If

            Dim changes As Boolean = False
            For i = start_date To end_date
                If IsWeekday(logger_frm.calendar.SelectionStart.ToString("yyyy/MM") & "/" & i.ToString()) Then
                    For j = 0 To logger_frm.idxTableWorkerPos.Length - 1

                        If (checkbox_logs_only.Checked And ((Not logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).checkin.Equals("") Or Not logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).checkin.Equals("00:00:00")) And
                            (logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).status.Equals("") Or logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).status.Equals("EP") Or
                            logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).status.Equals("MO")))) Or Not checkbox_logs_only.Checked Then
                            Dim vars As New Dictionary(Of String, String)
                            vars.Add("task", "5")
                            vars.Add("type", "add")
                            vars.Add("worker", logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).code)
                            vars.Add("site", logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).site)
                            vars.Add("section", logger_frm.serverData(logger_frm.idxTableWorkerPos(j), i).section)
                            vars.Add("date", logger_frm.calendar.SelectionStart.ToString("yyyy-MM") & "-" & i)
                            vars.Add("status", status)
                            vars.Add("absense", absense)
                            If Math.Abs(ts.Days) > state.delayDaysValidationAttendance Then
                                vars.Add("motif", motif.Text)
                            End If
                            Dim request As New HttpData(state)
                            response = request.RequestData(vars)
                            If Not IsResponseOk(response) Then
                                translations.load("messagebox")
                                msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                                msgbox.ShowDialog()
                                changes = False
                            Else
                                changes = True
                            End If
                        End If
                    Next j
                End If
            Next i
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If changes Then
                translations.load("attendance")
                MainMdiForm.statusMessage = translations.getText("validationSuccess")
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                translations.load("attendance")
                Dim message3 As String = translations.getText("noChanges")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        Else
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If

            translations.load("attendance")
            Dim message3 As String = translations.getText("errorSelectAnOption")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        saveBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.BackColor = state.buttonColor
        closeBtn.BackColor = state.buttonColor

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub


End Class