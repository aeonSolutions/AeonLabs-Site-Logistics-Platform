Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class duplicateRecordsCheck_frm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private siteSelection As Integer()
    Private SitesListSelection As New List(Of Integer)
    Private loaded As Boolean
    Private attendanceTableBuilder As attendanceTableBuilderClass
    Private mainForm As MainMdiForm

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm, _attendanceTableBuilder As attendanceTableBuilderClass)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainForm = _mainMdiForm
        attendanceTableBuilder = _attendanceTableBuilder
        stateCore = mainForm.state

        Me.Refresh()
    End Sub

    Private Sub duplicateRecordsCheck_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)
        ReDim siteSelection((attendanceTableBuilder.duplicateWorkerRecords.Count) * 2)
        loaded = False

        Me.SuspendLayout()
        divider.BackColor = stateCore.dividerColor
        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        subTitle.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        duplicatesListBox.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        closeBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")

        translations.load("duplicateAttendances")
        title.Text = translations.getText("title")
        subTitle.Text = translations.getText("subtitle")

    End Sub

    Private Sub duplicateRecordsCheck_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        translations.load("attendance")
        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics


        duplicatesListBox.Items.Clear()
        Dim numChars = CInt(duplicatesListBox.Width / (g.MeasureString(".", fontToMeasure).Width / 1.35)) + 1
        Dim lastDate As String = ""
        Dim pos As Integer = 0
        For j = 0 To attendanceTableBuilder.duplicateWorkerRecords.Count - 1
            If Not lastDate.Equals(attendanceTableBuilder.duplicateWorkerRecords(j).data) Then
                lastDate = attendanceTableBuilder.duplicateWorkerRecords(j).data
                duplicatesListBox.Items.Add(attendanceTableBuilder.duplicateWorkerRecords(j).data & " - " & attendanceTableBuilder.duplicateWorkerRecords(j).workerName)
                duplicatesListBox.SetItemCheckState(pos, CheckState.Indeterminate)
                siteSelection(pos) = 0
                pos += 1
            End If
            siteSelection(pos) = 1
            duplicatesListBox.Items.Add(attendanceTableBuilder.duplicateWorkerRecords(j).siteName & " (" & attendanceTableBuilder.duplicateWorkerRecords(j).sectionName & ")       # " & translations.getText("checkin") & ": " & attendanceTableBuilder.duplicateWorkerRecords(j).checkin & "       # " & translations.getText("checkout") & ": " & attendanceTableBuilder.duplicateWorkerRecords(j).checkout & "       # " & translations.getText("validation") & ": " & attendanceTableBuilder.duplicateWorkerRecords(j).status)
            pos += 1
        Next j
        loaded = True
    End Sub
    Private Sub duplicatesListBox_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles duplicatesListBox.ItemCheck
        If Not IsNothing(siteSelection) And loaded Then

            If siteSelection(e.Index).Equals(0) Then
                e.NewValue = e.CurrentValue
                duplicatesListBox.SetItemCheckState(e.Index, e.NewValue)
            End If
            TrackSelectionChange(duplicatesListBox)
        End If
    End Sub
    Private Sub TrackSelectionChange(ByVal lb As CheckedListBox)
        Dim sic As CheckedListBox.SelectedIndexCollection = lb.SelectedIndices

        For Each index As Integer In sic
            If Not SitesListSelection.Contains(index) Then SitesListSelection.Add(index)
        Next

        For Each index As Integer In New List(Of Integer)(SitesListSelection)
            If Not sic.Contains(index) Then SitesListSelection.Remove(index)
        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class