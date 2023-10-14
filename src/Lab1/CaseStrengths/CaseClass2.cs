namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass2 : CaseAbility
{
    private int _demadeCare = 50;

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }
}