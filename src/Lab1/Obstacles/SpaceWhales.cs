using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhales : Obstacle
{
    public SpaceWhales(Environment? environment)
    : base(30)
    {
        if (environment == null) throw new ValueException(nameof(environment));
        if (environment.TypeOfEnvironment != 'N')
        {
            throw new TypeExeption("Not the needed type of Environment");
        }

        Environment = environment;
    }

    public override int Damage { get; set; }
    public override Environment Environment { get; protected set; }
    public override int CountDamageToCase()
    {
        return int.MaxValue;
    }

    public override int CountDamageToDeflector(char typeOfDeflector)
    {
        return typeOfDeflector == 'N' ? Damage : 400;
    }
}