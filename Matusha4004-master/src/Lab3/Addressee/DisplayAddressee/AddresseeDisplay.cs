using Itmo.ObjectOrientedProgramming.Lab3.DisplayDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.DisplayAddressee;

public class AddresseeDisplay : IAddressee
{
    public IDisplay Display { get; init; }

    public void TakeMessage(Message message)
    {
        Display.TakeMessage(message.Body.Value);
    }

    public AddresseeDisplay(IDisplay display)
    {
        Display = display;
    }
}