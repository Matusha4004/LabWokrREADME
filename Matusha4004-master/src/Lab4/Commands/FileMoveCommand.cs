namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _oldFilePath;

    private readonly string _newFilePath;

    public FileMoveCommand(IFileSystem fileSystem, string oldFilePath, string newFilePath)
    {
        _oldFilePath = oldFilePath;
        _newFilePath = newFilePath;
        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        FileSystem.FileMove(_oldFilePath, _newFilePath);
        return new ResultOfComplitingCommand.EmptySuccess();
    }
}