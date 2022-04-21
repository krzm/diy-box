using CLIHelper;

namespace DiyBox.Integration.Tests;

public class InputMock
: IInput
{
    public string? ReadLine()
    {
        return "Enter";
    }
}
