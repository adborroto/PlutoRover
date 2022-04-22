using PlutoRover.Domain;

namespace PlutoRover.Services;

public class MoveBackwardCommand : IRoverCommand
{
    public void Execute(Rover rover)
    {
        if (rover == null)
            throw new ArgumentNullException("invalid rover");
        rover.MoveBackward();
    }

    public char CommandName => 'B';
}