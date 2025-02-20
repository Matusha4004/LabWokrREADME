using Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;
using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.ConsoleOut;
using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.Users;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer;

public class ConnectionWithConsoleOut : IConnectionWithConsole
{
    private readonly IAccountService _accountService;

    private IUser? _user = null;

    private IConsoleOut? _consoleOut = null;

    public ConnectionWithConsoleOut(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public void Run()
    {
        while (true)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What type of user?:")
                    .AddChoices("Basic User", "Admin", "Exit"));

            switch (choice)
            {
                case "Basic User":
                    string number = AnsiConsole.Ask<string>("Enter number of account:");
                    string pin = AnsiConsole.Ask<string>("Enter PIN:");
                    _user = new BasicUser(number, pin);
                    _consoleOut = new BasicUserConsoleOut(_accountService, (BasicUser)_user);
                    _consoleOut.Run();
                    break;
                case "Admin":
                    string password = AnsiConsole.Ask<string>("Enter admin password:");
                    if (password == AdminConsoleOut.AdminPassword)
                    {
                        _consoleOut = new AdminConsoleOut(_accountService);
                        _consoleOut.Run();
                    }
                    else
                    {
                        AnsiConsole.WriteLine("Incorrect password. Exiting...");
                        return;
                    }

                    break;
                case "Exit":
                {
                    return;
                }
            }
        }
    }
}