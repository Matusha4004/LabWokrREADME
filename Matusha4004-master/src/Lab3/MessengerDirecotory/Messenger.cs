namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerDirecotory;

public class Messenger : IMessenger
{
    public void TakeMessage(string message)
    {
        Console.WriteLine("Messenger:" + message);
    }
}