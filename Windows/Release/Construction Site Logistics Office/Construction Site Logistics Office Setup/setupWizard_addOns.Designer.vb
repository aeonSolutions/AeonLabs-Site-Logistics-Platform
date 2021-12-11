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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.translation_apikey_lbl = New System.Windows.Forms.Label()
        Me.translationApiKey = New System.Windows.Forms.TextBox()
        Me.weather_provider_lbl = New System.Windows.Forms.Label()
        Me.weatherProvider = New System.Windows.Forms.ComboBox()
        Me.translation_provider_lbl = New System.Windows.Forms.Label()
        Me.translationProvider = New System.Windows.Forms.ComboBox()
        Me.enableWeather = New System.Windows.Forms.CheckBox()
        Me.enableTranslation = New System.Windows.Forms.CheckBox()
        Me.weather_apikey_lbl = New System.Windows.Forms.Label()
        Me.weatherApiKey = New System.Windows.Forms.TextBox()
        Me.btnBackTxt = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnContinueTxt = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.subtitle = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.translation_apikey_lbl)
        Me.Panel1.Controls.Add(Me.translationApiKey)
        Me.Panel1.Controls.Add(Me.weather_provider_lbl)
        Me.Panel1.Controls.Add(Me.weatherProvider)
        Me.Panel1.Controls.Add(Me.translation_provider_lbl)
        Me.Panel1.Controls.Add(Me.translationProvider)
        Me.Panel1.Controls.Add(Me.enableWeather)
        Me.Panel1.Controls.Add(Me.enableTranslation)
        Me.Panel1.Controls.Add(Me.weather_apikey_lbl)
        Me.Panel1.Controls.Add(Me.weatherApiKey)
        Me.Panel1.Controls.Add(Me.btnBackTxt)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btnContinueTxt)
        Me.Panel1.Controls.Add(Me.btnContinue)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.subtitle)
        Me.Panel1.Controls.Add(Me.title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(775, 640)
        Me.Panel1.TabIndex = 1
        '
        'translation_apikey_lbl
        '
        Me.translation_apikey_lbl.AutoSize = True
        Me.translation_apikey_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_apikey_lbl.ForeColor = System.Drawing.Color.Gray
        Me.translation_apikey_lbl.Location = New System.Drawing.Point(326, 213)
        Me.translation_apikey_lbl.Name = "translation_apikey_lbl"
        Me.translation_apikey_lbl.Size = New System.Drawing.Size(48, 15)
        Me.translation_apikey_lbl.TabIndex = 21
        Me.translation_apikey_lbl.Text = "API Key"
        '
        'translationApiKey
        '
        Me.translationApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translationApiKey.Location = New System.Drawing.Point(384, 207)
        Me.translationApiKey.Name = "translationApiKey"
        Me.translationApiKey.Size = New System.Drawing.Size(236, 21)
        Me.translationApiKey.TabIndex = 20
        '
        'weather_provider_lbl
        '
        Me.weather_provider_lbl.AutoSize = True
        Me.weather_provider_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_provider_lbl.ForeColor = System.Drawing.Color.Gray
        Me.weather_provider_lbl.Location = New System.Drawing.Point(326, 285)
        Me.weather_provider_lbl.Name = "weather_provider_lbl"
        Me.weather_provider_lbl.Size = New System.Drawing.Size(52, 15)
        Me.weather_provider_lbl.TabIndex = 19
        Me.weather_provider_lbl.Text = "Provider"
        '
        'weatherProvider
        '
        Me.weatherProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.weatherProvider.FormattingEnabled = True
        Me.weatherProvider.Items.AddRange(New Object() {"OpenWeatherMap.org"})
        Me.weatherProvider.Location = New System.Drawing.Point(384, 283)
        Me.weatherProvider.Name = "weatherProvider"
        Me.weatherProvider.Size = New System.Drawing.Size(142, 21)
        Me.weatherProvider.TabIndex = 18
        '
        'translation_provider_lbl
        '
        Me.translation_provider_lbl.AutoSize = True
        Me.translation_provider_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.translation_provider_lbl.ForeColor = System.Drawing.Color.Gray
        Me.translation_provider_lbl.Location = New System.Drawing.Point(326, 182)
        Me.translation_provider_lbl.Name = "translation_provider_lbl"
        Me.translation_provider_lbl.Size = New System.Drawing.Size(52, 15)
        Me.translation_provider_lbl.TabIndex = 17
        Me.translation_provider_lbl.Text = "Provider"
        '
        'translationProvider
        '
        Me.translationProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.translationProvider.FormattingEnabled = True
        Me.translationProvider.Items.AddRange(New Object() {"Google"})
        Me.translationProvider.Location = New System.Drawing.Point(384, 180)
        Me.translationProvider.Name = "translationProvider"
        Me.translationProvider.Size = New System.Drawing.Size(142, 21)
        Me.translationProvider.TabIndex = 16
        '
        'enableWeather
        '
        Me.enableWeather.AutoSize = True
        Me.enableWeather.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableWeather.Location = New System.Drawing.Point(301, 258)
        Me.enableWeather.Name = "enableWeather"
        Me.enableWeather.Size = New System.Drawing.Size(259, 19)
        Me.enableWeather.TabIndex = 15
        Me.enableWeather.Text = "Enable weather reports inside the platform"
        Me.enableWeather.UseVisualStyleBackColor = True
        '
        'enableTranslation
        '
        Me.enableTranslation.AutoSize = True
        Me.enableTranslation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enableTranslation.Location = New System.Drawing.Point(301, 155)
        Me.enableTranslation.Name = "enableTranslation"
        Me.enableTranslation.Size = New System.Drawing.Size(231, 19)
        Me.enableTranslation.TabIndex = 14
        Me.enableTranslation.Text = "Enable translation inside the platform"
        Me.enableTranslation.UseVisualStyleBackColor = True
        '
        'weather_apikey_lbl
        '
        Me.weather_apikey_lbl.AutoSize = True
        Me.weather_apikey_lbl.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weather_apikey_lbl.ForeColor = System.Drawing.Color.Gray
        Me.weather_apikey_lbl.Location = New System.Drawing.Point(326, 313)
        Me.weather_apikey_lbl.Name = "weather_apikey_lbl"
        Me.weather_apikey_lbl.Size = New System.Drawing.Size(48, 15)
        Me.weather_apikey_lbl.TabIndex = 13
        Me.weather_apikey_lbl.Text = "API Key"
        '
        'weatherApiKey
        '
        Me.weatherApiKey.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weatherApiKey.Location = New System.Drawing.Point(384, 310)
        Me.weatherApiKey.Name = "weatherApiKey"
        Me.weatherApiKey.Size = New System.Drawing.Size(236, 21)
        Me.weatherApiKey.TabIndex = 12
        '
        'btnBackTxt
        '
        Me.btnBackTxt.AutoSize = True
        Me.btnBackTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnBackTxt.Location = New System.Drawing.Point(301, 596)
        Me.btnBackTxt.Name = "btnBackTxt"
        Me.btnBackTxt.Size = New System.Drawing.Size(36, 13)
        Me.btnBackTxt.TabIndex = 10
        Me.btnBackTxt.Text = "Back"
        Me.btnBackTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(301, 558)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'btnContinueTxt
        '
        Me.btnContinueTxt.AutoSize = True
        Me.btnContinueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinueTxt.ForeColor = System.Drawing.Color.DimGray
        Me.btnContinueTxt.Location = New System.Drawing.Point(379, 596)
        Me.btnContinueTxt.Name = "btnContinueTxt"
        Me.btnContinueTxt.Size = New System.Drawing.Size(57, 13)
        Me.btnContinueTxt.TabIndex = 8
        Me.btnContinueTxt.Text = "Continue"
        Me.btnContinueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnContinue
        '
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.Location = New System.Drawing.Point(391, 558)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(35, 35)
        Me.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(22, 137)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(239, 229)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'subtitle
        '
        Me.subtitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subtitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subtitle.ForeColor = System.Drawing.Color.Gray
        Me.subtitle.Location = New System.Drawing.Point(11, 77)
        Me.subtitle.Name = "subtitle"
        Me.subtitle.Size = New System.Drawing.Size(759, 32)
        Me.subtitle.TabIndex = 1
        Me.subtitle.Text = "Fill out the following information to configure Addons"
        Me.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.title.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.Gray
        Me.title.Location = New System.Drawing.Point(11, 6)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(751, 55)
        Me.title.TabIndex = 0
        Me.title.Text = "Configure Addons "
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'setupWizard_addOns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 640)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "setupWizard_addOns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnContinue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents subtitle As Label
    Friend WithEvents title As Label
    Friend WithEvents btnContinueTxt As Label
    Friend WithEvents btnContinue As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnBackTxt As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents weather_apikey_lbl As Label
    Friend WithEvents weatherApiKey As TextBox
    Friend WithEvents translation_apikey_lbl As Label
    Friend WithEvents translationApiKey As TextBox
    Friend WithEvents weather_provider_lbl As Label
    Friend WithEvents weatherProvider As ComboBox
    Friend WithEvents translation_provider_lbl As Label
    Friend WithEvents translationProvider As ComboBox
    Friend WithEvents enableWeather As CheckBox
    Friend WithEvents enableTranslation As CheckBox
End Class
