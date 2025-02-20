using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Subject;

public class TestSubjectBuilder : SubjectBuilder
{
    public Mark? MarkForSuccess { get; private set; }

    public TestSubjectBuilder WithMarkForSuccess(Mark markForExam)
    {
        MarkForSuccess = markForExam;
        return this;
    }

    public TestSubjectBuilder(Author author)
    {
        Author = author;
    }

    public override ISubject Build()
    {
        var subjectForReturn = new TestSubject(
            new Identifier(Guid.NewGuid()),
            Name ?? throw new ArgumentNullException(),
            LabWorks ?? throw new ArgumentNullException(),
            LectureMaterials ?? throw new ArgumentNullException(),
            MarkForSuccess ?? throw new ArgumentNullException(),
            Author ?? throw new ArgumentNullException());

        Author.AppendWork(subjectForReturn);

        int sum = 0;

        foreach (Labwork labwork in LabWorks)
        {
            sum += labwork.Mark.Value;
        }

        if (sum == 100) ResultOfCreating = new ResultOfCreatingEducatedProgram.Success();
        else ResultOfCreating = new ResultOfCreatingEducatedProgram.FailedNot100MarkInEducatedProgram(sum);

        return subjectForReturn;
    }
}