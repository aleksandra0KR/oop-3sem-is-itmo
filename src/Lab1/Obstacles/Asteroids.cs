using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class Asteroids : Obstacle
{
    private readonly int _damagePowerPercentage = 50;
    public Asteroids(Environment? environment)
    : base(10)
    {
        if (environment == null) throw new ValueException(nameof(environment));
        if (environment.TypeOfEnvironment != 'O')
        {
            throw new TypeExeption("Not the needed type of Environment");
        }

        Environment = environment;
    }

    public override int Damage { get; set; }
    public override Environment Environment { get; protected set; }
    public override int CountDamageToCase()
    {
        return Damage / _damagePowerPercentage;
    }

    public override int CountDamageToDeflector(char typeOfDeflector)
    {
        return Damage;
    }
}