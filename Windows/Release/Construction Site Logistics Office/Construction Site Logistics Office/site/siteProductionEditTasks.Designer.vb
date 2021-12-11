<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class siteProductionEditTasks_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBoxTask = New System.Windows.Forms.GroupBox()
        Me.numTranslations = New System.Windows.Forms.Label()
        Me.reference_lbl = New System.Windows.Forms.Label()
        Me.reference = New System.Windows.Forms.TextBox()
        Me.unitsTxt = New System.Windows.Forms.TextBox()
        Me.translatedLanguages_lbl = New System.Windows.Forms.Label()
        Me.translationText_lbl = New System.Windows.Forms.Label()
        Me.translationText = New System.Windows.Forms.TextBox()
        Me.show_all_lang = New System.Windows.Forms.CheckBox()
        Me.languagesList = New System.Windows.Forms.ListBox()
        Me.description_lbl = New System.Windows.Forms.Label()
        Me.price_lbl = New System.Windows.Forms.Label()
        Me.taskType_lbl = New System.Windows.Forms.Label()
        Me.del = New System.Windows.Forms.LinkLabel()
        Me.price = New System.Windows.Forms.TextBox()
        Me.TaskType = New System.Windows.Forms.ComboBox()
        Me.save = New System.Windows.Forms.LinkLabel()
        Me.units_lbl = New System.Windows.Forms.Label()
        Me.translate = New System.Windows.Forms.LinkLabel()
        Me.units = New System.Windows.Forms.ComboBox()
        Me.description = New System.Windows.Forms.TextBox()
        Me.qtd = New System.Windows.Forms.TextBox()
        Me.qtd_lbl = New System.Windows.Forms.Label()
        Me.groupBoxTasksList = New System.Windows.Forms.GroupBox()
        Me.tasksList = New System.Windows.Forms.ListBox()
        Me.title = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.mandatory = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxTask.SuspendLayout()
        Me.groupBoxTasksList.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBoxTask)
        Me.Panel1.Controls.Add(Me.groupBoxTasksList)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.mandatory)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1175, 670)
        Me.Panel1.TabIndex = 342
        '
        'GroupBoxTask
        '
        Me.GroupBoxTask.Controls.Add(Me.numTranslations)
        Me.GroupBoxTask.Controls.Add(Me.reference_lbl)
        Me.GroupBoxTask.Controls.Add(Me.reference)
        Me.GroupBoxTask.Controls.Add(Me.unitsTxt)
        Me.GroupBoxTask.Controls.Add(Me.translatedLanguages_lbl)
        Me.GroupBoxTask.Controls.Add(Me.translationText_lbl)
        Me.GroupBoxTask.Controls.Add(Me.translationText)
        Me.GroupBoxTask.Controls.Add(Me.show_all_lang)
        Me.GroupBoxTask.Controls.Add(Me.languagesList)
        Me.GroupBoxTask.Controls.Add(Me.description_lbl)
        Me.GroupBoxTask.Controls.Add(Me.price_lbl)
        Me.GroupBoxTask.Controls.Add(Me.taskType_lbl)
        Me.GroupBoxTask.Controls.Add(Me.del)
        Me.GroupBoxTask.Controls.Add(Me.price)
        Me.GroupBoxTask.Controls.Add(Me.TaskType)
        Me.GroupBoxTask.Controls.Add(Me.save)
        Me.GroupBoxTask.Controls.Add(Me.units_lbl)
        Me.GroupBoxTask.Controls.Add(Me.translate)
        Me.GroupBoxTask.Controls.Add(Me.units)
        Me.GroupBoxTask.Controls.Add(Me.description)
        Me.GroupBoxTask.Controls.Add(Me.qtd)
        Me.GroupBoxTask.Controls.Add(Me.qtd_lbl)
        Me.GroupBoxTask.Location = New System.Drawing.Point(613, 65)
        Me.GroupBoxTask.Name = "GroupBoxTask"
        Me.GroupBoxTask.Size = New System.Drawing.Size(538, 554)
        Me.GroupBoxTask.TabIndex = 356
        Me.GroupBoxTask.TabStop = False
        Me.GroupBoxTask.Text = "Tarefa"
        '
        'numTranslations
        '
        Me.numTranslations.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numTranslations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numTranslations.Location = New System.Drawing.Point(233, 232)
        Me.numTranslations.Name = "numTranslations"
        Me.numTranslations.Size = New System.Drawing.Size(294, 15)
        Me.numTranslations.TabIndex = 350
        Me.numTranslations.Text = "Traduzido em x idiomas"
        Me.numTranslations.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'reference_lbl
        '
        Me.reference_lbl.AutoSize = True
        Me.reference_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reference_lbl.Location = New System.Drawing.Point(212, 19)
        Me.reference_lbl.Name = "reference_lbl"
        Me.reference_lbl.Size = New System.Drawing.Size(39, 13)
        Me.reference_lbl.TabIndex = 349
        Me.reference_lbl.Text = "Preco*"
        '
        'reference
        '
        Me.reference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reference.Location = New System.Drawing.Point(215, 35)
        Me.reference.Name = "reference"
        Me.reference.Size = New System.Drawing.Size(133, 20)
        Me.reference.TabIndex = 348
        '
        'unitsTxt
        '
        Me.unitsTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitsTxt.Location = New System.Drawing.Point(188, 82)
        Me.unitsTxt.Name = "unitsTxt"
        Me.unitsTxt.Size = New System.Drawing.Size(76, 20)
        Me.unitsTxt.TabIndex = 347
        '
        'translatedLanguages_lbl
        '
        Me.translatedLanguages_lbl.AutoSize = True
        Me.translatedLanguages_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translatedLanguages_lbl.Location = New System.Drawing.Point(13, 243)
        Me.translatedLanguages_lbl.Name = "translatedLanguages_lbl"
        Me.translatedLanguages_lbl.Size = New System.Drawing.Size(118, 13)
        Me.translatedLanguages_lbl.TabIndex = 346
        Me.translatedLanguages_lbl.Text = "traducoes da descricao"
        '
        'translationText_lbl
        '
        Me.translationText_lbl.AutoSize = True
        Me.translationText_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationText_lbl.Location = New System.Drawing.Point(10, 394)
        Me.translationText_lbl.Name = "translationText_lbl"
        Me.translationText_lbl.Size = New System.Drawing.Size(147, 13)
        Me.translationText_lbl.TabIndex = 345
        Me.translationText_lbl.Text = "desxricao traduzida da tarefa*"
        '
        'translationText
        '
        Me.translationText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationText.Location = New System.Drawing.Point(13, 411)
        Me.translationText.Multiline = True
        Me.translationText.Name = "translationText"
        Me.translationText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.translationText.Size = New System.Drawing.Size(514, 96)
        Me.translationText.TabIndex = 344
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(13, 369)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(140, 17)
        Me.show_all_lang.TabIndex = 343
        Me.show_all_lang.Text = "Show project languages"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'languagesList
        '
        Me.languagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.languagesList.FormattingEnabled = True
        Me.languagesList.Location = New System.Drawing.Point(13, 260)
        Me.languagesList.Name = "languagesList"
        Me.languagesList.Size = New System.Drawing.Size(511, 106)
        Me.languagesList.TabIndex = 342
        '
        'description_lbl
        '
        Me.description_lbl.AutoSize = True
        Me.description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description_lbl.Location = New System.Drawing.Point(13, 116)
        Me.description_lbl.Name = "description_lbl"
        Me.description_lbl.Size = New System.Drawing.Size(137, 13)
        Me.description_lbl.TabIndex = 308
        Me.description_lbl.Text = "desxricao original da tarefa*"
        '
        'price_lbl
        '
        Me.price_lbl.AutoSize = True
        Me.price_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.price_lbl.Location = New System.Drawing.Point(386, 66)
        Me.price_lbl.Name = "price_lbl"
        Me.price_lbl.Size = New System.Drawing.Size(39, 13)
        Me.price_lbl.TabIndex = 316
        Me.price_lbl.Text = "Preco*"
        '
        'taskType_lbl
        '
        Me.taskType_lbl.AutoSize = True
        Me.taskType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.taskType_lbl.Location = New System.Drawing.Point(13, 15)
        Me.taskType_lbl.Name = "taskType_lbl"
        Me.taskType_lbl.Size = New System.Drawing.Size(32, 13)
        Me.taskType_lbl.TabIndex = 341
        Me.taskType_lbl.Text = "Tipo*"
        '
        'del
        '
        Me.del.AutoSize = True
        Me.del.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del.Location = New System.Drawing.Point(25, 519)
        Me.del.Name = "del"
        Me.del.Size = New System.Drawing.Size(41, 13)
        Me.del.TabIndex = 311
        Me.del.TabStop = True
        Me.del.Text = "Apagar"
        Me.del.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'price
        '
        Me.price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.price.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.price.Location = New System.Drawing.Point(389, 82)
        Me.price.Name = "price"
        Me.price.Size = New System.Drawing.Size(133, 20)
        Me.price.TabIndex = 315
        '
        'TaskType
        '
        Me.TaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TaskType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType.FormattingEnabled = True
        Me.TaskType.Items.AddRange(New Object() {"Title", "SubTitle", "Task"})
        Me.TaskType.Location = New System.Drawing.Point(13, 34)
        Me.TaskType.Name = "TaskType"
        Me.TaskType.Size = New System.Drawing.Size(147, 21)
        Me.TaskType.TabIndex = 340
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save.Location = New System.Drawing.Point(83, 519)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(39, 13)
        Me.save.TabIndex = 312
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        Me.save.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'units_lbl
        '
        Me.units_lbl.AutoSize = True
        Me.units_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units_lbl.Location = New System.Drawing.Point(185, 66)
        Me.units_lbl.Name = "units_lbl"
        Me.units_lbl.Size = New System.Drawing.Size(56, 13)
        Me.units_lbl.TabIndex = 310
        Me.units_lbl.Text = "Unidades*"
        '
        'translate
        '
        Me.translate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.translate.AutoSize = True
        Me.translate.Location = New System.Drawing.Point(476, 369)
        Me.translate.Name = "translate"
        Me.translate.Size = New System.Drawing.Size(45, 13)
        Me.translate.TabIndex = 339
        Me.translate.TabStop = True
        Me.translate.Text = "Traduzir"
        Me.translate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'units
        '
        Me.units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.units.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units.FormattingEnabled = True
        Me.units.Items.AddRange(New Object() {"KG", "M3", "M2", "ML", "PC"})
        Me.units.Location = New System.Drawing.Point(270, 82)
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(78, 21)
        Me.units.TabIndex = 306
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(13, 133)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.description.Size = New System.Drawing.Size(514, 96)
        Me.description.TabIndex = 305
        '
        'qtd
        '
        Me.qtd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd.Location = New System.Drawing.Point(12, 81)
        Me.qtd.Name = "qtd"
        Me.qtd.Size = New System.Drawing.Size(126, 20)
        Me.qtd.TabIndex = 307
        '
        'qtd_lbl
        '
        Me.qtd_lbl.AutoSize = True
        Me.qtd_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_lbl.Location = New System.Drawing.Point(13, 66)
        Me.qtd_lbl.Name = "qtd_lbl"
        Me.qtd_lbl.Size = New System.Drawing.Size(66, 13)
        Me.qtd_lbl.TabIndex = 309
        Me.qtd_lbl.Text = "Quantidade*"
        '
        'groupBoxTasksList
        '
        Me.groupBoxTasksList.Controls.Add(Me.tasksList)
        Me.groupBoxTasksList.Location = New System.Drawing.Point(11, 65)
        Me.groupBoxTasksList.Name = "groupBoxTasksList"
        Me.groupBoxTasksList.Size = New System.Drawing.Size(596, 554)
        Me.groupBoxTasksList.TabIndex = 355
        Me.groupBoxTasksList.TabStop = False
        Me.groupBoxTasksList.Text = "Insert next to"
        '
        'tasksList
        '
        Me.tasksList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tasksList.FormattingEnabled = True
        Me.tasksList.HorizontalScrollbar = True
        Me.tasksList.Location = New System.Drawing.Point(6, 19)
        Me.tasksList.Name = "tasksList"
        Me.tasksList.Size = New System.Drawing.Size(575, 485)
        Me.tasksList.TabIndex = 350
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 5)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(105, 20)
        Me.title.TabIndex = 313
        Me.title.Text = "Editar tarefas"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1064, 626)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'mandatory
        '
        Me.mandatory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mandatory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatory.Location = New System.Drawing.Point(865, 39)
        Me.mandatory.Name = "mandatory"
        Me.mandatory.Size = New System.Drawing.Size(289, 25)
        Me.mandatory.TabIndex = 319
        Me.mandatory.Text = "campos com * são obrigatórios"
        Me.mandatory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.Location = New System.Drawing.Point(5, 29)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1148, 4)
        Me.divider.TabIndex = 314
        '
        'siteProductionEditTasks_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 670)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "siteProductionEditTasks_frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBoxTask.ResumeLayout(False)
        Me.GroupBoxTask.PerformLayout()
        Me.groupBoxTasksList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents title As Label
    Friend WithEvents TaskType As ComboBox
    Friend WithEvents translate As LinkLabel
    Friend WithEvents closeBtn As Button
    Friend WithEvents qtd_lbl As Label
    Friend WithEvents qtd As TextBox
    Friend WithEvents units As ComboBox
    Friend WithEvents mandatory As Label
    Friend WithEvents units_lbl As Label
    Friend WithEvents divider As Label
    Friend WithEvents save As LinkLabel
    Friend WithEvents price As TextBox
    Friend WithEvents del As LinkLabel
    Friend WithEvents price_lbl As Label
    Friend WithEvents taskType_lbl As Label
    Friend WithEvents description_lbl As Label
    Friend WithEvents description As TextBox
    Friend WithEvents GroupBoxTask As GroupBox
    Friend WithEvents groupBoxTasksList As GroupBox
    Friend WithEvents tasksList As ListBox
    Friend WithEvents show_all_lang As CheckBox
    Friend WithEvents languagesList As ListBox
    Friend WithEvents translatedLanguages_lbl As Label
    Friend WithEvents translationText_lbl As Label
    Friend WithEvents translationText As TextBox
    Friend WithEvents unitsTxt As TextBox
    Friend WithEvents reference_lbl As Label
    Friend WithEvents reference As TextBox
    Friend WithEvents numTranslations As Label
End Class
