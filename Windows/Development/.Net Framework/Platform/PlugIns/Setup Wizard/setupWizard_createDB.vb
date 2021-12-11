Imports System.Drawing
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Windows.Forms
Imports ConstructionSiteLogistics
Imports ConstructionSiteLogistics.Libraries.Core

Public Class setupWizard_createDB
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


    Private Sub setupWizard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            translations = New languageTranslations(mainform.enVars)
            translations.load("setupWizard")

            db_name_lbl.Text = translations.getText("dbName")
            db_user_lbl.Text = translations.getText("dbUser")
            db_pwd_lbl.Text = translations.getText("dbPwd")

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub setupWizard_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        db_name.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)
        db_name_lbl.Font = New Font(mainform.enVars.fontTitle.Families(0), 9, FontStyle.Regular)

    End Sub

    Private Sub db_name_TextChanged(sender As Object, e As EventArgs) Handles db_name.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            mainform.settings.dbName = db_name.Text
            mainform.settings.dbPwd = db_pwd.Text
            mainform.settings.dbUser = db_user.Text
        Else

        End If
    End Sub

    Private Sub db_user_TextChanged(sender As Object, e As EventArgs) Handles db_user.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            mainform.settings.dbName = db_name.Text
            mainform.settings.dbPwd = db_pwd.Text
            mainform.settings.dbUser = db_user.Text
        Else

        End If
    End Sub

    Private Sub db_pwd_TextChanged(sender As Object, e As EventArgs) Handles db_pwd.TextChanged
        If Not db_name.Text.Equals("") And Not db_user.Text.Equals("") And Not db_pwd.Text.Equals("") Then
            mainform.settings.dbName = db_name.Text
            mainform.settings.dbPwd = db_pwd.Text
            mainform.settings.dbUser = db_user.Text
        Else

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class