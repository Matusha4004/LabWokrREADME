using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;

public class FileShowInnerHandlerPath : FileShowInnerHandlerBase
{
    public override void HandleCommand(int i, string[] command, IFileShowBuilder builder)
    {
        if (!Directory.Exists(command[i]))
        {
            Next?.HandleCommand(i, command, builder);
            return;
        }

        builder.WithPath(command[i]);
    }
}