using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConnectCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "connect") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");
        string address = args[1];
        string mode = args[3];

        State state;
        if (mode == "local") state = new LocalConnectionState(address);
        else throw new ValueException("unsupported mode");

        Command command = new CommandConnect(state);
        return command;
    }
}