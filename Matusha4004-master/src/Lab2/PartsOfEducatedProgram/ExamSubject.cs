using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;

public class ExamSubject : ISubject, IClone<ExamSubject>
{
    public Identifier Id { get; private set; }

    public Name Name { get; private set; }

    public IEnumerable<Labwork> LabWorks { get; init; }

    public IEnumerable<Lecture> Materials { get; private set; }

    public Mark MarkForExam { get; init; }

    public Identifier? IdentifierMother { get; private set; }

    public Author Author { get; private set; }

    public ExamSubject(Identifier id, Name name, IEnumerable<Labwork> labWorks, IEnumerable<Lecture> materials, Mark markForExam, Author user, Identifier? identifierMother = null)
    {
        Id = id;
        Name = name;
        LabWorks = labWorks;
        Materials = materials;
        MarkForExam = markForExam;
        Author = user;
        IdentifierMother = identifierMother;
    }

    public ResultOfChangingPartOfEducationalProgram ChangeInPartOfEducationalProgram(IObjectCanBeChanged objectCanBeChanged, Author author)
    {
        if (author != Author) return new ResultOfChangingPartOfEducationalProgram.FailureDifferentAuthor();

        if (objectCanBeChanged is Name name)
        {
            Name = name;
            return new ResultOfChangingPartOfEducationalProgram.Success();
        }
        else if (objectCanBeChanged is Lecture material)
        {
            Materials = Materials.Append(material);
            return new ResultOfChangingPartOfEducationalProgram.Success();
        }

        return new ResultOfChangingPartOfEducationalProgram.FailureFailInChangingPart();
    }

    public ExamSubject Clone(Author newAuthor)
    {
        var clone = (ExamSubject)MemberwiseClone();
        clone.Author = newAuthor;
        clone.Id = new Identifier(Guid.NewGuid());
        clone.IdentifierMother = Id;
        newAuthor.AppendWork(clone);
        return clone;
    }
}