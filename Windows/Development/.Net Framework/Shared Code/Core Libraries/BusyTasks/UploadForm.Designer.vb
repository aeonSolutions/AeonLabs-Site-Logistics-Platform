Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class upload_frm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bytesSent = New System.Windows.Forms.Label()
        Me.ProgressBarX1 = New System.Windows.Forms.ProgressBar()
        Me.fileSize = New System.Windows.Forms.Label()
        Me.downloadSpeed = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.closeLink = New System.Windows.Forms.LinkLabel()
        Me.uploading = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bytesSent
        '
        Me.bytesSent.AutoSize = True
        Me.bytesSent.Location = New System.Drawing.Point(13, 108)
        Me.bytesSent.Name = "bytesSent"
        Me.bytesSent.Size = New System.Drawing.Size(19, 13)
        Me.bytesSent.TabIndex = 23
        Me.bytesSent.Text = "- - "
        '
        'ProgressBarX1
        '
        Me.ProgressBarX1.Location = New System.Drawing.Point(12, 82)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(486, 23)
        Me.ProgressBarX1.TabIndex = 22
        '
        'fileSize
        '
        Me.fileSize.AutoSize = True
        Me.fileSize.Location = New System.Drawing.Point(13, 36)
        Me.fileSize.Name = "fileSize"
        Me.fileSize.Size = New System.Drawing.Size(47, 13)
        Me.fileSize.TabIndex = 21
        Me.fileSize.Text = "File size:"
        '
        'downloadSpeed
        '
        Me.downloadSpeed.AutoSize = True
        Me.downloadSpeed.Location = New System.Drawing.Point(11, 66)
        Me.downloadSpeed.Name = "downloadSpeed"
        Me.downloadSpeed.Size = New System.Drawing.Size(76, 13)
        Me.downloadSpeed.TabIndex = 20
        Me.downloadSpeed.Text = "Upload speed:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.uploading)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.closeLink)
        Me.Panel1.Controls.Add(Me.downloadSpeed)
        Me.Panel1.Controls.Add(Me.fileSize)
        Me.Panel1.Controls.Add(Me.bytesSent)
        Me.Panel1.Controls.Add(Me.ProgressBarX1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 164)
        Me.Panel1.TabIndex = 338
        '
        'closeLink
        '
        Me.closeLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeLink.Location = New System.Drawing.Point(322, 137)
        Me.closeLink.Name = "closeLink"
        Me.closeLink.Size = New System.Drawing.Size(176, 17)
        Me.closeLink.TabIndex = 338
        Me.closeLink.TabStop = True
        Me.closeLink.Text = "Cancel"
        Me.closeLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uploading
        '
        Me.uploading.AutoSize = True
        Me.uploading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uploading.Location = New System.Drawing.Point(8, 0)
        Me.uploading.Name = "uploading"
        Me.uploading.Size = New System.Drawing.Size(93, 20)
        Me.uploading.TabIndex = 342
        Me.uploading.Text = "Uploading..."
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(12, 20)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(486, 4)
        Me.divider.TabIndex = 343
        '
        'upload_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 164)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "upload_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bytesSent As Label
    Friend WithEvents ProgressBarX1 As ProgressBar
    Friend WithEvents fileSize As Label
    Friend WithEvents downloadSpeed As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents closeLink As LinkLabel
    Friend WithEvents uploading As Label
    Friend WithEvents divider As Label
End Class
