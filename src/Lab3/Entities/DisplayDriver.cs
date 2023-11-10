using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DisplayDriver : DecoratorForDisplay
{
    protected DisplayDriver(User user)
        : base(user)
    {
        Name = "Driver";
    }

    public override void GetMessage(Message message)
    {
        User.RepositoryForMessages = new AddresseeRepositoryOfMessages();
        User.GetMessage(message);
    }

    public void CleanMessages()
    {
        User.RepositoryForMessages = new AddresseeRepositoryOfMessages();
    }

    public override void Logging()
    {
        Console.Write(Name + " ");
        User.Logging();
    }
}