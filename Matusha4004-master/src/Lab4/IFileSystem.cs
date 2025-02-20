namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystem
{
    void TreeGoTo(string path);

    string[] TreeList(int depth = 1);

    string[] FileShow(string path, string? mode = null);

    void FileMove(string sourcePath, string destinationPath);

    void FileCopy(string sourcePath, string destinationPath);

    void FileDelete(string path);

    void FileRename(string path, string newName);
}