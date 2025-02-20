using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileMoveInnerHandler;

public abstract class FileMoveInnerHandlerBase : IFileMoveInnerHandler
{
    protected IFileMoveInnerHandler? Next { get; private set; }

    public IFileMoveInnerHandler AddNext(IFileMoveInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, IFileMoveBuilder builder);
}