
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Net
Imports System.Text

Public Class upload_frm
    Public fileName As String
    Public address As String
    Public postData As Dictionary(Of String, String) = Nothing
    Public responseBytes As Byte()
    Private speedtimer As New Stopwatch
    Private readings As Integer = 0
    Private translations As languageTranslations
    Private state As State
     
    Private WithEvents bwSites As BackgroundWorker
    Private reqparm As New Specialized.NameValueCollection

    Private Sub upload_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        state = MainMdiForm.state

        Me.SuspendLayout()
         
         

        closeLink.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        fileSize.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        bytesSent.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        downloadSpeed.Font = New Font(state.fontText.Families(0), state.RegularTextFontSize, Drawing.FontStyle.Regular)
        uploading.Font = New Font(state.fontTitle.Families(0), state.groupBoxTitleFontSize, Drawing.FontStyle.Bold)
        divider.BackColor = state.dividerColor

        translations = New languageTranslations(state)
        translations.load("commonForm")
        closeLink.Text = translations.getText("cancelBtn")
        translations.load("uploadFile")
        fileSize.Text = translations.getText("size") & ": " & " - - " & translations.getText("bytes")
        bytesSent.Text = translations.getText("bytesSent") & ": " & " - - " & translations.getText("bytes")
        downloadSpeed.Text = translations.getText("speed") & ": - - "
        uploading.Text = translations.getText("uploading")

        Me.ResumeLayout()

    End Sub
    Private Sub upload_frm_shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim uri As Uri = New Uri(address)
        speedtimer.Start()

        bwSites = New BackgroundWorker()
        bwSites.WorkerSupportsCancellation = True
        bwSites.WorkerReportsProgress = True
        bwSites.RunWorkerAsync()

        Try

        Catch ex As Exception
            translations.load("errorMessages")
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("contactingCommServer") & " (bad request query?)'}")
            speedtimer.Stop()
            Me.Close()
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub uploading_Click(sender As Object, e As EventArgs)
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


    Private Sub bwSites_ProgressChange(sender As Object, e As ProgressChangedEventArgs) Handles bwSites.ProgressChanged
        ProgressBarX1.Value = e.ProgressPercentage
    End Sub

    Private Sub bwSites_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwSites.RunWorkerCompleted

    End Sub

    Private Sub bwSites_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwSites.DoWork
        Dim currentspeed As Double = -1
        Dim translations As languageTranslations
        Dim state As New State
        translations = New languageTranslations(state)
        translations.load("uploadFile")

        Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & vbCrLf)
        Dim wr As HttpWebRequest = CType(WebRequest.Create(address), HttpWebRequest)
        wr.ContentType = "multipart/form-data; boundary=" & boundary
        wr.Method = "POST"
        wr.KeepAlive = True
        wr.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim rs As Stream = wr.GetRequestStream()
        Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" & vbCrLf & vbCrLf & "{1}"

        For i = 0 To postData.Count - 1
            rs.Write(boundarybytes, 0, boundarybytes.Length)
            Dim formitem As String = String.Format(formdataTemplate, postData.Keys(i), postData.Item(postData.Keys(i)))
            Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
            rs.Write(formitembytes, 0, formitembytes.Length)
        Next

        rs.Write(boundarybytes, 0, boundarybytes.Length)
        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCrLf & "Content-Type: {2}" & vbCrLf & vbCrLf
        Dim header As String = String.Format(headerTemplate, "file", fileName, "application/octet-stream")
        Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
        rs.Write(headerbytes, 0, headerbytes.Length)
        Dim fileStream As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim buffer As Byte() = New Byte(4095) {}
        Dim bytesRead As Integer = 0
        Dim totalBytesRead As Double = 0

        fileSize.Invoke(Sub()
                            fileSize.Text = translations.getText("size") & ": " & Math.Round(fileStream.Length / 1024, 0) & " " & translations.getText("bytes")
                        End Sub)
        bytesRead = fileStream.Read(buffer, 0, buffer.Length)
        While (bytesRead <> 0)
            rs.Write(buffer, 0, bytesRead)
            totalBytesRead += bytesRead
            bytesSent.Invoke(Sub()
                                 bytesSent.Text = translations.getText("bytesSent") & ": " & Math.Round(totalBytesRead / 1024, 0) & " " & translations.getText("bytes")
                             End Sub)
            bwSites.ReportProgress(totalBytesRead / fileStream.Length * 100)

            readings += 1
            If readings >= 5 Then
                currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                speedtimer.Reset()
                readings = 0
                downloadSpeed.Invoke(Sub()
                                         downloadSpeed.Text = translations.getText("speed") & ": " & currentspeed
                                     End Sub)
            End If
            bytesRead = fileStream.Read(buffer, 0, buffer.Length)
        End While

        fileStream.Close()
        Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & "--" & vbCrLf)
        rs.Write(trailer, 0, trailer.Length)
        rs.Close()
        Dim wresp As WebResponse = Nothing

        Try
            wresp = wr.GetResponse()
            Dim stream2 As Stream = wresp.GetResponseStream()
            Dim reader2 As StreamReader = New StreamReader(stream2)

            responseBytes = System.Text.Encoding.UTF8.GetBytes(reader2.ReadToEnd())
        Catch ex As Exception
            MainMdiForm.statusMessage = ex.Message.ToString
            saveCrash(ex)

            translations.load("errorMessages")
            responseBytes = System.Text.Encoding.UTF8.GetBytes("{'error':true,'message':'" & translations.getText("contactingCommServer") & ":" & ex.Message & "'}")

            If wresp IsNot Nothing Then
                wresp.Close()
                wresp = Nothing
            End If

        Finally
            wr = Nothing
            Me.Invoke(Sub()
                          Me.Close()
                      End Sub)

        End Try
    End Sub

End Class