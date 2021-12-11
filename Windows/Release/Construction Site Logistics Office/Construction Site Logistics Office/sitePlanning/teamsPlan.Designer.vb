<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class teams_plan_frm
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
        Me.worker_lbl = New System.Windows.Forms.Label()
        Me.groupboxPlanning = New System.Windows.Forms.GroupBox()
        Me.checkbox_del = New System.Windows.Forms.CheckBox()
        Me.checkbox_mo = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ep = New System.Windows.Forms.CheckBox()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusUpdate = New System.Windows.Forms.Label()
        Me.groupBoxTransports = New System.Windows.Forms.GroupBox()
        Me.combo_maintenance_car = New System.Windows.Forms.ComboBox()
        Me.combo_driver_car = New System.Windows.Forms.ComboBox()
        Me.driverChk = New System.Windows.Forms.CheckBox()
        Me.maintenanceCarChk = New System.Windows.Forms.CheckBox()
        Me.calendar = New System.Windows.Forms.MonthCalendar()
        Me.groupBoxBossType = New System.Windows.Forms.GroupBox()
        Me.combo_cat = New System.Windows.Forms.ComboBox()
        Me.groupBoxResponsabilities = New System.Windows.Forms.GroupBox()
        Me.logLivraisonsChk = New System.Windows.Forms.CheckBox()
        Me.checkPlanningChk = New System.Windows.Forms.CheckBox()
        Me.storeToolsChk = New System.Windows.Forms.CheckBox()
        Me.storeMaterialsChk = New System.Windows.Forms.CheckBox()
        Me.accessTabletChk = New System.Windows.Forms.CheckBox()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.site_lbl = New System.Windows.Forms.Label()
        Me.worker_photo = New System.Windows.Forms.PictureBox()
        Me.groupboxPlanning.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.groupBoxTransports.SuspendLayout()
        Me.groupBoxBossType.SuspendLayout()
        Me.groupBoxResponsabilities.SuspendLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'worker_lbl
        '
        Me.worker_lbl.AutoSize = True
        Me.worker_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.worker_lbl.Location = New System.Drawing.Point(134, 86)
        Me.worker_lbl.Name = "worker_lbl"
        Me.worker_lbl.Size = New System.Drawing.Size(181, 13)
        Me.worker_lbl.TabIndex = 7
        Me.worker_lbl.Text = "Miguel Tomas Pinto e Silva"
        '
        'groupboxPlanning
        '
        Me.groupboxPlanning.Controls.Add(Me.checkbox_del)
        Me.groupboxPlanning.Controls.Add(Me.checkbox_mo)
        Me.groupboxPlanning.Controls.Add(Me.CheckBox_ep)
        Me.groupboxPlanning.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupboxPlanning.Location = New System.Drawing.Point(256, 179)
        Me.groupboxPlanning.Name = "groupboxPlanning"
        Me.groupboxPlanning.Size = New System.Drawing.Size(233, 89)
        Me.groupboxPlanning.TabIndex = 8
        Me.groupboxPlanning.TabStop = False
        Me.groupboxPlanning.Text = "Planeamento"
        '
        'checkbox_del
        '
        Me.checkbox_del.AutoSize = True
        Me.checkbox_del.Location = New System.Drawing.Point(10, 66)
        Me.checkbox_del.Name = "checkbox_del"
        Me.checkbox_del.Size = New System.Drawing.Size(128, 17)
        Me.checkbox_del.TabIndex = 10
        Me.checkbox_del.Text = "Remover da Obra"
        Me.checkbox_del.UseVisualStyleBackColor = True
        '
        'checkbox_mo
        '
        Me.checkbox_mo.AutoSize = True
        Me.checkbox_mo.Location = New System.Drawing.Point(10, 43)
        Me.checkbox_mo.Name = "checkbox_mo"
        Me.checkbox_mo.Size = New System.Drawing.Size(126, 17)
        Me.checkbox_mo.TabIndex = 9
        Me.checkbox_mo.Text = "Mudança de Obra"
        Me.checkbox_mo.UseVisualStyleBackColor = True
        '
        'CheckBox_ep
        '
        Me.CheckBox_ep.AutoSize = True
        Me.CheckBox_ep.Location = New System.Drawing.Point(10, 20)
        Me.CheckBox_ep.Name = "CheckBox_ep"
        Me.CheckBox_ep.Size = New System.Drawing.Size(114, 17)
        Me.CheckBox_ep.TabIndex = 8
        Me.CheckBox_ep.Text = "Equipa Prevista"
        Me.CheckBox_ep.UseVisualStyleBackColor = True
        '
        'CloseBtn
        '
        Me.CloseBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseBtn.ForeColor = System.Drawing.Color.White
        Me.CloseBtn.Location = New System.Drawing.Point(403, 668)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(86, 26)
        Me.CloseBtn.TabIndex = 337
        Me.CloseBtn.Text = "Fechar"
        Me.CloseBtn.UseVisualStyleBackColor = False
        '
        'saveBtn
        '
        Me.saveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveBtn.ForeColor = System.Drawing.Color.White
        Me.saveBtn.Location = New System.Drawing.Point(17, 668)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(86, 26)
        Me.saveBtn.TabIndex = 338
        Me.saveBtn.Text = "Gravar"
        Me.saveBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.StatusUpdate)
        Me.Panel1.Controls.Add(Me.groupBoxTransports)
        Me.Panel1.Controls.Add(Me.calendar)
        Me.Panel1.Controls.Add(Me.groupBoxBossType)
        Me.Panel1.Controls.Add(Me.groupBoxResponsabilities)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.site_lbl)
        Me.Panel1.Controls.Add(Me.worker_lbl)
        Me.Panel1.Controls.Add(Me.worker_photo)
        Me.Panel1.Controls.Add(Me.groupboxPlanning)
        Me.Panel1.Controls.Add(Me.CloseBtn)
        Me.Panel1.Controls.Add(Me.saveBtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(512, 699)
        Me.Panel1.TabIndex = 358
        '
        'StatusUpdate
        '
        Me.StatusUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusUpdate.Location = New System.Drawing.Point(12, 33)
        Me.StatusUpdate.Name = "StatusUpdate"
        Me.StatusUpdate.Size = New System.Drawing.Size(488, 18)
        Me.StatusUpdate.TabIndex = 365
        Me.StatusUpdate.Text = "status update"
        Me.StatusUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBoxTransports
        '
        Me.groupBoxTransports.Controls.Add(Me.combo_maintenance_car)
        Me.groupBoxTransports.Controls.Add(Me.combo_driver_car)
        Me.groupBoxTransports.Controls.Add(Me.driverChk)
        Me.groupBoxTransports.Controls.Add(Me.maintenanceCarChk)
        Me.groupBoxTransports.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBoxTransports.Location = New System.Drawing.Point(17, 531)
        Me.groupBoxTransports.Name = "groupBoxTransports"
        Me.groupBoxTransports.Size = New System.Drawing.Size(472, 131)
        Me.groupBoxTransports.TabIndex = 364
        Me.groupBoxTransports.TabStop = False
        Me.groupBoxTransports.Text = "Viagem / Transporte "
        '
        'combo_maintenance_car
        '
        Me.combo_maintenance_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_maintenance_car.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_maintenance_car.FormattingEnabled = True
        Me.combo_maintenance_car.Location = New System.Drawing.Point(44, 93)
        Me.combo_maintenance_car.Name = "combo_maintenance_car"
        Me.combo_maintenance_car.Size = New System.Drawing.Size(326, 21)
        Me.combo_maintenance_car.TabIndex = 16
        '
        'combo_driver_car
        '
        Me.combo_driver_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_driver_car.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_driver_car.FormattingEnabled = True
        Me.combo_driver_car.Location = New System.Drawing.Point(44, 43)
        Me.combo_driver_car.Name = "combo_driver_car"
        Me.combo_driver_car.Size = New System.Drawing.Size(326, 21)
        Me.combo_driver_car.TabIndex = 15
        '
        'driverChk
        '
        Me.driverChk.AutoSize = True
        Me.driverChk.Location = New System.Drawing.Point(22, 20)
        Me.driverChk.Name = "driverChk"
        Me.driverChk.Size = New System.Drawing.Size(83, 17)
        Me.driverChk.TabIndex = 12
        Me.driverChk.Text = "Condutor "
        Me.driverChk.UseVisualStyleBackColor = True
        '
        'maintenanceCarChk
        '
        Me.maintenanceCarChk.AutoSize = True
        Me.maintenanceCarChk.Location = New System.Drawing.Point(21, 70)
        Me.maintenanceCarChk.Name = "maintenanceCarChk"
        Me.maintenanceCarChk.Size = New System.Drawing.Size(284, 17)
        Me.maintenanceCarChk.TabIndex = 13
        Me.maintenanceCarChk.Text = "Lavagem, limpeza e manutenção da carrinha"
        Me.maintenanceCarChk.UseVisualStyleBackColor = True
        '
        'calendar
        '
        Me.calendar.Location = New System.Drawing.Point(17, 179)
        Me.calendar.MaxSelectionCount = 31
        Me.calendar.Name = "calendar"
        Me.calendar.TabIndex = 363
        '
        'groupBoxBossType
        '
        Me.groupBoxBossType.Controls.Add(Me.combo_cat)
        Me.groupBoxBossType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBoxBossType.Location = New System.Drawing.Point(256, 274)
        Me.groupBoxBossType.Name = "groupBoxBossType"
        Me.groupBoxBossType.Size = New System.Drawing.Size(233, 67)
        Me.groupBoxBossType.TabIndex = 362
        Me.groupBoxBossType.TabStop = False
        Me.groupBoxBossType.Text = "Função a desempenhar"
        '
        'combo_cat
        '
        Me.combo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_cat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_cat.FormattingEnabled = True
        Me.combo_cat.Location = New System.Drawing.Point(10, 27)
        Me.combo_cat.Name = "combo_cat"
        Me.combo_cat.Size = New System.Drawing.Size(215, 21)
        Me.combo_cat.TabIndex = 205
        '
        'groupBoxResponsabilities
        '
        Me.groupBoxResponsabilities.Controls.Add(Me.logLivraisonsChk)
        Me.groupBoxResponsabilities.Controls.Add(Me.checkPlanningChk)
        Me.groupBoxResponsabilities.Controls.Add(Me.storeToolsChk)
        Me.groupBoxResponsabilities.Controls.Add(Me.storeMaterialsChk)
        Me.groupBoxResponsabilities.Controls.Add(Me.accessTabletChk)
        Me.groupBoxResponsabilities.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBoxResponsabilities.Location = New System.Drawing.Point(17, 347)
        Me.groupBoxResponsabilities.Name = "groupBoxResponsabilities"
        Me.groupBoxResponsabilities.Size = New System.Drawing.Size(472, 178)
        Me.groupBoxResponsabilities.TabIndex = 361
        Me.groupBoxResponsabilities.TabStop = False
        Me.groupBoxResponsabilities.Text = "Responsabilidades na organização do estaleiro"
        '
        'logLivraisonsChk
        '
        Me.logLivraisonsChk.Location = New System.Drawing.Point(14, 76)
        Me.logLivraisonsChk.Name = "logLivraisonsChk"
        Me.logLivraisonsChk.Size = New System.Drawing.Size(450, 37)
        Me.logLivraisonsChk.TabIndex = 16
        Me.logLivraisonsChk.Text = "Registar as guias de remessa dos materiais recebidos em obra no Tablet"
        Me.logLivraisonsChk.UseVisualStyleBackColor = True
        '
        'checkPlanningChk
        '
        Me.checkPlanningChk.Location = New System.Drawing.Point(14, 36)
        Me.checkPlanningChk.Name = "checkPlanningChk"
        Me.checkPlanningChk.Size = New System.Drawing.Size(450, 42)
        Me.checkPlanningChk.TabIndex = 15
        Me.checkPlanningChk.Text = "Verificação e distribuição dos trabalhos a realizar no dia de cada trabalhador (p" &
    "lanning)"
        Me.checkPlanningChk.UseVisualStyleBackColor = True
        '
        'storeToolsChk
        '
        Me.storeToolsChk.Location = New System.Drawing.Point(14, 130)
        Me.storeToolsChk.Name = "storeToolsChk"
        Me.storeToolsChk.Size = New System.Drawing.Size(451, 42)
        Me.storeToolsChk.TabIndex = 14
        Me.storeToolsChk.Text = "Contagem, verificação do estado de funcionamento e arrumação de máquinas ferramen" &
    "tas e equipamentos no armazém"
        Me.storeToolsChk.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.storeToolsChk.UseVisualStyleBackColor = True
        '
        'storeMaterialsChk
        '
        Me.storeMaterialsChk.Location = New System.Drawing.Point(14, 107)
        Me.storeMaterialsChk.Name = "storeMaterialsChk"
        Me.storeMaterialsChk.Size = New System.Drawing.Size(450, 31)
        Me.storeMaterialsChk.TabIndex = 11
        Me.storeMaterialsChk.Text = "Arrumação dos materiais e consumiveis no do armazém"
        Me.storeMaterialsChk.UseVisualStyleBackColor = True
        '
        'accessTabletChk
        '
        Me.accessTabletChk.AutoSize = True
        Me.accessTabletChk.Location = New System.Drawing.Point(15, 20)
        Me.accessTabletChk.Name = "accessTabletChk"
        Me.accessTabletChk.Size = New System.Drawing.Size(229, 17)
        Me.accessTabletChk.TabIndex = 9
        Me.accessTabletChk.Text = "Tablet de Obra (acesso ao sistema)"
        Me.accessTabletChk.UseVisualStyleBackColor = True
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(13, 28)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(487, 4)
        Me.divider.TabIndex = 360
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(8, 8)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(223, 18)
        Me.title.TabIndex = 359
        Me.title.Text = "Planeamento de equipas"
        '
        'site_lbl
        '
        Me.site_lbl.AutoSize = True
        Me.site_lbl.Location = New System.Drawing.Point(134, 62)
        Me.site_lbl.Name = "site_lbl"
        Me.site_lbl.Size = New System.Drawing.Size(16, 13)
        Me.site_lbl.TabIndex = 358
        Me.site_lbl.Text = "- -"
        '
        'worker_photo
        '
        Me.worker_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.worker_photo.InitialImage = Nothing
        Me.worker_photo.Location = New System.Drawing.Point(17, 58)
        Me.worker_photo.Name = "worker_photo"
        Me.worker_photo.Size = New System.Drawing.Size(111, 109)
        Me.worker_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.worker_photo.TabIndex = 357
        Me.worker_photo.TabStop = False
        '
        'teams_plan_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "teams_plan_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registo de presença"
        Me.groupboxPlanning.ResumeLayout(False)
        Me.groupboxPlanning.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupBoxTransports.ResumeLayout(False)
        Me.groupBoxTransports.PerformLayout()
        Me.groupBoxBossType.ResumeLayout(False)
        Me.groupBoxResponsabilities.ResumeLayout(False)
        Me.groupBoxResponsabilities.PerformLayout()
        CType(Me.worker_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents worker_lbl As Label
    Friend WithEvents groupboxPlanning As GroupBox
    Friend WithEvents CheckBox_ep As CheckBox
    Friend WithEvents checkbox_mo As CheckBox
    Friend WithEvents CloseBtn As Button
    Friend WithEvents saveBtn As Button
    Friend WithEvents worker_photo As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents site_lbl As Label
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents groupBoxBossType As GroupBox
    Friend WithEvents groupBoxResponsabilities As GroupBox
    Friend WithEvents maintenanceCarChk As CheckBox
    Friend WithEvents driverChk As CheckBox
    Friend WithEvents storeMaterialsChk As CheckBox
    Friend WithEvents accessTabletChk As CheckBox
    Friend WithEvents calendar As MonthCalendar
    Friend WithEvents storeToolsChk As CheckBox
    Friend WithEvents groupBoxTransports As GroupBox
    Friend WithEvents combo_maintenance_car As ComboBox
    Friend WithEvents combo_driver_car As ComboBox
    Friend WithEvents logLivraisonsChk As CheckBox
    Friend WithEvents checkPlanningChk As CheckBox
    Friend WithEvents StatusUpdate As Label
    Friend WithEvents combo_cat As ComboBox
    Friend WithEvents checkbox_del As CheckBox
End Class
