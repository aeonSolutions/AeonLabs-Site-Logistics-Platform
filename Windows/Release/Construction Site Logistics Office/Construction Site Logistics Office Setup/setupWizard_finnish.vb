Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO

Public Class setupWizard_finnish
    Private state As New State
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
        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        btnContinueTxt.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        Me.SuspendLayout()
        translations = New languageTranslations(setupWizard_country.state)
        translations.load("setupWizard")
        title.Text = translations.getText("titleFinnish")
        subtitle.Text = translations.getText("subtitleFinnish")
        btnContinueTxt.Text = translations.getText("startApp")

        Me.ResumeLayout()
    End Sub



    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        Process.Start(Path.Combine(Environment.CurrentDirectory, "finnish.exe"))
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub subtitle_Click(sender As Object, e As EventArgs) Handles subtitle.Click

    End Sub
End Class