Imports System.ComponentModel
Imports System.Drawing.Text

Public Class frm_tablets
    Private msgbox As message_box_frm
    Private state As State
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

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Application.DoEvents()
        Me.Refresh()
    End Sub

    Private Sub frm_tablets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Refresh()
        Me.SuspendLayout()
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(MainMdiForm.Width / 2 - Me.Width / 2, MainMdiForm.Height / 2 - Me.Height / 2)

        title.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        updateLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        remove.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        save.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        closeBtn.BackColor = state.buttonColor
        divider.BackColor = state.dividerColor

        devicesList_lbl.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        device_details.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        device_lastUsage.Font = New Font(state.fontText.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)

        device_name_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_serial_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_id_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_gsm_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_pin_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_puk_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        device_email_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        active.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        nome.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        serial.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        id.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mobile.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        pin.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        puk.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        email.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        worker_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        section_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        version_app_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        last_login_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        worker.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        site_logged.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        section_logged.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        version.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        last_login_date.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        mandatoryFields_lbl.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)

        translations.load("commonForm")
        updateLink.Text = translations.getText("updateLink")
        remove.Text = translations.getText("delLink")
        save.Text = translations.getText("saveLink")
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

        save.Location = New Point(remove.Location.X + remove.Width + 5, save.Location.Y)
        mandatoryFields_lbl.Location = New Point(divider.Location.X + divider.Width - mandatoryFields_lbl.Width, mandatoryFields_lbl.Location.Y)

        loaded = False
        save.Enabled = False
        remove.Enabled = False
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
        Dim checkConnection As waitingServer = New waitingServer()
        If Not (checkConnection.ShowDialog = DialogResult.OK) Then
            While Not Me.IsHandleCreated
                Application.DoEvents()
            End While
            Me.BeginInvoke(New MethodInvoker(AddressOf CloseMe))
            MainMdiForm.NoNetwork()
            Exit Sub
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If
        If Not IsNothing(bwSites) Then
            If bwSites.IsBusy Then
                bwSites.CancelAsync()
            End If
        End If

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
        tablets_list.Enabled = False
        remove.Enabled = False
        updateLink.Enabled = False
        closeBtn.Enabled = False
        save.Enabled = False

    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim vars As New Dictionary(Of String, String)
        Dim errorFlag As Boolean = False
        Dim errorMsg As String = ""

        vars.Add("task", "6")
        vars.Add("request", "mobiledevices")
        Dim request As New HttpData(state)
        Dim response As String = request.RequestData(vars)
        If Not IsResponseOk(response) Then
            errorMsg = GetMessage(response)
            errorFlag = True
            GoTo lastLine
        End If
        works_tablets = request.ConvertDataToArray("mobiledevices", state.queryMobileDevicesFields, response)
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
            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
            remove.Enabled = False
            updateLink.Enabled = True
            closeBtn.Enabled = True
            save.Enabled = False

            Exit Sub
        End If
        If e.Result(0).Equals("true") Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(e.Result(1)) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            remove.Enabled = False
            updateLink.Enabled = True
            closeBtn.Enabled = True
            save.Enabled = False

            Exit Sub
        End If

        translations.load("commonForm")
        tablets_list.Items.Clear()
        tablets_list.Items.Add(translations.getText("dropdownSelectSite"))
        For i = 0 To works_tablets.Item("name").Count - 1
            tablets_list.Items.Add(works_tablets.Item("tablet_id")(i) & " - " & works_tablets.Item("serial")(i) & " - " & works_tablets.Item("worker.name")(i))
        Next
        tablets_list.SelectedIndex = 0

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

        tablets_list.Enabled = True
        updated = True
        remove.Enabled = True
        updateLink.Enabled = True
        closeBtn.Enabled = True
        save.Enabled = True

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
        email.Text = "@aeonlabs.solutions"
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
            save.Enabled = True
            remove.Enabled = True

        Else
            clearFields()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub



    Sub EnforceAuthorities()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles save.LinkClicked
        If id.Text.Equals("") Then
            pin.Focus()
            Exit Sub
        End If
        If Not IsValidEmailFormat(email.Text) Then
            email.Focus()
            Exit Sub
        End If
        remove.Enabled = False
        updateLink.Enabled = False
        closeBtn.Enabled = False
        save.Enabled = False

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
        Dim request As New HttpData(state)
        response = request.RequestData(vars)

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If
        If Not IsResponseOk(response) Then
            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()
        Else
            load_list()

            clearFields()

            translations.load("messagebox")
            msgbox = New message_box_frm(GetMessage(response), translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            msgbox.ShowDialog()

        End If
        remove.Enabled = True
        updateLink.Enabled = True
        closeBtn.Enabled = True
        save.Enabled = True

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles remove.LinkClicked
        remove.Enabled = False
        updateLink.Enabled = False
        closeBtn.Enabled = False
        save.Enabled = False

        If tablets_list.SelectedIndex > 0 Then
            Dim vars As New Dictionary(Of String, String)
            vars.Add("task", "13")
            vars.Add("type", "del")
            vars.Add("cod", works_tablets.Item("cod_tablet")(tablets_list.SelectedIndex - 1))
            Dim request As New HttpData(state)
            response = request.RequestData(vars)
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            If Not IsResponseOk(response) Then
                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            Else
                load_list()

                clearFields()

                translations.load("messagebox")
                msgbox = New message_box_frm(GetMessage(response), translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                msgbox.ShowDialog()
            End If
        Else
            translations.load("mobileDevices")
            Dim message3 As String = translations.getText("errorSelectDevice")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If
        remove.Enabled = True
        updateLink.Enabled = True
        closeBtn.Enabled = True
        save.Enabled = True

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles updateLink.LinkClicked
        load_list()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


End Class