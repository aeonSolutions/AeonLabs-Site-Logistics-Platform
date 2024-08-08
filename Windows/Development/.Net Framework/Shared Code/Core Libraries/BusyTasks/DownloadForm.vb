
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Windows.Forms
Imports ConstructionSiteLogistics.Libraries.Core

Public Class DownloadForm
    Private whereToSave, fileExtension As String
    Public address As String
    Public postData As Dictionary(Of String, String) = Nothing
    Public responseBytes As Byte()
    Private speedtimer As New Stopwatch
    Private readings As Integer = 0
    Private translations As languageTranslations
    Private stateCore As New environmentVars

    Private WithEvents bwSites As BackgroundWorker

    Private WithEvents client As New WebClient

    Public Custom Event UploadProgressChanged As UploadProgressChangedEventHandler
        AddHandler(value As UploadProgressChangedEventHandler)

        End AddHandler
        RemoveHandler(value As UploadProgressChangedEventHandler)

        End RemoveHandler
        RaiseEvent()

        End RaiseEvent
    End Event

    Private mainform As MainMdiForm
    Public Sub New(_mainMdiForm As MainMdiForm)
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        ' This call is required by the designer.
        Me.SuspendLayout()
        InitializeComponent()
        Me.ResumeLayout()
        mainform = _mainMdiForm
        stateCore = mainform.state

        Me.Refresh()
    End Sub
    Private Sub mainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SuspendLayout()

        closeLink.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        fileSize.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        bytesSent.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadSpeed.Font = New Font(stateCore.fontText.Families(0), stateCore.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloading.Font = New Font(stateCore.fontTitle.Families(0), stateCore.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = stateCore.dividerColor

        translations = New languageTranslations(stateCore)
        translations.load("commonForm")
        closeLink.Text = translations.getText("cancelBtn")

        translations.load("uploadFile")
        fileSize.Text = translations.getText("size") & ": " & " - - " & translations.getText("bytes")
        bytesSent.Text = translations.getText("bytesReceived") & ": " & " - - " & translations.getText("bytes")
        downloadSpeed.Text = translations.getText("speed") & ": - - "
        downloading.Text = translations.getText("downloading")

        Me.ProgressBar1.Value = 0
        ResumeLayout()
        If IsNothing(postData) Then
            translations.load("errorMessages")
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("errorInvalidUrl") & "'}")
            Me.Close()
            Exit Sub
        End If

        If Not Me.address.StartsWith("http://") Then
            translations.load("errorMessages")
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("errorInvalidUrl") & "'}")
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub upload_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        speedtimer.Start()
        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.RunWorkerAsync()
    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim Data2Send As String = ""
        Dim currentspeed As Double = -1
        Dim translations As languageTranslations
        Dim stateCore As New environmentVars
        translations = New languageTranslations(stateCore)
        translations.load("uploadFile")

        For i = 0 To postData.Count - 1
            Data2Send += HttpUtility.UrlEncode(postData.Keys(i)) + "=" + HttpUtility.UrlEncode(postData.Item(postData.Keys(i))) + "&"
        Next

        Dim request As HttpWebRequest = HttpWebRequest.Create(address)
        request.Method = "POST"
        Dim data() As Byte = Encoding.UTF8.GetBytes(Data2Send)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = data.Length

        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(data, 0, data.Length)
        requestStream.Close()
        Try
            Using response As HttpWebResponse = request.GetResponse()
                Using stream = response.GetResponseStream()
                    Using bytes = New MemoryStream()
                        Dim Buffer(256) As Byte
                        fileSize.Invoke(Sub()
                                            fileSize.Text = translations.getText("size") & ": " & response.ContentLength & " " & translations.getText("bytes")
                                        End Sub)
                        While (bytes.Length < response.ContentLength)
                            Dim read = stream.Read(Buffer, 0, Buffer.Length)
                            If (read > 0) Then
                                bytes.Write(Buffer, 0, read)
                                bytesSent.Invoke(Sub()
                                                     bytesSent.Text = translations.getText("bytesReceived") & ": " & bytes.Length & " " & translations.getText("bytes")
                                                 End Sub)
                                ProgressBar1.Invoke(Sub()
                                                        ProgressBar1.Value = CInt(bytes.Length * 100 / response.ContentLength)
                                                    End Sub)

                                readings += 1
                                If readings >= 5 Then
                                    currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                                    speedtimer.Reset()
                                    readings = 0
                                    downloadSpeed.Invoke(Sub()
                                                             downloadSpeed.Text = translations.getText("speed") & ": " & currentspeed
                                                         End Sub)
                                End If
                            Else
                                Exit While
                            End If
                        End While
                        e.Result = bytes.ToArray()
                        fileExtension = response.GetResponseHeader("Content-Disposition")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            e.Result = False
            fileExtension = ex.Message
        End Try


    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted
        If e.Result.Equals(False) Or fileExtension.Equals("") Then
            If fileExtension.Equals("") Then
                fileExtension = "filename not found on download"
            End If
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & fileExtension & "','file':''}")
            Me.Close()
            Exit Sub
        End If
        Dim translations As languageTranslations
        Dim stateCore As New environmentVars
        translations = New languageTranslations(stateCore)

        whereToSave = mainForm.state.tmpPath & randomString() & fileExtension.Substring(fileExtension.IndexOf("."))

        System.IO.File.WriteAllBytes(whereToSave, e.Result)

        translations.load("readyMessages")
        responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':false,'message':'" & translations.getText("downloadCompleted") & "','file':'" & whereToSave.Replace("\", "\\") & "'}")
        Me.Close()
    End Sub



    Private Sub closeLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles closeLink.LinkClicked
        Try
            bwSites.CancelAsync()
        Catch ex As Exception

        End Try
        translations.load("errorMessages")
        responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("errorCanceledByUser") & "'}")
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class
