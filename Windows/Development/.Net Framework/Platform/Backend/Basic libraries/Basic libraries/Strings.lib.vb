Imports System.Text

Public Module Strings
    Public Function EncodeString(ByRef SourceData As String, ByRef CharSet As String) As String
        'get a byte pointer To the source data
        Dim bSourceData As Byte() = System.Text.Encoding.Unicode.GetBytes(SourceData)

        'get destination encoding 
        Dim OutEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding(CharSet)

        'Encode the data To destination code page/charset
        Dim bytes As Byte() = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, OutEncoding, bSourceData)

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function

    Public Function AddSpaces(str As String, numChars As Integer) As String
        Dim builder As New StringBuilder(str)
        Dim EndIndex = str.Length - (str.Length Mod numChars) + 1

        builder.Insert((str.Length Mod numChars), " "c)
        For i As Int32 = (str.Length Mod numChars) + numChars To EndIndex Step numChars + 1
            builder.Insert(i + 1, " "c)
        Next i
        Return builder.ToString()
    End Function

    Public Function randomString(ByVal Optional size = 12)
        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = size
        Return KeyGen.Generate()
    End Function

    Public Class RandomKeyGenerator
        Dim Key_Letters As String
        Dim Key_Numbers As String
        Dim Key_Chars As Integer
        Dim LettersArray As Char()
        Dim NumbersArray As Char()

        ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        Protected Friend WriteOnly Property KeyLetters() As String
            Set(ByVal Value As String)
                Key_Letters = Value
            End Set
        End Property

        ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        Protected Friend WriteOnly Property KeyNumbers() As String
            Set(ByVal Value As String)
                Key_Numbers = Value
            End Set
        End Property

        ''' WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
        Protected Friend WriteOnly Property KeyChars() As Integer
            Set(ByVal Value As Integer)
                Key_Chars = Value
            End Set
        End Property

        ''' GENERATES A RANDOM STRING OF LETTERS AND NUMBERS.
        ''' LETTERS CAN BE RANDOMLY CAPITAL OR SMALL. RETURNS THERANDOMLY GENERATED KEY</returns>
        Function Generate() As String
            Dim i_key As Integer
            Dim Random1 As Single
            Dim arrIndex As Int16
            Dim sb As New StringBuilder
            Dim RandomLetter As String

            ''' CONVERT LettersArray & NumbersArray TO CHARACTR ARRAYS
            LettersArray = Key_Letters.ToCharArray
            NumbersArray = Key_Numbers.ToCharArray

            For i_key = 1 To Key_Chars
                ''' START THE CLOCK    - LAITH - 27/07/2005 18:01:18 -
                Randomize()
                Random1 = Rnd()
                arrIndex = -1
                ''' IF THE VALUE IS AN EVEN NUMBER WE GENERATE A LETTER,
                ''' OTHERWISE WE GENERATE A NUMBER  
                ''' THE NUMBER '111' WAS RANDOMLY CHOSEN. ANY NUMBER
                ''' WILL DO, WE JUST NEED TO BRING THE VALUE
                ''' ABOVE '0' 
                If (CType(Random1 * 111, Integer)) Mod 2 = 0 Then
                    ''' GENERATE A RANDOM INDEX IN THE LETTERS
                    ''' CHARACTER ARRAY 
                    Do While arrIndex < 0
                        arrIndex =
                         Convert.ToInt16(LettersArray.GetUpperBound(0) _
                         * Random1)
                    Loop
                    RandomLetter = LettersArray(arrIndex)
                    ''' CREATE ANOTHER RANDOM NUMBER. IF IT IS ODD,
                    ''' WE CAPITALIZE THE LETTER
                    If (CType(arrIndex * Random1 * 99, Integer)) Mod 2 <> 0 Then
                        RandomLetter = LettersArray(arrIndex).ToString
                        RandomLetter = RandomLetter.ToUpper
                    End If
                    sb.Append(RandomLetter)
                Else
                    ''' GENERATE A RANDOM INDEX IN THE NUMBERS
                    ''' CHARACTER ARRAY 
                    Do While arrIndex < 0
                        arrIndex =
                          Convert.ToInt16(NumbersArray.GetUpperBound(0) _
                          * Random1)
                    Loop
                    sb.Append(NumbersArray(arrIndex))
                End If
            Next
            Return sb.ToString
        End Function
    End Class
End Module
