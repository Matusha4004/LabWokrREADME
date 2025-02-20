using Itmo.ObjectOrientedProgramming.Lab4.Visitor.FileSystemComponent;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileSystem : IFileSystem
{
    private readonly string _masterPath;
    private string _currectPath;

    public LocalFileSystem(string masterPath)
    {
        _masterPath = masterPath;
        _currectPath = _masterPath;
    }

    public void TreeGoTo(string path)
    {
        if (Directory.Exists(path))
        {
            _currectPath = path;
        }
        else
        {
            _currectPath = _currectPath + path;
        }

        return;
}

    public string[] TreeList(int depth = 1)
    {
        var factory = new FileSystemComponenentFactory();
        IFileSystemComponent rootComponent = factory.Create(_currectPath);

        var visitor = new ConsoleVisitor();

        return visitor.Strings.ToArray();
    }

    public string[] FileShow(string path, string? mode = null)
    {
        string[] q = File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
        return q;
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
        return;
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
        return;
    }

    public void FileDelete(string path)
    {
        File.Delete(path);
        return;
    }

    public void FileRename(string path, string newName)
    {
        File.Move(path, path + newName);
        return;
    }
}