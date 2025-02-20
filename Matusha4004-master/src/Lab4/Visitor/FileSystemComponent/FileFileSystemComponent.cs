using Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;

public class FileFileSystemComponent : IFileSystemComponent
{
    public FileFileSystemComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemComponentVisitor visitor, int maxDepth)
    {
        visitor.Visit(this, maxDepth);
    }
}