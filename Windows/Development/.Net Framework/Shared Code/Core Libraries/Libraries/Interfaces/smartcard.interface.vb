Imports System.Runtime.InteropServices

Public Interface IsmartCard
    Function getCardUIDString() As String
    Function getReadedString() As String
    Function getStatus()
    Function SelectDevice() As Boolean
    Function ListReaders() As List(Of String)
    Function GetAvailableReaders(<Out> ByRef smartCardReaders As List(Of String), <Out> ByRef errMsg As String) As Integer

    Function establishContext() As Boolean
    Function connectCard() As Boolean
    Sub Close()
    Function readCardUID() As Boolean
    Function SaveStringOnCard(ByVal Text As String, ByVal Block As String) As Boolean
    Function SaveStringBlockOnCard(ByVal Text As String, ByVal Block As Integer) As Boolean 'Please make sure you do not write data into these Authentication Blocks 0,3,7,11,15.
    Function readCard(ByVal Block As Integer) As String

    Function readStringOnCard(ByVal strSize As Integer, ByVal startingBlock As Integer) As Boolean
    Function readBlockOnCard(ByVal Block As Integer) As Boolean

End Interface
