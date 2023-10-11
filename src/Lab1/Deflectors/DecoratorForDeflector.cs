namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public abstract class DecoratorForDeflector : Deflector
{
    private Deflector deflector;
    protected DecoratorForDeflector(Deflector deflector)
    {
        this.deflector = deflector;
    }

    public override TypesOfDeflectors TypeOfDeflector => deflector.TypeOfDeflector;

    public override int DemageCare => deflector.DemageCare;

    public void SetDeflector(Deflector deflector)
    {
        this.deflector = deflector;
    }
}