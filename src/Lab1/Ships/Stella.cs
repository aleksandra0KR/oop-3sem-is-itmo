using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Stella : Ship
{
    public Stella(Engine engineFirst, EngineClassJumping engineSecond, Deflector deflector, CaseAbility caseAbility)
    {
        if (engineFirst is null && engineSecond is null) throw new ValueException(nameof(engineFirst));
        if (engineFirst is not null && engineFirst.TypeOfIEngine != TypesOfEngines.EngineC)
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        if (engineSecond is not null && engineSecond.TypeOfIEngine != TypesOfEngines.EngineOmega)
        {
            throw new TypeExeption("Not the needed type of Engine");
        }

        EngineFirst = engineFirst;
        EngineSecond = engineSecond;

        if (deflector is null) throw new ValueException(nameof(deflector));
        if (deflector.TypeOfDeflector != TypesOfDeflectors.FirstDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.FotonDeflector && deflector.TypeOfDeflector != TypesOfDeflectors.NitritDeflector)
        {
            throw new TypeExeption("Not the needed type of Deflector");
        }

        DeflectorOfShip = deflector;
        if (caseAbility is null) throw new ValueException(nameof(caseAbility));
        if (caseAbility.TypeOfCase != TypesOfCases.FirstCase)
        {
            throw new TypeExeption("Not the needed type of Case");
        }

        CaseOfShip = caseAbility;
    }
}