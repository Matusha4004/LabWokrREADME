using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;

public class FileShowInnerHandlerMode : FileShowInnerHandlerBase
{
    public override void HandleCommand(int i, string[] command, IFileShowBuilder builder)
    {
        if (command[i] != "-m" || i >= command.Length - 1)
        {
            Next?.HandleCommand(i, command, builder);
            return;
        }

        builder.WithMode(command[i + 1]);
    }
}