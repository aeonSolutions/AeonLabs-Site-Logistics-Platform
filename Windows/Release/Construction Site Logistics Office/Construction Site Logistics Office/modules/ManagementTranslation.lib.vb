Imports System.ComponentModel
Imports System.Threading
Imports Newtonsoft.Json.Linq

Module TranslationLib
    Private WithEvents bwTranslate As BackgroundWorker
    Private mre As ManualResetEvent
    Private translated As String = ""
    Private msgbox As message_box_frm
    Private state As State
    Private translations As languageTranslations

    Public Function DoTranslation(text As String, langToTranslate As String, originLang As String, Optional includeOriginalString As Boolean = True) As String
        'https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={langtotranslate}&hl={originlang}&dt=t&dt=bd&dj=1&source=icon&q={text}
        state = MainMdiForm.state
        translations = New languageTranslations(state)
        If langToTranslate.Equals("") Then
            langToTranslate = state.defaultTranslatedLang
        End If
        If originLang.Equals("") Then
            originLang = state.currentLang
        End If
        If Not state.addonsLoaded OrElse Not state.addons.ContainsKey("translation") Then
            translations.load("errorMessages")
            Dim message3 As String = translations.getText("errorWeatherAddonNotFound") & ". " & translations.getText("contactEnterpriseSupport")
            translations.load("messagebox")
            msgbox = New message_box_frm(message3 & ". ", translations.getText("warning"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            msgbox.ShowDialog()
            If Not IsNothing(MainMdiForm.busy) Then
                If MainMdiForm.busy.isActive().Equals(True) Then
                    MainMdiForm.busy.Close(True)
                End If
            End If
            Return text
        End If

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(False) Then
                MainMdiForm.busy = New BusyThread
                MainMdiForm.busy.Show()
            End If
        End If

        If Not IsNothing(bwTranslate) Then
            If bwTranslate.IsBusy Then
                bwTranslate.CancelAsync()
            End If
        End If
        translated = ""

        Dim str As String = text
        Dim idx As Integer = str.IndexOf(Environment.NewLine & " _________________________" & Environment.NewLine)
        If (idx > 0) Then
            str = str.Substring(0, idx)
        End If
        ' these chars are allowed   !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
        str = str.Replace(Environment.NewLine, "#$%@# ").Replace(".", "#$%@# ")

        Dim url As String = state.addons.Item("translation").Replace("{langtotranslate}", langToTranslate).Replace("{originlang}", originLang).Replace("{text}", System.Uri.EscapeDataString(str))
        Dim request As New HttpData(state)
        Dim res As String = request.RequestExternalData(url)

        Try
            Dim step3 As Newtonsoft.Json.Linq.JObject = JObject.Parse(res)
            Dim responseStr As String = step3.SelectToken("sentences[0]").SelectToken("trans").ToString()
            responseStr = responseStr.Replace("#$%@#", Environment.NewLine).Replace("#$%@#", ".")

            If includeOriginalString Then
                str = text
                idx = str.IndexOf(Environment.NewLine & " _________________________" & Environment.NewLine)
                If (idx > 0) Then
                    str = str.Substring(0, idx)
                End If
                str = str & Environment.NewLine & " _________________________" & Environment.NewLine
            Else
                str = ""
            End If
            translated = str & responseStr.ToString(System.Globalization.CultureInfo.InvariantCulture)

        Catch ex As Exception
            MainMdiForm.busy.Close(True)
            saveCrash(ex)
            MainMdiForm.statusMessage = (ex.ToString)
        End Try

        If Not IsNothing(MainMdiForm.busy) Then
            If MainMdiForm.busy.isActive().Equals(True) Then
                MainMdiForm.busy.Close(True)
            End If
        End If

        Return translated
    End Function


End Module
