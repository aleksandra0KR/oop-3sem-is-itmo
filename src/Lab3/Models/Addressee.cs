using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class Addressee
{
    public AddresseeRepositoryOfMessages RepositoryForMessages { get; set; } = new();

    public void AddMessage(Message message, string? addressee)
    {
        RepositoryForMessages.AddMessage(message, addressee);
    }

    public abstract void SendMessage(User? user, Message message);

    protected internal static void Logging()
    {
        Console.WriteLine("Mesage is sent");
    }
}