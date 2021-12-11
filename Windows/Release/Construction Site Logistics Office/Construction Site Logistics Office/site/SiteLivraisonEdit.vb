Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class SiteLivraisonEdit
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations
     
    Private mask As PictureBox = Nothing

    Private response As String
    Private WithEvents bwTranslate As BackgroundWorker
    Private LivraisonSite As Integer

    Sub EnforceAuthorities()

    End Sub
    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub SiteLivraisonEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        state = MainMdiForm.state
        translations = New languageTranslations(state)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(MainMdiForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()

        Me.SuspendLayout()
         
         
        divider.BackColor = state.dividerColor
        refdoc.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        recordDate.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        material.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        materialPreSelection.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        notas.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontTitle.Families(0), state.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor

        title.Font = New Font(state.fontTitle.Families(0), state.DialogTitleFontSize, Drawing.FontStyle.Bold)
        mandatory.Font = New Font(state.fontTitle.Families(0), state.SmallTextFontSize, Drawing.FontStyle.Regular)
        refDoc_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        data_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        units_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        material_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        notes_lbl.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        translate.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        del.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontTitle.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        translate.Text = translations.getText("translateLink")
        del.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
        mandatory.Text = translations.getText("mandatoryFields")
        data_lbl.Text = translations.getText("dateTitle") & "*"
        notes_lbl.Text = translations.getText("AnnotationTitle")
        closeBtn.Text = translations.getText("closeBtn")
        translations.load("siteActivity")
        title.Text = translations.getText("deliveryEditTitle")
        refDoc_lbl.Text = translations.getText("deliveryRefDoc") & "*"
        qtd_lbl.Text = translations.getText("deliveryQuantity") & "*"
        units_lbl.Text = translations.getText("deliveryUnits") & "*"
        material_lbl.Text = translations.getText("deliveryMaterials") & "*"

        save.Location = New Point(notas.Location.X + notas.Width - save.Width, save.Location.Y)
        del.Location = New Point(save.Location.X - 5 - del.Width, del.Location.Y)
        ResumeLayout()
        mask.Dispose()
    End Sub

    Private Sub SiteLivraisonEdit_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        site_frm.datatableChanges = False
        recordDate.CustomFormat = "yyyy-MM-dd"
        units.SelectedIndex = 0
        LivraisonSite = site_frm.query_site.Item("cod_site")(site_frm.livraison_site.SelectedIndex - 1)
        If Not site_frm.livraisonCodes(site_frm.livraison_datatable_cellY).Equals("") Then
            recordDate.Value = site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 1)

            refdoc.Text = site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 0)
            qtd.Text = site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 4)
            notas.Text = site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 5)
            material.Text = site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 2)

            For i = 0 To units.Items.Count - 1
                If site_frm.livraisonTable(site_frm.livraison_datatable_cellY, 3).ToUpper.Equals(units.Items(i).ToString) Then
                    units.SelectedIndex = i
                    Exit For
                End If
            Next i
        Else
            recordDate.Value = DateTime.Now
            translations.load("siteActivity")
            refdoc.Text = translations.getText("deliveryEditAddNew")
            qtd.Text = ""
            notas.Text = ""
            material.Text = ""
            del.Enabled = False
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub translate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles translate.LinkClicked
        enableButtonsAndLinks(Me, False)
        notas.Text = DoTranslation(notas.Text, site_frm.query_site("primary_lang")(InQueryDictionary(site_frm.query_site, LivraisonSite, "cod_site")), state.currentLang)
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub apagar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles del.LinkClicked
        translations.load("siteActivity")
        Dim message As String = translations.getText("deliveryQuestionDelRecord")
        translations.load("messagebox")
        msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If Not msgbox.ShowDialog = DialogResult.OK Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "22") 'delivery
        vars.Add("request", "del")
        vars.Add("cod", site_frm.livraisonCodes(site_frm.livraison_datatable_cellY))
        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            msgbox = New message_box_frm(translations.getText("resultSuccessDelRecord"), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub gravar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        Dim message As String = ""

        If refdoc.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorRefDoc")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            refdoc.Focus()
            Exit Sub
        End If
        If qtd.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorQuantity")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            qtd.Focus()
            Exit Sub
        End If
        If material.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorMaterials")
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            material.Focus()
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "22") 'delivery
        If site_frm.livraisonCodes(site_frm.livraison_datatable_cellY).Equals("") Then
            vars.Add("request", "add")
            vars.Add("cod", site_frm.livraisonCodes(site_frm.livraison_datatable_cellY))
            vars.Add("site", LivraisonSite)
            vars.Add("section", site_frm.livraisonSection(site_frm.livraison_datatable_cellY))
        Else
            vars.Add("request", "edit")
            vars.Add("cod", site_frm.livraisonCodes(site_frm.livraison_datatable_cellY))
        End If
        vars.Add("ref", refdoc.Text.ToString)
        vars.Add("qtd", qtd.Text.ToString)
        vars.Add("mat", material.Text.ToString)
        vars.Add("note", notas.Text.ToString)
        vars.Add("und", units.SelectedItem.ToString)
        vars.Add("date", recordDate.Value.ToString("yyyy-MM-dd"))
        Dim request As New HttpData(state)
        response = request.RequestData(vars)
        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            MainMdiForm.statusMessage = translations.getText("resultSuccessSaveRecord")
            Me.DialogResult = DialogResult.OK
            Me.Close()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles materialPreSelection.SelectedIndexChanged
        material.Text = materialPreSelection.SelectedItem.ToString
    End Sub
End Class