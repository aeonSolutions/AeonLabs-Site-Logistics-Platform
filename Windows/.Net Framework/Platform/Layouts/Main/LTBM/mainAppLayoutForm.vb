Imports System.ComponentModel
Imports AeonLabs.Environment
Imports AeonLabs.Layout.Menu.Vertical
Imports AeonLabs.BasicLibraries
Imports FontAwesome.Sharp
Imports AeonLabs.Environment.menuEnvironmentVarsClass

Public Class mainAppLayoutForm
    Inherits FormCustomized

#Region "SETUP LAYOUT"
#Region "REGISTER CONFIGURABLE LAYOUT CONTROLS"
    Private Sub registerConfigurableLayoutControls()
        'REGISTER CONFIGURABLE LAYOUT PANELS 
        registeredPanels.Add(panelLeftSide.Name)
        registeredPanels.Add(panelBottom.Name)
        registeredPanels.Add(panelTop.Name)
    End Sub
#End Region

#Region "assign control to assembly"
    Private Sub assignControlToAssembly()
        If ENABLE_TESTING_ENVIRONMENT Then
            Exit Sub
        End If
        Dim err As Boolean = False
        Dim errMsg As String = ""

        If enVars.assemblies.ContainsKey("settings.layout.widget.dll") Then
            If enVars.assemblies("settings.layout.widget.dll").ContainsKey("lateralSettingsForm") Then
                enVars.assemblies("settings.layout.widget.dll").Item("lateralSettingsForm").control = panelMenuOptionsContainer
            Else
                errMsg &= "lateralSettingsForm"
                err = True
            End If
        Else
            errMsg &= "settings.layout.widget.dll"
            err = True
        End If

        If err Then
            Microsoft.VisualBasic.MsgBox("Error: assembly cound not be assigned a panel, " & errMsg)
            Me.Close()
            Exit Sub
        End If
    End Sub
#End Region

#Region "Layout settings"
    Private Const LATERAL_MENU_OPEN_WIDTH As Integer = 400

    'AssembliesToLoadAtStart = {({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"})}
    Public ReadOnly AssembliesToLoadAtStartOLD = {({"", "", "", ""}), ({"", "", "", ""}), ({"", "", "", ""}), ({"", "", "", ""})}



#End Region

#End Region

#Region "constant, variables and fields"

#Region "constants"
    Const ENABLE_TESTING_ENVIRONMENT As Boolean = True
#End Region

#Region "PUBLIC FIELDS"
    Public updateMainApp As environmentVarsCore.updateMainLayoutDelegate
    Public Property enVars As New environmentVarsCore
    Public Property statusMessage As String = ""
#End Region

#Region "PRIVATE FIELDS"
    'Flag to check if there are loading errors
    Private ErrorLoading As Boolean = False
    'panel registered for layout color and background changes
    Private registeredPanels As New List(Of String)
    Private msgbox As messageBoxForm

    'menu builder
    Private WithEvents menuBuilder As MenuBuilderClass

    'STATUS MESSAGE 
    Private statusMessageLast As String = ""
    Private statusMessageTimeout As Integer = 10
    Private statusMessagePile As New List(Of String)
    Private WithEvents StatusMessagesDisplayTime As Timer
    Private WithEvents UpdateStatusMessageTimer As Timer

    'TOOLTIPS
    Private settingsToolTip As New ToolTip()
    Private menuToggleToolTip As New ToolTip()

    'CHANGE BACKGROUND IMAGE
    Private WithEvents ChangeBackgroundTimer As Timer
    Private WithEvents bwChangeBackground As New BackgroundWorker

#End Region


    Public CurrentWrapperForm As Form
    Public LoadedFrm As Form
    Public loaded As Boolean = False

    Private BusyMenuOption As Boolean = False

    Public Property usernamePhoto As PictureBox = Nothing


    Private eDelta As Integer
    Private Sensitivity As Integer = 20
#End Region

#Region "constructors"


    Public Sub New(Optional _envars As environmentVarsCore = Nothing)
        Application.AddMessageFilter(Me)
        ErrorLoading = False

        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()

        If _envars IsNot Nothing Then
            enVars = _envars
        End If
        enVars.layoutDesign.menu.properties.ClosedStateSize = LATERAL_MENU_OPEN_WIDTH

        'ASSIGN ASSEMBLIES TO PANELS
        assignControlToAssembly()

        'çheck if external files exist
        enVars = loadExternalFilesInUse(enVars)
        If enVars Is Nothing Then
            ErrorLoading = True
            Application.Exit()
            Exit Sub
        End If
        'Instantiating the delegate for update data from child forms
        updateMainApp = AddressOf updateMainAppLayout

        'Me.InactivityTimeOut = enVars.AutomaticLogoutTime

        Me.Visible = False
        Me.Opacity = 0
        Me.Refresh()
        registerConfigurableLayoutControls()
        addToolTips()

        If ENABLE_TESTING_ENVIRONMENT Then
            enVars = loadTestingEnvironmentVars(enVars)
        End If

        Me.ResumeLayout()

        '' needs to be the last 
        If Not Me.IsDisposed And Not ErrorLoading Then
            Me.Show()
        End If
    End Sub
#End Region

#Region "TOOLTIPS"
    Private Sub addToolTips()
        'ADD TOOLTIPS 
        Dim menuToggleToolTip As New ToolTip()
        menuToggleToolTip.SetToolTip(menuToggleIcon, My.Resources.strings.MenuToggle)

        Dim settingsToolTip As New ToolTip()
        settingsToolTip.SetToolTip(iconMenuSettings, My.Resources.strings.settingsToggle)
    End Sub
#End Region

#Region "update environment and layout"
    Public Sub updateMainAppLayout(sender As Object, ByRef updateContents As updateMainAppClass)
        enVars = updateContents.envars

        If updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT) Then
            SuspendLayout()
            updateBkColorAndTransparency(Me, False, False)
            ResumeLayout()
            Refresh()
        ElseIf updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT_BACKGROUND) Then
            SuspendLayout()
            Me.BackgroundImage = Image.FromFile(updateContents.backGroundFileName)
            Me.BackgroundImageLayout = ImageLayout.Stretch

            updateBkImageOnChildForms(Me, False, Nothing)
            ResumeLayout()
            Refresh()
        ElseIf updateContents.updateTask.Equals(updateMainAppClass.UPDATE_ENVIRONMENT_VARS) Then
            'REDUNDANT ...
        End If
    End Sub

    Private Sub updateBkColorAndTransparency(ByVal ctrlContainer As Control, isOnChildren As Boolean, isOnForm As Boolean)
        For Each ctrl As Control In ctrlContainer.Controls
            Dim t = ctrl.Name
            Dim typ = ctrl.GetType

            If TypeOf ctrl Is PanelDoubleBuffer And Not isOnChildren Then
                If registeredPanels.Contains(ctrl.Name.ToString) Then
                    ctrl.BackColor = Color.FromArgb(enVars.layoutDesign.PanelTransparencyIndex, enVars.layoutDesign.PanelBackColor)
                    If ctrl.HasChildren Then
                        updateBkColorAndTransparency(ctrl, True, False)
                    End If
                End If
            ElseIf (TypeOf ctrl Is FormCustomized Or TypeOf ctrl Is Form) And isOnChildren Then
                updateBkColorAndTransparency(ctrl, True, True)
            ElseIf TypeOf ctrl Is PanelDoubleBuffer And isOnChildren And isOnForm Then
                ctrl.BackColor = Color.FromArgb(enVars.layoutDesign.PanelTransparencyIndex, enVars.layoutDesign.PanelBackColor)
            ElseIf TypeOf ctrl Is PanelDoubleBuffer And isOnChildren And ctrl.HasChildren Then
                updateBkColorAndTransparency(ctrl, True, False)
            End If
        Next
    End Sub

    Private Sub updateBkImageOnChildForms(ByVal ctrlContainer As Control, isOnChildren As Boolean, panelHost As PanelDoubleBuffer)
        For Each ctrl As Control In ctrlContainer.Controls
            Dim t = ctrl.Name
            Dim typ = ctrl.GetType

            If TypeOf ctrl Is PanelDoubleBuffer Then
                If ctrl.HasChildren Then
                    updateBkImageOnChildForms(ctrl, True, ctrl)
                End If
            ElseIf (TypeOf ctrl Is FormCustomized Or TypeOf ctrl Is Form) And isOnChildren Then
                ctrl.BackgroundImage = cropImage(Me.BackgroundImage, panelHost.Location, panelHost.Size, Me.Size)
                ctrl.BackgroundImageLayout = ImageLayout.Stretch
            End If
        Next
    End Sub
#End Region

#Region "form events"
    Private Sub MyForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If ErrorLoading Then
            Application.Exit()
            Exit Sub
        End If

        SuspendLayout()

        loaded = False

        With panelLeftSide
            .Parent = Me
            .Width = enVars.layoutDesign.menu.properties.ClosedStateSize
            .BackColor = Color.Transparent
            .AutoScroll = True
        End With

        'TOP OPTIONS ON SIDE PANEL
        With panelMenuOptions
            .Parent = panelLeftSide
            .Dock = DockStyle.Top
            .BringToFront()
        End With

        'lateralPanelMenuOptions.BackColor = Color.FromArgb(50, Color.Red)

        menuToggleIcon.Parent = panelMenuOptions
        menuToggleIcon.BackColor = Color.Transparent
        menuToggleIcon.Width = enVars.layoutDesign.MENU_CLOSED_STATE - 3
        menuToggleIcon.Height = enVars.layoutDesign.MENU_CLOSED_STATE - 3

        iconMenuSettings.Parent = panelMenuOptions
        iconMenuSettings.BackColor = Color.Transparent

        With panelMenuOptionsContainer
            .Parent = panelLeftSide
            .Height = 0
            .Dock = DockStyle.Top
            .BringToFront()
        End With

        menuBuilder = New MenuBuilderClass(Me, panelLeftSide, enVars, MenuBuilderClass.MENU_VERTICAL)
        enVars = menuBuilder.buildMenu()
        panelLeftSide.Controls.Add(enVars.layoutDesign.menu.menuPanelContainer)

        enVars.layoutDesign.menu.menuPanelContainer.BringToFront()
        menuBuilder.MenuUpdate(False)

        'TOP PANEL
        panelTop.Parent = Me

        'BOTTOM PANEL
        panelBottom.Parent = Me

        statusText.Parent = panelBottom
        statusText.BackColor = Color.Transparent
        statusMessage = "status message test"

        updateBkColorAndTransparency(Me, False, False)

        ResumeLayout()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.IsDisposed Then
            Exit Sub
        End If
        If IsNothing(enVars) Then
            Exit Sub
        End If
        If (WindowState.Equals(FormWindowState.Maximized) Or WindowState.Equals(FormWindowState.Normal)) And enVars.successLogin.Equals(False) And loaded Then
            doLogin()
        End If

        If (WindowState = FormWindowState.Minimized) And loaded Then
            SuspendLayout()
            Me.WindowState = FormWindowState.Minimized
            ResumeLayout()
        ElseIf loaded Then
            'FormRedraw.Enabled = True
        End If

        If Not WindowState = FormWindowState.Maximized OrElse Not WindowState = FormWindowState.Minimized Then
            mbDoPaintBackground = True
            SuspendLayout()
            updateBkImageOnChildForms(Me, False, Nothing)
            ResumeLayout()
            Refresh()
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

        msgbox = New messageBoxForm(My.Resources.strings.exitApp & " ?", My.Resources.strings.question, MessageBoxButtons.YesNo, MessageBoxIcon.Question, Me.Location.X + (Me.Width / 2), Me.Location.Y + Me.Height / 2, enVars)
        If msgbox.ShowDialog = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "mouse motion"
    Private Sub menuPanelLateral_mouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        doLPanelLateralScrool(sender, e)
    End Sub


    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        Exit Sub


        eDelta = e.Delta
        Dim ctrlIni As Control = Me.GetChildAtPoint(New Drawing.Point(e.X, e.Y))

        Dim menuPanel As Panel = Nothing
        If TypeOf ctrlIni Is Panel Then
            Dim ctrl As Panel = CType(ctrlIni, Panel)
            If ctrl.Name.Equals("panelLateral") Then
                menuPanel = ctrl
            ElseIf ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf ctrlIni Is LabelDoubleBuffer Then
            Dim ctrl As LabelDoubleBuffer = CType(ctrlIni, LabelDoubleBuffer)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If
        If TypeOf ctrlIni Is PictureBox Then
            Dim ctrl As PictureBox = CType(ctrlIni, PictureBox)
            If ctrl.Parent.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    menuPanel = ctrl.Parent
                End If
            End If
        End If

        If menuPanel Is Nothing Then
            Exit Sub
        End If


        If menuPanel.Name.Equals("panelLateral") Then

            Dim vScrollPosition As Integer = VScroll 'panelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(eDelta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Value) Then
                enVars.layoutDesign.menu.menuPanelContainer.SuspendLayout()
                enVars.layoutDesign.menu.menuPanelContainer.AutoScroll = True
                enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Enabled = True
                enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Value = vScrollPosition
                enVars.layoutDesign.menu.menuPanelContainer.AutoScrollPosition = New Point(enVars.layoutDesign.menu.menuPanelContainer.AutoScrollPosition.X,
                         vScrollPosition)
                enVars.layoutDesign.menu.menuPanelContainer.AutoScroll = False
                enVars.layoutDesign.menu.menuPanelContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Value
        End If

    End Sub
    Private Sub doLPanelLateralScrool(sender As Object, e As System.Windows.Forms.MouseEventArgs)

        If enVars.layoutDesign.menu.menuPanelContainer.Bounds.Contains(e.Location) Then
            Dim vScrollPosition As Integer = VScroll 'panelLateral.VerticalScroll.Value
            vScrollPosition -= Math.Sign(e.Delta) * Sensitivity
            vScrollPosition = Math.Max(0, vScrollPosition)
            vScrollPosition = Math.Min(vScrollPosition, enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Maximum)
            If Not vScrollPosition.Equals(enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Value) Then
                enVars.layoutDesign.menu.menuPanelContainer.SuspendLayout()
                enVars.layoutDesign.menu.menuPanelContainer.AutoScroll = True

                enVars.layoutDesign.menu.menuPanelContainer.AutoScrollPosition = New Point(enVars.layoutDesign.menu.menuPanelContainer.AutoScrollPosition.X,
                                  vScrollPosition)
                enVars.layoutDesign.menu.menuPanelContainer.AutoScroll = False
                enVars.layoutDesign.menu.menuPanelContainer.ResumeLayout()
                VScroll = vScrollPosition
            End If
            statusMessage = "VSCROOL: " & vScrollPosition & "      Previous:" & enVars.layoutDesign.menu.menuPanelContainer.VerticalScroll.Value
        End If
    End Sub
#End Region

#Region "App main menu"
    Private Sub menuPanel_Click(sender As Object, menuPos As Integer) Handles menuBuilder.menuPanelClick
        If enVars.layoutDesign.menu.items.ElementAt(menuPos).showAsDialog Then
            enVars.layoutDesign.menu.items.ElementAt(menuPos).formWithContentsToLoad.ShowDialog()
        Else
            openChildForm(panelMain, enVars.layoutDesign.menu.items.ElementAt(menuPos).formWithContentsToLoad)
        End If
    End Sub

    Private Sub menuPanelNotifications_click(sender As Object, e As EventArgs) Handles menuBuilder.menuNotificationClick

    End Sub

    Public Sub doMenuAnimmation(origin As String)
        If (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
            menuBuilder.MenuItemStateReset(False)
            menuBuilder.MenuUpdate(False)
        ElseIf origin.Equals("main") Then
            menuBuilder.MenuUpdate(True)
        End If
    End Sub

#End Region

#Region "Status Message"
    Private Sub UpdateStatusMessageTimer_Tick(sender As Object, e As EventArgs) Handles UpdateStatusMessageTimer.Tick
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
#End Region

#Region "side panel selction clicks"
    Private Sub menuStateUpdateLayout(sender As Object, menuState As Boolean) Handles menuBuilder.menuStateUpdateLayout
        For Each ctrl As Control In panelMenuOptions.Controls
            ctrl.Visible = False
        Next
        panelMenuOptions.Refresh()
        If menuState.Equals(True) Then
            panelLeftSide.Width = enVars.layoutDesign.MENU_OPEN_STATE
            menuToggleIcon.Location = New Point(panelLeftSide.Width - menuToggleIcon.Width - 3 - 10, menuToggleIcon.Location.Y)
        Else
            panelLeftSide.Width = enVars.layoutDesign.MENU_CLOSED_STATE
            menuToggleIcon.Location = New Point(5, menuToggleIcon.Location.Y)
        End If
        For Each ctrl As Control In panelMenuOptions.Controls
            ctrl.Visible = True
        Next
        panelMenuOptions.Refresh()
    End Sub

    Private Sub panelLateral_Click(sender As Object, e As EventArgs)
        If (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) Then '' is open 
            menuBuilder.MenuUpdate(False)
        Else
            menuBuilder.MenuUpdate(True)
        End If
    End Sub

    Private Sub menuIconPic_Click_1(sender As Object, e As EventArgs) Handles menuToggleIcon.Click
        If menuToggleIcon.Location.X.Equals(5) Then
            menuBuilder.MenuUpdate(True)
        Else
            menuBuilder.MenuUpdate(False)
        End If
    End Sub

#Region "Icon quick settings side panel"
    Private optionsIsOnpen As Boolean = False
    Private Sub iconMenuSettings_Click_1(sender As Object, e As EventArgs) Handles iconMenuSettings.Click
        If optionsIsOnpen Then
            optionsIsOnpen = False
            If Not IsNothing(currentForm) Then
                currentForm.Close()
            End If
            panelMenuOptionsContainer.Height = 0
        Else
            optionsIsOnpen = True

            Dim formToLoad As FormCustomized = loadFormFromAssembly("settings.layout.widget.dll", "lateralSettingsForm", enVars, updateMainApp)

            panelMenuOptionsContainer.Height = formToLoad.Height
            openChildForm(panelMenuOptionsContainer, formToLoad)
        End If
    End Sub
#End Region

#End Region



    Private Sub panelLateralWrapper_Resize(sender As Object, e As System.EventArgs) Handles panelLeftSide.Resize
        'enVars.layoutDesign.menu.menuPanelContainer.Width = panelLeftSide.Width + enVars.layoutDesign.PANEL_SCROOL_UNDERLAY
        'enVars.layoutDesign.menu.menuPanelContainer.Height = panelLeftSide.Height - enVars.layoutDesign.menu.menuPanelContainer.Location.Y
    End Sub

    Private Sub resizeMenuElementsByOrder(previous As Control, current As Control)
        If previous Is Nothing Then
            current.Location = New Point(0, 0)
        Else
            current.Location = New Point(0, previous.Location.Y + previous.Height)
        End If
        current.Width = panelLeftSide.Width
        current.Dock = DockStyle.None
    End Sub


    Private currentForm As Form = Nothing
    Private Sub openChildForm(targetPanel As PanelDoubleBuffer, childForm As Form)
        SuspendLayout()
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        childForm.Parent = targetPanel
        childForm.Width = targetPanel.Width
        targetPanel.Height = childForm.Height
        targetPanel.Controls.Add(childForm)
        targetPanel.Tag = childForm
        childForm.BringToFront()
        childForm.BackgroundImage = cropImage(Me.BackgroundImage, targetPanel.Location, targetPanel.Size, Me.Size)
        childForm.BackgroundImageLayout = ImageLayout.Stretch
        childForm.Show()
        ResumeLayout()
    End Sub


    Private Sub doLogin()
        If Not loaded Then
            Exit Sub
        End If
        'TODO clear session vars
        enVars.successLogin = False
        If (WindowState.Equals(FormWindowState.Minimized)) Then
            Exit Sub
        End If

        ''If Application.OpenForms().OfType(Of SplashScreen).Any Then
        ''Exit Sub
        ''End If

        ''Me.Hide()
        '' If splashScreenLogin.ShowDialog() = DialogResult.OK Then
        ''Me.Show()
        ''Else
        ''Application.Exit()
        ''Close()
        ''End If
    End Sub

    Public Sub NoNetwork()
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        Dim mask As PictureBox = New PictureBox
        mask.Dock = DockStyle.Fill
        mask.Top = TopMost
        mask.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("noNetwork.png"))
        mask.SizeMode = PictureBoxSizeMode.CenterImage
        mask.Parent = panelMain
        panelMain.Controls.Clear()
        panelMain.Controls.Add(mask)
        mask.BringToFront()
        panelMain.Refresh()
    End Sub

    Public Sub UnloadForms()
        If Not IsNothing(CurrentWrapperForm) Then
            CurrentWrapperForm.Close()
            CurrentWrapperForm.Dispose()
        End If

        panelMain.Refresh()
        Exit Sub

        If Me.panelMain.Controls.Count > 0 Then
            Dim ctrl As Control = Nothing
            For i As Integer = Me.panelMain.Controls.Count - 1 To 0 Step -1
                ctrl = Me.panelMain.Controls(i)
                Try
                    'MISSING - BUGS HERE EVEN INSIDE THE TRY BLOCK
                    Me.panelMain.Controls.Remove(ctrl)
                Catch ex As Exception
                    statusMessage = "Error unloading form"
                End Try
            Next
            ctrl.Dispose()
        End If
    End Sub


    ''Private Sub sidebarWrapper_Paint(sender As Object, e As TableLayoutCellPaintEventArgs) 'Handles sidebarWrapperContents.Paint
    ''Dim TheControl As Control = CType(sender, Control)
    ''Dim oRAngle As Rectangle = New Rectangle(0, 0, TheControl.Width, TheControl.Height)
    ''Dim oGradientBrush As Brush = New System.Drawing.Drawing2D.LinearGradientBrush(
    ''                                oRAngle, enVars.colorMainMenu,
    ''                              enVars.colorMainMenu,
    ''                            System.Drawing.Drawing2D _
    ''.LinearGradientMode.ForwardDiagonal)
    ''  e.Graphics.FillRectangle(oGradientBrush, oRAngle)
    ''End Sub

    Private Sub wrapper_got_focus(sender As Object, e As EventArgs)
        enVars.layoutDesign.menu.menuPanelContainer.Width = 36
    End Sub

    Private Sub wrapper_Resize(sender As Object, e As System.EventArgs)
        If CurrentWrapperForm IsNot Nothing Then
            CurrentWrapperForm.Size = panelMain.Size
            CurrentWrapperForm.Refresh()
        End If
    End Sub

    Private Sub ChangeBackgroundTimer_Tick(sender As Object, e As EventArgs) Handles ChangeBackgroundTimer.Tick
        bwChangeBackground.RunWorkerAsync()
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
                                         ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                         Handles bwChangeBackground.DoWork

        'load background files from path or web ?


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                     Handles bwChangeBackground.RunWorkerCompleted

        ''Me.BackgroundImage= 

    End Sub

    Private Sub statusText_Click(sender As Object, e As EventArgs) Handles statusText.Click

    End Sub

    Private Sub panelTop_Paint(sender As Object, e As PaintEventArgs) Handles panelTop.Paint

    End Sub
End Class