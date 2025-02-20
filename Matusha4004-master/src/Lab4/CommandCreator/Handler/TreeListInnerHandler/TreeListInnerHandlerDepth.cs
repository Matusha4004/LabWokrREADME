using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeListInnerHandler;

public class TreeListInnerHandlerDepth : TreeListInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, ITreeListBuilder treeGoToBuilder)
    {
        if (lanesWithCommands[i] != "-d" || i >= lanesWithCommands.Length - 1)
        {
            Next?.HandleCommand(i, lanesWithCommands, treeGoToBuilder);
            return;
        }

        treeGoToBuilder.WithDepth(Convert.ToInt32(lanesWithCommands[i + 1]));
    }
}