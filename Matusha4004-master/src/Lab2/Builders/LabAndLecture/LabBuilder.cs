using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.LabAndLecture;

public class LabBuilder
{
    public Identifier? Id { get; protected set; }

    public Name? Name { get; protected set; }

    public Author? Author { get; protected set; }

    public Description? Description { get; protected set; }

    public LabBuilder WithName(Name name)
    {
        Name = name;
        return this;
    }

    public LabBuilder WithDescription(Description description)
    {
        Description = description;
        return this;
    }

    public MarkCriteria? MarkCriteria { get; private set; }

    public Mark? Mark { get; private set; }

    public LabBuilder WithMarkCriteria(MarkCriteria markCriteria)
    {
        MarkCriteria = markCriteria;
        return this;
    }

    public LabBuilder WithMark(Mark mark)
    {
        Mark = mark;
        return this;
    }

    public LabBuilder(Author author)
    {
        Author = author;
    }

    public ILabwork Build()
    {
        var labWorkForReturn = new Labwork(
            new Identifier(Guid.NewGuid()),
            Description ?? throw new NullReferenceException(),
            Name ?? throw new NullReferenceException(),
            MarkCriteria ?? throw new NullReferenceException(),
            Mark ?? throw new NullReferenceException(),
            Author ?? throw new NullReferenceException());

        Author.AppendWork(labWorkForReturn);
        return labWorkForReturn;
    }
}