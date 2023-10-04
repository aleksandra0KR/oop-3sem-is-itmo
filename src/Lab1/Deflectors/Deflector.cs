using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class Deflector
{
    protected Deflector(char type, int demagecare)
    {
        TypeOfDeflector = type;
        DemageCare = demagecare;
    }

    public abstract int DemageCare { get; protected set; }
    public bool IsWorking { get; protected set;  } = true;
    public abstract char TypeOfDeflector { get; protected set; }

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