Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Threading

Public Class site_materials_reception_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private query_site, db_sections, closuresDB As Dictionary(Of String, List(Of String))
    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False

    Private qtdSectionsIndex As Integer()

    Public response As String = ""

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

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
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
        materialsList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor
        searchTitle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        annotations_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        motivo.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mandatoryFields.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        material.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        material_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        materialPreSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        dia_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        start_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        end_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        custom_end.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        custom_start.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        section_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_section.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        remove.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        searchTitle.Text = translations.getText("SearchBoxTitle")
        closeBtn.Text = translations.getText("closeBtn")
        annotations_lbl.Text = translations.getText("AnnotationTitle")
        mandatoryFields.Text = translations.getText("mandatoryFields")
        section_lbl.Text = translations.getText("dropdownSectionTitle")
        start_lbl.Text = translations.getText("dateStartTitle")
        end_lbl.Text = translations.getText("dateEndTitle")
        dia_lbl.Text = translations.getText("dateTitle")

        translations.load("siteMaterialsReception")
        title.Text = translations.getText("title")
        material_lbl.Text = translations.getText("materials")
        qtd_lbl.Text = translations.getText("quantity")
        units_lbl.Text = translations.getText("units")

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
        custom_end.CustomFormat = "HH:mm"
        custom_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        custom_end.ShowUpDown = True
        custom_start.CustomFormat = "HH:mm"
        custom_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        custom_start.ShowUpDown = True
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
        vars.Add("request", "sites,sections")
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
        db_sections = request.ConvertDataToArray("sections", state.querySiteSectionFields, response)
        If IsNothing(db_sections) Then
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
        ReDim qtdSectionsIndex((db_sections.Item("cod_section").Count))
        translations.load("commonForm")
        listview_works.Items.Clear()
        listview_works.Items.Add(translations.getText("dropdownSelectSite"))
        translations.load("siteMaterialsReception")
        materialsList.Items.Add(translations.getText("addRecord"))
        For i = 0 To query_site.Item("name").Count - 1
            listview_works.Items.Add(query_site.Item("name")(i))
        Next
        listview_works.SelectedIndex = 0
        materialsList.Items.Clear()

        clearFields()

        motivo.Enabled = False
        save.Enabled = False
        remove.Enabled = False

        duracaoInicio.Enabled = False

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        removeMask()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DropClickSearchBox(PictureBox1)
        doSearch(If(listview_works.SelectedIndex <= 0, 1, listview_works.SelectedIndex + 1), True)
    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If Not query_site.Item("cod_site").Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To query_site.Item("cod_site").Count - 1
                If Not query_site.Item("name")(i).ToLower.IndexOf(searchbox.Text.ToLower) = -1 Then
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
        qtd_section.Items.Clear()
        If listview_works.SelectedIndex > 0 Then
            If db_sections.Item("cod_section").Count > 0 Then
                Dim idx As Integer = 0
                For i = 0 To db_sections.Item("cod_section").Count - 1
                    If db_sections.Item("cod_site")(i).Equals(query_site.Item("cod_site")(listview_works.SelectedIndex - 1)) Then
                        qtd_section.Items.Add(db_sections.Item("description")(i))
                        qtdSectionsIndex(idx) = i
                        idx = idx + 1
                    End If
                Next
            End If
            If qtd_section.Items.Count > 0 Then
                qtd_section.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub



    Private Sub materialPreSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles materialPreSelection.SelectedIndexChanged
        If Not IsNothing(materialPreSelection.SelectedItem) Then
            material.Text = materialPreSelection.SelectedItem.ToString
        End If
    End Sub

    Private Sub qtd_section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles qtd_section.SelectedIndexChanged
        If (listview_works.SelectedItems.Count > 0) Then
            materialsList.Enabled = True
            If Not IsNothing(MainMdiForm.busy) Then
                MainMdiForm.busy = New BusyThread
            End If
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
            listview_works.Enabled = False
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                materialsList.Items.Clear()

                clearFields()

                motivo.Enabled = False
                save.Enabled = False
                remove.Enabled = False
                materialsList.Enabled = False
                duracaoInicio.Enabled = False

            Else 'edit record
                'select cod_materials_reception, cod_site, cod_section, data, start, end, qtd, units, material, notes from site_materials_reception

                loadRecords()
                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
            End If
            listview_works.Enabled = True
        Else
            materialsList.Enabled = False
        End If
    End Sub

    Private Sub loadRecords()
        materialsList.Items.Clear()
        translations.load("siteMaterialsReception")
        materialsList.Items.Add(translations.getText("addRecord"))

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "sitematreception")
        vars.Add("site", query_site.Item("cod_site")(listview_works.SelectedIndices(0) - 1))
        vars.Add("section", db_sections.Item("cod_section")(qtdSectionsIndex(qtd_section.SelectedIndex)))

        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        closuresDB = request.ConvertDataToArray("sitematreception", state.querySiteMaterialsReceptionFields, response)
        If IsNothing(closuresDB) Then
            MainMdiForm.statusMessage = GetMessage(request.errorMessage)
            Exit Sub
        End If

        For i = 0 To closuresDB.Item("cod_materials_reception").Count - 1
            materialsList.Items.Add(closuresDB.Item("material")(i) & ", dia " & closuresDB.Item("data")(i) & " [" & closuresDB.Item("start")(i) & " às " & closuresDB.Item("end")(i) & "]")
        Next i
    End Sub

    Private Sub ausenciaslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles materialsList.SelectedIndexChanged
        If (materialsList.SelectedItems.Count > 0) Then

            save.Enabled = True
            duracaoInicio.Enabled = True
            custom_start.Enabled = True
            custom_end.Enabled = True
            motivo.Enabled = True
            material.Enabled = True
            qtd.Enabled = True
            units.Enabled = True
            materialPreSelection.Enabled = True

            duracaoInicio.Value = DateTime.Now

            If materialsList.SelectedIndices(0) = 0 Then 'new worker

                clearFields()
                remove.Enabled = False

            Else ' edit ausencia
                remove.Enabled = True
                duracaoInicio.Value = DateTime.Now

                If IsDate(closuresDB.Item("data")(materialsList.SelectedIndex - 1)) Then
                    duracaoInicio.Value = closuresDB.Item("data")(materialsList.SelectedIndex - 1)
                Else
                    duracaoInicio.Value = DateTime.Now
                End If

                custom_start.Text = closuresDB.Item("start")(materialsList.SelectedIndex - 1)
                custom_end.Text = closuresDB.Item("end")(materialsList.SelectedIndex - 1)
                qtd.Text = closuresDB.Item("qtd")(materialsList.SelectedIndex - 1)
                material.Text = closuresDB.Item("material")(materialsList.SelectedIndex - 1)
                motivo.Text = closuresDB.Item("notas")(materialsList.SelectedIndex - 1)
                For i = 0 To units.Items.Count - 1
                    If closuresDB.Item("units")(materialsList.SelectedIndex - 1).ToUpper.Equals(units.Items(i).ToString) Then
                        units.SelectedIndex = i
                        Exit For
                    End If
                Next i
            End If
        Else
            remove.Enabled = False
            save.Enabled = False
            duracaoInicio.Enabled = False
            custom_start.Enabled = False
            custom_end.Enabled = False
            motivo.Enabled = False
            material.Enabled = False
            qtd.Enabled = False
            units.Enabled = False
            materialPreSelection.Enabled = False
        End If
    End Sub

    Private Sub clearFields()
        duracaoInicio.Value = DateTime.Now
        motivo.Text = ""
        custom_end.Text = ""
        custom_start.Text = ""
        qtd.Text = ""
        material.Text = ""
        units.SelectedIndex = -1
        materialPreSelection.SelectedIndex = -1
        custom_end.Value = DateTime.Now.Date.ToString("yyyy-MM-dd") & " 10:00:00"
        custom_start.Value = DateTime.Now.Date.ToString("yyyy-MM-dd") & " 09:00:00"
    End Sub


    Private Sub del_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles remove.LinkClicked
        translations.load("messagebox")
        msgbox = New message_box_frm(translations.getText("questionRemoveRecord") & "? ", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        Dim response As String
        If (msgbox.ShowDialog = DialogResult.OK) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "12")
            vars.Add("type", "del")
            vars.Add("cod", closuresDB.Item("cod_materials_reception")(materialsList.SelectedIndex - 1))
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
                msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()

                clearFields()
                loadRecords()

                If Not IsNothing(MainMdiForm.busy) Then
                    If MainMdiForm.busy.isActive().Equals(True) Then
                        MainMdiForm.busy.Close(True)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub save_ausencia_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        If (materialsList.SelectedItems.Count = 0) Then ' edit ausencia
            translations.load("siteMaterialsReception")
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

        Dim selected As String = query_site.Item("cod_site")(listview_works.SelectedIndex - 1)
        ' Parse hour:minute value with "g" specifier current culture.'

        If TimeSpan.Compare(custom_start.Value.TimeOfDay, custom_end.Value.TimeOfDay) >= 1 Then
            translations.load("siteMaterialsReception")
            Dim message3 As String = translations.getText("endHourError")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If (qtd.Text.Equals("")) Then
            qtd.Focus()
            translations.load("siteMaterialsReception")
            Dim message3 As String = translations.getText("errorQuantity")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        If (material.Text.Equals("")) Then
            material.Focus()
            translations.load("siteMaterialsReception")
            Dim message3 As String = translations.getText("errorMaterial")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "12")
        If (materialsList.SelectedIndex > 0) Then ' edit 
            vars.Add("type", "edit")
            vars.Add("cod", closuresDB.Item("cod_materials_reception")(materialsList.SelectedIndex - 1))
        Else ' add new
            vars.Add("type", "add")
            vars.Add("site", selected)
            If qtd_section.Text = "Todas" Then
                vars.Add("section", "all")
            Else
                vars.Add("section", db_sections.Item("cod_section")(qtdSectionsIndex(qtd_section.SelectedIndex)))
            End If
        End If

        vars.Add("date", duracaoInicio.Value.ToString("yyyy-MM-dd"))
        vars.Add("qtd", qtd.Text.ToString)
        vars.Add("material", material.Text.ToString)
        vars.Add("units", units.Text.ToString)
        vars.Add("notes", motivo.Text.ToString)
        vars.Add("start", custom_start.Value.TimeOfDay.ToString())
        vars.Add("end", custom_end.Value.TimeOfDay.ToString())

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
            msgbox = New message_box_frm(translations.getText("resultSuccessAddRecord") & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()

            clearFields()
            remove.Enabled = False
            save.Enabled = False
            duracaoInicio.Enabled = False
            custom_start.Enabled = False
            custom_end.Enabled = False
            motivo.Enabled = False
            material.Enabled = False
            qtd.Enabled = False
            units.Enabled = False
            materialPreSelection.Enabled = False

            loadRecords()

            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
        End If
    End Sub
End Class