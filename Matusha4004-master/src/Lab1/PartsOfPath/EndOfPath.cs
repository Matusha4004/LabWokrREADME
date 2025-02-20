using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.PartsOfPath;

public class EndOfPath : ITrainStopper
{
    public EndOfPath(Speed speedLimit)
    {
        SpeedLimit = speedLimit;
    }

    public Speed SpeedLimit { get; init; }

    public TrainOnComponentOfPathResult TrainOnPath(ITrain train, Time accuracy)
    {
        return StopTrain(train.SpeedOfTrain);
    }

    public TrainOnComponentOfPathResult StopTrain(Speed incomeSpeed)
    {
        return SpeedLimit < incomeSpeed ? new TrainOnComponentOfPathResult.FailureCupOfSpeed() : new TrainOnComponentOfPathResult.Success(new Time(0));
    }
}