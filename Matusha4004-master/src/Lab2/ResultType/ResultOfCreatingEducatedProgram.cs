namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record ResultOfCreatingEducatedProgram
{
    private ResultOfCreatingEducatedProgram()
    {
    }

    public sealed record Success() : ResultOfCreatingEducatedProgram;

    public sealed record FailedNot100MarkInEducatedProgram(int Sum) : ResultOfCreatingEducatedProgram;
}