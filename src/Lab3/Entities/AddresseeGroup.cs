using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AddresseeGroup : Addressee
{
    private Collection<Tuple<Addressee, User>> singleAdressees = new();

    public void Add(Addressee component, User user)
    {
        singleAdressees.Add(new Tuple<Addressee, User>(component, user));
    }

    public void AddToManyUsers(Addressee component, Collection<User> users)
    {
        if (users is null) throw new ValueException("Empty list of users");
        foreach (User user in users)
        {
            singleAdressees.Add(new Tuple<Addressee, User>(component, user));
        }
    }

    public void Remove(Addressee component, User user)
    {
        singleAdressees.Remove(new Tuple<Addressee, User>(component, user));
    }

    public override void SendMessage(User? user, Message message)
    {
        foreach (Tuple<Addressee, User> component in singleAdressees)
        {
            component.Item1.SendMessage(component.Item2, message);
        }

        singleAdressees = new();
        Logging();
    }
}