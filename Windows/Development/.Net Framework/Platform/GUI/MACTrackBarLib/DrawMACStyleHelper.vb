#Region "Copyright (c) 2002-2006 X-Component, All Rights Reserved"
' ---------------------------------------------------------------------*
'*                           X-Component,                              *
'*              Copyright (c) 2002-2006 All Rights reserved              *
'*                                                                       *
'*                                                                       *
'* This file and its contents are protected by Vietnam and               *
'* International copyright laws.  Unauthorized reproduction and/or       *
'* distribution of all or any portion of the code contained herein       *
'* is strictly prohibited and will result in severe civil and criminal   *
'* penalties.  Any violations of this copyright will be prosecuted       *
'* to the fullest extent possible under law.                             *
'*                                                                       *
'* THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'* TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'* TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'* CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'* THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF ECONTECH JSC.,     *
'*                                                                       *
'* UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'* PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'* SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY ECONTECH JSC. PRODUCT.   *
'*                                                                       *
'* THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'* CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF ECONTECH JSC.,     *
'* THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO             *
'* INSURE ITS CONFIDENTIALITY.                                           *
'*                                                                       *
'* THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'* PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'* EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'* THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'* SOURCE CODE CONTAINED HEREIN.                                         *
'*                                                                       *
'* THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'* --------------------------------------------------------------------- *
'
#End Region ' Copyright (c) 2002-2006 X-Component, All Rights Reserved


Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Namespace XComponent.SliderBar
	''' <summary>
	''' Summary description for DrawMACStyleHelper.
	''' </summary>
	Public NotInheritable Class DrawMACStyleHelper
		''' <summary>
		''' The contructor 
		''' </summary>
		Private Sub New()
			'
			' TODO: Add constructor logic here
			'
		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="g"></param>
		''' <param name="drawRectF"></param>
		''' <param name="drawColor"></param>
		''' <param name="orientation"></param>
		Public Shared Sub DrawAquaPill(ByVal g As Graphics, ByVal drawRectF As RectangleF, ByVal drawColor As Color, ByVal orientation As Orientation)

			Dim color1 As Color
			Dim color2 As Color
			Dim color3 As Color
			Dim color4 As Color
			Dim color5 As Color
			Dim gradientBrush As System.Drawing.Drawing2D.LinearGradientBrush
			Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend()

			color1 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, Color.Black, 100), 40)
			color2 = ColorHelper.OpacityMix(Color.White, ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(64, 64, 64), 100), 20)
			color3 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(128, 128, 128), 100)
			color4 = ColorHelper.SoftLightMix(drawColor, ColorHelper.CreateColorFromRGB(192, 192, 192), 100)
			color5 = ColorHelper.OverlayMix(ColorHelper.SoftLightMix(drawColor, Color.White, 100), Color.White, 75)

			'			
			colorBlend.Colors = New Color(){color1, color2, color3, color4, color5}
			colorBlend.Positions = New Single(){0, 0.25f, 0.5f, 0.75f, 1}
			If orientation = Orientation.Horizontal Then
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top-1))), New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top)) + CInt(Fix(drawRectF.Height))+1), color1, color5)
			Else
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left-1)), CInt(Fix(drawRectF.Top))), New Point(CInt(Fix(drawRectF.Left)) + CInt(Fix(drawRectF.Width))+1, CInt(Fix(drawRectF.Top))), color1, color5)
			End If
			gradientBrush.InterpolationColors = colorBlend
			FillPill(gradientBrush, drawRectF, g)

			'
			color2 = Color.White
			colorBlend.Colors = New Color(){color2, color3, color4, color5}
			colorBlend.Positions = New Single(){0, 0.5f, 0.75f, 1}
			If orientation = Orientation.Horizontal Then
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left)) + 1, CInt(Fix(drawRectF.Top))), New Point(CInt(Fix(drawRectF.Left)) + 1, CInt(Fix(drawRectF.Top)) + CInt(Fix(drawRectF.Height - 1))), color2, color5)
			Else
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top)) + 1), New Point(CInt(Fix(drawRectF.Left)) + CInt(Fix(drawRectF.Width - 1)), CInt(Fix(drawRectF.Top)) + 1), color2, color5)
			End If
			gradientBrush.InterpolationColors = colorBlend
			FillPill(gradientBrush, RectangleF.Inflate(drawRectF,-3,-3), g)

		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="g"></param>
		''' <param name="drawRectF"></param>
		''' <param name="drawColor"></param>
		''' <param name="orientation"></param>
		Public Shared Sub DrawAquaPillSingleLayer(ByVal g As Graphics, ByVal drawRectF As RectangleF, ByVal drawColor As Color, ByVal orientation As Orientation)
			Dim color1 As Color
			Dim color2 As Color
			Dim color3 As Color
			Dim color4 As Color
			Dim gradientBrush As System.Drawing.Drawing2D.LinearGradientBrush
			Dim colorBlend As System.Drawing.Drawing2D.ColorBlend = New System.Drawing.Drawing2D.ColorBlend()

			color1 = drawColor
			color2 = ControlPaint.Light(color1)
			color3 = ControlPaint.Light(color2)
			color4 = ControlPaint.Light(color3)

			colorBlend.Colors = New Color(){color1, color2, color3, color4}
			colorBlend.Positions = New Single(){0, 0.25f, 0.65f, 1}

			If orientation = Orientation.Horizontal Then
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top))), New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top)) + CInt(Fix(drawRectF.Height))), color1, color4)
			Else
				gradientBrush = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(CInt(Fix(drawRectF.Left)), CInt(Fix(drawRectF.Top))), New Point(CInt(Fix(drawRectF.Left)) + CInt(Fix(drawRectF.Width)), CInt(Fix(drawRectF.Top))), color1, color4)
			End If
			gradientBrush.InterpolationColors = colorBlend

			FillPill(gradientBrush, drawRectF, g)

		End Sub


		''' <summary>
		''' 
		''' </summary>
		''' <param name="b"></param>
		''' <param name="rect"></param>
		''' <param name="g"></param>
		Public Shared Sub FillPill(ByVal b As Brush, ByVal rect As RectangleF, ByVal g As Graphics)
			If rect.Width > rect.Height Then
				g.SmoothingMode = SmoothingMode.HighQuality
				g.FillEllipse(b, New RectangleF(rect.Left, rect.Top, rect.Height, rect.Height))
				g.FillEllipse(b, New RectangleF(rect.Left + rect.Width - rect.Height, rect.Top, rect.Height, rect.Height))

				Dim w As Single = rect.Width - rect.Height
				Dim l As Single = rect.Left + ((rect.Height)/ 2)
				g.FillRectangle(b, New RectangleF(l, rect.Top, w, rect.Height))
				g.SmoothingMode = SmoothingMode.Default
			ElseIf rect.Width < rect.Height Then
				g.SmoothingMode = SmoothingMode.HighQuality
				g.FillEllipse(b, New RectangleF(rect.Left, rect.Top, rect.Width, rect.Width))
				g.FillEllipse(b, New RectangleF(rect.Left, rect.Top + rect.Height - rect.Width, rect.Width, rect.Width))

				Dim t As Single = rect.Top + (rect.Width/ 2)
				Dim h As Single = rect.Height - rect.Width
				g.FillRectangle (b, New RectangleF(rect.Left, t, rect.Width, h))
				g.SmoothingMode = SmoothingMode.Default
			ElseIf rect.Width = rect.Height Then
				g.SmoothingMode = SmoothingMode.HighQuality
				g.FillEllipse(b, rect)
				g.SmoothingMode = SmoothingMode.Default
			End If
		End Sub

	End Class
End Namespace
