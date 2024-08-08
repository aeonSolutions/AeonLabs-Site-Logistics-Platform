Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms

Imports ConstructionSiteLogistics.Libraries.Core

Public Class mobileDevicesForm
    Private msgbox As messageBoxForm
    Private stateCore As New environmentVars
    Private translations As languageTranslations

    Private works_tablets As Dictionary(Of String, List(Of String))
    Private response As String
    Dim mask As PictureBox = Nothing
    Private WithEvents bwSites As BackgroundWorker
    Public loaded As Boolean = False
    Public updated As Boolean = False

    Private Sub CloseMe()
        Me.Close()
    End Sub

    Private state As New environmentVars
    Private mainForm As MainMdiForm

    Public Sub New(_mainMdiForm As MainMdiForm, _state As environmentVars)
        mainForm = _mainMdiForm
        state = _state
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Application.DoEvents()
        Me.Refresh()
    End Sub

    Private Sub frm_tablets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateCore = mainForm.state
        translations = New languageTranslations(stateCore)

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(mask)
        mask.BringToFront()
        Me.Refresh()
        Me.SuspendLayout()
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(mainForm.Width / 2 - Me.Width / 2, mainForm.Height / 2 - Me.Height / 2)

        title.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        closeBtn.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = stateCore.buttonColor
        divider.BackColor = stateCore.dividerColor

        devicesList_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        device_details.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        device_lastUsage.Font = New Font(stateCore.fontText.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        device_name_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_serial_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_id_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_gsm_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_pin_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_puk_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_email_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        active.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        nome.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        serial.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        id.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        mobile.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        pin.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        puk.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        email.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        worker_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        section_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        version_app_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        last_login_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        worker.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_logged.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        section_logged.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        version.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        last_login_date.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        mandatoryFields_lbl.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        Dim updateToolTip As New ToolTip()
        updateToolTip.SetToolTip(updateBtn, translations.getText("updateLink"))

        Dim saveToolTip As New ToolTip()
        saveToolTip.SetToolTip(saveBtn, translations.getText("saveLink"))

        Dim delToolTip As New ToolTip()
        delToolTip.SetToolTip(delBtn, translations.getText("delLink"))

        closeBtn.Text = translations.getText("closeBtn")
        mandatoryFields_lbl.Text = translations.getText("mandatoryFields")
        device_email_lbl.Text = translations.getText("email")
        active.Text = translations.getText("active")
        site_lbl.Text = translations.getText("groupBoxSite")
        section_lbl.Text = translations.getText("siteSection")

        translations.load("mobileDevices")
        title.Text = translations.getText("title")
        device_name_lbl.Text = translations.getText("deviceName")
        device_serial_lbl.Text = translations.getText("deviceSerial")
        device_id_lbl.Text = translations.getText("deviceId")
        device_gsm_lbl.Text = translations.getText("deviceGsm")
        device_pin_lbl.Text = translations.getText("devicePin")
        device_puk_lbl.Text = translations.getText("devicePuk")
        worker_lbl.Text = translations.getText("assigned")
        version_app_lbl.Text = translations.getText("appVersion")
        last_login_lbl.Text = translations.getText("lastLogin")
        devicesList_lbl.Text = translations.getText("deviceList")
        device_details.Text = translations.getText("deviceDetails")
        device_lastUsage.Text = translations.getText("deviceLastUsage")

        mandatoryFields_lbl.Location = New Point(divider.Location.X + divider.Width - mandatoryFields_lbl.Width, mandatoryFields_lbl.Location.Y)

        loaded = False
        saveBtn.Enabled = False
        delBtn.Enabled = False
        Me.ResumeLayout()


    End Sub

    Private Sub frm_tablets_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        load_list()
    End Sub

    Private Sub removeMask()
        If loaded Then
            Exit Sub
        End If

        loaded = True
        Me.SuspendLayout()

        For i As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(i).Visible = True
        Next
        Me.ResumeLayout()
        mask.Dispose()

    End Sub

    Sub load_list()


        mainForm.busy.Show()
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
            End If
        End If

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
        tablets_list.Enabled = False
        delBtn.Enabled = False
        updateBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.Enabled = False

    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "mobiledevices")
        Dim request As New HttpDataCore
        Dim response As String = "" ''request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_tablets = request.ConvertDataToArray("mobiledevices", stateCore.queryMobileDevicesFields, response)
        If IsNothing(works_tablets) Then
            errorMsg = request.errorMessage
            errorFlag = True
            GoTo lastLine
        End If

lastLine:
        Dim s(1) As String
        If errorFlag Then
            s(0) = "true"
            s(1) = errorMsg
            e.Result = s
            Exit Sub
        Else
            s(0) = False
            s(1) = ""
            e.Result = s
        End If


    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        Static start As Single
        start = Microsoft.VisualBasic.Timer()
        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
        End While
        If Not Me.IsHandleCreated Then
            translations.load("system")
            mainForm.statusMessage = translations.getText("errorFormNoHandle")
            delBtn.Enabled = False
            updateBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.Enabled = False

            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            delBtn.Enabled = False
            updateBtn.Enabled = True
            closeBtn.Enabled = True
            saveBtn.Enabled = False

            Exit Sub
        End If

        translations.load("commonForm")
        tablets_list.Items.Clear()
        tablets_list.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_tablets.Item("name").Count - 1
            tablets_list.Items.Add(works_tablets.Item("tablet_id")(i) & " - " & works_tablets.Item("serial")(i) & " - " & works_tablets.Item("worker.name")(i))
        Next
        tablets_list.SelectedIndex = 0

        mainForm.busy.Close(True)

        tablets_list.Enabled = True
        updated = True
        delBtn.Enabled = True
        updateBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.Enabled = True

        EnforceAuthorities()
        removeMask()
    End Sub

    Private Sub clearFields()
        nome.Text = ""
        worker.Text = ""
        pin.Text = ""
        id.Text = ""
        puk.Text = ""
        mobile.Text = ""
        version.Text = ""
        serial.Text = ""
        site_logged.Text = ""
        section_logged.Text = ""
        last_login_date.Text = ""
        email.Text = "@qualityconstruction.be"
        active.Checked = False
    End Sub

    Private Sub tablets_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles tablets_list.SelectedIndexChanged
        '1 tablets.cod_tablet, 2 worker.Name, 3 tablets.pin, 4 tablets.tablet_id, 5 tablets.puk, 6 tablets.mobile, 7 tablets.Name,
        '8 tablets.sw_version, 9 tablets.serial, 10 Site.Name, 11 site_section.description, 12 tablets.active, 13 tablets.date, 14 tablets.email

        If tablets_list.SelectedIndex > 0 Then
            worker.Text = works_tablets.Item("worker.name")(tablets_list.SelectedIndex - 1)
            pin.Text = works_tablets.Item("pin")(tablets_list.SelectedIndex - 1)
            id.Text = works_tablets.Item("tablet_id")(tablets_list.SelectedIndex - 1)
            puk.Text = works_tablets.Item("puk")(tablets_list.SelectedIndex - 1)
            mobile.Text = works_tablets.Item("mobile")(tablets_list.SelectedIndex - 1)
            nome.Text = works_tablets.Item("name")(tablets_list.SelectedIndex - 1)
            version.Text = works_tablets.Item("sw_version")(tablets_list.SelectedIndex - 1)
            serial.Text = works_tablets.Item("serial")(tablets_list.SelectedIndex - 1)
            site_logged.Text = works_tablets.Item("site.name")(tablets_list.SelectedIndex - 1)
            section_logged.Text = works_tablets.Item("site_section.description")(tablets_list.SelectedIndex - 1)
            If works_tablets.Item("active")(tablets_list.SelectedIndex - 1).Equals("1") Then
                active.Checked = True
            Else
                active.Checked = False
            End If
            last_login_date.Text = works_tablets.Item("date")(tablets_list.SelectedIndex - 1)
            email.Text = works_tablets.Item("email")(tablets_list.SelectedIndex - 1)
            saveBtn.Enabled = True
            delBtn.Enabled = True

        Else
            clearFields()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub



    Sub EnforceAuthorities()

    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If id.Text.Equals("") Then
            pin.Focus()
            Exit Sub
        End If
        If Not IsValidEmailFormat(email.Text) Then
            email.Focus()
            Exit Sub
        End If
        delBtn.Enabled = False
        updateBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.Enabled = False

        Dim vars As New Dictionary(Of String, String)
        vars.Add("task", "13")
        If tablets_list.SelectedIndex < 1 Then
            vars.Add("type", "new")
        Else
            vars.Add("type", "edit")
            vars.Add("cod", works_tablets.Item("cod_tablet")(tablets_list.SelectedIndex - 1))
        End If
        vars.Add("active", If(active.Checked, "1", "0"))
        vars.Add("puk", puk.Text)
        vars.Add("pin", pin.Text)
        vars.Add("serial", serial.Text)
        vars.Add("mobile", mobile.Text)
        vars.Add("id", id.Text)
        vars.Add("email", email.Text)
        Dim request As New HttpDataCore
        response = "" ''request.RequestData(vars)

        mainForm.busy.Close(True)
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            load_list()

            clearFields()

            translations.load("messagebox")
            msgbox = New messageBoxForm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()

        End If
        delBtn.Enabled = True
        updateBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.Enabled = True

    End Sub

    Private Sub delBtn_Click(sender As Object, e As EventArgs) Handles delBtn.Click
        delBtn.Enabled = False
        updateBtn.Enabled = False
        closeBtn.Enabled = False
        saveBtn.Enabled = False

        If tablets_list.SelectedIndex > 0 Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "13")
            vars.Add("type", "del")
            vars.Add("cod", works_tablets.Item("cod_tablet")(tablets_list.SelectedIndex - 1))
            Dim request As New HttpDataCore
            response = "" ''request.RequestData(vars)
            mainForm.busy.Close(True)
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New messageBoxForm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                load_list()

                clearFields()

                translations.load("messagebox")
                msgbox = New messageBoxForm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        Else
            translations.load("mobileDevices")
            Dim message3 As String = translations.getText("errorSelectDevice")
            translations.load("messagebox")
            msgbox = New messageBoxForm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        delBtn.Enabled = True
        updateBtn.Enabled = True
        closeBtn.Enabled = True
        saveBtn.Enabled = True

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        load_list()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class