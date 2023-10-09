using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class SpaceWhales : Obstacle
{
    public SpaceWhales(Environment? environment)
    : base(30)
    {
        if (environment is null) throw new ValueException(nameof(environment));
        if (environment.TypeOfEnvironment != TypesOfEnvironments.NebulaeOdNitrineParticlesSpacce)
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

    public override int CountDamageToDeflector(TypesOfDeflectors typeOfDeflector)
    {
        return typeOfDeflector == TypesOfDeflectors.NitritDeflector ? Damage : 400;
    }
}