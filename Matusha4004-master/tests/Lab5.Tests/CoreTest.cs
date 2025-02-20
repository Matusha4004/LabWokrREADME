using Itmo.ObjectOrientedProgramming.Lab5.Core.BuisnesLogic;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Model;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class CoreTest
{
    [Fact]
    public void GetBalanceSuccess()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var account = new Account(Guid.NewGuid(), "12345", 1000, "1234");
        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns(account);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ResultOfAccountService result = service.GetBalance("12345", "1234");

        Assert.True(result is ResultOfAccountService.SuccessWithBalance);
        Assert.Equal(1000, ((ResultOfAccountService.SuccessWithBalance)result).Balance);
    }

    [Fact]
    public void GetBalanceFailure()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns((Account?)null);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ResultOfAccountService result = service.GetBalance("12345", "1234");

        Assert.True(result is ResultOfAccountService.Failure);
        Assert.Equal("Incorrect account", ((ResultOfAccountService.Failure)result).Reason);
    }

    [Fact]
    public void WithdrawSuccess()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var account = new Account(Guid.NewGuid(), "12345", 1000, "1234");
        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns(account);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ResultOfAccountService result = service.Withdraw("12345", "1234", 500);

        Assert.True(result is ResultOfAccountService.Success);
        accountRepositoryMock.Verify(r => r.UpdateAccount(It.Is<Account>(a => a.Balance == 500)), Times.Once);
        transactionRepositoryMock.Verify(r => r.AddTransaction(It.IsAny<TransitionOperation>()), Times.Once);
    }

    [Fact]
    public void WithdrawFailure()
    {
        // Arrange
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var account = new Account(Guid.NewGuid(), "12345", 100, "1234");
        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns(account);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        // Act
        ResultOfAccountService result = service.Withdraw("12345", "1234", 500);

        // Assert
        Assert.True(result is ResultOfAccountService.Failure);
        Assert.Equal("Insufficient balance", ((ResultOfAccountService.Failure)result).Reason);
        accountRepositoryMock.Verify(r => r.UpdateAccount(It.IsAny<Account>()), Times.Never);
        transactionRepositoryMock.Verify(r => r.AddTransaction(It.IsAny<TransitionOperation>()), Times.Never);
    }

    [Fact]
    public void DepositSuccess()
    {
        // Arrange
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var account = new Account(Guid.NewGuid(), "12345", 1000, "1234");
        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns(account);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        // Act
        ResultOfAccountService result = service.Deposit("12345", "1234", 500);

        // Assert
        Assert.True(result is ResultOfAccountService.Success);
        accountRepositoryMock.Verify(r => r.UpdateAccount(It.Is<Account>(a => a.Balance == 1500)), Times.Once);
        transactionRepositoryMock.Verify(r => r.AddTransaction(It.IsAny<TransitionOperation>()), Times.Once);
    }

    [Fact]
    public void GetTransactionHistorySuccess()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var accountId = Guid.NewGuid();
        var account = new Account(accountId, "12345", 1000, "1234");
        accountRepositoryMock.Setup(r => r.GetAccount("12345", "1234")).Returns(account);

        var transactions = new List<TransitionOperation>
        {
            new TransitionOperation(Guid.NewGuid(), accountId, 500, "withdraw"),
            new TransitionOperation(Guid.NewGuid(), accountId, 1000, "deposit"),
        };
        transactionRepositoryMock.Setup(r => r.GetTransactions(accountId)).Returns(transactions);

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ResultOfAccountService result = service.GetTransactionHistory("12345", "1234");

        Assert.True(result is ResultOfAccountService.SuccessWithHistory);
        Assert.Equal(2, ((ResultOfAccountService.SuccessWithHistory)result).Transitions.Count());
    }

    [Fact]
    public void AddNewAccountSuccess()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransitionRepository>();

        var service = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ResultOfAccountService result = service.AddNewAccount("12345", "1234");

        Assert.True(result is ResultOfAccountService.Success);
        accountRepositoryMock.Verify(r => r.AddAccount(It.Is<Account>(a => a.Number == "12345" && a.Pin == "1234")), Times.Once);
    }
}