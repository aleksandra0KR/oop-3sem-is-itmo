namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassNitrit : Deflector
{
    private int _demadeCare = 900;
    public DeflectorClassNitrit()
        : base(900) { }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.NitritDeflector;
}