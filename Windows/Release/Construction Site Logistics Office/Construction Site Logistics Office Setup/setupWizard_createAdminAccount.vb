Imports System.Drawing.Text
Imports System.Globalization
Imports ConstructionSiteLogistics

Public Class setupWizard_createAdminAccount
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

    Private Sub setupWizard_1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("AdminTitle")
            subtitle.Text = translations.getText("AdminSubtitle")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")
            full_name_lbl.Text = translations.getText("AdminFullName")
            id_lbl.Text = translations.getText("AdminId")
            id_verify_lbl.Text = translations.getText("AdminIdVerify")

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        full_name.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        full_name_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        title.Font = New Font(state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(state.fontTitle.Families(0), 12, FontStyle.Regular)
        full_name.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        full_name_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        id.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        id_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        id_verify.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)
        id_verify_lbl.Font = New Font(state.fontTitle.Families(0), 9, FontStyle.Regular)

    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        If (full_name.Text.Equals("") Or id.Text.Equals("") Or id_verify.Text.Equals("")) Or Not id.Text.Equals(id_verify.Text) Then
            Exit Sub
        End If
        setupWizard_country.settings.adminName = full_name.Text
        setupWizard_country.settings.adminId = id.Text

        Me.Hide()
        setupWizard_DiagnosticsCrashData.Show()
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Title = "Abrir ficheiro..."
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "Imagem jpg|*.jpg"
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim filename = OpenFileDialog1.FileName
            PictureBox3.Image = Image.FromFile(filename)
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub full_name_TextChanged(sender As Object, e As EventArgs) Handles full_name.TextChanged
        If Not full_name.Text.Equals("") And Not id.Text.Equals("") And Not id_verify.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        If Not full_name.Text.Equals("") And Not id.Text.Equals("") And Not id_verify.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub id_verify_TextChanged(sender As Object, e As EventArgs) Handles id_verify.TextChanged
        If Not full_name.Text.Equals("") And Not id.Text.Equals("") And Not id_verify.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub
End Class