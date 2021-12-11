<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanDailyTasksAddTeams_frm
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.material = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.motivo = New System.Windows.Forms.TextBox()
        Me.del_ausencia = New System.Windows.Forms.LinkLabel()
        Me.save_ausencia = New System.Windows.Forms.LinkLabel()
        Me.ausenciaslist = New System.Windows.Forms.ListBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1155, 417)
        Me.Panel1.TabIndex = 338
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label62)
        Me.Panel2.Controls.Add(Me.material)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label60)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.motivo)
        Me.Panel2.Controls.Add(Me.del_ausencia)
        Me.Panel2.Controls.Add(Me.save_ausencia)
        Me.Panel2.Controls.Add(Me.ausenciaslist)
        Me.Panel2.Controls.Add(Me.listview_works)
        Me.Panel2.Controls.Add(Me.Label70)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.Label59)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1153, 415)
        Me.Panel2.TabIndex = 338
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(953, 32)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(186, 13)
        Me.Label62.TabIndex = 348
        Me.Label62.Text = "campos com * são obrigatórios"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'material
        '
        Me.material.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.Location = New System.Drawing.Point(733, 127)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(216, 21)
        Me.material.TabIndex = 344
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(730, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 345
        Me.Label1.Text = "Designação da equipa*"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(11, 8)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(335, 18)
        Me.Label60.TabIndex = 271
        Me.Label60.Text = "Gestão de equipas de trabalho em obra"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1053, 381)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 26)
        Me.Button3.TabIndex = 336
        Me.Button3.Text = "Fechar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'motivo
        '
        Me.motivo.Enabled = False
        Me.motivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.motivo.Location = New System.Drawing.Point(733, 171)
        Me.motivo.Multiline = True
        Me.motivo.Name = "motivo"
        Me.motivo.Size = New System.Drawing.Size(408, 100)
        Me.motivo.TabIndex = 270
        '
        'del_ausencia
        '
        Me.del_ausencia.AutoSize = True
        Me.del_ausencia.Enabled = False
        Me.del_ausencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del_ausencia.Location = New System.Drawing.Point(1051, 336)
        Me.del_ausencia.Name = "del_ausencia"
        Me.del_ausencia.Size = New System.Drawing.Size(48, 13)
        Me.del_ausencia.TabIndex = 267
        Me.del_ausencia.TabStop = True
        Me.del_ausencia.Text = "Apagar"
        '
        'save_ausencia
        '
        Me.save_ausencia.AutoSize = True
        Me.save_ausencia.Enabled = False
        Me.save_ausencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_ausencia.Location = New System.Drawing.Point(1100, 336)
        Me.save_ausencia.Name = "save_ausencia"
        Me.save_ausencia.Size = New System.Drawing.Size(47, 13)
        Me.save_ausencia.TabIndex = 266
        Me.save_ausencia.TabStop = True
        Me.save_ausencia.Text = "Gravar"
        '
        'ausenciaslist
        '
        Me.ausenciaslist.BackColor = System.Drawing.Color.Honeydew
        Me.ausenciaslist.Enabled = False
        Me.ausenciaslist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ausenciaslist.FormattingEnabled = True
        Me.ausenciaslist.HorizontalScrollbar = True
        Me.ausenciaslist.Location = New System.Drawing.Point(289, 56)
        Me.ausenciaslist.Name = "ausenciaslist"
        Me.ausenciaslist.Size = New System.Drawing.Size(249, 277)
        Me.ausenciaslist.TabIndex = 273
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(11, 56)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(272, 277)
        Me.listview_works.TabIndex = 283
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(730, 155)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(58, 13)
        Me.Label70.TabIndex = 279
        Me.Label70.Text = "Anotações"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(220, 336)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(63, 13)
        Me.LinkLabel2.TabIndex = 282
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Actualizar"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.LimeGreen
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label59.Location = New System.Drawing.Point(9, 28)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(1130, 4)
        Me.Label59.TabIndex = 280
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(544, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(180, 277)
        Me.Panel3.TabIndex = 349
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = "Trabalhadores"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(288, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 351
        Me.Label3.Text = "Equipas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(541, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 352
        Me.Label4.Text = "Trabalhadores na equipa"
        '
        'PlanDailyTasksAddTeams_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 417)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PlanDailyTasksAddTeams_frm"
        Me.ShowIcon = False
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label62 As Label
    Friend WithEvents material As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents motivo As TextBox
    Friend WithEvents del_ausencia As LinkLabel
    Friend WithEvents save_ausencia As LinkLabel
    Friend WithEvents ausenciaslist As ListBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents Label70 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label59 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
