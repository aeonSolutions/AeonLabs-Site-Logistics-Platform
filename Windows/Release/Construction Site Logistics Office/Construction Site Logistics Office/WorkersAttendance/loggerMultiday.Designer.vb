<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class multiday_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(multiday_frm))
        Me.startdate_lbl = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.divider2 = New System.Windows.Forms.Label()
        Me.absense_time = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.checkbox_logs_only = New System.Windows.Forms.CheckBox()
        Me.CheckBox_c = New System.Windows.Forms.CheckBox()
        Me.CheckBox_a = New System.Windows.Forms.CheckBox()
        Me.checkbox_v = New System.Windows.Forms.CheckBox()
        Me.checkbox_i = New System.Windows.Forms.CheckBox()
        Me.CheckBox_p = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ah = New System.Windows.Forms.CheckBox()
        Me.hora_lbl = New System.Windows.Forms.Label()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.groupBoxMotif = New System.Windows.Forms.GroupBox()
        Me.motif = New System.Windows.Forms.TextBox()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.groupBoxMotif.SuspendLayout()
        Me.SuspendLayout()
        '
        'startdate_lbl
        '
        Me.startdate_lbl.AutoSize = True
        Me.startdate_lbl.Location = New System.Drawing.Point(193, 54)
        Me.startdate_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.startdate_lbl.Name = "startdate_lbl"
        Me.startdate_lbl.Size = New System.Drawing.Size(154, 17)
        Me.startdate_lbl.TabIndex = 0
        Me.startdate_lbl.Text = "Data inicio: 01/01/1990"
        Me.startdate_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.divider2)
        Me.GroupBox1.Controls.Add(Me.absense_time)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.checkbox_logs_only)
        Me.GroupBox1.Controls.Add(Me.CheckBox_c)
        Me.GroupBox1.Controls.Add(Me.CheckBox_a)
        Me.GroupBox1.Controls.Add(Me.checkbox_v)
        Me.GroupBox1.Controls.Add(Me.checkbox_i)
        Me.GroupBox1.Controls.Add(Me.CheckBox_p)
        Me.GroupBox1.Controls.Add(Me.CheckBox_ah)
        Me.GroupBox1.Controls.Add(Me.hora_lbl)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 79)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(529, 236)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Validar Presença"
        '
        'divider2
        '
        Me.divider2.BackColor = System.Drawing.Color.LimeGreen
        Me.divider2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider2.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider2.Location = New System.Drawing.Point(8, 161)
        Me.divider2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider2.Name = "divider2"
        Me.divider2.Size = New System.Drawing.Size(511, 2)
        Me.divider2.TabIndex = 363
        '
        'absense_time
        '
        Me.absense_time.CustomFormat = "HH:mm"
        Me.absense_time.Enabled = False
        Me.absense_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.absense_time.Location = New System.Drawing.Point(44, 116)
        Me.absense_time.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.absense_time.Name = "absense_time"
        Me.absense_time.ShowUpDown = True
        Me.absense_time.Size = New System.Drawing.Size(85, 22)
        Me.absense_time.TabIndex = 362
        Me.absense_time.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(13, 170)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(53, 48)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 196
        Me.PictureBox2.TabStop = False
        '
        'checkbox_logs_only
        '
        Me.checkbox_logs_only.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_logs_only.Location = New System.Drawing.Point(75, 170)
        Me.checkbox_logs_only.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.checkbox_logs_only.Name = "checkbox_logs_only"
        Me.checkbox_logs_only.Size = New System.Drawing.Size(444, 48)
        Me.checkbox_logs_only.TabIndex = 195
        Me.checkbox_logs_only.Text = "Apenas os trabalhadores com registo de presença em obra"
        Me.checkbox_logs_only.UseVisualStyleBackColor = True
        '
        'CheckBox_c
        '
        Me.CheckBox_c.AutoSize = True
        Me.CheckBox_c.Location = New System.Drawing.Point(301, 38)
        Me.CheckBox_c.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox_c.Name = "CheckBox_c"
        Me.CheckBox_c.Size = New System.Drawing.Size(74, 21)
        Me.CheckBox_c.TabIndex = 10
        Me.CheckBox_c.Text = "feriado"
        Me.CheckBox_c.UseVisualStyleBackColor = True
        '
        'CheckBox_a
        '
        Me.CheckBox_a.AutoSize = True
        Me.CheckBox_a.Location = New System.Drawing.Point(12, 66)
        Me.CheckBox_a.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox_a.Name = "CheckBox_a"
        Me.CheckBox_a.Size = New System.Drawing.Size(134, 21)
        Me.CheckBox_a.TabIndex = 9
        Me.CheckBox_a.Text = "Faltou (dia todo)"
        Me.CheckBox_a.UseVisualStyleBackColor = True
        '
        'checkbox_v
        '
        Me.checkbox_v.AutoSize = True
        Me.checkbox_v.Location = New System.Drawing.Point(301, 66)
        Me.checkbox_v.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.checkbox_v.Name = "checkbox_v"
        Me.checkbox_v.Size = New System.Drawing.Size(65, 21)
        Me.checkbox_v.TabIndex = 8
        Me.checkbox_v.Text = "férias"
        Me.checkbox_v.UseVisualStyleBackColor = True
        '
        'checkbox_i
        '
        Me.checkbox_i.AutoSize = True
        Me.checkbox_i.Location = New System.Drawing.Point(301, 95)
        Me.checkbox_i.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.checkbox_i.Name = "checkbox_i"
        Me.checkbox_i.Size = New System.Drawing.Size(100, 21)
        Me.checkbox_i.TabIndex = 7
        Me.checkbox_i.Text = "mau tempo"
        Me.checkbox_i.UseVisualStyleBackColor = True
        '
        'CheckBox_p
        '
        Me.CheckBox_p.AutoSize = True
        Me.CheckBox_p.Location = New System.Drawing.Point(13, 38)
        Me.CheckBox_p.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox_p.Name = "CheckBox_p"
        Me.CheckBox_p.Size = New System.Drawing.Size(112, 21)
        Me.CheckBox_p.TabIndex = 6
        Me.CheckBox_p.Text = "Dia completo"
        Me.CheckBox_p.UseVisualStyleBackColor = True
        '
        'CheckBox_ah
        '
        Me.CheckBox_ah.AutoSize = True
        Me.CheckBox_ah.Location = New System.Drawing.Point(12, 95)
        Me.CheckBox_ah.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox_ah.Name = "CheckBox_ah"
        Me.CheckBox_ah.Size = New System.Drawing.Size(69, 21)
        Me.CheckBox_ah.TabIndex = 4
        Me.CheckBox_ah.Text = "Faltou"
        Me.CheckBox_ah.UseVisualStyleBackColor = True
        '
        'hora_lbl
        '
        Me.hora_lbl.AutoSize = True
        Me.hora_lbl.Location = New System.Drawing.Point(139, 121)
        Me.hora_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.hora_lbl.Name = "hora_lbl"
        Me.hora_lbl.Size = New System.Drawing.Size(47, 17)
        Me.hora_lbl.TabIndex = 2
        Me.hora_lbl.Text = "h hoje"
        '
        'saveBtn
        '
        Me.saveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveBtn.ForeColor = System.Drawing.Color.White
        Me.saveBtn.Location = New System.Drawing.Point(15, 464)
        Me.saveBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(115, 32)
        Me.saveBtn.TabIndex = 340
        Me.saveBtn.Text = "Gravar"
        Me.saveBtn.UseVisualStyleBackColor = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(429, 464)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(115, 32)
        Me.closeBtn.TabIndex = 339
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.groupBoxMotif)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.startdate_lbl)
        Me.Panel1.Controls.Add(Me.saveBtn)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 513)
        Me.Panel1.TabIndex = 341
        '
        'groupBoxMotif
        '
        Me.groupBoxMotif.Controls.Add(Me.motif)
        Me.groupBoxMotif.Enabled = False
        Me.groupBoxMotif.Location = New System.Drawing.Point(15, 322)
        Me.groupBoxMotif.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBoxMotif.Name = "groupBoxMotif"
        Me.groupBoxMotif.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBoxMotif.Size = New System.Drawing.Size(529, 134)
        Me.groupBoxMotif.TabIndex = 350
        Me.groupBoxMotif.TabStop = False
        Me.groupBoxMotif.Text = "Justificação"
        '
        'motif
        '
        Me.motif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.motif.Location = New System.Drawing.Point(12, 23)
        Me.motif.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.motif.Multiline = True
        Me.motif.Name = "motif"
        Me.motif.Size = New System.Drawing.Size(509, 103)
        Me.motif.TabIndex = 0
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(15, 36)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(534, 4)
        Me.divider.TabIndex = 342
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(9, 11)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(170, 25)
        Me.title.TabIndex = 341
        Me.title.Text = "Validação multipla"
        '
        'multiday_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 513)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "multiday_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Validação vários dias"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupBoxMotif.ResumeLayout(False)
        Me.groupBoxMotif.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents startdate_lbl As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox_c As CheckBox
    Friend WithEvents CheckBox_a As CheckBox
    Friend WithEvents checkbox_v As CheckBox
    Friend WithEvents checkbox_i As CheckBox
    Friend WithEvents CheckBox_p As CheckBox
    Friend WithEvents CheckBox_ah As CheckBox
    Friend WithEvents hora_lbl As Label
    Friend WithEvents saveBtn As Button
    Friend WithEvents closeBtn As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents checkbox_logs_only As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents absense_time As DateTimePicker
    Friend WithEvents groupBoxMotif As GroupBox
    Friend WithEvents motif As TextBox
    Friend WithEvents divider2 As Label
End Class
