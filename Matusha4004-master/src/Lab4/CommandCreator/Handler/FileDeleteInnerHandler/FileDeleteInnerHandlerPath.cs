using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileDeleteInnerHandler;

public class FileDeleteInnerHandlerPath : FileDeleteInnerHandlerBase
{
    public override void HandleCommand(int i, string[] lanesWithCommands, IFileDeleteBuilder builder)
    {
        if (!Directory.Exists(lanesWithCommands[i]))
        {
            Next?.HandleCommand(i, lanesWithCommands, builder);
            return;
        }

        builder.WithPath(lanesWithCommands[i]);
    }
}