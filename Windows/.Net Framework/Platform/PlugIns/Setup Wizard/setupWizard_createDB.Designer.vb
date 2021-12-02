Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizard_createDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_createDB))
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.db_name = New System.Windows.Forms.TextBox()
        Me.db_name_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.db_user = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.db_user_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.db_pwd = New System.Windows.Forms.TextBox()
        Me.db_pwd_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'db_name
        '
        Me.db_name.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_name.Location = New System.Drawing.Point(583, 526)
        Me.db_name.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.db_name.Name = "db_name"
        Me.db_name.Size = New System.Drawing.Size(352, 28)
        Me.db_name.TabIndex = 10
        '
        'db_name_lbl
        '
        Me.db_name_lbl.AutoSize = True
        Me.db_name_lbl.BackColor = System.Drawing.Color.Transparent
        Me.db_name_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_name_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_name_lbl.Location = New System.Drawing.Point(578, 499)
        Me.db_name_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.db_name_lbl.Name = "db_name_lbl"
        Me.db_name_lbl.Size = New System.Drawing.Size(159, 23)
        Me.db_name_lbl.TabIndex = 11
        Me.db_name_lbl.Text = "DataBase name"
        '
        'db_user
        '
        Me.db_user.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_user.Location = New System.Drawing.Point(583, 591)
        Me.db_user.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.db_user.Name = "db_user"
        Me.db_user.Size = New System.Drawing.Size(352, 28)
        Me.db_user.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(487, 45)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(542, 409)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'db_user_lbl
        '
        Me.db_user_lbl.AutoSize = True
        Me.db_user_lbl.BackColor = System.Drawing.Color.Transparent
        Me.db_user_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_user_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_user_lbl.Location = New System.Drawing.Point(578, 563)
        Me.db_user_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.db_user_lbl.Name = "db_user_lbl"
        Me.db_user_lbl.Size = New System.Drawing.Size(274, 23)
        Me.db_user_lbl.TabIndex = 16
        Me.db_user_lbl.Text = "DataBase access username"
        '
        'db_pwd
        '
        Me.db_pwd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_pwd.Location = New System.Drawing.Point(583, 656)
        Me.db_pwd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.db_pwd.Name = "db_pwd"
        Me.db_pwd.Size = New System.Drawing.Size(352, 28)
        Me.db_pwd.TabIndex = 17
        '
        'db_pwd_lbl
        '
        Me.db_pwd_lbl.AutoSize = True
        Me.db_pwd_lbl.BackColor = System.Drawing.Color.Transparent
        Me.db_pwd_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_pwd_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_pwd_lbl.Location = New System.Drawing.Point(578, 628)
        Me.db_pwd_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.db_pwd_lbl.Name = "db_pwd_lbl"
        Me.db_pwd_lbl.Size = New System.Drawing.Size(275, 23)
        Me.db_pwd_lbl.TabIndex = 18
        Me.db_pwd_lbl.Text = "DataBase access password"
        '
        'setupWizard_createDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.db_pwd_lbl)
        Me.Controls.Add(Me.db_pwd)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.db_user_lbl)
        Me.Controls.Add(Me.db_name)
        Me.Controls.Add(Me.db_name_lbl)
        Me.Controls.Add(Me.db_user)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_createDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents db_name As TextBox
    Friend WithEvents db_name_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents db_user As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents db_user_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents db_pwd As TextBox
    Friend WithEvents db_pwd_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
End Class
