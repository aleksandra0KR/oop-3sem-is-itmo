namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass3 : Deflector
{
    private int _demadeCare = 400;
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.ThirdDeflector;
}