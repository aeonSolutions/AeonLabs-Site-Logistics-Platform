<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class logday_frm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.groupBoxMotif = New System.Windows.Forms.GroupBox()
        Me.motif = New System.Windows.Forms.TextBox()
        Me.groupbox_gruista = New System.Windows.Forms.GroupBox()
        Me.gruista_time = New System.Windows.Forms.DateTimePicker()
        Me.hora_lbl2 = New System.Windows.Forms.Label()
        Me.checkbox_gruista_fullday = New System.Windows.Forms.CheckBox()
        Me.checkbox_gruista_on_grua = New System.Windows.Forms.CheckBox()
        Me.checkbox_gruista_parcial = New System.Windows.Forms.CheckBox()
        Me.worker_photo = New System.Windows.Forms.PictureBox()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.worker_lbl = New System.Windows.Forms.Label()
        Me.groupbox_validation = New System.Windows.Forms.GroupBox()
        Me.absense_time = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox_cleanCheckout = New System.Windows.Forms.CheckBox()
        Me.CheckBox_m = New System.Windows.Forms.CheckBox()
        Me.CheckBox_a = New System.Windows.Forms.CheckBox()
        Me.CheckBox_v = New System.Windows.Forms.CheckBox()
        Me.CheckBox_p = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ah = New System.Windows.Forms.CheckBox()
        Me.hora_lbl1 = New System.Windows.Forms.Label()
        Me.groupbox_record = New System.Windows.Forms.GroupBox()
        Me.data_lbl = New System.Windows.Forms.Label()
        Me.time_lbl = New System.Windows.Forms.Label()
        Me.checkout_lbl = New System.Windows.Forms.Label()
        Me.checkin_lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.groupBoxMotif.SuspendLayout()
        Me.groupbox_gruista.SuspendLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupbox_validation.SuspendLayout()
        Me.groupbox_record.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.groupBoxMotif)
        Me.Panel1.Controls.Add(Me.groupbox_gruista)
        Me.Panel1.Controls.Add(Me.worker_photo)
        Me.Panel1.Controls.Add(Me.saveBtn)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.worker_lbl)
        Me.Panel1.Controls.Add(Me.groupbox_validation)
        Me.Panel1.Controls.Add(Me.groupbox_record)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(692, 406)
        Me.Panel1.TabIndex = 0
        '
        'groupBoxMotif
        '
        Me.groupBoxMotif.Controls.Add(Me.motif)
        Me.groupBoxMotif.Enabled = False
        Me.groupBoxMotif.Location = New System.Drawing.Point(10, 252)
        Me.groupBoxMotif.Name = "groupBoxMotif"
        Me.groupBoxMotif.Size = New System.Drawing.Size(668, 109)
        Me.groupBoxMotif.TabIndex = 349
        Me.groupBoxMotif.TabStop = False
        Me.groupBoxMotif.Text = "Justificação"
        '
        'motif
        '
        Me.motif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.motif.Location = New System.Drawing.Point(9, 19)
        Me.motif.Multiline = True
        Me.motif.Name = "motif"
        Me.motif.Size = New System.Drawing.Size(653, 84)
        Me.motif.TabIndex = 0
        '
        'groupbox_gruista
        '
        Me.groupbox_gruista.Controls.Add(Me.gruista_time)
        Me.groupbox_gruista.Controls.Add(Me.hora_lbl2)
        Me.groupbox_gruista.Controls.Add(Me.checkbox_gruista_fullday)
        Me.groupbox_gruista.Controls.Add(Me.checkbox_gruista_on_grua)
        Me.groupbox_gruista.Controls.Add(Me.checkbox_gruista_parcial)
        Me.groupbox_gruista.Enabled = False
        Me.groupbox_gruista.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupbox_gruista.Location = New System.Drawing.Point(392, 133)
        Me.groupbox_gruista.Name = "groupbox_gruista"
        Me.groupbox_gruista.Size = New System.Drawing.Size(290, 113)
        Me.groupbox_gruista.TabIndex = 348
        Me.groupbox_gruista.TabStop = False
        Me.groupbox_gruista.Text = "Gruista"
        '
        'gruista_time
        '
        Me.gruista_time.CustomFormat = "HH:mm"
        Me.gruista_time.Enabled = False
        Me.gruista_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.gruista_time.Location = New System.Drawing.Point(63, 82)
        Me.gruista_time.Name = "gruista_time"
        Me.gruista_time.ShowUpDown = True
        Me.gruista_time.Size = New System.Drawing.Size(65, 21)
        Me.gruista_time.TabIndex = 363
        Me.gruista_time.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'hora_lbl2
        '
        Me.hora_lbl2.AutoSize = True
        Me.hora_lbl2.Enabled = False
        Me.hora_lbl2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hora_lbl2.Location = New System.Drawing.Point(128, 86)
        Me.hora_lbl2.Name = "hora_lbl2"
        Me.hora_lbl2.Size = New System.Drawing.Size(39, 13)
        Me.hora_lbl2.TabIndex = 362
        Me.hora_lbl2.Text = "horas"
        '
        'checkbox_gruista_fullday
        '
        Me.checkbox_gruista_fullday.AutoSize = True
        Me.checkbox_gruista_fullday.Enabled = False
        Me.checkbox_gruista_fullday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_gruista_fullday.Location = New System.Drawing.Point(43, 43)
        Me.checkbox_gruista_fullday.Name = "checkbox_gruista_fullday"
        Me.checkbox_gruista_fullday.Size = New System.Drawing.Size(101, 17)
        Me.checkbox_gruista_fullday.TabIndex = 7
        Me.checkbox_gruista_fullday.Text = "Dia completo"
        Me.checkbox_gruista_fullday.UseVisualStyleBackColor = True
        '
        'checkbox_gruista_on_grua
        '
        Me.checkbox_gruista_on_grua.AutoSize = True
        Me.checkbox_gruista_on_grua.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_gruista_on_grua.Location = New System.Drawing.Point(10, 20)
        Me.checkbox_gruista_on_grua.Name = "checkbox_gruista_on_grua"
        Me.checkbox_gruista_on_grua.Size = New System.Drawing.Size(245, 17)
        Me.checkbox_gruista_on_grua.TabIndex = 6
        Me.checkbox_gruista_on_grua.Text = "Esteve a operar na grua durante o dia"
        Me.checkbox_gruista_on_grua.UseVisualStyleBackColor = True
        '
        'checkbox_gruista_parcial
        '
        Me.checkbox_gruista_parcial.AutoSize = True
        Me.checkbox_gruista_parcial.Enabled = False
        Me.checkbox_gruista_parcial.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkbox_gruista_parcial.Location = New System.Drawing.Point(43, 65)
        Me.checkbox_gruista_parcial.Name = "checkbox_gruista_parcial"
        Me.checkbox_gruista_parcial.Size = New System.Drawing.Size(127, 17)
        Me.checkbox_gruista_parcial.TabIndex = 4
        Me.checkbox_gruista_parcial.Text = "Trabalhou apenas"
        Me.checkbox_gruista_parcial.UseVisualStyleBackColor = True
        '
        'worker_photo
        '
        Me.worker_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.worker_photo.InitialImage = Nothing
        Me.worker_photo.Location = New System.Drawing.Point(10, 9)
        Me.worker_photo.Name = "worker_photo"
        Me.worker_photo.Size = New System.Drawing.Size(111, 109)
        Me.worker_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.worker_photo.TabIndex = 347
        Me.worker_photo.TabStop = False
        '
        'saveBtn
        '
        Me.saveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveBtn.ForeColor = System.Drawing.Color.White
        Me.saveBtn.Location = New System.Drawing.Point(11, 367)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(86, 26)
        Me.saveBtn.TabIndex = 346
        Me.saveBtn.Text = "Gravar"
        Me.saveBtn.UseVisualStyleBackColor = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(596, 367)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 345
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'worker_lbl
        '
        Me.worker_lbl.AutoSize = True
        Me.worker_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_lbl.Location = New System.Drawing.Point(127, 9)
        Me.worker_lbl.Name = "worker_lbl"
        Me.worker_lbl.Size = New System.Drawing.Size(181, 13)
        Me.worker_lbl.TabIndex = 344
        Me.worker_lbl.Text = "Miguel Tomas Pinto e Silva"
        '
        'groupbox_validation
        '
        Me.groupbox_validation.Controls.Add(Me.absense_time)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_cleanCheckout)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_m)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_a)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_v)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_p)
        Me.groupbox_validation.Controls.Add(Me.CheckBox_ah)
        Me.groupbox_validation.Controls.Add(Me.hora_lbl1)
        Me.groupbox_validation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupbox_validation.Location = New System.Drawing.Point(11, 124)
        Me.groupbox_validation.Name = "groupbox_validation"
        Me.groupbox_validation.Size = New System.Drawing.Size(376, 122)
        Me.groupbox_validation.TabIndex = 343
        Me.groupbox_validation.TabStop = False
        Me.groupbox_validation.Text = "Validar Presença"
        '
        'absense_time
        '
        Me.absense_time.CustomFormat = "HH:mm"
        Me.absense_time.Enabled = False
        Me.absense_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.absense_time.Location = New System.Drawing.Point(22, 84)
        Me.absense_time.Name = "absense_time"
        Me.absense_time.ShowUpDown = True
        Me.absense_time.Size = New System.Drawing.Size(65, 21)
        Me.absense_time.TabIndex = 361
        Me.absense_time.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'CheckBox_cleanCheckout
        '
        Me.CheckBox_cleanCheckout.AutoSize = True
        Me.CheckBox_cleanCheckout.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_cleanCheckout.Location = New System.Drawing.Point(192, 87)
        Me.CheckBox_cleanCheckout.Name = "CheckBox_cleanCheckout"
        Me.CheckBox_cleanCheckout.Size = New System.Drawing.Size(120, 17)
        Me.CheckBox_cleanCheckout.TabIndex = 14
        Me.CheckBox_cleanCheckout.Text = "Limpar checkout"
        Me.CheckBox_cleanCheckout.UseVisualStyleBackColor = True
        '
        'CheckBox_m
        '
        Me.CheckBox_m.AutoSize = True
        Me.CheckBox_m.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_m.Location = New System.Drawing.Point(192, 20)
        Me.CheckBox_m.Name = "CheckBox_m"
        Me.CheckBox_m.Size = New System.Drawing.Size(69, 17)
        Me.CheckBox_m.TabIndex = 11
        Me.CheckBox_m.Text = "Maladie"
        Me.CheckBox_m.UseVisualStyleBackColor = True
        '
        'CheckBox_a
        '
        Me.CheckBox_a.AutoSize = True
        Me.CheckBox_a.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_a.Location = New System.Drawing.Point(9, 43)
        Me.CheckBox_a.Name = "CheckBox_a"
        Me.CheckBox_a.Size = New System.Drawing.Size(119, 17)
        Me.CheckBox_a.TabIndex = 9
        Me.CheckBox_a.Text = "Faltou (dia todo)"
        Me.CheckBox_a.UseVisualStyleBackColor = True
        '
        'CheckBox_v
        '
        Me.CheckBox_v.AutoSize = True
        Me.CheckBox_v.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_v.Location = New System.Drawing.Point(192, 43)
        Me.CheckBox_v.Name = "CheckBox_v"
        Me.CheckBox_v.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox_v.TabIndex = 8
        Me.CheckBox_v.Text = "Férias"
        Me.CheckBox_v.UseVisualStyleBackColor = True
        '
        'CheckBox_p
        '
        Me.CheckBox_p.AutoSize = True
        Me.CheckBox_p.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_p.Location = New System.Drawing.Point(10, 20)
        Me.CheckBox_p.Name = "CheckBox_p"
        Me.CheckBox_p.Size = New System.Drawing.Size(101, 17)
        Me.CheckBox_p.TabIndex = 6
        Me.CheckBox_p.Text = "Dia completo"
        Me.CheckBox_p.UseVisualStyleBackColor = True
        '
        'CheckBox_ah
        '
        Me.CheckBox_ah.AutoSize = True
        Me.CheckBox_ah.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_ah.Location = New System.Drawing.Point(9, 66)
        Me.CheckBox_ah.Name = "CheckBox_ah"
        Me.CheckBox_ah.Size = New System.Drawing.Size(59, 17)
        Me.CheckBox_ah.TabIndex = 4
        Me.CheckBox_ah.Text = "Faltou"
        Me.CheckBox_ah.UseVisualStyleBackColor = True
        '
        'hora_lbl1
        '
        Me.hora_lbl1.AutoSize = True
        Me.hora_lbl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hora_lbl1.Location = New System.Drawing.Point(88, 88)
        Me.hora_lbl1.Name = "hora_lbl1"
        Me.hora_lbl1.Size = New System.Drawing.Size(39, 13)
        Me.hora_lbl1.TabIndex = 2
        Me.hora_lbl1.Text = "horas"
        '
        'groupbox_record
        '
        Me.groupbox_record.Controls.Add(Me.data_lbl)
        Me.groupbox_record.Controls.Add(Me.time_lbl)
        Me.groupbox_record.Controls.Add(Me.checkout_lbl)
        Me.groupbox_record.Controls.Add(Me.checkin_lbl)
        Me.groupbox_record.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupbox_record.Location = New System.Drawing.Point(127, 28)
        Me.groupbox_record.Name = "groupbox_record"
        Me.groupbox_record.Size = New System.Drawing.Size(555, 90)
        Me.groupbox_record.TabIndex = 342
        Me.groupbox_record.TabStop = False
        Me.groupbox_record.Text = "Registo Cartão"
        '
        'data_lbl
        '
        Me.data_lbl.AutoSize = True
        Me.data_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.data_lbl.Location = New System.Drawing.Point(6, 17)
        Me.data_lbl.Name = "data_lbl"
        Me.data_lbl.Size = New System.Drawing.Size(21, 13)
        Me.data_lbl.TabIndex = 7
        Me.data_lbl.Text = "- -"
        '
        'time_lbl
        '
        Me.time_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.time_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.time_lbl.Location = New System.Drawing.Point(360, 63)
        Me.time_lbl.Name = "time_lbl"
        Me.time_lbl.Size = New System.Drawing.Size(186, 14)
        Me.time_lbl.TabIndex = 5
        Me.time_lbl.Text = "Duração :  17:25"
        Me.time_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkout_lbl
        '
        Me.checkout_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkout_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkout_lbl.Location = New System.Drawing.Point(14, 63)
        Me.checkout_lbl.Name = "checkout_lbl"
        Me.checkout_lbl.Size = New System.Drawing.Size(181, 13)
        Me.checkout_lbl.TabIndex = 3
        Me.checkout_lbl.Text = "Saida :  17:25"
        Me.checkout_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'checkin_lbl
        '
        Me.checkin_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkin_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkin_lbl.Location = New System.Drawing.Point(6, 40)
        Me.checkin_lbl.Name = "checkin_lbl"
        Me.checkin_lbl.Size = New System.Drawing.Size(189, 13)
        Me.checkin_lbl.TabIndex = 1
        Me.checkin_lbl.Text = "Entrada :  08:25"
        Me.checkin_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'logday_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "logday_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registo de presença"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupBoxMotif.ResumeLayout(False)
        Me.groupBoxMotif.PerformLayout()
        Me.groupbox_gruista.ResumeLayout(False)
        Me.groupbox_gruista.PerformLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupbox_validation.ResumeLayout(False)
        Me.groupbox_validation.PerformLayout()
        Me.groupbox_record.ResumeLayout(False)
        Me.groupbox_record.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents worker_photo As PictureBox
    Friend WithEvents saveBtn As Button
    Friend WithEvents closeBtn As Button
    Friend WithEvents worker_lbl As Label
    Friend WithEvents groupbox_validation As GroupBox
    Friend WithEvents CheckBox_cleanCheckout As CheckBox
    Friend WithEvents CheckBox_m As CheckBox
    Friend WithEvents CheckBox_a As CheckBox
    Friend WithEvents CheckBox_v As CheckBox
    Friend WithEvents CheckBox_p As CheckBox
    Friend WithEvents CheckBox_ah As CheckBox
    Friend WithEvents hora_lbl1 As Label
    Friend WithEvents groupbox_record As GroupBox
    Friend WithEvents time_lbl As Label
    Friend WithEvents checkout_lbl As Label
    Friend WithEvents checkin_lbl As Label
    Friend WithEvents data_lbl As Label
    Friend WithEvents groupbox_gruista As GroupBox
    Friend WithEvents checkbox_gruista_fullday As CheckBox
    Friend WithEvents checkbox_gruista_on_grua As CheckBox
    Friend WithEvents checkbox_gruista_parcial As CheckBox
    Friend WithEvents gruista_time As DateTimePicker
    Friend WithEvents hora_lbl2 As Label
    Friend WithEvents absense_time As DateTimePicker
    Friend WithEvents groupBoxMotif As GroupBox
    Friend WithEvents motif As TextBox
End Class
