using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;

public class FileDeleteBuilder : IFileDeleteBuilder
{
    private IFileSystem? _fileSystem;
    private string? _path;

    public IFileDeleteBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public IFileDeleteBuilder WithSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public ICommand Build()
    {
        return new FileDeleteCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _path ?? throw new NullReferenceException());
    }
}