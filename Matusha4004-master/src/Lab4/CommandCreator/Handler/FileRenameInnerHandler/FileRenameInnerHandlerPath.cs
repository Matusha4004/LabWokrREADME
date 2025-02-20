using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileRenameInnerHandler;

public class FileRenameInnerHandlerPath : FileRenameInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, IFileRenameBuilder builder)
    {
        if (!Directory.Exists(lanesWithCommands[i]))
        {
            Next?.HandleCommand(i, lanesWithCommands, builder);
        }

        builder.WithPath(lanesWithCommands[i]);
    }
}