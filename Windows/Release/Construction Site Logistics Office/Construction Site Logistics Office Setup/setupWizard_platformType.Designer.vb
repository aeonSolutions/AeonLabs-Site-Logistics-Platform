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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_platformType))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ownBtn = New System.Windows.Forms.CheckBox()
        Me.sharedBtn = New System.Windows.Forms.CheckBox()
        Me.ownConnectExisting = New System.Windows.Forms.RadioButton()
        Me.ownSetupNew = New System.Windows.Forms.RadioButton()
        Me.SharedConnectExisting = New System.Windows.Forms.RadioButton()
        Me.sharedSetupNew = New System.Windows.Forms.RadioButton()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnBackTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ownBtn)
        Me.Panel1.Controls.Add(Me.sharedBtn)
        Me.Panel1.Controls.Add(Me.ownConnectExisting)
        Me.Panel1.Controls.Add(Me.ownSetupNew)
        Me.Panel1.Controls.Add(Me.SharedConnectExisting)
        Me.Panel1.Controls.Add(Me.sharedSetupNew)
        Me.Panel1.Controls.Add(Me.btnContinueTxt)
        Me.Panel1.Controls.Add(Me.btnBackTxt)
        Me.Panel1.Controls.Add(Me.btnContinue)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 788)
        Me.Panel1.TabIndex = 1
        '
        'ownBtn
        '
        Me.ownBtn.AutoSize = True
        Me.ownBtn.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownBtn.ForeColor = System.Drawing.Color.Gray
        Me.ownBtn.Location = New System.Drawing.Point(283, 548)
        Me.ownBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.ownBtn.Name = "ownBtn"
        Me.ownBtn.Size = New System.Drawing.Size(299, 26)
        Me.ownBtn.TabIndex = 16
        Me.ownBtn.Text = "Own Dedicated Cloud Server"
        Me.ownBtn.UseVisualStyleBackColor = True
        '
        'sharedBtn
        '
        Me.sharedBtn.AutoSize = True
        Me.sharedBtn.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sharedBtn.ForeColor = System.Drawing.Color.Gray
        Me.sharedBtn.Location = New System.Drawing.Point(283, 443)
        Me.sharedBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.sharedBtn.Name = "sharedBtn"
        Me.sharedBtn.Size = New System.Drawing.Size(309, 26)
        Me.sharedBtn.TabIndex = 15
        Me.sharedBtn.Text = "Shared Cloud Server Platform"
        Me.sharedBtn.UseVisualStyleBackColor = True
        '
        'ownConnectExisting
        '
        Me.ownConnectExisting.AutoSize = True
        Me.ownConnectExisting.Enabled = False
        Me.ownConnectExisting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownConnectExisting.ForeColor = System.Drawing.Color.Gray
        Me.ownConnectExisting.Location = New System.Drawing.Point(339, 613)
        Me.ownConnectExisting.Margin = New System.Windows.Forms.Padding(4)
        Me.ownConnectExisting.Name = "ownConnectExisting"
        Me.ownConnectExisting.Size = New System.Drawing.Size(250, 22)
        Me.ownConnectExisting.TabIndex = 14
        Me.ownConnectExisting.TabStop = True
        Me.ownConnectExisting.Text = "Connect to an existing platform"
        Me.ownConnectExisting.UseVisualStyleBackColor = True
        '
        'ownSetupNew
        '
        Me.ownSetupNew.AutoSize = True
        Me.ownSetupNew.Enabled = False
        Me.ownSetupNew.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ownSetupNew.ForeColor = System.Drawing.Color.Gray
        Me.ownSetupNew.Location = New System.Drawing.Point(339, 582)
        Me.ownSetupNew.Margin = New System.Windows.Forms.Padding(4)
        Me.ownSetupNew.Name = "ownSetupNew"
        Me.ownSetupNew.Size = New System.Drawing.Size(180, 22)
        Me.ownSetupNew.TabIndex = 13
        Me.ownSetupNew.TabStop = True
        Me.ownSetupNew.Text = "SetUp a new platform"
        Me.ownSetupNew.UseVisualStyleBackColor = True
        '
        'SharedConnectExisting
        '
        Me.SharedConnectExisting.AutoSize = True
        Me.SharedConnectExisting.Enabled = False
        Me.SharedConnectExisting.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SharedConnectExisting.ForeColor = System.Drawing.Color.Gray
        Me.SharedConnectExisting.Location = New System.Drawing.Point(339, 508)
        Me.SharedConnectExisting.Margin = New System.Windows.Forms.Padding(4)
        Me.SharedConnectExisting.Name = "SharedConnectExisting"
        Me.SharedConnectExisting.Size = New System.Drawing.Size(250, 22)
        Me.SharedConnectExisting.TabIndex = 12
        Me.SharedConnectExisting.TabStop = True
        Me.SharedConnectExisting.Text = "Connect to an existing platform"
        Me.SharedConnectExisting.UseVisualStyleBackColor = True
        '
        'sharedSetupNew
        '
        Me.sharedSetupNew.AutoSize = True
        Me.sharedSetupNew.Enabled = False
        Me.sharedSetupNew.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sharedSetupNew.ForeColor = System.Drawing.Color.Gray
        Me.sharedSetupNew.Location = New System.Drawing.Point(339, 478)
        Me.sharedSetupNew.Margin = New System.Windows.Forms.Padding(4)
        Me.sharedSetupNew.Name = "sharedSetupNew"
        Me.sharedSetupNew.Size = New System.Drawing.Size(180, 22)
        Me.sharedSetupNew.TabIndex = 11
        Me.sharedSetupNew.TabStop = True
        Me.sharedSetupNew.Text = "SetUp a new platform"
        Me.sharedSetupNew.UseVisualStyleBackColor = True
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(527, 732)
        Me.btnContinueTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnContinueTxt.Name = "btnContinueTxt"
        Me.btnContinueTxt.Size = New System.Drawing.Size(72, 17)
        Me.btnContinueTxt.TabIndex = 8
        Me.btnContinueTxt.Text = "Continue"
        Me.btnContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBackTxt
        '
        Me.btnBackTxt.AutoSize = True
        Me.btnBackTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnBackTxt.Location = New System.Drawing.Point(365, 732)
        Me.btnBackTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBackTxt.Name = "btnBackTxt"
        Me.btnBackTxt.Size = New System.Drawing.Size(43, 17)
        Me.btnBackTxt.TabIndex = 7
        Me.btnBackTxt.Text = "Back"
        Me.btnBackTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContinue
        '
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.Location = New System.Drawing.Point(540, 686)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(47, 43)
        Me.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(365, 686)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(47, 43)
        Me.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBack.TabIndex = 5
        Me.btnBack.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(212, 121)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(564, 302)
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
        Me.subtitle.Location = New System.Drawing.Point(15, 78)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1001, 39)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "Select between a Shared Cloud Server or a Private Cloud Server"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(19, 18)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(997, 60)
        Me.title.TabIndex = 0
        Me.title.Text = "Type of platform"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_platformType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setupWizard_platformType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnContinueTxt As Label
    Friend WithEvents btnBackTxt As Label
    Friend WithEvents btnContinue As PictureBox
    Friend WithEvents btnBack As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents subtitle As Label
    Friend WithEvents title As Label
    Friend WithEvents ownConnectExisting As RadioButton
    Friend WithEvents ownSetupNew As RadioButton
    Friend WithEvents SharedConnectExisting As RadioButton
    Friend WithEvents sharedSetupNew As RadioButton
    Friend WithEvents ownBtn As CheckBox
    Friend WithEvents sharedBtn As CheckBox
End Class
