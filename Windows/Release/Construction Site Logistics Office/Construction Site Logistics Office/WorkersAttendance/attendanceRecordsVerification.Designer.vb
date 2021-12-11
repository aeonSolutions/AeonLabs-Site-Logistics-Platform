<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class attendance_records_verification_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(attendance_records_verification_frm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.duplicatesBtn = New System.Windows.Forms.Button()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.searchDate = New System.Windows.Forms.DateTimePicker()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.nonValidatedBtn = New System.Windows.Forms.Button()
        Me.cmdbox = New System.Windows.Forms.TextBox()
        Me.month_lbl = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 133)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'duplicatesBtn
        '
        Me.duplicatesBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.duplicatesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.duplicatesBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duplicatesBtn.ForeColor = System.Drawing.Color.White
        Me.duplicatesBtn.Location = New System.Drawing.Point(318, 350)
        Me.duplicatesBtn.Name = "duplicatesBtn"
        Me.duplicatesBtn.Size = New System.Drawing.Size(141, 26)
        Me.duplicatesBtn.TabIndex = 340
        Me.duplicatesBtn.Text = "Registos duplicados"
        Me.duplicatesBtn.UseVisualStyleBackColor = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(666, 350)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 339
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'searchDate
        '
        Me.searchDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchDate.Location = New System.Drawing.Point(564, 11)
        Me.searchDate.Name = "searchDate"
        Me.searchDate.Size = New System.Drawing.Size(200, 21)
        Me.searchDate.TabIndex = 341
        '
        'subtitle
        '
        Me.subtitle.AutoSize = True
        Me.subtitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.Location = New System.Drawing.Point(155, 44)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(17, 13)
        Me.subtitle.TabIndex = 344
        Me.subtitle.Text = "--"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.nonValidatedBtn)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.cmdbox)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.duplicatesBtn)
        Me.Panel1.Controls.Add(Me.searchDate)
        Me.Panel1.Controls.Add(Me.month_lbl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(777, 389)
        Me.Panel1.TabIndex = 345
        '
        'nonValidatedBtn
        '
        Me.nonValidatedBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.nonValidatedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nonValidatedBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nonValidatedBtn.ForeColor = System.Drawing.Color.White
        Me.nonValidatedBtn.Location = New System.Drawing.Point(158, 350)
        Me.nonValidatedBtn.Name = "nonValidatedBtn"
        Me.nonValidatedBtn.Size = New System.Drawing.Size(154, 26)
        Me.nonValidatedBtn.TabIndex = 346
        Me.nonValidatedBtn.Text = "Registos nao validados"
        Me.nonValidatedBtn.UseVisualStyleBackColor = False
        '
        'cmdbox
        '
        Me.cmdbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmdbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbox.Location = New System.Drawing.Point(158, 62)
        Me.cmdbox.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdbox.Multiline = True
        Me.cmdbox.Name = "cmdbox"
        Me.cmdbox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.cmdbox.Size = New System.Drawing.Size(612, 285)
        Me.cmdbox.TabIndex = 1
        Me.cmdbox.Text = "CLIQUE EM INICIAR PARA EFETUAR A PROCURA"
        '
        'month_lbl
        '
        Me.month_lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.month_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.month_lbl.Location = New System.Drawing.Point(306, 15)
        Me.month_lbl.Name = "month_lbl"
        Me.month_lbl.Size = New System.Drawing.Size(257, 17)
        Me.month_lbl.TabIndex = 345
        Me.month_lbl.Text = "mês a procurar: "
        Me.month_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'attendance_records_verification_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 389)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "attendance_records_verification_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Verificacao de registos"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents duplicatesBtn As Button
    Friend WithEvents closeBtn As Button
    Friend WithEvents searchDate As DateTimePicker
    Friend WithEvents subtitle As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents month_lbl As Label
    Friend WithEvents cmdbox As TextBox
    Friend WithEvents nonValidatedBtn As Button
End Class
