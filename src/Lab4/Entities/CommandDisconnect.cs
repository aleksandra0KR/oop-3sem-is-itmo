using System;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandDisconnect : Command
{
    public override void Execute(Filesystem fileSystem)
    {
        Environment.Exit(0);
    }
}