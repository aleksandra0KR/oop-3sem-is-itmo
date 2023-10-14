using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public abstract class Ship
{
    public CaseAbility? CaseOfShip { get; protected set; }
    public Engine? EngineFirst { get; protected set; }
    public EngineClassJumping? EngineSecond { get; protected set; }
    public Deflector? DeflectorOfShip { get; protected set; }
}