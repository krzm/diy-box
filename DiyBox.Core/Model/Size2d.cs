using System;

namespace DiyBox.Core;

public class Size2d
{
    protected const string ErrorMessage = "Positive number requaried";

    public double X { get; private set; }

    public double Y { get; private set; }

    public Size2d(
        double x
        , double y)
    {
        if (x <= 0) throw
            new ArgumentException(
                ErrorMessage
                , nameof(x));
        if (y <= 0) throw
            new ArgumentException(
                ErrorMessage
                , nameof(y));
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        var size = obj as Size2d;
        if(size == null) return false;
        return Equals(size);
    }

    public bool Equals(Size2d other)
    {
        return other != null &&
            X == other.X &&
            Y == other.Y;
    }

    public override int GetHashCode()
    {
        return (X, Y).GetHashCode();
    }

    public override string ToString()
    {
        return $"Size2d({nameof(X)}={X}, {nameof(Y)}={Y})";
    }
}