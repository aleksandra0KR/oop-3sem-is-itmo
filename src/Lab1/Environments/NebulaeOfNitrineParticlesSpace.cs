using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NebulaeOfNitrineParticlesSpace : Environment
{
    private char _type;

    public NebulaeOfNitrineParticlesSpace()
    {
        TypeOfEnvironment = 'N';
    }

    public override char TypeOfEnvironment
    {
        get => _type;
        protected set => _type = 'N';
    }

    protected override Collection<char> NeededEngine { get; } = new() { 'E' };

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship == null) throw new ValueException("Ship is null");
        if (ship.EngineFirst == null) throw new ValueException("Engine is null");
        Engine engine = ship.EngineFirst;
        return engine.CountFuelConsumption(distance);
    }
}