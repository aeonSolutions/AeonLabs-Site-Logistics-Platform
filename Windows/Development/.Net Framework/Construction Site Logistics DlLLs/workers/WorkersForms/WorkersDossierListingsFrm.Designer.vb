Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WorkersDossierListingsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkersDossierListingsFrm))
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.available_fields = New System.Windows.Forms.ListBox()
        Me.workersListSelection = New System.Windows.Forms.ComboBox()
        Me.searchBoxBtn = New System.Windows.Forms.PictureBox()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.datatable.Location = New System.Drawing.Point(281, 12)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.datatable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.datatable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datatable.Size = New System.Drawing.Size(776, 413)
        Me.datatable.TabIndex = 5
        Me.datatable.Visible = False
        '
        'available_fields
        '
        Me.available_fields.FormattingEnabled = True
        Me.available_fields.HorizontalScrollbar = True
        Me.available_fields.Items.AddRange(New Object() {"Código Cartão", "Categoria Profissional", "Empresa", "Naturalidade", "Concelho", "Contacto", "Contacto de Emergência", "Data de Nascimento", "Idade", "Estado Civil", "Nacionalidade", "Cartão do Cidadão", "Validade do Cartão do Cidadão", "NIF", "NISS", "Email", "Data Inicio de trabalho", "Morada", "Alojamento", "NIB", "Peso", "Altura", "Pé", "Casaco", "Calças", "Contrato Trabalho Inicio", "Contrato Trabalho Fim", "Destacamento Inicio", "Destacamento Fim", "ACT Inicio", "ACT Fim", "A1 Inicio", "A1 Fim", "Mutuelle", "Exame Médico", "Cartão Europeu de Saúde", "Local de Refeição", "Numero do Quarto"})
        Me.available_fields.Location = New System.Drawing.Point(12, 44)
        Me.available_fields.Name = "available_fields"
        Me.available_fields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.available_fields.Size = New System.Drawing.Size(263, 381)
        Me.available_fields.TabIndex = 200
        Me.available_fields.Visible = False
        '
        'workersListSelection
        '
        Me.workersListSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.workersListSelection.FormattingEnabled = True
        Me.workersListSelection.Location = New System.Drawing.Point(12, 12)
        Me.workersListSelection.Name = "workersListSelection"
        Me.workersListSelection.Size = New System.Drawing.Size(236, 21)
        Me.workersListSelection.TabIndex = 204
        Me.workersListSelection.Visible = False
        '
        'searchBoxBtn
        '
        Me.searchBoxBtn.Image = CType(resources.GetObject("searchBoxBtn.Image"), System.Drawing.Image)
        Me.searchBoxBtn.InitialImage = Nothing
        Me.searchBoxBtn.Location = New System.Drawing.Point(254, 12)
        Me.searchBoxBtn.Name = "searchBoxBtn"
        Me.searchBoxBtn.Size = New System.Drawing.Size(21, 21)
        Me.searchBoxBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchBoxBtn.TabIndex = 205
        Me.searchBoxBtn.TabStop = False
        Me.searchBoxBtn.Visible = False
        '
        'frm_worker_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1069, 442)
        Me.Controls.Add(Me.searchBoxBtn)
        Me.Controls.Add(Me.workersListSelection)
        Me.Controls.Add(Me.available_fields)
        Me.Controls.Add(Me.datatable)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_worker_list"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listar trabalhadores"
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents datatable As DataGridView
    Friend WithEvents available_fields As ListBox
    Friend WithEvents workersListSelection As ComboBox
    Friend WithEvents searchBoxBtn As PictureBox
End Class
