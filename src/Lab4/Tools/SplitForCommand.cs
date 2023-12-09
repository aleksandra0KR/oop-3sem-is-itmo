using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class SplitForCommand
{
    private Collection<string> Path { get; } = new();
    private Dictionary<string, string> Commands { get; } = new();

    private StringBuilder Element { get; set; } = new StringBuilder();
    public Dictionary<string, string> SplitList(string input)
    {
        if (input is null) throw new ValueException("Empty input");
        Path.Clear();
        Commands.Clear();
        Element = new StringBuilder();

        bool insideQuotes = false;

        foreach (char letter in input)
        {
            switch (letter)
            {
                case ' ' when !insideQuotes:
                {
                    if (Element.Length > 0)
                    {
                        Path.Add(Element.ToString());
                        Element.Clear();
                    }

                    break;
                }

                case '"':
                    insideQuotes = !insideQuotes;
                    break;

                default:
                    Element.Append(letter);
                    break;
            }
        }

        if (Element.Length > 0)
        {
            Path.Add(Element.ToString());
        }

        for (int i = 0; i < Path.Count; i += 1)
        {
            Commands.Add(Path[i], Path[i + 1]);
        }

        return Commands;
    }
}