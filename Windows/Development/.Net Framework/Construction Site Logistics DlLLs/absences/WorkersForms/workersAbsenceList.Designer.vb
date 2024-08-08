Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class workersAbsenseList_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workersAbsenseList_frm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.GroupBoxSelection.SuspendLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_search.SuspendLayout()
        CType(Me.searchbox_button, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBoxSelection.Location = New System.Drawing.Point(18, 18)
        Me.GroupBoxSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSelection.Name = "GroupBoxSelection"
        Me.GroupBoxSelection.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxSelection.Size = New System.Drawing.Size(1540, 115)
        Me.GroupBoxSelection.TabIndex = 339
        Me.GroupBoxSelection.TabStop = False
        Me.GroupBoxSelection.Text = "Obra"
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle5
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(18, 143)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.datatable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.datatable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.Size = New System.Drawing.Size(2049, 1051)
        Me.datatable.TabIndex = 337
        '
        'GroupBox_search
        '
        Me.GroupBox_search.Controls.Add(Me.searchbox_button)
        Me.GroupBox_search.Controls.Add(Me.SearchBox)
        Me.GroupBox_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_search.Location = New System.Drawing.Point(1654, 18)
        Me.GroupBox_search.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_search.Name = "GroupBox_search"
        Me.GroupBox_search.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox_search.Size = New System.Drawing.Size(412, 74)
        Me.GroupBox_search.TabIndex = 338
        Me.GroupBox_search.TabStop = False
        Me.GroupBox_search.Text = "Procurar"
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
        'workersAbsenseList_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(2096, 1226)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBoxSelection)
        Me.Controls.Add(Me.datatable)
        Me.Controls.Add(Me.GroupBox_search)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "workersAbsenseList_frm"
        Me.Text = "Absenses"
        Me.GroupBoxSelection.ResumeLayout(False)
        Me.GroupBoxSelection.PerformLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_search.ResumeLayout(False)
        Me.GroupBox_search.PerformLayout()
        CType(Me.searchbox_button, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
