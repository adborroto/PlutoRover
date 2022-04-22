using PlutoRover.Domain;

namespace PlutoRover.Services;

public class TurnLeftCommand : IRoverCommand
{
    public void Execute(Rover rover)
    {
        if (rover == null)
            throw new ArgumentNullException("invalid rover");
        rover.TurnLeft();
    }

    public char CommandName => 'L';
}