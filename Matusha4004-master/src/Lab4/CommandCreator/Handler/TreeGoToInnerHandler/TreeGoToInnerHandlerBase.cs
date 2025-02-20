using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeGoToInnerHandler;

public abstract class TreeGoToInnerHandlerBase : ITreeGoToInnerHandler
{
    protected ITreeGoToInnerHandler? Next { get; private set; }

    public ITreeGoToInnerHandler AddNext(ITreeGoToInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, ITreeGoToBuilder treeGoToBuilder);
}