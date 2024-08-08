Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class workersClothesForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private WithEvents DataRequests As IDataClothesRequests

    Private workersDB, vestuarioDB, sitesDB, sectionsDB As Dictionary(Of String, List(Of String))
    Private siteSelection As Integer(,)
    Private workersDbCod As String()
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private WithEvents bwWorkers As BackgroundWorker
    Private taskRequest As String = ""
    private mainForm As MainMdiForm

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New(_mainMdiForm As MainMdiForm)
        mainForm = _mainMdiForm

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub workers_clothes_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        requestedDate.CustomFormat = "yyyy-MM-dd"
        deliveredDate.CustomFormat = "yyyy-MM-dd"

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredClothesList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        divider.BackColor = stateCore.dividerColor
        searchTitle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        annotations_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        tipo_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        tipo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        outro_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        outro.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredDate.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        requestedDate.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteRecordDate.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredDate_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        requestedDate_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        motivo.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        requieredClothesList.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        requested_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        delivered_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        site_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        workerClothesSizes.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        site_lbl.Text = translations.getText("dropdownSiteTitle")
        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(workersUpdateBtn, translations.getText("updateLink"))

        Dim saveToolTip As New ToolTip()
        saveToolTip.SetToolTip(saveBtn, translations.getText("saveLink"))

        Dim delToolTip As New ToolTip()
        delToolTip.SetToolTip(delBtn, translations.getText("delLink"))

        translations.load("workersClothes")
        title.Text = translations.getText("title")
        tipo_lbl.Text = translations.getText("typeOfClothes")
        outro_lbl.Text = translations.getText("otherClothes")
        deliveredDate_lbl.Text = translations.getText("deliveryDate")
        requestedDate_lbl.Text = translations.getText("requestedDate")
        requested_lbl.Text = translations.getText("requestedClothes")
        delivered_lbl.Text = translations.getText("deliveredClothes")
        workerClothesSizes.Text = ""

        siteRecordDate.Value = Now()

        ResumeLayout()
        loaded = False
    End Sub

    Private Sub workers_clothes_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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

    Sub load_list()
        mainForm.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "sites,sections")

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
        sitesDB = request.ConvertDataToArray("sites", stateCore.querySiteFields, response)
        If IsNothing(sitesDB) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        sectionsDB = request.ConvertDataToArray("sections", stateCore.querySiteSectionFields, response)
        If IsNothing(sectionsDB) Then
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
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        siteSelection = loadSitesWithSections(combo_site, sitesDB, sectionsDB)

        listview_works.Items.Clear()
        deliveredClothesList.Items.Clear()
        requieredClothesList.Items.Clear()
        tipo.SelectedIndex = -1

        motivo.Text = ""
        tipo.Enabled = False
        motivo.Enabled = False
        saveBtn.Enabled = False
        delBtn.Enabled = False
        deliveredDate.Enabled = False
        deliveredDate.Value = DateTime.Now
        requestedDate.Value = DateTime.Now

        mainForm.busy.Close(True)
        removeMask()
        loaded = True
    End Sub

    Private Function loadSitesWithSections(combo_site As ComboBox, sitesDB As Dictionary(Of String, List(Of String)), sectionsDB As Dictionary(Of String, List(Of String))) As Integer(,)
        Throw New NotImplementedException()
    End Function

    Private Sub delBtn_Click(sender As Object, e As EventArgs) Handles delBtn.Click
        translations.load("messagebox")
        msgbox = New messageBoxForm(translations.getText("questionRemoveRecord") & "? ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("type", "del")
            vars.Add("cod", vestuarioDB.Item("cod_clothes")(deliveredClothesList.SelectedIndex - 1))
            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.loadClothesReportData()
        End If
    End Sub
    Private Sub DataRequests_getResponseClothesReportData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseClothesReportData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore
        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            translations.load("messagebox")
            If taskRequest.Equals("del") Then
                msgbox = New messageBoxForm(translations.getText("resultSuccessDelRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            Else
                msgbox = New messageBoxForm(translations.getText("resultSuccessAddRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            End If
            msgbox.ShowDialog()
            deliveredDate.Value = DateTime.Now
            motivo.Text = ""
            tipo.SelectedIndex = 0
            outro.Text = ""

            loadClothes()
        End If
        taskRequest = ""
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If (deliveredClothesList.SelectedItems.Count = 0) Then ' edit ausencia
            msgbox = New messageBoxForm("Tem que seleccionar um registo de vestuario ou escolher 'adicionar vestuario' na lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If listview_works.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If tipo.SelectedIndex < 0 Then
            translations.load("workersClothes")
            Dim message3 As String = translations.getText("errorSelectClothes")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            tipo.Focus()
            Exit Sub
        End If
        If tipo.SelectedItem.ToString.Equals("Outro") And outro.Text.ToString.Equals("") Or tipo.SelectedIndex < 0 Then
            translations.load("workersClothes")
            Dim message3 As String = translations.getText("errorTypeClothes")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            outro.Focus()
            Exit Sub
        End If
        Dim selected As String = workersDB.Item("cod_worker")(listview_works.SelectedIndex - 1)
        Dim vestuario As String

        If (motivo.Text = "") Then
            motivo.Text = "null"
        End If
        If tipo.SelectedIndex.ToString.Equals("Outro") Then
            vestuario = outro.Text.ToString
        Else
            vestuario = tipo.SelectedItem.ToString
        End If

        Dim vars As New Dictionary(Of String, String)
        If (deliveredClothesList.SelectedIndex > 0) Then ' edit ausencia
            vars.Add("type", "edit")
            vars.Add("cod", vestuarioDB.Item("cod_clothes")(deliveredClothesList.SelectedIndex - 1))
        Else ' add new
            vars.Add("type", "add")
            vars.Add("worker", selected)
        End If
        vars.Add("date", deliveredDate.Value.ToString("yyyy-MM-dd"))
        vars.Add("vest", vestuario)
        vars.Add("nota", motivo.Text)
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadClothesReportData()
    End Sub

    Private Sub DataRequests_getResponseClothesData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseClothesData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        vestuarioDB = request.ConvertDataToArray("clothes", stateCore.querySiteClothesFields, response)
        If Not IsNothing(vestuarioDB) Then
            For i = 0 To vestuarioDB.Item("cod_clothes").Count - 1
                If vestuarioDB.Item("delivered")(i).Equals("1") Then
                    deliveredClothesList.Items.Add(vestuarioDB.Item("clothes")(i) & " [" & vestuarioDB.Item("data")(i) & " a " & vestuarioDB.Item("clothes")(i) & "]")
                Else
                    requieredClothesList.Items.Add(vestuarioDB.Item("clothes")(i) & " [" & vestuarioDB.Item("data")(i) & " a " & vestuarioDB.Item("clothes")(i) & "]")
                End If
            Next i
        End If

        ' "pe", "calcas", "casaco", "peso", "altura"
        translations.load("workers")
        workerClothesSizes.Text = translations.getText("size") & ": " _
         & Environment.NewLine & "• " & translations.getText("weight") & ": " & workersDB.Item("peso")(listview_works.SelectedIndex - 1) _
         & Environment.NewLine & "• " & translations.getText("height") & ": " & workersDB.Item("altura")(listview_works.SelectedIndex - 1) _
         & Environment.NewLine & "• " & translations.getText("pants") & ": " & workersDB.Item("calcas")(listview_works.SelectedIndex - 1) _
         & Environment.NewLine & "• " & translations.getText("foot") & ": " & workersDB.Item("pe")(listview_works.SelectedIndex - 1) _
         & Environment.NewLine & "• " & translations.getText("jacket") & ": " & workersDB.Item("casaco")(listview_works.SelectedIndex - 1)

        If workersDB.Item("photo")(listview_works.SelectedIndices(0) - 1).ToString.Equals("") Then
            photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("worker.png"))
        Else
            photobox.Image = Image.FromFile(mainForm.state.imagesPath & Convert.ToString("loading.png"))
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & workersDB.Item("photo")(listview_works.SelectedIndices(0) - 1).ToString)))
                photobox.Image = tImage
            Catch ex As Exception
                photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
                translations.load("errorMessages")
                mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub
    Private Sub loadClothes()
        requieredClothesList.Items.Clear()
        deliveredClothesList.Items.Clear()
        translations.load("workersClothes")
        deliveredClothesList.Items.Add(translations.getText("addClothes"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "clothes")
        vars.Add("cod", workersDB.Item("cod_worker")(listview_works.SelectedIndex - 1))

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadClothesData()

        'ToDo: replace clothes field by a code to enable translations
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        doSearchWorkers(0, True, False, workersDB, listview_works, searchbox.Text.ToString)
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

    Private Sub combo_site_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_site.SelectedIndexChanged
        If IsNothing(siteSelection) Or loaded.Equals(False) Then
            Exit Sub
        End If
        loadWorkers()
    End Sub

    Sub loadWorkers()
        mainForm.busy.Show()

        Dim qsite As String = ""
        Dim qsection As String = ""
        Dim sdate, edate As String
        Dim vars As New Dictionary(Of String, String)

        If siteSelection(combo_site.SelectedIndex - 1, 0).Equals(-1) Then 'ALL
            qsite = "all"
        Else
            qsite = siteSelection(combo_site.SelectedIndex - 1, 0)
        End If
        If siteSelection(combo_site.SelectedIndex - 1, 1).Equals(-1) Then
            qsection = "all"
        Else
            qsection = siteSelection(combo_site.SelectedIndex - 1, 1)
        End If

        sdate = siteRecordDate.Value.ToString("yyyy-MM") & "-01"
        edate = siteRecordDate.Value.ToString("yyyy-MM") & "-" & System.DateTime.DaysInMonth(DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"))

        vars.Add("request", "workersonsite")
        vars.Add("options", "clothesizes")
        vars.Add("site", qsite)
        vars.Add("section", qsection)
        vars.Add("sdate", sdate)
        vars.Add("edate", edate)

        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadWorkersOnSiteData()
    End Sub

    Private Sub DataRequests_getResponseWorkersOnSiteData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseWorkersOnSiteData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        workersDB = request.ConvertDataToArray("workersonsite", stateCore.queryWorkersOnSiteFields.Union(stateCore.queryWorkerOptionsClothes).ToArray(), response)
        If IsNothing(workersDB) Then
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
            mainForm.busy.Close(True)
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

        listview_works.Items.Clear()
        deliveredClothesList.Items.Clear()
        requieredClothesList.Items.Clear()

        translations.load("commonForm")
        listview_works.Items.Add(translations.getText("selectWorker"))
        translations.load("workersClothes")
        deliveredClothesList.Items.Add(translations.getText("addClothes"))

        ReDim workersDbCod(workersDB.Item("cod_worker").Count + 1)
        workersDbCod(0) = ""
        For i = 0 To workersDB.Item("cod_worker").Count - 1
            listview_works.Items.Add(workersDB.Item("name")(i).ToString())
            workersDbCod(i + 1) = workersDB.Item("cod_worker")(i).ToString()
        Next i
        listview_works.SelectedIndex = 0

        loaded = True
        mainForm.busy.Close(True)
    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            deliveredClothesList.Enabled = True
            If Not IsNothing(mainForm.busy) Then
                If mainForm.busy.isActive().Equals(False) Then

                    mainForm.busy.Show()
                End If
            End If
            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'select worker
                deliveredClothesList.Items.Clear()
                tipo.SelectedIndex = -1
                motivo.Text = ""
                tipo.Enabled = False
                motivo.Enabled = False
                saveBtn.Enabled = False
                delBtn.Enabled = False
                deliveredClothesList.Enabled = False
                deliveredDate.Enabled = False
                outro.Enabled = False
                deliveredDate.Value = DateTime.Now
                workerClothesSizes.Text = ""
                photobox.Image = Image.FromFile(mainForm.state.imagesPath & "worker.png")
                photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Else 'edit worker
                loadClothes()
            End If
            listview_works.Enabled = True
        Else
            deliveredClothesList.Enabled = False

        End If
        mainForm.busy.Close(True)
    End Sub

    Private Sub requieredClothesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles requieredClothesList.SelectedIndexChanged
        loadFormData(requieredClothesList)
    End Sub

    Private Sub workersUpdateBtn_Click(sender As Object, e As EventArgs) Handles workersUpdateBtn.Click
        loadWorkers()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub ausenciaslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles deliveredClothesList.SelectedIndexChanged
        loadFormData(deliveredClothesList)
    End Sub

    Private Sub loadFormData(listbox As ListBox)
        If (listbox.SelectedItems.Count > 0) Then
            tipo.Enabled = True
            motivo.Enabled = True
            saveBtn.Enabled = True
            deliveredDate.Enabled = True
            deliveredDate.Value = DateTime.Now
            outro.Enabled = True
            requestedDate_lbl.Enabled = True
            delivered_lbl.Enabled = True
            tipo_lbl.Enabled = True
            outro_lbl.Enabled = True
            annotations_lbl.Enabled = True
            tipo.SelectedIndex = 0
            deliveredDate_lbl.Enabled = True
            If listbox.SelectedIndices(0) = 0 Then 'new worker
                motivo.Text = ""
                delBtn.Enabled = False
            Else ' edit ausencia
                delBtn.Enabled = True
                'cod_clothes, cod_worker, data, clothes, note, request_date ,delivered
                If IsDate(vestuarioDB.Item("data")(listbox.SelectedIndex - 1)) Then
                    deliveredDate.Value = vestuarioDB.Item("data")(listbox.SelectedIndex - 1)
                Else
                    deliveredDate.Value = DateTime.Now
                End If
                If IsDate(vestuarioDB.Item("data")(listbox.SelectedIndex - 1)) Then
                    deliveredDate.Value = vestuarioDB.Item("data")(listbox.SelectedIndex - 1)
                Else
                    deliveredDate.Value = DateTime.Now
                End If

                motivo.Text = vestuarioDB.Item("note")(listbox.SelectedIndex - 1)
                Dim selected As Boolean = False
                For i = 0 To tipo.Items.Count - 1
                    If (tipo.Items(i).ToString().Equals(vestuarioDB.Item("clothes")(listbox.SelectedIndex - 1))) Then
                        tipo.SelectedIndex = i
                        selected = True
                    End If
                Next i
                If Not selected Then
                    outro.Text = vestuarioDB.Item("clothes")(listbox.SelectedIndex - 1)
                End If

            End If
        Else
            tipo.Enabled = False
            motivo.Enabled = False
            saveBtn.Enabled = False
            deliveredDate.Enabled = False
            deliveredDate.Value = DateTime.Now
            requestedDate.Value = DateTime.Now
            outro.Enabled = False
            requestedDate_lbl.Enabled = False
            delivered_lbl.Enabled = False
            tipo_lbl.Enabled = False
            outro_lbl.Enabled = False
            annotations_lbl.Enabled = False
            deliveredDate_lbl.Enabled = False

        End If
    End Sub
End Class