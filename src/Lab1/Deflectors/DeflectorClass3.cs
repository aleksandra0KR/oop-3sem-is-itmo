namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass3 : Deflector
{
    private char _typeOfDeflector;
    private int _demadeCare = 400;
    public DeflectorClass3()
        : base('3', 400) { }
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfDeflector
    {
        get => _typeOfDeflector;
        protected set => _typeOfDeflector = '3';
    }
}