namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class User
{
    public AddresseeRepositoryOfMessages RepositoryForMessages { get; set; } = new();
    public string Name { get; protected init; } = " ";
    public abstract void Logging();

    public abstract void GetMessage(Message message);
}