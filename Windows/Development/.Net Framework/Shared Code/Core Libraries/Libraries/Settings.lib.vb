Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Class Settings
    Public state As environmentVarsCore

    Public country As String
    Public lang As String = Nothing

    Public adminName As String = Nothing
    Public adminId As String = Nothing

    Public isNewServer As Boolean = Nothing
    Public isSharedServer As Boolean = Nothing

    Public serverWebAddr As String = Nothing
    Public ApiServerAddrPath As String = Nothing
    Public ApiEncryptionKey As String = Nothing

    Public serverFtpAddr As String = Nothing
    Public serverFtpUser As String = Nothing
    Public serverFtpPwd As String = Nothing
    Public serverFtpSsl As Boolean = Nothing
    Public serverFtpPort As String = Nothing

    Public userId As String = Nothing

    Public dbLang As String = Nothing
    Public dbName As String = Nothing
    Public dbUser As String = Nothing
    Public dbPwd As String = Nothing

    Public sendDiags As Boolean = Nothing
    Public sendCrash As Boolean = Nothing

    Public isTranslationEnabled As Boolean = Nothing
    Public translationProvider As String = Nothing
    Public translationApiKey As String = Nothing

    Public isWeatherEnabled As Boolean = Nothing
    Public weatherProvider As String = Nothing
    Public weatherApiKey As String = Nothing

    Public programId As String = Nothing

    Public disableOptions As Boolean = Nothing

    Public errorMessage As String = ""
    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing)
        If Not IsNothing(_state) Then
            state = _state
        End If
    End Sub

    Public Sub updateState(ByVal _state As environmentVarsCore)
        state = _state
    End Sub

    Public Function save() As Boolean
        Dim vars As New Dictionary(Of String, String)
        Dim translations As languageTranslations
        state.secretKey = state.SettingsSecretKey
        Dim encryption As New AesCipher(state)

        translations = New languageTranslations(state)
        vars.Add("country", country)
        vars.Add("language", lang)
        vars.Add("serverAddress", serverWebAddr)
        vars.Add("ApiServerAddrPath", ApiServerAddrPath)
        vars.Add("ApiEncryptionKey", ApiEncryptionKey)
        vars.Add("sendDiags", sendDiags)
        vars.Add("sendCrash", sendCrash)

        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(vars)
        Dim encrypted As String = encryption.encrypt(json)

        Dim settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                FileSystem.Kill(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
            Catch ex As Exception
                translations.load("errorMessages")
                errorMessage = translations.getText("errorDeletingData") & ". " & translations.getText("contactEnterpriseSupport")
                Return False
            End Try
        End If
        Try
            Dim bytes = Convert.FromBase64String(encrypted)
            File.WriteAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"), bytes)
        Catch ex As Exception
            translations.load("errorMessages")
            errorMessage = translations.getText("errorSavingData") & ". " & translations.getText("contactEnterpriseSupport")
            Return False
        End Try

        Return True
    End Function

    Public Function load(ByRef Optional LoadState As environmentVars = Nothing) As environmentVars
        If IsNothing(LoadState) Then
            LoadState = New environmentVars
        End If
        Dim translations As languageTranslations
        state.secretKey = state.SettingsSecretKey
        Dim encryption As New AesCipher(state)

        translations = New languageTranslations(state)

        Dim settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                Dim bytes = File.ReadAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"))

                Dim encrypted As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Dim decrypted As String = encryption.decrypt(encrypted)

                Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(decrypted)
                LoadState.country = data.Item("country").ToString
                LoadState.currentLang = data.Item("language").ToString
                LoadState.ServerBaseAddr = data.Item("serverAddress").ToString
                LoadState.ApiServerAddrPath = data.Item("ApiServerAddrPath").ToString
                LoadState.secretKey = data.Item("ApiEncryptionKey").ToString
                LoadState.SendDiagnosticData = data.Item("sendDiags")
                LoadState.SendCrashData = data.Item("sendCrash")

                Return LoadState
            Catch ex As Exception
                errorMessage = ex.ToString
                Return Nothing
            End Try
        Else
            errorMessage = translations.getText("errorDataFileNotFound")
            Return Nothing
        End If
    End Function
End Class
