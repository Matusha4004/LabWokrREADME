namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public record IsRad
{
    public bool Value { get; private set; } = false;

    public void Switch()
    {
        Value = !Value;
    }
}