Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupWizard_platformType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_platformType))
        Me.ownBtn = New System.Windows.Forms.CheckBox()
        Me.sharedBtn = New System.Windows.Forms.CheckBox()
        Me.ownConnectExisting = New System.Windows.Forms.RadioButton()
        Me.ownSetupNew = New System.Windows.Forms.RadioButton()
        Me.SharedConnectExisting = New System.Windows.Forms.RadioButton()
        Me.sharedSetupNew = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ownBtn
        '
        Me.ownBtn.AutoSize = True
        Me.ownBtn.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownBtn.ForeColor = System.Drawing.Color.Black
        Me.ownBtn.Location = New System.Drawing.Point(563, 582)
        Me.ownBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ownBtn.Name = "ownBtn"
        Me.ownBtn.Size = New System.Drawing.Size(447, 34)
        Me.ownBtn.TabIndex = 16
        Me.ownBtn.Text = "Own Dedicated Cloud Server"
        Me.ownBtn.UseVisualStyleBackColor = True
        '
        'sharedBtn
        '
        Me.sharedBtn.AutoSize = True
        Me.sharedBtn.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sharedBtn.ForeColor = System.Drawing.Color.Black
        Me.sharedBtn.Location = New System.Drawing.Point(563, 451)
        Me.sharedBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sharedBtn.Name = "sharedBtn"
        Me.sharedBtn.Size = New System.Drawing.Size(466, 34)
        Me.sharedBtn.TabIndex = 15
        Me.sharedBtn.Text = "Shared Cloud Server Platform"
        Me.sharedBtn.UseVisualStyleBackColor = True
        '
        'ownConnectExisting
        '
        Me.ownConnectExisting.AutoSize = True
        Me.ownConnectExisting.Enabled = False
        Me.ownConnectExisting.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownConnectExisting.ForeColor = System.Drawing.Color.Black
        Me.ownConnectExisting.Location = New System.Drawing.Point(626, 663)
        Me.ownConnectExisting.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ownConnectExisting.Name = "ownConnectExisting"
        Me.ownConnectExisting.Size = New System.Drawing.Size(379, 27)
        Me.ownConnectExisting.TabIndex = 14
        Me.ownConnectExisting.TabStop = True
        Me.ownConnectExisting.Text = "Connect to an existing platform"
        Me.ownConnectExisting.UseVisualStyleBackColor = True
        '
        'ownSetupNew
        '
        Me.ownSetupNew.AutoSize = True
        Me.ownSetupNew.Enabled = False
        Me.ownSetupNew.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownSetupNew.ForeColor = System.Drawing.Color.Black
        Me.ownSetupNew.Location = New System.Drawing.Point(626, 625)
        Me.ownSetupNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ownSetupNew.Name = "ownSetupNew"
        Me.ownSetupNew.Size = New System.Drawing.Size(254, 27)
        Me.ownSetupNew.TabIndex = 13
        Me.ownSetupNew.TabStop = True
        Me.ownSetupNew.Text = "SetUp a new platform"
        Me.ownSetupNew.UseVisualStyleBackColor = True
        '
        'SharedConnectExisting
        '
        Me.SharedConnectExisting.AutoSize = True
        Me.SharedConnectExisting.Enabled = False
        Me.SharedConnectExisting.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SharedConnectExisting.ForeColor = System.Drawing.Color.Black
        Me.SharedConnectExisting.Location = New System.Drawing.Point(626, 532)
        Me.SharedConnectExisting.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SharedConnectExisting.Name = "SharedConnectExisting"
        Me.SharedConnectExisting.Size = New System.Drawing.Size(379, 27)
        Me.SharedConnectExisting.TabIndex = 12
        Me.SharedConnectExisting.TabStop = True
        Me.SharedConnectExisting.Text = "Connect to an existing platform"
        Me.SharedConnectExisting.UseVisualStyleBackColor = True
        '
        'sharedSetupNew
        '
        Me.sharedSetupNew.AutoSize = True
        Me.sharedSetupNew.Enabled = False
        Me.sharedSetupNew.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sharedSetupNew.ForeColor = System.Drawing.Color.Black
        Me.sharedSetupNew.Location = New System.Drawing.Point(626, 495)
        Me.sharedSetupNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sharedSetupNew.Name = "sharedSetupNew"
        Me.sharedSetupNew.Size = New System.Drawing.Size(254, 27)
        Me.sharedSetupNew.TabIndex = 11
        Me.sharedSetupNew.TabStop = True
        Me.sharedSetupNew.Text = "SetUp a new platform"
        Me.sharedSetupNew.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(483, 48)
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
        'setupWizard_platformType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.ownBtn)
        Me.Controls.Add(Me.sharedBtn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ownConnectExisting)
        Me.Controls.Add(Me.sharedSetupNew)
        Me.Controls.Add(Me.SharedConnectExisting)
        Me.Controls.Add(Me.ownSetupNew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_platformType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ownConnectExisting As RadioButton
    Friend WithEvents ownSetupNew As RadioButton
    Friend WithEvents SharedConnectExisting As RadioButton
    Friend WithEvents sharedSetupNew As RadioButton
    Friend WithEvents ownBtn As CheckBox
    Friend WithEvents sharedBtn As CheckBox
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
