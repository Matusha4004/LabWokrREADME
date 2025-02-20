using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FIleCopyInnerHandler;

public abstract class FileCopyInnerHandlerBase : IFileCopyInnerHandler
{
    protected IFileCopyInnerHandler? Next { get; private set; }

    public IFileCopyInnerHandler AddNext(IFileCopyInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, IFileCopyBuilder builder);
}