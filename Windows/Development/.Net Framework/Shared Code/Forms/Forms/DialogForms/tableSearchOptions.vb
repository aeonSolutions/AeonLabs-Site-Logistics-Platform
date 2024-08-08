Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class tableSearchOptionsForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Public Property from As String = ""

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private state As New environmentVars
    Private mainForm As MainMdiForm

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Application.DoEvents()
        Me.Refresh()
    End Sub
    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub frm_tablets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)


        Me.SuspendLayout()
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(mainForm.Width / 2 - Me.Width / 2, mainForm.Height / 2 - Me.Height / 2)

        Me.title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        Me.viewOtherSitesChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.viewPlanningChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.viewAttendanceThisSiteChk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        Me.closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Me.closeBtn.BackColor = stateCore.buttonColor
        Me.divider.BackColor = stateCore.dividerColor

        translations.load("commonForm")
        Me.title.Text = translations.getText("searchParametersLink")
        Me.closeBtn.Text = translations.getText("closeBtn")


        translations.load("tableSettingsDialog")
        Me.viewOtherSitesChk.Text = translations.getText("viewOtherSites")
        Me.viewPlanningChk.Text = translations.getText("viewWorkersPlanning")
        Me.viewAttendanceThisSiteChk.Text = translations.getText("viewAttendanceThisSite")

        Me.viewOtherSitesChk.Checked = stateCore.tableSearchOptions.viewOtherConstructionSitesAttendance
        Me.viewPlanningChk.Checked = stateCore.tableSearchOptions.viewPlanningAssignmentWorkers
        If from.Equals("logger") Then
            Me.viewOtherSitesChk.Enabled = True
            Me.viewPlanningChk.Enabled = True
            Me.viewAttendanceThisSiteChk.Enabled = False
        End If
        If from.Equals("teams") Then
            Me.viewOtherSitesChk.Enabled = False
            Me.viewPlanningChk.Enabled = False
            Me.viewAttendanceThisSiteChk.Enabled = True
        End If
        If stateCore.tableSearchOptions.viewOtherConstructionSitesAttendance Then
            viewOtherSitesChk.Checked = True
        End If
        If stateCore.tableSearchOptions.viewPlanningAssignmentWorkers Then
            viewPlanningChk.Checked = True
        End If
        If stateCore.tableSearchOptions.viewThisConstructionSiteAttendance Then
            viewAttendanceThisSiteChk.Checked = True
        End If
        Me.ResumeLayout()


    End Sub

    Private Sub frm_tablets_show(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub viewPlanningChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewPlanningChk.CheckedChanged
        Dim options = stateCore.tableSearchOptions
        options = mainForm.state.tableSearchOptions
        options.viewPlanningAssignmentWorkers = viewPlanningChk.Checked
        options.viewOtherConstructionSitesAttendance = False
        mainForm.state.tableSearchOptions = options
        If viewPlanningChk.Checked Then
            viewOtherSitesChk.Checked = False
        End If
    End Sub

    Private Sub viewOtherSitesChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewOtherSitesChk.CheckedChanged
        Dim options = stateCore.tableSearchOptions
        options = mainForm.state.tableSearchOptions
        options.viewOtherConstructionSitesAttendance = viewOtherSitesChk.Checked
        options.viewPlanningAssignmentWorkers = False
        mainForm.state.tableSearchOptions = options
        If viewOtherSitesChk.Checked Then
            viewPlanningChk.Checked = False
        End If
    End Sub

    Private Sub viewAttendanceThisSiteChk_CheckedChanged(sender As Object, e As EventArgs) Handles viewAttendanceThisSiteChk.CheckedChanged
        Dim options = stateCore.tableSearchOptions
        options = mainForm.state.tableSearchOptions
        options.viewThisConstructionSiteAttendance = viewAttendanceThisSiteChk.Checked
        mainForm.state.tableSearchOptions = options
    End Sub
End Class