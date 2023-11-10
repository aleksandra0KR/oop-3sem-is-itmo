using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeRepositoryOfMessages
{
    private Collection<Tuple<string?, Message>> Messages { get; } = new();

    public Message? GetMessage(string givenHeading)
    {
        return (from message in Messages where message.Item2.Heading == givenHeading select message.Item2).FirstOrDefault();
    }

    public void AddMessage(Message givenMessage, string? toWhom)
    {
        if (Messages.Any(message => message.Item2.Heading == givenMessage.Heading)) return;

        Messages.Add(new Tuple<string?, Message>(toWhom, givenMessage));
    }
}