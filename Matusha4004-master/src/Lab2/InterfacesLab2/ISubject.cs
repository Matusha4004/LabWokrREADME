using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;

namespace Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

public interface ISubject : IChangingPart, IPartOfEducatedSystem
{
    IEnumerable<Labwork> LabWorks { get; }

    IEnumerable<Lecture> Materials { get; }
}
