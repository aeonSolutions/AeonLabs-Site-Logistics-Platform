Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadForm
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
        Me.bytesSent = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.fileSize = New System.Windows.Forms.Label()
        Me.downloadSpeed = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.closeLink = New System.Windows.Forms.LinkLabel()
        Me.downloading = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bytesSent
        '
        Me.bytesSent.AutoSize = True
        Me.bytesSent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bytesSent.Location = New System.Drawing.Point(3, 101)
        Me.bytesSent.Name = "bytesSent"
        Me.bytesSent.Size = New System.Drawing.Size(25, 13)
        Me.bytesSent.TabIndex = 16
        Me.bytesSent.Text = "- - "
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 75)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(480, 23)
        Me.ProgressBar1.TabIndex = 13
        '
        'fileSize
        '
        Me.fileSize.AutoSize = True
        Me.fileSize.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fileSize.Location = New System.Drawing.Point(0, 40)
        Me.fileSize.Name = "fileSize"
        Me.fileSize.Size = New System.Drawing.Size(57, 13)
        Me.fileSize.TabIndex = 12
        Me.fileSize.Text = "File size:"
        '
        'downloadSpeed
        '
        Me.downloadSpeed.AutoSize = True
        Me.downloadSpeed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downloadSpeed.Location = New System.Drawing.Point(0, 59)
        Me.downloadSpeed.Name = "downloadSpeed"
        Me.downloadSpeed.Size = New System.Drawing.Size(106, 13)
        Me.downloadSpeed.TabIndex = 11
        Me.downloadSpeed.Text = "Download speed:"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Title = "Where do you want to save the file?"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.downloading)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.closeLink)
        Me.Panel1.Controls.Add(Me.downloadSpeed)
        Me.Panel1.Controls.Add(Me.fileSize)
        Me.Panel1.Controls.Add(Me.bytesSent)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 155)
        Me.Panel1.TabIndex = 20
        '
        'closeLink
        '
        Me.closeLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeLink.Location = New System.Drawing.Point(285, 130)
        Me.closeLink.Name = "closeLink"
        Me.closeLink.Size = New System.Drawing.Size(198, 23)
        Me.closeLink.TabIndex = 339
        Me.closeLink.TabStop = True
        Me.closeLink.Text = "Cancelar"
        Me.closeLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'downloading
        '
        Me.downloading.AutoSize = True
        Me.downloading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downloading.Location = New System.Drawing.Point(3, 8)
        Me.downloading.Name = "downloading"
        Me.downloading.Size = New System.Drawing.Size(113, 20)
        Me.downloading.TabIndex = 340
        Me.downloading.Text = "Downloading..."
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(3, 33)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(480, 4)
        Me.divider.TabIndex = 341
        '
        'DownloadForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 155)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DownloadForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Download"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bytesSent As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents fileSize As Label
    Friend WithEvents downloadSpeed As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents closeLink As LinkLabel
    Friend WithEvents downloading As Label
    Friend WithEvents divider As Label
End Class
