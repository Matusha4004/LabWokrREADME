using Itmo.ObjectOrientedProgramming.Lab1.InterfacesOfPart;
using Itmo.ObjectOrientedProgramming.Lab1.MainClasses;
using Itmo.ObjectOrientedProgramming.Lab1.PartsOfPath;
using Itmo.ObjectOrientedProgramming.Lab1.ResultType;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObject;
using System.Collections.ObjectModel;
using Xunit;
using Path = Itmo.ObjectOrientedProgramming.Lab1.MainClasses.Path;

namespace Lab1.Tests;

public class TrainOnPart_ShouldReturnExpectedResult
{
    [Fact]
    public void TestSuccessPowerWayAndBasicWay()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(1000)), new Time(1));

        ResultOfPath result = path.Start();

        double timeOfCompleting = 0;

        if (result is ResultOfPath.Success qresult)
        {
            timeOfCompleting = qresult.Value.Value;
        }

        Assert.True(result is ResultOfPath.Success);
        Assert.Equal(7, timeOfCompleting);
    }

    [Fact]
    public void TestFailPowerWayAndBasicWayBecauseCupOfSpeed()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(1)), new Time(1));

        ResultOfPath result = path.Start();

        Assert.True(result is ResultOfPath.Failure);
    }

    [Fact]
    public void TestSuccessPowerWayAndBasicWayAndStation()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));
        partsOfPath.Add(new Station(new Speed(1000), new Time(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(1000)), new Time(1));

        ResultOfPath result = path.Start();

        double timeOfCompleting = 0;

        if (result is ResultOfPath.Success qresult)
        {
            timeOfCompleting = qresult.Value.Value;
        }

        Assert.True(result is ResultOfPath.Success);
        Assert.Equal(20, timeOfCompleting);
    }

    [Fact]
    public void TestFailPowerWayAndStationBecauseCupOfSpeedOnStation()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(10)));
        partsOfPath.Add(new Station(new Speed(1), new Time(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(10000)), new Time(1));

        ResultOfPath result = path.Start();

        Assert.True(result is ResultOfPath.Failure);
    }

    [Fact]
    public void TestFailPowerWayAndStationBecauseCupOfSpeedOnEnd()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));
        partsOfPath.Add(new Station(new Speed(10000), new Time(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(1)), new Time(1));

        ResultOfPath result = path.Start();

        Assert.True(result is ResultOfPath.Failure);
    }

    [Fact]
    public void TestSuccessWithManyWays()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(100)));
        partsOfPath.Add(new BasicWay(new Distance(100)));
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(-10)));
        partsOfPath.Add(new Station(new Speed(38), new Time(10)));
        partsOfPath.Add(new BasicWay(new Distance(100)));
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(100)));
        partsOfPath.Add(new BasicWay(new Distance(100)));
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(-10)));

        var train = new Train(new Power(100), new Weight(10));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(66)), new Time(1));

        ResultOfPath result = path.Start();

        double timeOfCompliting = 0;

        if (result is ResultOfPath.Success qresult)
        {
            timeOfCompliting = qresult.Value.Value;
        }

        Assert.True(result is ResultOfPath.Success);
        Assert.Equal(29, timeOfCompliting);
    }

    [Fact]
    public void TestFailBasicWay()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new BasicWay(new Distance(100)));

        var train = new Train(new Power(100), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(1)), new Time(1));

        ResultOfPath result = path.Start();

        Assert.True(result is ResultOfPath.Failure);
    }

    [Fact]
    public void TestFailTwoWays()
    {
        var partsOfPath = new Collection<IComponentOfPath>();
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(100)));
        partsOfPath.Add(new PowerWay(new Distance(100), new Power(-200)));

        var train = new Train(new Power(1000), new Weight(1));

        var path = new Path(partsOfPath, train, new EndOfPath(new Speed(10000)), new Time(1));

        ResultOfPath result = path.Start();

        Assert.True(result is ResultOfPath.Failure);
    }
}