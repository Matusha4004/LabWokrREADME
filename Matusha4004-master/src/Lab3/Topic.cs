using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    public Name Name { get; init; }

    public IEnumerable<IAddressee> Addressees { get; init; }

    public void TakeMessage(Message message)
    {
        foreach (IAddressee addressee in Addressees)
        {
            addressee.TakeMessage(message);
        }
    }

    public Topic(Name name, IEnumerable<IAddressee> addressees)
    {
        Name = name;
        Addressees = addressees;
    }
}