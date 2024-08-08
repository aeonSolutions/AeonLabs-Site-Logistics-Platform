Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class site_closure_frm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(site_closure_frm))
        Me.divider = New System.Windows.Forms.Label()
        Me.annotations_lbl = New System.Windows.Forms.Label()
        Me.ausenciaslist = New System.Windows.Forms.ListBox()
        Me.motif = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.end_lbl = New System.Windows.Forms.Label()
        Me.duracaoInicio = New System.Windows.Forms.DateTimePicker()
        Me.duracaoFim = New System.Windows.Forms.DateTimePicker()
        Me.start_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.updateBtn = New System.Windows.Forms.PictureBox()
        Me.delBtn = New System.Windows.Forms.PictureBox()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(14, 43)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1694, 5)
        Me.divider.TabIndex = 280
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Location = New System.Drawing.Point(948, 140)
        Me.annotations_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(86, 20)
        Me.annotations_lbl.TabIndex = 279
        Me.annotations_lbl.Text = "Anotações"
        '
        'ausenciaslist
        '
        Me.ausenciaslist.BackColor = System.Drawing.Color.Cornsilk
        Me.ausenciaslist.Enabled = False
        Me.ausenciaslist.FormattingEnabled = True
        Me.ausenciaslist.ItemHeight = 20
        Me.ausenciaslist.Location = New System.Drawing.Point(585, 86)
        Me.ausenciaslist.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ausenciaslist.Name = "ausenciaslist"
        Me.ausenciaslist.Size = New System.Drawing.Size(352, 424)
        Me.ausenciaslist.TabIndex = 273
        '
        'motif
        '
        Me.motif.Enabled = False
        Me.motif.Location = New System.Drawing.Point(948, 166)
        Me.motif.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.motif.Multiline = True
        Me.motif.Name = "motif"
        Me.motif.Size = New System.Drawing.Size(758, 344)
        Me.motif.TabIndex = 270
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(16, 12)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(576, 29)
        Me.title.TabIndex = 271
        Me.title.Text = "Marcação de periodos de encerramento do estaleiro"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(544, 102)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 286
        Me.PictureBox1.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Location = New System.Drawing.Point(17, 80)
        Me.searchTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(69, 20)
        Me.searchTitle.TabIndex = 284
        Me.searchTitle.Text = "Procurar"
        '
        'searchbox
        '
        Me.searchbox.Location = New System.Drawing.Point(14, 107)
        Me.searchbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(522, 26)
        Me.searchbox.TabIndex = 285
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(16, 152)
        Me.listview_works.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(558, 355)
        Me.listview_works.TabIndex = 283
        '
        'end_lbl
        '
        Me.end_lbl.AutoSize = True
        Me.end_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.end_lbl.Location = New System.Drawing.Point(1401, 80)
        Me.end_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.end_lbl.Name = "end_lbl"
        Me.end_lbl.Size = New System.Drawing.Size(37, 20)
        Me.end_lbl.TabIndex = 290
        Me.end_lbl.Text = "Fim"
        '
        'duracaoInicio
        '
        Me.duracaoInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoInicio.Location = New System.Drawing.Point(1016, 105)
        Me.duracaoInicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.duracaoInicio.Name = "duracaoInicio"
        Me.duracaoInicio.Size = New System.Drawing.Size(301, 26)
        Me.duracaoInicio.TabIndex = 287
        '
        'duracaoFim
        '
        Me.duracaoFim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duracaoFim.Location = New System.Drawing.Point(1406, 105)
        Me.duracaoFim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.duracaoFim.Name = "duracaoFim"
        Me.duracaoFim.Size = New System.Drawing.Size(301, 26)
        Me.duracaoFim.TabIndex = 288
        '
        'start_lbl
        '
        Me.start_lbl.AutoSize = True
        Me.start_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_lbl.Location = New System.Drawing.Point(1011, 82)
        Me.start_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.start_lbl.Name = "start_lbl"
        Me.start_lbl.Size = New System.Drawing.Size(48, 20)
        Me.start_lbl.TabIndex = 289
        Me.start_lbl.Text = "Inicio"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1580, 586)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 336
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.updateBtn)
        Me.Panel1.Controls.Add(Me.delBtn)
        Me.Panel1.Controls.Add(Me.saveBtn)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.motif)
        Me.Panel1.Controls.Add(Me.end_lbl)
        Me.Panel1.Controls.Add(Me.duracaoInicio)
        Me.Panel1.Controls.Add(Me.duracaoFim)
        Me.Panel1.Controls.Add(Me.start_lbl)
        Me.Panel1.Controls.Add(Me.ausenciaslist)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.searchTitle)
        Me.Panel1.Controls.Add(Me.searchbox)
        Me.Panel1.Controls.Add(Me.listview_works)
        Me.Panel1.Controls.Add(Me.annotations_lbl)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1731, 646)
        Me.Panel1.TabIndex = 337
        '
        'updateBtn
        '
        Me.updateBtn.Image = CType(resources.GetObject("updateBtn.Image"), System.Drawing.Image)
        Me.updateBtn.Location = New System.Drawing.Point(524, 515)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(50, 50)
        Me.updateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.updateBtn.TabIndex = 378
        Me.updateBtn.TabStop = False
        '
        'delBtn
        '
        Me.delBtn.Image = CType(resources.GetObject("delBtn.Image"), System.Drawing.Image)
        Me.delBtn.Location = New System.Drawing.Point(948, 518)
        Me.delBtn.Name = "delBtn"
        Me.delBtn.Size = New System.Drawing.Size(50, 50)
        Me.delBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delBtn.TabIndex = 377
        Me.delBtn.TabStop = False
        '
        'saveBtn
        '
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(1016, 517)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 376
        Me.saveBtn.TabStop = False
        '
        'site_closure_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1731, 646)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "site_closure_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Marcação de periodos de encerramento do estaleiro"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.updateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents divider As Label
    Friend WithEvents annotations_lbl As Label
    Friend WithEvents ausenciaslist As ListBox
    Friend WithEvents motif As TextBox
    Friend WithEvents title As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents end_lbl As Label
    Friend WithEvents duracaoInicio As DateTimePicker
    Friend WithEvents duracaoFim As DateTimePicker
    Friend WithEvents start_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents updateBtn As PictureBox
    Friend WithEvents delBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
End Class
