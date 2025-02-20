using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileMoveInnerHandler;

public interface IFileMoveInnerHandler
{
    IFileMoveInnerHandler AddNext(IFileMoveInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, IFileMoveBuilder builder);
}