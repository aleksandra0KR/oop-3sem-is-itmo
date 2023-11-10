namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(string heading, User addressee, Message message)
    {
        Heading = heading;
        User = addressee;
        CurrentMessage = message;
    }

    private string Heading { get; }
    private User User { get; }
    private Message CurrentMessage { get; }

    public void SendToAddressee(Addressee addressee)
    {
        if (addressee is null) throw new ValueException("Empty addressee");
        addressee.SendMessage(User, CurrentMessage);
    }
}