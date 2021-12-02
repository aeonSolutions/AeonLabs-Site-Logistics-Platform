Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports AeonLabs.Environment
Imports AeonLabs.Security
Imports Newtonsoft.Json

Public Class Settings
    Private state As environmentVarsCore

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
    Public hasError As Boolean = False

    Public Sub New(ByVal _state As environmentVarsCore)
        state = _state
    End Sub

    Public Sub updateState(ByVal _state As environmentVarsCore)
        state = _state
    End Sub

#Region "SAVE TO SETTINGS FILE"
    Public Function save() As Boolean
        hasError = False
        Dim vars As New Dictionary(Of String, String)
        state.secretKey = state.SettingsSecretKey
        Dim encryption As New AesCipher(state)

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
                hasError = True
                Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
                errorMessage = My.Resources.strings.errorDeletingData & ". " & My.Resources.strings.contactEnterpriseSupport
                Return False
            End Try
        End If
        Try
            Dim bytes = Convert.FromBase64String(encrypted)
            File.WriteAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"), bytes)
        Catch ex As Exception
            hasError = True
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            errorMessage = My.Resources.strings.errorSavingData & ". " & My.Resources.strings.contactEnterpriseSupport
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "LOAD SETTINGS FILE TO ENVIRONMENT"
    Public Function load() As environmentVarsCore
        state.secretKey = state.SettingsSecretKey
        Dim encryption As New AesCipher(state)

        Dim settingsFile = New FileInfo(Path.Combine(state.libraryPath, "ScrewDriver.eon"))
        settingsFile.Refresh()
        If settingsFile.Exists Then
            Try
                Dim bytes = File.ReadAllBytes(Path.Combine(state.libraryPath, "ScrewDriver.eon"))

                Dim encrypted As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Dim decrypted As String = encryption.decrypt(encrypted)

                Dim data = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(decrypted)
                state.country = data.Item("country").ToString
                state.currentLang = data.Item("language").ToString
                state.ServerBaseAddr = data.Item("serverAddress").ToString
                state.ApiServerAddrPath = data.Item("ApiServerAddrPath").ToString
                state.secretKey = data.Item("ApiEncryptionKey").ToString
                state.SendDiagnosticData = data.Item("sendDiags")
                state.SendCrashData = data.Item("sendCrash")

                Return state
            Catch ex As Exception
                hasError = True
                errorMessage = ex.ToString
                Return Nothing
            End Try
        Else
            hasError = True
            Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(state.currentLang)
            errorMessage = My.Resources.strings.errorDataFileNotFound
            Return Nothing
        End If
    End Function
#End Region
End Class
