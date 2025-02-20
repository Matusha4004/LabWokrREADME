using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileMoveInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class FileMoveHandler : FileHandlerBase
{
    private readonly IFileMoveInnerHandler _innerHandler;

    public FileMoveHandler(IFileMoveInnerHandler handler)
    {
        _innerHandler = handler;
    }

    public override ICommand? HandleCommand(int i, string[] lanesWithCommands, IFileSystem fileSystem)
    {
        string[] command = lanesWithCommands[i].Split(" ");

        if (command.Length < 3)
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        if (command[0] != "file" || command[1] != "move")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new FileMoveBuilder();
        builder.WithFileSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}