namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract class Builder
{
    public Computer Computer { get; } = new();
    public ResultStatus Res { get; private set; } = new();

    public ResultStatus MakeComputer(Motherboard? motherboard, BIOS? bios, CPU? cpu, ProcessorCoolingSystem? processorCoolingSystem, RandomAccessMemory? randomAccessMemory, CaseOfComputer? caseOfComputer, PowerUnit? powerUnit, SSD? ssd, Hdd? hdd, VideoCard? videoCard, WiFI? wifi)
    {
        SetMotherboard(motherboard);
        SetBIOS(bios);
        SetCpu(cpu);
        SetCoolingSystem(processorCoolingSystem);
        SetRAM(randomAccessMemory);
        SetCase(caseOfComputer);
        SetPowerUnit(powerUnit);
        SetVideoCard(videoCard);
        SetWiFi(wifi);
        SetDrive(ssd, hdd);
        return Res;
    }

    public Builder CloneComputer()
    {
        Builder builder = new BuilderWithoutSpecialElements();
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

    public abstract void SetMotherboard(Motherboard? motherboard);
    public abstract void SetBIOS(BIOS? bios);
    public abstract void SetCpu(CPU? cpu);
    public abstract void SetCoolingSystem(ProcessorCoolingSystem? processorCoolingSystem);
    public abstract void SetRAM(RandomAccessMemory? randomAccessMemory);
    public abstract void SetCase(CaseOfComputer? caseOfComputer);
    public abstract void SetDrive(SSD? ssd, Hdd? hdd);
    public abstract void SetPowerUnit(PowerUnit? powerUnit);
    public abstract void SetVideoCard(VideoCard? videoCard);
    public abstract void SetWiFi(WiFI? wifi);
}