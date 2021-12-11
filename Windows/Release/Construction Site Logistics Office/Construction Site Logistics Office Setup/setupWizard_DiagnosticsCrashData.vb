Imports System.Drawing.Text
Imports System.Globalization
Imports ConstructionSiteLogistics

Public Class setupWizard_DiagnosticsCrashData
    Private state As New State
    Private countryList As New SortedDictionary(Of String, String)
    Private translations As languageTranslations

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        share.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        share_details.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        send.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        send_details.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        about_diagnostics.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)

        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        Me.BringToFront()

        about_diagnostics.Links.Add(0, about_diagnostics.Text.Length - 1, "http://sitelogistics.construction/aboutdiagnostics")
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("titleDiagnostics")
            subtitle.Text = translations.getText("subtitlePlatformType")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            send.Text = translations.getText("sendDiagnostics")
            share.Text = translations.getText("shareCrashData")
            share_details.Text = translations.getText("crashDataDescription")
            send_details.Text = translations.getText("diagnosticsDescritpion")

            Me.ResumeLayout()
            If Not IsNothing(setupWizard_country.settings.sendDiags) Then
                If setupWizard_country.settings.sendDiags Then
                    send.Checked = True
                Else
                    send.Checked = False
                End If
            End If
            If Not IsNothing(setupWizard_country.settings.sendCrash) Then
                If setupWizard_country.settings.sendCrash Then
                    share.Checked = True
                Else
                    share.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        ' only if is a new setup 
        Me.Hide()
        If setupWizard_country.settings.isSharedServer Then
            If setupWizard_country.settings.isNewServer Then
                'ToDo: setup new shared
            Else
                'ToDo: setup exisiting shared
            End If
        Else
            If setupWizard_country.settings.isNewServer Then
                setupWizard_NewFtpWebSettings.Show()
            Else
                setupWizard_ServerAddress.Show()
            End If
        End If

    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()

        If send.Checked Then
            setupWizard_country.settings.sendDiags = True
        Else
            setupWizard_country.settings.sendDiags = False
        End If
        If share.Checked Then
            setupWizard_country.settings.sendCrash = True
        Else
            setupWizard_country.settings.sendCrash = False
        End If

        Me.Hide()
        setupWizard_settingUp.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub send_CheckedChanged(sender As Object, e As EventArgs) Handles send.CheckedChanged
    End Sub

    Private Sub about_diagnostics_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles about_diagnostics.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class