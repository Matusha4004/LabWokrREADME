using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeListInnerHandler;

public interface ITreeListInnerHandler
{
    ITreeListInnerHandler AddNext(ITreeListInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, ITreeListBuilder treeGoToBuilder);
}