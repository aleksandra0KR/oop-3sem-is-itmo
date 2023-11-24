using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileRenameCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "file" || args[1] != "rename") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        State state = new LocalFileRename(args[2], args[3]);
        Command command = new CommandFileRename(state);
        return command;
    }
}