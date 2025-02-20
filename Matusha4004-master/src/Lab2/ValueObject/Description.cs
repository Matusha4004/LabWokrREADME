using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record Description : IObjectCanBeChanged
{
    public Description(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentNullException(nameof(description));
        }

        Value = description;
    }

    public string Value { get; }
}