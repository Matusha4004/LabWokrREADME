using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;

public abstract class FileShowInnerHandlerBase : IFileShowInnerHandler
{
    protected IFileShowInnerHandler? Next { get; private set; }

    public IFileShowInnerHandler AddNext(IFileShowInnerHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract void HandleCommand(int i, string[] command, IFileShowBuilder builder);
}