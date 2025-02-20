namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Weight
{
    public Weight(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Weight cannot be negative.");
        }

        Value = value;
    }

    public double Value { get; }
}