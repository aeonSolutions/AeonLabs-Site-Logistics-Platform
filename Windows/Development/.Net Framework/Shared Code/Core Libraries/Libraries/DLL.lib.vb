Imports System.Reflection

Public Module DLLlibrary
    Public Function loadDllObject(ByVal state As environmentVarsCore, ByVal dllFileName As String, ByVal className As String) As Object
        Try
            Dim fullPath As String = state.libraryPath & dllFileName
            Dim asm As Assembly = Assembly.LoadFrom(fullPath)
            Dim myType As System.Type = asm.GetType(asm.GetName.Name & "." & className)
            Return Activator.CreateInstance(myType)
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Function loadDllForm(ByVal state As environmentVarsCore, ByVal dllFileName As String, ByVal className As String) As Object

        Dim Type As String = "<dllname>.<formname>"
        Dim asmAssemblyContainingForm As [Assembly] = [Assembly].LoadFrom("<dllname>.dll")
        Dim typetoload As Type = asmAssemblyContainingForm.GetType(Type)
        Dim GenericInstance As Object
        Dim Arguments() As Object = {CType("Hello", Object), CType(132, Object)}
        GenericInstance = Activator.CreateInstance(typetoload, Arguments)
        ' Dim frm As Form = CType(GenericInstance, Form)
        'frm.ShowDialog()
        'frm.Dispose()
        GC.Collect()

        Return ""
    End Function

End Module
