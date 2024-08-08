Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class activity_frm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(activity_frm))
        Me.divider = New System.Windows.Forms.Label()
        Me.siteFileTitle = New System.Windows.Forms.Label()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.lateralPanel = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.sideToggleBtn = New System.Windows.Forms.PictureBox()
        Me.date_lbl = New System.Windows.Forms.Label()
        Me.calendar_log = New System.Windows.Forms.DateTimePicker()
        Me.listBoxSite = New System.Windows.Forms.CheckedListBox()
        Me.combo_company = New System.Windows.Forms.ComboBox()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.company_lbl = New System.Windows.Forms.Label()
        Me.loadTableBtn = New System.Windows.Forms.PictureBox()
        Me.tablePanel = New System.Windows.Forms.Panel()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lateralPanel.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tablePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(8, 43)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1340, 5)
        Me.divider.TabIndex = 201
        '
        'siteFileTitle
        '
        Me.siteFileTitle.AutoSize = True
        Me.siteFileTitle.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteFileTitle.Location = New System.Drawing.Point(4, 12)
        Me.siteFileTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.siteFileTitle.Name = "siteFileTitle"
        Me.siteFileTitle.Size = New System.Drawing.Size(221, 29)
        Me.siteFileTitle.TabIndex = 200
        Me.siteFileTitle.Text = "Activity History"
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
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(9, 52)
        Me.datatable.Margin = New System.Windows.Forms.Padding(4)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datatable.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datatable.Size = New System.Drawing.Size(1618, 1090)
        Me.datatable.TabIndex = 325
        '
        'lateralPanel
        '
        Me.lateralPanel.Controls.Add(Me.Panel3)
        Me.lateralPanel.Controls.Add(Me.date_lbl)
        Me.lateralPanel.Controls.Add(Me.calendar_log)
        Me.lateralPanel.Controls.Add(Me.listBoxSite)
        Me.lateralPanel.Controls.Add(Me.combo_company)
        Me.lateralPanel.Controls.Add(Me.site_lbl)
        Me.lateralPanel.Controls.Add(Me.company_lbl)
        Me.lateralPanel.Controls.Add(Me.loadTableBtn)
        Me.lateralPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.lateralPanel.Location = New System.Drawing.Point(0, 0)
        Me.lateralPanel.Name = "lateralPanel"
        Me.lateralPanel.Size = New System.Drawing.Size(270, 1155)
        Me.lateralPanel.TabIndex = 330
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Ivory
        Me.Panel3.Controls.Add(Me.sideToggleBtn)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(28, 1155)
        Me.Panel3.TabIndex = 364
        '
        'sideToggleBtn
        '
        Me.sideToggleBtn.Image = CType(resources.GetObject("sideToggleBtn.Image"), System.Drawing.Image)
        Me.sideToggleBtn.InitialImage = Nothing
        Me.sideToggleBtn.Location = New System.Drawing.Point(2, 2)
        Me.sideToggleBtn.Name = "sideToggleBtn"
        Me.sideToggleBtn.Size = New System.Drawing.Size(24, 26)
        Me.sideToggleBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sideToggleBtn.TabIndex = 363
        Me.sideToggleBtn.TabStop = False
        '
        'date_lbl
        '
        Me.date_lbl.AutoSize = True
        Me.date_lbl.CausesValidation = False
        Me.date_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lbl.Location = New System.Drawing.Point(28, 323)
        Me.date_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.date_lbl.Name = "date_lbl"
        Me.date_lbl.Size = New System.Drawing.Size(64, 25)
        Me.date_lbl.TabIndex = 362
        Me.date_lbl.Text = "Data"
        '
        'calendar_log
        '
        Me.calendar_log.CustomFormat = "MMMM - yyyy"
        Me.calendar_log.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.calendar_log.Location = New System.Drawing.Point(31, 342)
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.Size = New System.Drawing.Size(227, 26)
        Me.calendar_log.TabIndex = 361
        Me.calendar_log.Value = New Date(2019, 11, 23, 0, 0, 0, 0)
        '
        'listBoxSite
        '
        Me.listBoxSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listBoxSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listBoxSite.FormattingEnabled = True
        Me.listBoxSite.Location = New System.Drawing.Point(31, 28)
        Me.listBoxSite.Name = "listBoxSite"
        Me.listBoxSite.Size = New System.Drawing.Size(227, 227)
        Me.listBoxSite.TabIndex = 328
        '
        'combo_company
        '
        Me.combo_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_company.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_company.FormattingEnabled = True
        Me.combo_company.Location = New System.Drawing.Point(31, 293)
        Me.combo_company.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_company.Name = "combo_company"
        Me.combo_company.Size = New System.Drawing.Size(227, 37)
        Me.combo_company.TabIndex = 6
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.CausesValidation = False
        Me.site_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_lbl.Location = New System.Drawing.Point(32, 9)
        Me.site_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(66, 25)
        Me.site_lbl.TabIndex = 0
        Me.site_lbl.Text = "Obra"
        '
        'company_lbl
        '
        Me.company_lbl.AutoSize = True
        Me.company_lbl.CausesValidation = False
        Me.company_lbl.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.company_lbl.Location = New System.Drawing.Point(28, 273)
        Me.company_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.company_lbl.Name = "company_lbl"
        Me.company_lbl.Size = New System.Drawing.Size(109, 25)
        Me.company_lbl.TabIndex = 5
        Me.company_lbl.Text = "Empresa"
        '
        'loadTableBtn
        '
        Me.loadTableBtn.Image = CType(resources.GetObject("loadTableBtn.Image"), System.Drawing.Image)
        Me.loadTableBtn.InitialImage = Nothing
        Me.loadTableBtn.Location = New System.Drawing.Point(234, 371)
        Me.loadTableBtn.Name = "loadTableBtn"
        Me.loadTableBtn.Size = New System.Drawing.Size(24, 26)
        Me.loadTableBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadTableBtn.TabIndex = 323
        Me.loadTableBtn.TabStop = False
        '
        'tablePanel
        '
        Me.tablePanel.Controls.Add(Me.siteFileTitle)
        Me.tablePanel.Controls.Add(Me.divider)
        Me.tablePanel.Controls.Add(Me.datatable)
        Me.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tablePanel.Location = New System.Drawing.Point(270, 0)
        Me.tablePanel.Name = "tablePanel"
        Me.tablePanel.Size = New System.Drawing.Size(1652, 1155)
        Me.tablePanel.TabIndex = 331
        '
        'activity_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1922, 1155)
        Me.ControlBox = False
        Me.Controls.Add(Me.tablePanel)
        Me.Controls.Add(Me.lateralPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "activity_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Activity History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lateralPanel.ResumeLayout(False)
        Me.lateralPanel.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.sideToggleBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadTableBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tablePanel.ResumeLayout(False)
        Me.tablePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents divider As Label
    Friend WithEvents siteFileTitle As Label
    Friend WithEvents datatable As DataGridView
    Friend WithEvents lateralPanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents sideToggleBtn As PictureBox
    Friend WithEvents date_lbl As Label
    Friend WithEvents calendar_log As DateTimePicker
    Friend WithEvents listBoxSite As CheckedListBox
    Friend WithEvents combo_company As ComboBox
    Friend WithEvents site_lbl As Label
    Friend WithEvents company_lbl As Label
    Friend WithEvents loadTableBtn As PictureBox
    Friend WithEvents tablePanel As Panel
End Class
