Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.AddOn.Translations.Web

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports Newtonsoft.Json.Linq

Public Class siteRegieEdit
    Private mask As PictureBox = Nothing
    Private loaded As Boolean = False
    Private regieWorkersList As List(Of Integer)
    Private attendanceWorkersList As List(Of Integer)
    Private regieWorkersListPhotos As List(Of String)
    Private attendanceWorkersListPhotos As List(Of String)
    Private cellX, cellY As Integer
    Private regieCodes As String()
    Private regieTable As String(,)
    Private regieSite As String
    Private response As String = ""
    Private hasChanges As Boolean = False
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private WithEvents DataRequests As IDataSiteRequests
    Private taskRequest As String = ""
    Private resetDate As String = ""
    Private mainform As MainMdiForm
    Private siteFrm As site_frm

    ''TODO move to a load dll if addon is installed
    Private WithEvents translateText As TranslationLibrary
    Public Sub New(_mainMdiForm As MainMdiForm, _siteFrm As site_frm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        mainform = _mainMdiForm
        siteFrm = _siteFrm
        Me.Refresh()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub siteRegieEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainform.state
        translations = New languageTranslations(stateCore)
        Me.SuspendLayout()

        edit_regie_hora_fim.CustomFormat = "HH:mm"
        edit_regie_hora_fim.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        edit_regie_hora_fim.ShowUpDown = True
        edit_regie_hora_inicio.CustomFormat = "HH:mm"
        edit_regie_hora_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        edit_regie_hora_inicio.ShowUpDown = True
        validation_duration.CustomFormat = "HH:mm"
        validation_duration.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        validation_duration.ShowUpDown = True
        validation_duration.Value = "2000-01-01 00:00:00"

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, FontStyle.Bold)
        search_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        workersList_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        workersAssigned_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        date_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        annotations_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)
        validation_reason_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Bold)

        edit_regie_duration_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_searchbox.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_available_workers.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_signed_workers.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        resetLink.Font = New Font(stateCore.fontText.Families(0), stateCore.SmallTextFontSize, FontStyle.Regular)
        edit_regie_date.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        start_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        end_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_hora_fim.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_hora_inicio.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_enable_hours.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_notes.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_notes_previous.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        validate_record.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        validation_duration.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        validation_time_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        validation_reason.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_translate.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_del.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        edit_regie_save.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        divider.BackColor = stateCore.dividerColor

        translations.load("EditRegieDialog")
        title.Text = translations.getText("title")
        workersList_lbl.Text = translations.getText("workersList")
        workersAssigned_lbl.Text = translations.getText("workersAssigned")
        date_lbl.Text = translations.getText("date")
        edit_regie_duration_lbl.Text = translations.getText("duration")
        start_time_lbl.Text = translations.getText("startTime")
        end_time_lbl.Text = translations.getText("endTime")
        edit_regie_enable_hours.Text = translations.getText("enableTimeEdit")
        validate_record.Text = translations.getText("validateRecord")
        validation_time_lbl.Text = translations.getText("duration")
        annotations_lbl.Text = translations.getText("annotations")
        validation_reason_lbl.Text = translations.getText("reason")
        edit_regie_notes.Text = translations.getText("listWorksMissing") & Environment.NewLine & "_____________________________________________________________"
        translations.load("commonForm")
        search_lbl.Text = translations.getText("SearchBoxTitle")
        resetLink.Text = translations.getText("resetLink")
        edit_regie_translate.Text = translations.getText("translateLink")
        edit_regie_del.Text = translations.getText("delLink")
        edit_regie_save.Text = translations.getText("saveLink")
        closeBtn.Text = translations.getText("closeBtn")
        If stateCore.addonsLoaded Then
            If Not stateCore.addons.ContainsKey("translation") Then
                edit_regie_translate.Enabled = False
            End If
        End If
        photobox.Image = Image.FromFile(stateCore.imagesPath & "worker.png")
        photobox.SizeMode = PictureBoxSizeMode.StretchImage
        validation_reason.Text = ""
        edit_regie_save.Location = New Point(edit_regie_del.Location.X + edit_regie_del.Width + 5, edit_regie_save.Location.Y)
        Me.ResumeLayout()

        loaded = False
        hasChanges = False
    End Sub

    Private Sub workers_absense_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "site.dll", "siteDataRequests"), IDataSiteRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainform.statusMessage = "DLL file not found"
            mainform.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        edit_regie_date.Value = DateTime.Now
        edit_regie_date.CustomFormat = "yyyy-MM-dd"
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Image = Image.FromFile(mainform.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Top = TopMost
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.SuspendLayout()

        cellX = siteFrm.regie_datatable_cellX
        cellY = siteFrm.regie_datatable_cellY
        regieCodes = siteFrm.regieCodes
        regieTable = siteFrm.regieTable
        regieSite = siteFrm.query_site.Item("cod_site")(siteFrm.regie_selected_site - 1)
        regieWorkersList = New List(Of Integer)
        attendanceWorkersList = New List(Of Integer)
        regieWorkersListPhotos = New List(Of String)
        attendanceWorkersListPhotos = New List(Of String)
        edit_regie_date.Value = Now
        edit_regie_hora_inicio.Value = "2000-01-01 00:00:00"
        edit_regie_hora_fim.Value = "2000-01-01 00:00:00"

        Me.ResumeLayout()
        Me.Refresh()
        load_list()

    End Sub

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

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()

    End Sub


    Sub load_list()
        mainform.busy.Show()
        If IsNothing(regieCodes) Then
            mainform.statusMessage = "regie code not found"
            Exit Sub
        End If
        Dim code As String = If(regieCodes(cellY).Equals("-1"), "null", regieCodes(cellY))
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "load")
        vars.Add("type", "edit")
        vars.Add("cod", code)
        If code.Equals("null") Then
            vars.Add("date", edit_regie_date.Value.ToString("yyyy-MM-dd"))
            vars.Add("site", regieSite)
            vars.Add("section", regieTable(cellY, 9))
        End If
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadRegieTableData()

    End Sub
    Private Sub DataRequests_getResponseLoadRegieTableData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseLoadRegieTableData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
        End If

        edit_regie_signed_workers.Items.Clear()
        edit_regie_available_workers.Items.Clear()
        regieWorkersList.Clear()
        attendanceWorkersList.Clear()

        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            removeMask()
            translations.load("system")
            mainform.statusMessage = translations.getText("errorFormNoHandle")
            mainform.busy.Close(True)
            Exit Sub
        End If

        If errorFlag Then
            removeMask()
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            mainform.busy.Close(True)
            Exit Sub
        End If

        edit_regie_hora_inicio.Value = "2000-01-01 00:00:00"
        edit_regie_hora_fim.Value = "2000-01-01 00:00:00"
        edit_regie_save.Enabled = True
        edit_regie_del.Enabled = If(regieCodes(cellY).Equals("-1"), False, True)
        edit_regie_date.Enabled = If(regieCodes(cellY).Equals("-1"), True, False)
        edit_regie_enable_hours.Checked = If(regieCodes(cellY).Equals("-1"), True, False)
        edit_regie_hora_inicio.Enabled = False
        edit_regie_hora_fim.Enabled = False
        edit_regie_enable_hours.Checked = False
        edit_regie_notes.Enabled = True
        edit_regie_signed_workers.Enabled = True
        edit_regie_available_workers.Enabled = True
        edit_regie_translate.Enabled = False
        edit_regie_notes_previous.Text = ""

        edit_regie_signed_workers.Items.Clear()
        edit_regie_available_workers.Items.Clear()
        regieWorkersList.Clear()
        attendanceWorkersList.Clear()
        regieWorkersListPhotos.Clear()
        attendanceWorkersListPhotos.Clear()
        Try
            Dim data = JObject.Parse(response)
            If data("regie") IsNot Nothing Then
                Dim stime, etime As DateTime
                stime = DateTime.ParseExact(If(data("regie").Item("start").ToString.Equals("00:00:00"), "07:30:00", data("regie").Item("start").ToString), "HH:mm:ss", CultureInfo.InvariantCulture)
                etime = DateTime.ParseExact(If(data("regie").Item("end").ToString.Equals("00:00:00"), "17:30:00", data("regie").Item("end").ToString), "HH:mm:ss", CultureInfo.InvariantCulture)

                edit_regie_hora_inicio.Value = "2000-01-01 " & data("regie").Item("start").ToString
                edit_regie_hora_fim.Value = "2000-01-01 " & data("regie").Item("end").ToString

                Dim time = etime - stime
                If etime.Hour >= 13 And stime.Hour < 13 Then
                    time = time.Subtract(New TimeSpan(0, 30, 0))
                End If
                translations.load("EditRegieDialog")
                edit_regie_duration_lbl.Text = translations.getText("duration") & ": " & time.ToString("c")

                If (data("regie").Item("end").ToString.Equals("00:00:00") And data("regie").Item("date").ToString.Equals(String.Format("{0:yyyy-MM-dd}", DateTime.Now))) Then ' regie Is Not closed today
                    edit_regie_notes.Text = data("regie").Item("notes").ToString
                    edit_regie_notes_previous.Text = ""
                Else
                    edit_regie_notes.Text = ""
                    edit_regie_notes_previous.Text = data("regie").Item("notes").ToString
                End If

                edit_regie_translate.Enabled = If(edit_regie_notes.Text.Equals(""), False, True)

                edit_regie_date.Value = data("regie").Item("date").ToString
                resetDate = data("regie").Item("date").ToString

                If Not (data("regie").Item("date").ToString.Equals("") Or data("regie").Item("date").ToString.Equals("00:00:00")) Then
                    validation_duration.Value = DateTime.ParseExact(data("regie").Item("validated").ToString, "HH:mm:ss", CultureInfo.InvariantCulture)
                    validation_reason.Text = data("regie").Item("reason").ToString
                    validate_record.Checked = True
                    validation_duration.Enabled = True
                    validation_reason.Enabled = True
                    edit_regie_enable_hours.Enabled = False
                    edit_regie_date.Enabled = False
                    edit_regie_hora_fim.Enabled = False
                    edit_regie_hora_inicio.Enabled = False
                    edit_regie_notes.Enabled = False
                    edit_regie_signed_workers.Enabled = False
                    edit_regie_available_workers.Enabled = False
                End If
                Dim regieWorkers As JArray = JArray.Parse(data.Item("regie").Item("workers").ToString)
                regieWorkersList.Clear()
                For Each regieWorker In regieWorkers
                    edit_regie_signed_workers.Items.Add(regieWorker.Item("name").ToString)
                    regieWorkersList.Add(regieWorker.Item("code").ToString)
                    regieWorkersListPhotos.Add(regieWorker.Item("photo").ToString)
                Next regieWorker
            End If
            If data("attendance") IsNot Nothing Then
                Dim attendanceWorkers As JArray = JArray.Parse(data.Item("attendance").Item("workers").ToString)
                For Each attendanceWorker In attendanceWorkers
                    edit_regie_available_workers.Items.Add(attendanceWorker.Item("name").ToString)
                    attendanceWorkersList.Add(attendanceWorker.Item("code").ToString)
                    attendanceWorkersListPhotos.Add(attendanceWorker.Item("photo").ToString)
                Next attendanceWorker
            End If
        Catch ex As Exception
            mainform.busy.Close(True)
            saveCrash(ex)
            mainform.statusMessage = (ex.ToString)
        End Try
        If Not regieCodes(cellY).Equals("-1") Then
            edit_regie_date.Enabled = False
            resetLink.Enabled = False
        End If

        mainform.busy.Close(True)
        removeMask()
        loaded = True
    End Sub

    Private Sub edit_regie_available_workers_DoubleClick(sender As Object, e As EventArgs) Handles edit_regie_available_workers.DoubleClick
        If edit_regie_available_workers.SelectedIndex > -1 Then
            If edit_regie_signed_workers.Items.Count > 0 Then
                For i = 0 To edit_regie_signed_workers.Items.Count - 1
                    If edit_regie_available_workers.SelectedItem.ToString().Equals(edit_regie_signed_workers.Items(i).ToString) Then
                        translations.load("EditRegieDialog")
                        Dim message As String = translations.getText("workerIsOnList")
                        translations.load("messagebox")
                        msgbox = New messageBoxForm(message & ". ", translations.getText("warning"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                        msgbox.ShowDialog()
                        Exit Sub
                    End If
                Next i
            End If
            edit_regie_signed_workers.Items.Add(edit_regie_available_workers.SelectedItem.ToString)
            regieWorkersList.Add(attendanceWorkersList.Item(edit_regie_available_workers.SelectedIndex).ToString)
        End If
    End Sub

    Private Sub edit_regie_signed_workers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles edit_regie_signed_workers.SelectedIndexChanged
        If edit_regie_signed_workers.SelectedIndex > -1 Then
            loadWorkerPhoto(regieWorkersListPhotos.Item(edit_regie_signed_workers.SelectedIndex).ToString)
        End If
    End Sub

    Private Sub edit_regie_signed_workers_DoubleClick(sender As Object, e As EventArgs) Handles edit_regie_signed_workers.DoubleClick
        If edit_regie_signed_workers.SelectedIndex > -1 Then
            regieWorkersList.RemoveAt(edit_regie_signed_workers.SelectedIndex)
            edit_regie_signed_workers.Items.RemoveAt(edit_regie_signed_workers.SelectedIndex)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        doSearch(If(edit_regie_available_workers.SelectedIndex <= 0, 1, edit_regie_available_workers.SelectedIndex + 1), True)
    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If edit_regie_available_workers.Items.Count > 0 Then
            Dim found As Boolean = False
            For i = start + 1 To edit_regie_available_workers.Items.Count - 1
                If Not edit_regie_available_workers.Items(i).ToString.ToLower.IndexOf(edit_regie_searchbox.Text.ToLower) = -1 Then
                    edit_regie_available_workers.SelectedIndex = i
                    found = True
                    Exit For
                End If
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message & ". ", translations.getText("information"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message As String = translations.getText("searchResultsNotFound") & "." & translations.getText("searchAgainQuestion")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message & "? ", translations.getText("question"), MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearch(0, False)
                End If
            End If
        End If
    End Sub

    Private Sub edit_regie_del_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles edit_regie_del.LinkClicked
        Dim code As String = If(regieCodes(cellY).Equals("-1"), "", regieCodes(cellY))
        If code.Equals("") Then
            translations.load("EditRegieDialog")
            Dim message As String = translations.getText("missingRecordCode") & "." & translations.getText("searchAgainQuestion")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message & "? ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)

        translations.load("EditRegieDialog")
        Dim message2 As String = translations.getText("removeRecordQuestion")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message2 & "? ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("request", "del")
            vars.Add("cod", code)
            taskRequest = "del"
            DataRequests.Initialise(stateCore)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveRegieData()
        End If
    End Sub
    Private Sub DataRequests_getResponseSaveRegieData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveRegieData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainform.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else

            translations.load("EditRegieDialog")
            If taskRequest.Equals("del") Then
                mainform.statusMessage = translations.getText("removeRecordSuccess")
                edit_regie_date.Value = DateTime.Now
                edit_regie_notes.Text = ""
                edit_regie_hora_inicio.Text = ""
                edit_regie_hora_fim.Text = ""
                edit_regie_available_workers.Items.Clear()
                edit_regie_signed_workers.Items.Clear()

                edit_regie_save.Enabled = False
                edit_regie_del.Enabled = False
                edit_regie_date.Enabled = True
                edit_regie_hora_inicio.Enabled = False
                edit_regie_hora_fim.Enabled = False
                edit_regie_notes.Enabled = False
                edit_regie_signed_workers.Enabled = False
                edit_regie_available_workers.Enabled = False
                edit_regie_translate.Enabled = False
            Else
                mainform.statusMessage = translations.getText("recordAddSuccess")
                edit_regie_date.Value = DateTime.Now
                edit_regie_notes.Text = ""
                edit_regie_hora_inicio.Text = ""
                edit_regie_hora_fim.Text = ""
                edit_regie_available_workers.Items.Clear()
                edit_regie_signed_workers.Items.Clear()
            End If
        End If
        enableButtonsAndLinks(Me, True)
        taskRequest = ""
        hasChanges = True
        loaded = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        If hasChanges Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        CloseMe()
    End Sub

    Private Sub edit_regie_update_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If loaded Then
            load_list()
        End If
    End Sub

    Private Sub edit_regie_date_ValueChanged(sender As Object, e As EventArgs) Handles edit_regie_date.ValueChanged
        If loaded Then
            load_list()
        End If
    End Sub

    Private Sub edit_regie_enable_hours_CheckedChanged(sender As Object, e As EventArgs) Handles edit_regie_enable_hours.CheckedChanged
        If edit_regie_enable_hours.Checked Then
            edit_regie_hora_inicio.Enabled = True
            edit_regie_hora_fim.Enabled = True
        ElseIf (regieCodes(cellY).Equals("-1")) Then
            edit_regie_enable_hours.Checked = True
        Else
            edit_regie_hora_inicio.Enabled = False
            edit_regie_hora_fim.Enabled = False
        End If
    End Sub

    Private Sub edit_regie_translate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles edit_regie_translate.LinkClicked
        enableButtonsAndLinks(Me, False)

        translateText = New TranslationLibrary(edit_regie_notes.Text, siteFrm.query_site("primary_lang")(InQueryDictionary(siteFrm.query_site, regieSite, "cod_site")), stateCore.currentLang, True)
    End Sub

    Private Sub translateText_getTranslationText(sender As Object, responseData As String) Handles translateText.getTranslationText
        edit_regie_notes.Text = responseData
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub resetLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles resetLink.LinkClicked
        If Not resetDate.Equals("") AndAlso IsDate(resetDate) Then
            edit_regie_date.Value = resetDate
        End If
    End Sub

    Private Sub loadWorkerPhoto(photo As String)
        If photo.Equals("") Then
            photobox.Image = Image.FromFile(mainform.state.imagesPath & Convert.ToString("worker.png"))
        Else
            photobox.Image = Image.FromFile(mainform.state.imagesPath & Convert.ToString("loading.png"))
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
            Dim tClient As WebClient = New WebClient
            Try
                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(stateCore.ServerBaseAddr & "/works/photos/" & photo)))
                photobox.Image = tImage
            Catch ex As Exception
                photobox.Image = Image.FromFile(mainform.state.imagesPath & "worker.png")
                translations.load("errorMessages")
                mainform.statusMessage = translations.getText("errorDownloadingPhoto")
            End Try
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub edit_regie_available_workers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles edit_regie_available_workers.SelectedIndexChanged
        If edit_regie_available_workers.SelectedIndex > -1 Then
            loadWorkerPhoto(attendanceWorkersListPhotos.Item(edit_regie_available_workers.SelectedIndex).ToString)
        End If
    End Sub

    Private Sub validate_record_CheckedChanged(sender As Object, e As EventArgs) Handles validate_record.CheckedChanged
        If validate_record.Checked And loaded Then
            ' Parse hour:minute value with "g" specifier current culture.'
            If TimeSpan.Compare(edit_regie_hora_inicio.Value.TimeOfDay, edit_regie_hora_fim.Value.TimeOfDay) >= 1 Then
                translations.load("EditRegieDialog")
                Dim message3 As String = translations.getText("endHourError")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                validate_record.Checked = False
                Exit Sub
            End If
            Dim time = edit_regie_hora_fim.Value - edit_regie_hora_inicio.Value
            If edit_regie_hora_fim.Value.Hour >= 13 And edit_regie_hora_inicio.Value.Hour < 13 Then
                time = time.Subtract(New TimeSpan(0, 30, 0))
            End If

            validation_duration.Value = DateTime.ParseExact(time.ToString, "HH:mm:ss", CultureInfo.InvariantCulture)
            validation_duration.Enabled = True
            validation_reason.Enabled = True
            edit_regie_enable_hours.Enabled = False
            edit_regie_date.Enabled = False
            edit_regie_hora_fim.Enabled = False
            edit_regie_hora_inicio.Enabled = False
            edit_regie_notes.Enabled = False
            edit_regie_signed_workers.Enabled = False
            edit_regie_available_workers.Enabled = False
        Else
            validation_duration.Enabled = False
            validation_reason.Enabled = False

            edit_regie_enable_hours.Enabled = True
            If Not regieCodes(cellY).Equals("-1") Then
                edit_regie_date.Enabled = False
                resetLink.Enabled = False
            Else
                edit_regie_date.Enabled = True
                resetLink.Enabled = True
            End If
            edit_regie_notes.Enabled = True
            edit_regie_signed_workers.Enabled = True
            edit_regie_available_workers.Enabled = True
        End If
    End Sub

    Private Sub edit_regie_notes_TextChanged(sender As Object, e As EventArgs) Handles edit_regie_notes.TextChanged
        If edit_regie_translate.Enabled.Equals(False) And edit_regie_notes.Text.Length > 0 Then
            edit_regie_translate.Enabled = True
        ElseIf edit_regie_translate.Enabled.Equals(True) And edit_regie_notes.Text.Length.Equals(0) Then
            edit_regie_translate.Enabled = False
        End If
    End Sub

    Private Sub edit_regie_save_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles edit_regie_save.LinkClicked
        If (edit_regie_signed_workers.Items.Count = 0) Then ' edit 
            translations.load("EditRegieDialog")
            Dim message3 As String = translations.getText("noAssignedWorkers")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        Dim s = edit_regie_hora_fim.Value.TimeOfDay.ToString("hh\:mm")

        ' Parse hour:minute value with "g" specifier current culture.'
        If TimeSpan.Compare(edit_regie_hora_inicio.Value.TimeOfDay, edit_regie_hora_fim.Value.TimeOfDay) >= 1 And Not edit_regie_hora_fim.Value.TimeOfDay.ToString("hh\:mm").Equals("00:00") Then
            translations.load("EditRegieDialog")
            Dim message3 As String = translations.getText("endHourError")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        enableButtonsAndLinks(Me, False)
        loaded = False
        Dim vars As New Dictionary(Of String, String)
        Dim workers As String = ""
        For i = 0 To regieWorkersList.Count - 1
            workers += If(i = 0, regieWorkersList.Item(i).ToString, "," & regieWorkersList.Item(i).ToString)
        Next i
        vars.Add("workers", workers)
        vars.Add("task", "4")
        Dim code As String = If(regieCodes(cellY).Equals("-1"), "", regieCodes(cellY))
        If code.Equals("") Then
            vars.Add("request", "add")
            vars.Add("site", regieSite)
            vars.Add("section", regieTable(cellY, 9))
        Else
            vars.Add("request", "edit")
            vars.Add("cod", code)
        End If
        If (edit_regie_notes.Text.Equals("")) Then
            vars.Add("nota", "null")
        Else
            vars.Add("nota", edit_regie_notes.Text)
        End If

        vars.Add("date", edit_regie_date.Value.ToString("yyyy-MM-dd"))

        If edit_regie_enable_hours.Checked Then
            vars.Add("stime", edit_regie_hora_inicio.Value.TimeOfDay.ToString("hh\:mm") & ":00")
            vars.Add("etime", edit_regie_hora_fim.Value.TimeOfDay.ToString("hh\:mm") & ":00")
        Else
            vars.Add("stime", "null")
            vars.Add("etime", "null")
        End If
        If validate_record.Checked Then
            vars.Add("duration", validation_duration.Value.TimeOfDay.ToString("hh\:mm\:ss"))
            vars.Add("reason", validation_reason.Text)
        End If

        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveRegieData()
    End Sub
End Class