using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileDeleteInnerHandler;

public interface IFileDeleteInnerHandler
{
    IFileDeleteInnerHandler AddNext(IFileDeleteInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, IFileDeleteBuilder builder);
}