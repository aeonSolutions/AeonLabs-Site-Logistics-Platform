Imports System.Drawing.Printing
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports ClosedXML.Excel

Public Class MainMdiForm
    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public childForm As String = ""
    Private checkPrint As Integer

    Public loaded As Boolean = False
    Public Property state As environmentVars
    Public Property statusMessage As String = ""

    Private statusMessageLast As String = ""
    Private statusMessageTimeout As Integer = 10
    Private statusMessagePile As New List(Of String)

    Public busy As BusyThread
    Private msgbox As messageBoxForm
    Private mask, loadingMask As PictureBox

    Private translations As languageTranslations
    Private BusyMenuOption As Boolean = False

    Private menuHolder As New Dictionary(Of String, _menuHolder)
    Public Shared usernamePhoto As PictureBox = Nothing

    Private mbDoPaintBackground As Boolean
    Private Const WM_SYSCOMMAND = &H112

    Private splashScreenLogin As SplashScreen

    Structure _menuHolder
        Public panel As Panel
        Public state As Boolean
        Public openHeight As Integer
    End Structure

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If IsNothing(state) Then
            Exit Sub
        End If
        If (WindowState.Equals(FormWindowState.Maximized) Or WindowState.Equals(FormWindowState.Normal)) And state.authOk.Equals(False) And loaded Then
            doLogin()
        End If

        If (WindowState = FormWindowState.Minimized) And loaded Then
            mask = New PictureBox
            mask.Dock = DockStyle.Fill
            mask.BackColor = Color.White
            mask.Top = TopMost
            'mask.Image = Image.FromFile(mainForm.state.imagesPath & "loadingPage.png")
            mask.SizeMode = PictureBoxSizeMode.CenterImage
            Me.Controls.Add(mask)
            mask.BringToFront()
            mask.Refresh()
        ElseIf loaded Then
            FormRedraw.Enabled = True
        End If

        If WindowState = FormWindowState.Maximized OrElse WindowState = FormWindowState.Minimized Then
            mbDoPaintBackground = True
            Invalidate()
        End If
    End Sub
    Private Sub FormRedraw_Tick(sender As Object, e As EventArgs) Handles FormRedraw.Tick
        If mask IsNot Nothing Then
            mask.Dispose()
            mask = Nothing
        End If
        FormRedraw.Enabled = False
    End Sub

    Public Sub New(stateIni As environmentVarsCore)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        Me.WindowState = FormWindowState.Maximized
        state = stateIni
        translations = New languageTranslations(state)
        Me.busy = New BusyThread(Me)
    End Sub

    'inactivity timer code
    Dim inActivity As New Stopwatch

    Private Const WM_MAXBUTTONSomethingSomething As Integer = &HF030  '61488
    Private Const WM_MINBUTTONSomethingSomething As Integer = &HF120   '61728
    ' sub to address flickering on maximize form
    Protected Overrides Sub WndProc(ByRef m As Message)
        'Traps specifically for "Maximize" button
        Try
            If m.Msg = WM_SYSCOMMAND Then
                ' Handle running on 64-bit platforms
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
            usernamePhoto.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
            usernamePhoto.SizeMode = PictureBoxSizeMode.StretchImage
            UnloadForms()
            doLogin()
        End If
    End Sub

    Private Sub MainMdiForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaded = False
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        loadingMask = New PictureBox
        loadingMask.Dock = DockStyle.Fill
        loadingMask.BackColor = Color.White
        loadingMask.Top = TopMost
        loadingMask.Image = Image.FromFile(state.imagesPath & "unloadedForm.png")
        loadingMask.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(loadingMask)
        loadingMask.BringToFront()
        Refresh()
        buildMenu()

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
        wrapper.Parent = backgroundAnimation
        wrapper.BackColor = Color.Transparent
        sidePanelMenuTop.Parent = backgroundAnimation
        sidePanelMenuTop.BackColor = Color.Transparent
        PanelMenuTop.Parent = backgroundAnimation
        PanelMenuTop.BackColor = Color.Transparent
        wrapper.AutoScroll = True

        label_time.Text = TimeOfDay.ToString("HH:mm")
        ResumeLayout()
    End Sub

    Private Sub MainMdiForm_show(sender As Object, e As EventArgs) Handles MyBase.Shown

        SuspendLayout()
        label_time.BackColor = state.colorMainMenu

        wrapper.Visible = True
        loadingMask.Dispose()
        Me.ResumeLayout()
        loaded = True

        loadLanguage()
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
    End Sub

    Private Sub wrapper_Paint_1(sender As Object, e As TableLayoutCellPaintEventArgs) Handles wrapper.CellPaint
        '' If e.Row = 0 Or e.Row = 2 Then
        ''Using brush As SolidBrush = New SolidBrush(Color.FromArgb(150, Color.Black))
        ''e.Graphics.FillRectangle(brush, e.CellBounds)
        ''End Using
        ''End If
    End Sub

    Private Sub buildMenu()
        Dim menuPosY As Integer = 5
        Dim menuPosX As Integer = 0
        Dim titlePosY As Integer = 0
        Dim menuItemHeight As Integer = 50
        Dim subMenuItemColor = Color.FromArgb(39, 49, 61)
        Dim subMenuActiveBarColor = Color.Orange
        Dim subMenuPos As Integer = 0
        Dim menuPos As Integer = 0

        translations.load("main")

        For Each menuItem In state.bundleSpecificVars.menu
            Dim subMenuItems As List(Of bundleSpecificVarsClass._menuStruct)
            subMenuItems = menuItem.Value
            Dim menuPanel As Panel = New Panel With {
                .Width = wrapper.ColumnStyles(0).Width - 30,
                .Location = New Point(0, menuPosY + menuPos * (menuItemHeight + 1)),
                .Height = menuItemHeight,
                .Name = menuItem.Key
            }

            subMenuPos = 0
            For Each subMenuItem In subMenuItems
                Dim subMenuPanel As New Panel With {
                .Width = menuPanel.Width,
                .Height = menuItemHeight,
                .BackColor = subMenuItemColor,
                .Name = menuItem.Key & "-" & subMenuPos
                }
                AddHandler subMenuPanel.Click, AddressOf menuPanel_Click


                If subMenuItem.submenu.Equals(False) Then ' new menu item
                    menuPosX = menuItemHeight + 5

                    Dim subMenuIcon As New PictureBox With {
                    .Width = menuItemHeight - 10,
                    .Height = menuItemHeight - 10,
                    .Location = New Point(0, 5),
                    .Parent = subMenuPanel
                    }

                    If subMenuItem.TagTitle.Equals("username") Then
                        If (state.userPhoto.Equals("")) Then
                            subMenuIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
                        Else
                            subMenuIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("loading.png"))
                            subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage

                            Dim tClient As WebClient = New WebClient
                            Try
                                Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(state.ServerBaseAddr & "/csaml/photos/" & state.userPhoto)))
                                subMenuIcon.Image = tImage
                            Catch ex As Exception
                                translations.load("errorMessages")
                                subMenuIcon.Image = Image.FromFile(state.imagesPath & Convert.ToString("worker.icon.png"))
                                statusMessage = translations.getText("errorDownloadingPhoto")
                            End Try
                            subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage
                        End If
                        usernamePhoto = subMenuIcon
                    Else
                        With subMenuIcon
                            .Image = Image.FromFile(state.imagesPath & subMenuItem.icon)
                            .SizeMode = PictureBoxSizeMode.StretchImage
                        End With
                    End If

                    AddHandler subMenuIcon.Click, AddressOf menuPanelExpand_click
                    subMenuPanel.Controls.Add(subMenuIcon)

                    subMenuIcon = New PictureBox With {
                        .Width = menuItemHeight - 10,
                        .Height = menuItemHeight - 10,
                        .Image = Image.FromFile(state.imagesPath & "downarrow.png"),
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Location = New Point(menuPanel.Width - (menuItemHeight - 10), 5),
                        .Parent = subMenuPanel,
                        .Name = menuItem.Key & "-expandIcon"
                    }
                    'TODO add tooltips
                    AddHandler subMenuIcon.Click, AddressOf menuPanelExpand_click
                    subMenuPanel.Controls.Add(subMenuIcon)
                Else ' submenu item
                    menuPosX = 15 + 5
                    Dim activeBar As New Panel With {
                       .Width = 15,
                       .Height = menuItemHeight,
                       .BackColor = subMenuActiveBarColor,
                       .Location = New Point(0, 0),
                       .Parent = subMenuPanel
                    }
                    subMenuPanel.Controls.Add(activeBar)

                    Dim notif As New Label With {
                        .Width = menuItemHeight - 10,
                        .Height = menuItemHeight - 10,
                        .Location = New Point(menuPanel.Width - (menuItemHeight - 10), 5),
                        .Text = "",
                        .Parent = subMenuPanel
                    }
                    If subMenuItem.notifications > 0 Then
                        If subMenuItem.notifications < 10 Then
                            notif.Text = "0" & subMenuItem.notifications.ToString
                        Else
                            notif.Text = subMenuItem.notifications.ToString
                        End If
                    End If
                    AddHandler notif.Click, AddressOf menuPanelNotifications_click
                    subMenuPanel.Controls.Add(notif)
                End If

                'menu title
                If subMenuItem.TagTitle.Equals("username") Then
                    Dim subtitle As New Label With {
                        .Font = New Font(state.fontText.Families(0), state.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                        .Location = New Point(menuPosX, 26),
                        .Text = state.businessName,
                        .Parent = subMenuPanel
                    }

                    AddHandler subtitle.Click, AddressOf menuPanel_Click
                    subMenuPanel.Controls.Add(subtitle)
                    titlePosY = 0
                Else
                    titlePosY = 11
                End If

                Dim title As New Label With {
                    .Font = New Font(state.fontText.Families(0), state.menuTitleFontSize, Drawing.FontStyle.Regular),
                    .Location = New Point(menuPosX, titlePosY),
                    .Text = translations.getText(subMenuItem.TagTitle).ToUpper,
                    .Parent = subMenuPanel
                }

                AddHandler title.Click, AddressOf menuPanel_Click
                subMenuPanel.Controls.Add(title)

                menuPanel.Controls.Add(subMenuPanel)
                subMenuItem.subMenuPanel = subMenuPanel

                state.bundleSpecificVars.menu.Item(menuItem.Key).Item(subMenuPos) = subMenuItem
                subMenuPos += 1
            Next

            wrapper.Controls.Add(menuPanel, 0, 0)
            menuPos += 1
            Dim menuHolderItem As New _menuHolder
            menuHolderItem.panel = menuPanel
            menuHolderItem.state = False
            menuHolderItem.openHeight = (subMenuPos + 1) * menuItemHeight
            menuHolder.Add(menuItem.Key, menuHolderItem)
        Next
    End Sub

    Private Sub menuPanel_Click(sender As Object, e As EventArgs)
        MenuItemStateReset(False)
        SuspendLayout()
        wrapper.ColumnStyles(0).Width = 36
        UnloadForms()
        ResumeLayout()
        Refresh()

        Me.busy.Show()

        Dim menuPanel As Panel = Nothing
        If TypeOf sender Is Panel Then
            Dim ctrl As Panel = CType(sender, Panel)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is Label Then
            Dim ctrl As Label = CType(sender, Label)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is PictureBox Then
            Dim ctrl As PictureBox = CType(sender, PictureBox)
            menuPanel = ctrl.Parent
        End If

        Dim menuKey As String = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
        Dim submenuPos As Integer = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))

        If state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).TagTitle.Equals("menuExitTitle") Then
            terminateApplicationAndExit()
            Exit Sub
        End If

        If state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).TagTitle.Equals("menuExitTitle") Then
            UnloadForms()
            doLogin()
            Exit Sub
        End If

        If state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).TagTitle.Equals("menuItemExport") Then
            exportData()
            Exit Sub
        End If

        If state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).TagTitle.Equals("menuItemPrint") Then
            DataPrint()
            Exit Sub
        End If

        If state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).showDialog Then
            Dim dialogForm As Form = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ProductName & "." & state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).contentToLoad)
            dialogForm.ShowDialog()
        Else
            CurrentWrapperForm = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ProductName & "." & state.bundleSpecificVars.menu.Item(menuKey).ElementAt(submenuPos).contentToLoad)
            With CurrentWrapperForm
                .TopLevel = False
                .AutoSize = False
            End With

            CurrentWrapperForm.Size = wrapper.Size
            CurrentWrapperForm.Dock = DockStyle.Fill
            wrapper.Controls.Add(CurrentWrapperForm, 1, 0)
            CurrentWrapperForm.Show()
        End If
    End Sub
    Private Sub menuPanelExpand_click(sender As Object, e As EventArgs)
        If (wrapper.ColumnStyles(0).Width.Equals(36)) Then
            wrapper.ColumnStyles(0).Width = 300
        End If

        Dim menuPanel As Panel = Nothing
        If TypeOf sender Is Panel Then
            Dim ctrl As Panel = CType(sender, Panel)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is Label Then
            Dim ctrl As Label = CType(sender, Label)
            menuPanel = ctrl.Parent
        End If
        If TypeOf sender Is PictureBox Then
            Dim ctrl As PictureBox = CType(sender, PictureBox)
            menuPanel = ctrl.Parent
        End If

        Dim menuKey As String = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
        Dim submenuPos As Integer = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))

        MenuItemState(menuKey, Not menuHolder(menuKey).state)
    End Sub
    Private Sub menuPanelNotifications_click(sender As Object, e As EventArgs)

    End Sub

    Public Sub doMenuAnimmation(origin As String)
        Me.SuspendLayout()

        If (wrapper.ColumnStyles(0).Width.Equals(300)) Then
            MenuItemStateReset(False)
            wrapper.ColumnStyles(0).Width = 36
        ElseIf origin.Equals("main") Then
            wrapper.ColumnStyles(0).Width = 300
        End If
        Me.ResumeLayout()
        Refresh()
    End Sub

    Private Sub MenuUpdate()
        wrapper.SuspendLayout()

        Dim j As Integer = 0
        Dim prevItem As KeyValuePair(Of String, _menuHolder) = Nothing
        For Each item In menuHolder

            Dim menuKey As String = menuHolder.Item(item.Key).panel.Name.Substring(0, menuHolder.Item(item.Key).panel.Name.IndexOf("-"))
            Dim ExpandIcon As PictureBox = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ProductName & "." & menuKey & "-" & "expandIcon")


            If item.Value.state Then
                menuHolder.Item(item.Key).panel.Height = menuHolder.Item(item.Key).openHeight
                ExpandIcon.Image = Image.FromFile(state.imagesPath & "uparrow.png")
                ExpandIcon.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                menuHolder.Item(item.Key).panel.Height = 30
                ExpandIcon.Image = Image.FromFile(state.imagesPath & "downarrow.png")
                ExpandIcon.SizeMode = PictureBoxSizeMode.StretchImage
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
        wrapper.ResumeLayout()
        wrapper.Refresh()

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

    Public Sub loadLanguage()
        translations = New languageTranslations(state)
        translations.load("main")


    End Sub
    Private Sub doLogin()

        state.authOk = False
        If (WindowState.Equals(FormWindowState.Minimized)) Then
            Exit Sub
        End If

        If splashScreenLogin.Visible.Equals(True) Then
            splashScreenLogin.Focus()
        Else
            splashScreenLogin.ShowDialog()
        End If
    End Sub

    Public Sub NoNetwork()
        childForm = ""
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        Dim mask As PictureBox = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & Convert.ToString("noNetwork.png"))
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Parent = wrapper
        wrapper.Controls.Clear()
        wrapper.Controls.Add(mask)
        mask.BringToFront()
        wrapper.Refresh()
    End Sub

    Public Sub UnloadForms()
        childForm = ""
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If
        mask = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.BackColor = System.Drawing.Color.White
        mask.Top = TopMost
        mask.Image = Image.FromFile(state.imagesPath & "unloadedForm.png")
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        wrapper.Controls.Clear()
        wrapper.Controls.Add(mask)
        mask.BringToFront()
        wrapper.Refresh()
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
    End Sub
    Private Sub terminateApplicationAndExit()
        translations.load("main")
        Dim message As String = translations.getText("exitApp")
        translations.load("messagebox")
        msgbox = New messageBoxForm(message & " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        If msgbox.ShowDialog = MsgBoxResult.Yes Then
            ' UnloadForms()
            Close()
            System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub clock_Tick(sender As Object, e As EventArgs) Handles clock.Tick
        If (wrapper.ColumnStyles(0).Width.Equals(36)) Then
            label_time.Text = TimeOfDay.ToString("HH:mm")
        Else
            label_time.Text = TimeOfDay.ToString("HH:mm") & ", " & DateTime.Now.ToString("dd MMMM yyyy")
        End If
        If Not statusMessage.Equals(statusText.Text) Then
            If StatusMessagesDisplayTime.Enabled.Equals(False) Then
                StatusMessagesDisplayTime.Enabled = True
            End If
            If statusMessageTimeout >= 5 Then
                statusText.Text = statusMessage
                statusMessageTimeout = 0
            Else
                statusMessagePile.Add(statusMessage)
            End If
        End If
    End Sub

    Private Sub StatusMessagesDisplayTime_Tick(sender As Object, e As EventArgs) Handles StatusMessagesDisplayTime.Tick
        statusMessageTimeout += 1
        If statusMessageTimeout.Equals(5) Then
            If statusMessagePile.Count > 0 Then
                statusMessage = statusMessagePile.ElementAt(0)
                statusMessagePile.RemoveAt(0)
            End If
        End If
    End Sub

    Private Sub main_minimize_Click(sender As Object, e As EventArgs)
        'DropClickMinimize(main_minimize)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub sidebarWrapper_Paint(sender As Object, e As PaintEventArgs) 'Handles sidebarWrapperContents.Paint
        Dim TheControl As Control = CType(sender, Control)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
        Dim oGradientBrush As Brush = New System.Drawing.Drawing2D.LinearGradientBrush(
                                      oRAngle, state.colorMainMenu,
                                      state.colorMainMenu,
                                      System.Drawing.Drawing2D _
                                      .LinearGradientMode.ForwardDiagonal)
        e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    End Sub

    Private Sub MenuSidebar_Click(sender As Object, e As EventArgs) Handles MenuSidebar.Click
        doMenuAnimmation("main")
    End Sub

    Private Sub wrapper_got_focus(sender As Object, e As EventArgs)
        wrapper.ColumnStyles(0).Width = 36
    End Sub

    Private Sub wrapper_Resize(sender As Object, e As System.EventArgs)
        Dim test As Integer = wrapper.Size.Width
        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Size = wrapper.Size
            CurrentWrapperForm.Refresh()
        End If
    End Sub

    Private Sub exportData()
        If BusyMenuOption Then
            Exit Sub
        End If

        MenuItemStateReset(False)
        SuspendLayout()
        wrapper.ColumnStyles(0).Width = 36
        ResumeLayout()
        Refresh()

        If Not CheckFields() Then
            Exit Sub
        End If
        BusyMenuOption = True

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
                msgbox = New messageBoxForm(errorFileIsWriteProtected, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
                msgbox.ShowDialog()
                BusyMenuOption = False
                Exit Sub
            End Try

        End If
        If Not IsNothing(Me.busy) Then
            If Me.busy.isActive().Equals(False) Then

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
        For Each column As DataColumn In state.datatableContents.Columns
            Dim col As DataColumn = New DataColumn()
            repeater = column.ColumnName.ToString
            Randomize()
            Dim rndNum As Integer = 1
            While Array.IndexOf(rndRepeaters, repeater) > -1
                repeater = column.ColumnName.ToString & StrDup(rndNum, NullString)
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
        For i = 0 To state.datatableContents.Rows.Count - 1
            dt.Rows.Add()
            For j = 0 To state.datatableContents.Columns.Count - 1
                dt.Rows(dt.Rows.Count - 1)(j) = If(IsNothing(state.datatableContents.Rows(i)(j).Value), "", state.datatableContents.Rows(i)(j).Value.ToString())
            Next j
        Next i

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
        msgbox = New messageBoxForm(successTableExport, translations.getText("information"), MessageBoxButtons.OK, MessageBoxIcon.Information, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
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

    Private Sub DataPrint()
        If BusyMenuOption Then
            Exit Sub
        End If

        MenuItemStateReset(False)
        SuspendLayout()
        wrapper.ColumnStyles(0).Width = 36
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
                PrintDialog1.Document = PrintDocument1
                PrintDialog1.AllowSelection = True
                PrintDialog1.AllowSomePages = True
                PageSetupDialog1.Document = PrintDocument1
                With PageSetupDialog1.Document.DefaultPageSettings
                    .Landscape = False
                End With
                printDoc.Print()
            Else
                BusyMenuOption = False
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
            Else
                BusyMenuOption = False
            End If
        End If

    End Sub

    Private Sub PrintDocument2_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        checkPrint = 0
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 0.75
    End Sub

    Private Sub PrintDocument2_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
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
        'TODO load datatable 

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

        If state.datatableContents Is Nothing Then
            msgbox = New messageBoxForm(errorNoTableToExport, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
            msgbox.ShowDialog()
            BusyMenuOption = False
            Return False
        End If

        Return True
    End Function
    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        mRow = 0
        newpage = True
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub backgroundAnimation_Click(sender As Object, e As EventArgs) Handles backgroundAnimation.Click

    End Sub

    Private Sub wrapper_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub menuItem_data_print_setup_Click(sender As Object, e As EventArgs)

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

End Class