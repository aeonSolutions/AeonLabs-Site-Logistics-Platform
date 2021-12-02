Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupWizard_ServerAddress
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_ServerAddress))
        Me.domain_web_ex = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_web_addr_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.server_web_addr = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.selectionOkpic = New System.Windows.Forms.PictureBox()
        Me.TimerCheckIsOnline = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.selectionOkpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'domain_web_ex
        '
        Me.domain_web_ex.AutoSize = True
        Me.domain_web_ex.Font = New System.Drawing.Font("Trajan Pro", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domain_web_ex.ForeColor = System.Drawing.Color.Black
        Me.domain_web_ex.Location = New System.Drawing.Point(454, 547)
        Me.domain_web_ex.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.domain_web_ex.Name = "domain_web_ex"
        Me.domain_web_ex.Size = New System.Drawing.Size(278, 18)
        Me.domain_web_ex.TabIndex = 22
        Me.domain_web_ex.Text = "ex.: http://www.yourdomain.com"
        '
        'server_web_addr_lbl
        '
        Me.server_web_addr_lbl.AutoSize = True
        Me.server_web_addr_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr_lbl.ForeColor = System.Drawing.Color.Black
        Me.server_web_addr_lbl.Location = New System.Drawing.Point(449, 482)
        Me.server_web_addr_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.server_web_addr_lbl.Name = "server_web_addr_lbl"
        Me.server_web_addr_lbl.Size = New System.Drawing.Size(207, 23)
        Me.server_web_addr_lbl.TabIndex = 21
        Me.server_web_addr_lbl.Text = "Server web address"
        Me.server_web_addr_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'server_web_addr
        '
        Me.server_web_addr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.server_web_addr.Location = New System.Drawing.Point(453, 510)
        Me.server_web_addr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.server_web_addr.Name = "server_web_addr"
        Me.server_web_addr.Size = New System.Drawing.Size(634, 28)
        Me.server_web_addr.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(453, 29)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(634, 378)
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
        'selectionOkpic
        '
        Me.selectionOkpic.Image = CType(resources.GetObject("selectionOkpic.Image"), System.Drawing.Image)
        Me.selectionOkpic.Location = New System.Drawing.Point(1094, 498)
        Me.selectionOkpic.Name = "selectionOkpic"
        Me.selectionOkpic.Size = New System.Drawing.Size(40, 40)
        Me.selectionOkpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.selectionOkpic.TabIndex = 24
        Me.selectionOkpic.TabStop = False
        Me.selectionOkpic.Visible = False
        '
        'TimerCheckIsOnline
        '
        Me.TimerCheckIsOnline.Interval = 1000
        '
        'setupWizard_ServerAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.selectionOkpic)
        Me.Controls.Add(Me.domain_web_ex)
        Me.Controls.Add(Me.server_web_addr_lbl)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.server_web_addr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_ServerAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.selectionOkpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents server_web_addr_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents server_web_addr As TextBox
    Friend WithEvents domain_web_ex As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents selectionOkpic As PictureBox
    Friend WithEvents TimerCheckIsOnline As Timer
End Class
