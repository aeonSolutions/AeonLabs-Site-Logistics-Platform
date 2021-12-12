Imports System.Drawing.Text
Imports System.Globalization


Public Class setupWizard_createDB
    Private translations As languageTranslations
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.Refresh()
    End Sub


    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(setupWizard_country.state)
            translations.load("setupWizard")
            title.Text = translations.getText("titleDb")
            subtitle.Text = translations.getText("subtitleDb")
            btnBackTxt.Text = translations.getText("btnBack")
            btnContinueTxt.Text = translations.getText("btnContinue")

            db_name_lbl.Text = translations.getText("dbName")
            db_user_lbl.Text = translations.getText("dbUser")
            db_pwd_lbl.Text = translations.getText("dbPwd")

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db_name.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)
        db_name_lbl.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 9, FontStyle.Regular)

        title.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 24, FontStyle.Bold)
        subtitle.Font = New Font(setupWizard_country.state.fontTitle.Families(0), 12, FontStyle.Regular)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles btnBackTxt.Click
        wizardGoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        wizardGoBack()
    End Sub

    Private Sub wizardGoBack()
        Me.Hide()
        setupWizard_NewFtpWebSettings.Show()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        wizardGoForward()
    End Sub

    Private Sub btnContinueTxt_Click(sender As Object, e As EventArgs) Handles btnContinueTxt.Click
        wizardGoForward()
    End Sub

    Private Sub wizardGoForward()
        If db_name.Text.Equals("") Or db_user.Text.Equals("") Or db_pwd.Text.Equals("") Then
            Exit Sub
        End If

        setupWizard_country.settings.dbName = db_name.Text
        setupWizard_country.settings.dbPwd = db_pwd.Text
        setupWizard_country.settings.dbUser = db_user.Text

        Me.Hide()
        setupWizard_addOns.Show()
    End Sub

    Private Sub db_name_TextChanged(sender As Object, e As EventArgs) Handles db_name.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub db_user_TextChanged(sender As Object, e As EventArgs) Handles db_user.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub db_pwd_TextChanged(sender As Object, e As EventArgs) Handles db_pwd.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtnOn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.DimGray
        Else
            btnContinue.Image = Image.FromFile(setupWizard_country.state.imagesPath & "rightArrowBtn.png")
            btnContinue.SizeMode = PictureBoxSizeMode.StretchImage
            btnContinueTxt.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles title.Click

    End Sub
End Class