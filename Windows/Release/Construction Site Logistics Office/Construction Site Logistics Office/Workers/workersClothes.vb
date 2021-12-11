Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class workersClothes_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations

    Private workersDB, vestuarioDB, sitesDB, sectionsDB As Dictionary(Of String, List(Of String))
    Private siteSelection As Integer(,)
    Private workersDbCod As String()
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private WithEvents bwWorkers As BackgroundWorker

    Public response As String = ""

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub workers_clothes_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()

        Me.SuspendLayout()
        requestedDate.CustomFormat = "yyyy-MM-dd"
        deliveredDate.CustomFormat = "yyyy-MM-dd"

        title.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        remove.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredClothesList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor
        searchTitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        annotations_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        tipo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        tipo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        outro_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        outro.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredDate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        requestedDate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        siteRecordDate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        deliveredDate_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        requestedDate_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        motivo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        requieredClothesList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        requested_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        delivered_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        site_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        combo_site.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        workerClothesSizes.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        remove.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        site_lbl.Text = translations.getText("dropdownSiteTitle")
        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(workersUpdateBtn, translations.getText("updateLink"))

        translations.load("workersClothes")
        title.Text = translations.getText("title")
        tipo_lbl.Text = translations.getText("typeOfClothes")
        outro_lbl.Text = translations.getText("otherClothes")
        deliveredDate_lbl.Text = translations.getText("deliveryDate")
        requestedDate_lbl.Text = translations.getText("requestedDate")
        requested_lbl.Text = translations.getText("requestedClothes")
        delivered_lbl.Text = translations.getText("deliveredClothes")
        workerClothesSizes.Text = ""
        save.Location = New Point(motivo.Location.X + motivo.Width - save.Width, save.Location.Y)
        remove.Location = New Point(save.Location.X - remove.Width - 5, remove.Location.Y)

        siteRecordDate.Value = Now()

        ResumeLayout()
        loaded = False
    End Sub

    Private Sub workers_clothes_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        loaded = False
        vars.Add("task", "6")
        vars.Add("request", "sites,sections")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        sitesDB = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(sitesDB) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        sectionsDB = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(sectionsDB) Then
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

        siteSelection = loadSitesWithSections(combo_site, sitesDB, sectionsDB)

        listview_works.Items.Clear()
        deliveredClothesList.Items.Clear()
        requieredClothesList.Items.Clear()
        tipo.SelectedIndex = -1

        motivo.Text = ""
        tipo.Enabled = False
        motivo.Enabled = False
        save.Enabled = False
        remove.Enabled = False
        deliveredDate.Enabled = False
        deliveredDate.Value = DateTime.Now
        requestedDate.Value = DateTime.Now

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
        loaded = True
    End Sub

    Private Sub del_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles remove.LinkClicked
        translations.load("messagebox")
        msgbox = New message_box_frm(translations.getText("questionRemoveRecord") & "? ", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.OK) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "11")
            vars.Add("type", "del")
            vars.Add("cod", vestuarioDB.Item("cod_ausencia")(deliveredClothesList.SelectedIndex - 1))
            Dim request As New HttpData(state)
            Dim response As String = request.RequestData(vars)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                translations.load("messagebox")
                msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord") & ". ", translations.getText("information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                deliveredDate.Value = DateTime.Now
                motivo.Text = ""
                tipo.SelectedIndex = 0

                loadClothes()

                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub save_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        If (deliveredClothesList.SelectedItems.Count = 0) Then ' edit ausencia
            msgbox = New message_box_frm("Tem que seleccionar um registo de vestuario ou escolher 'adicionar vestuario' na lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If listview_works.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If tipo.SelectedIndex < 0 Then
            translations.load("workersClothes")
            Dim message3 As String = translations.getText("errorSelectClothes")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            tipo.Focus()
            Exit Sub
        End If
        If tipo.SelectedItem.ToString.Equals("Outro") And outro.Text.ToString.Equals("") Or tipo.SelectedIndex < 0 Then
            translations.load("workersClothes")
            Dim message3 As String = translations.getText("errorTypeClothes")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            outro.Focus()
            Exit Sub
        End If
        Dim response As String
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
        vars.Add("task", "11")
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

        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultSuccessAddRecord") & ". ", translations.getText("information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            deliveredDate.Value = DateTime.Now
            motivo.Text = ""
            tipo.SelectedIndex = 0
            outro.Text = ""

            loadClothes()

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
        End If
    End Sub

    Private Sub loadClothes()
        requieredClothesList.Items.Clear()
        deliveredClothesList.Items.Clear()
        translations.load("workersClothes")
        deliveredClothesList.Items.Add(translations.getText("addClothes"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "clothes")
        vars.Add("cod", workersDbCod(listview_works.SelectedIndices(0)))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        vestuarioDB = request.ConvertDataToArray("clothes", state.querySiteClothesFields, response)
        If Not IsNothing(vestuarioDB) Then
            For i = 0 To vestuarioDB.Item("cod_clothes").Count - 1
                If vestuarioDB.Item("delivered")(i).Equals("1") Then
                    deliveredClothesList.Items.Add(vestuarioDB.Item("note")(i) & " [" & vestuarioDB.Item("data")(i) & " a " & vestuarioDB.Item("clothes")(i) & "]")
                Else
                    requieredClothesList.Items.Add(vestuarioDB.Item("note")(i) & " [" & vestuarioDB.Item("data")(i) & " a " & vestuarioDB.Item("clothes")(i) & "]")
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
            photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("worker.png"))
        Else
            photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & Convert.ToString("loading.png"))
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & workersDB.Item("photo")(listview_works.SelectedIndices(0) - 1).ToString)))
                photobox.Image = tImage
            Catch ex As Exception
                photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
                translations.load("errorMessages")
                MainMdiForm.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        DropClickSearchBox(searchBoxBtn)
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


        bwWorkers = New BackgroundWorker()
        bwWorkers.WorkerSupportsCancellation = True
        bwWorkers.RunWorkerAsync()
    End Sub

    Private Sub bwWorkers_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwWorkers.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim qsite As String = ""
        Dim qsection As String = ""
        Dim sdate, edate As String
        combo_site.Invoke(Sub()
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
                          End Sub)

        sdate = siteRecordDate.Value.ToString("yyyy-MM") & "-01"
        edate = siteRecordDate.Value.ToString("yyyy-MM") & "-" & System.DateTime.DaysInMonth(DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"))

        vars = New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "workersonsite")
        vars.Add("options", "clothesizes")
        vars.Add("site", qsite)
        vars.Add("section", qsection)
        vars.Add("sdate", sdate)
        vars.Add("edate", edate)

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If

        workersDB = request.ConvertDataToArray("workersonsite", state.queryWorkersOnSiteFields.Union(state.queryWorkerOptionsClothes).ToArray(), response)
        If IsNothing(workersDB) Then
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

    Private Sub bwWorkers_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwWorkers.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
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
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
    End Sub

    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            deliveredClothesList.Enabled = True
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(False) Then
                    MainMdiForm.busy = New BusyThread
                    MainMdiForm.busy.Show()
                End If
            End If
            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'select worker
                deliveredClothesList.Items.Clear()
                tipo.SelectedIndex = -1
                motivo.Text = ""
                tipo.Enabled = False
                motivo.Enabled = False
                save.Enabled = False
                remove.Enabled = False
                deliveredClothesList.Enabled = False
                deliveredDate.Enabled = False
                outro.Enabled = False
                deliveredDate.Value = DateTime.Now
                workerClothesSizes.Text = ""
                photobox.Image = Image.FromFile(MainMdiForm.state.imagesPath & "worker.png")
                photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Else 'edit worker
                loadClothes()
            End If
            listview_works.Enabled = True
        Else
            deliveredClothesList.Enabled = False

        End If
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
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
            save.Enabled = True
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
                remove.Enabled = False
            Else ' edit ausencia
                remove.Enabled = True
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
            save.Enabled = False
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