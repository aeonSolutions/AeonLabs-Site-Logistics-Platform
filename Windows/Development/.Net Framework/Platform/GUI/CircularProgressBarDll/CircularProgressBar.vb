Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace CircularProgress
    Public Class CircularProgressBar : Inherits UserControl

#Region "Declares"
        Private minimumSizeAllowed As Size
        Private _minimumSize As Size
        Private _barCount As Integer = 4
        Private _bars(4) As BarData
        Private _smoothTimer As System.Timers.Timer
        Private _borderEnabled As Boolean = False
        Private _image As Image = Nothing
        Private _barSeperation As Integer = 1
        Private _barWidth As Integer = 4
        Private _displayPercentage As Boolean = True
        Private _displayTotalPercentage As Boolean = False
        Private _smoothBars As Boolean = False
        Private _info As String = "Data"
        Private _textShadow As Boolean = False
        Private _textShadowColor As Color = Color.White
        Private _inactiveColorEnabled As Boolean = True
        Private _imageEnabled As Boolean = True
#End Region

#Region "Constructor"
        Public Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.ResizeRedraw, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            For i As Integer = 0 To _bars.Count - 1
                _bars(i) = New BarData(i + 1)
                AddHandler _bars(i).PropertyChanged, AddressOf Bars_PropertyChanged
            Next

            Size = New Size(150, 150)
            Font = New Font("Verdana", 14.0!)
            _smoothTimer = New System.Timers.Timer
            AddHandler _smoothTimer.Elapsed, AddressOf Smoother_Tick
            _smoothTimer.Enabled = False
            _smoothTimer.Interval = 1
            Call SetMinimumSize()
        End Sub
#End Region

#Region "Overrides"
        Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ExStyle = &H20
                Return cp
            End Get
        End Property

        Public Overrides Property MinimumSize As Size
            Get
                Return _minimumSize
            End Get
            Set(value As Size)
                If value.Height < minimumSizeAllowed.Height Then value.Height = minimumSizeAllowed.Height
                If value.Width < minimumSizeAllowed.Width Then value.Height = minimumSizeAllowed.Height
                _minimumSize = value
            End Set
        End Property

        Public Overrides Property Text As String
            Get
                Return _info
            End Get
            Set(ByVal v As String)
                _info = v : RefreshControl()
            End Set
        End Property

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim circleSize As Integer = _barWidth
            Dim realPercentage(_barCount) As Single
            Dim setPercentage(_barCount) As Single
            Dim currentAngle(_barCount) As Single
            Dim remainderAngle(_barCount) As Single
            For i As Integer = 0 To _barCount
                If Not _bars(i).Enabled Then Continue For
                setPercentage(i) = (_bars(i).SmoothValue / _bars(i).Maximum) * 100
                realPercentage(i) = (_bars(i).Value / _bars(i).Maximum) * 100
                currentAngle(i) = CSng(360 / 100 * setPercentage(i))
                remainderAngle(i) = 360 - currentAngle(i)
            Next

            Using B As New Bitmap(Width, Height)
                Using G As Graphics = Graphics.FromImage(B)

                    G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                    If BackColor <> Color.Transparent Then
                        G.Clear(BackColor)
                    End If

                    For i As Integer = 0 To _barCount
                        If Not _bars(i).Enabled Then Continue For
                        Dim colorToUse As Color
                        If _bars(i).SmoothValue >= _bars(i).Maximum Then
                            colorToUse = _bars(i).FinishColor
                        Else
                            colorToUse = _bars(i).ActiveColor
                        End If

                        Using progressPen As New Pen(colorToUse, circleSize), remainderPen As New Pen(_bars(i).InactiveColor, circleSize), BorderPen As New Pen(_bars(i).BorderColor, circleSize + 2)
                            progressPen.StartCap = Drawing2D.LineCap.NoAnchor
                            progressPen.EndCap = Drawing2D.LineCap.NoAnchor
                            remainderPen.StartCap = Drawing2D.LineCap.NoAnchor
                            remainderPen.EndCap = Drawing2D.LineCap.NoAnchor
                            BorderPen.StartCap = Drawing2D.LineCap.NoAnchor
                            BorderPen.EndCap = Drawing2D.LineCap.NoAnchor

                            If _borderEnabled Then
                                If _inactiveColorEnabled Then
                                    G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), 0, 360)
                                Else
                                    If currentAngle(i) >= 1 Then G.DrawArc(BorderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -90, currentAngle(i))
                                End If
                            End If
                            If currentAngle(i) >= 1 Then G.DrawArc(progressPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), -90, currentAngle(i))
                            If _inactiveColorEnabled AndAlso remainderAngle(i) >= 1 Then G.DrawArc(remainderPen, (_barSeperation * i) + (circleSize * (i + 1)), (_barSeperation * i) + (circleSize * (i + 1)), Width - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), Height - (_barSeperation * i * 2) - ((i + 1) * circleSize * 2), currentAngle(i) - 90, remainderAngle(i))
                        End Using
                    Next

                    If Image IsNot Nothing Then G.DrawImage(Image, New Point(CInt(Width / 2) - (Image.Width / 2), CInt(Height / 2) - (Image.Height / 2)))

                    Using fnt As New Font(Font.FontFamily, Font.Size)
                        Dim textDisplay As String = String.Empty

                        If _displayPercentage Then
                            If _displayTotalPercentage Then
                                Dim percentageCalculate As Integer = 0
                                For i As Integer = 0 To _barCount
                                    If Not _bars(i).Enabled Then Continue For
                                    percentageCalculate += realPercentage(i)
                                Next
                                percentageCalculate /= _barCount
                                textDisplay &= percentageCalculate.ToString + "%"
                            Else
                                For i As Integer = 0 To _barCount
                                    If Not _bars(i).Enabled Then Continue For
                                    If textDisplay = String.Empty Then
                                        textDisplay &= realPercentage(i).ToString + "%"
                                    Else : textDisplay &= vbNewLine & realPercentage(i).ToString + "%"
                                    End If
                                Next
                            End If
                        Else
                            textDisplay = _info
                        End If
                        Dim stringFormat As New StringFormat()
                        stringFormat.Alignment = StringAlignment.Center
                        stringFormat.LineAlignment = StringAlignment.Center

                        Dim textRect As Rectangle = New Rectangle(0, 0, Width, Height)
                        If _textShadow Then
                            Dim textRectShadow As New Rectangle(1, 1, Width, Height)
                            G.DrawString(textDisplay, fnt, New SolidBrush(_textShadowColor), textRectShadow, stringFormat)
                        End If
                        G.DrawString(textDisplay, fnt, New SolidBrush(ForeColor), textRect, stringFormat)
                    End Using
                    e.Graphics.DrawImageUnscaled(B, 0, 0)
                End Using
            End Using
        End Sub

        <DisplayName("BackColor")>
        <Description("Gets or Sets the enabled value of the back color to use.")>
        <Category("Bar Info")>
        Public Overrides Property BackColor As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal v As Color)
                MyBase.BackColor = v : RefreshControl()
            End Set
        End Property
#End Region

#Region "Properties"
        <DisplayName("Bar #1")>
        <Description("Bar #1 Data")>
        <Category("Bars")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property Bar1 As BarData
            Get
                Return _bars(0)
            End Get
            Set(v As BarData)
                _bars(0) = v
            End Set
        End Property

        <DisplayName("Bar #2")>
        <Description("Bar #2 Data")>
        <Category("Bars")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property Bar2 As BarData
            Get
                Return _bars(1)
            End Get
            Set(v As BarData)
                _bars(1) = v
            End Set
        End Property

        <DisplayName("Bar #3")>
        <Description("Bar #3 Data")>
        <Category("Bars")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property Bar3 As BarData
            Get
                Return _bars(2)
            End Get
            Set(v As BarData)
                _bars(2) = v
            End Set
        End Property

        <DisplayName("Bar #4")>
        <Description("Bar #4 Data")>
        <Category("Bars")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property Bar4 As BarData
            Get
                Return _bars(3)
            End Get
            Set(v As BarData)
                _bars(3) = v
            End Set
        End Property

        <DisplayName("Bar #5")>
        <Description("Bar #5 Data")>
        <Category("Bars")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property Bar5 As BarData
            Get
                Return _bars(4)
            End Get
            Set(v As BarData)
                _bars(4) = v
            End Set
        End Property

        <DefaultValue(1)>
        <DisplayName("Bar Seperation")>
        <Description("Gets or Sets the bar seperation value. This is the amount in pixels the distance between each bar defined.")>
        <Category("Bar Info")>
        Public Property Seperation As Integer
            Get
                Return _barSeperation
            End Get
            Set(ByVal v As Integer)
                If v < 0 Then v = 0
                _barSeperation = v : RefreshControl()
                Call SetMinimumSize()
            End Set
        End Property

        <DefaultValue(4)>
        <DisplayName("Bar Width")>
        <Description("Gets or Sets the bar width. This is the actual bar width, per bar.")>
        <Category("Bar Info")>
        Public Property BarWidth As Integer
            Get
                Return _barWidth
            End Get
            Set(ByVal v As Integer)
                _barWidth = v : RefreshControl()
                Call SetMinimumSize()
            End Set
        End Property

        <DefaultValue(True)>
        <DisplayName("Display Percentages")>
        <Description("Gets or Sets the display of bar percentages. This will display a percentage per bar displayed.")>
        <Category("Bar Info")>
        Public Property DisplayPercentage As Boolean
            Get
                Return _displayPercentage
            End Get
            Set(ByVal v As Boolean)
                _displayPercentage = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(False)>
        <DisplayName("Display Total Percentage")>
        <Description("Gets or Sets the display of a total percentage. This will calculate all the bars and display only one percentage.")>
        <Category("Bar Info")>
        Public Property DisplayTotalPercentage As Boolean
            Get
                Return _displayTotalPercentage
            End Get
            Set(ByVal v As Boolean)
                _displayTotalPercentage = v : RefreshControl()
            End Set
        End Property
        <DefaultValue(False)>
        <DisplayName("Smooth Bars")>
        <Description("Gets or Sets if the bars will increment in a smooth motion. This is good if your values change heavier and you want a smooth look to them.")>
        <Category("Bar Info")>
        Public Property SmoothBars As Boolean
            Get
                Return _smoothBars
            End Get
            Set(ByVal v As Boolean)
                _smoothBars = v : RefreshControl()
            End Set
        End Property

        <DefaultValue("Data")>
        <DisplayName("Text Data")>
        <Description("Gets or Sets the text when percentages is not enabled. This will display a set text (that can be edited at runtime) rather then percentages if 'Display Percentages' is disabled.")>
        <Category("Appearance")>
        Public Property Info As String
            Get
                Return _info
            End Get
            Set(ByVal v As String)
                _info = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(False)>
        <DisplayName("Text Shadow")>
        <Description("Gets or Sets there will be text shadowing.")>
        <Category("Appearance")>
        Public Property TextShadow As Boolean
            Get
                Return _textShadow
            End Get
            Set(ByVal v As Boolean)
                _textShadow = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(GetType(Color), "Color.White")>
        <DisplayName("Text Shadow Color")>
        <Description("Gets or Sets the color of text shadowing. This requires the Text Shadow boolean to be true.")>
        <Category("Appearance")>
        Public Property TextShadowColor As Color
            Get
                Return _textShadowColor
            End Get
            Set(ByVal v As Color)
                _textShadowColor = v : RefreshControl()
            End Set
        End Property

        <DefaultValue("Nothing")>
        <DisplayName("Image")>
        <Description("Gets or Sets the bar image. This will display a bar image in the middle of the bar.")>
        <Category("Bar Info")>
        Public Property Image As Image
            Get
                Return _image
            End Get
            Set(ByVal v As Image)
                _image = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(False)>
        <DisplayName("Borders Enabled")>
        <Description("Gets or Sets the enabled value of the border around the bar.")>
        <Category("Bar Info")>
        Public Property BorderEnabled As Boolean
            Get
                Return _borderEnabled
            End Get
            Set(ByVal v As Boolean)
                _borderEnabled = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(True)>
        <DisplayName("Inactive Colors Enabled")>
        <Description("Gets or Sets the enabled value of the inactive colors. If this is disabled, then the inactive bars won't be displayed.")>
        <Category("Bar Info")>
        Public Property InactiveColorEnabled As Boolean
            Get
                Return _inactiveColorEnabled
            End Get
            Set(ByVal v As Boolean)
                _inactiveColorEnabled = v : RefreshControl()
            End Set
        End Property

        <DefaultValue(True)>
        <DisplayName("Image Enabled")>
        <Description("Gets or Sets the enabled value of the image. If this is disabled, the image will not be rendered.")>
        <Category("Bar Info")>
        Public Property ImageEnabled As Boolean
            Get
                Return _imageEnabled
            End Get
            Set(ByVal v As Boolean)
                _imageEnabled = v : RefreshControl()
            End Set
        End Property
#End Region

#Region "Subs/Functions"
        Private Sub Smoother_Tick(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
            Dim allDone As Boolean = True
            For i As Integer = 0 To _barCount
                If _bars(i).Value > _bars(i).SmoothValue Then
                    _bars(i).SmoothValue += _bars(i).SmoothAmount
                    If _bars(i).SmoothValue > _bars(i).Value Then _bars(i).SmoothValue = _bars(i).Value
                    allDone = False
                ElseIf _bars(i).Value < _bars(i).SmoothValue Then
                    _bars(i).SmoothValue -= _bars(i).SmoothAmount
                    If _bars(i).SmoothValue < _bars(i).Value Then _bars(i).SmoothValue = _bars(i).Value
                    allDone = False
                End If
            Next
            If allDone Then _smoothTimer.Enabled = False
        End Sub

        Private Sub RefreshControl()
            Invalidate()
        End Sub

        Public Function ShouldSerializeBars() As Boolean
            Return Not (_bars Is Nothing)
        End Function

        Public Sub ResetBars()
            For i As Integer = 0 To _bars.Count - 1
                _bars(i) = New BarData(i)
                AddHandler _bars(i).PropertyChanged, AddressOf Bars_PropertyChanged
            Next
        End Sub

        <System.ComponentModel.Browsable(False)>
        <EditorBrowsable(EditorBrowsableState.Never)>
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Private Sub Bars_PropertyChanged(sender As Object,
        e As PropertyChangedEventArgs)
            If e.PropertyName = "Enabled" Then Call SetMinimumSize()
            If e.PropertyName = "Value" Then
                If _smoothBars = True Then
                    _smoothTimer.Enabled = True
                Else
                    Dim bar As BarData = sender
                    bar.SmoothValue = bar.Value
                End If
            End If
            RefreshControl()
        End Sub

        Private Sub SetMinimumSize()
            Dim bCount As Integer = 0
            For i As Integer = _bars.Count - 1 To 0 Step -1
                If _bars(i).Enabled Then
                    bCount = i + 1
                    Exit For
                End If
            Next

            Dim minSize As Integer = (bCount + 1) * (_barWidth + _barSeperation) * 2
            minimumSizeAllowed = New Size(minSize, minSize)
            MinimumSize = minimumSizeAllowed
            Dim width As Integer = Size.Width
            Dim height As Integer = Size.Width
            If width < minSize Then width = minSize
            If height < minSize Then height = minSize
            Size = New Size(width, height)
        End Sub
#End Region

    End Class
End Namespace