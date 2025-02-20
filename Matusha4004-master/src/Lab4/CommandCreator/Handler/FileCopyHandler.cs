using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FIleCopyInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public class FileCopyHandler : FileHandlerBase
{
    private readonly IFileCopyInnerHandler _innerHandler;

    public FileCopyHandler(IFileCopyInnerHandler innerHandler)
    {
        _innerHandler = innerHandler;
    }

    public override ICommand? HandleCommand(int i, string[] lanesWithCommands, IFileSystem fileSystem)
    {
        string[] command = lanesWithCommands[i].Split(" ");

        if (command.Length < 3)
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        if (command[0] != "file" || command[1] != "copy")
        {
            return Next?.HandleCommand(i, lanesWithCommands, fileSystem);
        }

        var builder = new FileCopyBuilder();
        builder.WithFileSystem(fileSystem);

        for (int j = 2; j < command.Length; j++)
        {
            _innerHandler.HandleCommand(j, command, builder);
        }

        return builder.Build();
    }
}