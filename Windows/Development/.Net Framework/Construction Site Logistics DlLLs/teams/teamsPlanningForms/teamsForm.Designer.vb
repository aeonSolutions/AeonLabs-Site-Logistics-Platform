Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class teamsForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(teamsForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.combo_site = New System.Windows.Forms.ComboBox()
        Me.workers_group = New System.Windows.Forms.GroupBox()
        Me.workersUpdateBtn = New System.Windows.Forms.PictureBox()
        Me.copyTeamsBtn = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.removeWorkerBtn = New System.Windows.Forms.PictureBox()
        Me.searchTitle = New System.Windows.Forms.Label()
        Me.addWorkerBtn = New System.Windows.Forms.PictureBox()
        Me.searchbox = New System.Windows.Forms.TextBox()
        Me.workersListBox = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.divider = New System.Windows.Forms.Label()
        Me.teams_title_text = New System.Windows.Forms.Label()
        Me.datatable = New System.Windows.Forms.DataGridView()
        Me.loadTableDataBtn = New System.Windows.Forms.PictureBox()
        Me.GroupBoxSiteSelection = New System.Windows.Forms.GroupBox()
        Me.calendar_log = New System.Windows.Forms.DateTimePicker()
        Me.tableSettingsBtn = New System.Windows.Forms.PictureBox()
        Me.groupBoxWorkerAssignments = New System.Windows.Forms.GroupBox()
        Me.groupBoxWorkerAssignmentsPanel = New System.Windows.Forms.Panel()
        Me.workerSelectionTasks = New System.Windows.Forms.Label()
        Me.loadForm = New System.Windows.Forms.Timer(Me.components)
        Me.workers_group.SuspendLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.copyTeamsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.removeWorkerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.addWorkerBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.loadTableDataBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSiteSelection.SuspendLayout()
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBoxWorkerAssignments.SuspendLayout()
        Me.groupBoxWorkerAssignmentsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'combo_site
        '
        Me.combo_site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_site.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_site.FormattingEnabled = True
        Me.combo_site.Location = New System.Drawing.Point(7, 19)
        Me.combo_site.Name = "combo_site"
        Me.combo_site.Size = New System.Drawing.Size(326, 28)
        Me.combo_site.TabIndex = 9
        '
        'workers_group
        '
        Me.workers_group.AutoSize = True
        Me.workers_group.Controls.Add(Me.workersUpdateBtn)
        Me.workers_group.Controls.Add(Me.copyTeamsBtn)
        Me.workers_group.Controls.Add(Me.PictureBox1)
        Me.workers_group.Controls.Add(Me.removeWorkerBtn)
        Me.workers_group.Controls.Add(Me.searchTitle)
        Me.workers_group.Controls.Add(Me.addWorkerBtn)
        Me.workers_group.Controls.Add(Me.searchbox)
        Me.workers_group.Controls.Add(Me.workersListBox)
        Me.workers_group.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workers_group.Location = New System.Drawing.Point(12, 338)
        Me.workers_group.Name = "workers_group"
        Me.workers_group.Size = New System.Drawing.Size(344, 360)
        Me.workers_group.TabIndex = 12
        Me.workers_group.TabStop = False
        Me.workers_group.Text = "Trabalhadores"
        Me.workers_group.Visible = False
        '
        'workersUpdateBtn
        '
        Me.workersUpdateBtn.Image = CType(resources.GetObject("workersUpdateBtn.Image"), System.Drawing.Image)
        Me.workersUpdateBtn.InitialImage = Nothing
        Me.workersUpdateBtn.Location = New System.Drawing.Point(10, 60)
        Me.workersUpdateBtn.Name = "workersUpdateBtn"
        Me.workersUpdateBtn.Size = New System.Drawing.Size(29, 29)
        Me.workersUpdateBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.workersUpdateBtn.TabIndex = 221
        Me.workersUpdateBtn.TabStop = False
        '
        'copyTeamsBtn
        '
        Me.copyTeamsBtn.Image = CType(resources.GetObject("copyTeamsBtn.Image"), System.Drawing.Image)
        Me.copyTeamsBtn.InitialImage = Nothing
        Me.copyTeamsBtn.Location = New System.Drawing.Point(45, 60)
        Me.copyTeamsBtn.Name = "copyTeamsBtn"
        Me.copyTeamsBtn.Size = New System.Drawing.Size(29, 29)
        Me.copyTeamsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.copyTeamsBtn.TabIndex = 220
        Me.copyTeamsBtn.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(317, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 196
        Me.PictureBox1.TabStop = False
        '
        'removeWorkerBtn
        '
        Me.removeWorkerBtn.Image = CType(resources.GetObject("removeWorkerBtn.Image"), System.Drawing.Image)
        Me.removeWorkerBtn.InitialImage = Nothing
        Me.removeWorkerBtn.Location = New System.Drawing.Point(268, 60)
        Me.removeWorkerBtn.Name = "removeWorkerBtn"
        Me.removeWorkerBtn.Size = New System.Drawing.Size(29, 29)
        Me.removeWorkerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.removeWorkerBtn.TabIndex = 218
        Me.removeWorkerBtn.TabStop = False
        '
        'searchTitle
        '
        Me.searchTitle.AutoSize = True
        Me.searchTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchTitle.Location = New System.Drawing.Point(6, 17)
        Me.searchTitle.Name = "searchTitle"
        Me.searchTitle.Size = New System.Drawing.Size(80, 20)
        Me.searchTitle.TabIndex = 194
        Me.searchTitle.Text = "Procurar"
        '
        'addWorkerBtn
        '
        Me.addWorkerBtn.Image = CType(resources.GetObject("addWorkerBtn.Image"), System.Drawing.Image)
        Me.addWorkerBtn.InitialImage = Nothing
        Me.addWorkerBtn.Location = New System.Drawing.Point(303, 60)
        Me.addWorkerBtn.Name = "addWorkerBtn"
        Me.addWorkerBtn.Size = New System.Drawing.Size(29, 29)
        Me.addWorkerBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.addWorkerBtn.TabIndex = 217
        Me.addWorkerBtn.TabStop = False
        '
        'searchbox
        '
        Me.searchbox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchbox.Location = New System.Drawing.Point(9, 33)
        Me.searchbox.Name = "searchbox"
        Me.searchbox.Size = New System.Drawing.Size(298, 28)
        Me.searchbox.TabIndex = 195
        '
        'workersListBox
        '
        Me.workersListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.workersListBox.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workersListBox.FormattingEnabled = True
        Me.workersListBox.HorizontalScrollbar = True
        Me.workersListBox.Location = New System.Drawing.Point(10, 95)
        Me.workersListBox.Name = "workersListBox"
        Me.workersListBox.Size = New System.Drawing.Size(324, 238)
        Me.workersListBox.TabIndex = 34
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(390, 36)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(1043, 4)
        Me.divider.TabIndex = 201
        Me.divider.Visible = False
        '
        'teams_title_text
        '
        Me.teams_title_text.AutoSize = True
        Me.teams_title_text.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.teams_title_text.Location = New System.Drawing.Point(387, 12)
        Me.teams_title_text.Name = "teams_title_text"
        Me.teams_title_text.Size = New System.Drawing.Size(234, 29)
        Me.teams_title_text.TabIndex = 200
        Me.teams_title_text.Text = "Equipa atribuida"
        Me.teams_title_text.Visible = False
        '
        'datatable
        '
        Me.datatable.AllowUserToAddRows = False
        Me.datatable.AllowUserToDeleteRows = False
        Me.datatable.BackgroundColor = System.Drawing.Color.White
        Me.datatable.CausesValidation = False
        Me.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datatable.DefaultCellStyle = DataGridViewCellStyle1
        Me.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datatable.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.datatable.Location = New System.Drawing.Point(390, 47)
        Me.datatable.MultiSelect = False
        Me.datatable.Name = "datatable"
        Me.datatable.ReadOnly = True
        Me.datatable.RowHeadersWidth = 62
        Me.datatable.Size = New System.Drawing.Size(1224, 647)
        Me.datatable.TabIndex = 202
        Me.datatable.VirtualMode = True
        Me.datatable.Visible = False
        '
        'loadTableDataBtn
        '
        Me.loadTableDataBtn.Image = CType(resources.GetObject("loadTableDataBtn.Image"), System.Drawing.Image)
        Me.loadTableDataBtn.InitialImage = Nothing
        Me.loadTableDataBtn.Location = New System.Drawing.Point(303, 52)
        Me.loadTableDataBtn.Name = "loadTableDataBtn"
        Me.loadTableDataBtn.Size = New System.Drawing.Size(24, 24)
        Me.loadTableDataBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.loadTableDataBtn.TabIndex = 215
        Me.loadTableDataBtn.TabStop = False
        '
        'GroupBoxSiteSelection
        '
        Me.GroupBoxSiteSelection.Controls.Add(Me.calendar_log)
        Me.GroupBoxSiteSelection.Controls.Add(Me.tableSettingsBtn)
        Me.GroupBoxSiteSelection.Controls.Add(Me.combo_site)
        Me.GroupBoxSiteSelection.Controls.Add(Me.loadTableDataBtn)
        Me.GroupBoxSiteSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxSiteSelection.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxSiteSelection.Name = "GroupBoxSiteSelection"
        Me.GroupBoxSiteSelection.Size = New System.Drawing.Size(346, 88)
        Me.GroupBoxSiteSelection.TabIndex = 216
        Me.GroupBoxSiteSelection.TabStop = False
        Me.GroupBoxSiteSelection.Text = "Obra"
        Me.GroupBoxSiteSelection.Visible = False
        '
        'calendar_log
        '
        Me.calendar_log.CustomFormat = "MMMM - yyyy"
        Me.calendar_log.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.calendar_log.Location = New System.Drawing.Point(9, 52)
        Me.calendar_log.Name = "calendar_log"
        Me.calendar_log.Size = New System.Drawing.Size(193, 26)
        Me.calendar_log.TabIndex = 327
        '
        'tableSettingsBtn
        '
        Me.tableSettingsBtn.Image = CType(resources.GetObject("tableSettingsBtn.Image"), System.Drawing.Image)
        Me.tableSettingsBtn.InitialImage = Nothing
        Me.tableSettingsBtn.Location = New System.Drawing.Point(273, 52)
        Me.tableSettingsBtn.Name = "tableSettingsBtn"
        Me.tableSettingsBtn.Size = New System.Drawing.Size(24, 24)
        Me.tableSettingsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tableSettingsBtn.TabIndex = 326
        Me.tableSettingsBtn.TabStop = False
        '
        'groupBoxWorkerAssignments
        '
        Me.groupBoxWorkerAssignments.Controls.Add(Me.groupBoxWorkerAssignmentsPanel)
        Me.groupBoxWorkerAssignments.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBoxWorkerAssignments.Location = New System.Drawing.Point(12, 106)
        Me.groupBoxWorkerAssignments.Name = "groupBoxWorkerAssignments"
        Me.groupBoxWorkerAssignments.Size = New System.Drawing.Size(344, 226)
        Me.groupBoxWorkerAssignments.TabIndex = 217
        Me.groupBoxWorkerAssignments.TabStop = False
        Me.groupBoxWorkerAssignments.Text = "Responsabilidades atribuidas"
        '
        'groupBoxWorkerAssignmentsPanel
        '
        Me.groupBoxWorkerAssignmentsPanel.AutoScroll = True
        Me.groupBoxWorkerAssignmentsPanel.Controls.Add(Me.workerSelectionTasks)
        Me.groupBoxWorkerAssignmentsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBoxWorkerAssignmentsPanel.Location = New System.Drawing.Point(3, 24)
        Me.groupBoxWorkerAssignmentsPanel.Name = "groupBoxWorkerAssignmentsPanel"
        Me.groupBoxWorkerAssignmentsPanel.Size = New System.Drawing.Size(338, 199)
        Me.groupBoxWorkerAssignmentsPanel.TabIndex = 0
        '
        'workerSelectionTasks
        '
        Me.workerSelectionTasks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workerSelectionTasks.Location = New System.Drawing.Point(3, 0)
        Me.workerSelectionTasks.Name = "workerSelectionTasks"
        Me.workerSelectionTasks.Size = New System.Drawing.Size(312, 401)
        Me.workerSelectionTasks.TabIndex = 0
        Me.workerSelectionTasks.Text = "Select a worker on the table"
        '
        'loadForm
        '
        '
        'teamsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1656, 782)
        Me.ControlBox = False
        Me.Controls.Add(Me.groupBoxWorkerAssignments)
        Me.Controls.Add(Me.GroupBoxSiteSelection)
        Me.Controls.Add(Me.datatable)
        Me.Controls.Add(Me.divider)
        Me.Controls.Add(Me.teams_title_text)
        Me.Controls.Add(Me.workers_group)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "teamsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Equipas"
        Me.workers_group.ResumeLayout(False)
        Me.workers_group.PerformLayout()
        CType(Me.workersUpdateBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.copyTeamsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.removeWorkerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.addWorkerBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datatable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.loadTableDataBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSiteSelection.ResumeLayout(False)
        CType(Me.tableSettingsBtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBoxWorkerAssignments.ResumeLayout(False)
        Me.groupBoxWorkerAssignmentsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents combo_site As ComboBox
    Friend WithEvents workers_group As GroupBox
    Friend WithEvents workersListBox As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents searchTitle As Label
    Friend WithEvents searchbox As TextBox
    Friend WithEvents divider As Label
    Friend WithEvents teams_title_text As Label
    Friend WithEvents datatable As DataGridView
    Friend WithEvents loadTableDataBtn As PictureBox
    Friend WithEvents GroupBoxSiteSelection As GroupBox
    Friend WithEvents tableSettingsBtn As PictureBox
    Friend WithEvents calendar_log As DateTimePicker
    Friend WithEvents addWorkerBtn As PictureBox
    Friend WithEvents removeWorkerBtn As PictureBox
    Friend WithEvents copyTeamsBtn As PictureBox
    Friend WithEvents workersUpdateBtn As PictureBox
    Friend WithEvents groupBoxWorkerAssignments As GroupBox
    Friend WithEvents groupBoxWorkerAssignmentsPanel As Panel
    Friend WithEvents workerSelectionTasks As Label
    Friend WithEvents loadForm As Timer
End Class
