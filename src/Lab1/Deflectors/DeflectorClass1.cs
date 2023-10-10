namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass1 : Deflector
{
    private int _demadeCare = 20;

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.FirstDeflector;
}