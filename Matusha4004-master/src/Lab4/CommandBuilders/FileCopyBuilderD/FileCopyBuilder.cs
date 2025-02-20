using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;

public class FileCopyBuilder : IFileCopyBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;
    private IFileSystem? _fileSystem;

    public IFileCopyBuilder WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public IFileCopyBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public IFileCopyBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public ICommand Build()
    {
        return new FileCopyCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _sourcePath ?? throw new NullReferenceException(),
            _destinationPath ?? throw new NullReferenceException());
    }
}