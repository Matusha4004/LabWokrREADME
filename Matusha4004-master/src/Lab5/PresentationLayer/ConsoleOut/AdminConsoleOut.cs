using Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.ConsoleOut;

public class AdminConsoleOut : IConsoleOut
{
    public static string AdminPassword { get; private set; } = "admin123";

    private readonly IAccountService _accountService;

    public AdminConsoleOut(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public void Run()
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What type of user?:")
                .AddChoices("Create new basic user", "Exit"));

        switch (choice)
        {
            case "Create new basic user":
            {
                string number = AnsiConsole.Ask<string>("Enter number: ");
                string pin = AnsiConsole.Ask<string>("Enter pin: ");
                _accountService.AddNewAccount(number, pin);
                break;
            }

            case "Exit":
            {
                return;
            }
        }
    }
}