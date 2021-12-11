Imports System.Drawing
Imports System.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class meteo_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(meteo_frm))
        Me.weather_pic = New System.Windows.Forms.PictureBox()
        Me.city_txt = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.site_combo = New System.Windows.Forms.ComboBox()
        Me.select_location_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.descricao_txt = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.meteo_txt = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.PictureBoxDoubleBuffer1 = New ConstructionSiteLogistics.Gui.Forms.Core.PictureBoxDoubleBuffer()
        Me.AlphaGradientPanel1 = New BlueActivity.AlphaGradientPanel()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        Me.LabelDoubleBuffer1 = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.LabelDoubleBuffer2 = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.weather_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxDoubleBuffer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlphaGradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'weather_pic
        '
        Me.weather_pic.Image = CType(resources.GetObject("weather_pic.Image"), System.Drawing.Image)
        Me.weather_pic.InitialImage = CType(resources.GetObject("weather_pic.InitialImage"), System.Drawing.Image)
        Me.weather_pic.Location = New System.Drawing.Point(740, 768)
        Me.weather_pic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.weather_pic.Name = "weather_pic"
        Me.weather_pic.Size = New System.Drawing.Size(116, 116)
        Me.weather_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.weather_pic.TabIndex = 1
        Me.weather_pic.TabStop = False
        '
        'city_txt
        '
        Me.city_txt.AutoSize = True
        Me.city_txt.BackColor = System.Drawing.Color.Maroon
        Me.city_txt.Font = New System.Drawing.Font("Verdana", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_txt.ForeColor = System.Drawing.Color.White
        Me.city_txt.Location = New System.Drawing.Point(341, 768)
        Me.city_txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.city_txt.Name = "city_txt"
        Me.city_txt.Size = New System.Drawing.Size(379, 116)
        Me.city_txt.TabIndex = 2
        Me.city_txt.Text = "Cidade"
        '
        'site_combo
        '
        Me.site_combo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.site_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.site_combo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_combo.FormattingEnabled = True
        Me.site_combo.Location = New System.Drawing.Point(18, 81)
        Me.site_combo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.site_combo.Name = "site_combo"
        Me.site_combo.Size = New System.Drawing.Size(612, 441)
        Me.site_combo.TabIndex = 3
        '
        'select_location_lbl
        '
        Me.select_location_lbl.AutoSize = True
        Me.select_location_lbl.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_location_lbl.ForeColor = System.Drawing.Color.White
        Me.select_location_lbl.Location = New System.Drawing.Point(27, 36)
        Me.select_location_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.select_location_lbl.Name = "select_location_lbl"
        Me.select_location_lbl.Size = New System.Drawing.Size(327, 44)
        Me.select_location_lbl.TabIndex = 4
        Me.select_location_lbl.Text = "Another Location"
        '
        'descricao_txt
        '
        Me.descricao_txt.AutoSize = True
        Me.descricao_txt.BackColor = System.Drawing.Color.Maroon
        Me.descricao_txt.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao_txt.ForeColor = System.Drawing.Color.White
        Me.descricao_txt.Location = New System.Drawing.Point(341, 905)
        Me.descricao_txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.descricao_txt.Name = "descricao_txt"
        Me.descricao_txt.Size = New System.Drawing.Size(40, 29)
        Me.descricao_txt.TabIndex = 5
        Me.descricao_txt.Text = "..."
        '
        'meteo_txt
        '
        Me.meteo_txt.AutoSize = True
        Me.meteo_txt.BackColor = System.Drawing.Color.Maroon
        Me.meteo_txt.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meteo_txt.ForeColor = System.Drawing.Color.White
        Me.meteo_txt.Location = New System.Drawing.Point(31, 640)
        Me.meteo_txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.meteo_txt.Name = "meteo_txt"
        Me.meteo_txt.Size = New System.Drawing.Size(371, 34)
        Me.meteo_txt.TabIndex = 6
        Me.meteo_txt.Text = "Aguarde um momento...."
        '
        'PictureBoxDoubleBuffer1
        '
        Me.PictureBoxDoubleBuffer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxDoubleBuffer1.Image = CType(resources.GetObject("PictureBoxDoubleBuffer1.Image"), System.Drawing.Image)
        Me.PictureBoxDoubleBuffer1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxDoubleBuffer1.Name = "PictureBoxDoubleBuffer1"
        Me.PictureBoxDoubleBuffer1.Size = New System.Drawing.Size(1850, 1166)
        Me.PictureBoxDoubleBuffer1.TabIndex = 338
        Me.PictureBoxDoubleBuffer1.TabStop = False
        '
        'AlphaGradientPanel1
        '
        Me.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.AlphaGradientPanel1.Border = True
        Me.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.AlphaGradientPanel1.Colors.Add(Me.ColorWithAlpha1)
        Me.AlphaGradientPanel1.ContentPadding = New System.Windows.Forms.Padding(0)
        Me.AlphaGradientPanel1.Controls.Add(Me.Label1)
        Me.AlphaGradientPanel1.Controls.Add(Me.LabelDoubleBuffer2)
        Me.AlphaGradientPanel1.Controls.Add(Me.site_combo)
        Me.AlphaGradientPanel1.Controls.Add(Me.select_location_lbl)
        Me.AlphaGradientPanel1.Controls.Add(Me.meteo_txt)
        Me.AlphaGradientPanel1.CornerRadius = 50
        Me.AlphaGradientPanel1.Corners = CType((BlueActivity.Corner.TopLeft Or BlueActivity.Corner.BottomLeft), BlueActivity.Corner)
        Me.AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Right
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
        Me.AlphaGradientPanel1.Location = New System.Drawing.Point(1207, 0)
        Me.AlphaGradientPanel1.Name = "AlphaGradientPanel1"
        Me.AlphaGradientPanel1.Rounded = True
        Me.AlphaGradientPanel1.Size = New System.Drawing.Size(643, 1166)
        Me.AlphaGradientPanel1.TabIndex = 339
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 80
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Me.AlphaGradientPanel1
        '
        'LabelDoubleBuffer1
        '
        Me.LabelDoubleBuffer1.AutoSize = True
        Me.LabelDoubleBuffer1.BackColor = System.Drawing.Color.Maroon
        Me.LabelDoubleBuffer1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDoubleBuffer1.ForeColor = System.Drawing.Color.White
        Me.LabelDoubleBuffer1.Location = New System.Drawing.Point(21, 768)
        Me.LabelDoubleBuffer1.Name = "LabelDoubleBuffer1"
        Me.LabelDoubleBuffer1.Size = New System.Drawing.Size(297, 166)
        Me.LabelDoubleBuffer1.TabIndex = 340
        Me.LabelDoubleBuffer1.Text = "16º"
        '
        'LabelDoubleBuffer2
        '
        Me.LabelDoubleBuffer2.AutoSize = True
        Me.LabelDoubleBuffer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDoubleBuffer2.ForeColor = System.Drawing.Color.White
        Me.LabelDoubleBuffer2.Location = New System.Drawing.Point(11, 580)
        Me.LabelDoubleBuffer2.Name = "LabelDoubleBuffer2"
        Me.LabelDoubleBuffer2.Size = New System.Drawing.Size(273, 40)
        Me.LabelDoubleBuffer2.TabIndex = 7
        Me.LabelDoubleBuffer2.Text = "Weather Details"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 557)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(616, 4)
        Me.Label1.TabIndex = 8
        '
        'meteo_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1850, 1166)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelDoubleBuffer1)
        Me.Controls.Add(Me.city_txt)
        Me.Controls.Add(Me.weather_pic)
        Me.Controls.Add(Me.descricao_txt)
        Me.Controls.Add(Me.AlphaGradientPanel1)
        Me.Controls.Add(Me.PictureBoxDoubleBuffer1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "meteo_frm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informação Meteorologica"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        CType(Me.weather_pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxDoubleBuffer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlphaGradientPanel1.ResumeLayout(False)
        Me.AlphaGradientPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents weather_pic As PictureBox
    Friend WithEvents city_txt As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents site_combo As ComboBox
    Friend WithEvents select_location_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents descricao_txt As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents meteo_txt As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents PictureBoxDoubleBuffer1 As Gui.Forms.Core.PictureBoxDoubleBuffer
    Friend WithEvents AlphaGradientPanel1 As BlueActivity.AlphaGradientPanel
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelDoubleBuffer2 As Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents LabelDoubleBuffer1 As Gui.Forms.Core.LabelDoubleBuffer
End Class
