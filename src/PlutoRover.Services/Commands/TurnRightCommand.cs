using PlutoRover.Domain;

namespace PlutoRover.Services;

public class TurnRightCommand : IRoverCommand
{
    public void Execute(Rover rover)
    {
        if (rover == null)
            throw new ArgumentNullException("invalid rover");
        rover.TurnRight();
    }

    public char CommandName => 'R';
}