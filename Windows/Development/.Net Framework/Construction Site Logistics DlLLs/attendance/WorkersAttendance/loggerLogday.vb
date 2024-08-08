Imports System.Drawing
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries

Public Class logday_frm
    Public cellX, cellY As Integer
    Private response As String = ""
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private ts As TimeSpan
    Private time As TimeSpan
    Private WithEvents attendanceDataRequests As IDataAttendanceRequests
    Private actionType As String
    private mainForm As MainMdiForm
    Private logger_frm As attendanceLoggerForm

    Private Sub CloseMe()
        Me.Close()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Public Sub New(_mainMdiForm As MainMdiForm, _logger_frm As attendanceLoggerForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        logger_frm = _logger_frm
        stateCore = mainForm.state

        Me.Refresh()
    End Sub
    Private Sub journal_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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
    End Sub

    Private Sub logday_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)
        Me.SuspendLayout()

        worker_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        groupbox_record.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        groupbox_validation.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        groupbox_gruista.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        groupBoxMotif.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)

        checkin_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        checkout_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        time_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)

        CheckBox_ah.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        CheckBox_v.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        CheckBox_a.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        CheckBox_i.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        CheckBox_m.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        CheckBox_p.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        checkbox_gruista_fullday.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        checkbox_gruista_parcial.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        checkbox_gruista_on_grua.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        CheckBox_cleanCheckout.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        gruista_time.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        absense_time.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        hora_lbl1.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        hora_lbl2.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        motif.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        saveBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        saveBtn.BackColor = stateCore.buttonColor

        translations.load("attendance")
        groupbox_record.Text = translations.getText("smartcardRecordTitle")
        groupbox_validation.Text = translations.getText("attendanceValidationTitle")
        time_lbl.Text = translations.getText("duration")
        CheckBox_ah.Text = translations.getText("absenceTime")
        CheckBox_v.Text = translations.getText("holidays")
        CheckBox_a.Text = translations.getText("fullDayAbsent")
        CheckBox_m.Text = translations.getText("malady")
        CheckBox_p.Text = translations.getText("fullDay")
        CheckBox_i.Text = translations.getText("badWeather")
        checkbox_gruista_fullday.Text = translations.getText("cranemanFullDay")
        checkbox_gruista_parcial.Text = translations.getText("cranemanPartialDay")
        CheckBox_cleanCheckout.Text = translations.getText("clearCheckoutRecord")
        worksHours_lbl.Text = translations.getText("workHours") & ": " & stateCore.maxWorkHoursDay.ToString("c")

        cellX = logger_frm.cellX
        cellY = logger_frm.cellY
        Dim ss = logger_frm.attendanceTableBuilder.serverData
        If logger_frm.attendanceTableBuilder.serverData(cellY, cellX).reference.ToLower.Equals("crn") Then
            checkbox_gruista_on_grua.Text = translations.getText("cranemanOnCrane")
            groupbox_gruista.Text = translations.getText("cranemanTitle")

        Else
            checkbox_gruista_on_grua.Text = translations.getText("machinistOnMachine")
            groupbox_gruista.Text = translations.getText("machinistTitle")

        End If

        hora_lbl1.Text = translations.getText("time")
        hora_lbl2.Text = translations.getText("time")
        translations.load("commonForm")
        saveBtn.Text = translations.getText("saveBtn")
        closeBtn.Text = translations.getText("closeBtn")

        absense_time.CustomFormat = "HH:mm"
        absense_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        absense_time.ShowUpDown = True
        gruista_time.CustomFormat = "HH:mm"
        gruista_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        gruista_time.ShowUpDown = True
        absense_time.Refresh()
        Dim query As String = ""

        CheckBox_ah.Checked = False
        CheckBox_v.Checked = False
        CheckBox_a.Checked = False
        CheckBox_m.Checked = False
        CheckBox_p.Checked = False
        absense_time.Enabled = False
        checkbox_gruista_on_grua.Enabled = False
        checkbox_gruista_fullday.Enabled = False
        checkbox_gruista_parcial.Enabled = False

        translations.load("attendance")
        worker_lbl.Text = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).name
        Me.Text = translations.getText("formTitle") & " " & logger_frm.works_site.Item("name")(InQueryDictionary(logger_frm.works_site, logger_frm.attendanceTableBuilder.serverData(cellY, cellX).site, "cod_site")) & " [" & logger_frm.calendar.Value.Date.ToString("yyyy-MM") & "-" & cellX & "]"

        checkin_lbl.Text = translations.getText("withoutCheckin")
        checkout_lbl.Text = translations.getText("withoutCheckout")
        time_lbl.Text = " - - "
        data_lbl.Text = cellX & ", " & logger_frm.calendar.Value.Date.ToString("MMMM, yyyy")

        If logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Then
            checkin_lbl.Text = translations.getText("withoutCheckin")
        Else
            checkin_lbl.Text = translations.getText("checkin") & ": " & logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin
        End If
        If logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Then
            checkout_lbl.Text = translations.getText("withoutCheckout")
        Else
            checkout_lbl.Text = translations.getText("checkout") & ": " & logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout
        End If
        CheckBox_cleanCheckout.Enabled = False
        If Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") And Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Then
            CheckBox_cleanCheckout.Enabled = True
        End If

        'calc how many days is from today
        Dim dateSelected As DateTime = Convert.ToDateTime(logger_frm.calendar_log.Value.Date.ToString("yyyy-MM-") & cellX)
        Dim dateToday As DateTime = Convert.ToDateTime(Date.Today().ToString("yyyy-MM-dd"))
        ts = dateToday.Subtract(dateSelected)

        motif.Text = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).validationReason

        Dim checkinStr As String
        Dim checkoutStr As String
        checkinStr = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin
        checkoutStr = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout

        If Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("") AndAlso (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00")) AndAlso
            Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Then
            checkinStr = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin
            checkoutStr = "17:30:00"
        End If

        If (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00")) AndAlso (Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("") And Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00")) Then
            checkoutStr = logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout
            checkinStr = "07:30:00"
        End If
        time = New TimeSpan(0, 0, 0)
        If Not checkinStr.Equals("null") And Not checkoutStr.Equals("null") And Not checkinStr.Equals("") And Not checkoutStr.Equals("") And Not checkinStr.Equals("00:00:00") And Not checkoutStr.Equals("00:00:00") Then
            Dim checkin = DateTime.ParseExact(checkinStr, "HH:mm:ss", CultureInfo.InvariantCulture)
            Dim checkout = DateTime.ParseExact(checkoutStr, "HH:mm:ss", CultureInfo.InvariantCulture)
            time = checkout - checkin
            If time < New TimeSpan(0, 0, 0) Then
                time = New TimeSpan(0, 0, 0)
            End If

            If checkout.Hour >= 13 And checkin.Hour < 13 Then
                time = time.Subtract(New TimeSpan(0, 30, 0))
            End If
            time_lbl.Text = translations.getText("duration") & ": " & time.ToString("c")
            gruista_time.Value = DateTime.ParseExact(time.ToString, "HH:mm:ss", CultureInfo.InvariantCulture)
        Else

        End If
        If Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).absense.Equals("") AndAlso Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).absense.Equals("00:00:00") Then
            absense_time.Value = "2005-01-01 " & logger_frm.attendanceTableBuilder.serverData(cellY, cellX).absense
            CheckBox_ah.Checked = True
            absense_time.Enabled = True
            absense_time.Refresh()
        ElseIf Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("") AndAlso Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("") AndAlso
            Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") AndAlso Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Then
            Dim absense As TimeSpan
            If stateCore.isWorkingHoursIncompleteWorkDayHoursLogged Then
                absense = time
            Else
                absense = stateCore.maxWorkHoursDay - time
            End If
            absense_time.Value = "2005-01-01 " & absense.ToString("hh\:mm\:ss")
            absense_time.Refresh()
        Else
            absense_time.Value = "2005-01-01 00:00:00"
            absense_time.Refresh()

        End If
        If logger_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("PI") Then
            CheckBox_ah.Checked = True
        ElseIf logger_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("V") Then
            CheckBox_v.Checked = True
        ElseIf logger_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("A") Then
            CheckBox_a.Checked = True
        ElseIf logger_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("M") Then
            CheckBox_m.Checked = True
        ElseIf logger_frm.attendanceTableBuilder.serverData(cellY, cellX).status.Equals("P") Then
            CheckBox_p.Checked = True
        End If

        If (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).photo.Equals("")) Then
            worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
        Else
            worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & logger_frm.attendanceTableBuilder.serverData(cellY, cellX).photo)))
                worker_photo.Image = tImage
            Catch ex As Exception
                worker_photo.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
                translations.load("attendance")
                mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            worker_photo.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        checkMotifEnabled()
        ResumeLayout()

    End Sub

    Private Function checkMotifEnabled() As Boolean
        translations.load("attendance")
        If Not CheckBox_p.Checked And Not CheckBox_v.Checked And Not CheckBox_a.Checked And Not CheckBox_m.Checked And Not CheckBox_ah.Checked And Not CheckBox_cleanCheckout.Checked Then
            motif.Enabled = True
            groupBoxMotif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= stateCore.delayDaysValidationAttendance And ((logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("")) And (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals(""))) Then
            motif.Enabled = True
            groupBoxMotif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= stateCore.delayDaysValidationAttendance And (Not (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("")) And (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals(""))) Then
            groupBoxMotif.Enabled = True
            motif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        ElseIf Math.Abs(ts.Days) <= stateCore.delayDaysValidationAttendance And (Not (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("")) And Not (logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("00:00:00") Or logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals(""))) Then
            groupBoxMotif.Enabled = False
            motif.Enabled = False
            groupBoxMotif.Text = translations.getText("attendanceNoValidationJustification")
            Return False
        ElseIf Math.Abs(ts.Days) > stateCore.delayDaysValidationAttendance Then
            groupBoxMotif.Enabled = True
            motif.Enabled = True
            groupBoxMotif.Text = translations.getText("attendanceValidationJustification")
            Return True
        End If
        Return False
    End Function
    Private Sub textbox_ah_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CheckBox_ah.Checked = True
        CheckBox_i.Checked = False
        CheckBox_v.Checked = False
        CheckBox_m.Checked = False
        CheckBox_a.Checked = False
        CheckBox_p.Checked = False
        CheckBox_c.Checked = False
        CheckBox_cleanCheckout.Checked = False
    End Sub

    Private Sub CheckBox_p_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_p.CheckedChanged
        If CheckBox_p.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_m.Checked = False
            CheckBox_a.Checked = False
            CheckBox_c.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_cleanCheckout.Checked = False

            groupbox_gruista.Enabled = True
            checkbox_gruista_on_grua.Enabled = True
            checkbox_gruista_fullday.Enabled = True
            checkbox_gruista_parcial.Enabled = True
            gruista_time.Value = "2005-01-01 " & time.ToString("hh\:mm\:ss")
        Else
            groupbox_gruista.Enabled = False
        End If
        checkMotifEnabled()
    End Sub


    Private Sub CheckBox_v_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_v.CheckedChanged
        If CheckBox_v.Checked Then
            CheckBox_i.Checked = False
            CheckBox_c.Checked = False
            CheckBox_m.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_cleanCheckout.Checked = False
        End If
        checkMotifEnabled()
    End Sub
    Private Sub CheckBox_c_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_c.CheckedChanged
        If CheckBox_c.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_m.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_cleanCheckout.Checked = False
        End If
        checkMotifEnabled()
    End Sub

    Private Sub CheckBox_a_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_a.CheckedChanged
        If CheckBox_a.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_m.Checked = False
            CheckBox_c.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_cleanCheckout.Checked = False
        End If
        checkMotifEnabled()
    End Sub
    Private Sub CheckBox_m_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_m.CheckedChanged
        If CheckBox_m.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_c.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_cleanCheckout.Checked = False
        End If
        checkMotifEnabled()
    End Sub
    Private Sub CheckBox_ah_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ah.CheckedChanged
        If CheckBox_ah.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_m.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_c.Checked = False
            CheckBox_cleanCheckout.Checked = False

            absense_time.Enabled = True
            checkbox_gruista_on_grua.Enabled = True
            checkbox_gruista_fullday.Enabled = True
            checkbox_gruista_parcial.Enabled = True
            groupbox_gruista.Enabled = True
            gruista_time.Value = absense_time.Value
        Else
            absense_time.Enabled = False
            groupbox_gruista.Enabled = False
        End If
        checkMotifEnabled()
    End Sub

    Private Sub CheckBox_cleanCheckout_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_cleanCheckout.CheckedChanged
        If CheckBox_cleanCheckout.Checked Then
            CheckBox_i.Checked = False
            CheckBox_v.Checked = False
            CheckBox_m.Checked = False
            CheckBox_a.Checked = False
            CheckBox_p.Checked = False
            CheckBox_ah.Checked = False
            CheckBox_c.Checked = False
        End If
        checkMotifEnabled()
    End Sub

    Private Sub checkbox_gruista_on_grua_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_gruista_on_grua.CheckedChanged
        If checkbox_gruista_on_grua.Checked Then
            checkbox_gruista_fullday.Enabled = True
            checkbox_gruista_parcial.Enabled = True
        Else
            checkbox_gruista_fullday.Enabled = False
            checkbox_gruista_parcial.Enabled = False
        End If
    End Sub

    Private Sub checkbox_gruista_parcial_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_gruista_parcial.CheckedChanged
        If checkbox_gruista_parcial.Checked Then
            checkbox_gruista_fullday.Checked = False
            gruista_time.Enabled = True
            hora_lbl2.Enabled = True
            If CheckBox_ah.Checked Then
                gruista_time.Value = absense_time.Value
            End If
            If CheckBox_p.Checked Then
                gruista_time.Value = "2005-01-01 " & time.ToString("hh\:mm\:ss")
            End If
        Else
            hora_lbl2.Enabled = False
            gruista_time.Enabled = False
        End If
    End Sub

    Private Sub CheckBox_EnableMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_EnableMultiple.CheckedChanged
        If CheckBox_EnableMultiple.Checked Then
            PictureBoxMultiWarning.Image = Image.FromFile(mainForm.state.imagesPath & "warning.png")
            checkbox_logs_only.Enabled = True
            groupbox_gruista.Enabled = False
            CheckBox_cleanCheckout.Enabled = False
            CheckBox_m.Enabled = False

            checkbox_logs_only.Checked = False
            CheckBox_cleanCheckout.Checked = False
            CheckBox_m.Checked = False
            checkbox_gruista_on_grua.Checked = False
        Else
            PictureBoxMultiWarning.Image = ChangeOpacity(Image.FromFile(stateCore.imagesPath & "warning.png"), 0.5)
            checkbox_logs_only.Enabled = False
            groupbox_gruista.Enabled = True
            CheckBox_cleanCheckout.Enabled = True
            CheckBox_m.Enabled = True
        End If
    End Sub

    Private Sub Checkbox_gruista_fullday_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox_gruista_fullday.CheckedChanged
        If checkbox_gruista_fullday.Checked Then
            checkbox_gruista_parcial.Checked = False
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If CheckBox_EnableMultiple.Checked Then
            saveMultiple()
        Else
            saveSingle()
        End If
    End Sub

    Private Sub saveSingle()
        saveBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.BackColor = Color.Silver
        closeBtn.BackColor = Color.Silver

        Dim status As String = ""
        Dim query As String = ""
        Dim temp As String = ""

        Dim dateSelected As DateTime = Convert.ToDateTime(logger_frm.calendar_log.Value.Date.ToString("yyyy-MM-") & cellX)
        Dim dateToday As DateTime = Convert.ToDateTime(Date.Today().ToString("yyyy-MM-dd"))
        Dim ts As TimeSpan = dateToday.Subtract(dateSelected)
        If checkbox_gruista_on_grua.Checked And Not checkbox_gruista_fullday.Checked And Not checkbox_gruista_parcial.Checked Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("attendanceErrorCheckCraneman")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = stateCore.buttonColor
            closeBtn.BackColor = stateCore.buttonColor
            Exit Sub
        End If
        If motif.Text.Equals("") And checkMotifEnabled() Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("attendanceErrorValidationJustification")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = stateCore.buttonColor
            closeBtn.BackColor = stateCore.buttonColor
            Exit Sub
        End If
        If CheckBox_i.Checked = False And CheckBox_v.Checked = False And CheckBox_a.Checked = False And CheckBox_m.Checked = False And CheckBox_ah.Checked = False And CheckBox_p.Checked = False And CheckBox_cleanCheckout.Checked = False Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("clearRecordMessage")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & "? ", translations.getText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If msgbox.ShowDialog = DialogResult.Yes Then
                status = "S"
            Else
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = stateCore.buttonColor
                closeBtn.BackColor = stateCore.buttonColor
                Exit Sub
            End If
        Else
            If checkbox_gruista_parcial.Checked Then
                If gruista_time.Value.TimeOfDay.ToString("hh\:mm\:ss").Equals("00:00:00") Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorZeroAbsenseTime")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
                    Exit Sub
                End If
                If gruista_time.Value.TimeOfDay > stateCore.maxWorkHoursDay Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorMaxWorkTime")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
                    Exit Sub
                End If
            End If

            If CheckBox_i.Checked Then
                status = "I"
            ElseIf CheckBox_v.Checked Then
                status = "V"
            ElseIf CheckBox_a.Checked Then
                status = "A"
            ElseIf CheckBox_m.Checked Then
                status = "M"
            ElseIf CheckBox_ah.Checked Then
                If absense_time.Value.TimeOfDay.ToString("hh\:mm\:ss").Equals("00:00:00") Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorZeroAbsenseTime")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
                    Exit Sub
                End If

                If absense_time.Value.TimeOfDay > stateCore.maxWorkHoursDay Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorMaxWorkTime")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
                    Exit Sub
                End If
                status = "PI"
                temp = "ah"
            ElseIf CheckBox_p.Checked Then
                status = "P"
            ElseIf CheckBox_cleanCheckout.Checked Then
                translations.load("attendance")
                Dim checkin As TimeSpan = TimeSpan.Parse(logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin)
                Dim checkout As TimeSpan = TimeSpan.Parse(logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout)
                Dim diff As TimeSpan
                diff = checkout - checkin

                If diff.Minutes <= stateCore.maxMinutesForClearCheckout Then
                    status = "clearcheckout"
                Else
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorClearCheckout")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor

                    Exit Sub
                End If
            End If
        End If

        Dim absense As String = "null"
        If temp <> "" Then
            absense = absense_time.Value.TimeOfDay.ToString("hh\:mm\:ss")
        End If

        If Not logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkin.Equals("") And logger_frm.attendanceTableBuilder.serverData(cellY, cellX).checkout.Equals("") And Now.ToLongTimeString < #6:00:00 PM# Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("questionOngoingDayValidation")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & "? ", translations.getText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            If Not msgbox.ShowDialog = DialogResult.Yes Then
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = stateCore.buttonColor
                closeBtn.BackColor = stateCore.buttonColor

                Exit Sub
            End If
        End If
        Dim vars As New Dictionary(Of String, String)

        If status <> "S" Then
            actionType = "save"
            vars.Add("type", "add")
            vars.Add("worker", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).code)
            vars.Add("section", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).section)
            vars.Add("site", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).site)
            vars.Add("date", logger_frm.calendar.Value.Date.ToString("yyyy-MM") & "-" & cellX)
            vars.Add("status", status)
            vars.Add("absense", absense)
            If checkbox_gruista_parcial.Checked Then
                vars.Add("craneman", gruista_time.Value.TimeOfDay.ToString("hh\:mm\:ss"))
            ElseIf checkbox_gruista_fullday.Checked Then
                vars.Add("craneman", stateCore.maxWorkHoursDay.ToString("hh\:mm\:ss"))
            Else
                vars.Add("craneman", "00:00:00")
            End If
            If checkMotifEnabled() Then
                vars.Add("motif", motif.Text)
            End If

            attendanceDataRequests.Initialise(stateCore)
            attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
            response = attendanceDataRequests.SaveLoggerValidationData()
        Else ' delete record
            actionType = "del"
            vars.Add("type", "del")
            vars.Add("worker", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).code)
            vars.Add("section", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).section)
            vars.Add("site", logger_frm.attendanceTableBuilder.serverData(cellY, cellX).site)
            vars.Add("date", logger_frm.calendar.Value.Date.ToString("yyyy-MM") & "-" & cellX)
            vars.Add("status", status)
            vars.Add("absense", "null")
            vars.Add("motif", motif.Text)

            attendanceDataRequests.Initialise(stateCore)
            attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
            response = attendanceDataRequests.SaveLoggerValidationData()
        End If
        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = stateCore.buttonColor
            closeBtn.BackColor = stateCore.buttonColor
        Else
            translations.load("attendance")
            If actionType.Equals("del") Then
                mainForm.statusMessage = translations.getText("validationDeleted")
            Else
                mainForm.statusMessage = translations.getText("validationSuccess")
            End If
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = stateCore.buttonColor
            closeBtn.BackColor = stateCore.buttonColor

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub saveMultiple()
        Dim changes As Boolean = False

        saveBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.BackColor = Color.Silver
        closeBtn.BackColor = Color.Silver

        Dim dateSelected As DateTime = Convert.ToDateTime(logger_frm.calendar_log.Value.Date.ToString("yyyy-MM-dd"))
        Dim dateToday As DateTime = Convert.ToDateTime(Date.Today().ToString("yyyy-MM-dd"))
        Dim ts As TimeSpan = dateToday.Subtract(dateSelected)

        If motif.Text.Equals("") And checkMotifEnabled() Then
            translations.load("attendance")
            Dim message3 As String = translations.getText("attendanceErrorValidationJustification")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            saveBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.BackColor = stateCore.buttonColor
            closeBtn.BackColor = stateCore.buttonColor
            Exit Sub
        End If

        saveBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.BackColor = Color.Silver
        closeBtn.BackColor = Color.Silver

        If CheckBox_i.Checked Or CheckBox_v.Checked Or CheckBox_a.Checked Or CheckBox_c.Checked Or CheckBox_ah.Checked Or CheckBox_p.Checked Then
            Dim start_date As Integer = logger_frm.calendar.Value.Date.ToString("dd")
            Dim end_date As Integer = logger_frm.calendar.Value.Date.ToString("dd")
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

            If CheckBox_i.Checked Then
                status = "I"

            ElseIf CheckBox_v.Checked Then
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
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
                    Exit Sub
                End If

                If absense_time.Value.TimeOfDay > stateCore.maxWorkHoursDay Then
                    translations.load("attendance")
                    Dim message3 As String = translations.getText("errorMaxWorkTime")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    saveBtn.Enabled = True
                    closeBtn.Enabled = True
                    saveBtn.BackColor = stateCore.buttonColor
                    closeBtn.BackColor = stateCore.buttonColor
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
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = stateCore.buttonColor
                closeBtn.BackColor = stateCore.buttonColor
                Exit Sub
            End If
            translations.load("messagebox")
            Dim message4 As String = translations.getText("question")
            translations.load("attendance")
            msgbox = New messageBoxForm(translations.getText("sureToValidate") & " " & temp2 & " " & translations.getText("sureToValidateDays") & " " & logger_frm.calendar.Value.Date.ToString("yyyy-MM-dd") & " ?", message4, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgbox.ShowDialog <> DialogResult.Yes Then
                saveBtn.Enabled = True
                closeBtn.Enabled = True
                saveBtn.BackColor = stateCore.buttonColor
                closeBtn.BackColor = stateCore.buttonColor
                Exit Sub
            End If

            mainForm.busy.Show()

            For i = start_date To end_date
                If IsWeekday(logger_frm.calendar.Value.Date.ToString("yyyy/MM") & "/" & i.ToString()) Then
                    For j = 0 To logger_frm.attendanceTableBuilder.idxTableWorkerPos.Length - 1
                        If (checkbox_logs_only.Checked And ((Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkin.Equals("null") And
                            Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkin.Equals("00:00:00") And
                            Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkin.Equals("")) Or
                            (Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkout.Equals("null") And
                            Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkout.Equals("00:00:00") And
                            Not logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).checkout.Equals(""))) And
                            (logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).status.Equals("") Or
                            logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).status.Equals("EP") Or
                            logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).status.Equals("MO"))) Or Not checkbox_logs_only.Checked Then

                            Dim vars As New Dictionary(Of String, String)
                            vars.Add("type", "add")
                            vars.Add("worker", logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).code)
                            vars.Add("site", logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).site)
                            vars.Add("section", logger_frm.attendanceTableBuilder.serverData(logger_frm.attendanceTableBuilder.idxTableWorkerPos(j), i).section)
                            vars.Add("date", logger_frm.calendar.Value.Date.ToString("yyyy-MM") & "-" & i)
                            vars.Add("status", status)
                            vars.Add("absense", absense)
                            If Math.Abs(ts.Days) > stateCore.delayDaysValidationAttendance Then
                                vars.Add("motif", motif.Text)
                            End If
                            'TODO move to a queue system

                            attendanceDataRequests.Initialise(stateCore)
                            attendanceDataRequests.loadQueue(vars, Nothing, Nothing)
                            response = attendanceDataRequests.SaveLoggerValidationData()
                            If Not IsResponseOk(response) Then
                                translations.load("messagebox")
                                msgbox = New messageBoxForm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                                msgbox.ShowDialog()
                                changes = False
                            Else
                                changes = True
                            End If
                        End If
                    Next j
                End If
            Next i
            mainForm.busy.Close(True)
            If changes Then
                translations.load("attendance")
                mainForm.statusMessage = translations.getText("validationSuccess")
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                translations.load("attendance")
                Dim message3 As String = translations.getText("noChanges")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        Else
            translations.load("attendance")
            Dim message3 As String = translations.getText("errorSelectAnOption")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        mainForm.busy.Close(True)
        saveBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.BackColor = stateCore.buttonColor
        closeBtn.BackColor = stateCore.buttonColor
    End Sub

End Class