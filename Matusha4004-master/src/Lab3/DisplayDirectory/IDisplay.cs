namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDirectory;

public interface IDisplay
{
    DisplayDriver Driver { get; }

    void TakeMessage(string message);
}