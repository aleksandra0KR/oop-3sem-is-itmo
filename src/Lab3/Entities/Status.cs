namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Status
{
    public string StatusOfTheMessage { get; private set; } = "Unread";
    public void ChangeStatus()
    {
        if (StatusOfTheMessage == "Unread") StatusOfTheMessage = "Read";
        else throw new ValueException("already read message");
    }
}