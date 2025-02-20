using Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

public class ConsoleVisitor : IFileSystemComponentVisitor
{
    public IEnumerable<string> Strings { get; private set; }

    private int _depth;

    public ConsoleVisitor()
    {
        Strings = new List<string>();
    }

    public void Visit(FileFileSystemComponent component, int maxDepth)
    {
        WriteIndented(component.Name);
    }

    public void Visit(DirectoryFileSystemComponent component, int maxDepth)
    {
        WriteIndented(component.Name);

        _depth += 1;

        if (maxDepth <= _depth) return;

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this, maxDepth);
        }

        _depth -= 1;
    }

    private void WriteIndented(string value)
    {
        string stringToAppend = new string(" ");
        if (_depth is not 0)
        {
            stringToAppend += string.Concat(Enumerable.Repeat("   ", _depth));
            stringToAppend += "|–> ";
        }

        stringToAppend += value;
        Strings.Append(stringToAppend);
    }
}