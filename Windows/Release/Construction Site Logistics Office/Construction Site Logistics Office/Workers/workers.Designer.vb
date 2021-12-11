<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class workers_frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workers_frm))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.workerSideWrapper = New System.Windows.Forms.Panel()
        Me.GroupBoxWorkers = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.workersUpdateBtn = New System.Windows.Forms.PictureBox()
        Me.workersListSelection = New System.Windows.Forms.ComboBox()
        Me.numWorkers = New System.Windows.Forms.Label()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.searchBoxBtn = New System.Windows.Forms.PictureBox()
        Me.company_lbl = New System.Windows.Forms.Label()
        Me.txt_nfc = New System.Windows.Forms.TextBox()
        Me.combo_empresa = New System.Windows.Forms.ComboBox()
        Me.nfcCode_lbl = New System.Windows.Forms.Label()
        Me.txt_mobile = New System.Windows.Forms.TextBox()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.contact_lbl = New System.Windows.Forms.Label()
        Me.combo_catpro = New System.Windows.Forms.ComboBox()
        Me.contact112_lbl = New System.Windows.Forms.Label()
        Me.catPro_lbl = New System.Windows.Forms.Label()
        Me.txt_112 = New System.Windows.Forms.TextBox()
        Me.nome_lbl = New System.Windows.Forms.Label()
        Me.photobox = New System.Windows.Forms.PictureBox()
        Me.datanascimento_txt = New System.Windows.Forms.TextBox()
        Me.dataNasc_lbl = New System.Windows.Forms.Label()
        Me.idade_txt = New System.Windows.Forms.TextBox()
        Me.age_lbl = New System.Windows.Forms.Label()
        Me.estadoCivil = New System.Windows.Forms.ComboBox()
        Me.estadoCivil_lbl = New System.Windows.Forms.Label()
        Me.nacionalidade = New System.Windows.Forms.TextBox()
        Me.country_lbl = New System.Windows.Forms.Label()
        Me.cartaocidadao = New System.Windows.Forms.TextBox()
        Me.cc_lbl = New System.Windows.Forms.Label()
        Me.ccvalidoate = New System.Windows.Forms.TextBox()
        Me.cc_valid_lbl = New System.Windows.Forms.Label()
        Me.nif = New System.Windows.Forms.TextBox()
        Me.nif_lbl = New System.Windows.Forms.Label()
        Me.niss = New System.Windows.Forms.TextBox()
        Me.niss_lbl = New System.Windows.Forms.Label()
        Me.filhos = New System.Windows.Forms.ComboBox()
        Me.kids_lbl = New System.Windows.Forms.Label()
        Me.quantosfilhos = New System.Windows.Forms.TextBox()
        Me.kids_num_lbl = New System.Windows.Forms.Label()
        Me.filhosenc = New System.Windows.Forms.ComboBox()
        Me.kidsEnc_lbl = New System.Windows.Forms.Label()
        Me.filhosencquantos = New System.Windows.Forms.TextBox()
        Me.kidsEnc_num_lbl = New System.Windows.Forms.Label()
        Me.email = New System.Windows.Forms.TextBox()
        Me.email_lbl = New System.Windows.Forms.Label()
        Me.datainiciotrabalho = New System.Windows.Forms.TextBox()
        Me.WorkStartDate_lbl = New System.Windows.Forms.Label()
        Me.morada = New System.Windows.Forms.TextBox()
        Me.morada_lbl = New System.Windows.Forms.Label()
        Me.nib = New System.Windows.Forms.TextBox()
        Me.nib_lbl = New System.Windows.Forms.Label()
        Me.probsaude = New System.Windows.Forms.ComboBox()
        Me.probSaude_lbl = New System.Windows.Forms.Label()
        Me.probsaudequais = New System.Windows.Forms.TextBox()
        Me.quais_lbl = New System.Windows.Forms.Label()
        Me.peso = New System.Windows.Forms.TextBox()
        Me.peso_lbl = New System.Windows.Forms.Label()
        Me.altura = New System.Windows.Forms.TextBox()
        Me.altura_lbl = New System.Windows.Forms.Label()
        Me.calcas = New System.Windows.Forms.TextBox()
        Me.calcas_lbl = New System.Windows.Forms.Label()
        Me.pe = New System.Windows.Forms.TextBox()
        Me.pe_lbl = New System.Windows.Forms.Label()
        Me.casaco = New System.Windows.Forms.TextBox()
        Me.casaco_lbl = New System.Windows.Forms.Label()
        Me.actInicio = New System.Windows.Forms.TextBox()
        Me.inicio_lbl = New System.Windows.Forms.Label()
        Me.actFim = New System.Windows.Forms.TextBox()
        Me.fim_lbl = New System.Windows.Forms.Label()
        Me.act_lbl = New System.Windows.Forms.Label()
        Me.destacamentoInicio = New System.Windows.Forms.TextBox()
        Me.destacamentoFim = New System.Windows.Forms.TextBox()
        Me.destacamento_lbl = New System.Windows.Forms.Label()
        Me.contratoInicio = New System.Windows.Forms.TextBox()
        Me.contratoFim = New System.Windows.Forms.TextBox()
        Me.contrato_lbl = New System.Windows.Forms.Label()
        Me.a1Inicio = New System.Windows.Forms.TextBox()
        Me.a1Fim = New System.Windows.Forms.TextBox()
        Me.a1_lbl = New System.Windows.Forms.Label()
        Me.mutuelle = New System.Windows.Forms.TextBox()
        Me.mutuelle_lbl = New System.Windows.Forms.Label()
        Me.limosas_lbl = New System.Windows.Forms.Label()
        Me.medico = New System.Windows.Forms.TextBox()
        Me.medic_lbl = New System.Windows.Forms.Label()
        Me.destacamentoactfile = New System.Windows.Forms.TextBox()
        Me.file_lbl = New System.Windows.Forms.Label()
        Me.actBtn = New System.Windows.Forms.Button()
        Me.destacamentofile = New System.Windows.Forms.TextBox()
        Me.destacamentoBtn = New System.Windows.Forms.Button()
        Me.contratofile = New System.Windows.Forms.TextBox()
        Me.contractFileBtn = New System.Windows.Forms.Button()
        Me.a1file = New System.Windows.Forms.TextBox()
        Me.a1Btn = New System.Windows.Forms.Button()
        Me.mutuellefile = New System.Windows.Forms.TextBox()
        Me.mutuelleBtn = New System.Windows.Forms.Button()
        Me.limosafile = New System.Windows.Forms.TextBox()
        Me.btn_limosa = New System.Windows.Forms.Button()
        Me.medicofile = New System.Windows.Forms.TextBox()
        Me.medicBtn = New System.Windows.Forms.Button()
        Me.gruista_lbl = New System.Windows.Forms.Label()
        Me.gruistaFile = New System.Windows.Forms.TextBox()
        Me.cranemanBtn = New System.Windows.Forms.Button()
        Me.limosaSite_lbl = New System.Windows.Forms.Label()
        Me.obra = New System.Windows.Forms.ComboBox()
        Me.del_limosa = New System.Windows.Forms.LinkLabel()
        Me.save_limosa = New System.Windows.Forms.LinkLabel()
        Me.limosaList = New System.Windows.Forms.ListBox()
        Me.contratoImg = New System.Windows.Forms.PictureBox()
        Me.destacamentoImg = New System.Windows.Forms.PictureBox()
        Me.actImg = New System.Windows.Forms.PictureBox()
        Me.a1Img = New System.Windows.Forms.PictureBox()
        Me.mutuelleImg = New System.Windows.Forms.PictureBox()
        Me.medicoImg = New System.Windows.Forms.PictureBox()
        Me.gruistaImg = New System.Windows.Forms.PictureBox()
        Me.calendar = New System.Windows.Forms.MonthCalendar()
        Me.addCalendarDateLink = New System.Windows.Forms.LinkLabel()
        Me.limosasImg = New System.Windows.Forms.PictureBox()
        Me.classificacao = New System.Windows.Forms.ComboBox()
        Me.classification_lbl = New System.Windows.Forms.Label()
        Me.salario = New System.Windows.Forms.TextBox()
        Me.salary_lbl = New System.Windows.Forms.Label()
        Me.salario_euro_mes = New System.Windows.Forms.Label()
        Me.refeicao = New System.Windows.Forms.TextBox()
        Me.refeicao_lbl = New System.Windows.Forms.Label()
        Me.refeicao_euro_mes = New System.Windows.Forms.Label()
        Me.ajudascusto = New System.Windows.Forms.TextBox()
        Me.acusto_lbl = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.localizacao = New System.Windows.Forms.ComboBox()
        Me.location_lbl = New System.Windows.Forms.Label()
        Me.alojamento = New System.Windows.Forms.ComboBox()
        Me.lodging_lbl = New System.Windows.Forms.Label()
        Me.naturalidade = New System.Windows.Forms.TextBox()
        Me.naturalidade_lbl = New System.Windows.Forms.Label()
        Me.concelho = New System.Windows.Forms.TextBox()
        Me.concelho_lbl = New System.Windows.Forms.Label()
        Me.cc_file_lbl = New System.Windows.Forms.Label()
        Me.ccfile = New System.Windows.Forms.TextBox()
        Me.ccBtn = New System.Windows.Forms.Button()
        Me.ccimg = New System.Windows.Forms.PictureBox()
        Me.csaude_lbl = New System.Windows.Forms.Label()
        Me.csaudefile = New System.Windows.Forms.TextBox()
        Me.cseBtn = New System.Windows.Forms.Button()
        Me.csaudeimg = New System.Windows.Forms.PictureBox()
        Me.contratodel = New System.Windows.Forms.CheckBox()
        Me.destacamentodel = New System.Windows.Forms.CheckBox()
        Me.actdel = New System.Windows.Forms.CheckBox()
        Me.a1del = New System.Windows.Forms.CheckBox()
        Me.mutuelledel = New System.Windows.Forms.CheckBox()
        Me.medicodel = New System.Windows.Forms.CheckBox()
        Me.gruistadel = New System.Windows.Forms.CheckBox()
        Me.ccdel = New System.Windows.Forms.CheckBox()
        Me.csaudedel = New System.Windows.Forms.CheckBox()
        Me.del_files = New System.Windows.Forms.LinkLabel()
        Me.docs_title_lbl = New System.Windows.Forms.Label()
        Me.WorkerFile_title = New System.Windows.Forms.Label()
        Me.mandatoryLbl = New System.Windows.Forms.Label()
        Me.ativo = New System.Windows.Forms.CheckBox()
        Me.activodate = New System.Windows.Forms.TextBox()
        Me.activolbl = New System.Windows.Forms.Label()
        Me.csaudevalidade = New System.Windows.Forms.TextBox()
        Me.validade_lbl = New System.Windows.Forms.Label()
        Me.download = New System.Windows.Forms.LinkLabel()
        Me.qrcode_img = New System.Windows.Forms.PictureBox()
        Me.refeicoes = New System.Windows.Forms.ComboBox()
        Me.placeMeals_lbl = New System.Windows.Forms.Label()
        Me.workerFile_divider = New System.Windows.Forms.Label()
        Me.docs_divider = New System.Windows.Forms.Label()
        Me.limosa_divider = New System.Windows.Forms.Label()
        Me.notas = New System.Windows.Forms.TextBox()
        Me.notes_lbl = New System.Windows.Forms.Label()
        Me.quarto = New System.Windows.Forms.TextBox()
        Me.quartolbl = New System.Windows.Forms.Label()
        Me.limosaStartDate_lbl = New System.Windows.Forms.Label()
        Me.duracaoFimLimosa = New System.Windows.Forms.DateTimePicker()
        Me.duracaoInicioLimosa = New System.Windows.Forms.DateTimePicker()
        Me.limosaValidTo_lbl = New System.Windows.Forms.Label()
        Me.workerMainWrapper = New System.Windows.Forms.Panel()
        Me.GroupBoxLimosas = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.nfc_auth_code_lbl = New System.Windows.Forms.Label()
        Me.nfc_auth_code = New System.Windows.Forms.TextBox()
        Me.saveNewCard = New System.Windows.Forms.LinkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.saveWorkerCard = New System.Windows.Forms.Button()
        Me.delWorkerCard = New System.Windows.Forms.Button()
        Me.workerBottomWrapper = New System.Windows.Forms.Panel()
        Me.workerSideWrapper.SuspendLayout()
        Me.GroupBoxWorkers.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchGroupBox.SuspendLayout()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contratoImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.destacamentoImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.a1Img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mutuelleImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.medicoImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gruistaImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.limosasImg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ccimg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.csaudeimg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qrcode_img, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.workerMainWrapper.SuspendLayout()
        Me.GroupBoxLimosas.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.workerBottomWrapper.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'workerSideWrapper
        '
        Me.workerSideWrapper.Controls.Add(Me.GroupBoxWorkers)
        Me.workerSideWrapper.Controls.Add(Me.SearchGroupBox)
        Me.workerSideWrapper.Dock = System.Windows.Forms.DockStyle.Left
        Me.workerSideWrapper.Location = New System.Drawing.Point(0, 0)
        Me.workerSideWrapper.Name = "workerSideWrapper"
        Me.workerSideWrapper.Size = New System.Drawing.Size(377, 968)
        Me.workerSideWrapper.TabIndex = 196
        Me.workerSideWrapper.Visible = False
        '
        'GroupBoxWorkers
        '
        Me.GroupBoxWorkers.Controls.Add(Me.Panel1)
        Me.GroupBoxWorkers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxWorkers.Location = New System.Drawing.Point(12, 63)
        Me.GroupBoxWorkers.Name = "GroupBoxWorkers"
        Me.GroupBoxWorkers.Size = New System.Drawing.Size(343, 746)
        Me.GroupBoxWorkers.TabIndex = 199
        Me.GroupBoxWorkers.TabStop = False
        Me.GroupBoxWorkers.Text = "Trabalhadores registados"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.workersUpdateBtn)
        Me.Panel1.Controls.Add(Me.workersListSelection)
        Me.Panel1.Controls.Add(Me.numWorkers)
        Me.Panel1.Controls.Add(Me.listview_works)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 726)
        Me.Panel1.TabIndex = 0
        '
        'workersUpdateBtn
        '
        Me.workersUpdateBtn.Image = CType(resources.GetObject("workersUpdateBtn.Image"), System.Drawing.Image)
        Me.workersUpdateBtn.InitialImage = Nothing
        Me.workersUpdateBtn.Location = New System.Drawing.Point(297, 37)
        Me.workersUpdateBtn.Name = "workersUpdateBtn"
        Me.workersUpdateBtn.Size = New System.Drawing.Size(29, 29)
        Me.workersUpdateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.workersUpdateBtn.TabIndex = 222
        Me.workersUpdateBtn.TabStop = False
        '
        'workersListSelection
        '
        Me.workersListSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.workersListSelection.FormattingEnabled = True
        Me.workersListSelection.Location = New System.Drawing.Point(6, 10)
        Me.workersListSelection.Name = "workersListSelection"
        Me.workersListSelection.Size = New System.Drawing.Size(321, 21)
        Me.workersListSelection.TabIndex = 203
        '
        'numWorkers
        '
        Me.numWorkers.AutoSize = True
        Me.numWorkers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numWorkers.Location = New System.Drawing.Point(3, 34)
        Me.numWorkers.Name = "numWorkers"
        Me.numWorkers.Size = New System.Drawing.Size(120, 13)
        Me.numWorkers.TabIndex = 200
        Me.numWorkers.Text = "Num. trabalhadores"
        '
        'listview_works
        '
        Me.listview_works.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.Location = New System.Drawing.Point(3, 72)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.ScrollAlwaysVisible = True
        Me.listview_works.Size = New System.Drawing.Size(323, 637)
        Me.listview_works.TabIndex = 199
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.searchbox)
        Me.SearchGroupBox.Controls.Add(Me.searchBoxBtn)
        Me.SearchGroupBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchGroupBox.Location = New System.Drawing.Point(12, 6)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(343, 51)
        Me.SearchGroupBox.TabIndex = 198
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "Procurar"
        '
        'searchbox
        '
        Me.searchbox.Location = New System.Drawing.Point(9, 21)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(296, 21)
        Me.searchbox.TabIndex = 192
        '
        'searchBoxBtn
        '
        Me.searchBoxBtn.Image = CType(resources.GetObject("searchBoxBtn.Image"), System.Drawing.Image)
        Me.searchBoxBtn.InitialImage = Nothing
        Me.searchBoxBtn.Location = New System.Drawing.Point(311, 19)
        Me.searchBoxBtn.Name = "searchBoxBtn"
        Me.searchBoxBtn.Size = New System.Drawing.Size(21, 21)
        Me.searchBoxBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchBoxBtn.TabIndex = 193
        Me.searchBoxBtn.TabStop = False
        '
        'company_lbl
        '
        Me.company_lbl.AutoSize = True
        Me.company_lbl.Location = New System.Drawing.Point(350, 16)
        Me.company_lbl.Name = "company_lbl"
        Me.company_lbl.Size = New System.Drawing.Size(52, 13)
        Me.company_lbl.TabIndex = 10
        Me.company_lbl.Text = "Empresa*"
        '
        'txt_nfc
        '
        Me.txt_nfc.Location = New System.Drawing.Point(19, 36)
        Me.txt_nfc.Name = "txt_nfc"
        Me.txt_nfc.Size = New System.Drawing.Size(258, 20)
        Me.txt_nfc.TabIndex = 37
        '
        'combo_empresa
        '
        Me.combo_empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_empresa.FormattingEnabled = True
        Me.combo_empresa.Location = New System.Drawing.Point(353, 33)
        Me.combo_empresa.Name = "combo_empresa"
        Me.combo_empresa.Size = New System.Drawing.Size(229, 21)
        Me.combo_empresa.TabIndex = 27
        '
        'nfcCode_lbl
        '
        Me.nfcCode_lbl.AutoSize = True
        Me.nfcCode_lbl.Location = New System.Drawing.Point(16, 19)
        Me.nfcCode_lbl.Name = "nfcCode_lbl"
        Me.nfcCode_lbl.Size = New System.Drawing.Size(78, 13)
        Me.nfcCode_lbl.TabIndex = 8
        Me.nfcCode_lbl.Text = "Código Cartao*"
        '
        'txt_mobile
        '
        Me.txt_mobile.Location = New System.Drawing.Point(18, 124)
        Me.txt_mobile.Name = "txt_mobile"
        Me.txt_mobile.Size = New System.Drawing.Size(179, 20)
        Me.txt_mobile.TabIndex = 40
        '
        'txt_name
        '
        Me.txt_name.Location = New System.Drawing.Point(17, 43)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(489, 20)
        Me.txt_name.TabIndex = 1
        '
        'contact_lbl
        '
        Me.contact_lbl.AutoSize = True
        Me.contact_lbl.Location = New System.Drawing.Point(15, 107)
        Me.contact_lbl.Name = "contact_lbl"
        Me.contact_lbl.Size = New System.Drawing.Size(54, 13)
        Me.contact_lbl.TabIndex = 4
        Me.contact_lbl.Text = "Contacto*"
        '
        'combo_catpro
        '
        Me.combo_catpro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_catpro.FormattingEnabled = True
        Me.combo_catpro.Location = New System.Drawing.Point(15, 33)
        Me.combo_catpro.Name = "combo_catpro"
        Me.combo_catpro.Size = New System.Drawing.Size(305, 21)
        Me.combo_catpro.TabIndex = 26
        '
        'contact112_lbl
        '
        Me.contact112_lbl.AutoSize = True
        Me.contact112_lbl.Location = New System.Drawing.Point(208, 107)
        Me.contact112_lbl.Name = "contact112_lbl"
        Me.contact112_lbl.Size = New System.Drawing.Size(123, 13)
        Me.contact112_lbl.TabIndex = 33
        Me.contact112_lbl.Text = "Contacto de emergência"
        '
        'catPro_lbl
        '
        Me.catPro_lbl.AutoSize = True
        Me.catPro_lbl.Location = New System.Drawing.Point(12, 16)
        Me.catPro_lbl.Name = "catPro_lbl"
        Me.catPro_lbl.Size = New System.Drawing.Size(112, 13)
        Me.catPro_lbl.TabIndex = 2
        Me.catPro_lbl.Text = "Categoria Profissional*"
        '
        'txt_112
        '
        Me.txt_112.Location = New System.Drawing.Point(211, 124)
        Me.txt_112.Name = "txt_112"
        Me.txt_112.Size = New System.Drawing.Size(183, 20)
        Me.txt_112.TabIndex = 41
        '
        'nome_lbl
        '
        Me.nome_lbl.AutoSize = True
        Me.nome_lbl.Location = New System.Drawing.Point(14, 26)
        Me.nome_lbl.Name = "nome_lbl"
        Me.nome_lbl.Size = New System.Drawing.Size(39, 13)
        Me.nome_lbl.TabIndex = 26
        Me.nome_lbl.Text = "Nome*"
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(25, 63)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(225, 225)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 35
        Me.photobox.TabStop = False
        '
        'datanascimento_txt
        '
        Me.datanascimento_txt.Location = New System.Drawing.Point(533, 42)
        Me.datanascimento_txt.Name = "datanascimento_txt"
        Me.datanascimento_txt.Size = New System.Drawing.Size(119, 20)
        Me.datanascimento_txt.TabIndex = 2
        '
        'dataNasc_lbl
        '
        Me.dataNasc_lbl.AutoSize = True
        Me.dataNasc_lbl.Location = New System.Drawing.Point(530, 26)
        Me.dataNasc_lbl.Name = "dataNasc_lbl"
        Me.dataNasc_lbl.Size = New System.Drawing.Size(106, 13)
        Me.dataNasc_lbl.TabIndex = 36
        Me.dataNasc_lbl.Text = "Data de nascimento*"
        '
        'idade_txt
        '
        Me.idade_txt.Location = New System.Drawing.Point(714, 42)
        Me.idade_txt.Name = "idade_txt"
        Me.idade_txt.Size = New System.Drawing.Size(54, 20)
        Me.idade_txt.TabIndex = 3
        '
        'age_lbl
        '
        Me.age_lbl.AutoSize = True
        Me.age_lbl.Location = New System.Drawing.Point(711, 26)
        Me.age_lbl.Name = "age_lbl"
        Me.age_lbl.Size = New System.Drawing.Size(38, 13)
        Me.age_lbl.TabIndex = 38
        Me.age_lbl.Text = "Idade*"
        '
        'estadoCivil
        '
        Me.estadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.estadoCivil.FormattingEnabled = True
        Me.estadoCivil.Items.AddRange(New Object() {"Solteiro", "Divorciado", "Casado"})
        Me.estadoCivil.Location = New System.Drawing.Point(18, 138)
        Me.estadoCivil.Name = "estadoCivil"
        Me.estadoCivil.Size = New System.Drawing.Size(148, 21)
        Me.estadoCivil.TabIndex = 8
        '
        'estadoCivil_lbl
        '
        Me.estadoCivil_lbl.AutoSize = True
        Me.estadoCivil_lbl.Location = New System.Drawing.Point(15, 121)
        Me.estadoCivil_lbl.Name = "estadoCivil_lbl"
        Me.estadoCivil_lbl.Size = New System.Drawing.Size(66, 13)
        Me.estadoCivil_lbl.TabIndex = 40
        Me.estadoCivil_lbl.Text = "Estado Civil*"
        '
        'nacionalidade
        '
        Me.nacionalidade.Location = New System.Drawing.Point(17, 92)
        Me.nacionalidade.Name = "nacionalidade"
        Me.nacionalidade.Size = New System.Drawing.Size(243, 20)
        Me.nacionalidade.TabIndex = 4
        '
        'country_lbl
        '
        Me.country_lbl.AutoSize = True
        Me.country_lbl.Location = New System.Drawing.Point(14, 75)
        Me.country_lbl.Name = "country_lbl"
        Me.country_lbl.Size = New System.Drawing.Size(79, 13)
        Me.country_lbl.TabIndex = 42
        Me.country_lbl.Text = "Nacionalidade*"
        '
        'cartaocidadao
        '
        Me.cartaocidadao.Location = New System.Drawing.Point(205, 138)
        Me.cartaocidadao.Name = "cartaocidadao"
        Me.cartaocidadao.Size = New System.Drawing.Size(171, 20)
        Me.cartaocidadao.TabIndex = 9
        '
        'cc_lbl
        '
        Me.cc_lbl.AutoSize = True
        Me.cc_lbl.Location = New System.Drawing.Point(202, 121)
        Me.cc_lbl.Name = "cc_lbl"
        Me.cc_lbl.Size = New System.Drawing.Size(99, 13)
        Me.cc_lbl.TabIndex = 44
        Me.cc_lbl.Text = "Cartão do Cidadão*"
        '
        'ccvalidoate
        '
        Me.ccvalidoate.Location = New System.Drawing.Point(408, 138)
        Me.ccvalidoate.Name = "ccvalidoate"
        Me.ccvalidoate.Size = New System.Drawing.Size(98, 20)
        Me.ccvalidoate.TabIndex = 10
        '
        'cc_valid_lbl
        '
        Me.cc_valid_lbl.AutoSize = True
        Me.cc_valid_lbl.Location = New System.Drawing.Point(405, 122)
        Me.cc_valid_lbl.Name = "cc_valid_lbl"
        Me.cc_valid_lbl.Size = New System.Drawing.Size(57, 13)
        Me.cc_valid_lbl.TabIndex = 46
        Me.cc_valid_lbl.Text = "válido até*"
        '
        'nif
        '
        Me.nif.Location = New System.Drawing.Point(528, 138)
        Me.nif.Name = "nif"
        Me.nif.Size = New System.Drawing.Size(162, 20)
        Me.nif.TabIndex = 11
        '
        'nif_lbl
        '
        Me.nif_lbl.AutoSize = True
        Me.nif_lbl.Location = New System.Drawing.Point(525, 121)
        Me.nif_lbl.Name = "nif_lbl"
        Me.nif_lbl.Size = New System.Drawing.Size(28, 13)
        Me.nif_lbl.TabIndex = 48
        Me.nif_lbl.Text = "NIF*"
        '
        'niss
        '
        Me.niss.Location = New System.Drawing.Point(728, 138)
        Me.niss.Name = "niss"
        Me.niss.Size = New System.Drawing.Size(157, 20)
        Me.niss.TabIndex = 12
        '
        'niss_lbl
        '
        Me.niss_lbl.AutoSize = True
        Me.niss_lbl.Location = New System.Drawing.Point(725, 121)
        Me.niss_lbl.Name = "niss_lbl"
        Me.niss_lbl.Size = New System.Drawing.Size(36, 13)
        Me.niss_lbl.TabIndex = 50
        Me.niss_lbl.Text = "NISS*"
        '
        'filhos
        '
        Me.filhos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filhos.FormattingEnabled = True
        Me.filhos.Items.AddRange(New Object() {"Não", "Sim"})
        Me.filhos.Location = New System.Drawing.Point(16, 32)
        Me.filhos.Name = "filhos"
        Me.filhos.Size = New System.Drawing.Size(72, 21)
        Me.filhos.TabIndex = 15
        '
        'kids_lbl
        '
        Me.kids_lbl.AutoSize = True
        Me.kids_lbl.Location = New System.Drawing.Point(14, 16)
        Me.kids_lbl.Name = "kids_lbl"
        Me.kids_lbl.Size = New System.Drawing.Size(55, 13)
        Me.kids_lbl.TabIndex = 52
        Me.kids_lbl.Text = "Tem filhos"
        '
        'quantosfilhos
        '
        Me.quantosfilhos.Location = New System.Drawing.Point(105, 33)
        Me.quantosfilhos.Name = "quantosfilhos"
        Me.quantosfilhos.Size = New System.Drawing.Size(63, 20)
        Me.quantosfilhos.TabIndex = 16
        '
        'kids_num_lbl
        '
        Me.kids_num_lbl.AutoSize = True
        Me.kids_num_lbl.Location = New System.Drawing.Point(102, 16)
        Me.kids_num_lbl.Name = "kids_num_lbl"
        Me.kids_num_lbl.Size = New System.Drawing.Size(45, 13)
        Me.kids_num_lbl.TabIndex = 54
        Me.kids_num_lbl.Text = "quantos"
        '
        'filhosenc
        '
        Me.filhosenc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filhosenc.FormattingEnabled = True
        Me.filhosenc.Items.AddRange(New Object() {"Não", "Sim"})
        Me.filhosenc.Location = New System.Drawing.Point(202, 33)
        Me.filhosenc.Name = "filhosenc"
        Me.filhosenc.Size = New System.Drawing.Size(88, 21)
        Me.filhosenc.TabIndex = 17
        '
        'kidsEnc_lbl
        '
        Me.kidsEnc_lbl.AutoSize = True
        Me.kidsEnc_lbl.Location = New System.Drawing.Point(199, 17)
        Me.kidsEnc_lbl.Name = "kidsEnc_lbl"
        Me.kidsEnc_lbl.Size = New System.Drawing.Size(91, 13)
        Me.kidsEnc_lbl.TabIndex = 56
        Me.kidsEnc_lbl.Text = "Filhos ao encargo"
        '
        'filhosencquantos
        '
        Me.filhosencquantos.Location = New System.Drawing.Point(308, 33)
        Me.filhosencquantos.Name = "filhosencquantos"
        Me.filhosencquantos.Size = New System.Drawing.Size(63, 20)
        Me.filhosencquantos.TabIndex = 18
        '
        'kidsEnc_num_lbl
        '
        Me.kidsEnc_num_lbl.AutoSize = True
        Me.kidsEnc_num_lbl.Location = New System.Drawing.Point(305, 16)
        Me.kidsEnc_num_lbl.Name = "kidsEnc_num_lbl"
        Me.kidsEnc_num_lbl.Size = New System.Drawing.Size(45, 13)
        Me.kidsEnc_num_lbl.TabIndex = 58
        Me.kidsEnc_num_lbl.Text = "quantos"
        '
        'email
        '
        Me.email.Location = New System.Drawing.Point(19, 79)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(322, 20)
        Me.email.TabIndex = 39
        '
        'email_lbl
        '
        Me.email_lbl.AutoSize = True
        Me.email_lbl.Location = New System.Drawing.Point(16, 63)
        Me.email_lbl.Name = "email_lbl"
        Me.email_lbl.Size = New System.Drawing.Size(32, 13)
        Me.email_lbl.TabIndex = 60
        Me.email_lbl.Text = "Email"
        '
        'datainiciotrabalho
        '
        Me.datainiciotrabalho.Location = New System.Drawing.Point(406, 131)
        Me.datainiciotrabalho.Name = "datainiciotrabalho"
        Me.datainiciotrabalho.Size = New System.Drawing.Size(116, 20)
        Me.datainiciotrabalho.TabIndex = 33
        '
        'WorkStartDate_lbl
        '
        Me.WorkStartDate_lbl.AutoSize = True
        Me.WorkStartDate_lbl.Location = New System.Drawing.Point(404, 115)
        Me.WorkStartDate_lbl.Name = "WorkStartDate_lbl"
        Me.WorkStartDate_lbl.Size = New System.Drawing.Size(118, 13)
        Me.WorkStartDate_lbl.TabIndex = 62
        Me.WorkStartDate_lbl.Text = "Data Inicio do trabalho*"
        '
        'morada
        '
        Me.morada.Location = New System.Drawing.Point(18, 187)
        Me.morada.Multiline = True
        Me.morada.Name = "morada"
        Me.morada.Size = New System.Drawing.Size(477, 71)
        Me.morada.TabIndex = 13
        '
        'morada_lbl
        '
        Me.morada_lbl.AutoSize = True
        Me.morada_lbl.Location = New System.Drawing.Point(15, 171)
        Me.morada_lbl.Name = "morada_lbl"
        Me.morada_lbl.Size = New System.Drawing.Size(47, 13)
        Me.morada_lbl.TabIndex = 64
        Me.morada_lbl.Text = "Morada*"
        '
        'nib
        '
        Me.nib.Location = New System.Drawing.Point(15, 131)
        Me.nib.Name = "nib"
        Me.nib.Size = New System.Drawing.Size(357, 20)
        Me.nib.TabIndex = 32
        '
        'nib_lbl
        '
        Me.nib_lbl.AutoSize = True
        Me.nib_lbl.Location = New System.Drawing.Point(12, 115)
        Me.nib_lbl.Name = "nib_lbl"
        Me.nib_lbl.Size = New System.Drawing.Size(135, 13)
        Me.nib_lbl.TabIndex = 66
        Me.nib_lbl.Text = "número de conta bancária*"
        '
        'probsaude
        '
        Me.probsaude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.probsaude.FormattingEnabled = True
        Me.probsaude.Items.AddRange(New Object() {"Não", "Sim"})
        Me.probsaude.Location = New System.Drawing.Point(299, 69)
        Me.probsaude.Name = "probsaude"
        Me.probsaude.Size = New System.Drawing.Size(72, 21)
        Me.probsaude.TabIndex = 19
        '
        'probSaude_lbl
        '
        Me.probSaude_lbl.Location = New System.Drawing.Point(101, 72)
        Me.probSaude_lbl.Name = "probSaude_lbl"
        Me.probSaude_lbl.Size = New System.Drawing.Size(194, 18)
        Me.probSaude_lbl.TabIndex = 68
        Me.probSaude_lbl.Text = "Problemas de saúde particulares?"
        Me.probSaude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'probsaudequais
        '
        Me.probsaudequais.Location = New System.Drawing.Point(101, 96)
        Me.probsaudequais.Multiline = True
        Me.probsaudequais.Name = "probsaudequais"
        Me.probsaudequais.Size = New System.Drawing.Size(272, 60)
        Me.probsaudequais.TabIndex = 20
        '
        'quais_lbl
        '
        Me.quais_lbl.Location = New System.Drawing.Point(16, 120)
        Me.quais_lbl.Name = "quais_lbl"
        Me.quais_lbl.Size = New System.Drawing.Size(79, 33)
        Me.quais_lbl.TabIndex = 70
        Me.quais_lbl.Text = "Quais?"
        Me.quais_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'peso
        '
        Me.peso.Location = New System.Drawing.Point(537, 90)
        Me.peso.Name = "peso"
        Me.peso.Size = New System.Drawing.Size(63, 20)
        Me.peso.TabIndex = 24
        '
        'peso_lbl
        '
        Me.peso_lbl.AutoSize = True
        Me.peso_lbl.Location = New System.Drawing.Point(534, 74)
        Me.peso_lbl.Name = "peso_lbl"
        Me.peso_lbl.Size = New System.Drawing.Size(50, 13)
        Me.peso_lbl.TabIndex = 72
        Me.peso_lbl.Text = "Peso(Kg)"
        '
        'altura
        '
        Me.altura.Location = New System.Drawing.Point(629, 90)
        Me.altura.Name = "altura"
        Me.altura.Size = New System.Drawing.Size(63, 20)
        Me.altura.TabIndex = 25
        '
        'altura_lbl
        '
        Me.altura_lbl.AutoSize = True
        Me.altura_lbl.Location = New System.Drawing.Point(626, 74)
        Me.altura_lbl.Name = "altura_lbl"
        Me.altura_lbl.Size = New System.Drawing.Size(48, 13)
        Me.altura_lbl.TabIndex = 74
        Me.altura_lbl.Text = "Altura(m)"
        '
        'calcas
        '
        Me.calcas.Location = New System.Drawing.Point(537, 39)
        Me.calcas.Name = "calcas"
        Me.calcas.Size = New System.Drawing.Size(83, 20)
        Me.calcas.TabIndex = 21
        '
        'calcas_lbl
        '
        Me.calcas_lbl.AutoSize = True
        Me.calcas_lbl.Location = New System.Drawing.Point(534, 22)
        Me.calcas_lbl.Name = "calcas_lbl"
        Me.calcas_lbl.Size = New System.Drawing.Size(39, 13)
        Me.calcas_lbl.TabIndex = 76
        Me.calcas_lbl.Text = "Calças"
        '
        'pe
        '
        Me.pe.Location = New System.Drawing.Point(629, 39)
        Me.pe.Name = "pe"
        Me.pe.Size = New System.Drawing.Size(63, 20)
        Me.pe.TabIndex = 22
        '
        'pe_lbl
        '
        Me.pe_lbl.AutoSize = True
        Me.pe_lbl.Location = New System.Drawing.Point(626, 22)
        Me.pe_lbl.Name = "pe_lbl"
        Me.pe_lbl.Size = New System.Drawing.Size(20, 13)
        Me.pe_lbl.TabIndex = 78
        Me.pe_lbl.Text = "Pé"
        '
        'casaco
        '
        Me.casaco.Location = New System.Drawing.Point(709, 39)
        Me.casaco.Name = "casaco"
        Me.casaco.Size = New System.Drawing.Size(63, 20)
        Me.casaco.TabIndex = 23
        '
        'casaco_lbl
        '
        Me.casaco_lbl.AutoSize = True
        Me.casaco_lbl.Location = New System.Drawing.Point(706, 22)
        Me.casaco_lbl.Name = "casaco_lbl"
        Me.casaco_lbl.Size = New System.Drawing.Size(43, 13)
        Me.casaco_lbl.TabIndex = 80
        Me.casaco_lbl.Text = "Casaco"
        '
        'actInicio
        '
        Me.actInicio.Location = New System.Drawing.Point(251, 86)
        Me.actInicio.Name = "actInicio"
        Me.actInicio.Size = New System.Drawing.Size(78, 20)
        Me.actInicio.TabIndex = 48
        '
        'inicio_lbl
        '
        Me.inicio_lbl.AutoSize = True
        Me.inicio_lbl.Location = New System.Drawing.Point(250, 12)
        Me.inicio_lbl.Name = "inicio_lbl"
        Me.inicio_lbl.Size = New System.Drawing.Size(32, 13)
        Me.inicio_lbl.TabIndex = 83
        Me.inicio_lbl.Text = "Inicio"
        '
        'actFim
        '
        Me.actFim.Location = New System.Drawing.Point(344, 86)
        Me.actFim.Name = "actFim"
        Me.actFim.Size = New System.Drawing.Size(86, 20)
        Me.actFim.TabIndex = 49
        '
        'fim_lbl
        '
        Me.fim_lbl.AutoSize = True
        Me.fim_lbl.Location = New System.Drawing.Point(341, 12)
        Me.fim_lbl.Name = "fim_lbl"
        Me.fim_lbl.Size = New System.Drawing.Size(23, 13)
        Me.fim_lbl.TabIndex = 85
        Me.fim_lbl.Text = "Fim"
        '
        'act_lbl
        '
        Me.act_lbl.Location = New System.Drawing.Point(98, 88)
        Me.act_lbl.Name = "act_lbl"
        Me.act_lbl.Size = New System.Drawing.Size(147, 14)
        Me.act_lbl.TabIndex = 87
        Me.act_lbl.Text = "Destacamento ACT"
        Me.act_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'destacamentoInicio
        '
        Me.destacamentoInicio.Location = New System.Drawing.Point(251, 60)
        Me.destacamentoInicio.Name = "destacamentoInicio"
        Me.destacamentoInicio.Size = New System.Drawing.Size(78, 20)
        Me.destacamentoInicio.TabIndex = 46
        '
        'destacamentoFim
        '
        Me.destacamentoFim.Location = New System.Drawing.Point(344, 60)
        Me.destacamentoFim.Name = "destacamentoFim"
        Me.destacamentoFim.Size = New System.Drawing.Size(85, 20)
        Me.destacamentoFim.TabIndex = 47
        '
        'destacamento_lbl
        '
        Me.destacamento_lbl.Location = New System.Drawing.Point(87, 66)
        Me.destacamento_lbl.Name = "destacamento_lbl"
        Me.destacamento_lbl.Size = New System.Drawing.Size(158, 13)
        Me.destacamento_lbl.TabIndex = 90
        Me.destacamento_lbl.Text = "Acordo Destacamento"
        Me.destacamento_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'contratoInicio
        '
        Me.contratoInicio.Location = New System.Drawing.Point(251, 28)
        Me.contratoInicio.Name = "contratoInicio"
        Me.contratoInicio.Size = New System.Drawing.Size(78, 20)
        Me.contratoInicio.TabIndex = 44
        '
        'contratoFim
        '
        Me.contratoFim.Location = New System.Drawing.Point(344, 28)
        Me.contratoFim.Name = "contratoFim"
        Me.contratoFim.Size = New System.Drawing.Size(85, 20)
        Me.contratoFim.TabIndex = 45
        '
        'contrato_lbl
        '
        Me.contrato_lbl.Location = New System.Drawing.Point(54, 31)
        Me.contrato_lbl.Name = "contrato_lbl"
        Me.contrato_lbl.Size = New System.Drawing.Size(191, 15)
        Me.contrato_lbl.TabIndex = 93
        Me.contrato_lbl.Text = "Contrato Trabalho"
        Me.contrato_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'a1Inicio
        '
        Me.a1Inicio.Location = New System.Drawing.Point(251, 112)
        Me.a1Inicio.Name = "a1Inicio"
        Me.a1Inicio.Size = New System.Drawing.Size(78, 20)
        Me.a1Inicio.TabIndex = 50
        '
        'a1Fim
        '
        Me.a1Fim.Location = New System.Drawing.Point(344, 112)
        Me.a1Fim.Name = "a1Fim"
        Me.a1Fim.Size = New System.Drawing.Size(85, 20)
        Me.a1Fim.TabIndex = 51
        '
        'a1_lbl
        '
        Me.a1_lbl.Location = New System.Drawing.Point(148, 115)
        Me.a1_lbl.Name = "a1_lbl"
        Me.a1_lbl.Size = New System.Drawing.Size(97, 15)
        Me.a1_lbl.TabIndex = 96
        Me.a1_lbl.Text = "A1"
        Me.a1_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mutuelle
        '
        Me.mutuelle.Location = New System.Drawing.Point(251, 138)
        Me.mutuelle.Name = "mutuelle"
        Me.mutuelle.Size = New System.Drawing.Size(78, 20)
        Me.mutuelle.TabIndex = 52
        '
        'mutuelle_lbl
        '
        Me.mutuelle_lbl.Location = New System.Drawing.Point(109, 143)
        Me.mutuelle_lbl.Name = "mutuelle_lbl"
        Me.mutuelle_lbl.Size = New System.Drawing.Size(136, 15)
        Me.mutuelle_lbl.TabIndex = 98
        Me.mutuelle_lbl.Text = "Mutuelle"
        Me.mutuelle_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'limosas_lbl
        '
        Me.limosas_lbl.AutoSize = True
        Me.limosas_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.limosas_lbl.Location = New System.Drawing.Point(274, 1181)
        Me.limosas_lbl.Name = "limosas_lbl"
        Me.limosas_lbl.Size = New System.Drawing.Size(68, 20)
        Me.limosas_lbl.TabIndex = 101
        Me.limosas_lbl.Text = "Limosas"
        '
        'medico
        '
        Me.medico.Location = New System.Drawing.Point(251, 167)
        Me.medico.Name = "medico"
        Me.medico.Size = New System.Drawing.Size(78, 20)
        Me.medico.TabIndex = 53
        '
        'medic_lbl
        '
        Me.medic_lbl.Location = New System.Drawing.Point(87, 170)
        Me.medic_lbl.Name = "medic_lbl"
        Me.medic_lbl.Size = New System.Drawing.Size(161, 15)
        Me.medic_lbl.TabIndex = 103
        Me.medic_lbl.Text = "Exame Médico"
        Me.medic_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'destacamentoactfile
        '
        Me.destacamentoactfile.Location = New System.Drawing.Point(544, 86)
        Me.destacamentoactfile.Name = "destacamentoactfile"
        Me.destacamentoactfile.Size = New System.Drawing.Size(269, 20)
        Me.destacamentoactfile.TabIndex = 69
        '
        'file_lbl
        '
        Me.file_lbl.AutoSize = True
        Me.file_lbl.Location = New System.Drawing.Point(541, 15)
        Me.file_lbl.Name = "file_lbl"
        Me.file_lbl.Size = New System.Drawing.Size(44, 13)
        Me.file_lbl.TabIndex = 105
        Me.file_lbl.Text = "Ficheiro"
        '
        'actBtn
        '
        Me.actBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.actBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.actBtn.ForeColor = System.Drawing.Color.White
        Me.actBtn.Location = New System.Drawing.Point(819, 83)
        Me.actBtn.Name = "actBtn"
        Me.actBtn.Size = New System.Drawing.Size(75, 23)
        Me.actBtn.TabIndex = 70
        Me.actBtn.Text = "Escolher"
        Me.actBtn.UseVisualStyleBackColor = False
        '
        'destacamentofile
        '
        Me.destacamentofile.Location = New System.Drawing.Point(543, 60)
        Me.destacamentofile.Name = "destacamentofile"
        Me.destacamentofile.Size = New System.Drawing.Size(270, 20)
        Me.destacamentofile.TabIndex = 67
        '
        'destacamentoBtn
        '
        Me.destacamentoBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.destacamentoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.destacamentoBtn.ForeColor = System.Drawing.Color.White
        Me.destacamentoBtn.Location = New System.Drawing.Point(819, 58)
        Me.destacamentoBtn.Name = "destacamentoBtn"
        Me.destacamentoBtn.Size = New System.Drawing.Size(75, 22)
        Me.destacamentoBtn.TabIndex = 68
        Me.destacamentoBtn.Text = "Escolher"
        Me.destacamentoBtn.UseVisualStyleBackColor = False
        '
        'contratofile
        '
        Me.contratofile.Location = New System.Drawing.Point(543, 31)
        Me.contratofile.Name = "contratofile"
        Me.contratofile.Size = New System.Drawing.Size(270, 20)
        Me.contratofile.TabIndex = 65
        '
        'contractFileBtn
        '
        Me.contractFileBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.contractFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.contractFileBtn.ForeColor = System.Drawing.Color.White
        Me.contractFileBtn.Location = New System.Drawing.Point(819, 29)
        Me.contractFileBtn.Name = "contractFileBtn"
        Me.contractFileBtn.Size = New System.Drawing.Size(75, 23)
        Me.contractFileBtn.TabIndex = 66
        Me.contractFileBtn.Text = "Escolher"
        Me.contractFileBtn.UseVisualStyleBackColor = False
        '
        'a1file
        '
        Me.a1file.Location = New System.Drawing.Point(543, 115)
        Me.a1file.Name = "a1file"
        Me.a1file.Size = New System.Drawing.Size(270, 20)
        Me.a1file.TabIndex = 71
        '
        'a1Btn
        '
        Me.a1Btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.a1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.a1Btn.ForeColor = System.Drawing.Color.White
        Me.a1Btn.Location = New System.Drawing.Point(819, 112)
        Me.a1Btn.Name = "a1Btn"
        Me.a1Btn.Size = New System.Drawing.Size(75, 23)
        Me.a1Btn.TabIndex = 72
        Me.a1Btn.Text = "Escolher"
        Me.a1Btn.UseVisualStyleBackColor = False
        '
        'mutuellefile
        '
        Me.mutuellefile.Location = New System.Drawing.Point(544, 141)
        Me.mutuellefile.Name = "mutuellefile"
        Me.mutuellefile.Size = New System.Drawing.Size(269, 20)
        Me.mutuellefile.TabIndex = 73
        '
        'mutuelleBtn
        '
        Me.mutuelleBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.mutuelleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mutuelleBtn.ForeColor = System.Drawing.Color.White
        Me.mutuelleBtn.Location = New System.Drawing.Point(819, 138)
        Me.mutuelleBtn.Name = "mutuelleBtn"
        Me.mutuelleBtn.Size = New System.Drawing.Size(75, 23)
        Me.mutuelleBtn.TabIndex = 74
        Me.mutuelleBtn.Text = "Escolher"
        Me.mutuelleBtn.UseVisualStyleBackColor = False
        '
        'limosafile
        '
        Me.limosafile.Enabled = False
        Me.limosafile.Location = New System.Drawing.Point(483, 109)
        Me.limosafile.Name = "limosafile"
        Me.limosafile.Size = New System.Drawing.Size(322, 20)
        Me.limosafile.TabIndex = 87
        '
        'btn_limosa
        '
        Me.btn_limosa.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btn_limosa.Enabled = False
        Me.btn_limosa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_limosa.ForeColor = System.Drawing.Color.White
        Me.btn_limosa.Location = New System.Drawing.Point(811, 107)
        Me.btn_limosa.Name = "btn_limosa"
        Me.btn_limosa.Size = New System.Drawing.Size(75, 23)
        Me.btn_limosa.TabIndex = 88
        Me.btn_limosa.Text = "Escolher"
        Me.btn_limosa.UseVisualStyleBackColor = False
        '
        'medicofile
        '
        Me.medicofile.Location = New System.Drawing.Point(543, 170)
        Me.medicofile.Name = "medicofile"
        Me.medicofile.Size = New System.Drawing.Size(270, 20)
        Me.medicofile.TabIndex = 75
        '
        'medicBtn
        '
        Me.medicBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.medicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.medicBtn.ForeColor = System.Drawing.Color.White
        Me.medicBtn.Location = New System.Drawing.Point(819, 167)
        Me.medicBtn.Name = "medicBtn"
        Me.medicBtn.Size = New System.Drawing.Size(75, 23)
        Me.medicBtn.TabIndex = 76
        Me.medicBtn.Text = "Escolher"
        Me.medicBtn.UseVisualStyleBackColor = False
        '
        'gruista_lbl
        '
        Me.gruista_lbl.Location = New System.Drawing.Point(213, 263)
        Me.gruista_lbl.Name = "gruista_lbl"
        Me.gruista_lbl.Size = New System.Drawing.Size(235, 14)
        Me.gruista_lbl.TabIndex = 108
        Me.gruista_lbl.Text = "Carta de Gruista"
        Me.gruista_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gruistaFile
        '
        Me.gruistaFile.Location = New System.Drawing.Point(543, 257)
        Me.gruistaFile.Name = "gruistaFile"
        Me.gruistaFile.Size = New System.Drawing.Size(270, 20)
        Me.gruistaFile.TabIndex = 81
        '
        'cranemanBtn
        '
        Me.cranemanBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.cranemanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cranemanBtn.ForeColor = System.Drawing.Color.White
        Me.cranemanBtn.Location = New System.Drawing.Point(818, 253)
        Me.cranemanBtn.Name = "cranemanBtn"
        Me.cranemanBtn.Size = New System.Drawing.Size(75, 23)
        Me.cranemanBtn.TabIndex = 82
        Me.cranemanBtn.Text = "Escolher"
        Me.cranemanBtn.UseVisualStyleBackColor = False
        '
        'limosaSite_lbl
        '
        Me.limosaSite_lbl.AutoSize = True
        Me.limosaSite_lbl.Location = New System.Drawing.Point(441, 19)
        Me.limosaSite_lbl.Name = "limosaSite_lbl"
        Me.limosaSite_lbl.Size = New System.Drawing.Size(30, 13)
        Me.limosaSite_lbl.TabIndex = 110
        Me.limosaSite_lbl.Text = "Obra"
        '
        'obra
        '
        Me.obra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obra.Enabled = False
        Me.obra.FormattingEnabled = True
        Me.obra.Location = New System.Drawing.Point(444, 35)
        Me.obra.Name = "obra"
        Me.obra.Size = New System.Drawing.Size(442, 21)
        Me.obra.TabIndex = 84
        '
        'del_limosa
        '
        Me.del_limosa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.del_limosa.AutoSize = True
        Me.del_limosa.Enabled = False
        Me.del_limosa.Location = New System.Drawing.Point(764, 157)
        Me.del_limosa.Name = "del_limosa"
        Me.del_limosa.Size = New System.Drawing.Size(41, 13)
        Me.del_limosa.TabIndex = 89
        Me.del_limosa.TabStop = True
        Me.del_limosa.Text = "Apagar"
        Me.del_limosa.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'save_limosa
        '
        Me.save_limosa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.save_limosa.AutoSize = True
        Me.save_limosa.Enabled = False
        Me.save_limosa.Location = New System.Drawing.Point(855, 157)
        Me.save_limosa.Name = "save_limosa"
        Me.save_limosa.Size = New System.Drawing.Size(39, 13)
        Me.save_limosa.TabIndex = 90
        Me.save_limosa.TabStop = True
        Me.save_limosa.Text = "Gravar"
        Me.save_limosa.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'limosaList
        '
        Me.limosaList.BackColor = System.Drawing.Color.Honeydew
        Me.limosaList.Enabled = False
        Me.limosaList.FormattingEnabled = True
        Me.limosaList.Location = New System.Drawing.Point(19, 19)
        Me.limosaList.Name = "limosaList"
        Me.limosaList.Size = New System.Drawing.Size(227, 147)
        Me.limosaList.TabIndex = 83
        '
        'contratoImg
        '
        Me.contratoImg.Image = CType(resources.GetObject("contratoImg.Image"), System.Drawing.Image)
        Me.contratoImg.Location = New System.Drawing.Point(454, 28)
        Me.contratoImg.Name = "contratoImg"
        Me.contratoImg.Size = New System.Drawing.Size(23, 23)
        Me.contratoImg.TabIndex = 114
        Me.contratoImg.TabStop = False
        '
        'destacamentoImg
        '
        Me.destacamentoImg.Image = CType(resources.GetObject("destacamentoImg.Image"), System.Drawing.Image)
        Me.destacamentoImg.Location = New System.Drawing.Point(454, 55)
        Me.destacamentoImg.Name = "destacamentoImg"
        Me.destacamentoImg.Size = New System.Drawing.Size(23, 23)
        Me.destacamentoImg.TabIndex = 115
        Me.destacamentoImg.TabStop = False
        '
        'actImg
        '
        Me.actImg.Image = CType(resources.GetObject("actImg.Image"), System.Drawing.Image)
        Me.actImg.Location = New System.Drawing.Point(454, 83)
        Me.actImg.Name = "actImg"
        Me.actImg.Size = New System.Drawing.Size(23, 23)
        Me.actImg.TabIndex = 116
        Me.actImg.TabStop = False
        '
        'a1Img
        '
        Me.a1Img.Image = CType(resources.GetObject("a1Img.Image"), System.Drawing.Image)
        Me.a1Img.Location = New System.Drawing.Point(454, 113)
        Me.a1Img.Name = "a1Img"
        Me.a1Img.Size = New System.Drawing.Size(23, 23)
        Me.a1Img.TabIndex = 117
        Me.a1Img.TabStop = False
        '
        'mutuelleImg
        '
        Me.mutuelleImg.Image = CType(resources.GetObject("mutuelleImg.Image"), System.Drawing.Image)
        Me.mutuelleImg.Location = New System.Drawing.Point(454, 141)
        Me.mutuelleImg.Name = "mutuelleImg"
        Me.mutuelleImg.Size = New System.Drawing.Size(23, 23)
        Me.mutuelleImg.TabIndex = 118
        Me.mutuelleImg.TabStop = False
        '
        'medicoImg
        '
        Me.medicoImg.Image = CType(resources.GetObject("medicoImg.Image"), System.Drawing.Image)
        Me.medicoImg.Location = New System.Drawing.Point(454, 170)
        Me.medicoImg.Name = "medicoImg"
        Me.medicoImg.Size = New System.Drawing.Size(23, 23)
        Me.medicoImg.TabIndex = 119
        Me.medicoImg.TabStop = False
        '
        'gruistaImg
        '
        Me.gruistaImg.Image = CType(resources.GetObject("gruistaImg.Image"), System.Drawing.Image)
        Me.gruistaImg.Location = New System.Drawing.Point(454, 257)
        Me.gruistaImg.Name = "gruistaImg"
        Me.gruistaImg.Size = New System.Drawing.Size(23, 23)
        Me.gruistaImg.TabIndex = 120
        Me.gruistaImg.TabStop = False
        '
        'calendar
        '
        Me.calendar.Location = New System.Drawing.Point(25, 518)
        Me.calendar.Name = "calendar"
        Me.calendar.TabIndex = 121
        '
        'addCalendarDateLink
        '
        Me.addCalendarDateLink.AutoSize = True
        Me.addCalendarDateLink.Location = New System.Drawing.Point(26, 680)
        Me.addCalendarDateLink.Name = "addCalendarDateLink"
        Me.addCalendarDateLink.Size = New System.Drawing.Size(51, 13)
        Me.addCalendarDateLink.TabIndex = 37
        Me.addCalendarDateLink.TabStop = True
        Me.addCalendarDateLink.Text = "Adicionar"
        '
        'limosasImg
        '
        Me.limosasImg.Enabled = False
        Me.limosasImg.Image = CType(resources.GetObject("limosasImg.Image"), System.Drawing.Image)
        Me.limosasImg.Location = New System.Drawing.Point(448, 107)
        Me.limosasImg.Name = "limosasImg"
        Me.limosasImg.Size = New System.Drawing.Size(23, 23)
        Me.limosasImg.TabIndex = 122
        Me.limosasImg.TabStop = False
        '
        'classificacao
        '
        Me.classificacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.classificacao.FormattingEnabled = True
        Me.classificacao.Location = New System.Drawing.Point(15, 82)
        Me.classificacao.Name = "classificacao"
        Me.classificacao.Size = New System.Drawing.Size(305, 21)
        Me.classificacao.TabIndex = 28
        '
        'classification_lbl
        '
        Me.classification_lbl.AutoSize = True
        Me.classification_lbl.Location = New System.Drawing.Point(12, 66)
        Me.classification_lbl.Name = "classification_lbl"
        Me.classification_lbl.Size = New System.Drawing.Size(73, 13)
        Me.classification_lbl.TabIndex = 123
        Me.classification_lbl.Text = "Classificação*"
        '
        'salario
        '
        Me.salario.Location = New System.Drawing.Point(353, 83)
        Me.salario.Name = "salario"
        Me.salario.Size = New System.Drawing.Size(101, 20)
        Me.salario.TabIndex = 29
        '
        'salary_lbl
        '
        Me.salary_lbl.AutoSize = True
        Me.salary_lbl.Location = New System.Drawing.Point(350, 66)
        Me.salary_lbl.Name = "salary_lbl"
        Me.salary_lbl.Size = New System.Drawing.Size(78, 13)
        Me.salary_lbl.TabIndex = 126
        Me.salary_lbl.Text = "Remuneração*"
        '
        'salario_euro_mes
        '
        Me.salario_euro_mes.AutoSize = True
        Me.salario_euro_mes.Location = New System.Drawing.Point(454, 85)
        Me.salario_euro_mes.Name = "salario_euro_mes"
        Me.salario_euro_mes.Size = New System.Drawing.Size(37, 13)
        Me.salario_euro_mes.TabIndex = 127
        Me.salario_euro_mes.Text = "€/mês"
        '
        'refeicao
        '
        Me.refeicao.Location = New System.Drawing.Point(520, 83)
        Me.refeicao.Name = "refeicao"
        Me.refeicao.Size = New System.Drawing.Size(84, 20)
        Me.refeicao.TabIndex = 30
        Me.refeicao.Text = "5.86"
        '
        'refeicao_lbl
        '
        Me.refeicao_lbl.AutoSize = True
        Me.refeicao_lbl.Location = New System.Drawing.Point(517, 66)
        Me.refeicao_lbl.Name = "refeicao_lbl"
        Me.refeicao_lbl.Size = New System.Drawing.Size(74, 13)
        Me.refeicao_lbl.TabIndex = 129
        Me.refeicao_lbl.Text = "Sub. refeição*"
        '
        'refeicao_euro_mes
        '
        Me.refeicao_euro_mes.AutoSize = True
        Me.refeicao_euro_mes.Location = New System.Drawing.Point(604, 85)
        Me.refeicao_euro_mes.Name = "refeicao_euro_mes"
        Me.refeicao_euro_mes.Size = New System.Drawing.Size(32, 13)
        Me.refeicao_euro_mes.TabIndex = 130
        Me.refeicao_euro_mes.Text = "€/dia"
        '
        'ajudascusto
        '
        Me.ajudascusto.Location = New System.Drawing.Point(656, 83)
        Me.ajudascusto.Name = "ajudascusto"
        Me.ajudascusto.Size = New System.Drawing.Size(84, 20)
        Me.ajudascusto.TabIndex = 31
        Me.ajudascusto.Text = "40.0"
        '
        'acusto_lbl
        '
        Me.acusto_lbl.AutoSize = True
        Me.acusto_lbl.Location = New System.Drawing.Point(653, 66)
        Me.acusto_lbl.Name = "acusto_lbl"
        Me.acusto_lbl.Size = New System.Drawing.Size(72, 13)
        Me.acusto_lbl.TabIndex = 132
        Me.acusto_lbl.Text = "Ajudas custo*"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(740, 85)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(32, 13)
        Me.Label50.TabIndex = 133
        Me.Label50.Text = "€/dia"
        '
        'localizacao
        '
        Me.localizacao.FormattingEnabled = True
        Me.localizacao.Items.AddRange(New Object() {"Continente", "Madeira", "Acores"})
        Me.localizacao.Location = New System.Drawing.Point(286, 91)
        Me.localizacao.Name = "localizacao"
        Me.localizacao.Size = New System.Drawing.Size(220, 21)
        Me.localizacao.TabIndex = 5
        '
        'location_lbl
        '
        Me.location_lbl.AutoSize = True
        Me.location_lbl.Location = New System.Drawing.Point(283, 75)
        Me.location_lbl.Name = "location_lbl"
        Me.location_lbl.Size = New System.Drawing.Size(68, 13)
        Me.location_lbl.TabIndex = 135
        Me.location_lbl.Text = "Localização*"
        '
        'alojamento
        '
        Me.alojamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.alojamento.FormattingEnabled = True
        Me.alojamento.Items.AddRange(New Object() {"Outro", "Assador", "Aldeia Velha", "Apartamento", "Cantinho"})
        Me.alojamento.Location = New System.Drawing.Point(18, 59)
        Me.alojamento.Name = "alojamento"
        Me.alojamento.Size = New System.Drawing.Size(138, 21)
        Me.alojamento.TabIndex = 34
        '
        'lodging_lbl
        '
        Me.lodging_lbl.AutoSize = True
        Me.lodging_lbl.Location = New System.Drawing.Point(15, 43)
        Me.lodging_lbl.Name = "lodging_lbl"
        Me.lodging_lbl.Size = New System.Drawing.Size(59, 13)
        Me.lodging_lbl.TabIndex = 137
        Me.lodging_lbl.Text = "Alojamento"
        '
        'naturalidade
        '
        Me.naturalidade.Location = New System.Drawing.Point(533, 90)
        Me.naturalidade.Name = "naturalidade"
        Me.naturalidade.Size = New System.Drawing.Size(157, 20)
        Me.naturalidade.TabIndex = 6
        '
        'naturalidade_lbl
        '
        Me.naturalidade_lbl.AutoSize = True
        Me.naturalidade_lbl.Location = New System.Drawing.Point(530, 72)
        Me.naturalidade_lbl.Name = "naturalidade_lbl"
        Me.naturalidade_lbl.Size = New System.Drawing.Size(71, 13)
        Me.naturalidade_lbl.TabIndex = 141
        Me.naturalidade_lbl.Text = "Naturalidade*"
        '
        'concelho
        '
        Me.concelho.Location = New System.Drawing.Point(714, 89)
        Me.concelho.Name = "concelho"
        Me.concelho.Size = New System.Drawing.Size(171, 20)
        Me.concelho.TabIndex = 7
        '
        'concelho_lbl
        '
        Me.concelho_lbl.AutoSize = True
        Me.concelho_lbl.Location = New System.Drawing.Point(711, 72)
        Me.concelho_lbl.Name = "concelho_lbl"
        Me.concelho_lbl.Size = New System.Drawing.Size(56, 13)
        Me.concelho_lbl.TabIndex = 143
        Me.concelho_lbl.Text = "Concelho*"
        '
        'cc_file_lbl
        '
        Me.cc_file_lbl.Location = New System.Drawing.Point(223, 235)
        Me.cc_file_lbl.Name = "cc_file_lbl"
        Me.cc_file_lbl.Size = New System.Drawing.Size(225, 16)
        Me.cc_file_lbl.TabIndex = 146
        Me.cc_file_lbl.Text = "Cartão do Cidadão"
        Me.cc_file_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ccfile
        '
        Me.ccfile.Location = New System.Drawing.Point(543, 228)
        Me.ccfile.Name = "ccfile"
        Me.ccfile.Size = New System.Drawing.Size(270, 20)
        Me.ccfile.TabIndex = 79
        '
        'ccBtn
        '
        Me.ccBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ccBtn.ForeColor = System.Drawing.Color.White
        Me.ccBtn.Location = New System.Drawing.Point(819, 224)
        Me.ccBtn.Name = "ccBtn"
        Me.ccBtn.Size = New System.Drawing.Size(75, 23)
        Me.ccBtn.TabIndex = 80
        Me.ccBtn.Text = "Escolher"
        Me.ccBtn.UseVisualStyleBackColor = False
        '
        'ccimg
        '
        Me.ccimg.Image = CType(resources.GetObject("ccimg.Image"), System.Drawing.Image)
        Me.ccimg.Location = New System.Drawing.Point(454, 228)
        Me.ccimg.Name = "ccimg"
        Me.ccimg.Size = New System.Drawing.Size(23, 23)
        Me.ccimg.TabIndex = 147
        Me.ccimg.TabStop = False
        '
        'csaude_lbl
        '
        Me.csaude_lbl.Location = New System.Drawing.Point(44, 201)
        Me.csaude_lbl.Name = "csaude_lbl"
        Me.csaude_lbl.Size = New System.Drawing.Size(204, 13)
        Me.csaude_lbl.TabIndex = 150
        Me.csaude_lbl.Text = "Cartão de Saúde Europeu"
        Me.csaude_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'csaudefile
        '
        Me.csaudefile.Location = New System.Drawing.Point(543, 199)
        Me.csaudefile.Name = "csaudefile"
        Me.csaudefile.Size = New System.Drawing.Size(270, 20)
        Me.csaudefile.TabIndex = 77
        '
        'cseBtn
        '
        Me.cseBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.cseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cseBtn.ForeColor = System.Drawing.Color.White
        Me.cseBtn.Location = New System.Drawing.Point(819, 195)
        Me.cseBtn.Name = "cseBtn"
        Me.cseBtn.Size = New System.Drawing.Size(75, 23)
        Me.cseBtn.TabIndex = 78
        Me.cseBtn.Text = "Escolher"
        Me.cseBtn.UseVisualStyleBackColor = False
        '
        'csaudeimg
        '
        Me.csaudeimg.Image = CType(resources.GetObject("csaudeimg.Image"), System.Drawing.Image)
        Me.csaudeimg.Location = New System.Drawing.Point(454, 199)
        Me.csaudeimg.Name = "csaudeimg"
        Me.csaudeimg.Size = New System.Drawing.Size(23, 23)
        Me.csaudeimg.TabIndex = 151
        Me.csaudeimg.TabStop = False
        '
        'contratodel
        '
        Me.contratodel.AutoSize = True
        Me.contratodel.Location = New System.Drawing.Point(500, 34)
        Me.contratodel.Name = "contratodel"
        Me.contratodel.Size = New System.Drawing.Size(15, 14)
        Me.contratodel.TabIndex = 55
        Me.contratodel.UseVisualStyleBackColor = True
        '
        'destacamentodel
        '
        Me.destacamentodel.AutoSize = True
        Me.destacamentodel.Location = New System.Drawing.Point(500, 62)
        Me.destacamentodel.Name = "destacamentodel"
        Me.destacamentodel.Size = New System.Drawing.Size(15, 14)
        Me.destacamentodel.TabIndex = 56
        Me.destacamentodel.UseVisualStyleBackColor = True
        '
        'actdel
        '
        Me.actdel.AutoSize = True
        Me.actdel.Location = New System.Drawing.Point(500, 88)
        Me.actdel.Name = "actdel"
        Me.actdel.Size = New System.Drawing.Size(15, 14)
        Me.actdel.TabIndex = 57
        Me.actdel.UseVisualStyleBackColor = True
        '
        'a1del
        '
        Me.a1del.AutoSize = True
        Me.a1del.Location = New System.Drawing.Point(500, 118)
        Me.a1del.Name = "a1del"
        Me.a1del.Size = New System.Drawing.Size(15, 14)
        Me.a1del.TabIndex = 58
        Me.a1del.UseVisualStyleBackColor = True
        '
        'mutuelledel
        '
        Me.mutuelledel.AutoSize = True
        Me.mutuelledel.Location = New System.Drawing.Point(500, 144)
        Me.mutuelledel.Name = "mutuelledel"
        Me.mutuelledel.Size = New System.Drawing.Size(15, 14)
        Me.mutuelledel.TabIndex = 59
        Me.mutuelledel.UseVisualStyleBackColor = True
        '
        'medicodel
        '
        Me.medicodel.AutoSize = True
        Me.medicodel.Location = New System.Drawing.Point(500, 173)
        Me.medicodel.Name = "medicodel"
        Me.medicodel.Size = New System.Drawing.Size(15, 14)
        Me.medicodel.TabIndex = 60
        Me.medicodel.UseVisualStyleBackColor = True
        '
        'gruistadel
        '
        Me.gruistadel.AutoSize = True
        Me.gruistadel.Location = New System.Drawing.Point(500, 259)
        Me.gruistadel.Name = "gruistadel"
        Me.gruistadel.Size = New System.Drawing.Size(15, 14)
        Me.gruistadel.TabIndex = 63
        Me.gruistadel.UseVisualStyleBackColor = True
        '
        'ccdel
        '
        Me.ccdel.AutoSize = True
        Me.ccdel.Location = New System.Drawing.Point(499, 230)
        Me.ccdel.Name = "ccdel"
        Me.ccdel.Size = New System.Drawing.Size(15, 14)
        Me.ccdel.TabIndex = 62
        Me.ccdel.UseVisualStyleBackColor = True
        '
        'csaudedel
        '
        Me.csaudedel.AutoSize = True
        Me.csaudedel.Location = New System.Drawing.Point(499, 201)
        Me.csaudedel.Name = "csaudedel"
        Me.csaudedel.Size = New System.Drawing.Size(15, 14)
        Me.csaudedel.TabIndex = 61
        Me.csaudedel.UseVisualStyleBackColor = True
        '
        'del_files
        '
        Me.del_files.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.del_files.AutoSize = True
        Me.del_files.Enabled = False
        Me.del_files.Location = New System.Drawing.Point(488, 280)
        Me.del_files.Name = "del_files"
        Me.del_files.Size = New System.Drawing.Size(41, 13)
        Me.del_files.TabIndex = 64
        Me.del_files.TabStop = True
        Me.del_files.Text = "Apagar"
        Me.del_files.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'docs_title_lbl
        '
        Me.docs_title_lbl.AutoSize = True
        Me.docs_title_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.docs_title_lbl.Location = New System.Drawing.Point(274, 841)
        Me.docs_title_lbl.Name = "docs_title_lbl"
        Me.docs_title_lbl.Size = New System.Drawing.Size(100, 20)
        Me.docs_title_lbl.TabIndex = 176
        Me.docs_title_lbl.Text = "Documentos"
        '
        'WorkerFile_title
        '
        Me.WorkerFile_title.AutoSize = True
        Me.WorkerFile_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkerFile_title.Location = New System.Drawing.Point(271, 6)
        Me.WorkerFile_title.Name = "WorkerFile_title"
        Me.WorkerFile_title.Size = New System.Drawing.Size(155, 20)
        Me.WorkerFile_title.TabIndex = 178
        Me.WorkerFile_title.Text = "Ficha do trabalhador"
        '
        'mandatoryLbl
        '
        Me.mandatoryLbl.Location = New System.Drawing.Point(923, 31)
        Me.mandatoryLbl.Name = "mandatoryLbl"
        Me.mandatoryLbl.Size = New System.Drawing.Size(248, 17)
        Me.mandatoryLbl.TabIndex = 184
        Me.mandatoryLbl.Text = "Campos marcados com * são obrigatórios"
        Me.mandatoryLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ativo
        '
        Me.ativo.AutoSize = True
        Me.ativo.Checked = True
        Me.ativo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ativo.Location = New System.Drawing.Point(467, 126)
        Me.ativo.Name = "ativo"
        Me.ativo.Size = New System.Drawing.Size(15, 14)
        Me.ativo.TabIndex = 42
        Me.ativo.UseVisualStyleBackColor = True
        '
        'activodate
        '
        Me.activodate.Location = New System.Drawing.Point(489, 123)
        Me.activodate.Name = "activodate"
        Me.activodate.Size = New System.Drawing.Size(94, 20)
        Me.activodate.TabIndex = 43
        '
        'activolbl
        '
        Me.activolbl.AutoSize = True
        Me.activolbl.Location = New System.Drawing.Point(486, 107)
        Me.activolbl.Name = "activolbl"
        Me.activolbl.Size = New System.Drawing.Size(62, 13)
        Me.activolbl.TabIndex = 187
        Me.activolbl.Text = "ativo desde"
        '
        'csaudevalidade
        '
        Me.csaudevalidade.Location = New System.Drawing.Point(254, 195)
        Me.csaudevalidade.Name = "csaudevalidade"
        Me.csaudevalidade.Size = New System.Drawing.Size(75, 20)
        Me.csaudevalidade.TabIndex = 54
        '
        'validade_lbl
        '
        Me.validade_lbl.AutoSize = True
        Me.validade_lbl.Location = New System.Drawing.Point(335, 198)
        Me.validade_lbl.Name = "validade_lbl"
        Me.validade_lbl.Size = New System.Drawing.Size(48, 13)
        Me.validade_lbl.TabIndex = 190
        Me.validade_lbl.Text = "Validade"
        '
        'download
        '
        Me.download.AutoSize = True
        Me.download.Enabled = False
        Me.download.Location = New System.Drawing.Point(22, 291)
        Me.download.Name = "download"
        Me.download.Size = New System.Drawing.Size(55, 13)
        Me.download.TabIndex = 191
        Me.download.TabStop = True
        Me.download.Text = "Download"
        '
        'qrcode_img
        '
        Me.qrcode_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.qrcode_img.Enabled = False
        Me.qrcode_img.Image = CType(resources.GetObject("qrcode_img.Image"), System.Drawing.Image)
        Me.qrcode_img.Location = New System.Drawing.Point(274, 19)
        Me.qrcode_img.Name = "qrcode_img"
        Me.qrcode_img.Size = New System.Drawing.Size(143, 147)
        Me.qrcode_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.qrcode_img.TabIndex = 192
        Me.qrcode_img.TabStop = False
        '
        'refeicoes
        '
        Me.refeicoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.refeicoes.FormattingEnabled = True
        Me.refeicoes.Items.AddRange(New Object() {"Aldeia Velha", "Assador", "Cantinho"})
        Me.refeicoes.Location = New System.Drawing.Point(18, 106)
        Me.refeicoes.Name = "refeicoes"
        Me.refeicoes.Size = New System.Drawing.Size(138, 21)
        Me.refeicoes.TabIndex = 36
        '
        'placeMeals_lbl
        '
        Me.placeMeals_lbl.AutoSize = True
        Me.placeMeals_lbl.Location = New System.Drawing.Point(15, 90)
        Me.placeMeals_lbl.Name = "placeMeals_lbl"
        Me.placeMeals_lbl.Size = New System.Drawing.Size(84, 13)
        Me.placeMeals_lbl.TabIndex = 194
        Me.placeMeals_lbl.Text = "Local Refeições"
        '
        'workerFile_divider
        '
        Me.workerFile_divider.BackColor = System.Drawing.Color.LimeGreen
        Me.workerFile_divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.workerFile_divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.workerFile_divider.Location = New System.Drawing.Point(277, 26)
        Me.workerFile_divider.Name = "workerFile_divider"
        Me.workerFile_divider.Size = New System.Drawing.Size(894, 4)
        Me.workerFile_divider.TabIndex = 262
        '
        'docs_divider
        '
        Me.docs_divider.BackColor = System.Drawing.Color.LimeGreen
        Me.docs_divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.docs_divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.docs_divider.Location = New System.Drawing.Point(278, 861)
        Me.docs_divider.Name = "docs_divider"
        Me.docs_divider.Size = New System.Drawing.Size(894, 4)
        Me.docs_divider.TabIndex = 263
        '
        'limosa_divider
        '
        Me.limosa_divider.BackColor = System.Drawing.Color.LimeGreen
        Me.limosa_divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.limosa_divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.limosa_divider.Location = New System.Drawing.Point(278, 1201)
        Me.limosa_divider.Name = "limosa_divider"
        Me.limosa_divider.Size = New System.Drawing.Size(894, 4)
        Me.limosa_divider.TabIndex = 264
        '
        'notas
        '
        Me.notas.Location = New System.Drawing.Point(528, 187)
        Me.notas.Multiline = True
        Me.notas.Name = "notas"
        Me.notas.Size = New System.Drawing.Size(357, 71)
        Me.notas.TabIndex = 14
        '
        'notes_lbl
        '
        Me.notes_lbl.AutoSize = True
        Me.notes_lbl.Location = New System.Drawing.Point(525, 171)
        Me.notes_lbl.Name = "notes_lbl"
        Me.notes_lbl.Size = New System.Drawing.Size(58, 13)
        Me.notes_lbl.TabIndex = 268
        Me.notes_lbl.Text = "Anotações"
        '
        'quarto
        '
        Me.quarto.Location = New System.Drawing.Point(190, 62)
        Me.quarto.Name = "quarto"
        Me.quarto.Size = New System.Drawing.Size(84, 20)
        Me.quarto.TabIndex = 35
        '
        'quartolbl
        '
        Me.quartolbl.AutoSize = True
        Me.quartolbl.Location = New System.Drawing.Point(187, 46)
        Me.quartolbl.Name = "quartolbl"
        Me.quartolbl.Size = New System.Drawing.Size(63, 13)
        Me.quartolbl.TabIndex = 270
        Me.quartolbl.Text = "núm. quarto"
        '
        'limosaStartDate_lbl
        '
        Me.limosaStartDate_lbl.AutoSize = True
        Me.limosaStartDate_lbl.Enabled = False
        Me.limosaStartDate_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.limosaStartDate_lbl.Location = New System.Drawing.Point(444, 61)
        Me.limosaStartDate_lbl.Name = "limosaStartDate_lbl"
        Me.limosaStartDate_lbl.Size = New System.Drawing.Size(73, 13)
        Me.limosaStartDate_lbl.TabIndex = 297
        Me.limosaStartDate_lbl.Text = "Data de Inicio"
        '
        'duracaoFimLimosa
        '
        Me.duracaoFimLimosa.Enabled = False
        Me.duracaoFimLimosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoFimLimosa.Location = New System.Drawing.Point(684, 80)
        Me.duracaoFimLimosa.Name = "duracaoFimLimosa"
        Me.duracaoFimLimosa.Size = New System.Drawing.Size(202, 20)
        Me.duracaoFimLimosa.TabIndex = 86
        '
        'duracaoInicioLimosa
        '
        Me.duracaoInicioLimosa.Enabled = False
        Me.duracaoInicioLimosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicioLimosa.Location = New System.Drawing.Point(447, 79)
        Me.duracaoInicioLimosa.Name = "duracaoInicioLimosa"
        Me.duracaoInicioLimosa.Size = New System.Drawing.Size(202, 20)
        Me.duracaoInicioLimosa.TabIndex = 85
        '
        'limosaValidTo_lbl
        '
        Me.limosaValidTo_lbl.AutoSize = True
        Me.limosaValidTo_lbl.Enabled = False
        Me.limosaValidTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.limosaValidTo_lbl.Location = New System.Drawing.Point(681, 62)
        Me.limosaValidTo_lbl.Name = "limosaValidTo_lbl"
        Me.limosaValidTo_lbl.Size = New System.Drawing.Size(53, 13)
        Me.limosaValidTo_lbl.TabIndex = 298
        Me.limosaValidTo_lbl.Text = "válida até"
        '
        'workerMainWrapper
        '
        Me.workerMainWrapper.AutoScroll = True
        Me.workerMainWrapper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.workerMainWrapper.Controls.Add(Me.GroupBoxLimosas)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox6)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox5)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox4)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox3)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox2)
        Me.workerMainWrapper.Controls.Add(Me.GroupBox1)
        Me.workerMainWrapper.Controls.Add(Me.limosa_divider)
        Me.workerMainWrapper.Controls.Add(Me.docs_divider)
        Me.workerMainWrapper.Controls.Add(Me.workerFile_divider)
        Me.workerMainWrapper.Controls.Add(Me.download)
        Me.workerMainWrapper.Controls.Add(Me.mandatoryLbl)
        Me.workerMainWrapper.Controls.Add(Me.WorkerFile_title)
        Me.workerMainWrapper.Controls.Add(Me.docs_title_lbl)
        Me.workerMainWrapper.Controls.Add(Me.addCalendarDateLink)
        Me.workerMainWrapper.Controls.Add(Me.calendar)
        Me.workerMainWrapper.Controls.Add(Me.limosas_lbl)
        Me.workerMainWrapper.Controls.Add(Me.photobox)
        Me.workerMainWrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.workerMainWrapper.Location = New System.Drawing.Point(377, 0)
        Me.workerMainWrapper.Name = "workerMainWrapper"
        Me.workerMainWrapper.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.workerMainWrapper.Size = New System.Drawing.Size(1393, 933)
        Me.workerMainWrapper.TabIndex = 195
        Me.workerMainWrapper.Visible = False
        '
        'GroupBoxLimosas
        '
        Me.GroupBoxLimosas.Controls.Add(Me.limosaList)
        Me.GroupBoxLimosas.Controls.Add(Me.limosafile)
        Me.GroupBoxLimosas.Controls.Add(Me.btn_limosa)
        Me.GroupBoxLimosas.Controls.Add(Me.limosaSite_lbl)
        Me.GroupBoxLimosas.Controls.Add(Me.obra)
        Me.GroupBoxLimosas.Controls.Add(Me.del_limosa)
        Me.GroupBoxLimosas.Controls.Add(Me.save_limosa)
        Me.GroupBoxLimosas.Controls.Add(Me.limosasImg)
        Me.GroupBoxLimosas.Controls.Add(Me.limosaValidTo_lbl)
        Me.GroupBoxLimosas.Controls.Add(Me.limosaStartDate_lbl)
        Me.GroupBoxLimosas.Controls.Add(Me.duracaoInicioLimosa)
        Me.GroupBoxLimosas.Controls.Add(Me.duracaoFimLimosa)
        Me.GroupBoxLimosas.Controls.Add(Me.qrcode_img)
        Me.GroupBoxLimosas.Location = New System.Drawing.Point(277, 1208)
        Me.GroupBoxLimosas.Name = "GroupBoxLimosas"
        Me.GroupBoxLimosas.Size = New System.Drawing.Size(906, 184)
        Me.GroupBoxLimosas.TabIndex = 306
        Me.GroupBoxLimosas.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.contrato_lbl)
        Me.GroupBox6.Controls.Add(Me.actInicio)
        Me.GroupBox6.Controls.Add(Me.inicio_lbl)
        Me.GroupBox6.Controls.Add(Me.actFim)
        Me.GroupBox6.Controls.Add(Me.fim_lbl)
        Me.GroupBox6.Controls.Add(Me.act_lbl)
        Me.GroupBox6.Controls.Add(Me.destacamentoInicio)
        Me.GroupBox6.Controls.Add(Me.destacamentoFim)
        Me.GroupBox6.Controls.Add(Me.destacamento_lbl)
        Me.GroupBox6.Controls.Add(Me.contratoInicio)
        Me.GroupBox6.Controls.Add(Me.contratoFim)
        Me.GroupBox6.Controls.Add(Me.a1Inicio)
        Me.GroupBox6.Controls.Add(Me.a1Fim)
        Me.GroupBox6.Controls.Add(Me.a1_lbl)
        Me.GroupBox6.Controls.Add(Me.mutuelle)
        Me.GroupBox6.Controls.Add(Me.mutuelle_lbl)
        Me.GroupBox6.Controls.Add(Me.medico)
        Me.GroupBox6.Controls.Add(Me.medic_lbl)
        Me.GroupBox6.Controls.Add(Me.destacamentoactfile)
        Me.GroupBox6.Controls.Add(Me.file_lbl)
        Me.GroupBox6.Controls.Add(Me.actBtn)
        Me.GroupBox6.Controls.Add(Me.validade_lbl)
        Me.GroupBox6.Controls.Add(Me.destacamentofile)
        Me.GroupBox6.Controls.Add(Me.csaudevalidade)
        Me.GroupBox6.Controls.Add(Me.destacamentoBtn)
        Me.GroupBox6.Controls.Add(Me.contratofile)
        Me.GroupBox6.Controls.Add(Me.contractFileBtn)
        Me.GroupBox6.Controls.Add(Me.a1file)
        Me.GroupBox6.Controls.Add(Me.a1Btn)
        Me.GroupBox6.Controls.Add(Me.mutuellefile)
        Me.GroupBox6.Controls.Add(Me.mutuelleBtn)
        Me.GroupBox6.Controls.Add(Me.medicofile)
        Me.GroupBox6.Controls.Add(Me.medicBtn)
        Me.GroupBox6.Controls.Add(Me.gruista_lbl)
        Me.GroupBox6.Controls.Add(Me.gruistaFile)
        Me.GroupBox6.Controls.Add(Me.cranemanBtn)
        Me.GroupBox6.Controls.Add(Me.contratoImg)
        Me.GroupBox6.Controls.Add(Me.destacamentoImg)
        Me.GroupBox6.Controls.Add(Me.del_files)
        Me.GroupBox6.Controls.Add(Me.actImg)
        Me.GroupBox6.Controls.Add(Me.csaudedel)
        Me.GroupBox6.Controls.Add(Me.a1Img)
        Me.GroupBox6.Controls.Add(Me.ccdel)
        Me.GroupBox6.Controls.Add(Me.mutuelleImg)
        Me.GroupBox6.Controls.Add(Me.gruistadel)
        Me.GroupBox6.Controls.Add(Me.medicoImg)
        Me.GroupBox6.Controls.Add(Me.medicodel)
        Me.GroupBox6.Controls.Add(Me.gruistaImg)
        Me.GroupBox6.Controls.Add(Me.mutuelledel)
        Me.GroupBox6.Controls.Add(Me.cc_file_lbl)
        Me.GroupBox6.Controls.Add(Me.a1del)
        Me.GroupBox6.Controls.Add(Me.ccfile)
        Me.GroupBox6.Controls.Add(Me.actdel)
        Me.GroupBox6.Controls.Add(Me.ccBtn)
        Me.GroupBox6.Controls.Add(Me.destacamentodel)
        Me.GroupBox6.Controls.Add(Me.ccimg)
        Me.GroupBox6.Controls.Add(Me.contratodel)
        Me.GroupBox6.Controls.Add(Me.csaude_lbl)
        Me.GroupBox6.Controls.Add(Me.csaudeimg)
        Me.GroupBox6.Controls.Add(Me.csaudefile)
        Me.GroupBox6.Controls.Add(Me.cseBtn)
        Me.GroupBox6.Location = New System.Drawing.Point(278, 868)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(906, 310)
        Me.GroupBox6.TabIndex = 305
        Me.GroupBox6.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.nfc_auth_code_lbl)
        Me.GroupBox5.Controls.Add(Me.nfc_auth_code)
        Me.GroupBox5.Controls.Add(Me.saveNewCard)
        Me.GroupBox5.Controls.Add(Me.nfcCode_lbl)
        Me.GroupBox5.Controls.Add(Me.txt_nfc)
        Me.GroupBox5.Controls.Add(Me.email_lbl)
        Me.GroupBox5.Controls.Add(Me.email)
        Me.GroupBox5.Controls.Add(Me.contact_lbl)
        Me.GroupBox5.Controls.Add(Me.txt_mobile)
        Me.GroupBox5.Controls.Add(Me.contact112_lbl)
        Me.GroupBox5.Controls.Add(Me.txt_112)
        Me.GroupBox5.Controls.Add(Me.activolbl)
        Me.GroupBox5.Controls.Add(Me.ativo)
        Me.GroupBox5.Controls.Add(Me.activodate)
        Me.GroupBox5.Location = New System.Drawing.Point(585, 680)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(597, 158)
        Me.GroupBox5.TabIndex = 304
        Me.GroupBox5.TabStop = False
        '
        'nfc_auth_code_lbl
        '
        Me.nfc_auth_code_lbl.AutoSize = True
        Me.nfc_auth_code_lbl.Location = New System.Drawing.Point(318, 20)
        Me.nfc_auth_code_lbl.Name = "nfc_auth_code_lbl"
        Me.nfc_auth_code_lbl.Size = New System.Drawing.Size(61, 13)
        Me.nfc_auth_code_lbl.TabIndex = 188
        Me.nfc_auth_code_lbl.Text = "Auth Code*"
        '
        'nfc_auth_code
        '
        Me.nfc_auth_code.Enabled = False
        Me.nfc_auth_code.Location = New System.Drawing.Point(319, 36)
        Me.nfc_auth_code.Name = "nfc_auth_code"
        Me.nfc_auth_code.Size = New System.Drawing.Size(264, 20)
        Me.nfc_auth_code.TabIndex = 189
        '
        'saveNewCard
        '
        Me.saveNewCard.Location = New System.Drawing.Point(428, 56)
        Me.saveNewCard.Name = "saveNewCard"
        Me.saveNewCard.Size = New System.Drawing.Size(155, 20)
        Me.saveNewCard.TabIndex = 38
        Me.saveNewCard.TabStop = True
        Me.saveNewCard.Text = "gravar novo"
        Me.saveNewCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lodging_lbl)
        Me.GroupBox4.Controls.Add(Me.alojamento)
        Me.GroupBox4.Controls.Add(Me.refeicoes)
        Me.GroupBox4.Controls.Add(Me.placeMeals_lbl)
        Me.GroupBox4.Controls.Add(Me.quarto)
        Me.GroupBox4.Controls.Add(Me.quartolbl)
        Me.GroupBox4.Location = New System.Drawing.Point(278, 680)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(301, 158)
        Me.GroupBox4.TabIndex = 303
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.kids_lbl)
        Me.GroupBox3.Controls.Add(Me.filhos)
        Me.GroupBox3.Controls.Add(Me.quantosfilhos)
        Me.GroupBox3.Controls.Add(Me.kids_num_lbl)
        Me.GroupBox3.Controls.Add(Me.filhosenc)
        Me.GroupBox3.Controls.Add(Me.kidsEnc_lbl)
        Me.GroupBox3.Controls.Add(Me.filhosencquantos)
        Me.GroupBox3.Controls.Add(Me.kidsEnc_num_lbl)
        Me.GroupBox3.Controls.Add(Me.probSaude_lbl)
        Me.GroupBox3.Controls.Add(Me.probsaude)
        Me.GroupBox3.Controls.Add(Me.probsaudequais)
        Me.GroupBox3.Controls.Add(Me.quais_lbl)
        Me.GroupBox3.Controls.Add(Me.calcas_lbl)
        Me.GroupBox3.Controls.Add(Me.peso)
        Me.GroupBox3.Controls.Add(Me.peso_lbl)
        Me.GroupBox3.Controls.Add(Me.altura)
        Me.GroupBox3.Controls.Add(Me.altura_lbl)
        Me.GroupBox3.Controls.Add(Me.calcas)
        Me.GroupBox3.Controls.Add(Me.pe)
        Me.GroupBox3.Controls.Add(Me.pe_lbl)
        Me.GroupBox3.Controls.Add(Me.casaco)
        Me.GroupBox3.Controls.Add(Me.casaco_lbl)
        Me.GroupBox3.Location = New System.Drawing.Point(277, 329)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(907, 176)
        Me.GroupBox3.TabIndex = 302
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nome_lbl)
        Me.GroupBox2.Controls.Add(Me.txt_name)
        Me.GroupBox2.Controls.Add(Me.datanascimento_txt)
        Me.GroupBox2.Controls.Add(Me.dataNasc_lbl)
        Me.GroupBox2.Controls.Add(Me.idade_txt)
        Me.GroupBox2.Controls.Add(Me.age_lbl)
        Me.GroupBox2.Controls.Add(Me.estadoCivil)
        Me.GroupBox2.Controls.Add(Me.estadoCivil_lbl)
        Me.GroupBox2.Controls.Add(Me.nacionalidade)
        Me.GroupBox2.Controls.Add(Me.country_lbl)
        Me.GroupBox2.Controls.Add(Me.cartaocidadao)
        Me.GroupBox2.Controls.Add(Me.cc_lbl)
        Me.GroupBox2.Controls.Add(Me.ccvalidoate)
        Me.GroupBox2.Controls.Add(Me.notes_lbl)
        Me.GroupBox2.Controls.Add(Me.cc_valid_lbl)
        Me.GroupBox2.Controls.Add(Me.notas)
        Me.GroupBox2.Controls.Add(Me.nif)
        Me.GroupBox2.Controls.Add(Me.nif_lbl)
        Me.GroupBox2.Controls.Add(Me.niss)
        Me.GroupBox2.Controls.Add(Me.niss_lbl)
        Me.GroupBox2.Controls.Add(Me.morada)
        Me.GroupBox2.Controls.Add(Me.morada_lbl)
        Me.GroupBox2.Controls.Add(Me.localizacao)
        Me.GroupBox2.Controls.Add(Me.location_lbl)
        Me.GroupBox2.Controls.Add(Me.naturalidade)
        Me.GroupBox2.Controls.Add(Me.naturalidade_lbl)
        Me.GroupBox2.Controls.Add(Me.concelho)
        Me.GroupBox2.Controls.Add(Me.concelho_lbl)
        Me.GroupBox2.Location = New System.Drawing.Point(278, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(906, 272)
        Me.GroupBox2.TabIndex = 301
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.salary_lbl)
        Me.GroupBox1.Controls.Add(Me.classificacao)
        Me.GroupBox1.Controls.Add(Me.classification_lbl)
        Me.GroupBox1.Controls.Add(Me.salario)
        Me.GroupBox1.Controls.Add(Me.salario_euro_mes)
        Me.GroupBox1.Controls.Add(Me.refeicao)
        Me.GroupBox1.Controls.Add(Me.refeicao_lbl)
        Me.GroupBox1.Controls.Add(Me.refeicao_euro_mes)
        Me.GroupBox1.Controls.Add(Me.ajudascusto)
        Me.GroupBox1.Controls.Add(Me.acusto_lbl)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.catPro_lbl)
        Me.GroupBox1.Controls.Add(Me.company_lbl)
        Me.GroupBox1.Controls.Add(Me.combo_empresa)
        Me.GroupBox1.Controls.Add(Me.combo_catpro)
        Me.GroupBox1.Controls.Add(Me.nib_lbl)
        Me.GroupBox1.Controls.Add(Me.nib)
        Me.GroupBox1.Controls.Add(Me.WorkStartDate_lbl)
        Me.GroupBox1.Controls.Add(Me.datainiciotrabalho)
        Me.GroupBox1.Location = New System.Drawing.Point(278, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(906, 163)
        Me.GroupBox1.TabIndex = 300
        Me.GroupBox1.TabStop = False
        '
        'saveWorkerCard
        '
        Me.saveWorkerCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveWorkerCard.AutoSize = True
        Me.saveWorkerCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.saveWorkerCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveWorkerCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveWorkerCard.ForeColor = System.Drawing.Color.White
        Me.saveWorkerCard.Location = New System.Drawing.Point(1249, 4)
        Me.saveWorkerCard.Name = "saveWorkerCard"
        Me.saveWorkerCard.Size = New System.Drawing.Size(132, 27)
        Me.saveWorkerCard.TabIndex = 92
        Me.saveWorkerCard.Text = "Gravar Ficha"
        Me.saveWorkerCard.UseVisualStyleBackColor = False
        '
        'delWorkerCard
        '
        Me.delWorkerCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.delWorkerCard.AutoSize = True
        Me.delWorkerCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.delWorkerCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.delWorkerCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delWorkerCard.ForeColor = System.Drawing.Color.White
        Me.delWorkerCard.Location = New System.Drawing.Point(1122, 4)
        Me.delWorkerCard.Name = "delWorkerCard"
        Me.delWorkerCard.Size = New System.Drawing.Size(121, 27)
        Me.delWorkerCard.TabIndex = 91
        Me.delWorkerCard.Text = "Apagar Ficha"
        Me.delWorkerCard.UseVisualStyleBackColor = False
        '
        'workerBottomWrapper
        '
        Me.workerBottomWrapper.Controls.Add(Me.delWorkerCard)
        Me.workerBottomWrapper.Controls.Add(Me.saveWorkerCard)
        Me.workerBottomWrapper.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.workerBottomWrapper.Location = New System.Drawing.Point(377, 933)
        Me.workerBottomWrapper.Name = "workerBottomWrapper"
        Me.workerBottomWrapper.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.workerBottomWrapper.Size = New System.Drawing.Size(1393, 35)
        Me.workerBottomWrapper.TabIndex = 197
        Me.workerBottomWrapper.Visible = False
        '
        'workers_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1770, 968)
        Me.ControlBox = False
        Me.Controls.Add(Me.workerMainWrapper)
        Me.Controls.Add(Me.workerBottomWrapper)
        Me.Controls.Add(Me.workerSideWrapper)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "workers_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestão de trabalhadores"
        Me.workerSideWrapper.ResumeLayout(False)
        Me.GroupBoxWorkers.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contratoImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.destacamentoImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.a1Img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mutuelleImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.medicoImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gruistaImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.limosasImg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ccimg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.csaudeimg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qrcode_img, System.ComponentModel.ISupportInitialize).EndInit()
        Me.workerMainWrapper.ResumeLayout(False)
        Me.workerMainWrapper.PerformLayout()
        Me.GroupBoxLimosas.ResumeLayout(False)
        Me.GroupBoxLimosas.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.workerBottomWrapper.ResumeLayout(False)
        Me.workerBottomWrapper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents workerSideWrapper As Panel
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents searchbox As TextBox
    Friend WithEvents searchBoxBtn As PictureBox
    Friend WithEvents GroupBoxWorkers As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents workersUpdateBtn As PictureBox
    Friend WithEvents workersListSelection As ComboBox
    Friend WithEvents numWorkers As Label
    Friend WithEvents listview_works As ListBox
    Friend WithEvents company_lbl As Label
    Friend WithEvents combo_empresa As ComboBox
    Friend WithEvents nfcCode_lbl As Label
    Friend WithEvents txt_mobile As TextBox
    Friend WithEvents txt_name As TextBox
    Friend WithEvents contact_lbl As Label
    Friend WithEvents combo_catpro As ComboBox
    Friend WithEvents contact112_lbl As Label
    Friend WithEvents catPro_lbl As Label
    Friend WithEvents txt_112 As TextBox
    Friend WithEvents nome_lbl As Label
    Friend WithEvents photobox As PictureBox
    Friend WithEvents datanascimento_txt As TextBox
    Friend WithEvents dataNasc_lbl As Label
    Friend WithEvents idade_txt As TextBox
    Friend WithEvents age_lbl As Label
    Friend WithEvents estadoCivil As ComboBox
    Friend WithEvents estadoCivil_lbl As Label
    Friend WithEvents nacionalidade As TextBox
    Friend WithEvents country_lbl As Label
    Friend WithEvents cartaocidadao As TextBox
    Friend WithEvents cc_lbl As Label
    Friend WithEvents ccvalidoate As TextBox
    Friend WithEvents cc_valid_lbl As Label
    Friend WithEvents nif As TextBox
    Friend WithEvents nif_lbl As Label
    Friend WithEvents niss As TextBox
    Friend WithEvents niss_lbl As Label
    Friend WithEvents filhos As ComboBox
    Friend WithEvents kids_lbl As Label
    Friend WithEvents quantosfilhos As TextBox
    Friend WithEvents kids_num_lbl As Label
    Friend WithEvents filhosenc As ComboBox
    Friend WithEvents kidsEnc_lbl As Label
    Friend WithEvents filhosencquantos As TextBox
    Friend WithEvents kidsEnc_num_lbl As Label
    Friend WithEvents email As TextBox
    Friend WithEvents email_lbl As Label
    Friend WithEvents datainiciotrabalho As TextBox
    Friend WithEvents WorkStartDate_lbl As Label
    Friend WithEvents morada As TextBox
    Friend WithEvents morada_lbl As Label
    Friend WithEvents nib As TextBox
    Friend WithEvents nib_lbl As Label
    Friend WithEvents probsaude As ComboBox
    Friend WithEvents probSaude_lbl As Label
    Friend WithEvents probsaudequais As TextBox
    Friend WithEvents quais_lbl As Label
    Friend WithEvents peso As TextBox
    Friend WithEvents peso_lbl As Label
    Friend WithEvents altura As TextBox
    Friend WithEvents altura_lbl As Label
    Friend WithEvents calcas As TextBox
    Friend WithEvents calcas_lbl As Label
    Friend WithEvents pe As TextBox
    Friend WithEvents pe_lbl As Label
    Friend WithEvents casaco As TextBox
    Friend WithEvents casaco_lbl As Label
    Friend WithEvents actInicio As TextBox
    Friend WithEvents inicio_lbl As Label
    Friend WithEvents actFim As TextBox
    Friend WithEvents fim_lbl As Label
    Friend WithEvents act_lbl As Label
    Friend WithEvents destacamentoInicio As TextBox
    Friend WithEvents destacamentoFim As TextBox
    Friend WithEvents destacamento_lbl As Label
    Friend WithEvents contratoInicio As TextBox
    Friend WithEvents contratoFim As TextBox
    Friend WithEvents contrato_lbl As Label
    Friend WithEvents a1Inicio As TextBox
    Friend WithEvents a1Fim As TextBox
    Friend WithEvents a1_lbl As Label
    Friend WithEvents mutuelle As TextBox
    Friend WithEvents mutuelle_lbl As Label
    Friend WithEvents limosas_lbl As Label
    Friend WithEvents medico As TextBox
    Friend WithEvents medic_lbl As Label
    Friend WithEvents destacamentoactfile As TextBox
    Friend WithEvents file_lbl As Label
    Friend WithEvents actBtn As Button
    Friend WithEvents destacamentofile As TextBox
    Friend WithEvents destacamentoBtn As Button
    Friend WithEvents contratofile As TextBox
    Friend WithEvents contractFileBtn As Button
    Friend WithEvents a1file As TextBox
    Friend WithEvents a1Btn As Button
    Friend WithEvents mutuellefile As TextBox
    Friend WithEvents mutuelleBtn As Button
    Friend WithEvents limosafile As TextBox
    Friend WithEvents btn_limosa As Button
    Friend WithEvents medicofile As TextBox
    Friend WithEvents medicBtn As Button
    Friend WithEvents gruista_lbl As Label
    Friend WithEvents gruistaFile As TextBox
    Friend WithEvents cranemanBtn As Button
    Friend WithEvents limosaSite_lbl As Label
    Friend WithEvents obra As ComboBox
    Friend WithEvents del_limosa As LinkLabel
    Friend WithEvents save_limosa As LinkLabel
    Friend WithEvents limosaList As ListBox
    Friend WithEvents contratoImg As PictureBox
    Friend WithEvents destacamentoImg As PictureBox
    Friend WithEvents actImg As PictureBox
    Friend WithEvents a1Img As PictureBox
    Friend WithEvents mutuelleImg As PictureBox
    Friend WithEvents medicoImg As PictureBox
    Friend WithEvents gruistaImg As PictureBox
    Friend WithEvents calendar As MonthCalendar
    Friend WithEvents addCalendarDateLink As LinkLabel
    Friend WithEvents limosasImg As PictureBox
    Friend WithEvents classificacao As ComboBox
    Friend WithEvents classification_lbl As Label
    Friend WithEvents salario As TextBox
    Friend WithEvents salary_lbl As Label
    Friend WithEvents salario_euro_mes As Label
    Friend WithEvents refeicao As TextBox
    Friend WithEvents refeicao_lbl As Label
    Friend WithEvents refeicao_euro_mes As Label
    Friend WithEvents ajudascusto As TextBox
    Friend WithEvents acusto_lbl As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents localizacao As ComboBox
    Friend WithEvents location_lbl As Label
    Friend WithEvents alojamento As ComboBox
    Friend WithEvents lodging_lbl As Label
    Friend WithEvents naturalidade As TextBox
    Friend WithEvents naturalidade_lbl As Label
    Friend WithEvents concelho As TextBox
    Friend WithEvents concelho_lbl As Label
    Friend WithEvents cc_file_lbl As Label
    Friend WithEvents ccfile As TextBox
    Friend WithEvents ccBtn As Button
    Friend WithEvents ccimg As PictureBox
    Friend WithEvents csaude_lbl As Label
    Friend WithEvents csaudefile As TextBox
    Friend WithEvents cseBtn As Button
    Friend WithEvents csaudeimg As PictureBox
    Friend WithEvents contratodel As CheckBox
    Friend WithEvents destacamentodel As CheckBox
    Friend WithEvents actdel As CheckBox
    Friend WithEvents a1del As CheckBox
    Friend WithEvents mutuelledel As CheckBox
    Friend WithEvents medicodel As CheckBox
    Friend WithEvents gruistadel As CheckBox
    Friend WithEvents ccdel As CheckBox
    Friend WithEvents csaudedel As CheckBox
    Friend WithEvents del_files As LinkLabel
    Friend WithEvents docs_title_lbl As Label
    Friend WithEvents WorkerFile_title As Label
    Friend WithEvents mandatoryLbl As Label
    Friend WithEvents ativo As CheckBox
    Friend WithEvents activodate As TextBox
    Friend WithEvents activolbl As Label
    Friend WithEvents csaudevalidade As TextBox
    Friend WithEvents validade_lbl As Label
    Friend WithEvents download As LinkLabel
    Friend WithEvents qrcode_img As PictureBox
    Friend WithEvents refeicoes As ComboBox
    Friend WithEvents placeMeals_lbl As Label
    Friend WithEvents workerFile_divider As Label
    Friend WithEvents docs_divider As Label
    Friend WithEvents limosa_divider As Label
    Friend WithEvents notas As TextBox
    Friend WithEvents notes_lbl As Label
    Friend WithEvents quarto As TextBox
    Friend WithEvents quartolbl As Label
    Friend WithEvents limosaStartDate_lbl As Label
    Friend WithEvents duracaoFimLimosa As DateTimePicker
    Friend WithEvents duracaoInicioLimosa As DateTimePicker
    Friend WithEvents limosaValidTo_lbl As Label
    Friend WithEvents workerMainWrapper As Panel
    Friend WithEvents saveWorkerCard As Button
    Friend WithEvents delWorkerCard As Button
    Friend WithEvents workerBottomWrapper As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBoxLimosas As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents saveNewCard As LinkLabel
    Public WithEvents txt_nfc As TextBox
    Friend WithEvents nfc_auth_code_lbl As Label
    Public WithEvents nfc_auth_code As TextBox
End Class
