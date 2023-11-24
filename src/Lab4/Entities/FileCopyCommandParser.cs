using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class FileCopyCommandParser : CommandParser
{
    public override Command? Handle(Collection<string> args)
    {
        if (args is null) throw new ValueException("Empty name of command");
        if (args[0] != "file" || args[1] != "copy") return base.Handle(args);
        if (args.Count != 4) throw new ValueException("Not enough parameters");

        State state = new LocalCopyFile(args[2], args[3]);
        Command command = new CommandFileCopy(state);
        return command;
    }
}