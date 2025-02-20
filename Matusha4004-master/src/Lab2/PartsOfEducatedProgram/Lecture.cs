using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;

public class Lecture : ILecture, IClone<Lecture>
{
    public Identifier Id { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public Content Content { get; private set; }

    public Author Author { get; private set; }

    public Identifier? IdentifierMother { get; private set; }

    public Lecture(Identifier id, Name name, Description description, Content content, Author author, Identifier? identifierMother = null)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
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
        else if (objectCanBeChanged is Content content)
        {
            Content = content;
            return new ResultOfChangingPartOfEducationalProgram.Success();
        }
        else if (objectCanBeChanged is Description description)
        {
            Description = description;
            return new ResultOfChangingPartOfEducationalProgram.Success();
        }

        return new ResultOfChangingPartOfEducationalProgram.FailureFailInChangingPart();
    }

    public Lecture Clone(Author newAuthor)
    {
        var clone = (Lecture)MemberwiseClone();
        clone.Author = newAuthor;
        clone.Id = new Identifier(Guid.NewGuid());
        clone.IdentifierMother = Id;
        newAuthor.AppendWork(clone);
        return clone;
    }
}