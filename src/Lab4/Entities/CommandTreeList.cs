namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandTreeList : Command
{
    public CommandTreeList(State state)
    {
        State = state ?? throw new ValueException("Empty state");
    }

    private State State { get; set; }

    public override void Execute(Filesystem fileSystem)
    {
        State.Execute(fileSystem);
    }
}