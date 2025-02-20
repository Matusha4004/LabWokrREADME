using Itmo.ObjectOrientedProgramming.Lab3.MessengerDirecotory;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.MessengerAddressee;

public class AddresseeMessenger : IAddressee
{
    public IMessenger Messenger { get; init; }

    public void TakeMessage(Message message)
    {
        Messenger.TakeMessage(message.Body.Value);
    }

    public AddresseeMessenger(IMessenger messenger)
    {
        Messenger = messenger;
    }
}