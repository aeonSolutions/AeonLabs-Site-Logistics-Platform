Imports System
Imports System.Management
Imports System.Security.Cryptography
Imports System.Security
Imports System.Collections
Imports System.Text

Public Class FingerPrint
    Private Shared fingerPrint As String = String.Empty

    Public Function Value() As String
        If String.IsNullOrEmpty(fingerPrint) Then
            fingerPrint = GetHash("CPU >> " & cpuId() & vbLf & "BIOS >> " & biosId() & vbLf & "BASE >> " & baseId())
        End If

        Return fingerPrint
    End Function

    Private Shared Function GetHash(ByVal s As String) As String
        Dim sec As MD5 = New MD5CryptoServiceProvider()
        Dim enc As ASCIIEncoding = New ASCIIEncoding()
        Dim bt As Byte() = enc.GetBytes(s)
        Return GetHexString(sec.ComputeHash(bt))
    End Function

    Private Shared Function GetHexString(ByVal bt As Byte()) As String
        Dim s As String = String.Empty

        For i As Integer = 0 To bt.Length - 1
            Dim b As Byte = bt(i)
            Dim n, n1, n2 As Integer
            n = CInt(b)
            n1 = n And 15
            n2 = (n >> 4) & 15

            If n2 > 9 Then
                s += (n2 - 10 + Asc("A")).ToString()
            Else
                s += n2.ToString()
            End If

            If n1 > 9 Then
                s += (n1 - 10 + Asc("A")).ToString()
            Else
                s += n1.ToString()
            End If

            If (i + 1) <> bt.Length AndAlso (i + 1) Mod 2 = 0 Then s += "-"
        Next

        Return s
    End Function

    Private Shared Function identifier(ByVal wmiClass As String, ByVal wmiProperty As String, ByVal wmiMustBeTrue As String) As String
        Dim result As String = ""
        Dim mc As ManagementClass = New System.Management.ManagementClass(wmiClass)
        Dim moc As System.Management.ManagementObjectCollection = mc.GetInstances()

        For Each mo As System.Management.ManagementObject In moc

            If mo(wmiMustBeTrue).ToString() = "True" Then

                If result = "" Then

                    Try
                        result = mo(wmiProperty).ToString()
                        Exit For
                    Catch
                    End Try
                End If
            End If
        Next

        Return result
    End Function

    Private Shared Function identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
        Dim result As String = ""
        Dim mc As System.Management.ManagementClass = New System.Management.ManagementClass(wmiClass)
        Dim moc As System.Management.ManagementObjectCollection = mc.GetInstances()

        For Each mo As System.Management.ManagementObject In moc
            If result = "" Then
                Try
                    If mo(wmiProperty) IsNot Nothing Then
                        result = mo(wmiProperty).ToString()
                        Exit For
                    End If
                Catch
                End Try
            End If
        Next
        Return result
    End Function

    Private Shared Function cpuId() As String
        Dim retVal As String = identifier("Win32_Processor", "UniqueId")

        If retVal = "" Then
            retVal = identifier("Win32_Processor", "ProcessorId")

            If retVal = "" Then
                retVal = identifier("Win32_Processor", "Name")

                If retVal = "" Then
                    retVal = identifier("Win32_Processor", "Manufacturer")
                End If

                retVal += identifier("Win32_Processor", "MaxClockSpeed")
            End If
        End If

        Return retVal
    End Function

    Private Shared Function biosId() As String
        Return identifier("Win32_BIOS", "Manufacturer") & identifier("Win32_BIOS", "SMBIOSBIOSVersion") & identifier("Win32_BIOS", "IdentificationCode") & identifier("Win32_BIOS", "SerialNumber") & identifier("Win32_BIOS", "ReleaseDate") & identifier("Win32_BIOS", "Version")
    End Function

    Private Shared Function diskId() As String
        Return identifier("Win32_DiskDrive", "Model") & identifier("Win32_DiskDrive", "Manufacturer") & identifier("Win32_DiskDrive", "Signature") & identifier("Win32_DiskDrive", "TotalHeads")
    End Function

    Private Shared Function baseId() As String
        Return identifier("Win32_BaseBoard", "Model") & identifier("Win32_BaseBoard", "Manufacturer") & identifier("Win32_BaseBoard", "Name") & identifier("Win32_BaseBoard", "SerialNumber")
    End Function

    Private Shared Function videoId() As String
        Return identifier("Win32_VideoController", "DriverVersion") & identifier("Win32_VideoController", "Name")
    End Function

    Private Shared Function macId() As String
        Return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled")
    End Function
End Class
