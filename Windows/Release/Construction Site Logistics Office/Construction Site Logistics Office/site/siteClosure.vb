Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Threading

Public Class site_closure_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private works_site, closuresDB As Dictionary(Of String, List(Of String))
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False

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
        searchTitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        annotations_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        start_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        end_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        motif.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        remove.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        start_lbl.Text = translations.getText("dateStartTitle")
        end_lbl.Text = translations.getText("dateEndTitle")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        translations.load("siteDaysClosed")
        title.Text = translations.getText("title")

        updateLink.Location = New Point(listview_works.Location.X + listview_works.Width - updateLink.Width, updateLink.Location.Y)
        save.Location = New Point(motif.Location.X + motif.Width - save.Width, save.Location.Y)
        remove.Location = New Point(save.Location.X - remove.Width - 5, remove.Location.Y)

        ResumeLayout()
        loaded = False
    End Sub
    Private Sub workers_absense_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
        load_list()
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
        vars.Add("request", "sites")
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
        listview_works.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_site.Item("name").Count - 1
            listview_works.Items.Add(works_site.Item("name")(i))
        Next
        listview_works.SelectedIndex = 0
        ausenciaslist.Items.Clear()

        motif.Text = ""
        motif.Enabled = False
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
        msgbox.ShowDialog()
        Dim response As String
        If (msgbox.ShowDialog = DialogResult.OK) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "3")
            vars.Add("type", "del")
            vars.Add("cod", closuresDB.Item("cod_closure")(ausenciaslist.SelectedIndex - 1))
            Dim request As New HttpData(state)
            response = request.RequestData(vars)

            If Not IsResponseOk(response) Then
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
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
                motif.Text = ""

                loadDateEntries()

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
            translations.load("siteDaysClosed")
            Dim message3 As String = translations.getText("errorRecordRequired")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If listview_works.SelectedIndex < 1 Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim selected As String = works_site.Item("cod_site")(listview_works.SelectedIndex)

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


        If (motif.Text = "") Then
            motif.Text = "null"
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "3")
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
            motif.Text = ""

            loadDateEntries()

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(False) Then
                    MainMdiForm.busy = New BusyThread
                    MainMdiForm.busy.Show()
                End If
            End If
            motif.Enabled = False
            save.Enabled = False
            duracaoFim.Enabled = False
            duracaoInicio.Enabled = False
            remove.Enabled = False
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DropClickSearchBox(PictureBox1)
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
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(False) Then
                    MainMdiForm.busy = New BusyThread
                    MainMdiForm.busy.Show()
                End If
            End If
            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                ausenciaslist.Items.Clear()

                motif.Text = ""

                motif.Enabled = False
                save.Enabled = False
                remove.Enabled = False
                ausenciaslist.Enabled = False
                duracaoFim.Enabled = False
                duracaoInicio.Enabled = False
                duracaoFim.Value = DateTime.Now
                duracaoInicio.Value = DateTime.Now
            Else 'edit worker
                loadDateEntries()

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

    Private Sub loadDateEntries()
        ausenciaslist.Items.Clear()
        translations.load("siteDaysClosed")
        ausenciaslist.Items.Add(translations.getText("addRecord"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "siteclosure")
        vars.Add("cod", works_site.Item("cod_site")(listview_works.SelectedIndices(0) - 1))
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        closuresDB = request.ConvertDataToArray("siteclosure", state.querySiteClosureFields, response)
        If IsNothing(closuresDB) Then
            MainMdiForm.statusMessage = GetMessage(request.errorMessage)
            Exit Sub
        End If

        For i = 0 To closuresDB.Item("cod_closure").Count - 1
            ausenciaslist.Items.Add(closuresDB.Item("motivo")(i) & " [" & closuresDB.Item("start")(i) & " a " & closuresDB.Item("end")(i) & "]")
        Next i
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ausenciaslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ausenciaslist.SelectedIndexChanged
        If (ausenciaslist.SelectedItems.Count > 0) Then

            motif.Enabled = True
            save.Enabled = True
            duracaoFim.Enabled = True
            duracaoInicio.Enabled = True


            duracaoFim.Value = DateTime.Now
            duracaoInicio.Value = DateTime.Now

            If ausenciaslist.SelectedIndices(0) = 0 Then 'new worker
                motif.Text = ""
                remove.Enabled = False
            Else ' edit ausencia
                remove.Enabled = True
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