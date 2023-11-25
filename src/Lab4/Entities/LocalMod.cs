using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class LocalMod : MoodParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        State state;
        string address = args[1];
        string mode = args[3];

        if (mode == "local") state = new LocalConnectionState(address);
        else throw new ValueException("unsupported mode");
        Command command = new CommandConnect(state);
        return command;
    }
}