namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CommonRepository
{
    private static CommonRepository? _instance;
    private CommonRepository()
    { }
    public static CommonRepository Instance => _instance ??= new CommonRepository();
    public MotherboardRepository MotherboardRepository { get; } = MotherboardRepository.Instance;
    public CpuRepository CpuRepository { get; } = CpuRepository.Instance;
    public BIOSRepository BiosRepository { get; } = BIOSRepository.Instance;
    public ProcessorCoolingSystemRepository ProcessorCoolingSystemRepository { get; } = ProcessorCoolingSystemRepository.Instance;
    public RAMRepository RamRepository { get; } = RAMRepository.Instance;
    public CaseRepository CaseRepository { get; } = CaseRepository.Instance;
    public PowerUnitRepository PowerUnitRepository { get; } = PowerUnitRepository.Instance;
    public SSDRepository SsdRepository { get; } = SSDRepository.Instance;
    public HDDRepository HddRepository { get; } = HDDRepository.Instance;
    public VideoCardRepository VideoCardRepository { get; } = VideoCardRepository.Instance;
    public WIFIRepository WifiRepository { get; } = WIFIRepository.Instance;

    public void Faker()
    {
        BiosRepository.Faker();
        CaseRepository.Faker();
        CpuRepository.Faker();
        HddRepository.Faker();
        MotherboardRepository.Faker();
        PowerUnitRepository.Faker();
        ProcessorCoolingSystemRepository.Faker();
        RamRepository.Faker();
        SsdRepository.Faker();
        VideoCardRepository.Faker();
        WifiRepository.Faker();
    }
}