namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Power
{
    public Power(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static bool operator >(Power s1, Power s2)
    {
        return s1.Value > s2.Value;
    }

    public static bool operator <(Power s1, Power s2)
    {
        return s1.Value < s2.Value;
    }
}