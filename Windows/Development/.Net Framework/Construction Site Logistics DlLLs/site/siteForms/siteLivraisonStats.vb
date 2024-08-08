Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class siteLivraisonStats
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private mainform As MainMdiForm
    Private siteFrm As site_frm

    Public Sub New(_mainMdiForm As MainMdiForm, _siteFrm As site_frm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        mainform = _mainMdiForm
        siteFrm = _siteFrm
        Me.Refresh()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub SiteLivraisonEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translations = New languageTranslations(stateCore)
        Me.SuspendLayout()

        divider.BackColor = stateCore.dividerColor
        material.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        materialPreSelection.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        material_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        quantity.Font = New Font(stateCore.fontTitle.Families(0), 16, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        calcLink.Text = translations.getText("calculateLink")
        translations.load("siteActivity")
        title.Text = translations.getText("deliveryStatsTitle")
        quantity.Text = "- -"
        ResumeLayout()
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub quantity_Click(sender As Object, e As EventArgs) Handles quantity.Click

    End Sub

    Private Sub calcLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles calcLink.LinkClicked
        quantity.Text = "- -"
        If (material.Text.Equals("") And materialPreSelection.SelectedIndex < 0) Then
            translations.load("siteActivity")
            Dim message As String = translations.getText("deliveryErrorMaterials")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            Exit Sub
        End If
        Dim searchStr As String = ""
        If material.Text.Equals("") Then
            searchStr = materialPreSelection.SelectedItem.ToString
        Else
            searchStr = material.Text
        End If
        Dim counter As Double = 0.0
        For i = 0 To siteFrm.currentLivraisonDatatable.Rows.Count - 1
            If siteFrm.currentLivraisonDatatable.Rows(i).Cells(2).Value.ToString.ToLower().Equals(searchStr.ToLower) Then
                If IsNumeric(siteFrm.currentLivraisonDatatable.Rows(i).Cells(4).Value) Then
                    counter += siteFrm.currentLivraisonDatatable.Rows(i).Cells(4).Value
                End If
            End If
        Next i

        translations.load("siteActivity")
        quantity.Text = translations.getText("deliveryQuantity") & ": " & counter.ToString("F2")
    End Sub

    Private Sub SiteLivraisonEdit_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub
End Class