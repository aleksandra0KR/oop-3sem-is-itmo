namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DecoratorForAddressee : Addressee
{
    protected DecoratorForAddressee(Addressee addressee)
    {
        this.Addressee = addressee;
    }

    protected Addressee Addressee { get; }
    public override void SendMessage(User? user, Message message)
    {
        Addressee.SendMessage(user, message);
    }
}