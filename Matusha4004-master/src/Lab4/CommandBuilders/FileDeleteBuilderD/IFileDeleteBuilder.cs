using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileDeleteBuilderD;

public interface IFileDeleteBuilder
{
    IFileDeleteBuilder WithPath(string path);

    IFileDeleteBuilder WithSystem(IFileSystem fileSystem);

    ICommand Build();
}