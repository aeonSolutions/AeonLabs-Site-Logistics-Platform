Public Class environmentAssembliesClass
    Public Const LAYOUT_PACKAGE As Integer = 1
    Public Const STARTUP_PACKAGE As Integer = 10
    Public Const REGULAR_PACKAGE As Integer = 100
    Public Const WIDGET As Integer = 200

    Public packageType As Integer

    Public deleteOnExit As Boolean

    Public Property spaceName As String

    Public Property friendlyUID As String
    Public Property UID As String
    Public Property AssemblyObject As Type
    Public Property assemblyFileName As String

    Public Property assemblyFormToLoad As FormCustomized
    Public Property assemblyFormName As String

    Public Property minWidth As Integer
    Public Property minHeight As Integer

    Public Property positionX As Integer
    Public Property positionY As Integer
    Public Property control As Control
    Public Property anchor As AnchorStyles
End Class
