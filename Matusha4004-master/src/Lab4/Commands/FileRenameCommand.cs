namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _newFileName;

    private readonly string _path;

    public FileRenameCommand(IFileSystem fileSystem, string newFileName, string path)
    {
        _newFileName = newFileName;
        _path = path;
        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; init; }

    public ResultOfComplitingCommand CommandUse()
    {
        FileSystem.FileRename(_path, _newFileName);
        return new ResultOfComplitingCommand.EmptySuccess();
    }
}