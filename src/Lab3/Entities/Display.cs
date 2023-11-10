using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Display : User
{
    public Display()
    {
        Name = "Best ever display";
    }

    public Display(string name)
    {
        Name = name;
    }

    private byte Red { get; set; }
    private byte Green { get; set; }
    private byte Blue { get; set; }

    public override void Logging()
    {
        Console.WriteLine(Name + " Message is delivered ");
    }

    public void GetColor(byte red, byte green, byte blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public override void GetMessage(Message message)
    {
        RepositoryForMessages.AddMessage(message, null);
        if (message is null) throw new ValueException("Empty message");
        Console.WriteLine(Rgb(Red, Green, Blue).Text(message.Body));

        const string path = "log.txt";

        using var writer = new StreamWriter(path, false);
        writer.WriteLineAsync(Rgb(Red, Green, Blue).Text(message.Body));
        Logging();
    }
}