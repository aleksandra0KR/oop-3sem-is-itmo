using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damage)
    {
        Damage = damage;
    }

    public abstract int Damage { get; set; }
    public abstract Environment Environment { get; protected set; }
    public abstract int CountDamageToDeflector(char typeOfDeflector);
    public abstract int CountDamageToCase();
}