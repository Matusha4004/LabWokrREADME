using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Author
{
    public void AppendWork(IPartOfEducatedSystem work)
    {
        AuthorOfPartOfEducationalProgram = AuthorOfPartOfEducationalProgram.Append(work);
    }

    public IEnumerable<IPartOfEducatedSystem> AuthorOfPartOfEducationalProgram { get; private set; } = new List<IPartOfEducatedSystem>();

    public Identifier Id { get; init; }

    public Name AuthorName { get; init; }

    public Author(Name name)
    {
        Id = new Identifier(Guid.NewGuid());
        AuthorName = name;
    }
}