Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Class HttpData

    Private url As String
    Private state As New State
    Private translations As languageTranslations
    Public errorMessage As String = ""

    Public Sub New(ByVal Optional _state As State = Nothing, ByVal Optional _url As String = "")
        If Not IsNothing(_state) And _url.Equals("") Then
            url = _state.ServerBaseAddr & _state.ApiServerAddrPath
        ElseIf Not _url.Equals("") Then
            url = _url
        End If
        If Not IsNothing(_state) Then
            state = _state
        End If
        translations = New languageTranslations(state)
        translations.load("errorMessages")
    End Sub

    Public Function RequestData(vars As Dictionary(Of String, String), ByVal Optional origin As String = "office") As String
        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            Return "{'error':true,'message':'" & translations.getText("errorNoNetwork") & "'}"
        End If

        If Not vars.ContainsKey("id") Then
            vars.Add("id", state.userId)
        End If
        If Not vars.ContainsKey("pid") Then
            Dim appId As New Security.FingerPrint
            vars.Add("pid", appId.Value)
        End If
        If Not vars.ContainsKey("language") Then
            vars.Add("language", state.currentLang)
        End If

        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encryption As New AesCipher(state)
        Dim encrypted As String = HttpUtility.UrlEncode(encryption.encrypt(json))
        Dim PostData = "origin=" & origin & "&data=" & encrypted
        Dim request As WebRequest = WebRequest.Create(url)
        Dim responseFromServer As String = ""
        Dim decrypted As String = ""

        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Try
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            responseFromServer = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()

            If response.StatusCode = HttpStatusCode.Accepted Or response.StatusCode = 200 Then
                If IsBase64String(responseFromServer) And Not responseFromServer.Equals("") Then
                    decrypted = encryption.decrypt((responseFromServer)).Replace("\'", "'")
                Else
                    decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " |" & responseFromServer & "|'}"
                End If
            Else
                decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & response.StatusCode & ")'}"
            End If
        Catch ex As Exception
            decrypted = "{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & ex.Message.ToString.Replace("'", "\'") & ")'}"
        End Try

        Return decrypted.Replace("\'", "'")

    End Function

    Public Function RequestExternalData(url As String) As String
        If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            Return "{'error':true,'message':'" & translations.getText("errorNoNetwork") & "'}"
        End If


        Dim webClient As New System.Net.WebClient
        Dim result As Byte()
        Try
            result = webClient.DownloadData((url))
        Catch ex As Exception
            translations.load("errorMessages")

            Return "{'error':true,'message':'" & translations.getText("contactingCommServer") & " (" & ex.Message.ToString & Environment.NewLine & url & ")'}"
        End Try
        Dim utf8Encoding As New System.Text.UTF8Encoding(True)

        Return utf8Encoding.GetString(result)

    End Function





    Private Function IsBase64String(ByVal s As String) As Boolean
        s = s.Trim()
        Return (s.Length Mod 4 = 0) AndAlso Regex.IsMatch(s, "^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None)
    End Function

    Public Function ConvertDataToArray(key As String, fields As String(), response As String) As Dictionary(Of String, List(Of String))
        If GetMessage(response).Equals("1001") Then
            translations.load("errorMessages")
            errorMessage = "{'error':true,'message':'" & translations.getText("errorNoRecordsFound") & "'}"
            Return Nothing
        End If
        Try
            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(response)
            If jsonResult.ContainsKey(key) Then
                If Not jsonResult.Item(key).item(0).Count.Equals(fields.Length) Then
                    translations.load("system")
                    errorMessage = "{'error':true,'message':'" & translations.getText("JsonFieldsMismatch") & ". table(" & key & ")'}"
                    Return Nothing
                Else
                    Dim results = New Dictionary(Of String, List(Of String))
                    For k = 0 To fields.Length - 1
                        Dim fieldValues As List(Of String) = New List(Of String)
                        For i = 0 To jsonResult.Item(key).Count - 1
                            fieldValues.Add(jsonResult.Item(key).item(i).item(k).ToString)
                        Next i
                        results.Add(fields(k), fieldValues)

                    Next k
                    Return results
                End If
            Else
                translations.load("system")
                errorMessage = "{'error':true,'message':'" & translations.getText("JsonkeyNotFound") & " (" & key & ")'}"
                Return Nothing
            End If
        Catch ex As Exception
            errorMessage = "{'error':true,'message':'" & ex.ToString & "'}"
            errorMessage = ex.ToString
            Return Nothing
        End Try
    End Function

End Class
