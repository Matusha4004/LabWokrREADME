namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(IFileSystem fileSystem, int depth = 1)
    {
        _depth = depth;

        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        return new ResultOfComplitingCommand.SuccessWithStrings(FileSystem.TreeList(_depth));
    }
}