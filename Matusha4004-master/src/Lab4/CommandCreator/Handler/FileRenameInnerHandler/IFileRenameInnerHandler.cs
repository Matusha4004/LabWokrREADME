using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileRenameInnerHandler;

public interface IFileRenameInnerHandler
{
    IFileRenameInnerHandler AddNext(IFileRenameInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, IFileRenameBuilder builder);
}