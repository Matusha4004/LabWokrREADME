namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(IFileSystem fileSystem, string path)
    {
        FileSystem = fileSystem;
        _path = path;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        FileSystem.TreeGoTo(_path);
        return new ResultOfComplitingCommand.EmptySuccess();
    }
}