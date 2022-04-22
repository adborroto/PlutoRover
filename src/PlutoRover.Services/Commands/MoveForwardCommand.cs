using PlutoRover.Domain;

namespace PlutoRover.Services;

public class MoveForwardCommand : IRoverCommand
{
    public void Execute(Rover rover)
    {
        if (rover == null)
            throw new ArgumentNullException("invalid rover");
        rover.MoveForward();
    }

    public char CommandName => 'F';
}