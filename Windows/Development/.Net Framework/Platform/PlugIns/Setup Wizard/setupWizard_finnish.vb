Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core


Public Class setupWizard_finnish
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
        btnContinueTxt.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        Me.SuspendLayout()
        translations = New languageTranslations(mainform.enVars)
        translations.load("setupWizard")
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub subtitle_Click(sender As Object, e As EventArgs)

    End Sub
End Class