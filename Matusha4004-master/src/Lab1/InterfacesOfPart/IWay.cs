using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;

public interface IWay : IComponentOfPath
{
    public Distance DistanceOfWay { get; }
}