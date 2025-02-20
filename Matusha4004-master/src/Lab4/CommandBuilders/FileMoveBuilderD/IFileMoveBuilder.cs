using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileMoveBuilderD;

public interface IFileMoveBuilder
{
    IFileMoveBuilder WithFileSystem(IFileSystem fileSystem);

    IFileMoveBuilder WithSourcePath(string sourcePath);

    IFileMoveBuilder WithDestinationPath(string destinationPath);

    ICommand Build();
}