Imports System.Drawing
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_DiagnosticsCrashData
    Private countryList As New SortedDictionary(Of String, String)
    Private translations As languageTranslations
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

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        share.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        share_details.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        send.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        send_details.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        about_diagnostics.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

        Me.BringToFront()

        about_diagnostics.Links.Add(0, about_diagnostics.Text.Length - 1, "http://sitelogistics.construction/aboutdiagnostics")
    End Sub

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")

            send.Text = translations.getText("sendDiagnostics")
            share.Text = translations.getText("shareCrashData")
            share_details.Text = translations.getText("crashDataDescription")
            send_details.Text = translations.getText("diagnosticsDescritpion")

            Me.ResumeLayout()
            If Not IsNothing(mainform.settings.sendDiags) Then
                If mainform.settings.sendDiags Then
                    send.Checked = True
                Else
                    send.Checked = False
                End If
            End If
            If Not IsNothing(mainform.settings.sendCrash) Then
                If mainform.settings.sendCrash Then
                    share.Checked = True
                Else
                    share.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) 
    End Sub

    Private Sub send_CheckedChanged(sender As Object, e As EventArgs) Handles send.CheckedChanged
        If send.Checked Then
            mainform.settings.sendDiags = True
        Else
            mainform.settings.sendDiags = False
        End If
        If share.Checked Then
            mainform.settings.sendCrash = True
        Else
            mainform.settings.sendCrash = False
        End If
    End Sub

    Private Sub about_diagnostics_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles about_diagnostics.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub share_CheckedChanged(sender As Object, e As EventArgs) Handles share.CheckedChanged
        If send.Checked Then
            mainform.settings.sendDiags = True
        Else
            mainform.settings.sendDiags = False
        End If
        If share.Checked Then
            mainform.settings.sendCrash = True
        Else
            mainform.settings.sendCrash = False
        End If
    End Sub
End Class