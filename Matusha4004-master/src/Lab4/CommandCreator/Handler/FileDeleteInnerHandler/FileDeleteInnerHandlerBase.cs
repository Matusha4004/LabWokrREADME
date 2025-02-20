using Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileDeleteInnerHandler;

public abstract class FileDeleteInnerHandlerBase : IFileDeleteInnerHandler
{
    protected IFileDeleteInnerHandler? Next { get; private set; }

    public IFileDeleteInnerHandler AddNext(IFileDeleteInnerHandler handler)
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

    public abstract void HandleCommand(int i, string[] lanesWithCommands, IFileDeleteBuilder builder);
}