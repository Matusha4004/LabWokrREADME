using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileDeleteInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class FileDeleteHandler : FileHandlerBase
{
    private readonly IFileDeleteInnerHandler _innerHandler;

    public FileDeleteHandler(IFileDeleteInnerHandler innerHandler)
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

        if (command[0] != "file" || command[1] != "delete")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new FileDeleteBuilder();
        builder.WithSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}