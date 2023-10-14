namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClassNitrit : DecoratorForDeflector
{
    private int _demadeCare;
    public DeflectorClassNitrit(Deflector deflector)
        : base(deflector)
    {
        _demadeCare = 30000 + base.DemageCare;
    }

    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }
}