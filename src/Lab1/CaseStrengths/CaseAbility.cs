using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public abstract class CaseAbility
{
    public abstract int DamageCare { get; protected set; }
    public bool IsWorking { get; private set;  } = true;

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is null) return;
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