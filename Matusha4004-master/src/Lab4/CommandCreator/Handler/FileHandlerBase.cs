using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;

public abstract class FileHandlerBase : ICommandHandler
{
    protected ICommandHandler? Next { get; private set; }

    public ICommandHandler AddNext(ICommandHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? HandleCommand(int i, string[] lanesWithCommands, IFileSystem fileSystem);
}