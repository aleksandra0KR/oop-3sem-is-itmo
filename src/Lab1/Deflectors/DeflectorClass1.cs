namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass1 : Deflector
{
    private char _typeOfDeflector;
    private int _demadeCare = 20;

    public DeflectorClass1()
        : base('1', 20) { }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set
        {
            _demadeCare = value;
        }
    }

    public override char TypeOfDeflector
    {
        get => _typeOfDeflector;
        protected set => _typeOfDeflector = '1';
    }
}