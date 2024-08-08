Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class workersAbsenseList_frm
    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private loaded As Boolean = False
    Private updated As Boolean = False
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Private works_site, works_worker, works_sections, works_absenses As Dictionary(Of String, List(Of String))
    Private SectionsIndex() As Integer
    Private siteSelectionText As String = ""
    Private sectionSelectionText As String = ""
    Private WithEvents DataRequests As IDataAbsencesRequests
    private mainForm As MainMdiForm

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        mainForm = _mainMdiForm

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Application.DoEvents()
        SetDoubleBuffered(datatable)

        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub

    Private Sub receptionMaterials_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        mainForm.childForm = "workersAbsenseList"

        Me.SuspendLayout()

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Height = Me.Height
        mask.Width = Me.Width
        mask.BackColor = Color.White
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Application.DoEvents()
        Me.SuspendLayout()
        datatable.Width = Me.Width - 10 - datatable.Location.X
        datatable.Height = Me.Height - 10 - datatable.Location.Y
        GroupBox_search.Location = New Point(Me.Width - 10 - GroupBox_search.Width, GroupBox_search.Location.Y)

        GroupBoxSelection.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, FontStyle.Bold)
        combo_site.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        Section_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, FontStyle.Regular)
        data_inicio.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        data_fim.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        combo_section.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        DateTo_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        SetCurrentMonth.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, FontStyle.Regular)
        Date_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, FontStyle.Regular)
        GroupBox_search.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, FontStyle.Regular)
        SearchBox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)

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
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "absences.dll", "absencesDataRequests"), IDataAbsencesRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

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
        mainForm.busy.Show()

        updated = False
        combo_site.Enabled = False

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites,sections")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadAbsencesInitialData()
    End Sub
    Private Sub DataRequests_getResponseAbsencesInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseAbsencesInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        Dim request As New HttpDataCore
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_site = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_sections = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(works_sections) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If errorFlag Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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

        mainForm.busy.Close(True)
        removeMask()
    End Sub

    Private Sub LoadData_Click(sender As Object, e As EventArgs) Handles LoadData.Click
        load_absenses()
    End Sub
    Private Sub load_absenses()
        Dim msgbox As messageBoxForm
        loaded = False
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSection")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        mainForm.busy.Show()

        siteSelectionText = combo_site.Text
        sectionSelectionText = combo_section.Text

        Dim vars As New Dictionary(Of String, String)
        vars.Add("type", "load")
        vars.Add("sdate", data_inicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("edate", data_fim.Value.ToString("yyyy-MM-dd"))
        translations.load("commonForm")
        If sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
            vars.Add("section", "all")
        Else
            vars.Add("section", works_sections.Item("cod_section")(SectionsIndex(combo_section.SelectedIndex)))
        End If
        If siteSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
            vars.Add("site", "all")
        Else
            vars.Add("site", works_site.Item("cod_site")(combo_site.SelectedIndex - 1))
        End If

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadAbsencesReportData()
    End Sub
    Private Sub DataRequests_getResponseAbsencesReportData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseAbsencesReportData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim rowCount As Integer
        Dim tableData As New DataTable

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastline
        End If

        tableData = New DataTable
        translations.load("workers")
        tableData.Columns.Add(translations.getText("workerName"), GetType(String))
        tableData.Columns.Add(translations.getText("start"), GetType(String))
        tableData.Columns.Add(translations.getText("end"), GetType(String))
        tableData.Columns.Add(translations.getText("motif"), GetType(String))
        tableData.Columns.Add(translations.getText("trip"), GetType(String))
        tableData.Columns.Add(translations.getText("annotations"), GetType(String))

        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If Not data.ContainsKey("absense") Then
                errorFlag = True
                translations.load("errorMessages")
                errorMsg = translations.getText("errorNoRecordsFound")
                GoTo lastline
            Else
                Dim absensesJson = JArray.Parse(data.Item("absense").ToString)

                'MISSING section name on table for all sections 
                translations.load("commonForm")

                Dim dr(tableData.Columns.Count - 1) As Object

                If Not siteSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                    dr(0) = siteSelectionText
                    tableData.Rows.Add(dr)

                    If Not sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                        dr(tableData.Columns.Count - 1) = New Object
                        dr(0) = sectionSelectionText
                        tableData.Rows.Add(dr)
                    End If
                End If

                For i = 0 To absensesJson.Count - 1
                    dr(tableData.Columns.Count - 1) = New Object

                    dr(0) = absensesJson(i).Item("name").ToString
                    dr(1) = absensesJson(i).Item("sdate").ToString
                    dr(2) = absensesJson(i).Item("edate").ToString
                    dr(3) = absensesJson(i).Item("type").ToString
                    dr(4) = absensesJson(i).Item("trip").ToString
                    dr(5) = absensesJson(i).Item("motif").ToString
                    tableData.Rows.Add(dr)
                Next i
                rowCount = absensesJson.Count
            End If
        Catch ex As Exception
            mainForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            errorFlag = True
            errorMsg = "Error on parsing data. Update software"
            GoTo lastline
        End Try
lastline:

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            loaded = True
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        translations.load("commonForm")
        mainForm.statusMessage = translations.getText("addDataToTable")
        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        sizeOfString = g.MeasureString("888", fontToMeasure)

        mainForm.state.datatableContents = tableData

        With datatable
            .SuspendLayout()
            .VirtualMode = True
            .Visible = False
            .DataSource = tableData

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 6

            .Columns(0).Width = 400
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(2).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(3).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(4).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(5).Width = 400
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            Dim colMaxHEight As Integer = 0
            Dim lines As Integer = 0
            Dim newlines As Integer = 0
            For i = 0 To tableData.Rows.Count - 1
                colMaxHEight = 0
                newlines = 0
                For j = 0 To datatable.Columns.Count - 1
                    If j > 0 Then
                        .Rows(i).Cells(j).ReadOnly = False
                    End If
                    sizeOfString = g.MeasureString(If(IsDBNull(tableData.Rows(i)(j)), " ", tableData.Rows(i)(j)), fontToMeasure)
                    lines = Math.Truncate(sizeOfString.Width / .Columns(j).Width) + 1
                    newlines = If(IsDBNull(tableData.Rows(i)(j)), " ", tableData.Rows(i)(j)).Split(Environment.NewLine).Length
                    lines = Math.Max(lines, newlines)
                    lines = If(lines.Equals(0), 1, lines)
                    If colMaxHEight < lines Then
                        colMaxHEight = lines
                    End If
                Next j
                .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * 1.15 * colMaxHEight
            Next i
            .Visible = True

        End With

        mainForm.busy.Close(True)
        translations.load("readyMessages")
        mainForm.statusMessage = translations.getText("ready")

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

    End Sub

    Private Sub SetCurrentMonth_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SetCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub Datatable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datatable.CellContentClick

    End Sub
End Class