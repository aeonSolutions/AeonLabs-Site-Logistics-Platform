<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class entreprises_frm
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
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_del = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_save = New System.Windows.Forms.LinkLabel()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_contact = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(243, 221)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel1.TabIndex = 32
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Actualizar"
        '
        'LinkLabel_del
        '
        Me.LinkLabel_del.AutoSize = True
        Me.LinkLabel_del.Location = New System.Drawing.Point(668, 157)
        Me.LinkLabel_del.Name = "LinkLabel_del"
        Me.LinkLabel_del.Size = New System.Drawing.Size(41, 13)
        Me.LinkLabel_del.TabIndex = 31
        Me.LinkLabel_del.TabStop = True
        Me.LinkLabel_del.Text = "Apagar"
        '
        'LinkLabel_save
        '
        Me.LinkLabel_save.AutoSize = True
        Me.LinkLabel_save.Location = New System.Drawing.Point(717, 157)
        Me.LinkLabel_save.Name = "LinkLabel_save"
        Me.LinkLabel_save.Size = New System.Drawing.Size(39, 13)
        Me.LinkLabel_save.TabIndex = 30
        Me.LinkLabel_save.TabStop = True
        Me.LinkLabel_save.Text = "Gravar"
        '
        'txt_name
        '
        Me.txt_name.Location = New System.Drawing.Point(328, 50)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(428, 20)
        Me.txt_name.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(325, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Nome da empresa"
        '
        'txt_contact
        '
        Me.txt_contact.Location = New System.Drawing.Point(328, 109)
        Me.txt_contact.Name = "txt_contact"
        Me.txt_contact.Size = New System.Drawing.Size(140, 20)
        Me.txt_contact.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Contato"
        '
        'listview_works
        '
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(12, 6)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.ScrollAlwaysVisible = True
        Me.listview_works.Size = New System.Drawing.Size(289, 212)
        Me.listview_works.TabIndex = 36
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(702, 221)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 26)
        Me.Button3.TabIndex = 338
        Me.Button3.Text = "Fechar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'entreprises_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(800, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.listview_works)
        Me.Controls.Add(Me.txt_contact)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LinkLabel_del)
        Me.Controls.Add(Me.LinkLabel_save)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "entreprises_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Empresas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel_del As LinkLabel
    Friend WithEvents LinkLabel_save As LinkLabel
    Friend WithEvents txt_name As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_contact As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents listview_works As ListBox
    Friend WithEvents Button3 As Button
End Class
