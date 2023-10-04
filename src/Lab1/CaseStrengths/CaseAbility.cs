using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public abstract class CaseAbility
{
    protected CaseAbility(char type, int damage)
    {
        TypeOfCase = type;
        DamageCare = damage;
    }

    public abstract int DamageCare { get; protected set; }
    public bool IsWorking { get; private set;  } = true;
    public abstract char TypeOfCase { get; protected set; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle == null) return;
        if (!IsWorking) return;
        DamageCare -= obstacle.CountDamageToCase();
        if (DamageCare >= 0)
        {
            obstacle.Damage = 0;
            if (DamageCare == 0) IsWorking = false;
            return;
        }

        IsWorking = false;
        obstacle.Damage = -DamageCare;
    }
}