using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class Environment
{
    public abstract char TypeOfEnvironment { get; protected set; }
    public Collection<Obstacle> Obstacles { get; } = new();

    protected abstract Collection<char> NeededEngine { get; }

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
        foreach (char needed in NeededEngine)
        {
            if (engine.TypeOfIEngine == needed) return true;
        }

        return false;
    }
}