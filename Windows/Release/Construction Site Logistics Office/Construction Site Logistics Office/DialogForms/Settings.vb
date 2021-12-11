Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Web.Script.Serialization


Public Class settings_frm
    Private state, newState As New State
    Private countryList As New SortedDictionary(Of String, String)
    Private translations As languageTranslations
    Private msgbox As message_box_frm

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()

    End Sub

    Private Sub settings_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         
         
        state = MainMdiForm.state
        translations = New languageTranslations(state)

        SuspendLayout()
        'divider
        languageDivider.BackColor = state.dividerColor
        fontsDivider.BackColor = state.dividerColor
        diagsDivider.BackColor = state.dividerColor
        addonsDivider.BackColor = state.dividerColor
        attendanceDivider.BackColor = state.dividerColor
        apiServerDivider.BackColor = state.dividerColor
        generalDivider.BackColor = state.dividerColor
        datatablesDivider.BackColor = state.dividerColor
        'buttons
        selectTitleFile.BackColor = state.buttonColor
        selectRegularFile.BackColor = state.buttonColor
        closeBtn.BackColor = state.buttonColor
        'tabs
        TabControl.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Regular)

        'titles
        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        generalTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        datatablesTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        apiServerTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        attendanceTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        addonsTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        diagsTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        fontsTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        languageTitle.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, FontStyle.Bold)
        'language
        ListBox1.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        show_all_lang.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        'fonts
        fontsTitles_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        fontsRegular_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        fontsTitleFontName.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        fontsRegularFontName.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        fontsTitleFile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        fontsRegularFile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        selectTitleFile.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        selectRegularFile.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        'diagnostics
        share.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        share_details.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        send.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        send_details.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        about_diagnostics.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        'addons
        enableTranslation.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translation_provider_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translation_apikey_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translationProvider.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        translationApiKey.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        enableWeather.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        weather_provider_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        weather_apikey_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        weatherProvider.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        weatherApiKey.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        'api server
        server_web_addr_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        domain_web_ex.Font = New Font(state.fontTitle.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        server_web_addr.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        ' attendance
        attendanceText.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        attendanceNumDays_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        attendanceNumDays.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        workHours_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        workHours.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        saveLink.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        closeBtn.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        'colors and fonts
        lateralMenu_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        lateralMenu_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        buttons_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        buttons_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        dividers_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        dividers_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        fullDayValidated_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        fullDayValidated_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        plannedTeam_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        plannedTeam_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        plannedSiteChange_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        plannedSiteChange_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        partialDayValidated_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        partialDayValidated_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        annualCloseDays_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        annualCloseDays_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        absentDayValidated_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        absentDayValidated_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        record_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        record_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        holidays_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        holidays_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        weekends_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        weekends_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        withoutRecord_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        withoutRecord_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        plannedAbsense_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        plannedAbsense_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        workCategories_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        workCategories_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        companies_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        companies_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        sections_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        sections_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        sites_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        sites_color.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        datatableResetLink.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        generalResetLink.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        saveColorsLink.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, FontStyle.Regular)


        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        saveLink.Text = translations.getText("saveLink")
        'language
        show_all_lang.Text = translations.getText("showAllLink")
        'fonts
        selectTitleFile.Text = translations.getText("chooseBtn")
        selectRegularFile.Text = translations.getText("chooseBtn")

        datatableResetLink.Text = translations.getText("resetLink")
        generalResetLink.Text = translations.getText("resetLink")
        saveColorsLink.Text = translations.getText("saveLink")

        translations.load("settings")
        'titles
        TabControl.TabPages.Item(0).Text = translations.getText("generalTabTitle")
        TabControl.TabPages.Item(1).Text = translations.getText("fontsTabTitle")
        title.Text = translations.getText("settingsTitle")
        generalTitle.Text = translations.getText("generalTitle")
        datatablesTitle.Text = translations.getText("datatableTitle")
        apiServerTitle.Text = translations.getText("apiServerTitle")
        attendanceTitle.Text = translations.getText("attendanceTitle")
        addonsTitle.Text = translations.getText("addonsTitle")
        diagsTitle.Text = translations.getText("diagonsticsTitle")
        fontsTitle.Text = translations.getText("fontsTitle")
        languageTitle.Text = translations.getText("languageTitle")

        'fonts
        fontsTitles_lbl.Text = translations.getText("fontsTitleSubTitle")
        fontsRegular_lbl.Text = translations.getText("fontsRegularSubTitle")

        'diagnostics
        share.Text = translations.getText("shareCrashSelection")
        share_details.Text = translations.getText("shareCrashDetails")
        send.Text = translations.getText("sendDiagsSelection")
        send_details.Text = translations.getText("sendDiagsDetails")
        about_diagnostics.Text = translations.getText("aboutDiagnosticsLink") & "..."
        'addons
        enableTranslation.Text = translations.getText("enableTranslation")
        translation_provider_lbl.Text = translations.getText("addonsProvider")
        translation_apikey_lbl.Text = translations.getText("addonsKey")
        enableWeather.Text = translations.getText("enableWeather")
        weather_provider_lbl.Text = translations.getText("addonsProvider")
        weather_apikey_lbl.Text = translations.getText("addonsKey")
        'api server
        server_web_addr_lbl.Text = translations.getText("serverWebAddr")
        ' attendance
        attendanceText.Text = translations.getText("attendanceDetails")
        attendanceNumDays_lbl.Text = translations.getText("attendanceNumDays")
        workHours_lbl.Text = translations.getText("attendanceNumHoursWork")

        'colors and fonts
        lateralMenu_lbl.Text = translations.getText("lateralMenu")
        buttons_lbl.Text = translations.getText("buttons")
        dividers_lbl.Text = translations.getText("dividers")
        fullDayValidated_lbl.Text = translations.getText("fullDayValidated")
        plannedTeam_lbl.Text = translations.getText("plannedTeam")
        plannedSiteChange_lbl.Text = translations.getText("plannedSiteChange")
        partialDayValidated_lbl.Text = translations.getText("partialDayValidated")
        annualCloseDays_lbl.Text = translations.getText("annualCloseDays")
        absentDayValidated_lbl.Text = translations.getText("absentDayValidated")
        record_lbl.Text = translations.getText("record")
        holidays_lbl.Text = translations.getText("holidays")
        weekends_lbl.Text = translations.getText("weekends")
        withoutRecord_lbl.Text = translations.getText("withoutRecord")
        plannedAbsense_lbl.Text = translations.getText("plannedAbsense")
        workCategories_lbl.Text = translations.getText("workCategories")
        companies_lbl.Text = translations.getText("companies")
        sections_lbl.Text = translations.getText("sections")
        sites_lbl.Text = translations.getText("sites")

        'load current settings
        buttons_color.Text = state.buttonColor.ToString
        dividers_color.Text = state.dividerColor.ToString
        fullDayValidated_color.Text = state.colorFullDayValidated.ToString
        plannedTeam_color.Text = state.colorPlannedTeam.ToString
        plannedSiteChange_color.Text = state.colorPlannedChangeOfSite.ToString
        partialDayValidated_color.Text = state.colorPartialDayValidated.ToString
        annualCloseDays_color.Text = state.colorFermetureAnnual.ToString
        absentDayValidated_color.Text = state.colorAbsentDay.ToString
        record_color.Text = state.colorWithRecord.ToString
        holidays_color.Text = state.colorHolidays.ToString
        weekends_color.Text = state.colorWeekends.ToString
        withoutRecord_color.Text = state.colorWithoutRecord.ToString
        plannedAbsense_color.Text = state.colorAbsense.ToString
        workCategories_color.Text = state.colorWorkCategories.ToString
        companies_color.Text = state.colorCompany.ToString
        sections_color.Text = state.colorSection.ToString
        sites_color.Text = state.colorSite.ToString
        lateralMenu_color.Text = state.colorMainMenu.ToString

        buttons_box.BackColor = state.buttonColor
        dividers_box.BackColor = state.dividerColor
        fullDayValidated_box.BackColor = state.colorFullDayValidated
        plannedTeam_box.BackColor = state.colorPlannedTeam
        plannedSiteChange_box.BackColor = state.colorPlannedChangeOfSite
        partialDayValidated_box.BackColor = state.colorPartialDayValidated
        annualCloseDays_box.BackColor = state.colorFermetureAnnual
        absentDayValidated_box.BackColor = state.colorAbsentDay
        record_box.BackColor = state.colorWithRecord
        holidays_box.BackColor = state.colorHolidays
        weekends_box.BackColor = state.colorWeekends
        withoutRecord_box.BackColor = state.colorWithoutRecord
        plannedAbsense_box.BackColor = state.colorAbsense
        workCategories_box.BackColor = state.colorWorkCategories
        companies_box.BackColor = state.colorCompany
        sections_box.BackColor = state.colorSection
        sites_box.BackColor = state.colorSite
        lateralMenu_box.BackColor = state.colorMainMenu

        fontsTitleFontName.Text = state.fontTitleFile
        fontsRegularFontName.Text = state.fontTextFile
        If state.SendCrashData Then
            share.Checked = True
        End If
        If state.SendDiagnosticData Then
            send.Checked = True
        End If

        workHours.CustomFormat = "HH:mm"
        workHours.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        workHours.ShowUpDown = True

        attendanceNumDays.Text = state.delayDaysValidationAttendance
        server_web_addr.Text = state.ServerBaseAddr
        workHours.Value = "2000-01-01 " & state.maxWorkHoursDay.ToString("hh\:mm") & ":00"

        If state.addonsLoaded Then
            If Not IsNothing(state.addons) Then
                For Each item In state.addons
                    If item.Key.Equals("translation") Then
                        enableTranslation.Checked = True
                    End If
                    If item.Key.Equals("weather") Then
                        enableWeather.Checked = True
                    End If
                Next
            End If
        End If

        GetAllCountryLanguages("short")
        Me.ResumeLayout()
    End Sub

    Private Sub settings_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Close()
    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            GetAllCountryLanguages("all")
        Else
            GetAllCountryLanguages("short")
        End If
    End Sub

    Private Sub send_CheckedChanged(sender As Object, e As EventArgs) Handles send.CheckedChanged
        If send.Checked Then
            newState.SendDiagnosticData = True
        Else
            newState.SendDiagnosticData = False
        End If
    End Sub

    Private Sub share_CheckedChanged(sender As Object, e As EventArgs) Handles share.CheckedChanged
        If share.Checked Then
            newState.SendCrashData = True
        Else
            newState.SendCrashData = False
        End If
    End Sub

    Private Sub about_diagnostics_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles about_diagnostics.LinkClicked
        'MISSING
    End Sub

    Private Sub enableTranlation_CheckedChanged(sender As Object, e As EventArgs) Handles enableTranslation.CheckedChanged
        If enableTranslation.Checked Then
            translationApiKey.Enabled = True
            translationProvider.Enabled = True
            translation_apikey_lbl.ForeColor = Color.Black
            translation_provider_lbl.ForeColor = Color.Black
        Else
            translationApiKey.Enabled = False
            translationProvider.Enabled = False
            translation_apikey_lbl.ForeColor = Color.Gray
            translation_provider_lbl.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub enableWeather_CheckedChanged(sender As Object, e As EventArgs) Handles enableWeather.CheckedChanged
        If enableWeather.Checked Then
            weatherApiKey.Enabled = True
            weatherProvider.Enabled = True
            weather_apikey_lbl.ForeColor = Color.Black
            weather_provider_lbl.ForeColor = Color.Black
        Else
            weatherApiKey.Enabled = False
            weatherProvider.Enabled = False
            weather_apikey_lbl.ForeColor = Color.Gray
            weather_provider_lbl.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub generalResetLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles generalResetLink.LinkClicked
        'load current settings
        buttons_color.Text = state.buttonColor.ToString
        dividers_color.Text = state.dividerColor.ToString
        lateralMenu_color.Text = state.colorMainMenu.ToString

        buttons_box.BackColor = state.buttonColor
        dividers_box.BackColor = state.dividerColor
        lateralMenu_box.BackColor = state.colorMainMenu

    End Sub

    Private Sub datatableResetLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles datatableResetLink.LinkClicked
        'load current settings
        fullDayValidated_color.Text = state.colorFullDayValidated.ToString
        plannedTeam_color.Text = state.colorPlannedTeam.ToString
        plannedSiteChange_color.Text = state.colorPlannedChangeOfSite.ToString
        partialDayValidated_color.Text = state.colorPartialDayValidated.ToString
        annualCloseDays_color.Text = state.colorFermetureAnnual.ToString
        absentDayValidated_color.Text = state.colorAbsentDay.ToString
        record_color.Text = state.colorWithRecord.ToString
        holidays_color.Text = state.colorHolidays.ToString
        weekends_color.Text = state.colorWeekends.ToString
        withoutRecord_color.Text = state.colorWithoutRecord.ToString
        plannedAbsense_color.Text = state.colorAbsense.ToString
        workCategories_color.Text = state.colorWorkCategories.ToString
        companies_color.Text = state.colorCompany.ToString
        sections_color.Text = state.colorSection.ToString
        sites_color.Text = state.colorSite.ToString

        fullDayValidated_box.BackColor = state.colorFullDayValidated
        plannedTeam_box.BackColor = state.colorPlannedTeam
        plannedSiteChange_box.BackColor = state.colorPlannedChangeOfSite
        partialDayValidated_box.BackColor = state.colorPartialDayValidated
        annualCloseDays_box.BackColor = state.colorFermetureAnnual
        absentDayValidated_box.BackColor = state.colorAbsentDay
        record_box.BackColor = state.colorWithRecord
        holidays_box.BackColor = state.colorHolidays
        weekends_box.BackColor = state.colorWeekends
        withoutRecord_box.BackColor = state.colorWithoutRecord
        plannedAbsense_box.BackColor = state.colorAbsense
        workCategories_box.BackColor = state.colorWorkCategories
        companies_box.BackColor = state.colorCompany
        sections_box.BackColor = state.colorSection
        sites_box.BackColor = state.colorSite
    End Sub

    Private Sub selectTitleFile_Click(sender As Object, e As EventArgs) Handles selectTitleFile.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesTtf") & "|*.ttf"
        OpenFileDialog1.ShowDialog()
        fontsTitleFile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub selectRegularFile_Click(sender As Object, e As EventArgs) Handles selectRegularFile.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesTtf") & "|*.ttf"
        OpenFileDialog1.ShowDialog()
        fontsRegularFile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub buttons_box_Click(sender As Object, e As EventArgs) Handles buttons_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            buttons_box.BackColor = ColorDialog1.Color
            buttons_color.Text = buttons_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub dividers_box_Click(sender As Object, e As EventArgs) Handles dividers_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            dividers_box.BackColor = ColorDialog1.Color
            dividers_color.Text = dividers_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub fullDayValidated_box_Click(sender As Object, e As EventArgs) Handles fullDayValidated_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            fullDayValidated_box.BackColor = ColorDialog1.Color
            fullDayValidated_color.Text = fullDayValidated_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub plannedTeam_box_Click(sender As Object, e As EventArgs) Handles plannedTeam_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            plannedTeam_box.BackColor = ColorDialog1.Color
            plannedTeam_color.Text = plannedTeam_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub plannedSiteChange_box_Click(sender As Object, e As EventArgs) Handles plannedSiteChange_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            plannedSiteChange_box.BackColor = ColorDialog1.Color
            plannedSiteChange_color.Text = plannedSiteChange_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub partialDayValidated_box_Click(sender As Object, e As EventArgs) Handles partialDayValidated_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            partialDayValidated_box.BackColor = ColorDialog1.Color
            partialDayValidated_color.Text = partialDayValidated_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub annualCloseDays_box_Click(sender As Object, e As EventArgs) Handles annualCloseDays_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            annualCloseDays_box.BackColor = ColorDialog1.Color
            annualCloseDays_color.Text = annualCloseDays_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub absentDayValidated_box_Click(sender As Object, e As EventArgs) Handles absentDayValidated_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            absentDayValidated_box.BackColor = ColorDialog1.Color
            absentDayValidated_color.Text = absentDayValidated_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub record_box_Click(sender As Object, e As EventArgs) Handles record_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            record_box.BackColor = ColorDialog1.Color
            record_color.Text = record_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub holidays_box_Click(sender As Object, e As EventArgs) Handles holidays_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            holidays_box.BackColor = ColorDialog1.Color
            holidays_color.Text = holidays_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub weekends_box_Click(sender As Object, e As EventArgs) Handles weekends_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            weekends_box.BackColor = ColorDialog1.Color
            weekends_color.Text = weekends_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub withoutRecord_box_Click(sender As Object, e As EventArgs) Handles withoutRecord_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            withoutRecord_box.BackColor = ColorDialog1.Color
            withoutRecord_color.Text = withoutRecord_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub plannedAbsense_box_Click(sender As Object, e As EventArgs) Handles plannedAbsense_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            plannedAbsense_box.BackColor = ColorDialog1.Color
            plannedAbsense_color.Text = plannedAbsense_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub workCategories_box_Click(sender As Object, e As EventArgs) Handles workCategories_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            workCategories_box.BackColor = ColorDialog1.Color
            workCategories_color.Text = workCategories_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub companies_box_Click(sender As Object, e As EventArgs) Handles companies_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            companies_box.BackColor = ColorDialog1.Color
            companies_color.Text = companies_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub sections_box_Click(sender As Object, e As EventArgs) Handles sections_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            sections_box.BackColor = ColorDialog1.Color
            sections_color.Text = sections_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub sites_box_Click(sender As Object, e As EventArgs) Handles sites_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            sites_box.BackColor = ColorDialog1.Color
            sites_color.Text = sites_box.BackColor.ToString
        End If
        Me.Show()
    End Sub
    Private Sub lateralMenu_box_Click(sender As Object, e As EventArgs) Handles lateralMenu_box.Click
        Me.Hide()
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            lateralMenu_box.BackColor = ColorDialog1.Color
            lateralMenu_color.Text = lateralMenu_box.BackColor.ToString
        End If
        Me.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItems.Count > 0 Then
            newState.currentLang = ListBox1.SelectedItem.ToString
        End If
    End Sub

    Public Sub GetAllCountryLanguages(listType As String)
        ' Iterate the Framework Cultures...
        Dim shortcountryList As New List(Of String)
        shortcountryList.Add("nl")
        shortcountryList.Add("en")
        shortcountryList.Add("fr")
        shortcountryList.Add("pt")

        ListBox1.Items.Clear()
        countryList.Clear()

        Dim ci As CultureInfo
        Dim aL As New ArrayList()
        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            If listType.Equals("all") Then
                If Not countryList.ContainsKey(ci.DisplayName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    ListBox1.Items.Add(ci.DisplayName)
                End If
            Else
                If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    ListBox1.Items.Add(ci.DisplayName)
                End If
            End If
        Next ci
        For i = 0 To ListBox1.Items.Count - 1
            If listType.Equals("all") Then
                If countryList.ElementAt(i).Value.ToString.Equals(state.currentLang) Then
                    ListBox1.SetSelected(i, True)
                    Exit For
                End If
            Else 'short list
                If Not shortcountryList.ElementAt(i).ToString.Equals(state.currentLang) Then
                    ListBox1.SetSelected(i, True)
                    Exit For
                End If
            End If
        Next i
    End Sub
    Private Sub saveLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveLink.LinkClicked
        saveSettings()
    End Sub

    Private Sub saveColorsLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveColorsLink.LinkClicked
        saveSettings()
    End Sub
    Private Sub saveSettings()
        generalPanel.Enabled = False
        fontsPanel.Enabled = False

        Dim msgTxt As String = ""
        If ListBox1.SelectedIndex < 0 Then
            translations.load("settings")
            msgTxt = translations.getText("errorSelectLanguage")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        Else
            newState.currentLang = countryList.Item(ListBox1.SelectedItem.ToString)
        End If
        If enableTranslation.Checked And (translationProvider.SelectedIndex < 0 Or translationApiKey.Text.Equals("")) Then
            translations.load("settings")
            msgTxt = translations.getText("errorSelectTranslation")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        End If
        If enableWeather.Checked And (weatherProvider.SelectedIndex < 0 Or weatherApiKey.Text.Equals("")) Then
            translations.load("settings")
            msgTxt = translations.getText("errorSelectWeather")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        End If
        'API SERVER
        server_web_addr.Text = If(server_web_addr.Text(server_web_addr.Text.Length - 1).Equals("/"), server_web_addr.Text.Substring(0, server_web_addr.Text.Length - 2), server_web_addr.Text)
        If Not IsValidUrl("http|https", server_web_addr.Text) Then
            Exit Sub
        ElseIf IsOnline(server_web_addr.Text) Then  ' check if is online and working
            newState.ServerBaseAddr = server_web_addr.Text
        Else
            translations.load("setupWiz1")
            msgbox = New message_box_frm(translations.getText("serverOffline"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        End If
        'delay Days Validation Attendance
        If Not IsNumeric(attendanceNumDays.Text) AndAlso CInt(attendanceNumDays.Text) < 0 Then
            translations.load("settings")
            msgTxt = translations.getText("errorInvalidDelayDays")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        Else
            newState.delayDaysValidationAttendance = CInt(attendanceNumDays.Text)
        End If
        'number of hours of work in a day
        If TimeSpan.Compare(TimeSpan.Parse("00:00:00"), workHours.Value.TimeOfDay) >= 1 Then
            translations.load("settings")
            msgTxt = translations.getText("errorInvalidHoursWork")
            translations.load("messagebox")
            msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        Else
            newState.delayDaysValidationAttendance = CInt(attendanceNumDays.Text)
        End If
        ' crash and diagnostics
        newState.SendDiagnosticData = send.Checked
        newState.SendCrashData = share.Checked
        ' font files
        Try
            Dim fontsTitleFileTest = New FileInfo(fontsTitleFile.Text)
            fontsTitleFileTest.Refresh()
            If fontsTitleFile.Text.IndexOf(".ttf") > 0 AndAlso fontsTitleFileTest.Exists Then
                Try
                    My.Computer.FileSystem.CopyFile(fontsTitleFile.Text, state.fontsPath & Path.GetFileName(fontsTitleFile.Text), overwrite:=False)
                Catch ex As Exception
                    translations.load("messagebox")
                    msgbox = New message_box_frm(ex.ToString, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    generalPanel.Enabled = True
                    fontsPanel.Enabled = True

                    Exit Sub
                End Try
                newState.fontTitleFile = Path.GetFileName(fontsTitleFile.Text)
            Else
                translations.load("settings")
                msgTxt = translations.getText("errorInvalidFontTitleFile")
                translations.load("messagebox")
                msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                generalPanel.Enabled = True
                fontsPanel.Enabled = True

                Exit Sub
            End If
        Catch ex As Exception
            newState.fontTitleFile = state.fontTitleFile
        End Try

        Try
            Dim fontsRegularFileTest = New FileInfo(fontsRegularFile.Text)
            fontsRegularFileTest.Refresh()
            If fontsRegularFile.Text.IndexOf(".ttf") > 0 AndAlso fontsRegularFileTest.Exists Then
                Try
                    My.Computer.FileSystem.CopyFile(fontsRegularFile.Text, state.fontsPath & Path.GetFileName(fontsRegularFile.Text), overwrite:=False)
                Catch ex As Exception
                    translations.load("messagebox")
                    msgbox = New message_box_frm(ex.ToString, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    msgbox.ShowDialog()
                    generalPanel.Enabled = True
                    fontsPanel.Enabled = True

                    Exit Sub
                End Try
                newState.fontTextFile = Path.GetFileName(fontsRegularFile.Text)
            Else
                translations.load("settings")
                msgTxt = translations.getText("errorInvalidFontRegularFile")
                translations.load("messagebox")
                msgbox = New message_box_frm(msgTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
                generalPanel.Enabled = True
                fontsPanel.Enabled = True

                Exit Sub
            End If

        Catch ex As Exception
            newState.fontTextFile = state.fontTextFile
        End Try
        'datatable color schemes
        newState.colorFullDayValidated = fullDayValidated_box.BackColor
        newState.colorPlannedTeam = plannedTeam_box.BackColor
        newState.colorPlannedChangeOfSite = plannedSiteChange_box.BackColor
        newState.colorPartialDayValidated = partialDayValidated_box.BackColor
        newState.colorFermetureAnnual = annualCloseDays_box.BackColor
        newState.colorAbsentDay = absentDayValidated_box.BackColor
        newState.colorWithRecord = record_box.BackColor
        newState.colorHolidays = holidays_box.BackColor
        newState.colorWeekends = weekends_box.BackColor
        newState.colorWithoutRecord = withoutRecord_box.BackColor
        newState.colorAbsense = plannedAbsense_box.BackColor
        newState.colorWorkCategories = workCategories_box.BackColor
        newState.colorCompany = companies_box.BackColor
        newState.colorSection = sections_box.BackColor
        newState.colorSite = sites_box.BackColor
        newState.dividerColor = dividers_box.BackColor
        newState.buttonColor = buttons_box.BackColor
        newState.colorMainMenu = lateralMenu_box.BackColor

        'SAVE SETTINGS FILE
        If Not save_settings() Then
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        End If
        'SAVE CONFIG FILE
        If Not save_config() Then
            generalPanel.Enabled = True
            fontsPanel.Enabled = True

            Exit Sub
        End If

        'MISSING SEND TO SEVER ADDONS SETUP , work hours in a day, validation delay
        If enableTranslation.Checked Then
            ' settings.isTranslationEnabled = True
            ' settings.translationProvider = translationProvider.SelectedItem.ToString
            '  settings.translationApiKey = translationApiKey.Text
        End If
        If enableWeather.Checked Then
            '  settings.isWeatherEnabled = True
            '  settings.weatherProvider = weatherProvider.SelectedItem.ToString
            '  settings.weatherApiKey = weatherApiKey.Text
        End If

        generalPanel.Enabled = True
        fontsPanel.Enabled = True

        MainMdiForm.state.loadAll("all")
        MainMdiForm.SuspendLayout()
        MainMdiForm.loadLanguage()
        MainMdiForm.sidebarWrapper.BackColor = newState.colorMainMenu
        MainMdiForm.sidebarWrapperContents.BackColor = newState.colorMainMenu
        MainMdiForm.label_time.BackColor = newState.colorMainMenu
        MainMdiForm.sidebarWrapperBottom.BackColor = newState.colorMainMenu
        MainMdiForm.ResumeLayout()

        Me.Close()
    End Sub

    Private Function save_config() As Boolean
        Dim vars As New Dictionary(Of String, String)
        Dim translations As languageTranslations
        Dim msgbox As message_box_frm
        Dim encryption As New AesCipher(state)

        translations = New languageTranslations(state)

        'datatable color schemes
        vars.Add("colorFullDayValidated", newState.colorFullDayValidated.ToArgb.ToString)
        vars.Add("colorPlannedTeam", newState.colorPlannedTeam.ToArgb.ToString)
        vars.Add("colorPlannedChangeOfSite", newState.colorPlannedChangeOfSite.ToArgb.ToString)
        vars.Add("colorPartialDayValidated", newState.colorPartialDayValidated.ToArgb.ToString)
        vars.Add("colorFermetureAnnual", newState.colorFermetureAnnual.ToArgb.ToString)
        vars.Add("colorAbsentDay", newState.colorAbsentDay.ToArgb.ToString)
        vars.Add("colorWithRecord", newState.colorWithRecord.ToArgb.ToString)
        vars.Add("colorHolidays", newState.colorHolidays.ToArgb.ToString)
        vars.Add("colorWeekends", newState.colorWeekends.ToArgb.ToString)
        vars.Add("colorWithoutRecord", newState.colorWithoutRecord.ToArgb.ToString)
        vars.Add("colorAbsense", newState.colorAbsense.ToArgb.ToString)
        vars.Add("colorWorkCategories", newState.colorWorkCategories.ToArgb.ToString)
        vars.Add("colorCompany", newState.colorCompany.ToArgb.ToString)
        vars.Add("colorSection", newState.colorSection.ToArgb.ToString)
        vars.Add("colorSite", newState.colorSite.ToArgb.ToString)
        vars.Add("dividerColor", newState.dividerColor.ToArgb.ToString)
        vars.Add("buttonColor", newState.buttonColor.ToArgb.ToString)
        vars.Add("colorMainMenu", newState.colorMainMenu.ToArgb.ToString)

        'font files
        vars.Add("fontTextFile", newState.fontTextFile)
        vars.Add("fontTitleFile", newState.fontTitleFile)
        'delay Days Validation Attendance
        vars.Add("delayDaysValidationAttendance", newState.delayDaysValidationAttendance)


        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encrypted As String = encryption.encrypt(json)

        Dim settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.cfg"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                FileSystem.Kill(Path.Combine(state.libraryPath, "ScrewDriver.cfg"))
            Catch ex As Exception
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorDeletingData") & ". " & translations.getText("contactEnterpriseSupport")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.DoEvents()
                msgbox.ShowDialog()
                Return False
            End Try
        End If
        Try
            Dim bytes = Convert.FromBase64String(encrypted)
            File.WriteAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.cfg"), bytes)
        Catch ex As Exception
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSavingData") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.DoEvents()
            msgbox.ShowDialog()
            Return False
        End Try

        Return True
    End Function

    Private Function save_settings() As Boolean
        Dim vars As New Dictionary(Of String, String)
        Dim translations As languageTranslations
        Dim msgbox As message_box_frm
        Dim encryptState As New State
        encryptState.secretKey = state.SettingsSecretKey
        Dim encryption As New AesCipher(encryptState)

        translations = New languageTranslations(state)

        vars.Add("country", state.country)
        vars.Add("language", newState.currentLang)
        vars.Add("serverAddress", newState.ServerBaseAddr)
        vars.Add("ApiServerAddrPath", state.ApiServerAddrPath)
        vars.Add("ApiEncryptionKey", state.secretKey)
        vars.Add("sendDiags", newState.SendDiagnosticData)
        vars.Add("sendCrash", newState.SendCrashData)


        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encrypted As String = encryption.encrypt(json)

        Dim settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                FileSystem.Kill(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
            Catch ex As Exception
                translations.load("errorMessages")
                Dim message As String = translations.getText("errorDeletingData") & ". " & translations.getText("contactEnterpriseSupport")
                translations.load("messagebox")
                msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.DoEvents()
                msgbox.ShowDialog()
                Return False
            End Try
        End If
        Try
            Dim bytes = Convert.FromBase64String(encrypted)
            File.WriteAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"), bytes)
        Catch ex As Exception
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSavingData") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.DoEvents()
            msgbox.ShowDialog()
            Return False
        End Try

        Return True
    End Function



End Class