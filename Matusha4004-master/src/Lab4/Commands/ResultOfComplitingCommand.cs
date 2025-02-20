namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public record ResultOfComplitingCommand
{
    private ResultOfComplitingCommand() { }

    public sealed record EmptySuccess : ResultOfComplitingCommand;

    public sealed record Failure : ResultOfComplitingCommand;

    public sealed record SuccessWithStrings(string[] Strings) : ResultOfComplitingCommand;
}