<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class holidays_frm
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
        Me.calendar = New System.Windows.Forms.MonthCalendar()
        Me.remove = New System.Windows.Forms.LinkLabel()
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        Me.add = New System.Windows.Forms.LinkLabel()
        Me.ListView_holidays = New System.Windows.Forms.ListBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.title = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'calendar
        '
        Me.calendar.Location = New System.Drawing.Point(246, 35)
        Me.calendar.Name = "calendar"
        Me.calendar.TabIndex = 35
        '
        'remove
        '
        Me.remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.remove.Location = New System.Drawing.Point(123, 200)
        Me.remove.Name = "remove"
        Me.remove.Size = New System.Drawing.Size(111, 20)
        Me.remove.TabIndex = 38
        Me.remove.TabStop = True
        Me.remove.Text = "Remover"
        Me.remove.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'updateLink
        '
        Me.updateLink.AutoSize = True
        Me.updateLink.Location = New System.Drawing.Point(3, 200)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(53, 13)
        Me.updateLink.TabIndex = 37
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Actualizar"
        '
        'add
        '
        Me.add.AutoSize = True
        Me.add.Location = New System.Drawing.Point(423, 200)
        Me.add.Name = "add"
        Me.add.Size = New System.Drawing.Size(51, 13)
        Me.add.TabIndex = 40
        Me.add.TabStop = True
        Me.add.Text = "Adicionar"
        '
        'ListView_holidays
        '
        Me.ListView_holidays.FormattingEnabled = True
        Me.ListView_holidays.HorizontalScrollbar = True
        Me.ListView_holidays.Location = New System.Drawing.Point(6, 37)
        Me.ListView_holidays.Name = "ListView_holidays"
        Me.ListView_holidays.Size = New System.Drawing.Size(231, 160)
        Me.ListView_holidays.TabIndex = 41
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(387, 226)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.ListView_holidays)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.updateLink)
        Me.Panel1.Controls.Add(Me.remove)
        Me.Panel1.Controls.Add(Me.add)
        Me.Panel1.Controls.Add(Me.calendar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 259)
        Me.Panel1.TabIndex = 339
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(83, 18)
        Me.title.TabIndex = 339
        Me.title.Text = "Feriados"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(1, 28)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(472, 4)
        Me.divider.TabIndex = 340
        '
        'holidays_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 259)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "holidays_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Feriados "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents calendar As MonthCalendar
    Friend WithEvents remove As LinkLabel
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents add As LinkLabel
    Friend WithEvents ListView_holidays As ListBox
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents title As Label
    Friend WithEvents divider As Label
End Class
