using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environment
{
    public abstract TypesOfEnvironments TypeOfEnvironment { get; }
    public Collection<Obstacle> Obstacles { get; } = new();

    protected abstract Collection<TypesOfEngines> NeededEngine { get; }

    public abstract int CountAmountOfFuel(Ship ship, int distance);
    public void AddObstacles(Collection<Obstacle> obstacles)
    {
        if (obstacles == null)
        {
            return;
        }

        foreach (Obstacle value in obstacles)
        {
            Obstacles.Add(value);
        }
    }

    public bool MatchEnvironmentAndEngine(Engine? engine)
    {
        if (engine == null) return false;
        foreach (TypesOfEngines needed in NeededEngine)
        {
            if (engine.TypeOfIEngine == needed) return true;
        }

        return false;
    }
}