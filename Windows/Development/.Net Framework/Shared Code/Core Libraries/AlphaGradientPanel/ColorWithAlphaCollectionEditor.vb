Imports System.ComponentModel.Design

Namespace CustomPanels
    Friend Class ColorWithAlphaCollectionEditor
        Inherits CollectionEditor

        Private cfForm As CollectionForm

        Sub New(ByVal Type As Type)
            MyBase.New(Type)
        End Sub

        Protected Overrides Function CreateCollectionForm() As System.ComponentModel.Design.CollectionEditor.CollectionForm
            cfForm = MyBase.CreateCollectionForm
            Return cfForm
        End Function

        Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            If Not cfForm Is Nothing AndAlso cfForm.Visible Then
                Return New ColorWithAlphaCollectionEditor(CollectionType)
            Else
                Return MyBase.EditValue(context, provider, value)
            End If
        End Function
    End Class
End Namespace
