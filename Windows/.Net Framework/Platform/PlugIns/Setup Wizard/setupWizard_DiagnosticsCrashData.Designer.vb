Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizard_DiagnosticsCrashData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_DiagnosticsCrashData))
        Me.about_diagnostics = New System.Windows.Forms.LinkLabel()
        Me.share = New System.Windows.Forms.CheckBox()
        Me.send = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.share_details = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.send_details = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'about_diagnostics
        '
        Me.about_diagnostics.AutoSize = True
        Me.about_diagnostics.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.about_diagnostics.Location = New System.Drawing.Point(707, 677)
        Me.about_diagnostics.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.about_diagnostics.Name = "about_diagnostics"
        Me.about_diagnostics.Size = New System.Drawing.Size(357, 23)
        Me.about_diagnostics.TabIndex = 13
        Me.about_diagnostics.TabStop = True
        Me.about_diagnostics.Text = "About Diagnostics and Privacy ..."
        '
        'share
        '
        Me.share.AutoSize = True
        Me.share.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.share.ForeColor = System.Drawing.Color.Black
        Me.share.Location = New System.Drawing.Point(523, 549)
        Me.share.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.share.Name = "share"
        Me.share.Size = New System.Drawing.Size(427, 27)
        Me.share.TabIndex = 11
        Me.share.Text = "Share crash data with app developers"
        Me.share.UseVisualStyleBackColor = True
        '
        'send
        '
        Me.send.AutoSize = True
        Me.send.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send.ForeColor = System.Drawing.Color.Black
        Me.send.Location = New System.Drawing.Point(523, 417)
        Me.send.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.send.Name = "send"
        Me.send.Size = New System.Drawing.Size(353, 27)
        Me.send.TabIndex = 9
        Me.send.Text = "Send diagnostics && usage data"
        Me.send.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(564, 14)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(459, 394)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'share_details
        '
        Me.share_details.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.share_details.ForeColor = System.Drawing.Color.Black
        Me.share_details.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.share_details.Location = New System.Drawing.Point(544, 581)
        Me.share_details.Name = "share_details"
        Me.share_details.Size = New System.Drawing.Size(479, 96)
        Me.share_details.TabIndex = 15
        Me.share_details.Text = "Help app developers improve their apps by allowing us to share crash data with th" &
    "em."
        '
        'send_details
        '
        Me.send_details.Font = New System.Drawing.Font("Trajan Pro", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send_details.ForeColor = System.Drawing.Color.Black
        Me.send_details.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.send_details.Location = New System.Drawing.Point(544, 449)
        Me.send_details.Name = "send_details"
        Me.send_details.Size = New System.Drawing.Size(520, 95)
        Me.send_details.TabIndex = 14
        Me.send_details.Text = "Help us improve the products and services by automatically sending diagnostics an" &
    "d usage data. Diagnostic my include locations."
        '
        'setupWizard_DiagnosticsCrashData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.share_details)
        Me.Controls.Add(Me.send_details)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.about_diagnostics)
        Me.Controls.Add(Me.send)
        Me.Controls.Add(Me.share)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_DiagnosticsCrashData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents about_diagnostics As LinkLabel
    Friend WithEvents share As CheckBox
    Friend WithEvents send As CheckBox
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents share_details As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents send_details As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
End Class
