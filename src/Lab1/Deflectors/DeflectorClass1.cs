namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass1 : Deflector
{
    private static int _demadeCare = 20;

    public DeflectorClass1()
        : base(_demadeCare) { }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.FirstDeflector;
}