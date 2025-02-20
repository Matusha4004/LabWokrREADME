using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;

namespace Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;

public interface IAccountRepository
{
    Account? GetAccount(string number, string pin);

    void AddAccount(Account account);

    void UpdateAccount(Account account);
}