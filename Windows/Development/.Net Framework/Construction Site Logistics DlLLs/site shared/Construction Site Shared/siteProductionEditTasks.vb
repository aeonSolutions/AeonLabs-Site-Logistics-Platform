Imports System.ComponentModel
Imports System.Globalization

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports Newtonsoft.Json
Imports ConstructionSiteLogistics.AddOn.Translations.Web

Public Class siteProductionEditTasksForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private mask As PictureBox = Nothing
    Private countryList As New Dictionary(Of String, String)
    Private WithEvents DataRequests As IDataSiteRequests
    Private taskRequest As String = ""
    Private response As String
    Private WithEvents bwTranslate As BackgroundWorker
    Private WithEvents bwLoadBordereau As BackgroundWorker
    Private DbBordereau As Dictionary(Of String, List(Of String))
    Private shortcountryListProject As New List(Of String)
    Private shortCountryListTask As New List(Of String)
    Private taskTranslations As New Dictionary(Of String, String)
    Private DBdata As New Dictionary(Of String, String)
    Private DBsites As New Dictionary(Of String, List(Of String))
    Private mainForm As MainMdiForm
    'TODO needs to move to an interface
    Private WithEvents translateText As TranslationLibrary
    Private Sub CloseMe()
        Me.Close()
    End Sub
    Public Sub New(_mainForm As MainMdiForm, _DBdata As Dictionary(Of String, String), _DBbordereau As Dictionary(Of String, List(Of String)), _DBsites As Dictionary(Of String, List(Of String)))
        DBdata = _DBdata
        DbBordereau = _DBbordereau
        DBsites = _DBsites
        mainForm = _mainForm

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        InitializeComponent()
    End Sub


    Private Sub SiteLivraisonEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()

        Me.SuspendLayout()

        divider.BackColor = stateCore.dividerColor
        closeBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        GroupBoxTask.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        groupBoxTasksList.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)

        tasksList.Font = New Font(stateCore.fontTitle.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Regular)
        TaskType.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        description.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        languagesList.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        translationText.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        units.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        unitsTxt.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        price.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        reference.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        mandatory.Font = New Font(stateCore.fontTitle.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Regular)
        translate.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        del.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        taskType_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        description_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        translatedLanguages_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        show_all_lang.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        translationText_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        units_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        price_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        reference_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        numTranslations.Font = New Font(stateCore.fontTitle.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Regular)

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

        units.SelectedIndex = 0
        TaskType.SelectedIndex = 2
        If DBdata("tasktype").Equals("1") Then
            TaskType.SelectedIndex = 2
        ElseIf DBdata("tasktype").Equals("0") Then
            TaskType.SelectedIndex = 1
        ElseIf DBdata("tasktype").Equals("2") Then
            TaskType.SelectedIndex = 0
        End If

        If Not DBdata("description").Equals(translations.getText("tasksAddTask")) Then
            del.Enabled = True
            description.Text = DBdata("original")
            Try
                Dim dec As Decimal = Decimal.Parse(DBdata("price"), NumberStyles.Currency)
                price.Text = dec.ToString
            Catch ex As Exception
                price.Text = ""
            End Try
            translationText.Text = ""
            qtd.Text = DBdata("qtd")
            reference.Text = DBdata("ref")
            units.Items.Add(translations.getText("tasksUnitsOther"))
            units.SelectedItem = 5
            For i = 0 To units.Items.Count - 1
                If DBdata("units").ToUpper.Equals(units.Items(i).ToString) Then
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

        translations.load("siteActivity")

        tasksList.Items.Clear()
        tasksList.Items.Add(translations.getText("tasksDropdownSelectMoveToFirstTask"))

        DbBordereau = orderTasksList(DbBordereau)
        For i = 0 To DbBordereau.Item("cod_task").Count - 1
            tasksList.Items.Add(DbBordereau.Item("cod_task")(i) & " - " & DbBordereau.Item("descricao")(i))
            If DBdata("prevTask").Equals(DbBordereau.Item("previous_task")(i)) Then
                tasksList.SelectedIndex = i
            End If
        Next i
        If tasksList.SelectedIndex < 0 Then
            tasksList.SelectedIndex = 0
        End If

        taskTranslations = getTaskTranslations(DBdata("translations"))
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
        msgbox = New messageBoxForm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not msgbox.ShowDialog = DialogResult.Yes Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "32") 'bordereau edit
        vars.Add("request", "del")
        vars.Add("cod", DBdata("cod"))
        vars.Add("site", DBdata("site"))
        vars.Add("section", DBdata("section"))
        taskRequest = "del"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveProductionData()

    End Sub
    Private Sub DataRequests_getResponseSaveProductionData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveProductionData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            If taskRequest.Equals("del") Then
                mainForm.statusMessage = translations.getText("resultSuccessDelRecord")
            Else
                mainForm.statusMessage = translations.getText("resultSuccessSaveRecord")
            End If
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
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            description.Focus()
            Exit Sub
        End If
        If description.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            description.Focus()
            Exit Sub
        End If
        If qtd.Text.Equals("") Or Not IsNumeric(qtd.Text) Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorQuantity")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            qtd.Focus()
            Exit Sub
        End If
        If price.Text.Equals("") Or Not IsNumeric(price.Text) Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            price.Focus()
            Exit Sub
        End If
        If units.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        vars.Add("site", DBdata("site"))
        vars.Add("section", DBdata("section"))

        If DBdata("description").Equals(translations.getText("tasksAddTask")) Then
            vars.Add("request", "add")
        Else
            vars.Add("request", "edit")
            vars.Add("cod", DBdata("cod"))
        End If
        vars.Add("ref", reference.Text.ToString)
        vars.Add("qtd", qtd.Text.ToString)
        vars.Add("price", price.Text.ToString)
        vars.Add("units", unitsTxt.Text.ToString)
        vars.Add("description", description.Text.ToString)
        vars.Add("translations", taskTranslationsToSend)
        vars.Add("tasktype", tasktypeToSend)
        vars.Add("previoustask", previoustask)

        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveProductionData()
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

        If Not IsNothing(DBsites) And show_all_lang.Checked Then
            Dim numLangs = DBsites.Item("project_languages")(InQueryDictionary(DBsites, DBdata("site"), "cod_site")).ToString.Split(",")
            For i = 0 To numLangs.Length - 1
                shortcountryList.Add(numLangs(i))
            Next i
        Else
            If Not IsNothing(taskTranslations) Then
                For i = 0 To taskTranslations.Count - 1
                    shortcountryList.Add(taskTranslations.ElementAt(i).Key)
                Next i
            Else
                mainForm.statusMessage = "No translatons found for the selected task"
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
        translateText = New TranslationLibrary(description.Text, countryList.ElementAt(languagesList.SelectedIndex).Value, DBsites("primary_lang")(InQueryDictionary(DBsites, DBdata("site"), "cod_site")), False)
    End Sub
    Private Sub translateText_getTranslationText(sender As Object, responseData As String) Handles translateText.getTranslationText
        translationText.Text = responseData
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