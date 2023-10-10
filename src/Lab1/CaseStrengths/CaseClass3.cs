namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass3 : CaseAbility
{
    private int _demadeCare = 200;

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override TypesOfCases TypeOfCase => TypesOfCases.ThirdCase;
}