using Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;

public interface IFileSystemComponent
    {
        string Name { get; }

        void Accept(IFileSystemComponentVisitor visitor, int maxDepth);
    }
