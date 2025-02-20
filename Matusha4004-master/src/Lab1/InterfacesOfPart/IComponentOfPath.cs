using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;

public interface IComponentOfPath
{
    public TrainOnComponentOfPathResult TrainOnPath(ITrain train, Time accuracy);
}