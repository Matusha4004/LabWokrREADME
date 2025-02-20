using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.LabAndLecture;

public class LectureBuilder
{
    public Identifier? Id { get; protected set; }

    public Name? Name { get; protected set; }

    public Author? Author { get; protected set; }

    public Description? Description { get; protected set; }

    public LectureBuilder WithName(Name name)
    {
        Name = name;
        return this;
    }

    public LectureBuilder WithDescription(Description description)
    {
        Description = description;
        return this;
    }

    public Content? Content { get; private set; }

    public LectureBuilder WithContent(Content content)
    {
        Content = content;
        return this;
    }

    public LectureBuilder(Author author)
    {
        Author = author;
    }

    public ILecture Build()
    {
        var lecture = new Lecture(
            new Identifier(Guid.NewGuid()),
            Name ?? throw new NullReferenceException(),
            Description ?? throw new NullReferenceException(),
            Content ?? throw new NullReferenceException(),
            Author ?? throw new NullReferenceException());

        Author.AppendWork(lecture);
        return lecture;
    }
}