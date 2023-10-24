namespace Itmo.ObjectOrientedProgramming.Lab2;

public class BuilderWithExcesses : BuilderWithoutSpecialElements
{
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