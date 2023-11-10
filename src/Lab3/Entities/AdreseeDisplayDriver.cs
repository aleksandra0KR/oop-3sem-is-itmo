namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AdreseeDisplayDriver : DecoratorForAddressee
{
    protected AdreseeDisplayDriver(Addressee addressee)
        : base(addressee)
    { }

    public override void SendMessage(User? user, Message message)
    {
        Addressee.RepositoryForMessages = new AddresseeRepositoryOfMessages();
        Addressee.SendMessage(user, message);
    }

    public void CleanMessages()
    {
        Addressee.RepositoryForMessages = new AddresseeRepositoryOfMessages();
    }
}