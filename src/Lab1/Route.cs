using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private readonly Collection<KeyValuePair<int, Environment>> _allRoutes;
    private readonly Collection<Ship> _allShips;
    private int _amoutOfFuel;
    private int _amoutOfMatter;

    public Route(Collection<KeyValuePair<int, Environment>> allRoutes, Collection<Ship> allShips)
    {
        _allRoutes = allRoutes;
        _allShips = allShips;
    }

    public void AddRoutes(Dictionary<int, Environment>? allRoutes)
    {
        if (allRoutes is null)
        {
            return;
        }

        foreach (KeyValuePair<int, Environment> pair in allRoutes)
        {
            _allRoutes.Add(pair);
        }
    }

    public void AddShips(Collection<Ship>? allShips)
    {
        if (allShips is null)
        {
            return;
        }

        foreach (Ship value in allShips)
        {
            _allShips.Add(value);
        }
    }

    public Result Start()
    {
        if (_allRoutes is null)
        {
            return new Result("You Win");
        }

        if (_allShips is null)
        {
            return new Result("Loose! You lost your ship");
        }

        int positionForShip = -1;
        foreach (KeyValuePair<int, Environment> pair in _allRoutes)
        {
            positionForShip++;
            Environment currentroute = pair.Value;
            int currentDistance = pair.Key;
            Ship currentShip = _allShips[positionForShip];

            // если двигатель не подходит для среды - проигрыш
            if (!(currentroute.MatchEnvironmentAndEngine(currentShip.EngineFirst) ||
                  currentroute.MatchEnvironmentAndEngine(currentShip.EngineSecond)))
            {
                return new Result("Loose! You lost your ship");
            }

            // проверяем выдержит ли корабль урон
            foreach (Obstacle obstracle in currentroute.Obstacles)
            {
                // сначала урон выдерживают дефлекторы, если они есть
                if (currentShip.DeflectorOfShip is not null && currentShip.DeflectorOfShip.IsWorking)
                {
                    currentShip.DeflectorOfShip.TakeDamage(obstracle);
                }

                // если урон осался после дефлекторов или их не было, проверяем урон корпусу
                if (obstracle.Damage > 0 && currentShip.CaseOfShip is not null && currentShip.CaseOfShip.IsWorking)
                {
                    currentShip.CaseOfShip.TakeDamage(obstracle);
                }

                // если дефлекторы и корпус уничтожены - поражение
                if (obstracle.Damage > 0)
                {
                    return new Result("Dead! Damage is fatale");
                }
            }

            // активация двигателей
            if (currentShip.EngineFirst is not null && currentShip.EngineSecond is not null)
            {
                _amoutOfFuel += currentShip.EngineFirst.FuelForActivation;
                _amoutOfMatter += currentShip.EngineSecond.FuelForActivation;
            }
            else if (currentShip.EngineFirst is not null)
            {
                _amoutOfFuel += currentShip.EngineFirst.FuelForActivation;
            }
            else if (currentShip.EngineSecond is not null)
            {
                _amoutOfMatter += currentShip.EngineSecond.FuelForActivation;
            }

            // проверяет сможет ли карабль пройти нужное расстояние канала и считаем топливо для прохождения
            if (currentroute.TypeOfEnvironment == TypesOfEnvironments.FoggySpace)
            {
                if (currentShip.EngineSecond is null || currentShip.EngineSecond.RangeOfTravel < currentDistance) return new Result("Loose! You lost your ship");
                _amoutOfMatter += currentroute.CountAmountOfFuel(currentShip, currentDistance);
            }
            else
            {
                _amoutOfFuel += currentroute.CountAmountOfFuel(currentShip, currentDistance);
            }
        }

        return new Result("You Win", _amoutOfFuel, _amoutOfMatter);
    }
}