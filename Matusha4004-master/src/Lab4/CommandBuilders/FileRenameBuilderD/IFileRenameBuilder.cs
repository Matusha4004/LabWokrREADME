using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileRenameBuilderD;

public interface IFileRenameBuilder
{
    IFileRenameBuilder WithSystem(IFileSystem fileSystem);

    IFileRenameBuilder WithName(string name);

    IFileRenameBuilder WithPath(string path);

    ICommand Build();
}