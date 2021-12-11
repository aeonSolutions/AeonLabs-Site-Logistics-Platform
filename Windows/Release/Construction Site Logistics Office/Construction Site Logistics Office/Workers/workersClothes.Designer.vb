<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class workersClothes_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workersClothes_frm))
        Me.deliveredDate = New System.Windows.Forms.DateTimePicker()
        Me.deliveredDate_lbl = New System.Windows.Forms.Label()
        Me.searchBoxBtn = New System.Windows.Forms.PictureBox()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.divider = New System.Windows.Forms.Label()
        Me.annotations_lbl = New System.Windows.Forms.Label()
        Me.outro_lbl = New System.Windows.Forms.Label()
        Me.tipo_lbl = New System.Windows.Forms.Label()
        Me.deliveredClothesList = New System.Windows.Forms.ListBox()
        Me.save = New System.Windows.Forms.LinkLabel()
        Me.remove = New System.Windows.Forms.LinkLabel()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.motivo = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.outro = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.workersUpdateBtn = New System.Windows.Forms.PictureBox()
        Me.siteRecordDate = New System.Windows.Forms.DateTimePicker()
        Me.workerClothesSizes = New System.Windows.Forms.Label()
        Me.requestedDate = New System.Windows.Forms.DateTimePicker()
        Me.requestedDate_lbl = New System.Windows.Forms.Label()
        Me.delivered_lbl = New System.Windows.Forms.Label()
        Me.requested_lbl = New System.Windows.Forms.Label()
        Me.requieredClothesList = New System.Windows.Forms.ListBox()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.photobox = New System.Windows.Forms.PictureBox()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deliveredDate
        '
        Me.deliveredDate.Enabled = False
        Me.deliveredDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredDate.Location = New System.Drawing.Point(900, 143)
        Me.deliveredDate.Name = "deliveredDate"
        Me.deliveredDate.Size = New System.Drawing.Size(202, 21)
        Me.deliveredDate.TabIndex = 308
        '
        'deliveredDate_lbl
        '
        Me.deliveredDate_lbl.AutoSize = True
        Me.deliveredDate_lbl.Enabled = False
        Me.deliveredDate_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredDate_lbl.Location = New System.Drawing.Point(897, 129)
        Me.deliveredDate_lbl.Name = "deliveredDate_lbl"
        Me.deliveredDate_lbl.Size = New System.Drawing.Size(100, 13)
        Me.deliveredDate_lbl.TabIndex = 310
        Me.deliveredDate_lbl.Text = "Data de entrega"
        '
        'searchBoxBtn
        '
        Me.searchBoxBtn.Image = CType(resources.GetObject("searchBoxBtn.Image"), System.Drawing.Image)
        Me.searchBoxBtn.InitialImage = Nothing
        Me.searchBoxBtn.Location = New System.Drawing.Point(357, 165)
        Me.searchBoxBtn.Name = "searchBoxBtn"
        Me.searchBoxBtn.Size = New System.Drawing.Size(21, 21)
        Me.searchBoxBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchBoxBtn.TabIndex = 307
        Me.searchBoxBtn.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(10, 148)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(56, 13)
        Me.searchTitle.TabIndex = 305
        Me.searchTitle.Text = "Procurar"
        '
        'searchbox
        '
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(6, 165)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(345, 21)
        Me.searchbox.TabIndex = 306
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(6, 192)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(373, 264)
        Me.listview_works.TabIndex = 304
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(1, 29)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1083, 4)
        Me.divider.TabIndex = 301
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Enabled = False
        Me.annotations_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.annotations_lbl.Location = New System.Drawing.Point(639, 190)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(66, 13)
        Me.annotations_lbl.TabIndex = 300
        Me.annotations_lbl.Text = "Anotações"
        '
        'outro_lbl
        '
        Me.outro_lbl.AutoSize = True
        Me.outro_lbl.Enabled = False
        Me.outro_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outro_lbl.Location = New System.Drawing.Point(643, 129)
        Me.outro_lbl.Name = "outro_lbl"
        Me.outro_lbl.Size = New System.Drawing.Size(39, 13)
        Me.outro_lbl.TabIndex = 299
        Me.outro_lbl.Text = "Outro"
        '
        'tipo_lbl
        '
        Me.tipo_lbl.AutoSize = True
        Me.tipo_lbl.Enabled = False
        Me.tipo_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_lbl.Location = New System.Drawing.Point(643, 72)
        Me.tipo_lbl.Name = "tipo_lbl"
        Me.tipo_lbl.Size = New System.Drawing.Size(31, 13)
        Me.tipo_lbl.TabIndex = 297
        Me.tipo_lbl.Text = "Tipo"
        '
        'deliveredClothesList
        '
        Me.deliveredClothesList.BackColor = System.Drawing.Color.Honeydew
        Me.deliveredClothesList.Enabled = False
        Me.deliveredClothesList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredClothesList.FormattingEnabled = True
        Me.deliveredClothesList.HorizontalScrollbar = True
        Me.deliveredClothesList.Location = New System.Drawing.Point(388, 309)
        Me.deliveredClothesList.Name = "deliveredClothesList"
        Me.deliveredClothesList.Size = New System.Drawing.Size(236, 147)
        Me.deliveredClothesList.TabIndex = 296
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Enabled = False
        Me.save.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save.Location = New System.Drawing.Point(1050, 373)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(47, 13)
        Me.save.TabIndex = 291
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        '
        'remove
        '
        Me.remove.AutoSize = True
        Me.remove.Enabled = False
        Me.remove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remove.Location = New System.Drawing.Point(1001, 373)
        Me.remove.Name = "remove"
        Me.remove.Size = New System.Drawing.Size(48, 13)
        Me.remove.TabIndex = 292
        Me.remove.TabStop = True
        Me.remove.Text = "Apagar"
        '
        'tipo
        '
        Me.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipo.Enabled = False
        Me.tipo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Botas", "Calças", "Casaco", "Capacete", "Colete refletor", "Galochas", "Impermeavel", "Luvas", "Oculos", "Proteção de ouvidos", "Outro"})
        Me.tipo.Location = New System.Drawing.Point(644, 88)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(247, 21)
        Me.tipo.TabIndex = 295
        '
        'motivo
        '
        Me.motivo.Enabled = False
        Me.motivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.motivo.Location = New System.Drawing.Point(642, 206)
        Me.motivo.Multiline = True
        Me.motivo.Name = "motivo"
        Me.motivo.Size = New System.Drawing.Size(460, 164)
        Me.motivo.TabIndex = 293
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 9)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(339, 18)
        Me.title.TabIndex = 294
        Me.title.Text = "Vestuário e Equipamento de Proteção"
        '
        'outro
        '
        Me.outro.Enabled = False
        Me.outro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outro.Location = New System.Drawing.Point(646, 145)
        Me.outro.Name = "outro"
        Me.outro.Size = New System.Drawing.Size(245, 21)
        Me.outro.TabIndex = 311
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1006, 430)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.workersUpdateBtn)
        Me.Panel1.Controls.Add(Me.siteRecordDate)
        Me.Panel1.Controls.Add(Me.workerClothesSizes)
        Me.Panel1.Controls.Add(Me.requestedDate)
        Me.Panel1.Controls.Add(Me.requestedDate_lbl)
        Me.Panel1.Controls.Add(Me.delivered_lbl)
        Me.Panel1.Controls.Add(Me.requested_lbl)
        Me.Panel1.Controls.Add(Me.requieredClothesList)
        Me.Panel1.Controls.Add(Me.combo_site)
        Me.Panel1.Controls.Add(Me.site_lbl)
        Me.Panel1.Controls.Add(Me.photobox)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.motivo)
        Me.Panel1.Controls.Add(Me.outro)
        Me.Panel1.Controls.Add(Me.tipo)
        Me.Panel1.Controls.Add(Me.deliveredDate)
        Me.Panel1.Controls.Add(Me.remove)
        Me.Panel1.Controls.Add(Me.deliveredDate_lbl)
        Me.Panel1.Controls.Add(Me.save)
        Me.Panel1.Controls.Add(Me.searchBoxBtn)
        Me.Panel1.Controls.Add(Me.deliveredClothesList)
        Me.Panel1.Controls.Add(Me.searchTitle)
        Me.Panel1.Controls.Add(Me.tipo_lbl)
        Me.Panel1.Controls.Add(Me.searchbox)
        Me.Panel1.Controls.Add(Me.outro_lbl)
        Me.Panel1.Controls.Add(Me.listview_works)
        Me.Panel1.Controls.Add(Me.annotations_lbl)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1110, 469)
        Me.Panel1.TabIndex = 338
        Me.Panel1.Visible = False
        '
        'workersUpdateBtn
        '
        Me.workersUpdateBtn.Image = CType(resources.GetObject("workersUpdateBtn.Image"), System.Drawing.Image)
        Me.workersUpdateBtn.InitialImage = Nothing
        Me.workersUpdateBtn.Location = New System.Drawing.Point(357, 96)
        Me.workersUpdateBtn.Name = "workersUpdateBtn"
        Me.workersUpdateBtn.Size = New System.Drawing.Size(21, 21)
        Me.workersUpdateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.workersUpdateBtn.TabIndex = 350
        Me.workersUpdateBtn.TabStop = False
        '
        'siteRecordDate
        '
        Me.siteRecordDate.CustomFormat = "yyyy - MMMM"
        Me.siteRecordDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteRecordDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.siteRecordDate.Location = New System.Drawing.Point(171, 96)
        Me.siteRecordDate.Name = "siteRecordDate"
        Me.siteRecordDate.Size = New System.Drawing.Size(180, 21)
        Me.siteRecordDate.TabIndex = 349
        '
        'workerClothesSizes
        '
        Me.workerClothesSizes.Location = New System.Drawing.Point(517, 47)
        Me.workerClothesSizes.Name = "workerClothesSizes"
        Me.workerClothesSizes.Size = New System.Drawing.Size(120, 140)
        Me.workerClothesSizes.TabIndex = 348
        Me.workerClothesSizes.Text = "Tamanhos"
        '
        'requestedDate
        '
        Me.requestedDate.Enabled = False
        Me.requestedDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestedDate.Location = New System.Drawing.Point(900, 85)
        Me.requestedDate.Name = "requestedDate"
        Me.requestedDate.Size = New System.Drawing.Size(202, 21)
        Me.requestedDate.TabIndex = 345
        '
        'requestedDate_lbl
        '
        Me.requestedDate_lbl.AutoSize = True
        Me.requestedDate_lbl.Enabled = False
        Me.requestedDate_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestedDate_lbl.Location = New System.Drawing.Point(897, 71)
        Me.requestedDate_lbl.Name = "requestedDate_lbl"
        Me.requestedDate_lbl.Size = New System.Drawing.Size(94, 13)
        Me.requestedDate_lbl.TabIndex = 346
        Me.requestedDate_lbl.Text = "Data do pedido"
        '
        'delivered_lbl
        '
        Me.delivered_lbl.AutoSize = True
        Me.delivered_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delivered_lbl.Location = New System.Drawing.Point(385, 293)
        Me.delivered_lbl.Name = "delivered_lbl"
        Me.delivered_lbl.Size = New System.Drawing.Size(58, 13)
        Me.delivered_lbl.TabIndex = 344
        Me.delivered_lbl.Text = "Entregue"
        '
        'requested_lbl
        '
        Me.requested_lbl.AutoSize = True
        Me.requested_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requested_lbl.Location = New System.Drawing.Point(385, 174)
        Me.requested_lbl.Name = "requested_lbl"
        Me.requested_lbl.Size = New System.Drawing.Size(65, 13)
        Me.requested_lbl.TabIndex = 343
        Me.requested_lbl.Text = "Requerido"
        '
        'requieredClothesList
        '
        Me.requieredClothesList.BackColor = System.Drawing.Color.Honeydew
        Me.requieredClothesList.Enabled = False
        Me.requieredClothesList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requieredClothesList.FormattingEnabled = True
        Me.requieredClothesList.HorizontalScrollbar = True
        Me.requieredClothesList.Location = New System.Drawing.Point(388, 190)
        Me.requieredClothesList.Name = "requieredClothesList"
        Me.requieredClothesList.Size = New System.Drawing.Size(236, 95)
        Me.requieredClothesList.TabIndex = 342
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(6, 63)
        Me.combo_site.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(373, 26)
        Me.combo_site.TabIndex = 341
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(8, 47)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(38, 14)
        Me.site_lbl.TabIndex = 340
        Me.site_lbl.Text = "Obra"
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(388, 47)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(122, 117)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 339
        Me.photobox.TabStop = False
        '
        'workersClothes_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 469)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "workersClothes_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vestuário e equipamento de protecção"
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents deliveredDate As DateTimePicker
    Friend WithEvents deliveredDate_lbl As Label
    Friend WithEvents searchBoxBtn As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents divider As Label
    Friend WithEvents annotations_lbl As Label
    Friend WithEvents outro_lbl As Label
    Friend WithEvents tipo_lbl As Label
    Friend WithEvents deliveredClothesList As ListBox
    Friend WithEvents save As LinkLabel
    Friend WithEvents remove As LinkLabel
    Friend WithEvents tipo As ComboBox
    Friend WithEvents motivo As TextBox
    Friend WithEvents title As Label
    Friend WithEvents outro As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents photobox As PictureBox
    Friend WithEvents delivered_lbl As Label
    Friend WithEvents requested_lbl As Label
    Friend WithEvents requieredClothesList As ListBox
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents site_lbl As Label
    Friend WithEvents requestedDate As DateTimePicker
    Friend WithEvents requestedDate_lbl As Label
    Friend WithEvents workerClothesSizes As Label
    Friend WithEvents siteRecordDate As DateTimePicker
    Friend WithEvents workersUpdateBtn As PictureBox
End Class
