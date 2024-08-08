Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMdiForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMdiForm))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.clock = New System.Windows.Forms.Timer(Me.components)
        Me.MenuSidebar = New System.Windows.Forms.PictureBox()
        Me.formTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.StatusMessagesDisplayTime = New System.Windows.Forms.Timer(Me.components)
        Me.FormRedraw = New System.Windows.Forms.Timer(Me.components)
        Me.backgroundAnimation = New System.Windows.Forms.PictureBox()
        Me.wrapper = New System.Windows.Forms.TableLayoutPanel()
        Me.sidePanelMenuTop = New System.Windows.Forms.Panel()
        Me.PanelMenuTop = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.main_minimize = New System.Windows.Forms.PictureBox()
        Me.statusText = New System.Windows.Forms.Label()
        Me.label_time = New System.Windows.Forms.Label()
        CType(Me.MenuSidebar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backgroundAnimation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wrapper.SuspendLayout()
        Me.sidePanelMenuTop.SuspendLayout()
        Me.PanelMenuTop.SuspendLayout()
        CType(Me.main_minimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'clock
        '
        Me.clock.Enabled = True
        Me.clock.Interval = 2000
        '
        'MenuSidebar
        '
        Me.MenuSidebar.Image = CType(resources.GetObject("MenuSidebar.Image"), System.Drawing.Image)
        Me.MenuSidebar.Location = New System.Drawing.Point(19, 21)
        Me.MenuSidebar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MenuSidebar.Name = "MenuSidebar"
        Me.MenuSidebar.Size = New System.Drawing.Size(38, 38)
        Me.MenuSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MenuSidebar.TabIndex = 10
        Me.MenuSidebar.TabStop = False
        '
        'formTimeOut
        '
        '
        'StatusMessagesDisplayTime
        '
        Me.StatusMessagesDisplayTime.Interval = 1000
        '
        'FormRedraw
        '
        Me.FormRedraw.Interval = 500
        '
        'backgroundAnimation
        '
        Me.backgroundAnimation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.backgroundAnimation.Image = CType(resources.GetObject("backgroundAnimation.Image"), System.Drawing.Image)
        Me.backgroundAnimation.Location = New System.Drawing.Point(0, 0)
        Me.backgroundAnimation.Name = "backgroundAnimation"
        Me.backgroundAnimation.Size = New System.Drawing.Size(1940, 1100)
        Me.backgroundAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.backgroundAnimation.TabIndex = 1
        Me.backgroundAnimation.TabStop = False
        '
        'wrapper
        '
        Me.wrapper.BackColor = System.Drawing.Color.Transparent
        Me.wrapper.ColumnCount = 2
        Me.wrapper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08247!))
        Me.wrapper.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.91753!))
        Me.wrapper.Controls.Add(Me.sidePanelMenuTop, 0, 0)
        Me.wrapper.Controls.Add(Me.PanelMenuTop, 1, 0)
        Me.wrapper.Controls.Add(Me.statusText, 1, 2)
        Me.wrapper.Controls.Add(Me.label_time, 0, 2)
        Me.wrapper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wrapper.Location = New System.Drawing.Point(0, 0)
        Me.wrapper.Name = "wrapper"
        Me.wrapper.RowCount = 3
        Me.wrapper.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.804448!))
        Me.wrapper.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.19555!))
        Me.wrapper.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.wrapper.Size = New System.Drawing.Size(1940, 1100)
        Me.wrapper.TabIndex = 6
        '
        'sidePanelMenuTop
        '
        Me.sidePanelMenuTop.BackColor = System.Drawing.Color.DarkGray
        Me.sidePanelMenuTop.Controls.Add(Me.MenuSidebar)
        Me.sidePanelMenuTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sidePanelMenuTop.Location = New System.Drawing.Point(3, 3)
        Me.sidePanelMenuTop.Name = "sidePanelMenuTop"
        Me.sidePanelMenuTop.Size = New System.Drawing.Size(305, 88)
        Me.sidePanelMenuTop.TabIndex = 0
        '
        'PanelMenuTop
        '
        Me.PanelMenuTop.BackColor = System.Drawing.Color.DarkGray
        Me.PanelMenuTop.Controls.Add(Me.TextBox1)
        Me.PanelMenuTop.Controls.Add(Me.main_minimize)
        Me.PanelMenuTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMenuTop.Location = New System.Drawing.Point(314, 3)
        Me.PanelMenuTop.Name = "PanelMenuTop"
        Me.PanelMenuTop.Size = New System.Drawing.Size(1623, 88)
        Me.PanelMenuTop.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(836, 21)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(456, 38)
        Me.TextBox1.TabIndex = 12
        '
        'main_minimize
        '
        Me.main_minimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.main_minimize.Image = CType(resources.GetObject("main_minimize.Image"), System.Drawing.Image)
        Me.main_minimize.Location = New System.Drawing.Point(1566, 21)
        Me.main_minimize.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.main_minimize.Name = "main_minimize"
        Me.main_minimize.Size = New System.Drawing.Size(30, 31)
        Me.main_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.main_minimize.TabIndex = 8
        Me.main_minimize.TabStop = False
        '
        'statusText
        '
        Me.statusText.AutoSize = True
        Me.statusText.BackColor = System.Drawing.Color.DarkGray
        Me.statusText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.statusText.ForeColor = System.Drawing.Color.White
        Me.statusText.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive
        Me.statusText.Location = New System.Drawing.Point(315, 1070)
        Me.statusText.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.statusText.Name = "statusText"
        Me.statusText.Size = New System.Drawing.Size(1621, 30)
        Me.statusText.TabIndex = 22
        Me.statusText.Text = "Loading..."
        '
        'label_time
        '
        Me.label_time.AutoSize = True
        Me.label_time.BackColor = System.Drawing.Color.DarkGray
        Me.label_time.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label_time.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_time.ForeColor = System.Drawing.Color.White
        Me.label_time.Location = New System.Drawing.Point(0, 1070)
        Me.label_time.Margin = New System.Windows.Forms.Padding(0)
        Me.label_time.Name = "label_time"
        Me.label_time.Size = New System.Drawing.Size(311, 30)
        Me.label_time.TabIndex = 24
        Me.label_time.Text = "--:--"
        '
        'MainMdiForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1940, 1100)
        Me.ControlBox = False
        Me.Controls.Add(Me.wrapper)
        Me.Controls.Add(Me.backgroundAnimation)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainMdiForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion de Chantiers"
        Me.TransparencyKey = System.Drawing.Color.White
        CType(Me.MenuSidebar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backgroundAnimation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wrapper.ResumeLayout(False)
        Me.wrapper.PerformLayout()
        Me.sidePanelMenuTop.ResumeLayout(False)
        Me.PanelMenuTop.ResumeLayout(False)
        Me.PanelMenuTop.PerformLayout()
        CType(Me.main_minimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents clock As Timer
    Private WithEvents MenuSidebar As PictureBox
    Friend WithEvents formTimeOut As Timer
    Friend WithEvents StatusMessagesDisplayTime As Timer
    Friend WithEvents FormRedraw As Timer
    Friend WithEvents backgroundAnimation As PictureBox
    Friend WithEvents wrapper As TableLayoutPanel
    Friend WithEvents sidePanelMenuTop As Panel
    Friend WithEvents PanelMenuTop As Panel
    Friend WithEvents TextBox1 As TextBox
    Private WithEvents main_minimize As PictureBox
    Friend WithEvents statusText As Label
    Friend WithEvents label_time As Label
End Class
