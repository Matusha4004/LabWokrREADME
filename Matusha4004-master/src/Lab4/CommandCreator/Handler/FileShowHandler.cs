using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class FileShowHandler : FileHandlerBase
{
    private readonly IFileShowInnerHandler _innerHandler;

    public FileShowHandler(IFileShowInnerHandler innerHandler)
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

        if (command[0] != "file" || command[1] != "show")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new FileShowBuilder();
        builder.WithSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}