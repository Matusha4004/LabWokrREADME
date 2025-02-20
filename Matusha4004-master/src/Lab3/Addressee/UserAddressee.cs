using Itmo.ObjectOrientedProgramming.Lab3.UserDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class UserAddressee : IAddressee
{
    public IUser User { get; init; }

    public void TakeMessage(Message message)
    {
        User.TakeMessage(message);
    }

    public UserAddressee(IUser user)
    {
        User = user;
    }
}