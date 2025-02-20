using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record Content : IObjectCanBeChanged
{
    public Content(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentNullException(nameof(content));
        }

        Value = content;
    }

    public string Value { get; }
}