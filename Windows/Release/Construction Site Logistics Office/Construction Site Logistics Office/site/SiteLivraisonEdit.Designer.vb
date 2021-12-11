<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SiteLivraisonEdit
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
        Me.mandatory = New System.Windows.Forms.Label()
        Me.notas = New System.Windows.Forms.TextBox()
        Me.notes_lbl = New System.Windows.Forms.Label()
        Me.material = New System.Windows.Forms.TextBox()
        Me.material_lbl = New System.Windows.Forms.Label()
        Me.del = New System.Windows.Forms.LinkLabel()
        Me.save = New System.Windows.Forms.LinkLabel()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.units_lbl = New System.Windows.Forms.Label()
        Me.units = New System.Windows.Forms.ComboBox()
        Me.qtd = New System.Windows.Forms.TextBox()
        Me.qtd_lbl = New System.Windows.Forms.Label()
        Me.refdoc = New System.Windows.Forms.TextBox()
        Me.refDoc_lbl = New System.Windows.Forms.Label()
        Me.recordDate = New System.Windows.Forms.DateTimePicker()
        Me.data_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.translate = New System.Windows.Forms.LinkLabel()
        Me.materialPreSelection = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mandatory
        '
        Me.mandatory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mandatory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatory.Location = New System.Drawing.Point(212, 33)
        Me.mandatory.Name = "mandatory"
        Me.mandatory.Size = New System.Drawing.Size(289, 25)
        Me.mandatory.TabIndex = 319
        Me.mandatory.Text = "campos com * são obrigatórios"
        Me.mandatory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'notas
        '
        Me.notas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notas.Location = New System.Drawing.Point(7, 221)
        Me.notas.Multiline = True
        Me.notas.Name = "notas"
        Me.notas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.notas.Size = New System.Drawing.Size(491, 123)
        Me.notas.TabIndex = 317
        '
        'notes_lbl
        '
        Me.notes_lbl.AutoSize = True
        Me.notes_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notes_lbl.Location = New System.Drawing.Point(4, 204)
        Me.notes_lbl.Name = "notes_lbl"
        Me.notes_lbl.Size = New System.Drawing.Size(58, 13)
        Me.notes_lbl.TabIndex = 318
        Me.notes_lbl.Text = "Anotações"
        '
        'material
        '
        Me.material.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.Location = New System.Drawing.Point(7, 181)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(256, 20)
        Me.material.TabIndex = 315
        '
        'material_lbl
        '
        Me.material_lbl.AutoSize = True
        Me.material_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material_lbl.Location = New System.Drawing.Point(4, 164)
        Me.material_lbl.Name = "material_lbl"
        Me.material_lbl.Size = New System.Drawing.Size(97, 13)
        Me.material_lbl.TabIndex = 316
        Me.material_lbl.Text = "Material Recebido*"
        '
        'del
        '
        Me.del.AutoSize = True
        Me.del.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del.Location = New System.Drawing.Point(309, 347)
        Me.del.Name = "del"
        Me.del.Size = New System.Drawing.Size(41, 13)
        Me.del.TabIndex = 311
        Me.del.TabStop = True
        Me.del.Text = "Apagar"
        Me.del.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save.Location = New System.Drawing.Point(421, 347)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(39, 13)
        Me.save.TabIndex = 312
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        Me.save.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.Location = New System.Drawing.Point(5, 29)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(496, 4)
        Me.divider.TabIndex = 314
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 5)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(137, 20)
        Me.title.TabIndex = 313
        Me.title.Text = "Guia de Remessa"
        '
        'units_lbl
        '
        Me.units_lbl.AutoSize = True
        Me.units_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units_lbl.Location = New System.Drawing.Point(141, 124)
        Me.units_lbl.Name = "units_lbl"
        Me.units_lbl.Size = New System.Drawing.Size(56, 13)
        Me.units_lbl.TabIndex = 310
        Me.units_lbl.Text = "Unidades*"
        '
        'units
        '
        Me.units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.units.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units.FormattingEnabled = True
        Me.units.Items.AddRange(New Object() {"KG", "M3", "M2", "ML", "PC"})
        Me.units.Location = New System.Drawing.Point(144, 140)
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(171, 21)
        Me.units.TabIndex = 306
        '
        'qtd
        '
        Me.qtd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd.Location = New System.Drawing.Point(7, 141)
        Me.qtd.Name = "qtd"
        Me.qtd.Size = New System.Drawing.Size(126, 20)
        Me.qtd.TabIndex = 307
        '
        'qtd_lbl
        '
        Me.qtd_lbl.AutoSize = True
        Me.qtd_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_lbl.Location = New System.Drawing.Point(4, 124)
        Me.qtd_lbl.Name = "qtd_lbl"
        Me.qtd_lbl.Size = New System.Drawing.Size(66, 13)
        Me.qtd_lbl.TabIndex = 309
        Me.qtd_lbl.Text = "Quantidade*"
        '
        'refdoc
        '
        Me.refdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refdoc.Location = New System.Drawing.Point(7, 62)
        Me.refdoc.Name = "refdoc"
        Me.refdoc.Size = New System.Drawing.Size(308, 20)
        Me.refdoc.TabIndex = 305
        '
        'refDoc_lbl
        '
        Me.refDoc_lbl.AutoSize = True
        Me.refDoc_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.refDoc_lbl.Location = New System.Drawing.Point(4, 45)
        Me.refDoc_lbl.Name = "refDoc_lbl"
        Me.refDoc_lbl.Size = New System.Drawing.Size(63, 13)
        Me.refDoc_lbl.TabIndex = 308
        Me.refDoc_lbl.Text = "Referência*"
        '
        'recordDate
        '
        Me.recordDate.Location = New System.Drawing.Point(7, 101)
        Me.recordDate.Name = "recordDate"
        Me.recordDate.Size = New System.Drawing.Size(200, 20)
        Me.recordDate.TabIndex = 321
        '
        'data_lbl
        '
        Me.data_lbl.AutoSize = True
        Me.data_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_lbl.Location = New System.Drawing.Point(4, 85)
        Me.data_lbl.Name = "data_lbl"
        Me.data_lbl.Size = New System.Drawing.Size(34, 13)
        Me.data_lbl.TabIndex = 322
        Me.data_lbl.Text = "Data*"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(415, 380)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'translate
        '
        Me.translate.AutoSize = True
        Me.translate.Location = New System.Drawing.Point(4, 347)
        Me.translate.Name = "translate"
        Me.translate.Size = New System.Drawing.Size(45, 13)
        Me.translate.TabIndex = 339
        Me.translate.TabStop = True
        Me.translate.Text = "Traduzir"
        '
        'materialPreSelection
        '
        Me.materialPreSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.materialPreSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.materialPreSelection.FormattingEnabled = True
        Me.materialPreSelection.Items.AddRange(New Object() {"Acier", "Béton", "Bloc Béton 9", "Bloc Béton 14", "Bloc Béton 19", "Bois de Coffrage", "Murs / Pre Murs", "Pré Dalles", "Silico Calcaire", "Seuils", "Stepoc", "Treillis", "Ytong", "Hourdis"})
        Me.materialPreSelection.Location = New System.Drawing.Point(269, 181)
        Me.materialPreSelection.Name = "materialPreSelection"
        Me.materialPreSelection.Size = New System.Drawing.Size(223, 21)
        Me.materialPreSelection.TabIndex = 340
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.materialPreSelection)
        Me.Panel1.Controls.Add(Me.refDoc_lbl)
        Me.Panel1.Controls.Add(Me.translate)
        Me.Panel1.Controls.Add(Me.refdoc)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.qtd_lbl)
        Me.Panel1.Controls.Add(Me.data_lbl)
        Me.Panel1.Controls.Add(Me.qtd)
        Me.Panel1.Controls.Add(Me.recordDate)
        Me.Panel1.Controls.Add(Me.units)
        Me.Panel1.Controls.Add(Me.mandatory)
        Me.Panel1.Controls.Add(Me.units_lbl)
        Me.Panel1.Controls.Add(Me.notas)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.notes_lbl)
        Me.Panel1.Controls.Add(Me.save)
        Me.Panel1.Controls.Add(Me.material)
        Me.Panel1.Controls.Add(Me.del)
        Me.Panel1.Controls.Add(Me.material_lbl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(519, 418)
        Me.Panel1.TabIndex = 341
        '
        'SiteLivraisonEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 418)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SiteLivraisonEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Guias de Remessa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mandatory As Label
    Friend WithEvents notas As TextBox
    Friend WithEvents notes_lbl As Label
    Friend WithEvents material As TextBox
    Friend WithEvents material_lbl As Label
    Friend WithEvents del As LinkLabel
    Friend WithEvents save As LinkLabel
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents units_lbl As Label
    Friend WithEvents units As ComboBox
    Friend WithEvents qtd As TextBox
    Friend WithEvents qtd_lbl As Label
    Friend WithEvents refdoc As TextBox
    Friend WithEvents refDoc_lbl As Label
    Friend WithEvents recordDate As DateTimePicker
    Friend WithEvents data_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents translate As LinkLabel
    Friend WithEvents materialPreSelection As ComboBox
    Friend WithEvents Panel1 As Panel
End Class
