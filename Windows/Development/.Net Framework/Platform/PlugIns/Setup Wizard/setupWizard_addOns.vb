Imports System.Drawing
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_addOns
    Private translations As New languageTranslations
    Private mainform As setupWizardMainForm
    Public Sub preLoadData(_mainForm As setupWizardMainForm)
        mainform = _mainForm
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)


        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")

            enableTranslation.Text = translations.getText("AddonsSelectTranslations")
            translation_provider_lbl.Text = translations.getText("AddonsProvider")
            translation_apikey_lbl.Text = translations.getText("AddonsApiKey")
            enableWeather.Text = translations.getText("AddonsSelectWeather")
            weather_provider_lbl.Text = translations.getText("AddonsProvider")
            weather_apikey_lbl.Text = translations.getText("AddonsApiKey")

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        enableTranslation.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        translation_provider_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        translation_apikey_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        translationProvider.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        translationApiKey.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        enableWeather.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        weather_provider_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        weather_apikey_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        weatherProvider.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        weatherApiKey.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

        translationProvider.SelectedIndex = 0
        weatherProvider.SelectedIndex = 0
    End Sub

    Private Sub wizardGoForward()
        If enableTranslation.Checked And (translationProvider.SelectedIndex < 0 Or translationApiKey.Text.Equals("")) Then
            Exit Sub
        End If
        If enableWeather.Checked And (weatherProvider.SelectedIndex < 0 Or weatherApiKey.Text.Equals("")) Then
            Exit Sub
        End If

        If enableTranslation.Checked Then
            mainform.settings.isTranslationEnabled = True
            mainform.settings.translationProvider = translationProvider.SelectedItem.ToString
            mainform.settings.translationApiKey = translationApiKey.Text
        End If
        If enableWeather.Checked Then
            mainform.settings.isWeatherEnabled = True
            mainform.settings.weatherProvider = weatherProvider.SelectedItem.ToString
            mainform.settings.weatherApiKey = weatherApiKey.Text
        End If
    End Sub

    Private Sub enableTranlation_CheckedChanged(sender As Object, e As EventArgs) Handles enableTranslation.CheckedChanged
        If enableTranslation.Checked Then
            translationApiKey.Enabled = True
            translationProvider.Enabled = True
            translation_apikey_lbl.ForeColor = Color.Black
            translation_provider_lbl.ForeColor = Color.Black
        Else
            translationApiKey.Enabled = False
            translationProvider.Enabled = False
            translation_apikey_lbl.ForeColor = Color.Gray
            translation_provider_lbl.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub enableWeather_CheckedChanged(sender As Object, e As EventArgs) Handles enableWeather.CheckedChanged
        If enableWeather.Checked Then
            weatherApiKey.Enabled = True
            weatherProvider.Enabled = True
            weather_apikey_lbl.ForeColor = Color.Black
            weather_provider_lbl.ForeColor = Color.Black
        Else
            weatherApiKey.Enabled = False
            weatherProvider.Enabled = False
            weather_apikey_lbl.ForeColor = Color.Gray
            weather_provider_lbl.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub weather_provider_lbl_Click(sender As Object, e As EventArgs) Handles weather_provider_lbl.Click

    End Sub
End Class