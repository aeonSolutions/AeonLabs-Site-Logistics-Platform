<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class documentos_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(documentos_frm))
        Me.listview_works = New System.Windows.Forms.ListBox()
        Me.updateLink = New System.Windows.Forms.LinkLabel()
        Me.FontDlg = New System.Windows.Forms.FontDialog()
        Me.ColorDlg = New System.Windows.Forms.ColorDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.FontToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.FontColorToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BoldToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.UnderlineToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LeftToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CenterToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RightToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BulletsToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SearchIconBtn = New System.Windows.Forms.PictureBox()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.documentTitle = New System.Windows.Forms.Label()
        Me.doc_type = New System.Windows.Forms.ComboBox()
        Me.richtxt = New ConstructionSiteLogistics.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SearchIconBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listview_works
        '
        Me.listview_works.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listview_works.Enabled = False
        Me.listview_works.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview_works.FormattingEnabled = True
        Me.listview_works.HorizontalScrollbar = True
        Me.listview_works.Location = New System.Drawing.Point(12, 103)
        Me.listview_works.Name = "listview_works"
        Me.listview_works.Size = New System.Drawing.Size(427, 446)
        Me.listview_works.TabIndex = 38
        Me.listview_works.Visible = False
        '
        'updateLink
        '
        Me.updateLink.AutoSize = True
        Me.updateLink.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateLink.Location = New System.Drawing.Point(376, 552)
        Me.updateLink.Name = "updateLink"
        Me.updateLink.Size = New System.Drawing.Size(63, 13)
        Me.updateLink.TabIndex = 37
        Me.updateLink.TabStop = True
        Me.updateLink.Text = "Actualizar"
        Me.updateLink.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.richtxt)
        Me.Panel1.Location = New System.Drawing.Point(445, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(927, 539)
        Me.Panel1.TabIndex = 40
        Me.Panel1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator, Me.FontToolStripButton, Me.FontColorToolStripButton, Me.BoldToolStripButton, Me.UnderlineToolStripButton, Me.ToolStripSeparator4, Me.LeftToolStripButton, Me.CenterToolStripButton, Me.RightToolStripButton, Me.ToolStripSeparator3, Me.BulletsToolStripButton, Me.ToolStripSeparator2, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.toolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(925, 25)
        Me.ToolStrip1.TabIndex = 42
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        Me.NewToolStripButton.Visible = False
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        Me.OpenToolStripButton.Visible = False
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        Me.SaveToolStripButton.Visible = False
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        Me.PrintToolStripButton.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        Me.toolStripSeparator.Visible = False
        '
        'FontToolStripButton
        '
        Me.FontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontToolStripButton.Image = CType(resources.GetObject("FontToolStripButton.Image"), System.Drawing.Image)
        Me.FontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontToolStripButton.Name = "FontToolStripButton"
        Me.FontToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontToolStripButton.Text = "Font"
        '
        'FontColorToolStripButton
        '
        Me.FontColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontColorToolStripButton.Image = CType(resources.GetObject("FontColorToolStripButton.Image"), System.Drawing.Image)
        Me.FontColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontColorToolStripButton.Name = "FontColorToolStripButton"
        Me.FontColorToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontColorToolStripButton.Text = "Font Color"
        '
        'BoldToolStripButton
        '
        Me.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BoldToolStripButton.Image = CType(resources.GetObject("BoldToolStripButton.Image"), System.Drawing.Image)
        Me.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BoldToolStripButton.Name = "BoldToolStripButton"
        Me.BoldToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BoldToolStripButton.Text = "Bold"
        '
        'UnderlineToolStripButton
        '
        Me.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnderlineToolStripButton.Image = CType(resources.GetObject("UnderlineToolStripButton.Image"), System.Drawing.Image)
        Me.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnderlineToolStripButton.Name = "UnderlineToolStripButton"
        Me.UnderlineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnderlineToolStripButton.Text = "Underline"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'LeftToolStripButton
        '
        Me.LeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton.Image = CType(resources.GetObject("LeftToolStripButton.Image"), System.Drawing.Image)
        Me.LeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton.Name = "LeftToolStripButton"
        Me.LeftToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton.Text = "Left"
        '
        'CenterToolStripButton
        '
        Me.CenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CenterToolStripButton.Image = CType(resources.GetObject("CenterToolStripButton.Image"), System.Drawing.Image)
        Me.CenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CenterToolStripButton.Name = "CenterToolStripButton"
        Me.CenterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CenterToolStripButton.Text = "Center"
        '
        'RightToolStripButton
        '
        Me.RightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RightToolStripButton.Image = CType(resources.GetObject("RightToolStripButton.Image"), System.Drawing.Image)
        Me.RightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RightToolStripButton.Name = "RightToolStripButton"
        Me.RightToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RightToolStripButton.Text = "Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BulletsToolStripButton
        '
        Me.BulletsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BulletsToolStripButton.Image = CType(resources.GetObject("BulletsToolStripButton.Image"), System.Drawing.Image)
        Me.BulletsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BulletsToolStripButton.Name = "BulletsToolStripButton"
        Me.BulletsToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BulletsToolStripButton.Text = "Bullets"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        Me.CutToolStripButton.Visible = False
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        Me.CopyToolStripButton.Visible = False
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        Me.PasteToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SearchIconBtn
        '
        Me.SearchIconBtn.Enabled = False
        Me.SearchIconBtn.Image = CType(resources.GetObject("SearchIconBtn.Image"), System.Drawing.Image)
        Me.SearchIconBtn.InitialImage = Nothing
        Me.SearchIconBtn.Location = New System.Drawing.Point(418, 76)
        Me.SearchIconBtn.Name = "SearchIconBtn"
        Me.SearchIconBtn.Size = New System.Drawing.Size(21, 21)
        Me.SearchIconBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SearchIconBtn.TabIndex = 199
        Me.SearchIconBtn.TabStop = False
        Me.SearchIconBtn.Visible = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(12, 57)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(56, 13)
        Me.searchTitle.TabIndex = 197
        Me.searchTitle.Text = "Procurar"
        Me.searchTitle.Visible = False
        '
        'searchbox
        '
        Me.searchbox.Enabled = False
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(12, 76)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(400, 21)
        Me.searchbox.TabIndex = 198
        Me.searchbox.Visible = False
        '
        'documentTitle
        '
        Me.documentTitle.AutoSize = True
        Me.documentTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.documentTitle.Location = New System.Drawing.Point(12, 12)
        Me.documentTitle.Name = "documentTitle"
        Me.documentTitle.Size = New System.Drawing.Size(72, 13)
        Me.documentTitle.TabIndex = 200
        Me.documentTitle.Text = "Documento"
        Me.documentTitle.Visible = False
        '
        'doc_type
        '
        Me.doc_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.doc_type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doc_type.FormattingEnabled = True
        Me.doc_type.Items.AddRange(New Object() {"Seleccione o tipo de documento", "Acordo de Destacamento", "Comunicação ACT", "Ficha de Inscrição", "Contrato"})
        Me.doc_type.Location = New System.Drawing.Point(12, 29)
        Me.doc_type.Name = "doc_type"
        Me.doc_type.Size = New System.Drawing.Size(400, 21)
        Me.doc_type.TabIndex = 201
        '
        'richtxt
        '
        Me.richtxt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.richtxt.Location = New System.Drawing.Point(7, 28)
        Me.richtxt.Name = "richtxt"
        Me.richtxt.Size = New System.Drawing.Size(912, 635)
        Me.richtxt.TabIndex = 41
        Me.richtxt.Text = ""
        '
        'documentos_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1504, 610)
        Me.Controls.Add(Me.doc_type)
        Me.Controls.Add(Me.documentTitle)
        Me.Controls.Add(Me.SearchIconBtn)
        Me.Controls.Add(Me.searchTitle)
        Me.Controls.Add(Me.searchbox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.listview_works)
        Me.Controls.Add(Me.updateLink)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "documentos_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documentos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SearchIconBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents listview_works As ListBox
    Friend WithEvents updateLink As LinkLabel
    Friend WithEvents FontDlg As FontDialog
    Friend WithEvents ColorDlg As ColorDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NewToolStripButton As ToolStripButton
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents FontToolStripButton As ToolStripButton
    Friend WithEvents FontColorToolStripButton As ToolStripButton
    Friend WithEvents BoldToolStripButton As ToolStripButton
    Friend WithEvents UnderlineToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents LeftToolStripButton As ToolStripButton
    Friend WithEvents CenterToolStripButton As ToolStripButton
    Friend WithEvents RightToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BulletsToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CutToolStripButton As ToolStripButton
    Friend WithEvents CopyToolStripButton As ToolStripButton
    Friend WithEvents PasteToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents richtxt As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents SearchIconBtn As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents documentTitle As Label
    Friend WithEvents doc_type As ComboBox
End Class
