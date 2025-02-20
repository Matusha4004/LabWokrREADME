namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    IFileSystem FileSystem { get; }

    ResultOfComplitingCommand CommandUse();
}