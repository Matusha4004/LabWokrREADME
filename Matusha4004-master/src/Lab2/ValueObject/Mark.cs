namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record Mark
{
    public Mark(int mark)
    {
        if (mark < 0)
        {
            throw new ArgumentException("Mark must be greater or equal to zero.");
        }

        Value = mark;
    }

    public int Value { get; }

    public static Mark operator +(Mark left, Mark right)
    {
        return new Mark(mark: left.Value + right.Value);
    }
}