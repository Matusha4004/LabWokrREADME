namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record Identifier
{
    public Identifier(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
}