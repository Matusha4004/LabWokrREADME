using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;

namespace Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;

public interface ITransitionRepository
{
    void AddTransaction(TransitionOperation transaction);

    IEnumerable<TransitionOperation> GetTransactions(Guid accountId);
}
