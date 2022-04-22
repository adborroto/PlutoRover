using PlutoRover.Domain.Core;

namespace PlutoRover.Domain;

public class Rover
{
    private Location _location;
    private readonly Grid _grid;

    private readonly Position[] _moves =
        {new(0, 1), new(1, 0), new(0, -1), new(-1, 0)};

    public Rover(Grid grid)
    {
        _grid = grid;
    }

    public Location Location => _location;

    public void Land(int x, int y, CardinalPoint facing)
    {
        _location = new Location(x, y, facing);
    }

    public void MoveForward()
    {
        Check.NotNull(_location, new RoverHasNotLandedException());

        var move = CalculateMoveBasedOnMyFacingDirection();
        var newPosition = move + Location.Position;

        if (!_grid.IsInside(newPosition))
            throw new InvalidMoveException();

        Location.UpdatePosition(newPosition);
    }

    public void MoveBackward()
    {
        Check.NotNull(_location, new RoverHasNotLandedException());

        var move = CalculateMoveBasedOnMyFacingDirection();
        var newPosition = (move * -1) + Location.Position;

        if (!_grid.IsInside(newPosition))
            throw new InvalidMoveException();

        Location.UpdatePosition(newPosition);
    }

    public void TurnLeft()
    {
        Check.NotNull(_location, new RoverHasNotLandedException());

        var newDirection = Location.Direction.SpinLeft();
        Location.UpdateDirection(newDirection);
    }

    public void TurnRight()
    {
        Check.NotNull(_location, new RoverHasNotLandedException());

        var newDirection = Location.Direction.SpinRight();
        Location.UpdateDirection(newDirection);
    }

    private Position CalculateMoveBasedOnMyFacingDirection()
    {
        return _moves[(int)Location.Direction.Facing];
    }
}