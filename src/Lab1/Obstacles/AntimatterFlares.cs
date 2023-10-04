using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : Obstacle
{
    public AntimatterFlares(Environment? environment)
        : base(30)
    {
        if (environment == null) throw new ValueException(nameof(environment));
        if (environment.TypeOfEnvironment != 'F')
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
        return typeOfDeflector != 'F' ? int.MaxValue : Damage;
    }
}