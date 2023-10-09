using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NebulaeOfNitrineParticlesSpace : Environment
{
    public NebulaeOfNitrineParticlesSpace() { }

    public override TypesOfEnvironments TypeOfEnvironment => TypesOfEnvironments.NebulaeOdNitrineParticlesSpacce;

    protected override Collection<TypesOfEngines> NeededEngine { get; } = new() { TypesOfEngines.EngineE };

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship == null) throw new ValueException("Ship is null");
        if (ship.EngineFirst == null) throw new ValueException("Engine is null");
        Engine engine = ship.EngineFirst;
        return engine.CountFuelConsumption(distance);
    }
}