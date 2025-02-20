using Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;
using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.Users;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.ConsoleOut;

public class BasicUserConsoleOut : IConsoleOut
{
    private readonly IAccountService _accountService;
    private readonly BasicUser _user;

    public BasicUserConsoleOut(IAccountService accountService, BasicUser user)
    {
        _accountService = accountService;
        _user = user;
    }

    public void Run()
    {
        while (true)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an action:")
                    .AddChoices("View Balance", "Withdraw", "Deposit", "View Transaction History", "Exit"));

            switch (choice)
            {
                case "View Balance":
                    ViewBalance();
                    break;
                case "Withdraw":
                    Withdraw();
                    break;
                case "Deposit":
                    Deposit();
                    break;
                case "View Transaction History":
                    ViewTransactionHistory();
                    break;
                case "Exit":
                    return;
            }
        }
    }

    private void ViewBalance()
    {
        ResultOfAccountService result = _accountService.GetBalance(_user.Number, _user.Pin);
        if (result is ResultOfAccountService.SuccessWithBalance success)
        {
            AnsiConsole.WriteLine($"Your balance: {success.Balance}");
        }
        else if (result is ResultOfAccountService.Failure failure)
        {
            AnsiConsole.WriteLine($"Error: {failure.Reason}");
        }
    }

    private void Withdraw()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to withdraw:");

        ResultOfAccountService result = _accountService.Withdraw(_user.Number, _user.Pin, amount);
        if (result is ResultOfAccountService.Success)
        {
            AnsiConsole.WriteLine("Withdrawal successful.");
        }
        else if (result is ResultOfAccountService.Failure failure)
        {
            AnsiConsole.WriteLine($"Error: {failure.Reason}");
        }
    }

    private void Deposit()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to deposit:");

        ResultOfAccountService result = _accountService.Deposit(_user.Number, _user.Pin, amount);
        if (result is ResultOfAccountService.Success)
        {
            AnsiConsole.WriteLine("Deposit successful.");
        }
        else if (result is ResultOfAccountService.Failure failure)
        {
            AnsiConsole.WriteLine($"Error: {failure.Reason}");
        }
    }

    private void ViewTransactionHistory()
    {
        ResultOfAccountService result = _accountService.GetTransactionHistory(_user.Number, _user.Pin);
        if (result is ResultOfAccountService.SuccessWithHistory success)
        {
            foreach (Core.Model.TransitionOperation transaction in success.Transitions)
            {
                AnsiConsole.WriteLine($"{transaction.Id}: {transaction.Type} {transaction.Amount}");
            }
        }
        else if (result is ResultOfAccountService.Failure failure)
        {
            AnsiConsole.WriteLine($"Error: {failure.Reason}");
        }
    }
}