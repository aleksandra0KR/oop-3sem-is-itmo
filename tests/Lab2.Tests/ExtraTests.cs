using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ExtraTests
{
    [Fact]

    // test for new video card from scratch and adding new product to repository
    private void CreatingNewVideoCardFromScratchAndAddingNewProductToRepo()
    {
        var videoCard = new VideoCard(new Dimensions(100, 100), 40, 2, 55, 45);
        VideoCardRepo videoCardRepo = VideoCardRepo.Instance;
        videoCardRepo.AddNewVideoCard(videoCard);
        Assert.Equal(videoCard, videoCardRepo.VideoCards[1]);
    }

    [Fact]

    // test for new video card based on old one
    private void CreatingNewVideoCardBasesOnOld()
    {
        VideoCardRepo videoCardRepo = VideoCardRepo.Instance;
        VideoCard videoCard = videoCardRepo.VideoCards[0];
        if (videoCard.Clone() is not VideoCard new_videCard) return;
        new_videCard.ChipFrequency = 60;
        Assert.Equal(60, new_videCard.ChipFrequency);
        Assert.Equal(50, videoCard.ChipFrequency);
    }

    [Fact]

    // test for new computer card based on old one
    private void CreatingNewComputerBasesOnOld()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithoutSpecialElements();
        builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[0], repo.CpuRepo.CpuList[1], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[1], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[0], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], null, null);
        Builder newBuilder = builder.CloneComputer();
        newBuilder.SetCpu(repo.CpuRepo.CpuList[0]);
        newBuilder.SetCoolingSystem(repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[0]);
        newBuilder.SetRAM(newBuilder.Computer.RAM);
        newBuilder.SetPowerUnit(newBuilder.Computer.PowerUnit);
        Assert.Equal("Cooling System is too week for your CPU TDP, but will work for a while", builder.Res.StatusForProcessorCoolingSystem);
        Assert.Equal("Everything is great. Your computer available!", newBuilder.Res.StatusForPowerUnit);
    }

    [Fact]

    // test for computer with wifi and video card
    private void ComputerWithWIFIAndVideoCard()
    {
        CommonRepo repo = CommonRepo.Instance;
        var builder = new BuilderWithExcesses();
        ResultStatus res = builder.MakeComputer(repo.MotherboardRepo.MotherboardList[0], repo.BiosRepo.BiosList[0], repo.CpuRepo.CpuList[0], repo.ProcessorCoolingSystemRepo.ProcessorCoolingSystemList[0], repo.RamRepo.RamList[0], repo.CaseRepo.CaseList[0], repo.PowerUnitRepo.PowerUnitList[0], repo.SsdRepo.SSDList[0], repo.HddRepo.HddList[0], repo.VideoCardRepo.VideoCards[0], repo.WifiRepo.WiFiLIst[0]);
        Assert.Equal("Everything is great. Your computer available!", res.StatusOfComputer);
        Assert.Equal(repo.VideoCardRepo.VideoCards[0], builder.Computer.VideoCard);
        Assert.Equal(repo.WifiRepo.WiFiLIst[0], builder.Computer.WiFi);
    }
}