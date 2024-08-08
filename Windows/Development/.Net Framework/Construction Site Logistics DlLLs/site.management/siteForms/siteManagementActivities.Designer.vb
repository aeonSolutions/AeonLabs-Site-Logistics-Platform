Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class siteManagementActivitiesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(siteManagementActivitiesForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lateralPanel = New System.Windows.Forms.Panel()
        Me.editModeBtn = New System.Windows.Forms.PictureBox()
        Me.addNewBtn = New System.Windows.Forms.PictureBox()
        Me.delBtn = New System.Windows.Forms.PictureBox()
        Me.saveBtn = New System.Windows.Forms.PictureBox()
        Me.listBoxSite = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.sideToggleBtn = New System.Windows.Forms.PictureBox()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.loadTableBtn = New System.Windows.Forms.PictureBox()
        Me.TablePanel = New System.Windows.Forms.Panel()
        Me.title = New System.Windows.Forms.Label()
        Me.divider = New System.Windows.Forms.Label()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.lateralPanel.SuspendLayout()
        CType(Me.editModeBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addNewBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TablePanel.SuspendLayout()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lateralPanel
        '
        Me.lateralPanel.Controls.Add(Me.editModeBtn)
        Me.lateralPanel.Controls.Add(Me.addNewBtn)
        Me.lateralPanel.Controls.Add(Me.delBtn)
        Me.lateralPanel.Controls.Add(Me.saveBtn)
        Me.lateralPanel.Controls.Add(Me.listBoxSite)
        Me.lateralPanel.Controls.Add(Me.Panel3)
        Me.lateralPanel.Controls.Add(Me.site_lbl)
        Me.lateralPanel.Controls.Add(Me.loadTableBtn)
        Me.lateralPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.lateralPanel.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lateralPanel.Name = "lateralPanel"
        Me.lateralPanel.Size = New System.Drawing.Size(405, 1226)
        Me.lateralPanel.TabIndex = 330
        Me.lateralPanel.Visible = False
        '
        'editModeBtn
        '
        Me.editModeBtn.Enabled = False
        Me.editModeBtn.Image = CType(resources.GetObject("editModeBtn.Image"), System.Drawing.Image)
        Me.editModeBtn.Location = New System.Drawing.Point(109, 81)
        Me.editModeBtn.Name = "editModeBtn"
        Me.editModeBtn.Size = New System.Drawing.Size(50, 50)
        Me.editModeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.editModeBtn.TabIndex = 375
        Me.editModeBtn.TabStop = False
        '
        'addNewBtn
        '
        Me.addNewBtn.Enabled = False
        Me.addNewBtn.Image = CType(resources.GetObject("addNewBtn.Image"), System.Drawing.Image)
        Me.addNewBtn.Location = New System.Drawing.Point(53, 81)
        Me.addNewBtn.Name = "addNewBtn"
        Me.addNewBtn.Size = New System.Drawing.Size(50, 50)
        Me.addNewBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.addNewBtn.TabIndex = 374
        Me.addNewBtn.TabStop = False
        '
        'delBtn
        '
        Me.delBtn.Enabled = False
        Me.delBtn.Image = CType(resources.GetObject("delBtn.Image"), System.Drawing.Image)
        Me.delBtn.Location = New System.Drawing.Point(182, 81)
        Me.delBtn.Name = "delBtn"
        Me.delBtn.Size = New System.Drawing.Size(50, 50)
        Me.delBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.delBtn.TabIndex = 373
        Me.delBtn.TabStop = False
        '
        'saveBtn
        '
        Me.saveBtn.Enabled = False
        Me.saveBtn.Image = CType(resources.GetObject("saveBtn.Image"), System.Drawing.Image)
        Me.saveBtn.Location = New System.Drawing.Point(257, 81)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(50, 50)
        Me.saveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.saveBtn.TabIndex = 372
        Me.saveBtn.TabStop = False
        '
        'listBoxSite
        '
        Me.listBoxSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listBoxSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listBoxSite.FormattingEnabled = True
        Me.listBoxSite.Location = New System.Drawing.Point(52, 43)
        Me.listBoxSite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.listBoxSite.Name = "listBoxSite"
        Me.listBoxSite.Size = New System.Drawing.Size(332, 28)
        Me.listBoxSite.TabIndex = 365
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Ivory
        Me.Panel3.Controls.Add(Me.sideToggleBtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(42, 1226)
        Me.Panel3.TabIndex = 364
        '
        'sideToggleBtn
        '
        Me.sideToggleBtn.Image = CType(resources.GetObject("sideToggleBtn.Image"), System.Drawing.Image)
        Me.sideToggleBtn.InitialImage = Nothing
        Me.sideToggleBtn.Location = New System.Drawing.Point(3, 3)
        Me.sideToggleBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sideToggleBtn.Name = "sideToggleBtn"
        Me.sideToggleBtn.Size = New System.Drawing.Size(36, 40)
        Me.sideToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sideToggleBtn.TabIndex = 363
        Me.sideToggleBtn.TabStop = False
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(48, 14)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(66, 25)
        Me.site_lbl.TabIndex = 0
        Me.site_lbl.Text = "Obra"
        '
        'loadTableBtn
        '
        Me.loadTableBtn.Image = CType(resources.GetObject("loadTableBtn.Image"), System.Drawing.Image)
        Me.loadTableBtn.InitialImage = Nothing
        Me.loadTableBtn.Location = New System.Drawing.Point(334, 81)
        Me.loadTableBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.loadTableBtn.Name = "loadTableBtn"
        Me.loadTableBtn.Size = New System.Drawing.Size(50, 50)
        Me.loadTableBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadTableBtn.TabIndex = 323
        Me.loadTableBtn.TabStop = False
        '
        'TablePanel
        '
        Me.TablePanel.Controls.Add(Me.title)
        Me.TablePanel.Controls.Add(Me.divider)
        Me.TablePanel.Controls.Add(Me.datatable)
        Me.TablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TablePanel.Location = New System.Drawing.Point(405, 0)
        Me.TablePanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TablePanel.Name = "TablePanel"
        Me.TablePanel.Size = New System.Drawing.Size(1692, 1226)
        Me.TablePanel.TabIndex = 332
        Me.TablePanel.Visible = False
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(9, 8)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(281, 29)
        Me.title.TabIndex = 325
        Me.title.Text = "Work Activities at the Site"
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(10, 46)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1624, 5)
        Me.divider.TabIndex = 326
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
        Me.datatable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datatable.BackgroundColor = System.Drawing.Color.White
        Me.datatable.CausesValidation = False
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle1
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(10, 72)
        Me.datatable.Margin = New System.Windows.Forms.Padding(6)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.Size = New System.Drawing.Size(1662, 1134)
        Me.datatable.TabIndex = 324
        '
        'siteManagementActivitiesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2097, 1226)
        Me.ControlBox = False
        Me.Controls.Add(Me.TablePanel)
        Me.Controls.Add(Me.lateralPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "siteManagementActivitiesForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Management Map"
        Me.TopMost = True
        Me.lateralPanel.ResumeLayout(False)
        Me.lateralPanel.PerformLayout()
        CType(Me.editModeBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addNewBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.delBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.saveBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TablePanel.ResumeLayout(False)
        Me.TablePanel.PerformLayout()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lateralPanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents sideToggleBtn As PictureBox
    Friend WithEvents site_lbl As Label
    Friend WithEvents loadTableBtn As PictureBox
    Friend WithEvents TablePanel As Panel
    Friend WithEvents datatable As DataGridView
    Friend WithEvents listBoxSite As ComboBox
    Friend WithEvents title As Label
    Friend WithEvents divider As Label
    Friend WithEvents delBtn As PictureBox
    Friend WithEvents saveBtn As PictureBox
    Friend WithEvents addNewBtn As PictureBox
    Friend WithEvents editModeBtn As PictureBox
End Class
