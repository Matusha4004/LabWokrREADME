using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDirectory;

public class DisplayDriver
{
    public Color Color { get; private set; }

    public void PrintInConsole(string text)
    {
        Console.Clear();

        Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(text));
    }

    public void PrintInFile(string text)
    {
        var fileStream = new StreamWriter("SomeFile.txt");

        fileStream.WriteLine(text);
    }

    public void DisplayClear()
    {
        Console.Clear();
    }

    public void MakeColor(byte r, byte g, byte b)
    {
        Color = Color.FromArgb(r, g, b);
    }
}