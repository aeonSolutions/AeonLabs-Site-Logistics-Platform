Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class CheckFileCompatibility_frm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private mainForm As MainMdiForm

    Private Sub ContinueBtn_Click(sender As Object, e As EventArgs) Handles ContinueBtn.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(_mainForm As MainMdiForm)
        mainForm = _mainForm
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.Refresh()
    End Sub

    Private Sub CheckFileCompatibility_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)

        Me.SuspendLayout()

        messageTxt.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        ContinueBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        ContinueBtn.BackColor = stateCore.buttonColor
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        translations.load("commonForm")
        closeBtn.Text = translations.getText("closeBtn")
        ContinueBtn.Text = translations.getText("continueBtn")
        translations.load("siteManagement")
        messageTxt.Text = translations.getText("checkCompatibilityMessage") & ":" & Environment.NewLine & Environment.NewLine _
            & "• reference" & Environment.NewLine _
            & "• description" & Environment.NewLine _
            & "• quantity" & Environment.NewLine _
            & "• units" & Environment.NewLine _
            & "• price" & Environment.NewLine _
            & "• enabled (0-Title, 1-Regular Task, 2-SubTitle)" & Environment.NewLine _
            & "• two letter country language translations" & Environment.NewLine & Environment.NewLine _
            & "ex.:" & Environment.NewLine _
            & "reference;description;quantity;units;price;amount;enabled;pt;fr;nl;en"
        Me.ResumeLayout()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub messageTxt_Click(sender As Object, e As EventArgs) Handles messageTxt.Click

    End Sub
End Class