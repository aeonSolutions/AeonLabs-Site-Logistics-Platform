Public Class DataRequestsDataResult
    Public Property responseData As String
    Public Property misc As Dictionary(Of String, String)

    Public Sub New(_responseData As String, _misc As Dictionary(Of String, String))
        responseData = _responseData
        misc = _misc
    End Sub

End Class
