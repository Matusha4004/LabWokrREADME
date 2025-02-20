using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;

public class EducationProgram : IPartOfEducatedSystem
{
    public Identifier Id { get; init; }

    public Name Name { get; init; }

    public IDictionary<ISubject, NumberOfSemestr> SubjectsAndNumberOfSemesters { get; init; }

    public Name NameOfMain { get; init; }

    public EducationProgram(Identifier id, Name name, Name nameOfMain, IDictionary<ISubject, NumberOfSemestr> numberOfSemesters)
    {
        Id = id;
        Name = name;
        SubjectsAndNumberOfSemesters = numberOfSemesters;
        NameOfMain = nameOfMain;
    }
}