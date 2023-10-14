namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class DeflectorClass2 : Deflector
{
    private int _demadeCare = 100;
    public override int DemageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }
}