using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

public class FileShowBuilder : IFileShowBuilder
{
    private IFileSystem? _fileSystem;
    private string? _path;
    private string? _mode;

    public IFileShowBuilder WithSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public IFileShowBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public IFileShowBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ICommand Build()
    {
        return new FileShowCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _path ?? throw new NullReferenceException(),
            _mode);
    }
}