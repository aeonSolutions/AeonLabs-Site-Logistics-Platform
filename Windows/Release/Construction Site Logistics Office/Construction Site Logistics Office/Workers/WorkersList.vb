Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Reflection

Public Class frm_worker_list
    Private state As State
    Private translations As languageTranslations
    Private msgbox As message_box_frm

    Public Shared fieldsPos As String()
    Public Shared currentDatatable As DataGridView
    Public Shared tipo As String = ""
    Public Shared fields As String(,)

    Private works_worker, works_category, works_entreprise, works_lodging, works_meals As Dictionary(Of String, List(Of String))
    Private response As String

    Private mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Private loaded As Boolean = False
    Private FieldsListSelection As New List(Of Integer)
    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        Me.Refresh()
    End Sub

    Private Sub frm_worker_list_show(sender As Object, e As EventArgs) Handles MyBase.Shown

        fields = {{"Código Cartão", "cod_nfc"}, {"Categoria Profissional", "cod_category"}, {"Empresa", "cod_entreprise"}, {"Naturalidade", "naturalidade"}, {"Concelho", "concelho"}, {"Contacto", "contact"}, {"Contacto de Emergência", "contact112"}, {"Data de Nascimento", "data_nascimento"}, {"Idade", "idade"},
            {"Estado Civil", "estado_civil"}, {"Nacionalidade", "nacionalidade"}, {"Cartão do Cidadão", "cc"}, {"Validade do Cartão do Cidadão", "cc_validade"}, {"NIF", "nif"}, {"NISS", "niss"}, {"Email", "email"}, {"Data Inicio de trabalho", "data_inicio_trabalho"},
            {"Morada", "morada"}, {"Alojamento", "cod_meal_place"}, {"NIB", "nib"}, {"Peso", "peso"}, {"Altura", "altura"}, {"Pé", "pe"}, {"Casaco", "casaco"}, {"Calças", "calcas"}, {"Contrato Trabalho Inicio", "contrato_inicio"}, {"Contrato Trabalho Fim", "contrato_fim"},
            {"Destacamento Inicio", "destacamento_inicio"}, {"Destacamento Fim", "destacamento_fim"}, {"ACT Inicio", "act_inicio"}, {"ACT Fim", "act_fim"}, {"A1 Inicio", "a1_inicio"}, {"A1 Fim", "a1_fim"}, {"Mutuelle", "mutuelle_inicio"}, {"Exame Médico", "medico_inicio"}, {"Cartão Europeu de Saúde", "csaude_validade"},
            {"Local de Refeição", "cod_meal_place"}, {"Numero do Quarto", "room"}}

        load_list()
    End Sub

    Private Sub frm_worker_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDoubleBuffered(datatable)
        loaded = False
        MainMdiForm.childForm = "listworkers"
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


        workersListSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        available_fields.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        datatable.Width = Me.Width - 10 - datatable.Location.X
        datatable.Height = Me.Height - 10 - datatable.Location.Y
        available_fields.Height = Me.Height - 10 - available_fields.Location.Y

        translations.load("workers")
        workersListSelection.Items.Add(translations.getText("workerActive"))
        workersListSelection.Items.Add(translations.getText("workerInactive"))
        workersListSelection.Items.Add(translations.getText("workerAll"))
        workersListSelection.SelectedIndex = 0

        Me.ResumeLayout()
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub SearchBoxBtn_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        If available_fields.Items.Count > 0 Then
            loadTable()
        End If
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

    Private Sub available_fields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles available_fields.SelectedIndexChanged
        TrackSelectionChange(available_fields)
    End Sub

    Private Sub TrackSelectionChange(ByVal lb As ListBox)
        Dim sic As ListBox.SelectedIndexCollection = lb.SelectedIndices

        For Each index As Integer In sic
            If Not FieldsListSelection.Contains(index) Then FieldsListSelection.Add(index)
        Next

        For Each index As Integer In New List(Of Integer)(FieldsListSelection)
            If Not sic.Contains(index) Then FieldsListSelection.Remove(index)
        Next
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
        vars.Add("request", "workers,categories,entreprises,meals,lodging")
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
        works_category = request.ConvertDataToArray("categories", state.queryWorkerCategoryFields, response)
        If IsNothing(works_category) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_entreprise = request.ConvertDataToArray("entreprises", state.queryEntreprisePartnersFields, response)
        If IsNothing(works_entreprise) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_meals = request.ConvertDataToArray("meals", state.queryWorkersMealsPlace, response)
        If IsNothing(works_meals) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_lodging = request.ConvertDataToArray("lodging", state.queryWorkersLodgingPlace, response)
        If IsNothing(works_lodging) Then
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
            MsgBox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            MsgBox.ShowDialog()
            Exit Sub
        End If
        removeMask()

    End Sub



    Sub loadTable()
        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()

        Dim pos As Integer = -1

        ReDim frm_worker_list.fieldsPos(available_fields.SelectedIndices.Count - 1)




        For i = 0 To UBound(fields)
            For Each Index In available_fields.SelectedIndices
                If fields(i, 0).Equals(available_fields.Items(Index).ToString) Then
                    pos = pos + 1
                    fieldsPos(pos) = fields(i, 1)
                End If
            Next
        Next i

        If fieldsPos.Length > 0 Then
            SuspendLayout()
            With datatable
                .Visible = False

                .RowHeadersVisible = False
                .ColumnCount = UBound(fieldsPos) + 2

                translations.load("workers")
                .Columns(0).HeaderCell.Value = translations.getText("workerName")
                .Columns(0).Width = 300

                For i = 0 To UBound(fieldsPos)
                    .Columns(i + 1).HeaderCell.Value = fields(InArray(fields, fieldsPos(i), 1), 0)
                    .Columns(i + 1).Width = fields(InArray(fields, fieldsPos(i), 1), 0).Length * 10

                Next i

                .Rows.Clear()
                .RowCount = works_worker.Item("cod_worker").Count - 1

                Dim cols As Integer()
                Dim rows As Integer
                ReDim cols(fieldsPos.GetLength(0))
                Dim fontToMeasure As New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
                Dim sizeOfString As New SizeF
                Dim g As Graphics = Me.CreateGraphics
                pos = 0
                Dim colMaxHEight As Integer = 0
                Dim lines As Integer = 0
                Dim newlines As Integer = 0

                Dim estadoCivilList As New List(Of String)
                translations.load("workers")
                estadoCivilList.Clear()
                estadoCivilList.Add(translations.getText("single"))
                estadoCivilList.Add(translations.getText("married"))
                estadoCivilList.Add(translations.getText("divorced"))
                estadoCivilList.Add(translations.getText("widow"))

                For i = 0 To works_worker.Item("cod_worker").Count - 1
                    If workersListSelection.SelectedIndex.Equals(0) And Not works_worker.Item("activo")(i).Equals("1") Then
                        Continue For
                    End If
                    If workersListSelection.SelectedIndex.Equals(1) And works_worker.Item("activo")(i).Equals("1") Then
                        Continue For
                    End If
                    .Rows(pos).Cells(0).Value = works_worker.Item("name")(i)
                    rows = 0
                    colMaxHEight = 0
                    newlines = 0
                    For j = 0 To UBound(fieldsPos)
                        If fieldsPos(j).Equals("cod_category") Then ' cod cat
                            Dim s = works_worker.Item(fieldsPos(j))(i)
                            .Rows(pos).Cells(j + 1).Value = works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item(fieldsPos(j))(i), "cod_category"))
                        ElseIf fieldsPos(j).Equals("cod_company") Then ' empresa
                            .Rows(pos).Cells(j + 1).Value = works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item(fieldsPos(j))(i), "cod_company"))
                        ElseIf fieldsPos(j).Equals("cod_lodging") Then ' lodging
                            .Rows(pos).Cells(j + 1).Value = works_lodging.Item("name")(InQueryDictionary(works_lodging, works_worker.Item(fieldsPos(j))(i), "cod_lodging"))
                        ElseIf fieldsPos(j).Equals("cod_meal_place") Then ' meals
                            .Rows(pos).Cells(j + 1).Value = works_meals.Item("name")(InQueryDictionary(works_meals, works_worker.Item(fieldsPos(j))(i), "cod_meal_place"))
                        ElseIf fieldsPos(j).Equals("estado_civil") Then
                            .Rows(pos).Cells(j + 1).Value = estadoCivilList.ElementAt(works_worker.Item(fieldsPos(j))(i))
                        Else
                            .Rows(pos).Cells(j + 1).Value = works_worker.Item(fieldsPos(j))(i)
                        End If
                        If cols(j) < works_worker.Item(fieldsPos(j))(i).Length Then
                            cols(j) = works_worker.Item(fieldsPos(j))(i).Length
                        End If
                        sizeOfString = g.MeasureString(works_worker.Item(fieldsPos(j))(i), fontToMeasure)
                        If sizeOfString.Height > rows Then
                            rows = sizeOfString.Height
                        End If
                    Next j
                    pos = pos + 1
                Next i

                For j = 0 To UBound(fieldsPos) - 1
                    If .Columns(j + 1).Width < cols(j) * 8 Then
                        .Columns(j + 1).Width = cols(j) * 8
                    End If
                Next j

                pos = 0
                For i = 1 To works_worker.Item("cod_worker").Count - 1
                    If workersListSelection.SelectedIndex.Equals(0) And Not works_worker.Item("activo")(i).Equals("1") Then
                        Continue For
                    End If
                    If workersListSelection.SelectedIndex.Equals(1) And works_worker.Item("activo")(i).Equals("1") Then
                        Continue For
                    End If
                    For j = 0 To UBound(fieldsPos) - 1
                        sizeOfString = g.MeasureString(works_worker.Item(fieldsPos(j))(i), fontToMeasure)
                        lines = Math.Round(sizeOfString.Width / .Columns(j).Width + 0.5, 0, MidpointRounding.AwayFromZero)
                        newlines = works_worker.Item(fieldsPos(j))(i).Split(Environment.NewLine).Length
                        lines = Math.Max(lines, newlines)
                        lines = If(lines.Equals(0), 1, lines)
                        If colMaxHEight < lines Then
                            colMaxHEight = lines
                        End If
                    Next j
                    .Rows(pos).Height = Math.Max(colMaxHEight, 20)
                    pos = pos + 1
                Next i
                .Visible = True

            End With
        End If
        ResumeLayout()
        mask.Dispose()
        currentDatatable = datatable
    End Sub
End Class