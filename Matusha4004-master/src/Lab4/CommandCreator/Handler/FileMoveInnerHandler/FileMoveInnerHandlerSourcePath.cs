using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileMoveInnerHandler;

public class FileMoveInnerHandlerSourcePath : FileMoveInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, IFileMoveBuilder builder)
    {
        if (i != 3 || !Directory.Exists(lanesWithCommands[i]))
        {
            Next?.HandleCommand(i, lanesWithCommands, builder);
        }

        builder.WithSourcePath(lanesWithCommands[i]);
    }
}