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
        VideoCardRepository videoCardRepository = VideoCardRepository.Instance;
        videoCardRepository.Faker();
        videoCardRepository.AddNewVideoCard(videoCard);
        Assert.Equal(videoCard, videoCardRepository.VideoCards[videoCardRepository.VideoCards.Count - 1]);
    }

    [Fact]

    // test for new video card based on old one
    private void CreatingNewVideoCardBasesOnOld()
    {
        VideoCardRepository videoCardRepository = VideoCardRepository.Instance;
        videoCardRepository.Faker();
        VideoCard videoCard = videoCardRepository.VideoCards[0];
        if (videoCard.Clone() is not VideoCard new_videCard) return;
        new_videCard.ChipFrequency = 60;
        Assert.Equal(60, new_videCard.ChipFrequency);
        Assert.Equal(50, videoCard.ChipFrequency);
    }

    [Fact]

    // test for new computer card based on old one
    private void CreatingNewComputerBasesOnOld()
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
        Builder newBuilder = builder.CloneComputer();
        newBuilder.SetCpu(repository.CpuRepository.CpuList[0]);
        newBuilder.SetCoolingSystem(repository.ProcessorCoolingSystemRepository.ProcessorCoolingSystemList[0]);
        Computer? computer = builder.GiveComputer();
        newBuilder.SetRAM(computer?.RAM);
        newBuilder.SetPowerUnit(computer?.PowerUnit);
        Assert.Equal("Cooling System is too week for your CPU TDP, but will work for a while", builder.Res.StatusForProcessorCoolingSystem);
        Assert.Equal("Everything is great. Your computer available!", newBuilder.Res.StatusForPowerUnit);
    }

    [Fact]

    // test for computer with wifi and video card
    private void ComputerWithWIFIAndVideoCard()
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
        builder.SetVideoCard(repository.VideoCardRepository.VideoCards[0]);
        builder.SetWiFi(repository.WifiRepository.WiFiLIst[0]);
        Assert.Equal("Everything is great. Your computer available!", builder.Res.StatusOfComputer);
        Computer? computer = builder.GiveComputer();
        Assert.Equal(repository.VideoCardRepository.VideoCards[0], computer?.VideoCard);
        Assert.Equal(repository.WifiRepository.WiFiLIst[0], computer?.WiFi);
    }
}