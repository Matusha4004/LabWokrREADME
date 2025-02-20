using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

public interface ILecture : IChangingPart, IPartOfEducatedSystem, IObjectCanBeChanged
{
    Description Description { get; }
}