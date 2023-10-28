using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Fact]

    // first test
    private void EverythingIsFine()
    {
        CommonRepository repository = CommonRepository.Instance;
        repository.Faker();
        var builder = new Builder();
        builder.SetMotherboard(repository.MotherboardRepository.MotherboardList[0]);
        builder.SetBIOS(repository.BiosRepository.BiosList[0]);
        builder.SetCpu(repository.CpuRepository.CpuList[0]);
        builder.SetCoolingSystem(repository.ProcessorCoolingSystemRepository.ProcessorCoolingSystemList[0]);
        builder.SetRAM(repository.RamRepository.RamList[0]);
        builder.SetCase(repository.CaseRepository.CaseList[0]);
        builder.SetPowerUnit(repository.PowerUnitRepository.PowerUnitList[0]);
        builder.SetDrive(repository.SsdRepository.SSDList[0],  repository.HddRepository.HddList[0]);
        Assert.Equal("Everything is great. Your computer available!", builder.Res.StatusOfComputer);
    }

    [Fact]

    // second test
    private void WorkingButConsumptionHeight()
    {
        CommonRepository repository = CommonRepository.Instance;
        repository.Faker();
        var builder = new Builder();
        builder.SetMotherboard(repository.MotherboardRepository.MotherboardList[0]);
        builder.SetBIOS(repository.BiosRepository.BiosList[0]);
        builder.SetCpu(repository.CpuRepository.CpuList[1]);
        builder.SetCoolingSystem(repository.ProcessorCoolingSystemRepository.ProcessorCoolingSystemList[0]);
        builder.SetRAM(repository.RamRepository.RamList[0]);
        builder.SetCase(repository.CaseRepository.CaseList[0]);
        builder.SetPowerUnit(repository.PowerUnitRepository.PowerUnitList[1]);
        builder.SetDrive(repository.SsdRepository.SSDList[0],  repository.HddRepository.HddList[0]);
        Assert.Equal("Everything is working. But Consumption little too height!", builder.Res.StatusForPowerUnit);
    }

    [Fact]

    // third test
    private void CoolingSystemIsWeakForCPU()
    {
        CommonRepository repository = CommonRepository.Instance;
        repository.Faker();
        var builder = new Builder();
        builder.SetMotherboard(repository.MotherboardRepository.MotherboardList[0]);
        builder.SetBIOS(repository.BiosRepository.BiosList[0]);
        builder.SetCpu(repository.CpuRepository.CpuList[1]);
        builder.SetCoolingSystem(repository.ProcessorCoolingSystemRepository.ProcessorCoolingSystemList[1]);
        builder.SetRAM(repository.RamRepository.RamList[0]);
        builder.SetCase(repository.CaseRepository.CaseList[0]);
        builder.SetPowerUnit(repository.PowerUnitRepository.PowerUnitList[0]);
        builder.SetDrive(repository.SsdRepository.SSDList[0],  repository.HddRepository.HddList[0]);
        Assert.Equal("Cooling System is too week for your CPU TDP, but will work for a while", builder.Res.StatusForProcessorCoolingSystem);
    }

    [Fact]

    // fourth test
    private void WrongBios()
    {
        CommonRepository repository = CommonRepository.Instance;
        repository.Faker();
        var builder = new Builder();
        builder.SetMotherboard(repository.MotherboardRepository.MotherboardList[0]);
        builder.SetBIOS(repository.BiosRepository.BiosList[1]);
        builder.SetCpu(repository.CpuRepository.CpuList[0]);
        builder.SetCoolingSystem(repository.ProcessorCoolingSystemRepository.ProcessorCoolingSystemList[0]);
        builder.SetRAM(repository.RamRepository.RamList[0]);
        builder.SetCase(repository.CaseRepository.CaseList[0]);
        builder.SetPowerUnit(repository.PowerUnitRepository.PowerUnitList[0]);
        builder.SetDrive(repository.SsdRepository.SSDList[0],  repository.HddRepository.HddList[0]);
        Assert.Equal("Not the needed type of Bios for motherboard, disclaimer of warranty", builder.Res.StatusForBIOS);
    }
}