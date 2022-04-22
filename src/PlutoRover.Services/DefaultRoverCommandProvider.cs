using PlutoRover.Services;

namespace PlutoRover.Domain.Tests;

public class DefaultRoverCommands : IRoverCommandProvider
{
    private IEnumerable<IRoverCommand> _commands = new List<IRoverCommand>
        {new MoveForwardCommand(), new MoveBackwardCommand(), new TurnLeftCommand(), new TurnRightCommand()};

    private IDictionary<char, IRoverCommand> _map;
    public DefaultRoverCommands()
    {
        _map = _commands.ToDictionary(c => c.CommandName, c => c);
    }

    public IRoverCommand? GetCommand(char commandName)
    {
        return _commands.FirstOrDefault(x => x.CommandName == commandName);
    }
}