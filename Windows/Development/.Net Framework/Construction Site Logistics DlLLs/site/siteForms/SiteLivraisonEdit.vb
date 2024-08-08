Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core
Imports ConstructionSiteLogistics.Gui.Libraries
Imports ConstructionSiteLogistics.AddOn.Translations.Web

Public Class SiteLivraisonEdit
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Private mask As PictureBox = Nothing
    Private taskRequest As String = ""
    Private response As String
    Private WithEvents bwTranslate As BackgroundWorker
    Private LivraisonSite As Integer
    Private WithEvents DataRequests As IDataSiteRequests
    Private mainform As MainMdiForm
    Private siteFrm As site_frm

    'TODO needs to move to an interface
    Private WithEvents translateText As TranslationLibrary

    Public Sub New(_mainMdiForm As MainMdiForm, _siteFrm As site_frm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainform = _mainMdiForm
        siteFrm = _siteFrm
        Me.Refresh()
    End Sub

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private Sub SiteLivraisonEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainform.state
        translations = New languageTranslations(stateCore)
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainform.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()

        Me.SuspendLayout()
        divider.BackColor = stateCore.dividerColor
        refdoc.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        recordDate.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        units.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        material.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        materialPreSelection.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        notas.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(stateCore.fontTitle.Families(0), stateCore.buttonFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.DialogTitleFontSize, Drawing.FontStyle.Bold)
        mandatory.Font = New Font(stateCore.fontTitle.Families(0), stateCore.SmallTextFontSize, Drawing.FontStyle.Regular)
        refDoc_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        data_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        qtd_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        units_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        material_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        notes_lbl.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        translate.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        del.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(stateCore.fontTitle.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

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
        Try
            DataRequests = DirectCast(loadDllObject(stateCore, "site.dll", "siteDataRequests"), IDataSiteRequests)
        Catch ex As Exception
            DataRequests = Nothing
        End Try
        If DataRequests Is Nothing Then
            mainform.statusMessage = "DLL file not found"
            mainform.busy.Close(True)
            Me.Close()
            Exit Sub
        End If

        siteFrm.datatableChanges = False
        recordDate.CustomFormat = "yyyy-MM-dd"
        units.SelectedIndex = 0
        LivraisonSite = siteFrm.query_site.Item("cod_site")(siteFrm.qtd_livraison_index)
        If Not siteFrm.livraisonCodes(siteFrm.livraison_datatable_cellY).Equals("") Then
            recordDate.Value = siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 1)
            refdoc.Text = siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 0)
            qtd.Text = siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 4)
            notas.Text = siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 5)
            material.Text = siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 2)

            For i = 0 To units.Items.Count - 1
                If siteFrm.livraisonTable(siteFrm.livraison_datatable_cellY, 3).ToUpper.Equals(units.Items(i).ToString) Then
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
        translateText = New TranslationLibrary(notas.Text, siteFrm.query_site("primary_lang")(InQueryDictionary(siteFrm.query_site, LivraisonSite, "cod_site")), stateCore.currentLang, True)
    End Sub

    Private Sub translateText_getTranslationText(sender As Object, responseData As String) Handles translateText.getTranslationText
        notas.Text = responseData
        enableButtonsAndLinks(Me, True)
    End Sub

    Private Sub apagar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles del.LinkClicked
        translations.load("siteActivity")
        Dim message As String = translations.getText("deliveryQuestionDelRecord")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Not msgbox.ShowDialog = DialogResult.Yes Then
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)
        vars.Add("request", "del")
        vars.Add("cod", siteFrm.livraisonCodes(siteFrm.livraison_datatable_cellY))
        taskRequest = "del"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveDeliveryData()
    End Sub
    Private Sub DataRequests_getResponseSaveDeliveryData(sender As Object, args As DataRequestsDataResult) Handles DataRequests.getResponseSaveDeliveryData
        Dim response As String = args.responseData
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""
        Dim request As New HttpDataCore

        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            translations.load("messagebox")
            If taskRequest.Equals("del") Then
                mainform.statusMessage = translations.getText("resultSuccessDelRecord")
            Else
                mainform.statusMessage = translations.getText("resultSuccessSaveRecord")
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
        taskRequest = ""
    End Sub

    Private Sub gravar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        Dim message As String = ""

        If refdoc.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorRefDoc")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            refdoc.Focus()
            Exit Sub
        End If
        If qtd.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorQuantity")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            qtd.Focus()
            Exit Sub
        End If
        If material.Text.Equals("") Then
            translations.load("siteActivity")
            message = translations.getText("deliveryErrorMaterials")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
            material.Focus()
            Exit Sub
        End If

        Dim vars As New Dictionary(Of String, String)

        If siteFrm.livraisonCodes(siteFrm.livraison_datatable_cellY).Equals("") Then
            vars.Add("request", "add")
            vars.Add("cod", siteFrm.livraisonCodes(siteFrm.livraison_datatable_cellY))
            vars.Add("site", LivraisonSite)
            vars.Add("section", siteFrm.livraisonSection(siteFrm.livraison_datatable_cellY))
        Else
            vars.Add("request", "edit")
            vars.Add("cod", siteFrm.livraisonCodes(siteFrm.livraison_datatable_cellY))
        End If
        vars.Add("ref", refdoc.Text.ToString)
        vars.Add("qtd", qtd.Text.ToString)
        vars.Add("mat", material.Text.ToString)
        vars.Add("note", notas.Text.ToString)
        vars.Add("und", units.SelectedItem.ToString)
        vars.Add("date", recordDate.Value.ToString("yyyy-MM-dd"))
        taskRequest = "edit"
        DataRequests.Initialise(stateCore)
        DataRequests.loadQueue(vars, Nothing, Nothing)
        DataRequests.saveDeliveryData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles materialPreSelection.SelectedIndexChanged
        material.Text = materialPreSelection.SelectedItem.ToString
    End Sub
End Class