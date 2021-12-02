Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports AeonLabs.Environment

Public Class AesCipher
    Private stateCore As New environmentVarsCore

    Public Sub New(ByVal Optional _state As environmentVarsCore = Nothing)
        If _state IsNot Nothing Then
            stateCore = _state
        End If
    End Sub

    Public Function encrypt(plainText As String) As String
        'missing convert plainText from local encoding to UTF8

        ' Check arguments.
        If plainText Is Nothing OrElse plainText.Length <= 0 Then
            Throw New ArgumentNullException("plainText")
        End If
        If stateCore.secretKey Is Nothing OrElse stateCore.secretKey.Length <= 0 Then
            Throw New ArgumentNullException("Invalid Key")
        End If

        Dim encrypted() As Byte
        Dim myAes As Aes = Aes.Create()
        Dim strIv As String = randomizeIV(16)
        Dim iv() As Byte = Encoding.UTF8.GetBytes(strIv) 'Guid.NewGuid().ToByteArray()
        With myAes
            .Padding = PaddingMode.PKCS7
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 128
            .Mode = CipherMode.CBC
            .IV = iv
            .Key = Encoding.ASCII.GetBytes(stateCore.secretKey)
        End With

        Using myAes
            ' Create an encryptor to perform the stream transform.
            Dim encryptor As ICryptoTransform = myAes.CreateEncryptor(myAes.Key, myAes.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)
                        'Write all data to the stream.
                        swEncrypt.Write(plainText)
                    End Using

                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using
        encrypt = Convert.ToBase64String(iv.Concat(encrypted).ToArray())

    End Function

    Public Function decrypt(strCipherText As String) As String

        ' Check arguments.
        If strCipherText Is Nothing OrElse strCipherText.Length <= 0 Then
            Throw New ArgumentNullException("plainText")
        End If
        If stateCore.secretKey Is Nothing OrElse stateCore.secretKey.Length <= 0 Then
            Throw New ArgumentNullException("Invalid Key")
        End If

        Dim arrSaltAndCipherText As Byte() = Nothing
        Try
            arrSaltAndCipherText = Convert.FromBase64String(strCipherText)
        Catch ex As Exception
            Throw New ArgumentNullException(ex.ToString)
        End Try


        Dim Algo As Aes = Aes.Create()

        With Algo
            .Padding = PaddingMode.PKCS7
            .BlockSize = 128
            .FeedbackSize = 128
            .KeySize = 128
            .Mode = CipherMode.CBC
            .IV = arrSaltAndCipherText.Take(16).ToArray()
            .Key = Encoding.ASCII.GetBytes(stateCore.secretKey)
        End With

        Using Decryptor As ICryptoTransform = Algo.CreateDecryptor()
            Using MemStream As New MemoryStream(arrSaltAndCipherText.Skip(16).ToArray())
                Using CryptStream As New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)
                    Using Reader As New StreamReader(CryptStream)
                        Return Reader.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function


    Function GetMD5Hash(theInput As String) As String 'returns a hex string

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
         hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function


    Private Function Bytes2HexString(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(Conversion.Hex(b))
        Next
        Return strTemp.ToString()
    End Function


    Function randomizeIV(len As Integer) As String
        Dim Letters As New List(Of Integer)
        'add ASCII codes for numbers
        For i As Integer = 49 To 57
            Letters.Add(i)
        Next
        'lowercase letters
        For i As Integer = 97 To 122
            Letters.Add(i)
        Next
        'uppercase letters
        For i As Integer = 65 To 90
            Letters.Add(i)
        Next

        Dim Rnd As New Random
        Dim SB As New System.Text.StringBuilder
        Dim Temp As Integer
        For count As Integer = 1 To len
            Temp = Rnd.Next(0, Letters.Count)
            SB.Append(Chr(Letters(Temp)))
        Next

        Return SB.ToString
    End Function

End Class
