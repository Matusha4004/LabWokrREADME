using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FIleCopyInnerHandler;

public interface IFileCopyInnerHandler
{
    IFileCopyInnerHandler AddNext(IFileCopyInnerHandler handler);

    void HandleCommand(int i, string[] lanesWithCommands, IFileCopyBuilder builder);
}