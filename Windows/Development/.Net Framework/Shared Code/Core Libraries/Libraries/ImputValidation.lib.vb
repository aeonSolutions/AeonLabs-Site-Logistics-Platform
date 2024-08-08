﻿Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Module ImputValidation
    Public Function IsNullOrEmpty(token As JToken) As Boolean
        Return (token.Equals(Nothing)) Or (token.Type.Equals(JTokenType.Array) And Not token.HasValues) Or (token.Type.Equals(JTokenType.Object) And Not token.HasValues) Or (token.Type.Equals(JTokenType.String) And token.ToString().Equals(String.Empty)) Or (token.Type.Equals(JTokenType.Null))
    End Function

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
        If IsNothing(url) Or url.Equals("") Then Return False
        Dim result = Regex.IsMatch(url, "(" & protocol & ")://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,30})$")
        Return result
    End Function

End Module
