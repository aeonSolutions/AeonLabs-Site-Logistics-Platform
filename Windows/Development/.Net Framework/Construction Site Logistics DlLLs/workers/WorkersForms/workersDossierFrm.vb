Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries

Imports ConstructionSiteLogistics.SmartCards.GUI

Public Class workersDossierFrm
    Public Shared initializeSmartCardCodeID As String
    Public Shared works_worker As Dictionary(Of String, List(Of String))
    Public Shared posToLoad As Integer = -1

    Private works_entreprise, works_category, limosasDB, works_site, ausenciasDB, works_lodging, works_meals As Dictionary(Of String, List(Of String))
    Private works_classificacao As String(,)

    Private state As New environmentVars
    Private translations As languageTranslations
    Private msgbox As messageBoxForm
    Private mask As PictureBox = Nothing
    private mainForm As MainMdiForm

    Private control As Control
    Private QrCode As String = ""
    Private prevSelection As Integer = 0
    Private scrolling As Boolean = False
    Private taskRequest As String
    Private loaded As Boolean = False
    Private formClose As Boolean = False
    Private inactiveWorkerPosZero As Integer = 0
    Private WithEvents sendFilesHttp As HttpDataFilesUpload
    Private WithEvents sendPhotoHttp As HttpDataFilesUpload
    Private WithEvents getFilesHttp As HttpDataFilesDownload
    Private WithEvents DataRequests As IDataWorkersRequests
    Private WithEvents initializeSmartCardForm As initializeSmartCard
    Private WithEvents nfc_card As IsmartCard

    Private Sub CloseMe()
        Me.Close()
    End Sub
    Public Sub ClickHandler(sender As Object, e As MouseEventArgs)
        mainForm.doMenuAnimmation("form")
    End Sub
    Private Sub Form_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        e.Cancel = True
        formClose = True
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

    Private Sub drawControls()
        Dim fontToMeasure As New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Regular)
        Dim sizeOfString As New SizeF
        Dim g As Graphics = Me.CreateGraphics

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        mask.Refresh()
        Me.SuspendLayout()

        GroupBoxWorkers.Height = Me.Height - GroupBoxWorkers.Location.Y
        listview_works.Height = GroupBoxWorkers.Height - listview_works.Location.Y - 30
        workerMainWrapper.Width = Me.Width - workerMainWrapper.Location.X
        workerMainWrapper.MaximumSize = New Size(workerMainWrapper.Width, Me.Height - workerBottomWrapper.Height)
        workerMainWrapper.AutoScroll = True
        workerMainWrapper.VerticalScroll.Visible = False

        searchbox.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        workersListSelection.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        numWorkers.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        listview_works.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        'lbl
        SearchGroupBox.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        GroupBoxWorkers.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        WorkerFile_title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        mandatoryLbl.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        nome_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nfcCode_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        catPro_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        company_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        naturalidade_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        concelho_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contact112_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        dataNasc_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        age_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        estadoCivil_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        country_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cc_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cc_valid_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nif_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        niss_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        kids_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        kids_num_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        kidsEnc_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        kidsEnc_num_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        WorkStartDate_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        classification_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        location_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        salary_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        refeicao_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        acusto_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        morada_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        probSaude_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        quais_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        lodging_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        quartolbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        placeMeals_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nib_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        peso_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        altura_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calcas_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        pe_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        casaco_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        activolbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        notes_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        docs_title_lbl.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Regular)
        inicio_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        fim_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        file_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contrato_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamento_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        act_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        a1_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mutuelle_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        medic_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        validade_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        csaude_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cc_file_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        gruista_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosas_lbl.Font = New Font(state.fontText.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        delWorkerCard.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveWorkerCard.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        addCalendarDateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosaStartDate_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosaValidTo_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosaSite_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        'boxes
        txt_name.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        txt_nfc.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_catpro.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        combo_empresa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        naturalidade.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        concelho.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        txt_mobile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        txt_112.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        datanascimento_txt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        idade_txt.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        estadoCivil.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nacionalidade.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cartaocidadao.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ccvalidoate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nif.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        niss.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        filhos.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        quantosfilhos.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        filhosenc.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        filhosencquantos.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        datainiciotrabalho.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        classificacao.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        localizacao.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        salario.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        refeicao.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ajudascusto.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        morada.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        probsaudequais.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        alojamento.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        quarto.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        refeicoes.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nib.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        peso.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        altura.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calcas.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        pe.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        casaco.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        activodate.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        notas.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contratoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contratoFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamentoInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamentoFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        actInicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        actFim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        a1Inicio.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        a1Fim.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mutuelle.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        medico.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        csaudevalidade.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contratofile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamentofile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamentoactfile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        a1file.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mutuellefile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        medicofile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        csaudefile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ccfile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        gruistaFile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        contractFileBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        destacamentoBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        actBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        a1Btn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mutuelleBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        medicBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cseBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        ccBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        cranemanBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosaList.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        obra.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoInicioLimosa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        duracaoFimLimosa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        limosafile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        btn_limosa.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        delWorkerCard.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        saveWorkerCard.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        calendar.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        contractFileBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        destacamentoBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        actBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        a1Btn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        mutuelleBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        medicBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        cseBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        ccBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        cranemanBtn.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        btn_limosa.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        salario_euro_mes.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        refeicao_euro_mes.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        saveNewCard.Font = New Font(state.fontText.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)

        contractFileBtn.BackColor = state.buttonColor
        destacamentoBtn.BackColor = state.buttonColor
        actBtn.BackColor = state.buttonColor
        a1Btn.BackColor = state.buttonColor
        mutuelleBtn.BackColor = state.buttonColor
        medicBtn.BackColor = state.buttonColor
        cseBtn.BackColor = state.buttonColor
        ccBtn.BackColor = state.buttonColor
        cranemanBtn.BackColor = state.buttonColor
        btn_limosa.BackColor = state.buttonColor

        delWorkerCard.BackColor = state.buttonColor
        saveWorkerCard.BackColor = state.buttonColor
        limosa_divider.BackColor = state.dividerColor
        docs_divider.BackColor = state.dividerColor
        workerFile_divider.BackColor = state.dividerColor

        translations.load("smartcard")
        saveNewCard.Text = translations.getText("newCard")

        numWorkers.Text = "- -"
        translations.load("commonForm")
        SearchGroupBox.Text = translations.getText("SearchBoxTitle")
        addCalendarDateLink.Text = translations.getText("addCalendarDateLink")
        mandatoryLbl.Text = translations.getText("mandatoryFields")
        notes_lbl.Text = translations.getText("AnnotationTitle")
        inicio_lbl.Text = translations.getText("dateStartTitle")
        fim_lbl.Text = translations.getText("dateEndTitle")
        delWorkerCard.Text = translations.getText("delLink")
        saveWorkerCard.Text = translations.getText("saveLink")
        limosaStartDate_lbl.Text = translations.getText("dateStartTitle")
        limosaValidTo_lbl.Text = translations.getText("dateValidTo")
        contractFileBtn.Text = translations.getText("chooseBtn")
        destacamentoBtn.Text = translations.getText("chooseBtn")
        actBtn.Text = translations.getText("chooseBtn")
        a1Btn.Text = translations.getText("chooseBtn")
        mutuelleBtn.Text = translations.getText("chooseBtn")
        medicBtn.Text = translations.getText("chooseBtn")
        cseBtn.Text = translations.getText("chooseBtn")
        ccBtn.Text = translations.getText("chooseBtn")
        cranemanBtn.Text = translations.getText("chooseBtn")
        btn_limosa.Text = translations.getText("chooseBtn")

        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(workersUpdateBtn, translations.getText("updateLink"))

        Dim DownloadToolTip As New ToolTip()
        DownloadToolTip.SetToolTip(download, translations.getText("downloadLink"))

        Dim saveToolTip As New ToolTip()
        saveToolTip.SetToolTip(save_limosa, translations.getText("saveLink"))

        Dim delimToolTip As New ToolTip()
        delimToolTip.SetToolTip(del_limosa, translations.getText("delLink"))

        Dim delToolTip As New ToolTip()
        delToolTip.SetToolTip(del_files, translations.getText("delLink"))

        translations.load("workers")
        limosaSite_lbl.Text = translations.getText("constructionSite")
        workersListSelection.Items.Add(translations.getText("workerActive"))
        workersListSelection.Items.Add(translations.getText("workerInactive"))
        workersListSelection.Items.Add(translations.getText("workerAll"))
        workersListSelection.SelectedIndex = 0

        GroupBoxWorkers.Text = translations.getText("workersRecordTitle")
        WorkerFile_title.Text = translations.getText("workerFileTitle")
        nome_lbl.Text = translations.getText("name") & "*"
        nfcCode_lbl.Text = translations.getText("smartCardCode") & "*"
        catPro_lbl.Text = translations.getText("professionalCategories") & "*"
        company_lbl.Text = translations.getText("company") & "*"
        naturalidade_lbl.Text = translations.getText("placeOfBirth") & "*"
        concelho_lbl.Text = translations.getText("state") & "*"
        contact_lbl.Text = translations.getText("contact") & "*"
        contact112_lbl.Text = translations.getText("emergencyContact")
        dataNasc_lbl.Text = translations.getText("dateBirth") & "*"
        age_lbl.Text = translations.getText("age") & "*"
        estadoCivil_lbl.Text = translations.getText("marriageStatus")
        country_lbl.Text = translations.getText("nationality") & "*"
        cc_lbl.Text = translations.getText("citizenCard") & "*"
        cc_valid_lbl.Text = translations.getText("ccExpireDate") & "*"
        nif_lbl.Text = translations.getText("irsNumber") & "*"
        niss_lbl.Text = translations.getText("socialSecurityNumber") & "*"
        kids_lbl.Text = translations.getText("kids")
        kids_num_lbl.Text = translations.getText("howMany")
        kidsEnc_lbl.Text = translations.getText("kidsCharge")
        kidsEnc_num_lbl.Text = translations.getText("howMany")
        email_lbl.Text = translations.getText("email")
        WorkStartDate_lbl.Text = translations.getText("workStartDate") & "*"
        classification_lbl.Text = translations.getText("classification") & "*"
        location_lbl.Text = translations.getText("location") & "*"
        salary_lbl.Text = translations.getText("salary")
        refeicao_lbl.Text = translations.getText("meal")
        acusto_lbl.Text = translations.getText("perDiems")
        morada_lbl.Text = translations.getText("address")
        probSaude_lbl.Text = translations.getText("healthProblems")
        quais_lbl.Text = translations.getText("whichOnes") & " ?"
        lodging_lbl.Text = translations.getText("lodging")
        quartolbl.Text = translations.getText("room")
        placeMeals_lbl.Text = translations.getText("placeMeals")
        nib_lbl.Text = translations.getText("bankAccountNumber")
        peso_lbl.Text = translations.getText("weight")
        altura_lbl.Text = translations.getText("height")
        calcas_lbl.Text = translations.getText("pants")
        pe_lbl.Text = translations.getText("foot")
        casaco_lbl.Text = translations.getText("jacket")
        activolbl.Text = translations.getText("active")
        docs_title_lbl.Text = translations.getText("documentsTitle")
        file_lbl.Text = translations.getText("fileTitle")
        contrato_lbl.Text = translations.getText("contract")
        destacamento_lbl.Text = translations.getText("secondment")
        act_lbl.Text = translations.getText("act")
        a1_lbl.Text = translations.getText("a1")
        mutuelle_lbl.Text = translations.getText("healthInsurance")
        medic_lbl.Text = translations.getText("medic")
        validade_lbl.Text = translations.getText("expireDate")
        csaude_lbl.Text = translations.getText("healthCard")
        cc_file_lbl.Text = translations.getText("citizenCard")
        gruista_lbl.Text = translations.getText("craneman")
        limosas_lbl.Text = translations.getText("limosasTitle")
        salario_euro_mes.Text = translations.getText("euroMonth")
        refeicao_euro_mes.Text = translations.getText("euroMonth")
        nfc_auth_code_lbl.Text = translations.getText("cardAuthCode") & "*"

        saveNewCard.Enabled = False

        Me.ResumeLayout()
        Refresh()
    End Sub

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub workers_frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        state = state
        translations = New languageTranslations(state)
        mainForm.childForm = "workers"
        delWorkerCard.Enabled = False
        loadForm.Enabled = True

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()
    End Sub
    Private Sub loadForm_Tick(sender As Object, e As EventArgs) Handles loadForm.Tick
        loadForm.Enabled = False
        drawControls()
    End Sub

    Private Sub workers_frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            DataRequests = DirectCast(loadDllObject(state, "workers.dll", "workersDataRequests"), IDataWorkersRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            mainForm.NoNetwork()
            Me.Close()
            Exit Sub
        End If

        Try
            nfc_card = DirectCast(loadDllObject(state, "contactless.smartcards.dll", "smartCard"), IsmartCard)
        Catch ex As Exception
            nfc_card = Nothing
        End Try
        If nfc_card Is Nothing Then
            mainForm.statusMessage = "DLL file not found"
            mainForm.busy.Close(True)
            mainForm.NoNetwork()
            Me.Close()
            Exit Sub
        End If

        load_list()
        If (Directory.Exists(state.basePath & "tmp")) Then
            For Each deleteFile In Directory.GetFiles(state.basePath & "tmp", "*.*", SearchOption.TopDirectoryOnly)
                File.Delete(deleteFile)
            Next
        Else
            Try
                Directory.CreateDirectory(state.basePath & "tmp")
            Catch ex As Exception
                msgbox = New messageBoxForm("tem que criar manualmente a pasta: " & vbCrLf & state.basePath & "tmp", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                msgbox.ShowDialog()
            End Try
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
        mask.Dispose()
        Refresh()
        Me.ResumeLayout()
        Refresh()
    End Sub


    Sub load_list()
        loaded = False
        mainForm.busy.Show()
        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "categories,entreprises,sites,meals,lodging,workers")
        DataRequests.Initialise(state)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadWorkersInitialData()
    End Sub

    Private Sub DataRequests_getResponseWorkersInitialData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseWorkersInitialData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
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
        works_site = request.ConvertDataToArray("sites", state.querySiteFields, response)
        If IsNothing(works_site) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If
        works_meals = request.ConvertDataToArray("meals", state.queryWorkersMealsPlace, response)
        If IsNothing(works_meals) Then
            errorMsg = request.errorMessage
            errorFlag = True
        End If
        works_lodging = request.ConvertDataToArray("lodging", state.queryWorkersLodgingPlace, response)
        If IsNothing(works_lodging) Then
            errorMsg = request.errorMessage
            errorFlag = True
        End If
        works_worker = request.ConvertDataToArray("workers", state.queryWorkersFields, response)
        If IsNothing(works_worker) Then
            errorMsg = request.errorMessage
            errorFlag = True
        End If

        ReDim works_classificacao(20, 4)
        works_classificacao(0, 0) = "" ' designacao
        works_classificacao(0, 1) = "" ' continente
        works_classificacao(0, 2) = "" ' madeira
        works_classificacao(0, 3) = "" ' acores
        works_classificacao(1, 0) = "Tec. Sup. de Seg. e Higiene no trabalho (grua III)"
        works_classificacao(1, 1) = "895"
        works_classificacao(1, 2) = "895"
        works_classificacao(1, 3) = "895"
        works_classificacao(2, 0) = "Encarregado Geral"
        works_classificacao(2, 1) = "795"
        works_classificacao(2, 2) = "795"
        works_classificacao(2, 3) = "795"
        works_classificacao(3, 0) = "Encarregado de primeira"
        works_classificacao(3, 1) = "668"
        works_classificacao(3, 2) = "668"
        works_classificacao(3, 3) = "668"
        works_classificacao(4, 0) = "Encarregado de segunda"
        works_classificacao(4, 1) = "620"
        works_classificacao(4, 2) = "620"
        works_classificacao(4, 3) = "630"
        works_classificacao(5, 0) = "Chefe de equipa"
        works_classificacao(5, 1) = "602"
        works_classificacao(5, 2) = "615"
        works_classificacao(5, 3) = "630"
        works_classificacao(6, 0) = "Oficial de primeira"
        works_classificacao(6, 1) = "602"
        works_classificacao(6, 2) = "615"
        works_classificacao(6, 3) = "630"
        works_classificacao(7, 0) = "Armador de ferro"
        works_classificacao(7, 1) = "600"
        works_classificacao(7, 2) = "615"
        works_classificacao(7, 3) = "630"
        works_classificacao(8, 0) = "Carpinteiro de limpo primeira"
        works_classificacao(8, 1) = "600"
        works_classificacao(8, 2) = "615"
        works_classificacao(8, 3) = "630"
        works_classificacao(9, 0) = "Carpinteiro de tosco ou cofragem de primeira"
        works_classificacao(9, 1) = "600"
        works_classificacao(9, 2) = "615"
        works_classificacao(9, 3) = "630"
        works_classificacao(10, 0) = "Pedreiro de primeira"
        works_classificacao(10, 1) = "600"
        works_classificacao(10, 2) = "615"
        works_classificacao(10, 3) = "630"
        works_classificacao(11, 0) = "Pintor de primeira"
        works_classificacao(11, 1) = "600"
        works_classificacao(11, 2) = "615"
        works_classificacao(11, 3) = "630"
        works_classificacao(12, 0) = "Trolha ou pedreiro de acabamentos primeira"
        works_classificacao(12, 1) = "600"
        works_classificacao(12, 2) = "615"
        works_classificacao(12, 3) = "630"
        works_classificacao(13, 0) = "Armador de ferro de segunda"
        works_classificacao(13, 1) = "600"
        works_classificacao(13, 2) = "615"
        works_classificacao(13, 3) = "630"
        works_classificacao(14, 0) = "Carpinteiro de limpo de segunda"
        works_classificacao(14, 1) = "600"
        works_classificacao(14, 2) = "615"
        works_classificacao(14, 3) = "630"
        works_classificacao(15, 0) = "Carpinteiro de tosco ou cofragem segunda"
        works_classificacao(15, 1) = "600"
        works_classificacao(15, 2) = "615"
        works_classificacao(15, 3) = "630"
        works_classificacao(16, 0) = "Pedreiro de segunda"
        works_classificacao(16, 1) = "600"
        works_classificacao(16, 2) = "615"
        works_classificacao(16, 3) = "630"
        works_classificacao(17, 0) = "Trolha ou pedreiro de acabamentos segunda"
        works_classificacao(17, 1) = "600"
        works_classificacao(17, 2) = "615"
        works_classificacao(17, 3) = "630"
        works_classificacao(18, 0) = "Condutor manobrador de equipamentos industriais"
        works_classificacao(18, 1) = "600"
        works_classificacao(18, 2) = "615"
        works_classificacao(18, 3) = "630"
        works_classificacao(19, 0) = "Servente"
        works_classificacao(19, 1) = "600"
        works_classificacao(19, 2) = "615"
        works_classificacao(19, 3) = "630"
        works_classificacao(19, 0) = "Outro"
        works_classificacao(19, 1) = ""
        works_classificacao(19, 2) = ""
        works_classificacao(19, 3) = ""

lastLine:
        Static start As Double
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            removeMask()
            Exit Sub
        End If
        If errorFlag Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(errorMsg) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            removeMask()
            Exit Sub
        End If

        Dim Counter As Integer = 0
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            If (Not works_worker.Item("activo")(i).Equals("0")) Then
                Counter = Counter + 1
            End If
        Next i
        translations.load("workers")
        numWorkers.Text = translations.getText("workersOnDatabase") & " : " & works_worker.Item("cod_worker").Count & Environment.NewLine & translations.getText("active").ToLower & ":" & Counter
        SuspendLayout()
        translations.load("workers")
        estadoCivil.Items.Clear()
        estadoCivil.Items.Add(translations.getText("single"))
        estadoCivil.Items.Add(translations.getText("married"))
        estadoCivil.Items.Add(translations.getText("divorced"))
        estadoCivil.Items.Add(translations.getText("widow"))
        estadoCivil.SelectedIndex = 0

        translations.load("commonForm")
        filhosenc.Items.Clear()
        filhosenc.Items.Add(translations.getText("yes"))
        filhosenc.Items.Add(translations.getText("no"))
        filhosenc.SelectedIndex = 0

        probsaude.Items.Clear()
        probsaude.Items.Add(translations.getText("yes"))
        probsaude.Items.Add(translations.getText("no"))
        probsaude.SelectedIndex = 0

        filhos.Items.Clear()
        filhos.Items.Add(translations.getText("yes"))
        filhos.Items.Add(translations.getText("no"))
        filhos.SelectedIndex = 0

        obra.Items.Clear()
        obra.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_site.Item("cod_site").Count - 1
            obra.Items.Add(works_site.Item("name")(i))
        Next
        obra.SelectedIndex = 0

        combo_catpro.Items.Clear()
        combo_catpro.Items.Add(translations.getText("dropdownSelectCategories"))
        For i = 0 To works_category.Item("cod_category").Count - 1
            combo_catpro.Items.Add(works_category.Item("designation")(i))
        Next
        combo_catpro.SelectedIndex = 0

        combo_empresa.Items.Clear()
        combo_empresa.Items.Add(translations.getText("dropdownSelectCompany"))
        For i = 0 To works_entreprise.Item("cod_entreprise").Count - 1
            combo_empresa.Items.Add(works_entreprise.Item("name")(i))
        Next
        combo_empresa.SelectedIndex = 0

        alojamento.Items.Clear()
        For i = 0 To works_lodging.Item("cod_lodging").Count - 1
            alojamento.Items.Add(works_lodging.Item("name")(i))
        Next
        alojamento.SelectedIndex = 0

        refeicoes.Items.Clear()
        For i = 0 To works_meals.Item("cod_meal_place").Count - 1
            refeicoes.Items.Add(works_meals.Item("name")(i))
        Next
        refeicoes.SelectedIndex = 0

        translations.load("workers")
        listview_works.Items.Clear()
        listview_works.Items.Add(translations.getText("dropdownAddNewWorker"))
        For i = 0 To works_worker.Item("cod_worker").Count - 1
            If workersListSelection.SelectedIndex.Equals(0) And works_worker.Item("activo")(i).Equals("1") Then
                listview_works.Items.Add(works_worker.Item("name")(i))
            ElseIf workersListSelection.SelectedIndex.Equals(1) And works_worker.Item("activo")(i).Equals("0") Then
                If inactiveWorkerPosZero.Equals(0) Then
                    inactiveWorkerPosZero = i
                End If
                listview_works.Items.Add(works_worker.Item("name")(i))
            ElseIf workersListSelection.SelectedIndex.Equals(2) Then
                listview_works.Items.Add(works_worker.Item("name")(i))
            End If
        Next i

        classificacao.Items.Clear()
        classificacao.Items.Add(translations.getText("dropdownSelectCategoryClassification"))
        For i = 1 To 19
            classificacao.Items.Add(works_classificacao(i, 0))
        Next
        classificacao.SelectedIndex = 0

        filhos.SelectedIndex = 0
        filhosenc.SelectedIndex = 0
        estadoCivil.SelectedIndex = 0
        probsaude.SelectedIndex = 0
        alojamento.SelectedIndex = 0
        localizacao.SelectedIndex = 0

        photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.png"))
        contratoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        destacamentoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        actImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        a1Img.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        mutuelleImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        medicoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        gruistaImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        removeMask()
        Me.ResumeLayout()
        Refresh()
        loaded = True
        mainForm.busy.Close(True)
    End Sub

    Private Sub workersUpdateBtn_Click(sender As Object, e As EventArgs) Handles workersUpdateBtn.Click
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        mask.Refresh()
        listview_works.Items.Clear()
        load_list()

    End Sub

    Private Sub delWorkerCard_Click(sender As Object, e As EventArgs) Handles delWorkerCard.Click
        Dim messageTxt As String
        If listview_works.SelectedIndex < 1 Then
            translations.load("errorMessages")
            messageTxt = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If workersListSelection.SelectedIndex.Equals(0) Then
            posToLoad = listview_works.SelectedIndices(0) - 1
        ElseIf workersListSelection.SelectedIndex.Equals(1) Then
            posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
        Else
            posToLoad = listview_works.SelectedIndices(0) - 1
        End If
        translations.load("workers")
        messageTxt = translations.getText("deleteWorkerFile")
        translations.load("messagebox")
        msgbox = New messageBoxForm(messageTxt & ", " & works_worker.Item("name")(posToLoad) & "?", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.OK) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("type", "delworker")
            vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
            taskRequest = "del"
            DataRequests.Initialise(state)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveWorkersData()
        End If
    End Sub

    Private Sub DataRequests_getResponseSaveWorkersData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveWorkersData
        Dim response As String = args.responseData

        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        Else
            prevSelection = 0
            translations.load("messagebox")
            Dim messageTxt As String = translations.getText("resultSuccessSaveRecord")
            msgbox = New messageBoxForm(messageTxt, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        If taskRequest.Equals("edit") Then
            Dim cod As String = GetMessageField(response, "code")
            If (listview_works.SelectedItems.Count > 0) Then
                If listview_works.SelectedIndices(0) > 0 Then 'edit worker
                    If Not cod.Equals(works_worker.Item("cod_worker")(posToLoad)) Then
                        translations.load("errorMessages")
                        Dim messageTxt As String = translations.getText("errorSavingData")
                        translations.load("messagebox")
                        msgbox = New messageBoxForm(messageTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                        msgbox.ShowDialog()
                        Exit Sub
                    End If
                End If
            End If

            sendFilesHttp = New HttpDataFilesUpload(state)
            Dim vars As New Dictionary(Of String, String)
            If (File.Exists(contratofile.Text)) Then
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "contrato")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, contratofile.Text)
            End If
            If (File.Exists(destacamentoactfile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "destacamento")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, destacamentoactfile.Text)
            End If
            If (File.Exists(a1file.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "a1")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, a1file.Text)
            End If
            If (File.Exists(mutuellefile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "mutuelle")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, mutuellefile.Text)
            End If
            If (File.Exists(medicofile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "medico")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, medicofile.Text)
            End If
            If (File.Exists(gruistaFile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "gruista")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, gruistaFile.Text)
            End If
            If (File.Exists(ccfile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "cc")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, ccfile.Text)
            End If
            If (File.Exists(csaudefile.Text)) Then
                vars = New Dictionary(Of String, String)
                vars.Add("task", state.taskId("workerDossier"))
                vars.Add("request", "addworkerfile")
                vars.Add("file", "csaude")
                vars.Add("user", cod)
                sendFilesHttp.loadQueue(vars, Nothing, csaudefile.Text)
            End If
            sendFilesHttp.startRequest()
        End If

        mainForm.busy.Close(True)
        ClearForm()
        load_list()
        taskRequest = ""
    End Sub
    Private Sub sendFilesHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles sendFilesHttp.dataArrived
        If Not IsResponseOk(responseData) Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            mainForm.statusMessage = "file sent successfully"
        End If
    End Sub
    Private Sub sendFilesHttp_requestCompleted(sender As Object, responseData As String) Handles sendFilesHttp.requestCompleted

    End Sub

    Private Sub saveWorkerCard_Click(sender As Object, e As EventArgs) Handles saveWorkerCard.Click

        Dim ValidationRequired As Boolean = False
        Dim err As String = ""
        Dim messageTxt As String

        If listview_works.SelectedIndex < 0 Then
            translations.load("errorMessages")
            messageTxt = translations.getText("errorSelectWorker")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("workers")
        If (txt_name.Text = "") Then
            ValidationRequired = True
            txt_name.Focus()
            err = translations.getText("name")
        ElseIf (txt_nfc.Text = "") Then
            ValidationRequired = True
            txt_nfc.Focus()
            err = translations.getText("smartCardCode")
        ElseIf (nfc_auth_code.Text = "") Then
            ValidationRequired = True
            txt_nfc.Focus()
            err = translations.getText("cardAuthCode")
        ElseIf (combo_catpro.SelectedIndex = 0) Then
            ValidationRequired = True
            combo_catpro.Focus()
            err = translations.getText("professionalCategories")
        ElseIf (combo_empresa.SelectedIndex = 0) Then
            ValidationRequired = True
            combo_empresa.Focus()
            err = translations.getText("company")
        ElseIf (naturalidade.Text = "") Then
            ValidationRequired = True
            naturalidade.Focus()
            err = translations.getText("nationality")
        ElseIf (concelho.Text = "") Then
            ValidationRequired = True
            concelho.Focus()
            err = translations.getText("state")
        ElseIf (txt_mobile.Text = "") Then
            ValidationRequired = True
            txt_mobile.Focus()
            err = translations.getText("contact")
        ElseIf (Not IsDate(datanascimento_txt.Text)) Then
            ValidationRequired = True
            datanascimento_txt.Focus()
            err = translations.getText("dateBirth")
        ElseIf (idade_txt.Text = "") Then
            ValidationRequired = True
            idade_txt.Focus()
            err = translations.getText("age")
        ElseIf (nacionalidade.Text = "") Then
            ValidationRequired = True
            nacionalidade.Focus()
            err = translations.getText("country")
        ElseIf (cartaocidadao.Text = "") Then
            ValidationRequired = True
            cartaocidadao.Focus()
            err = translations.getText("citizenCard")
        ElseIf (Not IsDate(ccvalidoate.Text)) Then
            ValidationRequired = True
            ccvalidoate.Focus()
            err = translations.getText("ccExpireDate")
        ElseIf (nif.Text = "" And Not IsNumeric(nif.Text)) Then
            ValidationRequired = True
            nif.Focus()
            err = translations.getText("irsNumber")
        ElseIf (niss.Text = "" And Not IsNumeric(niss.Text)) Then
            ValidationRequired = True
            niss.Focus()
            err = translations.getText("socialSecurityNumber")
        ElseIf ((quantosfilhos.Text = "" Or Not IsNumeric(quantosfilhos.Text)) And filhos.SelectedIndex = 1) Then
            ValidationRequired = True
            quantosfilhos.Focus()
            err = translations.getText("kids")
        ElseIf ((filhosencquantos.Text = "" Or Not IsNumeric(filhosencquantos.Text)) And filhosenc.SelectedIndex = 1) Then
            ValidationRequired = True
            filhosencquantos.Focus()
            err = translations.getText("kidsCharge")
        ElseIf (email.Text.Equals("") Or IsValidEmailFormat(email.Text).Equals(False)) Then
            ValidationRequired = True
            email.Focus()
            err = translations.getText("email")
        ElseIf (Not IsDate(datainiciotrabalho.Text)) Then
            ValidationRequired = True
            datainiciotrabalho.Focus()
            err = translations.getText("workStartDate")
        ElseIf (classificacao.SelectedIndex = 0) Then
            ValidationRequired = True
            classificacao.Focus()
            err = translations.getText("classification")
        ElseIf (salario.Text = "" And Not IsNumeric(salario.Text)) Then
            ValidationRequired = True
            salario.Focus()
            err = translations.getText("salary")
        ElseIf (refeicao.Text = "" And Not IsNumeric(refeicao.Text)) Then
            ValidationRequired = True
            refeicao.Focus()
            err = translations.getText("placeMeals")
        ElseIf (ajudascusto.Text = "" And Not IsNumeric(ajudascusto.Text)) Then
            ValidationRequired = True
            ajudascusto.Focus()
            err = translations.getText("perDiems")
        ElseIf (morada.Text = "") Then
            ValidationRequired = True
            morada.Focus()
            err = translations.getText("address")
        ElseIf (probsaudequais.Text = "" And probsaude.SelectedIndex = 1) Then
            ValidationRequired = True
            probsaudequais.Focus()
            err = translations.getText("healthProblems")
        ElseIf (nib.Text = "") Then
            ValidationRequired = True
            nib.Focus()
            err = translations.getText("bankAccountNumber")
        ElseIf (Not IsDate(contratoInicio.Text) And contratoInicio.Text <> "") Then
            ValidationRequired = True
            contratoInicio.Focus()
            err = translations.getText("contract")
        ElseIf (Not IsDate(contratoFim.Text) And contratoFim.Text <> "") Then
            ValidationRequired = True
            contratoFim.Focus()
            err = translations.getText("contract")
        ElseIf (Not IsDate(destacamentoFim.Text) And destacamentoFim.Text <> "") Then
            ValidationRequired = True
            destacamentoFim.Focus()
            err = translations.getText("secondment")
        ElseIf (Not IsDate(destacamentoInicio.Text) And destacamentoInicio.Text <> "") Then
            ValidationRequired = True
            destacamentoInicio.Focus()
            err = translations.getText("secondment")
        ElseIf (Not IsDate(actInicio.Text) And actInicio.Text <> "") Then
            ValidationRequired = True
            actInicio.Focus()
            err = translations.getText("act")
        ElseIf (Not IsDate(actFim.Text) And actFim.Text <> "") Then
            ValidationRequired = True
            actFim.Focus()
            err = translations.getText("act")
        ElseIf (Not IsDate(a1Inicio.Text) And a1Inicio.Text <> "") Then
            ValidationRequired = True
            a1Inicio.Focus()
            err = translations.getText("a1")
        ElseIf (Not IsDate(a1Fim.Text) And a1Fim.Text <> "") Then
            ValidationRequired = True
            a1Fim.Focus()
            err = translations.getText("a1")
        ElseIf (Not IsDate(mutuelle.Text) And mutuelle.Text <> "") Then
            ValidationRequired = True
            mutuelle.Focus()
            err = translations.getText("healthInsurance")
        ElseIf (Not IsDate(medico.Text) And medico.Text <> "") Then
            ValidationRequired = True
            medico.Focus()
            err = translations.getText("medic")
        ElseIf (Not IsDate(activodate.Text) And activodate.Text <> "") Then
            ValidationRequired = True
            activodate.Focus()
            err = translations.getText("active")
        ElseIf (Not IsDate(csaudevalidade.Text) And csaudevalidade.Text <> "") Then
            ValidationRequired = True
            csaudevalidade.Focus()
            err = translations.getText("citizenCard")
        End If

        If workersListSelection.SelectedIndex.Equals(0) Then
            posToLoad = listview_works.SelectedIndices(0) - 1
        ElseIf workersListSelection.SelectedIndex.Equals(1) Then
            posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
        Else
            posToLoad = listview_works.SelectedIndices(0) - 1
        End If

        If (listview_works.SelectedItems.Count > 0) Then
            For i = 0 To works_worker.Item("cod_worker").Count - 1
                If works_worker.Item("cod_nfc")(i).Equals(txt_nfc.Text) And Not txt_nfc.Text.Equals("0") And Not posToLoad.Equals(i) Then
                    ValidationRequired = True
                    translations.load("errorMessages")
                    err = translations.getText("errorNFCcodeAlreadyExists") & " ( " & works_worker.Item("name")(i) & " )"
                    txt_nfc.Focus()
                End If
            Next i
        End If

        If (ValidationRequired) Then
            translations.load("workers")
            messageTxt = translations.getText("errorFields")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt & ", " & err & ".", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            Dim aloja As String = ""
            Dim ativ As String = ""


            If filhos.SelectedIndex = 0 Then
                quantosfilhos.Text = "0"
            End If
            If filhosenc.SelectedIndex = 0 Then
                filhosencquantos.Text = "0"
            End If
            If probsaude.SelectedIndex = 0 Then
                probsaudequais.Text = "0"
            End If
            If (peso.Text = "") Then
                peso.Text = "0"
            End If
            If (altura.Text = "") Then
                altura.Text = "0"
            End If
            If (calcas.Text = "") Then
                calcas.Text = "0"
            End If
            If (pe.Text = "") Then
                pe.Text = "0"
            End If
            If (casaco.Text = "") Then
                casaco.Text = "0"
            End If
            If (txt_112.Text = "") Then
                txt_112.Text = "0"
            End If
            If (email.Text = "") Then
                email.Text = "0"
            End If
            If ativo.Checked Then
                ativ = "1"
            Else
                ativ = "0"
            End If

            If (quarto.Text.Equals("")) Then
                quarto.Text = "s/reg."
            End If

            Dim vars As New Dictionary(Of String, String)
            vars.Add("type", "addworker")
            If (listview_works.SelectedItems.Count > 0) Then
                If listview_works.SelectedIndices(0) > 0 Then 'edit worker
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                End If
            End If
            vars.Add("medico", medico.Text)
            vars.Add("mutuelle", mutuelle.Text)
            vars.Add("a1inicio", a1Inicio.Text)
            vars.Add("a1fim", a1Fim.Text)
            vars.Add("actinicio", actInicio.Text)
            vars.Add("actfim", actFim.Text)
            vars.Add("catpro", works_category.Item("cod_category")(combo_catpro.SelectedIndex - 1))
            vars.Add("entreprise", works_entreprise.Item("cod_entreprise")(combo_empresa.SelectedIndex - 1))
            vars.Add("datainicio", datainiciotrabalho.Text)
            vars.Add("datanasc", datanascimento_txt.Text)
            vars.Add("calcas", calcas.Text)
            vars.Add("casaco", casaco.Text)
            vars.Add("pe", pe.Text)
            vars.Add("altura", altura.Text)
            vars.Add("peso", peso.Text)
            vars.Add("nib", nib.Text)
            vars.Add("saude", probsaudequais.Text)
            vars.Add("morada", morada.Text)
            vars.Add("filhos", quantosfilhos.Text)
            vars.Add("filhosenc", filhosencquantos.Text)
            vars.Add("niss", niss.Text)
            vars.Add("nif", nif.Text)
            vars.Add("ccvalid", ccvalidoate.Text)
            vars.Add("cc", cartaocidadao.Text)
            vars.Add("nac", nacionalidade.Text)
            vars.Add("idade", idade_txt.Text)
            vars.Add("c112", txt_112.Text)
            vars.Add("nfc", txt_nfc.Text.ToString.Replace(" ", ""))
            vars.Add("nfckey", nfc_auth_code.Text.ToString.Replace(" ", "").Replace("-", ""))
            vars.Add("auth", nfc_auth_code.Text)
            vars.Add("mobile", txt_mobile.Text)
            vars.Add("nome", txt_name.Text)
            vars.Add("ecivil", estadoCivil.SelectedIndex)
            vars.Add("email", email.Text)
            vars.Add("class", classificacao.SelectedItem.ToString)
            vars.Add("loc", localizacao.SelectedItem.ToString)
            vars.Add("salario", salario.Text.Replace(", ", "."))
            vars.Add("refeicao", refeicao.Text.Replace(", ", "."))
            vars.Add("acusto", ajudascusto.Text.Replace(", ", "."))
            vars.Add("aloj", aloja)
            vars.Add("natura", naturalidade.Text)
            vars.Add("concelho", concelho.Text)
            vars.Add("ativo", ativ)
            vars.Add("adate", activodate.Text)
            vars.Add("csdate", csaudevalidade.Text)
            vars.Add("mealplace", works_meals.Item("cod_meal_place")(refeicoes.SelectedIndex))
            vars.Add("lodge", works_lodging.Item("cod_lodging")(alojamento.SelectedIndex))
            vars.Add("notes", notas.Text)
            vars.Add("room", quarto.Text)
            vars.Add("destacamentofim", destacamentoFim.Text)
            vars.Add("contratoinicio", contratoInicio.Text)
            vars.Add("contratofim", contratoFim.Text)
            vars.Add("destacamentoinicio", destacamentoInicio.Text)

            taskRequest = "edit"
            DataRequests.Initialise(state)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.saveWorkersData()
        End If
    End Sub

    Private Sub ClearForm()
        delWorkerCard.Enabled = False

        txt_name.Text = ""
        txt_mobile.Text = ""
        txt_nfc.Text = ""
        txt_112.Text = ""
        datanascimento_txt.Text = ""
        idade_txt.Text = ""
        nacionalidade.Text = ""
        cartaocidadao.Text = ""
        ccvalidoate.Text = ""
        nif.Text = ""
        niss.Text = ""
        quantosfilhos.Text = ""
        filhosencquantos.Text = ""
        email.Text = ""
        datainiciotrabalho.Text = ""
        morada.Text = ""
        probsaudequais.Text = ""
        nib.Text = ""
        peso.Text = ""
        altura.Text = ""
        pe.Text = ""
        casaco.Text = ""
        calcas.Text = ""
        contratoFim.Text = ""
        contratoInicio.Text = ""
        destacamentoInicio.Text = ""
        destacamentoFim.Text = ""
        actFim.Text = ""
        actInicio.Text = ""
        a1Fim.Text = ""
        a1Inicio.Text = ""
        mutuelle.Text = ""
        medico.Text = ""
        contratofile.Text = ""
        destacamentofile.Text = ""
        destacamentoactfile.Text = ""
        a1file.Text = ""
        mutuellefile.Text = ""
        medicofile.Text = ""
        gruistaFile.Text = ""
        ccfile.Text = ""
        csaudefile.Text = ""
        salario.Text = ""
        refeicao.Text = "5.86"
        ajudascusto.Text = "40.0"
        naturalidade.Text = ""
        concelho.Text = ""
        activodate.Text = calendar.SelectionStart.ToString("yyyy/MM/dd")
        csaudevalidade.Text = ""
        notas.Text = ""
        quarto.Text = ""
        activodate.Text = ""
        nfc_auth_code.Text = ""

        ativo.Checked = True
        activolbl.Text = "activo desde"

        probsaude.SelectedIndex = 0
        filhos.SelectedIndex = 0
        filhosenc.SelectedIndex = 0
        estadoCivil.SelectedIndex = 0
        combo_empresa.SelectedIndex = 0
        combo_catpro.SelectedIndex = 0
        classificacao.SelectedIndex = 0
        localizacao.SelectedIndex = 0
        alojamento.SelectedIndex = 0
        refeicoes.SelectedIndex = 0

        limosaList.Enabled = False
        obra.Enabled = False
        duracaoInicioLimosa.Enabled = False
        duracaoFimLimosa.Enabled = False
        limosafile.Enabled = False
        btn_limosa.Enabled = False
        del_limosa.Enabled = False
        save_limosa.Enabled = False
        limosaList.Items.Clear()


        del_files.Enabled = False
        csaudedel.Enabled = False
        ccdel.Enabled = False
        gruistadel.Enabled = False
        medicodel.Enabled = False
        mutuelledel.Enabled = False
        a1del.Enabled = False
        actdel.Enabled = False
        destacamentodel.Enabled = False
        contratodel.Enabled = False

        csaudedel.Checked = False
        ccdel.Checked = False
        gruistadel.Checked = False
        medicodel.Checked = False
        mutuelledel.Checked = False
        a1del.Checked = False
        actdel.Checked = False
        destacamentodel.Checked = False
        contratodel.Checked = False

        download.Enabled = False

        photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.png"))
        contratoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        destacamentoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        actImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        a1Img.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        mutuelleImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        medicoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        gruistaImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        ccimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        csaudeimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
        qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))

        idade_txt.ForeColor = Color.Black

    End Sub

    Private Sub photobox_Click(sender As Object, e As EventArgs) Handles photobox.Click
        If (listview_works.SelectedItems.Count > 0) Then

            If listview_works.SelectedIndex > 0 Then
                Dim idx = listview_works.SelectedIndex
                Dim OpenFileDialog1 As New OpenFileDialog
                OpenFileDialog1.Title = "Abrir ficheiro..."
                OpenFileDialog1.Multiselect = False
                OpenFileDialog1.Filter = "Imagem jpg|*.jpg"
                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                    Dim filename = OpenFileDialog1.FileName
                    photobox.Image = Image.FromFile(filename)
                    photobox.SizeMode = PictureBoxSizeMode.StretchImage

                    translations.load("messagebox")
                    msgbox = New messageBoxForm(translations.getText("questionAddPhoto"), translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    If (msgbox.ShowDialog = DialogResult.Yes) Then
                        enableButtonsAndLinks(Me, False)

                        Dim vars As New Dictionary(Of String, String)
                        vars.Add("task", state.taskId("workerDossier"))
                        vars.Add("request", "addworkerfile")
                        vars.Add("file", "photo")
                        vars.Add("user", works_worker.Item("cod_worker")(listview_works.SelectedIndex - 1))

                        sendPhotoHttp = New HttpDataFilesUpload(state)
                        sendPhotoHttp.loadQueue(vars, Nothing, filename)
                        sendPhotoHttp.startRequest()
                    End If
                End If
            Else
                translations.load("errorMessages")
                Dim messageTxt As String = translations.getText("errorSelectWorker")
                translations.load("messagebox")
                msgbox = New messageBoxForm(messageTxt, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub
    Private Sub sendPhotoHttp_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String, String)) Handles sendPhotoHttp.dataArrived
        If Not IsResponseOk(responseData) Then
            If Not IsNothing(mainForm.busy) Then
                If mainForm.busy.isActive().Equals(True) Then
                    mainForm.busy.Close(True)
                End If
            End If
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(responseData), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            load_list()
            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/photos/" & works_worker.Item("photo")(listview_works.SelectedIndex - 1))))
            photobox.Image = tImage
            photobox.SizeMode = PictureBoxSizeMode.StretchImage
        End If
        enableButtonsAndLinks(Me, False)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles actBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        destacamentoactfile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles destacamentoBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        destacamentofile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles contractFileBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        contratofile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles a1Btn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        a1file.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles mutuelleBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        mutuellefile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles ccBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        limosafile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles medicBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("commonForm")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        medicofile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub datainiciotrabalho_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles datainiciotrabalho.LostFocus
        control = datainiciotrabalho

    End Sub
    Private Sub contratoInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles contratoInicio.LostFocus
        control = contratoInicio
    End Sub
    Private Sub contratoFim_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles contratoFim.LostFocus
        control = contratoFim
    End Sub
    Private Sub destacamentoinicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles destacamentoInicio.LostFocus
        control = destacamentoInicio
    End Sub
    Private Sub destacamentofim_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles destacamentoFim.LostFocus
        control = destacamentoFim
    End Sub
    Private Sub actinicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actInicio.LostFocus
        control = actInicio
    End Sub
    Private Sub actFim_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles actFim.LostFocus
        control = actFim
    End Sub
    Private Sub a1inicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles a1Inicio.LostFocus
        control = a1Inicio
    End Sub
    Private Sub a1Fim_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles a1Fim.LostFocus
        control = a1Fim
    End Sub
    Private Sub medico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles medico.LostFocus
        control = medico
    End Sub

    Private Sub mutuelle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mutuelle.LostFocus
        control = mutuelle
    End Sub

    Private Sub datanascimento_txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles datanascimento_txt.LostFocus
        control = datanascimento_txt
    End Sub

    Private Sub ccvalidoate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ccvalidoate.LostFocus
        control = ccvalidoate
    End Sub

    Private Sub activodate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles activodate.LostFocus
        control = activodate
    End Sub
    Private Sub csaudevalidade_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles csaudevalidade.LostFocus
        control = csaudevalidade
    End Sub

    Private Sub del_limosa_Click(sender As Object, e As EventArgs) Handles del_limosa.Click

        translations.load("messagebox")
        Dim messageTxt = translations.getText("questionRemoveLimosa")
        translations.load("messagebox")
        msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)

        If (msgbox.ShowDialog = DialogResult.OK) Then
            enableButtonsAndLinks(Me, False)

            Dim vars As New Dictionary(Of String, String)
            taskRequest = "del"
            vars.Add("request", "delimosa")
            vars.Add("cod", limosasDB.Item("cod_limosa")(limosaList.SelectedIndices(0)))
            DataRequests.Initialise(state)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.delWorkersLimosasData()
        End If
    End Sub

    Private Sub DataRequests_getResponseDelWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseDelWorkersLimosasData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        If Not IsResponseOk(response) Then
            mainForm.busy.Close(True)
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, False)
            Exit Sub
        End If
        If taskRequest.Equals("del") Then

            obra.SelectedIndex = 0
            duracaoFimLimosa.Value = DateTime.Now
            duracaoInicioLimosa.Value = DateTime.Now
            limosafile.Text = ""

            qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))
            limosasImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
            If workersListSelection.SelectedIndex.Equals(0) Then
                posToLoad = listview_works.SelectedIndices(0) - 1
            ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
            Else
                posToLoad = listview_works.SelectedIndices(0) - 1
            End If
            loadLimosas()
            enableButtonsAndLinks(Me, True)

        End If
        taskRequest = ""
    End Sub

    Private Sub save_limosa_Click(sender As Object, e As EventArgs) Handles save_limosa.Click
        Dim startD As Date, endD As Date

        startD = duracaoInicioLimosa.Value
        endD = duracaoFimLimosa.Value

        If DateTime.Compare(startD, endD) > 0 And Not duracaoInicioLimosa.Value.ToString("yyyy-MM-dd").Equals(duracaoFimLimosa.Value.ToString("yyyy-MM-dd")) Then
            translations.load("errorMessages")
            Dim messageTxt = translations.getText("errorDateInterval")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        If (obra.SelectedIndex = 0) Then
            translations.load("errorMessages")
            Dim messageTxt = translations.getText("errorSelectSite")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            obra.Focus()
        ElseIf (Not File.Exists(limosafile.Text)) Then
            translations.load("errorMessages")
            Dim messageTxt = translations.getText("errorLoadingDataFile")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            limosafile.Focus()
        ElseIf (Not File.Exists(QrCode)) Then
            translations.load("workers")
            Dim messageTxt = translations.getText("errorQrCodeFile")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            enableButtonsAndLinks(Me, False)
            If workersListSelection.SelectedIndex.Equals(0) Then
                posToLoad = listview_works.SelectedIndices(0) - 1
            ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
            Else
                posToLoad = listview_works.SelectedIndices(0) - 1
            End If
            Dim vars As New Dictionary(Of String, String)
            vars.Add("request", "addlimosa")
            vars.Add("user", works_worker.Item("cod_worker")(posToLoad))
            vars.Add("inicio", duracaoInicioLimosa.Value.ToString("yyyy-MM-dd"))
            vars.Add("fim", duracaoFimLimosa.Value.ToString("yyyy-MM-dd"))
            vars.Add("site", works_site.Item("cod_site")(obra.SelectedIndex - 1))

            taskRequest = "saveLimosa"
            DataRequests.Initialise(state)
            DataRequests.saveWorkersLimosasData(vars, limosafile.Text)
        End If
    End Sub

    Private Sub saveWorkersLimosasData_getResponseSaveWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveWorkersLimosasData
        Dim response As String = args.responseData

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            enableButtonsAndLinks(Me, True)
            taskRequest = ""
        ElseIf taskRequest.Equals("saveLimosa") And File.Exists(QrCode) Then
            Dim cod As String = GetMessage(response)
            Dim vars2 As New Dictionary(Of String, String)
            vars2.Add("request", "addlimosa")
            vars2.Add("type", "qrcode")
            vars2.Add("cod", cod)

            taskRequest = "saveQrCode"
            DataRequests.Initialise(state)
            DataRequests.saveWorkersLimosasData(vars2, QrCode)
        ElseIf (taskRequest.Equals("saveLimosa") And Not File.Exists(QrCode)) Or (taskRequest.Equals("saveQrCode")) Then
            limosafile.Text = ""
            duracaoFimLimosa.Value = DateTime.Now
            duracaoInicioLimosa.Value = DateTime.Now
            taskRequest = ""
            qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))
            enableButtonsAndLinks(Me, True)
            loadLimosas()

            translations.load("messagebox")
            Dim messageTxt = translations.getText("resultSuccessAddRecord")
            msgbox = New messageBoxForm(messageTxt & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
    End Sub

    Private Sub loadLimosas()
        If listview_works.SelectedIndices(0) < 1 Then
            Exit Sub
        End If
        If workersListSelection.SelectedIndex.Equals(0) Then
            posToLoad = listview_works.SelectedIndices(0) - 1
        ElseIf workersListSelection.SelectedIndex.Equals(1) Then
            posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
        Else
            posToLoad = listview_works.SelectedIndices(0) - 1
        End If
        Dim vars As New Dictionary(Of String, String)

        vars.Add("request", "limosa")
        vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
        DataRequests.Initialise(state)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.loadWorkersLimosasData()
    End Sub

    Private Sub DataRequests_getResponseWorkersLimosasData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseWorkersLimosasData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        mainForm.busy.Close(True)

        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        limosasDB = request.ConvertDataToArray("limosa", state.queryLimosaRecords, response)
        If IsNothing(limosasDB) Then
            translations.load("workers")
            limosaList.Items.Clear()
            limosaList.Items.Add(translations.getText("dropdownAddLimosa"))
        Else
            translations.load("workers")
            limosaList.Items.Clear()
            limosaList.Items.Add(translations.getText("dropdownAddLimosa"))
            For i = 0 To limosasDB.Item("cod_limosa").Count - 1
                limosaList.Items.Add(limosasDB.Item("name")(i) & " [" & limosasDB.Item("inicio")(i) & "] [" & limosasDB.Item("fim")(i) & "]")
            Next i
        End If
    End Sub

    Private Sub quantosfilhos_TextChanged(sender As Object, e As EventArgs) Handles quantosfilhos.TextChanged
        If (quantosfilhos.Text.Equals("")) Then
            filhos.SelectedIndex = 0
        Else
            filhos.SelectedIndex = 1
        End If
    End Sub

    Private Sub filhosencquantos_TextChanged(sender As Object, e As EventArgs) Handles filhosencquantos.TextChanged
        If (filhosencquantos.Text.Equals("")) Then
            filhosenc.SelectedIndex = 0
        Else
            filhosenc.SelectedIndex = 1
        End If
    End Sub

    Private Sub probsaudequais_TextChanged(sender As Object, e As EventArgs) Handles probsaudequais.TextChanged
        If (probsaudequais.Text.Equals("")) Then
            probsaude.SelectedIndex = 0
        Else
            probsaude.SelectedIndex = 1
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles cranemanBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("messagebox")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        gruistaFile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub getDocumentFile(vars)
        getFilesHttp = New HttpDataFilesDownload(state)
        getFilesHttp.initialize()
        getFilesHttp.loadQueue(vars, Nothing, state.tmpPath)
        getFilesHttp.startRequest()
    End Sub
    Private Sub getFilesHttp_updateProgressStatistics(sender As Object, datastatistics As HttpDataCore._data_statistics, misc As Dictionary(Of String, String)) Handles getFilesHttp.updateProgressStatistics
        Dim percentage As Integer = (datastatistics.bytesSentReceived / datastatistics.filesize * 10)
        Dim status As String = StrDup(percentage, Chr(219)) & StrDup(10 - percentage, Chr(176))
        mainForm.statusMessage = status
    End Sub
    Private Sub getFilesHttp_dataArrived(sender As Object, fileNamePath As String, misc As Dictionary(Of String, String)) Handles getFilesHttp.dataArrived
        OpenDocumentFile(fileNamePath)
    End Sub
    Private Sub limosasImg_Click(sender As Object, e As EventArgs) Handles limosasImg.Click
        If (limosaList.SelectedItems.Count > 0) Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "33") 'getfile
            vars.Add("type", "limosa")
            vars.Add("cod", limosasDB.Item("cod_limosa")(limosaList.SelectedIndex - 1))
            getDocumentFile(vars)
        End If
    End Sub

    Private Sub contratoImg_Click(sender As Object, e As EventArgs) Handles contratoImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("contrato_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "contrato")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub ccimg_Click(sender As Object, e As EventArgs) Handles ccimg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("cc_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "cc")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub csaudeimg_Click(sender As Object, e As EventArgs) Handles csaudeimg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("csaude_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "csaude")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub
    Private Sub destacamentoImg_Click(sender As Object, e As EventArgs) Handles destacamentoImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("destacamento_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "destacamento")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub actImg_Click(sender As Object, e As EventArgs) Handles actImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("act_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "act")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub a1Img_Click(sender As Object, e As EventArgs) Handles a1Img.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("a1_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "a1")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub mutuelleImg_Click(sender As Object, e As EventArgs) Handles mutuelleImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("mutuelle_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "mutuelle")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub medicoImg_Click(sender As Object, e As EventArgs) Handles medicoImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("medico_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "medico")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub gruistaImg_Click(sender As Object, e As EventArgs) Handles gruistaImg.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If (listview_works.SelectedIndex > 0) Then
                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                If (Not works_worker.Item("gruista_file")(posToLoad).Equals("")) Then
                    Dim vars As New Dictionary(Of String, String)
                    vars.Add("task", "33") 'getfile
                    vars.Add("type", "gruista")
                    vars.Add("cod", works_worker.Item("cod_worker")(posToLoad))
                    getDocumentFile(vars)
                End If
            End If
        End If
    End Sub

    Private Sub OpenDocumentFile(filename As String)
        If Not IsResponseOk(filename) Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorDownloadingFile")
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(filename) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        ElseIf GetMessageField(filename, "file").Equals("false") Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorDownloadingFile")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            filename = GetMessageField(filename, "file")
            Dim checkFile = New FileInfo(filename)
            checkFile.Refresh()
            If checkFile.Exists Then
                Process.Start(filename)
            Else
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorDownloadingFile")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub classificacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles classificacao.SelectedIndexChanged
        If classificacao.SelectedIndex > 0 Then
            salario.Text = works_classificacao(classificacao.SelectedIndex, localizacao.SelectedIndex + 1)
        End If
    End Sub

    Private Sub localizacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles localizacao.SelectedIndexChanged
        If classificacao.SelectedIndex > 0 Then
            salario.Text = works_classificacao(classificacao.SelectedIndex, localizacao.SelectedIndex + 1)
        End If
    End Sub
    Private Sub ccvalidoate_TextChanged(sender As Object, e As EventArgs) Handles ccvalidoate.TextChanged
        ClearDate(ccvalidoate)
    End Sub

    Private Sub datainiciotrabalho_TextChanged(sender As Object, e As EventArgs) Handles datainiciotrabalho.TextChanged
        ClearDate(datainiciotrabalho)
    End Sub

    Private Sub contratoInicio_TextChanged(sender As Object, e As EventArgs) Handles contratoInicio.TextChanged
        ClearDate(contratoInicio)
    End Sub

    Private Sub contratoFim_TextChanged(sender As Object, e As EventArgs) Handles contratoFim.TextChanged
        ClearDate(contratoFim)
    End Sub

    Private Sub destacamentoInicio_TextChanged(sender As Object, e As EventArgs) Handles destacamentoInicio.TextChanged
        ClearDate(destacamentoInicio)
    End Sub

    Private Sub destacamentoFim_TextChanged(sender As Object, e As EventArgs) Handles destacamentoFim.TextChanged
        ClearDate(destacamentoFim)
    End Sub

    Private Sub actInicio_TextChanged(sender As Object, e As EventArgs) Handles actInicio.TextChanged
        ClearDate(actInicio)
    End Sub

    Private Sub actFim_TextChanged(sender As Object, e As EventArgs) Handles actFim.TextChanged
        ClearDate(actFim)
    End Sub

    Private Sub a1Inicio_TextChanged(sender As Object, e As EventArgs) Handles a1Inicio.TextChanged
        ClearDate(a1Inicio)
    End Sub

    Private Sub a1Fim_TextChanged(sender As Object, e As EventArgs) Handles a1Fim.TextChanged
        ClearDate(a1Fim)
    End Sub

    Private Sub mutuelle_TextChanged(sender As Object, e As EventArgs) Handles mutuelle.TextChanged
        ClearDate(mutuelle)
    End Sub

    Private Sub medico_TextChanged(sender As Object, e As EventArgs) Handles medico.TextChanged
        ClearDate(medico)
    End Sub

    Private Sub activodate_TextChanged(sender As Object, e As EventArgs) Handles activodate.TextChanged
        ClearDate(activodate)
    End Sub

    Private Sub del_files_Click(sender As Object, e As EventArgs) Handles del_files.Click

        Dim enableDel As Boolean = False
        Dim type As String = ""
        If contratodel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "contrato", type & ", contrato")
        End If
        If destacamentodel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "destacamento", type & ", destacamento")
        End If
        If a1del.Checked Then
            enableDel = True
            type = If(type.Equals(""), "a1", type & ", a1")
        End If
        If actdel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "act", type & ", act")
        End If
        If mutuelledel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "mutuelle", type & ", mutuelle")
        End If
        If medicodel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "medico", type & ", medico")
        End If
        If gruistadel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "gruista", type & ", gruista")
        End If
        If ccdel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "cc", type & ", cc")
        End If
        If csaudedel.Checked Then
            enableDel = True
            type = If(type.Equals(""), "csaude", type & ", csaude")
        End If

        If Not enableDel Then
            translations.load("errorMessages")
            Dim messageTxt2 = translations.getText("errorSelectAnOption")
            translations.load("messagebox")
            msgbox = New messageBoxForm(messageTxt2, translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If

        translations.load("messagebox")
        Dim messageTxt = translations.getText("questionDeleteFile")
        msgbox = New messageBoxForm(messageTxt, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If (msgbox.ShowDialog = DialogResult.Yes) Then
            enableButtonsAndLinks(Me, False)

            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "26")
            vars.Add("request", "delworkerfile")
            vars.Add("type", type)
            vars.Add("cod", works_worker.Item("cod_worker")(listview_works.SelectedIndex - 1))

            DataRequests.Initialise(state)
            DataRequests.loadQueue(vars, Nothing, Nothing)
            DataRequests.delWorkersFileData()
        End If
    End Sub

    Private Sub DataRequests_getResponseDelWorkersFileData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseDelWorkersFileData
        Dim response As String = args.responseData

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        Else
            ClearForm()
            load_list()
        End If
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles ccBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("messagebox")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        ccfile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles cseBtn.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        translations.load("messagebox")
        OpenFileDialog1.Title = translations.getText("openFileDialogTitle") & "..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = translations.getText("filesPdf") & "|*.pdf"
        OpenFileDialog1.ShowDialog()
        csaudefile.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub ativo_CheckedChanged(sender As Object, e As EventArgs) Handles ativo.CheckedChanged
        If IsNothing(translations) Then
            Exit Sub
        End If
        translations.load("workers")

        If ativo.Checked Then
            activolbl.Text = translations.getText("workerActive")
        Else
            activolbl.Text = translations.getText("workerInactive")
        End If
    End Sub

    Private Sub csaudevalidade_TextChanged(sender As Object, e As EventArgs) Handles csaudevalidade.TextChanged
        ClearDate(csaudevalidade)
    End Sub

    Private Sub altura_TextChanged(sender As Object, e As EventArgs) Handles altura.TextChanged
        MarkAsRed(altura)
    End Sub

    Sub MarkAsRed(c As Control)
        If c.Text.Equals("") Or c.Text.Equals("0") Then
            c.BackColor = Color.MistyRose
        Else
            c.BackColor = Color.White
        End If
    End Sub

    Private Sub peso_TextChanged(sender As Object, e As EventArgs) Handles peso.TextChanged
        MarkAsRed(peso)
    End Sub

    Private Sub calcas_TextChanged(sender As Object, e As EventArgs) Handles calcas.TextChanged
        MarkAsRed(calcas)
    End Sub

    Private Sub pe_TextChanged(sender As Object, e As EventArgs) Handles pe.TextChanged
        MarkAsRed(pe)

    End Sub

    Private Sub casaco_TextChanged(sender As Object, e As EventArgs) Handles casaco.TextChanged
        MarkAsRed(casaco)

    End Sub

    Private Sub nib_TextChanged(sender As Object, e As EventArgs) Handles nib.TextChanged
        MarkAsRed(nib)

    End Sub

    Private Sub ajudascusto_TextChanged(sender As Object, e As EventArgs) Handles ajudascusto.TextChanged
        MarkAsRed(ajudascusto)

    End Sub

    Private Sub refeicao_TextChanged(sender As Object, e As EventArgs) Handles refeicao.TextChanged
        MarkAsRed(refeicao)

    End Sub

    Private Sub salario_TextChanged(sender As Object, e As EventArgs) Handles salario.TextChanged
        MarkAsRed(salario)

    End Sub

    Private Sub email_TextChanged(sender As Object, e As EventArgs) Handles email.TextChanged

    End Sub

    Private Sub niss_TextChanged(sender As Object, e As EventArgs) Handles niss.TextChanged
        MarkAsRed(niss)

    End Sub

    Private Sub nif_TextChanged(sender As Object, e As EventArgs) Handles nif.TextChanged
        MarkAsRed(nif)

    End Sub

    Private Sub cartaocidadao_TextChanged(sender As Object, e As EventArgs) Handles cartaocidadao.TextChanged
        MarkAsRed(cartaocidadao)

    End Sub

    Private Sub nacionalidade_TextChanged(sender As Object, e As EventArgs) Handles nacionalidade.TextChanged
        MarkAsRed(nacionalidade)

    End Sub

    Private Sub idade_txt_TextChanged(sender As Object, e As EventArgs) Handles idade_txt.TextChanged
        MarkAsRed(idade_txt)

    End Sub

    Private Sub txt_mobile_TextChanged(sender As Object, e As EventArgs) Handles txt_mobile.TextChanged
        MarkAsRed(txt_mobile)

    End Sub

    Private Sub concelho_TextChanged(sender As Object, e As EventArgs) Handles concelho.TextChanged
        MarkAsRed(concelho)

    End Sub

    Private Sub naturalidade_TextChanged(sender As Object, e As EventArgs) Handles naturalidade.TextChanged
        MarkAsRed(naturalidade)

    End Sub

    Private Sub txt_nfc_TextChanged(sender As Object, e As EventArgs) Handles txt_nfc.TextChanged
        MarkAsRed(txt_nfc)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles searchBoxBtn.Click
        doSearch(If(listview_works.SelectedIndex <= 0, 1, listview_works.SelectedIndex + 1), True)
    End Sub

    Private Sub doSearch(start As Integer, firstTime As Boolean)
        If Not IsNothing(works_worker) Then
            Dim found As Boolean = False
            For i = start + 1 To works_worker.Item("cod_worker").Count - 1
                If Not works_worker.Item("name")(i).ToLower.IndexOf(searchbox.Text.ToLower) = -1 Then
                    listview_works.SelectedIndex = i + 1
                    found = True
                    Exit For
                End If
            Next i
            If firstTime.Equals(False) And Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            ElseIf Not found Then
                translations.load("infoMessages")
                Dim message3 As String = translations.getText("searchResultsNotFound") & ". " & translations.getText("searchAgainQuestion")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("question"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If msgbox.ShowDialog = DialogResult.OK Then
                    doSearch(0, False)
                End If
            End If
        End If
    End Sub

    Private Sub WorkersListSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles workersListSelection.SelectedIndexChanged
        If workersListSelection.SelectedIndex > -1 And loaded Then
            load_list()
        End If
    End Sub

    Private Sub qrcode_img_Click(sender As Object, e As EventArgs) Handles qrcode_img.Click
        If (listview_works.SelectedItems.Count > 0) Then
            If listview_works.SelectedIndex > 0 Then
                Dim idx = listview_works.SelectedIndex
                translations.load("commonForm")
                Dim saveFileDialog1 As New OpenFileDialog
                OpenFileDialog1.Title = translations.getText("openImageDialogTitle") & "..."
                OpenFileDialog1.Filter = translations.getText("filesImage") & "|*.jpg"
                OpenFileDialog1.Multiselect = False
                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

                    Dim filename = OpenFileDialog1.FileName
                    qrcode_img.Image = Image.FromFile(filename)
                    qrcode_img.SizeMode = PictureBoxSizeMode.StretchImage
                    QrCode = filename
                End If
            Else
                translations.load("errorMessages")
                Dim message3 As String = translations.getText("errorSelectWorker")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
            End If
        End If
    End Sub

    Private Sub combo_catpro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_catpro.SelectedIndexChanged

    End Sub

    Private Sub workerMainWrapper_Paint(sender As Object, e As PaintEventArgs) Handles workerMainWrapper.Paint

    End Sub

    Private Sub saveNewCard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles saveNewCard.LinkClicked
        Dim currentFormData As New Dictionary(Of String, String)
        If (listview_works.SelectedItems.Count > 0) Then
            If listview_works.SelectedIndices(0) > 0 Then 'edit worker
                currentFormData.Add("userCode", works_worker.Item("cod_worker")(posToLoad))
                currentFormData.Add("cardId", txt_nfc.Text)
                currentFormData.Add("authString", nfc_auth_code.Text)
            End If
        End If

        initializeSmartCardForm = New initializeSmartCard(Me.mainForm, state, currentFormData)
        initializeSmartCardForm.ShowDialog()
    End Sub
    Private Sub initializeSmartCardForm_getSmartCardDetails(sender As Object, args As Dictionary(Of String, String)) Handles initializeSmartCardForm.getSmartCardDetails
        txt_nfc.Text = args("cardId")
        nfc_auth_code.Text = args("authstring")
    End Sub

    Private Sub datanascimento_txt_TextChanged(sender As Object, e As EventArgs) Handles datanascimento_txt.TextChanged
        ClearDate(datanascimento_txt)
        If (IsDate(datanascimento_txt.Text)) Then
            Dim userBirthDateText = datanascimento_txt.Text
            Dim userBirthDate = Date.ParseExact(userBirthDateText.Replace("/", "-"), "yyyy-MM-dd", Nothing)
            Dim currentDate = Date.Now
            Dim age = Math.Floor(currentDate.Subtract(userBirthDate).TotalDays / 365)
            idade_txt.Text = age
        End If
    End Sub

    Private Sub downloadBtn_Click(sender As Object, e As EventArgs) Handles download.Click
        translations.load("commonForm")
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.Title = translations.getText("openImageDialogTitle") & "..."
        saveFileDialog1.Filter = translations.getText("filesImage") & "|*.jpg"
        If (saveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim cfgFile = New FileInfo(saveFileDialog1.FileName)
            cfgFile.Refresh()
            If cfgFile.Exists Then
                Try
                    FileSystem.Kill(saveFileDialog1.FileName)
                Catch
                    translations.load("errorMessages")
                    Dim msgTxt = translations.getText("errorFileIsWriteProtected")
                    translations.load("messagebox")
                    msgbox = New messageBoxForm(msgTxt, translations.getText("exclamantion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                    Exit Sub
                End Try

            End If
            Dim filename = saveFileDialog1.FileName
            photobox.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    Private Sub addCalendarDateLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles addCalendarDateLink.LinkClicked
        If (Not IsNothing(control)) Then
            If (control.Equals(csaudevalidade) Or control.Equals(datanascimento_txt) Or control.Equals(ccvalidoate) Or control.Equals(mutuelle) Or control.Equals(medico) Or control.Equals(a1Fim) Or control.Equals(a1Inicio) Or control.Equals(actInicio) Or control.Equals(actFim) Or control.Equals(destacamentoFim) Or control.Equals(destacamentoInicio) Or control.Equals(contratoFim) Or control.Equals(contratoInicio) Or control.Equals(datainiciotrabalho) Or control.Equals(activodate)) Then
                control.Text = calendar.SelectionStart.ToString("yyyy/MM/dd")
            End If
        End If
    End Sub

    Private Sub limosaList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles limosaList.SelectedIndexChanged
        If (limosaList.SelectedItems.Count > 0) Then
            txt_name.Text = listview_works.SelectedItems(0).ToString
            If limosaList.SelectedIndices(0) = 0 Then 'new worker
                obra.SelectedIndex = 0
                duracaoFimLimosa.Value = DateTime.Now
                duracaoInicioLimosa.Value = DateTime.Now

                limosafile.Text = ""
                del_limosa.Enabled = False
                save_limosa.Enabled = True

                limosasImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))

            Else ' edit limosa
                save_limosa.Enabled = False
                del_limosa.Enabled = True
                If IsDate(limosasDB.Item("inicio")(limosaList.SelectedIndex - 1)) Then
                    duracaoInicioLimosa.Value = limosasDB.Item("inicio")(limosaList.SelectedIndex - 1)
                Else
                    duracaoInicioLimosa.Value = DateTime.Now
                End If
                '"cod_limosa", "inicio", "fim", "file", "name", "qrcode"

                If IsDate(limosasDB.Item("fim")(limosaList.SelectedIndex - 1)) Then
                    duracaoFimLimosa.Value = limosasDB.Item("fim")(limosaList.SelectedIndex - 1)
                Else
                    duracaoFimLimosa.Value = DateTime.Now
                End If

                If (limosasDB.Item("file")(limosaList.SelectedIndices(0) - 1).Equals("")) Then
                    limosasImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    limosasImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                For i = 0 To obra.Items.Count - 1
                    If (obra.Items(i).ToString().Equals(limosasDB.Item("name")(limosaList.SelectedIndices(0) - 1))) Then
                        obra.SelectedIndex = i
                    End If
                Next i
                If (limosasDB.Item("qrcode")(limosaList.SelectedIndices(0) - 1).Equals("")) Then
                    qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))
                Else
                    qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("loading.png"))
                    qrcode_img.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/files/limosas/qrcode/" & limosasDB.Item("qrcode")(limosaList.SelectedIndices(0) - 1))))
                        qrcode_img.Image = tImage
                    Catch ex As Exception
                        qrcode_img.Image = Image.FromFile(state.imagesPath & Convert.ToString("searchqrcode.png"))
                        translations.load("errorMessages")
                        mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    qrcode_img.SizeMode = PictureBoxSizeMode.StretchImage
                End If

            End If
        End If
    End Sub


    Private Sub ListView_works_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listview_works.DrawItem
        If formClose Then
            Exit Sub
        End If

        e.DrawBackground()
        Dim selected As Boolean = False

        If e.Index > 0 Then
            If Not IsNothing(works_worker) AndAlso e.Index > 0 AndAlso (works_worker("cod_nfc")(e.Index - 1).Equals("") Or works_worker("cod_nfc")(e.Index - 1).Equals("0") Or
                IsValidEmailFormat(works_worker("email")(e.Index - 1)).Equals(False) Or works_worker("contact")(e.Index - 1).Equals("0") Or works_worker("contact")(e.Index - 1).Equals("")) Then
                Dim mybrush As System.Drawing.SolidBrush = New System.Drawing.SolidBrush(Color.MistyRose)
                e.Graphics.FillRectangle(mybrush, e.Bounds)
            ElseIf String.Compare(listview_works.Items(e.Index).ToString.Substring(0, 1).ToLower, listview_works.Items(e.Index - 1).ToString.Substring(0, 1).ToLower, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) Then
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

    Private Sub listview_works_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles listview_works.SelectedIndexChanged

        If (listview_works.SelectedItems.Count > 0) Then

            If detectChanges() And Not listview_works.SelectedIndices(0).Equals(prevSelection) Then

                translations.load("workers")
                Dim message3 As String = translations.getText("questionUnsavedChanges")
                translations.load("messagebox")
                msgbox = New messageBoxForm(message3 & ". ", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                If Not msgbox.ShowDialog = DialogResult.Yes Then
                    listview_works.SelectedIndex = prevSelection
                    If Not IsNothing(mainForm.busy) Then
                        If mainForm.busy.isActive().Equals(True) Then
                            mainForm.busy.Close(True)
                        End If
                    End If
                    Exit Sub
                Else
                    prevSelection = 0
                End If
            End If
            enableButtonsAndLinks(Me, False)
            If Not IsNothing(mainForm.busy) Then
                If mainForm.busy.isActive().Equals(False) Then

                    mainForm.busy.Show()
                End If
            End If
            listview_works.Enabled = False

            txt_name.Text = listview_works.SelectedItems(0).ToString
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                ClearForm()
                prevSelection = 0
                saveNewCard.Enabled = False
            Else 'edit worker
                SuspendLayout()

                ClearForm()

                If nfc_card.SelectDevice() Then
                    Dim smartCardReaders As New List(Of String)
                    Dim errMsg As String = ""
                    If nfc_card.GetAvailableReaders(smartCardReaders, errMsg) Then
                        saveNewCard.Enabled = True
                    End If
                End If

                prevSelection = listview_works.SelectedIndices(0)
                limosaList.Enabled = True
                obra.Enabled = True
                duracaoFimLimosa.Enabled = True
                duracaoInicioLimosa.Enabled = True
                limosafile.Enabled = True
                btn_limosa.Enabled = True
                save_limosa.Enabled = True


                delWorkerCard.Enabled = True

                If workersListSelection.SelectedIndex.Equals(0) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1
                ElseIf workersListSelection.SelectedIndex.Equals(1) Then
                    posToLoad = listview_works.SelectedIndices(0) - 1 + inactiveWorkerPosZero
                Else
                    posToLoad = listview_works.SelectedIndices(0) - 1
                End If
                txt_name.Text = works_worker.Item("name")(posToLoad)

                txt_nfc.Text = AddSpaces(works_worker.Item("cod_nfc")(posToLoad), 3)
                If works_worker.Item("card_auth_key")(posToLoad).ToString.Length.Equals(12) Then
                    nfc_auth_code.Text = works_worker.Item("card_auth_key")(posToLoad).Substring(0, 4) & " - " & works_worker.Item("card_auth_key")(posToLoad).Substring(4, 3) & " - " & works_worker.Item("card_auth_key")(posToLoad).Substring(7, 5)
                Else
                    nfc_auth_code.Text = works_worker.Item("card_auth_key")(posToLoad)
                End If

                txt_mobile.Text = works_worker.Item("contact")(posToLoad)
                txt_112.Text = works_worker.Item("contact112")(posToLoad)
                datanascimento_txt.Text = works_worker.Item("data_nascimento")(posToLoad)
                idade_txt.Text = works_worker.Item("idade")(posToLoad)

                ClearDate(datanascimento_txt)
                If (IsDate(datanascimento_txt.Text)) Then
                    Dim userBirthDateText = datanascimento_txt.Text
                    Dim userBirthDate = Date.ParseExact(userBirthDateText.Replace("/", "-"), "yyyy-MM-dd", Nothing)
                    Dim currentDate = Date.Now
                    Dim age = Math.Floor(currentDate.Subtract(userBirthDate).TotalDays / 365)
                    If works_worker.Item("idade")(posToLoad) <> age Then
                        idade_txt.ForeColor = Color.Green
                    End If
                    idade_txt.Text = age
                End If

                nacionalidade.Text = works_worker.Item("nacionalidade")(posToLoad)
                cartaocidadao.Text = works_worker.Item("cc")(posToLoad)
                ccvalidoate.Text = If(Not IsDate(works_worker.Item("cc_validade")(posToLoad)), "", works_worker.Item("cc_validade")(posToLoad))

                nif.Text = works_worker.Item("nif")(posToLoad)
                niss.Text = works_worker.Item("niss")(posToLoad)
                email.Text = works_worker.Item("email")(posToLoad)
                datainiciotrabalho.Text = If(Not IsDate(works_worker.Item("data_inicio_trabalho")(posToLoad)), "", works_worker.Item("data_inicio_trabalho")(posToLoad))
                morada.Text = works_worker.Item("morada")(posToLoad)
                naturalidade.Text = works_worker.Item("naturalidade")(posToLoad)
                concelho.Text = works_worker.Item("concelho")(posToLoad)
                nib.Text = works_worker.Item("nib")(posToLoad)

                peso.Text = works_worker.Item("peso")(posToLoad)
                altura.Text = works_worker.Item("altura")(posToLoad)
                pe.Text = works_worker.Item("pe")(posToLoad)
                casaco.Text = works_worker.Item("casaco")(posToLoad)
                calcas.Text = works_worker.Item("calcas")(posToLoad)

                contratoFim.Text = If(Not IsDate(works_worker.Item("contrato_fim")(posToLoad)), "", works_worker.Item("contrato_fim")(posToLoad))
                contratoInicio.Text = If(Not IsDate(works_worker.Item("contrato_inicio")(posToLoad)), "", works_worker.Item("contrato_inicio")(posToLoad))
                destacamentoInicio.Text = If(Not IsDate(works_worker.Item("destacamento_inicio")(posToLoad)), "", works_worker.Item("destacamento_inicio")(posToLoad))
                destacamentoFim.Text = If(Not IsDate(works_worker.Item("destacamento_fim")(posToLoad)), "", works_worker.Item("destacamento_fim")(posToLoad))
                actFim.Text = If(Not IsDate(works_worker.Item("act_fim")(posToLoad)), "", works_worker.Item("act_fim")(posToLoad))
                actInicio.Text = If(Not IsDate(works_worker.Item("act_inicio")(posToLoad)), "", works_worker.Item("act_inicio")(posToLoad))
                a1Fim.Text = If(Not IsDate(works_worker.Item("a1_fim")(posToLoad)), "", works_worker.Item("a1_fim")(posToLoad))
                a1Inicio.Text = If(Not IsDate(works_worker.Item("a1_inicio")(posToLoad)), "", works_worker.Item("a1_inicio")(posToLoad))
                mutuelle.Text = If(Not IsDate(works_worker.Item("mutuelle_inicio")(posToLoad)), "", works_worker.Item("mutuelle_inicio")(posToLoad))
                medico.Text = If(Not IsDate(works_worker.Item("medico_inicio")(posToLoad)), "", works_worker.Item("medico_inicio")(posToLoad))

                If (works_worker.Item("filhos")(posToLoad).Equals("0")) Then
                    quantosfilhos.Text = ""
                Else
                    quantosfilhos.Text = works_worker.Item("filhos")(posToLoad)
                End If
                If (works_worker.Item("filhos_encargo")(posToLoad).Equals("0")) Then
                    filhosencquantos.Text = ""
                Else
                    filhosencquantos.Text = works_worker.Item("filhos_encargo")(posToLoad)
                End If
                If (works_worker.Item("prob_saude")(posToLoad).Equals("0")) Then
                    probsaudequais.Text = ""
                Else
                    probsaudequais.Text = works_worker.Item("prob_saude")(posToLoad)
                End If

                If (works_worker.Item("filhos")(posToLoad).Equals("") Or works_worker.Item("filhos")(posToLoad).Equals("0")) Then
                    filhos.SelectedIndex = 0
                Else
                    filhos.SelectedIndex = 1
                End If
                If (works_worker.Item("filhos_encargo")(posToLoad).Equals("") Or works_worker.Item("filhos_encargo")(posToLoad).Equals("0")) Then
                    filhosenc.SelectedIndex = 0
                Else
                    filhosenc.SelectedIndex = 1
                End If
                If (works_worker.Item("prob_saude")(posToLoad).Equals("") Or works_worker.Item("prob_saude")(posToLoad).Equals("0")) Then
                    probsaude.SelectedIndex = 0
                Else
                    probsaude.SelectedIndex = 1
                End If
                ' 0 - solteiro
                ' 1 - casado
                ' 2 - divorciado
                ' 3 - viuvo

                estadoCivil.SelectedIndex = works_worker.Item("estado_civil")(posToLoad)

                For i = 0 To classificacao.Items.Count - 1
                    If (classificacao.Items(i).ToString().Equals(works_worker.Item("classificacao")(posToLoad))) Then
                        classificacao.SelectedIndex = i
                    End If
                Next i

                For i = 0 To localizacao.Items.Count - 1
                    If (localizacao.Items(i).ToString().Equals(works_worker.Item("localizacao")(posToLoad))) Then
                        localizacao.SelectedIndex = i
                    End If
                Next i

                refeicao.Text = works_worker.Item("refeicao")(posToLoad)
                ajudascusto.Text = works_worker.Item("ajudascusto")(posToLoad)
                salario.Text = works_worker.Item("salario")(posToLoad)

                If (works_worker.Item("photo")(posToLoad).Equals("")) Then
                    photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.png"))
                Else
                    photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("loading.png"))
                    photobox.SizeMode = PictureBoxSizeMode.StretchImage
                    Dim tClient As WebClient = New WebClient
                    Try
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/works/photos/" & works_worker.Item("photo")(posToLoad))))
                        photobox.Image = tImage
                        download.Enabled = True

                    Catch ex As Exception
                        photobox.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.png"))
                        translations.load("errorMessages")
                        mainForm.statusMessage = translations.getText("errorDownloadingPhoto")
                    End Try
                    photobox.SizeMode = PictureBoxSizeMode.StretchImage
                End If

                Dim enableDel As Boolean = False
                If (works_worker.Item("contrato_file")(posToLoad).Equals("")) Then
                    contratoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    contratoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                    contratodel.Enabled = True
                End If
                If (works_worker.Item("destacamento_file")(posToLoad).Equals("")) Then
                    destacamentoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    destacamentodel.Enabled = True
                    destacamentoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("act_file")(posToLoad).Equals("")) Then
                    actImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    actdel.Enabled = True
                    actImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("a1_file")(posToLoad).Equals("")) Then
                    a1Img.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    a1del.Enabled = True
                    a1Img.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("mutuelle_file")(posToLoad).Equals("")) Then
                    mutuelleImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    mutuelledel.Enabled = True
                    mutuelleImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("medico_file")(posToLoad).Equals("")) Then
                    medicoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    medicodel.Enabled = True
                    medicoImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("gruista_file")(posToLoad).Equals("")) Then
                    gruistaImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    gruistadel.Enabled = True
                    gruistaImg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("cc_file")(posToLoad).Equals("")) Then
                    ccimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    ccdel.Enabled = True
                    ccimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If
                If (works_worker.Item("csaude_file")(posToLoad).Equals("")) Then
                    csaudeimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileMissingSmall.fw.png"))
                Else
                    enableDel = True
                    csaudedel.Enabled = True
                    csaudeimg.Image = Image.FromFile(state.imagesPath & Convert.ToString("fileokSmall.fw.png"))
                End If


                If enableDel Then
                    del_files.Enabled = True
                End If

                translations.load("workers")
                If (works_worker.Item("activo")(posToLoad).Equals("0")) Then
                    ativo.Checked = False
                    activolbl.Text = translations.getText("workerInactive")
                Else
                    activolbl.Text = translations.getText("workerActive")
                    ativo.Checked = True
                End If
                activodate.Text = If(Not IsDate(works_worker.Item("activo_date")(posToLoad)), "", works_worker.Item("activo_date")(posToLoad))
                csaudevalidade.Text = If(Not IsDate(works_worker.Item("csaude_validade")(posToLoad)), "", works_worker.Item("csaude_validade")(posToLoad))

                For i = 0 To refeicoes.Items.Count - 1
                    If refeicoes.Items(i).ToString().Equals(works_meals.Item("name")(InQueryDictionary(works_meals, works_worker.Item("cod_meal_place")(posToLoad), "cod_meal_place"))) Then
                        refeicoes.SelectedIndex = i
                    End If
                Next i
                For i = 0 To alojamento.Items.Count - 1
                    If alojamento.Items(i).ToString().Equals(works_lodging.Item("name")(InQueryDictionary(works_lodging, works_worker.Item("cod_lodging")(posToLoad), "cod_lodging"))) Then
                        alojamento.SelectedIndex = i
                    End If
                Next i

                notas.Text = works_worker.Item("notes")(posToLoad)
                quarto.Text = works_worker.Item("room")(posToLoad)

                If Not IsNothing(works_entreprise) Then
                    For i = 0 To works_entreprise.Item("cod_entreprise").Count - 1
                        If works_entreprise.Item("cod_entreprise")(i).Equals(works_worker.Item("cod_entreprise")(posToLoad)) Then
                            combo_empresa.SelectedIndex = i + 1
                            Exit For
                        End If
                    Next i
                End If
                If Not IsNothing(works_category) Then
                    For i = 0 To works_category.Item("cod_category").Count - 1
                        If works_category.Item("cod_category")(i).Equals(works_worker.Item("cod_category")(posToLoad)) Then
                            combo_catpro.SelectedIndex = i + 1
                            Exit For
                        End If
                    Next i
                End If

                loadLimosas()
                ResumeLayout()
                Refresh()

            End If
            EnforceAuthorities()
            listview_works.Enabled = True
            mainForm.busy.Close(True)
            enableButtonsAndLinks(Me, True)
            If listview_works.SelectedIndices(0) = 0 Then 'new worker
                saveNewCard.Enabled = False
            ElseIf Not nfc_card.SelectDevice() Then 'edit worker
                saveNewCard.Enabled = True
            End If
            Refresh()
        End If
    End Sub

    Sub EnforceAuthorities()

    End Sub

    Private Function detectChanges() As Boolean
        Dim changes As Boolean = False

        If (listview_works.SelectedItems.Count > 0 And prevSelection > 0) Then
            changes = If(Not changes And txt_name.Text.Equals(works_worker.Item("name")(prevSelection)), False, True)

            changes = If(Not changes And txt_mobile.Text.Equals(works_worker.Item("contact")(prevSelection)), False, True)
            changes = If(Not changes And txt_nfc.Text.Equals(works_worker.Item("cod_nfc")(prevSelection)), False, True)
            changes = If(Not changes And txt_112.Text.Equals(works_worker.Item("contact112")(prevSelection)), False, True)
            changes = If(Not changes And datanascimento_txt.Text.Equals(normDate(works_worker.Item("data_nascimento")(prevSelection))), False, True)
            'changes = If(Not changes And idade_txt.Text.Equals(works_worker.Item("")(prevSelection, 10)), False, True)


            changes = If(Not changes And nacionalidade.Text.Equals(works_worker.Item("nacionalidade")(prevSelection)), False, True)
            changes = If(Not changes And cartaocidadao.Text.Equals(works_worker.Item("cc")(prevSelection)), False, True)
            changes = If(Not changes And ccvalidoate.Text.Equals(If(Not IsDate(works_worker.Item("cc_validade")(prevSelection)), "", normDate(works_worker.Item("cc_validade")(prevSelection)))), False, True)

            changes = If(Not changes And nif.Text.Equals(works_worker.Item("nif")(prevSelection)), False, True)
            changes = If(Not changes And niss.Text.Equals(works_worker.Item("niss")(prevSelection)), False, True)
            If (works_worker.Item("filhos")(prevSelection).Equals("0")) Then
                changes = If(Not changes And quantosfilhos.Text.Equals(""), False, True)
            Else
                changes = If(Not changes And quantosfilhos.Text.Equals(works_worker.Item("filhos")(prevSelection)), False, True)
            End If
            If (works_worker.Item("filhos_encargo")(prevSelection).Equals("0")) Then
                changes = If(Not changes And filhosencquantos.Text.Equals(""), False, True)
            Else
                changes = If(Not changes And filhosencquantos.Text.Equals(works_worker.Item("filhos_encargo")(prevSelection)), False, True)
            End If
            changes = If(Not changes And email.Text.Equals(works_worker.Item("email")(prevSelection)), False, True)
            changes = If(Not changes And datainiciotrabalho.Text.Equals(If(Not IsDate(works_worker.Item("data_inicio_trabalho")(prevSelection)), "", normDate(works_worker.Item("data_inicio_trabalho")(prevSelection)))), False, True)
            changes = If(Not changes And morada.Text.Equals(works_worker.Item("morada")(prevSelection)), False, True)
            If (works_worker.Item("prob_saude")(prevSelection).Equals("0")) Then
                changes = If(Not changes And probsaudequais.Text.Equals(""), False, True)
            Else
                changes = If(Not changes And probsaudequais.Text.Equals(works_worker.Item("prob_saude")(prevSelection)), False, True)
            End If
            changes = If(Not changes And nib.Text.Equals(works_worker.Item("nib")(prevSelection)), False, True)
            changes = If(Not changes And peso.Text.Equals(works_worker.Item("peso")(prevSelection)), False, True)
            changes = If(Not changes And altura.Text.Equals(works_worker.Item("altura")(prevSelection)), False, True)

            changes = If(Not changes And pe.Text.Equals(works_worker.Item("pe")(prevSelection)), False, True)
            changes = If(Not changes And casaco.Text.Equals(works_worker.Item("casaco")(prevSelection)), False, True)
            changes = If(Not changes And calcas.Text.Equals(works_worker.Item("calcas")(prevSelection)), False, True)
            changes = If(Not changes And contratoFim.Text.Equals(If(Not IsDate(works_worker.Item("contrato_fim")(prevSelection)), "", normDate(works_worker.Item("contrato_fim")(prevSelection)))), False, True)
            changes = If(Not changes And contratoInicio.Text.Equals(If(Not IsDate(works_worker.Item("contrato_inicio")(prevSelection)), "", normDate(works_worker.Item("contrato_inicio")(prevSelection)))), False, True)
            changes = If(Not changes And destacamentoInicio.Text.Equals(If(Not IsDate(works_worker.Item("destacamento_inicio")(prevSelection)), "", normDate(works_worker.Item("destacamento_inicio")(prevSelection)))), False, True)
            changes = If(Not changes And destacamentoFim.Text.Equals(If(Not IsDate(works_worker.Item("destacamento_fim")(prevSelection)), "", normDate(works_worker.Item("destacamento_fim")(prevSelection)))), False, True)
            changes = If(Not changes And actFim.Text.Equals(If(Not IsDate(works_worker.Item("act_fim")(prevSelection)), "", normDate(works_worker.Item("act_fim")(prevSelection)))), False, True)
            changes = If(Not changes And actInicio.Text.Equals(If(Not IsDate(works_worker.Item("act_inicio")(prevSelection)), "", normDate(works_worker.Item("act_inicio")(prevSelection)))), False, True)
            changes = If(Not changes And a1Fim.Text.Equals(If(Not IsDate(works_worker.Item("a1_fim")(prevSelection)), "", normDate(works_worker.Item("a1_fim")(prevSelection)))), False, True)
            changes = If(Not changes And a1Inicio.Text.Equals(If(Not IsDate(works_worker.Item("a1_inicio")(prevSelection)), "", normDate(works_worker.Item("a1_inicio")(prevSelection)))), False, True)
            changes = If(Not changes And mutuelle.Text.Equals(If(Not IsDate(works_worker.Item("mutuelle_inicio")(prevSelection)), "", normDate(works_worker.Item("mutuelle_inicio")(prevSelection)))), False, True)
            changes = If(Not changes And medico.Text.Equals(If(Not IsDate(works_worker.Item("medico_inicio")(prevSelection)), "", normDate(works_worker.Item("medico_inicio")(prevSelection)))), False, True)

            changes = If(Not changes And refeicao.Text.Equals(works_worker.Item("refeicao")(prevSelection)), False, True)
            changes = If(Not changes And ajudascusto.Text.Equals(works_worker.Item("ajudascusto")(prevSelection)), False, True)
            changes = If(Not changes And salario.Text.Equals(works_worker.Item("salario")(prevSelection)), False, True)

            changes = If(Not changes And naturalidade.Text.Equals(works_worker.Item("naturalidade")(prevSelection)), False, True)
            changes = If(Not changes And concelho.Text.Equals(works_worker.Item("concelho")(prevSelection)), False, True)

            changes = If(Not changes And activodate.Text.Equals(If(Not IsDate(works_worker.Item("activo_date")(prevSelection)), "", normDate(works_worker.Item("activo_date")(prevSelection)))), False, True)
            changes = If(Not changes And csaudevalidade.Text.Equals(If(Not IsDate(works_worker.Item("csaude_validade")(prevSelection)), "", normDate(works_worker.Item("csaude_validade")(prevSelection)))), False, True)

            changes = If(Not changes And notas.Text.Equals(works_worker.Item("notes")(prevSelection)), False, True)

            Return changes
        Else
            Return changes
        End If
    End Function


End Class