using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeGoToInnerHandler;

public class GoToInnerPathHandler : TreeGoToInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, ITreeGoToBuilder treeGoToBuilder)
    {
        if (!Directory.Exists(lanesWithCommands[i]))
        {
            Next?.HandleCommand(i, lanesWithCommands, treeGoToBuilder);
            return;
        }

        treeGoToBuilder.WithPath(lanesWithCommands[i]);
    }
}