namespace Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;

public class CaseClass2 : CaseAbility
{
    private char _typeOfCase;
    private int _demadeCare = 50;
    public CaseClass2()
        : base('2', 50) { }

    public override int DamageCare
    {
        get => _demadeCare;
        protected set => _demadeCare = value;
    }

    public override char TypeOfCase
    {
        get => _typeOfCase;
        protected set => _typeOfCase = '2';
    }
}