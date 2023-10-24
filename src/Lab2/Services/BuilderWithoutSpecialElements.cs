namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BuilderWithoutSpecialElements : Builder
{
    public override void SetMotherboard(Motherboard? motherboard)
    {
        if (motherboard is null) throw new ValueException("Empty motherboard");
        Computer.Motherboard = motherboard;
    }

    public override void SetBIOS(BIOS? bios)
    {
        if (bios is null) throw new ValueException("Empty bios");
        if (Computer.Motherboard?.TypeOfBIOS != bios.TypeOfBios)
        {
            Res.StatusForBIOS = "Not the needed type of Bios for motherboard, disclaimer of warranty";
            Res.HasProblems = true;
        }

        Computer.Bios = bios;
    }

    public override void SetCpu(CPU? cpu)
    {
        if (cpu is null) throw new ValueException("Empty cpu");
        if (Computer.Motherboard?.Socket != cpu.Socket)
        {
            Res.StatusForCPU = "Not the needed type of Bios for motherboard, disclaimer of warranty";
            Res.HasProblems = true;
        }

        if (Computer.Bios?.NeededCPU is not null)
        {
            foreach (string neededCpu in Computer.Bios.NeededCPU)
            {
                if (neededCpu == cpu.TypeOfCPU)
                {
                    Computer.Cpu = cpu;
                    return;
                }
            }
        }

        Computer.Cpu = cpu;
        Res.StatusForCPU = "Not the needed type of CPU for BIOS, disclaimer of warranty";
        Res.HasProblems = true;
    }

    public override void SetCoolingSystem(ProcessorCoolingSystem? processorCoolingSystem)
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

    public override void SetRAM(RandomAccessMemory? randomAccessMemory)
    {
        if (randomAccessMemory is null) throw new ValueException("Empty Cooling RAM");
        if (randomAccessMemory.Frequency < Computer.Cpu?.MaxSupportedMemoryFrequencies)
        {
            Res.StatusForRAM = "RAM frequency not enough for CPU, disclaimer of warranty";
            Res.HasProblems = true;
        }

        Computer.RAM = randomAccessMemory;
    }

    public override void SetCase(CaseOfComputer? caseOfComputer)
    {
        if (caseOfComputer is null) throw new ValueException("Empty Cooling Case");
        if (Computer.Motherboard?.FormFactor is not null)
        {
            foreach (string neededForm in caseOfComputer.DimensionOfMotherBoard)
            {
                if (neededForm == Computer.Motherboard.FormFactor)
                {
                    Computer.CaseOfComputer = caseOfComputer;
                    return;
                }
            }
        }

        Res.HasProblems = true;
        Computer.CaseOfComputer = caseOfComputer;
        Res.StatusForCaseOfComputer = "Not the needed type of Form Factor for Mother board, disclaimer of warranty";
    }

    public override void SetDrive(SSD? ssd, Hdd? hdd)
    {
        if (ssd is null && hdd is null) throw new ValueException("Empty HDD and SSD");
        Computer.Hdd = hdd;
        Computer.Ssd = ssd;
    }

    public override void SetPowerUnit(PowerUnit? powerUnit)
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

    public override void SetVideoCard(VideoCard? videoCard)
    { }

    public override void SetWiFi(WiFI? wifi)
    { }
}