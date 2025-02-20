namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;

    private readonly string? _mode;

    public FileShowCommand(IFileSystem fileSystem, string path, string? mode = null)
    {
        FileSystem = fileSystem;
        _path = path;
        _mode = mode;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        return new ResultOfComplitingCommand.SuccessWithStrings(FileSystem.FileShow(_path, _mode));
    }
}