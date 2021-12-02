Public Class updateMainAppClass
    Public Const UPDATE_LAYOUT As Integer = 10001
    Public Const UPDATE_LAYOUT_BACKGROUND As Integer = 10002
    Public Const UPDATE_ENVIRONMENT_VARS As Integer = 10003
    Public Const UPDATE_MAIN As Integer = 10004

    Public Property envars As environmentVarsCore
    Public Property updateTask As Integer = 0
    Public Property backGroundFileName As String = ""
End Class
