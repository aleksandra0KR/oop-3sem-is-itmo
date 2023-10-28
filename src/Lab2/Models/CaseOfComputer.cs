using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class CaseOfComputer : IComponent
{
    public CaseOfComputer(int maxWidthOfVideoCard, int maxLenghtOfVideoCard, Collection<string> supportedFormFactorsOfMotherboards, Dimensions dimension)
    {
        MaxWidthOfVideoCard = maxWidthOfVideoCard;
        MaxLenghtOfVideoCard = maxLenghtOfVideoCard;
        DimensionOfMotherBoard = supportedFormFactorsOfMotherboards;
        Dimension = dimension;
    }

    public Collection<string> DimensionOfMotherBoard { get; }
    private int MaxWidthOfVideoCard { get; }
    private int MaxLenghtOfVideoCard { get; }
    private Dimensions Dimension { get; }

    public IComponent Clone()
    {
        return new CaseOfComputer(MaxWidthOfVideoCard, MaxLenghtOfVideoCard, DimensionOfMotherBoard, Dimension);
    }
}