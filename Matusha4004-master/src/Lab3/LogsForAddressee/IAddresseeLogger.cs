namespace Itmo.ObjectOrientedProgramming.Lab3.LogsForAddressee;

public interface IAddresseeLogger
{
    IEnumerable<string> Logs { get; }

    void Log(string message);
}