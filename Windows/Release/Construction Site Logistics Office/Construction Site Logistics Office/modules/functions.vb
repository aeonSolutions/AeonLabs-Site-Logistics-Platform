Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Module functions
    Public Function IsNullOrEmpty(token As JToken) As Boolean
        Return (token.Equals(Nothing)) Or (token.Type.Equals(JTokenType.Array) And Not token.HasValues) Or (token.Type.Equals(JTokenType.Object) And Not token.HasValues) Or (token.Type.Equals(JTokenType.String) And token.ToString().Equals(String.Empty)) Or (token.Type.Equals(JTokenType.Null))
    End Function

    Function IsWeekday(theDate As Date) As Boolean
        IsWeekday = Weekday(theDate, vbMonday) <= 5
    End Function

    Function InQueryDictionary(ByRef arr As Dictionary(Of String, List(Of String)), ByVal needle As String, ByVal key As String) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.Item(key).Count - 1
            If arr.Item(key)(i).Equals(needle) Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Function isValidTime(ByVal atimestring As String) As String
        Try
            Dim dt As DateTime = DateTime.ParseExact(atimestring, "HH:mm", Nothing)
            Return True
        Catch
            Return False
        End Try
    End Function


    Function InArrayInt(ByVal arr As Array, ByVal needle As Integer) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.Length - 1
            If arr(i) = needle Then
                Return i
                Exit Function
            End If
        Next i
        Return -1
    End Function

    Function InArray(ByRef arr As Array, ByVal needle As String, ByVal pos As Integer) As Integer
        Dim i As Integer
        If arr Is Nothing Then
            Return -2
        End If

        For i = 0 To arr.GetLength(0) - 1
            If arr(i, pos).ToString.Equals(needle) Then
                Return i
                Exit Function
            End If
        Next i
        Return -1
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
