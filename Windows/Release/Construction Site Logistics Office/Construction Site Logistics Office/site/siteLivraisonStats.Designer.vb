<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class siteLivraisonStats
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.quantity = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.materialPreSelection = New System.Windows.Forms.ComboBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.divider = New System.Windows.Forms.Label()
        Me.material = New System.Windows.Forms.TextBox()
        Me.material_lbl = New System.Windows.Forms.Label()
        Me.calcLink = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.calcLink)
        Me.Panel1.Controls.Add(Me.quantity)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.materialPreSelection)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.material)
        Me.Panel1.Controls.Add(Me.material_lbl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(518, 188)
        Me.Panel1.TabIndex = 342
        '
        'quantity
        '
        Me.quantity.AutoSize = True
        Me.quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantity.Location = New System.Drawing.Point(11, 129)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(62, 13)
        Me.quantity.TabIndex = 341
        Me.quantity.Text = "Quantidade"
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(3, 5)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(179, 20)
        Me.title.TabIndex = 313
        Me.title.Text = "Stats Guia de Remessa"
        '
        'materialPreSelection
        '
        Me.materialPreSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.materialPreSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.materialPreSelection.FormattingEnabled = True
        Me.materialPreSelection.Items.AddRange(New Object() {"Acier", "Béton", "Bloc Béton 9", "Bloc Béton 14", "Bloc Béton 19", "Bois de Coffrage", "Murs / Pre Murs", "Pré Dalles", "Silico Calcaire", "Seuils", "Stepoc", "Treillis", "Ytong", "Hourdis"})
        Me.materialPreSelection.Location = New System.Drawing.Point(273, 65)
        Me.materialPreSelection.Name = "materialPreSelection"
        Me.materialPreSelection.Size = New System.Drawing.Size(223, 21)
        Me.materialPreSelection.TabIndex = 340
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(415, 143)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 338
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.Location = New System.Drawing.Point(5, 29)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(496, 4)
        Me.divider.TabIndex = 314
        '
        'material
        '
        Me.material.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material.Location = New System.Drawing.Point(11, 65)
        Me.material.Name = "material"
        Me.material.Size = New System.Drawing.Size(256, 20)
        Me.material.TabIndex = 315
        '
        'material_lbl
        '
        Me.material_lbl.AutoSize = True
        Me.material_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.material_lbl.Location = New System.Drawing.Point(8, 48)
        Me.material_lbl.Name = "material_lbl"
        Me.material_lbl.Size = New System.Drawing.Size(44, 13)
        Me.material_lbl.TabIndex = 316
        Me.material_lbl.Text = "Material"
        '
        'calcLink
        '
        Me.calcLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.calcLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calcLink.Location = New System.Drawing.Point(294, 89)
        Me.calcLink.Name = "calcLink"
        Me.calcLink.Size = New System.Drawing.Size(202, 16)
        Me.calcLink.TabIndex = 342
        Me.calcLink.TabStop = True
        Me.calcLink.Text = "calcular"
        Me.calcLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'siteLivraisonStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 188)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "siteLivraisonStats"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents title As Label
    Friend WithEvents materialPreSelection As ComboBox
    Friend WithEvents closeBtn As Button
    Friend WithEvents divider As Label
    Friend WithEvents material As TextBox
    Friend WithEvents material_lbl As Label
    Friend WithEvents quantity As Label
    Friend WithEvents calcLink As LinkLabel
End Class
