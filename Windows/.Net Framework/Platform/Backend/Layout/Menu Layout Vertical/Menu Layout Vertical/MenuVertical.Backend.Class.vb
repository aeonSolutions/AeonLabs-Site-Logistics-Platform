Imports System.IO
Imports System.Net
Imports AeonLabs.Environment
Imports AeonLabs.Environment.menuEnvironmentVarsClass
Imports FontAwesome.Sharp

Public Class MenuBuilderClass
    Public Const MENU_HORIZONTAL As Integer = 100
    Public Const MENU_VERTICAL As Integer = 200

    Public Property position As New menuPosition
    Public Class menuPosition
        Public Property x As Integer = 0
        Public Property y As Integer = 0
    End Class

    Public Event updateStausMessage(sender As Object, message As String)
    Public Event menuPanelClick(sender As Object, menuPos As Integer)
    Public Event menuPanelMouseOverEvent(sender As Object, menuPos As Integer)
    Public Event menuExpandPanelClick(sender As Object, e As EventArgs)
    Public Event menuNotificationClick(sender As Object, e As EventArgs)
    Public Event menuStateUpdateLayout(sender As Object, menuState As Boolean)

    Public Property setup As New menuSetup
    Public Class menuSetup
        Public MenuContainer As New PanelDoubleBuffer
        Public menuPanel As PanelDoubleBuffer
        Public menuTotalHeight As Integer = 0
    End Class

    Private sizeOfString As New SizeF
    Private menuOrientation As Integer
    Private enVars As environmentVarsCore
    Private mainForm As Form
    Private menuPanel As PanelDoubleBuffer

    Private previousPanelName As String = Nothing
    Private previousPanelmouseOver As Control = Nothing
    Private previousControlmouseOver As Control = Nothing
    Private previousPanelToToggle As Control = Nothing
    Private previousPanelTimer As New Timer()
    Dim entry = ""

#Region "CONSTRUCTORS"
    Public Sub New(_mainform As Form, _menuPanel As PanelDoubleBuffer, _envars As environmentVarsCore, _menuOrientation As Integer)
        mainForm = _mainform
        enVars = _envars
        menuOrientation = _menuOrientation
        menuPanel = _menuPanel

        If enVars.layoutDesign.fontTitle.Families.Count < 1 Then
            Microsoft.VisualBasic.MsgBox("Font files not loaded properly:" & Me.ToString)
            Exit Sub
        End If

        Dim fontToMeasure As New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular)
        Dim g As Graphics = mainForm.CreateGraphics
        sizeOfString = g.MeasureString("PQWER", fontToMeasure)

        previousPanelTimer.Interval = 300
        AddHandler previousPanelTimer.Tick, AddressOf delayActiveBar
    End Sub
#End Region

#Region "BUILD VERTICAL MENU"
    Public Function buildMenu() As environmentVarsCore
        Dim menuItems As IList(Of menuItemClass) = (From s In enVars.layoutDesign.menu.items
                                                    Where s.subMenuIndex.Equals(0)
                                                    Select s).ToList()
        Dim previousSubMenuItemsCounter As Integer = 0
        Me.setup.menuTotalHeight = 0

        Dim menuItemsCount As Integer = 0
        Dim panelPos As Point

        For i = 0 To menuItems.Count - 1
            If menuOrientation.Equals(MENU_VERTICAL) Then
                panelPos = New Point(position.x, position.y + previousSubMenuItemsCounter * (enVars.layoutDesign.menu.properties.height))
            Else 'MENU IS HORIZONTAL
                panelPos = New Point(position.x + enVars.layoutDesign.menu.properties.width * i, position.y)
            End If
            Me.setup.menuPanel = New PanelDoubleBuffer With {
            .Width = enVars.layoutDesign.menu.properties.width,
            .Location = panelPos,
            .Height = enVars.layoutDesign.menu.properties.height,
            .Name = menuItems(i).menuTitle,
            .Parent = Me.setup.MenuContainer,
            .BackColor = Color.Transparent 'Color.FromArgb(255, CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1)
            }
            enVars.layoutDesign.menu.items(i).menuListIndex = i
            Dim d = i

            'build top menu option
            buildMenu(menuItems(i), 0, i, menuItemsCount)
            menuItemsCount += 1

            Dim subMenuItems As IList(Of menuItemClass) = (From s In enVars.layoutDesign.menu.items
                                                           Where Not s.subMenuIndex.Equals(0) And s.menuIndex.Equals(menuItems(d).menuIndex)
                                                           Select s).ToList()

            Me.setup.menuTotalHeight += (subMenuItems.Count) * enVars.layoutDesign.menu.properties.height

            For j = 1 To subMenuItems.Count
                buildMenu(subMenuItems(j - 1), j, i, menuItemsCount)
                menuItemsCount += 1
            Next j

            previousSubMenuItemsCounter += subMenuItems.Count + 1
            menuItems(i).menuWrapperOpenHeight = enVars.layoutDesign.menu.properties.height * subMenuItems.Count + subMenuItems.Count

            Dim index = enVars.layoutDesign.menu.items.FindIndex(Function(c) c.menuUID.Equals(menuItems(d).menuUID))

            Me.setup.menuPanel.Height = (subMenuItems.Count + 1) * enVars.layoutDesign.menu.properties.height
            enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperOpenHeight = (subMenuItems.Count + 1) * enVars.layoutDesign.menu.properties.height
            enVars.layoutDesign.menu.items(index).menuWrapperPanel = Me.setup.menuPanel
            Me.setup.MenuContainer.Controls.Add(Me.setup.menuPanel)
        Next i

        With Me.setup.MenuContainer
            .Parent = menuPanel
            'hack to hide the scrool bars
            .Width = menuPanel.Width + enVars.layoutDesign.PANEL_SCROOL_UNDERLAY
            .Location = New Point(0, 0)
            .BackColor = Color.Transparent
            .Dock = DockStyle.Top
            .AutoSize = True
            .AutoScroll = False
        End With
        enVars.layoutDesign.menu.menuPanelContainer = Me.setup.MenuContainer
        Return enVars
    End Function
#End Region

#Region "BUILD MENU ITEMS"
    Private Sub buildMenu(menuItem As menuItemClass, placeIndex As Integer, firstmenuItemListIndex As Integer, menuItemsCount As Integer)
        Dim titlePosY As Integer = 0
        Dim menuPosX As Integer = enVars.layoutDesign.menu.properties.ClosedStateSize
        Dim iconSize As Integer = enVars.layoutDesign.menu.properties.ClosedStateSize * 0.7
        Dim subMenuExpandIcon As New IconPictureBox
        Dim subMenuIcon As New PictureBox
        menuItem.iconPicHolder = New List(Of PictureBox)
        Dim activeBar As PanelDoubleBuffer

        Dim index = enVars.layoutDesign.menu.items.FindIndex(Function(c) c.menuUID.Equals(menuItem.menuUID))

        Dim subMenuPanel As New PanelDoubleBuffer With {
            .Width = enVars.layoutDesign.menu.properties.width,
            .Height = enVars.layoutDesign.menu.properties.height,
            .BackColor = enVars.layoutDesign.menu.properties.backColor,
            .Parent = Me.setup.menuPanel,
            .Name = menuItem.menuUID & "-" & index,
            .Location = New Point(0, enVars.layoutDesign.menu.properties.height * placeIndex)
          }

        AddHandler subMenuPanel.Click, AddressOf menuPanel_Click

        If placeIndex.Equals(0) Then
            subMenuIcon = New PictureBox With {
                .Width = iconSize,
                .Height = iconSize,
                .Location = New Point((enVars.layoutDesign.menu.properties.height - iconSize) / 2, (enVars.layoutDesign.menu.properties.height - iconSize) / 2),
                .Parent = subMenuPanel,
                .Cursor = Cursors.Hand
            }

            If menuItem.menuTitle.Equals("username") Then
                If (enVars.userPhoto.Equals("")) Then
                    subMenuIcon.Image = Image.FromFile(enVars.imagesPath & "worker.icon.png")
                Else
                    subMenuIcon.InitialImage = Image.FromFile(enVars.imagesPath & Convert.ToString("loading.png"))
                    subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage

                    Dim tClient As WebClient = New WebClient
                    Try
                        'TODO where to save the files 
                        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(enVars.ServerBaseAddr & "/csl/photos/" & enVars.userPhoto)))
                        subMenuIcon.Image = tImage
                    Catch ex As Exception
                        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

                        subMenuIcon.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("worker.icon.png"))
                        RaiseEvent updateStausMessage(Me, My.Resources.strings.errorDownloadingPhoto)
                    End Try
                End If

            ElseIf Not menuItem.icon.Equals("") Then
                Dim checkFile = New FileInfo(enVars.imagesPath & menuItem.icon)
                checkFile.Refresh()
                If checkFile.Exists Then
                    With subMenuIcon
                        .Image = Image.FromFile(enVars.imagesPath & menuItem.icon)
                    End With
                End If
            End If
            With subMenuIcon
                .SizeMode = PictureBoxSizeMode.StretchImage
            End With

            AddHandler subMenuIcon.Click, AddressOf menuPanel_Click

            subMenuPanel.Controls.Add(subMenuIcon)

            subMenuExpandIcon = New IconPictureBox With {
            .IconColor = enVars.layoutDesign.labelForeColor,
            .BackColor = System.Drawing.Color.Transparent,
            .Cursor = System.Windows.Forms.Cursors.Hand,
            .IconChar = FontAwesome.Sharp.IconChar.AngleDown,
            .IconSize = iconSize,
            .Location = New Point(enVars.layoutDesign.menu.properties.width - enVars.layoutDesign.menu.properties.height, enVars.layoutDesign.menu.properties.height / 2 - iconSize / 2),
            .Name = menuItem.menuUID & "_expandIcon-" & index,
            .Size = New System.Drawing.Size(enVars.layoutDesign.menu.properties.height - 6, enVars.layoutDesign.menu.properties.height - 6),
            .Parent = subMenuPanel
            }

            'TODO add tooltips
            AddHandler subMenuExpandIcon.Click, AddressOf menuExpandPanel_Click

            subMenuPanel.Controls.Add(subMenuExpandIcon)
        End If

        'MENU ITEM ACTIVE BAR  =====================================================================================================================
        'TODO: ????
        If placeIndex.Equals(0) Then
            menuPosX = enVars.layoutDesign.menu.properties.height
        Else
            menuPosX = enVars.layoutDesign.menu.properties.activeBarWidth + 5
        End If

        If placeIndex > 0 Then
            activeBar = New PanelDoubleBuffer With {
               .Width = enVars.layoutDesign.menu.properties.activeBarWidth,
               .Height = subMenuPanel.Height - 1,
               .BackColor = Color.Transparent,
               .Location = New Point(0, 0),
               .Parent = subMenuPanel,
               .Name = menuItem.menuUID & "_activeBar-" & index
           }
            subMenuPanel.Controls.Add(activeBar)
        Else
            activeBar = Nothing
        End If

        'MENU ITEM NOTIFICATION  =====================================================================================================================
        Dim notif As New LabelDoubleBuffer With {
                    .Location = New Point(subMenuPanel.Width - enVars.layoutDesign.menu.properties.ClosedStateSize, 5),
                    .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                    .Text = "",
                    .Parent = subMenuPanel,
                    .ForeColor = Color.Orange,
                    .BackColor = Color.Transparent,
                    .Cursor = Cursors.Hand,
                    .Name = menuItem.menuUID & "_notificationIcon-" & index
                }
        If menuItem.notifications > 0 Then
            If menuItem.notifications < 10 Then
                notif.Text = "0" & menuItem.notifications.ToString
            Else
                notif.Text = menuItem.notifications.ToString
            End If
        End If
        AddHandler notif.Click, AddressOf menuNotification_Click

        subMenuPanel.Controls.Add(notif)

        'MENU ITEM TITLE TEXT =====================================================================================================================
        If menuItem.menuTitle.Equals("username") Then
            Dim subtitle As New LabelDoubleBuffer With {
                    .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                    .Location = New Point(menuPosX, 26),
                    .Text = enVars.customization.businessname,
                    .Parent = Me.setup.menuPanel,
                    .ForeColor = Color.White,
                    .BackColor = Color.Transparent,
                    .Width = enVars.layoutDesign.menu.properties.width,
                    .Cursor = Cursors.Hand
                }

            AddHandler subtitle.Click, AddressOf menuPanel_Click

            Me.setup.menuPanel.Controls.Add(subtitle)
            titlePosY = 5
        ElseIf placeIndex.Equals(0) Then
            titlePosY = (Me.setup.menuPanel.Height - sizeOfString.Height) / 2
        Else
            titlePosY = (Me.setup.menuPanel.Height - sizeOfString.Height) / 2
        End If

        Dim title As New LabelDoubleBuffer With {
                .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.menuTitleFontSize, Drawing.FontStyle.Regular),
                .Location = New Point(menuPosX, titlePosY),
                .Text = If(menuItem.menuTitle.Equals("username"), If(enVars.username.Equals(""), "user", enVars.username), menuItem.menuTitle),
                .Parent = Me.setup.menuPanel,
                .ForeColor = Color.White,
                .BackColor = Color.Transparent,
                .Width = enVars.layoutDesign.menu.properties.width,
                .Cursor = Cursors.Hand,
                .Name = menuItem.menuUID & "_title-" & index
            }

        AddHandler title.Click, AddressOf menuPanel_Click
        subMenuPanel.Controls.Add(title)

        Me.setup.menuPanel.Controls.Add(subMenuPanel)

        enVars.layoutDesign.menu.items(index).menuListIndex = firstmenuItemListIndex
        enVars.layoutDesign.menu.items(index).menuItemPanel = subMenuPanel
        enVars.layoutDesign.menu.items(index).menuActiveBarPanel = activeBar
        enVars.layoutDesign.menu.items(index).iconPicHolder = New List(Of PictureBox)
        enVars.layoutDesign.menu.items(index).iconPicHolder.Add(subMenuIcon)
        enVars.layoutDesign.menu.items(index).iconPicHolderFontAwesome(1) = subMenuExpandIcon
    End Sub
#End Region

#Region "MENU EVENTS"
    Private Sub menuPanelToggleActiveBar(sender As Object, e As EventArgs)
        Dim menukey As String = ""
        Dim subMenuPos As Integer = 0
        Dim ctrl As Control = CType(sender, Control)
        Dim clickedMenuPanel As New Control

        If TypeOf sender Is Panel Then
            If Not ctrl.Name.Equals(menuPanel.Name) Then
                clickedMenuPanel = ctrl
            ElseIf ctrl.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    clickedMenuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf sender Is LabelDoubleBuffer Then
            clickedMenuPanel = ctrl.Parent
        End If

        If TypeOf sender Is PictureBox Then 'menu icon
            clickedMenuPanel = ctrl.Parent
        End If

        If clickedMenuPanel.Name.IndexOf("-") > 0 Then
            If clickedMenuPanel.Name.IndexOf("_") > 0 Then
                menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("_"))
            Else
                menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"))
            End If
            subMenuPos = CInt(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1))

            clickedMenuPanel.SuspendLayout()

            If previousPanelmouseOver IsNot Nothing Then
                previousPanelToToggle = previousPanelmouseOver

                If Not previousPanelmouseOver.Parent.Equals(clickedMenuPanel) Then 'if menu items are diferent 
                    clickedMenuPanel.Controls.Item(menukey & "_title-" & subMenuPos).Text = Rnd.ToString
                    entry = "1"
                    previousPanelmouseOver.BackColor = Color.Transparent
                    clickedMenuPanel.Controls.Item(menukey & "_activeBar-" & subMenuPos).BackColor = enVars.layoutDesign.menu.properties.activeBarColor
                ElseIf previousPanelmouseOver.Equals(clickedMenuPanel) Then
                    previousPanelTimer.Start()
                    entry = "2"

                ElseIf previousControlmouseOver.Equals(ctrl) Then 'exiting the previous= current control
                    previousPanelTimer.Start()
                    entry = "3"

                ElseIf Not previousControlmouseOver.Equals(ctrl) Then 'entering control inside same panel
                    ' If entry.Equals("3") Then
                    '     previousPanelTimer.Start()
                    'Else
                    clickedMenuPanel.Controls.Item(menukey & "_activeBar-" & subMenuPos).BackColor = enVars.layoutDesign.menu.properties.activeBarColor
                    previousPanelTimer.Stop()
                    entry = "4"
                    'End If

                ElseIf previousPanelmouseOver.Parent.Equals(clickedMenuPanel) Then 'exiting the menu item panel
                    entry = "5"

                    previousPanelmouseOver = Nothing
                    previousPanelTimer.Start()
                End If
            Else
                entry = "6"

                previousPanelTimer.Stop()
                clickedMenuPanel.Controls.Item(menukey & "_activeBar-" & subMenuPos).BackColor = enVars.layoutDesign.menu.properties.activeBarColor
            End If

            clickedMenuPanel.ResumeLayout()

            mainForm.Controls.Item("panelMain").Controls.Item("Label1").Text &= ctrl.Name & "(" & entry & ")" & " >> "


            previousPanelmouseOver = clickedMenuPanel.Controls.Item(menukey & "_activeBar-" & subMenuPos)
            previousPanelName = menukey & "_activeBar-" & subMenuPos
            previousControlmouseOver = ctrl
        End If
    End Sub

    Private Sub delayActiveBar()
        previousPanelToToggle.BackColor = Color.Transparent
        previousPanelmouseOver = Nothing
        entry = ""

        mainForm.Controls.Item("panelMain").Controls.Item("Label1").Text = ""
        previousPanelTimer.Stop()
    End Sub

    Private Sub menuPanel_Click(sender As Object, e As EventArgs)
        Dim menukey As String = ""
        Dim subMenuPos As Integer = 0
        Dim ctrl As Control = CType(sender, Control)
        Dim clickedMenuPanel As New Control

        If TypeOf sender Is Panel Then
            If Not ctrl.Name.Equals(menuPanel.Name) Then
                clickedMenuPanel = ctrl
            ElseIf ctrl.Parent IsNot Nothing Then
                If ctrl.Parent.Parent.Name.Equals("panelLateral") Then
                    clickedMenuPanel = ctrl.Parent
                End If
            End If
        End If

        If TypeOf sender Is LabelDoubleBuffer Then
            clickedMenuPanel = ctrl.Parent
        End If

        If TypeOf sender Is PictureBox Then 'menu icon
            clickedMenuPanel = ctrl.Parent

            menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"))
            subMenuPos = CInt(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1))

            If clickedMenuPanel.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE) Then '' its open the lateral bar
                If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen.Equals(False) Then '' menu is closed
                    enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = True
                    MenuUpdate(True)
                Else
                    MenuItemStateReset(False)
                    MenuUpdate(False)
                End If
            Else
                enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = True
                MenuUpdate(True)
            End If
            Exit Sub
        End If

        ''is the submenu wrapper panel ?
        If clickedMenuPanel.Name.IndexOf("-") > -1 Then
            menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"))
            subMenuPos = CInt(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1))
        Else
            menukey = clickedMenuPanel.Name
            subMenuPos = 0
        End If

        ''no content to load and is also menu title
        If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad Is Nothing And enVars.layoutDesign.menu.items.ElementAt(subMenuPos).subMenuIndex.Equals(0) Then
            enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = Not enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen
            ''leave lateral pane open
            MenuUpdate(True)
        End If

        If enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad IsNot Nothing Then
            MenuUpdate(False)
            MenuItemActiveBarReset()
            enVars.layoutDesign.menu.items.ElementAt(subMenuPos).menuActiveBarPanel.BackColor = enVars.layoutDesign.menu.properties.activeBarColor
            RaiseEvent menuPanelClick(sender, subMenuPos)
        End If
    End Sub

    Private Sub menuExpandPanel_Click(sender As Object, e As EventArgs)
        Dim menuPanel As Panel
        Dim ctrl As Control

        ctrl = CType(sender, Control)
        menuPanel = ctrl.Parent

        Dim menuKey As String = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"))
        Dim submenuPos As Integer = CInt(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1))

        If enVars.layoutDesign.menu.items.ElementAt(submenuPos).subMenuIndex.Equals(0) Then
            enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen = Not enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen
            MenuUpdate(True)
            Exit Sub
        End If

        'TODO
        Dim menuState As Boolean = True
        If enVars.layoutDesign.menu.items.ElementAt(0).menuWrapperPanel.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE) Then
            menuState = False
        End If

        RaiseEvent menuExpandPanelClick(sender, e)
    End Sub

    Private Sub menuNotification_Click(sender As Object, e As EventArgs)
        RaiseEvent menuNotificationClick(sender, e)
    End Sub
#End Region

#Region "menu"
    Public Sub MenuUpdate(menuState As Boolean)

        RaiseEvent menuStateUpdateLayout(Me, menuState)

        Dim menuPosY As Integer = 0
        Dim menuItems As IList(Of menuItemClass) = (From s In enVars.layoutDesign.menu.items Where s.subMenuIndex.Equals(0) Select s).ToList()


        For i = 0 To menuItems.Count - 1
            Dim d = i
            Dim index = enVars.layoutDesign.menu.items.FindIndex(Function(c) c.menuUID.Equals(menuItems(d).menuUID))

            ''do opeing / closing of menu
            If enVars.layoutDesign.menu.items.ElementAt(index).isOpen Then
                enVars.layoutDesign.menu.items.ElementAt(index).iconPicHolderFontAwesome(1).IconChar = FontAwesome.Sharp.IconChar.AngleUp
                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height = enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperOpenHeight
            Else
                enVars.layoutDesign.menu.items.ElementAt(index).iconPicHolderFontAwesome(1).IconChar = FontAwesome.Sharp.IconChar.AngleDown
                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height = enVars.layoutDesign.menu.properties.height
            End If
            If menuState.Equals(True) Then
                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Width = enVars.layoutDesign.MENU_OPEN_STATE
            Else
                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Width = enVars.layoutDesign.MENU_CLOSED_STATE
            End If
            enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Location = New Point(enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Location.X, menuPosY)
            menuPosY = menuPosY + enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height
        Next i


    End Sub

    Public Sub MenuItemActiveBarReset()
        For i = 0 To enVars.layoutDesign.menu.items.Count - 1
            enVars.layoutDesign.menu.items.ElementAt(i).menuActiveBarPanel.BackColor = Color.Transparent
        Next i
    End Sub

    Public Sub MenuItemStateReset(menuState As Boolean)
        For i = 0 To enVars.layoutDesign.menu.items.Count - 1
            enVars.layoutDesign.menu.items.ElementAt(i).isOpen = menuState
        Next i
    End Sub
#End Region

End Class
