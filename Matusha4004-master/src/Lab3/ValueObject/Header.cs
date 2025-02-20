namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public record Header
{
    public Header(string header)
    {
        if (string.IsNullOrWhiteSpace(header)) throw new ArgumentNullException(nameof(header));
        Value = header;
    }

    public string Value { get; }
}