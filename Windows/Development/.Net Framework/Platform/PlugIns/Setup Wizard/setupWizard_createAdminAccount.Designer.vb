Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizard_createAdminAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_createAdminAccount))
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.id_verify_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.id_verify = New System.Windows.Forms.TextBox()
        Me.id_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.id = New System.Windows.Forms.TextBox()
        Me.full_name_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.full_name = New System.Windows.Forms.TextBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(459, 230)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(182, 180)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'id_verify_lbl
        '
        Me.id_verify_lbl.AutoSize = True
        Me.id_verify_lbl.BackColor = System.Drawing.Color.Transparent
        Me.id_verify_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_verify_lbl.ForeColor = System.Drawing.Color.Black
        Me.id_verify_lbl.Location = New System.Drawing.Point(674, 350)
        Me.id_verify_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.id_verify_lbl.Name = "id_verify_lbl"
        Me.id_verify_lbl.Size = New System.Drawing.Size(301, 23)
        Me.id_verify_lbl.TabIndex = 18
        Me.id_verify_lbl.Text = "Verify authentication code"
        '
        'id_verify
        '
        Me.id_verify.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_verify.Location = New System.Drawing.Point(678, 378)
        Me.id_verify.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.id_verify.Name = "id_verify"
        Me.id_verify.Size = New System.Drawing.Size(352, 28)
        Me.id_verify.TabIndex = 17
        '
        'id_lbl
        '
        Me.id_lbl.AutoSize = True
        Me.id_lbl.BackColor = System.Drawing.Color.Transparent
        Me.id_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id_lbl.ForeColor = System.Drawing.Color.Black
        Me.id_lbl.Location = New System.Drawing.Point(674, 285)
        Me.id_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.id_lbl.Name = "id_lbl"
        Me.id_lbl.Size = New System.Drawing.Size(235, 23)
        Me.id_lbl.TabIndex = 16
        Me.id_lbl.Text = "Authentication code"
        '
        'id
        '
        Me.id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(678, 313)
        Me.id.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(352, 28)
        Me.id.TabIndex = 15
        '
        'full_name_lbl
        '
        Me.full_name_lbl.AutoSize = True
        Me.full_name_lbl.BackColor = System.Drawing.Color.Transparent
        Me.full_name_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.full_name_lbl.ForeColor = System.Drawing.Color.Black
        Me.full_name_lbl.Location = New System.Drawing.Point(674, 222)
        Me.full_name_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.full_name_lbl.Name = "full_name_lbl"
        Me.full_name_lbl.Size = New System.Drawing.Size(113, 23)
        Me.full_name_lbl.TabIndex = 11
        Me.full_name_lbl.Text = "Full name"
        '
        'full_name
        '
        Me.full_name.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.full_name.Location = New System.Drawing.Point(678, 248)
        Me.full_name.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.full_name.Name = "full_name"
        Me.full_name.Size = New System.Drawing.Size(352, 28)
        Me.full_name.TabIndex = 10
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'setupWizard_createAdminAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.id_verify_lbl)
        Me.Controls.Add(Me.id_verify)
        Me.Controls.Add(Me.full_name)
        Me.Controls.Add(Me.id_lbl)
        Me.Controls.Add(Me.full_name_lbl)
        Me.Controls.Add(Me.id)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_createAdminAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents full_name_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents full_name As TextBox
    Friend WithEvents id_verify_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents id_verify As TextBox
    Friend WithEvents id_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents id As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
