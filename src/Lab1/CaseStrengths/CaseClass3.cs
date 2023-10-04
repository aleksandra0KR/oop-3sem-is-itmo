namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass3 : CaseAbility
{
    private char _typeOfCase;
    private int _demadeCare = 200;
    public CaseClass3()
        : base('3', 200) { }

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfCase
    {
        get => _typeOfCase;
        protected set => _typeOfCase = '3';
    }
}