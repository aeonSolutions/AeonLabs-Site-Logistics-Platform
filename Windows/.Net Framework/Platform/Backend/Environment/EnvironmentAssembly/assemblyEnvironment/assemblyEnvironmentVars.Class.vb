Imports System.Drawing
Imports System.Windows.Forms

Public Class assemblyEnvironmentVarsClass

    Public Property MenuPanelBackColor As Color
    'duplicate on layout env
    Public Property menu As New menuClass






    Public Class menuClass
        Public Property items As New List(Of menuItemClass) 'menu items
        Public Property menuSort As New List(Of Integer)
        Public Property properties As New menuDesignPropertiesClass
        Class menuDesignPropertiesClass
            Public Property height As Integer
            Public Property width As Integer
            Public Property ClosedStateSize As Integer
            Public Property backColor As Color
            Public Property border As Boolean
        End Class
    End Class

    Public Class menuItemClass
        'settings for loading contents
        Public Property nameSpaceString As String         ' Note that I´m in namespace  "ConsoleApplication1.MyClassA"
        Public Property assemblyFilename As String
        Public Property formWithContentsToLoad As System.Windows.Forms.Form
        Public Property showAsDialog As Boolean

        'settings for executing internal code tasks
        Public Property tasks As New List(Of String)

        'settings for design 
        Public Property menuUID As String
        Public Property menuTitle As String               ' menu title string for translations
        Public Property menuIndex As Integer              '1 is the first on TOP; 0 is disabled
        Public Property subMenuIndex As Integer = -1      '1 is the first on TOP; false means is a menu 
        Public Property menuListIndex As Integer            'index of the TOP menu item within the menuitems list
        Public Property menuDesignProperties As menuClass.menuDesignPropertiesClass

        Public Property notifications As Integer          ' number of notification pending on menu item
        Public Property icon As String

        Public Property menuItemPanel As Panel
        Public Property iconPicHolder As List(Of PictureBox)

        'menu wrapper
        Public Property menuWrapperPanel As Panel
        Public Property isOpen As Boolean
        Public Property menuWrapperOpenHeight As Integer
    End Class

End Class
