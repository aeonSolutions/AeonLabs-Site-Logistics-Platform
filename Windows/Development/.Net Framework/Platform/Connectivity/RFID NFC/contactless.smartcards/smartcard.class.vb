Imports System.Globalization
Imports System.Runtime.InteropServices

Public Class smartCard

    Private retCode As Integer
    Private hCard As Integer
    Private hContext As IntPtr
    Private Protocol As Integer
    Public connActive As Boolean = False
    Private readername As String = "ACS ACR122 0"
    Public SendBuff As Byte() = New Byte(262) {}
    Public RecvBuff As Byte() = New Byte(262) {}
    Public SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength As Integer
    Public RdrState As smartCard.SCARD_READERSTATE
    Public pioSendRequest As smartCard.SCARD_IO_REQUEST
    Public blockSize As Integer = 4 ' max byte length of block
    Public errorMessage As String = ""
    Private readedString As String = ""
    Private cardUID As String = ""

    Public Function getCardUIDString() As String
        Return cardUID
    End Function

    Public Function getReadedString() As String
        Return readedString
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SCARD_IO_REQUEST
        Public dwProtocol As Integer
        Public cbPciLength As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure APDURec
        Public bCLA As Byte
        Public bINS As Byte
        Public bP1 As Byte
        Public bP2 As Byte
        Public bP3 As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)>
        Public Data As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)>
        Public SW As Byte()
        Public IsSend As Boolean
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure SCARD_READERSTATE
        Public RdrName As String
        Public UserData As Integer
        Public RdrCurrState As Integer
        Public RdrEventState As Integer
        Public ATRLength As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=37)>
        Public ATRValue As Byte()
    End Structure

    Public Const SCARD_S_SUCCESS As Integer = 0
    Public Const SCARD_ATR_LENGTH As Integer = 33
    Public Const CT_MCU As Integer = &H0
    Public Const CT_IIC_Auto As Integer = &H1
    Public Const CT_IIC_1K As Integer = &H2
    Public Const CT_IIC_2K As Integer = &H3
    Public Const CT_IIC_4K As Integer = &H4
    Public Const CT_IIC_8K As Integer = &H5
    Public Const CT_IIC_16K As Integer = &H6
    Public Const CT_IIC_32K As Integer = &H7
    Public Const CT_IIC_64K As Integer = &H8
    Public Const CT_IIC_128K As Integer = &H9
    Public Const CT_IIC_256K As Integer = &HA
    Public Const CT_IIC_512K As Integer = &HB
    Public Const CT_IIC_1024K As Integer = &HC
    Public Const CT_AT88SC153 As Integer = &HD
    Public Const CT_AT88SC1608 As Integer = &HE
    Public Const CT_SLE4418 As Integer = &HF
    Public Const CT_SLE4428 As Integer = &H10
    Public Const CT_SLE4432 As Integer = &H11
    Public Const CT_SLE4442 As Integer = &H12
    Public Const CT_SLE4406 As Integer = &H13
    Public Const CT_SLE4436 As Integer = &H14
    Public Const CT_SLE5536 As Integer = &H15
    Public Const CT_MCUT0 As Integer = &H16
    Public Const CT_MCUT1 As Integer = &H17
    Public Const CT_MCU_Auto As Integer = &H18
    Public Const SCARD_SCOPE_USER As Integer = 0
    Public Const SCARD_SCOPE_TERMINAL As Integer = 1
    Public Const SCARD_SCOPE_SYSTEM As Integer = 2
    Public Const SCARD_STATE_UNAWARE As Integer = &H0
    Public Const SCARD_STATE_IGNORE As Integer = &H1
    Public Const SCARD_STATE_CHANGED As Integer = &H2
    Public Const SCARD_STATE_UNKNOWN As Integer = &H4
    Public Const SCARD_STATE_UNAVAILABLE As Integer = &H8
    Public Const SCARD_STATE_EMPTY As Integer = &H10
    Public Const SCARD_STATE_PRESENT As Integer = &H20
    Public Const SCARD_STATE_ATRMATCH As Integer = &H40
    Public Const SCARD_STATE_EXCLUSIVE As Integer = &H80
    Public Const SCARD_STATE_INUSE As Integer = &H100
    Public Const SCARD_STATE_MUTE As Integer = &H200
    Public Const SCARD_STATE_UNPOWERED As Integer = &H400
    Public Const SCARD_SHARE_EXCLUSIVE As Integer = 1
    Public Const SCARD_SHARE_SHARED As Integer = 2
    Public Const SCARD_SHARE_DIRECT As Integer = 3
    Public Const SCARD_LEAVE_CARD As Integer = 0
    Public Const SCARD_RESET_CARD As Integer = 1
    Public Const SCARD_UNPOWER_CARD As Integer = 2
    Public Const SCARD_EJECT_CARD As Integer = 3
    Public Const FILE_DEVICE_SMARTCARD As Long = &H310000
    Public Const IOCTL_SMARTCARD_DIRECT As Long = FILE_DEVICE_SMARTCARD + 2050 * 4
    Public Const IOCTL_SMARTCARD_SELECT_SLOT As Long = FILE_DEVICE_SMARTCARD + 2051 * 4
    Public Const IOCTL_SMARTCARD_DRAW_LCDBMP As Long = FILE_DEVICE_SMARTCARD + 2052 * 4
    Public Const IOCTL_SMARTCARD_DISPLAY_LCD As Long = FILE_DEVICE_SMARTCARD + 2053 * 4
    Public Const IOCTL_SMARTCARD_CLR_LCD As Long = FILE_DEVICE_SMARTCARD + 2054 * 4
    Public Const IOCTL_SMARTCARD_READ_KEYPAD As Long = FILE_DEVICE_SMARTCARD + 2055 * 4
    Public Const IOCTL_SMARTCARD_READ_RTC As Long = FILE_DEVICE_SMARTCARD + 2057 * 4
    Public Const IOCTL_SMARTCARD_SET_RTC As Long = FILE_DEVICE_SMARTCARD + 2058 * 4
    Public Const IOCTL_SMARTCARD_SET_OPTION As Long = FILE_DEVICE_SMARTCARD + 2059 * 4
    Public Const IOCTL_SMARTCARD_SET_LED As Long = FILE_DEVICE_SMARTCARD + 2060 * 4
    Public Const IOCTL_SMARTCARD_LOAD_KEY As Long = FILE_DEVICE_SMARTCARD + 2062 * 4
    Public Const IOCTL_SMARTCARD_READ_EEPROM As Long = FILE_DEVICE_SMARTCARD + 2065 * 4
    Public Const IOCTL_SMARTCARD_WRITE_EEPROM As Long = FILE_DEVICE_SMARTCARD + 2066 * 4
    Public Const IOCTL_SMARTCARD_GET_VERSION As Long = FILE_DEVICE_SMARTCARD + 2067 * 4
    Public Const IOCTL_SMARTCARD_GET_READER_INFO As Long = FILE_DEVICE_SMARTCARD + 2051 * 4
    Public Const IOCTL_SMARTCARD_SET_CARD_TYPE As Long = FILE_DEVICE_SMARTCARD + 2060 * 4
    Public Const IOCTL_SMARTCARD_ACR128_ESCAPE_COMMAND As Long = FILE_DEVICE_SMARTCARD + 2079 * 4
    Public Const SCARD_F_INTERNAL_ERROR As Integer = -2146435071
    Public Const SCARD_E_CANCELLED As Integer = -2146435070
    Public Const SCARD_E_INVALID_HANDLE As Integer = -2146435069
    Public Const SCARD_E_INVALID_PARAMETER As Integer = -2146435068
    Public Const SCARD_E_INVALID_TARGET As Integer = -2146435067
    Public Const SCARD_E_NO_MEMORY As Integer = -2146435066
    Public Const SCARD_F_WAITED_TOO_LONG As Integer = -2146435065
    Public Const SCARD_E_INSUFFICIENT_BUFFER As Integer = -2146435064
    Public Const SCARD_E_UNKNOWN_READER As Integer = -2146435063
    Public Const SCARD_E_TIMEOUT As Integer = -2146435062
    Public Const SCARD_E_SHARING_VIOLATION As Integer = -2146435061
    Public Const SCARD_E_NO_SMARTCARD As Integer = -2146435060
    Public Const SCARD_E_UNKNOWN_CARD As Integer = -2146435059
    Public Const SCARD_E_CANT_DISPOSE As Integer = -2146435058
    Public Const SCARD_E_PROTO_MISMATCH As Integer = -2146435057
    Public Const SCARD_E_NOT_READY As Integer = -2146435056
    Public Const SCARD_E_INVALID_VALUE As Integer = -2146435055
    Public Const SCARD_E_SYSTEM_CANCELLED As Integer = -2146435054
    Public Const SCARD_F_COMM_ERROR As Integer = -2146435053
    Public Const SCARD_F_UNKNOWN_ERROR As Integer = -2146435052
    Public Const SCARD_E_INVALID_ATR As Integer = -2146435051
    Public Const SCARD_E_NOT_TRANSACTED As Integer = -2146435050
    Public Const SCARD_E_READER_UNAVAILABLE As Integer = -2146435049
    Public Const SCARD_P_SHUTDOWN As Integer = -2146435048
    Public Const SCARD_E_PCI_TOO_SMALL As Integer = -2146435047
    Public Const SCARD_E_READER_UNSUPPORTED As Integer = -2146435046
    Public Const SCARD_E_DUPLICATE_READER As Integer = -2146435045
    Public Const SCARD_E_CARD_UNSUPPORTED As Integer = -2146435044
    Public Const SCARD_E_NO_SERVICE As Integer = -2146435043
    Public Const SCARD_E_SERVICE_STOPPED As Integer = -2146435042
    Public Const SCARD_W_UNSUPPORTED_CARD As Integer = -2146435041
    Public Const SCARD_W_UNRESPONSIVE_CARD As Integer = -2146435040
    Public Const SCARD_W_UNPOWERED_CARD As Integer = -2146435039
    Public Const SCARD_W_RESET_CARD As Integer = -2146435038
    Public Const SCARD_W_REMOVED_CARD As Integer = -2146435037
    Public Const SCARD_PROTOCOL_UNDEFINED As Integer = &H0
    Public Const SCARD_PROTOCOL_T0 As Integer = &H1
    Public Const SCARD_PROTOCOL_T1 As Integer = &H2
    Public Const SCARD_PROTOCOL_RAW As Integer = &H10000
    Public Const SCARD_UNKNOWN As Integer = 0
    Public Const SCARD_ABSENT As Integer = 1
    Public Const SCARD_PRESENT As Integer = 2
    Public Const SCARD_SWALLOWED As Integer = 3
    Public Const SCARD_POWERED As Integer = 4
    Public Const SCARD_NEGOTIABLE As Integer = 5
    Public Const SCARD_SPECIFIC As Integer = 6
    <DllImport("winscard.dll")>
    Public Shared Function SCardEstablishContext(ByVal dwScope As Integer, ByVal pvReserved1 As Integer, ByVal pvReserved2 As Integer, ByRef phContext As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardReleaseContext(ByVal phContext As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardConnect(ByVal hContext As Integer, ByVal szReaderName As String, ByVal dwShareMode As Integer, ByVal dwPrefProtocol As Integer, ByRef phCard As Integer, ByRef ActiveProtocol As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardBeginTransaction(ByVal hCard As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardDisconnect(ByVal hCard As Integer, ByVal Disposition As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardListReaderGroups(ByVal hContext As Integer, ByRef mzGroups As String, ByRef pcchGroups As Integer) As Integer

    End Function
    <DllImport("winscard.DLL", EntryPoint:="SCardListReadersA", CharSet:=CharSet.Ansi)>
    Public Shared Function SCardListReaders(ByVal hContext As Integer, ByVal Groups As Byte(), ByVal Readers As Byte(), ByRef pcchReaders As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardStatus(ByVal hCard As Integer, ByVal szReaderName As String, ByRef pcchReaderLen As Integer, ByRef stateCore As Integer, ByRef Protocol As Integer, ByRef ATR As Byte, ByRef ATRLen As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardEndTransaction(ByVal hCard As Integer, ByVal Disposition As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardState(ByVal hCard As Integer, ByRef stateCore As UInteger, ByRef Protocol As UInteger, ByRef ATR As Byte, ByRef ATRLen As UInteger) As Integer

    End Function
    <DllImport("WinScard.dll")>
    Public Shared Function SCardTransmit(ByVal hCard As IntPtr, ByRef pioSendPci As SCARD_IO_REQUEST, ByRef pbSendBuffer As Byte(), ByVal cbSendLength As Integer, ByRef pioRecvPci As SCARD_IO_REQUEST, ByRef pbRecvBuffer As Byte(), ByRef pcbRecvLength As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardTransmit(ByVal hCard As Integer, ByRef pioSendRequest As SCARD_IO_REQUEST, ByRef SendBuff As Byte, ByVal SendBuffLen As Integer, ByRef pioRecvRequest As SCARD_IO_REQUEST, ByRef RecvBuff As Byte, ByRef RecvBuffLen As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardTransmit(ByVal hCard As Integer, ByRef pioSendRequest As SCARD_IO_REQUEST, ByRef SendBuff As Byte(), ByVal SendBuffLen As Integer, ByRef pioRecvRequest As SCARD_IO_REQUEST, ByRef RecvBuff As Byte(), ByRef RecvBuffLen As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardControl(ByVal hCard As Integer, ByVal dwControlCode As UInteger, ByRef SendBuff As Byte, ByVal SendBuffLen As Integer, ByRef RecvBuff As Byte, ByVal RecvBuffLen As Integer, ByRef pcbBytesReturned As Integer) As Integer

    End Function
    <DllImport("winscard.dll")>
    Public Shared Function SCardGetStatusChange(ByVal hContext As Integer, ByVal TimeOut As Integer, ByRef ReaderState As SCARD_READERSTATE, ByVal ReaderCount As Integer) As Integer

    End Function

    Public Shared Function GetScardErrMsg(ByVal ReturnCode As Integer) As String
        Select Case ReturnCode
            Case SCARD_E_CANCELLED
                Return ("The action was canceled by an SCardCancel request.")
            Case SCARD_E_CANT_DISPOSE
                Return ("The system could not dispose of the media in the requested manner.")
            Case SCARD_E_CARD_UNSUPPORTED
                Return ("The smart card does not meet minimal requirements for support.")
            Case SCARD_E_DUPLICATE_READER
                Return ("The reader driver didn't produce a unique reader name.")
            Case SCARD_E_INSUFFICIENT_BUFFER
                Return ("The data buffer for returned data is too small for the returned data.")
            Case SCARD_E_INVALID_ATR
                Return ("An ATR string obtained from the registry is not a valid ATR string.")
            Case SCARD_E_INVALID_HANDLE
                Return ("The supplied handle was invalid.")
            Case SCARD_E_INVALID_PARAMETER
                Return ("One or more of the supplied parameters could not be properly interpreted.")
            Case SCARD_E_INVALID_TARGET
                Return ("Registry startup information is missing or invalid.")
            Case SCARD_E_INVALID_VALUE
                Return ("One or more of the supplied parameter values could not be properly interpreted.")
            Case SCARD_E_NOT_READY
                Return ("The reader or card is not ready to accept commands.")
            Case SCARD_E_NOT_TRANSACTED
                Return ("An attempt was made to end a non-existent transaction.")
            Case SCARD_E_NO_MEMORY
                Return ("Not enough memory available to complete this command.")
            Case SCARD_E_NO_SERVICE
                Return ("The smart card resource manager is not running.")
            Case SCARD_E_NO_SMARTCARD
                Return ("The operation requires a smart card, but no smart card is currently in the device.")
            Case SCARD_E_PCI_TOO_SMALL
                Return ("The PCI receive buffer was too small.")
            Case SCARD_E_PROTO_MISMATCH
                Return ("The requested protocols are incompatible with the protocol currently in use with the card.")
            Case SCARD_E_READER_UNAVAILABLE
                Return ("The specified reader is not currently available for use.")
            Case SCARD_E_READER_UNSUPPORTED
                Return ("The reader driver does not meet minimal requirements for support.")
            Case SCARD_E_SERVICE_STOPPED
                Return ("The smart card resource manager has shut down.")
            Case SCARD_E_SHARING_VIOLATION
                Return ("The smart card cannot be accessed because of other outstanding connections.")
            Case SCARD_E_SYSTEM_CANCELLED
                Return ("The action was canceled by the system, presumably to log off or shut down.")
            Case SCARD_E_TIMEOUT
                Return ("The user-specified timeout value has expired.")
            Case SCARD_E_UNKNOWN_CARD
                Return ("The specified smart card name is not recognized.")
            Case SCARD_E_UNKNOWN_READER
                Return ("The specified reader name is not recognized.")
            Case SCARD_F_COMM_ERROR
                Return ("An internal communications error has been detected.")
            Case SCARD_F_INTERNAL_ERROR
                Return ("An internal consistency check failed.")
            Case SCARD_F_UNKNOWN_ERROR
                Return ("An internal error has been detected, but the source is unknown.")
            Case SCARD_F_WAITED_TOO_LONG
                Return ("An internal consistency timer has expired.")
            Case SCARD_S_SUCCESS
                Return ("No error was encountered.")
            Case SCARD_W_REMOVED_CARD
                Return ("The smart card has been removed, so that further communication is not possible.")
            Case SCARD_W_RESET_CARD
                Return ("The smart card has been reset, so any shared stateCore information is invalid.")
            Case SCARD_W_UNPOWERED_CARD
                Return ("Power has been removed from the smart card, so that further communication is not possible.")
            Case SCARD_W_UNRESPONSIVE_CARD
                Return ("The smart card is not responding to a reset.")
            Case SCARD_W_UNSUPPORTED_CARD
                Return ("The reader cannot communicate with the card, due to ATR string configuration conflicts.")
            Case Else
                Return ("unknown error")
        End Select
    End Function

    Public Function getStatus()
        Dim szReaderList As String = ""
        Dim ATR As Byte
        Dim ATRLen As Long
        Dim stateCore As Long
        Dim Protocol As Long

        retCode = SCardStatus(hCard, szReaderList, 255, stateCore, Protocol, ATR, ATRLen)
        Select Case stateCore
            Case SCARD_ABSENT
                errorMessage = "No card is currently inserted."
            Case SCARD_PRESENT
                errorMessage = "A card is inserted."
            Case SCARD_SWALLOWED
                errorMessage = "A card is inserted and the reader is swallowed."
            Case SCARD_POWERED
                errorMessage = "The card is powered but the reader."
            Case SCARD_NEGOTIABLE
                errorMessage = "A card is inserted and awaits protocol negotiation."
            Case SCARD_SPECIFIC
                errorMessage = "A card is inserted and a protocol has been selected."
            Case Else
                errorMessage = stateCore
        End Select
        Return True
    End Function


    Public Function SelectDevice() As Boolean
        Dim availableReaders As List(Of String) = ListReaders()
        If Not IsNothing(availableReaders) AndAlso availableReaders.Count > 0 Then
            RdrState = New smartCard.SCARD_READERSTATE()
            readername = availableReaders(0).ToString()
            RdrState.RdrName = readername
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ListReaders() As List(Of String)
        errorMessage = ""
        Dim ReaderCount As UInteger = 0
        Dim AvailableReaderList As List(Of String) = New List(Of String)()

        retCode = SCardListReaders(hContext, Nothing, Nothing, ReaderCount)

        If retCode <> smartCard.SCARD_S_SUCCESS Then
            errorMessage = GetScardErrMsg(retCode)
            Return AvailableReaderList
        End If

        Dim ReadersList As Byte() = New Byte(ReaderCount - 1) {}
        retCode = smartCard.SCardListReaders(hContext, Nothing, ReadersList, ReaderCount)

        If retCode <> smartCard.SCARD_S_SUCCESS Then
            errorMessage = GetScardErrMsg(retCode)
            Return AvailableReaderList
        End If

        Dim rName As String = ""
        Dim indx As Integer = 0

        If ReaderCount > 0 Then
            While ReadersList(indx) <> 0
                While ReadersList(indx) <> 0
                    rName = rName & ChrW(ReadersList(indx))
                    indx = indx + 1
                End While
                AvailableReaderList.Add(rName)
                rName = ""
                indx = indx + 1
            End While
        End If

        Return AvailableReaderList
    End Function

    Public Function GetAvailableReaders(<Out> ByRef smartCardReaders As List(Of String), <Out> ByRef errMsg As String) As Integer
        Dim culture As CultureInfo = Globalization.CultureInfo.InvariantCulture
        Try
            retCode = SCardEstablishContext(SCARD_SCOPE_USER, IntPtr.Zero, IntPtr.Zero, hContext)
            If retCode <> SCARD_S_SUCCESS Then
                errMsg = "WinSCard GetPCSCReader: EstablishContext Error: " & CStr(retCode)
                Return retCode
            End If

            Dim readersList As Byte() = Nothing
            Dim byteCnt As UInteger = 0
            retCode = SCardListReaders(hContext, Nothing, Nothing, byteCnt)

            If retCode <> SCARD_S_SUCCESS Then
                errMsg = "WinSCard GetPCSCReader: ListReaders Error: " & CStr(retCode)
                Return False
            End If

            readersList = New Byte(byteCnt - 1) {}
            retCode = SCardListReaders(hContext, Nothing, readersList, byteCnt)

            If retCode <> SCARD_S_SUCCESS Then
                errMsg = "WinSCard GetPCSCReader: ListReaders Error: " & CStr(retCode)
                Return False
            End If

            Dim indx As Integer = 0
            Dim readerName As String = String.Empty
            Dim i As Integer = 0

            While readersList(indx) <> 0
                While readersList(indx) <> 0
                    readerName = readerName & ChrW(readersList(Math.Min(System.Threading.Interlocked.Increment(indx), indx - 1)))
                End While
                smartCardReaders.Add(readerName)
                i += 1
                readerName = ""
                indx += 1
            End While
        Catch ex As Exception
            errMsg = ex.Message
            Return False
        Finally

        End Try

        Return True
    End Function

    Public Function establishContext() As Boolean
        retCode = SCardEstablishContext(SCARD_SCOPE_USER, IntPtr.Zero, IntPtr.Zero, hContext)
        If retCode <> SCARD_S_SUCCESS Then
            errorMessage = "Check your device and please restart again"
            connActive = False
            Return False
        End If
        Return True
    End Function

    Public Function connectCard() As Boolean
        connActive = True
        retCode = smartCard.SCardConnect(hContext, readername, smartCard.SCARD_SHARE_SHARED, smartCard.SCARD_PROTOCOL_T0 Or smartCard.SCARD_PROTOCOL_T1, hCard, Protocol)
        If retCode <> smartCard.SCARD_S_SUCCESS Then
            errorMessage = smartCard.GetScardErrMsg(retCode)
            connActive = False
            Return False
        End If

        Return True
    End Function

    'disconnect card reader connection
    Public Sub Close()
        If connActive Then
            SCardReleaseContext(hContext)
            retCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD)
            ClearBuffers()
        End If
    End Sub

    'clear memory buffers
    Private Sub ClearBuffers()
        Dim indx As Long

        For indx = 0 To 262
            RecvBuff(indx) = 0
            SendBuff(indx) = 0
        Next
    End Sub

    Public Function readCardUID() As Boolean
        Dim receivedUID As Byte() = New Byte(255) {}
        Dim request As smartCard.SCARD_IO_REQUEST = New smartCard.SCARD_IO_REQUEST()
        request.dwProtocol = smartCard.SCARD_PROTOCOL_T1
        request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(GetType(smartCard.SCARD_IO_REQUEST))
        Dim sendBytes As Byte() = New Byte() {&HFF, &HCA, &H0, &H0, &H0}
        Dim outBytes As Integer = receivedUID.Length
        Dim status As Integer = smartCard.SCardTransmit(hCard, request, sendBytes(0), sendBytes.Length, request, receivedUID(0), outBytes)

        If status <> smartCard.SCARD_S_SUCCESS Then
            cardUID = "Error"
            Return False
        Else
            receivedUID = RemoveEmptyBytes16DigitsDecimal(receivedUID)
            cardUID = BitConverter.ToString(receivedUID.ToArray()).Replace("-", String.Empty).ToLower()
        End If

        Return True
    End Function

    Private Function RemoveEmptyBytes16DigitsDecimal(ByVal packet As Byte()) As Byte()
        Dim i = packet.Length - 1
        While packet(i) = 0
            i -= 1
        End While

        Dim temp = New Byte(i - 1) {} 'for full hex string should be i + 1 - 1 trimmed to 0+6=7 bytes for a number up to 16 digits
        Array.Copy(packet, temp, i) 'should be i+1
        Return temp
    End Function

    ' block authentication
    Private Function authenticateBlock(ByVal block As String) As Boolean
        ClearBuffers()
        SendBuff(0) = &HFF                          'CLASS same for all source types, current value:255
        SendBuff(1) = &H82                          'INS, current value:
        SendBuff(2) = &H0                           'key structure P1, current value:0
        SendBuff(3) = &H0                           'key number P2, current value:0
        SendBuff(4) = &H6                           'LC, current value:
        'data in 6 bytes
        SendBuff(5) = &H1                           'byte 1, version number, current value:1
        SendBuff(6) = &H0                           'byte 2, current value:0
        SendBuff(7) = CByte(Integer.Parse(block))   'byte 3: sector number for stored key input, current value: block
        SendBuff(8) = &H60                          'byte 4: Key A for stored key input, current value: 96
        SendBuff(9) = CByte(Integer.Parse("1"))     'byte 5: session key for non-volatile memory, current value:1  
        SendBuff(10) = &H0                          'byte 6: ??
        SendLen = &HB                               '11
        RecvLen = &H2                               '2
        retCode = SendAPDUandDisplay(0)

        If retCode <> SCARD_S_SUCCESS Then
            Return False
        End If

        Return True
    End Function

    ' send application protocol data unit : communication unit between a smart card reader And a smart card
    Private Function SendAPDUandDisplay(ByVal reqType As Integer) As Integer
        Dim indx As Integer
        Dim tmpStr As String = ""
        pioSendRequest.dwProtocol = Aprotocol
        pioSendRequest.cbPciLength = 8

        For indx = 0 To SendLen - 1
            tmpStr = tmpStr & " " & String.Format("{0:X2}", SendBuff(indx))
        Next

        retCode = SCardTransmit(hCard, pioSendRequest, SendBuff(0), SendLen, pioSendRequest, RecvBuff(0), RecvLen)

        If retCode <> SCARD_S_SUCCESS Then
            Return retCode
        Else
            Try
                tmpStr = ""
                Select Case reqType
                    Case 0
                        For indx = (RecvLen - 2) To (RecvLen - 1)
                            tmpStr = tmpStr & " " & String.Format("{0:X2}", RecvBuff(indx))
                        Next
                        If (tmpStr).Trim() <> "90 00" Then
                            Return -202
                        End If
                    Case 1
                        For indx = (RecvLen - 2) To (RecvLen - 1)
                            tmpStr = tmpStr & String.Format("{0:X2}", RecvBuff(indx))
                        Next
                        If tmpStr.Trim() <> "90 00" Then
                            tmpStr = tmpStr & " " & String.Format("{0:X2}", RecvBuff(indx))
                        Else
                            tmpStr = "ATR : "
                            For indx = 0 To (RecvLen - 3)
                                tmpStr = tmpStr & " " & String.Format("{0:X2}", RecvBuff(indx))
                            Next
                        End If
                    Case 2
                        For indx = 0 To (RecvLen - 1)
                            tmpStr = tmpStr & " " & String.Format("{0:X2}", RecvBuff(indx))
                        Next
                End Select
            Catch __unusedIndexOutOfRangeException1__ As IndexOutOfRangeException
                Return -200
            End Try
        End If

        Return retCode
    End Function

    Public Function SaveStringOnCard(ByVal Text As String, ByVal Block As String) As Boolean

        Dim str As String = ""
        Dim counter As Integer = 1
        Dim blockPos = Block

        For i = 0 To Text.Length - 1
            str = str & Text.Chars(counter - 1)
            If counter Mod blockSize = 0 Then
                If Not SaveStringBlockOnCard(str, blockPos) Then
                    Return False
                End If
                blockPos += 1
                str = ""
            End If
            counter += 1
        Next i
        Return True
    End Function

    Public Function SaveStringBlockOnCard(ByVal Text As String, ByVal Block As Integer) As Boolean 'Please make sure you do not write data into these Authentication Blocks 0,3,7,11,15.
        Dim tmpStr As String = Text
        Dim indx As Integer

        If authenticateBlock(Block) Then
            ClearBuffers()
            SendBuff(0) = &HFF                  'CLASS
            SendBuff(1) = &HD6                  'INS
            SendBuff(2) = &H0                   'P1
            SendBuff(3) = CByte(Block)          'P2: starting block
            SendBuff(4) = CByte(blockSize)      'P3: data length

            For indx = 0 To (tmpStr).Length - 1
                SendBuff(indx + 5) = Convert.ToByte(tmpStr(indx))
            Next

            SendLen = SendBuff(4) + 5
            RecvLen = &H2
            retCode = SendAPDUandDisplay(2)

            If retCode <> SCARD_S_SUCCESS Then
                errorMessage = "Fail Write"
                Return False
            Else
                errorMessage = "Write Success"
                Return True
            End If
        Else
            errorMessage = "Fail Authentication"
            Return False
        End If
    End Function

    Public Function readCard(ByVal Block As Integer) As String
        Dim value As String = ""

        If connectCard() Then
            value = readBlockOnCard(Block)
        End If

        value = value.Split(New Char() {vbNullChar}, 2, StringSplitOptions.None)(0).ToString()
        Return value
    End Function

    Public Function readStringOnCard(ByVal strSize As Integer, ByVal startingBlock As Integer) As Boolean
        If Not connectCard() Then
            errorMessage = "Card readed not connected"
            Return False
        End If

        Dim readedStr As String = ""
        Dim numBlocks As Integer
        numBlocks = If(strSize Mod blockSize = 0, Math.Floor(strSize / blockSize) - 1, Math.Floor(strSize / blockSize))

        For i = startingBlock To startingBlock + numBlocks
            If Not readBlockOnCard(i) Then
                Return False
            End If
            readedStr = readedStr & readedString.Split(New Char() {vbNullChar}, 2, StringSplitOptions.None)(0).ToString().Replace(ChrW(144), "")
        Next i

        readedString = readedStr
        Return True
    End Function

    Public Function readBlockOnCard(ByVal Block As Integer) As Boolean
        Dim tmpStr As String = ""
        Dim indx As Integer

        If authenticateBlock(Block) Then
            ClearBuffers()
            SendBuff(0) = &HFF
            SendBuff(1) = &HB0
            SendBuff(2) = &H0
            SendBuff(3) = CByte(Block)
            SendBuff(4) = CByte(blockSize)
            SendLen = 5
            RecvLen = SendBuff(4) + 2
            retCode = SendAPDUandDisplay(2)

            If retCode = -200 Then
                readedString = ""
                errorMessage = "out of range exception"
                Return False
            End If

            If retCode = -202 Then
                readedString = ""
                errorMessage = "Bytes Not Acceptable"
                Return False
            End If

            If retCode <> SCARD_S_SUCCESS Then
                readedString = ""
                errorMessage = "Fail Read"
                Return False
            End If

            For indx = 0 To RecvLen - 1
                tmpStr &= Convert.ToChar(RecvBuff(indx))
            Next
            readedString = tmpStr
            Return True
        Else
            readedString = ""
            errorMessage = "Fail Authentication"
            Return False
        End If
    End Function

End Class

