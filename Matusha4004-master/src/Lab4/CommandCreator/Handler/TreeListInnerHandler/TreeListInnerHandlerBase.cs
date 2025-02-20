using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeListInnerHandler;

public abstract class TreeListInnerHandlerBase : ITreeListInnerHandler
{
    protected ITreeListInnerHandler? Next { get; private set; }

    public ITreeListInnerHandler AddNext(ITreeListInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, ITreeListBuilder treeGoToBuilder);
}