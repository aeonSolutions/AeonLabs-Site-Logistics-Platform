Imports System.Drawing.Design
Imports System.ComponentModel

<TypeConverter(GetType(ColorWithAlphaCollectionConverter)), _
Editor(GetType(ColorWithAlphaCollectionEditor), GetType(UITypeEditor)), _
DesignTimeVisible(False), _
ToolboxItem(False), _
Serializable()> _
Public Class ColorWithAlphaCollection
    Inherits CollectionBase
    Implements ICustomTypeDescriptor

    Private ctlParent As Control

    Sub New()

    End Sub

    Sub New(ByVal ParentControl As Control)
        Parent = ParentControl
    End Sub

    <Browsable(False)> _
    Property Parent() As Control
        Get
            Return ctlParent
        End Get
        Set(ByVal value As Control)
            ctlParent = value
        End Set
    End Property

    Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
        CType(newValue, ColorWithAlpha).Parent = Parent
        MyBase.OnSet(index, oldValue, newValue)
    End Sub

    Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As Object)
        CType(value, ColorWithAlpha).Parent = Parent
        MyBase.OnInsert(index, value)
    End Sub

    Default ReadOnly Property Item(ByVal Index As Integer) As ColorWithAlpha
        Get
            Return DirectCast(List(Index), ColorWithAlpha)
        End Get
    End Property

    Public Function Add(ByVal value As ColorWithAlpha) As ColorWithAlpha
        List.Add(value)
        Return value
    End Function

    Public Function Contains(ByVal value As ColorWithAlpha) As Boolean
        Return List.Contains(value)
    End Function

    Public Sub Remove(ByVal value As ColorWithAlpha)
        List.Remove(value)
    End Sub

    Public Function IndexOf(ByVal value As ColorWithAlpha) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As ColorWithAlpha)
        List.Insert(index, value)
    End Sub

    Public Shadows Sub Clear()
        MyBase.Clear()
    End Sub

    Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
        Return TypeDescriptor.GetAttributes(Me, True)
    End Function

    Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
        Return TypeDescriptor.GetClassName(Me, True)
    End Function

    Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
        Return TypeDescriptor.GetComponentName(Me, True)
    End Function

    Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
        Return TypeDescriptor.GetConverter(Me, True)
    End Function

    Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
        Return TypeDescriptor.GetDefaultEvent(Me, True)
    End Function

    Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
        Return TypeDescriptor.GetDefaultProperty(Me, True)
    End Function

    Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
        Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
    End Function

    Public Overloads Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, True)
    End Function

    Public Overloads Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, attributes, True)
    End Function

    Public Overloads Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        Return Nothing
    End Function

    Public Overloads Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        Dim pdcProperties As New PropertyDescriptorCollection(Nothing)
        For i As Integer = 0 To List.Count - 1
            Dim pdProperty As New ColorWithAlphaCollectionPropertyDescriptor(Me, i)
            pdcProperties.Add(pdProperty)
        Next
        Return pdcProperties
    End Function

    Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
        Return Me
    End Function

End Class