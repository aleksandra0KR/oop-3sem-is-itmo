namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandTreeGoto : Command
{
    public CommandTreeGoto(State? state)
    {
        State = state ?? throw new ValueException("Empty state");
    }

    private State State { get; }

    public override void Execute(Filesystem fileSystem)
    {
        State.Execute(fileSystem);
    }
}