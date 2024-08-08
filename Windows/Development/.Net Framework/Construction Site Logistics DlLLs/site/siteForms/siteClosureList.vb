Imports System.ComponentModel
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core


Public Class siteClosureList_frm
    Private msgbox As messageBoxForm
    Private state As New environmentVars
    Private translations As languageTranslations


    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private loaded As Boolean = False
    Private updated As Boolean = False
    Private WithEvents DataRequests As IDataSiteRequests
    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwload As BackgroundWorker

    Public Shared currentDatatable As DataGridView
    Private closuresDB, query_site As Dictionary(Of String, List(Of String))
    Private mainForm As MainMdiForm
    Private tabledata As DataTable

    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub
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

    Private Sub siteClosureList_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        state = mainForm.state
        translations = New languageTranslations(state)
        mainForm.childForm = "siteClosureList"
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

        GroupBox.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        translations.load("commonForm")
        GroupBox.Text = translations.getText("groupBoxSite")

        Me.ResumeLayout()
    End Sub
    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(state, "site.dll", "siteDataRequests"), IDataSiteRequests)
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
            FileSystem.Kill(String.Format("{0}", state.tmpPath & "*.*"))
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
        vars.Add("request", "sites")
        DataRequests.Initialise(state)

        DataRequests.Initialise(state)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadSiteInitialData()

        updated = False
        combo_site.Enabled = False
    End Sub
    Private Sub DataRequests_getResponseSiteInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSiteInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        query_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(query_site) Then
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
        For i = 0 To query_site.Item("name").Count - 1
            combo_site.Items.Add(query_site.Item("name")(i))
        Next
        combo_site.SelectedIndex = 0
        combo_site.Enabled = True
        updated = True

        mainForm.busy.Close(True)
        removeMask()
    End Sub



    Private Sub LoadTable_Click(sender As Object, e As EventArgs) Handles LoadTable.Click
        load_production()
    End Sub

    Private Sub load_production()
        Dim msgbox As messageBoxForm
        loaded = False
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            loaded = True
            Exit Sub
        End If

        mainForm.busy.Show()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "siteclosure")
        vars.Add("cod", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))

        Dim misc As New Dictionary(Of String, String)
        misc.Add("task", "siteClosedDays")

        DataRequests.Initialise(state)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadSiteInitialData()

        updated = False
        combo_site.Enabled = False
    End Sub
    Private Sub DataRequests_getResponseLoadSiteClosedDaysData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadSiteClosedDaysData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        closuresDB = request.ConvertDataToArray("siteclosure", state.querySiteClosureFields, response)
        If IsNothing(closuresDB) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

        translations.load("commonForm")
        mainForm.statusMessage = translations.getText("addDataToTable")
        tabledata = New DataTable
        translations.load("siteClosedDays")
        tableData.Columns.Add(translations.getText("start"), GetType(String))
        tableData.Columns.Add(translations.getText("end"), GetType(String))
        tableData.Columns.Add(translations.getText("motif"), GetType(String))

        Dim dr(tableData.Columns.Count - 1) As Object

        For i = 0 To closuresDB.Item("cod_closure").Count - 1
            Array.Clear(dr, 0, dr.Length)

            dr(0) = closuresDB.Item("start")(i)
            dr(1) = closuresDB.Item("end")(i)
            dr(2) = closuresDB.Item("motivo")(i)
            tabledata.rows.add(dr)
        Next i

        datatable.DataSource = tabledata
        mainForm.state.datatableContents = tabledata

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        sizeOfString = g.MeasureString("888", fontToMeasure)

        With datatable
            .SuspendLayout()
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 3

            .Columns(0).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width
            .Columns(2).Width = 400
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            Dim colMaxHEight As Integer = 0
            Dim lines As Integer = 0
            Dim newlines As Integer = 0
            For i = 0 To tabledata.Rows.Count - 1
                colMaxHEight = 0
                newlines = 0
                For j = 0 To datatable.Columns.Count - 1
                    If j > 0 Then
                        .Rows(i).Cells(j).ReadOnly = False
                    End If
                    sizeOfString = g.MeasureString(If(IsDBNull(tabledata.Rows(i)(j)), " ", tabledata.Rows(i)(j)), fontToMeasure)
                    lines = Math.Truncate(sizeOfString.Width / .Columns(j).Width) + 1
                    newlines = If(IsDBNull(tabledata.Rows(i)(j)), " ", tabledata.Rows(i)(j)).Split(Environment.NewLine).Length
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
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded

    End Sub
End Class