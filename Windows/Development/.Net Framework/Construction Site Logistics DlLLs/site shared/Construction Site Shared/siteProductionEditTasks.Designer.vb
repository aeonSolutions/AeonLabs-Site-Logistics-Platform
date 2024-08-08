Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class siteProductionEditTasksForm
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1762, 1031)
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
        Me.GroupBoxTask.Location = New System.Drawing.Point(920, 100)
        Me.GroupBoxTask.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxTask.Name = "GroupBoxTask"
        Me.GroupBoxTask.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxTask.Size = New System.Drawing.Size(807, 852)
        Me.GroupBoxTask.TabIndex = 356
        Me.GroupBoxTask.TabStop = False
        Me.GroupBoxTask.Text = "Tarefa"
        '
        'numTranslations
        '
        Me.numTranslations.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numTranslations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numTranslations.Location = New System.Drawing.Point(350, 357)
        Me.numTranslations.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.numTranslations.Name = "numTranslations"
        Me.numTranslations.Size = New System.Drawing.Size(441, 23)
        Me.numTranslations.TabIndex = 350
        Me.numTranslations.Text = "Traduzido em x idiomas"
        Me.numTranslations.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'reference_lbl
        '
        Me.reference_lbl.AutoSize = True
        Me.reference_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reference_lbl.Location = New System.Drawing.Point(318, 29)
        Me.reference_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.reference_lbl.Name = "reference_lbl"
        Me.reference_lbl.Size = New System.Drawing.Size(59, 20)
        Me.reference_lbl.TabIndex = 349
        Me.reference_lbl.Text = "Preco*"
        '
        'reference
        '
        Me.reference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reference.Location = New System.Drawing.Point(322, 54)
        Me.reference.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.reference.Name = "reference"
        Me.reference.Size = New System.Drawing.Size(198, 26)
        Me.reference.TabIndex = 348
        '
        'unitsTxt
        '
        Me.unitsTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitsTxt.Location = New System.Drawing.Point(282, 126)
        Me.unitsTxt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.unitsTxt.Name = "unitsTxt"
        Me.unitsTxt.Size = New System.Drawing.Size(112, 26)
        Me.unitsTxt.TabIndex = 347
        '
        'translatedLanguages_lbl
        '
        Me.translatedLanguages_lbl.AutoSize = True
        Me.translatedLanguages_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translatedLanguages_lbl.Location = New System.Drawing.Point(20, 374)
        Me.translatedLanguages_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.translatedLanguages_lbl.Name = "translatedLanguages_lbl"
        Me.translatedLanguages_lbl.Size = New System.Drawing.Size(184, 20)
        Me.translatedLanguages_lbl.TabIndex = 346
        Me.translatedLanguages_lbl.Text = "traducoes da descricao"
        '
        'translationText_lbl
        '
        Me.translationText_lbl.AutoSize = True
        Me.translationText_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationText_lbl.Location = New System.Drawing.Point(15, 606)
        Me.translationText_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.translationText_lbl.Name = "translationText_lbl"
        Me.translationText_lbl.Size = New System.Drawing.Size(232, 20)
        Me.translationText_lbl.TabIndex = 345
        Me.translationText_lbl.Text = "desxricao traduzida da tarefa*"
        '
        'translationText
        '
        Me.translationText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationText.Location = New System.Drawing.Point(20, 632)
        Me.translationText.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.translationText.Multiline = True
        Me.translationText.Name = "translationText"
        Me.translationText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.translationText.Size = New System.Drawing.Size(769, 146)
        Me.translationText.TabIndex = 344
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(20, 568)
        Me.show_all_lang.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(205, 24)
        Me.show_all_lang.TabIndex = 343
        Me.show_all_lang.Text = "Show project languages"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'languagesList
        '
        Me.languagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.languagesList.FormattingEnabled = True
        Me.languagesList.ItemHeight = 20
        Me.languagesList.Location = New System.Drawing.Point(20, 400)
        Me.languagesList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.languagesList.Name = "languagesList"
        Me.languagesList.Size = New System.Drawing.Size(766, 162)
        Me.languagesList.TabIndex = 342
        '
        'description_lbl
        '
        Me.description_lbl.AutoSize = True
        Me.description_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description_lbl.Location = New System.Drawing.Point(20, 178)
        Me.description_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.description_lbl.Name = "description_lbl"
        Me.description_lbl.Size = New System.Drawing.Size(217, 20)
        Me.description_lbl.TabIndex = 308
        Me.description_lbl.Text = "desxricao original da tarefa*"
        '
        'price_lbl
        '
        Me.price_lbl.AutoSize = True
        Me.price_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.price_lbl.Location = New System.Drawing.Point(579, 102)
        Me.price_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.price_lbl.Name = "price_lbl"
        Me.price_lbl.Size = New System.Drawing.Size(59, 20)
        Me.price_lbl.TabIndex = 316
        Me.price_lbl.Text = "Preco*"
        '
        'taskType_lbl
        '
        Me.taskType_lbl.AutoSize = True
        Me.taskType_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.taskType_lbl.Location = New System.Drawing.Point(20, 23)
        Me.taskType_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.taskType_lbl.Name = "taskType_lbl"
        Me.taskType_lbl.Size = New System.Drawing.Size(47, 20)
        Me.taskType_lbl.TabIndex = 341
        Me.taskType_lbl.Text = "Tipo*"
        '
        'del
        '
        Me.del.AutoSize = True
        Me.del.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del.Location = New System.Drawing.Point(38, 798)
        Me.del.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.del.Name = "del"
        Me.del.Size = New System.Drawing.Size(62, 20)
        Me.del.TabIndex = 311
        Me.del.TabStop = True
        Me.del.Text = "Apagar"
        Me.del.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'price
        '
        Me.price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.price.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.price.Location = New System.Drawing.Point(584, 126)
        Me.price.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.price.Name = "price"
        Me.price.Size = New System.Drawing.Size(198, 26)
        Me.price.TabIndex = 315
        '
        'TaskType
        '
        Me.TaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TaskType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType.FormattingEnabled = True
        Me.TaskType.Items.AddRange(New Object() {"Title", "SubTitle", "Task"})
        Me.TaskType.Location = New System.Drawing.Point(20, 52)
        Me.TaskType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TaskType.Name = "TaskType"
        Me.TaskType.Size = New System.Drawing.Size(218, 28)
        Me.TaskType.TabIndex = 340
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save.Location = New System.Drawing.Point(124, 798)
        Me.save.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(60, 20)
        Me.save.TabIndex = 312
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        Me.save.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'units_lbl
        '
        Me.units_lbl.AutoSize = True
        Me.units_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units_lbl.Location = New System.Drawing.Point(278, 102)
        Me.units_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.units_lbl.Name = "units_lbl"
        Me.units_lbl.Size = New System.Drawing.Size(85, 20)
        Me.units_lbl.TabIndex = 310
        Me.units_lbl.Text = "Unidades*"
        '
        'translate
        '
        Me.translate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.translate.AutoSize = True
        Me.translate.Location = New System.Drawing.Point(714, 568)
        Me.translate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.translate.Name = "translate"
        Me.translate.Size = New System.Drawing.Size(66, 20)
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
        Me.units.Location = New System.Drawing.Point(405, 126)
        Me.units.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(115, 28)
        Me.units.TabIndex = 306
        '
        'description
        '
        Me.description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.description.Location = New System.Drawing.Point(20, 205)
        Me.description.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.description.Multiline = True
        Me.description.Name = "description"
        Me.description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.description.Size = New System.Drawing.Size(769, 146)
        Me.description.TabIndex = 305
        '
        'qtd
        '
        Me.qtd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd.Location = New System.Drawing.Point(18, 125)
        Me.qtd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.qtd.Name = "qtd"
        Me.qtd.Size = New System.Drawing.Size(187, 26)
        Me.qtd.TabIndex = 307
        '
        'qtd_lbl
        '
        Me.qtd_lbl.AutoSize = True
        Me.qtd_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qtd_lbl.Location = New System.Drawing.Point(20, 102)
        Me.qtd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.qtd_lbl.Name = "qtd_lbl"
        Me.qtd_lbl.Size = New System.Drawing.Size(100, 20)
        Me.qtd_lbl.TabIndex = 309
        Me.qtd_lbl.Text = "Quantidade*"
        '
        'groupBoxTasksList
        '
        Me.groupBoxTasksList.Controls.Add(Me.tasksList)
        Me.groupBoxTasksList.Location = New System.Drawing.Point(16, 100)
        Me.groupBoxTasksList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBoxTasksList.Name = "groupBoxTasksList"
        Me.groupBoxTasksList.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.groupBoxTasksList.Size = New System.Drawing.Size(894, 852)
        Me.groupBoxTasksList.TabIndex = 355
        Me.groupBoxTasksList.TabStop = False
        Me.groupBoxTasksList.Text = "Insert next to"
        '
        'tasksList
        '
        Me.tasksList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tasksList.FormattingEnabled = True
        Me.tasksList.HorizontalScrollbar = True
        Me.tasksList.Location = New System.Drawing.Point(9, 29)
        Me.tasksList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tasksList.Name = "tasksList"
        Me.tasksList.Size = New System.Drawing.Size(860, 732)
        Me.tasksList.TabIndex = 350
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(4, 8)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(154, 29)
        Me.title.TabIndex = 313
        Me.title.Text = "Editar tarefas"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1596, 963)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'mandatory
        '
        Me.mandatory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mandatory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mandatory.Location = New System.Drawing.Point(1298, 60)
        Me.mandatory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.mandatory.Name = "mandatory"
        Me.mandatory.Size = New System.Drawing.Size(434, 38)
        Me.mandatory.TabIndex = 319
        Me.mandatory.Text = "campos com * são obrigatórios"
        Me.mandatory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.Location = New System.Drawing.Point(8, 45)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1721, 5)
        Me.divider.TabIndex = 314
        '
        'siteProductionEditTasksForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1762, 1031)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "siteProductionEditTasksForm"
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
