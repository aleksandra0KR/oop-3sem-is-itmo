namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class CommonRepo
{
    private static CommonRepo? _instance;
    private CommonRepo()
    { }
    public static CommonRepo Instance => _instance ??= new CommonRepo();
    public MotherboardRepo MotherboardRepo { get; } = MotherboardRepo.Instance;
    public CPURepo CpuRepo { get; } = CPURepo.Instance;
    public BIOSRepo BiosRepo { get; } = BIOSRepo.Instance;
    public ProcessorCoolingSystemRepo ProcessorCoolingSystemRepo { get; } = ProcessorCoolingSystemRepo.Instance;
    public RAMRepo RamRepo { get; } = RAMRepo.Instance;
    public CaseRepo CaseRepo { get; } = CaseRepo.Instance;
    public PowerUnitRepo PowerUnitRepo { get; } = PowerUnitRepo.Instance;
    public SSDRepo SsdRepo { get; } = SSDRepo.Instance;
    public HDDRepo HddRepo { get; } = HDDRepo.Instance;
    public VideoCardRepo VideoCardRepo { get; } = VideoCardRepo.Instance;
    public WIFIRepo WifiRepo { get; } = WIFIRepo.Instance;
}