using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransitionRepository _transactionRepository;

    public AccountService(IAccountRepository accountRepository, ITransitionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public ResultOfAccountService GetBalance(string number, string pin)
    {
        Account? account = _accountRepository.GetAccount(number, pin);
        if (account == null)
        {
            return new ResultOfAccountService.Failure("Incorrect account");
        }

        return new ResultOfAccountService.SuccessWithBalance(account.Balance);
    }

    public ResultOfAccountService Withdraw(string number, string pin, decimal amount)
    {
        Account? account = _accountRepository.GetAccount(number, pin);
        if (account == null)
        {
            return new ResultOfAccountService.Failure("Incorrect account");
        }

        if (account.Balance < amount)
            return new ResultOfAccountService.Failure("Insufficient balance");

        account = account with { Balance = account.Balance - amount };

        _accountRepository.UpdateAccount(account);

        _transactionRepository.AddTransaction(new TransitionOperation(Guid.NewGuid(), account.Id, amount, "withdraw"));
        return new ResultOfAccountService.Success();
    }

    public ResultOfAccountService Deposit(string number, string pin, decimal amount)
    {
        Account? account = _accountRepository.GetAccount(number, pin);
        if (account == null)
        {
            return new ResultOfAccountService.Failure("Incorrect account");
        }

        account = account with { Balance = account.Balance + amount };
        _accountRepository.UpdateAccount(account);

        _transactionRepository.AddTransaction(new TransitionOperation(Guid.NewGuid(), account.Id, amount, "deposit"));
        return new ResultOfAccountService.Success();
    }

    public ResultOfAccountService GetTransactionHistory(string number, string pin)
    {
        Account? account = _accountRepository.GetAccount(number, pin);
        if (account == null)
        {
            return new ResultOfAccountService.Failure("Incorrect account");
        }

        return new ResultOfAccountService.SuccessWithHistory(_transactionRepository.GetTransactions(account.Id));
    }

    public ResultOfAccountService AddNewAccount(string number, string pin)
    {
        var newAccaunt = new Account(Guid.NewGuid(), number, 0, pin);
        _accountRepository.AddAccount(newAccaunt);
        return new ResultOfAccountService.Success();
    }
}