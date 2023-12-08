using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileCopyCommandParser : CommandParser
{
    public override Command? Handle(Dictionary<string, string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args["command"] != "filecopy") return base.Handle(args);
        if (args.Count < 3) throw new ValueException("Not enough parameters");

        Command command = new CommandFileCopy(args["address"], args["destination"]);
        return command;
    }
}