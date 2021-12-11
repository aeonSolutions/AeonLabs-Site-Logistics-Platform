Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class siteProductionEditTasks_frm
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
    Private mask As PictureBox = Nothing
    Private countryList As New Dictionary(Of String, String)

    Private response As String
    Private WithEvents bwTranslate As BackgroundWorker
    Private WithEvents bwLoadBordereau As BackgroundWorker
    Private DbBordereau As Dictionary(Of String, List(Of String))
    Private shortcountryListProject As New List(Of String)
    Private shortCountryListTask As New List(Of String)
    Private taskTranslations As New Dictionary(Of String, String)
    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub SiteLivraisonEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        divider.BackColor = state.dividerColor
        closeBtn.Font = New Font(state.fontTitle.Families(0), state.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor

        GroupBoxTask.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        groupBoxTasksList.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)

        tasksList.Font = New Font(state.fontTitle.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        TaskType.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        description.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        languagesList.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        translationText.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitsTxt.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        price.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        reference.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        mandatory.Font = New Font(state.fontTitle.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        translate.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        del.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        taskType_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        description_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        translatedLanguages_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_all_lang.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        translationText_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        price_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        reference_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        numTranslations.Font = New Font(state.fontTitle.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        translate.Text = translations.getText("translateLink")
        del.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        mandatory.Text = translations.getText("mandatoryFields")
        closeBtn.Text = translations.getText("closeBtn")

        translations.load("siteActivity")
        show_all_lang.Text = translations.getText("tasksShowProjectLanguages")
        title.Text = translations.getText("tasksEditTitle")
        description_lbl.Text = translations.getText("tasksEditDescription") & " *"
        qtd_lbl.Text = translations.getText("tasksEditQuantity") & " *"
        units_lbl.Text = translations.getText("tasksEditUnits") & " *"
        price_lbl.Text = translations.getText("tasksEditPrice") & " *"
        taskType_lbl.Text = translations.getText("tasksEditTaskType") & " *"
        translationText_lbl.Text = translations.getText("tasksEditTranslatedDescription") & " *"
        GroupBoxTask.Text = translations.getText("TasksTitle")
        translatedLanguages_lbl.Text = translations.getText("tasksLanguagesTitle")
        groupBoxTasksList.Text = translations.getText("tasksInsertTaskNextTo")
        reference_lbl.Text = translations.getText("tasksTableColumnReference") & " *"
        numTranslations.Text = ""

        TaskType.Items.Clear()
        TaskType.Items.Add(translations.getText("tasksTaskTitle"))
        TaskType.Items.Add(translations.getText("tasksTaskSubTitle"))
        TaskType.Items.Add(translations.getText("tasksTasksNornal"))

        save.Location = New Point(del.Location.X + del.Width + 5, save.Location.Y)

        site_frm.datatableChanges = False
        units.SelectedIndex = 0
        TaskType.SelectedIndex = 2
        If site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 1).Equals("1") Then
            TaskType.SelectedIndex = 2
        ElseIf site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 1).Equals("0") Then
            TaskType.SelectedIndex = 1
        ElseIf site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 1).Equals("2") Then
            TaskType.SelectedIndex = 0
        End If

        If Not site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 2).Equals(translations.getText("tasksAddTask")) Then
            del.Enabled = True
            description.Text = site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 5)
            Try
                Dim dec As Decimal = Decimal.Parse(site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 3), NumberStyles.Currency)
                price.Text = dec.ToString
            Catch ex As Exception
                price.Text = ""
            End Try
            translationText.Text = ""
            qtd.Text = site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 4)
            reference.Text = site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 1)
            units.Items.Add(translations.getText("tasksUnitsOther"))
            units.SelectedItem = 5
            For i = 0 To units.Items.Count - 1
                If site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 5).ToUpper.Equals(units.Items(i).ToString) Then
                    units.SelectedIndex = i
                    Exit For
                End If
            Next i
        Else
            qtd.Text = ""
            description.Text = ""
            price.Text = ""
            reference.Text = ""
            translationText.Text = ""
            del.Enabled = False
        End If
        tasksList.Items.Clear()

        ResumeLayout()
        mask.Dispose()
    End Sub

    Private Sub SiteLivraisonEdit_shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        translations.load("siteActivity")

        tasksList.Items.Clear()
        tasksList.Items.Add(translations.getText("tasksDropdownSelectMoveToFirstTask"))

        DbBordereau = orderTasksList(site_frm.DbBordereau)

        For i = 0 To DbBordereau.Item("cod_task").Count - 1
            tasksList.Items.Add(DbBordereau.Item("cod_task")(i) & " - " & DbBordereau.Item("descricao")(i))
            If site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 0).Equals(DbBordereau.Item("previous_task")(i)) Then
                tasksList.SelectedIndex = i
            End If
        Next i
        If tasksList.SelectedIndex < 0 Then
            tasksList.SelectedIndex = 0
        End If


        taskTranslations = getTaskTranslations(site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 4))
        GetAllCountryLanguages()
        translations.load("siteActivity")
        numTranslations.Text = translations.getText("tasksNumTranslations") & ": " & If(IsNothing(taskTranslations), "0", taskTranslations.Count.ToString)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        translations.load("siteActivity")
        If show_all_lang.Checked Then
            show_all_lang.Text = translations.getText("tasksShowTranslatedLanguages")
        Else
            show_all_lang.Text = translations.getText("tasksShowProjectLanguages")
        End If
        GetAllCountryLanguages()
    End Sub

    Private Sub apagar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles del.LinkClicked
        translations.load("siteActivity")
        Dim message As String = translations.getText("deliveryQuestionDelRecord")
        translations.load("messagebox")
        msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not msgbox.ShowDialog = DialogResult.Yes Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "32") 'bordereau edit
        vars.Add("request", "del")
        vars.Add("cod", site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 0))
        vars.Add("site", site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 3))
        vars.Add("section", site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 2))
        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord"), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub gravar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        Dim message As String = ""
        If reference.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorRefDoc")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            description.Focus()
            Exit Sub
        End If
        If description.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            description.Focus()
            Exit Sub
        End If
        If qtd.Text.Equals("") Or Not IsNumeric(qtd.Text) Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorQuantity")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            qtd.Focus()
            Exit Sub
        End If
        If price.Text.Equals("") Or Not IsNumeric(price.Text) Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            price.Focus()
            Exit Sub
        End If
        If units.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            price.Focus()
            Exit Sub
        End If

        translations.load("siteActivity")
        Dim tasktypeToSend As String = ""
        If TaskType.SelectedIndex.Equals(0) Then ' title
            tasktypeToSend = "2"
        ElseIf TaskType.SelectedIndex.Equals(1) Then 'sub title
            tasktypeToSend = "0"
        Else 'active task 
            tasktypeToSend = "1"
        End If
        Dim previoustask As String = ""
        If tasksList.SelectedIndex.Equals(0) Then
            previoustask = "0"
        Else
            previoustask = DbBordereau("cod_task")(tasksList.SelectedIndex - 1)
        End If

        Dim taskTranslationsToSend As String = ""
        If IsNothing(taskTranslations) Then
            taskTranslationsToSend = ""
        Else
            taskTranslationsToSend = JsonConvert.SerializeObject(taskTranslations)
        End If
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "32") 'bordereau edit
        vars.Add("site", site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 3))
        vars.Add("section", site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 2))

        If site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 2).Equals(translations.getText("tasksAddTask")) Then
            vars.Add("request", "add")
        Else
            vars.Add("request", "edit")
            vars.Add("cod", site_frm.bordereauTable(site_frm.qtd_datatable_cellY, 0))
        End If
        vars.Add("ref", reference.Text.ToString)
        vars.Add("qtd", qtd.Text.ToString)
        vars.Add("price", price.Text.ToString)
        vars.Add("units", unitsTxt.Text.ToString)
        vars.Add("description", description.Text.ToString)
        vars.Add("translations", taskTranslationsToSend)
        vars.Add("tasktype", tasktypeToSend)
        vars.Add("previoustask", previoustask)

        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            MainMdiForm.statusMessage = translations.getText("resultSuccessSaveRecord")
            site_frm.datatableChanges = True
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub closebtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub tasksList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tasksList.SelectedIndexChanged

    End Sub

    Private Sub tasksList_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles tasksList.DrawItem
        e.DrawBackground()
        Dim selected As Boolean = False
        If e.Index > 0 Then
            If DbBordereau("enabled")(e.Index - 1).Equals("2") Then ' title
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.AntiqueWhite)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            ElseIf DbBordereau("enabled")(e.Index - 1).Equals("1") Then ' normal task
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            ElseIf DbBordereau("enabled")(e.Index - 1).Equals("0") Then ' sub title
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.WhiteSmoke)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            End If
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
            If Not IsNothing(tasksList) Then
                If tasksList.Items.Count > 0 Then
                    e.Graphics.DrawString(tasksList.GetItemText(tasksList.Items(e.Index)), e.Font, b, e.Bounds)
                End If
            End If
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub units_SelectedIndexChanged(sender As Object, e As EventArgs) Handles units.SelectedIndexChanged
        If units.SelectedIndex = 5 Then
            unitsTxt.Text = ""
        Else
            unitsTxt.Text = units.SelectedItem.ToString
        End If

    End Sub

    Public Sub GetAllCountryLanguages()
        ' Iterate the Framework Cultures...
        Dim shortcountryList As New List(Of String)

        If Not IsNothing(site_frm.query_site) And show_all_lang.Checked Then
            Dim numLangs = site_frm.query_site.Item("project_languages")(InQueryDictionary(site_frm.query_site, site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 3), "cod_site")).ToString.Split(",")
            For i = 0 To numLangs.Length - 1
                shortcountryList.Add(numLangs(i))
            Next i
        Else
            If Not IsNothing(taskTranslations) Then
                For i = 0 To taskTranslations.Count - 1
                    shortcountryList.Add(taskTranslations.ElementAt(i).Key)
                Next i
            Else
                MainMdiForm.statusMessage = "No translatons found for the selected task"
            End If
        End If
        languagesList.Items.Clear()
        countryList.Clear()

        Dim ci As CultureInfo

        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                If Not IsNothing(taskTranslations) Then
                    If taskTranslations.ContainsKey(newKeyValuePair.Value) Then
                        If Not taskTranslations(newKeyValuePair.Value).Equals("") Then
                            translations.load("siteActivity")
                            languagesList.Items.Add(ci.DisplayName & " (" & translations.getText("tasksEditTranslated") & ")")
                        Else
                            languagesList.Items.Add(ci.DisplayName)
                        End If
                    Else
                        languagesList.Items.Add(ci.DisplayName)
                    End If
                Else
                    languagesList.Items.Add(ci.DisplayName)
                End If

                ' check if it hqs trqnslation and if true set selected

            End If
        Next ci
    End Sub

    Private Sub languagesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles languagesList.SelectedIndexChanged
        If languagesList.SelectedIndex > -1 And Not IsNothing(taskTranslations) Then
            If taskTranslations.ContainsKey(countryList.ElementAt(languagesList.SelectedIndex).Value) Then
                translationText.Text = taskTranslations(countryList.ElementAt(languagesList.SelectedIndex).Value)
                translations.load("siteActivity")
                translationText_lbl.Text = translations.getText("tasksEditTranslatedDescription") & " " & countryList.ElementAt(languagesList.SelectedIndex).Key & " *"
            Else
                translationText_lbl.Text = translations.getText("tasksEditTranslatedDescription") & " " & countryList.ElementAt(languagesList.SelectedIndex).Key & " *"
                translationText.Text = ""
                translate.Enabled = True
            End If
            translate.Enabled = True
        ElseIf languagesList.SelectedIndex > -1 Then
            translationText_lbl.Text = translations.getText("tasksEditTranslatedDescription") & " " & countryList.ElementAt(languagesList.SelectedIndex).Key & " *"
            translationText.Text = ""
            translate.Enabled = True
        Else
            translationText.Text = ""
            translationText_lbl.Text = translations.getText("tasksEditTranslatedDescription") & " - - *"
            translate.Enabled = False
        End If
    End Sub

    Private Sub translate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles translate.LinkClicked
        enableButtonsAndLinks(Me, False)
        translationText.Text = DoTranslation(description.Text, countryList.ElementAt(languagesList.SelectedIndex).Value, site_frm.query_site("primary_lang")(InQueryDictionary(site_frm.query_site, site_frm.bordereauTableState(site_frm.qtd_datatable_cellY, 3), "cod_site")), False)
        If IsNothing(taskTranslations) Then
            taskTranslations = New Dictionary(Of String, String)
        End If
        If taskTranslations.ContainsKey(countryList.ElementAt(languagesList.SelectedIndex).Value) Then
            taskTranslations(countryList.ElementAt(languagesList.SelectedIndex).Value) = translationText.Text
        Else
            taskTranslations.Add(countryList.ElementAt(languagesList.SelectedIndex).Value, translationText.Text)
        End If
        translations.load("siteActivity")
        numTranslations.Text = translations.getText("tasksNumTranslations") & ": " & If(IsNothing(taskTranslations), "0", taskTranslations.Count.ToString)
        GetAllCountryLanguages()
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub translationText_TextChanged(sender As Object, e As EventArgs) Handles translationText.TextChanged
        If Not IsNothing(taskTranslations) And languagesList.SelectedIndex > -1 Then
            If taskTranslations.ContainsKey(countryList.ElementAt(languagesList.SelectedIndex).Value) Then
                taskTranslations(countryList.ElementAt(languagesList.SelectedIndex).Value) = translationText.Text
            End If
        End If
    End Sub
End Class