Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class workersClothesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workersClothesForm))
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
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.motivo = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.outro = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.delBtn = New System.Windows.Forms.PictureBox()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
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
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deliveredDate
        '
        Me.deliveredDate.Enabled = False
        Me.deliveredDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredDate.Location = New System.Drawing.Point(1350, 220)
        Me.deliveredDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.deliveredDate.Name = "deliveredDate"
        Me.deliveredDate.Size = New System.Drawing.Size(301, 28)
        Me.deliveredDate.TabIndex = 308
        '
        'deliveredDate_lbl
        '
        Me.deliveredDate_lbl.AutoSize = True
        Me.deliveredDate_lbl.Enabled = False
        Me.deliveredDate_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredDate_lbl.Location = New System.Drawing.Point(1346, 198)
        Me.deliveredDate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.deliveredDate_lbl.Name = "deliveredDate_lbl"
        Me.deliveredDate_lbl.Size = New System.Drawing.Size(148, 20)
        Me.deliveredDate_lbl.TabIndex = 310
        Me.deliveredDate_lbl.Text = "Data de entrega"
        '
        'searchBoxBtn
        '
        Me.searchBoxBtn.Image = CType(resources.GetObject("searchBoxBtn.Image"), System.Drawing.Image)
        Me.searchBoxBtn.InitialImage = Nothing
        Me.searchBoxBtn.Location = New System.Drawing.Point(536, 254)
        Me.searchBoxBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.searchBoxBtn.Name = "searchBoxBtn"
        Me.searchBoxBtn.Size = New System.Drawing.Size(32, 32)
        Me.searchBoxBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchBoxBtn.TabIndex = 307
        Me.searchBoxBtn.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(15, 228)
        Me.searchTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(80, 20)
        Me.searchTitle.TabIndex = 305
        Me.searchTitle.Text = "Procurar"
        '
        'searchbox
        '
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(9, 254)
        Me.searchbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(516, 28)
        Me.searchbox.TabIndex = 306
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(9, 295)
        Me.listview_works.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(558, 394)
        Me.listview_works.TabIndex = 304
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(2, 45)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1624, 5)
        Me.divider.TabIndex = 301
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Enabled = False
        Me.annotations_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.annotations_lbl.Location = New System.Drawing.Point(958, 292)
        Me.annotations_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(97, 20)
        Me.annotations_lbl.TabIndex = 300
        Me.annotations_lbl.Text = "Anotações"
        '
        'outro_lbl
        '
        Me.outro_lbl.AutoSize = True
        Me.outro_lbl.Enabled = False
        Me.outro_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outro_lbl.Location = New System.Drawing.Point(964, 198)
        Me.outro_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.outro_lbl.Name = "outro_lbl"
        Me.outro_lbl.Size = New System.Drawing.Size(57, 20)
        Me.outro_lbl.TabIndex = 299
        Me.outro_lbl.Text = "Outro"
        '
        'tipo_lbl
        '
        Me.tipo_lbl.AutoSize = True
        Me.tipo_lbl.Enabled = False
        Me.tipo_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo_lbl.Location = New System.Drawing.Point(964, 111)
        Me.tipo_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.tipo_lbl.Name = "tipo_lbl"
        Me.tipo_lbl.Size = New System.Drawing.Size(45, 20)
        Me.tipo_lbl.TabIndex = 297
        Me.tipo_lbl.Text = "Tipo"
        '
        'deliveredClothesList
        '
        Me.deliveredClothesList.BackColor = System.Drawing.Color.Cornsilk
        Me.deliveredClothesList.Enabled = False
        Me.deliveredClothesList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveredClothesList.FormattingEnabled = True
        Me.deliveredClothesList.HorizontalScrollbar = True
        Me.deliveredClothesList.ItemHeight = 20
        Me.deliveredClothesList.Location = New System.Drawing.Point(582, 475)
        Me.deliveredClothesList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.deliveredClothesList.Name = "deliveredClothesList"
        Me.deliveredClothesList.Size = New System.Drawing.Size(352, 204)
        Me.deliveredClothesList.TabIndex = 296
        '
        'tipo
        '
        Me.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipo.Enabled = False
        Me.tipo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Botas", "Calças", "Casaco", "Capacete", "Colete refletor", "Galochas", "Impermeavel", "Luvas", "Oculos", "Proteção de ouvidos", "Outro"})
        Me.tipo.Location = New System.Drawing.Point(966, 135)
        Me.tipo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(368, 28)
        Me.tipo.TabIndex = 295
        '
        'motivo
        '
        Me.motivo.Enabled = False
        Me.motivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.motivo.Location = New System.Drawing.Point(963, 317)
        Me.motivo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.motivo.Multiline = True
        Me.motivo.Name = "motivo"
        Me.motivo.Size = New System.Drawing.Size(688, 332)
        Me.motivo.TabIndex = 293
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(4, 14)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(517, 29)
        Me.title.TabIndex = 294
        Me.title.Text = "Vestuário e Equipamento de Proteção"
        '
        'outro
        '
        Me.outro.Enabled = False
        Me.outro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outro.Location = New System.Drawing.Point(969, 223)
        Me.outro.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.outro.Name = "outro"
        Me.outro.Size = New System.Drawing.Size(366, 28)
        Me.outro.TabIndex = 311
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1522, 667)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.delBtn)
        Me.Panel1.Controls.Add(Me.saveBtn)
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
        Me.Panel1.Controls.Add(Me.deliveredDate_lbl)
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1665, 722)
        Me.Panel1.TabIndex = 338
        Me.Panel1.Visible = False
        '
        'delBtn
        '
        Me.delBtn.Image = CType(resources.GetObject("delBtn.Image"), System.Drawing.Image)
        Me.delBtn.Location = New System.Drawing.Point(965, 658)
        Me.delBtn.Name = "delBtn"
        Me.delBtn.Size = New System.Drawing.Size(50, 50)
        Me.delBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delBtn.TabIndex = 379
        Me.delBtn.TabStop = False
        '
        'saveBtn
        '
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(1033, 657)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 378
        Me.saveBtn.TabStop = False
        '
        'workersUpdateBtn
        '
        Me.workersUpdateBtn.Image = CType(resources.GetObject("workersUpdateBtn.Image"), System.Drawing.Image)
        Me.workersUpdateBtn.InitialImage = Nothing
        Me.workersUpdateBtn.Location = New System.Drawing.Point(536, 148)
        Me.workersUpdateBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.workersUpdateBtn.Name = "workersUpdateBtn"
        Me.workersUpdateBtn.Size = New System.Drawing.Size(32, 32)
        Me.workersUpdateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.workersUpdateBtn.TabIndex = 350
        Me.workersUpdateBtn.TabStop = False
        '
        'siteRecordDate
        '
        Me.siteRecordDate.CustomFormat = "yyyy - MMMM"
        Me.siteRecordDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteRecordDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.siteRecordDate.Location = New System.Drawing.Point(256, 148)
        Me.siteRecordDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.siteRecordDate.Name = "siteRecordDate"
        Me.siteRecordDate.Size = New System.Drawing.Size(268, 28)
        Me.siteRecordDate.TabIndex = 349
        '
        'workerClothesSizes
        '
        Me.workerClothesSizes.Location = New System.Drawing.Point(776, 72)
        Me.workerClothesSizes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workerClothesSizes.Name = "workerClothesSizes"
        Me.workerClothesSizes.Size = New System.Drawing.Size(180, 215)
        Me.workerClothesSizes.TabIndex = 348
        Me.workerClothesSizes.Text = "Tamanhos"
        '
        'requestedDate
        '
        Me.requestedDate.Enabled = False
        Me.requestedDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestedDate.Location = New System.Drawing.Point(1350, 131)
        Me.requestedDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.requestedDate.Name = "requestedDate"
        Me.requestedDate.Size = New System.Drawing.Size(301, 28)
        Me.requestedDate.TabIndex = 345
        '
        'requestedDate_lbl
        '
        Me.requestedDate_lbl.AutoSize = True
        Me.requestedDate_lbl.Enabled = False
        Me.requestedDate_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requestedDate_lbl.Location = New System.Drawing.Point(1346, 109)
        Me.requestedDate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.requestedDate_lbl.Name = "requestedDate_lbl"
        Me.requestedDate_lbl.Size = New System.Drawing.Size(140, 20)
        Me.requestedDate_lbl.TabIndex = 346
        Me.requestedDate_lbl.Text = "Data do pedido"
        '
        'delivered_lbl
        '
        Me.delivered_lbl.AutoSize = True
        Me.delivered_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delivered_lbl.Location = New System.Drawing.Point(578, 451)
        Me.delivered_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.delivered_lbl.Name = "delivered_lbl"
        Me.delivered_lbl.Size = New System.Drawing.Size(87, 20)
        Me.delivered_lbl.TabIndex = 344
        Me.delivered_lbl.Text = "Entregue"
        '
        'requested_lbl
        '
        Me.requested_lbl.AutoSize = True
        Me.requested_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requested_lbl.Location = New System.Drawing.Point(578, 268)
        Me.requested_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.requested_lbl.Name = "requested_lbl"
        Me.requested_lbl.Size = New System.Drawing.Size(96, 20)
        Me.requested_lbl.TabIndex = 343
        Me.requested_lbl.Text = "Requerido"
        '
        'requieredClothesList
        '
        Me.requieredClothesList.BackColor = System.Drawing.Color.Cornsilk
        Me.requieredClothesList.Enabled = False
        Me.requieredClothesList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requieredClothesList.FormattingEnabled = True
        Me.requieredClothesList.HorizontalScrollbar = True
        Me.requieredClothesList.ItemHeight = 20
        Me.requieredClothesList.Location = New System.Drawing.Point(582, 292)
        Me.requieredClothesList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.requieredClothesList.Name = "requieredClothesList"
        Me.requieredClothesList.Size = New System.Drawing.Size(352, 144)
        Me.requieredClothesList.TabIndex = 342
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(9, 97)
        Me.combo_site.Margin = New System.Windows.Forms.Padding(6)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(558, 37)
        Me.combo_site.TabIndex = 341
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(12, 72)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(54, 22)
        Me.site_lbl.TabIndex = 340
        Me.site_lbl.Text = "Obra"
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(582, 72)
        Me.photobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(182, 179)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 339
        Me.photobox.TabStop = False
        '
        'workersClothesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1665, 722)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "workersClothesForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vestuário e equipamento de protecção"
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents delBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
End Class
