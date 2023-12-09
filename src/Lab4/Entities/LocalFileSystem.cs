namespace Itmo.ObjectOrientedProgramming.Lab4.FS;

public class LocalFileSystem : Filesystem
{
    public override bool IsConnected()
    {
        return AbsolutePath is not null;
    }
}