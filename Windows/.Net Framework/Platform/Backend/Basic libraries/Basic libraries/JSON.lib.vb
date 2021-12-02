Imports System.Web.Script.Serialization
Imports Newtonsoft.Json.Linq

Public Module JSonFunctionsLibrary

    Public Function IsNullOrEmpty(token As JToken) As Boolean
        Return (token.Equals(Nothing)) Or (token.Type.Equals(JTokenType.Array) And Not token.HasValues) Or (token.Type.Equals(JTokenType.Object) And Not token.HasValues) Or (token.Type.Equals(JTokenType.String) And token.ToString().Equals(String.Empty)) Or (token.Type.Equals(JTokenType.Null))
    End Function

    Public Function getTaskTranslations(jsonString As String) As Dictionary(Of String, String)
        If jsonString.Equals("") Then
            Return Nothing
        End If
        Dim translations As New Dictionary(Of String, String)
        Try
            Dim j As Object = New JavaScriptSerializer().Deserialize(Of Object)(jsonString)
            For Each entry As KeyValuePair(Of String, Object) In j
                translations.Add(entry.Key, entry.Value)
            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return translations
    End Function
End Module
