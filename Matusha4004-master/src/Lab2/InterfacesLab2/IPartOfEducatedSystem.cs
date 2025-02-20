using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

public interface IPartOfEducatedSystem
{
    Identifier Id { get; }

    Name Name { get; }
}