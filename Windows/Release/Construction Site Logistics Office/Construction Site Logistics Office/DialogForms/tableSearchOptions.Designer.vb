<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tableSearchOptions_frm
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
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.viewOtherSitesChk = New System.Windows.Forms.CheckBox()
        Me.viewPlanningChk = New System.Windows.Forms.CheckBox()
        Me.viewAttendanceThisSiteChk = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.viewAttendanceThisSiteChk)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.divider)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Controls.Add(Me.viewOtherSitesChk)
        Me.Panel1.Controls.Add(Me.viewPlanningChk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(558, 170)
        Me.Panel1.TabIndex = 0
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(442, 128)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 368
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(16, 30)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(512, 4)
        Me.divider.TabIndex = 367
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(12, 10)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(145, 20)
        Me.title.TabIndex = 366
        Me.title.Text = "Search parameters"
        '
        'viewOtherSitesChk
        '
        Me.viewOtherSitesChk.AutoSize = True
        Me.viewOtherSitesChk.Location = New System.Drawing.Point(75, 82)
        Me.viewOtherSitesChk.Name = "viewOtherSitesChk"
        Me.viewOtherSitesChk.Size = New System.Drawing.Size(171, 17)
        Me.viewOtherSitesChk.TabIndex = 1
        Me.viewOtherSitesChk.Text = "view attendance on other sites"
        Me.viewOtherSitesChk.UseVisualStyleBackColor = True
        '
        'viewPlanningChk
        '
        Me.viewPlanningChk.AutoSize = True
        Me.viewPlanningChk.Location = New System.Drawing.Point(75, 59)
        Me.viewPlanningChk.Name = "viewPlanningChk"
        Me.viewPlanningChk.Size = New System.Drawing.Size(165, 17)
        Me.viewPlanningChk.TabIndex = 0
        Me.viewPlanningChk.Text = "View planning of assignments"
        Me.viewPlanningChk.UseVisualStyleBackColor = True
        '
        'viewAttendanceThisSiteChk
        '
        Me.viewAttendanceThisSiteChk.AutoSize = True
        Me.viewAttendanceThisSiteChk.Location = New System.Drawing.Point(75, 105)
        Me.viewAttendanceThisSiteChk.Name = "viewAttendanceThisSiteChk"
        Me.viewAttendanceThisSiteChk.Size = New System.Drawing.Size(158, 17)
        Me.viewAttendanceThisSiteChk.TabIndex = 369
        Me.viewAttendanceThisSiteChk.Text = "view attendance on this site"
        Me.viewAttendanceThisSiteChk.UseVisualStyleBackColor = True
        '
        'tableSearchOptions_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tableSearchOptions_frm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents viewOtherSitesChk As CheckBox
    Friend WithEvents viewPlanningChk As CheckBox
    Friend WithEvents divider As Label
    Friend WithEvents title As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents viewAttendanceThisSiteChk As CheckBox
End Class
