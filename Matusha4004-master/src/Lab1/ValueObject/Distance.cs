namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Distance
{
    public Distance(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Distance cannot be negative.");
        }

        Value = value;
    }

    public double Value { get; }

    public static Distance operator -(Distance s1, Distance s2)
    {
        return new Distance(s1.Value - s2.Value);
    }

    public static Distance operator +(Distance s1, Distance s2)
    {
        return new Distance(s1.Value + s2.Value);
    }

    public static bool operator >(Distance s1, Distance s2)
    {
        return s1.Value > s2.Value;
    }

    public static bool operator <(Distance s1, Distance s2)
    {
        return s1.Value < s2.Value;
    }
}