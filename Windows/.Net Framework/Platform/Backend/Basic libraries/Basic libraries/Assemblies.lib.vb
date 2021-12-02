Imports System.Reflection
Imports System.Windows.Forms
Imports AeonLabs.Environment

Public Module DLLlibrary

    Public Function GetFormByName(ByVal FormName As String) As Form
        Dim T As Type = Type.GetType(FormName, True, True)
        Return CType(Activator.CreateInstance(T), Form)
    End Function

    Public Function loadExternalAssembly(ByVal state As environmentVarsCore, ByVal dllFileName As String, ByVal className As String) As Object
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

    Public Function loadAssembly() As FormCustomized
        'TODO
        Try
            Dim assembly As Reflection.Assembly = Reflection.Assembly.LoadFile("store.dll")
            Dim type As Type = assembly.[GetType]("AeonLabs.storeMainForm")
            Dim SetupForm As Form = TryCast(Activator.CreateInstance(type), Form)

            Dim TypesOnAssemblies As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("TypesOnAssemblies")
            TypesOnAssemblies.SetValue(SetupForm, type)

            Dim enVarsSetup As Reflection.PropertyInfo = SetupForm.GetType().GetProperty("ExternalLoadEnVars")
            enVarsSetup.SetValue(SetupForm, "")

            SetupForm.ShowDialog()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Public Function loadFormFromAssembly(fileName As String, formName As String, enVars As environmentVarsCore, updateMainApp As environmentVarsCore.updateMainLayoutDelegate) As FormCustomized
        Dim formToLoad = enVars.assemblies(fileName).Item(formName).assemblyFormToLoad

        Dim setEnVars As Reflection.PropertyInfo = formToLoad.GetType().GetProperty("envars")
        setEnVars.SetValue(formToLoad, enVars)

        Dim setUpdateMainApp As Reflection.PropertyInfo = formToLoad.GetType().GetProperty("updateMainApp")
        setUpdateMainApp.SetValue(formToLoad, updateMainApp)

        Return formToLoad
    End Function
End Module
