using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.FileShowBuilderD;

public interface IFileShowBuilder
{
    IFileShowBuilder WithSystem(IFileSystem fileSystem);

    IFileShowBuilder WithPath(string path);

    IFileShowBuilder WithMode(string mode);

    ICommand Build();
}