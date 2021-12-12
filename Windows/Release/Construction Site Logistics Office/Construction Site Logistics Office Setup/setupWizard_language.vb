Imports System.Drawing.Text
Imports System.Globalization


Public Class setupWizard_language
    Private state As New State
    Private countryList As New SortedDictionary(Of String, String)
    Private translations As languageTranslations

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

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
            translations = New languageTranslations(state)
            translations.load("setupWizard")
            title.Text = translations.getText("titleCountry")
            subtitle.Text = translations.getText("subtitleCountry")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            show_all_lang.Text = translations.getText("showAll")
            defaultLanguage.Text = translations.getText("chooseDefaultLanguage")
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        ListBox1.Font = New Font(state.fontText.Families(0), 9, FontStyle.Regular)
        show_all_lang.Font = New Font(state.fontText.Families(0), 9, FontStyle.Regular)
        btnBackTxt.Font = New Font(state.fontText.Families(0), 9, FontStyle.Bold)
        btnContinueTxt.Font = New Font(state.fontText.Families(0), 9, FontStyle.Bold)
        defaultLanguage.Font = New Font(state.fontText.Families(0), 12, FontStyle.Bold)

        GetAllCountryLanguages("short")
        Me.ResumeLayout()
    End Sub

    Public Sub GetAllCountryLanguages(listType As String)
        ' Iterate the Framework Cultures...
        Dim shortcountryList As New List(Of String)
        shortcountryList.Add("fr")
        shortcountryList.Add("en")
        shortcountryList.Add("es")
        shortcountryList.Add("pt")
        shortcountryList.Add("nl")

        ListBox1.Items.Clear()
        countryList.Clear()


        Dim ci As CultureInfo
        For Each ci In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            If show_all_lang.Checked Then
                If Not countryList.ContainsKey(ci.DisplayName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    ListBox1.Items.Add(ci.DisplayName)
                End If
            Else
                If Not countryList.ContainsKey(ci.DisplayName) And shortcountryList.Contains(ci.TwoLetterISOLanguageName) Then
                    countryList.Add(newKeyValuePair.Key, newKeyValuePair.Value)
                    ListBox1.Items.Add(ci.DisplayName)
                End If
            End If
        Next ci

    End Sub




    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else

            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        continueBtn()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        continueBtn()
    End Sub

    Private Sub continueBtn()
        If ListBox1.SelectedIndex > -1 Then

            setupWizard_country.settings.lang = countryList.Item(ListBox1.SelectedItem.ToString)
            setupWizard_country.state.currentLang = setupWizard_country.settings.lang
            Me.Hide()
            setupWizard_platformType.Show()
        End If
    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            GetAllCountryLanguages("all")
        Else
            GetAllCountryLanguages("short")
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        wizardGoBack()
    End Sub

    Private Sub btnBackTxt_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()
        setupWizard_country.Show()
    End Sub
End Class