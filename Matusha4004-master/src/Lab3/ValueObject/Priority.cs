namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public record Priority
{
    public Priority(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 1);

        Value = value;
    }

    public int Value { get; init; }

    public static bool operator >(Priority left, Priority right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <(Priority left, Priority right)
    {
        return left.Value < right.Value;
    }
}