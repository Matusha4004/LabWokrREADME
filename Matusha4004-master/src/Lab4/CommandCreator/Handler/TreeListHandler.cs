using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeListInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class TreeListHandler : FileHandlerBase
{
    private readonly ITreeListInnerHandler _innerHandler;

    public TreeListHandler(ITreeListInnerHandler innerHandler)
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

        if (command[0] != "tree" || command[1] != "list")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new TreeListBuilder();
        builder.WithSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}