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
    <System.Diagnostics.DebuggerStepThrough()> _
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
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        Me.GroupBoxSelection.SuspendLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_search.SuspendLayout()
        CType(Me.searchbox_button, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.workersGroupBox.SuspendLayout()
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
        Me.GroupBoxSelection.Location = New System.Drawing.Point(9, 9)
        Me.GroupBoxSelection.Name = "GroupBoxSelection"
        Me.GroupBoxSelection.Size = New System.Drawing.Size(1027, 75)
        Me.GroupBoxSelection.TabIndex = 342
        Me.GroupBoxSelection.TabStop = False
        Me.GroupBoxSelection.Text = "Obra"
        '
        'Date_lbl
        '
        Me.Date_lbl.AutoSize = True
        Me.Date_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_lbl.Location = New System.Drawing.Point(542, 8)
        Me.Date_lbl.Name = "Date_lbl"
        Me.Date_lbl.Size = New System.Drawing.Size(37, 16)
        Me.Date_lbl.TabIndex = 322
        Me.Date_lbl.Text = "Data"
        '
        'SetCurrentMonth
        '
        Me.SetCurrentMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetCurrentMonth.Location = New System.Drawing.Point(789, 51)
        Me.SetCurrentMonth.Name = "SetCurrentMonth"
        Me.SetCurrentMonth.Size = New System.Drawing.Size(202, 16)
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
        Me.combo_site.Location = New System.Drawing.Point(6, 27)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(300, 21)
        Me.combo_site.TabIndex = 309
        '
        'data_fim
        '
        Me.data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_fim.Location = New System.Drawing.Point(789, 26)
        Me.data_fim.Name = "data_fim"
        Me.data_fim.Size = New System.Drawing.Size(202, 22)
        Me.data_fim.TabIndex = 284
        '
        'combo_section
        '
        Me.combo_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_section.FormattingEnabled = True
        Me.combo_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.combo_section.Location = New System.Drawing.Point(312, 27)
        Me.combo_section.Name = "combo_section"
        Me.combo_section.Size = New System.Drawing.Size(227, 21)
        Me.combo_section.TabIndex = 319
        '
        'DateTo_lbl
        '
        Me.DateTo_lbl.AutoSize = True
        Me.DateTo_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTo_lbl.Location = New System.Drawing.Point(760, 29)
        Me.DateTo_lbl.Name = "DateTo_lbl"
        Me.DateTo_lbl.Size = New System.Drawing.Size(17, 16)
        Me.DateTo_lbl.TabIndex = 285
        Me.DateTo_lbl.Text = "a"
        '
        'Section_lbl
        '
        Me.Section_lbl.AutoSize = True
        Me.Section_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Section_lbl.Location = New System.Drawing.Point(309, 9)
        Me.Section_lbl.Name = "Section_lbl"
        Me.Section_lbl.Size = New System.Drawing.Size(55, 16)
        Me.Section_lbl.TabIndex = 320
        Me.Section_lbl.Text = "Secção"
        '
        'LoadData
        '
        Me.LoadData.Image = CType(resources.GetObject("LoadData.Image"), System.Drawing.Image)
        Me.LoadData.InitialImage = Nothing
        Me.LoadData.Location = New System.Drawing.Point(996, 27)
        Me.LoadData.Name = "LoadData"
        Me.LoadData.Size = New System.Drawing.Size(20, 20)
        Me.LoadData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LoadData.TabIndex = 321
        Me.LoadData.TabStop = False
        '
        'data_inicio
        '
        Me.data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_inicio.Location = New System.Drawing.Point(545, 26)
        Me.data_inicio.Name = "data_inicio"
        Me.data_inicio.Size = New System.Drawing.Size(202, 22)
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
        Me.datatable.Location = New System.Drawing.Point(401, 90)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.datatable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.datatable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.Size = New System.Drawing.Size(973, 683)
        Me.datatable.TabIndex = 340
        '
        'GroupBox_search
        '
        Me.GroupBox_search.Controls.Add(Me.searchbox_button)
        Me.GroupBox_search.Controls.Add(Me.SearchBox)
        Me.GroupBox_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_search.Location = New System.Drawing.Point(1099, 9)
        Me.GroupBox_search.Name = "GroupBox_search"
        Me.GroupBox_search.Size = New System.Drawing.Size(275, 48)
        Me.GroupBox_search.TabIndex = 341
        Me.GroupBox_search.TabStop = False
        Me.GroupBox_search.Text = "Procurar"
        '
        'searchbox_button
        '
        Me.searchbox_button.Image = CType(resources.GetObject("searchbox_button.Image"), System.Drawing.Image)
        Me.searchbox_button.InitialImage = Nothing
        Me.searchbox_button.Location = New System.Drawing.Point(247, 15)
        Me.searchbox_button.Name = "searchbox_button"
        Me.searchbox_button.Size = New System.Drawing.Size(21, 21)
        Me.searchbox_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchbox_button.TabIndex = 310
        Me.searchbox_button.TabStop = False
        '
        'SearchBox
        '
        Me.SearchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBox.Location = New System.Drawing.Point(6, 16)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(235, 20)
        Me.SearchBox.TabIndex = 309
        '
        'workersGroupBox
        '
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
        Me.workersGroupBox.Controls.Add(Me.updateLink)
        Me.workersGroupBox.Location = New System.Drawing.Point(9, 90)
        Me.workersGroupBox.Margin = New System.Windows.Forms.Padding(2)
        Me.workersGroupBox.Name = "workersGroupBox"
        Me.workersGroupBox.Padding = New System.Windows.Forms.Padding(2)
        Me.workersGroupBox.Size = New System.Drawing.Size(388, 683)
        Me.workersGroupBox.TabIndex = 344
        Me.workersGroupBox.TabStop = False
        Me.workersGroupBox.Text = "Trabalhadores"
        '
        'workerEnd_lbl
        '
        Me.workerEnd_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.workerEnd_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerEnd_lbl.Location = New System.Drawing.Point(3, 599)
        Me.workerEnd_lbl.Name = "workerEnd_lbl"
        Me.workerEnd_lbl.Size = New System.Drawing.Size(82, 21)
        Me.workerEnd_lbl.TabIndex = 329
        Me.workerEnd_lbl.Text = "Fim"
        Me.workerEnd_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'workerStart_lbl
        '
        Me.workerStart_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.workerStart_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerStart_lbl.Location = New System.Drawing.Point(8, 567)
        Me.workerStart_lbl.Name = "workerStart_lbl"
        Me.workerStart_lbl.Size = New System.Drawing.Size(75, 20)
        Me.workerStart_lbl.TabIndex = 328
        Me.workerStart_lbl.Text = "Inicio"
        Me.workerStart_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'workerSetCurrentMonth
        '
        Me.workerSetCurrentMonth.AutoSize = True
        Me.workerSetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerSetCurrentMonth.Location = New System.Drawing.Point(88, 623)
        Me.workerSetCurrentMonth.Name = "workerSetCurrentMonth"
        Me.workerSetCurrentMonth.Size = New System.Drawing.Size(68, 13)
        Me.workerSetCurrentMonth.TabIndex = 327
        Me.workerSetCurrentMonth.TabStop = True
        Me.workerSetCurrentMonth.Text = "mês corrente"
        Me.workerSetCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'worker_data_fim
        '
        Me.worker_data_fim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_data_fim.Location = New System.Drawing.Point(88, 598)
        Me.worker_data_fim.Name = "worker_data_fim"
        Me.worker_data_fim.Size = New System.Drawing.Size(202, 22)
        Me.worker_data_fim.TabIndex = 325
        '
        'workerData_lbl
        '
        Me.workerData_lbl.AutoSize = True
        Me.workerData_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerData_lbl.Location = New System.Drawing.Point(5, 552)
        Me.workerData_lbl.Name = "workerData_lbl"
        Me.workerData_lbl.Size = New System.Drawing.Size(37, 16)
        Me.workerData_lbl.TabIndex = 324
        Me.workerData_lbl.Text = "Data"
        '
        'worker_data_inicio
        '
        Me.worker_data_inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_data_inicio.Location = New System.Drawing.Point(88, 565)
        Me.worker_data_inicio.Name = "worker_data_inicio"
        Me.worker_data_inicio.Size = New System.Drawing.Size(202, 22)
        Me.worker_data_inicio.TabIndex = 323
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(362, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 312
        Me.PictureBox1.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(5, 21)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(56, 13)
        Me.searchTitle.TabIndex = 310
        Me.searchTitle.Text = "Procurar"
        '
        'workerSearchBox
        '
        Me.workerSearchBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerSearchBox.Location = New System.Drawing.Point(7, 38)
        Me.workerSearchBox.Name = "workerSearchBox"
        Me.workerSearchBox.Size = New System.Drawing.Size(351, 21)
        Me.workerSearchBox.TabIndex = 311
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(7, 64)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(373, 485)
        Me.listview_works.TabIndex = 309
        '
        'updateLink
        '
        Me.updateLink.AutoSize = True
        Me.updateLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateLink.Location = New System.Drawing.Point(286, 658)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(94, 13)
        Me.updateLink.TabIndex = 308
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Ver informacao"
        '
        'workersClothesList_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1430, 861)
        Me.ControlBox = False
        Me.Controls.Add(Me.workersGroupBox)
        Me.Controls.Add(Me.GroupBoxSelection)
        Me.Controls.Add(Me.datatable)
        Me.Controls.Add(Me.GroupBox_search)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
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
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents workerEnd_lbl As Label
    Friend WithEvents workerStart_lbl As Label
    Friend WithEvents workerSetCurrentMonth As LinkLabel
    Friend WithEvents worker_data_fim As DateTimePicker
    Friend WithEvents workerData_lbl As Label
    Friend WithEvents worker_data_inicio As DateTimePicker
End Class
