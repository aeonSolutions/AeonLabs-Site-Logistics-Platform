Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Threading

Public Class workers_absense_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private works_worker, ausenciasDB As Dictionary(Of String, List(Of String))

    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private response As String = ""

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub workers_absense_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        Me.SuspendLayout()
         
         

        title.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        updateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        remove.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ausenciaslist.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor
        seachTitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        motif_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        trip_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        annotations_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        start_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        end_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        tipo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        viagem.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        motivo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        remove.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        seachTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        start_lbl.Text = translations.getText("dateStartTitle")
        end_lbl.Text = translations.getText("dateEndTitle")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        translations.load("workerAbsenses")
        motif_lbl.Text = translations.getText("motif")
        trip_lbl.Text = translations.getText("trip")
        title.Text = translations.getText("title")

        updateLink.Location = New Point(listview_works.Location.X + listview_works.Width - updateLink.Width, updateLink.Location.Y)
        save.Location = New Point(motivo.Location.X + motivo.Width - save.Width, save.Location.Y)
        remove.Location = New Point(save.Location.X - remove.Width - 5, remove.Location.Y)

        ResumeLayout()
        loaded = False
    End Sub
    Private Sub workers_absense_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.SuspendLayout()

        duracaoInicio.CustomFormat = "yyyy-MM-dd"
        duracaoFim.CustomFormat = "yyyy-MM-dd"
        Me.ResumeLayout()

    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()

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
        vars.Add("request", "workers")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
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
        translations.load("commonForm")
        listview_works.Items.Add(translations.getText("selectWorker"))
        translations.load("workerAbsenses")
        ausenciaslist.Items.Add(translations.getText("addAbsense"))

        For i = 1 To works_worker.Item("cod_worker").Count - 1
            If (Not works_worker.Item("activo")(i).Equals("0")) Then
                listview_works.Items.Add(works_worker.Item("name")(i))
            End If
        Next i

        ausenciaslist.Items.Clear()
        tipo.SelectedIndex = -1
        viagem.SelectedIndex = -1

        motivo.Text = ""
        tipo.Enabled = False
        viagem.Enabled = False
        motivo.Enabled = False
        save.Enabled = False
        remove.Enabled = False
        duracaoFim.Enabled = False
        duracaoInicio.Enabled = False
        duracaoFim.Value = DateTime.Now
        duracaoInicio.Value = DateTime.Now

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
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

    Private Sub del_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles remove.LinkClicked
        translations.load("messagebox")
        msgbox = New message_box_frm(translations.getText("questionRemoveRecord") & "? ", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.OK) Then

            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "10")
            vars.Add("type", "del")
            vars.Add("cod", ausenciasDB.Item("cod_ausencia")(ausenciaslist.SelectedIndex - 1))
            Dim request As New HttpData(state)
            Dim response As String = request.RequestData(vars)

            If Not IsResponseOk(response) Then
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                translations.load("messagebox")
                msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord") & ". ", translations.getText("information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now
                motivo.Text = ""
                tipo.SelectedIndex = 0
                viagem.SelectedIndex = 0

                loadAbsenses()

                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub save_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        If (ausenciaslist.SelectedItems.Count = 0) Then ' edit ausencia
            translations.load("workerAbsenses")
            Dim message3 As String = translations.getText("errorAbsenceRequired")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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

        Dim selected As String = works_worker.Item("cod_worker")(listview_works.SelectedIndex - 1)

        Dim startD As Date, endD As Date

        startD = duracaoInicio.Value
        endD = duracaoFim.Value

        If DateTime.Compare(startD, endD) > 0 And Not duracaoInicio.Value.ToString("yyyy-MM-dd").Equals(duracaoFim.Value.ToString("yyyy-MM-dd")) Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorDateInterval")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If


        If (motivo.Text = "") Then
            motivo.Text = "null"
        End If
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "10")
        If (ausenciaslist.SelectedIndex > 0) Then ' edit ausencia
            vars.Add("type", "edit")
            vars.Add("cod", ausenciasDB.Item("cod_ausencia")(ausenciaslist.SelectedIndex - 1))
        Else ' add new
            vars.Add("type", "add")
            vars.Add("worker", selected)
        End If
        vars.Add("inicio", duracaoInicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("fim", duracaoFim.Value.ToString("yyyy-MM-dd"))
        vars.Add("tipo", tipo.SelectedItem.ToString)
        vars.Add("viagem", viagem.SelectedItem.ToString)
        vars.Add("motivo", motivo.Text)

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
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultSuccessAddRecord") & ". ", translations.getText("information"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            duracaoFim.Value = DateTime.Now
            duracaoInicio.Value = DateTime.Now
            motivo.Text = ""
            tipo.SelectedIndex = 0
            viagem.SelectedIndex = 0

            loadAbsenses()

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DropClickSearchBox(PictureBox1)
        doSearch(If(listview_works.SelectedIndex <= 0, 1, listview_works.SelectedIndex + 1), True)
    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If Not works_worker.Item("cod_worker").Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To works_worker.Item("cod_worker").Count - 1
                If Not works_worker.Item("name")(i).ToLower.IndexOf(searchbox.Text.ToLower) = -1 Then
                    listview_works.SelectedIndex = i
                    found = True
                    Exit For
                End If
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound") & ". " & translations.getText("searchAgainQuestion")
                translations.load("messagebox")
                msgbox = New message_box_frm(message3 & ". ", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearch(0, False)
                End If
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles updateLink.LinkClicked
        load_list()

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
        If (listview_works.SelectedItems.Count > 0) Then
            ausenciaslist.Enabled = True
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(False) Then
                    MainMdiForm.busy = New BusyThread
                    MainMdiForm.busy.Show()
                End If
            End If
            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                ausenciaslist.Items.Clear()
                tipo.SelectedIndex = -1
                viagem.SelectedIndex = -1
                motivo.Text = ""
                tipo.Enabled = False
                viagem.Enabled = False
                motivo.Enabled = False
                save.Enabled = False
                remove.Enabled = False
                ausenciaslist.Enabled = False
                duracaoFim.Enabled = False
                duracaoInicio.Enabled = False
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now
            Else 'edit worker
                loadAbsenses()

                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
            End If
            listview_works.Enabled = True
        Else
            ausenciaslist.Enabled = False
        End If
    End Sub

    Private Sub loadAbsenses()
        ausenciaslist.Items.Clear()
        ausenciaslist.Items.Add(translations.getText("addAbsense"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "ausencias")
        vars.Add("cod", works_worker.Item("cod_worker")(listview_works.SelectedIndices(0)))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        ausenciasDB = request.ConvertDataToArray("ausencias", state.queryAbsenseFields, response)
        If IsNothing(ausenciasDB) Then
            MainMdiForm.statusMessage = GetMessage(request.errorMessage)
            Exit Sub
        End If

        For i = 0 To ausenciasDB.Item("cod_ausencia").Count - 1
            ausenciaslist.Items.Add(ausenciasDB.Item("viagem")(i) & " [" & ausenciasDB.Item("inicio")(i) & " a " & ausenciasDB.Item("fim")(i) & "]")
        Next i

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub



    Private Sub ausenciaslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ausenciaslist.SelectedIndexChanged
        If (ausenciaslist.SelectedItems.Count > 0) Then
            tipo.Enabled = True
            viagem.Enabled = True
            motivo.Enabled = True
            save.Enabled = True
            duracaoFim.Enabled = True
            duracaoInicio.Enabled = True
            duracaoFim.Value = DateTime.Now
            duracaoInicio.Value = DateTime.Now

            If ausenciaslist.SelectedIndices(0) = 0 Then 'new worker
                tipo.SelectedIndex = 0
                viagem.SelectedIndex = 0

                motivo.Text = ""
                remove.Enabled = False

            Else ' edit ausencia
                remove.Enabled = True
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now

                If IsDate(ausenciasDB.Item("inicio")(ausenciaslist.SelectedIndex - 1)) Then
                    duracaoInicio.Value = ausenciasDB.Item("inicio")(ausenciaslist.SelectedIndex - 1)
                Else
                    duracaoInicio.Value = DateTime.Now
                End If

                If IsDate(ausenciasDB.Item("fim")(ausenciaslist.SelectedIndex - 1)) Then
                    duracaoFim.Value = ausenciasDB.Item("fim")(ausenciaslist.SelectedIndex - 1)
                Else
                    duracaoFim.Value = DateTime.Now
                End If

                motivo.Text = ausenciasDB.Item("motivo")(ausenciaslist.SelectedIndex - 1)

                For i = 0 To tipo.Items.Count - 1
                    If (tipo.Items(i).ToString().Equals(ausenciasDB.Item("tipo")(ausenciaslist.SelectedIndex - 1))) Then
                        tipo.SelectedIndex = i
                    End If
                Next i

                For i = 0 To viagem.Items.Count - 1
                    If (viagem.Items(i).ToString().Equals(ausenciasDB.Item("viagem")(ausenciaslist.SelectedIndex - 1))) Then
                        viagem.SelectedIndex = i
                    End If
                Next i
            End If
        End If
    End Sub

End Class