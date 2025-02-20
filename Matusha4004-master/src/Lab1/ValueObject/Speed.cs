namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Speed
{
    public Speed(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static Distance operator -(Speed s1, Speed s2)
    {
        return new Distance(s1.Value - s2.Value);
    }

    public static Distance operator +(Speed s1, Speed s2)
    {
        return new Distance(s1.Value + s2.Value);
    }

    public static bool operator >(Speed s1, Speed s2)
    {
        return s1.Value > s2.Value;
    }

    public static bool operator <(Speed s1, Speed s2)
    {
        return s1.Value < s2.Value;
    }
}