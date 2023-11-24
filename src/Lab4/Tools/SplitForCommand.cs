using System.Collections.ObjectModel;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class SplitForCommand
{
    private Collection<string> Path { get; } = new Collection<string>();

    private StringBuilder Element { get; set; } = new StringBuilder();
    public Collection<string> SplitList(string input)
    {
        if (input is null) throw new ValueException("Empty input");
        Path.Clear();
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

        return Path;
    }
}