using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FIleCopyInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileDeleteInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileMoveInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileRenameInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.FileShowInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeGoToInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.CommandCreator.Handler.TreeListInnerHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandCreator;

public class CommandRunner : ICommandRunner
{
    private readonly IFileSystem _fileSystem;
    private readonly FileCopyHandler _handler;

    public CommandRunner(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;

        var copyInnerDestination = new FileCopyInnerHandlerDestinationPath();
        var copyInnerSource = new FileCopyInnerHandlerSourcePath();
        copyInnerSource.AddNext(copyInnerDestination);

        var deleteInner = new FileDeleteInnerHandlerPath();

        var moveInnerSource = new FileMoveInnerHandlerSourcePath();
        var moveInnerDestination = new FileMoveInnerHandlerDestinationPath();
        moveInnerSource.AddNext(moveInnerDestination);

        var renameInnerName = new FileRenameInnerHandlerName();
        var renameInnerPath = new FileRenameInnerHandlerPath();
        renameInnerName.AddNext(renameInnerPath);

        var showInnerPath = new FileShowInnerHandlerPath();
        var showInnerMode = new FileShowInnerHandlerMode();
        showInnerPath.AddNext(showInnerMode);

        var goToInnerPath = new GoToInnerPathHandler();

        var listInnerDepth = new TreeListInnerHandlerDepth();

        var fileCopyHandler = new FileCopyHandler(copyInnerSource);
        ICommandHandler fileDeleteHandler = new FileDeleteHandler(deleteInner);
        ICommandHandler fileRename = new FileRenameHandler(renameInnerName);
        ICommandHandler fileShow = new FileShowHandler(showInnerPath);
        ICommandHandler treeGoToHandler = new TreeGoToHandler(goToInnerPath);
        ICommandHandler treeListHandler = new TreeListHandler(listInnerDepth);
        ICommandHandler fileMoveHandler = new FileMoveHandler(moveInnerSource);

        fileCopyHandler.AddNext(fileDeleteHandler);
        fileCopyHandler.AddNext(fileRename);
        fileCopyHandler.AddNext(fileShow);
        fileCopyHandler.AddNext(treeGoToHandler);
        fileCopyHandler.AddNext(treeListHandler);
        fileCopyHandler.AddNext(fileMoveHandler);

        _handler = fileCopyHandler;
    }

    public ICommand? Run(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (_handler.HandleCommand(i, args, _fileSystem) is not null)
            {
                return _handler.HandleCommand(i, args, _fileSystem);
            }
        }

        return null;
    }
}