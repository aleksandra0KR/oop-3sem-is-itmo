namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass3 : Deflector
{
    private static int _demadeCare = 400;
    public DeflectorClass3()
        : base(_demadeCare) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.ThirdDeflector;
}