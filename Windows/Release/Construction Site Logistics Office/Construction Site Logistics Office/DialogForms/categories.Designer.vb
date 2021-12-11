<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class categories_frm
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
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(181, 219)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel1.TabIndex = 32
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Actualizar"
        '
        'LinkLabel_del
        '
        Me.LinkLabel_del.AutoSize = True
        Me.LinkLabel_del.Location = New System.Drawing.Point(424, 92)
        Me.LinkLabel_del.Name = "LinkLabel_del"
        Me.LinkLabel_del.Size = New System.Drawing.Size(41, 13)
        Me.LinkLabel_del.TabIndex = 31
        Me.LinkLabel_del.TabStop = True
        Me.LinkLabel_del.Text = "Apagar"
        '
        'LinkLabel_save
        '
        Me.LinkLabel_save.AutoSize = True
        Me.LinkLabel_save.Location = New System.Drawing.Point(482, 92)
        Me.LinkLabel_save.Name = "LinkLabel_save"
        Me.LinkLabel_save.Size = New System.Drawing.Size(39, 13)
        Me.LinkLabel_save.TabIndex = 30
        Me.LinkLabel_save.TabStop = True
        Me.LinkLabel_save.Text = "Gravar"
        '
        'btn_sair
        '
        Me.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_sair.Location = New System.Drawing.Point(447, 219)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 23)
        Me.btn_sair.TabIndex = 28
        Me.btn_sair.Text = "Fechar"
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'txt_name
        '
        Me.txt_name.Location = New System.Drawing.Point(243, 49)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(278, 20)
        Me.txt_name.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Designaçao"
        '
        'listview_works
        '
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(12, 20)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.ScrollAlwaysVisible = True
        Me.listview_works.Size = New System.Drawing.Size(222, 199)
        Me.listview_works.TabIndex = 36
        '
        'categories_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.listview_works)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LinkLabel_del)
        Me.Controls.Add(Me.LinkLabel_save)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "categories_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Categorias profissionais"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel_del As LinkLabel
    Friend WithEvents LinkLabel_save As LinkLabel
    Friend WithEvents btn_sair As Button
    Friend WithEvents txt_name As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents listview_works As ListBox
End Class
