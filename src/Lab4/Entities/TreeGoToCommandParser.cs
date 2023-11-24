using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class TreeGoToCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "tree" || args[1] != "goto") return base.Handle(args);
        if (args.Count != 3) throw new ValueException("Not enough parameters");

        State state = new LocalTreeGoto(args[2]);
        Command command = new CommandTreeGoto(state);
        return command;
    }
}