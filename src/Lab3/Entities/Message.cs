namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string heading, string body, int importanceLevel)
    {
        Heading = heading;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public string Heading { get; private set; }
    public string Body { get; private set; }
    public int ImportanceLevel { get; private set; }
}