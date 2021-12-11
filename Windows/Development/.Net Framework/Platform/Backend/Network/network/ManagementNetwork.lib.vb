Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Security.Authentication
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Module ManagementNetwork
    Public Function IsFtpOnline(enableSSL As Boolean, url As String, user As String, pass As String) As Boolean

        Dim request As FtpWebRequest = WebRequest.Create(New Uri(url))
        request.Credentials = New NetworkCredential(user, pass)
        request.Method = WebRequestMethods.Ftp.ListDirectory
        request.EnableSsl = enableSSL
        Try
            Dim response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
            ' Folder exists here
            Return True
        Catch ex As WebException
            Dim response As FtpWebResponse = DirectCast(ex.Response, FtpWebResponse)
            'Does not exist
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                Return False
            End If
            Return False
        End Try
    End Function

    Public Function IsOnline(url As String) As Boolean
        Try
            Dim objUrl As New System.Uri(url)
            If My.Computer.Network.Ping(objUrl) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function IsResponseOk(response As String, Optional jsonVar As String = "error") As Boolean
        If response.Equals("") Then
            Return False
        End If

        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Return Not jsonResult.Item(jsonVar)
        Catch ex As Exception
            Return False
        End Try

        ' (jsonResult.Item("error").Item(0).Equals("true")) 

    End Function

    Public Function GetMessage(response As String) As String
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Return jsonResult.Item("message")
        Catch ex As Exception
            Return response
        End Try

    End Function
    Public Function GetMessageField(response As String, field As String) As String
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            Return jsonResult.Item(field)
        Catch ex As Exception
            Return "false"
        End Try
    End Function

    Private Function encodeURL(url As String) As String
        Dim idx As Integer = 0
        Dim idx2 As Integer = 0
        Dim arr_s, arr_e As Integer()
        Dim pos As Integer = 0

        Return url

        ReDim arr_s(20)
        ReDim arr_e(20)

        While Not url.IndexOf("=", idx).Equals(-1)
            idx2 = url.IndexOf("=", idx) + 1
            idx = url.IndexOf("&", idx2)
            If idx.Equals(-1) Then
                idx = url.Length
            End If
            If idx - idx2 > 0 Then
                arr_e(pos) = idx - idx2
                arr_s(pos) = idx2
                pos = pos + 1
            End If
        End While

        For i = 0 To pos - 1
            Dim substr As String = url.Substring(arr_s(i), arr_e(i))
            Dim repstr As String = System.Uri.EscapeDataString(substr)
            url = url.Replace(substr, repstr)
        Next i
        Return url
    End Function

End Module
