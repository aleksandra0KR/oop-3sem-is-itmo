using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class DisconnectCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "disconnect") return base.Handle(args);
        if (args.Count != 1) throw new ValueException("Too many parameters");

        Command command = new CommandDisconnect();
        return command;
    }
}