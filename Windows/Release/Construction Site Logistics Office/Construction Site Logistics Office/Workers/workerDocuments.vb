Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Documents
Imports Newtonsoft.Json

Public Class documentos_frm
    Private state As State
    Private translations As languageTranslations
     


    Private relatorio_tipo As String
    Private works_worker, works_entreprise, works_category, works_site As Dictionary(Of String, List(Of String))

    Private mask As PictureBox = Nothing
    Private loaded As Boolean = False
    Private WithEvents bwSites As BackgroundWorker
    Private msgbox As message_box_frm

    Private s(50) As String

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()

    End Sub


    Private Sub documentos_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        MainMdiForm.childForm = "document"
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

        listview_works.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        updateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        doc_type.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        searchTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        documentTitle.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics
        sizeOfString = g.MeasureString(updateLink.Text, fontToMeasure)

        listview_works.Height = Me.Height - 10 - sizeOfString.Height - listview_works.Location.Y
        Panel1.Height = Me.Height - 10 - sizeOfString.Height - Panel1.Location.Y
        Panel1.Width = Me.Width - Panel1.Location.X - 10

        richtxt.Height = Panel1.Height - 10
        richtxt.Width = Panel1.Width - 10
        ToolStrip1.Width = Panel1.Width - 10
        updateLink.Location = New Point(listview_works.Location.X + listview_works.Width - sizeOfString.Width, listview_works.Location.Y + listview_works.Height)
        translations.load("commonForm")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        doc_type.Items.Clear()
        translations.load("workers")
        doc_type.Items.Add(translations.getText("selectDocumentType"))
        doc_type.Items.Add(translations.getText("contract"))
        doc_type.Items.Add(translations.getText("foreignWorkAccord"))
        doc_type.Items.Add(translations.getText("actCommunication"))
        doc_type.Items.Add(translations.getText("inscriptionDocument"))
        documentTitle.Text = translations.getText("documentTitle")
        Me.ResumeLayout()
    End Sub

    Private Sub documentos_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
        Try
            FileSystem.Kill(String.Format("{0}", Environment.CurrentDirectory & "\tmp\*.*"))
        Catch

        End Try

        listview_works.Enabled = False
        searchbox.Enabled = False
        SearchIconBtn.Enabled = False
        doc_type.SelectedIndex = 0

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

    Private Sub CloseMe()
        Me.Close()
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

        vars.Add("task", "6")
        vars.Add("request", "workers,categories,entreprises,sites")
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
        works_entreprise = request.ConvertDataToArray("entreprises", state.querySiteSectionFields, response)
        If IsNothing(works_entreprise) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_category = request.ConvertDataToArray("categories", state.queryWorkerCategoryFields, response)
        If IsNothing(works_category) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
        If IsNothing(works_worker) Then
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
        listview_works.Items.Clear()
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            listview_works.Items.Add(works_worker.Item("name")(i))
        Next i


        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
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
    Private Sub listview_works_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged

        If listview_works.SelectedIndex > -1 Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "26")
            vars.Add("type", relatorio_tipo)
            Dim request As New HttpData(state)
            Dim filename As String = request.GetHttpFile(vars)
            If Not IsResponseOk(filename) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(filename) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                Exit Sub
            Else
                Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(filename)
                filename = data.Item("file")
            End If

            Dim checkFile = New FileInfo(filename)
            checkFile.Refresh()
            If checkFile.Exists And Not FileInUse(filename) Then

                Dim estadoCivilList As New List(Of String)
                translations.load("workers")
                estadoCivilList.Clear()
                estadoCivilList.Add(translations.getText("single"))
                estadoCivilList.Add(translations.getText("married"))
                estadoCivilList.Add(translations.getText("divorced"))
                estadoCivilList.Add(translations.getText("widow"))

                richtxt.LoadFile(filename, RichTextBoxStreamType.RichText)
                richtxt.Rtf = richtxt.Rtf.Replace("[nome]", works_worker.Item("name")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[estadocivil]", estadoCivilList.ElementAt(works_worker.Item("estado_civil")(listview_works.SelectedIndex)))
                richtxt.Rtf = richtxt.Rtf.Replace("[morada]", works_worker.Item("morada")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[cc]", works_worker.Item("cc")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[ccvalid]", works_worker.Item("cc_validade")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[nif]", works_worker.Item("nif")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[niss]", works_worker.Item("niss")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[datanascimento]", works_worker.Item("data_nascimento")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[catpro]", works_worker.Item("classificacao")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[salario]", works_worker.Item("salario")(listview_works.SelectedIndex) & "€")
                richtxt.Rtf = richtxt.Rtf.Replace("[refeicao]", works_worker.Item("refeicao")(listview_works.SelectedIndex) & "€")
                richtxt.Rtf = richtxt.Rtf.Replace("[idade]", works_worker.Item("idade")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[nacionalidade]", works_worker.Item("nacionalidade")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[filhos]", works_worker.Item("filhos")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[filhosenc]", works_worker.Item("filhos_encargo")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[mobile]", works_worker.Item("contact")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[mobile112]", works_worker.Item("contact112")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[email]", works_worker.Item("email")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[datainicio]", works_worker.Item("data_inicio_trabalho")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[class]", works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item("cod_category")(listview_works.SelectedIndex), "cod_category")))
                richtxt.Rtf = richtxt.Rtf.Replace("[acusto]", works_worker.Item("ajudascusto")(listview_works.SelectedIndex) & "€")
                richtxt.Rtf = richtxt.Rtf.Replace("[nib]", works_worker.Item("nib")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[saude]", works_worker.Item("prob_saude")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[peso]", works_worker.Item("peso")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[altura]", works_worker.Item("altura")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[calcas]", works_worker.Item("calcas")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[pe]", works_worker.Item("pe")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[casaco]", works_worker.Item("casaco")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[dia]", DateAndTime.Day(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))
                richtxt.Rtf = richtxt.Rtf.Replace("[mes]", DateTime.Now.ToString("MMMM", New CultureInfo("pt")))
                richtxt.Rtf = richtxt.Rtf.Replace("[ano]", DateAndTime.Year(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))
                richtxt.Rtf = richtxt.Rtf.Replace("[destacamentoinicio]", works_worker.Item("destacamento_inicio")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[destacamentofim]", works_worker.Item("destacamento_fim")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[naturalidade]", works_worker.Item("naturalidade")(listview_works.SelectedIndex))
                richtxt.Rtf = richtxt.Rtf.Replace("[concelho]", works_worker.Item("concelho")(listview_works.SelectedIndex))
            Else
                MainMdiForm.statusMessage = "File is in use by another application"
            End If
        End If
    End Sub


    ' Update buttons when text is selected
    Private Sub richtxt_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles richtxt.SelectionChanged
        ' see which buttons should be checked or unchecked
        Try
            BoldToolStripButton.Checked = richtxt.SelectionFont.Bold
            UnderlineToolStripButton.Checked = richtxt.SelectionFont.Underline
            LeftToolStripButton.Checked = IIf(richtxt.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left, True, False)
            CenterToolStripButton.Checked = IIf(richtxt.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center, True, False)
            RightToolStripButton.Checked = IIf(richtxt.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right, True, False)
            BulletsToolStripButton.Checked = richtxt.SelectionBullet
        Catch ex As Exception
            saveCrash(ex)
            MainMdiForm.statusMessage = "Unable to do text formating"
        End Try


        'cmbFontName.Text = richtxt.SelectionFont.Name
        'cmbFontSize.Text = richtxt.SelectionFont.SizeInPoints

    End Sub

    Private Sub checkBullets()
        If richtxt.SelectionBullet = True Then
            BulletsToolStripButton.Checked = True
        Else
            BulletsToolStripButton.Checked = False
        End If
    End Sub

    Private Sub FontToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripButton.Click
        If FontDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            richtxt.SelectionFont = FontDlg.Font
        End If
    End Sub

    Private Sub FontColorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripButton.Click
        If ColorDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            richtxt.SelectionColor = ColorDlg.Color
        End If
    End Sub

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripButton.Click
        ' Switch Bold
        Dim currentFont As System.Drawing.Font = richtxt.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        Try
            If richtxt.SelectionFont.Bold = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
            End If
            richtxt.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

            ' Check/Uncheck Bold button
            BoldToolStripButton.Checked = IIf(richtxt.SelectionFont.Bold, True, False)
        Catch ex As Exception
            saveCrash(ex)
            MainMdiForm.statusMessage = "Unable to do text formating"
        End Try

    End Sub

    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripButton.Click
        ' Switch Underline
        Dim currentFont As System.Drawing.Font = richtxt.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        Try
            If richtxt.SelectionFont.Underline = True Then
                newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
            Else
                newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
            End If
            richtxt.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

            ' Check/Uncheck Underline button
            UnderlineToolStripButton.Checked = IIf(richtxt.SelectionFont.Underline, True, False)
        Catch ex As Exception
            saveCrash(ex)
            MainMdiForm.statusMessage = "Unable to do text formating"
        End Try

    End Sub

    Private Sub LeftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripButton.Click
        richtxt.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles SearchIconBtn.Click
        DropClickSearchBox(SearchIconBtn)

        If searchbox.Text.Equals("") Then
            translations.load("infoMessages")
            Dim message As String = translations.getText("searchEmptyQuery")
            translations.load("messagebox")
            msgbox = New message_box_frm(message & ".", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            doSearchWorkers(If(listview_works.SelectedIndex < 0, 0, listview_works.SelectedIndex), True, False, works_worker, listview_works, searchbox.Text)
        End If
    End Sub


    Private Sub doc_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles doc_type.SelectedIndexChanged
        If doc_type.SelectedIndex > 0 Then
            listview_works.Enabled = True
            searchbox.Enabled = True
            SearchIconBtn.Enabled = True
            translations.load("workers")
            If doc_type.SelectedItem.ToString.Equals(translations.getText("contract")) Then
                relatorio_tipo = "contrato"
            ElseIf doc_type.SelectedItem.ToString.Equals(translations.getText("foreignWorkAccord")) Then
                relatorio_tipo = "destacamento"
            ElseIf doc_type.SelectedItem.ToString.Equals(translations.getText("actCommunication")) Then
                relatorio_tipo = "act"
            ElseIf doc_type.SelectedItem.ToString.Equals(translations.getText("inscriptionDocument")) Then
                relatorio_tipo = "ficha"
            End If
        Else
            listview_works.Enabled = False
            searchbox.Enabled = False
            SearchIconBtn.Enabled = False
        End If
    End Sub

    Private Sub CenterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripButton.Click
        richtxt.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripButton.Click
        richtxt.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BulletsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BulletsToolStripButton.Click
        richtxt.SelectionBullet = Not richtxt.SelectionBullet
        BulletsToolStripButton.Checked = richtxt.SelectionBullet
    End Sub

End Class