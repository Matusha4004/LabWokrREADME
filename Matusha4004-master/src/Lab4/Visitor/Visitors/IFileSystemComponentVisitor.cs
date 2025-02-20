using Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component, int maxDepth);

    void Visit(DirectoryFileSystemComponent component, int maxDepth);
}