using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class VideoCardRepository
{
    private static VideoCardRepository? _instance;

    private VideoCardRepository() { }

    public static VideoCardRepository Instance => _instance ??= new VideoCardRepository();
    public Collection<VideoCard> VideoCards { get; } = new();

    public void Faker()
    {
        VideoCards.Add(new VideoCard(new Dimensions(300, 300), 20, 3, 50, 50));
    }

    public void AddNewVideoCard(VideoCard videoCard)
    {
        if (videoCard is null) throw new ValueException("Empty Video Card");
        VideoCards.Add(videoCard);
    }
}