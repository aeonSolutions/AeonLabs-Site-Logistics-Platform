Imports System.Drawing
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_language
    Private stateCore As New environmentVars
    Private countryList As New SortedDictionary(Of String, String)
    Private translations As languageTranslations
    Private mainform As setupWizardMainForm
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Public Sub preLoadData(_mainForm As setupWizardMainForm)
        mainform = _mainForm
        stateCore = mainform.enVars
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
            translations = New languageTranslations(stateCore)
            translations.load("setupWizard")

            If mainform.settings.lang Is Nothing Then
                selectionOkpic.Visible = False
            Else
                selectionOkpic.Visible = True
            End If

            show_all_lang.Text = translations.getText("showAll")
                defaultLanguage.Text = translations.getText("chooseDefaultLanguage")
                Me.ResumeLayout()
            End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        ListBox1.Font = New Font(stateCore.fontText.Families(0), 9, FontStyle.Regular)
        show_all_lang.Font = New Font(stateCore.fontText.Families(0), 9, FontStyle.Regular)
        defaultLanguage.Font = New Font(stateCore.fontText.Families(0), 12, FontStyle.Bold)

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
        mainform.settings.lang = countryList.Item(ListBox1.SelectedItem.ToString)
        selectionOkpic.Visible = True
    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            GetAllCountryLanguages("all")
        Else
            GetAllCountryLanguages("short")
        End If
    End Sub

    Private Sub AlphaGradientPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class