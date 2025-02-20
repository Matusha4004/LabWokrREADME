using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Repository
{
    public IEnumerable<IPartOfEducatedSystem> PartsOfEducatedSystems { get; private set; } = new List<IPartOfEducatedSystem>();

    public void AddToRepository(IPartOfEducatedSystem partOfEducatedSystems)
    {
        PartsOfEducatedSystems = PartsOfEducatedSystems.Append(partOfEducatedSystems);
    }

    public IPartOfEducatedSystem GetPartOfEducatedSystem(Identifier id)
    {
        foreach (IPartOfEducatedSystem part in PartsOfEducatedSystems)
        {
            if (part.Id.Value == id.Value)
            {
                return part;
            }
        }

        throw new KeyNotFoundException();
    }
}