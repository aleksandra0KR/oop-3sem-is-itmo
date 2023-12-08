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
        var fileMock = new Mock<CommandFileDelete>(filePath);

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
        var fileMock = new Mock<CommandFileMove>(sourceFilePath, destinationFilePath);

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
        var fileMock = new Mock<CommandFileCopy>(sourceFilePath, destinationFilePath);

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
        var fileMock = new Mock<CommandFileRename>(sourceFilePath, destinationname);

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

        var fileMock = new Mock<CommandTreeList>("3");

        fileMock.Object.Execute(fileSystem);

        fileMock.Verify(f => f.Execute(fileSystem), Times.Once);
    }
}
