<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class message_box_frm
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
        Me.message = New System.Windows.Forms.TextBox()
        Me.ContinueBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.title = New System.Windows.Forms.Label()
        Me.iconBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.iconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.message)
        Me.Panel1.Controls.Add(Me.ContinueBtn)
        Me.Panel1.Controls.Add(Me.cancelBtn)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.iconBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(403, 149)
        Me.Panel1.TabIndex = 0
        '
        'message
        '
        Me.message.BackColor = System.Drawing.Color.Honeydew
        Me.message.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.message.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message.Location = New System.Drawing.Point(92, 37)
        Me.message.Multiline = True
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(306, 75)
        Me.message.TabIndex = 349
        '
        'ContinueBtn
        '
        Me.ContinueBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.ContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ContinueBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContinueBtn.ForeColor = System.Drawing.Color.White
        Me.ContinueBtn.Location = New System.Drawing.Point(3, 118)
        Me.ContinueBtn.Name = "ContinueBtn"
        Me.ContinueBtn.Size = New System.Drawing.Size(86, 26)
        Me.ContinueBtn.TabIndex = 348
        Me.ContinueBtn.Text = "Continuar"
        Me.ContinueBtn.UseVisualStyleBackColor = False
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelBtn.ForeColor = System.Drawing.Color.White
        Me.cancelBtn.Location = New System.Drawing.Point(312, 118)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(86, 26)
        Me.cancelBtn.TabIndex = 347
        Me.cancelBtn.Text = "Cancelar"
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(176, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(46, 18)
        Me.title.TabIndex = 1
        Me.title.Text = "Title"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'iconBox
        '
        Me.iconBox.Location = New System.Drawing.Point(11, 37)
        Me.iconBox.Name = "iconBox"
        Me.iconBox.Size = New System.Drawing.Size(75, 75)
        Me.iconBox.TabIndex = 0
        Me.iconBox.TabStop = False
        '
        'message_box_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(403, 149)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "message_box_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.iconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents title As Label
    Friend WithEvents iconBox As PictureBox
    Friend WithEvents ContinueBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents message As TextBox
End Class
