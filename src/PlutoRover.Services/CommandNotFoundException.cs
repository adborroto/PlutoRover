namespace PlutoRover.Services;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException(char command) : base($"command `{command}` not found")
    {
    }
}