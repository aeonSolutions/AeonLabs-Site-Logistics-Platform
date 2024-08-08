Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class receptionMaterials_frm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(receptionMaterials_frm))
        Me.datatable = New System.Windows.Forms.DataGridView()
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
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSelection.SuspendLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.datatable.Location = New System.Drawing.Point(18, 159)
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
        Me.datatable.Size = New System.Drawing.Size(2049, 1035)
        Me.datatable.TabIndex = 7
        '
        'GroupBoxSelection
        '
        Me.GroupBoxSelection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxSelection.AutoSize = True
        Me.GroupBoxSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
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
        Me.GroupBoxSelection.Size = New System.Drawing.Size(2049, 128)
        Me.GroupBoxSelection.TabIndex = 336
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
        Me.SetCurrentMonth.Location = New System.Drawing.Point(1182, 75)
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
        'receptionMaterials_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(2085, 1212)
        Me.Controls.Add(Me.GroupBoxSelection)
        Me.Controls.Add(Me.datatable)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "receptionMaterials_frm"
        Me.Text = "Form1"
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSelection.ResumeLayout(False)
        Me.GroupBoxSelection.PerformLayout()
        CType(Me.LoadData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents datatable As DataGridView
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
End Class
