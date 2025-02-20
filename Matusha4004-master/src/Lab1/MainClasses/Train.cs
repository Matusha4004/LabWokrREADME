using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.MainClasses;

public class Train : ITrain
{
    public Train(Power trainMaxPower, Weight weightOfTrain)
    {
        TrainMaxPower = trainMaxPower;

        SpeedOfTrain = new Speed(0);

        WeightOfTrain = weightOfTrain;
    }

    public Power TrainMaxPower { get; init; }

    public Speed SpeedOfTrain { get; private set; }

    public Weight WeightOfTrain { get; init; }

    public void NewSpeedValue(Power powerValue, Time accuracy)
    {
        var acceleration = new Acceleration(powerValue.Value / WeightOfTrain.Value);
        SpeedOfTrain = new Speed((acceleration.Value * accuracy.Value) + SpeedOfTrain.Value);
    }

    public Distance DistancePassed(Distance distancePassed, Time accuracy)
    {
        return new Distance(distancePassed.Value + (SpeedOfTrain.Value * accuracy.Value));
    }
}