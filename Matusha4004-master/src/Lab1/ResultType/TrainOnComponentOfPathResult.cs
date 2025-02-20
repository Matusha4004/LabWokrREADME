using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultType;

public abstract record TrainOnComponentOfPathResult
{
    private TrainOnComponentOfPathResult() { }

    public sealed record Success(Time Value) : TrainOnComponentOfPathResult;

    public sealed record FailureMinLimitOfSpeed() : TrainOnComponentOfPathResult;

    public sealed record FailureCupOfPower() : TrainOnComponentOfPathResult;

    public sealed record FailureCupOfSpeed() : TrainOnComponentOfPathResult;
}