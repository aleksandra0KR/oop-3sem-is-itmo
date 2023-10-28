using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Builder
{
    public ResultStatus Res { get; set; } = new ResultStatus();
    private Computer Computer { get; } = new Computer();
    public Builder CloneComputer()
    {
        var builder = new Builder();
        builder.Res = Res;
        builder.Computer.Motherboard = Computer.Motherboard;
        builder.Computer.Bios = Computer.Bios;
        builder.Computer.Cpu = Computer.Cpu;
        builder.Computer.CoolingSystem = Computer.CoolingSystem;
        builder.Computer.RAM = Computer.RAM;
        builder.Computer.CaseOfComputer = Computer.CaseOfComputer;
        builder.Computer.PowerUnit = Computer.PowerUnit;
        return builder;
    }

    public void SetMotherboard(Motherboard? motherboard)
    {
        if (motherboard is null) throw new ValueException("Empty motherboard");
        Computer.Motherboard = motherboard;
    }

    public void SetBIOS(BIOS? bios)
    {
        if (bios is null) throw new ValueException("Empty bios");
        if (Computer.Motherboard?.TypeOfBIOS != bios.TypeOfBios)
        {
            Res.StatusForBIOS = "Not the needed type of Bios for motherboard, disclaimer of warranty";
            Res.HasProblems = true;
        }

        Computer.Bios = bios;
    }

    public void SetCpu(Cpu? cpu)
    {
        if (cpu is null) throw new ValueException("Empty cpu");
        if (Computer.Motherboard?.Socket != cpu.Socket)
        {
            Res.StatusForCPU = "Not the needed type of Bios for motherboard, disclaimer of warranty";
            Res.HasProblems = true;
        }

        if (Computer.Bios?.NeededCPU is not null)
        {
            if (Computer.Bios.NeededCPU.Any(neededCpu => neededCpu == cpu.TypeOfCPU))
            {
                Computer.Cpu = cpu;
                return;
            }
        }

        Computer.Cpu = cpu;
        Res.StatusForCPU = "Not the needed type of CPU for BIOS, disclaimer of warranty";
        Res.HasProblems = true;
    }

    public void SetCoolingSystem(ProcessorCoolingSystem? processorCoolingSystem)
    {
        if (processorCoolingSystem is null) throw new ValueException("Empty Cooling System");
        if (Computer.Cpu?.TDP <= processorCoolingSystem.TDP)
        {
            Computer.CoolingSystem = processorCoolingSystem;
            return;
        }

        if (Computer.Cpu?.TDP <= 2 * processorCoolingSystem.TDP)
        {
            Computer.CoolingSystem = processorCoolingSystem;
            Res.StatusForProcessorCoolingSystem = "Cooling System is too week for your CPU TDP, but will work for a while";
            Res.HasProblems = true;
            return;
        }

        Res.HasProblems = true;
        Res.StatusForProcessorCoolingSystem = "Cooling System is too week for your CPU TDP, disclaimer of warranty";
    }

    public void SetRAM(RandomAccessMemory? randomAccessMemory)
    {
        if (randomAccessMemory is null) throw new ValueException("Empty RAM");
        if (randomAccessMemory.Frequency < Computer.Cpu?.MaxSupportedMemoryFrequencies)
        {
            Res.StatusForRAM = "RAM frequency not enough for CPU, disclaimer of warranty";
            Res.HasProblems = true;
        }

        Computer.RAM = randomAccessMemory;
    }

    public void SetCase(CaseOfComputer? caseOfComputer)
    {
        if (caseOfComputer is null) throw new ValueException("Empty Case");
        if (Computer.Motherboard?.FormFactor is not null)
        {
            if (caseOfComputer.DimensionOfMotherBoard.Any(neededForm => neededForm == Computer.Motherboard.FormFactor))
            {
                Computer.CaseOfComputer = caseOfComputer;
                return;
            }
        }

        Res.HasProblems = true;
        Computer.CaseOfComputer = caseOfComputer;
        Res.StatusForCaseOfComputer = "Not the needed type of Form Factor for Mother board, disclaimer of warranty";
    }

    public void SetDrive(SSD? ssd, Hdd? hdd)
    {
        if (ssd is null && hdd is null) throw new ValueException("Empty HDD and SSD");
        Computer.Hdd = hdd;
        Computer.Ssd = ssd;
    }

    public void SetPowerUnit(PowerUnit? powerUnit)
    {
        if (powerUnit is null) throw new ValueException("Empty Power Unit");
        if (2 * powerUnit.MaximumLoad < Computer.Cpu?.PowerConsumption)
        {
            Res.StatusForPowerUnit = "Not enough power for CPU, disclaimer of warranty";
            Res.HasProblems = true;
            Computer.PowerUnit = powerUnit;
            return;
        }

        if (2 * powerUnit.MaximumLoad >= Computer.Cpu?.PowerConsumption &&
            powerUnit.MaximumLoad < Computer.Cpu?.PowerConsumption)
        {
            Res.StatusForPowerUnit = "Everything is working. But Consumption little too height!";
            Res.HasProblems = true;
            Computer.PowerUnit = powerUnit;
            return;
        }

        Res.StatusOfComputer = !Res.HasProblems ? "Everything is great. Your computer available!" : "Your computer has problems!";
        Computer.PowerUnit = powerUnit;
    }

    public void SetVideoCard(VideoCard? videoCard)
    {
        if (Computer.Cpu != null && videoCard is null && !Computer.Cpu.EmbeddedVideoCore)
            throw new ValueException("Empty Video Card");
        Computer.VideoCard = videoCard;
    }

    public void SetWiFi(WiFI? wifi)
    {
        Computer.WiFi = wifi;
    }

    public Computer? GiveComputer()
    {
        if (Computer.Motherboard is not null && Computer.Cpu is not null && Computer.Bios is not null && Computer.CaseOfComputer is not null && Computer.CoolingSystem is not null && Computer.PowerUnit is not null && Computer.RAM is not null) return Computer;
        return null;
    }
}