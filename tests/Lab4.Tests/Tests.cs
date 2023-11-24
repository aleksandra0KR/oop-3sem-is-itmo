using Itmo.ObjectOrientedProgramming.Lab4.FS;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]

    private void CheckConnection()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);
        Assert.True(fileSystem.IsConnected());
    }

    [Fact]

    private void CheckDelete()
    {
        State state = new LocalConnectionState("/Users/aleksandrakr/desktop/file.txt");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);
        string filePath = "/Users/aleksandrakr/desktop/file.txt";
        State state2 = new LocalFileDelete(filePath);
        var fileMock = new Mock<CommandFileDelete>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }

    [Fact]
    private void CheckMove()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);

        string sourceFilePath = "C/users/ITMO/source.txt";
        string destinationFilePath = "C/users/ITMO/destination.txt";
        State state2 = new LocalFileMove(sourceFilePath, destinationFilePath);
        var fileMock = new Mock<CommandFileMove>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }

    [Fact]
    private void CheckCopy()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);

        string sourceFilePath = "C/users/ITMO/source";
        string destinationFilePath = "C/users/ITMO/destination";
        State state2 = new LocalCopyFile(sourceFilePath, destinationFilePath);
        var fileMock = new Mock<CommandFileCopy>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }

    [Fact]
    private void CheckRename()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);

        string sourceFilePath = "C/users/ITMO/source.txt";
        string destinationname = "destination.txt";
        State state2 = new LocalFileRename(sourceFilePath, destinationname);
        var fileMock = new Mock<CommandFileRename>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }

    [Fact]
    private void CheckShow()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);

        string sourceFilePath = "C/users/ITMO/source.txt";
        State state2 = new LocalFileShow(sourceFilePath);
        var fileMock = new Mock<CommandFileShow>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }

    [Fact]
    private void CheckTreeList()
    {
        State state = new LocalConnectionState("C/users/ITMO");
        Command command = new CommandConnect(state);
        Filesystem fileSystem = new LocalFileSystem();
        command.Execute(fileSystem);

        State state2 = new LocalTreeList("3");
        var fileMock = new Mock<CommandTreeList>(state2);

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }
}
