using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damage)
    {
        Damage = damage;
    }

    public abstract int Damage { get; set; }
    public abstract Environment Environment { get; protected set; }
    public abstract int CountDamageToDeflector(Deflector deflector);
    public abstract int CountDamageToCase();
}