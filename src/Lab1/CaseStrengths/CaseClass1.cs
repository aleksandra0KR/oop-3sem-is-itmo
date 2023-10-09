namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass1 : CaseAbility
{
    private static int _demadeCare = 10;
    public CaseClass1()
    : base(_demadeCare) { }

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfCases TypeOfCase => TypesOfCases.FirstCase;
}