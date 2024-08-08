Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class siteRegieEdit
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(siteRegieEdit))
        Me.edit_regie_date = New System.Windows.Forms.DateTimePicker()
        Me.date_lbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.search_lbl = New System.Windows.Forms.Label()
        Me.edit_regie_searchbox = New System.Windows.Forms.TextBox()
        Me.edit_regie_available_workers = New System.Windows.Forms.ListBox()
        Me.divider = New System.Windows.Forms.Label()
        Me.annotations_lbl = New System.Windows.Forms.Label()
        Me.edit_regie_duration_lbl = New System.Windows.Forms.Label()
        Me.edit_regie_signed_workers = New System.Windows.Forms.ListBox()
        Me.edit_regie_save = New System.Windows.Forms.LinkLabel()
        Me.edit_regie_del = New System.Windows.Forms.LinkLabel()
        Me.edit_regie_notes = New System.Windows.Forms.TextBox()
        Me.title = New System.Windows.Forms.Label()
        Me.workersAssigned_lbl = New System.Windows.Forms.Label()
        Me.workersList_lbl = New System.Windows.Forms.Label()
        Me.start_time_lbl = New System.Windows.Forms.Label()
        Me.end_time_lbl = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.edit_regie_enable_hours = New System.Windows.Forms.CheckBox()
        Me.edit_regie_translate = New System.Windows.Forms.LinkLabel()
        Me.edit_regie_hora_inicio = New System.Windows.Forms.DateTimePicker()
        Me.edit_regie_hora_fim = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.edit_regie_notes_previous = New System.Windows.Forms.TextBox()
        Me.photobox = New System.Windows.Forms.PictureBox()
        Me.resetLink = New System.Windows.Forms.LinkLabel()
        Me.validation_reason = New System.Windows.Forms.TextBox()
        Me.validation_reason_lbl = New System.Windows.Forms.Label()
        Me.validation_duration = New System.Windows.Forms.DateTimePicker()
        Me.validation_time_lbl = New System.Windows.Forms.Label()
        Me.validate_record = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit_regie_date
        '
        Me.edit_regie_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_regie_date.Location = New System.Drawing.Point(950, 92)
        Me.edit_regie_date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_date.Name = "edit_regie_date"
        Me.edit_regie_date.Size = New System.Drawing.Size(301, 26)
        Me.edit_regie_date.TabIndex = 326
        '
        'date_lbl
        '
        Me.date_lbl.AutoSize = True
        Me.date_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lbl.Location = New System.Drawing.Point(945, 68)
        Me.date_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.date_lbl.Name = "date_lbl"
        Me.date_lbl.Size = New System.Drawing.Size(151, 20)
        Me.date_lbl.TabIndex = 327
        Me.date_lbl.Text = "Data dos trabalhos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(486, 106)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 325
        Me.PictureBox1.TabStop = False
        '
        'search_lbl
        '
        Me.search_lbl.AutoSize = True
        Me.search_lbl.Location = New System.Drawing.Point(14, 82)
        Me.search_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.search_lbl.Name = "search_lbl"
        Me.search_lbl.Size = New System.Drawing.Size(69, 20)
        Me.search_lbl.TabIndex = 323
        Me.search_lbl.Text = "Procurar"
        '
        'edit_regie_searchbox
        '
        Me.edit_regie_searchbox.Location = New System.Drawing.Point(14, 106)
        Me.edit_regie_searchbox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_searchbox.Name = "edit_regie_searchbox"
        Me.edit_regie_searchbox.Size = New System.Drawing.Size(462, 26)
        Me.edit_regie_searchbox.TabIndex = 324
        '
        'edit_regie_available_workers
        '
        Me.edit_regie_available_workers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edit_regie_available_workers.FormattingEnabled = True
        Me.edit_regie_available_workers.HorizontalScrollbar = True
        Me.edit_regie_available_workers.ItemHeight = 20
        Me.edit_regie_available_workers.Location = New System.Drawing.Point(14, 166)
        Me.edit_regie_available_workers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_available_workers.Name = "edit_regie_available_workers"
        Me.edit_regie_available_workers.Size = New System.Drawing.Size(502, 682)
        Me.edit_regie_available_workers.TabIndex = 322
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(10, 48)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1624, 5)
        Me.divider.TabIndex = 319
        '
        'annotations_lbl
        '
        Me.annotations_lbl.AutoSize = True
        Me.annotations_lbl.Location = New System.Drawing.Point(958, 169)
        Me.annotations_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.annotations_lbl.Name = "annotations_lbl"
        Me.annotations_lbl.Size = New System.Drawing.Size(86, 20)
        Me.annotations_lbl.TabIndex = 318
        Me.annotations_lbl.Text = "Anotações"
        '
        'edit_regie_duration_lbl
        '
        Me.edit_regie_duration_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edit_regie_duration_lbl.Location = New System.Drawing.Point(1355, 162)
        Me.edit_regie_duration_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.edit_regie_duration_lbl.Name = "edit_regie_duration_lbl"
        Me.edit_regie_duration_lbl.Size = New System.Drawing.Size(262, 31)
        Me.edit_regie_duration_lbl.TabIndex = 317
        Me.edit_regie_duration_lbl.Text = "Duração"
        Me.edit_regie_duration_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'edit_regie_signed_workers
        '
        Me.edit_regie_signed_workers.BackColor = System.Drawing.Color.Cornsilk
        Me.edit_regie_signed_workers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edit_regie_signed_workers.Enabled = False
        Me.edit_regie_signed_workers.FormattingEnabled = True
        Me.edit_regie_signed_workers.ItemHeight = 20
        Me.edit_regie_signed_workers.Location = New System.Drawing.Point(592, 300)
        Me.edit_regie_signed_workers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_signed_workers.Name = "edit_regie_signed_workers"
        Me.edit_regie_signed_workers.Size = New System.Drawing.Size(353, 542)
        Me.edit_regie_signed_workers.TabIndex = 316
        '
        'edit_regie_save
        '
        Me.edit_regie_save.AutoSize = True
        Me.edit_regie_save.Enabled = False
        Me.edit_regie_save.Location = New System.Drawing.Point(1038, 765)
        Me.edit_regie_save.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.edit_regie_save.Name = "edit_regie_save"
        Me.edit_regie_save.Size = New System.Drawing.Size(57, 20)
        Me.edit_regie_save.TabIndex = 312
        Me.edit_regie_save.TabStop = True
        Me.edit_regie_save.Text = "Gravar"
        '
        'edit_regie_del
        '
        Me.edit_regie_del.AutoSize = True
        Me.edit_regie_del.Enabled = False
        Me.edit_regie_del.Location = New System.Drawing.Point(958, 765)
        Me.edit_regie_del.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.edit_regie_del.Name = "edit_regie_del"
        Me.edit_regie_del.Size = New System.Drawing.Size(61, 20)
        Me.edit_regie_del.TabIndex = 313
        Me.edit_regie_del.TabStop = True
        Me.edit_regie_del.Text = "Apagar"
        '
        'edit_regie_notes
        '
        Me.edit_regie_notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edit_regie_notes.Enabled = False
        Me.edit_regie_notes.Location = New System.Drawing.Point(958, 377)
        Me.edit_regie_notes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_notes.Multiline = True
        Me.edit_regie_notes.Name = "edit_regie_notes"
        Me.edit_regie_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.edit_regie_notes.Size = New System.Drawing.Size(689, 173)
        Me.edit_regie_notes.TabIndex = 314
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(9, 9)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(191, 29)
        Me.title.TabIndex = 315
        Me.title.Text = "Trabalho à régie"
        '
        'workersAssigned_lbl
        '
        Me.workersAssigned_lbl.AutoSize = True
        Me.workersAssigned_lbl.Location = New System.Drawing.Point(588, 275)
        Me.workersAssigned_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workersAssigned_lbl.Name = "workersAssigned_lbl"
        Me.workersAssigned_lbl.Size = New System.Drawing.Size(160, 20)
        Me.workersAssigned_lbl.TabIndex = 329
        Me.workersAssigned_lbl.Text = "Trabalhadores afetos"
        '
        'workersList_lbl
        '
        Me.workersList_lbl.AutoSize = True
        Me.workersList_lbl.Location = New System.Drawing.Point(9, 142)
        Me.workersList_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.workersList_lbl.Name = "workersList_lbl"
        Me.workersList_lbl.Size = New System.Drawing.Size(173, 20)
        Me.workersList_lbl.TabIndex = 330
        Me.workersList_lbl.Text = "Trabalhadores em obra"
        '
        'start_time_lbl
        '
        Me.start_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.start_time_lbl.Location = New System.Drawing.Point(995, 137)
        Me.start_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.start_time_lbl.Name = "start_time_lbl"
        Me.start_time_lbl.Size = New System.Drawing.Size(159, 25)
        Me.start_time_lbl.TabIndex = 332
        Me.start_time_lbl.Text = "Inicio"
        Me.start_time_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'end_time_lbl
        '
        Me.end_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.end_time_lbl.Location = New System.Drawing.Point(1260, 135)
        Me.end_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.end_time_lbl.Name = "end_time_lbl"
        Me.end_time_lbl.Size = New System.Drawing.Size(160, 23)
        Me.end_time_lbl.TabIndex = 333
        Me.end_time_lbl.Text = "Fim"
        Me.end_time_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(1522, 811)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(112, 40)
        Me.closeBtn.TabIndex = 334
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(525, 722)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(48, 38)
        Me.PictureBox2.TabIndex = 335
        Me.PictureBox2.TabStop = False
        '
        'edit_regie_enable_hours
        '
        Me.edit_regie_enable_hours.AutoSize = True
        Me.edit_regie_enable_hours.Location = New System.Drawing.Point(1530, 135)
        Me.edit_regie_enable_hours.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_enable_hours.Name = "edit_regie_enable_hours"
        Me.edit_regie_enable_hours.Size = New System.Drawing.Size(77, 24)
        Me.edit_regie_enable_hours.TabIndex = 336
        Me.edit_regie_enable_hours.Text = "Editar"
        Me.edit_regie_enable_hours.UseVisualStyleBackColor = True
        '
        'edit_regie_translate
        '
        Me.edit_regie_translate.AutoSize = True
        Me.edit_regie_translate.Enabled = False
        Me.edit_regie_translate.Location = New System.Drawing.Point(1552, 555)
        Me.edit_regie_translate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.edit_regie_translate.Name = "edit_regie_translate"
        Me.edit_regie_translate.Size = New System.Drawing.Size(66, 20)
        Me.edit_regie_translate.TabIndex = 337
        Me.edit_regie_translate.TabStop = True
        Me.edit_regie_translate.Text = "Traduzir"
        '
        'edit_regie_hora_inicio
        '
        Me.edit_regie_hora_inicio.CustomFormat = "HH:mm"
        Me.edit_regie_hora_inicio.Enabled = False
        Me.edit_regie_hora_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.edit_regie_hora_inicio.Location = New System.Drawing.Point(1155, 132)
        Me.edit_regie_hora_inicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_hora_inicio.Name = "edit_regie_hora_inicio"
        Me.edit_regie_hora_inicio.ShowUpDown = True
        Me.edit_regie_hora_inicio.Size = New System.Drawing.Size(96, 26)
        Me.edit_regie_hora_inicio.TabIndex = 359
        Me.edit_regie_hora_inicio.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'edit_regie_hora_fim
        '
        Me.edit_regie_hora_fim.CustomFormat = "HH:mm"
        Me.edit_regie_hora_fim.Enabled = False
        Me.edit_regie_hora_fim.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.edit_regie_hora_fim.Location = New System.Drawing.Point(1424, 131)
        Me.edit_regie_hora_fim.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_hora_fim.Name = "edit_regie_hora_fim"
        Me.edit_regie_hora_fim.ShowUpDown = True
        Me.edit_regie_hora_fim.Size = New System.Drawing.Size(96, 26)
        Me.edit_regie_hora_fim.TabIndex = 360
        Me.edit_regie_hora_fim.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.edit_regie_notes_previous)
        Me.Panel1.Controls.Add(Me.photobox)
        Me.Panel1.Controls.Add(Me.resetLink)
        Me.Panel1.Controls.Add(Me.validation_reason)
        Me.Panel1.Controls.Add(Me.validation_reason_lbl)
        Me.Panel1.Controls.Add(Me.validation_duration)
        Me.Panel1.Controls.Add(Me.validation_time_lbl)
        Me.Panel1.Controls.Add(Me.validate_record)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.edit_regie_hora_fim)
        Me.Panel1.Controls.Add(Me.edit_regie_notes)
        Me.Panel1.Controls.Add(Me.edit_regie_hora_inicio)
        Me.Panel1.Controls.Add(Me.edit_regie_del)
        Me.Panel1.Controls.Add(Me.edit_regie_translate)
        Me.Panel1.Controls.Add(Me.edit_regie_save)
        Me.Panel1.Controls.Add(Me.edit_regie_enable_hours)
        Me.Panel1.Controls.Add(Me.edit_regie_signed_workers)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.edit_regie_duration_lbl)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.annotations_lbl)
        Me.Panel1.Controls.Add(Me.end_time_lbl)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.start_time_lbl)
        Me.Panel1.Controls.Add(Me.workersList_lbl)
        Me.Panel1.Controls.Add(Me.edit_regie_available_workers)
        Me.Panel1.Controls.Add(Me.workersAssigned_lbl)
        Me.Panel1.Controls.Add(Me.edit_regie_searchbox)
        Me.Panel1.Controls.Add(Me.edit_regie_date)
        Me.Panel1.Controls.Add(Me.search_lbl)
        Me.Panel1.Controls.Add(Me.date_lbl)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1658, 871)
        Me.Panel1.TabIndex = 361
        Me.Panel1.Visible = False
        '
        'edit_regie_notes_previous
        '
        Me.edit_regie_notes_previous.BackColor = System.Drawing.SystemColors.Control
        Me.edit_regie_notes_previous.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edit_regie_notes_previous.Enabled = False
        Me.edit_regie_notes_previous.Location = New System.Drawing.Point(958, 194)
        Me.edit_regie_notes_previous.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.edit_regie_notes_previous.Multiline = True
        Me.edit_regie_notes_previous.Name = "edit_regie_notes_previous"
        Me.edit_regie_notes_previous.ReadOnly = True
        Me.edit_regie_notes_previous.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.edit_regie_notes_previous.Size = New System.Drawing.Size(689, 173)
        Me.edit_regie_notes_previous.TabIndex = 368
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.InitialImage = Nothing
        Me.photobox.Location = New System.Drawing.Point(654, 68)
        Me.photobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(170, 176)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 367
        Me.photobox.TabStop = False
        '
        'resetLink
        '
        Me.resetLink.AutoSize = True
        Me.resetLink.Location = New System.Drawing.Point(951, 128)
        Me.resetLink.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.resetLink.Name = "resetLink"
        Me.resetLink.Size = New System.Drawing.Size(52, 20)
        Me.resetLink.TabIndex = 366
        Me.resetLink.TabStop = True
        Me.resetLink.Text = "Reset"
        '
        'validation_reason
        '
        Me.validation_reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.validation_reason.Enabled = False
        Me.validation_reason.Location = New System.Drawing.Point(958, 635)
        Me.validation_reason.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.validation_reason.Multiline = True
        Me.validation_reason.Name = "validation_reason"
        Me.validation_reason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.validation_reason.Size = New System.Drawing.Size(689, 124)
        Me.validation_reason.TabIndex = 364
        '
        'validation_reason_lbl
        '
        Me.validation_reason_lbl.AutoSize = True
        Me.validation_reason_lbl.Location = New System.Drawing.Point(958, 606)
        Me.validation_reason_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.validation_reason_lbl.Name = "validation_reason_lbl"
        Me.validation_reason_lbl.Size = New System.Drawing.Size(102, 20)
        Me.validation_reason_lbl.TabIndex = 365
        Me.validation_reason_lbl.Text = "Justidficação"
        '
        'validation_duration
        '
        Me.validation_duration.CustomFormat = "HH:mm"
        Me.validation_duration.Enabled = False
        Me.validation_duration.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.validation_duration.Location = New System.Drawing.Point(1522, 595)
        Me.validation_duration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.validation_duration.Name = "validation_duration"
        Me.validation_duration.ShowUpDown = True
        Me.validation_duration.Size = New System.Drawing.Size(96, 26)
        Me.validation_duration.TabIndex = 363
        Me.validation_duration.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'validation_time_lbl
        '
        Me.validation_time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.validation_time_lbl.Location = New System.Drawing.Point(1260, 595)
        Me.validation_time_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.validation_time_lbl.Name = "validation_time_lbl"
        Me.validation_time_lbl.Size = New System.Drawing.Size(255, 31)
        Me.validation_time_lbl.TabIndex = 362
        Me.validation_time_lbl.Text = "Duração"
        Me.validation_time_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'validate_record
        '
        Me.validate_record.AutoSize = True
        Me.validate_record.Location = New System.Drawing.Point(958, 575)
        Me.validate_record.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.validate_record.Name = "validate_record"
        Me.validate_record.Size = New System.Drawing.Size(136, 24)
        Me.validate_record.TabIndex = 361
        Me.validate_record.Text = "Validar registo"
        Me.validate_record.UseVisualStyleBackColor = True
        '
        'siteRegieEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1658, 871)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "siteRegieEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar marcações à régie"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents edit_regie_date As DateTimePicker
    Friend WithEvents date_lbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents search_lbl As Label
    Friend WithEvents edit_regie_searchbox As TextBox
    Friend WithEvents edit_regie_available_workers As ListBox
    Friend WithEvents divider As Label
    Friend WithEvents annotations_lbl As Label
    Friend WithEvents edit_regie_duration_lbl As Label
    Friend WithEvents edit_regie_signed_workers As ListBox
    Friend WithEvents edit_regie_save As LinkLabel
    Friend WithEvents edit_regie_del As LinkLabel
    Friend WithEvents edit_regie_notes As TextBox
    Friend WithEvents title As Label
    Friend WithEvents workersAssigned_lbl As Label
    Friend WithEvents workersList_lbl As Label
    Friend WithEvents start_time_lbl As Label
    Friend WithEvents end_time_lbl As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents edit_regie_enable_hours As CheckBox
    Friend WithEvents edit_regie_translate As LinkLabel
    Friend WithEvents edit_regie_hora_inicio As DateTimePicker
    Friend WithEvents edit_regie_hora_fim As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents validation_reason As TextBox
    Friend WithEvents validation_reason_lbl As Label
    Friend WithEvents validation_duration As DateTimePicker
    Friend WithEvents validation_time_lbl As Label
    Friend WithEvents validate_record As CheckBox
    Friend WithEvents resetLink As LinkLabel
    Friend WithEvents photobox As PictureBox
    Friend WithEvents edit_regie_notes_previous As TextBox
End Class
