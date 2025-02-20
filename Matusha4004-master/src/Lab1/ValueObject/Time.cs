namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

public record Time
{
    public Time(double time)
    {
        if (time < 0)
        {
            throw new ArgumentException("Time cannot be negative");
        }

        Value = time;
    }

    public double Value { get; }
}