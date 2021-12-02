Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Module ImputValidation

    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(s)
        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function IsValidUrl(protocol As String, url As String) As Boolean
        If Not protocol.Equals("http") And Not protocol.Equals("https") And Not protocol.Equals("ftp") And Not protocol.Equals("http|https") And Not protocol.Equals("https|http") Then Return False
        If url Is Nothing Then Return False
        If url.Equals("") Then Return False
        Dim result = Regex.IsMatch(url, "(" & protocol & ")://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,30})$")
        Return result
    End Function

End Module
