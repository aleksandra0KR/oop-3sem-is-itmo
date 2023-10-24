using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class VideoCardRepo
{
    private static VideoCardRepo? _instance;

    private VideoCardRepo()
    {
        VideoCards.Add(new VideoCard(new Dimensions(300, 300), 20, 3, 50, 50));
    }

    public static VideoCardRepo Instance => _instance ??= new VideoCardRepo();
    public Collection<VideoCard> VideoCards { get; } = new();
    public void AddNewVideoCard(VideoCard videoCard)
    {
        if (videoCard is null) throw new ValueException("Empty Video Card");
        VideoCards.Add(videoCard);
    }
}