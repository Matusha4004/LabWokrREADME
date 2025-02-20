using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandBuilders.TreeListBuilderD;

public interface ITreeListBuilder
{
    ITreeListBuilder WithDepth(int depth);

    ITreeListBuilder WithSystem(IFileSystem fileSystem);

    ICommand Build();
}