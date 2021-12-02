Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms


Public Class setupWizard_country
    Private mainform As setupWizardMainForm
    Private countryList As New Dictionary(Of String, String)

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub
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
            mainform.translations.load("setupWizard")
            show_all_lang.Text = mainform.translations.getText("showAll")
            chooseCountry.Text = mainform.translations.getText("chooseCountry")
            If mainform.settings.country Is Nothing Then
                selectionOkpic.Visible = False
            Else
                selectionOkpic.Visible = True
            End If
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        show_all_lang.Font = New Font(mainform.enVars.fontText.Families(0), 9, FontStyle.Regular)
        chooseCountry.Font = New Font(mainform.enVars.fontText.Families(0), 12, FontStyle.Bold)
        addCountries("short")
    End Sub

    Private Sub addCountries(listType As String)
        ' Iterate the Framework Cultures...
        Dim shortcountryList As New List(Of String)
        shortcountryList.Add("fr")
        shortcountryList.Add("en")
        shortcountryList.Add("es")
        shortcountryList.Add("pt")
        shortcountryList.Add("nl")

        ListBox1.Items.Clear()
        countryList.Clear()

        For Each ci As CultureInfo In CultureInfo.GetCultures(CultureTypes.AllCultures)
            ' Create new country dictionary entry.
            Dim newKeyValuePair As New KeyValuePair(Of String, String)(ci.DisplayName, ci.TwoLetterISOLanguageName)
            ' If the country is not already in the countryList add it...
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
        Next
        ListBox1.Sorted = True
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        mainform.settings.country = countryList(ListBox1.SelectedItem.ToString)
        selectionOkpic.Visible = True

    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            addCountries("all")
        Else
            addCountries("short")
        End If
    End Sub
End Class