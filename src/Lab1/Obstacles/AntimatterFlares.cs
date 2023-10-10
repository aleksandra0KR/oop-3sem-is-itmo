using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public class AntimatterFlares : Obstacle
{
    private static int _damage = 30;
    public AntimatterFlares(Environment? environment)
        : base(_damage)
    {
        if (environment is null) throw new ValueException(nameof(environment));
        if (environment.TypeOfEnvironment != TypesOfEnvironments.FoggySpace)
        {
            throw new TypeExeption("Not the needed type of Environment");
        }

        Environment = environment;
    }

    public override int Damage { get; set; }
    public override Environment Environment { get; protected set; }

    public override int CountDamageToCase()
    {
        return 10000;
    }

    public override int CountDamageToDeflector(TypesOfDeflectors typeOfDeflector)
    {
        return typeOfDeflector != TypesOfDeflectors.FotonDeflector ? 10000 : Damage;
    }
}