namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Acceleration
{
    public Acceleration(double value)
    {
        Value = value;
    }

    public double Value { get; }
}