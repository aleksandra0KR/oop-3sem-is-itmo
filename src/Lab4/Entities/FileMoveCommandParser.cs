using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileMoveCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "filemove") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        Command command = new CommandFileMove(args["path"], args["destination"]);
        return command;
    }
}