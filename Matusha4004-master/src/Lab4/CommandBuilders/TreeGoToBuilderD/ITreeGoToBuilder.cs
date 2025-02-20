using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeGoToBuilderD;

public interface ITreeGoToBuilder
{
    ITreeGoToBuilder WithSystem(IFileSystem fileSystem);

    ITreeGoToBuilder WithPath(string path);

    TreeGoToCommand Build();
}