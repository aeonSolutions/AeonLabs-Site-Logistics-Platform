Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class setupWizard_addOns
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(setupWizard_addOns))
        Me.translation_apikey_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.translationApiKey = New System.Windows.Forms.TextBox()
        Me.weather_provider_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.weatherProvider = New System.Windows.Forms.ComboBox()
        Me.translation_provider_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.translationProvider = New System.Windows.Forms.ComboBox()
        Me.enableWeather = New System.Windows.Forms.CheckBox()
        Me.enableTranslation = New System.Windows.Forms.CheckBox()
        Me.weather_apikey_lbl = New ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer()
        Me.weatherApiKey = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColorWithAlpha1 = New BlueActivity.ColorWithAlpha()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'translation_apikey_lbl
        '
        Me.translation_apikey_lbl.AutoSize = True
        Me.translation_apikey_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_apikey_lbl.ForeColor = System.Drawing.Color.Black
        Me.translation_apikey_lbl.Location = New System.Drawing.Point(762, 267)
        Me.translation_apikey_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.translation_apikey_lbl.Name = "translation_apikey_lbl"
        Me.translation_apikey_lbl.Size = New System.Drawing.Size(83, 23)
        Me.translation_apikey_lbl.TabIndex = 21
        Me.translation_apikey_lbl.Text = "API Key"
        '
        'translationApiKey
        '
        Me.translationApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationApiKey.Location = New System.Drawing.Point(853, 262)
        Me.translationApiKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.translationApiKey.Name = "translationApiKey"
        Me.translationApiKey.Size = New System.Drawing.Size(352, 28)
        Me.translationApiKey.TabIndex = 20
        '
        'weather_provider_lbl
        '
        Me.weather_provider_lbl.AutoSize = True
        Me.weather_provider_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_provider_lbl.ForeColor = System.Drawing.Color.Black
        Me.weather_provider_lbl.Location = New System.Drawing.Point(740, 392)
        Me.weather_provider_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weather_provider_lbl.Name = "weather_provider_lbl"
        Me.weather_provider_lbl.Size = New System.Drawing.Size(105, 23)
        Me.weather_provider_lbl.TabIndex = 19
        Me.weather_provider_lbl.Text = "Provider"
        '
        'weatherProvider
        '
        Me.weatherProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.weatherProvider.FormattingEnabled = True
        Me.weatherProvider.Items.AddRange(New Object() {"OpenWeatherMap.org"})
        Me.weatherProvider.Location = New System.Drawing.Point(853, 387)
        Me.weatherProvider.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.weatherProvider.Name = "weatherProvider"
        Me.weatherProvider.Size = New System.Drawing.Size(211, 28)
        Me.weatherProvider.TabIndex = 18
        '
        'translation_provider_lbl
        '
        Me.translation_provider_lbl.AutoSize = True
        Me.translation_provider_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_provider_lbl.ForeColor = System.Drawing.Color.Black
        Me.translation_provider_lbl.Location = New System.Drawing.Point(740, 229)
        Me.translation_provider_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.translation_provider_lbl.Name = "translation_provider_lbl"
        Me.translation_provider_lbl.Size = New System.Drawing.Size(105, 23)
        Me.translation_provider_lbl.TabIndex = 17
        Me.translation_provider_lbl.Text = "Provider"
        '
        'translationProvider
        '
        Me.translationProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.translationProvider.FormattingEnabled = True
        Me.translationProvider.Items.AddRange(New Object() {"Google"})
        Me.translationProvider.Location = New System.Drawing.Point(853, 224)
        Me.translationProvider.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.translationProvider.Name = "translationProvider"
        Me.translationProvider.Size = New System.Drawing.Size(211, 28)
        Me.translationProvider.TabIndex = 16
        '
        'enableWeather
        '
        Me.enableWeather.AutoSize = True
        Me.enableWeather.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableWeather.Location = New System.Drawing.Point(703, 346)
        Me.enableWeather.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.enableWeather.Name = "enableWeather"
        Me.enableWeather.Size = New System.Drawing.Size(492, 27)
        Me.enableWeather.TabIndex = 15
        Me.enableWeather.Text = "Enable weather reports inside the platform"
        Me.enableWeather.UseVisualStyleBackColor = True
        '
        'enableTranslation
        '
        Me.enableTranslation.AutoSize = True
        Me.enableTranslation.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableTranslation.Location = New System.Drawing.Point(703, 187)
        Me.enableTranslation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.enableTranslation.Name = "enableTranslation"
        Me.enableTranslation.Size = New System.Drawing.Size(448, 27)
        Me.enableTranslation.TabIndex = 14
        Me.enableTranslation.Text = "Enable translation inside the platform"
        Me.enableTranslation.UseVisualStyleBackColor = True
        '
        'weather_apikey_lbl
        '
        Me.weather_apikey_lbl.AutoSize = True
        Me.weather_apikey_lbl.Font = New System.Drawing.Font("Trajan Pro", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_apikey_lbl.ForeColor = System.Drawing.Color.Black
        Me.weather_apikey_lbl.Location = New System.Drawing.Point(762, 430)
        Me.weather_apikey_lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.weather_apikey_lbl.Name = "weather_apikey_lbl"
        Me.weather_apikey_lbl.Size = New System.Drawing.Size(83, 23)
        Me.weather_apikey_lbl.TabIndex = 13
        Me.weather_apikey_lbl.Text = "API Key"
        '
        'weatherApiKey
        '
        Me.weatherApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weatherApiKey.Location = New System.Drawing.Point(853, 425)
        Me.weatherApiKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.weatherApiKey.Name = "weatherApiKey"
        Me.weatherApiKey.Size = New System.Drawing.Size(352, 28)
        Me.weatherApiKey.TabIndex = 12
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(284, 160)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(358, 352)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ColorWithAlpha1
        '
        Me.ColorWithAlpha1.Alpha = 150
        Me.ColorWithAlpha1.Color = System.Drawing.Color.Black
        Me.ColorWithAlpha1.Parent = Nothing
        '
        'setupWizard_addOns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1600, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.translation_apikey_lbl)
        Me.Controls.Add(Me.translationApiKey)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.weather_provider_lbl)
        Me.Controls.Add(Me.weather_apikey_lbl)
        Me.Controls.Add(Me.weatherApiKey)
        Me.Controls.Add(Me.weatherProvider)
        Me.Controls.Add(Me.enableTranslation)
        Me.Controls.Add(Me.translation_provider_lbl)
        Me.Controls.Add(Me.enableWeather)
        Me.Controls.Add(Me.translationProvider)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "setupWizard_addOns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents weather_apikey_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents weatherApiKey As TextBox
    Friend WithEvents translation_apikey_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents translationApiKey As TextBox
    Friend WithEvents weather_provider_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents weatherProvider As ComboBox
    Friend WithEvents translation_provider_lbl As ConstructionSiteLogistics.Gui.Forms.Core.LabelDoubleBuffer
    Friend WithEvents translationProvider As ComboBox
    Friend WithEvents enableWeather As CheckBox
    Friend WithEvents enableTranslation As CheckBox
    Friend WithEvents ColorWithAlpha1 As BlueActivity.ColorWithAlpha
End Class
