using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    [Fact]
    public void Test5()
    {
        Environment environment1 = new FoggySpace(2, 200);
        Engine engine1 = new EngineClassE();
        EngineClassJumping engine12 = new EngineClassJumpingAlpha();
        Deflector deflector1 = new DeflectorClass3();
        CaseAbility case1 = new CaseClass3();
        Ship ship1 = new Avgur(engine1, engine12, deflector1, case1);
        var firstPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(200, environment1),
            };
        var firstShips = new Collection<Ship> { ship1 };
        var firstRoute = new Route(firstPath, firstShips);
        Assert.Equal("Loose! You lost your ship", firstRoute.Start());

        Environment environment2 = new FoggySpace(2, 200);
        Engine engine2 = new EngineClassC();
        EngineClassJumping engine22 = new EngineClassJumpingOmega();
        Deflector deflector2 = new DeflectorClass1();
        CaseAbility case2 = new CaseClass1();
        Ship ship2 = new Stella(engine2, engine22, deflector2, case2);
        var secondPath = new Collection<KeyValuePair<int, Environment>>
            {
                new(200, environment2),
            };
        var secondShips = new Collection<Ship> { ship2 };
        var secondRoute = new Route(secondPath, secondShips);
        Assert.Equal("We need 10l of fuel and 540 of graviton matter", secondRoute.Start());
    }
}