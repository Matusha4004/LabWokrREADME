namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public record BodyOfMessage
{
    public BodyOfMessage(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
        Value = value;
    }

    public string Value { get; }
}