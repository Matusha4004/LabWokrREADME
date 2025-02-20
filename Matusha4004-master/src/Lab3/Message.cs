using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public Header Header { get; init; }

    public BodyOfMessage Body { get; init; }

    public Priority Priority { get; init; }

    public Message(Header header, BodyOfMessage body, Priority priority)
    {
        Header = header;
        Body = body;
        Priority = priority;
    }
}