using PlutoRover.Domain;
using PlutoRover.Domain.Core;

namespace PlutoRover.Services;

public class RoverControl : IRoverControl
{
    private Rover _rover;
    private readonly IRoverCommandProvider _commandProvider;

    public RoverControl(IRoverCommandProvider commandProvider, Rover rover)
    {
        _rover = rover;
        _commandProvider = commandProvider;
    }

    public void Execute(string commands)
    {
        Check.NotNull(commands, new ArgumentNullException("invalid comamnds"));

        foreach (var command in commands)
        {
            Execute(command);
        }
    }

    private void Execute(char command)
    {
        var roverCommand = _commandProvider.GetCommand(command);
        if (roverCommand == null)
            throw new CommandNotFoundException(command);

        roverCommand.Execute(_rover);
    }
}