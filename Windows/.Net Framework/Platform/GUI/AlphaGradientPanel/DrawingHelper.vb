Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design

Public Class DrawingHelper

    Public Shared Function RoundedRect(ByVal rect As RectangleF, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Dim p As New Drawing2D.GraphicsPath
        Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height, r As Integer = cornerradius

        p.StartFigure()
        'top left arc
        If CBool(roundedcorners And Corner.TopLeft) Then
            p.AddArc(New RectangleF(x, y, 2 * r, 2 * r), 180, 90)
        Else
            p.AddLine(New PointF(x, y + r), New PointF(x, y))
            p.AddLine(New PointF(x, y), New PointF(x + r, y))
        End If

        'top line
        p.AddLine(New PointF(x + r, y), New PointF(x + w - r, y))

        'top right arc
        If CBool(roundedcorners And Corner.TopRight) Then
            p.AddArc(New RectangleF(x + w - 2 * r, y, 2 * r, 2 * r), 270, 90)
        Else
            p.AddLine(New PointF(x + w - r, y), New PointF(x + w, y))
            p.AddLine(New PointF(x + w, y), New PointF(x + w, y + r))
        End If

        'right line
        p.AddLine(New PointF(x + w, y + r), New PointF(x + w, y + h - r))

        'bottom right arc
        If CBool(roundedcorners And Corner.BottomRight) Then
            p.AddArc(New RectangleF(x + w - 2 * r, y + h - 2 * r, 2 * r, 2 * r), 0, 90)
        Else
            p.AddLine(New PointF(x + w, y + h - r), New PointF(x + w, y + h))
            p.AddLine(New PointF(x + w, y + h), New PointF(x + w - r, y + h))
        End If

        'bottom line
        p.AddLine(New PointF(x + w - r, y + h), New PointF(x + r, y + h))

        'bottom left arc
        If CBool(roundedcorners And Corner.BottomLeft) Then
            p.AddArc(New RectangleF(x, y + h - 2 * r, 2 * r, 2 * r), 90, 90)
        Else
            p.AddLine(New PointF(x + r, y + h), New PointF(x, y + h))
            p.AddLine(New PointF(x, y + h), New PointF(x, y + h - r))
        End If

        'left line
        p.AddLine(New PointF(x, y + h - r), New PointF(x, y + r))

        'close figure...
        p.CloseFigure()

        Return p
    End Function

    Public Shared Function RoundedRect(ByVal location As Point, ByVal size As Size, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners)
    End Function

    Public Shared Function RoundedRect(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(x, y, width, height), cornerradius, roundedcorners)
    End Function

    Public Shared Function RoundedRect(ByVal rect As Rectangle, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height), cornerradius, roundedcorners)
    End Function

    Public Shared Function RoundedRect(ByVal location As PointF, ByVal size As SizeF, Optional ByVal cornerradius As Integer = 5, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Return RoundedRect(New RectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, roundedcorners)
    End Function
End Class

<Flags()> _
Public Enum Corner
    None = 0
    TopLeft = 1
    TopRight = 2
    BottomLeft = 4
    BottomRight = 8
    All = TopLeft Or TopRight Or BottomLeft Or BottomRight
    TLBR = TopLeft Or BottomRight
    TRBL = TopRight Or BottomLeft
    TRBR = TopRight Or BottomRight
    TLBL = TopLeft Or BottomLeft
    TRTL = TopRight Or TopLeft
    BRBL = BottomRight Or BottomLeft
    AllxBottomRight = TopLeft Or TopRight Or BottomLeft
End Enum

<Flags()> _
Public Enum ImagePosition
    Center
    TopLeft
    TopRight
    BottomLeft
    BottomRight
End Enum