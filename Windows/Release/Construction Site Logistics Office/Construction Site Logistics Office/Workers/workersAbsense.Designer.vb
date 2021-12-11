<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class workers_absense_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(workers_absense_frm))
        Me.divider = New System.Windows.Forms.Label()
        Me.annotations_lbl = New System.Windows.Forms.Label()
        Me.trip_lbl = New System.Windows.Forms.Label()
        Me.viagem = New System.Windows.Forms.ComboBox()
        Me.motif_lbl = New System.Windows.Forms.Label()
        Me.ausenciaslist = New System.Windows.Forms.ListBox()
        Me.save = New System.Windows.Forms.LinkLabel()
        Me.remove = New System.Windows.Forms.LinkLabel()
        Me.tipo = New System.Windows.Forms.ComboBox()
        Me.motivo = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.seachTitle = New System.Windows.Forms.Label()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.end_lbl = New System.Windows.Forms.Label()
        Me.duracaoInicio = New System.Windows.Forms.DateTimePicker()
        Me.duracaoFim = New System.Windows.Forms.DateTimePicker()
        Me.start_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(1, 30)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1130, 4)
        Me.divider.TabIndex = 280
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Location = New System.Drawing.Point(625, 121)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(58, 13)
        Me.annotations_lbl.TabIndex = 279
        Me.annotations_lbl.Text = "Anotações"
        '
        'trip_lbl
        '
        Me.trip_lbl.AutoSize = True
        Me.trip_lbl.Location = New System.Drawing.Point(765, 49)
        Me.trip_lbl.Name = "trip_lbl"
        Me.trip_lbl.Size = New System.Drawing.Size(42, 13)
        Me.trip_lbl.TabIndex = 278
        Me.trip_lbl.Text = "Viagem"
        '
        'viagem
        '
        Me.viagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.viagem.Enabled = False
        Me.viagem.FormattingEnabled = True
        Me.viagem.Items.AddRange(New Object() {"Avião", "Automóvel"})
        Me.viagem.Location = New System.Drawing.Point(765, 64)
        Me.viagem.Name = "viagem"
        Me.viagem.Size = New System.Drawing.Size(117, 21)
        Me.viagem.TabIndex = 277
        '
        'motif_lbl
        '
        Me.motif_lbl.AutoSize = True
        Me.motif_lbl.Location = New System.Drawing.Point(625, 49)
        Me.motif_lbl.Name = "motif_lbl"
        Me.motif_lbl.Size = New System.Drawing.Size(39, 13)
        Me.motif_lbl.TabIndex = 276
        Me.motif_lbl.Text = "Motivo"
        '
        'ausenciaslist
        '
        Me.ausenciaslist.BackColor = System.Drawing.Color.Honeydew
        Me.ausenciaslist.Enabled = False
        Me.ausenciaslist.FormattingEnabled = True
        Me.ausenciaslist.Location = New System.Drawing.Point(382, 58)
        Me.ausenciaslist.Name = "ausenciaslist"
        Me.ausenciaslist.Size = New System.Drawing.Size(236, 277)
        Me.ausenciaslist.TabIndex = 273
        '
        'save
        '
        Me.save.AutoSize = True
        Me.save.Enabled = False
        Me.save.Location = New System.Drawing.Point(1092, 338)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(39, 13)
        Me.save.TabIndex = 266
        Me.save.TabStop = True
        Me.save.Text = "Gravar"
        '
        'remove
        '
        Me.remove.AutoSize = True
        Me.remove.Enabled = False
        Me.remove.Location = New System.Drawing.Point(1043, 338)
        Me.remove.Name = "remove"
        Me.remove.Size = New System.Drawing.Size(41, 13)
        Me.remove.TabIndex = 267
        Me.remove.TabStop = True
        Me.remove.Text = "Apagar"
        '
        'tipo
        '
        Me.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipo.Enabled = False
        Me.tipo.FormattingEnabled = True
        Me.tipo.Items.AddRange(New Object() {"Férias", "Doença", "Pessoal", "Outro"})
        Me.tipo.Location = New System.Drawing.Point(626, 65)
        Me.tipo.Name = "tipo"
        Me.tipo.Size = New System.Drawing.Size(117, 21)
        Me.tipo.TabIndex = 272
        '
        'motivo
        '
        Me.motivo.Enabled = False
        Me.motivo.Location = New System.Drawing.Point(624, 137)
        Me.motivo.Multiline = True
        Me.motivo.Name = "motivo"
        Me.motivo.Size = New System.Drawing.Size(507, 198)
        Me.motivo.TabIndex = 270
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 10)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(83, 20)
        Me.title.TabIndex = 271
        Me.title.Text = "Ausências"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(356, 66)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 286
        Me.PictureBox1.TabStop = False
        '
        'seachTitle
        '
        Me.seachTitle.AutoSize = True
        Me.seachTitle.Location = New System.Drawing.Point(3, 49)
        Me.seachTitle.Name = "seachTitle"
        Me.seachTitle.Size = New System.Drawing.Size(47, 13)
        Me.seachTitle.TabIndex = 284
        Me.seachTitle.Text = "Procurar"
        '
        'searchbox
        '
        Me.searchbox.Location = New System.Drawing.Point(6, 66)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(329, 20)
        Me.searchbox.TabIndex = 285
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(7, 97)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(369, 238)
        Me.listview_works.TabIndex = 283
        '
        'updateLink
        '
        Me.updateLink.AutoSize = True
        Me.updateLink.Location = New System.Drawing.Point(323, 338)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(53, 13)
        Me.updateLink.TabIndex = 282
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Actualizar"
        '
        'end_lbl
        '
        Me.end_lbl.AutoSize = True
        Me.end_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.end_lbl.Location = New System.Drawing.Point(927, 93)
        Me.end_lbl.Name = "end_lbl"
        Me.end_lbl.Size = New System.Drawing.Size(23, 13)
        Me.end_lbl.TabIndex = 290
        Me.end_lbl.Text = "Fim"
        '
        'duracaoInicio
        '
        Me.duracaoInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicio.Location = New System.Drawing.Point(929, 62)
        Me.duracaoInicio.Name = "duracaoInicio"
        Me.duracaoInicio.Size = New System.Drawing.Size(202, 20)
        Me.duracaoInicio.TabIndex = 287
        '
        'duracaoFim
        '
        Me.duracaoFim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoFim.Location = New System.Drawing.Point(929, 110)
        Me.duracaoFim.Name = "duracaoFim"
        Me.duracaoFim.Size = New System.Drawing.Size(202, 20)
        Me.duracaoFim.TabIndex = 288
        '
        'start_lbl
        '
        Me.start_lbl.AutoSize = True
        Me.start_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_lbl.Location = New System.Drawing.Point(926, 46)
        Me.start_lbl.Name = "start_lbl"
        Me.start_lbl.Size = New System.Drawing.Size(32, 13)
        Me.start_lbl.TabIndex = 289
        Me.start_lbl.Text = "Inicio"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1045, 383)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 336
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.motivo)
        Me.Panel1.Controls.Add(Me.end_lbl)
        Me.Panel1.Controls.Add(Me.tipo)
        Me.Panel1.Controls.Add(Me.duracaoInicio)
        Me.Panel1.Controls.Add(Me.remove)
        Me.Panel1.Controls.Add(Me.duracaoFim)
        Me.Panel1.Controls.Add(Me.save)
        Me.Panel1.Controls.Add(Me.start_lbl)
        Me.Panel1.Controls.Add(Me.ausenciaslist)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.motif_lbl)
        Me.Panel1.Controls.Add(Me.seachTitle)
        Me.Panel1.Controls.Add(Me.viagem)
        Me.Panel1.Controls.Add(Me.searchbox)
        Me.Panel1.Controls.Add(Me.trip_lbl)
        Me.Panel1.Controls.Add(Me.listview_works)
        Me.Panel1.Controls.Add(Me.annotations_lbl)
        Me.Panel1.Controls.Add(Me.updateLink)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1154, 420)
        Me.Panel1.TabIndex = 337
        Me.Panel1.Visible = False
        '
        'workers_absense_frm
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
        Me.Name = "workers_absense_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Marcação de ausencias de trabalhadores"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents divider As Label
    Friend WithEvents annotations_lbl As Label
    Friend WithEvents trip_lbl As Label
    Friend WithEvents viagem As ComboBox
    Friend WithEvents motif_lbl As Label
    Friend WithEvents ausenciaslist As ListBox
    Friend WithEvents save As LinkLabel
    Friend WithEvents remove As LinkLabel
    Friend WithEvents tipo As ComboBox
    Friend WithEvents motivo As TextBox
    Friend WithEvents title As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents seachTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents end_lbl As Label
    Friend WithEvents duracaoInicio As DateTimePicker
    Friend WithEvents duracaoFim As DateTimePicker
    Friend WithEvents start_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
End Class
