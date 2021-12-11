Imports System.Web.Script.Serialization
Imports Newtonsoft.Json.Linq

Module JSonFunctions
    Public Function getTaskTranslations(jsonString As String) As Dictionary(Of String, String)
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
