<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class site_materials_reception_frm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(site_materials_reception_frm))
        Me.divider = New System.Windows.Forms.Label()
        Me.annotations_lbl = New System.Windows.Forms.Label()
        Me.materialsList = New System.Windows.Forms.ListBox()
        Me.save = New System.Windows.Forms.LinkLabel()
        Me.remove = New System.Windows.Forms.LinkLabel()
        Me.motivo = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.duracaoInicio = New System.Windows.Forms.DateTimePicker()
        Me.dia_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.custom_end = New System.Windows.Forms.DateTimePicker()
        Me.custom_start = New System.Windows.Forms.DateTimePicker()
        Me.qtd_section = New System.Windows.Forms.ComboBox()
        Me.section_lbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.end_lbl = New System.Windows.Forms.Label()
        Me.start_lbl = New System.Windows.Forms.Label()
        Me.mandatoryFields = New System.Windows.Forms.Label()
        Me.qtd = New System.Windows.Forms.TextBox()
        Me.materialPreSelection = New System.Windows.Forms.ComboBox()
        Me.material = New System.Windows.Forms.TextBox()
        Me.material_lbl = New System.Windows.Forms.Label()
        Me.units_lbl = New System.Windows.Forms.Label()
        Me.units = New System.Windows.Forms.ComboBox()
        Me.qtd_lbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(9, 28)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1130, 4)
        Me.divider.TabIndex = 280
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Location = New System.Drawing.Point(728, 199)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(58, 13)
        Me.annotations_lbl.TabIndex = 279
        Me.annotations_lbl.Text = "Anotações"
        '
        'materialsList
        '
        Me.materialsList.BackColor = System.Drawing.Color.Honeydew
        Me.materialsList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.materialsList.FormattingEnabled = True
        Me.materialsList.HorizontalScrollbar = True
        Me.materialsList.Location = New System.Drawing.Point(390, 56)
        Me.materialsList.Name = "materialsList"
        Me.materialsList.Size = New System.Drawing.Size(332, 277)
        Me.materialsList.TabIndex = 273
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Enabled = False
        Me.save.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save.Location = New System.Drawing.Point(1100, 336)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(47, 13)
        Me.save.TabIndex = 266
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        '
        'remove
        '
        Me.remove.AutoSize = True
        Me.remove.Enabled = False
        Me.remove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remove.Location = New System.Drawing.Point(1051, 336)
        Me.remove.Name = "remove"
        Me.remove.Size = New System.Drawing.Size(48, 13)
        Me.remove.TabIndex = 267
        Me.remove.TabStop = True
        Me.remove.Text = "Apagar"
        '
        'motivo
        '
        Me.motivo.Enabled = False
        Me.motivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.motivo.Location = New System.Drawing.Point(731, 215)
        Me.motivo.Multiline = True
        Me.motivo.Name = "motivo"
        Me.motivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.motivo.Size = New System.Drawing.Size(412, 118)
        Me.motivo.TabIndex = 270
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(11, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(272, 18)
        Me.title.TabIndex = 271
        Me.title.Text = "Recepção de materiais em Obra"
        '
        'searchTitle
        '
        Me.searchTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(-1, 49)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(65, 17)
        Me.searchTitle.TabIndex = 284
        Me.searchTitle.Text = "Procurar"
        Me.searchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'searchbox
        '
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(9, 69)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(349, 21)
        Me.searchbox.TabIndex = 285
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(11, 121)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(373, 173)
        Me.listview_works.TabIndex = 283
        '
        'updateLink
        '
        Me.updateLink.AutoSize = True
        Me.updateLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateLink.Location = New System.Drawing.Point(8, 98)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(63, 13)
        Me.updateLink.TabIndex = 282
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Actualizar"
        '
        'duracaoInicio
        '
        Me.duracaoInicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicio.Location = New System.Drawing.Point(844, 56)
        Me.duracaoInicio.Name = "duracaoInicio"
        Me.duracaoInicio.Size = New System.Drawing.Size(202, 21)
        Me.duracaoInicio.TabIndex = 287
        '
        'dia_lbl
        '
        Me.dia_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dia_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dia_lbl.Location = New System.Drawing.Point(731, 61)
        Me.dia_lbl.Name = "dia_lbl"
        Me.dia_lbl.Size = New System.Drawing.Size(107, 16)
        Me.dia_lbl.TabIndex = 289
        Me.dia_lbl.Text = "Dia"
        Me.dia_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1053, 381)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 336
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.custom_end)
        Me.Panel1.Controls.Add(Me.custom_start)
        Me.Panel1.Controls.Add(Me.qtd_section)
        Me.Panel1.Controls.Add(Me.section_lbl)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.end_lbl)
        Me.Panel1.Controls.Add(Me.start_lbl)
        Me.Panel1.Controls.Add(Me.mandatoryFields)
        Me.Panel1.Controls.Add(Me.qtd)
        Me.Panel1.Controls.Add(Me.materialPreSelection)
        Me.Panel1.Controls.Add(Me.material)
        Me.Panel1.Controls.Add(Me.material_lbl)
        Me.Panel1.Controls.Add(Me.units_lbl)
        Me.Panel1.Controls.Add(Me.units)
        Me.Panel1.Controls.Add(Me.qtd_lbl)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.motivo)
        Me.Panel1.Controls.Add(Me.duracaoInicio)
        Me.Panel1.Controls.Add(Me.remove)
        Me.Panel1.Controls.Add(Me.save)
        Me.Panel1.Controls.Add(Me.dia_lbl)
        Me.Panel1.Controls.Add(Me.materialsList)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.searchTitle)
        Me.Panel1.Controls.Add(Me.searchbox)
        Me.Panel1.Controls.Add(Me.listview_works)
        Me.Panel1.Controls.Add(Me.annotations_lbl)
        Me.Panel1.Controls.Add(Me.updateLink)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1154, 420)
        Me.Panel1.TabIndex = 337
        '
        'custom_end
        '
        Me.custom_end.CustomFormat = "HH:mm"
        Me.custom_end.Enabled = False
        Me.custom_end.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.custom_end.Location = New System.Drawing.Point(981, 83)
        Me.custom_end.Name = "custom_end"
        Me.custom_end.ShowUpDown = True
        Me.custom_end.Size = New System.Drawing.Size(65, 20)
        Me.custom_end.TabIndex = 359
        '
        'custom_start
        '
        Me.custom_start.CustomFormat = "HH:mm"
        Me.custom_start.Enabled = False
        Me.custom_start.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.custom_start.Location = New System.Drawing.Point(844, 83)
        Me.custom_start.Name = "custom_start"
        Me.custom_start.ShowUpDown = True
        Me.custom_start.Size = New System.Drawing.Size(65, 20)
        Me.custom_start.TabIndex = 358
        '
        'qtd_section
        '
        Me.qtd_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.qtd_section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_section.FormattingEnabled = True
        Me.qtd_section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.qtd_section.Location = New System.Drawing.Point(14, 312)
        Me.qtd_section.Name = "qtd_section"
        Me.qtd_section.Size = New System.Drawing.Size(370, 21)
        Me.qtd_section.TabIndex = 356
        '
        'section_lbl
        '
        Me.section_lbl.AutoSize = True
        Me.section_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.section_lbl.Location = New System.Drawing.Point(11, 297)
        Me.section_lbl.Name = "section_lbl"
        Me.section_lbl.Size = New System.Drawing.Size(55, 16)
        Me.section_lbl.TabIndex = 357
        Me.section_lbl.Text = "Secção"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(911, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 354
        Me.Label4.Text = "h"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1047, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 353
        Me.Label3.Text = "h"
        '
        'end_lbl
        '
        Me.end_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.end_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.end_lbl.Location = New System.Drawing.Point(931, 86)
        Me.end_lbl.Name = "end_lbl"
        Me.end_lbl.Size = New System.Drawing.Size(50, 14)
        Me.end_lbl.TabIndex = 351
        Me.end_lbl.Text = "Fim"
        Me.end_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'start_lbl
        '
        Me.start_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.start_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_lbl.Location = New System.Drawing.Point(734, 87)
        Me.start_lbl.Name = "start_lbl"
        Me.start_lbl.Size = New System.Drawing.Size(106, 16)
        Me.start_lbl.TabIndex = 350
        Me.start_lbl.Text = "Inicio"
        Me.start_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mandatoryFields
        '
        Me.mandatoryFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mandatoryFields.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatoryFields.Location = New System.Drawing.Point(731, 32)
        Me.mandatoryFields.Name = "mandatoryFields"
        Me.mandatoryFields.Size = New System.Drawing.Size(408, 21)
        Me.mandatoryFields.TabIndex = 348
        Me.mandatoryFields.Text = "campos com * são obrigatórios"
        Me.mandatoryFields.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'qtd
        '
        Me.qtd.Enabled = False
        Me.qtd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd.Location = New System.Drawing.Point(731, 175)
        Me.qtd.Name = "qtd"
        Me.qtd.Size = New System.Drawing.Size(75, 21)
        Me.qtd.TabIndex = 347
        '
        'materialPreSelection
        '
        Me.materialPreSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.materialPreSelection.Enabled = False
        Me.materialPreSelection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.materialPreSelection.FormattingEnabled = True
        Me.materialPreSelection.Items.AddRange(New Object() {"Acier", "Béton", "Bloc Béton 9", "Bloc Béton 14", "Bloc Béton 19", "Bois de Coffrage", "Murs / Pre Murs", "Pré Dalles", "Silico Calcaire", "Seuils", "Stepoc", "Treillis", "Ytong", "Hourdis"})
        Me.materialPreSelection.Location = New System.Drawing.Point(953, 135)
        Me.materialPreSelection.Name = "materialPreSelection"
        Me.materialPreSelection.Size = New System.Drawing.Size(190, 21)
        Me.materialPreSelection.TabIndex = 346
        '
        'material
        '
        Me.material.Enabled = False
        Me.material.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.Location = New System.Drawing.Point(731, 135)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(216, 21)
        Me.material.TabIndex = 344
        '
        'material_lbl
        '
        Me.material_lbl.AutoSize = True
        Me.material_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material_lbl.Location = New System.Drawing.Point(728, 118)
        Me.material_lbl.Name = "material_lbl"
        Me.material_lbl.Size = New System.Drawing.Size(170, 13)
        Me.material_lbl.TabIndex = 345
        Me.material_lbl.Text = "Material a receber em obra*"
        '
        'units_lbl
        '
        Me.units_lbl.AutoSize = True
        Me.units_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units_lbl.Location = New System.Drawing.Point(813, 159)
        Me.units_lbl.Name = "units_lbl"
        Me.units_lbl.Size = New System.Drawing.Size(59, 13)
        Me.units_lbl.TabIndex = 343
        Me.units_lbl.Text = "Unidades"
        '
        'units
        '
        Me.units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.units.Enabled = False
        Me.units.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units.FormattingEnabled = True
        Me.units.Items.AddRange(New Object() {"KG", "M3", "M2", "ML", "PC"})
        Me.units.Location = New System.Drawing.Point(816, 175)
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(67, 21)
        Me.units.TabIndex = 341
        '
        'qtd_lbl
        '
        Me.qtd_lbl.AutoSize = True
        Me.qtd_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_lbl.Location = New System.Drawing.Point(728, 159)
        Me.qtd_lbl.Name = "qtd_lbl"
        Me.qtd_lbl.Size = New System.Drawing.Size(72, 13)
        Me.qtd_lbl.TabIndex = 342
        Me.qtd_lbl.Text = "Quantidade"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(364, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 286
        Me.PictureBox1.TabStop = False
        '
        'site_materials_reception_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 420)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "site_materials_reception_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Marcação de periodos de encerramento do estaleiro"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents divider As Label
    Friend WithEvents annotations_lbl As Label
    Friend WithEvents materialsList As ListBox
    Friend WithEvents save As LinkLabel
    Friend WithEvents remove As LinkLabel
    Friend WithEvents motivo As TextBox
    Friend WithEvents title As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents duracaoInicio As DateTimePicker
    Friend WithEvents dia_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents materialPreSelection As ComboBox
    Friend WithEvents material As TextBox
    Friend WithEvents material_lbl As Label
    Friend WithEvents units_lbl As Label
    Friend WithEvents units As ComboBox
    Friend WithEvents qtd_lbl As Label
    Friend WithEvents qtd As TextBox
    Friend WithEvents mandatoryFields As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents end_lbl As Label
    Friend WithEvents start_lbl As Label
    Friend WithEvents qtd_section As ComboBox
    Friend WithEvents section_lbl As Label
    Friend WithEvents custom_end As DateTimePicker
    Friend WithEvents custom_start As DateTimePicker
End Class
