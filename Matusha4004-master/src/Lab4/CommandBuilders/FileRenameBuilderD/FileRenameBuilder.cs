using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

public class FileRenameBuilder : IFileRenameBuilder
{
    private IFileSystem? _fileSystem;
    private string? _fileName;
    private string? _path;

    public IFileRenameBuilder WithSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public IFileRenameBuilder WithName(string name)
    {
        _fileName = name;
        return this;
    }

    public IFileRenameBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ICommand Build()
    {
        return new FileRenameCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _fileName ?? throw new NullReferenceException(),
            _path ?? throw new NullReferenceException());
    }
}