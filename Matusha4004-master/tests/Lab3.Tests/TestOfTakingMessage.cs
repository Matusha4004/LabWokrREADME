using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.MessengerAddressee;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.LogsForAddressee;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerDirecotory;
using Itmo.ObjectOrientedProgramming.Lab3.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.UserDirectory;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class TestOfTakingMessage
{
    [Fact]

    public void TestSuccessUserTakingMessageWithNotRadStatus()
    {
        var user = new User();

        var message = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        var userAddressee = new UserAddressee(user);

        userAddressee.TakeMessage(message);

        KeyValuePair<Message, IsRad> tookMessage = user.RadMessages.FirstOrDefault();

        Assert.False(tookMessage.Value.Value);
    }

    [Fact]
    public void TestSuccessUserTakingMessageWithNotRadStatusAndReadThem()
        {
            var user = new User();

            var someMessage = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

            var userAddressee = new UserAddressee(user);

            userAddressee.TakeMessage(someMessage);

            Assert.True(user.CheckMessage(someMessage) is CheckMessageResult.Success);

            KeyValuePair<Message, IsRad> tookMessage = user.RadMessages.FirstOrDefault();

            Assert.True(tookMessage.Value.Value);
        }

    [Fact]
    public void TestFailedUserTakingMessageWithNotRadStatusAndReadThemTwice()
    {
        var user = new User();

        var userAddressee = new UserAddressee(user);

        var someMessage = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        userAddressee.TakeMessage(someMessage);

        user.CheckMessage(someMessage);

        Assert.True(user.CheckMessage(someMessage) is CheckMessageResult.FailMessageIsBeenChecked);
    }

    [Fact]
    public void TestFailedLowPriorityOnMessage()
    {
        var message = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        var user = new Mock<IUser>();

        user.Setup(m => m.TakeMessage(It.IsAny<Message>()));

        var userAddressee = new UserAddressee(user.Object);

        var priory = new AddresseePriory(userAddressee, new Priority(100));

        priory.TakeMessage(message);

        user.Verify(m => m.TakeMessage(It.IsAny<Message>()), Times.Never());
    }

    [Fact]
    public void TestLogMessageArrived()
    {
        var log = new AddresseeLogger();

        var user = new Mock<IUser>();

        var someMessage = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        user.Setup(m => m.TakeMessage(It.IsAny<Message>()));

        var addressee = new UserAddressee(user.Object);

        var logger = new LoggerAddressee(addressee, log);

        logger.TakeMessage(someMessage);

        user.Verify(m => m.TakeMessage(It.IsAny<Message>()), Times.Once());

        Assert.Contains("Some body", log.Logs);
    }

    [Fact]

    public void TestSuccessMessengerWork()
    {
        var message = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        var messanger = new Mock<IMessenger>();

        messanger.Setup(m => m.TakeMessage(It.IsAny<string>()));

        var messagnerAddressee = new AddresseeMessenger(messanger.Object);

        messagnerAddressee.TakeMessage(message);

        messanger.Verify(m => m.TakeMessage(It.IsAny<string>()), Times.Once);
    }

    [Fact]

    public void TestWithOneUserAndTwoAddresses()
    {
        var user = new Mock<IUser>();

        user.Setup(u => u.TakeMessage(It.IsAny<Message>()));

        var userAddressee = new UserAddressee(user.Object);

        var anotherUserAddressee = new UserAddressee(user.Object);

        var message = new Message(new Header("Some header"), new BodyOfMessage("Some body"), new Priority(10));

        var prioryFirst = new AddresseePriory(userAddressee, new Priority(1));

        var priorySecond = new AddresseePriory(anotherUserAddressee, new Priority(100));

        prioryFirst.TakeMessage(message);

        priorySecond.TakeMessage(message);

        user.Verify(u => u.TakeMessage(It.IsAny<Message>()), Times.Once());
    }
}