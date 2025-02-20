using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record Name : IObjectCanBeChanged
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Name cant be Null or WhiteSpace");
        }

        Value = value;
    }

    public string Value { get; }
}