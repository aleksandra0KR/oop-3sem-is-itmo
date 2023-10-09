namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassNitrit : Deflector
{
    private static int _demadeCare = 900;
    public DeflectorClassNitrit()
        : base(_demadeCare) { }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfDeflectors TypeOfDeflector => TypesOfDeflectors.NitritDeflector;
}