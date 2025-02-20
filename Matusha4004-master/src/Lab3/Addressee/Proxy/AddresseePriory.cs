using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Proxy;

public class AddresseePriory : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly Priority _priority;

    public AddresseePriory(IAddressee addressee, Priority priority)
    {
        _addressee = addressee;
        _priority = priority;
    }

    public void TakeMessage(Message message)
    {
        if (_priority < message.Priority)
            _addressee.TakeMessage(message);
    }
}