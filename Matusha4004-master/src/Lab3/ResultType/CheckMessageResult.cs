namespace Itmo.ObjectOrientedProgramming.Lab3.ResultType;

public abstract record CheckMessageResult
{
    private CheckMessageResult() { }

    public sealed record Success() : CheckMessageResult;

    public sealed record FailMessageIsBeenChecked() : CheckMessageResult;

    public sealed record FailMessageNotForThisUser() : CheckMessageResult;
}