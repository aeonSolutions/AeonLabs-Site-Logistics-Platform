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
        Me.city_txt = New System.Windows.Forms.Label()
        Me.site_combo = New System.Windows.Forms.ComboBox()
        Me.select_location_lbl = New System.Windows.Forms.Label()
        Me.descricao_txt = New System.Windows.Forms.Label()
        Me.meteo_txt = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.weather_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'weather_pic
        '
        Me.weather_pic.Image = CType(resources.GetObject("weather_pic.Image"), System.Drawing.Image)
        Me.weather_pic.InitialImage = CType(resources.GetObject("weather_pic.InitialImage"), System.Drawing.Image)
        Me.weather_pic.Location = New System.Drawing.Point(50, 64)
        Me.weather_pic.Name = "weather_pic"
        Me.weather_pic.Size = New System.Drawing.Size(150, 150)
        Me.weather_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.weather_pic.TabIndex = 1
        Me.weather_pic.TabStop = False
        '
        'city_txt
        '
        Me.city_txt.AutoSize = True
        Me.city_txt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_txt.Location = New System.Drawing.Point(282, 73)
        Me.city_txt.Name = "city_txt"
        Me.city_txt.Size = New System.Drawing.Size(47, 13)
        Me.city_txt.TabIndex = 2
        Me.city_txt.Text = "Cidade"
        '
        'site_combo
        '
        Me.site_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.site_combo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.site_combo.FormattingEnabled = True
        Me.site_combo.Location = New System.Drawing.Point(285, 35)
        Me.site_combo.Name = "site_combo"
        Me.site_combo.Size = New System.Drawing.Size(321, 21)
        Me.site_combo.TabIndex = 3
        '
        'select_location_lbl
        '
        Me.select_location_lbl.AutoSize = True
        Me.select_location_lbl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_location_lbl.Location = New System.Drawing.Point(282, 19)
        Me.select_location_lbl.Name = "select_location_lbl"
        Me.select_location_lbl.Size = New System.Drawing.Size(163, 13)
        Me.select_location_lbl.TabIndex = 4
        Me.select_location_lbl.Text = "Seleccione uma localização"
        '
        'descricao_txt
        '
        Me.descricao_txt.AutoSize = True
        Me.descricao_txt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descricao_txt.Location = New System.Drawing.Point(299, 97)
        Me.descricao_txt.Name = "descricao_txt"
        Me.descricao_txt.Size = New System.Drawing.Size(19, 13)
        Me.descricao_txt.TabIndex = 5
        Me.descricao_txt.Text = "..."
        '
        'meteo_txt
        '
        Me.meteo_txt.AutoSize = True
        Me.meteo_txt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meteo_txt.Location = New System.Drawing.Point(299, 121)
        Me.meteo_txt.Name = "meteo_txt"
        Me.meteo_txt.Size = New System.Drawing.Size(151, 13)
        Me.meteo_txt.TabIndex = 6
        Me.meteo_txt.Text = "Aguarde um momento...."
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Location = New System.Drawing.Point(520, 294)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(86, 26)
        Me.closeBtn.TabIndex = 336
        Me.closeBtn.Text = "Fechar"
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.weather_pic)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.city_txt)
        Me.Panel1.Controls.Add(Me.meteo_txt)
        Me.Panel1.Controls.Add(Me.site_combo)
        Me.Panel1.Controls.Add(Me.descricao_txt)
        Me.Panel1.Controls.Add(Me.select_location_lbl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 332)
        Me.Panel1.TabIndex = 337
        '
        'meteo_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 332)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "meteo_frm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informação Meteorologica"
        CType(Me.weather_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents weather_pic As PictureBox
    Friend WithEvents city_txt As Label
    Friend WithEvents site_combo As ComboBox
    Friend WithEvents select_location_lbl As Label
    Friend WithEvents descricao_txt As Label
    Friend WithEvents meteo_txt As Label
    Friend WithEvents closeBtn As Button
    Friend WithEvents Panel1 As Panel
End Class
