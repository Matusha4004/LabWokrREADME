namespace Itmo.ObjectOrientedProgramming.Lab2.InterfacesLab2;

public interface IClone<T> where T : IClone<T>
{
    T Clone(Author newAuthor);
}