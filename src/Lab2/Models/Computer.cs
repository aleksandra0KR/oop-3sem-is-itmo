namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Computer
{
    public Motherboard? Motherboard { get; set; }
    public BIOS? Bios { get; set; }
    public CPU? Cpu { get; set; }
    public ProcessorCoolingSystem? CoolingSystem { get; set; }
    public RandomAccessMemory? RAM { get; set; }
    public CaseOfComputer? CaseOfComputer { get; set; }
    public Hdd? Hdd { get; set; }
    public SSD? Ssd { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public VideoCard? VideoCard { get; set; }
    public WiFI? WiFi { get; set; }
}