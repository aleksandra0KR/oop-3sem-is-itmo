namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeMessenger : Addressee
{
    public override void SendMessage(User? user, Message message)
    {
        if (user is null) throw new ValueException("Empty user");
        user.GetMessage(message);
        Logging();
    }
}