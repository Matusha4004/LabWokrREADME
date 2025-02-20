using Itmo.ObjectOrientedProgramming.Lab3.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDirectory;

public interface IUser
{
    public IEnumerable<KeyValuePair<Message, IsRad>> RadMessages { get; }

    public CheckMessageResult CheckMessage(Message message);

    public void TakeMessage(Message message);
}