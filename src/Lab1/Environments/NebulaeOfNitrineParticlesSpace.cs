using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class NebulaeOfNitrineParticlesSpace : Environment
{
    protected override Collection<Type> NeededEngine { get; } = new() { typeof(EngineClassE) };

    public override int CountAmountOfFuel(Ship ship, int distance)
    {
        if (ship is null) throw new ValueException("Ship is null");
        if (ship.EngineFirst is null) throw new ValueException("Engine is null");
        Engine engine = ship.EngineFirst;
        return engine.CountFuelConsumption(distance);
    }
}