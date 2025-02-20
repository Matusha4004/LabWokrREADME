using Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;
using Itmo.ObjectOrientedProgramming.Lab2.PartsOfEducatedProgram;
using Itmo.ObjectOrientedProgramming.Lab2.ResultType;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders.Subject;

public class ExamSubjectBuilder : SubjectBuilder
{
    public Mark? MarkForExam { get; private set; }

    public ExamSubjectBuilder WithMarkForExam(Mark markForExam)
    {
        MarkForExam = markForExam;
        return this;
    }

    public ExamSubjectBuilder(Author author)
    {
        Author = author;
    }

    public override ISubject Build()
    {
        var subjectForReturn = new ExamSubject(
            new Identifier(Guid.NewGuid()),
            Name ?? throw new ArgumentNullException(),
            LabWorks ?? throw new ArgumentNullException(),
            LectureMaterials ?? throw new ArgumentNullException(),
            MarkForExam ?? throw new ArgumentNullException(),
            Author ?? throw new ArgumentNullException());

        Author.AppendWork(subjectForReturn);

        int sum = 0;

        foreach (Labwork labwork in LabWorks)
        {
            sum += labwork.Mark.Value;
        }

        sum += MarkForExam.Value;

        if (sum == 100) ResultOfCreating = new ResultOfCreatingEducatedProgram.Success();
        else ResultOfCreating = new ResultOfCreatingEducatedProgram.FailedNot100MarkInEducatedProgram(sum);

        return subjectForReturn;
    }
}