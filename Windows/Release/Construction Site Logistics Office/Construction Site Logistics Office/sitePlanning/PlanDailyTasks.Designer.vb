<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlanDailyTasks_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlanDailyTasks_frm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tasks_datatable = New System.Windows.Forms.DataGridView()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.duration_group = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.custom = New System.Windows.Forms.CheckBox()
        Me.evening = New System.Windows.Forms.CheckBox()
        Me.night = New System.Windows.Forms.CheckBox()
        Me.afternoon = New System.Windows.Forms.CheckBox()
        Me.morning = New System.Windows.Forms.CheckBox()
        Me.all_day = New System.Windows.Forms.CheckBox()
        Me.auto_medicao_tasks_group = New System.Windows.Forms.GroupBox()
        Me.tasks_list = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.worker_photo = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.autoMedicaoSetCurrentMonth = New System.Windows.Forms.LinkLabel()
        Me.site_list = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.section = New System.Windows.Forms.ComboBox()
        Me.data = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.tasks_datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.duration_group.SuspendLayout()
        Me.auto_medicao_tasks_group.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.Label62)
        Me.Panel1.Controls.Add(Me.Label60)
        Me.Panel1.Controls.Add(Me.Label59)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.duration_group)
        Me.Panel1.Controls.Add(Me.auto_medicao_tasks_group)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox8)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1706, 927)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 18)
        Me.Label5.TabIndex = 383
        Me.Label5.Text = "Equipas de Trabalho"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LimeGreen
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label8.Location = New System.Drawing.Point(5, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(950, 4)
        Me.Label8.TabIndex = 384
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tasks_datatable)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 265)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(596, 602)
        Me.GroupBox4.TabIndex = 378
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tarefas"
        '
        'tasks_datatable
        '
        Me.tasks_datatable.AllowUserToAddRows = False
        Me.tasks_datatable.AllowUserToDeleteRows = False
        Me.tasks_datatable.BackgroundColor = System.Drawing.Color.White
        Me.tasks_datatable.CausesValidation = False
        Me.tasks_datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tasks_datatable.DefaultCellStyle = DataGridViewCellStyle1
        Me.tasks_datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.tasks_datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tasks_datatable.Location = New System.Drawing.Point(6, 16)
        Me.tasks_datatable.MultiSelect = False
        Me.tasks_datatable.Name = "tasks_datatable"
        Me.tasks_datatable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tasks_datatable.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tasks_datatable.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.tasks_datatable.Size = New System.Drawing.Size(584, 580)
        Me.tasks_datatable.TabIndex = 364
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(774, 246)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(186, 13)
        Me.Label62.TabIndex = 382
        Me.Label62.Text = "campos com * são obrigatórios"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(12, 222)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(157, 18)
        Me.Label60.TabIndex = 380
        Me.Label60.Text = "Tarefas a Realizar"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.LimeGreen
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label59.Location = New System.Drawing.Point(10, 242)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(950, 4)
        Me.Label59.TabIndex = 381
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListBox1)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(608, 497)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(896, 183)
        Me.GroupBox3.TabIndex = 379
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Outras tarefas"
        '
        'ListBox1
        '
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(884, 160)
        Me.ListBox1.TabIndex = 350
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button5)
        Me.GroupBox5.Controls.Add(Me.Button4)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(608, 688)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(896, 181)
        Me.GroupBox5.TabIndex = 377
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Descrição dos trabalhos"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Silver
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(6, 49)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 23)
        Me.Button5.TabIndex = 361
        Me.Button5.Text = "Execução"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Silver
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(6, 78)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 23)
        Me.Button4.TabIndex = 360
        Me.Button4.Text = "Terminar"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(6, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 23)
        Me.Button2.TabIndex = 359
        Me.Button2.Text = "Preparação"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(98, 20)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(792, 155)
        Me.TextBox1.TabIndex = 15
        '
        'duration_group
        '
        Me.duration_group.Controls.Add(Me.DateTimePicker2)
        Me.duration_group.Controls.Add(Me.DateTimePicker1)
        Me.duration_group.Controls.Add(Me.Label4)
        Me.duration_group.Controls.Add(Me.Label3)
        Me.duration_group.Controls.Add(Me.Label2)
        Me.duration_group.Controls.Add(Me.Label6)
        Me.duration_group.Controls.Add(Me.custom)
        Me.duration_group.Controls.Add(Me.evening)
        Me.duration_group.Controls.Add(Me.night)
        Me.duration_group.Controls.Add(Me.afternoon)
        Me.duration_group.Controls.Add(Me.morning)
        Me.duration_group.Controls.Add(Me.all_day)
        Me.duration_group.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duration_group.Location = New System.Drawing.Point(1510, 265)
        Me.duration_group.Name = "duration_group"
        Me.duration_group.Size = New System.Drawing.Size(184, 602)
        Me.duration_group.TabIndex = 376
        Me.duration_group.TabStop = False
        Me.duration_group.Text = "Duração"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "HH:mm"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker2.Location = New System.Drawing.Point(65, 67)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.ShowUpDown = True
        Me.DateTimePicker2.Size = New System.Drawing.Size(65, 21)
        Me.DateTimePicker2.TabIndex = 22
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "HH:mm"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(65, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(65, 21)
        Me.DateTimePicker1.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "h"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(136, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "h"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Fim"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Inicio"
        '
        'custom
        '
        Me.custom.AutoSize = True
        Me.custom.Location = New System.Drawing.Point(6, 20)
        Me.custom.Name = "custom"
        Me.custom.Size = New System.Drawing.Size(118, 17)
        Me.custom.TabIndex = 13
        Me.custom.Text = "Definir intervalo"
        Me.custom.UseVisualStyleBackColor = True
        '
        'evening
        '
        Me.evening.AutoSize = True
        Me.evening.Location = New System.Drawing.Point(6, 191)
        Me.evening.Name = "evening"
        Me.evening.Size = New System.Drawing.Size(157, 17)
        Me.evening.TabIndex = 12
        Me.evening.Text = "Anoitecer (17h ás 00h)"
        Me.evening.UseVisualStyleBackColor = True
        '
        'night
        '
        Me.night.AutoSize = True
        Me.night.Location = New System.Drawing.Point(6, 217)
        Me.night.Name = "night"
        Me.night.Size = New System.Drawing.Size(134, 17)
        Me.night.TabIndex = 11
        Me.night.Text = "Noturno (0h ás 8h)"
        Me.night.UseVisualStyleBackColor = True
        '
        'afternoon
        '
        Me.afternoon.AutoSize = True
        Me.afternoon.Location = New System.Drawing.Point(6, 136)
        Me.afternoon.Name = "afternoon"
        Me.afternoon.Size = New System.Drawing.Size(135, 17)
        Me.afternoon.TabIndex = 10
        Me.afternoon.Text = "Tarde (13h ás 17h)"
        Me.afternoon.UseVisualStyleBackColor = True
        '
        'morning
        '
        Me.morning.AutoSize = True
        Me.morning.Location = New System.Drawing.Point(6, 159)
        Me.morning.Name = "morning"
        Me.morning.Size = New System.Drawing.Size(133, 17)
        Me.morning.TabIndex = 9
        Me.morning.Text = "Manhã (9h ás 12h)"
        Me.morning.UseVisualStyleBackColor = True
        '
        'all_day
        '
        Me.all_day.AutoSize = True
        Me.all_day.Checked = True
        Me.all_day.CheckState = System.Windows.Forms.CheckState.Checked
        Me.all_day.Location = New System.Drawing.Point(6, 113)
        Me.all_day.Name = "all_day"
        Me.all_day.Size = New System.Drawing.Size(155, 17)
        Me.all_day.TabIndex = 8
        Me.all_day.Text = "Todo o dia (9h ás 17h)"
        Me.all_day.UseVisualStyleBackColor = True
        '
        'auto_medicao_tasks_group
        '
        Me.auto_medicao_tasks_group.Controls.Add(Me.tasks_list)
        Me.auto_medicao_tasks_group.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auto_medicao_tasks_group.Location = New System.Drawing.Point(608, 265)
        Me.auto_medicao_tasks_group.Name = "auto_medicao_tasks_group"
        Me.auto_medicao_tasks_group.Size = New System.Drawing.Size(896, 226)
        Me.auto_medicao_tasks_group.TabIndex = 375
        Me.auto_medicao_tasks_group.TabStop = False
        Me.auto_medicao_tasks_group.Text = "Mapa de tarefas"
        '
        'tasks_list
        '
        Me.tasks_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tasks_list.FormattingEnabled = True
        Me.tasks_list.HorizontalScrollbar = True
        Me.tasks_list.Location = New System.Drawing.Point(6, 19)
        Me.tasks_list.Name = "tasks_list"
        Me.tasks_list.Size = New System.Drawing.Size(884, 199)
        Me.tasks_list.TabIndex = 350
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.listview_works)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(335, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1365, 168)
        Me.GroupBox1.TabIndex = 374
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Equipas"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.worker_photo)
        Me.Panel2.Location = New System.Drawing.Point(385, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(974, 141)
        Me.Panel2.TabIndex = 361
        '
        'worker_photo
        '
        Me.worker_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.worker_photo.InitialImage = Nothing
        Me.worker_photo.Location = New System.Drawing.Point(16, 15)
        Me.worker_photo.Name = "worker_photo"
        Me.worker_photo.Size = New System.Drawing.Size(111, 109)
        Me.worker_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.worker_photo.TabIndex = 357
        Me.worker_photo.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 144)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(63, 13)
        Me.LinkLabel1.TabIndex = 360
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Actualizar"
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(6, 20)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(373, 121)
        Me.listview_works.TabIndex = 306
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(316, 144)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(60, 13)
        Me.LinkLabel2.TabIndex = 305
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Adicionar"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.autoMedicaoSetCurrentMonth)
        Me.GroupBox8.Controls.Add(Me.site_list)
        Me.GroupBox8.Controls.Add(Me.PictureBox1)
        Me.GroupBox8.Controls.Add(Me.section)
        Me.GroupBox8.Controls.Add(Me.data)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(317, 168)
        Me.GroupBox8.TabIndex = 373
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Obra"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 322
        Me.Label7.Text = "Data"
        '
        'autoMedicaoSetCurrentMonth
        '
        Me.autoMedicaoSetCurrentMonth.AutoSize = True
        Me.autoMedicaoSetCurrentMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.autoMedicaoSetCurrentMonth.Location = New System.Drawing.Point(143, 128)
        Me.autoMedicaoSetCurrentMonth.Name = "autoMedicaoSetCurrentMonth"
        Me.autoMedicaoSetCurrentMonth.Size = New System.Drawing.Size(68, 13)
        Me.autoMedicaoSetCurrentMonth.TabIndex = 319
        Me.autoMedicaoSetCurrentMonth.TabStop = True
        Me.autoMedicaoSetCurrentMonth.Text = "mês corrente"
        '
        'site_list
        '
        Me.site_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.site_list.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_list.FormattingEnabled = True
        Me.site_list.Location = New System.Drawing.Point(6, 16)
        Me.site_list.Name = "site_list"
        Me.site_list.Size = New System.Drawing.Size(300, 21)
        Me.site_list.TabIndex = 309
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(217, 103)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 321
        Me.PictureBox1.TabStop = False
        '
        'section
        '
        Me.section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.section.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.section.FormattingEnabled = True
        Me.section.Items.AddRange(New Object() {"Gestionnaire", "Conducteur"})
        Me.section.Location = New System.Drawing.Point(9, 60)
        Me.section.Name = "section"
        Me.section.Size = New System.Drawing.Size(189, 21)
        Me.section.TabIndex = 319
        '
        'data
        '
        Me.data.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data.Location = New System.Drawing.Point(9, 103)
        Me.data.Name = "data"
        Me.data.Size = New System.Drawing.Size(202, 22)
        Me.data.TabIndex = 282
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 320
        Me.Label1.Text = "Secção"
        '
        'PlanDailyTasks_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1718, 802)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PlanDailyTasks_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Planeamento de tarefas diarias"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.tasks_datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.duration_group.ResumeLayout(False)
        Me.duration_group.PerformLayout()
        Me.auto_medicao_tasks_group.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tasks_datatable As DataGridView
    Friend WithEvents Label62 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents duration_group As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents custom As CheckBox
    Friend WithEvents evening As CheckBox
    Friend WithEvents night As CheckBox
    Friend WithEvents afternoon As CheckBox
    Friend WithEvents morning As CheckBox
    Friend WithEvents all_day As CheckBox
    Friend WithEvents auto_medicao_tasks_group As GroupBox
    Friend WithEvents tasks_list As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents worker_photo As PictureBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents autoMedicaoSetCurrentMonth As LinkLabel
    Friend WithEvents site_list As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents section As ComboBox
    Friend WithEvents data As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
End Class
