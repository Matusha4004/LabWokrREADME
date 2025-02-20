using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;

public class TreeListBuilder : ITreeListBuilder
{
    private int? _depth;

    private IFileSystem? _fileSystem;

    public ITreeListBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ITreeListBuilder WithSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public ICommand Build()
    {
        return new TreeListCommand(
            _fileSystem ?? throw new NullReferenceException("File System is null."),
            _depth ?? throw new NullReferenceException("Depth is null."));
    }
}