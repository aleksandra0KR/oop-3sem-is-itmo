using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class Deflector
{
    protected Deflector(int demagecare)
    {
        DemageCare = demagecare;
    }

    public abstract int DemageCare { get; protected set; }
    public bool IsWorking { get; protected set;  } = true;
    public abstract TypesOfDeflectors TypeOfDeflector { get; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null) return;
        if (!IsWorking) return;
        DemageCare -= obstacle.CountDamageToDeflector(TypeOfDeflector);
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