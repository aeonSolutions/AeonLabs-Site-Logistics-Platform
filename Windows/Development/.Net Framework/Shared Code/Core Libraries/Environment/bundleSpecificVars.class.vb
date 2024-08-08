Imports System.Windows.Forms

Public Class bundleSpecificVarsClass
    Public Property menu As New Dictionary(Of String, List(Of _menuStruct))

    Private menuItem As New List(Of _menuStruct)

    Structure _menuStruct
        Dim TagTitle As String       ' menu title string for translations
        Dim contentToLoad As String  ' name of the form to load
        Dim submenu As Boolean       ' true for submenu item, false for menu item
        Dim notifications As Integer ' number of notification pending on menu item
        Dim icon As String
        Dim showDialog As Boolean
        Dim subMenuPanel As Panel
    End Structure

    Public Sub addMenuItem(_tagTitle As String, _contentToLoad As String, _showDialog As Boolean, _icon As String, _submenu As Boolean, Optional _notifications As Integer = 0)
        Dim menuItemOption As New _menuStruct

        With menuItemOption
            .TagTitle = _tagTitle
            .contentToLoad = _contentToLoad
            .submenu = _submenu
            .icon = _icon
            .notifications = _notifications
            .showDialog = _showDialog
        End With
        menuItem.Add(menuItemOption)
    End Sub

    Public Sub addMenu(tagTitle As String)
        menu.Add(tagTitle, menuItem)
        menuItem = New List(Of _menuStruct)
    End Sub
End Class
