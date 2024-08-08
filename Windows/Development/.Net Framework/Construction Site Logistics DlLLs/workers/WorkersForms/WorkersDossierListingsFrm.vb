Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class WorkersDossierListingsFrm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm

    Public Shared fieldsPos As String()
    Public Shared tipo As String = ""
    Public Shared fields As String(,)

    Private works_worker, works_category, works_entreprise, works_lodging, works_meals As Dictionary(Of String, List(Of String))

    Private mask As PictureBox = Nothing
    Private loaded As Boolean = False
    Private FieldsListSelection As New List(Of Integer)
    private mainForm As MainMdiForm
    Private tableData As DataTable

    Private WithEvents requestDataHttp As HttpDataPostData

    Public Shared Sub SetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        mainForm.doMenuAnimmation("form")
    End Sub
    Public Sub New(_mainMdiForm As MainMdiForm)
        mainForm = _mainMdiForm

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
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

        workersListSelection.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        available_fields.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        datatable.ColumnHeadersDefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Bold)
        datatable.DefaultCellStyle.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

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
        mainForm.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "6")
        vars.Add("request", "workers,categories,entreprises,meals,lodging")
        requestDataHttp.loadQueue(vars, Nothing)
        requestDataHttp.startRequest()
    End Sub

    Private Sub requestDataHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles requestDataHttp.dataArrived
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        If Not IsResponseOk(responseData) Then
            errorMsg = GetMessage(responseData)
            errorFlag = True
            GoTo lastLine
        End If
        works_worker = requestDataHttp.ConvertDataToArray("workers", stateCore.queryWorkersFields, responseData)
        If IsNothing(works_worker) Then
            errorMsg = requestDataHttp.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_category = requestDataHttp.ConvertDataToArray("categories", stateCore.queryWorkerCategoryFields, responseData)
        If IsNothing(works_category) Then
            errorMsg = requestDataHttp.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_entreprise = requestDataHttp.ConvertDataToArray("entreprises", stateCore.queryEntreprisePartnersFields, responseData)
        If IsNothing(works_entreprise) Then
            errorMsg = requestDataHttp.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_meals = requestDataHttp.ConvertDataToArray("meals", stateCore.queryWorkersMealsPlace, responseData)
        If IsNothing(works_meals) Then
            errorMsg = requestDataHttp.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_lodging = requestDataHttp.ConvertDataToArray("lodging", stateCore.queryWorkersLodgingPlace, responseData)
        If IsNothing(works_lodging) Then
            errorMsg = requestDataHttp.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            Exit Sub
        End If
        If errorFlag Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        mainForm.busy.Close(True)
        removeMask()
    End Sub
    Private Sub requestDataHttp_requestCompleted(sender As Object, responseData As String) Handles requestDataHttp.requestCompleted

    End Sub

    Sub loadTable()
        mask = New PictureBox
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Width = datatable.Width
        mask.Height = datatable.Height
        mask.Location = New Drawing.Point(datatable.Location.X, datatable.Location.Y)
        mask.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(mask)
        mask.BringToFront()

        Dim pos As Integer = -1

        ReDim fieldsPos(available_fields.SelectedIndices.Count - 1)

        For i = 0 To UBound(fields)
            For Each Index In available_fields.SelectedIndices
                If fields(i, 0).Equals(available_fields.Items(Index).ToString) Then
                    pos = pos + 1
                    fieldsPos(pos) = fields(i, 1)
                End If
            Next
        Next i

        If fieldsPos.Length > 0 Then
            tableData = New DataTable

            translations.load("workers")
            tableData.Columns.Add(translations.getText("workerName"), GetType(String))
            For i = 0 To UBound(fieldsPos)
                tableData.Columns.Add(fields(InArray(fields, fieldsPos(i), 1), 0))
            Next i

            Dim cols As Integer()
            Dim rows As Integer
            ReDim cols(fieldsPos.GetLength(0))
            Dim fontToMeasure As New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
            Dim sizeOfString As New SizeF
            Dim g As Graphics = Me.CreateGraphics
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
                Dim dr(tableData.Columns.Count - 1) As Object

                dr(0) = works_worker.Item("name")(i)

                For j = 0 To UBound(fieldsPos)
                    If fieldsPos(j).Equals("cod_category") Then ' cod cat
                        Dim s = works_worker.Item(fieldsPos(j))(i)
                        dr(j + 1) = works_category.Item("designation")(InQueryDictionary(works_category, works_worker.Item(fieldsPos(j))(i), "cod_category"))
                    ElseIf fieldsPos(j).Equals("cod_company") Then ' empresa
                        dr(j + 1) = works_entreprise.Item("name")(InQueryDictionary(works_entreprise, works_worker.Item(fieldsPos(j))(i), "cod_company"))
                    ElseIf fieldsPos(j).Equals("cod_lodging") Then ' lodging
                        dr(j + 1) = works_lodging.Item("name")(InQueryDictionary(works_lodging, works_worker.Item(fieldsPos(j))(i), "cod_lodging"))
                    ElseIf fieldsPos(j).Equals("cod_meal_place") Then ' meals
                        dr(j + 1) = works_meals.Item("name")(InQueryDictionary(works_meals, works_worker.Item(fieldsPos(j))(i), "cod_meal_place"))
                    ElseIf fieldsPos(j).Equals("estado_civil") Then
                        dr(j + 1) = estadoCivilList.ElementAt(works_worker.Item(fieldsPos(j))(i))
                    Else
                        dr(j + 1) = works_worker.Item(fieldsPos(j))(i)
                    End If

                    If cols(j) < works_worker.Item(fieldsPos(j))(i).Length Then
                        cols(j) = works_worker.Item(fieldsPos(j))(i).Length
                    End If
                    sizeOfString = g.MeasureString(works_worker.Item(fieldsPos(j))(i), fontToMeasure)
                    If sizeOfString.Height > rows Then
                        rows = sizeOfString.Height
                    End If
                Next j
            Next i

            SuspendLayout()
            With datatable
                .Visible = False
                .RowHeadersVisible = False
                .Columns(0).Width = 300

                For i = 0 To UBound(fieldsPos)
                    .Columns(i + 1).Width = fields(InArray(fields, fieldsPos(i), 1), 0).Length * 10
                Next i

                For j = 0 To UBound(fieldsPos) - 1
                    If .Columns(j + 1).Width < cols(j) * 8 Then
                        .Columns(j + 1).Width = cols(j) * 8
                    End If
                Next j

                For i = 0 To tableData.Rows.Count - 1
                    colMaxHEight = 0
                    newlines = 0
                    For j = 0 To datatable.Columns.Count - 1
                        If j > 0 Then
                            .Rows(i).Cells(j).ReadOnly = False
                        End If
                        sizeOfString = g.MeasureString(If(IsDBNull(tableData.Rows(i)(j)), " ", tableData.Rows(i)(j)), fontToMeasure)
                        lines = Math.Truncate(sizeOfString.Width / .Columns(j).Width) + 1
                        newlines = If(IsDBNull(tableData.Rows(i)(j)), " ", tableData.Rows(i)(j)).Split(Environment.NewLine).Length
                        lines = Math.Max(lines, newlines)
                        lines = If(lines.Equals(0), 1, lines)
                        If colMaxHEight < lines Then
                            colMaxHEight = lines
                        End If
                    Next j
                    .Rows(i).Height = g.MeasureString("F", fontToMeasure).Height * 1.15 * colMaxHEight
                Next i

                .Visible = True
            End With
        End If
        ResumeLayout()
        mask.Dispose()
        stateCore.datatableContents = tableData
    End Sub
End Class