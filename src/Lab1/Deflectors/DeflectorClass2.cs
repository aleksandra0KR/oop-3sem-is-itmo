namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass2 : Deflector
{
    private static int _demadeCare = 100;
    public DeflectorClass2()
        : base(_demadeCare) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.SecondDeflector;
}