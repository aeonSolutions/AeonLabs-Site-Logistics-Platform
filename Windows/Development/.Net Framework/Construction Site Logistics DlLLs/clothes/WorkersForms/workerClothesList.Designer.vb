Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class workersClothesList_frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workersClothesList_frm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxSelection = New System.Windows.Forms.GroupBox()
        Me.Date_lbl = New System.Windows.Forms.Label()
        Me.SetCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.data_fim = New System.Windows.Forms.DateTimePicker()
        Me.combo_section = New System.Windows.Forms.ComboBox()
        Me.DateTo_lbl = New System.Windows.Forms.Label()
        Me.Section_lbl = New System.Windows.Forms.Label()
        Me.LoadData = New System.Windows.Forms.PictureBox()
        Me.data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.GroupBox_search = New System.Windows.Forms.GroupBox()
        Me.searchbox_button = New System.Windows.Forms.PictureBox()
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.workersGroupBox = New System.Windows.Forms.GroupBox()
        Me.loadDataByWorkerBtn = New System.Windows.Forms.PictureBox()
        Me.workerEnd_lbl = New System.Windows.Forms.Label()
        Me.workerStart_lbl = New System.Windows.Forms.Label()
        Me.workerSetCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.worker_data_fim = New System.Windows.Forms.DateTimePicker()
        Me.workerData_lbl = New System.Windows.Forms.Label()
        Me.worker_data_inicio = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.workerSearchBox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.GroupBoxSelection.SuspendLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_search.SuspendLayout()
        CType(Me.searchbox_button, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.workersGroupBox.SuspendLayout()
        CType(Me.loadDataByWorkerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxSelection
        '
        Me.GroupBoxSelection.Controls.Add(Me.Date_lbl)
        Me.GroupBoxSelection.Controls.Add(Me.SetCurrentMonth)
        Me.GroupBoxSelection.Controls.Add(Me.combo_site)
        Me.GroupBoxSelection.Controls.Add(Me.data_fim)
        Me.GroupBoxSelection.Controls.Add(Me.combo_section)
        Me.GroupBoxSelection.Controls.Add(Me.DateTo_lbl)
        Me.GroupBoxSelection.Controls.Add(Me.Section_lbl)
        Me.GroupBoxSelection.Controls.Add(Me.LoadData)
        Me.GroupBoxSelection.Controls.Add(Me.data_inicio)
        Me.GroupBoxSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxSelection.Location = New System.Drawing.Point(14, 14)
        Me.GroupBoxSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSelection.Name = "GroupBoxSelection"
        Me.GroupBoxSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSelection.Size = New System.Drawing.Size(1540, 115)
        Me.GroupBoxSelection.TabIndex = 342
        Me.GroupBoxSelection.TabStop = False
        Me.GroupBoxSelection.Text = "Obra"
        Me.GroupBoxSelection.Visible = False
        '
        'Date_lbl
        '
        Me.Date_lbl.AutoSize = True
        Me.Date_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_lbl.Location = New System.Drawing.Point(813, 12)
        Me.Date_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Date_lbl.Name = "Date_lbl"
        Me.Date_lbl.Size = New System.Drawing.Size(53, 25)
        Me.Date_lbl.TabIndex = 322
        Me.Date_lbl.Text = "Data"
        '
        'SetCurrentMonth
        '
        Me.SetCurrentMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetCurrentMonth.Location = New System.Drawing.Point(1184, 78)
        Me.SetCurrentMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SetCurrentMonth.Name = "SetCurrentMonth"
        Me.SetCurrentMonth.Size = New System.Drawing.Size(303, 25)
        Me.SetCurrentMonth.TabIndex = 319
        Me.SetCurrentMonth.TabStop = True
        Me.SetCurrentMonth.Text = "mês corrente"
        Me.SetCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(9, 42)
        Me.combo_site.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(448, 28)
        Me.combo_site.TabIndex = 309
        '
        'data_fim
        '
        Me.data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim.Location = New System.Drawing.Point(1184, 40)
        Me.data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.data_fim.Name = "data_fim"
        Me.data_fim.Size = New System.Drawing.Size(301, 30)
        Me.data_fim.TabIndex = 284
        '
        'combo_section
        '
        Me.combo_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_section.FormattingEnabled = True
        Me.combo_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.combo_section.Location = New System.Drawing.Point(468, 42)
        Me.combo_section.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.combo_section.Name = "combo_section"
        Me.combo_section.Size = New System.Drawing.Size(338, 28)
        Me.combo_section.TabIndex = 319
        '
        'DateTo_lbl
        '
        Me.DateTo_lbl.AutoSize = True
        Me.DateTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTo_lbl.Location = New System.Drawing.Point(1140, 45)
        Me.DateTo_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DateTo_lbl.Name = "DateTo_lbl"
        Me.DateTo_lbl.Size = New System.Drawing.Size(24, 25)
        Me.DateTo_lbl.TabIndex = 285
        Me.DateTo_lbl.Text = "a"
        '
        'Section_lbl
        '
        Me.Section_lbl.AutoSize = True
        Me.Section_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Section_lbl.Location = New System.Drawing.Point(464, 14)
        Me.Section_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Section_lbl.Name = "Section_lbl"
        Me.Section_lbl.Size = New System.Drawing.Size(79, 25)
        Me.Section_lbl.TabIndex = 320
        Me.Section_lbl.Text = "Secção"
        '
        'LoadData
        '
        Me.LoadData.Image = CType(resources.GetObject("LoadData.Image"), System.Drawing.Image)
        Me.LoadData.InitialImage = Nothing
        Me.LoadData.Location = New System.Drawing.Point(1494, 42)
        Me.LoadData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoadData.Name = "LoadData"
        Me.LoadData.Size = New System.Drawing.Size(30, 31)
        Me.LoadData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LoadData.TabIndex = 321
        Me.LoadData.TabStop = False
        '
        'data_inicio
        '
        Me.data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio.Location = New System.Drawing.Point(818, 40)
        Me.data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.data_inicio.Name = "data_inicio"
        Me.data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.data_inicio.TabIndex = 282
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
        Me.datatable.BackgroundColor = System.Drawing.Color.White
        Me.datatable.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(602, 138)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.datatable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.datatable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.Size = New System.Drawing.Size(1460, 1051)
        Me.datatable.TabIndex = 340
        Me.datatable.Visible = False
        '
        'GroupBox_search
        '
        Me.GroupBox_search.Controls.Add(Me.searchbox_button)
        Me.GroupBox_search.Controls.Add(Me.SearchBox)
        Me.GroupBox_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_search.Location = New System.Drawing.Point(1648, 14)
        Me.GroupBox_search.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_search.Name = "GroupBox_search"
        Me.GroupBox_search.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_search.Size = New System.Drawing.Size(412, 74)
        Me.GroupBox_search.TabIndex = 341
        Me.GroupBox_search.TabStop = False
        Me.GroupBox_search.Text = "Procurar"
        Me.GroupBox_search.Visible = False
        '
        'searchbox_button
        '
        Me.searchbox_button.Image = CType(resources.GetObject("searchbox_button.Image"), System.Drawing.Image)
        Me.searchbox_button.InitialImage = Nothing
        Me.searchbox_button.Location = New System.Drawing.Point(370, 23)
        Me.searchbox_button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.searchbox_button.Name = "searchbox_button"
        Me.searchbox_button.Size = New System.Drawing.Size(32, 32)
        Me.searchbox_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchbox_button.TabIndex = 310
        Me.searchbox_button.TabStop = False
        '
        'SearchBox
        '
        Me.SearchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBox.Location = New System.Drawing.Point(9, 25)
        Me.SearchBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(350, 26)
        Me.SearchBox.TabIndex = 309
        '
        'workersGroupBox
        '
        Me.workersGroupBox.Controls.Add(Me.loadDataByWorkerBtn)
        Me.workersGroupBox.Controls.Add(Me.workerEnd_lbl)
        Me.workersGroupBox.Controls.Add(Me.workerStart_lbl)
        Me.workersGroupBox.Controls.Add(Me.workerSetCurrentMonth)
        Me.workersGroupBox.Controls.Add(Me.worker_data_fim)
        Me.workersGroupBox.Controls.Add(Me.workerData_lbl)
        Me.workersGroupBox.Controls.Add(Me.worker_data_inicio)
        Me.workersGroupBox.Controls.Add(Me.PictureBox1)
        Me.workersGroupBox.Controls.Add(Me.searchTitle)
        Me.workersGroupBox.Controls.Add(Me.workerSearchBox)
        Me.workersGroupBox.Controls.Add(Me.listview_works)
        Me.workersGroupBox.Location = New System.Drawing.Point(14, 138)
        Me.workersGroupBox.Name = "workersGroupBox"
        Me.workersGroupBox.Size = New System.Drawing.Size(582, 1051)
        Me.workersGroupBox.TabIndex = 344
        Me.workersGroupBox.TabStop = False
        Me.workersGroupBox.Text = "Trabalhadores"
        Me.workersGroupBox.Visible = False
        '
        'loadDataByWorkerBtn
        '
        Me.loadDataByWorkerBtn.Image = CType(resources.GetObject("loadDataByWorkerBtn.Image"), System.Drawing.Image)
        Me.loadDataByWorkerBtn.InitialImage = Nothing
        Me.loadDataByWorkerBtn.Location = New System.Drawing.Point(487, 920)
        Me.loadDataByWorkerBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.loadDataByWorkerBtn.Name = "loadDataByWorkerBtn"
        Me.loadDataByWorkerBtn.Size = New System.Drawing.Size(32, 32)
        Me.loadDataByWorkerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadDataByWorkerBtn.TabIndex = 330
        Me.loadDataByWorkerBtn.TabStop = False
        '
        'workerEnd_lbl
        '
        Me.workerEnd_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.workerEnd_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerEnd_lbl.Location = New System.Drawing.Point(4, 922)
        Me.workerEnd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workerEnd_lbl.Name = "workerEnd_lbl"
        Me.workerEnd_lbl.Size = New System.Drawing.Size(123, 32)
        Me.workerEnd_lbl.TabIndex = 329
        Me.workerEnd_lbl.Text = "Fim"
        Me.workerEnd_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'workerStart_lbl
        '
        Me.workerStart_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.workerStart_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerStart_lbl.Location = New System.Drawing.Point(12, 872)
        Me.workerStart_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workerStart_lbl.Name = "workerStart_lbl"
        Me.workerStart_lbl.Size = New System.Drawing.Size(112, 31)
        Me.workerStart_lbl.TabIndex = 328
        Me.workerStart_lbl.Text = "Inicio"
        Me.workerStart_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'workerSetCurrentMonth
        '
        Me.workerSetCurrentMonth.AutoSize = True
        Me.workerSetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerSetCurrentMonth.Location = New System.Drawing.Point(132, 958)
        Me.workerSetCurrentMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workerSetCurrentMonth.Name = "workerSetCurrentMonth"
        Me.workerSetCurrentMonth.Size = New System.Drawing.Size(108, 20)
        Me.workerSetCurrentMonth.TabIndex = 327
        Me.workerSetCurrentMonth.TabStop = True
        Me.workerSetCurrentMonth.Text = "mês corrente"
        Me.workerSetCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'worker_data_fim
        '
        Me.worker_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_data_fim.Location = New System.Drawing.Point(132, 920)
        Me.worker_data_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.worker_data_fim.Name = "worker_data_fim"
        Me.worker_data_fim.Size = New System.Drawing.Size(301, 30)
        Me.worker_data_fim.TabIndex = 325
        '
        'workerData_lbl
        '
        Me.workerData_lbl.AutoSize = True
        Me.workerData_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerData_lbl.Location = New System.Drawing.Point(8, 849)
        Me.workerData_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workerData_lbl.Name = "workerData_lbl"
        Me.workerData_lbl.Size = New System.Drawing.Size(53, 25)
        Me.workerData_lbl.TabIndex = 324
        Me.workerData_lbl.Text = "Data"
        '
        'worker_data_inicio
        '
        Me.worker_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_data_inicio.Location = New System.Drawing.Point(132, 869)
        Me.worker_data_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.worker_data_inicio.Name = "worker_data_inicio"
        Me.worker_data_inicio.Size = New System.Drawing.Size(301, 30)
        Me.worker_data_inicio.TabIndex = 323
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(543, 57)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 312
        Me.PictureBox1.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(8, 32)
        Me.searchTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(80, 20)
        Me.searchTitle.TabIndex = 310
        Me.searchTitle.Text = "Procurar"
        '
        'workerSearchBox
        '
        Me.workerSearchBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerSearchBox.Location = New System.Drawing.Point(10, 58)
        Me.workerSearchBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.workerSearchBox.Name = "workerSearchBox"
        Me.workerSearchBox.Size = New System.Drawing.Size(524, 28)
        Me.workerSearchBox.TabIndex = 311
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(10, 98)
        Me.listview_works.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(558, 732)
        Me.listview_works.TabIndex = 309
        '
        'workersClothesList_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(2145, 1325)
        Me.ControlBox = False
        Me.Controls.Add(Me.workersGroupBox)
        Me.Controls.Add(Me.GroupBoxSelection)
        Me.Controls.Add(Me.datatable)
        Me.Controls.Add(Me.GroupBox_search)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "workersClothesList_frm"
        Me.Text = "Form1"
        Me.GroupBoxSelection.ResumeLayout(False)
        Me.GroupBoxSelection.PerformLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_search.ResumeLayout(False)
        Me.GroupBox_search.PerformLayout()
        CType(Me.searchbox_button, System.ComponentModel.ISupportInitialize).EndInit()
        Me.workersGroupBox.ResumeLayout(False)
        Me.workersGroupBox.PerformLayout()
        CType(Me.loadDataByWorkerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxSelection As GroupBox
    Friend WithEvents Date_lbl As Label
    Friend WithEvents SetCurrentMonth As LinkLabel
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents data_fim As DateTimePicker
    Friend WithEvents combo_section As ComboBox
    Friend WithEvents DateTo_lbl As Label
    Friend WithEvents Section_lbl As Label
    Friend WithEvents LoadData As PictureBox
    Friend WithEvents data_inicio As DateTimePicker
    Friend WithEvents datatable As DataGridView
    Friend WithEvents GroupBox_search As GroupBox
    Friend WithEvents searchbox_button As PictureBox
    Friend WithEvents SearchBox As TextBox
    Friend WithEvents workersGroupBox As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents workerSearchBox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents workerEnd_lbl As Label
    Friend WithEvents workerStart_lbl As Label
    Friend WithEvents workerSetCurrentMonth As LinkLabel
    Friend WithEvents worker_data_fim As DateTimePicker
    Friend WithEvents workerData_lbl As Label
    Friend WithEvents worker_data_inicio As DateTimePicker
    Friend WithEvents loadDataByWorkerBtn As PictureBox
End Class
