Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tableSearchOptionsForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.viewAttendanceThisSiteChk = New System.Windows.Forms.CheckBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.divider = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.viewOtherSitesChk = New System.Windows.Forms.CheckBox()
        Me.viewPlanningChk = New System.Windows.Forms.CheckBox()
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 262)
        Me.Panel1.TabIndex = 0
        '
        'viewAttendanceThisSiteChk
        '
        Me.viewAttendanceThisSiteChk.AutoSize = True
        Me.viewAttendanceThisSiteChk.Location = New System.Drawing.Point(112, 162)
        Me.viewAttendanceThisSiteChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.viewAttendanceThisSiteChk.Name = "viewAttendanceThisSiteChk"
        Me.viewAttendanceThisSiteChk.Size = New System.Drawing.Size(230, 24)
        Me.viewAttendanceThisSiteChk.TabIndex = 369
        Me.viewAttendanceThisSiteChk.Text = "view attendance on this site"
        Me.viewAttendanceThisSiteChk.UseVisualStyleBackColor = True
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(663, 197)
        Me.closeBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(129, 40)
        Me.closeBtn.TabIndex = 368
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'divider
        '
        Me.divider.BackColor = System.Drawing.Color.LimeGreen
        Me.divider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.divider.ForeColor = System.Drawing.Color.GreenYellow
        Me.divider.Location = New System.Drawing.Point(24, 46)
        Me.divider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.divider.Name = "divider"
        Me.divider.Size = New System.Drawing.Size(767, 5)
        Me.divider.TabIndex = 367
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(18, 15)
        Me.title.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(217, 29)
        Me.title.TabIndex = 366
        Me.title.Text = "Search parameters"
        '
        'viewOtherSitesChk
        '
        Me.viewOtherSitesChk.AutoSize = True
        Me.viewOtherSitesChk.Location = New System.Drawing.Point(112, 126)
        Me.viewOtherSitesChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.viewOtherSitesChk.Name = "viewOtherSitesChk"
        Me.viewOtherSitesChk.Size = New System.Drawing.Size(250, 24)
        Me.viewOtherSitesChk.TabIndex = 1
        Me.viewOtherSitesChk.Text = "view attendance on other sites"
        Me.viewOtherSitesChk.UseVisualStyleBackColor = True
        '
        'viewPlanningChk
        '
        Me.viewPlanningChk.AutoSize = True
        Me.viewPlanningChk.Location = New System.Drawing.Point(112, 91)
        Me.viewPlanningChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.viewPlanningChk.Name = "viewPlanningChk"
        Me.viewPlanningChk.Size = New System.Drawing.Size(245, 24)
        Me.viewPlanningChk.TabIndex = 0
        Me.viewPlanningChk.Text = "View planning of assignments"
        Me.viewPlanningChk.UseVisualStyleBackColor = True
        '
        'tableSearchOptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tableSearchOptionsForm"
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
