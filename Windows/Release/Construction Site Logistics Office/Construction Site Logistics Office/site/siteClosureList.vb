Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class siteClosureList_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     

    Private mask As PictureBox = Nothing
    Private loadedForm As Boolean = False
    Private loaded As Boolean = False
    Private updated As Boolean = False

    Private WithEvents bwSites As BackgroundWorker
    Private WithEvents bwload As BackgroundWorker

    Private AMTable As String(,)
    Public Shared currentDatatable As DataGridView
    Private closuresDB, query_site As Dictionary(Of String, List(Of String))


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

    Private Sub siteClosureList_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadedForm = False
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        MainMdiForm.childForm = "siteClosureList"
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

        GroupBox.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular)

        translations.load("commonForm")
        GroupBox.Text = translations.getText("groupBoxSite")

        Me.ResumeLayout()
    End Sub
    Private Sub site_frm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
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
        vars.Add("request", "sites")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
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
        For i = 0 To query_site.Item("name").Count - 1
            combo_site.Items.Add(query_site.Item("name")(i))
        Next
        combo_site.SelectedIndex = 0
        combo_site.Enabled = True
        updated = True

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub LoadTable_Click(sender As Object, e As EventArgs) Handles LoadTable.Click
        load_production()
    End Sub

    Private Sub load_production()
        Dim msgbox As message_box_frm
        loaded = False
        If combo_site.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message As String = translations.getText("errorSelectSite")
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

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "siteclosure")
        vars.Add("cod", query_site.Item("cod_site")(combo_site.SelectedIndex - 1))

        bwload = New BackgroundWorker()
        bwload.WorkerSupportsCancellation = True
        bwload.RunWorkerAsync(vars)
    End Sub
    Private Sub bwLoadAM_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwload.DoWork
        Dim send(1) As String
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(e.Argument)

        send(0) = response
        e.Result = send


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

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            Dim rowpos As Integer = 0
            Dim num_cols As Integer = 0

            rowpos = closuresDB.Item("cod_closure").Count
            num_cols = 3
            ReDim AMTable(rowpos, num_cols)
            For i = 0 To rowpos
                For j = 0 To num_cols
                    AMTable(i, j) = ""
                Next j
            Next i
            For i = 0 To closuresDB.Item("cod_closure").Count - 1
                AMTable(i, 0) = closuresDB.Item("start")(i)
                AMTable(i, 1) = closuresDB.Item("end")(i)
                AMTable(i, 2) = closuresDB.Item("motivo")(i)
            Next i

            s(0) = "false"
            s(1) = rowpos
            e.Result = s
        End If

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
            .RowCount = e.Result(1)
            translations.load("siteClosedDays")

            .RowHeadersVisible = False
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnCount = 3

            .Columns(0).HeaderCell.Value = translations.getText("start")
            .Columns(0).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(1).HeaderCell.Value = translations.getText("end")
            .Columns(1).Width = g.MeasureString("31-31-2031", fontToMeasure).Width

            .Columns(2).HeaderCell.Value = translations.getText("motif")
            .Columns(2).Width = 400
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft

            Dim colMaxHEight As Integer = 0
            Dim newlines As Integer = 0
            Dim lines As Integer = 0
            For i = 0 To .RowCount - 1
                colMaxHEight = 0
                For j = 0 To 2
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

    Private Sub datatable_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles datatable.CellValueNeeded

        If UBound(AMTable, 1) < e.RowIndex Or UBound(AMTable, 2) < e.ColumnIndex Then
            Exit Sub
        End If

        e.Value = AMTable(e.RowIndex, e.ColumnIndex)
        currentDatatable = datatable
    End Sub
End Class