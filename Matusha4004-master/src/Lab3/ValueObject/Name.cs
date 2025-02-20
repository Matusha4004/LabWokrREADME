namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public record Name
{
    public Name(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        Value = name;
    }

    public string Value { get; }
}