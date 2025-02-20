using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileCopyBuilderD;

public interface IFileCopyBuilder
{
    IFileCopyBuilder WithFileSystem(IFileSystem fileSystem);

    IFileCopyBuilder WithSourcePath(string sourcePath);

    IFileCopyBuilder WithDestinationPath(string destinationPath);

    ICommand Build();
}