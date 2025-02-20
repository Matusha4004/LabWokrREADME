using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileRenameInnerHandler;

public class FileRenameInnerHandlerName : FileRenameInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, IFileRenameBuilder builder)
    {
        if (i != 3)
        {
            Next?.HandleCommand(i, lanesWithCommands, builder);
        }

        builder.WithName(lanesWithCommands[i]);
    }
}