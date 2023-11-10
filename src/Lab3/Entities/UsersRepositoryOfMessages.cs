using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class UsersRepositoryOfMessages
{
    private Collection<Tuple<Status, Message>> Messages { get; } = new();

    public Message? GetMessage(string givenHeading)
    {
        return (from message in Messages where message.Item2.Heading == givenHeading select message.Item2).FirstOrDefault();
    }

    public Status GetMessageStatus(string givenHeading)
    {
        foreach (Tuple<Status, Message> component in Messages)
        {
            if (component.Item2.Heading == givenHeading)
            {
                return component.Item1;
            }
        }

        throw new ValueException("Message is not in the list");
    }

    public void AddMessage(Message givenMessage)
    {
        if (Messages.Any(message => message.Item2.Heading == givenMessage.Heading)) return;

        Messages.Add(new Tuple<Status, Message>(new Status(), givenMessage));
    }

    public void ChangeStatus(string givenHeading)
    {
        foreach (Tuple<Status, Message> message in Messages)
        {
            if (message.Item2.Heading == givenHeading)
            {
                message.Item1.ChangeStatus();
            }
        }
    }
}