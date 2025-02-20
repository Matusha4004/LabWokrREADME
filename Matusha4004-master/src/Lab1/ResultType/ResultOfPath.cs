using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultType;

public abstract record ResultOfPath
{
    private ResultOfPath() { }

    public sealed record Success(Time Value) : ResultOfPath;

    public sealed record Failure() : ResultOfPath;
}