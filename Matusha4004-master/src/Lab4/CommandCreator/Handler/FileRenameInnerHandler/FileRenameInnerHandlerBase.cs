using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileRenameInnerHandler;

public abstract class FileRenameInnerHandlerBase : IFileRenameInnerHandler
{
    protected IFileRenameInnerHandler? Next { get; private set; }

    public IFileRenameInnerHandler AddNext(IFileRenameInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, IFileRenameBuilder builder);
}