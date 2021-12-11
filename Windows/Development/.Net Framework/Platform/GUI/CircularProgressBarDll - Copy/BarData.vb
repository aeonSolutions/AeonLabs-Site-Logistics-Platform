Imports System.ComponentModel
Imports System.Drawing

Namespace CircularProgress
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class BarData
        Implements INotifyPropertyChanged

#Region "Declares"
        Private _barID As Integer
        Private _enabled As Boolean = False
        Private _smoothAmount As Integer = 1
        Private _smoothValue As Integer = 0
        Private _value As Integer = 0
        Private _maximum As Integer = 100
        Private _borderColor As Color = Color.Black
        Private _finishColor As Color = Color.LightGreen
        Private _activeColor As Color = Color.LightSeaGreen
        Private _inactiveColor As Color = Color.LightGray
#End Region

#Region "Events"
        Public Event PropertyChanged(sender As Object,
         e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
#End Region

#Region "Constructor"
        Public Sub New(barID As Integer)
            _barID = barID
            If _barID = 1 Then Enabled = True
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Function ToString() As String
            Return "Data #" & _barID
        End Function
#End Region

#Region "Properties"
        <DefaultValue(False)>
        <DisplayName("Enabled")>
        <Description("Gets or Sets the enabled value of the bar. If the bar is enabled, then the bar will be visible.")>
        Public Property Enabled As Boolean
            Get
                Return _enabled
            End Get
            Set(ByVal v As Boolean)
                If _barID = 1 Then v = True
                _enabled = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("Enabled"))
            End Set
        End Property
        <DefaultValue(1)>
        <DisplayName("Smooth Amount")>
        <Description("Gets or Sets the smooth amount per timer tick. The higher this is, the less smooth it will look, but the faster it will go. Setting it lower will feel more smooth, but may take too long.")>
        Public Property SmoothAmount As Integer
            Get
                Return _smoothAmount
            End Get
            Set(ByVal v As Integer)
                _smoothAmount = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("SmoothAmount"))
            End Set
        End Property

        Friend Property SmoothValue As Integer
            Get
                Return _smoothValue
            End Get
            Set(ByVal v As Integer)
                If v < 0 Then v = 0
                If v > _maximum Then v = _maximum
                _smoothValue = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("SmoothValue"))
            End Set
        End Property

        <DefaultValue(0)>
        <DisplayName("Value")>
        <Description("Gets or Sets the value. The value cannot be higher then maximum, and less then 0.")>
        Public Property Value As Integer
            Get
                Return _value
            End Get
            Set(ByVal v As Integer)
                If v < 0 Then v = 0
                If v > _maximum Then v = _maximum
                _value = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("Value"))
            End Set
        End Property

        <DefaultValue(100)>
        <DisplayName("Maximum")>
        <Description("Gets or Sets the maximum value. The value cannot lower then 1.")>
        Public Property Maximum As Integer
            Get
                Return _maximum
            End Get
            Set(ByVal v As Integer)
                If v < 1 Then v = 1
                If _value > v Then
                    _smoothValue = v
                    _value = v
                End If
                _maximum = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("Maximum"))
            End Set
        End Property

        <DefaultValue(GetType(Color), "Color.Black")>
        <DisplayName("Border Color")>
        <Description("Gets or Sets the border color. This is the color for the border itself aroudn the bar.")>
        Public Property BorderColor As Color
            Get
                Return _borderColor
            End Get
            Set(ByVal v As Color)
                _borderColor = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("BorderColor"))
            End Set
        End Property

        <DefaultValue(GetType(Color), "Color.LightGreen")>
        <DisplayName("Finish Color")>
        <Description("Gets or Sets the finish color. This is the color of the bar when the bar value is equal to maximum value.")>
        Public Property FinishColor As Color
            Get
                Return _finishColor
            End Get
            Set(ByVal v As Color)
                _finishColor = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("FinishColor"))
            End Set
        End Property

        <DefaultValue(GetType(Color), "Color.LightSeaGreen")>
        <DisplayName("Active Color")>
        <Description("Gets or Sets the active color. This is the color of the active portion of the bar while not complete.")>
        Public Property ActiveColor As Color
            Get
                Return _activeColor
            End Get
            Set(ByVal v As Color)
                _activeColor = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("ActiveColor"))
            End Set
        End Property

        <DefaultValue(GetType(Color), "Color.LightGray")>
        <DisplayName("Inactive Color")>
        <Description("Gets or Sets the inactive color. This is the color of the inactive portion of the bar while not complete.")>
        Public Property InactiveColor As Color
            Get
                Return _inactiveColor
            End Get
            Set(ByVal v As Color)
                _inactiveColor = v
                RaiseEvent PropertyChanged(Me,
                   New PropertyChangedEventArgs("InactiveColor"))
            End Set
        End Property
#End Region

#Region "Subs"
        Public Sub Increment(amount As Integer)
            Value += amount
        End Sub

        Public Sub Decrement(amount As Integer)
            Value -= amount
        End Sub

        Public Sub Reset()
            Value = 0
        End Sub

        Public Sub Max()
            Value = Maximum
        End Sub
#End Region

    End Class
End Namespace