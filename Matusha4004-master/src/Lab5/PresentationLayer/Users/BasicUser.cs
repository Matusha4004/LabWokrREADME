namespace Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.Users;

public class BasicUser : IUser
{
    public string Number { get; init; }

    public string Pin { get; init; }

    public BasicUser(string number, string pin)
    {
        Number = number;
        Pin = pin;
    }
}