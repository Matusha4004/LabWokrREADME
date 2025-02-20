using Itmo.ObjectOrientedProgramming.Lab3.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserDirectory;

public class User : IUser
{
    public IEnumerable<KeyValuePair<Message, IsRad>> RadMessages { get; private set; } = new List<KeyValuePair<Message, IsRad>>();

    public CheckMessageResult CheckMessage(Message message)
    {
        foreach (KeyValuePair<Message, IsRad> radMessage in RadMessages)
        {
            if (radMessage.Key == message && !radMessage.Value.Value)
            {
                radMessage.Value.Switch();
                return new CheckMessageResult.Success();
            }
            else if (radMessage.Value.Value)
            {
                return new CheckMessageResult.FailMessageIsBeenChecked();
            }
        }

        return new CheckMessageResult.FailMessageNotForThisUser();
    }

    public void TakeMessage(Message message)
    {
        RadMessages = RadMessages.Append(new KeyValuePair<Message, IsRad>(message, new IsRad()));
    }
}