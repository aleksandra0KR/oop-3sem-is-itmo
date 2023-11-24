using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class TreeListCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "tree" || args[1] != "list") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        State state = new LocalTreeList(args[3]);

        Command command = new CommandTreeList(state);
        return command;
    }
}