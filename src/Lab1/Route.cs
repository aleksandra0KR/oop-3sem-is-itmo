using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Environment;

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
        if (allRoutes == null)
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
        if (allShips == null)
        {
            return;
        }

        foreach (Ship value in allShips)
        {
            _allShips.Add(value);
        }
    }

    public string Start()
    {
        if (_allRoutes == null)
        {
            return "Win! 0 min, 0 fuel";
        }

        if (_allShips == null)
        {
            return "Loose! You lost your ship";
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
                return "Loose! You lost your ship";
            }

            // проверяем выдержит ли корабль урон
            foreach (Obstacle obstracle in currentroute.Obstacles)
            {
                // сначала урон выдерживают дефлекторы, если они есть
                if (currentShip.DeflectorOfShip != null && currentShip.DeflectorOfShip.IsWorking)
                {
                    currentShip.DeflectorOfShip.TakeDamage(obstracle);
                }

                // если урон осался после дефлекторов или их не было, проверяем урон корпусу
                if (obstracle.Damage > 0 && currentShip.CaseOfShip != null && currentShip.CaseOfShip.IsWorking)
                {
                    currentShip.CaseOfShip.TakeDamage(obstracle);
                }

                // если дефлекторы и корпус уничтожены - поражение
                if (obstracle.Damage > 0)
                {
                    return "Dead! Damage is fatale";
                }
            }

            // активация двигателей
            if (currentShip.EngineFirst != null && currentShip.EngineSecond != null)
            {
                _amoutOfFuel += currentShip.EngineFirst.FuelForActivation;
                _amoutOfMatter += currentShip.EngineSecond.FuelForActivation;
            }
            else if (currentShip.EngineFirst != null)
            {
                _amoutOfFuel += currentShip.EngineFirst.FuelForActivation;
            }
            else if (currentShip.EngineSecond != null)
            {
                _amoutOfMatter += currentShip.EngineSecond.FuelForActivation;
            }

            // проверяет сможет ли карабль пройти нужное расстояние канала и считаем топливо для прохождения
            if (currentroute.TypeOfEnvironment == 'F')
            {
                if (currentShip.EngineSecond == null || currentShip.EngineSecond.RangeOfTravel < currentDistance) return "Loose! You lost your ship";
                _amoutOfMatter += currentroute.CountAmountOfFuel(currentShip, currentDistance);
            }
            else
            {
                _amoutOfFuel += currentroute.CountAmountOfFuel(currentShip, currentDistance);
            }
        }

        return "We need " + _amoutOfFuel + "l of fuel and " + _amoutOfMatter + " of graviton matter";
    }
}