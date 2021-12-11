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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.db_pwd_lbl = New System.Windows.Forms.Label()
        Me.db_pwd = New System.Windows.Forms.TextBox()
        Me.db_user_lbl = New System.Windows.Forms.Label()
        Me.db_user = New System.Windows.Forms.TextBox()
        Me.db_name_lbl = New System.Windows.Forms.Label()
        Me.db_name = New System.Windows.Forms.TextBox()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnBackTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.db_pwd_lbl)
        Me.Panel1.Controls.Add(Me.db_pwd)
        Me.Panel1.Controls.Add(Me.db_user_lbl)
        Me.Panel1.Controls.Add(Me.db_user)
        Me.Panel1.Controls.Add(Me.db_name_lbl)
        Me.Panel1.Controls.Add(Me.db_name)
        Me.Panel1.Controls.Add(Me.btnContinueTxt)
        Me.Panel1.Controls.Add(Me.btnBackTxt)
        Me.Panel1.Controls.Add(Me.btnContinue)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(775, 640)
        Me.Panel1.TabIndex = 1
        '
        'db_pwd_lbl
        '
        Me.db_pwd_lbl.AutoSize = True
        Me.db_pwd_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_pwd_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_pwd_lbl.Location = New System.Drawing.Point(271, 477)
        Me.db_pwd_lbl.Name = "db_pwd_lbl"
        Me.db_pwd_lbl.Size = New System.Drawing.Size(163, 15)
        Me.db_pwd_lbl.TabIndex = 18
        Me.db_pwd_lbl.Text = "DataBase access password"
        '
        'db_pwd
        '
        Me.db_pwd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_pwd.Location = New System.Drawing.Point(274, 495)
        Me.db_pwd.Name = "db_pwd"
        Me.db_pwd.Size = New System.Drawing.Size(236, 21)
        Me.db_pwd.TabIndex = 17
        '
        'db_user_lbl
        '
        Me.db_user_lbl.AutoSize = True
        Me.db_user_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_user_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_user_lbl.Location = New System.Drawing.Point(271, 435)
        Me.db_user_lbl.Name = "db_user_lbl"
        Me.db_user_lbl.Size = New System.Drawing.Size(165, 15)
        Me.db_user_lbl.TabIndex = 16
        Me.db_user_lbl.Text = "DataBase access username"
        '
        'db_user
        '
        Me.db_user.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_user.Location = New System.Drawing.Point(274, 453)
        Me.db_user.Name = "db_user"
        Me.db_user.Size = New System.Drawing.Size(236, 21)
        Me.db_user.TabIndex = 15
        '
        'db_name_lbl
        '
        Me.db_name_lbl.AutoSize = True
        Me.db_name_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_name_lbl.ForeColor = System.Drawing.Color.Black
        Me.db_name_lbl.Location = New System.Drawing.Point(271, 393)
        Me.db_name_lbl.Name = "db_name_lbl"
        Me.db_name_lbl.Size = New System.Drawing.Size(97, 15)
        Me.db_name_lbl.TabIndex = 11
        Me.db_name_lbl.Text = "DataBase name"
        '
        'db_name
        '
        Me.db_name.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.db_name.Location = New System.Drawing.Point(274, 411)
        Me.db_name.Name = "db_name"
        Me.db_name.Size = New System.Drawing.Size(236, 21)
        Me.db_name.TabIndex = 10
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(395, 595)
        Me.btnContinueTxt.Name = "btnContinueTxt"
        Me.btnContinueTxt.Size = New System.Drawing.Size(57, 13)
        Me.btnContinueTxt.TabIndex = 8
        Me.btnContinueTxt.Text = "Continue"
        Me.btnContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBackTxt
        '
        Me.btnBackTxt.AutoSize = True
        Me.btnBackTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnBackTxt.Location = New System.Drawing.Point(274, 595)
        Me.btnBackTxt.Name = "btnBackTxt"
        Me.btnBackTxt.Size = New System.Drawing.Size(36, 13)
        Me.btnBackTxt.TabIndex = 7
        Me.btnBackTxt.Text = "Back"
        Me.btnBackTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContinue
        '
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.Location = New System.Drawing.Point(405, 557)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(35, 35)
        Me.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(274, 557)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(210, 98)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(361, 266)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'subtitle
        '
        Me.subtitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subtitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.ForeColor = System.Drawing.Color.Gray
        Me.subtitle.Location = New System.Drawing.Point(11, 62)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(751, 33)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "Fill out the following information to create the Database on server"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(11, 15)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(751, 47)
        Me.title.TabIndex = 0
        Me.title.Text = "Database configuration"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_createDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 640)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "setupWizard_createDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnContinueTxt As Label
    Friend WithEvents btnBackTxt As Label
    Friend WithEvents btnContinue As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents subtitle As Label
    Friend WithEvents title As Label
    Friend WithEvents db_name_lbl As Label
    Friend WithEvents db_name As TextBox
    Friend WithEvents db_pwd_lbl As Label
    Friend WithEvents db_pwd As TextBox
    Friend WithEvents db_user_lbl As Label
    Friend WithEvents db_user As TextBox
End Class
