Imports System.Drawing.Text
Imports System.Globalization
Imports ConstructionSiteLogistics

Public Class setupWizard_country
    Public state As New State
    Public defaultEncryptionKey As String = "26kozQaMwRuNJ24t"
    Public defaultApiServerAddrPath As String = "/shared/csaml/api/index.php"

    Public settings As New Settings
    Private countryList As New SortedDictionary(Of String, String)

    Private translations As languageTranslations
    Private programId As New Security.FingerPrint

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

            btnContinueTxt.Text = translations.getText("btnContinue")
            show_all_lang.Text = translations.getText("showAll")
            chooseCountry.Text = translations.getText("chooseCountry")
            settings.programId = programId.Value()
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_0_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        ListBox1.Font = New Font(state.fontText.Families(0), 9, FontStyle.Regular)
        show_all_lang.Font = New Font(state.fontText.Families(0), 9, FontStyle.Regular)

        btnContinueTxt.Font = New Font(state.fontText.Families(0), 9, FontStyle.Bold)
        chooseCountry.Font = New Font(state.fontText.Families(0), 12, FontStyle.Bold)
        addCountries("short")
        Me.ResumeLayout()
        ' check if setup.cfg file exists and load setup
        Dim setupCfg As New setupSettings
        If setupCfg.load() Then
            If Not setupCfg.getText("platform").Equals("error") Then
                If setupCfg.getText("platform").Equals("custom") Then
                    settings.isSharedServer = False
                End If
                If setupCfg.getText("platform").Equals("shared") Then
                    settings.isSharedServer = True
                End If
            End If
            If Not setupCfg.getText("server").Equals("error") Then
                If setupCfg.getText("server").Equals("new") Then
                    settings.isNewServer = True
                End If
                If setupCfg.getText("server").Equals("existing") Then
                    settings.isNewServer = False
                End If
            End If
            If Not setupCfg.getText("serverWebAddress").Equals("error") Then
                settings.serverWebAddr = setupCfg.getText("serverWebAddress")

                settings.serverWebAddr = If(settings.serverWebAddr(settings.serverWebAddr.Length - 1).Equals("/"), settings.serverWebAddr.Substring(0, settings.serverWebAddr.Length - 2), settings.serverWebAddr)
                If settings.serverWebAddr.IndexOf("www.") > -1 And settings.serverWebAddr.IndexOf("http://") = -1 And settings.serverWebAddr.IndexOf("https://") = -1 Then
                    settings.serverWebAddr = "http://" & settings.serverWebAddr
                End If
                If (IsValidUrl("http|https", settings.serverWebAddr).Equals(True)) Then
                    settings.serverWebAddr = setupCfg.getText("serverWebAddress")
                Else
                    settings.serverWebAddr = Nothing
                End If
            End If
            If Not setupCfg.getText("serverFtpAddress").Equals("error") Then
                settings.serverFtpAddr = setupCfg.getText("serverftpAddress")

                settings.serverFtpAddr = If(settings.serverFtpAddr(settings.serverFtpAddr.Length - 1).Equals("/"), settings.serverFtpAddr.Substring(0, settings.serverFtpAddr.Length - 2), settings.serverFtpAddr)
                If settings.serverFtpAddr.IndexOf("ftp.") > -1 And settings.serverFtpAddr.IndexOf("ftp://") = -1 Then
                    settings.serverFtpAddr = "ftp://" & settings.serverFtpAddr
                End If
                If (IsValidUrl("ftp", settings.serverFtpAddr).Equals(True)) Then
                    settings.serverFtpAddr = setupCfg.getText("serverftpAddress")
                Else
                    settings.serverFtpAddr = Nothing
                End If
            End If
            If Not setupCfg.getText("disableOptions").Equals("error") Then
                If setupCfg.getText("disableOptions").Equals("true") Then
                    settings.disableOptions = True
                ElseIf setupCfg.getText("disableOptions").Equals("false") Then
                    settings.disableOptions = False
                End If
            End If

            If Not setupCfg.getText("diagnostics").Equals("error") Then
                If setupCfg.getText("diagnostics").Equals("true") Then
                    settings.sendDiags = True
                ElseIf setupCfg.getText("diagnostics").Equals("false") Then
                    settings.sendDiags = False
                End If
            End If

            If Not setupCfg.getText("crashreports").Equals("error") Then
                If setupCfg.getText("crashreports").Equals("true") Then
                    settings.sendCrash = True
                ElseIf setupCfg.getText("crashreports").Equals("false") Then
                    settings.sendCrash = False
                End If
            End If
        End If

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
        If ListBox1.SelectedIndex > -1 Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
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
            settings.country = ListBox1.SelectedItem.ToString
            Me.Hide()
            setupWizard_language.Show()
        End If
    End Sub

    Private Sub show_all_lang_CheckedChanged(sender As Object, e As EventArgs) Handles show_all_lang.CheckedChanged
        If show_all_lang.Checked Then
            addCountries("all")
        Else
            addCountries("short")
        End If
    End Sub

    Private Sub title_Click(sender As Object, e As EventArgs) Handles title.Click

    End Sub
End Class