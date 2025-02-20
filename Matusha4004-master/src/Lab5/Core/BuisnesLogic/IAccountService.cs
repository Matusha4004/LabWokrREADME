namespace Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;

public interface IAccountService
{
    public ResultOfAccountService GetBalance(string number, string pin);

    public ResultOfAccountService Withdraw(string number, string pin, decimal amount);

    public ResultOfAccountService Deposit(string number, string pin, decimal amount);

    public ResultOfAccountService GetTransactionHistory(string number, string pin);

    public ResultOfAccountService AddNewAccount(string number, string pin);
}