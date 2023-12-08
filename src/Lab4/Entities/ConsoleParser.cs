using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConsoleParser : CommandParser
{
    public static CommandParser InitializeParser()
    {
        CommandParserWithParameters parser1 = new FileShowCommandParser();
        parser1.SetNextParameter(new ConsoleModeShow());
        CommandParser parser = new TreeGoToCommandParser();
        parser1.SetNextHandler(parser);
        CommandParser parser3 = new FileMoveCommandParser();
        parser3.SetNextHandler(parser1);
        CommandParser parser4 = new FileDeleteCommandParser();
        parser4.SetNextHandler(parser3);
        CommandParser parser5 = new FileCopyCommandParser();
        parser5.SetNextHandler(parser4);
        CommandParser parser6 = new DisconnectCommandParser();
        parser6.SetNextHandler(parser5);
        CommandParserWithParameters parser7 = new ConnectCommandParser();
        parser7.SetNextParameter(new ConnectCommandParser());
        parser7.SetNextHandler(parser6);
        CommandParser parser8 = new FileRenameCommandParser();
        parser8.SetNextHandler(parser7);
        CommandParser parser9 = new TreeListCommandParser();
        parser9.SetNextHandler(parser8);
        return parser9;
    }
}