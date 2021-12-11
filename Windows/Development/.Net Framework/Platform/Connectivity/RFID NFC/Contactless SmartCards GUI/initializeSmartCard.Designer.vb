Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class initializeSmartCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(initializeSmartCard))
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.authCode_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.readCodeOnly = New System.Windows.Forms.LinkLabel()
        Me.cardIdCode = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(363, 107)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.authCode_lbl)
        Me.Panel1.Controls.Add(Me.readCodeOnly)
        Me.Panel1.Controls.Add(Me.cardIdCode)
        Me.Panel1.Controls.Add(Me.progressBar)
        Me.Panel1.Controls.Add(Me.StartBtn)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(454, 143)
        Me.Panel1.TabIndex = 338
        '
        'authCode_lbl
        '
        Me.authCode_lbl.AutoSize = True
        Me.authCode_lbl.Location = New System.Drawing.Point(108, 90)
        Me.authCode_lbl.Name = "authCode_lbl"
        Me.authCode_lbl.Size = New System.Drawing.Size(29, 13)
        Me.authCode_lbl.TabIndex = 343
        Me.authCode_lbl.Text = "Auth"
        '
        'readCodeOnly
        '
        Me.readCodeOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.readCodeOnly.Location = New System.Drawing.Point(288, 71)
        Me.readCodeOnly.Name = "readCodeOnly"
        Me.readCodeOnly.Size = New System.Drawing.Size(153, 18)
        Me.readCodeOnly.TabIndex = 342
        Me.readCodeOnly.TabStop = True
        Me.readCodeOnly.Text = "read code"
        Me.readCodeOnly.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cardIdCode
        '
        Me.cardIdCode.AutoSize = True
        Me.cardIdCode.Location = New System.Drawing.Point(107, 73)
        Me.cardIdCode.Name = "cardIdCode"
        Me.cardIdCode.Size = New System.Drawing.Size(34, 13)
        Me.cardIdCode.TabIndex = 341
        Me.cardIdCode.Text = "UUID"
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(107, 46)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(334, 23)
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressBar.TabIndex = 340
        '
        'StartBtn
        '
        Me.StartBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartBtn.ForeColor = System.Drawing.Color.White
        Me.StartBtn.Location = New System.Drawing.Point(11, 107)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(86, 26)
        Me.StartBtn.TabIndex = 339
        Me.StartBtn.Text = "new card"
        Me.StartBtn.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(11, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 338
        Me.PictureBox1.TabStop = False
        '
        'initializeSmartCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 143)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "initializeSmartCard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Initialize card"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents StartBtn As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cardIdCode As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents readCodeOnly As LinkLabel
    Friend WithEvents authCode_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
End Class
