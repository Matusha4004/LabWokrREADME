using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;

public class FileMoveBuilder : IFileMoveBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;
    private IFileSystem? _fileSystem;

    public IFileMoveBuilder WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public IFileMoveBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public IFileMoveBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public ICommand Build()
    {
        return new FileMoveCommand(
            _fileSystem ?? throw new NullReferenceException(),
            _sourcePath ?? throw new NullReferenceException(),
            _destinationPath ?? throw new NullReferenceException());
    }
}