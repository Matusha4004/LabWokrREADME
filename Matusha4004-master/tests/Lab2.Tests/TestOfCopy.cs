using Itmo.ObjectOrientedProgramming.Lab2;
using Itmo.ObjectOrientedProgramming.Lab2.Builders.LabAndLecture;
using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;
using Xunit;

namespace Lab2.Tests;

public class TestOfCopy
{
    [Fact]

    public void TestSuccessCopy()
    {
        var repo = new Repository();
        var author1 = new Author(new Name("John Doe"));

        var author2 = new Author(new Name("Koeken Koeken"));

        var lectureBuilder = new LectureBuilder(author1);

        ILecture firstLecture = lectureBuilder
            .WithContent(new Content("Some content"))
            .WithDescription(new Description("Some description"))
            .WithName(new Name("Koeken Koeken"))
            .Build();

        repo.AddToRepository(firstLecture);

        if (firstLecture is Lecture copyOfLecture)
        {
            Lecture someNewCopy = copyOfLecture.Clone(author2);
            Assert.True(someNewCopy.IdentifierMother == firstLecture.Id);
        }
    }
}