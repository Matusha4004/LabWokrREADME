using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;

public class TreeGoToBuilder : ITreeGoToBuilder
{
    private IFileSystem? _fileSystem;
    private string? _path;

    public ITreeGoToBuilder WithSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public ITreeGoToBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public TreeGoToCommand Build()
    {
        return new TreeGoToCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _path ?? throw new NullReferenceException());
    }
}