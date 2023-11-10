using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Messenger : User
{
    public Messenger()
    {
        Name = "Best ever Messenger";
    }

    public Messenger(string name)
    {
        Name = name;
    }

    public override void Logging()
    {
        Console.WriteLine(Name + " Message is delivered");
    }

    public override void GetMessage(Message message)
    {
        if (message is null) throw new ValueException("Empty message");
        Console.WriteLine(Name + " " + message.Body);
        Logging();
    }
}