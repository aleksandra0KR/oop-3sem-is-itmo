namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass1 : CaseAbility
{
    private int _demadeCare = 10;

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }
}