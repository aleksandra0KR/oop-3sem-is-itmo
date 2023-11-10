using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Person : User
{
    public Person()
    {
        Name = "Jane Doe";
        ImportanceLevel = 10;
    }

    public Person(string name, int importanceLevel)
    {
        Name = name;
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }
    private new UsersRepositoryOfMessages RepositoryForMessages { get; } = new();

    public override void Logging()
    {
        Console.WriteLine("Message is delivered to " + Name);
    }

    public override void GetMessage(Message message)
    {
        RepositoryForMessages.AddMessage(message);
        Logging();
    }

    public Message? GiveMessage(string heading)
    {
        return RepositoryForMessages.GetMessage(heading);
    }

    public Status StatusOfMessage(string heading)
    {
        return RepositoryForMessages.GetMessageStatus(heading);
    }
}