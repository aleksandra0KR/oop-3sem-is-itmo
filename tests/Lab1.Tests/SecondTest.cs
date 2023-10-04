using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SecondTest
{
    [Fact]
    public void Test2()
    {
        Environment environment1 = new FoggySpace(1, 500);
        Obstacle obstacle = new AntimatterFlares(environment1);
        var obstacles = new Collection<Obstacle> { obstacle };
        environment1.AddObstacles(obstacles);
        var firstPath = new Collection<KeyValuePair<int, Environment>>
        {
            new(500, environment1),
        };
        Engine engine1 = new EngineClassE();
        EngineClassJumping engine11 = new EngineClassJunpingGamma();
        CaseAbility case1 = new CaseClass2();
        Deflector deflector1 = new DeflectorClass1();
        Ship ship1 = new Vaclas(engine1, engine11, deflector1, case1);
        var firstShips = new Collection<Ship>() { ship1 };
        var firstRoute = new Route(firstPath, firstShips);
        Assert.Equal("Dead! Damage is fatale", firstRoute.Start());

        Environment environment2 = new FoggySpace(1, 500);
        Obstacle obstacle2 = new AntimatterFlares(environment2);
        var obstacles2 = new Collection<Obstacle> { obstacle2 };
        environment2.AddObstacles(obstacles2);
        var secondPath = new Collection<KeyValuePair<int, Environment>>
        {
            new(500, environment2),
        };
        Engine engine2 = new EngineClassE();
        EngineClassJumping engine22 = new EngineClassJunpingGamma();
        CaseAbility case2 = new CaseClass2();
        Deflector deflector2 = new DeflectorClassFoton();
        Ship ship2 = new Vaclas(engine2, engine22, deflector2, case2);
        var secondShips = new Collection<Ship> { ship2 };
        var secondRoute = new Route(secondPath, secondShips);
        Assert.Equal("We need 20l of fuel and 120 of graviton matter", secondRoute.Start());
    }
}