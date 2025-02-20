using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.LabAndLecture;
using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;
using Xunit;

namespace Lab2.Tests;

public class TestChange
{
    [Fact]

    public void TestFailedChangeWithDifferentAuthor()
    {
        var repo = new Repository();
        var author1 = new Author(new Name("John Doe"));

        var author2 = new Author(new Name("Koeken Koeken"));

        var lectureBuilder = new LectureBuilder(author1);
        ILecture firstLecture = lectureBuilder.WithContent(new Content("Some content"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("First Lecture"))
            .Build();
        repo.AddToRepository(firstLecture);

        Assert.True(firstLecture.ChangeInPartOfEducationalProgram(new Description("New Some Description"), author2) is ResultOfChangingPartOfEducationalProgram.FailureDifferentAuthor);
    }
}