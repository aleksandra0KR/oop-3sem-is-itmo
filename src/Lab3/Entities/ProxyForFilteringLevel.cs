namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ProxyForFilteringLevel : Addressee
{
    private readonly Addressee _addressee;

    public ProxyForFilteringLevel(Addressee addressee)
    {
        _addressee = addressee;
    }

    public void SendMessage(Person? user, Message message)
    {
        if (user is null) return;
        if (user.ImportanceLevel >= message?.ImportanceLevel)
        {
            _addressee.SendMessage(user, message);
        }
    }

    public override void SendMessage(User? user, Message message)
    {
        _addressee.SendMessage(user, message);
    }
}