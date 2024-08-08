Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports Newtonsoft.Json
Imports ConstructionSiteLogistics.Site.Shared

Public Class siteManagementActivitiesForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm

    Private loaded As Boolean = False
    Private WithEvents DataRequests As IDataSiteManagementRequests
    Private mask As PictureBox = Nothing
    Private tableData As DataTable
    Private ToggleSidePanelToolTip As New ToolTip()
    Private editMode As Boolean = False
    Private works_site, works_sections, dbBordereau As Dictionary(Of String, List(Of String))
    Private WithEvents requestDataQueue As HttpDataPostData
    Private sectionsIndex As Integer()
    Private siteSelection As Integer(,)
    Private response As String = ""
    Private editModeToolTip As New ToolTip()
    Private selectedSiteIdx As Integer
    Private CellPreviousContents As List(Of String)
    private mainForm As MainMdiForm

    Public Shared datatable_cellY
    Public Shared datatable_cellX
    Public Shared site_index

    Private Sub lateralPanel_Paint(sender As Object, e As PaintEventArgs) Handles lateralPanel.Paint
    End Sub
    Public Sub New(_mainMdiform As MainMdiForm)
        mainForm = _mainMdiform

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        SetDoubleBuffered(datatable)
        Me.Refresh()
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub
    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Private Sub form_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Me.SuspendLayout()

        site_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        translations.load("commonForm")
        site_lbl.Text = translations.getText("dropdownSiteTitle")
        ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))

        Me.ResumeLayout()
    End Sub
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub logger_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        SuspendLayout()
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        divider.BackColor = stateCore.dividerColor

        translations.load("commonForm")
        Dim loadToolTip As New ToolTip()
        loadToolTip.SetToolTip(loadTableBtn, translations.getText("viewLink"))

        Dim saveToolTip As New ToolTip()
        saveToolTip.SetToolTip(saveBtn, translations.getText("saveLink"))

        Dim delToolTip As New ToolTip()
        delToolTip.SetToolTip(delBtn, translations.getText("delLink"))

        Dim addNewToolTip As New ToolTip()
        addNewToolTip.SetToolTip(addNewBtn, translations.getText("addLink"))

        editModeToolTip.SetToolTip(editModeBtn, translations.getText("editModeDisabledLink"))

        Dim hidePanelToolTip As New ToolTip()
        hidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))

        addNewBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "addNew.png"), 0.5)
        saveBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "save.png"), 0.5)
        delBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "delete.png"), 0.5)
        editModeBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "edit.png"), 0.5)

        ResumeLayout()
    End Sub


    Private Sub logger_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        mainForm.childForm = "siteManagementActivities"
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "site.management.dll", "siteManagementDataRequests"), IDataSiteManagementRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        load_data()
        loaded = False
    End Sub

    Private Sub sideToggleBtn_Click(sender As Object, e As EventArgs) Handles sideToggleBtn.Click
        translations.load("commonForm")
        If (lateralPanel.Width.Equals(270)) Then
            lateralPanel.Width = 28
            Refresh()
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("showPanel"))
        Else
            ToggleSidePanelToolTip.SetToolTip(sideToggleBtn, translations.getText("hidePanel"))
            lateralPanel.Width = 270
            Refresh()
        End If
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub removeMask()
        If loaded Then
            Exit Sub
        End If

        loaded = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()
        mask = Nothing
    End Sub

    Private Sub load_data()
        mainForm.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites,sections")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadSiteInitialData()
    End Sub

    Private Sub DataRequests_getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSiteInitialData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim response As String = args.responseData

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
        End If
        ReDim sectionsIndex(works_sections.Count - 1)
lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            Exit Sub
        End If

        siteSelection = loadSitesWithSections(listBoxSite, works_site, works_sections, False)
        listBoxSite.SelectedItem = 0
        removeMask()
        If mask IsNot Nothing Then
            mask.Dispose()
            mask = Nothing
        End If
        mainForm.busy.Close(True)
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub addNewBtn_Click(sender As Object, e As EventArgs) Handles addNewBtn.Click
        Dim CheckFileCompatibility_frm As New CheckFileCompatibility_frm(mainForm)

        If CheckFileCompatibility_frm.ShowDialog = DialogResult.OK Then
            Dim OpenFileDialog1 As New OpenFileDialog
            translations.load("commonForm")
            OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.Filter = translations.getText("filesCsv") & "|*.csv"
            OpenFileDialog1.ShowDialog()
            Dim filename = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub loadTableBtn_Click(sender As Object, e As EventArgs) Handles loadTableBtn.Click
        enableButtonsAndLinks(Me, False)
        Dim vars As New Dictionary(Of String, String)
        Dim misc As New Dictionary(Of String, String)
        selectedSiteIdx = listBoxSite.SelectedIndex - 1
        vars.Add("request", "bordereau")
        vars.Add("site", siteSelection(listBoxSite.SelectedIndex - 1, 0))
        vars.Add("section", siteSelection(listBoxSite.SelectedIndex - 1, 1))

        misc.Add("task", "activities")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, misc, Nothing)
        DataRequests.loadSiteInitialData()

    End Sub

    Private Sub editModeBtn_Click(sender As Object, e As EventArgs) Handles editModeBtn.Click
        If editMode.Equals(True) Then
            datatable.ReadOnly = True
            editMode = False
            editModeBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "edit.png"), 0.5)

            translations.load("commonForm")
            editModeToolTip.SetToolTip(editModeBtn, translations.getText("editModeDisabledLink"))
        Else
            translations.load("commonForm")
            editModeToolTip.SetToolTip(editModeBtn, translations.getText("editModeEnabledLink"))

            datatable.ReadOnly = False
            datatable.Rows(datatable.Rows.Count - 1).ReadOnly = True
            editMode = True
            editModeBtn.Image = Image.FromFile(mainForm.state.imagesPath & "edit.png")
        End If
    End Sub

    Private Sub DataRequests_getResponseActivitiesInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseActivitiesInitialData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        Dim response As String = args.responseData

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        dbBordereau = request.ConvertDataToArray("bordereau", stateCore.queryBordereauFields, response)
        If IsNothing(dbBordereau) Then
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
            enableButtonsAndLinks(Me, True)
            addNewBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "addNew.png"), 0.5)
            saveBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "save.png"), 0.5)
            delBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "delete.png"), 0.5)
            addNewBtn.Enabled = False
            saveBtn.Enabled = False
            delBtn.Enabled = False
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            addNewBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "addNew.png"), 0.5)
            saveBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "save.png"), 0.5)
            delBtn.Image = ChangeOpacity(Image.FromFile(mainForm.state.imagesPath & "delete.png"), 0.5)
            addNewBtn.Enabled = False
            saveBtn.Enabled = False
            delBtn.Enabled = False
            Exit Sub
        End If

        dbBordereau = orderTasksList(dbBordereau)

        translations.load("siteActivity")
        tableData = New DataTable
        tableData.Columns.Add(New DataColumn With {
        .ReadOnly = False,
        .ColumnName = translations.getText("tasksTableColumnId"),
        .DataType = GetType(String)
    })

        tableData.Columns.Add(translations.getText("tasksTableColumnReference"), GetType(String))
        tableData.Columns(1).ReadOnly = False

        Dim primaryLang As String = works_site("primary_lang")(InQueryDictionary(works_site, siteSelection(listBoxSite.SelectedIndex - 1, 0), "cod_site"))
        tableData.Columns.Add(translations.getText("tasksTableColumnActivityTask") & " (" & primaryLang & ")", GetType(String))
        tableData.Columns(2).ReadOnly = False

        Dim siteLangs As String() = works_site("project_languages")(InQueryDictionary(works_site, siteSelection(listBoxSite.SelectedIndex - 1, 0), "cod_site")).Split(",")
        Dim langsCols = If(Array.IndexOf(siteLangs, primaryLang) > -1, siteLangs.Length - 1, siteLangs.Length)
        Dim pos As Integer = 3
        For Each lang As String In siteLangs
            If lang.Equals(primaryLang) Then
                Continue For
            End If
            tableData.Columns.Add(translations.getText("tasksTableColumnActivityTask") & " (" & lang & ")", GetType(String))
            tableData.Columns(pos).ReadOnly = False
            pos += 1
        Next

        tableData.Columns.Add(translations.getText("tasksTableColumnUnitPrice"), GetType(String))
        tableData.Columns(pos).ReadOnly = False
        tableData.Columns.Add(translations.getText("tasksTableColumnQuantity"), GetType(String))
        tableData.Columns(pos + 1).ReadOnly = False
        tableData.Columns.Add(translations.getText("tasksTableColumnUnits"), GetType(String))
        tableData.Columns(pos + 2).ReadOnly = False

        Dim dr(tableData.Columns.Count - 1) As Object
        For i = 0 To dbBordereau("cod_task").Count - 1
            Array.Clear(dr, 0, dr.Length)

            dr(0) = dbBordereau("cod_task")(i)
            dr(1) = dbBordereau("contractor_ref")(i)
            dr(2) = dbBordereau("descricao")(i)
            Try
                pos = 3
                Dim translationData = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(dbBordereau("translations")(i))
                If translationData IsNot Nothing Then
                    For Each lang As String In siteLangs
                        If lang.Equals(primaryLang) Then
                            Continue For
                        End If
                        If translationData.Item(lang) IsNot Nothing Then
                            dr(pos) = translationData.Item(lang).ToString
                        End If
                        pos += 1
                    Next
                End If
            Catch ex As Exception

            End Try
            dr(3 + langsCols) = dbBordereau("pu")(i)
            dr(4 + langsCols) = dbBordereau("qtd")(i)
            dr(5 + langsCols) = dbBordereau("units")(i)

            tableData.Rows.Add(dr)
        Next i
        Array.Clear(dr, 0, dr.Length)
        For i = 0 To tableData.Columns.Count - 1
            dr(i) = ""
        Next
        translations.load("siteActivity")
        dr(3) = translations.getText("tasksAddTask")
        tableData.Rows.Add(dr)

        datatable.DataSource = tableData
        mainForm.state.datatableContents = tableData

        Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        With datatable
            .Visible = False
            '.VirtualMode = True
            .ReadOnly = False

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

            .Columns(0).Width = g.MeasureString("FFFF", fontToMeasure).Width
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).ReadOnly = True
            .Columns(1).Width = g.MeasureString("FFFfffFFFfff", fontToMeasure).Width
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns(2).Width = 400
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

            pos = 3
            For Each lang As String In siteLangs
                If lang.Equals(primaryLang) Then
                    Continue For
                End If
                .Columns(pos).Width = 400
                .Columns(pos).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Columns(pos).SortMode = DataGridViewColumnSortMode.NotSortable
                pos += 1
            Next

            .Columns(3 + langsCols).Width = g.MeasureString("88.888.00€", fontToMeasure).Width
            .Columns(3 + langsCols).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(3 + langsCols).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns(4 + langsCols).Width = g.MeasureString("88.888.00€", fontToMeasure).Width
            .Columns(4 + langsCols).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(4 + langsCols).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns(5 + langsCols).Width = g.MeasureString(translations.getText("tasksTableColumnUnits") & "....", fontToMeasure).Width
            .Columns(5 + langsCols).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5 + langsCols).SortMode = DataGridViewColumnSortMode.NotSortable

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
            .Rows(datatable.Rows.Count - 1).ReadOnly = True
            .Visible = True
        End With

        translations.load("commonForm")
        editModeToolTip.SetToolTip(editModeBtn, translations.getText("editModeEnabledLink"))
        editMode = True
        editModeBtn.Image = Image.FromFile(mainForm.state.imagesPath & "edit.png")
        addNewBtn.Image = Image.FromFile(mainForm.state.imagesPath & "addNew.png")
        saveBtn.Image = Image.FromFile(mainForm.state.imagesPath & "save.png")
        delBtn.Image = Image.FromFile(mainForm.state.imagesPath & "delete.png")
        enableButtonsAndLinks(Me, True)
    End Sub
    Private Sub datatable_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles datatable.CellMouseDoubleClick
        Dim dbdata As New Dictionary(Of String, String)
        datatable_cellY = e.RowIndex
        datatable_cellX = e.ColumnIndex
        site_index = listBoxSite.SelectedIndex
        If datatable_cellY.Equals(-1) Or datatable_cellX.Equals(-1) Then
            Exit Sub
        End If

        translations.load("siteActivity")
        If Not datatable.Rows(datatable_cellY).Cells(datatable_cellX).value.ToString.Equals(translations.getText("tasksAddTask")) Then
            dbdata.Add("tasktype", dbBordereau("enabled")(datatable_cellY))
            dbdata.Add("description", dbBordereau("descricao")(datatable_cellY))
            dbdata.Add("qtd", dbBordereau("qtd")(datatable_cellY))
            dbdata.Add("ref", dbBordereau("contractor_ref")(datatable_cellY))
            dbdata.Add("units", dbBordereau("units")(datatable_cellY))
            dbdata.Add("prevTask", dbBordereau("previous_task")(datatable_cellY))
            dbdata.Add("cod", dbBordereau("cod_task")(datatable_cellY))
            dbdata.Add("site", siteSelection(selectedSiteIdx, 0))
            dbdata.Add("section", siteSelection(selectedSiteIdx, 1))
            dbdata.Add("original", dbBordereau("descricao")(datatable_cellY))
            dbdata.Add("price", dbBordereau("pu")(datatable_cellY))
            dbdata.Add("translations", dbBordereau("translations")(datatable_cellY))
        Else
            dbdata.Add("tasktype", "")
            dbdata.Add("description", translations.getText("tasksAddTask"))
            dbdata.Add("qtd", "")
            dbdata.Add("ref", "")
            dbdata.Add("units", "")
            dbdata.Add("prevTask", "")
            dbdata.Add("cod", "")
            dbdata.Add("site", siteSelection(selectedSiteIdx, 0))
            dbdata.Add("section", siteSelection(selectedSiteIdx, 1))
            dbdata.Add("original", "")
            dbdata.Add("price", "")
            dbdata.Add("translations", "")
        End If

        If editMode.Equals(False) Then
            Dim editsActivityTasks As New siteProductionEditTasksForm(mainForm, dbdata, dbBordereau, works_site)
            If editsActivityTasks.ShowDialog() = DialogResult.OK Then
                load_data()
            End If
        End If


    End Sub

    Private Sub TablePanel_Paint(sender As Object, e As PaintEventArgs) Handles TablePanel.Paint

    End Sub

    Private Sub datatable_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles datatable.CellEnter
        Dim contents As New List(Of String)
        For i = 0 To datatable.Columns.Count - 1
            contents.Add(datatable.Rows(e.RowIndex).Cells(i).Value.ToString)
        Next i

        CellPreviousContents = contents
    End Sub

    Private Sub datatable_CellLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles datatable.CellLeave
        If editMode And Not datatable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Equals(CellPreviousContents(e.ColumnIndex)) Then
            Dim vars As New Dictionary(Of String, String)
            Dim miscData As New Dictionary(Of String, String)

            'TODO ...

        End If
    End Sub

End Class