namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BuilderWithExcesses : BuilderWithoutSpecialElements
{
    public ResultStatus MakeComputer(Motherboard? motherboard, BIOS? bios, CPU? cpu, ProcessorCoolingSystem? processorCoolingSystem, RandomAccessMemory? randomAccessMemory, CaseOfComputer? caseOfComputer, PowerUnit? powerUnit, SSD? ssd, Hdd? hdd, VideoCard? videoCard, WiFI? wiFi)
    {
        SetMotherboard(motherboard);
        SetBIOS(bios);
        SetCpu(cpu);
        SetCoolingSystem(processorCoolingSystem);
        SetRAM(randomAccessMemory);
        SetCase(caseOfComputer);
        SetPowerUnit(powerUnit);
        SetDrive(ssd, hdd);
        SetVideoCard(videoCard);
        SetWiFi(wiFi);
        return Res;
    }

    public override void SetVideoCard(VideoCard? videoCard)
    {
        if (Computer.Cpu != null && videoCard is null && !Computer.Cpu.EmbeddedVideoCore)
            throw new ValueException("Empty Video Card");
        Computer.VideoCard = videoCard;
    }

    public override void SetWiFi(WiFI? wifi)
    {
        Computer.WiFi = wifi;
    }
}