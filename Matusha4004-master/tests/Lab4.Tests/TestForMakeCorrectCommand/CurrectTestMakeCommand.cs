using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests.TestForMakeCorrectCommand;

public class CurrectTestMakeCommand
{
    [Fact]
    public void MakeCorrectFileShowCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(tempDirPath);

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"file show {tempDirPath} -m Test" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is FileShowCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectFileCopyCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"file copy {tempDirPath} {tempDirPath}" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is FileCopyCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectFileDeleteCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"file delete {tempDirPath}" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is FileDeleteCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectFileMoveCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"file move {tempDirPath} {tempDirPath}" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is FileMoveCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectFileRenameCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"file rename {tempDirPath} qwe" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is FileRenameCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectTreeGoToCommandTest()
    {
        string tempFilePath = Path.GetTempFileName();
        string tempDirPath = Path.GetTempPath();

        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { $"tree goto {tempDirPath}" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is TreeGoToCommand);

        File.Delete(tempFilePath);
    }

    [Fact]
    public void MakeCorrectTreeListCommandTest()
    {
        var local = new LocalFileSystem(" ");

        var commandRunner = new CommandRunner(local);

        string[] a = new string[] { "tree list -d 2" };

        ICommand? q = commandRunner.Run(a);

        Assert.True(q is TreeListCommand);
    }
}