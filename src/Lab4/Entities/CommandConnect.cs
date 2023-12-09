namespace Itmo.ObjectOrientedProgramming.Lab4;

public class CommandConnect : Command
{
    public CommandConnect(State? state)
    {
        State = state ?? throw new ValueException("Empty state");
    }

    private State State { get; set; }

    public override void Execute(Filesystem fileSystem)
    {
        State.Execute(fileSystem);
    }
}