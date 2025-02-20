using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;

public interface ITrainStopper : IComponentOfPath
{
    public Speed SpeedLimit { get; }

    public TrainOnComponentOfPathResult StopTrain(Speed incomeSpeed);
}