namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeDisplay : Addressee
{
    public override void SendMessage(User? user, Message message)
    {
        if (user is null) throw new ValueException("Empty display");
        user.GetMessage(message);
        Logging();
    }
}