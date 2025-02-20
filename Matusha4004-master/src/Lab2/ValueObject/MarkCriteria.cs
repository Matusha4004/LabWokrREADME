using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

public record MarkCriteria : IObjectCanBeChanged
{
    public MarkCriteria(string criteria)
    {
        if (string.IsNullOrWhiteSpace(criteria))
        {
            throw new ArgumentException($"'{nameof(criteria)}' cannot be null or whitespace", nameof(criteria));
        }

        Value = criteria;
    }

    public string Value { get; }
}