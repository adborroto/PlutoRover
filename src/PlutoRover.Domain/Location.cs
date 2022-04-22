namespace PlutoRover.Domain;

public class Location
{
    public Location(int x, int y, CardinalPoint facing)
    {
        Position = new Position(x, y);
        Direction = Direction.NewFacing(facing);
    }

    public Position Position { get; private set; }
    public Direction Direction { get; private set; }

    public void UpdatePosition(Position newPosition)
    {
        Position = newPosition ?? throw new ArgumentNullException("invalid position");
    }

    public void UpdateDirection(Direction newDirection)
    {
        Direction = newDirection ?? throw new ArgumentNullException("invalid direction");
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Location otherLocation)
            return false;

        return otherLocation.Position.Equals(Position) && otherLocation.Direction.Equals(Direction);
    }

    public override string ToString()
    {
        return $"({Position.X},{Position.Y},{Direction})";
    }
}