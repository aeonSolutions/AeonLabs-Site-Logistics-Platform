Imports ConstructionSiteLogistics.Libraries.Core
Imports Newtonsoft.Json.Linq

Public Class TranslationLibrary
    Public Event getTranslationText(sender As Object, responseData As String)

    Private translated As String = ""
    Private stateCore As New environmentVars
    Private translations As languageTranslations
    Private WithEvents HttpDataRequestGoogleFree As HttpDataGetData

    Private includeOriginalString As Boolean
    Private originalTextToTranslate As String
    Private originLang As String
    Private langToTranslate As String

    Public Sub New(_text As String, _langToTranslate As String, _originLang As String, Optional _includeOriginalString As Boolean = True)
        includeOriginalString = _includeOriginalString
        originalTextToTranslate = _text
        originLang = _originLang
        langToTranslate = _langToTranslate

        If Not stateCore.addonsLoaded OrElse Not stateCore.addons.ContainsKey("translation") Then
            translations.load("errorMessages")
            translated = "{'error':true,'message':'" & translations.getText("errorWeatherAddonNotFound") & ". " & translations.getText("contactEnterpriseSupport") & "'}"
            RaiseEvent getTranslationText(Me, translated)
            Exit Sub
        ElseIf stateCore.addons("translation")("name").Equals("googleFreeTranslation") Then
            googleFreeTranslation()
        End If
    End Sub
    Public Sub googleFreeTranslation()
        'https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={langtotranslate}&hl={originlang}&dt=t&dt=bd&dj=1&source=icon&q={text}

        translations = New languageTranslations(stateCore)
        If langToTranslate.Equals("") Then
            langToTranslate = stateCore.defaultTranslatedLang
        End If
        If originLang.Equals("") Then
            originLang = stateCore.currentLang
        End If

        translated = ""

        Dim str As String = originalTextToTranslate
        Dim idx As Integer = str.IndexOf(Environment.NewLine & " _________________________" & Environment.NewLine)
        If (idx > 0) Then
            str = str.Substring(0, idx)
        End If
        ' these chars are allowed   !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
        str = str.Replace(Environment.NewLine, "#$%@# ").Replace(".", "#$%@# ")

        Dim url As String = stateCore.addons("translation")("url").Replace("{langtotranslate}", langToTranslate).Replace("{originlang}", originLang).Replace("{text}", System.Uri.EscapeDataString(str)).Replace("{key}", stateCore.addons("translation")("key"))
        HttpDataRequestGoogleFree = New HttpDataGetData(stateCore, url)
        HttpDataRequestGoogleFree.initialize()
        HttpDataRequestGoogleFree.loadQueue(Nothing, Nothing, Nothing)
        HttpDataRequestGoogleFree.startRequest()
    End Sub

    Private Sub HttpDataRequestGoogleFree_dataArrived(sender As Object, responseData As String, misc As Dictionary(Of String,String)) Handles HttpDataRequestGoogleFree.dataArrived
        Try
            Dim step3 As Newtonsoft.Json.Linq.JObject = JObject.Parse(responseData)
            Dim responseStr As String = step3.SelectToken("sentences[0]").SelectToken("trans").ToString()
            responseStr = responseStr.Replace("#$%@#", Environment.NewLine).Replace("#$%@#", ".")
            Dim str As String = ""
            Dim idx As Integer

            If includeOriginalString Then
                str = originalTextToTranslate
                idx = str.IndexOf(Environment.NewLine & " _________________________" & Environment.NewLine)
                If (idx > 0) Then
                    str = str.Substring(0, idx)
                End If
                str = str & Environment.NewLine & " _________________________" & Environment.NewLine
            Else
                str = ""
            End If
            translated = str & responseStr.ToString(System.Globalization.CultureInfo.InvariantCulture)
            RaiseEvent getTranslationText(Me, translated)

        Catch ex As Exception
            saveCrash(ex)
            RaiseEvent getTranslationText(Me, ex.ToString)
        End Try
    End Sub

End Class
