using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileDeleteCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "file" || args[1] != "delete") return base.Handle(args);
        if (args.Count != 3) throw new ValueException("Not enough parameters");
        State state = new LocalFileDelete(args[2]);
        Command command = new CommandFileDelete(state);
        return command;
    }
}