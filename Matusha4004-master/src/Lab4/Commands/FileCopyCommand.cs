namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _oldFilePath;

    private readonly string _newFilePath;

    public FileCopyCommand(IFileSystem fileSystem, string oldFilePath, string newFilePath)
    {
        FileSystem = fileSystem;
        _oldFilePath = oldFilePath;
        _newFilePath = newFilePath;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        FileSystem.FileCopy(_oldFilePath, _newFilePath);
        return new ResultOfComplitingCommand.EmptySuccess();
    }
}