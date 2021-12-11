Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace CheckComboBox
    Public Class CCBoxItem
        Private val As Integer

        Public Property Value As Integer
            Get
                Return val
            End Get
            Set(ByVal value As Integer)
                val = value
            End Set
        End Property

        Private nom As String

        Public Property name As String
            Get
                Return nom
            End Get
            Set(ByVal value As String)
                nom = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal name As String, ByVal val As Integer)
            Me.nom = name
            Me.val = val
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("name: '{0}', value: {1}", nom, val)
        End Function
    End Class
End Namespace
