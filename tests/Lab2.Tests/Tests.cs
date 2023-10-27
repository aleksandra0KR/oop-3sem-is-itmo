using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Fact]

    // first test
    private void EverythingIsFine()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithoutSpecialElements();
        ResultStatus res = builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[0], repo.CpuRepo.CpuList[0], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[0], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[0], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], null, null);
        Assert.Equal("Everything is great. Your computer available!", res.StatusOfComputer);
    }

    [Fact]

    // second test
    private void WorkingButConsumptionHeight()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithoutSpecialElements();
        ResultStatus res = builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[0], repo.CpuRepo.CpuList[1], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[0], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[1], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], null, null);
        Assert.Equal("Everything is working. But Consumption little too height!", res.StatusForPowerUnit);
    }

    [Fact]

    // third test
    private void CoolingSystemIsWeakForCPU()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithoutSpecialElements();
        ResultStatus res = builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[0], repo.CpuRepo.CpuList[1], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[1], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[0], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], null, null);
        Assert.Equal("Cooling System is too week for your CPU TDP, but will work for a while", res.StatusForProcessorCoolingSystem);
    }

    [Fact]

    // fourth test
    private void WrongBios()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithoutSpecialElements();
        ResultStatus res = builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[1], repo.CpuRepo.CpuList[0], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[0], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[0], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], null, null);
        Assert.Equal("Not the needed type of Bios for motherboard, disclaimer of warranty", res.StatusForBIOS);
    }
}