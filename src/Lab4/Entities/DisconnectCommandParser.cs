using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class DisconnectCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "disconnect") return base.Handle(args);
        if (args.Count < 1) throw new ValueException("Too many parameters");

        Command command = new CommandDisconnect();
        return command;
    }
}