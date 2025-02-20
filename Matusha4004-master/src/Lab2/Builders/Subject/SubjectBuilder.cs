using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Subject;

public abstract class SubjectBuilder
{
    public Identifier? Id { get; protected set; }

    public Name? Name { get; protected set; }

    public Author? Author { get; protected set; }

    public IEnumerable<Labwork> LabWorks { get; protected set; } = new List<Labwork>();

    public IEnumerable<Lecture> LectureMaterials { get; protected set; } = new List<Lecture>();

    public SubjectBuilder WithLabWorks(IEnumerable<Labwork> labWorks)
    {
        LabWorks = labWorks;
        return this;
    }

    public SubjectBuilder AddLabWork(Labwork labWork)
    {
        LabWorks = LabWorks.Append(labWork);
        return this;
    }

    public SubjectBuilder WithLectures(IEnumerable<Lecture> lectureMaterials)
    {
        LectureMaterials = lectureMaterials;
        return this;
    }

    public SubjectBuilder AddLecture(Lecture lectureMaterial)
    {
        LectureMaterials = LectureMaterials.Append(lectureMaterial);
        return this;
    }

    public SubjectBuilder WithName(Name name)
    {
        Name = name;
        return this;
    }

    public abstract ISubject Build();

    public ResultOfCreatingEducatedProgram? ResultOfCreating { get; protected set; }
}