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
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Namespace XComponent.SliderBar
    ''' <summary>
    ''' Summary description for ColorHelper.
    ''' </summary>
    Friend Class ColorHelper
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="red"></param>
        ''' <param name="green"></param>
        ''' <param name="blue"></param>
        ''' <returns></returns>
        Public Shared Function CreateColorFromRGB(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer) As Color
            'Corect Red element
            Dim r As Integer = red
            If r > 255 Then
                r = 255
            End If
            If r < 0 Then
                r = 0
            End If
            'Corect Green element
            Dim g As Integer = green
            If g > 255 Then
                g = 255
            End If
            If g < 0 Then
                g = 0
            End If
            'Correct Blue Element
            Dim b As Integer = blue
            If b > 255 Then
                b = 255
            End If
            If b < 0 Then
                b = 0
            End If
            Return Color.FromArgb(r, g, b)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="blendColor"></param>
        ''' <param name="baseColor"></param>
        ''' <param name="opacity"></param>
        ''' <returns></returns>
        Public Shared Function OpacityMix(ByVal blendColor As Color, ByVal baseColor As Color, ByVal opacity As Integer) As Color
            Dim r1 As Integer
            Dim g1 As Integer
            Dim b1 As Integer
            Dim r2 As Integer
            Dim g2 As Integer
            Dim b2 As Integer
            Dim r3 As Integer
            Dim g3 As Integer
            Dim b3 As Integer
            r1 = blendColor.R
            g1 = blendColor.G
            b1 = blendColor.B
            r2 = baseColor.R
            g2 = baseColor.G
            b2 = baseColor.B
            r3 = CInt(Fix(((r1 * (CSng(opacity) / 100)) + (r2 * (1 - (CSng(opacity) / 100))))))
            g3 = CInt(Fix(((g1 * (CSng(opacity) / 100)) + (g2 * (1 - (CSng(opacity) / 100))))))
            b3 = CInt(Fix(((b1 * (CSng(opacity) / 100)) + (b2 * (1 - (CSng(opacity) / 100))))))
            Return CreateColorFromRGB(r3, g3, b3)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="baseColor"></param>
        ''' <param name="blendColor"></param>
        ''' <param name="opacity"></param>
        ''' <returns></returns>
        Public Shared Function SoftLightMix(ByVal baseColor As Color, ByVal blendColor As Color, ByVal opacity As Integer) As Color
            Dim r1 As Integer
            Dim g1 As Integer
            Dim b1 As Integer
            Dim r2 As Integer
            Dim g2 As Integer
            Dim b2 As Integer
            Dim r3 As Integer
            Dim g3 As Integer
            Dim b3 As Integer
            r1 = baseColor.R
            g1 = baseColor.G
            b1 = baseColor.B
            r2 = blendColor.R
            g2 = blendColor.G
            b2 = blendColor.B
            r3 = SoftLightMath(r1, r2)
            g3 = SoftLightMath(g1, g2)
            b3 = SoftLightMath(b1, b2)
            Return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="baseColor"></param>
        ''' <param name="blendColor"></param>
        ''' <param name="opacity"></param>
        ''' <returns></returns>
        Public Shared Function OverlayMix(ByVal baseColor As Color, ByVal blendColor As Color, ByVal opacity As Integer) As Color
            Dim r1 As Integer
            Dim g1 As Integer
            Dim b1 As Integer
            Dim r2 As Integer
            Dim g2 As Integer
            Dim b2 As Integer
            Dim r3 As Integer
            Dim g3 As Integer
            Dim b3 As Integer
            r1 = baseColor.R
            g1 = baseColor.G
            b1 = baseColor.B
            r2 = blendColor.R
            g2 = blendColor.G
            b2 = blendColor.B
            r3 = OverlayMath(baseColor.R, blendColor.R)
            g3 = OverlayMath(baseColor.G, blendColor.G)
            b3 = OverlayMath(baseColor.B, blendColor.B)
            Return OpacityMix(CreateColorFromRGB(r3, g3, b3), baseColor, opacity)
        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ibase"></param>
        ''' <param name="blend"></param>
        ''' <returns></returns>
        Private Shared Function SoftLightMath(ByVal ibase As Integer, ByVal blend As Integer) As Integer
            Dim dbase As Single
            Dim dblend As Single
            dbase = CSng(ibase) / 255
            dblend = CSng(blend) / 255
            If dblend < 0.5 Then
                Return CInt(Fix(((2 * dbase * dblend) + (Math.Pow(dbase, 2)) * (1 - (2 * dblend))) * 255))
            Else
                Return CInt(Fix(((Math.Sqrt(dbase) * (2 * dblend - 1)) + ((2 * dbase) * (1 - dblend))) * 255))
            End If
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ibase"></param>
        ''' <param name="blend"></param>
        ''' <returns></returns>
        Public Shared Function OverlayMath(ByVal ibase As Integer, ByVal blend As Integer) As Integer
            Dim dbase As Double
            Dim dblend As Double
            dbase = CDbl(ibase) / 255
            dblend = CDbl(blend) / 255
            If dbase < 0.5 Then
                Return CInt(Fix((2 * dbase * dblend) * 255))
            Else
                Return CInt(Fix((1 - (2 * (1 - dbase) * (1 - dblend))) * 255))
            End If
        End Function

    End Class
End Namespace