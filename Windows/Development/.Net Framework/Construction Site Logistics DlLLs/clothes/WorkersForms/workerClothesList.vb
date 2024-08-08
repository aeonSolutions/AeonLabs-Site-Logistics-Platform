Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class workersClothesList_frm
    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private loaded As Boolean = False
    Private updated As Boolean = False
    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwload As BackgroundWorker
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private WithEvents DataRequests As IDataClothesRequests
    Private mainForm As MainMdiForm

    Private tableData As DataTable
    Public Shared currentDatatable As DataGridView
    Private works_site, works_worker, works_sections As Dictionary(Of String, List(Of String))
    Private SectionsIndex() As Integer
    Private siteSelectionText As String = ""
    Private sectionSelectionText As String = ""
    Private requestType As String = ""

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        SetDoubleBuffered(datatable)
        Me.WindowState = FormWindowState.Maximized
        mainForm = _mainMdiForm
        Me.Refresh()
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub

    Private Sub receptionMaterials_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        mainForm.childForm = "workersClothesList"

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
        Me.SuspendLayout()
        GroupBox_search.Location = New Point(Me.Width - 10 - GroupBox_search.Width, GroupBox_search.Location.Y)
        GroupBoxSelection.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, FontStyle.Bold)
        workersGroupBox.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, FontStyle.Bold)
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
        listview_works.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        workerSearchBox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        searchTitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        workerData_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, FontStyle.Bold)
        workerStart_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        workerEnd_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        workerSetCurrentMonth.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, FontStyle.Regular)

        translations.load("commonForm")
        workersGroupBox.Text = translations.getText("workersTitle")
        GroupBoxSelection.Text = translations.getText("groupBoxSite")
        Section_lbl.Text = translations.getText("siteSection")
        DateTo_lbl.Text = translations.getText("dateTo")
        SetCurrentMonth.Text = translations.getText("currentMonth")
        Date_lbl.Text = translations.getText("dateTitle")
        GroupBox_search.Text = translations.getText("SearchBoxTitle")

        Dim LoadDataByWorkerToolTip As New ToolTip()
        LoadDataByWorkerToolTip.SetToolTip(loadDataByWorkerBtn, translations.getText("viewInfoLink"))

        Dim loadDataToolTip As New ToolTip()
        loadDataToolTip.SetToolTip(LoadData, translations.getText("viewInfoLink"))

        searchTitle.Text = translations.getText("SearchBoxTitle")
        workerData_lbl.Text = translations.getText("dateTitle")
        workerStart_lbl.Text = translations.getText("dateStartTitle")
        workerEnd_lbl.Text = translations.getText("dateEndTitle")
        workerSetCurrentMonth.Text = translations.getText("currentMonth")

        datatable.Width = Me.Width - 10 - datatable.Location.X
        datatable.Height = Me.Height - 10 - datatable.Location.Y
        workersGroupBox.Height = datatable.Height

        workerSetCurrentMonth.Location = New Point(workerSetCurrentMonth.Location.X, workersGroupBox.Height - loadDataByWorkerBtn.Height - 5)
        workerEnd_lbl.Location = New Point(workerEnd_lbl.Location.X, workerSetCurrentMonth.Location.Y - workerSetCurrentMonth.Height - 10)
        workerStart_lbl.Location = New Point(workerStart_lbl.Location.X, workerEnd_lbl.Location.Y - workerEnd_lbl.Height - 10)
        workerData_lbl.Location = New Point(workerData_lbl.Location.X, workerStart_lbl.Location.Y - workerStart_lbl.Height - 5)
        worker_data_fim.Location = New Point(worker_data_fim.Location.X, workerEnd_lbl.Location.Y)
        worker_data_inicio.Location = New Point(worker_data_inicio.Location.X, workerStart_lbl.Location.Y)
        loadDataByWorkerBtn.Location = New Point(loadDataByWorkerBtn.Location.X, worker_data_fim.Location.Y)

        listview_works.Height = workerData_lbl.Location.Y - listview_works.Location.Y
        Me.ResumeLayout()
    End Sub

    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "clothes.dll", "clothesDataRequests"), IDataClothesRequests)
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
        vars.Add("request", "sites,sections,workers")

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadClothesInitialData()
    End Sub
    Private Sub DataRequests_getResponseClothesInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseClothesInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", stateCore.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
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

        listview_works.Items.Clear()
        translations.load("commonForm")
        listview_works.Items.Add(translations.getText("selectWorker"))
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            If (Not works_worker.Item("activo")(i).Equals("0")) Then
                listview_works.Items.Add(works_worker.Item("name")(i))
            End If
        Next i
        listview_works.Items.Add(translations.getText("dropdownSelectAll"))

        mainForm.busy.Close(True)
        removeMask()
    End Sub

    Private Sub LoadData_Click(sender As Object, e As EventArgs) Handles LoadData.Click
        requestType = "site"
        load_absenses()
    End Sub

    Private Sub load_absenses()
        Dim msgbox As messageBoxForm
        loaded = False
        If (combo_site.SelectedIndex < 1 And requestType.Equals("site")) Or (requestType.Equals("worker") And listview_works.SelectedIndex < 1) Then
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
        If requestType.Equals("site") Then
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
        Else
            vars.Add("sdate", worker_data_inicio.Value.ToString("yyyy-MM-dd"))
            vars.Add("edate", worker_data_fim.Value.ToString("yyyy-MM-dd"))

            If listview_works.SelectedItems(0).ToString.Equals(translations.getText("dropdownSelectAll")) Then
                vars.Add("worker", "all")
            Else
                vars.Add("worker", works_worker.Item("cod_worker")(listview_works.SelectedIndex - 1))
            End If
        End If

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadClothesReportData()
    End Sub

    Private Sub DataRequests_getResponseClothesReportData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseClothesReportData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        Dim rowCount As Integer = 0
        Try
            Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If Not data.ContainsKey("clothes") Then
                errorFlag = True
                translations.load("errorMessages")
                errorMsg = translations.getText("errorNoRecordsFound")
                GoTo lastLine
            Else
                Dim absensesJson = JArray.Parse(data.Item("clothes").ToString)

                tableData = New DataTable
                translations.load("workers")
                tableData.Columns.Add(translations.getText("workerName"), GetType(String))
                tableData.Columns.Add(translations.getText("clothes"), GetType(String))
                translations.load("commonForm")
                tableData.Columns.Add(translations.getText("dateTitle"), GetType(String))
                tableData.Columns.Add(translations.getText("AnnotationTitle"), GetType(String))

                Dim dr(tableData.Columns.Count - 1) As Object

                If Not siteSelectionText.Equals(translations.getText("dropdownSelectAll")) And requestType.Equals("site") Then
                    dr(0) = siteSelectionText
                    tableData.Rows.Add(dr)

                    If Not sectionSelectionText.Equals(translations.getText("dropdownSelectAll")) Then
                        dr(tableData.Columns.Count - 1) = New Object
                        dr(0) = sectionSelectionText
                        tableData.Rows.Add(dr)

                    End If
                End If
                Dim prevName As String = ""
                For i = 0 To absensesJson.Count - 1
                    Array.Clear(dr, 0, dr.Length)

                    If Not prevName.Equals(absensesJson(i).Item("name").ToString) Then
                        dr(0) = absensesJson(i).Item("name").ToString
                        prevName = absensesJson(i).Item("name").ToString
                    End If
                    dr(1) = absensesJson(i).Item("date").ToString
                    dr(2) = absensesJson(i).Item("clothes").ToString
                    dr(3) = absensesJson(i).Item("note").ToString
                    tableData.Rows.Add(dr)
                Next i
            End If
        Catch ex As Exception
            mainForm.busy.Close(True)
            mainForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
            Exit Sub
        End Try
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
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(errorMsg & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        datatable.DataSource = tableData
        mainForm.state.datatableContents = tableData

        translations.load("commonForm")
        mainForm.statusMessage = translations.getText("addDataToTable")


        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)

        With datatable
            .SuspendLayout()
            .Visible = False

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 4

            .Columns(0).Width = 400
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(2).Width = 200
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(3).Width = 400
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

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
        Dim translations2 As New languageTranslations(stateCore)


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
            translations2.load("commonForm")
            combo_section.Items.Add(translations2.getText("dropdownSelectAll"))
            If Not combo_site.SelectedItem.ToString.Equals(translations2.getText("dropdownSelectAll")) Then
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

    Private Sub WorkersGroupBox_Enter(sender As Object, e As EventArgs) Handles workersGroupBox.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        doSearch(If(listview_works.SelectedIndex <= 0, 1, listview_works.SelectedIndex + 1), True)
    End Sub

    Private Sub loadDataByWorkerBtn_Click(sender As Object, e As EventArgs) Handles loadDataByWorkerBtn.Click
        requestType = "worker"
        load_absenses()
    End Sub

    Private Sub workerSetCurrentMonth_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles workerSetCurrentMonth.LinkClicked
        Dim num_days As Integer = System.DateTime.DaysInMonth(DateAndTime.Now.ToString("yyyy"), DateAndTime.Now.ToString("MM"))

        worker_data_inicio.Value = DateAndTime.Now.ToString("yyyy-MM") & "-01"
        worker_data_fim.Value = DateAndTime.Now.ToString("yyyy-MM-") & num_days
    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged

    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If Not works_worker.Item("cod_worker").Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To works_worker.Item("cod_worker").Count - 1
                If Not works_worker.Item("name")(i).ToLower.IndexOf(workerSearchBox.Text.ToLower) = -1 Then
                    listview_works.SelectedIndex = i
                    found = True
                    Exit For
                End If
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound") & ". " & translations.getText("searchAgainQuestion")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearch(0, False)
                End If
            End If
        End If
    End Sub

    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listview_works.DrawItem

        e.DrawBackground()
        Dim selected As Boolean = False
        If e.Index > 0 Then
            If String.Compare(listview_works.Items(e.Index).ToString.Substring(0, 1).ToLower, listview_works.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            Else
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            selected = True
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        Dim ForeColor As Color = Color.Black
        If selected Then
            ForeColor = Color.DarkGreen
        End If
        Using b As New SolidBrush(ForeColor)
            If Not IsNothing(listview_works) Then
                If listview_works.Items.Count > 0 Then
                    e.Graphics.DrawString(listview_works.GetItemText(listview_works.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub
End Class
