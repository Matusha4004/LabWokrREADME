using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.PartsOfPath;

public class BasicWay : IWay
{
    public BasicWay(Distance distanceOfWay)
    {
        DistanceOfWay = distanceOfWay;
    }

    public Distance DistanceOfWay { get; init;  }

    public TrainOnComponentOfPathResult TrainOnPath(ITrain train, Time accuracy)
    {
        if (train.SpeedOfTrain.Value <= 0)
        {
            return new TrainOnComponentOfPathResult.FailureMinLimitOfSpeed();
        }

        var timeOfComliting = new Time(0);

        var passingDistance = new Distance(0);

        while (passingDistance < DistanceOfWay)
        {
            passingDistance = train.DistancePassed(passingDistance, accuracy);

            timeOfComliting = new Time(timeOfComliting.Value + accuracy.Value);
        }

        return new TrainOnComponentOfPathResult.Success(timeOfComliting);
    }
}