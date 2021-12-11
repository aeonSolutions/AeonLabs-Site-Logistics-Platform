
Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class workersAbsenseList_frm
    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private loaded As Boolean = False
    Private updated As Boolean = False
    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwload As BackgroundWorker
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations


    Private AMTable As String(,)
    Public Shared currentDatatable As DataGridView
    Private works_site, works_worker, works_sections, works_absenses As Dictionary(Of String, List(Of String))
    Private SectionsIndex() As Integer
    Private siteSelectionText As String = ""
    Private sectionSelectionText As String = ""

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.DoEvents()
        SetDoubleBuffered(datatable)

        Me.WindowState = FormWindowState.Maximized

        Me.Refresh()
    End Sub

    Private Sub receptionMaterials_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        MainMdiForm.childForm = "workersAbsenseList"

        Me.SuspendLayout()
         
         

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Height = Me.Height
        mask.Width = Me.Width
        mask.BackColor = Color.White
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Application.DoEvents()
        Me.SuspendLayout()
        datatable.Width = Me.Width - 10 - datatable.Location.X
        datatable.Height = Me.Height - 10 - datatable.Location.Y
        GroupBox_search.Location = New Point(Me.Width - 10 - GroupBox_search.Width, GroupBox_search.Location.Y)

        GroupBoxSelection.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        Section_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        data_inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        data_fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        combo_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        DateTo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        SetCurrentMonth.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        Date_lbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, FontStyle.Regular)
        GroupBox_search.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, FontStyle.Regular)
        SearchBox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        translations.load("commonForm")
        GroupBoxSelection.Text = translations.getText("groupBoxSite")
        Section_lbl.Text = translations.getText("siteSection")
        DateTo_lbl.Text = translations.getText("dateTo")
        SetCurrentMonth.Text = translations.getText("currentMonth")
        Date_lbl.Text = translations.getText("dateTitle")
        GroupBox_search.Text = translations.getText("SearchBoxTitle")

        Me.ResumeLayout()
    End Sub

    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
        Try
            FileSystem.Kill(String.Format("{0}", Environment.CurrentDirectory & "\tmp\*.*"))
        Catch

        End Try
    End Sub

    Private Sub removeMask()
        If loadedForm Then
            Exit Sub
        End If

        loadedForm = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()
    End Sub

    Sub load_list()
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
            End If
        End If

        updated = False
        combo_site.Enabled = False

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "sites,sections")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(works_sections) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If

    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("commonForm")
        combo_site.Items.Clear()
        combo_site.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_site.Item("cod_site").Count - 1
            combo_site.Items.Add(works_site.Item("name")(i))
        Next
        combo_site.Items.Add(translations.getText("dropdownSelectAll"))

        combo_site.SelectedIndex = 0
        combo_site.Enabled = True
        updated = True
        ReDim SectionsIndex(works_sections.Item("cod_section").Count)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles LoadData.Click
        load_absenses()
    End Sub

    Private Sub load_absenses()
        Dim msgbox As message_box_frm
        loaded = False
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSection")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwload) Then
            If bwload.IsBusy Then
                bwload.CancelAsync()
            End If
        End If
        siteSelectionText = combo_site.Text
        sectionSelectionText = combo_section.Text

        bwload = New BackgroundWorker()
        bwload.WorkerSupportsCancellation = True
        bwload.RunWorkerAsync()
    End Sub
    Private Sub bwLoadAM_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwload.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "10") ' absenses
        vars.Add("type", "load")
        vars.Add("sdate", data_inicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("edate", data_fim.Value.ToString("yyyy-MM-dd"))
        translations.load("commonForm")
        combo_section.Invoke(Sub()
                                 If sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                                     vars.Add("section", "all")
                                 Else
                                     vars.Add("section", works_sections.Item("cod_section")(SectionsIndex(combo_section.SelectedIndex)))
                                     End If
                                 End Sub)

        combo_site.Invoke(Sub()
                              If siteSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                                  vars.Add("site", "all")
                              Else
                                  vars.Add("site", works_site.Item("cod_site")(combo_site.SelectedIndex - 1))
                              End If
                          End Sub)

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(2) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If Not data.ContainsKey("absense") Then
                s(0) = "true"
                translations.load("errorMessages")
                s(1) = translations.getText("errorNoRecordsFound")
                e.Result = s
                Exit Sub
            Else
                Dim absensesJson = JArray.Parse(data.Item("absense").ToString)

                'MISSING section name on table for all sections 
                translations.load("commonForm")
                Dim pos As Integer = 0
                If Not siteSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                    pos = pos + 1
                    If Not sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                        pos = pos + 1
                    End If
                End If
                ReDim AMTable(absensesJson.Count - 1 + pos, 6)
                For i = 0 To absensesJson.Count - 1 + pos
                    For j = 0 To 5
                        AMTable(i, j) = ""
                    Next j
                Next i
                If Not siteSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                    AMTable(0, 0) = siteSelectionText
                    If Not sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                        AMTable(1, 0) = sectionSelectionText
                    End If
                End If
                For i = 0 To absensesJson.Count - 1
                    AMTable(pos + i, 0) = absensesJson(i).Item("name").ToString
                    AMTable(pos + i, 1) = absensesJson(i).Item("sdate").ToString
                    AMTable(pos + i, 2) = absensesJson(i).Item("edate").ToString
                    AMTable(pos + i, 3) = absensesJson(i).Item("type").ToString
                    AMTable(pos + i, 4) = absensesJson(i).Item("trip").ToString
                    AMTable(pos + i, 5) = absensesJson(i).Item("motif").ToString
                Next i
                s(2) = absensesJson.Count
                e.Result = s
            End If
        Catch ex As Exception
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            Exit Sub
        End Try

    End Sub

    Private Sub bwLoadAM_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwload.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("commonForm")
        MainMdiForm.statusMessage = translations.getText("addDataToTable")


        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)

        With datatable
            .SuspendLayout()
            .VirtualMode = True
            .Rows.Clear()
            .RowCount = e.Result(2)
            translations.load("workers")

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 6

            .Columns(0).HeaderCell.Value = translations.getText("workerName")
            .Columns(0).Width = 400
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(1).HeaderCell.Value = translations.getText("start")
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(2).HeaderCell.Value = translations.getText("end")
            .Columns(2).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(3).HeaderCell.Value = translations.getText("motif")
            .Columns(3).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(4).HeaderCell.Value = translations.getText("trip")
            .Columns(4).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(5).HeaderCell.Value = translations.getText("annotations")
            .Columns(5).Width = 400
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            Dim colMaxHEight As Integer = 0
            Dim newlines As Integer = 0
            Dim lines As Integer = 0
            For i = 0 To .RowCount - 1
                colMaxHEight = 0
                For j = 0 To 5
                    sizeOfString = g.MeasureString(AMTable(i, j), fontToMeasure)
                    lines = Math.Round(sizeOfString.Width / .Columns(j).Width + 0.5, 0, MidpointRounding.AwayFromZero)
                    newlines = AMTable(i, j).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * colMaxHEight
            Next i

        End With

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        translations.load("readyMessages")
        MainMdiForm.statusMessage = translations.getText("ready")

        loaded = True
    End Sub

    Private Sub Combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_site.SelectedIndexChanged
        combo_section.Items.Clear()
        If combo_site.SelectedIndex > 0 Then
            If combo_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                data_inicio.Value = DateTime.Now
            ElseIf IsDate(works_site.Item("data_inicio")(combo_site.SelectedIndex - 1)) Then
                data_inicio.Value = works_site.Item("data_inicio")(combo_site.SelectedIndex - 1)
            Else
                data_inicio.Value = DateTime.Now
            End If
            If combo_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                data_fim.Value = DateTime.Now
            ElseIf IsDate(works_site.Item("data_fim")(combo_site.SelectedIndex - 1)) Then
                data_fim.Value = works_site.Item("data_fim")(combo_site.SelectedIndex - 1)
            Else
                data_fim.Value = DateTime.Now
            End If

            Dim idx As Integer = 1
                translations.load("commonForm")
                combo_section.Items.Add(translations.getText("dropdownSelectAll"))
                If Not combo_site.SelectedItem.ToString.Equals(translations.getText("dropdownSelectAll")) Then
                    For i = 0 To works_sections.Item("cod_section").Count - 1
                        If works_sections.Item("cod_site")(i).Equals(works_site.Item("cod_site")(combo_site.SelectedIndex - 1)) Then
                            combo_section.Items.Add(works_sections.Item("description")(i))
                            SectionsIndex(idx) = i
                            idx = idx + 1
                        End If
                    Next
                End If
                If combo_section.Items.Count > 0 Then
                    combo_section.SelectedIndex = 0
                End If
            End If
    End Sub

    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded

        If UBound(AMTable, 1) < e.RowIndex Or UBound(AMTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If

        e.Value = AMTable(e.RowIndex, e.ColumnIndex)
        currentDatatable = datatable
    End Sub

    Private Sub SetCurrentMonth_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SetCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub Datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick

    End Sub
End Class