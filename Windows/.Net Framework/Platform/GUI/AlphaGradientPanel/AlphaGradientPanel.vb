Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class AlphaGradientPanel
    Inherits Panel

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        Me.BackColor = Color.Transparent
    End Sub

#Region "PROPERTIES"
    Private bRoundCorners As Boolean = True
    <Category("Borders")> _
    Property Rounded() As Boolean
        Get
            Return bRoundCorners
        End Get
        Set(ByVal value As Boolean)
            bRoundCorners = value
            Invalidate()
        End Set
    End Property

    Private eCorners As Corner = Corner.All
    <Category("Borders")> _
    Property Corners() As Corner
        Get
            Return eCorners
        End Get
        Set(ByVal value As Corner)
            eCorners = value
            Invalidate()
        End Set
    End Property

    Private clBorder As Color = SystemColors.ActiveBorder
    <Category("Borders")> _
    Property BorderColor() As Color
        Get
            Return clBorder
        End Get
        Set(ByVal value As Color)
            clBorder = value
            Invalidate()
        End Set
    End Property

    Private bGradient As Boolean = True
    <Category("Content")> _
    Property Gradient() As Boolean
        Get
            Return bGradient
        End Get
        Set(ByVal value As Boolean)
            bGradient = value
            Invalidate()
        End Set
    End Property

    Private bBorder As Boolean = True
    <Category("Borders")> _
    Property Border() As Boolean
        Get
            Return bBorder
        End Get
        Set(ByVal value As Boolean)
            bBorder = value
            Invalidate()
        End Set
    End Property

    Private iCornerRadius As Integer = 20
    <Category("Borders")> _
    Property CornerRadius() As Integer
        Get
            Return iCornerRadius
        End Get
        Set(ByVal value As Integer)
            iCornerRadius = value
            Invalidate()
        End Set
    End Property

    Private gmMode As LinearGradientMode = LinearGradientMode.Vertical
    <Category("Content")> _
    Property GradientMode() As LinearGradientMode
        Get
            Return gmMode
        End Get
        Set(ByVal value As LinearGradientMode)
            gmMode = value
            Invalidate()
        End Set
    End Property

    Private imImage As Image
    <Category("Image")> _
    Property Image() As Image
        Get
            Return imImage
        End Get
        Set(ByVal value As Image)
            imImage = value
            Invalidate()
        End Set
    End Property

    Private eImagePosition As ImagePosition = ImagePosition.BottomRight
    <Category("Image")> _
    Property ImagePosition() As ImagePosition
        Get
            Return eImagePosition
        End Get
        Set(ByVal value As ImagePosition)
            eImagePosition = value
            Invalidate()
        End Set
    End Property

    Private szImageSize As Size = New Size(48, 48)
    <Category("Image")> _
    Property ImageSize() As Size
        Get
            Return szImageSize
        End Get
        Set(ByVal value As Size)
            szImageSize = value
            Invalidate()
        End Set
    End Property

    Private iImageAlpha As Integer = 75
    <Category("Image")> _
    Property ImageAlpha() As Integer
        Get
            Return iImageAlpha
        End Get
        Set(ByVal value As Integer)
            iImageAlpha = value
            Invalidate()
        End Set
    End Property

    Private pdImage As Padding = New Padding(5)
    <Category("Image")> _
    Property ImagePadding() As Padding
        Get
            Return pdImage
        End Get
        Set(ByVal value As Padding)
            pdImage = value
            Invalidate()
        End Set
    End Property

    Private pdContent As Padding = New Padding(0)
    <Category("Content")> _
    Property ContentPadding() As Padding
        Get
            Return pdContent
        End Get
        Set(ByVal value As Padding)
            pdContent = value
            Invalidate()
        End Set
    End Property

    Private bGrayscale As Boolean = False
    <Category("Image")> _
    Property Grayscale() As Boolean
        Get
            Return bGrayscale
        End Get
        Set(ByVal value As Boolean)
            bGrayscale = value
            Invalidate()
        End Set
    End Property

    Private szGradient As Size
    <Category("Content")> _
    Property GradientSize() As Size
        Get
            Return szGradient
        End Get
        Set(ByVal value As Size)
            szGradient = value
            Invalidate()
        End Set
    End Property

    Private wmWrap As WrapMode = WrapMode.Tile
    <Category("Content")> _
    Property GradientWrapMode() As WrapMode
        Get
            Return wmWrap
        End Get
        Set(ByVal value As WrapMode)
            wmWrap = value
            Invalidate()
        End Set
    End Property

    Private snOffset As Single = 1
    <Category("Content")> _
    Property GradientOffset() As Single
        Get
            Return snOffset
        End Get
        Set(ByVal value As Single)
            snOffset = value
            Invalidate()
        End Set
    End Property

    Private clGradient As ColorWithAlphaCollection = New ColorWithAlphaCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Category("Content")> _
    ReadOnly Property Colors() As ColorWithAlphaCollection
        Get
            Return clGradient
        End Get
    End Property

#End Region

#Region "EVENTS"
    Private Sub AlphaGradientPanel_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Invalidate()
    End Sub

    Private Sub AlphaGradientPanel_PaddingChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PaddingChanged
        Invalidate()
    End Sub
#End Region

    Private Sub AlphaGradientPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim brBrush As Brush

        Dim rcClient As Rectangle = New Rectangle(ContentPadding.Left, ContentPadding.Top, Me.Width - ContentPadding.Right - ContentPadding.Left, Me.Height - ContentPadding.Bottom - ContentPadding.Top)

        If Gradient Then
            Dim rcBrush As Rectangle
            If Not GradientSize = Nothing Then
                rcBrush = New Rectangle(0, 0, GradientSize.Width, GradientSize.Height)
            Else
                rcBrush = rcClient
            End If

            If Colors.Count > 1 Then
                brBrush = New LinearGradientBrush(rcBrush, Color.White, Color.White, GradientMode)
                With CType(brBrush, LinearGradientBrush)
                    If GradientWrapMode = WrapMode.Clamp Then GradientWrapMode = WrapMode.Tile
                    .WrapMode = GradientWrapMode
                    .SetSigmaBellShape(snOffset)
                    Dim cb As New ColorBlend(Colors.Count)
                    For i As Integer = 0 To Colors.Count - 1
                        cb.Positions(i) = (1.0! / (cb.Positions.Length - 1)) * i
                        cb.Colors(i) = Color.FromArgb(Colors(i).Alpha, Colors(i).Color.R, Colors(i).Color.G, Colors(i).Color.B)
                    Next
                    .InterpolationColors = cb
                End With
            Else
                brBrush = New SolidBrush(Color.Transparent)
                e.Graphics.DrawString("[GRADIENT] Not enough color (at least 2 needed)", SystemFonts.DialogFont, Brushes.Black, 5, 5)
            End If
        Else
            If Colors.Count > 0 Then
                Dim cwa As ColorWithAlpha = CType(Colors.Item(0), ColorWithAlpha)
                brBrush = New SolidBrush(Color.FromArgb(cwa.Alpha, cwa.Color.R, cwa.Color.G, cwa.Color.B))
            Else
                brBrush = New SolidBrush(Color.Transparent)
                e.Graphics.DrawString("[SOLID] Not enough color (at least 1 needed)", SystemFonts.DialogFont, Brushes.Black, 5, 5)
            End If

        End If

        e.Graphics.CompositingQuality = CompositingQuality.HighQuality
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.CompositingMode = CompositingMode.SourceOver
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim rcBorder As Rectangle = New Rectangle(rcClient.X, rcClient.Y, rcClient.Width - 1, rcClient.Height - 1)
        Dim rcContent As Rectangle = rcClient

        If Rounded Then
            e.Graphics.FillPath(brBrush, DrawingHelper.RoundedRect(rcContent, iCornerRadius, Corners))
            If Border = True Then
                e.Graphics.DrawPath(New Pen(BorderColor), DrawingHelper.RoundedRect(rcBorder, iCornerRadius, Corners))
            End If
        Else
            e.Graphics.FillRectangle(brBrush, rcContent)
            If Border = True Then
                e.Graphics.DrawRectangle(New Pen(BorderColor), rcBorder)
            End If
        End If


        'Dim brShadow As New SolidBrush(Color.FromArgb(85, 0, 0, 0))

        'e.Graphics.DrawString("This is a title", Font, brShadow, ContentPadding.Left + 2, ContentPadding.Right + 2)
        'e.Graphics.DrawString("This is a title", Font, Brushes.White, ContentPadding.Left, ContentPadding.Right)

        If Not Image Is Nothing Then
            Dim btBitmap As Bitmap = Image
            Dim arArray As Single()() = {New Single() {1, 0, 0, 0, 0}, New Single() {0, 1, 0, 0, 0}, New Single() {0, 0, 1, 0, 0}, New Single() {0, 0, 0, CSng(ImageAlpha / 100), 0}, New Single() {0, 0, 0, 0, 1}}

            Dim clrMatrix As ColorMatrix
            If Grayscale Then
                clrMatrix = New ColorMatrix(New Single()() _
                       {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                        New Single() {0.587, 0.587, 0.587, 0, 0}, _
                        New Single() {0.114, 0.114, 0.114, 0, 0}, _
                        New Single() {0, 0, 0, CSng(ImageAlpha / 100), 0}, _
                        New Single() {0, 0, 0, 0, 1}})
            Else
                clrMatrix = New ColorMatrix(New Single()() _
                       {New Single() {1, 0, 0, 0, 0}, _
                        New Single() {0, 1, 0, 0, 0}, _
                        New Single() {0, 0, 1, 0, 0}, _
                        New Single() {0, 0, 0, CSng(ImageAlpha / 100), 0}, _
                        New Single() {0, 0, 0, 0, 1}})
            End If

            Dim imgAttributes As New ImageAttributes()

            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

            Dim rcImage As Rectangle
            Select Case ImagePosition
                Case ImagePosition.TopLeft
                    rcImage = New Rectangle(ContentPadding.Left + ImagePadding.Left, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height)
                Case ImagePosition.BottomRight
                    rcImage = New Rectangle(ContentPadding.Right + rcContent.Width - ImageSize.Width - ImagePadding.Right, ContentPadding.Top + rcContent.Height - ImageSize.Height - ImagePadding.Bottom, ImageSize.Width, ImageSize.Height)
                Case ImagePosition.TopRight
                    rcImage = New Rectangle(ContentPadding.Right + rcContent.Width - ImageSize.Width - ImagePadding.Right, ImagePadding.Top + ContentPadding.Top, ImageSize.Width, ImageSize.Height)
                Case ImagePosition.BottomLeft
                    rcImage = New Rectangle(ContentPadding.Right + ImagePadding.Left, rcContent.Height - ImageSize.Height - ImagePadding.Bottom + ContentPadding.Top, ImageSize.Width, ImageSize.Height)
                Case ImagePosition.Center
                    rcImage = New Rectangle(((rcContent.Width - ImageSize.Width) / 2) + ContentPadding.Left, ((rcContent.Height - ImageSize.Height) / 2) + ContentPadding.Top, ImageSize.Width, ImageSize.Height)
            End Select

            e.Graphics.DrawImage(btBitmap, rcImage, 0, 0, btBitmap.Width, btBitmap.Height, GraphicsUnit.Pixel, imgAttributes)
        End If
    End Sub

End Class
