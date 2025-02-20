namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDirectory;

public class Display : IDisplay
{
    public DisplayDriver Driver { get; init; }

    public void TakeMessage(string message)
    {
        Driver.DisplayClear();
        Driver.PrintInConsole(message);
    }

    public Display(DisplayDriver driver)
    {
        Driver = driver;
    }
}