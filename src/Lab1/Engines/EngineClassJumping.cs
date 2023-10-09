namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class EngineClassJumping : Engine
{
    protected EngineClassJumping(int speed, int rangeOfTravel)
        : base(speed)
    {
        RangeOfTravel = rangeOfTravel;
    }

    public abstract int RangeOfTravel { get; protected set; }
}