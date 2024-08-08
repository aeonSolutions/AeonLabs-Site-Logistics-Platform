Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class frm_attendances_close_status
    Private translations As languageTranslations
    Private stateCore As New environmentVars
    Private mainForm As MainMdiForm
    Private reportsFrm As attendanceReportsForm

    Public Sub New(_mainMdiForm As MainMdiForm, _reportsFrm As attendanceReportsForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        stateCore = mainForm.state
        reportsFrm = _reportsFrm
        Me.Refresh()
    End Sub

    Private Sub frm_attendances_close_status_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = New environmentVars(LOAD_SETTINGS)
        translations = New languageTranslations(stateCore)

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, FontStyle.Bold)
        message.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        divider.BackColor = stateCore.dividerColor

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")

        Dim checkDate As Date
        Dim formats As String() = New String() {"dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd"}
        message.Text = ""
        For i = 0 To reportsFrm.works_site("cod_site").Count - 1
            For j = 0 To reportsFrm.works_sections("cod_section").Count - 1
                If Not reportsFrm.works_sections("cod_site")(j).Equals(reportsFrm.works_site("cod_site")(i)) Then
                    Continue For
                End If
                Dim status As String = "OPEN   "
                If DateTime.TryParseExact(reportsFrm.works_sections("attendances_last_close")(j), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, checkDate) Then
                    checkDate = Convert.ToDateTime(reportsFrm.works_sections("attendances_last_close")(j))
                    If (checkDate.Year = DateTime.Now.Year And checkDate.Month = DateTime.Now.Month) Then 'already closed
                        status = "CLOSED"
                    End If
                End If
                message.Text = message.Text & status & "        " & reportsFrm.works_site("name")(i) & " (" & reportsFrm.works_sections("description")(j) & ")" & Environment.NewLine
            Next j
        Next i
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class