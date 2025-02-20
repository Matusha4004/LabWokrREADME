namespace Itmo.ObjectOrientedProgramming.Lab3.LogsForAddressee;

public class AddresseeLogger : IAddresseeLogger
{
    public IEnumerable<string> Logs { get; private set; } = new List<string>();

    public void Log(string message)
    {
        Logs = Logs.Append(message);
    }
}