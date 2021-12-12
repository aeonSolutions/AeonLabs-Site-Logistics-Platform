Imports System.Drawing.Text
Imports System.Globalization


Public Class setupWizard_addOns
    Private translations As New languageTranslations
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("AddonsTitle")
            subtitle.Text = translations.getText("AddonsSubTitle")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")

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
        title.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 12, FontStyle.Regular)

        enableTranslation.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        translation_provider_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        translation_apikey_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        translationProvider.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        translationApiKey.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        enableWeather.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        weather_provider_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        weather_apikey_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        weatherProvider.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        weatherApiKey.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)

        translationProvider.SelectedIndex = 0
        weatherProvider.SelectedIndex = 0
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()
        setupWizard_createDB.Show()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        If enableTranslation.Checked And (translationProvider.SelectedIndex < 0 Or translationApiKey.Text.Equals("")) Then
            Exit Sub
        End If
        If enableWeather.Checked And (weatherProvider.SelectedIndex < 0 Or weatherApiKey.Text.Equals("")) Then
            Exit Sub
        End If

        If enableTranslation.Checked Then
            setupWizard_country.settings.isTranslationEnabled = True
            setupWizard_country.settings.translationProvider = translationProvider.SelectedItem.ToString
            setupWizard_country.settings.translationApiKey = translationApiKey.Text
        End If
        If enableWeather.Checked Then
            setupWizard_country.settings.isWeatherEnabled = True
            setupWizard_country.settings.weatherProvider = weatherProvider.SelectedItem.ToString
            setupWizard_country.settings.weatherApiKey = weatherApiKey.Text
        End If
        Me.Hide()
        setupWizard_createAdminAccount.Show()
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class