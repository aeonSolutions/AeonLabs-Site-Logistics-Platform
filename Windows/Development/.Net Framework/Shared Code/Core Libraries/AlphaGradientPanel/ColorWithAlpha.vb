Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace CustomPanels


    <TypeConverter(GetType(ColorWithAlphaTypeConverter)),
DesignTimeVisible(False),
ToolboxItem(False),
Serializable()>
    Public Class ColorWithAlpha
        Inherits Component

        Private ctlParent As Control

        <Browsable(False)>
        Public Property Parent() As Control
            Get
                Return ctlParent
            End Get
            Set(ByVal value As Control)
                ctlParent = value
            End Set
        End Property

        Sub New()
            MyBase.New()
            Invalidate()
        End Sub

        Sub Invalidate()
            If Not Parent Is Nothing Then
                Parent.Invalidate()
            End If
        End Sub

        Private clColor As Color = SystemColors.Control
        Private iAlpha As Integer = 255

        Property Color() As Color
            Get
                Return clColor
            End Get
            Set(ByVal value As Color)
                clColor = value
                Invalidate()
            End Set
        End Property

        Property Alpha() As Integer
            Get
                Return iAlpha
            End Get
            Set(ByVal value As Integer)
                iAlpha = value
                Invalidate()
            End Set
        End Property

    End Class
End Namespace

