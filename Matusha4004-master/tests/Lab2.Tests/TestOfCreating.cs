using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.LabAndLecture;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.Subject;
using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;
using Xunit;

namespace Lab2.Tests;

public class TestOfCreating
{
    [Fact]
    public void TestOfCreatingSuccessWith100Mark()
    {
        var repo = new Repository();

        var author1 = new Author(new Name("John Doe"));

        var labBuilder1 = new LabBuilder(author1);
        ILabwork firstLab = labBuilder1
            .WithMark(new Mark(33))
            .WithMarkCriteria(new MarkCriteria("Some criteria"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("Some name"))
            .Build();

        repo.AddToRepository(firstLab);

        ILabwork secondLab = labBuilder1
            .WithMark(new Mark(33))
            .WithMarkCriteria(new MarkCriteria("Some differnt criteria"))
            .WithDescription(new Description("Some differnt description"))
            .WithName(new Name("Some differnt name"))
            .Build();

        repo.AddToRepository(secondLab);

        var listOfLabs = new List<Labwork>();
        listOfLabs.Add((Labwork)firstLab);
        listOfLabs.Add((Labwork)secondLab);

        var lectureBuilder = new LectureBuilder(author1);
        ILecture firstLecture = lectureBuilder.WithContent(new Content("Some content"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("First Lecture"))
            .Build();
        repo.AddToRepository(firstLecture);

        var listOfLectures = new List<Lecture>();

        listOfLectures.Add((Lecture)firstLecture);

        var subjectBuilder1 = new ExamSubjectBuilder(author1);

        IChangingPart examSubject = subjectBuilder1
            .WithMarkForExam(new Mark(34))
            .WithLabWorks(listOfLabs)
            .WithLectures(listOfLectures)
            .WithName(new Name("Some name"))
            .Build();

        Assert.True(subjectBuilder1.ResultOfCreating is ResultOfCreatingEducatedProgram.Success);
    }

    [Fact]
    public void TestOfCreatingFailureWith101Mark()
    {
        var repo = new Repository();

        var author1 = new Author(new Name("John Doe"));

        var labBuilder1 = new LabBuilder(author1);
        ILabwork firstLab = labBuilder1
            .WithMark(new Mark(33))
            .WithMarkCriteria(new MarkCriteria("Some criteria"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("Some name"))
            .Build();

        repo.AddToRepository(firstLab);

        ILabwork secondLab = labBuilder1
            .WithMark(new Mark(34))
            .WithMarkCriteria(new MarkCriteria("Some differnt criteria"))
            .WithDescription(new Description("Some differnt description"))
            .WithName(new Name("Some differnt name"))
            .Build();

        repo.AddToRepository(secondLab);

        var listOfLabs = new List<Labwork>();
        listOfLabs.Add((Labwork)firstLab);
        listOfLabs.Add((Labwork)secondLab);

        var lectureBuilder = new LectureBuilder(author1);
        ILecture firstLecture = lectureBuilder.WithContent(new Content("Some content"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("First Lecture"))
            .Build();
        repo.AddToRepository(firstLecture);

        var listOfLectures = new List<Lecture>();

        listOfLectures.Add((Lecture)firstLecture);

        var subjectBuilder1 = new ExamSubjectBuilder(author1);

        IChangingPart examSubject = subjectBuilder1
            .WithMarkForExam(new Mark(34))
            .WithLabWorks(listOfLabs)
            .WithLectures(listOfLectures)
            .WithName(new Name("Some name"))
            .Build();

        Assert.True(subjectBuilder1.ResultOfCreating is ResultOfCreatingEducatedProgram.FailedNot100MarkInEducatedProgram);
    }
}