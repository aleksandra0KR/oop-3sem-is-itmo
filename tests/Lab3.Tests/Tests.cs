using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]

    private void FirstStatusIsUnread()
    {
        var message = new Message("work", "I'm quitting", 1);
        var elon = new Person("Elon Musk", 1);
        var addressee = new AddresseePerson();

        addressee.SendMessage(elon, message);
        Assert.Equal("Unread", elon.StatusOfMessage("work").StatusOfTheMessage);
    }

    [Fact]

    private void ChangedStatus()
    {
        var message = new Message("work", "I'm quitting", 1);
        var elon = new Person("Elon Musk", 1);
        var addressee = new AddresseePerson();

        addressee.SendMessage(elon, message);
        elon.StatusOfMessage("work")?.ChangeStatus();
        Assert.Equal("Read", elon.StatusOfMessage("work").StatusOfTheMessage);
    }

    [Fact]

    private void CantChangeUnreadStatus()
    {
        var message = new Message("work", "I'm quitting", 1);
        var elon = new Person("Elon Musk", 1);
        var addressee = new AddresseePerson();

        addressee.SendMessage(elon, message);
        elon.StatusOfMessage("work")?.ChangeStatus();
        var expected = new ValueException("already read message");

        ValueException result = Assert.Throws<ValueException>(() => elon.StatusOfMessage("work").ChangeStatus());
        Assert.Equal(expected.Message, result.Message);
    }

    [Fact]
    private void DeniedMessegeWithLowImportance()
    {
        var message = new Message("work", "I'm quitting", 5);
        var elon = new Person("Elon Musk", 1);
        var addresseeMock = new Mock<AddresseePerson>();
        var proxy = new ProxyForFilteringLevel(addresseeMock.Object);

        proxy.SendMessage(elon, message);
        addresseeMock.Verify(x => x.SendMessage(elon, message), Times.Never);
    }

    [Fact]
    private void CheckLogging()
    {
        var message = new Message("work", "I'm quitting", 1);
        var addresseeMock = new Mock<Person>();
        addresseeMock.CallBase = true;
        var proxy = new ProxyForFilteringLevel(new AddresseePerson());

        proxy.SendMessage(addresseeMock.Object, message);
        addresseeMock.Verify(x => x.Logging(), Times.Once);
    }

    [Fact]
    private void CheckMessengerWork()
    {
        var message = new Message("work", "I'm quitting", 1);
        var addresseeMock = new Mock<Messenger>();
        addresseeMock.CallBase = true;
        var addressedMessenger = new AddresseeMessenger();

        addressedMessenger.SendMessage(addresseeMock.Object, message);
        addresseeMock.Verify(x => x.GetMessage(message), Times.Once);
    }
}