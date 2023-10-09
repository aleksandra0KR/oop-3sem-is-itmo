namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EngineClassJumping : Engine
{
    protected EngineClassJumping(int speed)
        : base(speed) { }

    public abstract int RangeOfTravel { get; }
}