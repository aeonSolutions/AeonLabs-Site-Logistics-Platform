Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class site_closure_frm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Private works_site, closuresDB As Dictionary(Of String, List(Of String))
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private WithEvents DataRequests As IDataSiteRequests
    Private taskRequest As String = ""
    Private response As String = ""
    Private mainForm As MainMdiForm

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        mainForm = _mainMdiForm
        Me.Refresh()
    End Sub


    Private Sub workers_absense_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = System.Drawing.SystemColors.Control
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        Refresh()
        Me.SuspendLayout()

        duracaoInicio.CustomFormat = "yyyy-MM-dd"
        duracaoFim.CustomFormat = "yyyy-MM-dd"
        Me.ResumeLayout()

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        ausenciaslist.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        divider.BackColor = stateCore.dividerColor
        searchTitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        annotations_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        start_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        end_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFim.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        motif.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")

        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(updateBtn, translations.getText("updateLink"))

        Dim saveToolTip As New ToolTip()
        saveToolTip.SetToolTip(saveBtn, translations.getText("saveLink"))

        Dim delToolTip As New ToolTip()
        delToolTip.SetToolTip(delBtn, translations.getText("delLink"))

        searchTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        start_lbl.Text = translations.getText("dateStartTitle")
        end_lbl.Text = translations.getText("dateEndTitle")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        translations.load("siteDaysClosed")
        title.Text = translations.getText("title")

        ResumeLayout()
        loaded = False
    End Sub
    Private Sub workers_absense_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "site.dll", "siteDataRequests"), IDataSiteRequests)
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
    End Sub


    Sub load_list()
        mainForm.busy.Show()

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites")
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadSiteInitialData()

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
        works_site = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(works_site) Then
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
        listview_works.Items.Clear()
        listview_works.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_site.Item("name").Count - 1
            listview_works.Items.Add(works_site.Item("name")(i))
        Next
        listview_works.SelectedIndex = 0
        ausenciaslist.Items.Clear()

        motif.Text = ""
        motif.Enabled = False
        saveBtn.Enabled = False
        delBtn.Enabled = False
        duracaoFim.Enabled = False
        duracaoInicio.Enabled = False
        duracaoFim.Value = DateTime.Now
        duracaoInicio.Value = DateTime.Now

        mainForm.busy.Close(True)
        removeMask()
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

    End Sub


    Private Sub DataRequests_getResponseSaveClosedDaysData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveClosedDaysData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else

            translations.load("messagebox")
            If taskRequest.Equals("del") Then
                msgbox = New messageBoxForm(translations.getText("resultSuccessDelRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            Else
                msgbox = New messageBoxForm(translations.getText("resultSuccessAddRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            End If
            msgbox.ShowDialog()
            duracaoFim.Value = DateTime.Now
            duracaoInicio.Value = DateTime.Now
            motif.Text = ""

            loadDateEntries()
            mainForm.busy.Close(True)

            motif.Enabled = False
            saveBtn.Enabled = False
            duracaoFim.Enabled = False
            duracaoInicio.Enabled = False
            delBtn.Enabled = False

        End If
        taskRequest = ""
    End Sub

    Private Sub delBtn_Click(sender As Object, e As EventArgs) Handles delBtn.Click
        translations.load("messagebox")
        msgbox = New messageBoxForm(translations.getText("questionRemoveRecord") & "? ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("type", "del")
            vars.Add("cod", closuresDB.Item("cod_closure")(ausenciaslist.SelectedIndex - 1))
            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveClosedDaysData()
        End If
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If (ausenciaslist.SelectedItems.Count = 0) Then ' edit ausencia
            translations.load("siteDaysClosed")
            Dim message3 As String = translations.getText("errorRecordRequired")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If listview_works.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim selected As String = works_site.Item("cod_site")(listview_works.SelectedIndex - 1)

        Dim startD As Date, endD As Date

        startD = duracaoInicio.Value
        endD = duracaoFim.Value

        If DateTime.Compare(startD, endD) > 0 And Not duracaoInicio.Value.ToString("yyyy-MM-dd").Equals(duracaoFim.Value.ToString("yyyy-MM-dd")) Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorDateInterval")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If


        If (motif.Text = "") Then
            motif.Text = "null"
        End If

        Dim vars As New Dictionary(Of String, String)
        If (ausenciaslist.SelectedIndex > 0) Then ' edit ausencia
            vars.Add("type", "edit")
            vars.Add("cod", closuresDB.Item("cod_ausencia")(ausenciaslist.SelectedIndex - 1))
        Else ' add new
            vars.Add("type", "add")
            vars.Add("site", selected)
        End If
        vars.Add("inicio", duracaoInicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("fim", duracaoFim.Value.ToString("yyyy-MM-dd"))
        vars.Add("motivo", motif.Text)

        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveClosedDaysData()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        doSearch(If(listview_works.SelectedIndex <= 0, 1, listview_works.SelectedIndex + 1), True)
    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If Not works_site.Item("cod_site").Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To works_site.Item("cod_site").Count - 1
                If Not works_site.Item("name")(i).ToLower.IndexOf(searchbox.Text.ToLower) = -1 Then
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

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        load_list()
    End Sub


    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listview_works.DrawItem
        e.DrawBackground()
        If e.Index > 0 Then
            If String.Compare(listview_works.Items(e.Index).ToString.Substring(0, 1).ToLower, listview_works.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            Else
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
        Else
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.Honeydew)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.LimeGreen)
            e.Graphics.FillRectangle(mybrush, e.Bounds)
        End If
        Using b As New SolidBrush(e.ForeColor)
            If Not IsNothing(listview_works) Then
                If listview_works.Items.Count > 0 Then
                    e.Graphics.DrawString(listview_works.GetItemText(listview_works.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            ausenciaslist.Enabled = True
            mainForm.busy.Show()

            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                ausenciaslist.Items.Clear()

                motif.Text = ""
                motif.Enabled = False
                saveBtn.Enabled = False
                delBtn.Enabled = False
                ausenciaslist.Enabled = False
                duracaoFim.Enabled = False
                duracaoInicio.Enabled = False
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now
            Else 'edit worker
                loadDateEntries()
                mainForm.busy.Close(True)
            End If
            listview_works.Enabled = True
        Else
            ausenciaslist.Enabled = False
        End If
    End Sub

    Private Sub loadDateEntries()
        ausenciaslist.Items.Clear()
        translations.load("siteDaysClosed")
        ausenciaslist.Items.Add(translations.getText("addRecord"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "siteclosure")
        vars.Add("cod", works_site.Item("cod_site")(listview_works.SelectedIndices(0) - 1))

        Dim misc As New Dictionary(Of String, String)
        misc.Add("task", "siteClosedDays")

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, misc, Nothing)
        DataRequests.loadSiteInitialData()
    End Sub
    Private Sub DataRequests_getResponseLoadSiteClosedDaysData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadSiteClosedDaysData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        closuresDB = request.ConvertDataToArray("siteclosure", stateCore.querySiteClosureFields, response)
        If IsNothing(closuresDB) Then
            mainForm.statusMessage = GetMessage(request.errorMessage)
            Exit Sub
        End If

        For i = 0 To closuresDB.Item("cod_closure").Count - 1
            ausenciaslist.Items.Add(closuresDB.Item("motivo")(i) & " [" & closuresDB.Item("start")(i) & " a " & closuresDB.Item("end")(i) & "]")
        Next i
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ausenciaslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ausenciaslist.SelectedIndexChanged
        If (ausenciaslist.SelectedItems.Count > 0) Then
            motif.Enabled = True
            saveBtn.Enabled = True
            duracaoFim.Enabled = True
            duracaoInicio.Enabled = True
            duracaoFim.Value = DateTime.Now
            duracaoInicio.Value = DateTime.Now

            If ausenciaslist.SelectedIndices(0) = 0 Then 'new worker
                motif.Text = ""
                delBtn.Enabled = False
            Else ' edit ausencia
                delBtn.Enabled = True
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now

                If IsDate(closuresDB.Item("start")(ausenciaslist.SelectedIndex - 1)) Then
                    duracaoInicio.Value = closuresDB.Item("start")(ausenciaslist.SelectedIndex - 1)
                Else
                    duracaoInicio.Value = DateTime.Now
                End If

                If IsDate(closuresDB.Item("end")(ausenciaslist.SelectedIndex - 1)) Then
                    duracaoFim.Value = closuresDB.Item("end")(ausenciaslist.SelectedIndex - 1)
                Else
                    duracaoFim.Value = DateTime.Now
                End If

                motif.Text = closuresDB.Item("motivo")(ausenciaslist.SelectedIndex - 1)
            End If
        End If
    End Sub

End Class