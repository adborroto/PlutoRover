namespace PlutoRover.Services;

public interface IRoverCommandProvider
{
    public IRoverCommand? GetCommand(char commandName);
}