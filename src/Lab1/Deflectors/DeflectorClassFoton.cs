namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassFoton : Deflector
{
    private int _demadeCare = 900;
    public DeflectorClassFoton()
        : base(900) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.FotonDeflector;
}