Imports System.Drawing.Printing

Imports System.IO

Imports AutoUpdaterDotNET
Imports ClosedXML.Excel
Imports Newtonsoft.Json

Public Class MainMdiForm
    Public username As String = "to be deleted"

    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public childForm As String = ""
    Private checkPrint As Integer

    Public loaded As Boolean = False
    Public Shared state As State
    Public Shared statusMessage As String = ""

    Public busy As BusyThread
    Public busyForm As New waiting_frm
    Private msgbox As message_box_frm
    Private mask, loadingMask As PictureBox

    Private translations As languageTranslations
    Private BusyMenuOption As Boolean = False



    Private menuHolder As New Dictionary(Of String, _menuHolder)
    Private menuItem As _menuHolder
    Private mbDoPaintBackground As Boolean
    Private Const WM_SYSCOMMAND = &H112

    Structure _menuHolder
        Public panel As Panel
        Public state As Boolean
        Public openHeight As Integer
    End Structure

    Private Sub AutoUpdaterOnParseUpdateInfoEvent(ByVal args As ParseUpdateInfoEventArgs)
        Dim json = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(args.RemoteData)

        args.UpdateInfo = New UpdateInfoEventArgs With {
        .CurrentVersion = New Version(json.Item("version")),
        .ChangelogURL = json.Item("changelog"),
        .Mandatory = Convert.ToBoolean(json.Item("mandatory")),
        .DownloadURL = json.Item("url")
    }
    End Sub
    Private Sub enterprise_lbl_Click(sender As Object, e As EventArgs) Handles enterprise_lbl.Click

    End Sub
    Private Sub wrapper_Paint_1(sender As Object, e As PaintEventArgs) Handles wrapper.Paint

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If IsNothing(state) Then
            Exit Sub
        End If
        If (WindowState.Equals(FormWindowState.Maximized) Or WindowState.Equals(FormWindowState.Normal)) And state.authOk.Equals(False) And loaded Then
            doLogin()
        End If
    End Sub
    Private Sub Form1_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.SuspendLayout()
    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Me.ResumeLayout()
    End Sub

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        state = New State("loadSettingsOnly")
        translations = New languageTranslations(state)
    End Sub

    'inactivity timer code
    Dim inActivity As New Stopwatch

    Private Sub VisualTranslationForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If WindowState = FormWindowState.Maximized OrElse WindowState = FormWindowState.Minimized Then
            mbDoPaintBackground = True
            Refresh()
            Application.DoEvents()

        End If
    End Sub

    Private Const WM_MAXBUTTONSomethingSomething As Integer = &HF030  '61488
    Private Const WM_MINBUTTONSomethingSomething As Integer = &HF120   '61728
    ' sub to address flickering on maximize form
    Protected Overrides Sub WndProc(ByRef m As Message)
        'Traps specifically for "Maximize" button
        Try
            If m.Msg = WM_SYSCOMMAND Then
                '
                ' Handle running on 64-bit platforms
                '
                Dim param As Long
                If (IntPtr.Size = 4) Then
                    param = CLng(m.WParam.ToInt32)
                Else
                    param = CLng(m.WParam.ToInt64)
                End If

                If CInt(param) = WM_MAXBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                ElseIf CInt(param) = WM_MINBUTTONSomethingSomething Then
                    mbDoPaintBackground = False
                End If
            Else
                ' Not a WM_SYSCOMMAND message
            End If
        Catch ex As Exception

        End Try
        'Listen for operating system messages to the application. If the form to expire is moved, mousemove detected, keydown detected it will stay open
        'When no message is sent from the OS within 30 seconds the form will expire.
        resetActivity()
        MyBase.WndProc(m)
    End Sub
    Public Sub resetActivity()
        inActivity.Reset()
        inActivity.Start()
    End Sub

    Private Sub formTimeOut_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles formTimeOut.Tick
        If inActivity.Elapsed > state.AutomaticLogoutTime Then
            menu_profile_icon_title.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
            menu_profile_icon_title.SizeMode = PictureBoxSizeMode.StretchImage
            UnloadForms()
            doLogin()
        End If
    End Sub

    Private Sub mainMdiForm_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.SuspendLayout()
            enterprise_lbl.Text = state.businessName

            loadLanguage()
            'menu_.Text = translations.getText("").ToUpper

            Me.ResumeLayout()
        End If
    End Sub

    Private Sub MainMdiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadingMask = New PictureBox
        loadingMask.Dock = DockStyle.Fill
        loadingMask.BackColor = Color.White
        loadingMask.Top = TopMost
        loadingMask.Image = Image.FromFile(state.imagesPath & "unloadedForm.png")
        loadingMask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(loadingMask)
        loadingMask.BringToFront()
        Refresh()
        'define lateral menu tree
        menuItem.panel = panel_menu_profile
        menuItem.state = False
        menuItem.openHeight = panel_menu_profile.Height
        menuHolder.Add("profile", menuItem)

        menuItem.panel = panel_menu_data
        menuItem.state = False
        menuItem.openHeight = panel_menu_data.Height
        menuHolder.Add("data", menuItem)

        menuItem.panel = panel_menu_workers
        menuItem.state = False
        menuItem.openHeight = panel_menu_workers.Height
        menuHolder.Add("workers", menuItem)

        menuItem.panel = panel_menu_site
        menuItem.state = False
        menuItem.openHeight = panel_menu_site.Height
        menuHolder.Add("site", menuItem)

        menuItem.panel = panel_menu_clients
        menuItem.state = False
        menuItem.openHeight = panel_menu_clients.Height
        menuHolder.Add("clients", menuItem)

        menuItem.panel = panel_menu_sub_companies
        menuItem.state = False
        menuItem.openHeight = panel_menu_sub_companies.Height
        menuHolder.Add("companies", menuItem)

        menuItem.panel = panel_menu_reports
        menuItem.state = False
        menuItem.openHeight = panel_menu_reports.Height
        menuHolder.Add("reports", menuItem)

        menuItem.panel = panel_menu_help
        menuItem.state = False
        menuItem.openHeight = panel_menu_help.Height
        menuHolder.Add("help", menuItem)

        menuItem.panel = panel_menu_exit
        menuItem.state = False
        menuItem.openHeight = panel_menu_exit.Height
        menuHolder.Add("exit", menuItem)

        menuHolder.FirstOrDefault().Value.panel.Height = 30
        Dim i As Integer = 0
        Dim prevItem As KeyValuePair(Of String, _menuHolder) = Nothing
        For Each item In menuHolder
            If i.Equals(0) Then
                prevItem = item
                i = i + 1
                Continue For
            End If
            menuHolder.Item(item.Key).panel.Height = 30
            menuHolder.Item(item.Key).panel.Location = New Point(menuHolder.Item(item.Key).panel.Location.X, menuHolder.Item(prevItem.Key).panel.Location.Y + menuHolder.Item(prevItem.Key).panel.Height + 3)
            prevItem = item
            i = i + 1
        Next

        SuspendLayout()
        Me.WindowState = FormWindowState.Maximized
        sidebarWrapper.BackColor = state.colorMainMenu
        sidebarWrapper.Width = 36
        sidebarWrapperContents.AutoScroll = False
        sidebarWrapper.AutoScroll = False
        wrapper.AutoScroll = True
        sidebarWrapperContents.Visible = False

        label_time.Text = TimeOfDay.ToString("HH:mm")
        ResumeLayout()
    End Sub

    Private Sub MainMdiForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        busy = New BusyThread
        busy.Show()
        translations.load("commonForm")
        statusMessage = translations.getText("downloadSettings")
        state = New State("all")
        busy.Close()
        If state.stateLoaded.Equals(False) Then
            translations.load("errorMessages")
            Dim message = translations.getText("errorLoadingSettings") & Environment.NewLine & state.stateErrorMessage
            translations.load("messagebox")
            msgbox = New message_box_frm(message, translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
        End If

        SuspendLayout()
        sidebarWrapper.BackColor = state.colorMainMenu
        sidebarWrapperContents.BackColor = state.colorMainMenu
        sidebarWrapperBottom.BackColor = state.colorMainMenu
        label_time.BackColor = state.colorMainMenu

        menuTop.Visible = True
        wrapper.Visible = True
        statusBarPanel.Visible = True
        sidebarWrapper.Visible = True
        sidebarWrapperBottom.Visible = True
        loadingMask.Dispose()
        Me.ResumeLayout()
        Application.DoEvents()

        doLogin()
        If state.authOk.Equals(False) Then
            Exit Sub
        End If
        sidebarWrapperContents.Visible = True
        Refresh()
        resetActivity()
        formTimeOut.Interval = 1 * 1000 'check every 1 second for new messages from the OS
        formTimeOut.Start()

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = System.Drawing.Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & "unloadedForm.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        wrapper.Controls.Add(mask)
        mask.BringToFront()

        translations.load("commonForm")
        statusMessage = translations.getText("downloadSettings")
        state.loadAddons()

        AutoUpdater.ReportErrors = False
        AutoUpdater.Mandatory = True
        AddHandler AutoUpdater.ParseUpdateInfoEvent, AddressOf AutoUpdaterOnParseUpdateInfoEvent
        ' MISSING: change to update server
        AutoUpdater.Start(state.updateServerAddr)

        Dim crashFile = New FileInfo(Path.Combine(state.basePath, "crash.log"))
        crashFile.Refresh()
        If crashFile.Exists And state.SendDiagnosticData Then
            translations.load("crashReport")
            statusMessage = translations.getText("message")
            Dim report As String = My.Computer.FileSystem.ReadAllText(Path.Combine(state.basePath, "crash.log"), System.Text.Encoding.UTF8)
            Dim logs As String() = Split(report, "-------------end report---------------")
            For i = 0 To logs.Length - 1
                If logs(i).Replace(" ", "").Replace(Environment.NewLine, "").Equals("") Then
                    Continue For
                End If

                Dim url As String = state.crashReportServerAddr.Replace("{origin}", state.userId).Replace("{report}", System.Uri.EscapeDataString(logs(i)))
                Dim request As New HttpData(state)
                Dim response As String = request.RequestExternalData(url)

                If Not IsNothing(Me.busy) Then
                    If Me.busy.isActive().Equals(True) Then
                        Static start As Single
                        start = Microsoft.VisualBasic.Timer()
                        While Not Me.IsHandleCreated And Microsoft.VisualBasic.Timer() < start + 10
                        End While
                        If Not Me.IsHandleCreated Then
                            translations.load("system")
                            MainMdiForm.statusMessage = translations.getText("errorFormNoHandle")
                            Exit Sub
                        End If
                        Me.busy.Close(True)
                    End If
                End If
                If Not IsResponseOk(response) Then
                    translations.load("messagebox")
                    msgbox = New message_box_frm(GetMessage(response) & ". ", translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                    msgbox.ShowDialog()
                End If
            Next i
            Try
                crashFile.Delete()
            Catch ex As Exception
                translations.load("readyMessages")
                statusMessage = translations.getText("errorDeletingData")
            End Try
        End If
        translations.load("readyMessages")
        statusMessage = translations.getText("ready")
    End Sub

    Public Sub loadLanguage()
        translations = New languageTranslations(state)
        translations.load("main")
        menu_profile_title.Text = translations.getText("menuProfileTitle").ToUpper
        menu_data_title.Text = translations.getText("menuDataTitle").ToUpper
        menu_workers_title.Text = translations.getText("menuWorkersTitle").ToUpper
        menu_site_title.Text = translations.getText("menuSiteTitle").ToUpper
        menu_clients_title.Text = translations.getText("menuClientsTitle").ToUpper
        menu_companies_title.Text = translations.getText("menuSubContractsTitle").ToUpper
        menu_reports_title.Text = translations.getText("menuReportsTitle").ToUpper
        menu_help_title.Text = translations.getText("menuHelpTitle").ToUpper
        menu_exit_title.Text = translations.getText("menuExitTitle").ToUpper

        menu_item_profile_myprofile.Text = translations.getText("menuItemMyProfile").ToUpper
        menu_item_profile_settings.Text = translations.getText("menuItemSettings").ToUpper
        menu_item_profile_logout.Text = translations.getText("menuItemLogout").ToUpper
        menuItem_data_export.Text = translations.getText("menuItemExport").ToUpper
        menuItem_data_print.Text = translations.getText("menuItemPrint").ToUpper
        menuItem_data_print_setup.Text = translations.getText("menuItemPageSetup").ToUpper
        menuItem_workers_card.Text = translations.getText("menuItemWorkerFile").ToUpper
        menu_worker_locate.Text = translations.getText("menuItemLocateWorker").ToUpper
        menu_wrokers_docs.Text = translations.getText("menuItemWorkerDocs").ToUpper
        menu_site_logger.Text = translations.getText("menuIytemDailyAttendance").ToUpper
        menu_site_duplicate_entries.Text = translations.getText("menuItemDuplicates").ToUpper
        menu_site_absenses.Text = translations.getText("menuItemAbsences").ToUpper
        menu_site_holidays.Text = translations.getText("menuItemHolidays").ToUpper
        menu_site_teams.Text = translations.getText("menuItemTeams").ToUpper
        menu_site_fermeture_days.Text = translations.getText("menuItemFermetures").ToUpper
        menu_site_team_works.Text = translations.getText("menuItemTeamWorks").ToUpper
        menu_site_clothes.Text = translations.getText("menuItemClothes").ToUpper
        menu_site_materials_stockage.Text = translations.getText("menuItemMaterialStocks").ToUpper
        menu_site_reception_materials.Text = translations.getText("menuItemMaterialDelivery").ToUpper
        menu_site_machinery.Text = translations.getText("menuItemMachinery").ToUpper
        menu_site_site_activity.Text = translations.getText("menuItemSiteActivity").ToUpper
        menu_site_meteo.Text = translations.getText("menuItemMeteo").ToUpper
        menu_site_mobile_devices.Text = translations.getText("menuItemSiteDevices").ToUpper
        menu_clients_site_file.Text = translations.getText("menuItemSiteFile").ToUpper
        menu_companies_companies.Text = translations.getText("menuItemSubContractsCompanies").ToUpper
        menu_workers_list_workers.Text = translations.getText("menuItemReportWorkers").ToUpper
        menu_reports_list_clothes.Text = translations.getText("menuItemReportClothes").ToUpper
        menu_reports_list_absences.Text = translations.getText("menuItemReportAbsences").ToUpper
        menu_site_montly_resume.Text = translations.getText("menuItemReportAttendance").ToUpper
        menu_reports_materials_delivery.Text = translations.getText("menuItemReportMaterialsDelivery").ToUpper
        menu_reports_site_closed.Text = translations.getText("menuItemReportSiteClosures").ToUpper
        menu_help_about.Text = translations.getText("menuItemHelpAbout").ToUpper

        menu_title.Text = translations.getText("menuTitle").ToUpper
    End Sub
    Private Sub doLogin()

        state.authOk = False
        If (WindowState.Equals(FormWindowState.Minimized)) Then
            Exit Sub
        End If
        If auth_frm.Visible.Equals(True) Then
            auth_frm.Location = New Point(Me.Width / 2 - auth_frm.Width / 2, Me.Height / 2 - auth_frm.Height / 2)
            auth_frm.Focus()
        Else
            auth_frm.ShowDialog()
        End If
    End Sub

    Public Sub NoNetwork()
        UnloadForms()
        Dim mask As PictureBox = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & Convert.ToString("noNetwork.png"))
        mask.SizeMode = PictureBoxSizeMode.StretchImage
        mask.Parent = wrapper
        wrapper.Controls.Add(mask)
    End Sub

    Public Sub UnloadForms()
        childForm = ""
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If
        Exit Sub

        If Me.wrapper.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.wrapper.Controls.Count - 1 To 0 Step -1
                ctrl = Me.wrapper.Controls(i)
                Try
                    'MISSING - BUGS HERE EVEN INSIDE THE TRY BLOCK
                    Me.wrapper.Controls.Remove(ctrl)

                Catch ex As Exception
                    statusMessage = "Error unloading form"
                End Try
            Next
            ctrl.Dispose()
        End If

        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = System.Drawing.Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & "unloadedForm.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        wrapper.Controls.Add(mask)
        mask.BringToFront()

    End Sub
    Private Sub terminateApplicationAndExit()
        translations.load("main")
        Dim message As String = translations.getText("exitApp")
        translations.load("messagebox")
        msgbox = New message_box_frm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If msgbox.ShowDialog = MsgBoxResult.Yes Then
            ' UnloadForms()
            Close()
            System.Windows.Forms.Application.Exit()
        End If
    End Sub
    Private Sub main_exit_Click(sender As Object, e As EventArgs) Handles main_exit.Click
        terminateApplicationAndExit()
    End Sub

    Private Sub main_minimize_Click(sender As Object, e As EventArgs) Handles main_minimize.Click
        'DropClickMinimize(main_minimize)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub main_maximize_Click(sender As Object, e As EventArgs) Handles main_maximize.Click
        'DropClickMaximize(main_maximize)
        Me.WindowState = FormWindowState.Maximized
        main_maximize.Visible = False
        main_restore.Visible = True
    End Sub

    Private Sub main_restore_Click(sender As Object, e As EventArgs) Handles main_restore.Click
        Exit Sub
        'DropClickRestore(main_restore)
        Me.WindowState = FormWindowState.Normal
        main_restore.Visible = False
        main_maximize.Visible = True
    End Sub

    Private Sub sidebarWrapper_Paint(sender As Object, e As PaintEventArgs) Handles sidebarWrapper.Paint
        Dim TheControl As Control = CType(sender, Control)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
        Dim oGradientBrush As Brush = New System.Drawing.Drawing2D.LinearGradientBrush(
                                      oRAngle, System.Drawing.Color.DarkSlateGray,
                                      System.Drawing.Color.DarkSlateGray,
                                      System.Drawing.Drawing2D _
                                      .LinearGradientMode.ForwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub MenuSidebar_Click(sender As Object, e As EventArgs) Handles MenuSidebar.Click
        DropClickMenu(MenuSidebar)
        Me.SuspendLayout()

        If (sidebarWrapper.Width.Equals(300)) Then
            MenuItemStateReset(False)
            sidebarWrapper.Width = 36
        Else
            sidebarWrapper.Width = 300
        End If
        Me.ResumeLayout()
        sidebarWrapper.Refresh()


    End Sub

    Private Sub MenuUpdate()
        sidebarWrapperContents.SuspendLayout()

        Dim j As Integer = 0
        Dim prevItem As KeyValuePair(Of String, _menuHolder) = Nothing
        For Each item In menuHolder

            If item.Value.state Then
                menuHolder.Item(item.Key).panel.Height = menuHolder.Item(item.Key).openHeight
            Else
                menuHolder.Item(item.Key).panel.Height = 30
            End If
            If j.Equals(0) Then

                prevItem = item
                j = j + 1
                Continue For
            End If
            menuHolder.Item(item.Key).panel.Location = New Point(menuHolder.Item(item.Key).panel.Location.X, menuHolder.Item(prevItem.Key).panel.Location.Y + menuHolder.Item(prevItem.Key).panel.Height + 3)

            prevItem = item
            j = j + 1
        Next
        sidebarWrapperContents.ResumeLayout()
        sidebarWrapperContents.Refresh()

    End Sub

    Private Sub MenuItemState(itemKey As String, state As Boolean)
        Dim ItemTemp As _menuHolder = Nothing

        For i As Integer = 0 To menuHolder.Count - 1
            ItemTemp = menuHolder.ElementAt(i).Value
            If menuHolder.ElementAt(i).Key.Equals(itemKey) Then
                ItemTemp.state = state
            Else
                ItemTemp.state = False
            End If

            'ItemTemp.state = If(menuHolder.ElementAt(i).Key.Equals(itemKey), state, False)
            menuHolder(menuHolder.ElementAt(i).Key) = ItemTemp
        Next

        MenuUpdate()
    End Sub

    Private Sub MenuItemStateReset(state As Boolean)
        Dim ItemTemp As _menuHolder = Nothing

        For i As Integer = 0 To menuHolder.Count - 1
            ItemTemp = menuHolder.ElementAt(i).Value
            ItemTemp.state = state
            menuHolder(menuHolder.ElementAt(i).Key) = ItemTemp
        Next
        MenuUpdate()
    End Sub


    Private Sub wrapper_got_focus(sender As Object, e As EventArgs) Handles wrapper.GotFocus
        sidebarWrapper.Width = 36
    End Sub

    Private Sub menu_data_title_Click(sender As Object, e As EventArgs) Handles menu_data_title.Click
        MenuItemState("data", Not menuHolder("data").state)
    End Sub

    Private Sub menu_workers_title_Click(sender As Object, e As EventArgs) Handles menu_workers_title.Click
        MenuItemState("workers", Not menuHolder("workers").state)
    End Sub

    Private Sub menu_site_title_Click(sender As Object, e As EventArgs) Handles menu_site_title.Click
        MenuItemState("site", Not menuHolder("site").state)
    End Sub

    Private Sub menu_clients_title_Click(sender As Object, e As EventArgs) Handles menu_clients_title.Click
        MenuItemState("clients", Not menuHolder("clients").state)
    End Sub

    Private Sub menu_companies_title_Click(sender As Object, e As EventArgs) Handles menu_companies_title.Click
        MenuItemState("companies", Not menuHolder("companies").state)
    End Sub
    Private Sub menu_reports_title_Click(sender As Object, e As EventArgs) Handles menu_reports_title.Click
        MenuItemState("reports", Not menuHolder("reports").state)
    End Sub

    Private Sub menu_help_title_Click(sender As Object, e As EventArgs) Handles menu_help_title.Click
        MenuItemState("help", Not menuHolder("help").state)
    End Sub

    Private Sub menu_settings_title_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub menu_exit_title_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menu_exit_title_Click_1(sender As Object, e As EventArgs) Handles menu_exit_title.Click
        terminateApplicationAndExit()
    End Sub

    Private Sub menu_help_icon_title_Click(sender As Object, e As EventArgs) Handles menu_help_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("help", Not menuHolder("help").state)
    End Sub

    Private Sub menu_data_icon_title_Click(sender As Object, e As EventArgs) Handles menu_data_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("data", Not menuHolder("data").state)
    End Sub

    Private Sub menu_workers_icon_title_Click(sender As Object, e As EventArgs) Handles menu_workers_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("workers", Not menuHolder("workers").state)
    End Sub

    Private Sub menu_site_icon_title_Click(sender As Object, e As EventArgs) Handles menu_site_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("site", Not menuHolder("site").state)
    End Sub

    Private Sub menu_clients_icon_title_Click(sender As Object, e As EventArgs) Handles menu_clients_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("clients", Not menuHolder("clients").state)
    End Sub

    Private Sub menu_companies_icon_title_Click(sender As Object, e As EventArgs) Handles menu_companies_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("companies", Not menuHolder("companies").state)
    End Sub

    Private Sub menu_reports_icon_title_Click(sender As Object, e As EventArgs) Handles menu_reports_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("reports", Not menuHolder("reports").state)
    End Sub

    Private Sub menu_settings_icon_title_Click(sender As Object, e As EventArgs)
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("settings", Not menuHolder("settings").state)
    End Sub

    Private Sub menu_logout_icon_title_Click(sender As Object, e As EventArgs)
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("logout", Not menuHolder("logout").state)
    End Sub

    Private Sub menu_exit_icon_title_Click(sender As Object, e As EventArgs) Handles menu_exit_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("exit", Not menuHolder("exit").state)
    End Sub
    Private Sub menu_profile_title_Click(sender As Object, e As EventArgs) Handles menu_profile_title.Click
        MenuItemState("profile", Not menuHolder("profile").state)
    End Sub

    Private Sub menu_profile_icon_title_Click(sender As Object, e As EventArgs) Handles menu_profile_icon_title.Click
        If (sidebarWrapper.Width.Equals(36)) Then
            sidebarWrapper.Width = 300
        End If
        MenuItemState("profile", Not menuHolder("profile").state)
    End Sub

    Private Sub wrapper_Resize(sender As Object, e As System.EventArgs)
        Dim test As Integer = wrapper.Size.Width

        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Size = wrapper.Size
            CurrentWrapperForm.Refresh()
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles menuItem_data_export.Click
        If BusyMenuOption Then
            Exit Sub
        End If

        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        If Not CheckFields() Then
            Exit Sub
        End If
        BusyMenuOption = True

        Dim dgvzz As DataGridView = Nothing
        If childForm.Equals("report") Then
            dgvzz = report_frm.currentDatatable
        ElseIf childForm.Equals("logger") Then
            dgvzz = logger_frm.currentDatatable
        ElseIf childForm.Equals("site") Then
            dgvzz = site_frm.currentDatatable
        ElseIf childForm.Equals("listworkers") Then
            dgvzz = frm_worker_list.currentDatatable
        ElseIf childForm.Equals("siteClosureList") Then
            dgvzz = siteClosureList_frm.currentDatatable
        ElseIf childForm.Equals("receptionMaterialsList") Then
            dgvzz = receptionMaterials_frm.currentDatatable
        ElseIf childForm.Equals("workersAbsenseList") Then
            dgvzz = workersAbsenseList_frm.currentDatatable
        ElseIf childForm.Equals("workersClothesList") Then
            dgvzz = workersClothesList_frm.currentDatatable
        End If

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.CreatePrompt = False
        saveFileDialog1.OverwritePrompt = False
        saveFileDialog1.Filter = "xlsx Excel (*.xlsx*)|*.xlsx"
        saveFileDialog1.Title = "Save a Excel File"
        saveFileDialog1.ShowDialog()
        ' If the file name is not an empty string open it for saving.  
        If saveFileDialog1.FileName = "" Then
            BusyMenuOption = False
            Exit Sub
        End If

        Dim cfgFile = New FileInfo(saveFileDialog1.FileName)
        cfgFile.Refresh()
        If cfgFile.Exists Then
            Try
                FileSystem.Kill(saveFileDialog1.FileName)
            Catch ex As Exception
                translations.load("errorMessages")
                Dim errorFileIsWriteProtected As String = translations.getText("errorNoTableToExport")
                translations.load("messagebox")
                msgbox = New message_box_frm(errorFileIsWriteProtected, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Exit Sub
            End Try

        End If
        If Not IsNothing(Me.busy) Then
            If Me.busy.isActive().Equals(False) Then
                Me.busy = New BusyThread
                Me.busy.Show()
            End If
        End If

        'Creating DataTable
        Dim dt As New DataTable()
        Dim NullString As String = "\0"
        Dim repeater As String = ""
        Dim rndRepeaters As String()
        ReDim rndRepeaters(0)
        rndRepeaters(0) = ""

        'Adding the Columns
        For Each column As DataGridViewColumn In dgvzz.Columns
            Dim col As DataColumn = New DataColumn()
            repeater = column.HeaderText.ToString
            Randomize()
            Dim rndNum As Integer = 1
            While Array.IndexOf(rndRepeaters, repeater) > -1
                repeater = column.HeaderText.ToString & StrDup(rndNum, NullString)
                rndNum += 1
            End While
            rndRepeaters(UBound(rndRepeaters)) = repeater
            ReDim Preserve rndRepeaters(UBound(rndRepeaters) + 1)

            col.Caption = repeater
            col.ColumnName = repeater
            col.DataType = System.Type.GetType("System.String")

            dt.Columns.Add(col)
        Next

        'Adding the Rows
        For Each row As DataGridViewRow In dgvzz.Rows
            dt.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = If(IsNothing(cell.Value), "", cell.Value.ToString())
            Next
        Next

        'Exporting to Excel
        Using wb As New XLWorkbook()
            wb.Worksheets.Add(dt, "Customers")
            wb.SaveAs(saveFileDialog1.FileName)
        End Using

        If Not IsNothing(Me.busy) Then
            If Me.busy.isActive().Equals(True) Then
                Me.busy.Close(True)
            End If
        End If
        translations.load("successMessages")
        Dim successTableExport As String = translations.getText("successTableExport")
        translations.load("messagebox")
        msgbox = New message_box_frm(successTableExport, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        msgbox.ShowDialog()

        BusyMenuOption = False
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            saveCrash(ex)
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub

    Private Sub menuItem_data_print_Click(sender As Object, e As EventArgs) Handles menuItem_data_print.Click
        If BusyMenuOption Then
            Exit Sub
        End If

        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        If Not CheckFields() Then
            Exit Sub
        End If
        BusyMenuOption = True

        If childForm.Equals("document") Then
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim printDoc As New PrintDocument()
                printDoc.DocumentName = "Print Document"
                PrintDialog1.Document = PrintDocument2
                PrintDialog1.AllowSelection = True
                PrintDialog1.AllowSomePages = True
                PageSetupDialog1.Document = PrintDocument2
                With PageSetupDialog1.Document.DefaultPageSettings
                    .Landscape = False
                End With
                printDoc.Print()
            End If
        Else
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim printDoc As New PrintDocument()
                printDoc.DocumentName = "Print Document"
                PrintDialog1.Document = PrintDocument1
                PrintDialog1.AllowSelection = True
                PrintDialog1.AllowSomePages = True
                PageSetupDialog1.Document = PrintDocument1
                With PageSetupDialog1.Document.DefaultPageSettings
                    .Landscape = False
                End With
                printDoc.Print()
            End If
        End If

    End Sub



    Private Sub PrintDocument2_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument2.BeginPrint
        checkPrint = 0
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 0.75
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        Dim richtext As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl = CType(CurrentWrapperForm.Controls.Item("richtxt"), RichTextBoxPrintCtrl.RichTextBoxPrintCtrl)
        checkPrint = richtext.Print(checkPrint, richtext.TextLength, e)

        ' Look for more pages
        If checkPrint < richtext.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private mRow As Integer = 0
    Private newpage As Boolean = True

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' sets it to show '...' for long text
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        Dim y As Int32 = e.MarginBounds.Top
        Dim rc As System.Drawing.Rectangle
        Dim x As Int32
        Dim h As Int32 = 0
        Dim row As DataGridViewRow
        Dim scale As Double = 1


        Dim dgvzz As DataGridView = Nothing
        If childForm.Equals("report") Then
            dgvzz = report_frm.currentDatatable
        ElseIf childForm.Equals("logger") Then
            dgvzz = logger_frm.currentDatatable
        ElseIf childForm.Equals("site") Then
            dgvzz = site_frm.currentDatatable
        ElseIf childForm.Equals("listworkers") Then
            dgvzz = frm_worker_list.currentDatatable
        ElseIf childForm.Equals("receptionMaterialsList") Then
            dgvzz = receptionMaterials_frm.currentDatatable
        ElseIf childForm.Equals("workersAbsenseList") Then
            dgvzz = workersAbsenseList_frm.currentDatatable
        ElseIf childForm.Equals("workersClothesList") Then
            dgvzz = workersClothesList_frm.currentDatatable
        End If



        scale = (e.MarginBounds.Width / dgvzz.Width) * 1.0

        ' print the header text for a new page
        '   use a grey bg just like the control
        If newpage Then
            row = dgvzz.Rows(mRow)
            x = e.MarginBounds.Left

            For Each cell As DataGridViewCell In row.Cells
                ' since we are printing the control's view,
                ' skip invidible columns
                If cell.Visible Then

                    rc = New System.Drawing.Rectangle(x, y, cell.Size.Width * scale, cell.Size.Height)

                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    ' reused in the data pront - should be a function
                    Select Case dgvzz.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(dgvzz.Columns(cell.ColumnIndex).HeaderText,
                                                dgvzz.Font, Brushes.Black, rc, fmt)
                    x += rc.Width
                    h = System.Math.Max(h, rc.Height)
                End If
            Next
            y += h

        End If
        newpage = False

        ' now print the data for each row
        Dim thisNDX As Int32
        For thisNDX = mRow To dgvzz.RowCount - 1
            ' no need to try to print the new row
            If dgvzz.Rows(thisNDX).IsNewRow Then Exit For

            row = dgvzz.Rows(thisNDX)
            x = e.MarginBounds.Left
            h = 0

            ' reset X for data
            x = e.MarginBounds.Left

            ' print the data
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New System.Drawing.Rectangle(x, y, cell.Size.Width * scale, cell.Size.Height)

                    ' SAMPLE CODE: How To 
                    ' up a RowPrePaint rule
                    'If Convert.ToDecimal(row.Cells(5).Value) < 9.99 Then
                    '    Using br As New SolidBrush(Color.MistyRose)
                    '        e.Graphics.FillRectangle(br, rc)
                    '    End Using
                    'End If

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    Select Case dgvzz.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(cell.FormattedValue.ToString(), dgvzz.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = System.Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' next row to print
            mRow = thisNDX + 1

            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                ' mRow -= 1   causes last row to rePrint on next page
                If (dgvzz.RowCount - 1) >= mRow Then
                    newpage = True
                End If
                Return
            End If
        Next


    End Sub
    Private Function CheckFields() As Boolean

        translations.load("busyMessages")
        statusMessage = translations.getText("loadingTable")
        translations.load("errorMessages")
        Dim errorNoTableToExport As String = translations.getText("errorNoTableToExport")
        translations.load("messagebox")

        If Not (childForm.Equals("report") Or childForm.Equals("logger") Or childForm.Equals("site") Or childForm.Equals("document") Or childForm.Equals("listworkers") _
           Or childForm.Equals("workersAbsenseList") Or childForm.Equals("receptionMaterialsList") Or childForm.Equals("workersClothesList")) Or childForm.Equals("") Then
            msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            BusyMenuOption = False
            Return False
        End If

        If childForm.Equals("workersClothesList") Then
            If IsNothing(workersClothesList_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf workersClothesList_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("workersAbsenseList") Then
            If IsNothing(workersAbsenseList_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf workersAbsenseList_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("receptionMaterialsList") Then
            If IsNothing(receptionMaterials_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf receptionMaterials_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("siteClosureList") Then
            If IsNothing(siteClosureList_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf siteClosureList_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("report") Then
            If IsNothing(report_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf report_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("logger") Then
            If IsNothing(logger_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf logger_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("site") Then
            translations.load("siteActivity")
            If site_frm.TabControl.SelectedTab.Text.Equals(translations.getText("deliveryTabTitle")) Then
                site_frm.currentDatatable = site_frm.currentLivraisonDatatable
            ElseIf site_frm.TabControl.SelectedTab.Text.Equals(translations.getText("regieTabTitle")) Then
                site_frm.currentDatatable = site_frm.currentRegieDatatable
            ElseIf site_frm.TabControl.SelectedTab.Text.Equals(translations.getText("productionTabTitle")) Then
                site_frm.currentDatatable = site_frm.currentProductionDatatable
            ElseIf site_frm.TabControl.SelectedTab.Text.Equals(translations.getText("tasksTabTitle")) Then
                site_frm.currentDatatable = site_frm.currentBorderauDatatable
            End If

            If IsNothing(site_frm.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf site_frm.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If

        If childForm.Equals("listworkers") Then
            If IsNothing(frm_worker_list.currentDatatable) Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            ElseIf frm_worker_list.currentDatatable.Rows.Count < 1 Then
                msgbox = New message_box_frm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        mRow = 0
        newpage = True
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
    End Sub

    Private Sub menuItem_data_print_setup_Click(sender As Object, e As EventArgs) Handles menuItem_data_print_setup.Click

        With PageSetupDialog1
            .AllowMargins = True
            .AllowOrientation = True
            .AllowPaper = True
            .AllowPrinter = True
            .ShowHelp = True
            .ShowNetwork = True

            .Document = PrintDocument1
        End With
        With PageSetupDialog1.Document.DefaultPageSettings
            .Margins.Top = 50
            .Margins.Left = 50
            .Margins.Right = 50
            .Margins.Bottom = 50
            .Landscape = True
        End With
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub menu_worker_locate_Click(sender As Object, e As EventArgs) Handles menu_worker_locate.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        Me.busy = New BusyThread
        Me.busy.Show()
        frm_locate_worker.ShowDialog()
    End Sub

    Private Sub menu_workers_list_workers_Click(sender As Object, e As EventArgs) Handles menu_workers_list_workers.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New frm_worker_list With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_wrokers_docs_Click(sender As Object, e As EventArgs) Handles menu_wrokers_docs.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New documentos_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm

        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_site_mobile_devices_Click(sender As Object, e As EventArgs) Handles menu_site_mobile_devices.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        frm_tablets.ShowDialog()
    End Sub

    Private Sub menu_site_meteo_Click(sender As Object, e As EventArgs) Handles menu_site_meteo.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        meteo_frm.ShowDialog()
    End Sub

    Private Sub menu_site_clothes_Click(sender As Object, e As EventArgs) Handles menu_site_clothes.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        workersClothes_frm.ShowDialog()
    End Sub

    Private Sub wrapper_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles menuItem_workers_card.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New workers_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill
        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_site_duplicate_entries_Click(sender As Object, e As EventArgs) Handles menu_site_duplicate_entries.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        If My.Application.OpenForms().OfType(Of attendance_records_verification_frm).Any Then
            attendance_records_verification_frm.BringToFront()
            attendance_records_verification_frm.WindowState = FormWindowState.Normal
        Else
            Me.busy = New BusyThread
            Me.busy.Show()
            attendance_records_verification_frm.WindowState = FormWindowState.Normal
            attendance_records_verification_frm.TopMost = True
            attendance_records_verification_frm.Show()
            attendance_records_verification_frm.BringToFront()
        End If
    End Sub


    Private Sub menu_site_absenses_Click(sender As Object, e As EventArgs) Handles menu_site_absenses.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        Me.busy = New BusyThread
        Me.busy.Show()
        workers_absense_frm.ShowDialog()
    End Sub

    Private Sub menu_site_holidays_Click(sender As Object, e As EventArgs) Handles menu_site_holidays.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        holidays_frm.ShowDialog()
    End Sub

    Private Sub menu_site_logger_Click(sender As Object, e As EventArgs) Handles menu_site_logger.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New logger_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_site_fermeture_days_Click(sender As Object, e As EventArgs) Handles menu_site_fermeture_days.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        site_closure_frm.ShowDialog()
    End Sub

    Private Sub menu_site_teams_Click(sender As Object, e As EventArgs) Handles menu_site_teams.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New team_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_site_site_activity_Click(sender As Object, e As EventArgs) Handles menu_site_site_activity.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New site_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()

    End Sub

    Private Sub menu_site_montly_resume_Click(sender As Object, e As EventArgs) Handles menu_site_montly_resume.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New report_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_site_reception_materials_Click(sender As Object, e As EventArgs) Handles menu_site_reception_materials.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        Me.busy = New BusyThread
        Me.busy.Show()
        site_materials_reception_frm.ShowDialog()
    End Sub

    Private Sub menu_clients_site_file_Click(sender As Object, e As EventArgs) Handles menu_clients_site_file.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New site_mng_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_help_about_Click(sender As Object, e As EventArgs) Handles menu_help_about.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        about_frm.ShowDialog()
    End Sub

    Private Sub clock_Tick(sender As Object, e As EventArgs) Handles clock.Tick
        If (sidebarWrapper.Width.Equals(36)) Then
            label_time.Text = TimeOfDay.ToString("HH:mm")
        Else
            label_time.Text = TimeOfDay.ToString("HH:mm") & ", " & DateTime.Now.ToString("dd MMMM yyyy")
        End If
        If Not statusMessage.Equals(statusText.Text) Then
            statusText.Text = statusMessage
        End If
    End Sub

    Private Sub menu_item_profile_logout_Click(sender As Object, e As EventArgs) Handles menu_item_profile_logout.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        menu_profile_icon_title.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
        menu_profile_icon_title.SizeMode = PictureBoxSizeMode.StretchImage
        UnloadForms()
        doLogin()
    End Sub



    Private Sub menu_reports_site_closed_Click(sender As Object, e As EventArgs) Handles menu_reports_site_closed.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New siteClosureList_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_reports_materials_delivery_Click(sender As Object, e As EventArgs) Handles menu_reports_materials_delivery.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New receptionMaterials_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_reports_list_absences_Click(sender As Object, e As EventArgs) Handles menu_reports_list_absences.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New workersAbsenseList_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()

    End Sub





    Private Sub Menu_reports_list_clothes_Click(sender As Object, e As EventArgs) Handles menu_reports_list_clothes.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()


        UnloadForms()
        Me.busy = New BusyThread
        Me.busy.Show()

        CurrentWrapperForm = New workersClothesList_frm With {.TopLevel = False, .AutoSize = False}
        CurrentWrapperForm.Parent = wrapper
        CurrentWrapperForm.Size = wrapper.Size
        CurrentWrapperForm.Dock = DockStyle.Fill

        LoadedFrm = CurrentWrapperForm
        CurrentWrapperForm.Show()
    End Sub

    Private Sub menu_item_profile_myprofile_Click(sender As Object, e As EventArgs) Handles menu_item_profile_myprofile.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        Me.busy = New BusyThread
        Me.busy.Show()
        frm_user_profile.WindowState = FormWindowState.Normal
        frm_user_profile.TopMost = True
        frm_user_profile.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click

    End Sub

    Private Sub PictureBox26_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menu_item_profile_settings_Click(sender As Object, e As EventArgs) Handles menu_item_profile_settings.Click
        MenuItemStateReset(False)
        SuspendLayout()
        sidebarWrapper.Width = 36
        ResumeLayout()
        Refresh()

        Me.busy = New BusyThread
        Me.busy.Show()
        settings_frm.WindowState = FormWindowState.Normal
        settings_frm.TopMost = True
        settings_frm.ShowDialog()
    End Sub


End Class