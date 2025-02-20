using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator;

public interface ICommandRunner
{
    ICommand? Run(string[] args);
}