Imports System.Drawing.Text

Public Class logger_stats_frm
    Private state As State
    Private translations As languageTranslations
     
    Private msgbox As message_box_frm

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub logger_stats_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        Me.SuspendLayout()
         
         

        title.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        mes.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        absense_hours.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        max_workers.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        min_workers.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_days.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_days_at_work.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_works_days.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        hoursInAbsense_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        maxDailyWorkers_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        minDailyWorkers_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        maxWorkDaysInMonth_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        daysAtWor_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        totalDaysAtWork_subtitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor

        title.Text = logger_frm.stats.site
        mes.Text = logger_frm.stats.data
        If logger_frm.stats.absenseHours.ToString().IndexOf(".") > -1 Then
            Dim d As Integer = logger_frm.stats.absenseHours.ToString().Substring(0, logger_frm.stats.absenseHours.ToString().IndexOf("."))
            absense_hours.Text = (d * 24 + CInt(logger_frm.stats.absenseHours.Hours.ToString())).ToString() & "H" & If(logger_frm.stats.absenseHours.Minutes < 10, "0", "") & logger_frm.stats.absenseHours.Minutes.ToString()
        Else
            absense_hours.Text = logger_frm.stats.absenseHours.ToString().Substring(0, 5).Replace(":", "H")
        End If

        max_workers.Text = logger_frm.stats.maxWorkers
        min_workers.Text = logger_frm.stats.minWorkers
        total_days.Text = logger_frm.stats.totalWorkDays
        total_days_at_work.Text = logger_frm.stats.totalDaysWorked
        total_works_days.Text = logger_frm.stats.totalDaysInMonth
        translations.load("attendance")
        hoursInAbsense_subtitle.Text = translations.getText("totalHoursOfAbsense")
        maxDailyWorkers_subtitle.Text = translations.getText("maxDailyWorker")
        minDailyWorkers_subtitle.Text = translations.getText("minDailyWorker")
        maxWorkDaysInMonth_subtitle.Text = translations.getText("possibleWorkDaysInMonth")
        daysAtWor_subtitle.Text = translations.getText("daysWorkInMonth")
        totalDaysAtWork_subtitle.Text = translations.getText("totalDaysWorked")
        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class