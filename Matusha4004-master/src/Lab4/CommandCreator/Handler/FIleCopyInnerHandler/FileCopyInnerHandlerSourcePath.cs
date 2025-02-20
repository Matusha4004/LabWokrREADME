using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FIleCopyInnerHandler;

public class FileCopyInnerHandlerSourcePath : FileCopyInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, IFileCopyBuilder builder)
    {
        if (i != 3 || !Directory.Exists(lanesWithCommands[i]))
        {
            Next?.HandleCommand(i, lanesWithCommands, builder);
        }

        builder.WithSourcePath(lanesWithCommands[i]);
    }
}