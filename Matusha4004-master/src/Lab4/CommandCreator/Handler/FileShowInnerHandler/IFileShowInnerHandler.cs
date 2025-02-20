using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;

public interface IFileShowInnerHandler
{
    IFileShowInnerHandler AddNext(IFileShowInnerHandler handler);

    void HandleCommand(int i, string[] command, IFileShowBuilder builder);
}