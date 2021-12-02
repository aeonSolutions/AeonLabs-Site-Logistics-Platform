Imports System.Drawing.Text
Imports System.IO
Imports AeonLabs.Environment.menuEnvironmentVarsClass

Public Class environmentLayoutClass
    Public externalImages As New Dictionary(Of String, String)

    Public WithEvents menu As New menuClass

    'MAIN LAYOUT design scheme
    Public Property MENU_BACK_COLOR As Color = Color.Black
    Public Property MENU_CLOSED_STATE As Integer = 40
    Public Property MENU_OPEN_STATE As Integer = 400
    Public Property PANEL_SCROOL_UNDERLAY As Integer = 30

    'widgets & plugIns design scheme
    Public Property labelForeColor As Color = Color.White
    Public Property linkLabelForeColor As Color = Color.White
    Public Property buttonForecolor As Color = Color.White
    Public Property editTextBackColor As Color = Color.White
    Public Property controlWithSelectionBackcolor As Color
    Public Property buttonBackcolor As Color

    Public Property borderColor As Color

    Public Property PanelBackColor As Color
    Public Property PanelTransparencyIndex As Double

    Public Property IconsDefaultSize As Integer

    ' Time interval to change background image on main form
    Public Property RandomBackgroundTimeInterval As New TimeSpan(0, 15, 0) '15 min timeout - integer (Hours, Minutes, Seconds) 
    'fonts
    Public fontText, fontTitle As New PrivateFontCollection()
    Public Property fontTitleFile As String = "TrajanPro.ttf"
    Public Property fontTextFile As String = "Roboto-Medium.ttf"

    'font text size
    Public Property menuTitleFontSize As Integer = 10
    Public Property subMenuTitleFontSize As Integer = 8
    Public Property buttonFontSize As Integer = 12
    Public Property SmallTextFontSize As Integer = 7
    Public Property RegularTextFontSize As Integer = 9
    Public Property DialogTitleFontSize As Integer = 12
    Public Property groupBoxTitleFontSize As Integer = 8
    'main color schemes
    Public Property buttonColor As Color = Color.DarkOrange
    Public Property dividerColor As Color = Color.FromArgb(253, 186, 49)
    Public Property colorMainMenu As Color = Color.FromArgb(35, 40, 45)
    Public Property colorMainPageHeader As Color = Color.FromArgb(253, 186, 49)

    Public Sub loadDefaults(envars As environmentVarsCore)
        'ToDo check default font files are present
        Dim FontFileName = New FileInfo(envars.fontsPath & fontTitleFile)
        FontFileName.Refresh()
        If FontFileName.Exists Then
            envars.layoutDesign.fontTitle.AddFontFile(envars.fontsPath & fontTitleFile)
        Else
            MessageBox.Show("font file not found. reinstall the program")
            Throw New Exception("font file not found")
        End If

        FontFileName = New FileInfo(envars.fontsPath & fontTextFile)
        FontFileName.Refresh()
        If FontFileName.Exists Then
            envars.layoutDesign.fontText.AddFontFile(envars.fontsPath & fontTextFile)
        Else
            MessageBox.Show("font file not found. reinstall the program")
            Throw New Exception("font file not found")
        End If
    End Sub
End Class
