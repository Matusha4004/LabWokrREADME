using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CompositeBuilder
{
    public IEnumerable<IAddressee> Addresses { get; private set; } = new List<IAddressee>();

    public CompositeBuilder AddAddressee(IAddressee addressee)
    {
        Addresses = Addresses.Append(addressee);
        return this;
    }

    public CompositeBuilder WithAddresses(IEnumerable<IAddressee> addresses)
    {
        Addresses = addresses;
        return this;
    }

    public AddresseeComposite Build()
    {
        return new AddresseeComposite(Addresses);
    }
}