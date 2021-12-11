<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_locate_worker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_locate_worker))
        Me.searchBoxBtn = New System.Windows.Forms.PictureBox()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.seeInfo = New System.Windows.Forms.LinkLabel()
        Me.workerGroupBox = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.contents = New System.Windows.Forms.Label()
        Me.photobox = New System.Windows.Forms.PictureBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.workerGroupBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'searchBoxBtn
        '
        Me.searchBoxBtn.Image = CType(resources.GetObject("searchBoxBtn.Image"), System.Drawing.Image)
        Me.searchBoxBtn.InitialImage = Nothing
        Me.searchBoxBtn.Location = New System.Drawing.Point(326, 45)
        Me.searchBoxBtn.Name = "searchBoxBtn"
        Me.searchBoxBtn.Size = New System.Drawing.Size(20, 20)
        Me.searchBoxBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.searchBoxBtn.TabIndex = 200
        Me.searchBoxBtn.TabStop = False
        '
        'searchbox
        '
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(9, 45)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(311, 21)
        Me.searchbox.TabIndex = 199
        '
        'listview_works
        '
        Me.listview_works.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.Location = New System.Drawing.Point(9, 71)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.ScrollAlwaysVisible = True
        Me.listview_works.Size = New System.Drawing.Size(350, 273)
        Me.listview_works.TabIndex = 198
        '
        'seeInfo
        '
        Me.seeInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.seeInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seeInfo.Location = New System.Drawing.Point(11, 351)
        Me.seeInfo.Name = "seeInfo"
        Me.seeInfo.Size = New System.Drawing.Size(348, 20)
        Me.seeInfo.TabIndex = 203
        Me.seeInfo.TabStop = True
        Me.seeInfo.Text = "Ver informação"
        Me.seeInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'workerGroupBox
        '
        Me.workerGroupBox.Controls.Add(Me.Panel1)
        Me.workerGroupBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerGroupBox.Location = New System.Drawing.Point(376, 45)
        Me.workerGroupBox.Name = "workerGroupBox"
        Me.workerGroupBox.Size = New System.Drawing.Size(525, 297)
        Me.workerGroupBox.TabIndex = 204
        Me.workerGroupBox.TabStop = False
        Me.workerGroupBox.Text = "Informação do trabalhador"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.contents)
        Me.Panel1.Controls.Add(Me.photobox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(519, 277)
        Me.Panel1.TabIndex = 0
        '
        'contents
        '
        Me.contents.AutoSize = True
        Me.contents.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contents.Location = New System.Drawing.Point(181, 6)
        Me.contents.Name = "contents"
        Me.contents.Size = New System.Drawing.Size(88, 13)
        Me.contents.TabIndex = 206
        Me.contents.Text = "Contents here"
        '
        'photobox
        '
        Me.photobox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.photobox.Image = CType(resources.GetObject("photobox.Image"), System.Drawing.Image)
        Me.photobox.Location = New System.Drawing.Point(3, 3)
        Me.photobox.Name = "photobox"
        Me.photobox.Size = New System.Drawing.Size(172, 172)
        Me.photobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.photobox.TabIndex = 205
        Me.photobox.TabStop = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(812, 348)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 337
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.divider)
        Me.Panel2.Controls.Add(Me.title)
        Me.Panel2.Controls.Add(Me.searchbox)
        Me.Panel2.Controls.Add(Me.closeBtn)
        Me.Panel2.Controls.Add(Me.listview_works)
        Me.Panel2.Controls.Add(Me.workerGroupBox)
        Me.Panel2.Controls.Add(Me.searchBoxBtn)
        Me.Panel2.Controls.Add(Me.seeInfo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(914, 383)
        Me.Panel2.TabIndex = 338
        Me.Panel2.Visible = False
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(9, 28)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(876, 4)
        Me.divider.TabIndex = 339
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(11, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(157, 20)
        Me.title.TabIndex = 338
        Me.title.Text = "Localizar trabalhador"
        '
        'frm_locate_worker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 383)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_locate_worker"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Localizar trabalhador"
        CType(Me.searchBoxBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.workerGroupBox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.photobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents searchBoxBtn As PictureBox
    Friend WithEvents searchbox As TextBox
    Friend WithEvents listview_works As ListBox
    Friend WithEvents seeInfo As LinkLabel
    Friend WithEvents workerGroupBox As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents contents As Label
    Friend WithEvents photobox As PictureBox
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
End Class
