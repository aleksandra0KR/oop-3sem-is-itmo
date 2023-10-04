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

public class SeventhTest
{
    [Fact]
    public void Test7()
    {
        Environment environment1 = new OrdinarySpace();
        Obstacle obstacle11 = new Asteroids(environment1);
        Obstacle obstacle12 = new Meteorite(environment1);
        var obstaclesFirstEnvironment = new Collection<Obstacle>() { obstacle11, obstacle12 };
        environment1.AddObstacles(obstaclesFirstEnvironment);
        Environment environment2 = new FoggySpace(2, 200);
        Obstacle obstacle21 = new AntimatterFlares(environment2);
        var obstaclesSecondEnvironment = new Collection<Obstacle> { obstacle21 };
        environment2.AddObstacles(obstaclesSecondEnvironment);
        var firstPath = new Collection<KeyValuePair<int, Environment>>
        {
            new(100, environment1),
            new(400, environment2),
        };
        Engine engine11 = new EngineClassE();
        EngineClassJumping engine12 = new EngineClassJunpingGamma();
        Deflector deflector1 = new DeflectorClassFoton();
        CaseAbility case1 = new CaseClass2();
        Ship ship1 = new Vaclas(engine11, engine12, deflector1, case1);
        var firstShips = new Collection<Ship> { ship1, ship1 };
        var firstRoute = new Route(firstPath, firstShips);
        Assert.Equal("We need 80l of fuel and 210 of graviton matter", firstRoute.Start());
    }
}