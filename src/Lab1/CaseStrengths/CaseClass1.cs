namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass1 : CaseAbility
{
    private char _typeOfCase;
    private int _demadeCare = 10;
    public CaseClass1()
    : base('1', 10) { }

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfCase
    {
        get => _typeOfCase;
        protected set => _typeOfCase = '1';
    }
}