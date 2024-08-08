Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class logger_stats_frm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm
    private mainForm As MainMdiForm
    Private loggerStats As attendanceTableBuilderClass.statsJson
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm, _loggerStats As attendanceTableBuilderClass.statsJson)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        stateCore = mainForm.state
        loggerStats = _loggerStats
        Me.Refresh()
    End Sub

    Private Sub logger_stats_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)
        Me.SuspendLayout()

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        mes.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        absense_hours.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        max_workers.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        min_workers.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_days.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_days_at_work.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        total_works_days.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        hoursInAbsense_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        maxDailyWorkers_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        minDailyWorkers_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        maxWorkDaysInMonth_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        daysAtWor_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        totalDaysAtWork_subtitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        title.Text = loggerStats.site
        mes.Text = loggerStats.data
        If loggerStats.absenseHours.ToString().IndexOf(".") > -1 Then
            Dim d As Integer = loggerStats.absenseHours.ToString().Substring(0, loggerStats.absenseHours.ToString().IndexOf("."))
            absense_hours.Text = (d * 24 + CInt(loggerStats.absenseHours.Hours.ToString())).ToString() & "H" & If(loggerStats.absenseHours.Minutes < 10, "0", "") & loggerStats.absenseHours.Minutes.ToString()
        Else
            absense_hours.Text = loggerStats.absenseHours.ToString().Substring(0, 5).Replace(":", "H")
        End If

        max_workers.Text = loggerStats.maxWorkers
        min_workers.Text = loggerStats.minWorkers
        total_days.Text = loggerStats.totalWorkDays
        total_days_at_work.Text = loggerStats.totalDaysWorked
        total_works_days.Text = loggerStats.totalDaysInMonth
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