namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;

    public FileDeleteCommand(IFileSystem fileSystem, string filePath)
    {
        _filePath = filePath;
        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        FileSystem.FileDelete(_filePath);
        return new ResultOfComplitingCommand.EmptySuccess();
    }
}