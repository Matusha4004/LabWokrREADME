using Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(
        string name,
        IReadOnlyCollection<IFileSystemComponent> components)
    {
        Name = name;
        Components = components;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components { get; }

    public void Accept(IFileSystemComponentVisitor visitor, int maxDepth)
    {
        visitor.Visit(this, maxDepth);
    }
}