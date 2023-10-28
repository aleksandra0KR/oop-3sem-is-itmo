namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Motherboard : IComponent
{
    public Motherboard(string socket, int pcie, int sata, int chipset, int ddr, int numberOfTablesUnderRam,  string formFactor, double versionOfBios, string typeOfBios)
    {
        Socket = socket;
        PCIE = pcie;
        SATA = sata;
        Chipset = chipset;
        DDR = ddr;
        NumberOfTablesUnderRAM = numberOfTablesUnderRam;
        FormFactor = formFactor;
        VersionOfBIOS = versionOfBios;
        TypeOfBIOS = typeOfBios;
    }

    public string Socket { get; }
    public string TypeOfBIOS { get; }
    public string FormFactor { get; }
    private int SATA { get; }
    private int Chipset { get; }
    private int PCIE { get; }
    private int DDR { get; }
    private int NumberOfTablesUnderRAM { get; }
    private double VersionOfBIOS { get; }

    public IComponent Clone()
    {
        return new Motherboard(Socket, PCIE, SATA, Chipset, DDR, NumberOfTablesUnderRAM, FormFactor, VersionOfBIOS, TypeOfBIOS);
    }
}