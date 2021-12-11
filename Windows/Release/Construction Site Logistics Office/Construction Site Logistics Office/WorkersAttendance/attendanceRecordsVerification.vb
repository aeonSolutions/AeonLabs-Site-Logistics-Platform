Imports System.Drawing.Text
Imports System.Threading

Public Class attendance_records_verification_frm
    Private state As State
    Private translations As languageTranslations
    Private msgbox As message_box_frm
    Private works_worker, entries As Dictionary(Of String, List(Of String))
    Private response As String = ""
    Private taskDuplicates, taskValidated As Task
    Private ctsDuplicates, ctsValidated As New CancellationTokenSource
    Private tokenDuplicates As CancellationToken = ctsDuplicates.Token
    Private tokenValidated As CancellationToken = ctsValidated.Token


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

    Private Sub duplicates_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        Me.SuspendLayout()
         
         

        subtitle.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        Me.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cmdbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duplicatesBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        searchDate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        month_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        duplicatesBtn.BackColor = state.buttonColor

        translations.load("duplicateAttendances")
        Me.Text = translations.getText("title")
        Me.Text = translations.getText("title")
        month_lbl.Text = translations.getText("month")
        cmdbox.Text = translations.getText("initalMessage")
        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        duplicatesBtn.Text = translations.getText("startBtn")

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(MainMdiForm.Width / 2 - Me.Width / 2, MainMdiForm.Height / 2 - Me.Height / 2)
        ResumeLayout()
    End Sub

    Private Sub duplicates_frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        Me.Show()

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        duplicatesBtn.Enabled = True
        translations.load("commonForm")
        duplicatesBtn.Text = translations.getText("startBtn")

        Try
            ctsDuplicates.Cancel()
            taskDuplicates.Wait()
            ctsValidated.Cancel()
            taskValidated.Wait()
        Catch ex As Exception

        Finally
            If Not IsNothing(taskDuplicates) Then
                taskDuplicates.Dispose()
                taskDuplicates = Nothing
            End If
            If Not IsNothing(taskValidated) Then
                taskValidated.Dispose()
                taskValidated = Nothing
            End If
        End Try
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles duplicatesBtn.Click
        translations.load("duplicateAttendances")
        cmdbox.Text = translations.getText("searchStart") & "..."
        duplicatesBtn.Text = translations.getText("waitBtn") & "..."

        duplicatesBtn.Enabled = False
        ctsDuplicates = New CancellationTokenSource
        tokenDuplicates = ctsDuplicates.Token
        taskDuplicates = New Task(Sub() doDuiplicatesSearch(tokenDuplicates), tokenDuplicates)

        taskDuplicates.Start()
    End Sub

    Private Sub cmdbox_TextChanged(sender As Object, e As EventArgs) Handles cmdbox.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Public Sub doDuiplicatesSearch(token As CancellationToken)
        translations.load("duplicateAttendances")

        Dim num_days As Integer = System.DateTime.DaysInMonth(searchDate.Value.ToString("yyyy"), searchDate.Value.ToString("MM"))
        If System.DateTime.Today.Month.ToString().Equals(searchDate.Value.ToString("MM")) Then
            num_days = System.DateTime.Today.Day.ToString
        End If

        Dim str As String = ""
        Try
            cmdbox.Invoke(Sub()
                              cmdbox.Text = translations.getText("dbContact") & "..." & translations.getText("waitBtn") & "."
                          End Sub)

            Dim vars As New Dictionary(Of String, String)
            Dim errorFlag As Boolean = False
            Dim errorMsg As String = ""

            vars.Add("task", "6")
            vars.Add("request", "workers")
            vars.Add("type", "active")
            Dim request As New HttpData(state)
            Dim response As String = request.RequestData(vars)
            If Not IsResponseOk(response) Then
                errorMsg = GetMessage(response)
                errorFlag = True
                GoTo lastline
            End If
            works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
            If IsNothing(works_worker) Then
                errorMsg = request.errorMessage
                errorFlag = True
                GoTo lastline
            End If
lastline:
            If errorFlag.Equals(True) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                translations.load("commonForm")
                duplicatesBtn.Invoke(Sub()
                                         duplicatesBtn.Enabled = True
                                         duplicatesBtn.Text = translations.getText("startBtn")
                                     End Sub)
                Exit Sub
            End If

            cmdbox.Invoke(Sub()
                              cmdbox.Text = cmdbox.Text & "OK."
                          End Sub)

            For i = 1 To num_days
                Dim currentDay = i
                subtitle.Invoke(Sub()
                                    subtitle.Text = translations.getText("title") & " ... " & translations.getText("searchInDay") & " " & currentDay & "/" & num_days
                                End Sub)
                Dim data As String = searchDate.Value.ToString("yyyy-MM-") & i.ToString()
                For j = 0 To works_worker.Item("cod_worker").Count - 1
                    errorFlag = False
                    If token.IsCancellationRequested Then
                        token.ThrowIfCancellationRequested()
                        duplicatesBtn.Enabled = True
                        translations.load("commonForm")
                        duplicatesBtn.Text = translations.getText("startBtn")
                        Exit Sub
                    End If

                    vars = New Dictionary(Of String, String)
                    vars.Add("task", "6")
                    vars.Add("request", "duplicates")
                    vars.Add("data", data)
                    vars.Add("worker", works_worker.Item("cod_worker")(j))
                    request = New HttpData(state)
                    response = request.RequestData(vars)
                    If Not IsResponseOk(response) Then
                        errorMsg = GetMessage(response)
                        errorFlag = True
                        GoTo lastlineFor
                    ElseIf GetMessage(response).Equals("1001") Then
                        Continue For
                    End If
                    entries = request.ConvertDataToArray("duplicates", state.queryDuplicatesFields, response)
                    If IsNothing(entries) Then
                        errorMsg = request.errorMessage
                        errorFlag = True
                        GoTo lastlineFor
                    End If
lastlineFor:
                    If errorFlag.Equals(True) Then
                        translations.load("messagebox")
                        msgbox = New message_box_frm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                        msgbox.ShowDialog()
                        Continue For
                    End If

                    str = ""
                    If entries.Item("cod_site").Count > 1 Then 'found duplicate
                        str = Environment.NewLine & Environment.NewLine & works_worker.Item("name")(j) & "    ( " & data & " ) :" & Environment.NewLine
                        For k = 0 To entries.Item("cod_site").Count - 1
                            str = str & " - [ " & entries.Item("name")(k) & " ]"
                        Next k
                    End If
                    cmdbox.Invoke(Sub()
                                      cmdbox.Text = cmdbox.Text & str
                                  End Sub)
                Next j
            Next i
            cmdbox.Invoke(Sub()
                              cmdbox.Text = cmdbox.Text & Environment.NewLine & "__________________________________________________________________________________________" & Environment.NewLine & translations.getText("EndOfSearch")
                          End Sub)

            translations.load("messagebox")
            Dim message As String = translations.getText("information")
            translations.load("duplicateAttendances")
            msgbox = New message_box_frm(translations.getText("EndOfSearch") & "." & translations.getText("correctRecords"), message, MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)
        End Try
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        duplicatesBtn.Invoke(Sub()
                                 duplicatesBtn.Enabled = True
                                 translations.load("commonForm")
                                 duplicatesBtn.Text = translations.getText("startBtn")
                             End Sub)
        nonValidatedBtn.Invoke(Sub()
                                   nonValidatedBtn.Text = translations.getText("startBtn")
                                   nonValidatedBtn.Enabled = True
                               End Sub)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles nonValidatedBtn.Click
        translations.load("nonValidatedAttendances")
        cmdbox.Text = translations.getText("searchStart") & "..."
        nonValidatedBtn.Text = translations.getText("waitBtn") & "..."

        nonValidatedBtn.Enabled = False
        duplicatesBtn.Enabled = False

        ctsValidated = New CancellationTokenSource
        tokenValidated = ctsValidated.Token
        taskValidated = New Task(Sub() doNonValidatedEntriesSearch(), tokenValidated)

        taskValidated.Start()
    End Sub

    Sub doNonValidatedEntriesSearch()
        translations.load("nonValidatedAttendances")
        cmdbox.Invoke(Sub()

                          cmdbox.Text = translations.getText("searchStart") & "..." & Environment.NewLine
                      End Sub)

        Dim num_days As Integer = System.DateTime.DaysInMonth(System.DateTime.Today.Year.ToString(), System.DateTime.Today.Month.ToString())
        Dim str As String = ""
        cmdbox.Invoke(Sub()
                          cmdbox.Text = translations.getText("dbContact") & "..." & translations.getText("waitBtn") & "."
                      End Sub)

        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "workers,nonvalidatedentries")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastline
        End If
        works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastline
        End If
        entries = request.ConvertDataToArray("nonvalidatedentries", state.queryNonValidatedEntriesFields, response)
        If IsNothing(entries) Then
            cmdbox.Invoke(Sub()
                              cmdbox.Text = cmdbox.Text & Environment.NewLine & "__________________________________________________________________________________________" & Environment.NewLine & translations.getText("recordsNotFound") & "." & translations.getText("EndOfSearch")
                          End Sub)
            Exit Sub
        End If
lastline:
        If errorFlag.Equals(True) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        cmdbox.Invoke(Sub()
                          cmdbox.Text = cmdbox.Text & "OK." & Environment.NewLine & Environment.NewLine
                      End Sub)

        cmdbox.Invoke(Sub()
                          cmdbox.Text = cmdbox.Text & translations.getText("recordsFound") & ":" & Environment.NewLine
                      End Sub)

        For i = 0 To entries.Item("cod_site").Count - 1
            For j = 0 To works_worker.Item("cod_worker").Count - 1
                If entries.Item("cod_worker")(i) = works_worker.Item("cod_worker")(j) Then
                    str = Environment.NewLine & works_worker.Item("name")(j) & " (" & entries.Item("date")(i) & ") " & translations.getText("site") & " " & entries.Item("name")(i)
                    Exit For
                End If
            Next j
            cmdbox.Invoke(Sub()
                              cmdbox.Text = cmdbox.Text & str
                          End Sub)
        Next i
        cmdbox.Invoke(Sub()
                          cmdbox.Text = cmdbox.Text & Environment.NewLine & "__________________________________________________________________________________________" & Environment.NewLine & translations.getText("EndOfSearch")
                      End Sub)
        duplicatesBtn.Invoke(Sub()
                                 duplicatesBtn.Text = translations.getText("startBtn")
                                 duplicatesBtn.Enabled = True
                             End Sub)
        nonValidatedBtn.Invoke(Sub()
                                   nonValidatedBtn.Text = translations.getText("startBtn")
                                   nonValidatedBtn.Enabled = True
                               End Sub)
    End Sub

End Class