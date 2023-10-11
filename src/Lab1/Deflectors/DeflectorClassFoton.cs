namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassFoton : DecoratorForDeflector
{
    private int _demadeCare;
    public DeflectorClassFoton(Deflector deflector)
        : base(deflector)
    {
        _demadeCare = 900 + base.DemageCare;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.FotonDeflector;
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }
}