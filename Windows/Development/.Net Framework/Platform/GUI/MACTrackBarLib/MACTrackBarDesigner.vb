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
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace XComponent.SliderBar.Designer
	''' <summary>
	''' The Designer for the <see cref="MACTrackBar"/>.
	''' </summary>
	Public Class MACTrackBarDesigner : Inherits System.Windows.Forms.Design.ControlDesigner
		Public Sub New()
		End Sub

		''' <summary>
		''' Returns the allowable design time selection rules.
		''' </summary>
		Public Overrides ReadOnly Property SelectionRules() As SelectionRules

			Get
				Dim control As MACTrackBar = CType(IIf(TypeOf Me.Control Is MACTrackBar, Me.Control, Nothing), MACTrackBar)

				' Disallow vertical or horizontal sizing when AutoSize = True
				If Not control Is Nothing AndAlso control.AutoSize = True Then
					If control.Orientation = Orientation.Horizontal Then
						Return (MyBase.SelectionRules And (Not SelectionRules.TopSizeable)) And Not SelectionRules.BottomSizeable
					Else 'control.Orientation == Orientation.Vertical
						Return (MyBase.SelectionRules And (Not SelectionRules.LeftSizeable)) And Not SelectionRules.RightSizeable
					End If
				Else
					Return MyBase.SelectionRules
				End If

			End Get
		End Property



		'Overrides
		''' <summary>
		''' Remove Button and Control properties that are 
		''' not supported by the <see cref="MACTrackBar"/>.
		''' </summary>
		Protected Overrides Sub PostFilterProperties(ByVal Properties As IDictionary)
			Properties.Remove("AllowDrop")
			Properties.Remove("BackgroundImage")
			Properties.Remove("ContextMenu")

			Properties.Remove("Text")
			Properties.Remove("TextAlign")
			Properties.Remove("RightToLeft")
		End Sub


		'Overrides
		''' <summary>
		''' Remove Button and Control events that are 
		''' not supported by the <see cref="MACTrackBar"/>.
		''' </summary>
		Protected Overrides Sub PostFilterEvents(ByVal events As IDictionary)
			'Actions
			events.Remove("Click")
			events.Remove("DoubleClick")

			'Appearence
			events.Remove("Paint")

			'Behavior
			events.Remove("ChangeUICues")
			events.Remove("ImeModeChanged")
			events.Remove("QueryAccessibilityHelp")
			events.Remove("StyleChanged")
			events.Remove("SystemColorsChanged")

			'Drag Drop
			events.Remove("DragDrop")
			events.Remove("DragEnter")
			events.Remove("DragLeave")
			events.Remove("DragOver")
			events.Remove("GiveFeedback")
			events.Remove("QueryContinueDrag")
			events.Remove("DragDrop")

			'Layout
			events.Remove("Layout")
			events.Remove("Move")
			events.Remove("Resize")

			'Property Changed
			events.Remove("BackColorChanged")
			events.Remove("BackgroundImageChanged")
			events.Remove("BindingContextChanged")
			events.Remove("CausesValidationChanged")
			events.Remove("CursorChanged")
			events.Remove("FontChanged")
			events.Remove("ForeColorChanged")
			events.Remove("RightToLeftChanged")
			events.Remove("SizeChanged")
			events.Remove("TextChanged")

			MyBase.PostFilterEvents (events)
		End Sub

	End Class
End Namespace