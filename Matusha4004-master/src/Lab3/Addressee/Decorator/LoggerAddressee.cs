using Itmo.ObjectOrientedProgramming.Lab3.LogsForAddressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Decorator;

public class LoggerAddressee : IAddressee
{
    public IAddresseeLogger Logs { get; init; }

    public IAddressee Addressee { get; init; }

    public LoggerAddressee(IAddressee addressee, IAddresseeLogger logs)
    {
        Addressee = addressee;
        Logs = logs;
    }

    public void TakeMessage(Message message)
    {
        Addressee.TakeMessage(message);
        Logs.Log(message.Body.Value);
    }
}