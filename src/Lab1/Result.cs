namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Result
{
    public Result(string statusOfTheTrip, int neededFuel, int neededMatter)
    {
        StatusOfTheTrip = statusOfTheTrip;
        NeededFuel = neededFuel;
        NeededMatter = neededMatter;
    }

    public Result(string statusOfTheTrip)
    {
        StatusOfTheTrip = statusOfTheTrip;
    }

    public string StatusOfTheTrip { get; }
    public int NeededFuel { get; }
    public int NeededMatter { get; }
}