Public Class tableSearchOptions_frm
    Private state As New State
    Private translations As languageTranslations
    Public Shared from As String = ""

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
        Application.DoEvents()
        Me.Refresh()
    End Sub

    Private Sub frm_tablets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)


        Me.SuspendLayout()
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(MainMdiForm.Width / 2 - Me.Width / 2, MainMdiForm.Height / 2 - Me.Height / 2)

        Me.title.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        Me.viewOtherSitesChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.viewPlanningChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.viewAttendanceThisSiteChk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        Me.closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.closeBtn.BackColor = state.buttonColor
        Me.divider.BackColor = state.dividerColor

        translations.load("commonForm")
        Me.title.Text = translations.getText("searchParametersLink")
        Me.closeBtn.Text = translations.getText("closeBtn")


        translations.load("tableSettingsDialog")
        Me.viewOtherSitesChk.Text = translations.getText("viewOtherSites")
        Me.viewPlanningChk.Text = translations.getText("viewWorkersPlanning")
        Me.viewAttendanceThisSiteChk.Text = translations.getText("viewAttendanceThisSite")

        Me.viewOtherSitesChk.Checked = state.tableSearchOptions.viewOtherConstructionSitesAttendance
        Me.viewPlanningChk.Checked = state.tableSearchOptions.viewPlanningAssignmentWorkers
        If Me.from.Equals("logger") Then
            Me.viewOtherSitesChk.Enabled = True
            Me.viewPlanningChk.Enabled = True
            Me.viewAttendanceThisSiteChk.Enabled = False
        End If
        If Me.from.Equals("teams") Then
            Me.viewOtherSitesChk.Enabled = False
            Me.viewPlanningChk.Enabled = False
            Me.viewAttendanceThisSiteChk.Enabled = True
        End If

        Me.ResumeLayout()


    End Sub

    Private Sub frm_tablets_show(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub viewPlanningChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewPlanningChk.CheckedChanged
        MainMdiForm.state.tableSearchOptions.viewPlanningAssignmentWorkers = viewPlanningChk.Checked
    End Sub

    Private Sub viewOtherSitesChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewOtherSitesChk.CheckedChanged
        MainMdiForm.state.tableSearchOptions.viewOtherConstructionSitesAttendance = viewPlanningChk.Checked
    End Sub

    Private Sub viewAttendanceThisSiteChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewAttendanceThisSiteChk.CheckedChanged
        MainMdiForm.state.tableSearchOptions.viewThisConstructionSiteAttendance = viewAttendanceThisSiteChk.Checked
    End Sub
End Class