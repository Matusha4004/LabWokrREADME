using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeGoToInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class TreeGoToHandler : FileHandlerBase
{
    private readonly ITreeGoToInnerHandler _innerHandler;

    public TreeGoToHandler(ITreeGoToInnerHandler innerHandler)
    {
        _innerHandler = innerHandler;
    }

    public override ICommand? HandleCommand(int i, string[] lanesWithCommands, IFileSystem fileSystem)
    {
        string[] command = lanesWithCommands[i].Split(" ");

        if (command.Length < 2)
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        if (command[0] != "tree" || command[1] != "goto")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new TreeGoToBuilder();
        builder.WithSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}