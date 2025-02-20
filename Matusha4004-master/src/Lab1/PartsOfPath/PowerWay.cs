using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.PartsOfPath;

public class PowerWay : IWay
{
    public PowerWay(Distance distanceOfWay, Power powerOnWay)
    {
        PowerOnWay = powerOnWay;

        DistanceOfWay = distanceOfWay;
    }

    public Distance DistanceOfWay { get; init; }

    public Power PowerOnWay { get; init; }

    public TrainOnComponentOfPathResult TrainOnPath(ITrain train, Time accuracy)
    {
        if (PowerOnWay > train.TrainMaxPower)
        {
            return new TrainOnComponentOfPathResult.FailureCupOfPower();
        }

        var passingDistance = new Distance(0);

        var timeOfCompleting = new Time(0);

        while (DistanceOfWay > passingDistance)
        {
            train.NewSpeedValue(PowerOnWay, accuracy);

            if (train.SpeedOfTrain.Value < 0) return new TrainOnComponentOfPathResult.FailureMinLimitOfSpeed();

            passingDistance = train.DistancePassed(passingDistance, accuracy);

            timeOfCompleting = new Time(accuracy.Value + timeOfCompleting.Value);
        }

        return new TrainOnComponentOfPathResult.Success(timeOfCompleting);
    }
}