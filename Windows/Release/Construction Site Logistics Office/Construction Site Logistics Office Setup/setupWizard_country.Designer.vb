<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizard_country
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_country))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chooseCountry = New System.Windows.Forms.Label()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.show_all_lang = New System.Windows.Forms.CheckBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chooseCountry)
        Me.Panel1.Controls.Add(Me.btnContinueTxt)
        Me.Panel1.Controls.Add(Me.btnContinue)
        Me.Panel1.Controls.Add(Me.show_all_lang)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 788)
        Me.Panel1.TabIndex = 0
        '
        'chooseCountry
        '
        Me.chooseCountry.AutoSize = True
        Me.chooseCountry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseCountry.ForeColor = System.Drawing.Color.Gray
        Me.chooseCountry.Location = New System.Drawing.Point(208, 426)
        Me.chooseCountry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.chooseCountry.Name = "chooseCountry"
        Me.chooseCountry.Size = New System.Drawing.Size(215, 18)
        Me.chooseCountry.TabIndex = 11
        Me.chooseCountry.Text = "Choose the Country you're in"
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(451, 732)
        Me.btnContinueTxt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnContinueTxt.Name = "btnContinueTxt"
        Me.btnContinueTxt.Size = New System.Drawing.Size(72, 17)
        Me.btnContinueTxt.TabIndex = 8
        Me.btnContinueTxt.Text = "Continue"
        Me.btnContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContinue
        '
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.Location = New System.Drawing.Point(464, 686)
        Me.btnContinue.Margin = New System.Windows.Forms.Padding(4)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(47, 43)
        Me.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.TabStop = False
        '
        'show_all_lang
        '
        Me.show_all_lang.AutoSize = True
        Me.show_all_lang.Location = New System.Drawing.Point(312, 607)
        Me.show_all_lang.Margin = New System.Windows.Forms.Padding(4)
        Me.show_all_lang.Name = "show_all_lang"
        Me.show_all_lang.Size = New System.Drawing.Size(82, 21)
        Me.show_all_lang.TabIndex = 4
        Me.show_all_lang.Text = "Show all"
        Me.show_all_lang.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(312, 453)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(338, 146)
        Me.ListBox1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(212, 150)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(564, 266)
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
        Me.subtitle.Location = New System.Drawing.Point(4, 95)
        Me.subtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(1012, 35)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "we need to setup the platform and make things ready for you."
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(15, 8)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(1001, 68)
        Me.title.TabIndex = 0
        Me.title.Text = "Welcome"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_country
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 788)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "setupWizard_country"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents title As Label
    Friend WithEvents show_all_lang As CheckBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents subtitle As Label
    Friend WithEvents btnContinueTxt As Label
    Friend WithEvents btnContinue As PictureBox
    Friend WithEvents chooseCountry As Label
End Class
