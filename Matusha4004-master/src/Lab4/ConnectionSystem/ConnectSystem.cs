using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConnectionSystem;

public class ConnectSystem
{
    private IFileSystem? _fileSystem;
    private CommandRunner? _commandRunner;

    public string[]? ExecuteCommand(string commandString)
    {
        string[] commandParts = commandString.Split(" ");
        if (commandParts[0] == "connect")
        {
            Connect(commandString);
            return null;
        }

        if (commandParts[0] == "disconnect")
        {
            Disconnect();
            return null;
        }

        ICommand? command = null;
        if (_commandRunner != null)
        {
            command = _commandRunner.Run(commandParts);
        }

        ResultOfComplitingCommand? result = command?.CommandUse();
        if (result is ResultOfComplitingCommand.SuccessWithStrings success)
        {
            return success.Strings;
        }

        return null;
    }

    private void Disconnect()
    {
        _fileSystem = null;
        _commandRunner = null;
    }

    private void Connect(string commandString)
    {
        string[] commands = commandString.Split(" ");

        if (commands[4] == "local")
        {
            _fileSystem = new LocalFileSystem(commands[1]);
            _commandRunner = new CommandRunner(_fileSystem);
        }
    }
}