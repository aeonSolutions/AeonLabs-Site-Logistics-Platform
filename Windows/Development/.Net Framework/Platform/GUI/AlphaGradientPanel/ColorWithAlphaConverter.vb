Imports System.ComponentModel

Public Class ColorWithAlphaTypeConverter
    Inherits ExpandableObjectConverter

    Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destType As Type) As Boolean
        If destType Is GetType(String) Then
            Return True
        End If
        Return MyBase.CanConvertTo(context, destType)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
        If destType Is GetType(String) Then
            Return "My color"
        End If
        Return MyBase.ConvertTo(context, culture, value, destType)
    End Function

End Class
