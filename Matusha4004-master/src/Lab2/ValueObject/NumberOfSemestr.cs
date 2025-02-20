namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record NumberOfSemestr
{
    public NumberOfSemestr(int number)
    {
        if (number is < 1 or > 9)
        {
            throw new ArgumentException("The number must be between 1 and 9");
        }

        Value = number;
    }

    public int Value { get; init; }
}