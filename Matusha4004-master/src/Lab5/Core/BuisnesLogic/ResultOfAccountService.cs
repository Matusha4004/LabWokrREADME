using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;

namespace Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;

public abstract record ResultOfAccountService
{
    private ResultOfAccountService() { }

    public sealed record Success() : ResultOfAccountService;

    public sealed record Failure(string Reason) : ResultOfAccountService;

    public sealed record SuccessWithHistory(IEnumerable<TransitionOperation> Transitions) : ResultOfAccountService;

    public sealed record SuccessWithBalance(decimal Balance) : ResultOfAccountService;
}