namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class DecoratorForDisplay : User
{
    protected DecoratorForDisplay(User user)
    {
        this.User = user;
    }

    protected User User { get; }
    public override void GetMessage(Message message)
    {
        User.GetMessage(message);
    }

    public override void Logging()
    {
        User.Logging();
    }
}