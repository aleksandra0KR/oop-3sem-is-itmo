namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass2 : Deflector
{
    private char _typeOfDeflector;
    private int _demadeCare = 100;
    public DeflectorClass2()
        : base('2', 100) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfDeflector
    {
        get => _typeOfDeflector;
        protected set => _typeOfDeflector = '2';
    }
}