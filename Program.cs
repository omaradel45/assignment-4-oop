using System;
using System.Collections.Generic;

// First Project
public class Point3D : IComparable<Point3D>, ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    // Constructors using chaining
    public Point3D() : this(0, 0, 0) { }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }

    public override bool Equals(object obj)
    {
        if (obj is Point3D other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(Point3D p1, Point3D p2)
    {
        return p1.Equals(p2);
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !p1.Equals(p2);
    }

    public int CompareTo(Point3D other)
    {
        int xComparison = X.CompareTo(other.X);
        if (xComparison != 0) return xComparison;
        return Y.CompareTo(other.Y);
    }

    public object Clone()
    {
        return new Point3D(X, Y, Z);
    }
}

// Second Project
public static class Maths
{
    public static int Add(int a, int b) => a + b;

    public static int Subtract(int a, int b) => a - b;

    public static int Multiply(int a, int b) => a * b;

    public static double Divide(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return (double)a / b;
    }
}

// Third Project
public class Duration
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }

    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Normalize();
    }

    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
    }

    private void Normalize()
    {
        int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        Hours = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
    }

    public override string ToString()
    {
        return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Duration other)
        {
            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }

    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds +
                            d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
    }

    public static Duration operator +(Duration d, int seconds)
    {
        return new Duration(d.Hours * 3600 + d.Minutes * 60 + d.Seconds + seconds);
    }

    public static Duration operator +(int seconds, Duration d)
    {
        return d + seconds;
    }

    public static Duration operator ++(Duration d)
    {
        return d + 60;
    }

    public static Duration operator --(Duration d)
    {
        return d + (-60);
    }

    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds -
                            (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds));
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) >
               (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) <
               (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return !(d1 > d2);
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return !(d1 < d2);
    }

    public static explicit operator DateTime(Duration d)
    {
        return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
    }
}
