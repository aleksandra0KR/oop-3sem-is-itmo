namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassFoton : Deflector
{
    private static int _demadeCare = 900;
    public DeflectorClassFoton()
        : base(_demadeCare) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.FotonDeflector;
}