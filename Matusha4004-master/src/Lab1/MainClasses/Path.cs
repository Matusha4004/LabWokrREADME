using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.PartsOfPath;
using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.MainClasses;

public class Path
{
    public Time Accuracy { get; init; }

    private IEnumerable<IComponentOfPath> PartOfPaths { get; init; }

    private Train Train { get; init; }

    public Path(IEnumerable<IComponentOfPath> partOfPaths, Train train, EndOfPath endPath, Time accuracy)
    {
        IEnumerable<IComponentOfPath> componentOfPaths = partOfPaths.Append(endPath);

        PartOfPaths = componentOfPaths;

        Train = train;

        Accuracy = accuracy;
    }

    public ResultOfPath Start()
    {
        var timeOfCompleting = new Time(0);

        foreach (IComponentOfPath parts in PartOfPaths)
        {
            TrainOnComponentOfPathResult trainOnComponentOfPathResult = parts.TrainOnPath(Train, Accuracy);
            if (trainOnComponentOfPathResult is TrainOnComponentOfPathResult.Success success)
            {
                timeOfCompleting = new Time(timeOfCompleting.Value + success.Value.Value);
            }
            else
            {
                ResultOfPath resultOfPath = new ResultOfPath.Failure();
                return resultOfPath;
            }
        }

        return new ResultOfPath.Success(timeOfCompleting);
    }
}