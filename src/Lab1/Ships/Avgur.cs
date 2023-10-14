using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Avgur : Ship
{
    public Avgur(Engine engineFirst, EngineClassJumping engineSecond, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst is null && engineSecond is null) throw new ValueException(nameof(engineFirst));
        if (engineFirst is not null && engineFirst.GetType() != typeof(EngineClassE))
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        if (engineSecond is not null && engineSecond.GetType() != typeof(EngineClassJumpingAlpha))
        {
            throw new TypeExeption("Not the needed type of Jumping Engine");
        }

        EngineFirst = engineFirst;
        EngineSecond = engineSecond;

        if (deflector is null) throw new ValueException(nameof(deflector));
        if (deflector.GetType() != typeof(DeflectorClass3) && deflector.GetType() != typeof(DeflectorClassFoton) && deflector.GetType() != typeof(DeflectorClassNitrit))
        {
            throw new TypeExeption("Not the needed type of Deflector");
        }

        DeflectorOfShip = deflector;
        if (caseAbility is null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.GetType() != typeof(CaseClass3))
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}