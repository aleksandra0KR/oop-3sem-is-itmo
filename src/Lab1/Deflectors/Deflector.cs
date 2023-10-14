using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class Deflector
{
    public abstract int DemageCare { get; protected set; }
    public bool IsWorking { get; protected set;  } = true;
    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;
        if (!IsWorking) return;
        DemageCare -= obstacle.CountDamageToDeflector(GetType());
        if (DemageCare >= 0)
        {
            obstacle.Damage = 0;
            if (DemageCare == 0) IsWorking = false;
            return;
        }

        obstacle.Damage = -DemageCare;
        IsWorking = false;
    }
}