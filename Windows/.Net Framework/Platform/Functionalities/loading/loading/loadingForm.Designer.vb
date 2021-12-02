<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loadingForm
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
        Me.progressbar = New CircularProgressBar.CircularProgress.CircularProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.exitAppLink = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'progressbar
        '
        Me.progressbar.AutoSize = True
        Me.progressbar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.progressbar.Bar1.ActiveColor = System.Drawing.Color.White
        Me.progressbar.Bar1.BorderColor = System.Drawing.Color.DarkRed
        Me.progressbar.Bar1.Enabled = True
        Me.progressbar.Bar1.FinishColor = System.Drawing.Color.Honeydew
        Me.progressbar.Bar1.InactiveColor = System.Drawing.Color.DarkGray
        Me.progressbar.Bar2.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar2.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar2.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar2.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar3.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar3.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar3.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar3.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar4.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar4.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar4.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar4.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Bar5.ActiveColor = System.Drawing.Color.LightSeaGreen
        Me.progressbar.Bar5.BorderColor = System.Drawing.Color.Black
        Me.progressbar.Bar5.FinishColor = System.Drawing.Color.LightGreen
        Me.progressbar.Bar5.InactiveColor = System.Drawing.Color.LightGray
        Me.progressbar.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.progressbar.ForeColor = System.Drawing.Color.Black
        Me.progressbar.Image = Nothing
        Me.progressbar.Location = New System.Drawing.Point(350, 175)
        Me.progressbar.MaximumSize = New System.Drawing.Size(100, 100)
        Me.progressbar.MinimumSize = New System.Drawing.Size(20, 20)
        Me.progressbar.Name = "progressbar"
        Me.progressbar.Size = New System.Drawing.Size(100, 100)
        Me.progressbar.TabIndex = 352
        Me.progressbar.TextShadowColor = System.Drawing.Color.White
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(382, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 353
        Me.Label1.Text = "Label1"
        '
        'exitAppLink
        '
        Me.exitAppLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.exitAppLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitAppLink.LinkColor = System.Drawing.Color.LightGray
        Me.exitAppLink.Location = New System.Drawing.Point(645, 418)
        Me.exitAppLink.Name = "exitAppLink"
        Me.exitAppLink.Size = New System.Drawing.Size(143, 23)
        Me.exitAppLink.TabIndex = 354
        Me.exitAppLink.TabStop = True
        Me.exitAppLink.Text = "Exit"
        Me.exitAppLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'loadingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitAppLink)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.progressbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "loadingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents progressbar As CircularProgressBar.CircularProgress.CircularProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents exitAppLink As LinkLabel
End Class
