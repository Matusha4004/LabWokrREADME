using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler handler);

    ICommand? HandleCommand(int i, string[] lanesWithCommands, IFileSystem fileSystem);
}