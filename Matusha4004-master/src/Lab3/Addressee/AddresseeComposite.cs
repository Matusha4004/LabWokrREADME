namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeComposite : IAddressee
{
    public IEnumerable<IAddressee> Addresses { get; private set; }

    public void TakeMessage(Message message)
    {
        foreach (IAddressee addressee in Addresses)
        {
            addressee.TakeMessage(message);
        }
    }

    public AddresseeComposite(IEnumerable<IAddressee> addresses)
    {
        Addresses = addresses;
    }
}