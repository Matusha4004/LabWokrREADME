using Itmo.ObjectOrientedProgramming.Lab2.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

public interface IChangingPart
{
    ResultOfChangingPartOfEducationalProgram ChangeInPartOfEducationalProgram(IObjectCanBeChanged objectCanBeChanged, Author author);
}