Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MessageBoxChild
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
        Me.AlphaGradientPanel1 = New BlueActivity.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.ContinueBtn = New System.Windows.Forms.Button()
        Me.iconBox = New System.Windows.Forms.PictureBox()
        Me.PanelMessage = New System.Windows.Forms.Panel()
        Me.message = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.AlphaGradientPanel1.SuspendLayout()
        CType(Me.iconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'AlphaGradientPanel1
        '
        Me.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.AlphaGradientPanel1.Border = False
        Me.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel1.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel1.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel1.Controls.Add(Me.cancelBtn)
        Me.AlphaGradientPanel1.Controls.Add(Me.ContinueBtn)
        Me.AlphaGradientPanel1.Controls.Add(Me.iconBox)
        Me.AlphaGradientPanel1.Controls.Add(Me.PanelMessage)
        Me.AlphaGradientPanel1.Controls.Add(Me.title)
        Me.AlphaGradientPanel1.CornerRadius = 20
        Me.AlphaGradientPanel1.Corners = BlueActivity.Corner.None
        Me.AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AlphaGradientPanel1.Gradient = False
        Me.AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.AlphaGradientPanel1.GradientOffset = 1.0!
        Me.AlphaGradientPanel1.GradientSize = New System.Drawing.Size(0, 0)
        Me.AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile
        Me.AlphaGradientPanel1.Grayscale = False
        Me.AlphaGradientPanel1.Image = Nothing
        Me.AlphaGradientPanel1.ImageAlpha = 75
        Me.AlphaGradientPanel1.ImagePadding = New System.Windows.Forms.Padding(5)
        Me.AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight
        Me.AlphaGradientPanel1.ImageSize = New System.Drawing.Size(48, 48)
        Me.AlphaGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.AlphaGradientPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.AlphaGradientPanel1.Name = "AlphaGradientPanel1"
        Me.AlphaGradientPanel1.Rounded = True
        Me.AlphaGradientPanel1.Size = New System.Drawing.Size(400, 160)
        Me.AlphaGradientPanel1.TabIndex = 351
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 0
        Me.ColorWithAlpha1.Color = System.Drawing.Color.YellowGreen
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel1
        '
        'cancelBtn
        '
        Me.cancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cancelBtn.FlatAppearance.BorderSize = 0
        Me.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelBtn.ForeColor = System.Drawing.Color.White
        Me.cancelBtn.Location = New System.Drawing.Point(271, 127)
        Me.cancelBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(105, 25)
        Me.cancelBtn.TabIndex = 354
        Me.cancelBtn.Text = "Cancelar"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'ContinueBtn
        '
        Me.ContinueBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ContinueBtn.FlatAppearance.BorderSize = 0
        Me.ContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ContinueBtn.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContinueBtn.ForeColor = System.Drawing.Color.White
        Me.ContinueBtn.Location = New System.Drawing.Point(15, 127)
        Me.ContinueBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ContinueBtn.Name = "ContinueBtn"
        Me.ContinueBtn.Size = New System.Drawing.Size(105, 25)
        Me.ContinueBtn.TabIndex = 353
        Me.ContinueBtn.Text = "Continuar"
        Me.ContinueBtn.UseVisualStyleBackColor = True
        '
        'iconBox
        '
        Me.iconBox.BackColor = System.Drawing.Color.Transparent
        Me.iconBox.Location = New System.Drawing.Point(23, 54)
        Me.iconBox.Name = "iconBox"
        Me.iconBox.Size = New System.Drawing.Size(53, 53)
        Me.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.iconBox.TabIndex = 0
        Me.iconBox.TabStop = False
        '
        'PanelMessage
        '
        Me.PanelMessage.AutoScroll = True
        Me.PanelMessage.Controls.Add(Me.message)
        Me.PanelMessage.Location = New System.Drawing.Point(103, 41)
        Me.PanelMessage.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelMessage.Name = "PanelMessage"
        Me.PanelMessage.Size = New System.Drawing.Size(293, 77)
        Me.PanelMessage.TabIndex = 350
        '
        'message
        '
        Me.message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.message.BackColor = System.Drawing.Color.Transparent
        Me.message.Font = New System.Drawing.Font("Bookman Old Style", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message.ForeColor = System.Drawing.Color.White
        Me.message.Location = New System.Drawing.Point(2, 1)
        Me.message.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(254, 77)
        Me.message.TabIndex = 0
        Me.message.Text = "message"
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.AutoSize = True
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Font = New System.Drawing.Font("Trajan Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.White
        Me.title.Location = New System.Drawing.Point(178, 11)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(55, 20)
        Me.title.TabIndex = 1
        Me.title.Text = "Title"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MessageBoxChild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(400, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.AlphaGradientPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Yi Baiti", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageBoxChild"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Gainsboro
        Me.AlphaGradientPanel1.ResumeLayout(False)
        Me.AlphaGradientPanel1.PerformLayout()
        CType(Me.iconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelMessage As Windows.Forms.Panel
    Friend WithEvents message As Label
    Friend WithEvents iconBox As Windows.Forms.PictureBox
    Friend WithEvents title As Label
    Friend WithEvents AlphaGradientPanel1 As BlueActivity.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents ContinueBtn As Windows.Forms.Button
    Friend WithEvents cancelBtn As Windows.Forms.Button
End Class
