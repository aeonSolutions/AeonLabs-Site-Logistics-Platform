<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class logger_stats_frm
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
        Me.mes = New System.Windows.Forms.Label()
        Me.total_works_days = New System.Windows.Forms.Label()
        Me.totalDaysAtWork_subtitle = New System.Windows.Forms.Label()
        Me.total_days_at_work = New System.Windows.Forms.Label()
        Me.daysAtWor_subtitle = New System.Windows.Forms.Label()
        Me.total_days = New System.Windows.Forms.Label()
        Me.min_workers = New System.Windows.Forms.Label()
        Me.max_workers = New System.Windows.Forms.Label()
        Me.absense_hours = New System.Windows.Forms.Label()
        Me.hoursInAbsense_subtitle = New System.Windows.Forms.Label()
        Me.maxDailyWorkers_subtitle = New System.Windows.Forms.Label()
        Me.minDailyWorkers_subtitle = New System.Windows.Forms.Label()
        Me.maxWorkDaysInMonth_subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.mes)
        Me.Panel1.Controls.Add(Me.total_works_days)
        Me.Panel1.Controls.Add(Me.totalDaysAtWork_subtitle)
        Me.Panel1.Controls.Add(Me.total_days_at_work)
        Me.Panel1.Controls.Add(Me.daysAtWor_subtitle)
        Me.Panel1.Controls.Add(Me.total_days)
        Me.Panel1.Controls.Add(Me.min_workers)
        Me.Panel1.Controls.Add(Me.max_workers)
        Me.Panel1.Controls.Add(Me.absense_hours)
        Me.Panel1.Controls.Add(Me.hoursInAbsense_subtitle)
        Me.Panel1.Controls.Add(Me.maxDailyWorkers_subtitle)
        Me.Panel1.Controls.Add(Me.minDailyWorkers_subtitle)
        Me.Panel1.Controls.Add(Me.maxWorkDaysInMonth_subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 230)
        Me.Panel1.TabIndex = 0
        '
        'mes
        '
        Me.mes.AutoSize = True
        Me.mes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mes.Location = New System.Drawing.Point(11, 27)
        Me.mes.Name = "mes"
        Me.mes.Size = New System.Drawing.Size(31, 13)
        Me.mes.TabIndex = 366
        Me.mes.Text = "mes"
        '
        'total_works_days
        '
        Me.total_works_days.AutoSize = True
        Me.total_works_days.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total_works_days.Location = New System.Drawing.Point(245, 174)
        Me.total_works_days.Name = "total_works_days"
        Me.total_works_days.Size = New System.Drawing.Size(17, 13)
        Me.total_works_days.TabIndex = 365
        Me.total_works_days.Text = "--"
        '
        'totalDaysAtWork_subtitle
        '
        Me.totalDaysAtWork_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalDaysAtWork_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalDaysAtWork_subtitle.Location = New System.Drawing.Point(10, 174)
        Me.totalDaysAtWork_subtitle.Name = "totalDaysAtWork_subtitle"
        Me.totalDaysAtWork_subtitle.Size = New System.Drawing.Size(229, 16)
        Me.totalDaysAtWork_subtitle.TabIndex = 364
        Me.totalDaysAtWork_subtitle.Text = "Somatório de dias de trabalho"
        Me.totalDaysAtWork_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'total_days_at_work
        '
        Me.total_days_at_work.AutoSize = True
        Me.total_days_at_work.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total_days_at_work.Location = New System.Drawing.Point(245, 150)
        Me.total_days_at_work.Name = "total_days_at_work"
        Me.total_days_at_work.Size = New System.Drawing.Size(17, 13)
        Me.total_days_at_work.TabIndex = 363
        Me.total_days_at_work.Text = "--"
        '
        'daysAtWor_subtitle
        '
        Me.daysAtWor_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.daysAtWor_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.daysAtWor_subtitle.Location = New System.Drawing.Point(11, 150)
        Me.daysAtWor_subtitle.Name = "daysAtWor_subtitle"
        Me.daysAtWor_subtitle.Size = New System.Drawing.Size(228, 16)
        Me.daysAtWor_subtitle.TabIndex = 362
        Me.daysAtWor_subtitle.Text = "Total de dias a trabalhar"
        Me.daysAtWor_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'total_days
        '
        Me.total_days.AutoSize = True
        Me.total_days.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total_days.Location = New System.Drawing.Point(245, 127)
        Me.total_days.Name = "total_days"
        Me.total_days.Size = New System.Drawing.Size(17, 13)
        Me.total_days.TabIndex = 361
        Me.total_days.Text = "--"
        '
        'min_workers
        '
        Me.min_workers.AutoSize = True
        Me.min_workers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.min_workers.Location = New System.Drawing.Point(245, 100)
        Me.min_workers.Name = "min_workers"
        Me.min_workers.Size = New System.Drawing.Size(17, 13)
        Me.min_workers.TabIndex = 360
        Me.min_workers.Text = "--"
        '
        'max_workers
        '
        Me.max_workers.AutoSize = True
        Me.max_workers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.max_workers.Location = New System.Drawing.Point(245, 72)
        Me.max_workers.Name = "max_workers"
        Me.max_workers.Size = New System.Drawing.Size(17, 13)
        Me.max_workers.TabIndex = 359
        Me.max_workers.Text = "--"
        '
        'absense_hours
        '
        Me.absense_hours.AutoSize = True
        Me.absense_hours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.absense_hours.Location = New System.Drawing.Point(245, 46)
        Me.absense_hours.Name = "absense_hours"
        Me.absense_hours.Size = New System.Drawing.Size(17, 13)
        Me.absense_hours.TabIndex = 358
        Me.absense_hours.Text = "--"
        '
        'hoursInAbsense_subtitle
        '
        Me.hoursInAbsense_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hoursInAbsense_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hoursInAbsense_subtitle.Location = New System.Drawing.Point(10, 46)
        Me.hoursInAbsense_subtitle.Name = "hoursInAbsense_subtitle"
        Me.hoursInAbsense_subtitle.Size = New System.Drawing.Size(229, 16)
        Me.hoursInAbsense_subtitle.TabIndex = 356
        Me.hoursInAbsense_subtitle.Text = "Horas faltadas"
        Me.hoursInAbsense_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'maxDailyWorkers_subtitle
        '
        Me.maxDailyWorkers_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxDailyWorkers_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxDailyWorkers_subtitle.Location = New System.Drawing.Point(14, 72)
        Me.maxDailyWorkers_subtitle.Name = "maxDailyWorkers_subtitle"
        Me.maxDailyWorkers_subtitle.Size = New System.Drawing.Size(224, 16)
        Me.maxDailyWorkers_subtitle.TabIndex = 355
        Me.maxDailyWorkers_subtitle.Text = "Pico max. diário de trabalhadores"
        Me.maxDailyWorkers_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'minDailyWorkers_subtitle
        '
        Me.minDailyWorkers_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minDailyWorkers_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minDailyWorkers_subtitle.Location = New System.Drawing.Point(13, 100)
        Me.minDailyWorkers_subtitle.Name = "minDailyWorkers_subtitle"
        Me.minDailyWorkers_subtitle.Size = New System.Drawing.Size(225, 16)
        Me.minDailyWorkers_subtitle.TabIndex = 354
        Me.minDailyWorkers_subtitle.Text = "Pico min.  diário de trabalhadores"
        Me.minDailyWorkers_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'maxWorkDaysInMonth_subtitle
        '
        Me.maxWorkDaysInMonth_subtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxWorkDaysInMonth_subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maxWorkDaysInMonth_subtitle.Location = New System.Drawing.Point(14, 127)
        Me.maxWorkDaysInMonth_subtitle.Name = "maxWorkDaysInMonth_subtitle"
        Me.maxWorkDaysInMonth_subtitle.Size = New System.Drawing.Size(225, 16)
        Me.maxWorkDaysInMonth_subtitle.TabIndex = 353
        Me.maxWorkDaysInMonth_subtitle.Text = "dias de trabalho possiveis no mês"
        Me.maxWorkDaysInMonth_subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(7, 11)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(43, 16)
        Me.title.TabIndex = 351
        Me.title.Text = "Obra"
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(276, 194)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 350
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'logger_stats_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 230)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "logger_stats_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Estatisticas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents total_days As Label
    Friend WithEvents min_workers As Label
    Friend WithEvents max_workers As Label
    Friend WithEvents absense_hours As Label
    Friend WithEvents hoursInAbsense_subtitle As Label
    Friend WithEvents maxDailyWorkers_subtitle As Label
    Friend WithEvents minDailyWorkers_subtitle As Label
    Friend WithEvents maxWorkDaysInMonth_subtitle As Label
    Friend WithEvents title As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents total_days_at_work As Label
    Friend WithEvents daysAtWor_subtitle As Label
    Friend WithEvents total_works_days As Label
    Friend WithEvents totalDaysAtWork_subtitle As Label
    Friend WithEvents mes As Label
End Class
