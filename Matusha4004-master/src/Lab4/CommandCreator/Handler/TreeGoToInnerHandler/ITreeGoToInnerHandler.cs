using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeGoToInnerHandler;

public interface ITreeGoToInnerHandler
{
    ITreeGoToInnerHandler AddNext(ITreeGoToInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, ITreeGoToBuilder treeGoToBuilder);
}