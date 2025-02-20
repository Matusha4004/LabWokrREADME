using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;

public interface ITrain
{
    public Power TrainMaxPower { get; }

    public Speed SpeedOfTrain { get; }

    public Weight WeightOfTrain { get; }

    public void NewSpeedValue(Power powerValue, Time accuracy);

    public Distance DistancePassed(Distance distancePassed, Time accuracy);
}