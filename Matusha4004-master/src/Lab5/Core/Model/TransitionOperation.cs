namespace Itmo.ObjectOrientedProgramming.Lab5.Core.Model;

public record TransitionOperation(Guid Id, Guid AccountId, decimal Amount, string Type);