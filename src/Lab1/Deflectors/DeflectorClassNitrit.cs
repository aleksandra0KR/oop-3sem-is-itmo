namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassNitrit : Deflector
{
    private char _typeOfDeflector;
    private int _demadeCare = 900;
    public DeflectorClassNitrit()
        : base('N', 900) { }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfDeflector
    {
        get => _typeOfDeflector;
        protected set => _typeOfDeflector = 'N';
    }
}