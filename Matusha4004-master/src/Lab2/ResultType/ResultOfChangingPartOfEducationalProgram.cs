namespace Itmo.ObjectOrientedProgramming.Lab2.ResultType;

public abstract record ResultOfChangingPartOfEducationalProgram
{
    private ResultOfChangingPartOfEducationalProgram()
    {
    }

    public sealed record Success() : ResultOfChangingPartOfEducationalProgram;

    public sealed record FailureDifferentAuthor() : ResultOfChangingPartOfEducationalProgram;

    public sealed record FailureFailInChangingPart() : ResultOfChangingPartOfEducationalProgram;
}